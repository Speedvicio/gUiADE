Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
    Dim IdUADE As Integer()
    Dim pModule, arg, pList As String
    Dim pfc As New PrivateFontCollection()

    Dim imgPlay As Image = My.Resources.play
    Dim imgStop As Image = My.Resources._stop

    Dim pUADE() As Process
    Private SW As New Stopwatch

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Archive Files|*.lha;*.lhz;*.zip;*.7z;*.rar|All Files|*.*"
        OpenFileDialog1.FilterIndex = 2
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ListBox1.Items.Clear()
            DeleteTemp()
            pModule = OpenFileDialog1.FileName
            Select Case Path.GetExtension(pModule)
                Case ".lhz", ".lha", ".zip", ".7z", ".rar"
                    DecompressArchive(pModule)
                    pModule = Path.Combine(Application.StartupPath, "temp")
                    PrepareList()
                Case Else
                    PlayModule()
            End Select

        End If
    End Sub

    Private Sub PlayModule()
        Dim txt As StreamWriter
        If pModule.Trim <> "" Then
            UseThread("stop")
            Action_UADE("kill")
            MakeBat(txt, "info", "--detect-format-by-content -g ", "err")
            Retrieve_Info()
            Threading.Thread.Sleep(1000)

            'arg = "-w -1 -y -1 "
            UseThread("start")
        End If
    End Sub

    Private Sub Retrieve_Info()
        Label1.Text = ""
        Dim pfile = Path.Combine(Application.StartupPath, "err.txt")
        Dim reader As New StreamReader(pfile)
        Dim a, mn As String
        Dim asp As String()

        mn = Path.GetFileName(pModule)

        Do While reader.Peek() <> -1
            a = reader.ReadLine()

            If a.Contains(":") Then asp = a.Trim.Split(":")

            If a.Trim <> "" Then
                If a.Contains("playername:") Then
                    Label1.Text = "Player Name: " & asp(1) & vbCrLf & vbCrLf
                ElseIf a.Contains("modulename:") Then
                    Label1.Text = "Module Name: " & asp(1) & vbCrLf & vbCrLf
                ElseIf a.Contains("formatname: type:") Then
                    Label1.Text = "Format Type: " & asp(2)
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
        If Label1.Text.Contains("modulename:") = False Then Label1.Text += "File Name: " & mn
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Control_UADE("c")

        If Button2.BackgroundImage Is imgStop Then
            Button2.BackgroundImage = imgPlay
            Timer1.Start()
        Else
            Button2.BackgroundImage = imgStop
            Timer1.Stop()
        End If
    End Sub

    Private Sub UADE_start(mode As String)
        Label1.Image = My.Resources.g_empty

        Dim mDir = Path.GetDirectoryName(pModule)
        Dim mFile = Path.GetFileName(pModule)

        Dim wdir = Path.Combine(Application.StartupPath, Path.Combine("Player", "uade213"))
        Dim oProcess As New Process()
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

        oStartInfo.Arguments = "--cygwin --speed-hack " & arg & cPar & Chr(34) & Replace(pModule, "\", "/") & Chr(34)

        oProcess.StartInfo = oStartInfo
        oProcess.Start()
        IdUADE(0) = oProcess.Id
        If oProcess.HasExited Then UseThread("stop") : Exit Sub

        Try
            If CheckConsole.Checked = False And CheckLoop.Checked = False Then
                Do
                    Invoke(MethodDelegateAddText, oProcess.StandardOutput.ReadLine())
                Loop Until oProcess.StandardOutput.ReadLine() Is Nothing
            End If
        Catch
            SW.Reset()
            Timer1.Stop()
            If CheckWAV.Checked = True Then MsgBox("Tunes converted in wav format!", vbOKOnly + MsgBoxStyle.Information, "Conversion done...")
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

    Sub UseThread(action As String)
        Dim t As New Threading.Thread(AddressOf UADE_start)
        If action = "start" Then
            SetPar()
            SW.Reset()
            t.Start()
            Threading.Thread.Sleep(500)
            Timer1.Start()
            SW.Start()
            CheckConsole.Enabled = False
            CheckWAV.Enabled = False
            CheckQuad.Enabled = False
            Button2.BackgroundImage = imgPlay
            If Label1.Text = "" Then Retrieve_Info()

        ElseIf action = "stop" Then
            arg = Nothing
            t.Abort()
            Threading.Thread.Sleep(500)
            SW.Reset()
            Timer1.Stop()
            CheckConsole.Enabled = True
            CheckWAV.Enabled = True
            wavstate()
            labelMin.Text = "- A Crappy Frontend for UADE -"
            Button2.BackgroundImage = imgStop
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Control_UADE("b")
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

    Private Function Action_UADE(action As String) As Integer
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
                        Label1.Image = My.Resources.Guru_meditation
                    Case "killMantain"
                        p.Kill()
                    Case Else
                        IdUADE(Action_UADE) = p.Id
                End Select
            End If
        Next
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Control_UADE("z")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CheckConsole.Enabled = True
        Control_UADE("n")
        UseThread("stop")
        Action_UADE("kill")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Action_UADE("kill")
        Me.Icon = My.Resources.uade
        Label1.Image = My.Resources.guiade
        Button2.BackgroundImage = imgStop
        Button4.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY)
        SetFont()
        SetCursor()
    End Sub

    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Action_UADE("kill")
        UseThread("stop")
        DeleteTemp()
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
        arg = "-s " & ListBox1.SelectedIndex & " "
        UseThread("start")
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        pModule = Path.Combine(TreeView1.Nodes(0).Tag, TreeView1.SelectedNode.FullPath)
        If Path.GetExtension(pModule) <> "" Then PlayModule()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckConsole.CheckedChanged
        If CheckConsole.Checked = True Then
            Panel1.Enabled = True
        Else
            Panel1.Enabled = False
        End If
    End Sub

    Private Sub SetFont()
        Try

            Dim tempFilePath = Path.GetTempFileName()
            File.WriteAllBytes(tempFilePath, My.Resources.Topaz_a500_v1_0)

            pfc.AddFontFile(tempFilePath)
            Dim allCtrl As New List(Of Control)
            For Each ctrl As Control In FindALLControlRecursive(allCtrl, Me)
                If TypeOf ctrl Is Label Or TypeOf ctrl Is TextBox Or TypeOf ctrl Is Button Or TypeOf ctrl Is CheckBox Or TypeOf ctrl Is RadioButton Or TypeOf ctrl Is ProgressBar _
                Or TypeOf ctrl Is GroupBox Or TypeOf ctrl Is ListBox Or TypeOf ctrl Is TreeView Or TypeOf ctrl Is ComboBox Or TypeOf ctrl Is Form Then
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

    Private Function FindALLControlRecursive(ByVal list As List(Of Control), ByVal parent As Control) As List(Of Control)
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
            If Path.GetExtension(pModule) <> "" Then PlayModule()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        IsProcessRunning("uade123")

        If SW.IsRunning Then
            UpdateStopwatch()
        End If
    End Sub

    Public Function IsProcessRunning(name As String) As Boolean

        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then

                'process found so it's running so return true
                If CheckConsole.Checked = True Then
                    Dim hWnd As Long = clsProcess.MainWindowHandle
                    ShowWindow(hWnd, ShowWindowCommands.ForceMinimize)
                    clsProcess.StartInfo.WindowStyle = ProcessWindowStyle.Minimized
                End If

            End If

        Next

        'process not found, return false

        Return False

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
        Dim subsong As String
        If ListBox1.Items.Count < 1 Then
            subsong = "(0)"
        Else
            subsong = "(" & ListBox1.SelectedIndex & ")"
        End If

        Dim ts As TimeSpan = SW.Elapsed
        labelMin.Text = "Playing time " & String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10) &
                " in subsong " & subsong
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
            arg = "-s " & ListBox1.SelectedIndex & " "
            UseThread("start")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        MsgBox("gUiADE by Speedvicio", vbOKOnly + vbInformation, "About")
    End Sub

    Private Sub CheckWAV_CheckedChanged(sender As Object, e As EventArgs) Handles CheckWAV.CheckedChanged
        wavstate()
    End Sub

    Private Sub wavstate()
        If CheckWAV.Checked = True Then
            CheckQuad.Enabled = True
        Else
            CheckQuad.Checked = False
            CheckQuad.Enabled = False
        End If
    End Sub

    Private Sub SetCursor()
        Dim tempFilePath = Path.GetTempFileName()

        'scrivo la risorsa su un file temporaneo e ne prelievo il percorso
        File.WriteAllBytes(tempFilePath, My.Resources.amiga_arrow)
        Me.Cursor = NativeMethods.LoadCustomCursor(tempFilePath)

        'Delete file when done.
        File.Delete(tempFilePath)
    End Sub

    Private Sub SetPar()

        If CheckWAV.Checked = True Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "Wave File|*.wav"
            saveFileDialog1.Title = "Save in WAV audio format"
            saveFileDialog1.DefaultExt = ".wav"

            If TreeView1.Nodes.Count > 0 Then
                Dim wfile As String = TreeView1.SelectedNode.FullPath & " - "

                If wfile.Contains("\") Then
                    Dim wsfile() As String = wfile.Split("\")
                    wfile = ""
                    For i = wsfile.Length - 2 To wsfile.Length - 1
                        wfile += wsfile(i) & " - "
                    Next i
                End If

                saveFileDialog1.FileName = wfile & "subsong " & ListBox1.SelectedIndex.ToString
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

        If CheckLoop.Checked Then
            arg += "-n "
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
        End If

        If CheckBox3.Checked Then
            arg += "-G " & NumericGAIN.Value & " "
        End If

    End Sub

End Class