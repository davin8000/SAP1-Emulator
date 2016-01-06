Public Class SAP
    Public Shared fileloc, bin(16) As String
    Public Structure org
        Dim address, data As String
    End Structure
    Public Structure func
        Dim funcs, address As String
    End Structure
    Public Shared arrorg(10) As org
    Public Shared arrfunc(10) As func
    Public Shared org_in, func_in As Integer
    Private Sub fileExit_Click(sender As Object, e As EventArgs) Handles fileExit.Click
        Me.Close()
    End Sub

    Private Sub fileLoad_Click(sender As Object, e As EventArgs) Handles fileLoad.Click
        If openFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            textArea.Visible = True
            textArea.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText)
            fileloc = openFile.FileName
            fileSave.Enabled = True
            fileSave2.Enabled = True
            assembler.Enabled = True
            'For i = 0 To UBound(textArea.Lines)
            'MsgBox(textArea.Lines(i))
            'Next
            Label1.Text = "Loaded: " + fileloc
        End If
    End Sub

    Private Sub SAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        openFile.Filter = "SAP-1 Files (*.sap1*)|*.sap1|All Files (*.*)|*.*"
        openFile.FilterIndex = 1
        openFile.Title = "Open SAP-1 Code"
        saveFile.Filter = "SAP-1 Files (*.sap1*)|*.sap1|All Files (*.*)|*.*"
        saveFile.FilterIndex = 1
        saveFile.Title = "Save SAP-1 Code"
        openBin.Filter = "Bin Files (*.bin*)|*.bin|All Files (*.*)|*.*"
        openBin.FilterIndex = 1
        openBin.Title = "Open Bin File"
        fileSave2.ShortcutKeys = Shortcut.CtrlS
        fileLoad.ShortcutKeys = Shortcut.CtrlO
        assembler.ShortcutKeys = Shortcut.CtrlA
        emulator.ShortcutKeys = Shortcut.CtrlE
        org_in = 0
        func_in = 0
    End Sub

    Private Sub assembler_Click(sender As Object, e As EventArgs) Handles assembler.Click
        Dim i, j, state As Integer
        state = 0
        org_in = 0
        func_in = 0
        For i = 0 To UBound(textArea.Lines) - 1
            If textArea.Lines(i) = "" Then
                i = i + 1
            End If
            For j = 0 To 10
                'MsgBox(j.ToString + " " + state.ToString)
                Select Case state
                    Case 0
                        Select Case textArea.Lines(i).Chars(j)
                            Case "O" 'ORG/OUT state
                                If textArea.Lines(i).Chars(j + 1) = "R" Then 'ORG state
                                    state = 1
                                ElseIf textArea.Lines(i).Chars(j + 1) = "U" Then 'OUT state
                                    state = 2
                                End If
                            Case "L" 'LDA state
                                state = 3
                            Case "A" 'ADD state
                                state = 3
                            Case "S" 'SUB state
                                state = 2
                            Case "H" 'HLT state
                                state = 4
                            Case Else
                                state = 11
                        End Select
                    Case 1
                        Select Case textArea.Lines(i).Chars(j)
                            Case "R" 'ORG state
                                state = 5
                        End Select
                    Case 2
                        Select Case textArea.Lines(i).Chars(j)
                            Case "U" 'OUT/SUB state
                                If textArea.Lines(i).Chars(j + 1) = "T" Then 'OUT state
                                    state = 6
                                ElseIf textArea.Lines(i).Chars(j + 1) = "B" Then 'SUB state
                                    state = 7
                                End If
                        End Select
                    Case 3
                        Select Case textArea.Lines(i).Chars(j)
                            Case "D" 'LDA state
                                If textArea.Lines(i).Chars(j + 1) = "A" Then 'LDA state
                                    state = 8
                                ElseIf textArea.Lines(i).Chars(j + 1) = "D" Then 'ADD state
                                    state = 9
                                End If
                        End Select
                    Case 4
                        Select Case textArea.Lines(i).Chars(j)
                            Case "L" 'HLT state
                                state = 10
                        End Select
                    Case 5
                        Select Case textArea.Lines(i).Chars(j)
                            Case "G" 'ORG state
                                If textArea.Lines(i).Chars(j + 7) <= "F" Then
                                    arrorg(org_in).address = textArea.Lines(i).Substring(j + 2, 1)
                                    arrorg(org_in).data = textArea.Lines(i).Substring(j + 7, 2)
                                    state = 0
                                    org_in = org_in + 1
                                    Exit For
                                Else
                                    state = 0
                                    org_in = org_in + 1
                                    Exit For
                                End If
                        End Select
                    Case 6
                        Select Case textArea.Lines(i).Chars(j)
                            Case "T" 'OUT state
                                arrfunc(func_in).funcs = "1110"
                                arrfunc(func_in).address = "F"
                                state = 0
                                func_in = func_in + 1
                                Exit For
                        End Select
                    Case 7
                        Select Case textArea.Lines(i).Chars(j)
                            Case "B" 'SUB state
                                arrfunc(func_in).funcs = "0010"
                                arrfunc(func_in).address = textArea.Lines(i).Substring(j + 3, 1)
                                state = 0
                                func_in = func_in + 1
                                Exit For
                        End Select
                    Case 8
                        Select Case textArea.Lines(i).Chars(j)
                            Case "A" 'LDA state
                                arrfunc(func_in).funcs = "0000"
                                arrfunc(func_in).address = textArea.Lines(i).Substring(j + 3, 1)
                                state = 0
                                func_in = func_in + 1
                                Exit For
                        End Select
                    Case 9
                        Select Case textArea.Lines(i).Chars(j)
                            Case "D" 'ADD state
                                arrfunc(func_in).funcs = "0001"
                                arrfunc(func_in).address = textArea.Lines(i).Substring(j + 3, 1)
                                state = 0
                                func_in = func_in + 1
                                Exit For
                        End Select
                    Case 10
                        Select Case textArea.Lines(i).Chars(j)
                            Case "T" 'HLT state
                                arrfunc(func_in).funcs = "1111"
                                arrfunc(func_in).address = "F"
                                state = 11
                                func_in = func_in + 1
                                Exit For
                        End Select
                    Case 11
                        state = 0
                        Exit For
                End Select
            Next
        Next
        Dim ins, bin_in As Integer
        bin_in = 0
        For ins = 0 To 8
            If ins < func_in Then
                bin(bin_in) = "A" + ConvertHexToBin(bin_in) + arrfunc(ins).funcs + ConvertHexToBin(arrfunc(ins).address)
            Else
                bin(bin_in) = "A" + ConvertHexToBin(bin_in) + "1111" + "1111"
            End If
            bin_in = bin_in + 1
        Next
        For ins = 0 To 6
            If ins < org_in - 1 Then
                bin(bin_in) = "A" + Convert.ToString(bin_in, 2) + ConvertHexToBin(arrorg(ins).data)
            Else
                bin(bin_in) = "A" + Convert.ToString(bin_in, 2) + "1111" + "1111"
            End If
            bin_in = bin_in + 1
        Next
        Dim fl As Integer
        fl = fileloc.Length - 4
        Label1.Text = "Created:" + fileloc.Substring(0, fl) + "bin"
        System.IO.File.WriteAllLines(fileloc.Substring(0, fl) + "bin", bin)
    End Sub

    Private Function ConvertHexToBin(hex As String) As String
        Return String.Concat(hex.Select(Function(c) Convert.ToString(Convert.ToInt32(c, 16), 2).PadLeft(4, "0"c)))
    End Function

    Private Sub fileSave_Click(sender As Object, e As EventArgs) Handles fileSave.Click
        If saveFile.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            textArea.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText)
            Label1.Text = "Saved to: " + saveFile.FileName
        End If
    End Sub

    Private Sub fileSave2_Click(sender As Object, e As EventArgs) Handles fileSave2.Click
        textArea.SaveFile(fileloc, RichTextBoxStreamType.PlainText)
        Label1.Text = "Saved to: " + fileloc
    End Sub

    Private Sub emulator_Click(sender As Object, e As EventArgs) Handles emulator.Click
        Dim i, t As Integer
        org_in = 0
        func_in = 0
        t = 0
        If openBin.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            textArea.Visible = True
            textArea.LoadFile(openBin.FileName, RichTextBoxStreamType.PlainText)
            fileloc = openBin.FileName
            For i = 0 To UBound(textArea.Lines) - 1
                bin(i) = textArea.Lines(i)
            Next
            For i = 0 To UBound(bin)
                If i < 9 Then
                    Select Case bin(i).Substring(5, 4)
                        Case "0000"
                            arrfunc(func_in).funcs = "LDA"
                            arrfunc(func_in).address = Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2))
                            func_in = func_in + 1
                        Case "0001"
                            arrfunc(func_in).funcs = "ADD"
                            arrfunc(func_in).address = Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2))
                            func_in = func_in + 1
                        Case "0010"
                            arrfunc(func_in).funcs = "SUB"
                            arrfunc(func_in).address = Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2))
                            func_in = func_in + 1
                        Case "1110"
                            arrfunc(func_in).funcs = "OUT"
                            arrfunc(func_in).address = Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2))
                            func_in = func_in + 1
                        Case "1111"
                            If t = 0 Then
                                arrfunc(func_in).funcs = "HLT"
                                arrfunc(func_in).address = Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2))
                                func_in = func_in + 1
                                t = 1
                            Else
                                arrfunc(func_in).funcs = "--"
                                arrfunc(func_in).address = "--"
                                func_in = func_in + 1
                                t = 1
                            End If
                    End Select
                End If
            Next
            For i = 9 To UBound(bin) - 1
                If bin(i).Substring(5, 4) <> "1111" Then
                    arrorg(org_in).address = arrfunc(i - 9).address
                    arrorg(org_in).data = Conversion.Hex(Convert.ToInt32(bin(i).Substring(5, 8), 2))
                    'MsgBox(Conversion.Hex(Convert.ToInt32(bin(i).Substring(9, 4), 2)))
                    org_in = org_in + 1
                Else
                    org_in = org_in + 1
                End If
            Next
            textArea.Clear()
            textArea.Text = arrfunc(0).funcs + " " + arrfunc(0).address + vbCrLf
            For i = 1 To UBound(arrfunc)
                textArea.Text += arrfunc(i).funcs + " " + arrfunc(i).address + vbCrLf
            Next
            'Label1.Text = arrfunc(0).funcs + arrfunc(0).address
            Label1.Text = ""
            textArea.Text = ""
            textArea.Visible = False
            SEmulator.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutUsToolStripMenuItem.Click
        about.Show()
        'about.Controls(1).Focus()
    End Sub

    Private Sub SAP1AgricultureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAP1AgricultureToolStripMenuItem.Click
        arc.Show()
    End Sub

    Private Sub GlossaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GlossaryToolStripMenuItem.Click
        glos.Show()
    End Sub
End Class
