﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainModule
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainModule))
        Me.TimerGetWords = New System.Windows.Forms.Timer(Me.components)
        Me.TimerWord = New System.Windows.Forms.Timer(Me.components)
        Me.TimerVisualCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.LbCountDown = New System.Windows.Forms.Label()
        Me.LbWord = New System.Windows.Forms.Label()
        Me.lbTipoBatalla = New System.Windows.Forms.Label()
        Me.lbCaractBatalla = New System.Windows.Forms.Label()
        Me.TimerProgressBar1 = New System.Windows.Forms.Timer(Me.components)
        Me.CustomProgressBar1 = New HazteUnFree.CustomProgressBar()
        Me.SuspendLayout()
        '
        'TimerGetWords
        '
        Me.TimerGetWords.Interval = 5000
        '
        'TimerWord
        '
        Me.TimerWord.Interval = 50000
        '
        'TimerVisualCountDown
        '
        '
        'LbCountDown
        '
        Me.LbCountDown.BackColor = System.Drawing.Color.Transparent
        Me.LbCountDown.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LbCountDown.Font = New System.Drawing.Font("Impact", 170.0!)
        Me.LbCountDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbCountDown.Location = New System.Drawing.Point(665, 94)
        Me.LbCountDown.Name = "LbCountDown"
        Me.LbCountDown.Size = New System.Drawing.Size(600, 470)
        Me.LbCountDown.TabIndex = 6
        Me.LbCountDown.Text = "00"
        Me.LbCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.LbCountDown, "Arrastra y suelta el contador para posicionarlo en la pantalla.")
        '
        'LbWord
        '
        Me.LbWord.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LbWord.Font = New System.Drawing.Font("Impact", 130.0!)
        Me.LbWord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.LbWord.Location = New System.Drawing.Point(-72, 603)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(1900, 290)
        Me.LbWord.TabIndex = 3
        Me.LbWord.Text = "HazteUnFree"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.LbWord, "Arrastra y suelta la palabra para posicionarla en la pantalla.")
        '
        'lbTipoBatalla
        '
        Me.lbTipoBatalla.BackColor = System.Drawing.Color.Transparent
        Me.lbTipoBatalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbTipoBatalla.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Italic)
        Me.lbTipoBatalla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.lbTipoBatalla.Location = New System.Drawing.Point(581, 879)
        Me.lbTipoBatalla.Name = "lbTipoBatalla"
        Me.lbTipoBatalla.Size = New System.Drawing.Size(372, 88)
        Me.lbTipoBatalla.TabIndex = 9
        Me.lbTipoBatalla.Text = "MODO"
        Me.lbTipoBatalla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lbTipoBatalla, "Arrastra y suelta el contador para posicionarlo en la pantalla.")
        '
        'lbCaractBatalla
        '
        Me.lbCaractBatalla.BackColor = System.Drawing.Color.Transparent
        Me.lbCaractBatalla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbCaractBatalla.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Italic)
        Me.lbCaractBatalla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.lbCaractBatalla.Location = New System.Drawing.Point(959, 879)
        Me.lbCaractBatalla.Name = "lbCaractBatalla"
        Me.lbCaractBatalla.Size = New System.Drawing.Size(361, 88)
        Me.lbCaractBatalla.TabIndex = 10
        Me.lbCaractBatalla.Text = "MODO"
        Me.lbCaractBatalla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.lbCaractBatalla, "Arrastra y suelta el contador para posicionarlo en la pantalla.")
        '
        'TimerProgressBar1
        '
        '
        'CustomProgressBar1
        '
        Me.CustomProgressBar1.Location = New System.Drawing.Point(712, 979)
        Me.CustomProgressBar1.Name = "CustomProgressBar1"
        Me.CustomProgressBar1.Size = New System.Drawing.Size(480, 10)
        Me.CustomProgressBar1.TabIndex = 8
        '
        'MainModule
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.CustomProgressBar1)
        Me.Controls.Add(Me.lbCaractBatalla)
        Me.Controls.Add(Me.lbTipoBatalla)
        Me.Controls.Add(Me.LbCountDown)
        Me.Controls.Add(Me.LbWord)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "MainModule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla Principal - HazteUnFree -  Versión 1.0.1"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents TimerGetWords As Timer
    Friend WithEvents TimerWord As Timer
    Friend WithEvents TimerVisualCountDown As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Public WithEvents LbCountDown As Label
    Public WithEvents LbWord As Label
    Friend WithEvents TimerProgressBar1 As Timer
    Friend WithEvents CustomProgressBar1 As CustomProgressBar
    Public WithEvents lbTipoBatalla As Label
    Public WithEvents lbCaractBatalla As Label
End Class
