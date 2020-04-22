Imports System.IO
Imports SevenZip

Public Module extract

    Friend Sub DecompressArchive(archive As String)
        Dim final_path = Path.Combine(Application.StartupPath, "temp")
        SevenZipExtractor.SetLibraryPath(Path.Combine(Application.StartupPath, "7z.dll"))
        Dim szip As SevenZipExtractor = New SevenZipExtractor(archive)
        szip.ExtractArchive(final_path)
        szip.Dispose()
    End Sub

    Friend Sub DeleteTemp()
        If Directory.Exists(Path.Combine(Application.StartupPath, "temp")) Then Directory.Delete(Path.Combine(Application.StartupPath, "temp"), True)
    End Sub

End Module