Imports System.IO
Imports WMPLib

Public Class Fn

    Public Shared Sub SetMySettings()
        ' Inicializar y cargar la configuración
        Ms.InitSettings()
        Ms.LoadSettings()

        ' Establecer la imagen de fondo si está definida
        Dim backgroundImagePath As String = Ms.ReadSetting("MainBackGroundImage")
        If Not String.IsNullOrEmpty(backgroundImagePath) AndAlso IO.File.Exists(backgroundImagePath) Then
            Try
                ControlModule.BackgroundImage = New Bitmap(backgroundImagePath)
                MainModule.BackgroundImage = ControlModule.BackgroundImage
            Catch ex As Exception
                WriteLog("No se pudo cargar la imagen de fondo: " & ex.Message)
            End Try
        End If

        ' Configurar el color y fuente del control LbWord
        Try
            SetControlColor(MainModule.LbWord, "lbWordColor")
            SetControlFont(MainModule.LbWord, "lbWordFont")
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Configurar el color y fuente del control LbCountDown
        Try
            SetControlColor(MainModule.LbCountDown, "lbCountDownColor")
            SetControlFont(MainModule.LbCountDown, "lbCountDownFont")
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Configurar la ubicación de controles
        Try
            SetControlLocation(MainModule.LbCountDown, "lbCountDownPositionX", "lbCountDownPositionY")
            SetControlLocation(MainModule.LbWord, "lbWordPositionX", "lbWordPositionY")
            SetControlLocation(MainModule.lbTipoBatalla, "LbTipoBatallaPositionX", "LbTipoBatallaPositionY")
            SetControlLocation(MainModule.lbCaractBatalla, "LbCaractBatallaPositionX", "LbCaractBatallaPositionY")
            SetControlLocation(MainModule.CustomProgressBar1, "ProgressBar1PositionX", "ProgressBar1PositionY")
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Configurar el tamaño del formulario principal si está definido
        Try
            SetControlSize(MainModule, "MainWidth", "MainHeight")
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Configurar el estado de la ventana (maximizado o normal)
        Try
            SetWindowState()
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Configurar las casillas de verificación
        Try
            SetCheckboxState(ControlModule.chkSoundFx, "chkSoundFx")
            SetCheckboxState(ControlModule.chkMinimize, "chkMinimize")
            SetCheckboxState(ControlModule.chPlayMusic, "chPlayMusic")
        Catch ex As Exception
            WriteLog(ex.ToString())
        End Try

        ' Inicializar la música
        InitMusic()
    End Sub

    Private Shared Sub SetControlColor(control As Control, settingName As String)
        Dim colorValue As String = Ms.ReadSetting(settingName)
        If Not String.IsNullOrEmpty(colorValue) Then
            control.ForeColor = Color.FromArgb(Integer.Parse(colorValue))
        End If
    End Sub

    Private Shared Sub SetControlFont(control As Control, settingName As String)
        Dim fontValue As String = Ms.ReadSetting(settingName)
        If Not String.IsNullOrEmpty(fontValue) Then
            control.Font = GetFontByString(fontValue)
        End If
    End Sub

    Private Shared Sub SetControlLocation(control As Control, posXSetting As String, posYSetting As String)
        Dim posXValue As String = Ms.ReadSetting(posXSetting)
        Dim posYValue As String = Ms.ReadSetting(posYSetting)

        If Not String.IsNullOrEmpty(posXValue) AndAlso Not String.IsNullOrEmpty(posYValue) Then
            Dim x As Integer
            Dim y As Integer

            If Integer.TryParse(posXValue, x) AndAlso Integer.TryParse(posYValue, y) Then
                control.Location = New Point(x, y)
            End If
        End If
    End Sub

    Private Shared Sub SetControlSize(control As Control, widthSetting As String, heightSetting As String)
        Dim widthValue As String = Ms.ReadSetting(widthSetting)
        Dim heightValue As String = Ms.ReadSetting(heightSetting)

        If Not String.IsNullOrEmpty(widthValue) AndAlso Not String.IsNullOrEmpty(heightValue) Then
            Dim width As Integer
            Dim height As Integer

            If Integer.TryParse(widthValue, width) AndAlso Integer.TryParse(heightValue, height) Then
                control.Width = width
                control.Height = height
            End If
        End If
    End Sub

    Private Shared Sub SetWindowState()
        Dim windowStateValue As String = Ms.ReadSetting("WindowState")
        If Not String.IsNullOrEmpty(windowStateValue) Then
            Dim formWindowState As FormWindowState
            If [Enum].TryParse(windowStateValue, formWindowState) Then
                MainModule.WindowState = formWindowState
            End If
        End If
    End Sub

    Private Shared Sub SetCheckboxState(checkbox As CheckBox, settingName As String)
        Dim checkboxValue As String = Ms.ReadSetting(settingName)
        If Not String.IsNullOrEmpty(checkboxValue) Then
            checkbox.Checked = (checkboxValue = "1")
        End If
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
        If items Is Nothing = False Then
            Dim j As Int32
            Dim temp As String
            For n As Int32 = items.Length - 1 To 0 Step -1
                j = MainModule.Rnd.Next(0, n + 1)
                temp = items(n)
                items(n) = items(j)
                items(j) = temp
            Next n
        End If

    End Sub

    Public Shared Sub Alert(msg)
        MsgBox(msg)
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
            Dim musicFiles As New Dictionary(Of String, String)()
            Dim musicDirectory = Ms.ReadSetting("MusicDirectory")

            ' Verificar si el directorio de música existe
            If Directory.Exists(musicDirectory) Then
                Dim shuffled As Boolean = False

                If ControlModule.chshufflemusic.Checked Then
                    Shuffle(Vars.Files)
                    shuffled = True
                End If

                For Each musicFile In Vars.Files
                    Dim fileName = Path.GetFileNameWithoutExtension(musicFile)

                    If fileName <> "SoundFx" Then
                        Dim duration As TimeSpan = TimeSpan.FromSeconds(Math.Round(GetMediaDuration(musicFile)))
                        Dim formattedDuration As String = duration.ToString("mm\:ss")
                        Dim displayName As String = $"{fileName} ({formattedDuration})"

                        musicFiles.Add(musicFile, displayName)
                    End If
                Next

                ' Enlazar los archivos de música al ComboBox
                ControlModule.cbMusicList.DataSource = New BindingSource(musicFiles, Nothing)
                ControlModule.cbMusicList.DisplayMember = "Value"
                ControlModule.cbMusicList.ValueMember = "Key"

                Dim instrumentalesCount As Integer = musicFiles.Count
                Dim logMessage As String = $"{instrumentalesCount} instrumentales cargadas"

                If shuffled Then
                    logMessage &= " (orden aleatorio)"
                End If

                WriteLog(logMessage)
            Else
                WriteLog($"Error: El directorio de música '{musicDirectory}' no existe.")
            End If
        Catch ex As Exception
            Fn.WriteLog($"Error al cargar instrumentales: {ex.Message}")
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
                                        Optional startIndex As Long = 1) As String
        ' Asegurarse de que startIndex sea al menos 1
        If startIndex < 1 Then startIndex = 1

        ' Buscar la posición del marcador de apertura
        Dim openingIndex As Long = InStr(startIndex, text, openDelimiter, CompareMethod.Text)
        If openingIndex = 0 Then
            ' No se encontró el marcador de apertura
            Return ""
        End If
        openingIndex += Len(openDelimiter)

        ' Buscar la posición del marcador de cierre
        Dim closingIndex As Long = InStr(openingIndex, text, closeDelimiter, CompareMethod.Text)
        If closingIndex = 0 Then
            ' No se encontró el marcador de cierre
            Return ""
        End If

        ' Obtener el texto entre los dos delimitadores
        Return Mid$(text, openingIndex, closingIndex - openingIndex)
    End Function

End Class