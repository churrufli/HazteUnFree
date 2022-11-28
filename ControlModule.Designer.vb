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
        Me.lblBattleType = New System.Windows.Forms.Label()
        Me.chshufflemusic = New System.Windows.Forms.CheckBox()
        Me.chkShuffle = New System.Windows.Forms.CheckBox()
        Me.TbWordsWaittoStart = New System.Windows.Forms.TextBox()
        Me.chkDepureDic = New System.Windows.Forms.CheckBox()
        Me.CbBattleType = New System.Windows.Forms.ComboBox()
        Me.btNextWord = New System.Windows.Forms.Button()
        Me.CbDuration = New System.Windows.Forms.ComboBox()
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
        Me.ReestablecerPersonalizaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarPantallaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreHazteUnFreeAAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GithubToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DIscordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ListBoxDictionaries = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkSoundFx = New System.Windows.Forms.CheckBox()
        Me.tbmusicdir = New System.Windows.Forms.TextBox()
        Me.btmusicdir = New System.Windows.Forms.Button()
        Me.chPlayMusic = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btStopBattle = New System.Windows.Forms.Button()
        Me.btStartWords = New System.Windows.Forms.Button()
        Me.BtStartBattle = New System.Windows.Forms.Button()
        Me.cbMusicList = New System.Windows.Forms.ComboBox()
        Me.chkMinimize = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabBattle = New System.Windows.Forms.TabControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.LbCountDown = New System.Windows.Forms.Label()
        Me.LbWord = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TimerWait = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabMode = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.MenuStrip1.SuspendLayout
        Me.TabPage3.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.TabPage1.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.TabBattle.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.TabMode.SuspendLayout
        Me.TabPage2.SuspendLayout
        Me.TabPage4.SuspendLayout
        Me.TabPage5.SuspendLayout
        Me.SuspendLayout
        '
        'tbUserLog
        '
        Me.tbUserLog.Location = New System.Drawing.Point(14, 522)
        Me.tbUserLog.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbUserLog.Multiline = true
        Me.tbUserLog.Name = "tbUserLog"
        Me.tbUserLog.ReadOnly = true
        Me.tbUserLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbUserLog.Size = New System.Drawing.Size(491, 122)
        Me.tbUserLog.TabIndex = 25
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = New System.Drawing.Font("Impact", 130!)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.wmf;"
        '
        'lblBattleType
        '
        Me.lblBattleType.AutoSize = true
        Me.lblBattleType.BackColor = System.Drawing.Color.Transparent
        Me.lblBattleType.ForeColor = System.Drawing.Color.Black
        Me.lblBattleType.Location = New System.Drawing.Point(7, 11)
        Me.lblBattleType.Name = "lblBattleType"
        Me.lblBattleType.Size = New System.Drawing.Size(124, 19)
        Me.lblBattleType.TabIndex = 23
        Me.lblBattleType.Text = "Formato de Batalla"
        Me.ToolTip1.SetToolTip(Me.lblBattleType, "Selecciona tipo de batalla")
        '
        'chshufflemusic
        '
        Me.chshufflemusic.AutoSize = true
        Me.chshufflemusic.Location = New System.Drawing.Point(11, 76)
        Me.chshufflemusic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chshufflemusic.Name = "chshufflemusic"
        Me.chshufflemusic.Size = New System.Drawing.Size(183, 23)
        Me.chshufflemusic.TabIndex = 35
        Me.chshufflemusic.Text = "Reproducir pista aleatoria"
        Me.ToolTip1.SetToolTip(Me.chshufflemusic, "Selecciona la música para la batalla (en caso de que tengas en las opciones de mú"& _ 
        "sica desactivado ")
        Me.chshufflemusic.UseVisualStyleBackColor = true
        '
        'chkShuffle
        '
        Me.chkShuffle.AutoSize = true
        Me.chkShuffle.Checked = true
        Me.chkShuffle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShuffle.Location = New System.Drawing.Point(21, 125)
        Me.chkShuffle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkShuffle.Name = "chkShuffle"
        Me.chkShuffle.Size = New System.Drawing.Size(338, 23)
        Me.chkShuffle.TabIndex = 27
        Me.chkShuffle.Text = "Aleatorizar orden de palabras al cargar diccionarios"
        Me.ToolTip1.SetToolTip(Me.chkShuffle, "El orden de las palabras en cada batalla se aleatorizará y no aparecerán en el mi"& _ 
        "smo orden que el archivo de diccionario(s)")
        Me.chkShuffle.UseVisualStyleBackColor = true
        '
        'TbWordsWaittoStart
        '
        Me.TbWordsWaittoStart.Font = New System.Drawing.Font("Segoe UI", 10!)
        Me.TbWordsWaittoStart.Location = New System.Drawing.Point(273, 86)
        Me.TbWordsWaittoStart.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TbWordsWaittoStart.MaxLength = 2
        Me.TbWordsWaittoStart.Name = "TbWordsWaittoStart"
        Me.TbWordsWaittoStart.Size = New System.Drawing.Size(25, 25)
        Me.TbWordsWaittoStart.TabIndex = 32
        Me.TbWordsWaittoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ToolTip1.SetToolTip(Me.TbWordsWaittoStart, "segundos")
        '
        'chkDepureDic
        '
        Me.chkDepureDic.AutoSize = true
        Me.chkDepureDic.Location = New System.Drawing.Point(21, 156)
        Me.chkDepureDic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkDepureDic.Name = "chkDepureDic"
        Me.chkDepureDic.Size = New System.Drawing.Size(399, 23)
        Me.chkDepureDic.TabIndex = 36
        Me.chkDepureDic.Text = "Depurar diccionarios al cargar eliminando términos repetidos"
        Me.ToolTip1.SetToolTip(Me.chkDepureDic, "Marca y desmarca los diccionarios para depurarlos")
        Me.chkDepureDic.UseVisualStyleBackColor = true
        '
        'CbBattleType
        '
        Me.CbBattleType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbBattleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbBattleType.FormattingEnabled = true
        Me.CbBattleType.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.CbBattleType.Location = New System.Drawing.Point(11, 40)
        Me.CbBattleType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbBattleType.Name = "CbBattleType"
        Me.CbBattleType.Size = New System.Drawing.Size(305, 25)
        Me.CbBattleType.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.CbBattleType, "Elige el formato de la batalla")
        '
        'btNextWord
        '
        Me.btNextWord.BackColor = System.Drawing.Color.Gainsboro
        Me.btNextWord.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btNextWord.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btNextWord.Location = New System.Drawing.Point(249, 33)
        Me.btNextWord.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btNextWord.Name = "btNextWord"
        Me.btNextWord.Size = New System.Drawing.Size(188, 45)
        Me.btNextWord.TabIndex = 38
        Me.btNextWord.Text = "PALABRA"
        Me.ToolTip1.SetToolTip(Me.btNextWord, "muestra una nueva palabra en pantalla")
        Me.btNextWord.UseVisualStyleBackColor = false
        '
        'CbDuration
        '
        Me.CbDuration.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CbDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDuration.FormattingEnabled = true
        Me.CbDuration.Items.AddRange(New Object() {"1'", "1'20''", "2'", "All"})
        Me.CbDuration.Location = New System.Drawing.Point(325, 40)
        Me.CbDuration.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CbDuration.Name = "CbDuration"
        Me.CbDuration.Size = New System.Drawing.Size(118, 25)
        Me.CbDuration.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.CbDuration, "Tiempo de duración de la batalla")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraciónToolStripMenuItem, Me.MostrarPantallaPrincipalToolStripMenuItem, Me.SobreHazteUnFreeAAPToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(517, 29)
        Me.MenuStrip1.TabIndex = 42
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ConfiguraciónToolStripMenuItem
        '
        Me.ConfiguraciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PersonalizarToolStripMenuItem, Me.ReestablecerPersonalizaciónToolStripMenuItem})
        Me.ConfiguraciónToolStripMenuItem.Name = "ConfiguraciónToolStripMenuItem"
        Me.ConfiguraciónToolStripMenuItem.Size = New System.Drawing.Size(106, 23)
        Me.ConfiguraciónToolStripMenuItem.Text = "Configuración"
        '
        'PersonalizarToolStripMenuItem
        '
        Me.PersonalizarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PalabrasToolStripMenuItem, Me.RelojToolStripMenuItem, Me.VentanaPrincipalToolStripMenuItem})
        Me.PersonalizarToolStripMenuItem.Name = "PersonalizarToolStripMenuItem"
        Me.PersonalizarToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.PersonalizarToolStripMenuItem.Text = "Personalizar"
        '
        'PalabrasToolStripMenuItem
        '
        Me.PalabrasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuenteYTamañoToolStripMenuItem, Me.ColorToolStripMenuItem, Me.PosiciónToolStripMenuItem})
        Me.PalabrasToolStripMenuItem.Name = "PalabrasToolStripMenuItem"
        Me.PalabrasToolStripMenuItem.Size = New System.Drawing.Size(183, 24)
        Me.PalabrasToolStripMenuItem.Text = "Palabras"
        '
        'FuenteYTamañoToolStripMenuItem
        '
        Me.FuenteYTamañoToolStripMenuItem.Name = "FuenteYTamañoToolStripMenuItem"
        Me.FuenteYTamañoToolStripMenuItem.Size = New System.Drawing.Size(182, 24)
        Me.FuenteYTamañoToolStripMenuItem.Text = "Fuente y Tamaño"
        '
        'ColorToolStripMenuItem
        '
        Me.ColorToolStripMenuItem.Name = "ColorToolStripMenuItem"
        Me.ColorToolStripMenuItem.Size = New System.Drawing.Size(182, 24)
        Me.ColorToolStripMenuItem.Text = "Color"
        '
        'PosiciónToolStripMenuItem
        '
        Me.PosiciónToolStripMenuItem.Name = "PosiciónToolStripMenuItem"
        Me.PosiciónToolStripMenuItem.Size = New System.Drawing.Size(182, 24)
        Me.PosiciónToolStripMenuItem.Text = "Posición"
        '
        'RelojToolStripMenuItem
        '
        Me.RelojToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FuenteYTamañoToolStripMenuItem1, Me.ColorToolStripMenuItem1, Me.PosiciónToolStripMenuItem1})
        Me.RelojToolStripMenuItem.Name = "RelojToolStripMenuItem"
        Me.RelojToolStripMenuItem.Size = New System.Drawing.Size(183, 24)
        Me.RelojToolStripMenuItem.Text = "Reloj"
        '
        'FuenteYTamañoToolStripMenuItem1
        '
        Me.FuenteYTamañoToolStripMenuItem1.Name = "FuenteYTamañoToolStripMenuItem1"
        Me.FuenteYTamañoToolStripMenuItem1.Size = New System.Drawing.Size(182, 24)
        Me.FuenteYTamañoToolStripMenuItem1.Text = "Fuente y Tamaño"
        '
        'ColorToolStripMenuItem1
        '
        Me.ColorToolStripMenuItem1.Name = "ColorToolStripMenuItem1"
        Me.ColorToolStripMenuItem1.Size = New System.Drawing.Size(182, 24)
        Me.ColorToolStripMenuItem1.Text = "Color"
        '
        'PosiciónToolStripMenuItem1
        '
        Me.PosiciónToolStripMenuItem1.Name = "PosiciónToolStripMenuItem1"
        Me.PosiciónToolStripMenuItem1.Size = New System.Drawing.Size(182, 24)
        Me.PosiciónToolStripMenuItem1.Text = "Posición"
        '
        'VentanaPrincipalToolStripMenuItem
        '
        Me.VentanaPrincipalToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ModoVentanaToolStripMenuItem, Me.ModoPantallaCompletaToolStripMenuItem, Me.FondoDePantallaToolStripMenuItem})
        Me.VentanaPrincipalToolStripMenuItem.Name = "VentanaPrincipalToolStripMenuItem"
        Me.VentanaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(183, 24)
        Me.VentanaPrincipalToolStripMenuItem.Text = "Ventana Principal"
        '
        'ModoVentanaToolStripMenuItem
        '
        Me.ModoVentanaToolStripMenuItem.Name = "ModoVentanaToolStripMenuItem"
        Me.ModoVentanaToolStripMenuItem.Size = New System.Drawing.Size(230, 24)
        Me.ModoVentanaToolStripMenuItem.Text = "Modo Ventana"
        '
        'ModoPantallaCompletaToolStripMenuItem
        '
        Me.ModoPantallaCompletaToolStripMenuItem.Name = "ModoPantallaCompletaToolStripMenuItem"
        Me.ModoPantallaCompletaToolStripMenuItem.Size = New System.Drawing.Size(230, 24)
        Me.ModoPantallaCompletaToolStripMenuItem.Text = "Modo Pantalla Completa"
        '
        'FondoDePantallaToolStripMenuItem
        '
        Me.FondoDePantallaToolStripMenuItem.Name = "FondoDePantallaToolStripMenuItem"
        Me.FondoDePantallaToolStripMenuItem.Size = New System.Drawing.Size(230, 24)
        Me.FondoDePantallaToolStripMenuItem.Text = "Fondo de Pantalla"
        '
        'ReestablecerPersonalizaciónToolStripMenuItem
        '
        Me.ReestablecerPersonalizaciónToolStripMenuItem.Name = "ReestablecerPersonalizaciónToolStripMenuItem"
        Me.ReestablecerPersonalizaciónToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.ReestablecerPersonalizaciónToolStripMenuItem.Text = "Reestablecer Personalización"
        '
        'MostrarPantallaPrincipalToolStripMenuItem
        '
        Me.MostrarPantallaPrincipalToolStripMenuItem.Name = "MostrarPantallaPrincipalToolStripMenuItem"
        Me.MostrarPantallaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(177, 23)
        Me.MostrarPantallaPrincipalToolStripMenuItem.Text = "Mostrar Pantalla Principal"
        '
        'SobreHazteUnFreeAAPToolStripMenuItem
        '
        Me.SobreHazteUnFreeAAPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GithubToolStripMenuItem, Me.DIscordToolStripMenuItem})
        Me.SobreHazteUnFreeAAPToolStripMenuItem.Name = "SobreHazteUnFreeAAPToolStripMenuItem"
        Me.SobreHazteUnFreeAAPToolStripMenuItem.Size = New System.Drawing.Size(139, 23)
        Me.SobreHazteUnFreeAAPToolStripMenuItem.Text = "Sobre HazteUnFree"
        '
        'GithubToolStripMenuItem
        '
        Me.GithubToolStripMenuItem.Name = "GithubToolStripMenuItem"
        Me.GithubToolStripMenuItem.Size = New System.Drawing.Size(124, 24)
        Me.GithubToolStripMenuItem.Text = "Github"
        '
        'DIscordToolStripMenuItem
        '
        Me.DIscordToolStripMenuItem.Name = "DIscordToolStripMenuItem"
        Me.DIscordToolStripMenuItem.Size = New System.Drawing.Size(124, 24)
        Me.DIscordToolStripMenuItem.Text = "Discord"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 26)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(492, 385)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Música y Diccionarios"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDepureDic)
        Me.GroupBox1.Controls.Add(Me.ListBoxDictionaries)
        Me.GroupBox1.Controls.Add(Me.chkShuffle)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 187)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Diccionarios"
        '
        'ListBoxDictionaries
        '
        Me.ListBoxDictionaries.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListBoxDictionaries.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBoxDictionaries.CheckOnClick = true
        Me.ListBoxDictionaries.ColumnWidth = 250
        Me.ListBoxDictionaries.Font = New System.Drawing.Font("Segoe UI", 9!)
        Me.ListBoxDictionaries.FormattingEnabled = true
        Me.ListBoxDictionaries.Location = New System.Drawing.Point(21, 29)
        Me.ListBoxDictionaries.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListBoxDictionaries.MultiColumn = true
        Me.ListBoxDictionaries.Name = "ListBoxDictionaries"
        Me.ListBoxDictionaries.Size = New System.Drawing.Size(427, 72)
        Me.ListBoxDictionaries.TabIndex = 35
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkSoundFx)
        Me.GroupBox4.Controls.Add(Me.tbmusicdir)
        Me.GroupBox4.Controls.Add(Me.btmusicdir)
        Me.GroupBox4.Controls.Add(Me.chPlayMusic)
        Me.GroupBox4.Location = New System.Drawing.Point(20, 18)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(457, 122)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Música"
        '
        'chkSoundFx
        '
        Me.chkSoundFx.AutoSize = true
        Me.chkSoundFx.Location = New System.Drawing.Point(19, 76)
        Me.chkSoundFx.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkSoundFx.Name = "chkSoundFx"
        Me.chkSoundFx.Size = New System.Drawing.Size(303, 23)
        Me.chkSoundFx.TabIndex = 52
        Me.chkSoundFx.Text = "Reproducir SoundFx.mp3 al finalizar la batalla"
        Me.chkSoundFx.UseVisualStyleBackColor = true
        '
        'tbmusicdir
        '
        Me.tbmusicdir.Location = New System.Drawing.Point(19, 47)
        Me.tbmusicdir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tbmusicdir.Name = "tbmusicdir"
        Me.tbmusicdir.Size = New System.Drawing.Size(318, 25)
        Me.tbmusicdir.TabIndex = 51
        '
        'btmusicdir
        '
        Me.btmusicdir.BackColor = System.Drawing.Color.Gainsboro
        Me.btmusicdir.Location = New System.Drawing.Point(343, 42)
        Me.btmusicdir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btmusicdir.Name = "btmusicdir"
        Me.btmusicdir.Size = New System.Drawing.Size(105, 32)
        Me.btmusicdir.TabIndex = 49
        Me.btmusicdir.Text = "Examinar..."
        Me.btmusicdir.UseVisualStyleBackColor = false
        '
        'chPlayMusic
        '
        Me.chPlayMusic.AutoSize = true
        Me.chPlayMusic.Location = New System.Drawing.Point(19, 22)
        Me.chPlayMusic.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chPlayMusic.Name = "chPlayMusic"
        Me.chPlayMusic.Size = New System.Drawing.Size(140, 23)
        Me.chPlayMusic.TabIndex = 47
        Me.chPlayMusic.Text = "Reproducir música"
        Me.chPlayMusic.UseVisualStyleBackColor = true
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage1.Controls.Add(Me.chkMinimize)
        Me.TabPage1.Controls.Add(Me.TabMode)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(492, 385)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Batalla"
        '
        'btStopBattle
        '
        Me.btStopBattle.BackColor = System.Drawing.Color.Gainsboro
        Me.btStopBattle.Enabled = false
        Me.btStopBattle.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btStopBattle.Location = New System.Drawing.Point(10, 461)
        Me.btStopBattle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btStopBattle.Name = "btStopBattle"
        Me.btStopBattle.Size = New System.Drawing.Size(495, 45)
        Me.btStopBattle.TabIndex = 40
        Me.btStopBattle.Text = "PARAR BATALLA"
        Me.btStopBattle.UseVisualStyleBackColor = false
        '
        'btStartWords
        '
        Me.btStartWords.BackColor = System.Drawing.Color.Gainsboro
        Me.btStartWords.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btStartWords.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btStartWords.Location = New System.Drawing.Point(28, 33)
        Me.btStartWords.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btStartWords.Name = "btStartWords"
        Me.btStartWords.Size = New System.Drawing.Size(162, 45)
        Me.btStartWords.TabIndex = 33
        Me.btStartWords.Text = "COMENZAR BATALLA"
        Me.btStartWords.UseVisualStyleBackColor = false
        '
        'BtStartBattle
        '
        Me.BtStartBattle.BackColor = System.Drawing.Color.Gainsboro
        Me.BtStartBattle.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.BtStartBattle.Location = New System.Drawing.Point(103, 33)
        Me.BtStartBattle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtStartBattle.Name = "BtStartBattle"
        Me.BtStartBattle.Size = New System.Drawing.Size(234, 45)
        Me.BtStartBattle.TabIndex = 39
        Me.BtStartBattle.Text = "COMENZAR BATALLA"
        Me.BtStartBattle.UseVisualStyleBackColor = false
        '
        'cbMusicList
        '
        Me.cbMusicList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cbMusicList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMusicList.FormattingEnabled = true
        Me.cbMusicList.Items.AddRange(New Object() {"Easy Mode (10)", "Hard Mode (5)", "Extreme Mode (2)", "4 Words each 10''"})
        Me.cbMusicList.Location = New System.Drawing.Point(11, 108)
        Me.cbMusicList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbMusicList.Name = "cbMusicList"
        Me.cbMusicList.Size = New System.Drawing.Size(432, 25)
        Me.cbMusicList.TabIndex = 32
        '
        'chkMinimize
        '
        Me.chkMinimize.AutoSize = true
        Me.chkMinimize.Location = New System.Drawing.Point(23, 341)
        Me.chkMinimize.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkMinimize.Name = "chkMinimize"
        Me.chkMinimize.Size = New System.Drawing.Size(430, 23)
        Me.chkMinimize.TabIndex = 40
        Me.chkMinimize.Text = "Modo Una Pantalla: Minimizar esta ventana al comenzar la batalla"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkMinimize.UseVisualStyleBackColor = true
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8!)
        Me.Label2.Location = New System.Drawing.Point(100, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(254, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Iniciar palabras tras los primeros          segundos"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.CbBattleType)
        Me.Panel3.Controls.Add(Me.lblBattleType)
        Me.Panel3.Controls.Add(Me.CbDuration)
        Me.Panel3.Controls.Add(Me.cbMusicList)
        Me.Panel3.Controls.Add(Me.chshufflemusic)
        Me.Panel3.Location = New System.Drawing.Point(12, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(466, 152)
        Me.Panel3.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(321, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 19)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Duración"
        '
        'TabBattle
        '
        Me.TabBattle.Controls.Add(Me.TabPage1)
        Me.TabBattle.Controls.Add(Me.TabPage3)
        Me.TabBattle.Location = New System.Drawing.Point(10, 38)
        Me.TabBattle.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabBattle.Name = "TabBattle"
        Me.TabBattle.SelectedIndex = 0
        Me.TabBattle.Size = New System.Drawing.Size(500, 415)
        Me.TabBattle.TabIndex = 1
        '
        'LbCountDown
        '
        Me.LbCountDown.AutoSize = true
        Me.LbCountDown.Font = New System.Drawing.Font("Segoe UI", 20!)
        Me.LbCountDown.Location = New System.Drawing.Point(3, 3)
        Me.LbCountDown.Name = "LbCountDown"
        Me.LbCountDown.Size = New System.Drawing.Size(47, 37)
        Me.LbCountDown.TabIndex = 0
        Me.LbCountDown.Text = "00"
        Me.LbCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LbWord
        '
        Me.LbWord.BackColor = System.Drawing.Color.Transparent
        Me.LbWord.Cursor = System.Windows.Forms.Cursors.Default
        Me.LbWord.Location = New System.Drawing.Point(64, 3)
        Me.LbWord.Name = "LbWord"
        Me.LbWord.Size = New System.Drawing.Size(432, 37)
        Me.LbWord.TabIndex = 43
        Me.LbWord.Text = "HazteUnFree"
        Me.LbWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LbWord)
        Me.Panel1.Controls.Add(Me.LbCountDown)
        Me.Panel1.Location = New System.Drawing.Point(14, 651)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 40)
        Me.Panel1.TabIndex = 44
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button3.Location = New System.Drawing.Point(227, 36)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(188, 45)
        Me.Button3.TabIndex = 41
        Me.Button3.Text = "COMENZAR PALABRAS"
        Me.Button3.UseVisualStyleBackColor = false
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Button4.Location = New System.Drawing.Point(27, 36)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(183, 45)
        Me.Button4.TabIndex = 40
        Me.Button4.Text = "COMENZAR INSTRUMENTAL"
        Me.Button4.UseVisualStyleBackColor = false
        '
        'TabMode
        '
        Me.TabMode.Controls.Add(Me.TabPage2)
        Me.TabMode.Controls.Add(Me.TabPage4)
        Me.TabMode.Controls.Add(Me.TabPage5)
        Me.TabMode.Location = New System.Drawing.Point(12, 178)
        Me.TabMode.Name = "TabMode"
        Me.TabMode.SelectedIndex = 0
        Me.TabMode.Size = New System.Drawing.Size(466, 156)
        Me.TabMode.TabIndex = 50
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Controls.Add(Me.TbWordsWaittoStart)
        Me.TabPage2.Controls.Add(Me.BtStartBattle)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(458, 126)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "Modo Automático"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage4.Controls.Add(Me.Button3)
        Me.TabPage4.Controls.Add(Me.Button4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 26)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(455, 126)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Modo Semi-Automático"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage5.Controls.Add(Me.btNextWord)
        Me.TabPage5.Controls.Add(Me.btStartWords)
        Me.TabPage5.Location = New System.Drawing.Point(4, 26)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(455, 126)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Modo Manual"
        '
        'ControlModule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96!, 96!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(517, 695)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btStopBattle)
        Me.Controls.Add(Me.TabBattle)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tbUserLog)
        Me.Font = New System.Drawing.Font("Segoe UI", 10!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = false
        Me.Name = "ControlModule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control - HazteUnFree - Versión 1.0.1"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.TabPage3.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.TabPage1.ResumeLayout(false)
        Me.TabPage1.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.TabBattle.ResumeLayout(false)
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.TabMode.ResumeLayout(false)
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        Me.TabPage4.ResumeLayout(false)
        Me.TabPage5.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

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
    Friend WithEvents SobreHazteUnFreeAAPToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents TbWordsWaittoStart As TextBox
    Friend WithEvents btStartWords As Button
    Friend WithEvents chkShuffle As CheckBox
    Friend WithEvents ListBoxDictionaries As CheckedListBox
    Friend WithEvents cbMusicList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CbDuration As ComboBox
    Friend WithEvents lblBattleType As Label
    Friend WithEvents CbBattleType As ComboBox
    Friend WithEvents TabBattle As TabControl
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PosiciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PosiciónToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents chkMinimize As CheckBox
    Friend WithEvents chkSoundFx As CheckBox
    Friend WithEvents LbCountDown As Label
    Public WithEvents LbWord As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents chkDepureDic As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DIscordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TimerWait As Timer
    Friend WithEvents ReestablecerPersonalizaciónToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents TabMode As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
End Class
