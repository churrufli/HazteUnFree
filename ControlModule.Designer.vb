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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ControlModule))
        Me.tbUserLog = New System.Windows.Forms.TextBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.FontDialog2 = New System.Windows.Forms.FontDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.lblBattleType = New System.Windows.Forms.Label()
        Me.chshufflemusic = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ColorDialog2 = New System.Windows.Forms.ColorDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ConfiguraciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PalabrasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuenteYTamañoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelojToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuenteYTamañoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PosiciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentanaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModoVentanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModoPantallaCompletaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondoDePantallaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarPantallaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreBatallaRAAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GithubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkHorn = New System.Windows.Forms.CheckBox()
        Me.tbmusicdir = New System.Windows.Forms.TextBox()
        Me.btmusicdir = New System.Windows.Forms.Button()
        Me.chPlayMusic = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CbBattleType = New System.Windows.Forms.ComboBox()
        Me.rbManualMode = New System.Windows.Forms.RadioButton()
        Me.rbAutoMode = New System.Windows.Forms.RadioButton()
        Me.btStopBattle = New System.Windows.Forms.Button()
        Me.TbWordsWaittoStart = New System.Windows.Forms.TextBox()
        Me.chkMinimize = New System.Windows.Forms.CheckBox()
        Me.chautoinitwords = New System.Windows.Forms.CheckBox()
        Me.gbManualMode = New System.Windows.Forms.GroupBox()
        Me.btNextWord = New System.Windows.Forms.Button()
        Me.chamanuailnitwords = New System.Windows.Forms.CheckBox()
        Me.btStartWords = New System.Windows.Forms.Button()
        Me.gbAutoMode = New System.Windows.Forms.GroupBox()
        Me.BtStartBattle = New System.Windows.Forms.Button()
        Me.cbMusicList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbDuration = New System.Windows.Forms.ComboBox()
        Me.ListBoxDictionaries = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkShuffle = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.tabcontrol1 = New System.Windows.Forms.TabControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LbCountDown = New System.Windows.Forms.Label()
        Me.LbWord = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbManualMode.SuspendLayout()
        Me.gbAutoMode.SuspendLayout()
        Me.tabcontrol1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbUserLog
        '
        Me.tbUserLog.Location = New System.Drawing.Point(14, 522)
        Me.tbUserLog.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbUserLog.Multiline = True
        Me.tbUserLog.Name = "tbUserLog"
        Me.tbUserLog.ReadOnly = True
        Me.tbUserLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbUserLog.Size = New System.Drawing.Size(773, 181)
        Me.tbUserLog.TabIndex = 25
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = New System.Drawing.Font("Impact", 130.0!)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.wmf;"
        '
        'PictureBox7
        '
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox7.Cursor = System.Windows.Forms.Cursors.Help
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(17, 21)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(24, 22)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 36
        Me.PictureBox7.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox7, "Las palabras se inician automáticamente al comenzar la batalla, con una pausa en " &
        "segundos establecida (por defecto, 0).")
        Me.PictureBox7.Visible = False
        '
        'lblBattleType
        '
        Me.lblBattleType.AutoSize = True
        Me.lblBattleType.BackColor = System.Drawing.Color.Transparent
        Me.lblBattleType.ForeColor = System.Drawing.Color.Black
        Me.lblBattleType.Location = New System.Drawing.Point(153, 19)
        Me.lblBattleType.Name = "lblBattleType"
        Me.lblBattleType.Size = New System.Drawing.Size(140, 21)
        Me.lblBattleType.TabIndex = 23
        Me.lblBattleType.Text = "Formato de Batalla"
        Me.ToolTip1.SetToolTip(Me.lblBattleType, "Selecciona tipo de batalla")
        '
        'chshufflemusic
        '
        Me.chshufflemusic.AutoSize = True
        Me.chshufflemusic.Location = New System.Drawing.Point(402, 18)
        Me.chshufflemusic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chshufflemusic.Name = "chshufflemusic"
        Me.chshufflemusic.Size = New System.Drawing.Size(207, 25)
        Me.chshufflemusic.TabIndex = 35
        Me.chshufflemusic.Text = "Reproducir pista aleatoria"
        Me.ToolTip1.SetToolTip(Me.chshufflemusic, "Selecciona la música para la batalla (en caso de que tengas en las opciones de mú" &
        "sica desactivado ")
        Me.chshufflemusic.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.MostrarPantallaPrincipalToolStripMenuItem, Me.SobreBatallaRAAPToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(802, 30)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalizarToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(114, 24)
        Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
        '
        'PersonalizarToolStripMenuItem
        '
        Me.PersonalizarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PalabrasToolStripMenuItem, Me.RelojToolStripMenuItem, Me.VentanaPrincipalToolStripMenuItem})
        Me.PersonalizarToolStripMenuItem.Name = "PersonalizarToolStripMenuItem"
        Me.PersonalizarToolStripMenuItem.Size = New System.Drawing.Size(157, 24)
        Me.PersonalizarToolStripMenuItem.Text = "Personalizar"
        '
        'PalabrasToolStripMenuItem
        '
        Me.PalabrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuenteYTamañoToolStripMenuItem, Me.ColorToolStripMenuItem, Me.PosiciónToolStripMenuItem})
        Me.PalabrasToolStripMenuItem.Name = "PalabrasToolStripMenuItem"
        Me.PalabrasToolStripMenuItem.Size = New System.Drawing.Size(192, 24)
        Me.PalabrasToolStripMenuItem.Text = "Palabras"
        '
        'FuenteYTamañoToolStripMenuItem
        '
        Me.FuenteYTamañoToolStripMenuItem.Name = "FuenteYTamañoToolStripMenuItem"
        Me.FuenteYTamañoToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.FuenteYTamañoToolStripMenuItem.Text = "Fuente y Tamaño"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'PosiciónToolStripMenuItem
        '
        Me.PosiciónToolStripMenuItem.Name = "PosiciónToolStripMenuItem"
        Me.PosiciónToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.PosiciónToolStripMenuItem.Text = "Posición"
        '
        'RelojToolStripMenuItem
        '
        Me.RelojToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuenteYTamañoToolStripMenuItem1, Me.ColorToolStripMenuItem1, Me.PosiciónToolStripMenuItem1})
        Me.RelojToolStripMenuItem.Name = "RelojToolStripMenuItem"
        Me.RelojToolStripMenuItem.Size = New System.Drawing.Size(192, 24)
        Me.RelojToolStripMenuItem.Text = "Reloj"
        '
        'FuenteYTamañoToolStripMenuItem1
        '
        Me.FuenteYTamañoToolStripMenuItem1.Name = "FuenteYTamañoToolStripMenuItem1"
        Me.FuenteYTamañoToolStripMenuItem1.Size = New System.Drawing.Size(189, 24)
        Me.FuenteYTamañoToolStripMenuItem1.Text = "Fuente y Tamaño"
        '
        'ColorToolStripMenuItem1
        '
        Me.ColorToolStripMenuItem1.Name = "ColorToolStripMenuItem1"
        Me.ColorToolStripMenuItem1.Size = New System.Drawing.Size(189, 24)
        Me.ColorToolStripMenuItem1.Text = "Color"
        '
        'PosiciónToolStripMenuItem1
        '
        Me.PosiciónToolStripMenuItem1.Name = "PosiciónToolStripMenuItem1"
        Me.PosiciónToolStripMenuItem1.Size = New System.Drawing.Size(189, 24)
        Me.PosiciónToolStripMenuItem1.Text = "Posición"
        '
        'VentanaPrincipalToolStripMenuItem
        '
        Me.VentanaPrincipalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModoVentanaToolStripMenuItem, Me.ModoPantallaCompletaToolStripMenuItem, Me.FondoDePantallaToolStripMenuItem})
        Me.VentanaPrincipalToolStripMenuItem.Name = "VentanaPrincipalToolStripMenuItem"
        Me.VentanaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(192, 24)
        Me.VentanaPrincipalToolStripMenuItem.Text = "Ventana Principal"
        '
        'ModoVentanaToolStripMenuItem
        '
        Me.ModoVentanaToolStripMenuItem.Name = "ModoVentanaToolStripMenuItem"
        Me.ModoVentanaToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.ModoVentanaToolStripMenuItem.Text = "Modo Ventana"
        '
        'ModoPantallaCompletaToolStripMenuItem
        '
        Me.ModoPantallaCompletaToolStripMenuItem.Name = "ModoPantallaCompletaToolStripMenuItem"
        Me.ModoPantallaCompletaToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.ModoPantallaCompletaToolStripMenuItem.Text = "Modo Pantalla Completa"
        '
        'FondoDePantallaToolStripMenuItem
        '
        Me.FondoDePantallaToolStripMenuItem.Name = "FondoDePantallaToolStripMenuItem"
        Me.FondoDePantallaToolStripMenuItem.Size = New System.Drawing.Size(243, 24)
        Me.FondoDePantallaToolStripMenuItem.Text = "Fondo de Pantalla"
        '
        'MostrarPantallaPrincipalToolStripMenuItem
        '
        Me.MostrarPantallaPrincipalToolStripMenuItem.Name = "MostrarPantallaPrincipalToolStripMenuItem"
        Me.MostrarPantallaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(189, 24)
        Me.MostrarPantallaPrincipalToolStripMenuItem.Text = "Mostrar Pantalla Principal"
        '
        'SobreBatallaRAAPToolStripMenuItem
        '
        Me.SobreBatallaRAAPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GithubToolStripMenuItem})
        Me.SobreBatallaRAAPToolStripMenuItem.Name = "SobreBatallaRAAPToolStripMenuItem"
        Me.SobreBatallaRAAPToolStripMenuItem.Size = New System.Drawing.Size(147, 24)
        Me.SobreBatallaRAAPToolStripMenuItem.Text = "Sobre BatallaRAAP"
        '
        'GithubToolStripMenuItem
        '
        Me.GithubToolStripMenuItem.Name = "GithubToolStripMenuItem"
        Me.GithubToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.GithubToolStripMenuItem.Text = "Github"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(773, 447)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Música y Diccionarios"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkHorn)
        Me.GroupBox4.Controls.Add(Me.tbmusicdir)
        Me.GroupBox4.Controls.Add(Me.btmusicdir)
        Me.GroupBox4.Controls.Add(Me.chPlayMusic)
        Me.GroupBox4.Location = New System.Drawing.Point(20, 18)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(732, 160)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Música"
        '
        'chkHorn
        '
        Me.chkHorn.AutoSize = True
        Me.chkHorn.Location = New System.Drawing.Point(21, 106)
        Me.chkHorn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkHorn.Name = "chkHorn"
        Me.chkHorn.Size = New System.Drawing.Size(297, 25)
        Me.chkHorn.TabIndex = 52
        Me.chkHorn.Text = "Reproducir bocina al finalizar la batalla"
        Me.chkHorn.UseVisualStyleBackColor = True
        '
        'tbmusicdir
        '
        Me.tbmusicdir.Location = New System.Drawing.Point(21, 69)
        Me.tbmusicdir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbmusicdir.Name = "tbmusicdir"
        Me.tbmusicdir.Size = New System.Drawing.Size(560, 29)
        Me.tbmusicdir.TabIndex = 51
        '
        'btmusicdir
        '
        Me.btmusicdir.BackColor = System.Drawing.Color.Gainsboro
        Me.btmusicdir.Location = New System.Drawing.Point(587, 66)
        Me.btmusicdir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btmusicdir.Name = "btmusicdir"
        Me.btmusicdir.Size = New System.Drawing.Size(105, 32)
        Me.btmusicdir.TabIndex = 49
        Me.btmusicdir.Text = "Examinar..."
        Me.btmusicdir.UseVisualStyleBackColor = False
        '
        'chPlayMusic
        '
        Me.chPlayMusic.AutoSize = True
        Me.chPlayMusic.Location = New System.Drawing.Point(21, 36)
        Me.chPlayMusic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chPlayMusic.Name = "chPlayMusic"
        Me.chPlayMusic.Size = New System.Drawing.Size(159, 25)
        Me.chPlayMusic.TabIndex = 47
        Me.chPlayMusic.Text = "Reproducir música"
        Me.chPlayMusic.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.CbBattleType)
        Me.TabPage1.Controls.Add(Me.rbManualMode)
        Me.TabPage1.Controls.Add(Me.rbAutoMode)
        Me.TabPage1.Controls.Add(Me.lblBattleType)
        Me.TabPage1.Controls.Add(Me.btStopBattle)
        Me.TabPage1.Controls.Add(Me.TbWordsWaittoStart)
        Me.TabPage1.Controls.Add(Me.chkMinimize)
        Me.TabPage1.Controls.Add(Me.gbManualMode)
        Me.TabPage1.Controls.Add(Me.gbAutoMode)
        Me.TabPage1.Controls.Add(Me.chshufflemusic)
        Me.TabPage1.Controls.Add(Me.cbMusicList)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.CbDuration)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(773, 447)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Batalla"
        '
        'CbBattleType
        '
        Me.CbBattleType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbBattleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbBattleType.FormattingEnabled = True
        Me.CbBattleType.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.CbBattleType.Location = New System.Drawing.Point(157, 48)
        Me.CbBattleType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbBattleType.Name = "CbBattleType"
        Me.CbBattleType.Size = New System.Drawing.Size(226, 29)
        Me.CbBattleType.TabIndex = 2
        '
        'rbManualMode
        '
        Me.rbManualMode.AutoSize = True
        Me.rbManualMode.Location = New System.Drawing.Point(391, 94)
        Me.rbManualMode.Name = "rbManualMode"
        Me.rbManualMode.Size = New System.Drawing.Size(125, 25)
        Me.rbManualMode.TabIndex = 43
        Me.rbManualMode.TabStop = True
        Me.rbManualMode.Text = "Modo Manual"
        Me.rbManualMode.UseVisualStyleBackColor = True
        '
        'rbAutoMode
        '
        Me.rbAutoMode.AutoSize = True
        Me.rbAutoMode.Checked = True
        Me.rbAutoMode.Location = New System.Drawing.Point(22, 94)
        Me.rbAutoMode.Name = "rbAutoMode"
        Me.rbAutoMode.Size = New System.Drawing.Size(153, 25)
        Me.rbAutoMode.TabIndex = 42
        Me.rbAutoMode.TabStop = True
        Me.rbAutoMode.Text = "Modo Automático"
        Me.rbAutoMode.UseVisualStyleBackColor = True
        '
        'btStopBattle
        '
        Me.btStopBattle.BackColor = System.Drawing.Color.Gainsboro
        Me.btStopBattle.Enabled = False
        Me.btStopBattle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btStopBattle.Location = New System.Drawing.Point(22, 384)
        Me.btStopBattle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btStopBattle.Name = "btStopBattle"
        Me.btStopBattle.Size = New System.Drawing.Size(729, 43)
        Me.btStopBattle.TabIndex = 40
        Me.btStopBattle.Text = "PARAR BATALLA"
        Me.btStopBattle.UseVisualStyleBackColor = False
        '
        'TbWordsWaittoStart
        '
        Me.TbWordsWaittoStart.Location = New System.Drawing.Point(511, 341)
        Me.TbWordsWaittoStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbWordsWaittoStart.MaxLength = 2
        Me.TbWordsWaittoStart.Name = "TbWordsWaittoStart"
        Me.TbWordsWaittoStart.Size = New System.Drawing.Size(28, 29)
        Me.TbWordsWaittoStart.TabIndex = 32
        Me.TbWordsWaittoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkMinimize
        '
        Me.chkMinimize.AutoSize = True
        Me.chkMinimize.Location = New System.Drawing.Point(127, 315)
        Me.chkMinimize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkMinimize.Name = "chkMinimize"
        Me.chkMinimize.Size = New System.Drawing.Size(482, 25)
        Me.chkMinimize.TabIndex = 40
        Me.chkMinimize.Text = "Modo Una Pantalla: Minimizar esta ventana al comenzar la batalla" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkMinimize.UseVisualStyleBackColor = True
        '
        'chautoinitwords
        '
        Me.chautoinitwords.AutoSize = True
        Me.chautoinitwords.Checked = True
        Me.chautoinitwords.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chautoinitwords.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chautoinitwords.Location = New System.Drawing.Point(146, 558)
        Me.chautoinitwords.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chautoinitwords.Name = "chautoinitwords"
        Me.chautoinitwords.Size = New System.Drawing.Size(512, 25)
        Me.chautoinitwords.TabIndex = 34
        Me.chautoinitwords.Text = "La primera palabra aparece cuando pasen los primeros         segundos"
        Me.chautoinitwords.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.ToolTip1.SetToolTip(Me.chautoinitwords, "Las palabras se inician automáticamente al comenzar la batalla, con una pausa en " &
        "segundos establecida (por defecto, 0).")
        Me.chautoinitwords.UseVisualStyleBackColor = True
        Me.chautoinitwords.Visible = False
        '
        'gbManualMode
        '
        Me.gbManualMode.Controls.Add(Me.PictureBox7)
        Me.gbManualMode.Controls.Add(Me.btNextWord)
        Me.gbManualMode.Controls.Add(Me.chamanuailnitwords)
        Me.gbManualMode.Controls.Add(Me.btStartWords)
        Me.gbManualMode.Enabled = False
        Me.gbManualMode.Location = New System.Drawing.Point(391, 115)
        Me.gbManualMode.Name = "gbManualMode"
        Me.gbManualMode.Size = New System.Drawing.Size(360, 187)
        Me.gbManualMode.TabIndex = 40
        Me.gbManualMode.TabStop = False
        '
        'btNextWord
        '
        Me.btNextWord.BackColor = System.Drawing.Color.Gainsboro
        Me.btNextWord.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btNextWord.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btNextWord.Location = New System.Drawing.Point(30, 51)
        Me.btNextWord.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btNextWord.Name = "btNextWord"
        Me.btNextWord.Size = New System.Drawing.Size(306, 45)
        Me.btNextWord.TabIndex = 38
        Me.btNextWord.Text = "PALABRA"
        Me.btNextWord.UseVisualStyleBackColor = False
        '
        'chamanuailnitwords
        '
        Me.chamanuailnitwords.AutoSize = True
        Me.chamanuailnitwords.Location = New System.Drawing.Point(60, 22)
        Me.chamanuailnitwords.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chamanuailnitwords.Name = "chamanuailnitwords"
        Me.chamanuailnitwords.Size = New System.Drawing.Size(171, 25)
        Me.chamanuailnitwords.TabIndex = 37
        Me.chamanuailnitwords.Text = "Iniciar manualmente"
        Me.chamanuailnitwords.UseVisualStyleBackColor = True
        Me.chamanuailnitwords.Visible = False
        '
        'btStartWords
        '
        Me.btStartWords.BackColor = System.Drawing.Color.Gainsboro
        Me.btStartWords.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btStartWords.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btStartWords.Location = New System.Drawing.Point(30, 117)
        Me.btStartWords.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btStartWords.Name = "btStartWords"
        Me.btStartWords.Size = New System.Drawing.Size(306, 45)
        Me.btStartWords.TabIndex = 33
        Me.btStartWords.Text = "COMENZAR BATALLA"
        Me.btStartWords.UseVisualStyleBackColor = False
        '
        'gbAutoMode
        '
        Me.gbAutoMode.Controls.Add(Me.BtStartBattle)
        Me.gbAutoMode.Location = New System.Drawing.Point(20, 115)
        Me.gbAutoMode.Name = "gbAutoMode"
        Me.gbAutoMode.Size = New System.Drawing.Size(350, 187)
        Me.gbAutoMode.TabIndex = 39
        Me.gbAutoMode.TabStop = False
        '
        'BtStartBattle
        '
        Me.BtStartBattle.BackColor = System.Drawing.Color.Gainsboro
        Me.BtStartBattle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtStartBattle.Location = New System.Drawing.Point(25, 63)
        Me.BtStartBattle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtStartBattle.Name = "BtStartBattle"
        Me.BtStartBattle.Size = New System.Drawing.Size(306, 45)
        Me.BtStartBattle.TabIndex = 39
        Me.BtStartBattle.Text = "COMENZAR BATALLA"
        Me.BtStartBattle.UseVisualStyleBackColor = False
        '
        'cbMusicList
        '
        Me.cbMusicList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbMusicList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMusicList.FormattingEnabled = True
        Me.cbMusicList.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.cbMusicList.Location = New System.Drawing.Point(402, 47)
        Me.cbMusicList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbMusicList.Name = "cbMusicList"
        Me.cbMusicList.Size = New System.Drawing.Size(350, 29)
        Me.cbMusicList.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Duración"
        '
        'CbDuration
        '
        Me.CbDuration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDuration.FormattingEnabled = True
        Me.CbDuration.Items.AddRange(New Object() {"1'", "1'20''", "2'", "All"})
        Me.CbDuration.Location = New System.Drawing.Point(22, 47)
        Me.CbDuration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbDuration.Name = "CbDuration"
        Me.CbDuration.Size = New System.Drawing.Size(126, 29)
        Me.CbDuration.TabIndex = 3
        '
        'ListBoxDictionaries
        '
        Me.ListBoxDictionaries.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListBoxDictionaries.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBoxDictionaries.CheckOnClick = True
        Me.ListBoxDictionaries.FormattingEnabled = True
        Me.ListBoxDictionaries.Location = New System.Drawing.Point(21, 29)
        Me.ListBoxDictionaries.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBoxDictionaries.MultiColumn = True
        Me.ListBoxDictionaries.Name = "ListBoxDictionaries"
        Me.ListBoxDictionaries.Size = New System.Drawing.Size(699, 96)
        Me.ListBoxDictionaries.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(119, 679)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(418, 21)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Mostrar          palabras de otros diccionarios en cada ronda "
        Me.Label4.Visible = False
        '
        'chkShuffle
        '
        Me.chkShuffle.AutoSize = True
        Me.chkShuffle.Checked = True
        Me.chkShuffle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShuffle.Location = New System.Drawing.Point(21, 186)
        Me.chkShuffle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShuffle.Name = "chkShuffle"
        Me.chkShuffle.Size = New System.Drawing.Size(384, 25)
        Me.chkShuffle.TabIndex = 27
        Me.chkShuffle.Text = "Aleatorizar orden de palabras al cargar diccionarios"
        Me.ToolTip1.SetToolTip(Me.chkShuffle, "El orden de las palabras en cada batalla se aleatorizará y no aparecerán en el mi" &
        "smo orden que el archivo de diccionario(s)")
        Me.chkShuffle.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(180, 674)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBox1.MaxLength = 2
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(28, 29)
        Me.TextBox1.TabIndex = 38
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBox1.Visible = False
        Me.TextBox1.WordWrap = False
        '
        'tabcontrol1
        '
        Me.tabcontrol1.Controls.Add(Me.TabPage1)
        Me.tabcontrol1.Controls.Add(Me.TabPage3)
        Me.tabcontrol1.Location = New System.Drawing.Point(10, 37)
        Me.tabcontrol1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabcontrol1.Name = "tabcontrol1"
        Me.tabcontrol1.SelectedIndex = 0
        Me.tabcontrol1.Size = New System.Drawing.Size(781, 481)
        Me.tabcontrol1.TabIndex = 1
        '
        'LbCountDown
        '
        Me.LbCountDown.AutoSize = True
        Me.LbCountDown.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.LbCountDown.Location = New System.Drawing.Point(3, 0)
        Me.LbCountDown.Name = "LbCountDown"
        Me.LbCountDown.Size = New System.Drawing.Size(47, 37)
        Me.LbCountDown.TabIndex = 0
        Me.LbCountDown.Text = "00"
        Me.LbCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbWord
        '
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LbWord.Location = New System.Drawing.Point(64, 3)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(674, 37)
        Me.LbWord.TabIndex = 43
        Me.LbWord.Text = "BatallaRAAP"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LbWord)
        Me.Panel1.Controls.Add(Me.LbCountDown)
        Me.Panel1.Location = New System.Drawing.Point(14, 710)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 40)
        Me.Panel1.TabIndex = 44
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBoxDictionaries)
        Me.GroupBox1.Controls.Add(Me.chkShuffle)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 185)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(726, 231)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diccionarios"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(123, 344)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(493, 21)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "La primera palabra aparece cuando pasen los primeros         segundos"
        '
        'ControlModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(802, 762)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tabcontrol1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.chautoinitwords)
        Me.Controls.Add(Me.tbUserLog)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "ControlModule"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Control - BatallaRAAP"
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbManualMode.ResumeLayout(False)
        Me.gbManualMode.PerformLayout()
        Me.gbAutoMode.ResumeLayout(False)
        Me.tabcontrol1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbUserLog As TextBox
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents FontDialog2 As FontDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ColorDialog2 As ColorDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ConfiguraciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PersonalizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentanaPrincipalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModoVentanaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ModoPantallaCompletaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FondoDePantallaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PalabrasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuenteYTamañoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RelojToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FuenteYTamañoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ColorToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents MostrarPantallaPrincipalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SobreBatallaRAAPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GithubToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox4 As GroupBox
    Public WithEvents tbmusicdir As TextBox
    Friend WithEvents btmusicdir As Button
    Friend WithEvents chPlayMusic As CheckBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btStopBattle As Button
    Friend WithEvents chshufflemusic As CheckBox
    Friend WithEvents BtStartBattle As Button
    Friend WithEvents btNextWord As Button
    Friend WithEvents chamanuailnitwords As CheckBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents TbWordsWaittoStart As TextBox
    Friend WithEvents chautoinitwords As CheckBox
    Friend WithEvents btStartWords As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents chkShuffle As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ListBoxDictionaries As CheckedListBox
    Friend WithEvents cbMusicList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CbDuration As ComboBox
    Friend WithEvents lblBattleType As Label
    Friend WithEvents CbBattleType As ComboBox
    Friend WithEvents tabcontrol1 As TabControl
    Friend WithEvents gbManualMode As GroupBox
    Friend WithEvents gbAutoMode As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PosiciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PosiciónToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents chkMinimize As CheckBox
    Friend WithEvents chkHorn As CheckBox
    Friend WithEvents LbCountDown As Label
    Public WithEvents LbWord As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbManualMode As RadioButton
    Friend WithEvents rbAutoMode As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
End Class
