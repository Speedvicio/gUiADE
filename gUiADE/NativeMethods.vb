'Code for import colored cursor from:
'https://stackoverflow.com/a/4306984

Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.InteropServices

Friend Module NativeMethods

    Public Function LoadCustomCursor(ByVal path As String) As Cursor
        Dim hCurs As IntPtr = LoadCursorFromFile(path)
        If hCurs = IntPtr.Zero Then Throw New Win32Exception()
        Dim curs = New Cursor(hCurs)
        ' Note: force the cursor to own the handle so it gets released properly
        Dim fi = GetType(Cursor).GetField("ownHandle", BindingFlags.NonPublic Or BindingFlags.Instance)
        fi.SetValue(curs, True)
        Return curs
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Function LoadCursorFromFile(ByVal path As String) As IntPtr
    End Function

End Module