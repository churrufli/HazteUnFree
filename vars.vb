Imports System.Diagnostics.Contracts
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports WMPLib
Imports Shell32
Public Class vars
    Shared MyWords As String = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\MyWords.txt")
    Shared arr As String() = Split(MyWords, vbNewLine)
    Shared files() As String = Directory.GetFiles(IO.Directory.GetCurrentDirectory, "*.mp3", SearchOption.AllDirectories)
    Shared Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Shared StopBattle As Boolean = False
    Shared rnd As New Random()

    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76
End Class
