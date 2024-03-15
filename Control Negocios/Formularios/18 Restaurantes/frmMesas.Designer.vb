<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMesas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMesas))
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.parea = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btncambiar = New System.Windows.Forms.Button()
        Me.btnjuntar = New System.Windows.Forms.Button()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.btncobro = New System.Windows.Forms.Button()
        Me.btnconsulta = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMesa = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNComensales = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbltotalmesa = New System.Windows.Forms.Label()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.btntemporales = New System.Windows.Forms.Button()
        Me.psuperior.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'psuperior
        '
        Me.psuperior.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.psuperior.Controls.Add(Me.parea)
        Me.psuperior.Controls.Add(Me.Panel1)
        Me.psuperior.Controls.Add(Me.Panel5)
        Me.psuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.psuperior.Location = New System.Drawing.Point(0, 0)
        Me.psuperior.Name = "psuperior"
        Me.psuperior.Size = New System.Drawing.Size(1372, 104)
        Me.psuperior.TabIndex = 0
        '
        'parea
        '
        Me.parea.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.parea.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.parea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.parea.Location = New System.Drawing.Point(186, 0)
        Me.parea.Name = "parea"
        Me.parea.Size = New System.Drawing.Size(531, 104)
        Me.parea.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.ForeColor = System.Drawing.Color.CadetBlue
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(186, 104)
        Me.Panel1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(186, 104)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Controls.Add(Me.btntemporales)
        Me.Panel5.Controls.Add(Me.btncambiar)
        Me.Panel5.Controls.Add(Me.btnjuntar)
        Me.Panel5.Controls.Add(Me.btnagregar)
        Me.Panel5.Controls.Add(Me.btncobro)
        Me.Panel5.Controls.Add(Me.btnconsulta)
        Me.Panel5.Controls.Add(Me.btnLimpiar)
        Me.Panel5.Controls.Add(Me.btnSalir)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(717, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(655, 104)
        Me.Panel5.TabIndex = 3
        '
        'btncambiar
        '
        Me.btncambiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btncambiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btncambiar.FlatAppearance.BorderSize = 0
        Me.btncambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncambiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncambiar.ForeColor = System.Drawing.Color.Black
        Me.btncambiar.Image = CType(resources.GetObject("btncambiar.Image"), System.Drawing.Image)
        Me.btncambiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncambiar.Location = New System.Drawing.Point(101, 0)
        Me.btncambiar.Name = "btncambiar"
        Me.btncambiar.Size = New System.Drawing.Size(81, 104)
        Me.btncambiar.TabIndex = 21
        Me.btncambiar.Text = "Cambio de mesa"
        Me.btncambiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncambiar.UseVisualStyleBackColor = False
        '
        'btnjuntar
        '
        Me.btnjuntar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnjuntar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnjuntar.FlatAppearance.BorderSize = 0
        Me.btnjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnjuntar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnjuntar.ForeColor = System.Drawing.Color.Black
        Me.btnjuntar.Image = CType(resources.GetObject("btnjuntar.Image"), System.Drawing.Image)
        Me.btnjuntar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnjuntar.Location = New System.Drawing.Point(182, 0)
        Me.btnjuntar.Name = "btnjuntar"
        Me.btnjuntar.Size = New System.Drawing.Size(71, 104)
        Me.btnjuntar.TabIndex = 20
        Me.btnjuntar.Text = "Juntar mesas"
        Me.btnjuntar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnjuntar.UseVisualStyleBackColor = False
        '
        'btnagregar
        '
        Me.btnagregar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnagregar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnagregar.FlatAppearance.BorderSize = 0
        Me.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnagregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregar.ForeColor = System.Drawing.Color.Black
        Me.btnagregar.Image = CType(resources.GetObject("btnagregar.Image"), System.Drawing.Image)
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnagregar.Location = New System.Drawing.Point(253, 0)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(88, 104)
        Me.btnagregar.TabIndex = 19
        Me.btnagregar.Text = "Agregar mesa"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnagregar.UseVisualStyleBackColor = False
        '
        'btncobro
        '
        Me.btncobro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btncobro.Dock = System.Windows.Forms.DockStyle.Right
        Me.btncobro.FlatAppearance.BorderSize = 0
        Me.btncobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncobro.ForeColor = System.Drawing.Color.Black
        Me.btncobro.Image = CType(resources.GetObject("btncobro.Image"), System.Drawing.Image)
        Me.btncobro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncobro.Location = New System.Drawing.Point(341, 0)
        Me.btncobro.Name = "btncobro"
        Me.btncobro.Size = New System.Drawing.Size(80, 104)
        Me.btncobro.TabIndex = 18
        Me.btncobro.Text = "Cobro"
        Me.btncobro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncobro.UseVisualStyleBackColor = False
        '
        'btnconsulta
        '
        Me.btnconsulta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnconsulta.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnconsulta.Enabled = False
        Me.btnconsulta.FlatAppearance.BorderSize = 0
        Me.btnconsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnconsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnconsulta.ForeColor = System.Drawing.Color.Black
        Me.btnconsulta.Image = CType(resources.GetObject("btnconsulta.Image"), System.Drawing.Image)
        Me.btnconsulta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnconsulta.Location = New System.Drawing.Point(421, 0)
        Me.btnconsulta.Name = "btnconsulta"
        Me.btnconsulta.Size = New System.Drawing.Size(80, 104)
        Me.btnconsulta.TabIndex = 17
        Me.btnconsulta.Text = "Consulta"
        Me.btnconsulta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnconsulta.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(501, 0)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 104)
        Me.btnLimpiar.TabIndex = 16
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(581, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(74, 104)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblusuario)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.btnok)
        Me.Panel2.Controls.Add(Me.btn0)
        Me.Panel2.Controls.Add(Me.btnborra)
        Me.Panel2.Controls.Add(Me.btn9)
        Me.Panel2.Controls.Add(Me.btn8)
        Me.Panel2.Controls.Add(Me.btn7)
        Me.Panel2.Controls.Add(Me.btn6)
        Me.Panel2.Controls.Add(Me.btn5)
        Me.Panel2.Controls.Add(Me.btn4)
        Me.Panel2.Controls.Add(Me.btn3)
        Me.Panel2.Controls.Add(Me.btn2)
        Me.Panel2.Controls.Add(Me.btn1)
        Me.Panel2.Controls.Add(Me.txtUsuario)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtMesa)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtNComensales)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(1180, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 640)
        Me.Panel2.TabIndex = 1
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.SteelBlue
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(6, 371)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(181, 24)
        Me.lblusuario.TabIndex = 100
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 348)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(180, 23)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "USUARIO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.White
        Me.btnok.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnok.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.Location = New System.Drawing.Point(130, 305)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(56, 40)
        Me.btnok.TabIndex = 98
        Me.btnok.Text = "INTRO"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn0.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(68, 305)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(56, 40)
        Me.btn0.TabIndex = 97
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnborra
        '
        Me.btnborra.BackColor = System.Drawing.Color.White
        Me.btnborra.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnborra.Font = New System.Drawing.Font("Segoe UI Emoji", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnborra.Location = New System.Drawing.Point(6, 305)
        Me.btnborra.Name = "btnborra"
        Me.btnborra.Size = New System.Drawing.Size(56, 40)
        Me.btnborra.TabIndex = 96
        Me.btnborra.Text = "RETRO"
        Me.btnborra.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn9.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(128, 169)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(58, 40)
        Me.btn9.TabIndex = 95
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn8.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(67, 169)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(56, 40)
        Me.btn8.TabIndex = 94
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn7.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(6, 170)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(56, 40)
        Me.btn7.TabIndex = 93
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn6.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(130, 215)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(56, 40)
        Me.btn6.TabIndex = 92
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn5.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(68, 215)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(56, 40)
        Me.btn5.TabIndex = 91
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn4.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(6, 215)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(56, 40)
        Me.btn4.TabIndex = 90
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(130, 261)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(56, 40)
        Me.btn3.TabIndex = 89
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(68, 261)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(56, 40)
        Me.btn2.TabIndex = 88
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1.Font = New System.Drawing.Font("Segoe UI Emoji", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(6, 261)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(56, 40)
        Me.btn1.TabIndex = 87
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'txtUsuario
        '
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(6, 142)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(180, 22)
        Me.txtUsuario.TabIndex = 86
        Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(180, 23)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "CLAVE DE USUARIO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMesa
        '
        Me.txtMesa.BackColor = System.Drawing.SystemColors.Window
        Me.txtMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesa.Location = New System.Drawing.Point(6, 91)
        Me.txtMesa.Name = "txtMesa"
        Me.txtMesa.Size = New System.Drawing.Size(180, 22)
        Me.txtMesa.TabIndex = 84
        Me.txtMesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 23)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "NOMBRE DE LA MESA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNComensales
        '
        Me.txtNComensales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNComensales.Location = New System.Drawing.Point(6, 40)
        Me.txtNComensales.Name = "txtNComensales"
        Me.txtNComensales.Size = New System.Drawing.Size(180, 22)
        Me.txtNComensales.TabIndex = 82
        Me.txtNComensales.Text = "1"
        Me.txtNComensales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 23)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "TOTAL DE COMENSALES"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Panel6.Controls.Add(Me.lbltotalmesa)
        Me.Panel6.Controls.Add(Me.lblfolio)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 406)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(192, 234)
        Me.Panel6.TabIndex = 0
        '
        'lbltotalmesa
        '
        Me.lbltotalmesa.BackColor = System.Drawing.Color.Gainsboro
        Me.lbltotalmesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalmesa.Location = New System.Drawing.Point(6, 202)
        Me.lbltotalmesa.Name = "lbltotalmesa"
        Me.lbltotalmesa.Size = New System.Drawing.Size(61, 23)
        Me.lbltotalmesa.TabIndex = 38
        Me.lbltotalmesa.Text = "0.00"
        Me.lbltotalmesa.Visible = False
        '
        'lblfolio
        '
        Me.lblfolio.BackColor = System.Drawing.Color.Gainsboro
        Me.lblfolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolio.Location = New System.Drawing.Point(3, 179)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(61, 23)
        Me.lblfolio.TabIndex = 37
        Me.lblfolio.Visible = False
        '
        'pmesas
        '
        Me.pmesas.BackColor = System.Drawing.Color.White
        Me.pmesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pmesas.Location = New System.Drawing.Point(0, 104)
        Me.pmesas.Name = "pmesas"
        Me.pmesas.Size = New System.Drawing.Size(1180, 640)
        Me.pmesas.TabIndex = 3
        '
        'btntemporales
        '
        Me.btntemporales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btntemporales.Dock = System.Windows.Forms.DockStyle.Right
        Me.btntemporales.FlatAppearance.BorderSize = 0
        Me.btntemporales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntemporales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntemporales.ForeColor = System.Drawing.Color.Black
        Me.btntemporales.Image = CType(resources.GetObject("btntemporales.Image"), System.Drawing.Image)
        Me.btntemporales.Location = New System.Drawing.Point(1, 0)
        Me.btntemporales.Name = "btntemporales"
        Me.btntemporales.Size = New System.Drawing.Size(100, 104)
        Me.btntemporales.TabIndex = 22
        Me.btntemporales.Text = "Temporales"
        Me.btntemporales.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btntemporales.UseVisualStyleBackColor = False
        '
        'frmMesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1372, 744)
        Me.Controls.Add(Me.pmesas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.psuperior)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMesas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mesas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.psuperior.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents psuperior As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pmesas As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btncambiar As Button
    Friend WithEvents btnjuntar As Button
    Friend WithEvents btnagregar As Button
    Friend WithEvents btncobro As Button
    Friend WithEvents btnconsulta As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel6 As Panel
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
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtMesa As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNComensales As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltotalmesa As Label
    Friend WithEvents lblfolio As Label
    Friend WithEvents parea As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btntemporales As Button
End Class
