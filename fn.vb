Imports System.IO
'Imports System.Text.RegularExpressions
Imports WMPLib

Public Class Fn
    Public Shared Sub SetMySettings()

        Ms.InitSettings()
        Ms.LoadSettings()

        If Ms.ReadSetting("MainBackGroundImage") <> Nothing Then
            Try
                ControlModule.BackgroundImage = New Bitmap(Ms.ReadSetting("MainBackGroundImage").ToString)
                MainModule.BackgroundImage = ControlModule.BackgroundImage
            Catch
                WriteLog("No se encontró la imagen de fondo " & Ms.ReadSetting("MainBackGroundImage").ToString)
            End Try
        End If

        Try
            If Ms.ReadSetting("lbWordColor") <> Nothing Then
                MainModule.LbWord.ForeColor = Color.FromArgb(Ms.ReadSetting("lbWordColor"))
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("lbWordFont") <> Nothing Then
                MainModule.LbWord.Font = GetFontByString(Ms.ReadSetting("lbWordFont"))
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("lbCountDownColor") <> Nothing Then
                MainModule.LbCountDown.ForeColor = Color.FromArgb(Ms.ReadSetting("lbCountDownColor"))
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try

            If Ms.ReadSetting("lbCountDownFont") <> Nothing Then
                MainModule.LbCountDown.Font = GetFontByString(Ms.ReadSetting("lbCountDownFont"))
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("MusicDirectory") <> Nothing Then
                ControlModule.tbmusicdir.Text = Ms.ReadSetting("MusicDirectory")
            Else
                ControlModule.tbmusicdir.Text = Vars.UserDir
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("lbCountDownPositionX") <> Nothing And Ms.ReadSetting("lbCountDownPositionY") <> Nothing Then
                MainModule.LbCountDown.Location = New Point(CInt(Ms.ReadSetting("lbCountDownPositionX")),
                                                            CInt(Ms.ReadSetting("lbCountDownPositionY")))
            End If
            If Ms.ReadSetting("lbWordPositionX") <> Nothing And Ms.ReadSetting("lbWordPositionY") <> Nothing Then
                MainModule.LbWord.Location = New Point(CInt(Ms.ReadSetting("lbWordPositionX")),
                                                   CInt(Ms.ReadSetting("lbWordPositionY")))
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("MainWidth") <> Nothing Then
                MainModule.Width = Ms.ReadSetting("MainWidth")
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try

            If Ms.ReadSetting("MainHeight") <> Nothing Then
                MainModule.Height = Ms.ReadSetting("MainWidth")
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try

            If Ms.ReadSetting("WindowState") <> Nothing Then
                Dim fws As FormWindowState = [Enum].Parse(GetType(FormWindowState), Ms.ReadSetting("WindowState"))
                'MainModule.WindowState = fws
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("chkSoundFx") <> Nothing Then
                If Ms.ReadSetting("chkSoundFx") = "1" Then
                    ControlModule.chkSoundFx.Checked = True
                Else
                    ControlModule.chkSoundFx.Checked = False
                End If
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("chkMinimize") <> Nothing Then
                If Ms.ReadSetting("chkMinimize") = "1" Then
                    ControlModule.chkMinimize.Checked = True
                Else
                    ControlModule.chkMinimize.Checked = False
                End If
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        Try
            If Ms.ReadSetting("chPlayMusic") <> Nothing Then
                If Ms.ReadSetting("chPlayMusic") = "1" Then
                    ControlModule.chPlayMusic.Checked = True
                Else
                    ControlModule.chPlayMusic.Checked = False
                End If
            End If
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
        InitMusic()
    End Sub

    Public Shared Function ImageToString(img As Image)
        Dim imgConverter As New ImageConverter()
        Dim imgBytes As Byte() = imgConverter.ConvertTo(img, GetType(Byte()))
        Return Convert.ToBase64String(imgBytes)
    End Function

    Public Shared Function FindIt(total As String, first As String, last As String) As String
        Return GetDelimitedText(total, first, last)
        Exit Function
    End Function


    'Public Shared Sub SaveSetting(setting, value)
    '    Try
    '        Dim objWriter As New System.IO.StreamWriter(IO.Directory.GetCurrentDirectory & "\" & vars.MySettingsFileName)
    '        objWriter.Write(vars.MySettingsFileName)
    '        objWriter.Close()
    '    Catch ex As Exception
    '        WriteLog("Archivo de configuración no encontrado")
    '    End Try
    'End Sub

    Public Shared Sub WriteLog(msg)
        Try
            ControlModule.tbUserLog.SelectedText = "- " & msg & vbCrLf
            ControlModule.tbUserLog.SelectionStart = ControlModule.tbUserLog.Text.Length
            ControlModule.tbUserLog.ScrollToCaret()
        Catch
        End Try
    End Sub

    Public Shared Sub Shuffle(items As String())
        Dim j As Int32
        Dim temp As String
        For n As Int32 = items.Length - 1 To 0 Step -1
            j = MainModule.Rnd.Next(0, n + 1)
            temp = items(n)
            items(n) = items(j)
            items(j) = temp
        Next n
    End Sub

    Public Shared Sub Alert(msg)
        MsgBox(msg)
    End Sub

    Public Shared Sub SaveSettings(a As String)
        My.Settings.Save()
        Alert("Configuración guardada.")
    End Sub

    Public Shared Sub InitMusic()
        Try
            Dim dir = Ms.ReadSetting("MusicDirectory")
            If dir = Nothing Then Exit Sub
            Vars.Files =
                Directory.GetFiles(dir, "*.*").Where(
                    Function(file) file.ToLower().EndsWith(".mp3") OrElse file.ToLower().EndsWith(".wav")).ToArray()
        Catch ex As Exception
            Fn.WriteLog(ex.ToString())
        End Try
    End Sub


    Public Shared Sub LoadMusic()
        Try
            'If ControlModule.chPlayMusic.Checked = False Then Exit Sub
            Dim comboSource As New Dictionary(Of String, String)()
            'Dim dir = ms.ReadSetting("MusicDirectory")
            'If dir = Nothing Then Exit Sub
            'vars.files = Directory.GetFiles(dir, "*.*").Where(Function(file) file.ToLower().EndsWith(".mp3") OrElse file.ToLower().EndsWith(".wav")).ToArray()

            If ControlModule.chshufflemusic.Checked Then
                Shuffle(Vars.Files)
            End If
            Dim dir = Ms.ReadSetting("MusicDirectory")
            Dim i = 0
            For Each u In Vars.Files

             
                Dim n = u
                n = Replace(n, ".mp3", "")
                n = Replace(n, ".wav", "")
                n = Replace(n, dir & "\", Nothing)
                If n <> "SoundFx" Then
                    n = n & " (" & TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") & ")"
                    comboSource.Add(u, n)
                       i = i + 1
                Else
                    n = n
                End If
            Next
            ControlModule.cbMusicList.DataSource = New BindingSource(comboSource, Nothing)
            ControlModule.cbMusicList.DisplayMember = "Value"
            ControlModule.cbMusicList.ValueMember = "Key"
            WriteLog(i & " instrumentales cargadas")
            If InStr(ControlModule.chshufflemusic.Text, "(") < 0 Then
                ControlModule.chshufflemusic.Text = ControlModule.chshufflemusic.Text & (" (" & i & " instrumentales)")
            End If
        Catch
            Fn.WriteLog("No se encontraron instrumentales en " & Ms.ReadSetting("MusicDirectory"))
        End Try
    End Sub

    Public Shared Function PlayMusic()
        Try
            If ControlModule.chPlayMusic.Checked = False Then Exit Function

            If ControlModule.chshufflemusic.Checked Then
                LoadMusic()
            End If
            '///// MUSIC //////
            Dim vidhhmmss As String
            Dim u = ControlModule.cbMusicList.SelectedValue
            Vars.Player.URL = u
            Vars.Player.controls.play()
            Dim vidSecs As Integer = Math.Round(GetMediaDuration(u.ToString)) 'Get total seconds
            If ControlModule.CbBattleType.SelectedIndex = 3 Then
                vidhhmmss = TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") ' Format hh:mm:ss
                MainModule.CountDownFrom = TimeSpan.FromSeconds(vidSecs)
            End If
            WriteLog("Reproduciendo " & Replace(u, Directory.GetCurrentDirectory() & "\", ""))
            Return vidSecs
        Catch
            Fn.WriteLog("No se ha encontrado música para reproducir")
        End Try
    End Function

    Public Shared Sub Wait(seconds As Single)
        'If Vars.StopBattle <> True Then
        '    Static start As Single
        '    start = VB.Timer()
        '    Do While VB.Timer() < start + seconds
        '        Application.DoEvents()
        '    Loop
        'Else
        '    Exit Sub
        'End If
        'Do While Vars.StopBattle <> True
        ' Threading.Thread.Sleep(seconds & "000")
        'Loop

        Dim dteFutureDate = Date.Now().AddSeconds(seconds)

        'And wait.
        Do Until Date.Now() > dteFutureDate
            Application.DoEvents()
        Loop

    End Sub

    Public Shared Function GetFontByString(s As String) As Font
        ' A function that returnes a font from the given string
        Dim int1 As Integer
        Dim name As String
        Dim size As String
        Dim style As String
        Dim unit As String
        Dim gdiChar As String
        Dim gdiVerticalFont As String
        Dim gdiVertical As Boolean

        ' Find Font Name
        int1 = InStr(s, "Name=") ' find the location of the text Name= in the string
        If int1 = 0 Then ' Checks if this has failed
            name = "Courier New" ' Puts the default font name into the name string variable
        Else
            name = Mid(s, int1 + 5) ' returns the string with the part before Name= chopped off
            int1 = InStr(name, ",") ' Finds the location of the text , in the string
            name = Left(name, int1 - 1) ' returns the string with the part after the , chopped off
        End If

        ' Find Font Size
        int1 = InStr(s, "Size=") ' find the location of the text Size= in the string
        If int1 = 0 Then ' Checks if this has failed
            size = "8" ' Puts the default font size into the size string variable
        Else
            size = Mid(s, int1 + 5) ' returns the string with the part before Size= chopped off
            int1 = InStr(size, ",") ' Finds the location of the text , in the string
            size = Left(size, int1 - 1) ' returns the string with the part after the , chopped off
        End If

        ' Find Font Units
        int1 = InStr(s, "Units=") ' find the location of the text Units= in the string
        If int1 = 0 Then ' Checks if this has failed
            unit = "3" ' Puts the default font units into the unit string variable
        Else
            unit = Mid(s, int1 + 6) ' returns the string with the part before Units= chopped off
            int1 = InStr(unit, ",") ' Finds the location of the text , in the string
            unit = Left(unit, int1 - 1) ' returns the string with the part after the , chopped off
        End If


        ' Find Font GdiCharSet
        int1 = InStr(s, "GdiCharSet=") ' find the location of the text GdiCharSet= in the string
        If int1 = 0 Then ' Checks if this has failed
            gdiChar = "1" ' Puts the default font GdiCharSet into the GdiChar string variable
        Else
            gdiChar = Mid(s, int1 + 11) ' returns the string with the part before GdiCharSet= chopped off
            int1 = InStr(gdiChar, ",") ' Finds the location of the text , in the string
            gdiChar = Left(gdiChar, int1 - 1) ' returns the string with the part after the , chopped off
        End If


        ' Find Font GdiVerticalFont
        int1 = InStr(s, "GdiVerticalFont=") ' find the location of the text GdiCharSet= in the string
        If int1 = 0 Then ' Checks if this has failed
            gdiVertical = False ' Puts the default font GdiVertical into the GdiVertical boolean variable 
        Else
            gdiVerticalFont = Mid(s, int1 + 16) ' returns the string with the part before GdiVerticalFont= chopped off
            int1 = InStr(gdiVerticalFont, "]") ' Finds the location of the text ] in the string
            gdiVerticalFont = Left(gdiVerticalFont, int1 - 1) ' returns the string with the part after the ] chopped off
            gdiVertical = CBool(gdiVerticalFont) ' converts the returend string variable into a boolean variable
        End If


        ' Find Font Style
        int1 = InStr(s, "FontStyle=") ' returns the string with the part before FontStyle= chopped off
        If int1 = 0 Then ' Checks if this has failed
            style = "1"  ' Puts the default font style into the style string variable
        Else
            style = Mid(s, int1 + 10) ' returns the string with the part before FontStyle= chopped off
        End If

        Select Case CInt(style) ' Uses a case select to find the style from the numerical representation of it
            ' then sets the function to return a new font dependant of the name size and style variables
            Case 0
                Return New Font(name, CInt(size), FontStyle.Regular, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 1
                Return New Font(name, CInt(size), FontStyle.Bold, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 2
                Return New Font(name, CInt(size), FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 3
                Return _
                    New Font(name, CInt(size), FontStyle.Bold Or FontStyle.Italic, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 4
                Return New Font(name, CInt(size), FontStyle.Underline, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 5
                Return _
                    New Font(name, CInt(size), FontStyle.Underline Or FontStyle.Bold, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 6
                Return _
                    New Font(name, CInt(size), FontStyle.Underline Or FontStyle.Italic, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 7
                Return _
                    New Font(name, CInt(size), FontStyle.Underline Or FontStyle.Bold Or FontStyle.Italic, CInt(unit),
                             CInt(gdiChar), gdiVertical)
            Case 8
                Return New Font(name, CInt(size), FontStyle.Strikeout, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 9
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Bold, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 10
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Italic, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 11
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Bold Or FontStyle.Italic, CInt(unit),
                             CInt(gdiChar), gdiVertical)
            Case 12
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline, CInt(unit), CInt(gdiChar),
                             gdiVertical)
            Case 13
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Bold, CInt(unit),
                             CInt(gdiChar), gdiVertical)
            Case 14
                Return _
                    New Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Italic,
                             CInt(unit), CInt(gdiChar), gdiVertical)
            Case 15
                Return _
                    New Font(name, CInt(size),
                             FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Bold Or FontStyle.Italic,
                             CInt(unit), CInt(gdiChar), gdiVertical)
            Case Else
                Return New Font(name, CInt(size), FontStyle.Regular, CInt(unit), CInt(gdiChar), gdiVertical)
        End Select
    End Function

    Public Shared Function GetMediaDuration(mediafile As String)
        Try
            Dim w As New WindowsMediaPlayer
            Dim m As IWMPMedia = w.newMedia(mediafile)
            w.close()
            Return m.duration
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetDelimitedText(text As String, openDelimiter As String, closeDelimiter As String,
                                            Optional index As Long = 0) As String
        Dim i As Long, j As Long

        If index = 0 Then index = 1

        ' search the opening mark
        i = InStr(index, text, openDelimiter, vbTextCompare)
        If i = 0 Then
            index = 0
            Exit Function
        End If
        i = i + Len(openDelimiter)

        ' search the closing mark
        j = InStr(i + 1, text, closeDelimiter, vbTextCompare)
        If j = 0 Then
            index = 0
            Exit Function
        End If

        ' get the text between the two Delimiters
        GetDelimitedText = Mid$(text, i, j - i)

        ' advanced the index after the closing Delimiter
        index = j + Len(closeDelimiter)
    End Function
End Class
