<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPedidos_Tienda
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos_Tienda))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.lblNumCliente = New System.Windows.Forms.Label()
        Me.cbofolio = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.RichTextBox()
        Me.txt_referencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_metodo_pago = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtacuenta = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtresta = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_subtotal = New System.Windows.Forms.TextBox()
        Me.btn_produccion = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbltipo_envio = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.opt_pendientes = New System.Windows.Forms.RadioButton()
        Me.opt_entregados = New System.Windows.Forms.RadioButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_envio = New System.Windows.Forms.TextBox()
        Me.btn_entregado = New System.Windows.Forms.Button()
        Me.box_Pago = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtequivale = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtvalor = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboBancoRecepcion = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cboCuentaRecepcion = New System.Windows.Forms.ComboBox()
        Me.txtComentarioPago = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.grdpago = New System.Windows.Forms.DataGridView()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtMontoP = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.dtpFecha_P = New System.Windows.Forms.DateTimePicker()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtdescuento2 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPagar = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtdescu = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.picQR = New System.Windows.Forms.PictureBox()
        Me.txtdescuento1 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cbotpago = New System.Windows.Forms.ComboBox()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtnumref = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pComanda80 = New System.Drawing.Printing.PrintDocument()
        Me.pComanda58 = New System.Drawing.Printing.PrintDocument()
        Me.p_envio = New System.Drawing.Printing.PrintDocument()
        Me.p_recoge_t = New System.Drawing.Printing.PrintDocument()
        Me.lblt_pago = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.box_Pago.SuspendLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(1110, 34)
        Me.Label1.TabIndex = 5
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(900, 6)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(98, 23)
        Me.txtusuario.TabIndex = 230
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(1004, 6)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(98, 23)
        Me.lblusuario.TabIndex = 231
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumCliente
        '
        Me.lblNumCliente.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblNumCliente.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCliente.ForeColor = System.Drawing.Color.White
        Me.lblNumCliente.Location = New System.Drawing.Point(8, 6)
        Me.lblNumCliente.Name = "lblNumCliente"
        Me.lblNumCliente.Size = New System.Drawing.Size(103, 22)
        Me.lblNumCliente.TabIndex = 232
        Me.lblNumCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbofolio
        '
        Me.cbofolio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbofolio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofolio.FormattingEnabled = True
        Me.cbofolio.Location = New System.Drawing.Point(738, 44)
        Me.cbofolio.Name = "cbofolio"
        Me.cbofolio.Size = New System.Drawing.Size(131, 25)
        Me.cbofolio.TabIndex = 238
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(636, 47)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 19)
        Me.Label28.TabIndex = 237
        Me.Label28.Text = "Folio:"
        '
        'cbonombre
        '
        Me.cbonombre.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(267, 44)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(363, 25)
        Me.cbonombre.TabIndex = 234
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 19)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(186, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 19)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "Dirección:"
        '
        'txtdireccion
        '
        Me.txtdireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdireccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdireccion.Location = New System.Drawing.Point(267, 73)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(363, 54)
        Me.txtdireccion.TabIndex = 235
        Me.txtdireccion.Text = ""
        '
        'txt_referencia
        '
        Me.txt_referencia.BackColor = System.Drawing.Color.White
        Me.txt_referencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_referencia.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_referencia.Location = New System.Drawing.Point(738, 73)
        Me.txt_referencia.Name = "txt_referencia"
        Me.txt_referencia.ReadOnly = True
        Me.txt_referencia.Size = New System.Drawing.Size(131, 25)
        Me.txt_referencia.TabIndex = 240
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(636, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 19)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "Referencia:"
        '
        'txt_metodo_pago
        '
        Me.txt_metodo_pago.BackColor = System.Drawing.Color.White
        Me.txt_metodo_pago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_metodo_pago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_metodo_pago.Location = New System.Drawing.Point(738, 102)
        Me.txt_metodo_pago.Name = "txt_metodo_pago"
        Me.txt_metodo_pago.ReadOnly = True
        Me.txt_metodo_pago.Size = New System.Drawing.Size(361, 25)
        Me.txt_metodo_pago.TabIndex = 242
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(636, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 19)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "Método pago:"
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ColumnHeadersVisible = False
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Total, Me.Column6})
        Me.grdcaptura.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdcaptura.Location = New System.Drawing.Point(11, 152)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.RowTemplate.Height = 25
        Me.grdcaptura.Size = New System.Drawing.Size(1088, 370)
        Me.grdcaptura.TabIndex = 244
        '
        'Column1
        '
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Precio"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Existencia"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(996, 134)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 19)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "Total"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(897, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 19)
        Me.Label8.TabIndex = 249
        Me.Label8.Text = "Precio"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(757, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = "Unidad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(92, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(666, 19)
        Me.Label7.TabIndex = 246
        Me.Label7.Text = "Descripción"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(11, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 19)
        Me.Label10.TabIndex = 245
        Me.Label10.Text = "Código"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(817, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 19)
        Me.Label11.TabIndex = 248
        Me.Label11.Text = "Cantidad"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(711, 531)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 19)
        Me.Label16.TabIndex = 258
        Me.Label16.Text = "Subtotal:"
        '
        'txtacuenta
        '
        Me.txtacuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtacuenta.BackColor = System.Drawing.Color.White
        Me.txtacuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtacuenta.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtacuenta.Location = New System.Drawing.Point(987, 557)
        Me.txtacuenta.Name = "txtacuenta"
        Me.txtacuenta.ReadOnly = True
        Me.txtacuenta.Size = New System.Drawing.Size(112, 25)
        Me.txtacuenta.TabIndex = 251
        Me.txtacuenta.Text = "0.00"
        Me.txtacuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(908, 560)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 19)
        Me.Label12.TabIndex = 252
        Me.Label12.Text = "A cuenta:"
        '
        'txtresta
        '
        Me.txtresta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtresta.BackColor = System.Drawing.Color.White
        Me.txtresta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtresta.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresta.Location = New System.Drawing.Point(987, 586)
        Me.txtresta.Name = "txtresta"
        Me.txtresta.ReadOnly = True
        Me.txtresta.Size = New System.Drawing.Size(112, 25)
        Me.txtresta.TabIndex = 253
        Me.txtresta.Text = "0.00"
        Me.txtresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(908, 589)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 19)
        Me.Label13.TabIndex = 254
        Me.Label13.Text = "Resta:"
        '
        'txt_total
        '
        Me.txt_total.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_total.BackColor = System.Drawing.Color.White
        Me.txt_total.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_total.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_total.Location = New System.Drawing.Point(790, 586)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(112, 25)
        Me.txt_total.TabIndex = 255
        Me.txt_total.Text = "0.00"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(711, 589)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 19)
        Me.Label14.TabIndex = 256
        Me.Label14.Text = "Total:"
        '
        'txt_subtotal
        '
        Me.txt_subtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_subtotal.BackColor = System.Drawing.Color.White
        Me.txt_subtotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_subtotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_subtotal.Location = New System.Drawing.Point(790, 528)
        Me.txt_subtotal.Name = "txt_subtotal"
        Me.txt_subtotal.ReadOnly = True
        Me.txt_subtotal.Size = New System.Drawing.Size(112, 25)
        Me.txt_subtotal.TabIndex = 257
        Me.txt_subtotal.Text = "0.00"
        Me.txt_subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_produccion
        '
        Me.btn_produccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_produccion.BackColor = System.Drawing.Color.White
        Me.btn_produccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_produccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_produccion.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_produccion.Image = CType(resources.GetObject("btn_produccion.Image"), System.Drawing.Image)
        Me.btn_produccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_produccion.Location = New System.Drawing.Point(11, 528)
        Me.btn_produccion.Name = "btn_produccion"
        Me.btn_produccion.Size = New System.Drawing.Size(76, 83)
        Me.btn_produccion.TabIndex = 259
        Me.btn_produccion.Text = "Enviar a producción"
        Me.btn_produccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_produccion.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(940, 47)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 19)
        Me.Label15.TabIndex = 261
        Me.Label15.Text = "Tipo de envío:"
        '
        'lbltipo_envio
        '
        Me.lbltipo_envio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipo_envio.Location = New System.Drawing.Point(875, 73)
        Me.lbltipo_envio.Name = "lbltipo_envio"
        Me.lbltipo_envio.Size = New System.Drawing.Size(224, 25)
        Me.lbltipo_envio.TabIndex = 262
        Me.lbltipo_envio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel5.Controls.Add(Me.opt_pendientes)
        Me.Panel5.Controls.Add(Me.opt_entregados)
        Me.Panel5.Location = New System.Drawing.Point(11, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(169, 83)
        Me.Panel5.TabIndex = 263
        '
        'opt_pendientes
        '
        Me.opt_pendientes.AutoSize = True
        Me.opt_pendientes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_pendientes.Location = New System.Drawing.Point(7, 8)
        Me.opt_pendientes.Name = "opt_pendientes"
        Me.opt_pendientes.Size = New System.Drawing.Size(87, 19)
        Me.opt_pendientes.TabIndex = 0
        Me.opt_pendientes.TabStop = True
        Me.opt_pendientes.Text = "Pendientes"
        Me.opt_pendientes.UseVisualStyleBackColor = True
        '
        'opt_entregados
        '
        Me.opt_entregados.AutoSize = True
        Me.opt_entregados.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt_entregados.Location = New System.Drawing.Point(7, 33)
        Me.opt_entregados.Name = "opt_entregados"
        Me.opt_entregados.Size = New System.Drawing.Size(87, 19)
        Me.opt_entregados.TabIndex = 1
        Me.opt_entregados.TabStop = True
        Me.opt_entregados.Text = "Entregados"
        Me.opt_entregados.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(711, 560)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 19)
        Me.Label17.TabIndex = 265
        Me.Label17.Text = "Envío:"
        '
        'txt_envio
        '
        Me.txt_envio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_envio.BackColor = System.Drawing.Color.White
        Me.txt_envio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_envio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_envio.Location = New System.Drawing.Point(790, 557)
        Me.txt_envio.Name = "txt_envio"
        Me.txt_envio.ReadOnly = True
        Me.txt_envio.Size = New System.Drawing.Size(112, 25)
        Me.txt_envio.TabIndex = 264
        Me.txt_envio.Text = "0.00"
        Me.txt_envio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_entregado
        '
        Me.btn_entregado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_entregado.BackColor = System.Drawing.Color.White
        Me.btn_entregado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_entregado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_entregado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_entregado.Image = CType(resources.GetObject("btn_entregado.Image"), System.Drawing.Image)
        Me.btn_entregado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_entregado.Location = New System.Drawing.Point(93, 528)
        Me.btn_entregado.Name = "btn_entregado"
        Me.btn_entregado.Size = New System.Drawing.Size(71, 83)
        Me.btn_entregado.TabIndex = 266
        Me.btn_entregado.Text = "Terminar pedido"
        Me.btn_entregado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_entregado.UseVisualStyleBackColor = False
        '
        'box_Pago
        '
        Me.box_Pago.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.box_Pago.Controls.Add(Me.TextBox1)
        Me.box_Pago.Controls.Add(Me.Label19)
        Me.box_Pago.Controls.Add(Me.Button1)
        Me.box_Pago.Controls.Add(Me.txtequivale)
        Me.box_Pago.Controls.Add(Me.Label46)
        Me.box_Pago.Controls.Add(Me.txtvalor)
        Me.box_Pago.Controls.Add(Me.Label45)
        Me.box_Pago.Controls.Add(Me.cboBancoRecepcion)
        Me.box_Pago.Controls.Add(Me.Label43)
        Me.box_Pago.Controls.Add(Me.cboCuentaRecepcion)
        Me.box_Pago.Controls.Add(Me.txtComentarioPago)
        Me.box_Pago.Controls.Add(Me.Label40)
        Me.box_Pago.Controls.Add(Me.Button9)
        Me.box_Pago.Controls.Add(Me.grdpago)
        Me.box_Pago.Controls.Add(Me.Label30)
        Me.box_Pago.Controls.Add(Me.Label18)
        Me.box_Pago.Controls.Add(Me.txtMontoP)
        Me.box_Pago.Controls.Add(Me.Label27)
        Me.box_Pago.Controls.Add(Me.dtpFecha_P)
        Me.box_Pago.Controls.Add(Me.txtSubTotal)
        Me.box_Pago.Controls.Add(Me.Label26)
        Me.box_Pago.Controls.Add(Me.txtdescuento2)
        Me.box_Pago.Controls.Add(Me.Label25)
        Me.box_Pago.Controls.Add(Me.txtPagar)
        Me.box_Pago.Controls.Add(Me.GroupBox5)
        Me.box_Pago.Controls.Add(Me.cbotpago)
        Me.box_Pago.Controls.Add(Me.txtmonto)
        Me.box_Pago.Controls.Add(Me.cbobanco)
        Me.box_Pago.Controls.Add(Me.Label24)
        Me.box_Pago.Controls.Add(Me.Label22)
        Me.box_Pago.Controls.Add(Me.txtnumref)
        Me.box_Pago.Controls.Add(Me.Label23)
        Me.box_Pago.Controls.Add(Me.Label41)
        Me.box_Pago.Controls.Add(Me.Label21)
        Me.box_Pago.Location = New System.Drawing.Point(90, 202)
        Me.box_Pago.Name = "box_Pago"
        Me.box_Pago.Size = New System.Drawing.Size(930, 271)
        Me.box_Pago.TabIndex = 267
        Me.box_Pago.TabStop = False
        Me.box_Pago.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(523, 183)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(319, 25)
        Me.TextBox1.TabIndex = 278
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(435, 186)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(87, 19)
        Me.Label19.TabIndex = 277
        Me.Label19.Text = "Repartidor:"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(848, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 78)
        Me.Button1.TabIndex = 276
        Me.Button1.Text = "Terminar pedido"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtequivale
        '
        Me.txtequivale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtequivale.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtequivale.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtequivale.Location = New System.Drawing.Point(433, 150)
        Me.txtequivale.Name = "txtequivale"
        Me.txtequivale.ReadOnly = True
        Me.txtequivale.Size = New System.Drawing.Size(84, 25)
        Me.txtequivale.TabIndex = 275
        Me.txtequivale.Text = "0.00"
        Me.txtequivale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label46
        '
        Me.Label46.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label46.Location = New System.Drawing.Point(438, 132)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(75, 15)
        Me.Label46.TabIndex = 274
        Me.Label46.Text = "Equivalencia"
        '
        'txtvalor
        '
        Me.txtvalor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtvalor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtvalor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvalor.Location = New System.Drawing.Point(433, 100)
        Me.txtvalor.Name = "txtvalor"
        Me.txtvalor.ReadOnly = True
        Me.txtvalor.Size = New System.Drawing.Size(84, 25)
        Me.txtvalor.TabIndex = 273
        Me.txtvalor.Text = "0.00"
        Me.txtvalor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label45.Location = New System.Drawing.Point(445, 79)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(61, 19)
        Me.Label45.TabIndex = 272
        Me.Label45.Text = "Cambio"
        '
        'cboBancoRecepcion
        '
        Me.cboBancoRecepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboBancoRecepcion.Location = New System.Drawing.Point(299, 98)
        Me.cboBancoRecepcion.Name = "cboBancoRecepcion"
        Me.cboBancoRecepcion.Size = New System.Drawing.Size(130, 23)
        Me.cboBancoRecepcion.TabIndex = 269
        '
        'Label43
        '
        Me.Label43.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(11, 100)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(59, 19)
        Me.Label43.TabIndex = 268
        Me.Label43.Text = "Cuenta:"
        '
        'cboCuentaRecepcion
        '
        Me.cboCuentaRecepcion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboCuentaRecepcion.FormattingEnabled = True
        Me.cboCuentaRecepcion.Location = New System.Drawing.Point(99, 98)
        Me.cboCuentaRecepcion.Name = "cboCuentaRecepcion"
        Me.cboCuentaRecepcion.Size = New System.Drawing.Size(135, 23)
        Me.cboCuentaRecepcion.TabIndex = 267
        '
        'txtComentarioPago
        '
        Me.txtComentarioPago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComentarioPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioPago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioPago.Location = New System.Drawing.Point(99, 71)
        Me.txtComentarioPago.Name = "txtComentarioPago"
        Me.txtComentarioPago.Size = New System.Drawing.Size(330, 25)
        Me.txtComentarioPago.TabIndex = 265
        '
        'Label40
        '
        Me.Label40.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(11, 74)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 19)
        Me.Label40.TabIndex = 264
        Me.Label40.Text = "Comentario:"
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackColor = System.Drawing.Color.White
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(240, 123)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(189, 24)
        Me.Button9.TabIndex = 263
        Me.Button9.Text = "Agregar pago"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'grdpago
        '
        Me.grdpago.AllowUserToAddRows = False
        Me.grdpago.AllowUserToDeleteRows = False
        Me.grdpago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdpago.BackgroundColor = System.Drawing.Color.White
        Me.grdpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpago.ColumnHeadersVisible = False
        Me.grdpago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column9, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31})
        Me.grdpago.Location = New System.Drawing.Point(13, 151)
        Me.grdpago.Name = "grdpago"
        Me.grdpago.ReadOnly = True
        Me.grdpago.RowHeadersVisible = False
        Me.grdpago.Size = New System.Drawing.Size(416, 108)
        Me.grdpago.TabIndex = 262
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
        'Column27
        '
        Me.Column27.HeaderText = "BancoRe"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        Me.Column27.Visible = False
        '
        'Column28
        '
        Me.Column28.HeaderText = "CuentaRe"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        Me.Column28.Visible = False
        '
        'Column29
        '
        Me.Column29.HeaderText = "valor"
        Me.Column29.Name = "Column29"
        Me.Column29.ReadOnly = True
        Me.Column29.Visible = False
        Me.Column29.Width = 5
        '
        'Column30
        '
        Me.Column30.HeaderText = "equivale"
        Me.Column30.Name = "Column30"
        Me.Column30.ReadOnly = True
        Me.Column30.Visible = False
        Me.Column30.Width = 5
        '
        'Column31
        '
        Me.Column31.HeaderText = "dolar"
        Me.Column31.Name = "Column31"
        Me.Column31.ReadOnly = True
        Me.Column31.Visible = False
        Me.Column31.Width = 5
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(11, 126)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 19)
        Me.Label30.TabIndex = 261
        Me.Label30.Text = "Fecha:"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(449, 18)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 20)
        Me.Label18.TabIndex = 258
        Me.Label18.Text = "Total pagos:"
        '
        'txtMontoP
        '
        Me.txtMontoP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMontoP.BackColor = System.Drawing.Color.White
        Me.txtMontoP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoP.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoP.ForeColor = System.Drawing.Color.Black
        Me.txtMontoP.Location = New System.Drawing.Point(446, 43)
        Me.txtMontoP.Name = "txtMontoP"
        Me.txtMontoP.ReadOnly = True
        Me.txtMontoP.Size = New System.Drawing.Size(100, 31)
        Me.txtMontoP.TabIndex = 257
        Me.txtMontoP.Text = "0.00"
        Me.txtMontoP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(566, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 20)
        Me.Label27.TabIndex = 256
        Me.Label27.Text = "Subtotal:"
        '
        'dtpFecha_P
        '
        Me.dtpFecha_P.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha_P.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha_P.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha_P.Location = New System.Drawing.Point(99, 123)
        Me.dtpFecha_P.Name = "dtpFecha_P"
        Me.dtpFecha_P.Size = New System.Drawing.Size(135, 25)
        Me.dtpFecha_P.TabIndex = 260
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BackColor = System.Drawing.Color.White
        Me.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(549, 43)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(107, 31)
        Me.txtSubTotal.TabIndex = 255
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(659, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 20)
        Me.Label26.TabIndex = 254
        Me.Label26.Text = "Descuento: ($)"
        '
        'txtdescuento2
        '
        Me.txtdescuento2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdescuento2.BackColor = System.Drawing.Color.White
        Me.txtdescuento2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescuento2.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento2.ForeColor = System.Drawing.Color.Black
        Me.txtdescuento2.Location = New System.Drawing.Point(659, 43)
        Me.txtdescuento2.Name = "txtdescuento2"
        Me.txtdescuento2.ReadOnly = True
        Me.txtdescuento2.Size = New System.Drawing.Size(113, 31)
        Me.txtdescuento2.TabIndex = 253
        Me.txtdescuento2.Text = "0.00"
        Me.txtdescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(815, 18)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(105, 20)
        Me.Label25.TabIndex = 252
        Me.Label25.Text = "Total a pagar:"
        '
        'txtPagar
        '
        Me.txtPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPagar.BackColor = System.Drawing.Color.Navy
        Me.txtPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagar.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagar.ForeColor = System.Drawing.Color.White
        Me.txtPagar.Location = New System.Drawing.Point(775, 43)
        Me.txtPagar.Name = "txtPagar"
        Me.txtPagar.ReadOnly = True
        Me.txtPagar.Size = New System.Drawing.Size(145, 39)
        Me.txtPagar.TabIndex = 251
        Me.txtPagar.Text = "0.00"
        Me.txtPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.txtdescu)
        Me.GroupBox5.Controls.Add(Me.Label44)
        Me.GroupBox5.Controls.Add(Me.picQR)
        Me.GroupBox5.Controls.Add(Me.txtdescuento1)
        Me.GroupBox5.Controls.Add(Me.Label33)
        Me.GroupBox5.Controls.Add(Me.txtefectivo)
        Me.GroupBox5.Controls.Add(Me.Label32)
        Me.GroupBox5.Controls.Add(Me.txtCambio)
        Me.GroupBox5.Controls.Add(Me.Label31)
        Me.GroupBox5.Location = New System.Drawing.Point(523, 84)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(397, 93)
        Me.GroupBox5.TabIndex = 259
        Me.GroupBox5.TabStop = False
        '
        'txtdescu
        '
        Me.txtdescu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescu.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdescu.Location = New System.Drawing.Point(75, 20)
        Me.txtdescu.Name = "txtdescu"
        Me.txtdescu.Size = New System.Drawing.Size(117, 27)
        Me.txtdescu.TabIndex = 211
        Me.txtdescu.Text = "0.00"
        Me.txtdescu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(6, 23)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(63, 20)
        Me.Label44.TabIndex = 210
        Me.Label44.Text = "$ Desc.:"
        '
        'picQR
        '
        Me.picQR.BackColor = System.Drawing.Color.White
        Me.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQR.Location = New System.Drawing.Point(-43, -60)
        Me.picQR.Margin = New System.Windows.Forms.Padding(10)
        Me.picQR.Name = "picQR"
        Me.picQR.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
        Me.picQR.Size = New System.Drawing.Size(57, 55)
        Me.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQR.TabIndex = 209
        Me.picQR.TabStop = False
        Me.picQR.Visible = False
        '
        'txtdescuento1
        '
        Me.txtdescuento1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescuento1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento1.Location = New System.Drawing.Point(75, 53)
        Me.txtdescuento1.Name = "txtdescuento1"
        Me.txtdescuento1.Size = New System.Drawing.Size(117, 29)
        Me.txtdescuento1.TabIndex = 171
        Me.txtdescuento1.Text = "0"
        Me.txtdescuento1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label33.Location = New System.Drawing.Point(6, 57)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 20)
        Me.Label33.TabIndex = 170
        Me.Label33.Text = "% Desc.:"
        '
        'txtefectivo
        '
        Me.txtefectivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtefectivo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtefectivo.ForeColor = System.Drawing.Color.Blue
        Me.txtefectivo.Location = New System.Drawing.Point(274, 19)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(116, 29)
        Me.txtefectivo.TabIndex = 169
        Me.txtefectivo.Text = "0.00"
        Me.txtefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label32.Location = New System.Drawing.Point(200, 23)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(69, 20)
        Me.Label32.TabIndex = 168
        Me.Label32.Text = "Efectivo:"
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.White
        Me.txtCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCambio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.ForeColor = System.Drawing.Color.Green
        Me.txtCambio.Location = New System.Drawing.Point(274, 53)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(116, 29)
        Me.txtCambio.TabIndex = 167
        Me.txtCambio.Text = "0.00"
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label31.Location = New System.Drawing.Point(200, 57)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 20)
        Me.Label31.TabIndex = 166
        Me.Label31.Text = "Cambio:"
        '
        'cbotpago
        '
        Me.cbotpago.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbotpago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotpago.FormattingEnabled = True
        Me.cbotpago.Location = New System.Drawing.Point(99, 17)
        Me.cbotpago.Name = "cbotpago"
        Me.cbotpago.Size = New System.Drawing.Size(135, 25)
        Me.cbotpago.TabIndex = 243
        '
        'txtmonto
        '
        Me.txtmonto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtmonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmonto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.Location = New System.Drawing.Point(299, 44)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(130, 25)
        Me.txtmonto.TabIndex = 250
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbobanco
        '
        Me.cbobanco.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbobanco.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(299, 17)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(130, 25)
        Me.cbobanco.TabIndex = 245
        '
        'Label24
        '
        Me.Label24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(240, 47)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(57, 19)
        Me.Label24.TabIndex = 249
        Me.Label24.Text = "Monto:"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(240, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 19)
        Me.Label22.TabIndex = 246
        Me.Label22.Text = "Banco:"
        '
        'txtnumref
        '
        Me.txtnumref.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtnumref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumref.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumref.Location = New System.Drawing.Point(99, 44)
        Me.txtnumref.Name = "txtnumref"
        Me.txtnumref.Size = New System.Drawing.Size(135, 25)
        Me.txtnumref.TabIndex = 248
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(11, 47)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 19)
        Me.Label23.TabIndex = 247
        Me.Label23.Text = "Número:"
        '
        'Label41
        '
        Me.Label41.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(240, 100)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 19)
        Me.Label41.TabIndex = 266
        Me.Label41.Text = "Banco:"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(11, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(82, 19)
        Me.Label21.TabIndex = 244
        Me.Label21.Text = "Tipo pago:"
        '
        'pComanda80
        '
        '
        'p_envio
        '
        '
        'p_recoge_t
        '
        '
        'lblt_pago
        '
        Me.lblt_pago.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblt_pago.Location = New System.Drawing.Point(269, 530)
        Me.lblt_pago.Name = "lblt_pago"
        Me.lblt_pago.Size = New System.Drawing.Size(224, 25)
        Me.lblt_pago.TabIndex = 269
        Me.lblt_pago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(171, 533)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(92, 19)
        Me.Label29.TabIndex = 268
        Me.Label29.Text = "Tipo de pago:"
        '
        'frmPedidos_Tienda
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1110, 622)
        Me.Controls.Add(Me.lblt_pago)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.box_Pago)
        Me.Controls.Add(Me.btn_entregado)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txt_envio)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.lbltipo_envio)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btn_produccion)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtacuenta)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtresta)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_subtotal)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_metodo_pago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_referencia)
        Me.Controls.Add(Me.cbofolio)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cbonombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.lblNumCliente)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1126, 661)
        Me.Name = "frmPedidos_Tienda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos tienda"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.box_Pago.ResumeLayout(False)
        Me.box_Pago.PerformLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents lblusuario As Label
    Friend WithEvents lblNumCliente As Label
    Friend WithEvents cbofolio As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents cbonombre As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdireccion As RichTextBox
    Friend WithEvents txt_referencia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_metodo_pago As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtacuenta As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtresta As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_total As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_subtotal As TextBox
    Friend WithEvents btn_produccion As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents lbltipo_envio As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Panel5 As Panel
    Friend WithEvents opt_pendientes As RadioButton
    Friend WithEvents opt_entregados As RadioButton
    Friend WithEvents Label17 As Label
    Friend WithEvents txt_envio As TextBox
    Friend WithEvents btn_entregado As Button
    Friend WithEvents box_Pago As GroupBox
    Friend WithEvents txtequivale As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents txtvalor As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents cboBancoRecepcion As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents cboCuentaRecepcion As ComboBox
    Friend WithEvents txtComentarioPago As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents Button9 As Button
    Friend WithEvents grdpago As DataGridView
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column29 As DataGridViewTextBoxColumn
    Friend WithEvents Column30 As DataGridViewTextBoxColumn
    Friend WithEvents Column31 As DataGridViewTextBoxColumn
    Friend WithEvents Label30 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtMontoP As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents dtpFecha_P As DateTimePicker
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtdescuento2 As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtPagar As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtdescu As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents picQR As PictureBox
    Friend WithEvents txtdescuento1 As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtefectivo As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtCambio As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents cbotpago As ComboBox
    Friend WithEvents txtmonto As TextBox
    Friend WithEvents cbobanco As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtnumref As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents pComanda80 As Printing.PrintDocument
    Friend WithEvents pComanda58 As Printing.PrintDocument
    Friend WithEvents p_envio As Printing.PrintDocument
    Friend WithEvents p_recoge_t As Printing.PrintDocument
    Friend WithEvents lblt_pago As Label
    Friend WithEvents Label29 As Label
End Class
