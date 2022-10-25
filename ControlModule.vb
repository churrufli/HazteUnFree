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
        LoadDictionaries()
        LoadWords()
        Me.InitStates()
        MainModule.InitStates()
        Fn.LoadMusic()
        Calculate()
    End Sub
    Sub InitStates()
        TbWordsWaittoStart.Text = ms.ReadSetting("TbWordsWaittoStart")
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
        Dim checked As Boolean = True   ' Set to True or False, as required.
        For i As Integer = 0 To ListBoxDictionaries.Items.Count - 1
            ListBoxDictionaries.SetItemChecked(i, checked)
        Next
    End Sub
    Sub LoadWords()

        Dim MyTotalWords As String = Nothing
        For i = 0 To ListBoxDictionaries.Items.Count - 1
            Dim Item As Object = ListBoxDictionaries.Items(i)
            If ListBoxDictionaries.GetItemChecked(i) Then

                Dim FullText As String
                Dim a = Item
                Item = "dic_" & Item & ".txt"
                Try
                    FullText = My.Computer.FileSystem.ReadAllText(vars.UserDir & "\" & Item)

                    If IsNothing(MyTotalWords) Then
                        MyTotalWords = FullText
                    Else
                        MyTotalWords = FullText & vbNewLine & MyTotalWords
                    End If

                    Fn.WriteLog(CountWords(FullText) & " cargadas de Palabras - " & a.ToString)

                Catch err As Exception
                    Fn.WriteLog(err.Message.ToString)
                End Try
            End If
        Next

        Dim MyTotalWordsArr As String()
        If InStr(MyTotalWords, ",") > 0 Then
            MyTotalWords = Replace(MyTotalWords, ",", vbNewLine)
        End If

        MyTotalWordsArr = Split(MyTotalWords, vbNewLine)
        vars.arr = MyTotalWordsArr

    End Sub
    Function CountWords(s)
        Dim MyTotalWordsArr As String()
        If InStr(s, ",") > 0 Then
            s = Replace(s, ",", vbNewLine)
        End If
        MyTotalWordsArr = Split(s, vbNewLine)
        vars.arr = MyTotalWordsArr
        Return MyTotalWordsArr.Count

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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        If chautoinitwords.Checked = True Then
            btStartWords.Enabled = False
            btNextWord.Enabled = False
        Else
            btStartWords.Enabled = True
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

    Private Sub btchangetypo_Click(sender As Object, e As EventArgs)
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font
            ms.SaveSetting("LbWordFont", FontDialog1.Font.ToString)
        End If
        FontDialog1.Dispose()
    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Me.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            ms.SaveSetting("MainBackGroundImage", OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub btwordcolor_Click(sender As Object, e As EventArgs)
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbWord.ForeColor = Color.FromArgb(mycolor)
            ms.SaveSetting("lbWordColor", mycolor)

        End If
        ColorDialog1.Dispose()
    End Sub

    Private Sub btchangecountercolor_Click(sender As Object, e As EventArgs)
        If ColorDialog2.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog2.Color.ToArgb.ToString
            MainModule.LbCountDown.ForeColor = Color.FromArgb(mycolor)
            ms.SaveSetting("lbCountDownColor", mycolor)
        End If
        ColorDialog2.Dispose()
    End Sub

    Private Sub btchangecountertypo_Click(sender As Object, e As EventArgs)
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub

    Private Sub btstartwords_Click_1(sender As Object, e As EventArgs) Handles btStartWords.Click
        MainModule.GetWord()
        MainModule.TimerWord.Start()
        btStartWords.Enabled = False
        btNextWord.Enabled = True
        StartBattle()
    End Sub

    Private Sub btstartbattle_Click(sender As Object, e As EventArgs) Handles BtStartBattle.Click
        StartBattle()
    End Sub

    Sub StartBattle()
        BtStartBattle.Enabled = False
        MainModule.Show()
        If chautoinitwords.Checked = True Then
            MainModule.Startwords = True
            btNextWord.Enabled = False
        Else
            MainModule.Startwords = False
            btNextWord.Enabled = True
        End If
        vars.StopBattle = False
        CbBattleType.Enabled = False
        CbDuration.Enabled = False
        'btNextWord.Enabled = True

        Fn.PlayMusic()

        MainModule.SetBattle()
    End Sub

    Private Sub btstopbattle_Click(sender As Object, e As EventArgs) Handles btStopBattle.Click
        MainModule.StopBattleFunctions()

    End Sub

    Private Sub btNextWord_Click_1(sender As Object, e As EventArgs)
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
        cbMusicList.Visible = IIf(chshufflemusic.Checked, False, True)
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

    Private Sub ModoVentanaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModoVentanaToolStripMenuItem.Click
        MainModule.WindowState = FormWindowState.Normal
        MainModule.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Private Sub ModoPantallaCompletaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModoPantallaCompletaToolStripMenuItem.Click
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub FondoDePantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FondoDePantallaToolStripMenuItem.Click
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then
            Me.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            MainModule.BackgroundImage = New System.Drawing.Bitmap(OpenFileDialog1.FileName)
            ms.SaveSetting("MainBackGroundImage", OpenFileDialog1.FileName)
        End If
        OpenFileDialog1.Dispose()
    End Sub

    Private Sub FuenteYTamañoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FuenteYTamañoToolStripMenuItem.Click
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbWord.Font = FontDialog1.Font
            ms.SaveSetting("LbWordFont", FontDialog1.Font.ToString)
        End If
        FontDialog1.Dispose()
    End Sub

    Private Sub ColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog() <> DialogResult.Cancel Then
            Dim mycolor = ColorDialog1.Color.ToArgb.ToString
            MainModule.LbWord.ForeColor = Color.FromArgb(mycolor)
            ms.SaveSetting("lbWordColor", mycolor)

        End If
        ColorDialog1.Dispose()
    End Sub

    Private Sub ColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColorToolStripMenuItem1.Click
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub

    Private Sub FuenteYTamañoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FuenteYTamañoToolStripMenuItem1.Click
        If FontDialog2.ShowDialog() <> DialogResult.Cancel Then
            MainModule.LbCountDown.Font = FontDialog2.Font
            ms.SaveSetting("lbCountDownFont", FontDialog2.Font.ToString)
        End If
        FontDialog2.Dispose()
    End Sub


    Private Sub chamanualnitwords_CheckedChanged(sender As Object, e As EventArgs) Handles chamanuailnitwords.CheckedChanged



        If chautoinitwords.Checked Then
            btStartWords.Enabled = False
            btNextWord.Enabled = False
            chamanuailnitwords.Checked = False
            BtStartBattle.Enabled = True
        Else
            btStartWords.Enabled = True
            btNextWord.Enabled = True
            chamanuailnitwords.Checked = True
            BtStartBattle.Enabled = False

        End If


    End Sub
    Private Sub chautoinitwords_CheckedChanged(sender As Object, e As EventArgs) Handles chautoinitwords.CheckedChanged
        If chautoinitwords.Checked Then
            btStartWords.Enabled = False
            btNextWord.Enabled = False
            chamanuailnitwords.Checked = False
            BtStartBattle.Enabled = True
        Else
            btStartWords.Enabled = True
            btNextWord.Enabled = True
            chamanuailnitwords.Checked = True
            BtStartBattle.Enabled = False

        End If
    End Sub

    Private Sub TbWordsWaittoStart_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles TbWordsWaittoStart.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso (e.KeyChar <> "."c) Then
            e.Handled = True
        End If

        If (e.KeyChar = "."c) AndAlso ((TryCast(sender, TextBox)).Text.IndexOf("."c) > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TbWordsWaittoStart_TextChanged(sender As Object, e As EventArgs) Handles TbWordsWaittoStart.TextChanged
        ms.SaveSetting("TbWordsWaittoStart", TbWordsWaittoStart.text)
    End Sub

    Private Sub ListBoxDictionaries_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBoxDictionaries.SelectedValueChanged
        For Each item In ListBoxDictionaries.CheckedItems
            If ListBoxDictionaries.GetItemCheckState(ListBoxDictionaries.Items.IndexOf(item)) Then
              
            End If
        Next
    End Sub

    Private Sub ListBoxDictionaries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxDictionaries.SelectedIndexChanged
        LoadWords()
    End Sub

    Private Sub btNextWord_Click_2(sender As Object, e As EventArgs) Handles btNextWord.Click
        MainModule.GetWord()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub chkShuffle_CheckedChanged(sender As Object, e As EventArgs) Handles chkShuffle.CheckedChanged

    End Sub

    Private Sub MostrarPantallaPrincipalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarPantallaPrincipalToolStripMenuItem.Click
        MainModule.Show()
        Me.Show()
    End Sub
End Class