<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManejo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManejo))
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.pUbicaciones = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.pBotones = New System.Windows.Forms.Panel()
        Me.btnCambiarH = New System.Windows.Forms.Button()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.btnServicio = New System.Windows.Forms.Button()
        Me.btnHabitacion = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pcontra = New System.Windows.Forms.Panel()
        Me.lblidusuario = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblidcliente = New System.Windows.Forms.Label()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnborra = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHabitacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pHab = New System.Windows.Forms.Panel()
        Me.psuperior.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pBotones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pcontra.SuspendLayout()
        Me.SuspendLayout()
        '
        'psuperior
        '
        Me.psuperior.BackColor = System.Drawing.Color.SteelBlue
        Me.psuperior.Controls.Add(Me.pUbicaciones)
        Me.psuperior.Controls.Add(Me.Panel3)
        Me.psuperior.Controls.Add(Me.pBotones)
        Me.psuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.psuperior.Location = New System.Drawing.Point(0, 0)
        Me.psuperior.Name = "psuperior"
        Me.psuperior.Size = New System.Drawing.Size(1181, 100)
        Me.psuperior.TabIndex = 0
        '
        'pUbicaciones
        '
        Me.pUbicaciones.BackColor = System.Drawing.Color.SteelBlue
        Me.pUbicaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pUbicaciones.Location = New System.Drawing.Point(159, 0)
        Me.pUbicaciones.Name = "pUbicaciones"
        Me.pUbicaciones.Size = New System.Drawing.Size(439, 100)
        Me.pUbicaciones.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.Controls.Add(Me.piclogo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(159, 100)
        Me.Panel3.TabIndex = 5
        '
        'piclogo
        '
        Me.piclogo.BackColor = System.Drawing.Color.White
        Me.piclogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.piclogo.Location = New System.Drawing.Point(0, 0)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(159, 100)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.piclogo.TabIndex = 0
        Me.piclogo.TabStop = False
        '
        'pBotones
        '
        Me.pBotones.BackColor = System.Drawing.Color.SteelBlue
        Me.pBotones.Controls.Add(Me.btnCambiarH)
        Me.pBotones.Controls.Add(Me.btnPagar)
        Me.pBotones.Controls.Add(Me.btnServicio)
        Me.pBotones.Controls.Add(Me.btnHabitacion)
        Me.pBotones.Controls.Add(Me.btnSalir)
        Me.pBotones.Controls.Add(Me.btnLimpiar)
        Me.pBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pBotones.Location = New System.Drawing.Point(598, 0)
        Me.pBotones.Name = "pBotones"
        Me.pBotones.Size = New System.Drawing.Size(583, 100)
        Me.pBotones.TabIndex = 4
        '
        'btnCambiarH
        '
        Me.btnCambiarH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCambiarH.BackColor = System.Drawing.Color.White
        Me.btnCambiarH.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCambiarH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarH.Image = CType(resources.GetObject("btnCambiarH.Image"), System.Drawing.Image)
        Me.btnCambiarH.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCambiarH.Location = New System.Drawing.Point(110, 12)
        Me.btnCambiarH.Name = "btnCambiarH"
        Me.btnCambiarH.Size = New System.Drawing.Size(88, 80)
        Me.btnCambiarH.TabIndex = 7
        Me.btnCambiarH.Text = "Cambio Habitación"
        Me.btnCambiarH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCambiarH.UseVisualStyleBackColor = False
        '
        'btnPagar
        '
        Me.btnPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPagar.BackColor = System.Drawing.Color.White
        Me.btnPagar.Enabled = False
        Me.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagar.Image = CType(resources.GetObject("btnPagar.Image"), System.Drawing.Image)
        Me.btnPagar.Location = New System.Drawing.Point(205, 12)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(88, 80)
        Me.btnPagar.TabIndex = 6
        Me.btnPagar.Text = "Cobro"
        Me.btnPagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPagar.UseVisualStyleBackColor = False
        '
        'btnServicio
        '
        Me.btnServicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnServicio.BackColor = System.Drawing.Color.White
        Me.btnServicio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnServicio.Image = CType(resources.GetObject("btnServicio.Image"), System.Drawing.Image)
        Me.btnServicio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnServicio.Location = New System.Drawing.Point(300, 12)
        Me.btnServicio.Name = "btnServicio"
        Me.btnServicio.Size = New System.Drawing.Size(88, 80)
        Me.btnServicio.TabIndex = 5
        Me.btnServicio.Text = "Servicio"
        Me.btnServicio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnServicio.UseVisualStyleBackColor = False
        '
        'btnHabitacion
        '
        Me.btnHabitacion.BackColor = System.Drawing.Color.White
        Me.btnHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnHabitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHabitacion.Image = CType(resources.GetObject("btnHabitacion.Image"), System.Drawing.Image)
        Me.btnHabitacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnHabitacion.Location = New System.Drawing.Point(6, 12)
        Me.btnHabitacion.Name = "btnHabitacion"
        Me.btnHabitacion.Size = New System.Drawing.Size(97, 80)
        Me.btnHabitacion.TabIndex = 1
        Me.btnHabitacion.Text = "Habitaciones"
        Me.btnHabitacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHabitacion.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(490, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(88, 80)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(395, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(88, 80)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pcontra)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(988, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(193, 726)
        Me.Panel2.TabIndex = 1
        '
        'pcontra
        '
        Me.pcontra.Controls.Add(Me.lblidusuario)
        Me.pcontra.Controls.Add(Me.Label9)
        Me.pcontra.Controls.Add(Me.Label8)
        Me.pcontra.Controls.Add(Me.Label7)
        Me.pcontra.Controls.Add(Me.lblidcliente)
        Me.pcontra.Controls.Add(Me.lblcliente)
        Me.pcontra.Controls.Add(Me.Label6)
        Me.pcontra.Controls.Add(Me.Label5)
        Me.pcontra.Controls.Add(Me.Label1)
        Me.pcontra.Controls.Add(Me.lblusuario)
        Me.pcontra.Controls.Add(Me.Label4)
        Me.pcontra.Controls.Add(Me.btnok)
        Me.pcontra.Controls.Add(Me.btn0)
        Me.pcontra.Controls.Add(Me.btnborra)
        Me.pcontra.Controls.Add(Me.btn9)
        Me.pcontra.Controls.Add(Me.btn8)
        Me.pcontra.Controls.Add(Me.btn7)
        Me.pcontra.Controls.Add(Me.btn6)
        Me.pcontra.Controls.Add(Me.btn5)
        Me.pcontra.Controls.Add(Me.btn4)
        Me.pcontra.Controls.Add(Me.btn3)
        Me.pcontra.Controls.Add(Me.btn2)
        Me.pcontra.Controls.Add(Me.btn1)
        Me.pcontra.Controls.Add(Me.txtpass)
        Me.pcontra.Controls.Add(Me.Label3)
        Me.pcontra.Controls.Add(Me.txtHabitacion)
        Me.pcontra.Controls.Add(Me.Label2)
        Me.pcontra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pcontra.Location = New System.Drawing.Point(0, 0)
        Me.pcontra.Name = "pcontra"
        Me.pcontra.Size = New System.Drawing.Size(193, 726)
        Me.pcontra.TabIndex = 3
        '
        'lblidusuario
        '
        Me.lblidusuario.BackColor = System.Drawing.Color.Silver
        Me.lblidusuario.Location = New System.Drawing.Point(101, 560)
        Me.lblidusuario.Name = "lblidusuario"
        Me.lblidusuario.Size = New System.Drawing.Size(85, 20)
        Me.lblidusuario.TabIndex = 121
        Me.lblidusuario.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Yellow
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(5, 443)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 20)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Ventilación"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Aqua
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(106, 383)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 20)
        Me.Label8.TabIndex = 119
        Me.Label8.Text = "Limpieza"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(6, 414)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 20)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Mantenimiento"
        '
        'lblidcliente
        '
        Me.lblidcliente.BackColor = System.Drawing.Color.LightGray
        Me.lblidcliente.Location = New System.Drawing.Point(7, 504)
        Me.lblidcliente.Name = "lblidcliente"
        Me.lblidcliente.Size = New System.Drawing.Size(100, 23)
        Me.lblidcliente.TabIndex = 117
        Me.lblidcliente.Visible = False
        '
        'lblcliente
        '
        Me.lblcliente.BackColor = System.Drawing.Color.LightGray
        Me.lblcliente.Location = New System.Drawing.Point(5, 472)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(180, 23)
        Me.lblcliente.TabIndex = 116
        Me.lblcliente.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(6, 383)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 20)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Reservada"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(104, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Ocupada"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Disponible"
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.SteelBlue
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(6, 318)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(179, 24)
        Me.lblusuario.TabIndex = 112
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 23)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "USUARIO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.White
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnok.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.Location = New System.Drawing.Point(130, 252)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(56, 40)
        Me.btnok.TabIndex = 110
        Me.btnok.Text = "INTRO"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn0.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(68, 252)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(56, 40)
        Me.btn0.TabIndex = 109
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnborra
        '
        Me.btnborra.BackColor = System.Drawing.Color.White
        Me.btnborra.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnborra.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnborra.Location = New System.Drawing.Point(6, 252)
        Me.btnborra.Name = "btnborra"
        Me.btnborra.Size = New System.Drawing.Size(56, 40)
        Me.btnborra.TabIndex = 108
        Me.btnborra.Text = "RETRO"
        Me.btnborra.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn9.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(128, 116)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(58, 40)
        Me.btn9.TabIndex = 107
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn8.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(67, 116)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(56, 40)
        Me.btn8.TabIndex = 106
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn7.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(6, 117)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(56, 40)
        Me.btn7.TabIndex = 105
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn6.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(130, 162)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(56, 40)
        Me.btn6.TabIndex = 104
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn5.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(68, 162)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(56, 40)
        Me.btn5.TabIndex = 103
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn4.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(6, 162)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(56, 40)
        Me.btn4.TabIndex = 102
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(130, 208)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(56, 40)
        Me.btn3.TabIndex = 101
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(68, 208)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(56, 40)
        Me.btn2.TabIndex = 100
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(6, 208)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(56, 40)
        Me.btn1.TabIndex = 99
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'txtpass
        '
        Me.txtpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.Location = New System.Drawing.Point(6, 89)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.Size = New System.Drawing.Size(180, 22)
        Me.txtpass.TabIndex = 88
        Me.txtpass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 23)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "CLAVE DE USUARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtHabitacion
        '
        Me.txtHabitacion.BackColor = System.Drawing.SystemColors.Window
        Me.txtHabitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHabitacion.Location = New System.Drawing.Point(6, 38)
        Me.txtHabitacion.Name = "txtHabitacion"
        Me.txtHabitacion.Size = New System.Drawing.Size(180, 22)
        Me.txtHabitacion.TabIndex = 86
        Me.txtHabitacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 23)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "N° HABITACIÓN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pHab
        '
        Me.pHab.BackColor = System.Drawing.Color.LightCyan
        Me.pHab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pHab.Location = New System.Drawing.Point(0, 100)
        Me.pHab.Name = "pHab"
        Me.pHab.Size = New System.Drawing.Size(988, 726)
        Me.pHab.TabIndex = 4
        '
        'frmManejo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1181, 826)
        Me.Controls.Add(Me.pHab)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.psuperior)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmManejo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administración"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.psuperior.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pBotones.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pcontra.ResumeLayout(False)
        Me.pcontra.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents psuperior As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pcontra As Panel
    Friend WithEvents lblidusuario As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblidcliente As Label
    Friend WithEvents lblcliente As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnok As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnborra As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents txtpass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtHabitacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pBotones As Panel
    Friend WithEvents btnCambiarH As Button
    Friend WithEvents btnPagar As Button
    Friend WithEvents btnServicio As Button
    Friend WithEvents btnHabitacion As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents piclogo As PictureBox
    Friend WithEvents pHab As Panel
    Friend WithEvents pUbicaciones As Panel
End Class
