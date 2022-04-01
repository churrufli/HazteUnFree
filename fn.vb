Imports VB = Microsoft.VisualBasic
Public Class fn

    Public Shared Sub WriteLog(msg)
        ControlModule.tbUserLog.SelectedText = "- " & msg & vbCrLf
        ControlModule.tbUserLog.SelectionStart = ControlModule.tbUserLog.Text.Length
        ControlModule.tbUserLog.ScrollToCaret()
    End Sub

    Public Shared Sub Shuffle(items As String())
        Dim j As Int32
        Dim temp As String
        For n As Int32 = items.Length - 1 To 0 Step -1
            j = MainModule.rnd.Next(0, n + 1)
            temp = items(n)
            items(n) = items(j)
            items(j) = temp
        Next n
    End Sub

    Public Shared Sub PlayMusic()
        '///// MUSIC //////
        Dim Vidhhmmss As String
        For Each u In vars.files
            vars.Player.URL = u
            vars.Player.controls.play()
            Dim VidSecs As Integer = Math.Round(GetMediaDuration(u.ToString)) 'Get total seconds
            If ControlModule.CbBattleType.SelectedIndex = 3 Then
                Vidhhmmss = TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") ' Format hh:mm:ss
                MainModule.CountDownFrom = TimeSpan.FromSeconds(VidSecs)
            End If
            Exit For
        Next
    End Sub

    Public Shared Sub wait(ByVal seconds As Single)
        If vars.StopBattle <> True Then
            Static start As Single
            start = VB.Timer()
            Do While VB.Timer() < start + seconds
                System.Windows.Forms.Application.DoEvents()
            Loop
        Else
            Exit Sub
        End If
    End Sub

    Public Shared Function GetMediaDuration(ByVal MediaFile As String)
        Try
            Dim w As New WMPLib.WindowsMediaPlayer
            Dim m As WMPLib.IWMPMedia = w.newMedia(MediaFile)
            w.close()
            Return m.duration
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
