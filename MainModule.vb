Imports System.Net
Imports WMPLib

Public Class MainModule

    Public Shared ControlPositions As New Dictionary(Of String, Point)()

    ' Variables para el seguimiento de la ubicación del control mientras se arrastra.
    Private dragging As Boolean = False

    Private dragCursorPoint As Point
    Private dragControlPoint As Point

    ' Función para habilitar el drag and drop en un control.
    Private Sub EnableDragAndDrop(control As Control)
        AddHandler control.MouseDown, AddressOf Control_MouseDown
        AddHandler control.MouseMove, AddressOf Control_MouseMove
        AddHandler control.MouseUp, AddressOf Control_MouseUp
    End Sub

    ' Manejador del evento MouseDown para iniciar el arrastre.
    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            dragging = True
            Dim control = TryCast(sender, Control)
            dragCursorPoint = Cursor.Position
            dragControlPoint = control.PointToScreen(New Point(0, 0))
            dragControlPoint.X = dragControlPoint.X - dragCursorPoint.X
            dragControlPoint.Y = dragControlPoint.Y - dragCursorPoint.Y
            control.Capture = True
        End If
    End Sub

    ' Manejador del evento MouseMove para mover el control arrastrado.
    ' Manejador del evento MouseMove para mover el control arrastrado.
    Private Sub Control_MouseMove(sender As Object, e As MouseEventArgs)
        If dragging Then
            Dim control = TryCast(sender, Control) ' Declarar la variable control aquí
            Dim controlLocation As Point = Control.MousePosition
            controlLocation.Offset(dragControlPoint.X, dragControlPoint.Y)
            control.Location = control.Parent.PointToClient(controlLocation)
        End If
    End Sub

    ' Manejador del evento MouseUp para finalizar el arrastre.
    Private Sub Control_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            Dim control = TryCast(sender, Control)
            control.Capture = False
            dragging = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama a EnableDragAndDrop para habilitar el drag and drop en controles específicos.
        EnableDragAndDrop(lbCaractBatalla) ' Cambia Button1 al control que quieras habilitar.
        EnableDragAndDrop(lbTipoBatalla)  ' Cambia Label1 al control que quieras habilitar.
        If Ms.ReadSetting("chshufflemusic") = "1" Then
            ControlModule.chshufflemusic.Checked = True
        Else
            ControlModule.chshufflemusic.Checked = False

        End If
    End Sub

    Sub PlayVideo()
        'AxWindowsMediaPlayer1.URL = "video.mp4"
        'AxWindowsMediaPlayer1.settings.autoStart = True
        'AxWindowsMediaPlayer1.settings.mute = True
        'AxWindowsMediaPlayer1.settings.setMode("loop", True)
        'AxWindowsMediaPlayer1.uiMode = "None"
        'AxWindowsMediaPlayer1.Dock = DockStyle.Fill
        'AxWindowsMediaPlayer1.UseWaitCursor = False
        'esto no lo usaba Do While AxWindowsMediaPlayer1.playState <> WMPLib.WMPPlayState.wmppsPlaying
        '    Application.DoEvents()
        'Loop
        'AxWindowsMediaPlayer1.fullScreen = True
    End Sub

    Private _targetDt As DateTime
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60)
    Public Shared Rnd As New Random()
    Public Shared Startwords As Boolean = True
    Public Shared InitAll As Boolean = True
    Public Shared CountWords As Integer = 0

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PlayVideo()
        LbCountDown.BackColor = System.Drawing.Color.Transparent
        'Label1.BackColor = System.Drawing.Color.Transparent
        If Ms.ReadSetting("WindowState") <> "normal" Then
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = FormBorderStyle.None
        End If

        If Ms.ReadSetting("chshufflemusic") = "1" Then
            ControlModule.chkShuffle.Checked = True
        Else
            ControlModule.chkShuffle.Checked = False

        End If

        'Me.FormBorderStyle = FormBorderStyle.None
    End Sub

    Sub InitStates()
        ControlModule.CbBattleType.SelectedIndex = 1
        ControlModule.CbDuration.SelectedIndex = 0
        ControlModule.EscribirTipoBatalla()
        ControlModule.TbWordsWaittoStart.Text = Ms.ReadSetting("TbWordsWaittoStart")
        ControlModule.tbmusicdir.Text = Ms.ReadSetting("MusicDirectory")
        Me.Show()

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

    Dim intervalo As Long

    Sub PlayBattle(mode, wordswaittoStart, song, duration, manualorauto)
        LbCountDown.Visible = True
        LbWord.Text = ""
        ControlModule.LbWord.Text = ""
        Dim settimer = False
        _targetDt = DateTime.Now.Add(CountDownFrom)
        ControlModule.btStopBattle.Enabled = True

        If manualorauto = "manual" Or manualorauto = "semimanual" Then
            wordswaittoStart = 0
        End If

        Fn.Wait(CInt(wordswaittoStart)) ' Espera

        If manualorauto = "auto" Or manualorauto = "semimanual" Then
            If mode <> 3 Then
                Dim myfont As Font = Fn.GetFontByString(Ms.ReadSetting("lbWordFont"))
                Dim fontName As FontFamily = myfont.FontFamily
                Dim fontsize = myfont.Size
                LbWord.Font = New Font(fontName, fontsize)
                GetWord()
            Else
                GenerateArray4Words()
                LbWord.Text = UCase(Vars.Arr4Words(0).ToString)
                Dim otherword As String = LbWord.Text
                otherword = Replace(otherword, vbNewLine, "/")
                ControlModule.LbWord.Text = otherword
            End If
        End If

        CountWords = CountWords + 1
        Dim MyMode As String = ControlModule.TabMode.SelectedTab.Text()

        If manualorauto = "auto" Or manualorauto = "semimanual" Then
            Select Case ControlModule.CbBattleType.SelectedIndex
                Case 0, 3
                    TimerWord.Interval = 10000 ' Intervalo de 10 segundos
                Case 1
                    TimerWord.Interval = 5000 ' Intervalo de 5 segundos
                Case 2
                    TimerWord.Interval = 2000 ' Intervalo de 2 segundos
            End Select

            intervalo = TimerWord.Interval

            If manualorauto = "auto" Then
                iniciarCustomProgressBar1()
                TimerWord.Start()
            Else
                TimerWord.Stop()
            End If
        Else
            TimerWord.Stop()
        End If

        TimerVisualCountDown.Interval = 100 ' Intervalo de 1 segundo
        TimerVisualCountDown.Start()

    End Sub

    Sub iniciarCustomProgressBar1()
        CustomProgressBar1.Minimum = 0
        CustomProgressBar1.Maximum = TimerWord.Interval - 100
        CustomProgressBar1.Value = TimerWord.Interval - 100
        CustomProgressBar1.Invalidate()
        TimerProgressBar1.Start()
    End Sub

    Sub pararCustomProgressBar1()
        CustomProgressBar1.Minimum = 0
        CustomProgressBar1.Maximum = TimerWord.Interval
        CustomProgressBar1.Value = 0
        CustomProgressBar1.Invalidate()
        TimerProgressBar1.Stop()
    End Sub

    Private Sub TimerProgressBar1_Tick(sender As Object, e As EventArgs) Handles TimerProgressBar1.Tick
        If CustomProgressBar1.Value >= 100 Then
            CustomProgressBar1.Value -= 100
            CustomProgressBar1.Invalidate()
        Else
            CustomProgressBar1.Value = 0
            CustomProgressBar1.Invalidate()
            TimerProgressBar1.Stop() ' Detener el temporizador
            ' Realizar otras acciones necesarias
        End If
    End Sub

    Sub GenerateArray4Words()

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
    End Sub

    Private Sub TimerWord_Tick(sender As Object, e As EventArgs) Handles TimerWord.Tick
        Dim tiempo As TimeSpan
        If TimeSpan.TryParse(LbCountDown.Text, tiempo) Then
            Dim segundos As Double = tiempo.TotalSeconds
            If intervalo < (segundos * 1000) Then
                GetWord()
                Me.Invoke(New Action(AddressOf iniciarCustomProgressBar1))
            Else
                LbWord.Text = ""
            End If
        Else
            ' Manejar el caso en el que LbCountDown.Text no es un formato de tiempo válido
            ' Puedes mostrar un mensaje de error o tomar otra acción apropiada.
        End If
    End Sub

    Sub GetWord()
        Try
            If ControlModule.CbBattleType.SelectedIndex <> 3 Then
                Dim word = UCase(Vars.Arr(CountWords).ToString)

                If Not InStr("%" & Vars.WordsShowed & "%", "%" & word & "%") <> 0 Then
                    LbWord.Text = word
                    ControlModule.LbWord.Text = word

                    If Vars.WordsShowed = "" Then
                        Vars.WordsShowed = "%" & LbWord.Text & "%"
                    Else
                        Vars.WordsShowed &= LbWord.Text & "%"
                    End If
                Else
                    CountWords += 1
                    GetWord()
                End If
            Else
                If IsNothing(Vars.Arr4Words) Then
                    GenerateArray4Words()
                End If

                LbWord.Text = UCase(Vars.Arr4Words(CountWords).ToString)
                ControlModule.LbWord.Text = Replace(LbWord.Text, vbCrLf, "/")
            End If

            CountWords += 1
        Catch
            CountWords = 0
            Vars.WordsShowed = ""
            Fn.WriteLog("Repitiendo palabras, se han mostrado todas o no hay nada seleccionado en los diccionarios.")
        End Try
    End Sub

    'Sub CheckIfStartwords(espera, b)
    '    Try
    '        If Startwords = True Then
    '            'problema cuando es más de 60 minutos
    '            'Dim tas As TimeSpan = TimeSpan.Parse("00:" & LblCountDown.Text.ToString, Globalization.CultureInfo.InvariantCulture)
    '            'Dim x = tas.TotalSeconds

    '            Dim totalsectranscurridos = TimeSpan.FromSeconds((LbCountDown.Text)).TotalSeconds
    '            While CInt(totalsectranscurridos + espera) >= b
    '                totalsectranscurridos = TimeSpan.FromSeconds(LbCountDown.Text).TotalSeconds
    '                Fn.Wait(0.01)
    '            End While
    '        Else
    '            While Startwords = False
    '                Fn.Wait(0.01)
    '            End While
    '        End If
    '    Catch
    '        'aqui da error MsgBox("Error en la espera")
    '    End Try
    'End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        StopBattleFunctions()
    End Sub

    Public Shared Sub StopBattleFunctions(Optional ByVal ManualStop As Boolean = False)
        Try
            Vars.StopBattle = True
            MainModule.LbCountDown.Text = "00"
            ControlModule.LbCountDown.Text = "00"
            MainModule.TimerVisualCountDown.Stop()
            MainModule.LbWord.Text = "HazteUnFree"
            ControlModule.LbWord.Text = "HazteUnFree"
            MainModule.pararCustomProgressBar1()

            MainModule.TimerProgressBar1.Stop()

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
            ControlModule.Button3.Enabled = True
            ControlModule.Button4.Enabled = True
            If ManualStop = False Then
                If Ms.ReadSetting("chkSoundFx") = "1" Then
                    Dim wmplayer = New WindowsMediaPlayer()
                    wmplayer.URL = "SoundFx.mp3"
                    wmplayer.controls.play()
                    wmplayer = Nothing
                End If
            End If
        Catch
        End Try

        Try
            MainModule.Show()
        Catch

        End Try
    End Sub

    Private Sub TimerVisualCountDown_Tick(sender As Object, e As EventArgs) Handles TimerVisualCountDown.Tick
        Dim timeRemaining As TimeSpan = _targetDt.Subtract(DateTime.Now)
        Dim remainingText As String = ""

        Dim countdownFont As Font = Fn.GetFontByString(Ms.ReadSetting("lbCountDownFont"))
        Dim normalFontSize As Single = countdownFont.Size
        Dim smallerFontSize As Single = normalFontSize - Math.Round(normalFontSize / 3)

        If timeRemaining.TotalMilliseconds > 60000 Then
            remainingText = timeRemaining.ToString("mm\:ss").Substring(1)
            If LbCountDown.Font.Size <> smallerFontSize Then
                LbCountDown.Font = New Font(countdownFont.FontFamily, smallerFontSize)
            End If
        ElseIf timeRemaining.TotalMilliseconds < 60000 Then
            remainingText = timeRemaining.ToString("ss")
            If LbCountDown.Font.Size <> normalFontSize Then
                LbCountDown.Font = countdownFont
            End If
        End If

        LbCountDown.Text = remainingText
        ControlModule.LbCountDown.Text = remainingText

        If timeRemaining.TotalMilliseconds <= 0 Then
            TimerVisualCountDown.Stop()

            If Ms.ReadSetting("chkSoundFx") = "1" Then
                Dim wmplayer As New WindowsMediaPlayer()
                wmplayer.URL = "SoundFx.mp3"
                wmplayer.controls.play()
            End If

            If ControlModule.chkMinimize.Checked Then
                ControlModule.Show()
            End If

            StopBattleFunctions()
        End If

        countdownFont.Dispose() ' Dispose the font when done to prevent memory leaks
    End Sub

    Public Shared Sub SaveControlPositions()
        For Each ctrl As Control In ControlModule.Controls ' Cambia ControlModule al nombre de tu formulario
            ControlPositions(ctrl.Name) = ctrl.Location
        Next
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'SaveControlPositions()
        StopBattleFunctions(True)
        SavePositions()
    End Sub

    Sub SavePositions()
        Ms.SaveSetting("MainWidth", Me.Width)
        Ms.SaveSetting("MainHeight", Me.Height)
        Ms.SaveSetting("WindowState", Me.WindowState.ToString())
        Ms.SaveSetting("LbCountDownPositionX", LbCountDown.Left)
        Ms.SaveSetting("LbCountDownPositionY", LbCountDown.Top)
        Ms.SaveSetting("LbTipoBatallaPositionX", lbTipoBatalla.Left)
        Ms.SaveSetting("LbTipoBatallaPositionY", lbTipoBatalla.Top)
        Ms.SaveSetting("LbCaractBatallaPositionX", lbCaractBatalla.Left)
        Ms.SaveSetting("LbCaractBatallaPositionY", lbCaractBatalla.Top)
        Ms.SaveSetting("LbWordPositionX", LbWord.Left)
        Ms.SaveSetting("LbWordPositionY", LbWord.Top)
        Ms.SaveSetting("ProgressBar1PositionX", CustomProgressBar1.Location.X)
        Ms.SaveSetting("ProgressBar1PositionY", CustomProgressBar1.Location.Y)
        Ms.SaveSetting("chshufflemusic", IIf(ControlModule.chshufflemusic.Checked = True, "1", "0"))

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

        If e.Button = MouseButtons.Right Then
            MsgBox("Right Button Clicked")
            Exit Sub

        End If
    End Sub

    Private Sub LbCountDown_MouseMove(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseMove
        If _dragging = True Then
            LbCountDown.Location = New Point(LbCountDown.Location.X + e.X - _beginX,
                                             LbCountDown.Location.Y + e.Y - _beginY)

        End If
    End Sub

    Private Sub LbCountDown_MouseUp(sender As Object, e As MouseEventArgs) Handles LbCountDown.MouseUp
        _dragging = False

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

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = FormBorderStyle.Sizable
        End If
    End Sub

    Private Sub LbWord_MouseUp(sender As Object, e As MouseEventArgs) Handles LbWord.MouseUp
        _dragging = False
        'Ms.SaveSetting("LbWordPositionX", sender.left)
        'Ms.SaveSetting("LbWordPositionY", sender.top)
        'Fn.WriteLog("posición de la palabra guardada.")
    End Sub

    Private Sub LbWord_DragDrop(sender As Object, e As DragEventArgs) Handles LbWord.DragDrop
        LbWord.Location = New Point(LbWord.Location.X + e.X - _beginX, LbWord.Location.Y + e.Y - _beginY)
    End Sub

    Private isDragging As Boolean = False
    Private dragStartPoint As Point

    Private Sub CustomProgressBar1_MouseDown(sender As Object, e As MouseEventArgs) Handles CustomProgressBar1.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            dragStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub CustomProgressBar1_MouseMove(sender As Object, e As MouseEventArgs) Handles CustomProgressBar1.MouseMove
        If isDragging Then
            Dim deltaX As Integer = e.X - dragStartPoint.X
            Dim deltaY As Integer = e.Y - dragStartPoint.Y
            CustomProgressBar1.Location = New Point(CustomProgressBar1.Location.X + deltaX, CustomProgressBar1.Location.Y + deltaY)
        End If
    End Sub

    Private Sub CustomProgressBar1_MouseUp(sender As Object, e As MouseEventArgs) Handles CustomProgressBar1.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lbCaractBatalla.Click

    End Sub

    '    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent)
    '        If e.newState = 8 Or e.newState = 9 Or e.newState = 10 Then

    '            If e.newState = 8 Then
    '            If axWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Then
    '    axWindowsMediaPlayer1.Ctlcontrols.play()
    'End If
    '            End If
    '        End If
    '    End Sub
End Class