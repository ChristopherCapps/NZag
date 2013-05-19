﻿
Imports NZag.Utilities

Public Module GameTests

    Class Screen
        Implements IScreen

        Private builder As New Text.StringBuilder

        Public Function WriteCharAsync(ch As Char) As Task Implements IOutputStream.WriteCharAsync
            Return Task.Factory.StartNew(Sub()
                                             builder.Append(ch)
                                         End Sub)
        End Function

        Public Function WriteTextAsync(s As String) As Task Implements IOutputStream.WriteTextAsync
            Return Task.Factory.StartNew(Sub()
                                             builder.Append(s)
                                         End Sub)
        End Function

        Public ReadOnly Property Output As String
            Get
                Return builder.ToString()
            End Get
        End Property
    End Class

    <Fact()>
    Sub RunCZech()
        Dim expected =
<![CDATA[
CZECH: the Comprehensive Z-machine Emulation CHecker, version 0.8
Test numbers appear in [brackets].

print works or you wouldn't be seeing this.

Jumps [2]: jump.je..........jg.......jl.......jz...offsets..
Variables [32]: push/pull..store.load.dec.......inc.......
    dec_chk...........inc_chk.........
Arithmetic ops [70]: add.......sub.......
    mul........div...........mod...........
Logical ops [114]: not....and.....or.....art_shift........log_shift........
Memory [144]: loadw.loadb..storeb..storew...
Subroutines [152]: call_1s.call_2s..call_vs2...call_vs.....ret.
    call_1n.call_2n..call_vn..call_vn2..
    rtrue.rfalse.ret_popped.
    Computed call...
    check_arg_count................
Objects [193]: get_parent....get_sibling.......get_child......jin.......
    test_attr......set_attr....clear_attr....set/clear/test_attr..
    get_next_prop
]]>

        Test(CZech, expected)
    End Sub

    <Fact()>
    Sub RunZork1()
        Dim expected =
<![CDATA[
]]>

        Test(Zork1, expected)
    End Sub

    Private Sub Test(gameName As String, expected As XCData)
        Dim memory = GameMemory(gameName)
        Dim machine = New Machine(memory, debugging:=True)
        Dim screen = New Screen()
        machine.RegisterScreen(screen)
        Try
            machine.Run()
        Catch ex As Exceptions.ZMachineQuitException
        Catch
        End Try

        Dim expectedText = expected.Value.Trim()

        Assert.Equal(expectedText, screen.Output)
    End Sub

End Module
