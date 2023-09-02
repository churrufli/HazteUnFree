Imports System.IO
Imports System.Text.RegularExpressions

Public Class Ms
    Public Shared ControlPositions As New Dictionary(Of String, Point)()

    Public Shared MySettings 'aqui guardaré para leer
    'Public Shared MainBackGroundImage As String
    'Public Shared LbWordFont As String
    'Public Shared LbWordSize As String
    'Public Shared lbWordColor As String
    'Public Shared lbCountDownFont As String
    'Public Shared lbCountDownFontSize As String
    'Public Shared lbCountDownColor As String
    'Public Shared cbBattleType As String

    Public Shared Sub LoadSettings()
        MySettings = File.ReadAllText(Vars.UserDir & "\" & Vars.MySettingsFileName)
        ' Cargar las posiciones de los controles si están disponibles
        For Each ctrl As Control In ControlModule.Controls ' Cambia ControlModule al nombre de tu formulario
            If ControlPositions.ContainsKey(ctrl.Name) Then
                ctrl.Location = ControlPositions(ctrl.Name)
            End If
        Next
    End Sub

    Public Shared Sub InitSettings()
        If File.Exists(Vars.UserDir & "\" & Vars.MySettingsFileName) = False Then
            CreateDefaultSettings()
        End If
        CheckSettings()
    End Sub

    Public Shared Sub CreateDefaultSettings()
        Dim t = ""
        t = t & AddSetting("MainBackGroundImage", Vars.UserDir & "bg.jpg")
        t = t & AddSetting("LbWordFont", "[Font: Name=Impact, Size=120, Units=3, GdiCharSet=0, GdiVerticalFont=False]")
        t = t & AddSetting("LbWordSize", "130pt")
        t = t & AddSetting("lbWordColor", "-16565619")
        t = t & AddSetting("lbCountDownFont", "[Font: Name=Impact, Size=200,25, Units=3, GdiCharSet=0, GdiVerticalFont=False]")
        t = t & AddSetting("lbCountDownFontSize", "125")
        t = t & AddSetting("lbCountDownColor", "-32768")
        t = t & AddSetting("cbBattleType", "2")
        t = t & AddSetting("MusicDirectory", Directory.GetCurrentDirectory)
        t = t & AddSetting("TbWordsWaittoStart", "0")
        t = t & AddSetting("chkSoundFx", "1")
        t = t & AddSetting("chPlayMusic", "1")
        t = t & AddSetting("chkMinimize", "0")

        File.Create(Vars.MySettingsFileName).Dispose()
        File.WriteAllText(Vars.MySettingsFileName, t)
    End Sub

    Public Shared Sub CheckSettings()
        WriteIfNotExistSetting("MainBackGroundImage", Vars.UserDir & "bg.jpg")
        WriteIfNotExistSetting("LbWordFont", "[Font: Name=Impact, Size=120, Units=3, GdiCharSet=0, GdiVerticalFont=False]")
        WriteIfNotExistSetting("LbWordSize", "130pt")
        WriteIfNotExistSetting("lbWordColor", "-16565619")
        WriteIfNotExistSetting("lbCountDownFont", "[Font: Name=Impact, Size=200,25, Units=3, GdiCharSet=0, GdiVerticalFont=False]")
        WriteIfNotExistSetting("lbCountDownFontSize", "125")
        WriteIfNotExistSetting("lbCountDownColor", "-32768")
        WriteIfNotExistSetting("cbBattleType", "2")
        WriteIfNotExistSetting("MusicDirectory", Directory.GetCurrentDirectory)
        WriteIfNotExistSetting("TbWordsWaittoStart", "3")
        WriteIfNotExistSetting("chkSoundFx", "1")
        WriteIfNotExistSetting("chkMinimize", "0")
        WriteIfNotExistSetting("chPlayMusic", "1")
    End Sub

    Public Shared Function ReadSetting(setting)
        Return Fn.GetDelimitedText(MySettings, "<" & setting & ">", "</" & setting & ">")
    End Function

    Public Shared Sub WriteIfNotExistSetting(setting, value)
        LoadSettings()
        If InStr(MySettings, "<" & setting & ">", CompareMethod.Text) = 0 Then
            MySettings = MySettings & "<" & setting & ">" & value & "</" & setting & ">" & Environment.NewLine
            MySettings = Replace(MySettings, "><", ">" & Environment.NewLine & "<")
            Try
                File.Delete(Vars.MySettingsFileName)
            Catch
            End Try
            File.WriteAllText(Vars.MySettingsFileName, MySettings)
            LoadSettings()
        End If
    End Sub

    Public Shared Function AddSetting(setting, value)
        Return "<" & setting & ">" & value & "</" & setting & ">" & Environment.NewLine
    End Function

    Public Shared Sub DeleteSetting(setting)
        UpdateSettings(setting, "")
        MySettings = Replace(MySettings, "<" & setting & "></" & setting & ">", Nothing)
        LoadSettings()
    End Sub

    Public Shared Sub SaveSetting(setting As String, myvalue As String)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(Vars.UserDir & "\" & Vars.MySettingsFileName)

        ' Buscar si la configuración ya existe en el archivo
        Dim settingPattern As String = $"<{setting}>(.*?)</{setting}>"
        Dim settingMatch As Match = Regex.Match(mylog, settingPattern, RegexOptions.Singleline)

        If settingMatch.Success Then
            ' Si la configuración ya existe, actualiza su valor
            mylog = Regex.Replace(mylog, settingPattern, $"<{setting}>{myvalue}</{setting}>", RegexOptions.Singleline)
        Else
            ' Si la configuración no existe, crea una nueva entrada
            mylog &= $"<{setting}>{myvalue}</{setting}>" & Environment.NewLine
        End If

        Try
            File.WriteAllText(Vars.UserDir & "\" & Vars.MySettingsFileName, mylog)
            LoadSettings()
        Catch ex As Exception
            ' Manejar errores aquí
            Fn.WriteLog($"Error al guardar la configuración '{setting}': {ex.Message}")
        End Try
    End Sub

    Public Shared Sub UpdateSettings(idsetting, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(Vars.MySettingsFileName)
        Dim previousmyvalue = Fn.GetDelimitedText(mylog, "<" & idsetting & ">", "</" & idsetting & ">")
        Dim newSetting = Replace(mylog, "<" & idsetting & ">" & previousmyvalue & "</" & idsetting & ">",
                                 "<" & idsetting & ">" & myvalue & "</" & idsetting & ">")
        Try
            File.Delete(Vars.UserDir & Vars.MySettingsFileName)
        Catch
        End Try
        Try
            File.WriteAllText(Vars.UserDir & Vars.MySettingsFileName, newSetting)
        Catch
        End Try
        LoadSettings()
    End Sub

End Class