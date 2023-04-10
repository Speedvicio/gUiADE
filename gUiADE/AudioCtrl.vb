Imports System.Runtime.InteropServices

Module AudioCtrl
    Dim NumLEDS As Integer = 20
    Dim devEnum
    Dim defaultDevice
    Public oldVol As Integer

    Public Sub StartPeak()

        gUiADE.TrackBar1.Minimum = 0
        gUiADE.TrackBar1.Maximum = 100
        gUiADE.TrackBar1.TickFrequency = 5

        If Val(Environment.OSVersion.Version.Major) >= 6 Then
            devEnum = New CoreAudioApi.MMDeviceEnumerator
            defaultDevice = devEnum.GetDefaultAudioEndpoint(CoreAudioApi.EDataFlow.eRender, CoreAudioApi.ERole.eMultimedia)
            oldVol = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100
            gUiADE.TrackBar1.Value = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100
            gUiADE.PeakMeterCtrl1.Start(1000 / 20)
            gUiADE.PeakMeterCtrl2.Start(1000 / 20)
        Else
            gUiADE.TrackBar1.Value = GetApplicationVolume()
            oldVol = GetApplicationVolume()
        End If
        gUiADE.ToolTip1.SetToolTip(gUiADE.TrackBar1, "Volume " & gUiADE.TrackBar1.Value.ToString & "%")
    End Sub

    Public Sub VolumeScroll()
        If Val(Environment.OSVersion.Version.Major) >= 6 Then
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = gUiADE.TrackBar1.Value / 100
        Else
            Dim vol As UInteger = CUInt((UShort.MaxValue / 100) * gUiADE.TrackBar1.Value)
            waveOutSetVolume(IntPtr.Zero, CUInt((vol And &HFFFF) Or (vol << 16)))
        End If
        gUiADE.ToolTip1.SetToolTip(gUiADE.TrackBar1, "Volume " & gUiADE.TrackBar1.Value.ToString & "%")
    End Sub

    Public Sub MovePeak()
        On Error Resume Next
        Dim meters1() As Integer = New Integer((NumLEDS) - 1) {}
        Dim meters2() As Integer = New Integer((NumLEDS) - 1) {}
        Dim rand As Random = New Random
        Dim i As Integer = 0
        Do While (i < meters1.Length)
            If Environment.OSVersion.Version.Major >= 6 And IO.File.Exists(Application.StartupPath & "\CoreAudioApi.dll") Then
                Dim leftVolume As Integer = defaultDevice.AudioMeterInformation.PeakValues(0) * 100
                Dim rightVolume As Integer = defaultDevice.AudioMeterInformation.PeakValues(1) * 100
                meters1(i) = leftVolume
                meters2(i) = rightVolume
            Else
                meters1(i) = rand.Next(0, 100)
                meters2(i) = rand.Next(0, 100)
            End If

            i = (i + 1)
        Loop

        gUiADE.PeakMeterCtrl2.SetData(meters1, 0, meters1.Length)
        gUiADE.PeakMeterCtrl1.SetData(meters2, 0, meters2.Length)

        Dim v As Integer
        If Val(Environment.OSVersion.Version.Major) >= 6 Then
            Dim leftVolume As Integer = defaultDevice.AudioMeterInformation.PeakValues(0) * 100
            Dim rightVolume As Integer = defaultDevice.AudioMeterInformation.PeakValues(1) * 100
            v = defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100
        Else
            v = GetApplicationVolume()
        End If
        If gUiADE.TrackBar1.Value <> v Then
            gUiADE.TrackBar1.Value = v
            gUiADE.ToolTip1.SetToolTip(gUiADE.TrackBar1, "Volume " & gUiADE.TrackBar1.Value.ToString & "%")
        End If
    End Sub

    Public Sub ResetVol()
        If Val(Environment.OSVersion.Version.Major) >= 6 Then
            defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar = oldVol / 100
        Else
            Dim vol As UInteger = CUInt((UShort.MaxValue / 100) * oldVol)
            waveOutSetVolume(IntPtr.Zero, CUInt((vol And &HFFFF) Or (vol << 16)))
        End If
    End Sub

    Private Function GetApplicationVolume() As Integer
        Dim vol As UInteger = 0
        waveOutGetVolume(IntPtr.Zero, vol)
        Return CInt((vol And &HFFFF) / (UShort.MaxValue / 100))
    End Function

    <DllImport("winmm.dll")> Public Function waveOutSetVolume(ByVal hwo As IntPtr, ByVal dwVolume As UInteger) As UInteger
    End Function

    <DllImport("winmm.dll")> Public Function waveOutGetVolume(ByVal hwo As IntPtr, ByRef pdwVolume As UInteger) As UInteger
    End Function

    Declare Function auxGetNumDevs Lib "winmm.dll" Alias "auxGetNumDevs" () As Long
End Module