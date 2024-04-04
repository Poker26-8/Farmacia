<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDetalleH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleH))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.grdPrecios = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpEntrada = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboRegistro = New System.Windows.Forms.ComboBox()
        Me.cbocliente = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpSalida = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblidcliented = New System.Windows.Forms.Label()
        Me.pdesocupar = New System.Windows.Forms.Panel()
        Me.btnDesocupar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtcontra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbltipo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCaracteristicas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblhabitacion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pdesocupar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 137)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(850, 242)
        Me.Panel4.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.GroupBox1)
        Me.Panel5.Controls.Add(Me.txttelefono)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.dtpEntrada)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.cboRegistro)
        Me.Panel5.Controls.Add(Me.cbocliente)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.dtpSalida)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(850, 242)
        Me.Panel5.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblHoras)
        Me.GroupBox1.Controls.Add(Me.lblPrecio)
        Me.GroupBox1.Controls.Add(Me.grdPrecios)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(470, 170)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Precios de la habitación"
        '
        'lblHoras
        '
        Me.lblHoras.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblHoras.Location = New System.Drawing.Point(313, 55)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(147, 23)
        Me.lblHoras.TabIndex = 95
        '
        'lblPrecio
        '
        Me.lblPrecio.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblPrecio.Location = New System.Drawing.Point(313, 19)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(147, 23)
        Me.lblPrecio.TabIndex = 94
        '
        'grdPrecios
        '
        Me.grdPrecios.AllowUserToAddRows = False
        Me.grdPrecios.AllowUserToDeleteRows = False
        Me.grdPrecios.BackgroundColor = System.Drawing.Color.White
        Me.grdPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column2, Me.Column1})
        Me.grdPrecios.Location = New System.Drawing.Point(4, 19)
        Me.grdPrecios.Name = "grdPrecios"
        Me.grdPrecios.ReadOnly = True
        Me.grdPrecios.RowHeadersVisible = False
        Me.grdPrecios.Size = New System.Drawing.Size(303, 145)
        Me.grdPrecios.TabIndex = 10
        '
        'Column3
        '
        Me.Column3.HeaderText = "Horas"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Precio"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Precio Día"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(620, 3)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(224, 20)
        Me.txttelefono.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(524, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 22)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Telefono:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpEntrada
        '
        Me.dtpEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEntrada.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEntrada.Location = New System.Drawing.Point(506, 28)
        Me.dtpEntrada.Name = "dtpEntrada"
        Me.dtpEntrada.Size = New System.Drawing.Size(99, 22)
        Me.dtpEntrada.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(359, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(141, 20)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Fecha de Entrada:"
        '
        'cboRegistro
        '
        Me.cboRegistro.FormattingEnabled = True
        Me.cboRegistro.Items.AddRange(New Object() {"HOSPEDAR", "RESERVACION", "MANTENIMIENTO", "LIMPIEZA", "VENTILACION"})
        Me.cboRegistro.Location = New System.Drawing.Point(133, 28)
        Me.cboRegistro.Name = "cboRegistro"
        Me.cboRegistro.Size = New System.Drawing.Size(220, 21)
        Me.cboRegistro.TabIndex = 5
        '
        'cbocliente
        '
        Me.cbocliente.FormattingEnabled = True
        Me.cbocliente.Location = New System.Drawing.Point(73, 3)
        Me.cbocliente.Name = "cbocliente"
        Me.cbocliente.Size = New System.Drawing.Size(448, 21)
        Me.cbocliente.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Tipo de registro:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Cliente:"
        '
        'dtpSalida
        '
        Me.dtpSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSalida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpSalida.Location = New System.Drawing.Point(745, 28)
        Me.dtpSalida.Name = "dtpSalida"
        Me.dtpSalida.Size = New System.Drawing.Size(99, 22)
        Me.dtpSalida.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(611, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 22)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Fecha de Salida:"
        '
        'lblidcliented
        '
        Me.lblidcliented.BackColor = System.Drawing.Color.Silver
        Me.lblidcliented.Location = New System.Drawing.Point(203, 6)
        Me.lblidcliented.Name = "lblidcliented"
        Me.lblidcliented.Size = New System.Drawing.Size(113, 23)
        Me.lblidcliented.TabIndex = 93
        Me.lblidcliented.Visible = False
        '
        'pdesocupar
        '
        Me.pdesocupar.Controls.Add(Me.btnDesocupar)
        Me.pdesocupar.Location = New System.Drawing.Point(3, 6)
        Me.pdesocupar.Name = "pdesocupar"
        Me.pdesocupar.Size = New System.Drawing.Size(194, 47)
        Me.pdesocupar.TabIndex = 92
        Me.pdesocupar.Visible = False
        '
        'btnDesocupar
        '
        Me.btnDesocupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDesocupar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesocupar.Location = New System.Drawing.Point(3, 12)
        Me.btnDesocupar.Name = "btnDesocupar"
        Me.btnDesocupar.Size = New System.Drawing.Size(176, 23)
        Me.btnDesocupar.TabIndex = 1
        Me.btnDesocupar.Text = "Desocupar Habitación"
        Me.btnDesocupar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(610, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 71)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(691, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 71)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(772, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 71)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtcontra
        '
        Me.txtcontra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcontra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontra.Location = New System.Drawing.Point(732, 38)
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(115, 22)
        Me.txtcontra.TabIndex = 89
        Me.txtcontra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtcontra.UseSystemPasswordChar = True
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(732, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 23)
        Me.Label11.TabIndex = 88
        Me.Label11.Text = "CLAVE DE USUARIO"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.SteelBlue
        Me.lblusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(732, 61)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(115, 20)
        Me.lblusuario.TabIndex = 5
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.lbltipo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.lblCaracteristicas)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtcontra)
        Me.Panel2.Controls.Add(Me.lblhabitacion)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.lblusuario)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 100)
        Me.Panel2.TabIndex = 6
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.White
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(264, 69)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(134, 23)
        Me.lblEstado.TabIndex = 9
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(264, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Estado"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbltipo
        '
        Me.lbltipo.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lbltipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipo.Location = New System.Drawing.Point(108, 41)
        Me.lbltipo.Name = "lbltipo"
        Me.lbltipo.Size = New System.Drawing.Size(150, 23)
        Me.lbltipo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo:"
        '
        'lblCaracteristicas
        '
        Me.lblCaracteristicas.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblCaracteristicas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaracteristicas.Location = New System.Drawing.Point(404, 12)
        Me.lblCaracteristicas.Name = "lblCaracteristicas"
        Me.lblCaracteristicas.Size = New System.Drawing.Size(303, 81)
        Me.lblCaracteristicas.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(264, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Caracteristicas:"
        '
        'lblhabitacion
        '
        Me.lblhabitacion.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblhabitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhabitacion.Location = New System.Drawing.Point(108, 12)
        Me.lblhabitacion.Name = "lblhabitacion"
        Me.lblhabitacion.Size = New System.Drawing.Size(150, 23)
        Me.lblhabitacion.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Habitación:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(850, 37)
        Me.Panel1.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnLimpiar)
        Me.Panel3.Controls.Add(Me.pdesocupar)
        Me.Panel3.Controls.Add(Me.lblidcliented)
        Me.Panel3.Controls.Add(Me.btnGuardar)
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 379)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(850, 82)
        Me.Panel3.TabIndex = 94
        '
        'frmDetalleH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(850, 461)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDetalleH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Habitación"
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pdesocupar.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblidcliented As Label
    Friend WithEvents pdesocupar As Panel
    Friend WithEvents btnDesocupar As Button
    Friend WithEvents txtcontra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpEntrada As DateTimePicker
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cboRegistro As ComboBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpSalida As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents cbocliente As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEstado As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lbltipo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCaracteristicas As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblhabitacion As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdPrecios As DataGridView
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblHoras As Label
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
