Imports VB = Microsoft.VisualBasic

Public Class MainModule
    Private TargetDT As DateTime
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60)
    Public Shared rnd As New Random()
    Public Shared Startwords As Boolean = True
    Public Shared InitAll As Boolean = True
    Public Shared CountWords As Integer = 0
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'Me.FormBorderStyle = FormBorderStyle.None
    End Sub
    Sub InitStates()
        ControlModule.CbBattleType.SelectedIndex = 1
        ControlModule.CbDuration.SelectedIndex = 0
        CenterItems()
    End Sub
    Public Shared Sub CenterItems()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TimerGetWords.Stop()
    End Sub

    Sub SetBattle()
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
                Me.CountDownFrom = TimeSpan.FromSeconds(240)
        End Select

        PlayBattle(Mode, ControlModule.TbWordsWaittoStart.Text, Nothing, Me.CountDownFrom)
    End Sub

    Function PlayBattle(Mode, WordswaittoStart, Song, duration)


        PlayBattleV2(Mode, WordswaittoStart, Song, duration)
        Exit Function


        LbWord.Text = ""

        If vars.StopBattle = True Then
            Exit Function
        End If

        Fn.PlayMusic()

        Dim settimer As Boolean = False

        TargetDT = DateTime.Now.Add(CountDownFrom)
        ControlModule.btstopbattle.Enabled = True
        TimerVisualCountDown.Interval = CInt(Mode + 1)
        TimerVisualCountDown.Start()
        Dim a = CInt(CountDownFrom.TotalSeconds + WordswaittoStart)
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim b = CInt(ts.TotalSeconds)

        Dim arr = vars.arr
        Dim espera = CInt(WordswaittoStart)
        LbCountDown.Text = b

        If Mode <> 3 Then ' si no es el modo de sacar varias, y solo saca una....

            LbWord.Font = New Font("Impact", 190.25)
            For Each w In arr
                'valido
                If vars.StopBattle = True Then
                    Exit Function
                End If

                ts = TargetDT.Subtract(DateTime.Now)
                b = CInt(ts.TotalSeconds)

                If b > 60 Then
                    LbCountDown.Font = New Font("Impact", 180)
                Else
                    LbCountDown.Font = New Font("Impact", 240.25)
                End If

                CheckIfStartwords(espera, b)


                LbWord.Text = UCase(w)
                Fn.Wait(CInt(Mode) - 0.15)

                If settimer = False Then
                    settimer = True
                    CenterItems()
                End If

                If vars.StopBattle Then
                    vars.StopBattle = False
                    Exit Function
                End If
            Next
        Else

            'valido

            If vars.StopBattle = True Then
                Exit Function
            End If

            LbWord.Font = New Font("Impact", 100)
            'LbWord.Top = (LbWord.Parent.Height \ 2) - (LbWord.Height \ 2) + 245

            Dim CountWords As Integer = 0
            Dim cadena As String = ""
            Dim salir As Integer = 0

            For Each w In arr
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
                If salir > 10000 Then Exit For
            Next

            Dim arr2 As String() = Split(cadena, ";")

            For Each w In arr2

                ts = TargetDT.Subtract(DateTime.Now)
                b = CInt(ts.TotalSeconds)

                CheckIfStartwords(espera, b)

                LbWord.Text = UCase(w)
                CenterItems()


                Fn.Wait(10 - 0.15)
                If settimer = False Then
                    settimer = True
                    CenterItems()
                End If

                If vars.StopBattle Then
                    StopBattleFunctions()
                    vars.StopBattle = False
                    Exit Function
                End If
            Next

            '//////////////////
        End If

    End Function

    Sub PlayBattleV2(Mode, WordswaittoStart, Song, duration)
        '///////////////////////////////////////

        LbWord.Text = ""
        Fn.LoadMusic()
        Fn.PlayMusic()

        Dim settimer As Boolean = False

        TargetDT = DateTime.Now.Add(CountDownFrom)
        ControlModule.btstopbattle.Enabled = True

        'esto llama a la funcion tick y el contador del tiempo
        TimerVisualCountDown.Interval = (900)
        TimerVisualCountDown.Start()

        If ControlModule.chautoinitwords.Checked Then
            'espera 
            Dim espera = CInt(WordswaittoStart)
            Fn.Wait(espera)
            'pongo la primera palabra

            If Mode <> 3 Then
                LbWord.Text = UCase(vars.arr(0).ToString)
            Else
                '////////////////
                'LbWord.Font = New Font("Impact", 100)
                'LbWord.Top = (LbWord.Parent.Height \ 2) - (LbWord.Height \ 2) + 245

                Dim CountWords As Integer = 0
                Dim cadena As String = ""
                Dim salir As Integer = 0

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

                '////////////////
            End If


            'ahora inicio el temporizador para las palabras
            CountWords = CountWords + 1

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
            ProgressBar1.Maximum = CInt(TimerWord.Interval / 10) - 10
            ProgressBar1.Minimum = 10
            TimerProgressBar.Enabled = True
            TimerProgressBar.Start()
            TimerWord.Start()

        End If
    End Sub

    Private Sub TimerWord_Tick(sender As Object, e As EventArgs) Handles TimerWord.Tick
        'aqui mostraría la palabra siguiente
        ProcessTick()

    End Sub

    Sub ProcessTick()
        If ControlModule.CbBattleType.SelectedIndex <> 3 Then
            LbWord.Text = UCase(vars.arr(CountWords).ToString)
        Else
            LbWord.Text = UCase(vars.arr4words(CountWords).ToString)
        End If
        CountWords = CountWords + 1
    End Sub

    Private Sub TimerProgressBar_Tick(sender As Object, e As EventArgs) Handles TimerProgressBar.Tick
        ProgressBar1.Value = ProgressBar1.Value + 10
        If ProgressBar1.Value >= ProgressBar1.Maximum Then
            ProgressBar1.Value = 10
            'TimerProgressBar.Enabled = False
            'ProgressBar1.Refresh()
        End If
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
        vars.StopBattle = True
        MainModule.LbCountDown.Text = "00"
        MainModule.TimerVisualCountDown.Stop()
        MainModule.LbWord.Text = "-"
        MainModule.TimerWord.Stop()
        Fn.Wait(1)
        vars.Player.controls.stop()
        ControlModule.btstartbattle.Enabled = True
        ControlModule.Enabled = True
        ControlModule.btstartbattle.Enabled = True
        ControlModule.btstartwords.Enabled = True
        ControlModule.CbBattleType.Enabled = True
        ControlModule.CbDuration.Enabled = True
        ControlModule.btstopbattle.Enabled = True
        CountWords = 0
    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As System.EventArgs) Handles TimerVisualCountDown.Tick
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim t As String = ""
        Select Case ts.TotalMilliseconds
            Case > 60000
                t = ts.ToString("mm\:ss").Remove(0, 1)
            Case < 60000
                t = ts.ToString("ss")
        End Select

        LbCountDown.Text = t

        'If ProgressBar1.Value = ProgressBar1.Maximum Then ProgressBar1.Value = 1
        'ProgressBar1.Value = ProgressBar1.Value + 1

        If ts.TotalMilliseconds <= 0 Then
            TimerVisualCountDown.Stop()

            StopBattleFunctions()
        End If
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopBattleFunctions()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        SetBattle()
    End Sub
    Public Shared Function ReadWeb(MyUrl As String)
        Dim reply As String
        MyUrl = Replace(MyUrl, "'", "")
        MyUrl = Replace(MyUrl, """", "")
        Dim res As String
        If MyUrl = "" Then Exit Function
        Try
            Dim client As Net.WebClient = New Net.WebClient()
            System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
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
        Dim MyWords As String
        MyWords = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\" & vars.MyWordsFileName)
        Dim w = "https://www.palabrasaleatorias.com/?fs=10&fs2=0&Submit=Nueva+palabra"
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(ReadWeb(Trim(w)))
        Dim div = doc.DocumentNode.SelectNodes("//div[@style='font-size:3em; color:#6200C5;']")
        Dim counter = 0
        For Each word In div
            Dim MyWord = LCase(word.InnerText.ToString)
            If MyWords.Contains(MyWord & "") = False Then
                MyWords = MyWords & MyWord
                Dim FILE_NAME As String = vars.MyWordsFileName
                Dim objWriter As New System.IO.StreamWriter(IO.Directory.GetCurrentDirectory & "\" & vars.MyWordsFileName)
                objWriter.Write(MyWords)
                objWriter.Close()
                Fn.WriteLog(MyWord)
            End If
        Next word

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerGetWords.Tick
        sacapalabra()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i = 0
        While i < 1000000
            sacapalabra()
            Fn.Wait(5)
            i = i + 1
        End While
    End Sub


End Class
