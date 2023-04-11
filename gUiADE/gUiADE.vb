Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices

Public Class gUiADE
    Dim IdUADE As Integer()
    Dim TSleep As Decimal
    Dim pList As String
    Dim pfc As New PrivateFontCollection()
    Dim full_arg As String
    Dim VuMeter As Boolean = True

    Public arg, pModule, plst As String

    Dim imgPlay As Image = My.Resources.play
    Dim imgStop As Image = My.Resources._stop

    Dim uade As Boolean

    Dim oProcess As New Process()
    Dim pUADE() As Process
    Private SW As New Stopwatch

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Archive Files|*.lha;*.lhz;*.zip;*.7z;*.rar|All Files|*.*"
        OpenFileDialog1.FilterIndex = 2
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            arg = ""
            ListBox1.Items.Clear()
            DeleteTemp()
            pModule = OpenFileDialog1.FileName
            Select Case Path.GetExtension(pModule)
                Case ".ade"
                    If Playlist.Visible = False Then Playlist.Show() : Button9.BackgroundImage = My.Resources.informationR
                    plst = pModule
                    Playlist.LoadADE(plst)
                Case ".lhz", ".lha", ".zip", ".7z", ".rar"
                    DecompressArchive(pModule)
                    pModule = Path.Combine(Application.StartupPath, "temp")
                    PrepareList()
                Case Else
                    PlayModule()
            End Select

        End If
    End Sub

    Public Sub PlayModule()
        uade = True

        If pModule.Trim <> "" Then
            UseThread("stop")
            Action_UADE("kill")
            'Retrieve_Info()
            'arg = "-w -1 -y -1 "
            If uade = True Then UseThread("start")

        End If
    End Sub

    Private Sub Retrieve_Info()

        Dim txt As StreamWriter
        MakeBat(txt, "info", "--detect-format-by-content -g ", "err")
        Threading.Thread.Sleep(1000)
        Label1.Text = ""

        Dim pfile = Path.Combine(Application.StartupPath, "err.txt")
        If FileNotUsed(pfile) = True Then
            Dim reader As New StreamReader(pfile)
            Dim a, mn As String
            Dim asp As String()

            mn = Path.GetFileName(pModule)

            If reader.Peek() = -1 Then
                reader.Close()
                Label1.Image = My.Resources.Guru_meditation
                labelMin.Text = "This file is not supported by UADE, select another file"
                MsgBox("This file is not supported by UADE", MsgBoxStyle.Critical + vbOKOnly, "Unknown format...")
                uade = False
                Exit Sub
            End If

            Do While reader.Peek() <> -1
                a = reader.ReadLine()

                If a.Contains(":") Then asp = a.Trim.Split(":")

                If a.Trim <> "" Then
                    If a.Contains("playername:") Then
                        Label1.Text = "Player Name: " & asp(1) & vbCrLf & vbCrLf
                    ElseIf a.Contains("modulename:") Then
                        Label1.Text += "Module Name: " & asp(1) & vbCrLf & vbCrLf
                    ElseIf a.Contains("formatname: type:") Then
                        Label1.Text += "Format Type: " & asp(2)
                        If Label1.Text.Contains("Module Name:") = False Then Label1.Text += vbCrLf & vbCrLf
                    ElseIf a.Contains("subsong_info:") Then
                        Dim b As String()
                        b = a.Split(" ")
                        ListBox1.Items.Clear()
                        If Val(b(3)) > 0 Then
                            For i = 0 To Val(b(3))
                                ListBox1.Items.Add("- Subsong (" & i & ")")
                            Next
                            If ListBox1.Items.Count > 1 Then ListBox1.SelectedIndex = b(1)
                        End If
                    End If
                End If
            Loop

            reader.Close()
            If Label1.Text.Contains("Module Name:") = False Then Label1.Text += "File Name: " & mn
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Control_UADE("c")

        If Button2.BackgroundImage Is imgStop Then
            Button2.BackgroundImage = imgPlay
            Timer1.Start()
            TimerAudio.Start()
        Else
            Button2.BackgroundImage = imgStop
            Timer1.Stop()
            Threading.Thread.Sleep(TSleep)
            TimerAudio.Stop()
        End If
    End Sub

    Private Sub UADE_start(mode As String)
        'Label1.Image = My.Resources.g_empty
        Label1.Image = Nothing
        Dim mDir = Path.GetDirectoryName(pModule)
        Dim mFile = Path.GetFileName(pModule)

        Dim wdir = Path.Combine(Application.StartupPath, Path.Combine("Player", "uade213"))
        'dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo
        oStartInfo.WorkingDirectory = wdir
        oStartInfo.FileName = Path.Combine(wdir, "uade123")
        'oStartInfo.WindowStyle = ProcessWindowStyle.Minimized

        If CheckConsole.Checked = False Then
            oStartInfo.CreateNoWindow = True
            oStartInfo.UseShellExecute = False
            oStartInfo.RedirectStandardOutput = True
            oStartInfo.RedirectStandardError = True
            oStartInfo.RedirectStandardInput = True
        Else
            oStartInfo.WindowStyle = ProcessWindowStyle.Minimized
        End If

        Dim cPar As String = TextBox1.Text.Trim
        If cPar <> "" Then
            If cPar.EndsWith(" ") = False Then cPar += " "
        End If

        full_arg = "--cygwin --speed-hack " & arg & cPar & Chr(34) & Replace(pModule, "\", "/") & Chr(34)
        oStartInfo.Arguments = full_arg

        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        IdUADE(0) = oProcess.Id

        If oProcess.HasExited Then
            UseThread("stop")
            SW.Reset()
            Timer1.Stop()
            Threading.Thread.Sleep(TSleep)
            TimerAudio.Stop()
            If CheckWAV.Checked = True Then MsgBox("Tunes converted in wav format!", vbOKOnly + MsgBoxStyle.Information, "Conversion done...")
            Exit Sub
        End If

        Try
            If CheckConsole.Checked = False And CheckLoop.Checked = False Then
                Do
                    Invoke(MethodDelegateAddText, oProcess.StandardOutput.ReadLine())
                Loop Until oProcess.StandardOutput.ReadLine() Is Nothing
            End If
        Catch
        End Try

        Try
            If CheckConsole.Checked = False Then
                File.WriteAllText(Path.Combine(Application.StartupPath, "out.txt"), oProcess.StandardOutput.ReadToEnd())
                File.WriteAllText(Path.Combine(Application.StartupPath, "err.txt"), oProcess.StandardError.ReadToEnd())
                File.WriteAllText(Path.Combine(Application.StartupPath, "inp.txt"), oProcess.StandardError.ReadToEnd())
            End If
        Catch
        End Try

    End Sub

    Private Delegate Sub DelegateAddText(ByVal str As String)

    Private MethodDelegateAddText As New DelegateAddText(AddressOf AddText)

    Private Sub AddText(ByVal str As String)
        'labelMin.Text = str.Trim
        Dim splitsong() As String
        splitsong = str.Trim.Split(" ")
        If ListBox1.SelectedIndex <> splitsong(6).Trim() Then
            ListBox1.SelectedIndex = splitsong(6).Trim()
        End If

    End Sub

    Public Sub UseThread(action As String)

        If CheckWAV.Checked = True Then
            Timer1.Interval = TSleep / 10
        Else
            Timer1.Interval = TSleep
        End If

        Dim t As New Threading.Thread(AddressOf UADE_start)
        If action = "start" Then
            If Label1.Text = "" Then Retrieve_Info()
            SetPar()
            SW.Reset()
            t.Start()
            Threading.Thread.Sleep(2000)
            Timer1.Start()
            SW.Start()
            Button2.BackgroundImage = imgPlay
            CheckConsole.Enabled = False
            CheckWAV.Enabled = False
            CheckQuad.Enabled = False
            If pModule.Contains(Path.Combine(Application.StartupPath, "temp")) = False Then
                Button5.Enabled = True
                Button5.BackgroundImage = My.Resources.plus
            End If
        ElseIf action = "stop" Then
            'arg = Nothing
            t.Abort()
            Threading.Thread.Sleep(500)
            SW.Reset()
            Timer1.Stop()
            Threading.Thread.Sleep(TSleep)
            TimerAudio.Stop()
            wavstate()
            Label1.Text = ""
            labelMin.Text = "- A Crappy Frontend for UADE -"
            Button2.BackgroundImage = imgStop
            CheckConsole.Enabled = True
            CheckWAV.Enabled = True
            Button5.Enabled = False
            Button5.BackgroundImage = My.Resources.plus_
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SW.Reset()
        Control_UADE("b")
        Threading.Thread.Sleep(TSleep)
        SW.Start()
    End Sub

    Private Function Control_UADE(btn As String)

        Select Case btn
            Case "b", "z"
                If ListBox1.Items.Count >= 1 Then
                    If btn = "b" And ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
                        ListBox1.SelectedIndex += 1
                    ElseIf btn = "z" And ListBox1.SelectedIndex > 0 Then
                        ListBox1.SelectedIndex -= 1
                    Else
                        Exit Function
                    End If
                Else
                    Exit Function
                End If
        End Select

        If Action_UADE("") = 0 Then Exit Function
        For i = 0 To IdUADE.Length - 1
            Try
                AppActivate(IdUADE(i))
                If Control.IsKeyLocked(Keys.CapsLock) Then
                    Select Case btn
                        Case "N", "H"
                        Case Else
                            My.Computer.Keyboard.SendKeys("+(" & btn & ")", True)
                            Exit Function
                    End Select
                End If
                My.Computer.Keyboard.SendKeys(btn, True)
            Catch
            End Try
        Next

    End Function

    Public Function Action_UADE(action As String) As Integer
        Dim prox() As Process
        prox = Process.GetProcesses()
        IdUADE = New Integer() {0, 0, 0}
        For Each p As Process In prox
            If p.ProcessName = "uade123" Then
                Action_UADE += 1
                Select Case action
                    Case "kill"
                        p.Kill()
                        Label1.Text = ""
                        labelMin.Text = "- A Crappy Frontend for UADE -"
                        Label1.Image = My.Resources.guiade
                    Case "killMantain"
                        p.Kill()
                    Case Else
                        IdUADE(Action_UADE) = p.Id
                End Select
            End If
        Next
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SW.Reset()
        Control_UADE("z")
        Threading.Thread.Sleep(TSleep)
        SW.Start()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CheckConsole.Enabled = True
        Control_UADE("n")
        UseThread("stop")
        Action_UADE("kill")
        Label1.Image = My.Resources.guiade
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TSleep = My.Settings.TSleep
        If TSleep = 0 Then TSleep = 100
        Timer1.Interval = TSleep
        Action_UADE("kill")
        StartPeak()
        Me.Icon = My.Resources.uade
        Label1.Image = My.Resources.guiade
        Button2.BackgroundImage = imgStop
        Button4.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY)
        SetFont(Me)
        SetCursor(Me)
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Action_UADE("kill")
        UseThread("stop")
        DeleteTemp()
        ResetVol()
    End Sub

    Private Sub MakeBat(testo As StreamWriter, nBat As String, bPar As String, dbName As String)
        Dim uPExe As String = Path.Combine(Application.StartupPath, Path.Combine("Player", "uade213"))
        testo = My.Computer.FileSystem.OpenTextFileWriter(Path.Combine(uPExe, nBat & ".bat"), False)
        testo.WriteLine("@ECHO OFF" & vbCrLf & "uade123.exe --cygwin " & bPar & Chr(34) & pModule & Chr(34) & " > " & Chr(34) & Path.Combine(Application.StartupPath, dbName & ".txt") & Chr(34))
        testo.Close()

        Dim processinfo As New ProcessStartInfo()
        processinfo.WindowStyle = ProcessWindowStyle.Minimized
        processinfo.WorkingDirectory = uPExe
        processinfo.FileName = nBat
        Dim prox As Process = Process.Start(processinfo)
        If nBat <> "makelist" Then IdUADE(0) = prox.Id
        prox.WaitForExit()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim txt As StreamWriter
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            ListBox1.Items.Clear()
            DeleteTemp()
            pModule = FolderBrowserDialog1.SelectedPath
            'Action_UADE("kill")
            PrepareList()
        End If
    End Sub

    Private Sub PrepareList()
        Dim txt As StreamWriter

        pList = pModule
        MakeBat(txt, "makelist", "--scan -r --stderr ", "modulelist_CgWin")
        Dim modulelist As String = Path.Combine(Application.StartupPath, "modulelist_CgWin.txt")
        If File.Exists(modulelist) = False Then Exit Sub

        If File.ReadAllText(modulelist).Length = 0 Then
            MsgBox("No supported module in this folder", MsgBoxStyle.Information + vbOKOnly, "No module...")
            Exit Sub
        Else
            If File.Exists(Replace(modulelist, "_CgWin", "")) Then My.Computer.FileSystem.DeleteFile(Replace(modulelist, "_CgWin", ""))
        End If

        Dim reader As New StreamReader(modulelist)
        Dim a As String
        Do While reader.Peek() <> -1
            a = Replace(reader.ReadLine(), "/cygdrive/", "")
            a = a.Substring(0, 1) + ":" + a.Substring(1)
            txt = My.Computer.FileSystem.OpenTextFileWriter(Path.Combine(Application.StartupPath, "modulelist.txt"), True)
            txt.WriteLine(Replace(a, "/", "\"))
            txt.Close()
        Loop
        reader.Close()

        My.Computer.FileSystem.DeleteFile(modulelist)
        Dim NodeDataFile As String = Path.Combine(Application.StartupPath, "modulelist.txt")
        If File.Exists(NodeDataFile) Then
            LoadNodes(NodeDataFile)
        End If
    End Sub

    Private Sub LoadNodes(ByVal filePath As String)
        TreeView1.Nodes.Clear()
        Dim modlist As New List(Of String)
        Dim reader As New StreamReader(filePath)
        Dim a As String
        TreeView1.Nodes.Add(pList)
        TreeView1.Nodes(0).Tag = pList
        TreeView1.Nodes(0).Text = Replace(pList, Path.GetDirectoryName(pList) & "\", "")
        Do While reader.Peek() <> -1

            a = reader.ReadLine()
            a = Replace(a, pList & "\", "")
            Dim sb() As String = Split(a, vbCrLf)

            If sb.Length > 0 Then
                For i As Integer = 0 To sb.Length - 1
                    modlist.Add(sb(i).Trim.ToString)
                Next
            End If
        Loop
        reader.Close()
        PopulateTreeView(TreeView1, modlist, "\")
    End Sub

    Private Shared Sub PopulateTreeView(ByVal treeView As TreeView, ByVal paths As IEnumerable(Of String), ByVal pathSeparator As Char)
        Dim lastNode As TreeNode = Nothing
        Dim subPathAgg As String
        For Each path As String In paths
            subPathAgg = String.Empty

            For Each subPath As String In path.Split(pathSeparator)
                subPathAgg += subPath & pathSeparator
                Dim nodes As TreeNode() = treeView.Nodes.Find(subPathAgg, True)

                If nodes.Length = 0 Then

                    If lastNode Is Nothing Then
                        lastNode = treeView.Nodes.Add(subPathAgg, subPath)
                    Else
                        lastNode = lastNode.Nodes.Add(subPathAgg, subPath)
                    End If
                Else
                    lastNode = nodes(0)
                End If
                lastNode.BackColor = Color.Black
                lastNode.ForeColor = Color.DarkOrange
            Next
            lastNode = Nothing
        Next
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.Items.Count < 1 Then Exit Sub
        Action_UADE("killMantain")
        arg = ""
        arg = "-s " & ListBox1.SelectedIndex & " "
        UseThread("start")
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        pModule = Path.Combine(TreeView1.Nodes(0).Tag, TreeView1.SelectedNode.FullPath)
        If Path.GetExtension(pModule) <> "" Then arg = "" : PlayModule()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckConsole.CheckedChanged
        If CheckConsole.Checked = True Then
            Panel1.Enabled = True
        Else
            Panel1.Enabled = False
        End If
    End Sub

    Public Sub SetFont(box As Control)
        Try

            Dim tempFilePath = Path.GetTempFileName()
            File.WriteAllBytes(tempFilePath, My.Resources.Topaz_a500_v1_0)

            pfc.AddFontFile(tempFilePath)
            Dim allCtrl As New List(Of Control)
            For Each ctrl As Control In FindALLControlRecursive(allCtrl, box)
                If TypeOf ctrl Is Label Or TypeOf ctrl Is TextBox Or TypeOf ctrl Is Button Or TypeOf ctrl Is CheckBox Or TypeOf ctrl Is RadioButton Or TypeOf ctrl Is ProgressBar _
                Or TypeOf ctrl Is GroupBox Or TypeOf ctrl Is ListBox Or TypeOf ctrl Is TreeView Or TypeOf ctrl Is ComboBox Or TypeOf ctrl Is Label Or TypeOf ctrl Is Form Then
                    If ctrl.Tag = "menot" Then Continue For
                    Dim CurrentCtrlFontSize = 11
                    ctrl.Font = New Font(pfc.Families(0), CurrentCtrlFontSize, FontStyle.Regular)
                    If ctrl.BackColor = Color.DarkOrange Then ctrl.BackColor = ColorTranslator.FromHtml("#ff8800")
                    If ctrl.BackColor = Color.FromKnownColor(KnownColor.HotTrack) Then ctrl.BackColor = ColorTranslator.FromHtml("#0055aa")
                End If
            Next
            allCtrl.Clear()
        Catch
        End Try
    End Sub

    Public Function FindALLControlRecursive(ByVal list As List(Of Control), ByVal parent As Control) As List(Of Control)
        If parent Is Nothing Then
            Return list
        Else
            list.Add(parent)
        End If
        For Each child As Control In parent.Controls
            FindALLControlRecursive(list, child)
        Next
        Return list
    End Function

    Private Sub TreeView1_KeyUp(sender As Object, e As KeyEventArgs) Handles TreeView1.KeyUp
        e.SuppressKeyPress = True
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            pModule = Path.Combine(TreeView1.Nodes(0).Tag, TreeView1.SelectedNode.FullPath)
            If Path.GetExtension(pModule) <> "" Then arg = "" : PlayModule()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If IsProcessRunning("uade123") = False Then
            Label1.Text = ""
            Label1.Image = My.Resources.guiade
            Control_UADE("n")
            UseThread("stop")
            Action_UADE("kill")
            If CheckWAV.Checked = True Then
                CheckConsole.Enabled = True
                MsgBox("Tunes converted in wav format!", vbOKOnly + MsgBoxStyle.Information, "Conversion done...")
            End If
            Threading.Thread.Sleep(TSleep)
            TimerAudio.Stop()
        Else
            TimerAudio.Start()
        End If

    End Sub

    Public Function IsProcessRunning(name As String) As Boolean

        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                'Process found so it's running so return true
                If CheckConsole.Checked = True Then
                    Dim hWnd As Long = clsProcess.MainWindowHandle
                    ShowWindow(hWnd, ShowWindowCommands.ForceMinimize)
                    clsProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
                End If
                Return True
                'Exit For
            End If
        Next

        'process not found, return false

        'Return False

    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As ShowWindowCommands) As Boolean
    End Function

    Enum ShowWindowCommands As Integer
        Hide = 0
        Normal = 1
        ShowMinimized = 2
        Maximize = 3
        ShowMaximized = 3
        ShowNoActivate = 4
        Show = 5
        Minimize = 6
        ShowMinNoActive = 7
        ShowNA = 8
        Restore = 9
        ShowDefault = 10
        ForceMinimize = 11
    End Enum

    Private Sub UpdateStopwatch()
        Dim subsong() As String
        Dim ssng As String = ""

        If arg.Contains("-s ") Then
            subsong = arg.Split(" ")
            ssng = " in subsong " & subsong(1)
        End If

        'If ListBox1.Items.Count < 1 Then
        'subsong = "(0)"
        'Else
        'subsong = "(" & ListBox1.SelectedIndex & ")"
        'End If

        Dim ts As TimeSpan = SW.Elapsed
        labelMin.Text = "Playing time " & String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10) & ssng

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Control_UADE("f")
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        Control_UADE("g")
        If CheckBox3.Checked = True Then
            CheckBox4.Checked = False
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        Control_UADE("N")
        If CheckBox4.Checked = True Then
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        Control_UADE("p")
        If CheckBox5.Checked = True Then
            CheckBox4.Enabled = True
            ButtonHEAFSET.Enabled = True
        Else
            CheckBox4.Enabled = False
            ButtonHEAFSET.Enabled = False
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        Control_UADE("P")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles ButtonHEAFSET.Click
        Control_UADE("H")

        If CheckConsole.Checked = True And ButtonHEAFSET.Text = 1 Then
            ButtonHEAFSET.Text = 0
            Exit Sub
        End If

        Select Case ButtonHEAFSET.Text
            Case 2
                ButtonHEAFSET.Text = 0
                Exit Sub
        End Select

        ButtonHEAFSET.Text += 1
    End Sub

    Private Sub ListBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyUp
        e.SuppressKeyPress = True
        If ListBox1.Items.Count < 1 Then Exit Sub
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            Action_UADE("killMantain")
            arg = ""
            arg = "-s " & ListBox1.SelectedIndex & " "
            UseThread("start")
        End If
    End Sub

    Private Sub CheckWAV_CheckedChanged(sender As Object, e As EventArgs) Handles CheckWAV.CheckedChanged
        wavstate()
    End Sub

    Private Sub wavstate()
        Try
            If CheckWAV.Checked = True Then
                CheckQuad.Enabled = True
                CheckConsole.Checked = False
            Else
                CheckQuad.Checked = False
                CheckQuad.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Protected Function FileNotUsed(ByVal sPathFile As String) As Boolean
        Dim bRet As Boolean = False
        Try
            Dim bNotUsed As Boolean = False
            Dim dtStart As DateTime = DateTime.Now
            Dim fsFile As IO.FileStream = Nothing

            While Not bNotUsed
                Try
                    fsFile = IO.File.Open(sPathFile, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None)
                    bNotUsed = True
                Catch ex As Exception
                Finally
                    If Not IsNothing(fsFile) Then fsFile.Close()
                    If Not IsNothing(fsFile) Then fsFile.Dispose()
                    fsFile = Nothing
                End Try

                Dim tsDiff As TimeSpan = dtStart - DateTime.Now
                If tsDiff.TotalMinutes > 1 Then Throw New Exception("File utilizzato da un altro processo")
                Threading.Thread.Sleep(200)
            End While

            bRet = True
        Catch ex As Exception

        End Try
        Return bRet
    End Function

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        VolumeScroll()
    End Sub

    Private Sub TimerAudio_Tick(sender As Object, e As EventArgs) Handles TimerAudio.Tick
        If SW.IsRunning Then
            UpdateStopwatch()
            If VuMeter = True Then MovePeak()
        End If
    End Sub

    Public Sub SetCursor(box As Control)
        Dim tempFilePath = Path.GetTempFileName()

        'scrivo la risorsa su un file temporaneo e ne prelievo il percorso
        File.WriteAllBytes(tempFilePath, My.Resources.amiga_arrow)
        box.Cursor = NativeMethods.LoadCustomCursor(tempFilePath)

        'Delete file when done.
        File.Delete(tempFilePath)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim message, title, defaultValue As String
        Dim myValue As Object
        message = "Set Interval and Sleep Timer to run UADE" & vbCrLf & "Use value between 50 to 1000 - Def value is 100" &
             vbCrLf & "On wave export the value will be divided by 10"
        title = "Interval/Sleep Timer"
        defaultValue = TSleep
        myValue = InputBox(message, title, defaultValue)
        If myValue = "" Then Exit Sub

        If myValue > 1000 Or myValue < 50 Then
            MsgBox("Use value between 50 to 1000", vbExclamation + vbOKOnly, "Wrong value...")
            Exit Sub
        Else
            TSleep = myValue
            My.Settings.TSleep = TSleep
            Timer1.Interval = TSleep
        End If

    End Sub

    Private Sub PeakMeterCtrl1_Click(sender As Object, e As EventArgs) Handles PeakMeterCtrl1.Click
        VMeterState()
    End Sub

    Private Sub VMeterState()
        If VuMeter = True Then
            VuMeter = False
        Else
            VuMeter = True
        End If
    End Sub

    Private Sub PeakMeterCtrl2_Click(sender As Object, e As EventArgs) Handles PeakMeterCtrl2.Click
        VMeterState()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If Button9.Tag = "InfoOff" Then
            Button9.BackgroundImage = My.Resources.informationR
            Button9.Tag = "InfoOn"
            Playlist.Show()
            If Path.GetExtension(plst) = ".ade" Then Playlist.LoadADE(plst)
        Else
            Button9.BackgroundImage = My.Resources.informationG
            Button9.Tag = "InfoOff"
            Playlist.Close()
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        If Playlist.Visible = False Then Playlist.Show()

        Dim test() As String
        Dim subsong As String
        test = full_arg.Split("""")
        Dim TunePath As String = test(1).ToString.Trim
        If test(0).Contains(" -s ") Then
            test = test(0).Split(" ")
            subsong = test(3).Trim
        End If

        If TunePath.Trim <> "" Then
            Dim PlsDirectory() As String = TunePath.Split("/")

            Dim Values() As String = {Path.GetFileName(TunePath), subsong, Path.GetDirectoryName(TunePath), PlsDirectory(PlsDirectory.Length - 2)}
            If Playlist.DataGridView1.Rows.Count <= 0 Then
                Playlist.DataGridView1.Rows.Add(Values)
            Else
                If Playlist.ControlRow(Values) = False Then
                    Playlist.DataGridView1.Rows.Add(Values)
                End If
            End If
        End If

    End Sub

    Private Sub SetPar()

        If CheckWAV.Checked = True Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Wave File|*.wav"
            saveFileDialog1.Title = "Save in WAV audio format"
            saveFileDialog1.DefaultExt = ".wav"

            If TreeView1.Nodes.Count > 0 Then
                If TreeView1.SelectedNode IsNot Nothing Then
                    Dim wfile As String = TreeView1.SelectedNode.FullPath

                    If wfile.Contains("\") Then
                        Dim wsfile() As String = wfile.Split("\")
                        wfile = ""
                        For i = wsfile.Length - 2 To wsfile.Length - 1
                            wfile += wsfile(i) & " - "
                        Next i
                    End If

                    If wfile.Contains(Path.GetFileName(pModule)) Then
                        saveFileDialog1.FileName = wfile & "subsong " & ListBox1.SelectedIndex.ToString
                    Else
                        saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(pModule)
                    End If
                Else
                    saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(pModule)
                End If
            Else
                saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(pModule)
            End If

            If saveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                If saveFileDialog1.OpenFile() IsNot Nothing Then
                    arg += "--one -f " & Chr(34) & saveFileDialog1.FileName & Chr(34) & " "
                End If
            Else
                CheckWAV.Checked = False
                wavstate()
            End If
        End If

        If CheckLoop.Checked = True And CheckWAV.Checked = True Then
            arg += "-n -t " & NumericUpDown1.Value & " -w " & NumericUpDown1.Value & " "
        ElseIf CheckLoop.Checked = True Then
            arg += "-n -t -1 -w -1 "
        Else
            arg += "-t " & NumericUpDown1.Value & " -w " & NumericUpDown1.Value & " -y 20 "

        End If

        If CheckNtsc.Checked Then
            arg += "--ntsc "
        End If

        If CheckQuad.Checked Then
            arg += "--quadmode "
        End If

        If CheckBox2.Checked Then
            arg += "--filter "
            arg += "--force-led=1 "
            arg += "--filter=" & ComboFILTER.Text & " "
        Else
            arg += "--force-led=0 "
        End If

        arg += "--resampler=" & LCase(ComboSampler.Text) & " "

        If CheckBox2.Checked Then
            Select Case ButtonHEAFSET.Text
                Case 1
                    arg += "--headphones "
                Case 2
                    arg += "--headphones2 "
            End Select

            If CheckBox4.Checked Then
                arg += "--normalise "
            End If
        End If

        If CheckBox6.Checked Then
            arg += "-p " & NumericPANNING.Value & " "
        Else
            arg += "-p 0 "
        End If

        If CheckBox3.Checked Then
            arg += "-G " & NumericGAIN.Value & " "
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button = MouseButtons.Right Then
            If File.Exists(Path.Combine(Application.StartupPath, "UADE readme.txt")) Then Process.Start(Path.Combine(Application.StartupPath, "UADE readme.txt"))
        ElseIf e.Button = MouseButtons.Left Then
            MsgBox("gUiADE by Speedvicio", vbOKOnly + vbInformation, "About")
        End If

    End Sub

End Class