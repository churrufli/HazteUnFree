Imports System.IO
Imports WMPLib

Public Class vars
    Public Shared MyWords As String
    Public Shared MyWordsFileName As String = "Dic_General.txt"
    Public Shared MySettingsFileName As String = "MySettings.txt"
    Public Shared SongDuration As String
    Public Shared arr As String()
    Public Shared arr4words As String()
    Public Shared files() As String
    Public Shared Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Public Shared StopBattle As Boolean = False
    Public Shared rnd As New Random()
    Public Shared UserDir = Directory.GetCurrentDirectory & "\"
End Class
