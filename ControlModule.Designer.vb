<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ControlModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlModule))
        Me.tabcontrol1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btNextWord = New System.Windows.Forms.Button()
        Me.TbWordsWaittoStart = New System.Windows.Forms.TextBox()
        Me.chautoinitwords = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btstartwords = New System.Windows.Forms.Button()
        Me.CbDuration = New System.Windows.Forms.ComboBox()
        Me.lblBattleType = New System.Windows.Forms.Label()
        Me.CbBattleType = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btchangetypocounter = New System.Windows.Forms.Button()
        Me.btchangetypoword = New System.Windows.Forms.Button()
        Me.btwindowmode = New System.Windows.Forms.Button()
        Me.btfullscreen = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btstartbattle = New System.Windows.Forms.Button()
        Me.btstopbattle = New System.Windows.Forms.Button()
        Me.tbUserLog = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.FontDialog2 = New System.Windows.Forms.FontDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabcontrol1
        '
        Me.tabcontrol1.Controls.Add(Me.TabPage1)
        Me.tabcontrol1.Controls.Add(Me.TabPage3)
        Me.tabcontrol1.Controls.Add(Me.TabPage2)
        Me.tabcontrol1.Controls.Add(Me.TabPage4)
        Me.tabcontrol1.Location = New System.Drawing.Point(7, 12)
        Me.tabcontrol1.Name = "tabcontrol1"
        Me.tabcontrol1.SelectedIndex = 0
        Me.tabcontrol1.Size = New System.Drawing.Size(438, 142)
        Me.tabcontrol1.TabIndex = 20
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.btNextWord)
        Me.TabPage1.Controls.Add(Me.TbWordsWaittoStart)
        Me.TabPage1.Controls.Add(Me.chautoinitwords)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.btstartwords)
        Me.TabPage1.Controls.Add(Me.CbDuration)
        Me.TabPage1.Controls.Add(Me.lblBattleType)
        Me.TabPage1.Controls.Add(Me.CbBattleType)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(430, 116)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Batalla"
        '
        'btNextWord
        '
        Me.btNextWord.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btNextWord.Enabled = False
        Me.btNextWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btNextWord.Location = New System.Drawing.Point(233, 75)
        Me.btNextWord.Name = "btNextWord"
        Me.btNextWord.Size = New System.Drawing.Size(175, 32)
        Me.btNextWord.TabIndex = 26
        Me.btNextWord.Text = "SIGUIENTE PALABRA"
        Me.btNextWord.UseVisualStyleBackColor = True
        '
        'TbWordsWaittoStart
        '
        Me.TbWordsWaittoStart.Location = New System.Drawing.Point(378, 11)
        Me.TbWordsWaittoStart.Name = "TbWordsWaittoStart"
        Me.TbWordsWaittoStart.Size = New System.Drawing.Size(20, 20)
        Me.TbWordsWaittoStart.TabIndex = 22
        Me.TbWordsWaittoStart.Text = "0"
        Me.TbWordsWaittoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chautoinitwords
        '
        Me.chautoinitwords.AutoSize = True
        Me.chautoinitwords.Checked = True
        Me.chautoinitwords.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chautoinitwords.Location = New System.Drawing.Point(233, 14)
        Me.chautoinitwords.Name = "chautoinitwords"
        Me.chautoinitwords.Size = New System.Drawing.Size(182, 17)
        Me.chautoinitwords.TabIndex = 26
        Me.chautoinitwords.Text = "AutoIniciar Palabras a los           ''"
        Me.chautoinitwords.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(147, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Duración"
        '
        'btstartwords
        '
        Me.btstartwords.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btstartwords.Enabled = False
        Me.btstartwords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstartwords.Location = New System.Drawing.Point(233, 37)
        Me.btstartwords.Name = "btstartwords"
        Me.btstartwords.Size = New System.Drawing.Size(175, 32)
        Me.btstartwords.TabIndex = 23
        Me.btstartwords.Text = "COMENZAR PALABRAS"
        Me.btstartwords.UseVisualStyleBackColor = True
        '
        'CbDuration
        '
        Me.CbDuration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDuration.FormattingEnabled = True
        Me.CbDuration.Items.AddRange(New Object() {"1'", "1'20''", "2'", "All"})
        Me.CbDuration.Location = New System.Drawing.Point(150, 41)
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
        Me.CbBattleType.Size = New System.Drawing.Size(122, 21)
        Me.CbBattleType.TabIndex = 20
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.Button2)
        Me.TabPage3.Controls.Add(Me.btchangetypocounter)
        Me.TabPage3.Controls.Add(Me.btchangetypoword)
        Me.TabPage3.Controls.Add(Me.btwindowmode)
        Me.TabPage3.Controls.Add(Me.btfullscreen)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(430, 116)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Pantalla"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(319, 95)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btchangetypocounter
        '
        Me.btchangetypocounter.Location = New System.Drawing.Point(212, 65)
        Me.btchangetypocounter.Name = "btchangetypocounter"
        Me.btchangetypocounter.Size = New System.Drawing.Size(183, 23)
        Me.btchangetypocounter.TabIndex = 29
        Me.btchangetypocounter.Text = "Cambiar Tipografía de Reloj"
        Me.btchangetypocounter.UseVisualStyleBackColor = True
        '
        'btchangetypoword
        '
        Me.btchangetypoword.Location = New System.Drawing.Point(14, 65)
        Me.btchangetypoword.Name = "btchangetypoword"
        Me.btchangetypoword.Size = New System.Drawing.Size(183, 23)
        Me.btchangetypoword.TabIndex = 28
        Me.btchangetypoword.Text = "Cambiar Tipografía de Textos"
        Me.btchangetypoword.UseVisualStyleBackColor = True
        '
        'btwindowmode
        '
        Me.btwindowmode.Location = New System.Drawing.Point(14, 23)
        Me.btwindowmode.Name = "btwindowmode"
        Me.btwindowmode.Size = New System.Drawing.Size(183, 23)
        Me.btwindowmode.TabIndex = 27
        Me.btwindowmode.Text = "Modo Ventana"
        Me.btwindowmode.UseVisualStyleBackColor = True
        '
        'btfullscreen
        '
        Me.btfullscreen.Location = New System.Drawing.Point(212, 23)
        Me.btfullscreen.Name = "btfullscreen"
        Me.btfullscreen.Size = New System.Drawing.Size(183, 23)
        Me.btfullscreen.TabIndex = 26
        Me.btfullscreen.Text = "Modo Pantalla Completa"
        Me.btfullscreen.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(430, 116)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Música"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(338, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(408, 78)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Indica el directorio donde tienes tus instrumentales. Si no se indica, se reprodu" &
    "cirán aleatoriamente archivos mp3 que estén en el mismo directorio/subdirectorio" &
    "s que el archivo BatallaRAAP.exe"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(430, 116)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "BatallaAPP"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Label3"
        '
        'btstartbattle
        '
        Me.btstartbattle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btstartbattle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstartbattle.Location = New System.Drawing.Point(21, 160)
        Me.btstartbattle.Name = "btstartbattle"
        Me.btstartbattle.Size = New System.Drawing.Size(197, 49)
        Me.btstartbattle.TabIndex = 22
        Me.btstartbattle.Text = "COMENZAR BATALLA"
        Me.btstartbattle.UseVisualStyleBackColor = True
        '
        'btstopbattle
        '
        Me.btstopbattle.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btstopbattle.Enabled = False
        Me.btstopbattle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btstopbattle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btstopbattle.Location = New System.Drawing.Point(244, 161)
        Me.btstopbattle.Name = "btstopbattle"
        Me.btstopbattle.Size = New System.Drawing.Size(175, 47)
        Me.btstopbattle.TabIndex = 24
        Me.btstopbattle.Text = "PARAR BATALLA"
        Me.btstopbattle.UseVisualStyleBackColor = True
        '
        'tbUserLog
        '
        Me.tbUserLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbUserLog.Location = New System.Drawing.Point(7, 215)
        Me.tbUserLog.Multiline = True
        Me.tbUserLog.Name = "tbUserLog"
        Me.tbUserLog.ReadOnly = True
        Me.tbUserLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbUserLog.Size = New System.Drawing.Size(438, 197)
        Me.tbUserLog.TabIndex = 25
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.wmf;"
        '
        'ControlModule
        '
        Me.AcceptButton = Me.btstartbattle
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.btstopbattle
        Me.ClientSize = New System.Drawing.Size(459, 424)
        Me.Controls.Add(Me.tbUserLog)
        Me.Controls.Add(Me.btstopbattle)
        Me.Controls.Add(Me.btstartbattle)
        Me.Controls.Add(Me.tabcontrol1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "ControlModule"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control - BatallaRAAP"
        Me.TopMost = True
        Me.tabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabcontrol1 As TabControl
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
    Friend WithEvents chautoinitwords As CheckBox
    Friend WithEvents tbUserLog As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btNextWord As Button
    Friend WithEvents btchangetypoword As Button
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents btchangetypocounter As Button
    Friend WithEvents FontDialog2 As FontDialog
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button2 As Button
End Class
