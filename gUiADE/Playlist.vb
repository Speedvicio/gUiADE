Imports System.IO

Public Class Playlist

    Private Sub Playlist_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Icon = My.Resources.uade
        gUiADE.SetFont(Me)
        gUiADE.SetCursor(Me)

        Me.Location = New Point(gUiADE.Location.X + gUiADE.Width + 14, gUiADE.Location.Y - ((Me.Height - gUiADE.Height) / 2))
    End Sub

    Private Sub Playlist_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        gUiADE.Button9.BackgroundImage = My.Resources.informationG
        gUiADE.Button9.Tag = "InfoOff"
    End Sub

    Public Function ControlRow(values() As String) As Boolean
        For i = 0 To DataGridView1.Rows.Count - 1
            Dim RetRow() As String = {DataGridView1.Rows(i).Cells(0).Value, DataGridView1.Rows(i).Cells(1).Value, DataGridView1.Rows(i).Cells(2).Value}
            If values(0) & values(1) & values(2) = RetRow(0) & RetRow(1) & RetRow(2) Then
                Return True
                Exit For
            End If
        Next
    End Function

    Private Sub ToolStripRem_Click_1(sender As Object, e As EventArgs) Handles ToolStripRem.Click
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
        ResizeADE()
    End Sub

    Private Sub ToolStripSave_Click(sender As Object, e As EventArgs) Handles ToolStripSave.Click
        If DataGridView1.Rows.Count <= 0 Then Exit Sub
        SaveFileDialog1.Filter = "Playlist Files (*.ade*)|*.ade"
        If gUiADE.plst <> "" Then
            SaveFileDialog1.InitialDirectory = Path.GetDirectoryName(gUiADE.plst)
            SaveFileDialog1.FileName = Path.GetFileName(gUiADE.plst)
        End If
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using sw As StreamWriter = File.CreateText(SaveFileDialog1.FileName)
                For i = 0 To DataGridView1.Rows.Count - 1
                    Dim subs As String = DataGridView1.Rows(i).Cells(1).Value
                    If subs IsNot Nothing Then subs = "|" & subs
                    sw.WriteLine(Path.Combine(DataGridView1.Rows(i).Cells(2).Value, DataGridView1.Rows(i).Cells(0).Value) & subs)
                Next
            End Using
        End If
    End Sub

    Public Function LoadADE(ade As String)
        DataGridView1.Rows.Clear()
        Using sr As StreamReader = File.OpenText(ade)
            Do While sr.Peek() >= 0
                Dim SplitAde() As String = Split(sr.ReadLine(), "|")
                Dim subsong As String = Nothing
                If SplitAde.Length > 1 Then
                    subsong = SplitAde(1).ToString
                End If
                Dim PlsDirectory() As String = SplitAde(0).Split("\")

                DataGridView1.Rows.Add(Path.GetFileName(SplitAde(0)), subsong, Path.GetDirectoryName(SplitAde(0)), PlsDirectory(PlsDirectory.Length - 2))
            Loop
        End Using
        ResizeADE()
    End Function

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.Rows.Count < 1 Then Exit Sub
        PlayFromPls()
    End Sub

    Public Sub ResizeADE()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.AutoResizeRows()
        DataGridView1.AutoResizeColumns()
        Dim intWidth As Integer
        For Each dgvcc As DataGridViewColumn In DataGridView1.Columns
            If dgvcc.Index <> 2 Then intWidth += dgvcc.Width
        Next

        Me.Width = intWidth + 50
    End Sub

    Private Sub PlayFromPls()
        gUiADE.Action_UADE("kill")
        gUiADE.arg = ""
        gUiADE.pModule = Path.Combine(DataGridView1.SelectedRows(0).Cells(2).Value.ToString(), DataGridView1.SelectedRows(0).Cells(0).Value.ToString())
        Dim subm As String = DataGridView1.SelectedRows(0).Cells(1).Value
        If subm <> "" Then
            gUiADE.arg = "-s " & subm & " "
        End If
        gUiADE.UseThread("start")
        If subm <> "" Then gUiADE.ListBox1.Items.Clear()
        Me.Focus()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            PlayFromPls()
        End If
    End Sub

    Private Sub ToolStripSearch_TextChanged(sender As Object, e As EventArgs) Handles ToolStripSearch.TextChanged
        If DataGridView1.Rows.Count <= 0 Then Exit Sub

        If ToolStripSearch.TextLength > 2 Then
            FilterText(ToolStripSearch.Text)
            ToolStripRem.Enabled = False
            ToolStripSave.Enabled = False
        Else
            For i = 0 To DataGridView1.Rows.Count - 1
                DataGridView1.Rows(i).Visible = True
            Next
            ToolStripRem.Enabled = True
            ToolStripSave.Enabled = True
        End If
    End Sub

    Private Sub FilterText(Ftext As String)

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim concat As String = (DataGridView1.Rows(i).Cells(0).Value & "|" & DataGridView1.Rows(i).Cells(3).Value)
            If LCase(concat).Contains(LCase(Ftext)) Then
                DataGridView1.Rows(i).Visible = True
            Else
                DataGridView1.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Sub ToolStripPoint_Click(sender As Object, e As EventArgs) Handles ToolStripPoint.Click
        Dim pFile As String = Path.Combine(DataGridView1.SelectedRows(0).Cells(2).Value.ToString(), DataGridView1.SelectedRows(0).Cells(0).Value.ToString())
        If File.Exists(pFile) Then
            Process.Start("explorer.exe", " /select ," & Chr(34) & pFile & Chr(34))
        Else
            MsgBox("This file not exist", MsgBoxStyle.Exclamation + vbOKOnly, "Unrecognized file")
        End If
    End Sub

End Class