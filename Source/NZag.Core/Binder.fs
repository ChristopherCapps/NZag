﻿namespace NZag.Core

open NZag.Utilities
open BoundNodeConstruction
open BoundNodeVisitors
open OperandPatterns

[<AbstractClass>]
type BoundTreeBuilder() =

    member x.AssignTemp temp value =
        let write = WriteTempStmt(temp, value)
        x.AddStatement(write)

    member x.InitTemp value =
        let temp = x.NewTemp()
        x.AssignTemp temp value
        TempExpr(temp)

    member x.MarkLabel label =
        let label = LabelStmt(label)
        x.AddStatement(label)

    member x.JumpTo label =
        let jump = JumpStmt(label)
        x.AddStatement(jump)

    member x.BranchIf condition expression label =
        let jump = JumpStmt(label)
        let branch = BranchStmt(condition, expression, jump)
        x.AddStatement(branch)

    member x.BranchIfFalse expression label =
        label |> x.BranchIf false expression

    member x.BranchIfTrue expression label =
        label |> x.BranchIf true expression

    member x.Return expression =
        let ret = ReturnStmt(expression)
        x.AddStatement(ret)

    member x.IfThenElse condition whenTrue whenFalse =
        let whenTrueLabel = x.NewLabel()
        let whenFalseLabel = x.NewLabel()
        let doneLabel = x.NewLabel()

        whenFalseLabel |> x.BranchIfFalse condition

        x.MarkLabel(whenTrueLabel)
        whenTrue()
        x.JumpTo(doneLabel)

        x.MarkLabel(whenFalseLabel)
        whenFalse()

        x.MarkLabel(doneLabel)

    abstract member AddStatement : statement:Statement -> unit
    abstract member NewTemp : unit -> int
    abstract member NewLabel : unit -> int

    abstract member Statements : List<Statement>
    abstract member TempCount : int
    abstract member LabelCount : int

    abstract member GetTree : unit -> BoundTree

type BoundTreeCreator(routine: Routine) =
    inherit BoundTreeBuilder()

    let statements = ResizeArray.create()
    let mutable tempCount = 0
    let mutable labelCount = 0

    let newLabel() =
        let newLabel = labelCount
        labelCount <- labelCount + 1
        newLabel

    let newTemp() =
        let newTemp = tempCount
        tempCount <- tempCount + 1
        newTemp

    let jumpTargetMap =
        let d = Dictionary.create()
        for a in routine.JumpTargets do
            d.Add(a, newLabel())
        d

    member x.IsJumpTarget address =
        jumpTargetMap.ContainsKey(address)

    member x.GetJumpTargetLabel address =
        jumpTargetMap.[address]

    override x.AddStatement(statement: Statement) =
        statements.Add(statement)

    override x.NewTemp() =
        newTemp()

    override x.NewLabel() =
        newLabel()

    override x.Statements = statements |> List.ofSeq
    override x.TempCount = tempCount
    override x.LabelCount = labelCount

    override x.GetTree() =
        { Statements = statements |> Seq.toList; TempCount = tempCount; LabelCount = labelCount }

type BoundTreeUpdater(tree : BoundTree) =
    inherit BoundTreeBuilder()

    let mutable statements = ResizeArray.create()
    let mutable tempCount = tree.TempCount
    let mutable labelCount = tree.LabelCount

    override x.AddStatement(statement: Statement) =
        statements.Add(statement)

    override x.NewTemp() =
        let newTemp = tempCount
        tempCount <- tempCount + 1
        newTemp

    override x.NewLabel() =
        let newLabel = labelCount
        labelCount <- labelCount + 1
        newLabel

    override x.Statements = statements |> List.ofSeq
    override x.TempCount = tempCount
    override x.LabelCount = labelCount

    member x.Update f =
        for s in tree.Statements do
            f s x

    override x.GetTree() =
        { Statements = statements |> Seq.toList; TempCount = tempCount; LabelCount = labelCount }

