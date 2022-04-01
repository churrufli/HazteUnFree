Imports System.Diagnostics.Contracts
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports WMPLib
Imports System.Web

Public Class ControlModule
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76
    Private Sub control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 30)
        MainModule.Show()
        MainModule.InitProgram()
        LoadMySettings()
        LoadWords()
    End Sub

    Public Shared Sub LoadMySettings()
        Try
            vars.MySettings = My.Computer.FileSystem.ReadAllText(vars.UserDir & "\" & vars.MySettingsFileName)
        Catch err As Exception
            fn.WriteLog(err.Message.ToString)
        End Try
    End Sub
    Public Shared Sub LoadWords()
        Try
            vars.MyWords = My.Computer.FileSystem.ReadAllText(vars.UserDir & "\" & vars.MyWordsFileName)
            vars.arr = Split(vars.MyWords, vbNewLine)
        Catch err As Exception
            fn.WriteLog(err.Message.ToString)
        End Try

        fn.WriteLog(vars.arr.Count & " palabras cargadas.")


    End Sub

    Public Shared Sub Alert(msg)
        MsgBox(msg)
    End Sub

    Public Shared Sub UpdateSettings(idsetting, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(vars.MySettingsFileName)
        Dim previousmyvalue = FindIt(mylog, "<" & idsetting & ">", "</" & idsetting & ">")
        Dim NewSetting = Replace(mylog, "<" & idsetting & ">" & previousmyvalue & "</" & idsetting & ">",
                             "<" & idsetting & ">" & myvalue & "</" & idsetting & ">")
        Try
            File.Delete(vars.UserDir & vars.MySettingsFileName)
        Catch
        End Try
        Try
            File.WriteAllText(vars.UserDir & vars.MySettingsFileName, NewSetting)
        Catch
        End Try
    End Sub

    Public Shared Function FindIt(total As String, first As String, last As String) As String
        If total = Nothing Then total = ""
        If last.Length < 1 Then
            FindIt = total.Substring(total.IndexOf(first))
        End If
        If first.Length < 1 Then
            FindIt = total.Substring(0, (total.IndexOf(last)))
        End If
        Try
            FindIt =
                ((total.Substring(total.IndexOf(first), (total.IndexOf(last) - total.IndexOf(first)))).Replace(first, "")) _
                    .Replace(last, "")
        Catch
        End Try
    End Function
    Public Sub BtClose_Click(sender As Object, e As EventArgs)
        MainModule.StopBattleFunctions()
        Application.Exit()
    End Sub

    Private Sub BtStop_Click(sender As Object, e As EventArgs)
        MainModule.StopBattleFunctions()
    End Sub

    Private Sub BtStart_Click(sender As Object, e As EventArgs)
        MainModule.Show()
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
        MainModule.SetBattle()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btstartbattle.Click
        MainModule.Show()
        If chautoinitwords.Checked = True Then
            MainModule.Startwords = True
            btNextWord.Enabled = False
        Else
            MainModule.Startwords = False
            btNextWord.Enabled = True
        End If
        vars.StopBattle = False
        btstartbattle.Enabled = False

        btstartbattle.Enabled = True
        CbBattleType.Enabled = False
        CbDuration.Enabled = False
        btNextWord.Enabled = True
        MainModule.SetBattle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btstopbattle.Click
        MainModule.Startwords = False
        MainModule.StopBattleFunctions()
        btstartbattle.Enabled = True
        btstartwords.Enabled = True
    End Sub
    Private Sub btfullscreen_Click(sender As Object, e As EventArgs) Handles btfullscreen.Click
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub btwindowmode_Click(sender As Object, e As EventArgs) Handles btwindowmode.Click
        MainModule.WindowState = FormWindowState.Normal
        MainModule.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ControlModule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainModule.StopBattleFunctions()
        Application.Exit()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chautoinitwords.CheckedChanged
        If chautoinitwords.Checked = True Then
            btstartwords.Enabled = False
            btNextWord.Enabled = False
        Else
            btstartwords.Enabled = True
        End If
    End Sub

    Private Sub btstartwords_Click(sender As Object, e As EventArgs) Handles btstartwords.Click
        'MainModule.Startwords = True
        'btstartwords.Enabled = False
        MainModule.ProcessTick()
        btstartwords.Enabled = False
        btNextWord.Enabled = True

    End Sub

    Private Sub TbWordsWaittoStart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbWordsWaittoStart.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btNextWord_Click(sender As Object, e As EventArgs) Handles btNextWord.Click
        MainModule.ProcessTick()
    End Sub

    Private Sub btchangetypo_Click(sender As Object, e As EventArgs) Handles btchangetypoword.Click
        FontDialog1.ShowColor = True
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font 'Change the font of the selected string  
            MainModule.LbWord.ForeColor = FontDialog1.Color 'Change the color of selected string  
        End If
    End Sub

    Private Sub btchangetypocounter_Click(sender As Object, e As EventArgs) Handles btchangetypocounter.Click
        FontDialog2.ShowColor = True
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LblCountDown.Font = FontDialog2.Font 'Change the font of the selected string  
            MainModule.LblCountDown.ForeColor = FontDialog2.Color 'Change the color of selected string  
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()

        ' Test result.
        If result = DialogResult.OK Then
            Alert(OpenFileDialog1.FileName)
            Me.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
        End If
    End Sub
End Class