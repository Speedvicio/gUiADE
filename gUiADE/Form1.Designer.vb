﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CheckConsole = New System.Windows.Forms.CheckBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelMin = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckLoop = New System.Windows.Forms.CheckBox()
        Me.NumericGAIN = New System.Windows.Forms.NumericUpDown()
        Me.NumericPANNING = New System.Windows.Forms.NumericUpDown()
        Me.ComboFILTER = New System.Windows.Forms.ComboBox()
        Me.ButtonHEAFSET = New System.Windows.Forms.Button()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckWAV = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericGAIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericPANNING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Title = "Select a music module"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.DodgerBlue
        Me.ToolTip1.ForeColor = System.Drawing.Color.White
        Me.ToolTip1.IsBalloon = True
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(149, 416)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(306, 20)
        Me.TextBox1.TabIndex = 19
        Me.TextBox1.Tag = ""
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Input any custom parameters described onto UADE readme." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "--filter=A1200" &
        " -G 10")
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.Black
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.White
        Me.TreeView1.LineColor = System.Drawing.Color.White
        Me.TreeView1.Location = New System.Drawing.Point(6, 23)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(346, 122)
        Me.TreeView1.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.TreeView1, "Double left mouse click to load a tune")
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.Black
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.DarkOrange
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(6, 151)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(346, 100)
        Me.ListBox1.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.ListBox1, "Double left mouse click to load a subtune")
        '
        'CheckConsole
        '
        Me.CheckConsole.AutoSize = True
        Me.CheckConsole.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckConsole.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.CheckConsole.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HotTrack
        Me.CheckConsole.ForeColor = System.Drawing.Color.White
        Me.CheckConsole.Location = New System.Drawing.Point(7, 100)
        Me.CheckConsole.Name = "CheckConsole"
        Me.CheckConsole.Size = New System.Drawing.Size(64, 17)
        Me.CheckConsole.TabIndex = 21
        Me.CheckConsole.Text = "&Console"
        Me.ToolTip1.SetToolTip(Me.CheckConsole, "Enable control of UADE in realtime" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(This will show UADE cmd window minimized)")
        Me.CheckConsole.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(101, 23)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(90, 29)
        Me.Button7.TabIndex = 19
        Me.Button7.Text = "&Directory"
        Me.ToolTip1.SetToolTip(Me.Button7, "Load a folder recursively")
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(7, 58)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(90, 29)
        Me.Button6.TabIndex = 20
        Me.Button6.Text = "&Stop"
        Me.ToolTip1.SetToolTip(Me.Button6, "Stop music play")
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrange
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(7, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 29)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "&File"
        Me.ToolTip1.SetToolTip(Me.Button1, "Load Single File")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 419)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Custom Parameters:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TreeView1)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkOrange
        Me.GroupBox2.Location = New System.Drawing.Point(12, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(358, 255)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Songs && Subsongs"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.labelMin)
        Me.Panel2.Location = New System.Drawing.Point(18, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(548, 145)
        Me.Panel2.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Image = Global.gUiADE.My.Resources.Resources.guiade
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(542, 98)
        Me.Label1.TabIndex = 15
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelMin
        '
        Me.labelMin.BackColor = System.Drawing.Color.Black
        Me.labelMin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMin.ForeColor = System.Drawing.Color.Red
        Me.labelMin.Location = New System.Drawing.Point(3, 106)
        Me.labelMin.Name = "labelMin"
        Me.labelMin.Size = New System.Drawing.Size(542, 33)
        Me.labelMin.TabIndex = 14
        Me.labelMin.Text = "- A Crappy Frontend for UADE -"
        Me.labelMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.CheckLoop)
        Me.GroupBox1.Controls.Add(Me.NumericGAIN)
        Me.GroupBox1.Controls.Add(Me.NumericPANNING)
        Me.GroupBox1.Controls.Add(Me.ComboFILTER)
        Me.GroupBox1.Controls.Add(Me.ButtonHEAFSET)
        Me.GroupBox1.Controls.Add(Me.CheckBox6)
        Me.GroupBox1.Controls.Add(Me.CheckBox5)
        Me.GroupBox1.Controls.Add(Me.CheckBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.CheckConsole)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkOrange
        Me.GroupBox1.Location = New System.Drawing.Point(376, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 255)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Controls"
        '
        'CheckLoop
        '
        Me.CheckLoop.AutoSize = True
        Me.CheckLoop.ForeColor = System.Drawing.Color.White
        Me.CheckLoop.Location = New System.Drawing.Point(103, 65)
        Me.CheckLoop.Name = "CheckLoop"
        Me.CheckLoop.Size = New System.Drawing.Size(78, 17)
        Me.CheckLoop.TabIndex = 32
        Me.CheckLoop.Text = "&Loop Song"
        Me.CheckLoop.UseVisualStyleBackColor = True
        '
        'NumericGAIN
        '
        Me.NumericGAIN.BackColor = System.Drawing.SystemColors.HotTrack
        Me.NumericGAIN.DecimalPlaces = 1
        Me.NumericGAIN.ForeColor = System.Drawing.Color.White
        Me.NumericGAIN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericGAIN.Location = New System.Drawing.Point(132, 229)
        Me.NumericGAIN.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.NumericGAIN.Name = "NumericGAIN"
        Me.NumericGAIN.ReadOnly = True
        Me.NumericGAIN.Size = New System.Drawing.Size(56, 20)
        Me.NumericGAIN.TabIndex = 31
        Me.NumericGAIN.Value = New Decimal(New Integer() {10, 0, 0, 65536})
        '
        'NumericPANNING
        '
        Me.NumericPANNING.BackColor = System.Drawing.SystemColors.HotTrack
        Me.NumericPANNING.DecimalPlaces = 1
        Me.NumericPANNING.ForeColor = System.Drawing.Color.White
        Me.NumericPANNING.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericPANNING.Location = New System.Drawing.Point(132, 206)
        Me.NumericPANNING.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericPANNING.Name = "NumericPANNING"
        Me.NumericPANNING.ReadOnly = True
        Me.NumericPANNING.Size = New System.Drawing.Size(56, 20)
        Me.NumericPANNING.TabIndex = 30
        Me.NumericPANNING.Value = New Decimal(New Integer() {7, 0, 0, 65536})
        '
        'ComboFILTER
        '
        Me.ComboFILTER.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ComboFILTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboFILTER.ForeColor = System.Drawing.Color.DarkOrange
        Me.ComboFILTER.FormattingEnabled = True
        Me.ComboFILTER.Items.AddRange(New Object() {"NONE", "A500", "A1200"})
        Me.ComboFILTER.Location = New System.Drawing.Point(70, 130)
        Me.ComboFILTER.Name = "ComboFILTER"
        Me.ComboFILTER.Size = New System.Drawing.Size(89, 21)
        Me.ComboFILTER.TabIndex = 29
        Me.ComboFILTER.Text = "NONE"
        '
        'ButtonHEAFSET
        '
        Me.ButtonHEAFSET.BackColor = System.Drawing.Color.White
        Me.ButtonHEAFSET.BackgroundImage = Global.gUiADE.My.Resources.Resources.headset
        Me.ButtonHEAFSET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonHEAFSET.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonHEAFSET.ForeColor = System.Drawing.Color.Black
        Me.ButtonHEAFSET.Location = New System.Drawing.Point(165, 127)
        Me.ButtonHEAFSET.Name = "ButtonHEAFSET"
        Me.ButtonHEAFSET.Size = New System.Drawing.Size(25, 25)
        Me.ButtonHEAFSET.TabIndex = 28
        Me.ButtonHEAFSET.Tag = "menot"
        Me.ButtonHEAFSET.Text = "0"
        Me.ButtonHEAFSET.UseVisualStyleBackColor = False
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.ForeColor = System.Drawing.Color.White
        Me.CheckBox6.Location = New System.Drawing.Point(7, 207)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(96, 17)
        Me.CheckBox6.TabIndex = 27
        Me.CheckBox6.Text = "Panning &Effect"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Checked = True
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.ForeColor = System.Drawing.Color.White
        Me.CheckBox5.Location = New System.Drawing.Point(7, 180)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(102, 17)
        Me.CheckBox5.TabIndex = 26
        Me.CheckBox5.Text = "&Post-Processing"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.ForeColor = System.Drawing.Color.White
        Me.CheckBox4.Location = New System.Drawing.Point(7, 157)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox4.TabIndex = 25
        Me.CheckBox4.Text = "No&rmalise"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.ForeColor = System.Drawing.Color.White
        Me.CheckBox3.Location = New System.Drawing.Point(7, 230)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox3.TabIndex = 24
        Me.CheckBox3.Text = "&Gain"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(7, 132)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(48, 17)
        Me.CheckBox2.TabIndex = 23
        Me.CheckBox2.Text = "&Filter"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(98, 92)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(92, 32)
        Me.Panel1.TabIndex = 22
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.BackgroundImage = Global.gUiADE.My.Resources.Resources._next
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(3, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(25, 25)
        Me.Button4.TabIndex = 8
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.BackgroundImage = Global.gUiADE.My.Resources.Resources._next
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(65, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(25, 25)
        Me.Button3.TabIndex = 7
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.BackgroundImage = Global.gUiADE.My.Resources.Resources._stop
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(34, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 25)
        Me.Button2.TabIndex = 6
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CheckWAV
        '
        Me.CheckWAV.AutoSize = True
        Me.CheckWAV.ForeColor = System.Drawing.Color.White
        Me.CheckWAV.Location = New System.Drawing.Point(479, 418)
        Me.CheckWAV.Name = "CheckWAV"
        Me.CheckWAV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckWAV.Size = New System.Drawing.Size(91, 17)
        Me.CheckWAV.TabIndex = 28
        Me.CheckWAV.Text = "Write to WAV"
        Me.CheckWAV.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.gUiADE.My.Resources.Resources.bounce
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(139, 157)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(42, 42)
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(584, 441)
        Me.Controls.Add(Me.CheckWAV)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gUiADE"
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericGAIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericPANNING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents labelMin As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents CheckConsole As CheckBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox6 As CheckBox
    Friend WithEvents ButtonHEAFSET As Button
    Friend WithEvents ComboFILTER As ComboBox
    Friend WithEvents NumericGAIN As NumericUpDown
    Friend WithEvents NumericPANNING As NumericUpDown
    Friend WithEvents CheckLoop As CheckBox
    Friend WithEvents CheckWAV As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
