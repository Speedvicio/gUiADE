<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.CheckConsole = New System.Windows.Forms.CheckBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckQuad = New System.Windows.Forms.CheckBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckNtsc = New System.Windows.Forms.CheckBox()
        Me.CheckLoop = New System.Windows.Forms.CheckBox()
        Me.NumericGAIN = New System.Windows.Forms.NumericUpDown()
        Me.NumericPANNING = New System.Windows.Forms.NumericUpDown()
        Me.ComboFILTER = New System.Windows.Forms.ComboBox()
        Me.ButtonHEAFSET = New System.Windows.Forms.Button()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckWAV = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.PeakMeterCtrl2 = New Ernzo.WinForms.Controls.PeakMeterCtrl()
        Me.PeakMeterCtrl1 = New Ernzo.WinForms.Controls.PeakMeterCtrl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelMin = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboSampler = New System.Windows.Forms.ComboBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TimerAudio = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericGAIN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericPANNING, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Button7.Location = New System.Drawing.Point(61, 23)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 29)
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
        Me.Button6.Location = New System.Drawing.Point(142, 23)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(48, 29)
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
        Me.Button1.Size = New System.Drawing.Size(48, 29)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "&File"
        Me.ToolTip1.SetToolTip(Me.Button1, "Load Single File")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckQuad
        '
        Me.CheckQuad.AutoSize = True
        Me.CheckQuad.Enabled = False
        Me.CheckQuad.ForeColor = System.Drawing.Color.White
        Me.CheckQuad.Location = New System.Drawing.Point(481, 418)
        Me.CheckQuad.Name = "CheckQuad"
        Me.CheckQuad.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckQuad.Size = New System.Drawing.Size(85, 17)
        Me.CheckQuad.TabIndex = 29
        Me.CheckQuad.Text = "Quad Export"
        Me.ToolTip1.SetToolTip(Me.CheckQuad, "Export a wave in quad channells")
        Me.CheckQuad.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.NumericUpDown1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.gUiADE.My.MySettings.Default, "Timeout", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericUpDown1.ForeColor = System.Drawing.Color.White
        Me.NumericUpDown1.Location = New System.Drawing.Point(45, 64)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(56, 20)
        Me.NumericUpDown1.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.NumericUpDown1, "Set song timeout in seconds. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-1 is infinite" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PS: This parameter is valid only o" &
        "n non forced looped song and with wav export")
        Me.NumericUpDown1.Value = Global.gUiADE.My.MySettings.Default.Timeout
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.gUiADE.My.MySettings.Default, "CParameters", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TextBox1.ForeColor = System.Drawing.Color.White
        Me.TextBox1.Location = New System.Drawing.Point(189, 416)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(181, 20)
        Me.TextBox1.TabIndex = 19
        Me.TextBox1.Tag = ""
        Me.TextBox1.Text = Global.gUiADE.My.MySettings.Default.CParameters
        Me.ToolTip1.SetToolTip(Me.TextBox1, "Input any custom parameters described onto UADE readme." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Example:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "--filter=A1200" &
        " -G 10")
        '
        'CheckNtsc
        '
        Me.CheckNtsc.AutoSize = True
        Me.CheckNtsc.ForeColor = System.Drawing.Color.White
        Me.CheckNtsc.Location = New System.Drawing.Point(7, 230)
        Me.CheckNtsc.Name = "CheckNtsc"
        Me.CheckNtsc.Size = New System.Drawing.Size(48, 17)
        Me.CheckNtsc.TabIndex = 35
        Me.CheckNtsc.Text = "&Ntsc"
        Me.ToolTip1.SetToolTip(Me.CheckNtsc, "Set NTSC mode for playing (can be buggy and work only in non console mode)")
        Me.CheckNtsc.UseVisualStyleBackColor = True
        '
        'CheckLoop
        '
        Me.CheckLoop.AutoSize = True
        Me.CheckLoop.Checked = Global.gUiADE.My.MySettings.Default.Loop_Song
        Me.CheckLoop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckLoop.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "Loop_Song", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckLoop.ForeColor = System.Drawing.Color.White
        Me.CheckLoop.Location = New System.Drawing.Point(107, 65)
        Me.CheckLoop.Name = "CheckLoop"
        Me.CheckLoop.Size = New System.Drawing.Size(78, 17)
        Me.CheckLoop.TabIndex = 32
        Me.CheckLoop.Text = "&Loop Song"
        Me.ToolTip1.SetToolTip(Me.CheckLoop, "Enable loop to selected song." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It also enable timeout for looped song." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you wa" &
        "nt to play infinitely, set the value -1 on the ""Time"" box")
        Me.CheckLoop.UseVisualStyleBackColor = True
        '
        'NumericGAIN
        '
        Me.NumericGAIN.BackColor = System.Drawing.SystemColors.HotTrack
        Me.NumericGAIN.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.gUiADE.My.MySettings.Default, "Gain", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericGAIN.DecimalPlaces = 1
        Me.NumericGAIN.ForeColor = System.Drawing.Color.White
        Me.NumericGAIN.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericGAIN.Location = New System.Drawing.Point(132, 229)
        Me.NumericGAIN.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.NumericGAIN.Name = "NumericGAIN"
        Me.NumericGAIN.ReadOnly = True
        Me.NumericGAIN.Size = New System.Drawing.Size(56, 20)
        Me.NumericGAIN.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.NumericGAIN, "Set volume gain to x in range [0, 128]. Default is 1,0")
        Me.NumericGAIN.Value = Global.gUiADE.My.MySettings.Default.Gain
        '
        'NumericPANNING
        '
        Me.NumericPANNING.BackColor = System.Drawing.SystemColors.HotTrack
        Me.NumericPANNING.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.gUiADE.My.MySettings.Default, "Panning", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.NumericPANNING.DecimalPlaces = 1
        Me.NumericPANNING.ForeColor = System.Drawing.Color.White
        Me.NumericPANNING.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericPANNING.Location = New System.Drawing.Point(132, 206)
        Me.NumericPANNING.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericPANNING.Name = "NumericPANNING"
        Me.NumericPANNING.ReadOnly = True
        Me.NumericPANNING.Size = New System.Drawing.Size(56, 20)
        Me.NumericPANNING.TabIndex = 30
        Me.ToolTip1.SetToolTip(Me.NumericPANNING, "Set panning value in range [0, 2]. 0 is full stereo," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 is mono, and 2 is inverse" &
        " stereo. The default is 0,7.")
        Me.NumericPANNING.Value = Global.gUiADE.My.MySettings.Default.Panning
        '
        'ComboFILTER
        '
        Me.ComboFILTER.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ComboFILTER.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.gUiADE.My.MySettings.Default, "Filter", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboFILTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboFILTER.ForeColor = System.Drawing.Color.DarkOrange
        Me.ComboFILTER.FormattingEnabled = True
        Me.ComboFILTER.Items.AddRange(New Object() {"NONE", "A500", "A1200"})
        Me.ComboFILTER.Location = New System.Drawing.Point(70, 130)
        Me.ComboFILTER.Name = "ComboFILTER"
        Me.ComboFILTER.Size = New System.Drawing.Size(89, 21)
        Me.ComboFILTER.TabIndex = 29
        Me.ComboFILTER.Text = Global.gUiADE.My.MySettings.Default.Filter
        Me.ToolTip1.SetToolTip(Me.ComboFILTER, "Set filter model to A500, A1200 or NONE. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NONE means disabling the filter.")
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
        Me.ToolTip1.SetToolTip(Me.ButtonHEAFSET, "Enable headphones postprocessing effect")
        Me.ButtonHEAFSET.UseVisualStyleBackColor = False
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Checked = Global.gUiADE.My.MySettings.Default.PanningEnabled
        Me.CheckBox6.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "PanningEnabled", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox6.ForeColor = System.Drawing.Color.White
        Me.CheckBox6.Location = New System.Drawing.Point(7, 207)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(99, 17)
        Me.CheckBox6.TabIndex = 27
        Me.CheckBox6.Text = "Panning &Effect:"
        Me.ToolTip1.SetToolTip(Me.CheckBox6, "Enable/Disable panning")
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Checked = Global.gUiADE.My.MySettings.Default.Normalise
        Me.CheckBox4.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "Normalise", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox4.ForeColor = System.Drawing.Color.White
        Me.CheckBox4.Location = New System.Drawing.Point(7, 157)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox4.TabIndex = 25
        Me.CheckBox4.Text = "No&rmalise"
        Me.ToolTip1.SetToolTip(Me.CheckBox4, "Enable/Disable normalise postprocessing effect")
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = Global.gUiADE.My.MySettings.Default.GainEnabled
        Me.CheckBox3.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "GainEnabled", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox3.ForeColor = System.Drawing.Color.White
        Me.CheckBox3.Location = New System.Drawing.Point(70, 230)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox3.TabIndex = 24
        Me.CheckBox3.Text = "&Gain:"
        Me.ToolTip1.SetToolTip(Me.CheckBox3, "Enable/Disable volume gain")
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = Global.gUiADE.My.MySettings.Default.FilterEnabled
        Me.CheckBox2.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "FilterEnabled", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.Location = New System.Drawing.Point(7, 132)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(51, 17)
        Me.CheckBox2.TabIndex = 23
        Me.CheckBox2.Text = "&Filter:"
        Me.ToolTip1.SetToolTip(Me.CheckBox2, "Enable filter emulation" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you want to disable Paula filters you need to enable " &
        "it and select NONE")
        Me.CheckBox2.UseVisualStyleBackColor = True
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
        Me.ToolTip1.SetToolTip(Me.Button4, "Previous subsong (Console mode only)")
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
        Me.ToolTip1.SetToolTip(Me.Button3, "Next subsong (Console mode only)")
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
        Me.ToolTip1.SetToolTip(Me.Button2, "Play/Pause (Console mode only)")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'CheckWAV
        '
        Me.CheckWAV.AutoSize = True
        Me.CheckWAV.ForeColor = System.Drawing.Color.White
        Me.CheckWAV.Location = New System.Drawing.Point(376, 418)
        Me.CheckWAV.Name = "CheckWAV"
        Me.CheckWAV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckWAV.Size = New System.Drawing.Size(91, 17)
        Me.CheckWAV.TabIndex = 28
        Me.CheckWAV.Text = "Write to WAV"
        Me.ToolTip1.SetToolTip(Me.CheckWAV, "Write Selected song in wave stereo format")
        Me.CheckWAV.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.gUiADE.My.Resources.Resources.bounce
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(42, 413)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "- Left click to open About" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Right click to open UADE parameters manual")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(72, 419)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Custom Parameters:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
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
        Me.Panel2.Controls.Add(Me.TrackBar1)
        Me.Panel2.Controls.Add(Me.PeakMeterCtrl2)
        Me.Panel2.Controls.Add(Me.PeakMeterCtrl1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.labelMin)
        Me.Panel2.Location = New System.Drawing.Point(18, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(548, 145)
        Me.Panel2.TabIndex = 21
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.BackColor = System.Drawing.Color.Black
        Me.TrackBar1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.gUiADE.My.MySettings.Default, "Volume", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.TrackBar1.Location = New System.Drawing.Point(465, 9)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(80, 12)
        Me.TrackBar1.TabIndex = 18
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar1.Value = Global.gUiADE.My.MySettings.Default.Volume
        '
        'PeakMeterCtrl2
        '
        Me.PeakMeterCtrl2.BackColor = System.Drawing.Color.Black
        Me.PeakMeterCtrl2.BandsCount = 2
        Me.PeakMeterCtrl2.ColorHigh = System.Drawing.Color.Red
        Me.PeakMeterCtrl2.ColorHighBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl2.ColorMedium = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PeakMeterCtrl2.ColorMediumBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl2.ColorNormal = System.Drawing.Color.Maroon
        Me.PeakMeterCtrl2.ColorNormalBack = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl2.FalloffColor = System.Drawing.Color.Gray
        Me.PeakMeterCtrl2.GridColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PeakMeterCtrl2.LEDCount = 10
        Me.PeakMeterCtrl2.Location = New System.Drawing.Point(8, 27)
        Me.PeakMeterCtrl2.Name = "PeakMeterCtrl2"
        Me.PeakMeterCtrl2.ShowGrid = False
        Me.PeakMeterCtrl2.Size = New System.Drawing.Size(18, 108)
        Me.PeakMeterCtrl2.TabIndex = 17
        Me.PeakMeterCtrl2.Text = "PeakMeterCtrl2"
        '
        'PeakMeterCtrl1
        '
        Me.PeakMeterCtrl1.BackColor = System.Drawing.Color.Black
        Me.PeakMeterCtrl1.BandsCount = 2
        Me.PeakMeterCtrl1.ColorHigh = System.Drawing.Color.Red
        Me.PeakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl1.ColorMedium = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PeakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl1.ColorNormal = System.Drawing.Color.Maroon
        Me.PeakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PeakMeterCtrl1.FalloffColor = System.Drawing.Color.Gray
        Me.PeakMeterCtrl1.GridColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PeakMeterCtrl1.LEDCount = 10
        Me.PeakMeterCtrl1.Location = New System.Drawing.Point(522, 27)
        Me.PeakMeterCtrl1.Name = "PeakMeterCtrl1"
        Me.PeakMeterCtrl1.ShowGrid = False
        Me.PeakMeterCtrl1.Size = New System.Drawing.Size(18, 108)
        Me.PeakMeterCtrl1.TabIndex = 16
        Me.PeakMeterCtrl1.Text = "PeakMeterCtrl1"
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
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.CheckNtsc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ComboSampler)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Time:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 182)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Resampler:"
        '
        'ComboSampler
        '
        Me.ComboSampler.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ComboSampler.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.gUiADE.My.MySettings.Default, "Resampler", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ComboSampler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboSampler.ForeColor = System.Drawing.Color.DarkOrange
        Me.ComboSampler.FormattingEnabled = True
        Me.ComboSampler.Items.AddRange(New Object() {"NONE", "DEFAULT", "SINC"})
        Me.ComboSampler.Location = New System.Drawing.Point(98, 179)
        Me.ComboSampler.Name = "ComboSampler"
        Me.ComboSampler.Size = New System.Drawing.Size(92, 21)
        Me.ComboSampler.TabIndex = 33
        Me.ComboSampler.Text = Global.gUiADE.My.MySettings.Default.Resampler
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Checked = Global.gUiADE.My.MySettings.Default.PostProcess
        Me.CheckBox5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.gUiADE.My.MySettings.Default, "PostProcess", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.CheckBox5.ForeColor = System.Drawing.Color.White
        Me.CheckBox5.Location = New System.Drawing.Point(89, 157)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(88, 17)
        Me.CheckBox5.TabIndex = 26
        Me.CheckBox5.Text = "&Post-Process"
        Me.CheckBox5.UseVisualStyleBackColor = True
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
        'TimerAudio
        '
        Me.TimerAudio.Interval = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.gUiADE.My.Resources.Resources.Clock
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(12, 413)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox2.TabIndex = 36
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, "Set Sleep Time interval to run UADE (def value is 500)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Increase this value if y" &
        "ou have problem to start UADE)")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(584, 441)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckQuad)
        Me.Controls.Add(Me.CheckWAV)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gUiADE"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericGAIN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericPANNING, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CheckQuad As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboSampler As ComboBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckNtsc As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents PeakMeterCtrl2 As Ernzo.WinForms.Controls.PeakMeterCtrl
    Friend WithEvents PeakMeterCtrl1 As Ernzo.WinForms.Controls.PeakMeterCtrl
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents TimerAudio As Timer
    Friend WithEvents PictureBox2 As PictureBox
End Class
