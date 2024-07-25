<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGastos))
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboArea = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboiPlaca = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtContraseña = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtPagos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rtbObservaciones = New System.Windows.Forms.RichTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboConcepto = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFactura = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grdpago = New System.Windows.Forms.DataGridView()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnPagos = New System.Windows.Forms.Button()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboBancoRecepcion = New System.Windows.Forms.TextBox()
        Me.cboCuentaRecepcion = New System.Windows.Forms.ComboBox()
        Me.txtComentarioPago = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dtpFecha_P = New System.Windows.Forms.DateTimePicker()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.cbotpago = New System.Windows.Forms.ComboBox()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtIva = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(583, 41)
        Me.Label20.TabIndex = 144
        Me.Label20.Text = "Gastos de transporte"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 18)
        Me.Label1.TabIndex = 145
        Me.Label1.Text = "Área:"
        '
        'cboArea
        '
        Me.cboArea.FormattingEnabled = True
        Me.cboArea.Items.AddRange(New Object() {"VENTA", "ADMINISTRACIÓN", "OPERACIÓN"})
        Me.cboArea.Location = New System.Drawing.Point(50, 51)
        Me.cboArea.Name = "cboArea"
        Me.cboArea.Size = New System.Drawing.Size(254, 21)
        Me.cboArea.TabIndex = 146
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtModelo)
        Me.GroupBox1.Controls.Add(Me.txtChofer)
        Me.GroupBox1.Controls.Add(Me.txtMarca)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboiPlaca)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 86)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vehiculo"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(359, 50)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(207, 22)
        Me.txtModelo.TabIndex = 153
        '
        'txtChofer
        '
        Me.txtChofer.Location = New System.Drawing.Point(359, 19)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(207, 22)
        Me.txtChofer.TabIndex = 152
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(62, 50)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(217, 22)
        Me.txtMarca.TabIndex = 151
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(289, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 23)
        Me.Label4.TabIndex = 150
        Me.Label4.Text = "Modelo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 23)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Marca:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboiPlaca
        '
        Me.cboiPlaca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboiPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboiPlaca.FormattingEnabled = True
        Me.cboiPlaca.Location = New System.Drawing.Point(62, 18)
        Me.cboiPlaca.Name = "cboiPlaca"
        Me.cboiPlaca.Size = New System.Drawing.Size(217, 23)
        Me.cboiPlaca.TabIndex = 148
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 23)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Placa:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(294, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 23)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Chofer:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContraseña
        '
        Me.txtContraseña.Location = New System.Drawing.Point(488, 52)
        Me.txtContraseña.Name = "txtContraseña"
        Me.txtContraseña.Size = New System.Drawing.Size(89, 20)
        Me.txtContraseña.TabIndex = 154
        Me.txtContraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtContraseña.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(398, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Contraseña:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIva)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtSubtotal)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtEfectivo)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.txtPagos)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.rtbObservaciones)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cboConcepto)
        Me.GroupBox2.Controls.Add(Me.dtpFecha)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtFactura)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(572, 215)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Salida"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(462, 130)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(102, 22)
        Me.txtEfectivo.TabIndex = 156
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(383, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 22)
        Me.Label18.TabIndex = 168
        Me.Label18.Text = "Total:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(383, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 22)
        Me.Label8.TabIndex = 155
        Me.Label8.Text = "Efectivo:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(462, 102)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(102, 22)
        Me.txtTotal.TabIndex = 167
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPagos
        '
        Me.txtPagos.Enabled = False
        Me.txtPagos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagos.Location = New System.Drawing.Point(462, 158)
        Me.txtPagos.Name = "txtPagos"
        Me.txtPagos.Size = New System.Drawing.Size(102, 22)
        Me.txtPagos.TabIndex = 154
        Me.txtPagos.Text = "0.00"
        Me.txtPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(385, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 22)
        Me.Label7.TabIndex = 150
        Me.Label7.Text = "Pagos:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtbObservaciones
        '
        Me.rtbObservaciones.Location = New System.Drawing.Point(10, 101)
        Me.rtbObservaciones.Name = "rtbObservaciones"
        Me.rtbObservaciones.Size = New System.Drawing.Size(361, 107)
        Me.rtbObservaciones.TabIndex = 162
        Me.rtbObservaciones.Text = ""
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(114, 24)
        Me.Label15.TabIndex = 161
        Me.Label15.Text = "Observaciones:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 24)
        Me.Label14.TabIndex = 160
        Me.Label14.Text = "Concepto:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboConcepto
        '
        Me.cboConcepto.FormattingEnabled = True
        Me.cboConcepto.Items.AddRange(New Object() {"ADMINISTRACIÓN", "GASOLINA Y ACEITES", "MANTENIMIENTO", "OTROS", "REPARACIÓN Y REF", "SEGURO"})
        Me.cboConcepto.Location = New System.Drawing.Point(93, 47)
        Me.cboConcepto.Name = "cboConcepto"
        Me.cboConcepto.Size = New System.Drawing.Size(278, 24)
        Me.cboConcepto.TabIndex = 158
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(462, 18)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 22)
        Me.dtpFecha.TabIndex = 159
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(383, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 22)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "Fecha:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFactura
        '
        Me.txtFactura.Location = New System.Drawing.Point(94, 18)
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(151, 22)
        Me.txtFactura.TabIndex = 154
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 23)
        Me.Label11.TabIndex = 155
        Me.Label11.Text = "N° Factura:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(310, 51)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(82, 21)
        Me.lblUsuario.TabIndex = 154
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grdpago)
        Me.GroupBox3.Controls.Add(Me.btnGuardar)
        Me.GroupBox3.Controls.Add(Me.btnSalir)
        Me.GroupBox3.Controls.Add(Me.btnNuevo)
        Me.GroupBox3.Controls.Add(Me.btnPagos)
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.Label41)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.cboBancoRecepcion)
        Me.GroupBox3.Controls.Add(Me.cboCuentaRecepcion)
        Me.GroupBox3.Controls.Add(Me.txtComentarioPago)
        Me.GroupBox3.Controls.Add(Me.Label40)
        Me.GroupBox3.Controls.Add(Me.dtpFecha_P)
        Me.GroupBox3.Controls.Add(Me.txtMonto)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txtReferencia)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.cbobanco)
        Me.GroupBox3.Controls.Add(Me.cbotpago)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 391)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(572, 260)
        Me.GroupBox3.TabIndex = 157
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Formas de pago"
        '
        'grdpago
        '
        Me.grdpago.AllowUserToAddRows = False
        Me.grdpago.AllowUserToDeleteRows = False
        Me.grdpago.BackgroundColor = System.Drawing.Color.White
        Me.grdpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpago.ColumnHeadersVisible = False
        Me.grdpago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column9, Me.Column28, Me.Column27})
        Me.grdpago.Location = New System.Drawing.Point(11, 159)
        Me.grdpago.Name = "grdpago"
        Me.grdpago.ReadOnly = True
        Me.grdpago.RowHeadersVisible = False
        Me.grdpago.Size = New System.Drawing.Size(474, 95)
        Me.grdpago.TabIndex = 287
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column15.HeaderText = "Tipo"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column16.HeaderText = "Banco"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column17.HeaderText = "Número"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column18.HeaderText = "Monto"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column19.HeaderText = "Fecha"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Comentario"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column28
        '
        Me.Column28.HeaderText = "CuentaRe"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        Me.Column28.Visible = False
        '
        'Column27
        '
        Me.Column27.HeaderText = "BancoRe"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        Me.Column27.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(491, 11)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 77)
        Me.btnGuardar.TabIndex = 286
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(491, 177)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 70)
        Me.btnSalir.TabIndex = 285
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(491, 94)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 77)
        Me.btnNuevo.TabIndex = 284
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnPagos
        '
        Me.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagos.Location = New System.Drawing.Point(269, 131)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Size = New System.Drawing.Size(216, 27)
        Me.btnPagos.TabIndex = 282
        Me.btnPagos.Text = "Agregar pago"
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(9, 106)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(59, 19)
        Me.Label43.TabIndex = 281
        Me.Label43.Text = "Cuenta:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(260, 104)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 19)
        Me.Label41.TabIndex = 277
        Me.Label41.Text = "Banco:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(9, 132)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 19)
        Me.Label30.TabIndex = 280
        Me.Label30.Text = "Fecha:"
        '
        'cboBancoRecepcion
        '
        Me.cboBancoRecepcion.Enabled = False
        Me.cboBancoRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBancoRecepcion.Location = New System.Drawing.Point(320, 106)
        Me.cboBancoRecepcion.Name = "cboBancoRecepcion"
        Me.cboBancoRecepcion.Size = New System.Drawing.Size(165, 20)
        Me.cboBancoRecepcion.TabIndex = 279
        '
        'cboCuentaRecepcion
        '
        Me.cboCuentaRecepcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuentaRecepcion.FormattingEnabled = True
        Me.cboCuentaRecepcion.Location = New System.Drawing.Point(93, 106)
        Me.cboCuentaRecepcion.Name = "cboCuentaRecepcion"
        Me.cboCuentaRecepcion.Size = New System.Drawing.Size(166, 21)
        Me.cboCuentaRecepcion.TabIndex = 278
        '
        'txtComentarioPago
        '
        Me.txtComentarioPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioPago.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioPago.Location = New System.Drawing.Point(93, 79)
        Me.txtComentarioPago.Name = "txtComentarioPago"
        Me.txtComentarioPago.Size = New System.Drawing.Size(392, 22)
        Me.txtComentarioPago.TabIndex = 276
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(5, 82)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 19)
        Me.Label40.TabIndex = 275
        Me.Label40.Text = "Comentario:"
        '
        'dtpFecha_P
        '
        Me.dtpFecha_P.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha_P.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha_P.Location = New System.Drawing.Point(93, 131)
        Me.dtpFecha_P.Name = "dtpFecha_P"
        Me.dtpFecha_P.Size = New System.Drawing.Size(166, 22)
        Me.dtpFecha_P.TabIndex = 274
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(320, 51)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(165, 22)
        Me.txtMonto.TabIndex = 266
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(265, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 19)
        Me.Label17.TabIndex = 265
        Me.Label17.Text = "Monto:"
        '
        'txtReferencia
        '
        Me.txtReferencia.Location = New System.Drawing.Point(93, 51)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(166, 22)
        Me.txtReferencia.TabIndex = 169
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(7, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 19)
        Me.Label9.TabIndex = 264
        Me.Label9.Text = "Referencia:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(5, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 19)
        Me.Label21.TabIndex = 261
        Me.Label21.Text = "Tipo pago:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(265, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 19)
        Me.Label22.TabIndex = 263
        Me.Label22.Text = "Banco:"
        '
        'cbobanco
        '
        Me.cbobanco.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(320, 24)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(165, 21)
        Me.cbobanco.TabIndex = 262
        '
        'cbotpago
        '
        Me.cbotpago.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotpago.FormattingEnabled = True
        Me.cbotpago.Location = New System.Drawing.Point(93, 24)
        Me.cbotpago.Name = "cbotpago"
        Me.cbotpago.Size = New System.Drawing.Size(166, 21)
        Me.cbotpago.TabIndex = 260
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(462, 49)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(102, 22)
        Me.txtSubtotal.TabIndex = 170
        Me.txtSubtotal.Text = "0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(382, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 22)
        Me.Label10.TabIndex = 169
        Me.Label10.Text = "Subtotal:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIva
        '
        Me.txtIva.Enabled = False
        Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIva.Location = New System.Drawing.Point(462, 74)
        Me.txtIva.Name = "txtIva"
        Me.txtIva.Size = New System.Drawing.Size(102, 22)
        Me.txtIva.TabIndex = 172
        Me.txtIva.Text = "0.00"
        Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(386, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 22)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "Iva:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(583, 656)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtContraseña)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboArea)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label20)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gastos de transporte"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboArea As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboiPlaca As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents txtChofer As TextBox
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtContraseña As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPagos As TextBox
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFactura As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cboConcepto As ComboBox
    Friend WithEvents rtbObservaciones As RichTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cbobanco As ComboBox
    Friend WithEvents cbotpago As ComboBox
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents cboBancoRecepcion As TextBox
    Friend WithEvents cboCuentaRecepcion As ComboBox
    Friend WithEvents txtComentarioPago As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents dtpFecha_P As DateTimePicker
    Friend WithEvents btnPagos As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents grdpago As DataGridView
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents txtIva As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label10 As Label
End Class
