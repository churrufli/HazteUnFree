
Imports System.Net
Imports WMPLib

Public Class MainModule
    Private _targetDt As DateTime
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60)
    Public Shared Rnd As New Random()
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
            Fn.Shuffle(Vars.Arr)
            Fn.WriteLog("Aleatorizando orden de aparición de palabras...")
        End If
        Dim mode As String = ControlModule.CbBattleType.SelectedIndex
        Select Case mode
            Case 0
                mode = 10
            Case 1
                mode = 5
            Case 2
                mode = 2
            Case 3
                mode = 3
            Case Else
                mode = 0
                ControlModule.CbBattleType.SelectedIndex = mode
        End Select

        Select Case ControlModule.CbDuration.SelectedIndex
            Case 0 '1
                Me.CountDownFrom = TimeSpan.FromSeconds(60)
            Case 1 '1_20
                Me.CountDownFrom = TimeSpan.FromSeconds(80)
            Case 2
                Me.CountDownFrom = TimeSpan.FromSeconds(120)
            Case Else
                Me.CountDownFrom = TimeSpan.FromSeconds(Vars.SongDuration)
        End Select

        PlayBattle(mode, ControlModule.TbWordsWaittoStart.Text, Nothing, Me.CountDownFrom, manualorauto)
    End Sub


    Sub PlayBattle(mode, wordswaittoStart, song, duration, manualorauto)
        '///////////////////////////////////////
        LbCountDown.Visible = True
        LbWord.Text = ""
        ControlModule.LbWord.Text = ""

        Dim settimer = False

        _targetDt = DateTime.Now.Add(CountDownFrom)
        ControlModule.btStopBattle.Enabled = True


        'esto llama a la funcion tick y el contador del tiempo
        TimerVisualCountDown.Interval = (900)
        TimerVisualCountDown.Start()

        'espera 
        Dim espera = CInt(wordswaittoStart)
        Fn.Wait(espera)

        'pongo la primera palabra


        If mode <> 3 Then

            LbWord.Text = UCase(Vars.Arr(0).ToString)
            ControlModule.LbWord.Text = UCase(Vars.Arr(0).ToString)
        Else
            'aqui tengo que cambiar el tamaño de la fuente
            Dim myfont As Font = Fn.GetFontByString(Ms.ReadSetting("lbWordFont"))
            Dim fontName As FontFamily = myfont.FontFamily
            Dim fontsize = myfont.Size - Math.Round(myfont.Size / 3)
            LbWord.Font = New Font(fontName, fontsize)

            Dim countWords = 0
            Dim cadena = ""
            Dim salir = 0

            For Each w In Vars.Arr
                countWords = countWords + 1

                Select Case countWords
                    Case 1, 3
                        cadena = cadena & w
                    Case 2
                        cadena = cadena & "/" & w & vbNewLine
                    Case 4
                        cadena = cadena & "/" & w & ";"
                End Select

                If countWords >= 4 Then
                    countWords = 0
                End If
                salir = salir + 1
                If salir > 1000 Then Exit For
            Next

            Vars.Arr4Words = Split(cadena, ";")
            LbWord.Text = UCase(Vars.Arr4Words(0).ToString)
            Dim otherword As String = LbWord.Text
            otherword = Replace(otherword, vbNewLine, "/")
            otherword = otherword
            ControlModule.LbWord.Text = otherword
        End If

        'ahora inicio el temporizador para las palabras
        CountWords = CountWords + 1
        Dim MyMode as string = ControlModule.TabMode.SelectedTab.Text() 
       
        If MyMode = "Modo Automático"  Then

            Select Case ControlModule.CbBattleType.SelectedIndex
                Case 0, 3
                    TimerWord.Interval = (10000) 'ms
                Case 1
                    TimerWord.Interval = (5000)
                Case 2
                    TimerWord.Interval = (2000)
            End Select

            If MyMode = "Modo Automático"  Then
                TimerWord.Start()
            Else
                TimerWord.Stop()

            End If

        Else
            'es manual 
            'TimerWord.Interval = (1000000)

            TimerWord.Stop()
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

                If InStr("%" & Vars.WordsShowed & "%", "%" & UCase(Vars.Arr(CountWords).ToString) & "%") = 0 Then
                    LbWord.Text = UCase(Vars.Arr(CountWords).ToString)
                    ControlModule.LbWord.Text = UCase(Vars.Arr(CountWords).ToString)

                    If Vars.WordsShowed = "" Then
                        Vars.WordsShowed = "%" & LbWord.Text & "%"
                    Else
                        Vars.WordsShowed = Vars.WordsShowed & LbWord.Text & "%"
                    End If
                Else
                    CountWords = CountWords + 1
                    GetWord()
                End If


            Else
                LbWord.Text = UCase(Vars.Arr4Words(CountWords).ToString)
                ControlModule.LbWord.Text = UCase(Vars.Arr4Words(CountWords).ToString)

            End If
            CountWords = CountWords + 1
        Catch
            CountWords = 0
            Vars.WordsShowed = ""
            Fn.WriteLog("Repitiendo palabras, se han mostrado todas o no hay nada seleccionado en los diccionarios.")
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
                    Fn.Wait(0.01)
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
            Vars.StopBattle = True
            MainModule.LbCountDown.Text = "00"
            ControlModule.LbCountDown.Text = "00"
            MainModule.TimerVisualCountDown.Stop()
            MainModule.LbWord.Text = "HazteUnFree"
            ControlModule.LbWord.Text = "HazteUnFree"

            MainModule.TimerWord.Stop()
            'Fn.Wait(1)
            Vars.Player.controls.stop()
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

    Dim fontreaded As Boolean = false

    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles TimerVisualCountDown.Tick
        Dim ts As TimeSpan = _targetDt.Subtract(DateTime.Now)
        Dim t = ""

        Dim myfont = Fn.GetFontByString(Ms.ReadSetting("lbCountDownFont"))
      

        Dim fontName As FontFamily = myfont.FontFamily
        Dim fontsize = myfont.Size - Math.Round(myfont.Size / 3)
        Dim fontsizereal = myfont.Size

        Select Case ts.TotalMilliseconds
            Case > 60000
                t = ts.ToString("mm\:ss").Remove(0, 1)
                If LbCountDown.Font.Size <> fontsize Then
                    LbCountDown.Font = New Font(fontName, fontsize)
                End If
            Case < 60000
                t = ts.ToString("ss")
                If LbCountDown.Font.Size <> fontsizereal Then
                    LbCountDown.Font = Fn.GetFontByString(Ms.ReadSetting("lbCountDownFont"))
                End If
                'End If
        End Select

        LbCountDown.Text = t
        ControlModule.LbCountDown.Text = t

        If ts.TotalMilliseconds <= 0 Then
            TimerVisualCountDown.Stop()
            If Ms.ReadSetting("chkSoundFx") = "1" Then
                Dim wmplayer = New WindowsMediaPlayer()
                wmplayer.URL = "SoundFx.mp3"
                wmplayer.controls.play()
                wmplayer = Nothing
            End If
            If ControlModule.chkMinimize.Checked Then
                ControlModule.Show()
            End If

            StopBattleFunctions()
        End If
        myfont = Nothing

    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopBattleFunctions()
        Ms.SaveSetting("MainWidth", Me.Width)
        Ms.SaveSetting("MainHeight", Me.Height)
        Ms.SaveSetting("WindowState", Me.WindowState.ToString())

    End Sub

    Public Shared Function ReadWeb(myUrl As String)
        Dim reply As String
        myUrl = Replace(myUrl, "'", "")
        myUrl = Replace(myUrl, """", "")
        Dim res As String
        If myUrl = "" Then Exit Function
        Try
            Dim client = New WebClient()
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            reply = client.DownloadString(myUrl)
            Return reply
            Exit Function
        Catch ex As Exception
        End Try
        ReadWeb = res
    End Function

    Dim _dragging
    Dim _beginX
    Dim _beginY
    Dim _pictureBox1 = LbCountDown

    Private Sub LbCountDown_MouseDown(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseDown
        _dragging = True
        _beginX = e.X
        _beginY = e.Y
    End Sub

    Private Sub LbCountDown_MouseMove(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseMove
        If _dragging = True Then
            LbCountDown.Location = New Point(LbCountDown.Location.X + e.X - _beginX,
                                             LbCountDown.Location.Y + e.Y - _beginY)

        End If
    End Sub

    Private Sub LbCountDown_MouseUp(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseUp
        _dragging = False
        Ms.SaveSetting("LbCountDownPositionX", sender.left)
        Ms.SaveSetting("LbCountDownPositionY", sender.top)
        Fn.WriteLog("posición del contador guardada.")
    End Sub

    Private Sub LbCountDown_DragDrop(sender As Object, e As DragEventArgs) Handles LbCountDown.DragDrop
        LbCountDown.Location = New Point(LbCountDown.Location.X + e.X - _beginX, LbCountDown.Location.Y + e.Y - _beginY)
    End Sub

    ''''
    Private Sub LbWord_MouseDown(sender As Object, e As MouseEventArgs) Handles LbWord.MouseDown
        _dragging = True
        _beginX = e.X
        _beginY = e.Y

        If e.Button = MouseButtons.Right Then

        End If
    End Sub

    Private Sub LbWord_MouseMove(sender As Object, e As MouseEventArgs) Handles LbWord.MouseMove
        If _dragging = True Then
            LbWord.Location = New Point(LbWord.Location.X + e.X - _beginX, LbWord.Location.Y + e.Y - _beginY)
        End If
    End Sub

    Private Sub LbWord_MouseUp(sender As Object, e As MouseEventArgs) Handles LbWord.MouseUp
        _dragging = False
        Ms.SaveSetting("LbWordPositionX", sender.left)
        Ms.SaveSetting("LbWordPositionY", sender.top)
        Fn.WriteLog("posición de la palabra guardada.")
    End Sub

    Private Sub LbWord_DragDrop(sender As Object, e As DragEventArgs) Handles LbWord.DragDrop
        LbWord.Location = New Point(LbWord.Location.X + e.X - _beginX, LbWord.Location.Y + e.Y - _beginY)
    End Sub
End Class
