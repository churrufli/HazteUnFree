
Imports System.Net
Imports WMPLib

Public Class MainModule
    Private TargetDT As DateTime
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60)
    Public Shared rnd As New Random()
    Public Shared Startwords As Boolean = True
    Public Shared InitAll As Boolean = True
    Public Shared CountWords As Integer = 0

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        'Me.FormBorderStyle = FormBorderStyle.None
    End Sub

    Sub InitStates()
        ControlModule.CbBattleType.SelectedIndex = 1
        ControlModule.CbDuration.SelectedIndex = 0
        CenterItems()
    End Sub

    Public Shared Sub CenterItems()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        TimerGetWords.Stop()
    End Sub

    Sub SetBattle(manualorauto As String)
        If ControlModule.chkShuffle.Checked = True Then
            Fn.Shuffle(vars.arr)
            Fn.WriteLog("Aleatorizando orden de aparición de palabras...")
        End If
        Dim Mode As String = ControlModule.CbBattleType.SelectedIndex
        Select Case Mode
            Case 0
                Mode = 10
            Case 1
                Mode = 5
            Case 2
                Mode = 2
            Case 3
                Mode = 3
            Case Else
                Mode = 0
                ControlModule.CbBattleType.SelectedIndex = Mode
        End Select

        Select Case ControlModule.CbDuration.SelectedIndex
            Case 0 '1
                Me.CountDownFrom = TimeSpan.FromSeconds(60)
            Case 1 '1_20
                Me.CountDownFrom = TimeSpan.FromSeconds(80)
            Case 2
                Me.CountDownFrom = TimeSpan.FromSeconds(120)
            Case Else
                Me.CountDownFrom = TimeSpan.FromSeconds(vars.SongDuration)
        End Select

        PlayBattle(Mode, ControlModule.TbWordsWaittoStart.Text, Nothing, Me.CountDownFrom, manualorauto)
    End Sub


    Sub PlayBattle(Mode, WordswaittoStart, Song, duration, manualorauto)
        '///////////////////////////////////////
        LbCountDown.Visible = True
        LbWord.Text = ""
        ControlModule.LbWord.Text = ""

        Dim settimer = False

        TargetDT = DateTime.Now.Add(CountDownFrom)
        ControlModule.btStopBattle.Enabled = True

        'esto llama a la funcion tick y el contador del tiempo
        TimerVisualCountDown.Interval = (900)
        TimerVisualCountDown.Start()

        'If ControlModule.chautoinitwords.Checked Then
        'espera 
        Dim espera = CInt(WordswaittoStart)
        Fn.Wait(espera)
        'pongo la primera palabra


        If Mode <> 3 Then
            LbWord.Text = UCase(vars.arr(0).ToString)
            ControlModule.LbWord.Text = UCase(vars.arr(0).ToString)
        Else
            'aqui tengo que cambiar el tamaño de la fuente
            Dim myfont As Font = Fn.GetFontByString(ms.ReadSetting("lbWordFont"))
            Dim fontName As FontFamily = myfont.FontFamily
            Dim fontsize = myfont.Size - Math.Round(myfont.Size / 3)
            LbWord.Font = New Font(fontName, fontsize)

            Dim CountWords = 0
            Dim cadena = ""
            Dim salir = 0

            For Each w In vars.arr
                CountWords = CountWords + 1

                Select Case CountWords
                    Case 1, 3
                        cadena = cadena & w
                    Case 2
                        cadena = cadena & "/" & w & vbNewLine
                    Case 4
                        cadena = cadena & "/" & w & ";"
                End Select

                If CountWords >= 4 Then
                    CountWords = 0
                End If
                salir = salir + 1
                If salir > 1000 Then Exit For
            Next

            vars.arr4words = Split(cadena, ";")
            LbWord.Text = UCase(vars.arr4words(0).ToString)
            ControlModule.LbWord.Text = Replace(UCase(vars.arr4words(0).ToString), vbNewLine, "/")

            '////////////////
        End If


        'ahora inicio el temporizador para las palabras
        CountWords = CountWords + 1

        If ControlModule.rbAutoMode.Checked Then

            Select Case ControlModule.CbBattleType.SelectedIndex
                Case 0, 3
                    TimerWord.Interval = (10000) 'ms
                Case 1
                    TimerWord.Interval = (5000)
                Case 2
                    TimerWord.Interval = (2000)
            End Select

            'PROGRESS BAR
            TimerProgressBar.Interval = 100
            ProgressBar1.Maximum = CInt(TimerWord.Interval / 10)
            ProgressBar1.Minimum = 10
            TimerProgressBar.Enabled = True
            TimerProgressBar.Start()

            If ControlModule.rbAutoMode.Checked Then
                TimerWord.Start()
            End If

        Else
            'es manual 
            TimerWord.Interval = (1000000)
        End If


        'Fn.LoadMusic()
    End Sub

    Private Sub TimerWord_Tick(sender As Object, e As EventArgs) Handles TimerWord.Tick
        'aqui mostraría la palabra siguiente
        GetWord()
    End Sub

    Sub GetWord()
        Try
            If ControlModule.CbBattleType.SelectedIndex <> 3 Then
                LbWord.Text = UCase(vars.arr(CountWords).ToString)
                ControlModule.LbWord.Text = UCase(vars.arr(CountWords).ToString)

            Else
                LbWord.Text = UCase(vars.arr4words(CountWords).ToString)
                ControlModule.LbWord.Text = UCase(vars.arr4words(CountWords).ToString)

            End If
            CountWords = CountWords + 1
        Catch
            CountWords = 0
            Fn.WriteLog("Repitiendo palabras, se han mostrado todas.")
        End Try
    End Sub

    Private Sub TimerProgressBar_Tick(sender As Object, e As EventArgs) Handles TimerProgressBar.Tick
        Try
            ProgressBar1.Value = ProgressBar1.Value + 10
            If ProgressBar1.Value >= ProgressBar1.Maximum Then
                ProgressBar1.Value = 10
                'TimerProgressBar.Enabled = False
                'ProgressBar1.Refresh()
            End If
        Catch
        End Try
    End Sub

    Sub CheckIfStartwords(espera, b)
        Try
            If Startwords = True Then
                'problema cuando es más de 60 minutos
                'Dim tas As TimeSpan = TimeSpan.Parse("00:" & LblCountDown.Text.ToString, Globalization.CultureInfo.InvariantCulture)
                'Dim x = tas.TotalSeconds

                Dim totalsectranscurridos = TimeSpan.FromSeconds((LbCountDown.Text)).TotalSeconds
                While CInt(totalsectranscurridos + espera) >= b
                    totalsectranscurridos = TimeSpan.FromSeconds(LbCountDown.Text).TotalSeconds
                    Fn.Wait(0.1)
                End While
            Else
                While Startwords = False
                    Fn.Wait(0.01)
                End While
            End If
        Catch
            'aqui da error MsgBox("Error en la espera")
        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs)
        StopBattleFunctions()
    End Sub

    Public Shared Sub StopBattleFunctions()
        Try
            vars.StopBattle = True
            MainModule.LbCountDown.Text = "00"
            ControlModule.LbCountDown.Text = "00"
            MainModule.TimerVisualCountDown.Stop()
            MainModule.LbWord.Text = "-"

            MainModule.TimerWord.Stop()
            Fn.Wait(1)
            vars.Player.controls.stop()
            ControlModule.LbWord.Text = ""
            ControlModule.BtStartBattle.Enabled = True
            ControlModule.Enabled = True
            ControlModule.BtStartBattle.Enabled = True
            ControlModule.btStartWords.Enabled = True
            ControlModule.CbBattleType.Enabled = True
            ControlModule.CbDuration.Enabled = True
            'ControlModule.btStopBattle.Enabled = True
            CountWords = 0
        Catch
        End Try
    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles TimerVisualCountDown.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim t = ""
        Select Case ts.TotalMilliseconds
            Case > 60000
                t = ts.ToString("mm\:ss").Remove(0, 1)
                Dim myfont As Font = Fn.GetFontByString(ms.ReadSetting("lbCountDownFont"))
                Dim fontName As FontFamily = myfont.FontFamily
                Dim fontsize = myfont.Size - Math.Round(myfont.Size / 3)
                LbCountDown.Font = New Font(fontName, fontsize)
            Case < 60000
                t = ts.ToString("ss")
                LbCountDown.Font = Fn.GetFontByString(ms.ReadSetting("lbCountDownFont"))
        End Select

        LbCountDown.Text = t
        ControlModule.LbCountDown.Text = t


        'If ProgressBar1.Value = ProgressBar1.Maximum Then ProgressBar1.Value = 1
        'ProgressBar1.Value = ProgressBar1.Value + 1

        If ts.TotalMilliseconds <= 0 Then

            TimerVisualCountDown.Stop()

            If ms.ReadSetting("chkHorn") = "1" Then
                Dim wplayer = New WindowsMediaPlayer()
                wplayer.URL = "horn.mp3"
                wplayer.controls.play()
                wplayer = Nothing
            End If
            If ControlModule.chkMinimize.Checked Then
                ControlModule.Show()
            End If

            StopBattleFunctions()
        End If
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopBattleFunctions()
        ms.SaveSetting("MainWidth", Me.Width)
        ms.SaveSetting("MainHeight", Me.Height)
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    SetBattle()
    'End Sub
    Public Shared Function ReadWeb(MyUrl As String)
        Dim reply As String
        MyUrl = Replace(MyUrl, "'", "")
        MyUrl = Replace(MyUrl, """", "")
        Dim res As String
        If MyUrl = "" Then Exit Function
        Try
            Dim client = New WebClient()
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            reply = client.DownloadString(MyUrl)
            Return reply
            Exit Function
        Catch ex As Exception
        End Try
        ReadWeb = res
    End Function
    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    TimerGetWords.Start()
    'End Sub
    Sub sacapalabra()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerGetWords.Tick
        sacapalabra()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim i = 0
        While i < 1000000
            sacapalabra()
            Fn.Wait(2)
            i = i + 1
        End While
    End Sub

    Dim dragging
    Dim beginX
    Dim beginY
    Dim PictureBox1 = LbCountDown

    Private Sub LbCountDown_MouseDown(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseDown
        dragging = True
        beginX = e.X
        beginY = e.Y
    End Sub

    Private Sub LbCountDown_MouseMove(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseMove
        If dragging = True Then
            LbCountDown.Location = New Point(LbCountDown.Location.X + e.X - beginX,
                                             LbCountDown.Location.Y + e.Y - beginY)
            'Me.Refresh()
        End If
    End Sub

    Private Sub LbCountDown_MouseUp(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseUp
        dragging = False
        ms.SaveSetting("LbCountDownPositionX", sender.left)
        ms.SaveSetting("LbCountDownPositionY", sender.top)
        Fn.WriteLog("posición del contador guardada.")
    End Sub

    Private Sub LbCountDown_DragDrop(sender As Object, e As DragEventArgs) Handles LbCountDown.DragDrop
        LbCountDown.Location = New Point(LbCountDown.Location.X + e.X - beginX, LbCountDown.Location.Y + e.Y - beginY)
    End Sub

    ''''
    Private Sub LbWord_MouseDown(sender As Object, e As MouseEventArgs) Handles LbWord.MouseDown
        dragging = True
        beginX = e.X
        beginY = e.Y

        If e.Button = MouseButtons.Right Then

        End If
    End Sub

    Private Sub LbWord_MouseMove(sender As Object, e As MouseEventArgs) Handles LbWord.MouseMove
        If dragging = True Then
            LbWord.Location = New Point(LbWord.Location.X + e.X - beginX, LbWord.Location.Y + e.Y - beginY)
            'Me.Refresh()
        End If
    End Sub

    Private Sub LbWord_MouseUp(sender As Object, e As MouseEventArgs) Handles LbWord.MouseUp
        dragging = False
        ms.SaveSetting("LbWordPositionX", sender.left)
        ms.SaveSetting("LbWordPositionY", sender.top)
        Fn.WriteLog("posición de la palabra guardada.")
    End Sub

    Private Sub LbWord_DragDrop(sender As Object, e As DragEventArgs) Handles LbWord.DragDrop
        LbWord.Location = New Point(LbWord.Location.X + e.X - beginX, LbWord.Location.Y + e.Y - beginY)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
    End Sub
End Class
