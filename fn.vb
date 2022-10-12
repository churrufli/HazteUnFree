Imports VB = Microsoft.VisualBasic
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Fn
    Public Shared Sub SetMySettings()

        ms.InitSettings()
        ms.LoadSettings()

        If ms.ReadSetting("MainBackGroundImage") <> Nothing Then
            ControlModule.BackgroundImage = New System.Drawing.Bitmap(ms.ReadSetting("MainBackGroundImage").ToString)
            MainModule.BackgroundImage = ControlModule.BackgroundImage
        End If

        If ms.ReadSetting("lbWordColor") <> Nothing Then
            MainModule.LbWord.ForeColor = Color.FromArgb(ms.ReadSetting("lbWordColor"))
        End If

        If ms.ReadSetting("lbWordFont") <> Nothing Then
            MainModule.LbWord.Font = Fn.GetFontByString(ms.ReadSetting("lbWordFont"))
        End If

        If ms.ReadSetting("lbCountDownColor") <> Nothing Then
            MainModule.LbCountDown.ForeColor = Color.FromArgb(ms.ReadSetting("lbCountDownColor"))
        End If

        If ms.ReadSetting("lbCountDownFont") <> Nothing Then
            MainModule.LbCountDown.Font = Fn.GetFontByString(ms.ReadSetting("lbCountDownFont"))
        End If

        If ms.ReadSetting("MusicDirectory") <> Nothing Then
            ControlModule.tbmusicdir.Text = ms.ReadSetting("MusicDirectory")
        Else
            ControlModule.tbmusicdir.Text = vars.UserDir
        End If

        InitMusic()

    End Sub




    Public Shared Function ColourFromData(s As String) As Color
        Dim fallbackColour = Color.Black

        If Not s.StartsWith("color", StringComparison.OrdinalIgnoreCase) Then
            Return fallbackColour
        End If

        ' Extract whatever is between the brackets.
        Dim re = New Regex("\[(.+?)]")
        Dim colorNameMatch = re.Match(s)
        If Not colorNameMatch.Success Then
            Return fallbackColour
        End If

        Dim colourName = colorNameMatch.Groups(1).Value

        ' Get the names of the known colours.
        'TODO: If this function is called frequently, consider creating allColours as a variable with a larger scope.
        Dim allColours = [Enum].GetNames(GetType(System.Drawing.KnownColor))

        ' Attempt a case-insensitive match to the known colours.
        Dim nameOfColour = allColours.FirstOrDefault(Function(c) String.Compare(c, colourName, StringComparison.OrdinalIgnoreCase) = 0)

        If Not String.IsNullOrEmpty(nameOfColour) Then
            Return Color.FromName(nameOfColour)
        End If

        ' Was not a named colour. Parse for ARGB values.
        re = New Regex("A=(\d+).*?R=(\d+).*?G=(\d+).*?B=(\d+)", RegexOptions.IgnoreCase)
        Dim componentMatches = re.Match(colourName)

        If componentMatches.Success Then

            Dim a = Integer.Parse(componentMatches.Groups(1).Value)
            Dim r = Integer.Parse(componentMatches.Groups(2).Value)
            Dim g = Integer.Parse(componentMatches.Groups(3).Value)
            Dim b = Integer.Parse(componentMatches.Groups(4).Value)

            Dim maxValue = 255

            If a > maxValue OrElse r > maxValue OrElse g > maxValue OrElse b > maxValue Then
                Return fallbackColour
            End If

            Return System.Drawing.Color.FromArgb(a, r, g, b)

        End If

        Return fallbackColour

    End Function
    Public Shared Function ImageToString(ByVal Img As Image)
        Dim imgConverter As New ImageConverter()
        Dim imgBytes As Byte() = imgConverter.ConvertTo(Img, GetType(Byte()))
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
        ControlModule.tbUserLog.SelectedText = "- " & msg & vbCrLf
        ControlModule.tbUserLog.SelectionStart = ControlModule.tbUserLog.Text.Length
        ControlModule.tbUserLog.ScrollToCaret()
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

    Public Shared Sub Alert(msg)
        MsgBox(msg)
    End Sub

    Public Shared Sub SaveSettings(a As String)
        My.Settings.Save()
        Alert("Configuración guardada.")
    End Sub
    Public Shared Sub InitMusic()
        Dim dir = ms.ReadSetting("MusicDirectory")
        If dir = Nothing Then Exit Sub
        vars.files = Directory.GetFiles(dir, "*.*").Where(Function(file) file.ToLower().EndsWith(".mp3") OrElse file.ToLower().EndsWith(".wav")).ToArray()
    End Sub


    Public Shared Sub LoadMusic()
        If ControlModule.chPlayMusic.Checked Then Exit Sub
        Dim comboSource As New Dictionary(Of String, String)()
        'Dim dir = ms.ReadSetting("MusicDirectory")
        'If dir = Nothing Then Exit Sub
        'vars.files = Directory.GetFiles(dir, "*.*").Where(Function(file) file.ToLower().EndsWith(".mp3") OrElse file.ToLower().EndsWith(".wav")).ToArray()

        If ControlModule.chshufflemusic.Checked Then
            Fn.Shuffle(vars.files)
        End If
        Dim dir = ms.ReadSetting("MusicDirectory")
        For Each u In vars.files
            Dim n = u & " (" & TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") & ")"
            n = Replace(n, ".mp3", "")
            n = Replace(n, ".wav", "")
            n = Replace(n, dir & "\", Nothing)
            comboSource.Add(u, n)
        Next
        ControlModule.cbMusicList.DataSource = New BindingSource(comboSource, Nothing)
        ControlModule.cbMusicList.DisplayMember = "Value"
        ControlModule.cbMusicList.ValueMember = "Key"

    End Sub
    Public Shared Sub PlayMusic()
        If ControlModule.chPlayMusic.Checked Then Exit Sub

        If ControlModule.chshufflemusic.Checked Then
            LoadMusic()
        End If
        '///// MUSIC //////
        Dim Vidhhmmss As String
        Dim u = ControlModule.cbMusicList.SelectedValue
        vars.Player.URL = u
        vars.Player.controls.play()
        Dim VidSecs As Integer = Math.Round(GetMediaDuration(u.ToString)) 'Get total seconds
        If ControlModule.CbBattleType.SelectedIndex = 3 Then
            Vidhhmmss = TimeSpan.FromSeconds(Math.Round(GetMediaDuration(u))).ToString("mm\:ss") ' Format hh:mm:ss
            MainModule.CountDownFrom = TimeSpan.FromSeconds(VidSecs)
        End If
        Fn.WriteLog("Reproduciendo " & Replace(u, IO.Directory.GetCurrentDirectory() & "\", ""))

    End Sub

    Public Shared Sub Wait(ByVal seconds As Single)
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

    'Public Shared Function GetFontByString(ByVal sFont As String) As Font


    '    Dim myFontConv As New FontConverter
    '    Dim myNewFont As Font

    '    myNewFont = CType(myFontConv.ConvertFromString(sFont), Font)
    '    Return myNewFont

    '    sFont = sFont.Substring(1, sFont.Length - 2)
    '    sFont = Replace(sFont, ",", vbNullString)
    '    sFont = Replace(sFont, "Font:", vbNullString)
    '    Dim sElement() As String = Split(sFont, " ")
    '    Dim sSingle() As String
    '    Dim sValue As String
    '    Dim FontName As String
    '    Dim FontSize As Single
    '    Dim FontStyle As FontStyle = Drawing.FontStyle.Regular
    '    Dim FontUnit As GraphicsUnit = GraphicsUnit.Point
    '    Dim gdiCharSet As Byte
    '    Dim gdiVerticalFont As Boolean

    '    For Each sValue In sElement
    '        sValue = Trim(sValue)
    '        sSingle = Split(sValue, "=")
    '        If sSingle.GetUpperBound(0) > 0 Then
    '            If sSingle(0) = "Name" Then
    '                FontName = sSingle(1)
    '            ElseIf sSingle(0) = "Size" Then
    '                FontSize = CSng(sSingle(1))
    '            ElseIf sSingle(0) = "Units" Then
    '                FontUnit = CInt(sSingle(1))
    '            ElseIf sSingle(0) = "GdiCharSet" Then
    '                FontName = CByte(sSingle(1))
    '            ElseIf sSingle(0) = "GdiVerticalFont" Then
    '                FontName = CBool(sSingle(1))
    '            End If
    '        End If
    '    Next
    '    Return New Font(FontName, FontSize, FontStyle, FontUnit, gdiCharSet, gdiVerticalFont)
    'End Function


    Public Shared Function GetFontByString(ByVal s As String) As Font
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
            name = Microsoft.VisualBasic.Mid(s, int1 + 5) ' returns the string with the part before Name= chopped off
            int1 = InStr(name, ",") ' Finds the location of the text , in the string
            name = Microsoft.VisualBasic.Left(name, int1 - 1) ' returns the string with the part after the , chopped off
        End If


        ' Find Font Size
        int1 = InStr(s, "Size=") ' find the location of the text Size= in the string
        If int1 = 0 Then ' Checks if this has failed
            size = "8" ' Puts the default font size into the size string variable
        Else
            size = Microsoft.VisualBasic.Mid(s, int1 + 5) ' returns the string with the part before Size= chopped off
            int1 = InStr(size, ",") ' Finds the location of the text , in the string
            size = Microsoft.VisualBasic.Left(size, int1 - 1) ' returns the string with the part after the , chopped off
        End If

        ' Find Font Units
        int1 = InStr(s, "Units=") ' find the location of the text Units= in the string
        If int1 = 0 Then ' Checks if this has failed
            unit = "3" ' Puts the default font units into the unit string variable
        Else
            unit = Microsoft.VisualBasic.Mid(s, int1 + 6) ' returns the string with the part before Units= chopped off
            int1 = InStr(unit, ",") ' Finds the location of the text , in the string
            unit = Microsoft.VisualBasic.Left(unit, int1 - 1) ' returns the string with the part after the , chopped off
        End If


        ' Find Font GdiCharSet
        int1 = InStr(s, "GdiCharSet=") ' find the location of the text GdiCharSet= in the string
        If int1 = 0 Then ' Checks if this has failed
            gdiChar = "1" ' Puts the default font GdiCharSet into the GdiChar string variable
        Else
            gdiChar = Microsoft.VisualBasic.Mid(s, int1 + 11) ' returns the string with the part before GdiCharSet= chopped off
            int1 = InStr(gdiChar, ",") ' Finds the location of the text , in the string
            gdiChar = Microsoft.VisualBasic.Left(gdiChar, int1 - 1) ' returns the string with the part after the , chopped off
        End If


        ' Find Font GdiVerticalFont
        int1 = InStr(s, "GdiVerticalFont=") ' find the location of the text GdiCharSet= in the string
        If int1 = 0 Then ' Checks if this has failed
            gdiVertical = False ' Puts the default font GdiVertical into the GdiVertical boolean variable 
        Else
            gdiVerticalFont = Microsoft.VisualBasic.Mid(s, int1 + 16) ' returns the string with the part before GdiVerticalFont= chopped off
            int1 = InStr(gdiVerticalFont, "]") ' Finds the location of the text ] in the string
            gdiVerticalFont = Microsoft.VisualBasic.Left(gdiVerticalFont, int1 - 1) ' returns the string with the part after the ] chopped off
            gdiVertical = CBool(gdiVerticalFont) ' converts the returend string variable into a boolean variable
        End If


        ' Find Font Style
        int1 = InStr(s, "FontStyle=") ' returns the string with the part before FontStyle= chopped off
        If int1 = 0 Then ' Checks if this has failed
            style = "1"  ' Puts the default font style into the style string variable
        Else
            style = Microsoft.VisualBasic.Mid(s, int1 + 10) ' returns the string with the part before FontStyle= chopped off
        End If

        Select Case CInt(style) ' Uses a case select to find the style from the numerical representation of it
            ' then sets the function to return a new font dependant of the name size and style variables
            Case 0
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Regular, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 1
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Bold, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 2
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 3
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Bold Or Drawing.FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 4
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Underline, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 5
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Underline Or FontStyle.Bold, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 6
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Underline Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 7
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Underline Or FontStyle.Bold Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 8
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 9
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Bold, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 10
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 11
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Bold Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 12
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 13
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Bold, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 14
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case 15
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Strikeout Or FontStyle.Underline Or FontStyle.Bold Or FontStyle.Italic, CInt(unit), CInt(gdiChar), gdiVertical)
            Case Else
                Return New System.Drawing.Font(name, CInt(size), FontStyle.Regular, CInt(unit), CInt(gdiChar), gdiVertical)
        End Select

    End Function

    Public Shared Function GetMediaDuration(ByVal mediafile As String)
        Try
            Dim w As New WMPLib.WindowsMediaPlayer
            Dim m As WMPLib.IWMPMedia = w.newMedia(mediafile)
            w.close()
            Return m.duration
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetDelimitedText(Text As String, OpenDelimiter As String, CloseDelimiter As String, Optional index As Long = 0) As String
        Dim i As Long, j As Long

        If index = 0 Then index = 1

        ' search the opening mark
        i = InStr(index, Text, OpenDelimiter, vbTextCompare)
        If i = 0 Then
            index = 0
            Exit Function
        End If
        i = i + Len(OpenDelimiter)

        ' search the closing mark
        j = InStr(i + 1, Text, CloseDelimiter, vbTextCompare)
        If j = 0 Then
            index = 0
            Exit Function
        End If

        ' get the text between the two Delimiters
        GetDelimitedText = Mid$(Text, i, j - i)

        ' advanced the index after the closing Delimiter
        index = j + Len(CloseDelimiter)

    End Function
End Class