type InstructionBinder(memory: Memory, builder: BoundTreeCreator) =

    let packedMultiplier =
        match memory.Version with
        | 1 | 2 | 3 -> two
        | 4 | 5 | 6 | 7 -> four
        | 8 -> eight
        | v -> failcompilef "Invalid version number: %d" v

    let routinesOffset =
        int32Const (memory |> Header.readRoutinesOffset).IntValue

    let addStatement s =
        builder.AddStatement(s)

    let ret expression =
        builder.Return(expression)

    let assignTemp t v =
        builder.AssignTemp t v

    let initTemp expression =
        builder.InitTemp expression

    let ifThenElse condition whenTrue whenFalse =
        builder.IfThenElse condition whenTrue whenFalse

    let bindOperand = function
        | LargeConstantOperand(v) -> wordConst v
        | SmallConstantOperand(v) -> byteConst v
        | VariableOperand(v)      -> readVar v

    member x.BindInstruction(instruction: Instruction) =

        let branchIf expression =
            let branch =
                match instruction.Branch with
                | Some(b) -> b
                | None -> failcompile "Expected instruction to have a valid branch."

            let statement =
                match branch with
                | RTrueBranch(_) -> ReturnStmt(one)
                | RFalseBranch(_) -> ReturnStmt(zero)
                | OffsetBranch(_,_) -> JumpStmt(builder.GetJumpTargetLabel(instruction.BranchAddress.Value))

            BranchStmt(branch.Condition, expression, statement)
                |> builder.AddStatement

        let store expression =
            let storeVar =
                match instruction.StoreVariable with
                | Some(v) -> v
                | None -> failcompile "Expected instruction to have a valid store variable."

            storeVar |> writeVar expression |> addStatement

        // If this instruction is a jump target, mark its label
        if builder.IsJumpTarget(instruction.Address) then
            let label = builder.GetJumpTargetLabel(instruction.Address)
            builder.MarkLabel(label)

        // Create temps for all operands
        let operandValues = instruction.Operands |> List.map bindOperand
        let operandTemps = operandValues |> List.map (fun v -> initTemp v)
        let operandMap = List.zip operandTemps operandValues |> Map.ofList

        let byRefVariable variableIndex =

            let byRefVariableFromExpression expression =
                initTemp (ReadComputedVarExpr(expression)), (fun v -> WriteComputedVarStmt(expression, v))

            let byRefVariableFromValue value =
                if value = 0uy then
                    initTemp StackPeekExpr, (fun v -> StackUpdateStmt(v))
                elif value < 16uy then
                    let varIndex = byteConst (value - 1uy)
                    initTemp (ReadLocalExpr(varIndex)), (fun v -> WriteLocalStmt(varIndex, v))
                else
                    let varIndex = byteConst (value - 16uy)
                    initTemp (ReadGlobalExpr(varIndex)), (fun v -> WriteGlobalStmt(varIndex, v))

            let byRefVariableFromOperandTemp temp =
                match operandMap |> Map.tryFind temp with
                | Some(ConstantExpr(Byte(b))) ->
                    byRefVariableFromValue b
                | Some(e) ->
                    byRefVariableFromExpression e
                | _ ->
                    failcompile "Expected operand temp for by-ref variable index"

            match variableIndex with
            | ConstantExpr(Byte(b)) ->
                byRefVariableFromValue b
            | TempExpr(_) as t ->
                byRefVariableFromOperandTemp t
            | e ->
                byRefVariableFromExpression e

        // Bind the instruction
        match (instruction.Opcode.Name, instruction.Opcode.Version, operandTemps) with
        | "add", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            store (left .+. right)

        | "call", Any, OpAndList(address, args)
        | "call_vs", Any, OpAndList(address, args) ->

            ifThenElse (address .=. zero)
                (fun () ->
                    store zero)
                (fun () ->
                    let baseAddress = initTemp (address .*. packedMultiplier)
                    let address = 
                        if memory.Version = 6 || memory.Version = 7 then
                            initTemp (baseAddress .+. routinesOffset)
                        else
                            baseAddress

                    store (CallExpr(address, args)))

        | "dec", Any, Op1(varIndex) ->
            let read, write = byRefVariable varIndex

            let read = initTemp (read |> toInt16)
            write (read .-. (one |> toInt16)) |> addStatement

        | "div", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            store (left ./. right)

        | "inc", Any, Op1(varIndex) ->
            let read, write = byRefVariable varIndex

            let read = initTemp (read |> toInt16)
            write (read .+. (one |> toInt16)) |> addStatement

        | "je", Any, OpAndList(left, values) ->
            // je can have 2 to 4 operands to test for equality.
            let conditions = values |> List.map (fun v -> initTemp (left .=. v))

            branchIf
                ((List.tail conditions)
                |> List.fold
                    (fun res c -> res .|. c)
                    (List.head conditions))

        | "jg", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            branchIf (left .>. right)

        | "jl", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            branchIf (left .<. right)

        | "jump", Any, Op1(_) ->
            let label = builder.GetJumpTargetLabel(instruction.JumpAddress)
            builder.JumpTo(label)

        | "jz", Any, Op1(left) ->
            branchIf (left .=. zero)

        | "loadb", Any, Op2(address,offset) ->
            let address = initTemp (address .+. offset)

            store (ReadMemoryByteExpr(address))

        | "loadw", Any, Op2(address,offset) ->
            let offset = initTemp (offset .*. two)
            let address = initTemp (address .+. offset)

            store (ReadMemoryWordExpr(address))

        | "mod", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            store (left .%. right)

        | "mul", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            store (left .*. right)

        | "new_line", Any, NoOps ->
            textConst "\n" |> printText |> addStatement

        | "print", Any, NoOps ->
            textConst instruction.Text.Value |> printText |> addStatement

        | "print_obj", Any, Op1(obj) ->
            objectName obj |> printText |> addStatement

        | "quit", Any, NoOps ->
            QuitStmt |> addStatement

        | "random", Any, Op1(range) ->
            let range = initTemp (range |> toInt16)

            ifThenElse (range .>. zero)
                (fun () ->
                    store (random range))
                (fun () ->
                    randomize range |> addStatement
                    store zero)

        | "ret", Any, Op1(value) ->
            ret value

        | "ret_popped", Any, NoOps ->
            ret StackPopExpr

        | "rfalse", Any, NoOps ->
            ret zero

        | "rtrue", Any, NoOps ->
            ret one

        | "store", Any, Op2(varIndex, value) ->
            let read, write = byRefVariable varIndex

            write value |> addStatement

        | "storeb", Any, Op3(address, offset, value) ->
            let address = initTemp (address .+. offset)

            WriteMemoryByteStmt(address, value) |> addStatement

        | "storew", Any, Op3(address, offset, value) ->
            let offset = initTemp (offset .*. two)
            let address = initTemp (address .+. offset)

            WriteMemoryWordStmt(address, value) |> addStatement

        | "sub", Any, Op2(left, right) ->
            let left = initTemp (left |> toInt16)
            let right = initTemp (right |> toInt16)

            store (left .-. right)

        | "test_attr", Any, Op2(obj, attribute) ->
            let attributeValue = initTemp (ReadObjectAttributeExpr(obj, attribute))

            branchIf (attributeValue .=. one)

        | (n,k,ops) ->
            runtimeException "Unsupported opcode: %s (v.%d) with %d operands" n k ops.Length |> addStatement

