Imports VB = Microsoft.VisualBasic

Public Class MainModule
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76
    Public Shared rnd As New Random()
    Public Shared Startwords As Boolean = True
    Public Shared InitAll As Boolean = True
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'Me.FormBorderStyle = FormBorderStyle.None
    End Sub
    Sub InitProgram()
        ControlModule.CbBattleType.SelectedIndex = 1
        ControlModule.CbDuration.SelectedIndex = 0
        CenterItems()
        'LbWord.Left = (LbWord.Parent.Width \ 2) - (LbWord.Width \ 2)
        'LbWord.Top = (LbWord.Parent.Height \ 2) - (LbWord.Height \ 2) + 250
        'LblCountDown.Left = (LblCountDown.Parent.Width \ 2) - (LblCountDown.Width \ 2)
        ''LblCountDown.Top = (LblCountDown.Parent.Height \ 2) - (LblCountDown.Height \ 2) - 200
    End Sub
    Public Shared Sub CenterItems()
        'Try
        '    'MainModule.LbWord.Visible = False
        '    'MainModule.LbWord.Left = (MainModule.LbWord.Parent.Width \ 2) - (MainModule.LbWord.Width \ 2)
        '    MainModule.LblCountDown.Left = (MainModule.LblCountDown.Parent.Width \ 2) - (MainModule.LblCountDown.Width \ 2)
        '    'MainModule.LbWord.Visible = True
        '    MainModule.LbWord.Top = (MainModule.LbWord.Parent.Height \ 2) - (MainModule.LbWord.Height \ 2) + 250
        'Catch
        'End Try
    End Sub

    Public Shared Sub Shuffle(items As String())
        Dim j As Int32
        Dim temp As String
        For n As Int32 = items.Length - 1 To 0 Step -1
            j = MainModule.rnd.Next(0, n + 1)
            temp = items(n)
            items(n) = items(j)
            items(j) = temp
        Next n
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TimerGetWords.Start()
    End Sub

    Sub sacapalabra()
        Dim MyWords As String
        MyWords = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\MyWords.txt")
        Dim w = "https://www.palabrasaleatorias.com/?fs=10&fs2=0&Submit=Nueva+palabra"
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument()
        doc.LoadHtml(ReadWeb(Trim(w)))
        Dim div = doc.DocumentNode.SelectNodes("//div[@style='font-size:3em; color:#6200C5;']")
        Dim counter = 0
        For Each word In div
            Dim MyWord = LCase(word.InnerText.ToString)
            If MyWords.Contains(MyWord & "") = False Then
                MyWords = MyWords & MyWord
                Dim FILE_NAME As String = "MyWords.txt"
                Dim objWriter As New System.IO.StreamWriter(IO.Directory.GetCurrentDirectory & "\MyWords.txt")
                objWriter.Write(MyWords)
                objWriter.Close()
            End If
        Next word

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerGetWords.Tick
        sacapalabra()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TimerGetWords.Stop()
    End Sub

    Sub SetBattle()
        Shuffle(vars.files)
        Shuffle(vars.arr)
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
    Sub PlayMusic()
        '///// MUSIC //////
        Dim Vidhhmmss As String
        For Each u In vars.files
            vars.Player.URL = u
            vars.Player.controls.play()
            Dim VidSecs As Integer = Math.Round(GetMediaDuration(u.ToString)) 'Get total seconds
            If ControlModule.CbBattleType.SelectedIndex = 3 Then
                Vidhhmmss = TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") ' Format hh:mm:ss
                CountDownFrom = TimeSpan.FromSeconds(VidSecs)
            End If
            Exit For
        Next
    End Sub
    Function PlayBattle(Mode, WordsWaittoStart, Song, duration)
        LbWord.Text = ""

        If vars.StopBattle = True Then
            Exit Function
        End If

        PlayMusic()

        Dim settimer As Boolean = False

        TargetDT = DateTime.Now.Add(CountDownFrom)
        TimerCountDown.Interval = CInt(Mode + 1)
        TimerCountDown.Start()
        Dim a = CInt(CountDownFrom.TotalSeconds + WordsWaittoStart)
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim b = CInt(ts.TotalSeconds)

        Dim arr = vars.arr
        Dim espera = CInt(WordsWaittoStart)
        LblCountDown.Text = b

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
                    LblCountDown.Font = New Font("Impact", 180)
                Else
                    LblCountDown.Font = New Font("Impact", 240.25)
                End If

                If Startwords = True Then
                    'problema cuando es más de 60 minutos
                    'Dim tas As TimeSpan = TimeSpan.Parse("00:" & LblCountDown.Text.ToString, Globalization.CultureInfo.InvariantCulture)
                    'Dim x = tas.TotalSeconds

                    Dim totalsectranscurridos = TimeSpan.FromSeconds((LblCountDown.Text)).TotalSeconds
                    While CInt(totalsectranscurridos + espera) >= b
                        totalsectranscurridos = TimeSpan.FromSeconds(LblCountDown.Text).TotalSeconds
                        wait(0.1)
                    End While
                Else
                    While Startwords = False
                        wait(0.01)
                    End While
                End If

                LbWord.Text = UCase(w)
                wait(CInt(Mode) - 0.15)

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
                ' ///////////
                If Startwords = True Then
                    'problema cuando es más de 60 minutos
                    'Dim tas As TimeSpan = TimeSpan.Parse("00:" & LblCountDown.Text.ToString, Globalization.CultureInfo.InvariantCulture)
                    'Dim x = tas.TotalSeconds

                    Dim totalsectranscurridos = TimeSpan.FromSeconds((LblCountDown.Text)).TotalSeconds
                    While CInt(totalsectranscurridos + espera) >= b
                        totalsectranscurridos = TimeSpan.FromSeconds(LblCountDown.Text).TotalSeconds
                        wait(0.1)
                    End While
                Else
                    While Startwords = False
                        wait(0.01)
                    End While
                End If
                ' ////////////
                LbWord.Text = UCase(w)
                    CenterItems()


                wait(10 - 0.15)
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

    Public Shared Function GetMediaDuration(ByVal MediaFile As String)
        Try
            Dim w As New WMPLib.WindowsMediaPlayer
            Dim m As WMPLib.IWMPMedia = w.newMedia(MediaFile)
            w.close()
            Return m.duration
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Sub wait(ByVal seconds As Single)
        If vars.StopBattle <> True Then
            Static start As Single
            start = VB.Timer()
            Do While VB.Timer() < start + seconds
                System.Windows.Forms.Application.DoEvents()
            Loop
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        StopBattleFunctions()
    End Sub

    Public Shared Sub StopBattleFunctions()
        vars.StopBattle = True
        MainModule.LblCountDown.Text = "00"
        MainModule.TimerCountDown.Stop()
        MainModule.LbWord.Text = "-"
        MainModule.TimerWord.Stop()
        wait(1)
        vars.Player.controls.stop()
        ControlModule.btstartbattle.Enabled = True
        ControlModule.Enabled = True
        ControlModule.btstartbattle.Enabled = True
        ControlModule.btstartwords.Enabled = True
        ControlModule.CbBattleType.Enabled = True
        ControlModule.CbDuration.Enabled = True
    End Sub

    Private Sub tmrCountdown_Tick(sender As Object, e As System.EventArgs) Handles TimerCountDown.Tick

        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim t As String = ""
        Select Case ts.TotalMilliseconds
            Case > 60000
                t = ts.ToString("mm\:ss").Remove(0, 1)
            Case < 60000
                t = ts.ToString("ss")
        End Select

        LblCountDown.Text = t

        If ProgressBar1.Value = ProgressBar1.Maximum Then ProgressBar1.Value = 0
        ProgressBar1.Value = ProgressBar1.Value + 1

        If ts.TotalMilliseconds <= 0 Then
            TimerCountDown.Stop()

            StopBattleFunctions()
        End If
    End Sub


    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StopBattleFunctions()
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs)
        SetBattle()
    End Sub


End Class
