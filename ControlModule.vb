Imports System.Diagnostics.Contracts
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports VB = Microsoft.VisualBasic
Imports WMPLib
Imports System.Web

Public Class ControlModule
    Public CountDownFrom As TimeSpan = TimeSpan.FromSeconds(60) '76
    Private Sub control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 30)
        MainModule.Show()
        MainModule.InitProgram()
    End Sub

    Public Sub BtClose_Click(sender As Object, e As EventArgs)
        MainModule.StopBattleFunctions()
        Application.Exit()
    End Sub

    Private Sub BtStop_Click(sender As Object, e As EventArgs)
        MainModule.StopBattleFunctions()
    End Sub

    Private Sub BtStart_Click(sender As Object, e As EventArgs)
        MainModule.Show()
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
        MainModule.SetBattle()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btstartbattle.Click
        MainModule.Show()
        If CheckBox1.Checked = True Then
            MainModule.Startwords = True
        Else
            MainModule.Startwords = False
        End If
        vars.StopBattle = False
        btstartbattle.Enabled = False

        btstartbattle.Enabled = True
        CbBattleType.Enabled = False
        CbDuration.Enabled = False
        MainModule.SetBattle()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btstopbattle.Click
        MainModule.Startwords = False
        MainModule.StopBattleFunctions()
        btstartbattle.Enabled = True
        btstartwords.Enabled = True
    End Sub
    Private Sub btfullscreen_Click(sender As Object, e As EventArgs) Handles btfullscreen.Click
        MainModule.WindowState = FormWindowState.Maximized
        MainModule.FormBorderStyle = FormBorderStyle.None
    End Sub

    Private Sub btwindowmode_Click(sender As Object, e As EventArgs) Handles btwindowmode.Click
        MainModule.WindowState = FormWindowState.Normal
        MainModule.FormBorderStyle = FormBorderStyle.Sizable
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ControlModule_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MainModule.StopBattleFunctions()
        Application.Exit()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btstartwords.Enabled = False
        Else
            btstartwords.Enabled = True
        End If
    End Sub

    Private Sub btstartwords_Click(sender As Object, e As EventArgs) Handles btstartwords.Click
        MainModule.Startwords = True
        btstartwords.Enabled = False
    End Sub

    Private Sub TbWordsWaittoStart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TbWordsWaittoStart.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class