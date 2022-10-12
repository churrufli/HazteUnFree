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
        Me.TimerVisualCountDown = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LbCountDown = New System.Windows.Forms.Label()
        Me.TimerProgressBar = New System.Windows.Forms.Timer(Me.components)
        Me.LbWord = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(65, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(33, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TimerGetWords
        '
        Me.TimerGetWords.Interval = 5000
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(104, 46)
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
        'TimerVisualCountDown
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.LbCountDown)
        Me.Panel2.Location = New System.Drawing.Point(601, 146)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(696, 404)
        Me.Panel2.TabIndex = 40
        '
        'LbCountDown
        '
        Me.LbCountDown.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbCountDown.BackColor = System.Drawing.Color.Transparent
        Me.LbCountDown.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.LbCountDown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbCountDown.Location = New System.Drawing.Point(0, 0)
        Me.LbCountDown.Name = "LbCountDown"
        Me.LbCountDown.Size = New System.Drawing.Size(722, 404)
        Me.LbCountDown.TabIndex = 6
        Me.LbCountDown.Text = "00"
        Me.LbCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimerProgressBar
        '
        '
        'LbWord
        '
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Font = New System.Drawing.Font("Impact", 130.0!)
        Me.LbWord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.LbWord.Location = New System.Drawing.Point(0, 0)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(1900, 350)
        Me.LbWord.TabIndex = 3
        Me.LbWord.Text = "BatallaRAAP"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(54, 107)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(281, 20)
        Me.ProgressBar1.TabIndex = 37
        Me.ProgressBar1.Visible = False
        '
        'MainModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Name = "MainModule"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main Screen - BatallaRAPP"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As Button
    Friend WithEvents TimerGetWords As Timer
    Friend WithEvents Button3 As Button
    Friend WithEvents TimerWord As Timer
    Friend WithEvents TimerVisualCountDown As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TimerProgressBar As Timer
    Public WithEvents LbWord As Label
    Friend WithEvents Panel1 As Panel
    Public WithEvents LbCountDown As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
