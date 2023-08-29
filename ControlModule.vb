Imports System.IO

Public Class ControlModule
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76

    Private Sub control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, 30)
        Fn.SetMySettings()
        MainModule.Show()
        LoadDictionaries()
        LoadWords()
        Me.InitStates()
        MainModule.InitStates()
        Fn.LoadMusic()
    End Sub

    Sub InitStates()
        TbWordsWaittoStart.Text = Ms.ReadSetting("TbWordsWaittoStart")
    End Sub

    Sub LoadDictionaries()
        Dim di As New DirectoryInfo(Directory.GetCurrentDirectory)
        Dim fiArr As FileInfo() = di.GetFiles("dic_*.txt")
        Dim fri As FileInfo
        For Each fri In fiArr

            If chkDepureDic.Checked Then
                DepureDictionary(fri.FullName)
            End If

            Dim name = Split(Split(fri.Name, "_")(1).ToString, ".txt")(0).ToString
            ListBoxDictionaries.Items.Add(name, IIf(LCase(name) = "general", True, False))
        Next fri
        Dim checked = True   ' Set to True or False, as required.
        For i = 0 To ListBoxDictionaries.Items.Count - 1

            'ListBoxDictionaries.SetItemChecked(i, checked)
        Next
    End Sub

    Private Sub DepureDictionary(fullName As String)
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(fullName)
        fileReader = Replace(fileReader, ".", vbNewLine)
        fileReader = Replace(fileReader, ":", vbNewLine)
        fileReader = Replace(fileReader, ",,", vbNewLine)
        fileReader = Replace(fileReader, ",", vbNewLine)
        fileReader = Replace(fileReader, vbNewLine & vbNewLine, vbNewLine)

        Dim arr = Split(fileReader, vbNewLine)
        Dim arrout As String = ""
        For Each w In arr
            w = RTrim(LTrim(w))
            If Len(w) > 2 Then
                If InStr(arrout, vbNewLine & w & vbNewLine, CompareMethod.Text) = 0 Then
                    arrout = arrout & w & vbNewLine
                Else
                    If w <> "" Then
                        Fn.WriteLog("Se eliminó """ & w & """ del diccionario " & System.IO.Path.GetFileName(fullName).ToString() & " por duplicidad")
                    End If
                End If
            End If
        Next
        'fixing double vbNewLine
        arrout = Replace(arrout, vbNewLine & vbNewLine, vbNewLine)
        arrout = Replace(arrout, vbNewLine & vbNewLine, vbNewLine)
        arrout = Replace(arrout, ",,", ",")
        arrout = Replace(arrout, ",,", ",")

        System.IO.File.WriteAllText(fullName, arrout)
    End Sub

    Sub LoadWords()

        Dim myTotalWords As String = Nothing
        For i = 0 To ListBoxDictionaries.Items.Count - 1
            Dim item As Object = ListBoxDictionaries.Items(i)
            If ListBoxDictionaries.GetItemChecked(i) Then
                Dim fullText As String
                Dim a = item
                item = "dic_" & item & ".txt"
                Try
                    fullText = My.Computer.FileSystem.ReadAllText(Vars.UserDir & "\" & item)
                    If myTotalWords Is Nothing Then
                        myTotalWords = fullText
                    Else
                        myTotalWords = fullText & vbNewLine & myTotalWords
                    End If
                    Fn.WriteLog(CountWords(fullText) & " palabras cargadas del diccionario - " & a.ToString)
                Catch err As Exception
                    Fn.WriteLog(err.Message.ToString)
                End Try
            End If
        Next

        Dim myTotalWordsArr As String()
        If InStr(myTotalWords, ",") > 0 Then
            myTotalWords = Replace(myTotalWords, ",", vbNewLine)
        End If

        myTotalWordsArr = Split(myTotalWords, vbNewLine)
        Vars.Arr = myTotalWordsArr
    End Sub

    Function CountWords(s)
        Dim myTotalWordsArr As String()
        If InStr(s, ",") > 0 Then
            s = Replace(s, ",", vbNewLine)
        End If
        myTotalWordsArr = Split(s, vbNewLine)
        Vars.Arr = myTotalWordsArr
        Return myTotalWordsArr.Count
    End Function

    Public Sub BtClose_Click(sender As Object, e As EventArgs)
        MainModule.StopBattleFunctions()
        Application.Exit()
    End Sub

    Private Sub BtStart_Click(sender As Object, e As EventArgs)
        'MainModule.Show()
        'MainModule.WindowState = FormWindowState.Maximized
        'MainModule.FormBorderStyle = FormBorderStyle.None
        'MainModule.SetBattle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        MainModule.Startwords = False
        MainModule.StopBattleFunctions()
        BtStartBattle.Enabled = True
        btStartWords.Enabled = True
    End Sub

    Private Sub btfullscreen_Click(sender As Object, e As EventArgs)
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub btwindowmode_Click(sender As Object, e As EventArgs)
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

    Private Sub btchangetypo_Click(sender As Object, e As EventArgs)
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font
            Ms.SaveSetting("LbWordFont", FontDialog1.Font.ToString)
        End If
        FontDialog1.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Me.BackgroundImage = New Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New Bitmap(OpenFileDialog1.FileName)
            Ms.SaveSetting("MainBackGroundImage", OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub btwordcolor_Click(sender As Object, e As EventArgs)
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbWord.ForeColor = Color.FromArgb(mycolor)
            Ms.SaveSetting("lbWordColor", mycolor)
        End If
        ColorDialog1.Dispose()
    End Sub

    Private Sub btchangecountercolor_Click(sender As Object, e As EventArgs)
        If ColorDialog2.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog2.Color.ToArgb.ToString
            MainModule.LbCountDown.ForeColor = Color.FromArgb(mycolor)
            Ms.SaveSetting("lbCountDownColor", mycolor)
        End If
        ColorDialog2.Dispose()
    End Sub

    Private Sub btchangecountertypo_Click(sender As Object, e As EventArgs)
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            Ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub

    Private Sub btstartwords_Click_1(sender As Object, e As EventArgs) Handles btStartWords.Click
        MainModule.TimerWord.Start()
        btStartWords.Enabled = False
        btNextWord.Enabled = True
        StartBattle("manual")
    End Sub

    Private Sub btstartbattle_Click(sender As Object, e As EventArgs) Handles BtStartBattle.Click
        StartBattle("auto")
    End Sub

    Sub StartBattle(mode As String)
        BtStartBattle.Enabled = False
        MainModule.Show()

        MainModule.Startwords = False
        btNextWord.Enabled = True

        Vars.StopBattle = False
        CbBattleType.Enabled = False
        CbDuration.Enabled = False
        btNextWord.Enabled = True

        Vars.SongDuration = Fn.PlayMusic()
        Dim minimize As Boolean = False
        If chkMinimize.Checked Then
            minimize = True
        Else
            minimize = False
        End If

        If mode = "semimanual" Then
            minimize = False
        Else
            minimize = False
        End If
        If mode = "auto" Then
            If chkMinimize.Checked Then
                minimize = True
            Else
                minimize = False
            End If
        End If
        If mode = "manual" Then
            minimize = False
        End If

        If minimize Then
            Me.WindowState = FormWindowState.Minimized
        End If

        MainModule.SetBattle(mode)
    End Sub

    Private Sub btstopbattle_Click(sender As Object, e As EventArgs) Handles btStopBattle.Click
        MainModule.StopBattleFunctions()
        btStopBattle.Enabled = False
    End Sub

    Private Sub btNextWord_Click_1(sender As Object, e As EventArgs)
        MainModule.GetWord()
    End Sub

    Private Sub btmusicdir_Click(sender As Object, e As EventArgs) Handles btmusicdir.Click
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Ms.SaveSetting("MusicDirectory", FolderBrowserDialog1.SelectedPath.ToString)
            tbmusicdir.Text = FolderBrowserDialog1.SelectedPath.ToString
            Fn.InitMusic()
            Fn.LoadMusic()
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles chshufflemusic.CheckedChanged
        cbMusicList.Enabled = IIf(chshufflemusic.Checked, False, True)
        Ms.SaveSetting("chshufflemusic", IIf(cbMusicList.Enabled, "1", "0"))
        Try
            Fn.LoadMusic()
        Catch
        End Try
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs)
        Ms.UpdateSettings("MainBackGroundImage", "")
        Fn.WriteLog("El fondo de pantalla se reestableció a su valor por defecto.")
    End Sub

    Private Sub ModoVentanaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ModoVentanaToolStripMenuItem.Click
        MainModule.WindowState = FormWindowState.Normal
        MainModule.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Private Sub ModoPantallaCompletaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ModoPantallaCompletaToolStripMenuItem.Click
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub FondoDePantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FondoDePantallaToolStripMenuItem.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Me.BackgroundImage = New Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New Bitmap(OpenFileDialog1.FileName)
            Ms.SaveSetting("MainBackGroundImage", OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub FuenteYTamañoToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles FuenteYTamañoToolStripMenuItem.Click
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font
            Ms.SaveSetting("LbWordFont", FontDialog1.Font.ToString)
        End If
        FontDialog1.Dispose()
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbWord.ForeColor = Color.FromArgb(mycolor)
            Ms.SaveSetting("lbWordColor", mycolor)
        End If
        ColorDialog1.Dispose()
    End Sub

    Private Sub ColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem1.Click

        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbCountDown.ForeColor = Color.FromArgb(mycolor)
            Ms.SaveSetting("lbCountDownColor", mycolor)
        End If
        ColorDialog1.Dispose()

    End Sub

    Private Sub FuenteYTamañoToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles FuenteYTamañoToolStripMenuItem1.Click
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            Ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub

    Private Sub TbWordsWaittoStart_KeyPress_1(sender As Object, e As KeyPressEventArgs) _
        Handles TbWordsWaittoStart.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso (e.KeyChar <> "."c) Then
            e.Handled = True
        End If
        If (e.KeyChar = "."c) AndAlso ((TryCast(sender, TextBox)).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TbWordsWaittoStart_TextChanged(sender As Object, e As EventArgs) Handles TbWordsWaittoStart.TextChanged
        Ms.SaveSetting("TbWordsWaittoStart", TbWordsWaittoStart.Text)
    End Sub

    Private Sub ListBoxDictionaries_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles ListBoxDictionaries.SelectedIndexChanged
        If chkDepureDic.Checked Then
            DepureDictionary(Directory.GetCurrentDirectory() & "\Dic_" & sender.selecteditem.ToString & ".txt")
        End If
        LoadWords()
    End Sub

    Private Sub btNextWord_Click_2(sender As Object, e As EventArgs) Handles btNextWord.Click
        MainModule.GetWord()
    End Sub

    Private Sub MostrarPantallaPrincipalToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles MostrarPantallaPrincipalToolStripMenuItem.Click
        MainModule.Show()
    End Sub

    Private Sub PosiciónToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles PosiciónToolStripMenuItem.Click
        MsgBox(
            "En la pantalla principal, situa el ratón en la zona de las palabras y arrastra y suelta para cambiar su posición en la pantalla.",
            MsgBoxStyle.Information)
    End Sub

    Private Sub PosiciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        Handles PosiciónToolStripMenuItem1.Click
        MsgBox(
            "En la pantalla principal, situa el ratón en la zona del reloj y arrastra y suelta para cambiar su posición en la pantalla.",
            MsgBoxStyle.Information)
    End Sub

    Private Sub chkSoundFx_CheckedChanged(sender As Object, e As EventArgs) Handles chkSoundFx.CheckedChanged
        Ms.SaveSetting("chkSoundFx", IIf(chkSoundFx.Checked = True, "1", "0"))
    End Sub

    Private Sub chkminimize_CheckedChanged(sender As Object, e As EventArgs) Handles chkMinimize.CheckedChanged
        Ms.SaveSetting("chkMinimize", IIf(chkMinimize.Checked = True, "1", "0"))
    End Sub

    'Private Sub rbManualMode_CheckedChanged(sender As Object, e As EventArgs)
    '    If rbManualMode.Checked = True Then
    '        gbManualMode.Enabled = True
    '        gbAutoMode.Enabled = False
    '        btNextWord.Enabled = False
    '    End If
    '    MainModule.StopBattleFunctions()
    'End Sub

    'Private Sub rbAutoMode_CheckedChanged(sender As Object, e As EventArgs)
    '    If rbAutoMode.Checked = True Then
    '        gbManualMode.Enabled = False
    '        gbAutoMode.Enabled = True
    '    End If
    '    MainModule.StopBattleFunctions()
    'End Sub

    Private Sub chPlayMusic_CheckedChanged(sender As Object, e As EventArgs) Handles chPlayMusic.CheckedChanged
        Ms.SaveSetting("chPlayMusic", IIf(chPlayMusic.Checked = True, "1", "0"))
        If chPlayMusic.Checked Then
            tbmusicdir.Enabled = True
            btmusicdir.Enabled = True
            chshufflemusic.Enabled = True
            cbMusicList.Enabled = True
        Else
            tbmusicdir.Enabled = False
            btmusicdir.Enabled = False
            chshufflemusic.Enabled = False
            cbMusicList.Enabled = False
        End If
    End Sub

    Private Sub GithubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GithubToolStripMenuItem.Click
        Process.Start("https://github.com/churrufli/HazteUnFree/")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MainModule.GetWord()
    End Sub

    Private Sub DIscordToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DIscordToolStripMenuItem.Click
        Process.Start("https://discord.gg/4JwTRxS8p3")
    End Sub

    Private Sub ReestablecerPersonalizaciónToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MainModule.TimerWord.Start()
        btStartWords.Enabled = False
        btNextWord.Enabled = True
        StartBattle("semimanual")
        Button4.Enabled = False
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        MainModule.GetWord()
        MainModule.TimerWord.Start()
        Button3.Enabled = False
        If chkMinimize.Checked Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub ReestablecerConfiguraciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReestablecerConfiguraciónToolStripMenuItem.Click
        If (MsgBox("¿Deseas reestablecer la personalización a los valores por defecto del programa?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Ms.CreateDefaultSettings()
            Ms.LoadSettings()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        If (MsgBox("¿Salir del programa?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            Application.Exit()
        End If

    End Sub

End Class