type RoutineBinder(memory: Memory) =

    let sortLabels tree =
        let nextLabelIndex = ref 0
        let labels = Dictionary.create()

        // First, collect the existing labels and create new ones
        tree |> walkTree
            (fun s ->
                match s with
                | LabelStmt(l) ->
                    let newLabel = !nextLabelIndex
                    labels |> Dictionary.add l newLabel
                    incr nextLabelIndex
                | _ -> ())
            (fun e -> ())

        // Next, rewrite the tree, replacing the old labels with new ones
        tree |> rewriteTree
            (fun s -> 
                match s with
                | LabelStmt(l) -> LabelStmt(labels.[l])
                | JumpStmt(l) -> JumpStmt(labels.[l])
                | s -> s)
            (fun e -> e)

    let sortTemps tree =
        let nextTempIndex = ref 0
        let temps = Dictionary.create()

        let getOrAddTemp t =
            match temps |> Dictionary.tryFind t with
            | Some(t) -> t
            | None    -> let newTemp = !nextTempIndex
                         temps |> Dictionary.add t newTemp
                         incr nextTempIndex
                         newTemp

        // Rewrite the tree's statements, replacing old temps with new ones
        let rewriteTemps s =
            s |> rewriteStatement
                (fun s -> 
                    match s with
                    | WriteTempStmt(t,e) ->
                        let newTemp = getOrAddTemp t
                        WriteTempStmt(newTemp,e)
                    | s -> s)
                (fun e ->
                    match e with
                    | TempExpr(t) ->
                        let newTemp = getOrAddTemp t
                        TempExpr(newTemp)
                    | e -> e)

        let newStatements = tree.Statements |> List.map rewriteTemps

        { Statements = newStatements; TempCount = !nextTempIndex; LabelCount = tree.LabelCount }

    let updateTree f tree =
        let updater = new BoundTreeUpdater(tree)

        updater.Update f

        updater.GetTree()

    let lower_GlobalVariableReadsAndWrites tree =
        let globalVariableTableAddress =
            let x = memory |> Header.readGlobalVariableTableAddress
            int32Const x.IntValue

        tree |> updateTree (fun s updater ->
            let computeGlobalVariableAddress index =
                let x = updater.InitTemp(index .*. two)
                updater.InitTemp(x .+. globalVariableTableAddress)

            let s' =
                s |> rewriteStatement
                    (fun s ->
                        match s with
                        | WriteGlobalStmt(i,v) -> writeWord (computeGlobalVariableAddress i) v
                        | s -> s)
                    (fun e ->
                        match e with
                        | ReadGlobalExpr(i) -> readWord (computeGlobalVariableAddress i)
                        | e -> e)

            updater.AddStatement(s'))

    let optimize_PropagateConstants tree =
        let graph = Graphs.buildControlFlowGraph tree
        let reachingDefinitions = Graphs.computeReachingDefinitions graph

        let block = ref None
        let index = ref 0

        let setBlock id =
            block := Some(reachingDefinitions.Graph.Blocks |> List.find (fun b -> b.ID = id))

        let getDefinitions t =
            match !block with
            | Some(b) ->
                b.Data.Statements.[!index].InDefinitions
                    |> Set.filter (fun d -> d.Temp = t)
                    |> Set.map (fun d -> d.Value)
                    |> Set.toList
            | None ->
                failcompile "Couldn't find statement info"

        tree |> updateTree (fun s updater ->
            let s' =
                s |> rewriteStatement
                    (fun s ->
                        match s with
                        | LabelStmt(l) ->
                            index := 0
                            setBlock(l)
                            incr index
                            s
                        | s ->
                            incr index
                            s)
                    (fun e ->
                        match e with
                        | TempExpr(t) ->
                            // If this temp only has a single definition of a constant expression
                            // at this point, use the constant.
                            match getDefinitions t with
                            | [ConstantExpr(c) as v] -> v
                            | _ -> e
                        | e -> e)

            updater.AddStatement(s'))

    let optimize_FoldConstants tree =
        let binaryOp l r k =
            match k with
            | BinaryOperationKind.Add         -> Some(wordConst (uint16 ((int16 l) + (int16 r))))
            | BinaryOperationKind.Subtract    -> Some(wordConst (uint16 ((int16 l) - (int16 r))))
            | BinaryOperationKind.Multiply    -> Some(wordConst (uint16 ((int16 l) * (int16 r))))
            | BinaryOperationKind.Divide      -> Some(wordConst (uint16 ((int16 l) / (int16 r))))
            | BinaryOperationKind.Remainder   -> Some(wordConst (uint16 ((int16 l) % (int16 r))))
            | BinaryOperationKind.Or          -> Some(wordConst (uint16 l ||| uint16 r))
            | BinaryOperationKind.And         -> Some(wordConst (uint16 l &&& uint16 r))
            | BinaryOperationKind.ShiftLeft   -> Some(wordConst (uint16 l <<< r))
            | BinaryOperationKind.ShiftRight  -> Some(wordConst (uint16 l >>> r))
            | BinaryOperationKind.Equal       -> if l = r then Some(one) else Some(zero)
            | BinaryOperationKind.NotEqual    -> if l <> r then Some(one) else Some(zero)
            | BinaryOperationKind.LessThan    -> if (int16 l) < (int16 r) then Some(one) else Some(zero)
            | BinaryOperationKind.GreaterThan -> if (int16 l) > (int16 r) then Some(one) else Some(zero)
            | BinaryOperationKind.AtLeast     -> if (int16 l) >= (int16 r) then Some(one) else Some(zero)
            | BinaryOperationKind.AtMost      -> if (int16 l) <= (int16 r) then Some(one) else Some(zero)
            | _ -> None

        tree |> updateTree (fun s updater ->
            let s' =
                s |> rewriteStatement
                    (fun s -> s)
                    (fun e ->
                        match e with
                        | BinaryOperationExpr(k,l,r) ->
                            match l,r with
                            | ConstantExpr(Int32Value v1),ConstantExpr(Int32Value v2) ->
                                match binaryOp v1 v2 k with
                                | Some(res) -> res
                                | None -> e
                            | _ -> e
                        | e -> e)

            updater.AddStatement(s'))

    let optimize_RemoveUnusedTemps tree =
        let graph = Graphs.buildControlFlowGraph tree
        let reachingDefinitions = Graphs.computeReachingDefinitions graph

        let block = ref None
        let index = ref 0

        let setBlock id =
            block := Some(reachingDefinitions.Graph.Blocks |> List.find (fun b -> b.ID = id))

        let hasUsages t =
            match !block with
            | Some(b) ->
                let defs =
                    reachingDefinitions.Definitions.[t]
                    |> Set.filter (fun d -> d.BlockID = b.ID && d.StatementIndex = !index)
                    |> Set.toList

                match defs with
                | [d] ->
                    match reachingDefinitions.Usages |> Map.tryFind d with
                    | Some(u) -> u > 0
                    | None -> false
                | _ -> failcompile "Expected a single definition"

            | None ->
                failcompile "Couldn't find block"

        tree |> updateTree (fun s updater ->
            let s' = match s with
                     | LabelStmt(l) ->
                         index := 0
                         setBlock(l)
                         Some(s)
                     | WriteTempStmt(t,_) ->
                         if hasUsages t then Some(s)
                         else None
                     | s ->
                         Some(s)

            incr index

            match s' with
            | Some(s') -> updater.AddStatement(s')
            | None -> ())

    let lower tree =
        tree
        |> lower_GlobalVariableReadsAndWrites

    let optimize tree =
        tree |> fixedpoint (fun tree ->
            tree
            |> optimize_PropagateConstants
            |> optimize_FoldConstants
            |> optimize_RemoveUnusedTemps)

    member x.BindRoutine(routine: Routine) =

        let builder = new BoundTreeCreator(routine)
        let binder = new InstructionBinder(memory, builder)

        for i in routine.Instructions do
            binder.BindInstruction(i)

        builder.GetTree()
            |> lower
            |> optimize
            |> sortLabels
            |> sortTemps
