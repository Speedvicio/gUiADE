Imports System.Drawing.Text
Imports System.Globalization
Imports System.IO

Public Class Form1
    Dim IdUADE As Integer()
    Dim pModule, arg, pList As String
    Dim pfc As New PrivateFontCollection()

    Dim imgPlay As Image = My.Resources.play
    Dim imgStop As Image = My.Resources._stop
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
            Action_UADE("kill")
            'arg = "--detect-format-by-content -g"
            'UADE_start("hide")
            MakeBat(txt, "info", "--detect-format-by-content -g ", "err")
            Retrieve_Info()
            Threading.Thread.Sleep(1000)

            arg = "-n --normalise -w -1 -y -1 "
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
        If CheckBox1.Checked = False Then
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
            'If CheckBox1.Checked = False Then
            'Do
            'Invoke(MethodDelegateAddText, oProcess.StandardOutput.ReadLine())
            'Loop Until oProcess.StandardOutput.ReadLine() Is Nothing
            'End If
        Catch
        End Try

        Try
            File.WriteAllText(Path.Combine(Application.StartupPath, "out.txt"), oProcess.StandardOutput.ReadToEnd())
            File.WriteAllText(Path.Combine(Application.StartupPath, "err.txt"), oProcess.StandardError.ReadToEnd())
            File.WriteAllText(Path.Combine(Application.StartupPath, "inp.txt"), oProcess.StandardError.ReadToEnd())
        Catch
        End Try
    End Sub

    'Private Delegate Sub DelegateAddText(ByVal str As String)

    'Private MethodDelegateAddText As New DelegateAddText(AddressOf AddText)

    'Private Sub AddText(ByVal str As String)
    '   labelMin.Text = str.Trim
    'End Sub

    Sub UseThread(action As String)

        Dim t As New Threading.Thread(AddressOf UADE_start)
        If action = "start" Then
            t.Start()
            Timer1.Start()
            SW.Start()
            CheckBox1.Enabled = False
            Button2.BackgroundImage = imgPlay
            If Label1.Text = "" Then Retrieve_Info()
        ElseIf action = "stop" Then
            t.Abort()
            SW.Reset()
            Timer1.Stop()
            CheckBox1.Enabled = True
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
        CheckBox1.Enabled = True
        Control_UADE("n")
        UseThread("stop")
        Action_UADE("kill")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.uade
        Label1.Image = My.Resources.guiade
        Button2.BackgroundImage = imgStop
        Button4.BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipY)
        SetFont()
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
        arg = "-n -s " & ListBox1.SelectedIndex & " "
        UseThread("start")
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        pModule = Path.Combine(TreeView1.Nodes(0).Tag, TreeView1.SelectedNode.FullPath)
        If Path.GetExtension(pModule) <> "" Then PlayModule()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel1.Enabled = True
        Else
            Panel1.Enabled = False
        End If
    End Sub

    Private Sub SetFont()
        Try
            pfc.AddFontFile(Path.Combine(Application.StartupPath, "Topaz_a500_v1.0.ttf"))
            Dim allCtrl As New List(Of Control)
            For Each ctrl As Control In FindALLControlRecursive(allCtrl, Me)
                If TypeOf ctrl Is Label Or TypeOf ctrl Is TextBox Or TypeOf ctrl Is Button Or TypeOf ctrl Is CheckBox Or TypeOf ctrl Is RadioButton Or TypeOf ctrl Is ProgressBar _
                Or TypeOf ctrl Is GroupBox Or TypeOf ctrl Is ListBox Or TypeOf ctrl Is TreeView Then
                    If ctrl.Tag = "menot" Then Continue For
                    Dim CurrentCtrlFontSize = 11
                    ctrl.Font = New Font(pfc.Families(0), CurrentCtrlFontSize, FontStyle.Regular)
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
        If SW.IsRunning Then
            UpdateStopwatch()
        End If
    End Sub

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

    Private Sub ListBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles ListBox1.KeyUp
        e.SuppressKeyPress = True
        If ListBox1.Items.Count < 1 Then Exit Sub
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            Action_UADE("killMantain")
            arg = "-n -s " & ListBox1.SelectedIndex & " "
            UseThread("start")
        End If
    End Sub

End Class