﻿namespace NZag.Core

open NZag.Utilities
open BoundNodeVisitors

module Graphs =

    let Entry = -1
    let Exit = -2

    type Block<'T> =
      { ID : int
        Data : 'T
        Predecessors : int list
        Successors : int list }

        member x.IsEntry = x.ID = Entry
        member x.IsExit = x.ID = Exit

    type Graph<'T> =
      { Tree : BoundTree
        Blocks : Block<'T> list }

    type Builder<'T> =
      { AddNode : int -> unit;
        AddEdge : int -> int -> unit;
        AddEdgeToNext : int -> unit;
        GetData : int -> 'T option
        UpdateData : int -> 'T option -> unit }

    let computeBlocks (buildBlocks : Builder<'T> -> unit) (finalizeData : 'T option -> 'U) : Block<'U> list =

        let compareIds x y = 
            if x = y then 0
            elif x = Entry then System.Int32.MinValue
            elif x = Exit then System.Int32.MaxValue
            elif y = Entry then System.Int32.MaxValue
            elif y = Exit then System.Int32.MinValue
            else compare x y

        let map = SortedList.createWithCompare compareIds

        let get id =
            map |> Dictionary.find id

        let next id =
            let nextId = id + 1
            if map |> Dictionary.contains nextId then nextId
            else Exit

        let addNode id =
            let pred = SortedSet.create()
            let succ = SortedSet.create()

            map |> Dictionary.add id (pred, succ, None)

        let addEdge id1 id2 =
            let (_,succ,_) = get id1
            let (pred,_,_) = get id2

            succ |> SortedSet.add id2
            pred |> SortedSet.add id1

        let addEdgeToNext id =
            addEdge id (next id)

        let getData id  =
            let (_,_,data) = get id
            data

        let updateData id (data : 'T option) =
            let (pred,succ,_) = get id
            map.[id] <- (pred,succ,data)

        addNode Entry
        addNode Exit

        let builder =
          { AddNode = addNode;
            AddEdge = addEdge;
            AddEdgeToNext = addEdgeToNext;
            GetData = getData;
            UpdateData = updateData }

        buildBlocks builder

        addEdgeToNext Entry

        let createBlock (id, (pred,succ,data)) =
          { ID = id
            Data = data |> finalizeData
            Predecessors = pred |> SortedSet.toList
            Successors = succ |> SortedSet.toList }

        map
            |> Dictionary.toList
            |> List.map createBlock

    type ControlFlowData =
      { Statements : Statement list }

    [<CompiledNameAttribute("BuildControlFlowGraph")>]
    let buildControlFlowGraph (tree : BoundTree) =

        let blocks =
            computeBlocks
                (fun builder ->
                    // First, add all nodes to the map.
                    do tree |> walkTree
                        (fun s -> match s with | LabelStmt(label) -> builder.AddNode label | _ -> ())
                        (fun e -> ())

                    // Next, add all data (i.e. statements) and edges.
                    let currentId = ref Entry
                    let lastStatement = ref None

                    do tree |> walkTree
                        (fun s ->
                            let mutable id = !currentId

                            match s with
                            | LabelStmt(label) ->
                                match !lastStatement with
                                | Some(JumpStmt(_))
                                | Some(ReturnStmt(_))
                                | Some(QuitStmt) -> ()
                                | _ -> builder.AddEdge id label

                                id <- label
                                currentId := label
                            | JumpStmt(label) ->
                                builder.AddEdge id label
                            | BranchStmt(_,_,_) ->
                                builder.AddEdgeToNext id
                            | ReturnStmt(_)
                            | QuitStmt ->
                                builder.AddEdge id Exit
                            | _ -> ()

                            let slist =
                                match builder.GetData id with
                                | Some(slist) -> slist
                                | None -> ResizeArray.create()

                            slist |> ResizeArray.add s
                            builder.UpdateData id (Some(slist))

                            lastStatement := Some(s))
                        (fun e -> ()))
                (fun data ->
                    match data with
                    | Some(slist) -> { Statements = slist |> List.ofSeq }
                    | None -> { Statements = List.empty })

        { Tree = tree; Blocks = blocks }

    type Definition =
      { Temp : int
        BlockID : int
        StatementIndex : int
        Value : Expression }

        override x.ToString() =
            sprintf "Definition: Temp = %d; BlockID = %d; StatementIndex = %d" x.Temp x.BlockID x.StatementIndex

    type StatementFlowInfo =
      { Statement : Statement
        InDefinitions : Set<Definition>
        OutDefinitions : Set<Definition> }

    type DefinitionData =
      { Statements : StatementFlowInfo list
        InDefinitions : Set<Definition>
        OutDefinitions : Set<Definition> }

    type ReachingDefinitions =
      { Definitions : Map<int, Set<Definition>>
        Usages : Map<Definition, int>
        Graph : Graph<DefinitionData> }

    [<CompiledNameAttribute("ComputeReachingDefinitions")>]
    let computeReachingDefinitions (graph : Graph<ControlFlowData>) =
        let entry,rest =
            match graph.Blocks with
            | [] | _::[] | _::_::[] -> failcompile "Expected at least three nodes in graph (entry, exit and some basic block)"
            | h::t -> h,t

        let statementsMap = Dictionary.createFrom (graph.Blocks |> List.map (fun b -> b.ID, ResizeArray.create()))
        let insMap = Dictionary.createFrom (graph.Blocks |> List.map (fun b -> b.ID, Set.empty))
        let outsMap = Dictionary.createFrom (graph.Blocks |> List.map (fun b -> b.ID, Set.empty))
        let tempToDefinitionsMap = Dictionary.create()
        let definitionToUsagesMap = Dictionary.create()

        let computeIns b =
            b.Predecessors
            |> List.map (fun p -> outsMap.[p])
            |> List.fold (fun res s -> Set.union res s) Set.empty

        let computeOuts (b : Block<ControlFlowData>) =
            let oldIns = insMap.[b.ID]
            let ins = computeIns b
            if oldIns <> ins then
                insMap.[b.ID] <- ins

            let statements = statementsMap.[b.ID]
            let generated = ref Set.empty
            let killed = ref Set.empty
            let currentOuts = ref (Set.union !generated (Set.difference ins !killed))

            b.Data.Statements |> List.iteri (fun i s ->
                let currentIns = !currentOuts

                // First, get the flow info for this statement
                let info =
                    match s with
                    | WriteTempStmt(t,e) ->
                        let definitionSet =
                            tempToDefinitionsMap
                            |> Dictionary.getOrAdd t (fun () -> Set.empty)

                        let definition = { Temp = t
                                           BlockID = b.ID
                                           StatementIndex = i
                                           Value = e }

                        tempToDefinitionsMap.[t] <- definitionSet |> Set.add definition

                        generated := !generated |> Set.filter (fun d -> d.Temp <> t)
                        killed := !killed |> Set.filter (fun d -> d.Temp = t)
                        generated := !generated |> Set.add definition
                        currentOuts := Set.union !generated (Set.difference currentIns !killed)
                    | s -> ()

                    {Statement = s; InDefinitions = currentIns; OutDefinitions = !currentOuts}

                // Next, find any definition usages for this statement
                s |> walkStatement
                    (fun s -> ())
                    (fun e ->
                        match e with
                        | TempExpr(t) ->
                            let defs = currentIns |> Set.filter (fun d -> d.Temp = t)
                            for def in defs do
                                let usages = match definitionToUsagesMap |> Dictionary.tryFind def with
                                             | Some(u) -> u + 1
                                             | None -> 1

                                definitionToUsagesMap.[def] <- usages

                        | e -> ())

                statements.Add(info))

            !currentOuts

        let stop = ref false
        while not (!stop) do
            stop := true

            rest
            |> List.iter (fun b ->
                let currentOuts = outsMap |> Dictionary.find b.ID
                let newOuts = computeOuts b
                if currentOuts <> newOuts then
                    outsMap.[b.ID] <- newOuts
                    stop := false)

        let blocks =
            graph.Blocks
            |> List.map (fun b -> { ID = b.ID
                                    Data = { Statements = statementsMap |> Dictionary.find b.ID |> ResizeArray.toList
                                             InDefinitions = insMap |> Dictionary.find b.ID
                                             OutDefinitions = outsMap |> Dictionary.find b.ID }
                                    Predecessors = b.Predecessors
                                    Successors = b.Successors })

        { Definitions =
            tempToDefinitionsMap 
            |> Dictionary.toList
            |> Map.ofList
          Usages =
            definitionToUsagesMap
            |> Dictionary.toMap
          Graph =
            { Tree = graph.Tree;
              Blocks = blocks } }


