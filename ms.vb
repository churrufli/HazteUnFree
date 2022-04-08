Imports System.IO
Public Class ms
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
        ms.MySettings = File.ReadAllText(vars.UserDir & "\" & vars.MySettingsFileName)
    End Sub

    Public Shared Sub InitSettings()
        If IO.File.Exists(vars.UserDir & "\" & vars.MySettingsFileName) = False Then
            CreateDefaultSettings()
        End If
        CheckSettings()
    End Sub
    Public Shared Sub CreateDefaultSettings()
        Dim t As String = ""
        t = t & AddSetting("MainBackGroundImage", vars.UserDir & "bg.jpg")
        t = t & AddSetting("LbWordFont", "Impact")
        t = t & AddSetting("LbWordSize", "130pt")
        t = t & AddSetting("lbWordColor", "0; 47; 65")
        t = t & AddSetting("lbCountDownFont", "Impact")
        t = t & AddSetting("lbCountDownFontSize", "125")
        t = t & AddSetting("lbCountDownColor", "192; 64; 0")
        t = t & AddSetting("cbBattleType", "2")
        File.Create(vars.MySettingsFileName).Dispose()
        File.WriteAllText(vars.MySettingsFileName, t)
    End Sub
    Public Shared Sub CheckSettings()
        WriteIfNotExistSetting("MainBackGroundImage", vars.UserDir & "bg.jpg")
        WriteIfNotExistSetting("LbWordFont", "Impact")
        WriteIfNotExistSetting("LbWordSize", "130pt")
        WriteIfNotExistSetting("lbWordColor", "0; 47; 65")
        WriteIfNotExistSetting("lbCountDownFont", "Impact")
        WriteIfNotExistSetting("lbCountDownFontSize", "125")
        WriteIfNotExistSetting("lbCountDownColor", "192; 64; 0")
        WriteIfNotExistSetting("cbBattleType", "2")
    End Sub

    Public Shared Function ReadSetting(setting)
        Return Fn.GetDelimitedText(ms.MySettings, "<" & setting & ">", "</" & setting & ">")
    End Function

    Public Shared Sub WriteIfNotExistSetting(setting, value)
        LoadSettings()
        If InStr(ms.MySettings, "<" & setting & ">", CompareMethod.Text) = 0 Then
            ms.MySettings = ms.MySettings & "<" & setting & ">" & value & "</" & setting & ">" & Environment.NewLine
            ms.MySettings = Replace(ms.MySettings, "><", ">" & Environment.NewLine & "<")
            Try
                File.Delete(vars.MySettingsFileName)
            Catch
            End Try
            File.WriteAllText(vars.MySettingsFileName, ms.MySettings)
            LoadSettings()
        End If
    End Sub

    Public Shared Function AddSetting(setting, value)
        Return "<" & setting & ">" & value & "</" & setting & ">" & Environment.NewLine
    End Function

    Public Shared Sub DeleteSetting(setting)
        UpdateSettings(setting, "")
        ms.MySettings = Replace(ms.MySettings, "<" & setting & "></" & setting & ">", Nothing)
        ms.LoadSettings()
    End Sub
    Public Shared Sub SaveSetting(setting, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(vars.UserDir & vars.MySettingsFileName)
        Dim previousmyvalue = Fn.GetDelimitedText(mylog, "<" & setting & ">", "</" & setting & ">")
        Dim newlog As String
        If previousmyvalue <> Nothing Then
            newlog = Replace(mylog, "<" & setting & ">" & previousmyvalue & "</" & setting & ">",
                             "<" & setting & ">" & myvalue & "</" & setting & ">")
        Else
            newlog = mylog & "<" & setting & ">" & myvalue & "</" & setting & ">" & Environment.NewLine
        End If
        Try
            File.Delete(vars.UserDir & "/" & vars.MySettingsFileName)
        Catch
        End Try
        Try
            File.WriteAllText(vars.UserDir & "/" & vars.MySettingsFileName, newlog)
        Catch
        End Try
        ms.LoadSettings()
    End Sub

    Public Shared Sub UpdateSettings(idsetting, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(vars.MySettingsFileName)
        Dim previousmyvalue = Fn.GetDelimitedText(mylog, "<" & idsetting & ">", "</" & idsetting & ">")
        Dim newSetting = Replace(mylog, "<" & idsetting & ">" & previousmyvalue & "</" & idsetting & ">",
                             "<" & idsetting & ">" & myvalue & "</" & idsetting & ">")
        Try
            File.Delete(vars.UserDir & vars.MySettingsFileName)
        Catch
        End Try
        Try
            File.WriteAllText(vars.UserDir & vars.MySettingsFileName, newSetting)
        Catch
        End Try
        ms.LoadSettings()
    End Sub
End Class
