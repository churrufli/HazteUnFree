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
    Public Shared MyWords As String = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\MyWords.txt")
    Public Shared arr As String() = Split(MyWords, vbNewLine)
    Public Shared files() As String = Directory.GetFiles(IO.Directory.GetCurrentDirectory, "*.mp3", SearchOption.AllDirectories)
    Public Shared Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Public Shared StopBattle As Boolean = False
    Public Shared rnd As New Random()
End Class
