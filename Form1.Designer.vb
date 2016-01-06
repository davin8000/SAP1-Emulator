<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SAP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SAP))
        Me.mainMenu = New System.Windows.Forms.MenuStrip()
        Me.menuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileLoad = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileSave2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.fileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAssemble = New System.Windows.Forms.ToolStripMenuItem()
        Me.assembler = New System.Windows.Forms.ToolStripMenuItem()
        Me.emulator = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAP1AgricultureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlossaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.openFile = New System.Windows.Forms.OpenFileDialog()
        Me.saveFile = New System.Windows.Forms.SaveFileDialog()
        Me.textArea = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.openBin = New System.Windows.Forms.OpenFileDialog()
        Me.mainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu
        '
        Me.mainMenu.BackColor = System.Drawing.Color.RoyalBlue
        Me.mainMenu.BackgroundImage = Global.SAP1.My.Resources.Resources.c_des_4
        Me.mainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFile, Me.menuAssemble, Me.HelpToolStripMenuItem})
        Me.mainMenu.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu.Name = "mainMenu"
        Me.mainMenu.Size = New System.Drawing.Size(292, 24)
        Me.mainMenu.TabIndex = 0
        Me.mainMenu.Text = "MenuStrip1"
        '
        'menuFile
        '
        Me.menuFile.BackColor = System.Drawing.Color.RoyalBlue
        Me.menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileLoad, Me.fileSave2, Me.fileSave, Me.fileExit})
        Me.menuFile.ForeColor = System.Drawing.Color.White
        Me.menuFile.Name = "menuFile"
        Me.menuFile.Size = New System.Drawing.Size(37, 20)
        Me.menuFile.Text = "File"
        '
        'fileLoad
        '
        Me.fileLoad.BackColor = System.Drawing.SystemColors.Control
        Me.fileLoad.Name = "fileLoad"
        Me.fileLoad.Size = New System.Drawing.Size(186, 22)
        Me.fileLoad.Text = "Load/View SAP-1 File"
        '
        'fileSave2
        '
        Me.fileSave2.Enabled = False
        Me.fileSave2.Name = "fileSave2"
        Me.fileSave2.Size = New System.Drawing.Size(186, 22)
        Me.fileSave2.Text = "Save"
        '
        'fileSave
        '
        Me.fileSave.Enabled = False
        Me.fileSave.Name = "fileSave"
        Me.fileSave.Size = New System.Drawing.Size(186, 22)
        Me.fileSave.Text = "Save As"
        '
        'fileExit
        '
        Me.fileExit.Name = "fileExit"
        Me.fileExit.Size = New System.Drawing.Size(186, 22)
        Me.fileExit.Text = "Exit"
        '
        'menuAssemble
        '
        Me.menuAssemble.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.assembler, Me.emulator})
        Me.menuAssemble.ForeColor = System.Drawing.Color.White
        Me.menuAssemble.Name = "menuAssemble"
        Me.menuAssemble.Size = New System.Drawing.Size(127, 20)
        Me.menuAssemble.Text = "Assembler/Emulator"
        '
        'assembler
        '
        Me.assembler.Enabled = False
        Me.assembler.Name = "assembler"
        Me.assembler.Size = New System.Drawing.Size(205, 22)
        Me.assembler.Text = "Assemble/Create bin File"
        '
        'emulator
        '
        Me.emulator.Name = "emulator"
        Me.emulator.Size = New System.Drawing.Size(205, 22)
        Me.emulator.Text = "Open SAP-1 Emulator"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SAP1AgricultureToolStripMenuItem, Me.GlossaryToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'SAP1AgricultureToolStripMenuItem
        '
        Me.SAP1AgricultureToolStripMenuItem.Name = "SAP1AgricultureToolStripMenuItem"
        Me.SAP1AgricultureToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SAP1AgricultureToolStripMenuItem.Text = "SAP-1 Architecture"
        '
        'GlossaryToolStripMenuItem
        '
        Me.GlossaryToolStripMenuItem.Name = "GlossaryToolStripMenuItem"
        Me.GlossaryToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.GlossaryToolStripMenuItem.Text = "Glossary"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.AboutUsToolStripMenuItem.Text = "About SAP1"
        '
        'textArea
        '
        Me.textArea.Location = New System.Drawing.Point(12, 27)
        Me.textArea.Name = "textArea"
        Me.textArea.Size = New System.Drawing.Size(268, 217)
        Me.textArea.TabIndex = 1
        Me.textArea.Text = ""
        Me.textArea.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 247)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 2
        '
        'SAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.RoyalBlue
        Me.BackgroundImage = Global.SAP1.My.Resources.Resources.c_des_4
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(292, 269)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textArea)
        Me.Controls.Add(Me.mainMenu)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mainMenu
        Me.MaximizeBox = False
        Me.Name = "SAP"
        Me.Text = "SAP-1 v1.01"
        Me.mainMenu.ResumeLayout(False)
        Me.mainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents menuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileLoad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuAssemble As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents assembler As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents emulator As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents saveFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents textArea As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fileSave2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openBin As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAP1AgricultureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlossaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
