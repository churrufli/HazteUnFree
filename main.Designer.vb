<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.LbWord = New System.Windows.Forms.Label()
        Me.BtStart = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TimerGetWords = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TimerWord = New System.Windows.Forms.Timer(Me.components)
        Me.BtStop = New System.Windows.Forms.Button()
        Me.TimerCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.LblCountDown = New System.Windows.Forms.Label()
        Me.CbBattleType = New System.Windows.Forms.ComboBox()
        Me.lblBattleType = New System.Windows.Forms.Label()
        Me.LbWordsWaittoStart = New System.Windows.Forms.Label()
        Me.TbWordsWaittoStart = New System.Windows.Forms.TextBox()
        Me.CbDuration = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LbWord
        '
        Me.LbWord.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbWord.AutoSize = True
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Font = New System.Drawing.Font("Impact", 190.25!, System.Drawing.FontStyle.Bold)
        Me.LbWord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.LbWord.Location = New System.Drawing.Point(300, 300)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(977, 310)
        Me.LbWord.TabIndex = 0
        Me.LbWord.Text = "mylabel"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtStart
        '
        Me.BtStart.BackColor = System.Drawing.Color.Transparent
        Me.BtStart.BackgroundImage = CType(resources.GetObject("BtStart.BackgroundImage"), System.Drawing.Image)
        Me.BtStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtStart.FlatAppearance.BorderSize = 0
        Me.BtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtStart.Location = New System.Drawing.Point(481, 8)
        Me.BtStart.Name = "BtStart"
        Me.BtStart.Size = New System.Drawing.Size(49, 48)
        Me.BtStart.TabIndex = 3
        Me.BtStart.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(1028, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TimerGetWords
        '
        Me.TimerGetWords.Interval = 10000
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(1079, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 33)
        Me.Button3.TabIndex = 3
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TimerWord
        '
        Me.TimerWord.Interval = 50000
        '
        'BtStop
        '
        Me.BtStop.BackColor = System.Drawing.Color.Transparent
        Me.BtStop.BackgroundImage = CType(resources.GetObject("BtStop.BackgroundImage"), System.Drawing.Image)
        Me.BtStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtStop.FlatAppearance.BorderSize = 0
        Me.BtStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtStop.Location = New System.Drawing.Point(536, 7)
        Me.BtStop.Name = "BtStop"
        Me.BtStop.Size = New System.Drawing.Size(48, 48)
        Me.BtStop.TabIndex = 4
        Me.BtStop.UseVisualStyleBackColor = False
        '
        'TimerCountDown
        '
        '
        'LblCountDown
        '
        Me.LblCountDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCountDown.AutoSize = True
        Me.LblCountDown.BackColor = System.Drawing.Color.Transparent
        Me.LblCountDown.Font = New System.Drawing.Font("Impact", 240.25!, System.Drawing.FontStyle.Bold)
        Me.LblCountDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCountDown.Location = New System.Drawing.Point(438, 84)
        Me.LblCountDown.Name = "LblCountDown"
        Me.LblCountDown.Size = New System.Drawing.Size(615, 392)
        Me.LblCountDown.TabIndex = 5
        Me.LblCountDown.Text = "--:--"
        Me.LblCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CbBattleType
        '
        Me.CbBattleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbBattleType.FormattingEnabled = True
        Me.CbBattleType.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.CbBattleType.Location = New System.Drawing.Point(71, 22)
        Me.CbBattleType.Name = "CbBattleType"
        Me.CbBattleType.Size = New System.Drawing.Size(121, 21)
        Me.CbBattleType.TabIndex = 1
        '
        'lblBattleType
        '
        Me.lblBattleType.AutoSize = True
        Me.lblBattleType.BackColor = System.Drawing.Color.Transparent
        Me.lblBattleType.ForeColor = System.Drawing.Color.White
        Me.lblBattleType.Location = New System.Drawing.Point(13, 25)
        Me.lblBattleType.Name = "lblBattleType"
        Me.lblBattleType.Size = New System.Drawing.Size(58, 13)
        Me.lblBattleType.TabIndex = 8
        Me.lblBattleType.Text = "BattleType"
        '
        'LbWordsWaittoStart
        '
        Me.LbWordsWaittoStart.AutoSize = True
        Me.LbWordsWaittoStart.BackColor = System.Drawing.Color.Transparent
        Me.LbWordsWaittoStart.ForeColor = System.Drawing.Color.White
        Me.LbWordsWaittoStart.Location = New System.Drawing.Point(314, 26)
        Me.LbWordsWaittoStart.Name = "LbWordsWaittoStart"
        Me.LbWordsWaittoStart.Size = New System.Drawing.Size(117, 13)
        Me.LbWordsWaittoStart.TabIndex = 9
        Me.LbWordsWaittoStart.Text = "First Word Wait to Start"
        '
        'TbWordsWaittoStart
        '
        Me.TbWordsWaittoStart.Location = New System.Drawing.Point(437, 23)
        Me.TbWordsWaittoStart.Name = "TbWordsWaittoStart"
        Me.TbWordsWaittoStart.Size = New System.Drawing.Size(20, 20)
        Me.TbWordsWaittoStart.TabIndex = 2
        Me.TbWordsWaittoStart.Text = "10"
        '
        'CbDuration
        '
        Me.CbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDuration.FormattingEnabled = True
        Me.CbDuration.Items.AddRange(New Object() {"1'", "1'20''", "2'", "All"})
        Me.CbDuration.Location = New System.Drawing.Point(251, 22)
        Me.CbDuration.Name = "CbDuration"
        Me.CbDuration.Size = New System.Drawing.Size(57, 21)
        Me.CbDuration.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(198, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Duration"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 61)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(587, 20)
        Me.ProgressBar1.TabIndex = 37
        Me.ProgressBar1.Visible = False
        '
        'BtClose
        '
        Me.BtClose.Location = New System.Drawing.Point(797, 25)
        Me.BtClose.Name = "BtClose"
        Me.BtClose.Size = New System.Drawing.Size(75, 23)
        Me.BtClose.TabIndex = 38
        Me.BtClose.Text = "Close"
        Me.BtClose.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1512, 642)
        Me.Controls.Add(Me.BtClose)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbDuration)
        Me.Controls.Add(Me.LbWordsWaittoStart)
        Me.Controls.Add(Me.lblBattleType)
        Me.Controls.Add(Me.TbWordsWaittoStart)
        Me.Controls.Add(Me.CbBattleType)
        Me.Controls.Add(Me.LbWord)
        Me.Controls.Add(Me.LblCountDown)
        Me.Controls.Add(Me.BtStop)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BtStart)
        Me.Name = "Main"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "freestylizedme"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbWord As Label
    Friend WithEvents BtStart As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TimerGetWords As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents TimerWord As Timer
    Friend WithEvents BtStop As Button
    Friend WithEvents TimerCountDown As Timer
    Friend WithEvents LblCountDown As Label
    Friend WithEvents CbBattleType As ComboBox
    Friend WithEvents lblBattleType As Label
    Friend WithEvents LbWordsWaittoStart As Label
    Friend WithEvents TbWordsWaittoStart As TextBox
    Friend WithEvents CbDuration As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BtClose As Button
End Class
