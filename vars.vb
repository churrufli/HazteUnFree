Imports System.IO
Imports WMPLib

Public Class Vars
    Public Shared MyWords As String
    Public Shared MyWordsFileName As String = "Dic_General.txt"
    Public Shared MySettingsFileName As String = "MySettings.txt"
    Public Shared SongDuration As String
    Public Shared Arr As String()
    Public Shared WordsShowed As String
    Public Shared Arr4Words As String()
    Public Shared Files() As String
    Public Shared Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Public Shared StopBattle As Boolean = False
    Public Shared Rnd As New Random()
    Public Shared UserDir = Directory.GetCurrentDirectory & "\"
End Class
