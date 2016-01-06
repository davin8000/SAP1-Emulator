Public Class SEmulator
    Private Declare Function GetSystemMenu Lib "user32" (ByVal hwnd As Integer, ByVal revert As Integer) As Integer
    Private Declare Function EnableMenuItem Lib "user32" (ByVal menu As Integer, ByVal ideEnableItem As Integer, ByVal enable As Integer) As Integer
    Private Const SC_CLOSE As Integer = &HF060
    Private Const MF_BYCOMMAND As Integer = &H0
    Private Const MF_GRAYED As Integer = &H1
    Private Const MF_ENABLED As Integer = &H0
    Public Shared Sub Disable(ByVal form As System.Windows.Forms.Form)
        Select Case EnableMenuItem(GetSystemMenu(form.Handle.ToInt32, 0), SC_CLOSE, MF_BYCOMMAND Or MF_GRAYED)
            Case MF_ENABLED
            Case MF_GRAYED
            Case &HFFFFFFFF
                Throw New Exception("The Close menu item does not exist.")
            Case Else
        End Select
    End Sub
    Dim t_state, pc, mar, stops, b_state As Integer
    Dim ir, acc, br, our, cs, cur, mn As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        Call Disable(Me)
        Timer1.Interval = 2000
        TrackBar1.Value = 0
        mn = SAP.arrfunc(0).funcs
        Label11.Text = Convert.ToString(Math.Abs(TrackBar1.Value - 1500)) + "ms"
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        t_state = 1
        pc = 0
        stops = -1
        b_state = 0
        ir = "-1"
        acc = "-1"
        br = "-1"
        our = "-1"
        cs = "-1"
        textArea.Text = "Machine Code" + vbCrLf
        tArea.Text = "Assembly Code" + vbCrLf
        fRes.Text = "Program Counter" + vbCrLf
        fRes.Text += "MAR" + vbCrLf
        fRes.Text += "Instruction Register" + vbCrLf
        fRes.Text += "Accumulator" + vbCrLf
        fRes.Text += "B Register" + vbCrLf
        fRes.Text += "Output Register" + vbCrLf
        fRes.Text += "Controller Sequencer" + vbCrLf
        SLog.Text = "T" + vbTab + "MNE" + vbTab + "PC" + vbTab + "MAR" + vbTab + vbTab + "IR" + vbTab + vbTab + "ACC" + vbTab + vbTab + "BR" + vbTab + vbTab + "OR" + vbTab + vbTab + "CS" + vbCrLf
        EBox.Text = Convert.ToInt32(SAP.arrorg(0).data, 16).ToString
        For i = 1 To (SAP.func_in - 1) / 2
            If SAP.arrfunc(i).funcs = "ADD" Or SAP.arrfunc(i).funcs = "SUB" Then
                Select Case SAP.arrfunc(i).funcs
                    Case "ADD"
                        EBox.Text += " + "
                    Case "SUB"
                        EBox.Text += " - "
                End Select
                EBox.Text += Convert.ToInt32(SAP.arrorg(i).data, 16).ToString
            End If
        Next
        For i = 0 To SAP.func_in - 1
            Select Case SAP.arrfunc(i).funcs
                Case "LDA"
                    textArea.Text += Conversion.Hex(i) + "H " + "0" + SAP.arrfunc(i).address + "H" + vbCrLf
                    tArea.Text += SAP.arrfunc(i).funcs + " " + SAP.arrfunc(i).address + "H" + vbCrLf
                Case "ADD"
                    textArea.Text += Conversion.Hex(i) + "H " + "1" + SAP.arrfunc(i).address + "H" + vbCrLf
                    tArea.Text += SAP.arrfunc(i).funcs + " " + SAP.arrfunc(i).address + "H" + vbCrLf
                Case "SUB"
                    textArea.Text += Conversion.Hex(i) + "H " + "2" + SAP.arrfunc(i).address + "H" + vbCrLf
                    tArea.Text += SAP.arrfunc(i).funcs + " " + SAP.arrfunc(i).address + "H" + vbCrLf
                Case "OUT"
                    textArea.Text += Conversion.Hex(i) + "H " + "E" + SAP.arrfunc(i).address + "H" + vbCrLf
                    tArea.Text += SAP.arrfunc(i).funcs + " " + "----" + vbCrLf
                Case "HLT"
                    textArea.Text += Conversion.Hex(i) + "H " + "F" + SAP.arrfunc(i).address + "H" + vbCrLf
                    tArea.Text += SAP.arrfunc(i).funcs + " " + "----" + vbCrLf
                Case Else
                    textArea.Text += Conversion.Hex(i) + "H " + SAP.arrfunc(i).funcs + SAP.arrfunc(i).address + vbCrLf
            End Select
        Next
        For i = 0 To SAP.org_in - 1
            If SAP.arrorg(i).data <> "" Then
                textArea.Text += Conversion.Hex(i + 9) + "H " + SAP.arrorg(i).data + "H" + vbCrLf
            Else
                textArea.Text += Conversion.Hex(i + 9) + "H " + "----" + vbCrLf
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        arc_func()
    End Sub
    Private Sub arc_func()
        Dim cur As String
        fResVal.Text = ""
        Label4.Text = t_state
        cur = cs
        Button3.Enabled = True
        SLog.Text += Convert.ToString(t_state) + vbTab
        If t_state = 1 Then
            If SAP.arrfunc(pc).funcs = "OUT" Or SAP.arrfunc(pc).funcs = "HLT" Then
                Label6.Text = SAP.arrfunc(pc).funcs
                mn = SAP.arrfunc(pc).funcs + " "
            Else
                Label6.Text = SAP.arrfunc(pc).funcs + " " + SAP.arrfunc(pc).address + "H"
                mn = SAP.arrfunc(pc).funcs + " " + SAP.arrfunc(pc).address + "H" + " "
            End If
        End If
        SLog.Text += mn + vbTab
        If t_state = 3 Then
            Select Case SAP.arrfunc(pc - 1).funcs
                Case "LDA"
                    cur = "0"
                Case "ADD"
                    cur = "1"
                Case "SUB"
                    cur = "2"
                Case "OUT"
                    cur = "14"
                Case "HLT"
                    cur = "15"
            End Select
        End If
        Select Case t_state
            Case 1
                mar = pc
                PictureBox2.Visible = True
                PictureBox3.Visible = True
                PictureBox4.Visible = False
                PictureBox5.Visible = False
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False
                PictureBox9.Visible = False
                PictureBox10.Visible = False
                PictureBox11.Visible = False
                PictureBox12.Visible = False
                PictureBox13.Visible = False
                PictureBox14.Visible = True
                PictureBox15.Visible = False
                PictureBox16.Visible = False
                PictureBox17.Visible = False
                PictureBox18.Visible = False
                PictureBox19.Visible = False
                PictureBox20.Visible = True
                PictureBox21.Visible = True
                PictureBox22.Visible = True
                PictureBox23.Visible = True
                PictureBox24.Visible = True
                PictureBox25.Visible = True
                PictureBox26.Visible = True
                PictureBox27.Visible = True
                Label12.Text = "Ep"
                Label13.Text = "~Lm"
                Label14.Text = ""
                Label15.Text = ""
                Label16.Text = ""
                Label17.Text = ""
                Label18.Text = ""
                Label19.Text = ""
                t_state = 2
            Case 2
                pc = pc + 1
                PictureBox2.Visible = False
                PictureBox3.Visible = False
                PictureBox4.Visible = False
                PictureBox5.Visible = False
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False
                PictureBox9.Visible = False
                PictureBox10.Visible = False
                PictureBox11.Visible = False
                PictureBox12.Visible = False
                PictureBox13.Visible = False
                PictureBox14.Visible = True
                PictureBox15.Visible = False
                PictureBox16.Visible = False
                PictureBox17.Visible = False
                PictureBox18.Visible = False
                PictureBox19.Visible = True
                PictureBox20.Visible = True
                PictureBox21.Visible = True
                PictureBox22.Visible = True
                PictureBox23.Visible = True
                PictureBox24.Visible = True
                PictureBox25.Visible = True
                PictureBox26.Visible = False
                PictureBox27.Visible = True
                Label12.Text = "Cp"
                Label13.Text = ""
                Label14.Text = ""
                Label15.Text = ""
                Label16.Text = ""
                Label17.Text = ""
                Label18.Text = ""
                Label19.Text = ""
                t_state = 3
            Case 3
                ir = SAP.arrfunc(mar).address
                cs = cur
                PictureBox2.Visible = False
                PictureBox3.Visible = False
                PictureBox4.Visible = True
                PictureBox5.Visible = True
                PictureBox6.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False
                PictureBox9.Visible = False
                PictureBox10.Visible = True
                PictureBox11.Visible = False
                PictureBox12.Visible = False
                PictureBox13.Visible = False
                PictureBox14.Visible = True
                PictureBox15.Visible = False
                PictureBox16.Visible = False
                PictureBox17.Visible = False
                PictureBox18.Visible = True
                PictureBox19.Visible = False
                PictureBox20.Visible = True
                PictureBox21.Visible = True
                PictureBox22.Visible = False
                PictureBox23.Visible = True
                PictureBox24.Visible = False
                PictureBox25.Visible = True
                PictureBox26.Visible = False
                PictureBox27.Visible = True
                Label12.Text = ""
                Label13.Text = ""
                Label14.Text = "~CE"
                Label15.Text = "~Li"
                Label16.Text = ""
                Label17.Text = ""
                Label18.Text = ""
                Label19.Text = ""
                t_state = 4
            Case 4
                PictureBox2.Visible = False
                PictureBox4.Visible = False
                PictureBox5.Visible = False
                PictureBox6.Visible = False
                PictureBox9.Visible = False
                PictureBox10.Visible = False
                PictureBox11.Visible = False
                PictureBox15.Visible = False
                PictureBox16.Visible = False
                PictureBox18.Visible = True
                PictureBox22.Visible = True
                PictureBox23.Visible = True
                If SAP.arrfunc(pc - 1).funcs = "LDA" Or SAP.arrfunc(pc - 1).funcs = "ADD" Or SAP.arrfunc(pc - 1).funcs = "SUB" Then
                    mar = Convert.ToInt32(ir, 16)
                    PictureBox3.Visible = True
                    PictureBox7.Visible = True
                    PictureBox8.Visible = False
                    PictureBox13.Visible = False
                    PictureBox17.Visible = False
                    PictureBox12.Visible = True
                    PictureBox14.Visible = True
                    PictureBox19.Visible = False
                    PictureBox20.Visible = True
                    PictureBox21.Visible = True
                    PictureBox24.Visible = False
                    PictureBox25.Visible = True
                    PictureBox26.Visible = False
                    PictureBox27.Visible = True
                    Label12.Text = ""
                    Label13.Text = "~Lm"
                    Label14.Text = ""
                    Label15.Text = "~Ei"
                    Label16.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = ""
                    t_state = 5
                ElseIf SAP.arrfunc(pc - 1).funcs = "OUT" Then
                    our = acc
                    Label7.Visible = True
                    Label7.Text = Convert.ToInt32(our, 16)
                    PictureBox3.Visible = False
                    PictureBox7.Visible = False
                    PictureBox8.Visible = True
                    PictureBox13.Visible = True
                    PictureBox17.Visible = True
                    PictureBox12.Visible = True
                    PictureBox14.Visible = True
                    PictureBox19.Visible = True
                    PictureBox20.Visible = False
                    PictureBox21.Visible = True
                    PictureBox24.Visible = False
                    PictureBox25.Visible = False
                    PictureBox26.Visible = False
                    PictureBox27.Visible = False
                    Label12.Text = ""
                    Label13.Text = ""
                    Label14.Text = ""
                    Label15.Text = ""
                    Label16.Text = "~Lo"
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = "Ea"
                    t_state = 5
                ElseIf SAP.arrfunc(pc - 1).funcs = "HLT" Then
                    PictureBox3.Visible = False
                    PictureBox7.Visible = False
                    PictureBox8.Visible = False
                    PictureBox13.Visible = False
                    PictureBox17.Visible = False
                    PictureBox12.Visible = False
                    PictureBox14.Visible = False
                    PictureBox19.Visible = True
                    PictureBox20.Visible = True
                    PictureBox21.Visible = True
                    PictureBox24.Visible = True
                    PictureBox25.Visible = True
                    PictureBox26.Visible = True
                    PictureBox27.Visible = True
                    Label4.Text = "Program Halted!"
                    Button1.Enabled = False
                    Button2.Enabled = False
                    stops = 1
                End If
            Case 5
                PictureBox2.Visible = False
                PictureBox3.Visible = False
                PictureBox7.Visible = False
                PictureBox8.Visible = False
                PictureBox9.Visible = False
                PictureBox10.Visible = False
                PictureBox11.Visible = False
                PictureBox13.Visible = False
                PictureBox15.Visible = False
                PictureBox17.Visible = False
                PictureBox18.Visible = True
                PictureBox21.Visible = True
                PictureBox25.Visible = True
                PictureBox27.Visible = True
                If SAP.arrfunc(pc - 1).funcs <> "OUT" And SAP.arrfunc(pc - 1).funcs <> "HLT" Then
                    PictureBox19.Visible = False
                    PictureBox22.Visible = False
                    PictureBox24.Visible = False
                    PictureBox26.Visible = False
                    For i = 0 To SAP.org_in - 1
                        If Convert.ToInt32(SAP.arrorg(i).address, 16) = mar Then
                            If SAP.arrfunc(pc - 1).funcs = "LDA" Then
                                acc = SAP.arrorg(i).data
                            Else
                                br = SAP.arrorg(i).data
                            End If

                        End If
                    Next
                    PictureBox4.Visible = True
                    PictureBox5.Visible = True
                    If SAP.arrfunc(pc - 1).funcs = "LDA" Then
                        PictureBox6.Visible = False
                        PictureBox16.Visible = True
                        PictureBox20.Visible = False
                        PictureBox23.Visible = True
                        Label12.Text = ""
                        Label13.Text = ""
                        Label14.Text = "~CE"
                        Label15.Text = ""
                        Label16.Text = ""
                        Label17.Text = ""
                        Label18.Text = ""
                        Label19.Text = "~La"
                    Else
                        PictureBox6.Visible = True
                        PictureBox16.Visible = False
                        PictureBox20.Visible = True
                        PictureBox23.Visible = False
                        Label12.Text = ""
                        Label13.Text = ""
                        Label14.Text = "~CE"
                        Label15.Text = ""
                        Label16.Text = ""
                        Label17.Text = "~Lb"
                        Label18.Text = ""
                        Label19.Text = ""
                    End If
                    PictureBox12.Visible = True
                    PictureBox14.Visible = True
                Else
                    PictureBox4.Visible = False
                    PictureBox5.Visible = False
                    PictureBox6.Visible = False
                    PictureBox16.Visible = False
                    PictureBox12.Visible = False
                    PictureBox14.Visible = False
                    PictureBox19.Visible = True
                    PictureBox22.Visible = True
                    PictureBox24.Visible = True
                    PictureBox26.Visible = True
                    PictureBox20.Visible = True
                    PictureBox23.Visible = True
                    Label12.Text = ""
                    Label13.Text = ""
                    Label14.Text = ""
                    Label15.Text = ""
                    Label16.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = ""
                End If
                t_state = 6
            Case 6
                PictureBox18.Visible = True
                PictureBox19.Visible = True
                PictureBox22.Visible = True
                PictureBox25.Visible = True
                PictureBox27.Visible = True
                If SAP.arrfunc(pc - 1).funcs <> "OUT" And SAP.arrfunc(pc - 1).funcs <> "HLT" Then
                    For i = 0 To SAP.org_in - 1
                        If Convert.ToInt32(SAP.arrorg(i).address, 16) = mar Then
                            If SAP.arrfunc(pc - 1).funcs = "LDA" Then
                                acc = SAP.arrorg(i).data
                            ElseIf SAP.arrfunc(pc - 1).funcs = "ADD" Then
                                acc = Conversion.Hex(Convert.ToInt32(acc, 16) + Convert.ToInt32(br, 16))
                            ElseIf SAP.arrfunc(pc - 1).funcs = "SUB" Then
                                acc = Conversion.Hex(Convert.ToInt32(acc, 16) - Convert.ToInt32(br, 16))
                            End If
                        End If
                    Next
                    If SAP.arrfunc(pc - 1).funcs = "ADD" Or SAP.arrfunc(pc - 1).funcs = "SUB" Then
                        PictureBox20.Visible = False
                        PictureBox21.Visible = False
                        PictureBox23.Visible = False
                        PictureBox24.Visible = False
                        PictureBox26.Visible = False
                    Else
                        PictureBox20.Visible = True
                        PictureBox21.Visible = True
                        PictureBox23.Visible = True
                        PictureBox24.Visible = True
                        PictureBox26.Visible = True
                    End If
                    PictureBox2.Visible = False
                    PictureBox3.Visible = False
                    PictureBox4.Visible = False
                    PictureBox5.Visible = False
                    PictureBox6.Visible = False
                    PictureBox7.Visible = False
                    PictureBox8.Visible = False
                    PictureBox10.Visible = False
                    PictureBox13.Visible = False
                    PictureBox17.Visible = False
                    If SAP.arrfunc(pc - 1).funcs = "LDA" Then
                        PictureBox9.Visible = False
                        PictureBox11.Visible = False
                        PictureBox12.Visible = False
                        PictureBox14.Visible = False
                        PictureBox15.Visible = False
                        PictureBox16.Visible = False
                        Label12.Text = ""
                        Label13.Text = ""
                        Label14.Text = ""
                        Label15.Text = ""
                        Label16.Text = ""
                        Label17.Text = ""
                        Label18.Text = ""
                        Label19.Text = ""
                    Else
                        PictureBox9.Visible = True
                        PictureBox11.Visible = True
                        PictureBox12.Visible = True
                        PictureBox14.Visible = True
                        PictureBox15.Visible = True
                        PictureBox16.Visible = True
                        Label12.Text = ""
                        Label13.Text = ""
                        Label14.Text = ""
                        Label15.Text = ""
                        Label16.Text = ""
                        Label17.Text = ""
                        Label18.Text = "Eu"
                        Label19.Text = "~La"
                    End If
                Else
                    PictureBox20.Visible = True
                    PictureBox21.Visible = True
                    PictureBox23.Visible = True
                    PictureBox24.Visible = True
                    PictureBox26.Visible = True
                    Label12.Text = ""
                    Label13.Text = ""
                    Label14.Text = ""
                    Label15.Text = ""
                    Label16.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = ""
                End If
                t_state = 1
        End Select
        SLog.Text += ConvertHexToBin(Conversion.Hex(pc), 4) + vbTab
        SLog.Text += ConvertHexToBin(Conversion.Hex(mar), 4) + vbTab + vbTab
        fResVal.Text = ConvertHexToBin(Conversion.Hex(pc), 4) + vbCrLf
        fResVal.Text += ConvertHexToBin(Conversion.Hex(mar), 4) + vbCrLf
        If ir = "-1" Then
            fResVal.Text += "---- ----" + vbCrLf
            SLog.Text += "---- ----" + "          "
        Else
            fResVal.Text += ConvertHexToBin(Conversion.Hex(cs), 4) + ConvertHexToBin(ir, 4) + vbCrLf
            SLog.Text += ConvertHexToBin(Conversion.Hex(cs), 4) + ConvertHexToBin(ir, 4) + "          "
        End If
        If acc = "-1" Then
            fResVal.Text += "---- ----" + vbCrLf
            SLog.Text += "---- ----" + "            "
        Else
            fResVal.Text += ConvertHexToBin(acc, 4) + vbCrLf
            SLog.Text += ConvertHexToBin(acc, 4) + "            "
        End If
        If br = "-1" Then
            fResVal.Text += "---- ----" + vbCrLf
            SLog.Text += "---- ----" + "           "
        Else
            fResVal.Text += ConvertHexToBin(br, 4) + vbCrLf
            SLog.Text += ConvertHexToBin(br, 4) + "           "
        End If
        If our = "-1" Then
            fResVal.Text += "---- ----" + vbCrLf
            SLog.Text += "---- ----" + "            "
        Else
            fResVal.Text += ConvertHexToBin(our, 4) + vbCrLf
            SLog.Text += ConvertHexToBin(our, 4) + "            "
        End If
        If cs = "-1" Then
            fResVal.Text += "----" + vbCrLf
            SLog.Text += "----" + vbCrLf
        Else
            fResVal.Text += ConvertHexToBin(Conversion.Hex(cs), 4) + vbCrLf
            SLog.Text += ConvertHexToBin(Conversion.Hex(cs), 4) + vbCrLf
        End If
    End Sub
    Private Function ConvertHexToBin(hex As String, bits As Integer) As String
        Return String.Concat(hex.Select(Function(c) Convert.ToString(Convert.ToInt32(c, 16), 2).PadLeft(bits, "0"c)))
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SAP.Show()
        SAP.Refresh()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Enabled = False
        Label12.Text = ""
        Label13.Text = ""
        Label14.Text = ""
        Label15.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False
        PictureBox14.Visible = False
        PictureBox15.Visible = False
        PictureBox16.Visible = False
        PictureBox17.Visible = False
        PictureBox18.Visible = True
        PictureBox19.Visible = True
        PictureBox20.Visible = True
        PictureBox21.Visible = True
        PictureBox22.Visible = True
        PictureBox23.Visible = True
        PictureBox24.Visible = True
        PictureBox25.Visible = True
        PictureBox26.Visible = True
        PictureBox27.Visible = True
        t_state = 1
        TrackBar1.Value = 0
        Label11.Text = Convert.ToString(Math.Abs(TrackBar1.Value - 1500)) + "ms"
        pc = 0
        stops = -1
        ir = "-1"
        acc = "-1"
        br = "-1"
        our = "-1"
        cs = "-1"
        SLog.Text = "T" + vbTab + "MNE" + vbTab + "PC" + vbTab + "MAR" + vbTab + vbTab + "IR" + vbTab + vbTab + "ACC" + vbTab + vbTab + "BR" + vbTab + vbTab + "OR" + vbTab + vbTab + "CS" + vbCrLf
        fResVal.Text = ""
        Label4.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Button1.Enabled = True
        Timer1.Stop()
        Button2.Text = "Continuous"
        b_state = 0
        Button2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If b_state = 0 Then
            Button1.Enabled = False
            Timer1.Start()
            Button2.Text = "Stop"
            b_state = 1
        Else
            Timer1.Stop()
            Button1.Enabled = True
            Button2.Text = "Continuous"
            b_state = 0
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Interval = Math.Abs((TrackBar1.Value + 1) - 1500)
        Label11.Text = Convert.ToString(Math.Abs(TrackBar1.Value - 1500)) + "ms"
        If stops <> 1 Then
            arc_func()
        Else
            Timer1.Stop()
            Button2.Text = "Continuous"
            b_state = 0
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label11.Text = Convert.ToString(Math.Abs(TrackBar1.Value - 1500)) + "ms"
    End Sub

    Private Sub SEmulator_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call Disable(Me)
    End Sub
End Class