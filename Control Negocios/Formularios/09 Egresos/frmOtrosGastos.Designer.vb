<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtrosGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtrosGastos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtpagos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtcomentario = New System.Windows.Forms.RichTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.cboconcepto = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtfolio = New System.Windows.Forms.TextBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbotipo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboBancoRecepcion = New System.Windows.Forms.TextBox()
        Me.txtnumref = New System.Windows.Forms.TextBox()
        Me.cboCuentaRecepcion = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtComentarioPago = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.btnPagos = New System.Windows.Forms.Button()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.grdpago = New System.Windows.Forms.DataGridView()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbotpago = New System.Windows.Forms.ComboBox()
        Me.dtpFecha_P = New System.Windows.Forms.DateTimePicker()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtpagos)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtcomentario)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dtpfecha)
        Me.GroupBox2.Controls.Add(Me.cboconcepto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtefectivo)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtfolio)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(414, 146)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Salida"
        '
        'txtpagos
        '
        Me.txtpagos.BackColor = System.Drawing.Color.White
        Me.txtpagos.Enabled = False
        Me.txtpagos.Location = New System.Drawing.Point(73, 96)
        Me.txtpagos.Name = "txtpagos"
        Me.txtpagos.Size = New System.Drawing.Size(101, 23)
        Me.txtpagos.TabIndex = 214
        Me.txtpagos.Text = "0.00"
        Me.txtpagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "Pagos:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(239, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 187
        Me.Label10.Text = "Fecha:"
        '
        'txtcomentario
        '
        Me.txtcomentario.Location = New System.Drawing.Point(180, 87)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(202, 49)
        Me.txtcomentario.TabIndex = 185
        Me.txtcomentario.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(177, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 184
        Me.Label9.Text = "Observaciones:"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(286, 18)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(101, 23)
        Me.dtpfecha.TabIndex = 186
        '
        'cboconcepto
        '
        Me.cboconcepto.FormattingEnabled = True
        Me.cboconcepto.Location = New System.Drawing.Point(73, 44)
        Me.cboconcepto.Name = "cboconcepto"
        Me.cboconcepto.Size = New System.Drawing.Size(314, 23)
        Me.cboconcepto.TabIndex = 174
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Concepto:"
        '
        'txtefectivo
        '
        Me.txtefectivo.Location = New System.Drawing.Point(73, 70)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(101, 23)
        Me.txtefectivo.TabIndex = 212
        Me.txtefectivo.Text = "0.00"
        Me.txtefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(7, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 15)
        Me.Label11.TabIndex = 211
        Me.Label11.Text = "Efectivo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 166
        Me.Label2.Text = "Factura:"
        '
        'txtfolio
        '
        Me.txtfolio.Location = New System.Drawing.Point(73, 18)
        Me.txtfolio.Name = "txtfolio"
        Me.txtfolio.Size = New System.Drawing.Size(110, 23)
        Me.txtfolio.TabIndex = 165
        '
        'btnguardar
        '
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(297, 218)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 63)
        Me.btnguardar.TabIndex = 218
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(231, 218)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 217
        Me.btnnuevo.Text = "Limpiar"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.White
        Me.txtcontraseña.Location = New System.Drawing.Point(342, 40)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(81, 23)
        Me.txtcontraseña.TabIndex = 222
        Me.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 44)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 15)
        Me.Label17.TabIndex = 220
        Me.Label17.Text = "Área:"
        '
        'cbotipo
        '
        Me.cbotipo.FormattingEnabled = True
        Me.cbotipo.Location = New System.Drawing.Point(55, 40)
        Me.cbotipo.Name = "cbotipo"
        Me.cbotipo.Size = New System.Drawing.Size(173, 23)
        Me.cbotipo.TabIndex = 219
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(0, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label16.Size = New System.Drawing.Size(431, 31)
        Me.Label16.TabIndex = 224
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(244, 40)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 23)
        Me.lblusuario.TabIndex = 225
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(80, 218)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(101, 23)
        Me.txttotal.TabIndex = 227
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 15)
        Me.Label5.TabIndex = 226
        Me.Label5.Text = "Total:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(5, 293)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 19)
        Me.Label21.TabIndex = 257
        Me.Label21.Text = "Tipo pago:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(9, 371)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(59, 19)
        Me.Label43.TabIndex = 273
        Me.Label43.Text = "Cuenta:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(234, 373)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 19)
        Me.Label41.TabIndex = 269
        Me.Label41.Text = "Banco:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(9, 397)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 19)
        Me.Label30.TabIndex = 272
        Me.Label30.Text = "Fecha:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(5, 320)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 19)
        Me.Label23.TabIndex = 260
        Me.Label23.Text = "Referencia:"
        '
        'cboBancoRecepcion
        '
        Me.cboBancoRecepcion.Enabled = False
        Me.cboBancoRecepcion.Location = New System.Drawing.Point(293, 371)
        Me.cboBancoRecepcion.Name = "cboBancoRecepcion"
        Me.cboBancoRecepcion.Size = New System.Drawing.Size(130, 23)
        Me.cboBancoRecepcion.TabIndex = 271
        '
        'txtnumref
        '
        Me.txtnumref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumref.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumref.Location = New System.Drawing.Point(93, 317)
        Me.txtnumref.Name = "txtnumref"
        Me.txtnumref.Size = New System.Drawing.Size(135, 25)
        Me.txtnumref.TabIndex = 261
        '
        'cboCuentaRecepcion
        '
        Me.cboCuentaRecepcion.FormattingEnabled = True
        Me.cboCuentaRecepcion.Location = New System.Drawing.Point(93, 371)
        Me.cboCuentaRecepcion.Name = "cboCuentaRecepcion"
        Me.cboCuentaRecepcion.Size = New System.Drawing.Size(135, 23)
        Me.cboCuentaRecepcion.TabIndex = 270
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(234, 293)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 19)
        Me.Label22.TabIndex = 259
        Me.Label22.Text = "Banco:"
        '
        'txtComentarioPago
        '
        Me.txtComentarioPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioPago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioPago.Location = New System.Drawing.Point(93, 344)
        Me.txtComentarioPago.Name = "txtComentarioPago"
        Me.txtComentarioPago.Size = New System.Drawing.Size(330, 25)
        Me.txtComentarioPago.TabIndex = 268
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(234, 320)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 19)
        Me.Label24.TabIndex = 262
        Me.Label24.Text = "Monto:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(5, 347)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 19)
        Me.Label40.TabIndex = 267
        Me.Label40.Text = "Comentario:"
        '
        'cbobanco
        '
        Me.cbobanco.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(293, 290)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(130, 25)
        Me.cbobanco.TabIndex = 258
        '
        'btnPagos
        '
        Me.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagos.Location = New System.Drawing.Point(234, 396)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Size = New System.Drawing.Size(189, 24)
        Me.btnPagos.TabIndex = 266
        Me.btnPagos.Text = "Agregar pago"
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'txtmonto
        '
        Me.txtmonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmonto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.Location = New System.Drawing.Point(293, 317)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(130, 25)
        Me.txtmonto.TabIndex = 263
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grdpago
        '
        Me.grdpago.AllowUserToAddRows = False
        Me.grdpago.AllowUserToDeleteRows = False
        Me.grdpago.BackgroundColor = System.Drawing.Color.White
        Me.grdpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpago.ColumnHeadersVisible = False
        Me.grdpago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column9, Me.Column28, Me.Column27})
        Me.grdpago.Location = New System.Drawing.Point(7, 424)
        Me.grdpago.Name = "grdpago"
        Me.grdpago.ReadOnly = True
        Me.grdpago.RowHeadersVisible = False
        Me.grdpago.Size = New System.Drawing.Size(416, 78)
        Me.grdpago.TabIndex = 265
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
        'cbotpago
        '
        Me.cbotpago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotpago.FormattingEnabled = True
        Me.cbotpago.Location = New System.Drawing.Point(93, 290)
        Me.cbotpago.Name = "cbotpago"
        Me.cbotpago.Size = New System.Drawing.Size(135, 25)
        Me.cbotpago.TabIndex = 256
        '
        'dtpFecha_P
        '
        Me.dtpFecha_P.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha_P.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha_P.Location = New System.Drawing.Point(93, 396)
        Me.dtpFecha_P.Name = "dtpFecha_P"
        Me.dtpFecha_P.Size = New System.Drawing.Size(135, 25)
        Me.dtpFecha_P.TabIndex = 264
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(363, 218)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 63)
        Me.btnSalir.TabIndex = 274
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmOtrosGastos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(431, 508)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cboBancoRecepcion)
        Me.Controls.Add(Me.txtnumref)
        Me.Controls.Add(Me.cboCuentaRecepcion)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtComentarioPago)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.cbobanco)
        Me.Controls.Add(Me.btnPagos)
        Me.Controls.Add(Me.txtmonto)
        Me.Controls.Add(Me.grdpago)
        Me.Controls.Add(Me.cbotpago)
        Me.Controls.Add(Me.dtpFecha_P)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cbotipo)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label16)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOtrosGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otros gastos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtcomentario As System.Windows.Forms.RichTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboconcepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtfolio As System.Windows.Forms.TextBox
    Friend WithEvents txtefectivo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents txtcontraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbotipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents txtpagos As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cboBancoRecepcion As TextBox
    Friend WithEvents txtnumref As TextBox
    Friend WithEvents cboCuentaRecepcion As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtComentarioPago As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents cbobanco As ComboBox
    Friend WithEvents btnPagos As Button
    Friend WithEvents txtmonto As TextBox
    Friend WithEvents grdpago As DataGridView
    Friend WithEvents cbotpago As ComboBox
    Friend WithEvents dtpFecha_P As DateTimePicker
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents btnSalir As Button
End Class
