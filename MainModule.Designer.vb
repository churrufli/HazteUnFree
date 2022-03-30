<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TimerGetWords = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TimerWord = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.BattleTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EasyModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HardModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtremeModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WordsIn10ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbWord = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LblCountDown = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(1278, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TimerGetWords
        '
        Me.TimerGetWords.Interval = 10000
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(1317, 30)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 33)
        Me.Button3.TabIndex = 3
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'TimerWord
        '
        Me.TimerWord.Interval = 50000
        '
        'TimerCountDown
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(1162, 69)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(281, 20)
        Me.ProgressBar1.TabIndex = 37
        Me.ProgressBar1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BattleTypeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1512, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'BattleTypeToolStripMenuItem
        '
        Me.BattleTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EasyModeToolStripMenuItem, Me.HardModeToolStripMenuItem, Me.ExtremeModeToolStripMenuItem, Me.WordsIn10ToolStripMenuItem})
        Me.BattleTypeToolStripMenuItem.Name = "BattleTypeToolStripMenuItem"
        Me.BattleTypeToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
        Me.BattleTypeToolStripMenuItem.Text = "Battle Type"
        '
        'EasyModeToolStripMenuItem
        '
        Me.EasyModeToolStripMenuItem.Name = "EasyModeToolStripMenuItem"
        Me.EasyModeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EasyModeToolStripMenuItem.Text = "Easy Mode"
        Me.EasyModeToolStripMenuItem.ToolTipText = "1 word each 10''"
        '
        'HardModeToolStripMenuItem
        '
        Me.HardModeToolStripMenuItem.Name = "HardModeToolStripMenuItem"
        Me.HardModeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.HardModeToolStripMenuItem.Text = "Hard Mode"
        Me.HardModeToolStripMenuItem.ToolTipText = "1 word each 5''"
        '
        'ExtremeModeToolStripMenuItem
        '
        Me.ExtremeModeToolStripMenuItem.Name = "ExtremeModeToolStripMenuItem"
        Me.ExtremeModeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ExtremeModeToolStripMenuItem.Text = "Extreme Mode"
        Me.ExtremeModeToolStripMenuItem.ToolTipText = "1 word each 2''"
        '
        'WordsIn10ToolStripMenuItem
        '
        Me.WordsIn10ToolStripMenuItem.Name = "WordsIn10ToolStripMenuItem"
        Me.WordsIn10ToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.WordsIn10ToolStripMenuItem.Text = "4 words set each 10''"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LbWord)
        Me.Panel1.ForeColor = System.Drawing.Color.Transparent
        Me.Panel1.Location = New System.Drawing.Point(0, 600)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1900, 350)
        Me.Panel1.TabIndex = 39
        '
        'LbWord
        '
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LbWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LbWord.Font = New System.Drawing.Font("Impact", 120.25!)
        Me.LbWord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.LbWord.Location = New System.Drawing.Point(0, 0)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(1900, 350)
        Me.LbWord.TabIndex = 3
        Me.LbWord.Text = "FREESTYLELIZEDME"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.LblCountDown)
        Me.Panel2.Location = New System.Drawing.Point(689, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(551, 529)
        Me.Panel2.TabIndex = 40
        '
        'LblCountDown
        '
        Me.LblCountDown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCountDown.AutoEllipsis = True
        Me.LblCountDown.AutoSize = True
        Me.LblCountDown.BackColor = System.Drawing.Color.Transparent
        Me.LblCountDown.Font = New System.Drawing.Font("Impact", 240.25!, System.Drawing.FontStyle.Bold)
        Me.LblCountDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCountDown.Location = New System.Drawing.Point(33, 68)
        Me.LblCountDown.Name = "LblCountDown"
        Me.LblCountDown.Size = New System.Drawing.Size(511, 392)
        Me.LblCountDown.TabIndex = 6
        Me.LblCountDown.Text = "00"
        Me.LblCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MainModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1512, 761)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainModule"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Screen - FreeStylelizedMe"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents TimerGetWords As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents TimerWord As Timer
    Friend WithEvents TimerCountDown As Timer
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents BattleTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EasyModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HardModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtremeModeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WordsIn10ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LblCountDown As Label
    Public WithEvents LbWord As Label
End Class
