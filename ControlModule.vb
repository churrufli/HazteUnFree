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
        Fn.SetMySettings()
        MainModule.Show()
        LoadWords()
        LoadDictionaries()
        MainModule.InitStates()
        Fn.LoadMusic()
        Calculate()
    End Sub

    Sub Calculate()
        'toma todas las opciones y muestra en el log 
    End Sub
    Sub LoadDictionaries()
        Dim di As New DirectoryInfo(Directory.GetCurrentDirectory)
        Dim fiArr As FileInfo() = di.GetFiles("dic_*.txt")
        Dim fri As FileInfo
        For Each fri In fiArr
            Dim name = Split(Split(fri.Name, "_")(1).ToString, ".txt")(0).ToString
            ListBoxDictionaries.Items.Add(name, IIf(LCase(name) = "general", True, False))
        Next fri
    End Sub
    Public Shared Sub LoadWords()
        Try
            vars.MyWords = My.Computer.FileSystem.ReadAllText(vars.UserDir & "\" & vars.MyWordsFileName)
            vars.arr = Split(vars.MyWords, vbNewLine)
        Catch err As Exception
            Fn.WriteLog(err.Message.ToString)
        End Try
        Fn.WriteLog(vars.arr.Count & " cargadas de Palabras - General")
    End Sub

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

    Private Sub Button3_Click(sender As Object, e As EventArgs)
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If chautoinitwords.Checked = True Then
            btstartwords.Enabled = False
            btNextWord.Enabled = False
        Else
            btstartwords.Enabled = True
        End If
    End Sub


    Private Sub TbWordsWaittoStart_KeyPress(sender As Object, e As KeyPressEventArgs)
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btNextWord_Click(sender As Object, e As EventArgs)
        MainModule.GetWord()
    End Sub

    Private Sub btchangetypo_Click(sender As Object, e As EventArgs) Handles btchangewordtypo.Click
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font
            ms.SaveSetting("LbWordFont", FontDialog1.Font.ToString)
        End If
        FontDialog1.Dispose()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Me.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            ms.SaveSetting("MainBackGroundImage", OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub btwordcolor_Click(sender As Object, e As EventArgs) Handles btwordcolor.Click
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbWord.ForeColor = Color.FromArgb(mycolor)
            ms.SaveSetting("lbWordColor", mycolor)

        End If
        ColorDialog1.Dispose()
    End Sub

    Private Sub btchangecountercolor_Click(sender As Object, e As EventArgs) Handles btchangecountercolor.Click
        If ColorDialog2.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog2.Color.ToArgb.ToString
            MainModule.LbCountDown.ForeColor = Color.FromArgb(mycolor)
            ms.SaveSetting("lbCountDownColor", mycolor)
        End If
        ColorDialog2.Dispose()
    End Sub

    Private Sub btchangecountertypo_Click(sender As Object, e As EventArgs) Handles btchangecountertypo.Click
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub

    Private Sub chautoinitwords_CheckedChanged(sender As Object, e As EventArgs) Handles chautoinitwords.CheckedChanged
        If chautoinitwords.Checked Then
            btstartwords.Enabled = False
        Else
            btstartwords.Enabled = True
        End If
    End Sub

    Private Sub btstartwords_Click_1(sender As Object, e As EventArgs) Handles btstartwords.Click
        MainModule.GetWord()
        MainModule.TimerWord.Start()
        btstartwords.Enabled = False
        btNextWord.Enabled = True
    End Sub

    Private Sub btstartbattle_Click(sender As Object, e As EventArgs) Handles btstartbattle.Click
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

    Private Sub btstopbattle_Click(sender As Object, e As EventArgs) Handles btstopbattle.Click
        MainModule.StopBattleFunctions()

    End Sub

    Private Sub btNextWord_Click_1(sender As Object, e As EventArgs) Handles btNextWord.Click
        MainModule.GetWord()

    End Sub

    Private Sub btmusicdir_Click(sender As Object, e As EventArgs) Handles btmusicdir.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = DialogResult.OK Then
            ms.SaveSetting("MusicDirectory", FolderBrowserDialog1.SelectedPath.ToString)
            tbmusicdir.Text = FolderBrowserDialog1.SelectedPath.ToString
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chshufflemusic.CheckedChanged
        cbMusicList.Enabled = IIf(chshufflemusic.Checked, False, True)
        Try
            Fn.LoadMusic()
        Catch
        End Try

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)
        ms.UpdateSettings("MainBackGroundImage", "")
        Fn.WriteLog("El fondo de pantalla se reestableció a su valor por defecto.")
    End Sub
End Class