Imports System.Diagnostics.Contracts
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports WMPLib


Public Class Main
    Private rnd As New Random()
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitProgram()
    End Sub
    Sub InitProgram()
        CbBattleType.SelectedIndex = 1
        CbDuration.SelectedIndex = 0
        LbWord.Text = ""
        LblCountDown.Text = ""
        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = FormBorderStyle.None
        CenterItems()
        LbWord.Left = (LbWord.Parent.Width \ 2) - (LbWord.Width \ 2)
        LbWord.Top = (LbWord.Parent.Height \ 2) - (LbWord.Height \ 2) + 250
        LblCountDown.Left = (LblCountDown.Parent.Width \ 2) - (LblCountDown.Width \ 2)
        LblCountDown.Top = (LblCountDown.Parent.Height \ 2) - (LblCountDown.Height \ 2) - 200
    End Sub
    Public Sub CenterItems()
        Try
            LbWord.Left = (LbWord.Parent.Width \ 2) - (LbWord.Width \ 2)
            LblCountDown.Left = (LblCountDown.Parent.Width \ 2) - (LblCountDown.Width \ 2)
        Catch
        End Try
    End Sub

    Public Sub Shuffle(items As String())
        Dim j As Int32
        Dim temp As String
        For n As Int32 = items.Length - 1 To 0 Step -1
            j = rnd.Next(0, n + 1)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtStart.Click
        Shuffle(vars.files)
        Shuffle(vars.arr)
        CenterItems()
        Dim Mode As String = CbBattleType.SelectedIndex
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
                CbBattleType.SelectedIndex = Mode
        End Select

        Select Case CbDuration.SelectedIndex
            Case 0 '1
                CountDownFrom = TimeSpan.FromSeconds(60)
            Case 1 '1_20
                CountDownFrom = TimeSpan.FromSeconds(80)
            Case 2
                CountDownFrom = TimeSpan.FromSeconds(120)
            Case Else
                CountDownFrom = TimeSpan.FromSeconds(240)
        End Select

        PlayBattle(Mode, TbWordsWaittoStart.Text, Nothing)
    End Sub

    Function PlayBattle(Mode, WordsWaittoStart, Song)
        CenterItems()
        For Each u In vars.files
            vars.Player.URL = u
            vars.Player.controls.play()
        Next

        Dim settimer As Boolean = False

        TargetDT = DateTime.Now.Add(CountDownFrom)
        TimerCountDown.Interval = CInt(Mode)
        TimerCountDown.Start()
        Dim a = CInt(CountDownFrom.TotalSeconds + WordsWaittoStart)
        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Dim b = CInt(ts.TotalSeconds)

        Dim arr = vars.arr
        If Mode <> 3 Then ' si no es el modo de sacar varias, y solo saca una....

            For Each w In arr

                ts = TargetDT.Subtract(DateTime.Now)
                b = CInt(ts.TotalSeconds)
                LbWord.Text = UCase(w)
                wait(CInt(Mode))


                If settimer = False Then
                    ProgressBar1.Minimum = 0
                    ProgressBar1.Maximum = CInt(Mode)
                    settimer = True
                    CenterItems()
                End If

                If vars.StopBattle Then
                    vars.StopBattle = False
                    Exit Function
                End If
            Next
        Else

            LbWord.Font = New Font("Impact", 100)


            Dim CountWords As Integer = 0
            Dim cadena As String = ""
            Dim salir As Integer = 0

            For Each w In arr
                CountWords = CountWords + 1

                Select Case CountWords
                    Case 1
                        cadena = cadena & w
                    Case 2
                        cadena = cadena & "/" & w & vbNewLine
                    Case 3
                        cadena = cadena & w
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

                LbWord.Text = UCase(w)
                wait(10)
                If settimer = False Then

                    ProgressBar1.Minimum = 0
                    ProgressBar1.Maximum = CInt(Mode)
                    settimer = True
                    'End If
                    CenterItems()
                End If

                If vars.StopBattle Then
                    vars.StopBattle = False
                    Exit Function
                End If
            Next



            '//////////////////







        End If
    End Function

    Public Sub wait(ByVal seconds As Single)
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles BtStop.Click
        StopBattleFunctions()
    End Sub

    Private Shared Sub StopBattleFunctions()
        vars.StopBattle = True
        Main.LblCountDown.Text = ""
        Main.TimerCountDown.Stop()
        Main.LbWord.Text = ""
        Main.TimerWord.Stop()
        Main.wait(5)
        vars.Player.controls.stop()
        Main.CenterItems()
    End Sub



    Private Sub tmrCountdown_Tick(sender As Object, e As System.EventArgs) Handles TimerCountDown.Tick


        Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
        Select Case ts.TotalMilliseconds
            Case > 60000
                LblCountDown.Text = ts.ToString("mm\:ss")
                'LblCountDown.Scale()
            Case < 60000
                LblCountDown.Text = ts.ToString("ss")
        End Select
        CenterItems()
        If ProgressBar1.Value = ProgressBar1.Maximum Then ProgressBar1.Value = 0
        ProgressBar1.Value = ProgressBar1.Value + 1

        If ts.TotalMilliseconds <= 0 Then
            TimerCountDown.Stop()
            vars.StopBattle = True
            StopBattleFunctions()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub CbDuration_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbDuration.SelectedIndexChanged
        Select Case CbDuration.SelectedIndex
            Case 0 '1
                CountDownFrom = TimeSpan.FromSeconds(60)
            Case 1 '1_20
                CountDownFrom = TimeSpan.FromSeconds(80)
            Case 2
                CountDownFrom = TimeSpan.FromSeconds(120)
            Case Else
                CountDownFrom = TimeSpan.FromSeconds(240)
        End Select
    End Sub

    Private Sub BtClose_Click(sender As Object, e As EventArgs) Handles BtClose.Click
        Application.Exit()

    End Sub
End Class
