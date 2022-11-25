Imports System.IO

Public Class Ms
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
        t = t & AddSetting("TbWordsWaittoStart", "3")
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

    Public Shared Sub SaveSetting(setting, myvalue)
        Dim mylog As String = My.Computer.FileSystem.ReadAllText(Vars.UserDir & Vars.MySettingsFileName)
        Dim previousmyvalue = Fn.GetDelimitedText(mylog, "<" & setting & ">", "</" & setting & ">")
        Dim newlog As String
        If previousmyvalue = myvalue Then Exit Sub

        If previousmyvalue <> Nothing Then
            newlog = Replace(mylog, "<" & setting & ">" & previousmyvalue & "</" & setting & ">",
                             "<" & setting & ">" & myvalue & "</" & setting & ">")
        Else
            newlog = mylog & "<" & setting & ">" & myvalue & "</" & setting & ">" & Environment.NewLine
        End If
        Try
            File.Delete(Vars.UserDir & "/" & Vars.MySettingsFileName)
        Catch
        End Try
        Try
            File.WriteAllText(Vars.UserDir & "/" & Vars.MySettingsFileName, newlog)
        Catch
        End Try
        LoadSettings()
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
