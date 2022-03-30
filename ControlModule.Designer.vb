<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlModule
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TbWordsWaittoStart = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbDuration = New System.Windows.Forms.ComboBox()
        Me.lblBattleType = New System.Windows.Forms.Label()
        Me.CbBattleType = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btwindowmode = New System.Windows.Forms.Button()
        Me.btfullscreen = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btstartbattle = New System.Windows.Forms.Button()
        Me.btstartwords = New System.Windows.Forms.Button()
        Me.btstopbattle = New System.Windows.Forms.Button()
        Me.txlog = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(7, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(231, 127)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.TbWordsWaittoStart)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CbDuration)
        Me.TabPage1.Controls.Add(Me.lblBattleType)
        Me.TabPage1.Controls.Add(Me.CbBattleType)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(223, 101)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Batalla"
        '
        'TbWordsWaittoStart
        '
        Me.TbWordsWaittoStart.Location = New System.Drawing.Point(155, 73)
        Me.TbWordsWaittoStart.Name = "TbWordsWaittoStart"
        Me.TbWordsWaittoStart.Size = New System.Drawing.Size(20, 20)
        Me.TbWordsWaittoStart.TabIndex = 22
        Me.TbWordsWaittoStart.Text = "0"
        Me.TbWordsWaittoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(10, 73)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(182, 17)
        Me.CheckBox1.TabIndex = 26
        Me.CheckBox1.Text = "AutoIniciar Palabras a los           ''"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(126, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Duración"
        '
        'CbDuration
        '
        Me.CbDuration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDuration.FormattingEnabled = True
        Me.CbDuration.Items.AddRange(New Object() {"1'", "1'20''", "2'", "All"})
        Me.CbDuration.Location = New System.Drawing.Point(129, 41)
        Me.CbDuration.Name = "CbDuration"
        Me.CbDuration.Size = New System.Drawing.Size(57, 21)
        Me.CbDuration.TabIndex = 21
        '
        'lblBattleType
        '
        Me.lblBattleType.AutoSize = True
        Me.lblBattleType.BackColor = System.Drawing.Color.Transparent
        Me.lblBattleType.ForeColor = System.Drawing.Color.Black
        Me.lblBattleType.Location = New System.Drawing.Point(7, 17)
        Me.lblBattleType.Name = "lblBattleType"
        Me.lblBattleType.Size = New System.Drawing.Size(28, 13)
        Me.lblBattleType.TabIndex = 23
        Me.lblBattleType.Text = "Tipo"
        '
        'CbBattleType
        '
        Me.CbBattleType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbBattleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbBattleType.FormattingEnabled = True
        Me.CbBattleType.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.CbBattleType.Location = New System.Drawing.Point(10, 41)
        Me.CbBattleType.Name = "CbBattleType"
        Me.CbBattleType.Size = New System.Drawing.Size(113, 21)
        Me.CbBattleType.TabIndex = 20
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.btwindowmode)
        Me.TabPage3.Controls.Add(Me.btfullscreen)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(223, 101)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pantalla"
        '
        'btwindowmode
        '
        Me.btwindowmode.Location = New System.Drawing.Point(112, 37)
        Me.btwindowmode.Name = "btwindowmode"
        Me.btwindowmode.Size = New System.Drawing.Size(103, 23)
        Me.btwindowmode.TabIndex = 27
        Me.btwindowmode.Text = "WINDOW MODE"
        Me.btwindowmode.UseVisualStyleBackColor = True
        '
        'btfullscreen
        '
        Me.btfullscreen.Location = New System.Drawing.Point(9, 37)
        Me.btfullscreen.Name = "btfullscreen"
        Me.btfullscreen.Size = New System.Drawing.Size(97, 23)
        Me.btfullscreen.TabIndex = 26
        Me.btfullscreen.Text = "FULL SCREEN"
        Me.btfullscreen.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(203, 101)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Música"
        '
        'btstartbattle
        '
        Me.btstartbattle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstartbattle.Location = New System.Drawing.Point(244, 34)
        Me.btstartbattle.Name = "btstartbattle"
        Me.btstartbattle.Size = New System.Drawing.Size(201, 23)
        Me.btstartbattle.TabIndex = 22
        Me.btstartbattle.Text = "COMENZAR BATALLA"
        Me.btstartbattle.UseVisualStyleBackColor = True
        '
        'btstartwords
        '
        Me.btstartwords.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btstartwords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstartwords.Location = New System.Drawing.Point(244, 63)
        Me.btstartwords.Name = "btstartwords"
        Me.btstartwords.Size = New System.Drawing.Size(201, 23)
        Me.btstartwords.TabIndex = 23
        Me.btstartwords.Text = "COMENZAR PALABRAS"
        Me.btstartwords.UseVisualStyleBackColor = True
        '
        'btstopbattle
        '
        Me.btstopbattle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btstopbattle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstopbattle.Location = New System.Drawing.Point(244, 116)
        Me.btstopbattle.Name = "btstopbattle"
        Me.btstopbattle.Size = New System.Drawing.Size(201, 23)
        Me.btstopbattle.TabIndex = 24
        Me.btstopbattle.Text = "PARAR BATALLA"
        Me.btstopbattle.UseVisualStyleBackColor = True
        '
        'txlog
        '
        Me.txlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlog.Location = New System.Drawing.Point(7, 159)
        Me.txlog.Multiline = True
        Me.txlog.Name = "txlog"
        Me.txlog.ReadOnly = True
        Me.txlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txlog.Size = New System.Drawing.Size(438, 231)
        Me.txlog.TabIndex = 25
        Me.txlog.Visible = False
        '
        'ControlModule
        '
        Me.AcceptButton = Me.btstartbattle
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btstopbattle
        Me.ClientSize = New System.Drawing.Size(454, 156)
        Me.Controls.Add(Me.txlog)
        Me.Controls.Add(Me.btstopbattle)
        Me.Controls.Add(Me.btstartwords)
        Me.Controls.Add(Me.btstartbattle)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "ControlModule"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dock Control - FreeStylelizedMe"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents CbDuration As ComboBox
    Friend WithEvents lblBattleType As Label
    Friend WithEvents TbWordsWaittoStart As TextBox
    Friend WithEvents CbBattleType As ComboBox
    Friend WithEvents btstartbattle As Button
    Friend WithEvents btstartwords As Button
    Friend WithEvents btstopbattle As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btwindowmode As Button
    Friend WithEvents btfullscreen As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txlog As TextBox
End Class
