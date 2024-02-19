<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepEntradas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepEntradas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSalTarj = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtEfeCaja = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalAbono = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEgresos = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtIngresos = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDevoefectivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCancelaefectivo = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.optEgresosTransferencia = New System.Windows.Forms.RadioButton()
        Me.optAbonosTransferencia = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.optEgresosTarjeta = New System.Windows.Forms.RadioButton()
        Me.optAbonosTarjeta = New System.Windows.Forms.RadioButton()
        Me.optCargosEfectivo = New System.Windows.Forms.RadioButton()
        Me.optAbonoEfectivo = New System.Windows.Forms.RadioButton()
        Me.optVendedor = New System.Windows.Forms.RadioButton()
        Me.MC2 = New System.Windows.Forms.MonthCalendar()
        Me.MC1 = New System.Windows.Forms.MonthCalendar()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.grdpagos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txttotalformas = New System.Windows.Forms.TextBox()
        Me.grdCanceñlaciones = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtcancelacionestotales = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtdevolucionesformas = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grddevoluciones = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboFormaPago = New System.Windows.Forms.ComboBox()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdpagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCanceñlaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grddevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(1015, 31)
        Me.Label1.TabIndex = 227
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(521, 529)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 18)
        Me.Label9.TabIndex = 319
        Me.Label9.Text = "Saldo Formas Pago:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSalTarj
        '
        Me.txtSalTarj.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalTarj.Location = New System.Drawing.Point(644, 526)
        Me.txtSalTarj.Name = "txtSalTarj"
        Me.txtSalTarj.Size = New System.Drawing.Size(85, 23)
        Me.txtSalTarj.TabIndex = 318
        Me.txtSalTarj.Text = "0.00"
        Me.txtSalTarj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(546, 501)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 317
        Me.Label10.Text = "Efectivo en caja:"
        '
        'txtEfeCaja
        '
        Me.txtEfeCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfeCaja.Location = New System.Drawing.Point(644, 498)
        Me.txtEfeCaja.Name = "txtEfeCaja"
        Me.txtEfeCaja.Size = New System.Drawing.Size(85, 23)
        Me.txtEfeCaja.TabIndex = 316
        Me.txtEfeCaja.Text = "0.00"
        Me.txtEfeCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(569, 473)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 15)
        Me.Label16.TabIndex = 315
        Me.Label16.Text = "Saldo final:"
        '
        'txtTotalAbono
        '
        Me.txtTotalAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAbono.BackColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotalAbono.ForeColor = System.Drawing.Color.White
        Me.txtTotalAbono.Location = New System.Drawing.Point(644, 470)
        Me.txtTotalAbono.Name = "txtTotalAbono"
        Me.txtTotalAbono.Size = New System.Drawing.Size(85, 23)
        Me.txtTotalAbono.TabIndex = 314
        Me.txtTotalAbono.Text = "0.00"
        Me.txtTotalAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(556, 445)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 15)
        Me.Label17.TabIndex = 313
        Me.Label17.Text = "Total egresos:"
        '
        'txtEgresos
        '
        Me.txtEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEgresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtEgresos.Location = New System.Drawing.Point(644, 442)
        Me.txtEgresos.Name = "txtEgresos"
        Me.txtEgresos.Size = New System.Drawing.Size(85, 23)
        Me.txtEgresos.TabIndex = 312
        Me.txtEgresos.Text = "0.00"
        Me.txtEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(556, 417)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 15)
        Me.Label18.TabIndex = 311
        Me.Label18.Text = "Total ingresos:"
        '
        'txtIngresos
        '
        Me.txtIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIngresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txtIngresos.Location = New System.Drawing.Point(644, 414)
        Me.txtIngresos.Name = "txtIngresos"
        Me.txtIngresos.Size = New System.Drawing.Size(85, 23)
        Me.txtIngresos.TabIndex = 310
        Me.txtIngresos.Text = "0.00"
        Me.txtIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(818, 414)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 15)
        Me.Label15.TabIndex = 301
        Me.Label15.Text = "Ingresos efectivo:"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txtEfectivo.Location = New System.Drawing.Point(923, 411)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(85, 23)
        Me.txtEfectivo.TabIndex = 300
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(791, 534)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 15)
        Me.Label3.TabIndex = 291
        Me.Label3.Text = "Devoluciones efectivo:"
        '
        'txtDevoefectivo
        '
        Me.txtDevoefectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDevoefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtDevoefectivo.Location = New System.Drawing.Point(923, 532)
        Me.txtDevoefectivo.Name = "txtDevoefectivo"
        Me.txtDevoefectivo.Size = New System.Drawing.Size(85, 23)
        Me.txtDevoefectivo.TabIndex = 290
        Me.txtDevoefectivo.Text = "0.00"
        Me.txtDevoefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(786, 474)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 15)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Cancelaciones efectivo:"
        '
        'txtCancelaefectivo
        '
        Me.txtCancelaefectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCancelaefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtCancelaefectivo.Location = New System.Drawing.Point(923, 471)
        Me.txtCancelaefectivo.Name = "txtCancelaefectivo"
        Me.txtCancelaefectivo.Size = New System.Drawing.Size(85, 23)
        Me.txtCancelaefectivo.TabIndex = 288
        Me.txtCancelaefectivo.Text = "0.00"
        Me.txtCancelaefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(356, 40)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 287
        Me.btnGuardar.Text = "Reporte"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(422, 40)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 286
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'optEgresosTransferencia
        '
        Me.optEgresosTransferencia.AutoSize = True
        Me.optEgresosTransferencia.Location = New System.Drawing.Point(278, 629)
        Me.optEgresosTransferencia.Name = "optEgresosTransferencia"
        Me.optEgresosTransferencia.Size = New System.Drawing.Size(254, 19)
        Me.optEgresosTransferencia.TabIndex = 284
        Me.optEgresosTransferencia.TabStop = True
        Me.optEgresosTransferencia.Text = "Devoluciones / Cancelaciones tranferencias"
        Me.optEgresosTransferencia.UseVisualStyleBackColor = True
        Me.optEgresosTransferencia.Visible = False
        '
        'optAbonosTransferencia
        '
        Me.optAbonosTransferencia.AutoSize = True
        Me.optAbonosTransferencia.Location = New System.Drawing.Point(278, 609)
        Me.optAbonosTransferencia.Name = "optAbonosTransferencia"
        Me.optAbonosTransferencia.Size = New System.Drawing.Size(201, 19)
        Me.optAbonosTransferencia.TabIndex = 283
        Me.optAbonosTransferencia.TabStop = True
        Me.optAbonosTransferencia.Text = "Devoluciones en formas de pago "
        Me.optAbonosTransferencia.UseVisualStyleBackColor = True
        Me.optAbonosTransferencia.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(5, 65)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(246, 23)
        Me.ComboBox1.TabIndex = 282
        '
        'optEgresosTarjeta
        '
        Me.optEgresosTarjeta.AutoSize = True
        Me.optEgresosTarjeta.Location = New System.Drawing.Point(278, 589)
        Me.optEgresosTarjeta.Name = "optEgresosTarjeta"
        Me.optEgresosTarjeta.Size = New System.Drawing.Size(203, 19)
        Me.optEgresosTarjeta.TabIndex = 281
        Me.optEgresosTarjeta.TabStop = True
        Me.optEgresosTarjeta.Text = "Cancelaciones en formas de pago"
        Me.optEgresosTarjeta.UseVisualStyleBackColor = True
        Me.optEgresosTarjeta.Visible = False
        '
        'optAbonosTarjeta
        '
        Me.optAbonosTarjeta.AutoSize = True
        Me.optAbonosTarjeta.Location = New System.Drawing.Point(278, 569)
        Me.optAbonosTarjeta.Name = "optAbonosTarjeta"
        Me.optAbonosTarjeta.Size = New System.Drawing.Size(168, 19)
        Me.optAbonosTarjeta.TabIndex = 280
        Me.optAbonosTarjeta.TabStop = True
        Me.optAbonosTarjeta.Text = "Abonos en formas de pago"
        Me.optAbonosTarjeta.UseVisualStyleBackColor = True
        Me.optAbonosTarjeta.Visible = False
        '
        'optCargosEfectivo
        '
        Me.optCargosEfectivo.AutoSize = True
        Me.optCargosEfectivo.Location = New System.Drawing.Point(278, 549)
        Me.optCargosEfectivo.Name = "optCargosEfectivo"
        Me.optCargosEfectivo.Size = New System.Drawing.Size(244, 19)
        Me.optCargosEfectivo.TabIndex = 279
        Me.optCargosEfectivo.TabStop = True
        Me.optCargosEfectivo.Text = "Devoluciones / Cancelaciones en efectivo"
        Me.optCargosEfectivo.UseVisualStyleBackColor = True
        Me.optCargosEfectivo.Visible = False
        '
        'optAbonoEfectivo
        '
        Me.optAbonoEfectivo.AutoSize = True
        Me.optAbonoEfectivo.Location = New System.Drawing.Point(278, 529)
        Me.optAbonoEfectivo.Name = "optAbonoEfectivo"
        Me.optAbonoEfectivo.Size = New System.Drawing.Size(127, 19)
        Me.optAbonoEfectivo.TabIndex = 278
        Me.optAbonoEfectivo.TabStop = True
        Me.optAbonoEfectivo.Text = "Abonos en efectivo"
        Me.optAbonoEfectivo.UseVisualStyleBackColor = True
        Me.optAbonoEfectivo.Visible = False
        '
        'optVendedor
        '
        Me.optVendedor.AutoSize = True
        Me.optVendedor.Location = New System.Drawing.Point(8, 40)
        Me.optVendedor.Name = "optVendedor"
        Me.optVendedor.Size = New System.Drawing.Size(169, 19)
        Me.optVendedor.TabIndex = 277
        Me.optVendedor.TabStop = True
        Me.optVendedor.Text = "Movimientos por vendedor"
        Me.optVendedor.UseVisualStyleBackColor = True
        '
        'MC2
        '
        Me.MC2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MC2.Location = New System.Drawing.Point(760, 40)
        Me.MC2.Name = "MC2"
        Me.MC2.TabIndex = 276
        '
        'MC1
        '
        Me.MC1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MC1.Location = New System.Drawing.Point(494, 40)
        Me.MC1.Name = "MC1"
        Me.MC1.TabIndex = 275
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Location = New System.Drawing.Point(10, 214)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(998, 185)
        Me.grdcaptura.TabIndex = 285
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(290, 40)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(60, 63)
        Me.btnExportar.TabIndex = 320
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'grdpagos
        '
        Me.grdpagos.AllowUserToAddRows = False
        Me.grdpagos.AllowUserToDeleteRows = False
        Me.grdpagos.BackgroundColor = System.Drawing.Color.White
        Me.grdpagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.grdpagos.Location = New System.Drawing.Point(6, 19)
        Me.grdpagos.Name = "grdpagos"
        Me.grdpagos.ReadOnly = True
        Me.grdpagos.RowHeadersVisible = False
        Me.grdpagos.Size = New System.Drawing.Size(237, 84)
        Me.grdpagos.TabIndex = 323
        '
        'Column1
        '
        Me.Column1.HeaderText = "Forma de Pago"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 134
        '
        'Column2
        '
        Me.Column2.HeaderText = "Total"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(766, 445)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(151, 15)
        Me.Label19.TabIndex = 324
        Me.Label19.Text = "Ingreso en formas de pago:"
        '
        'txttotalformas
        '
        Me.txttotalformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotalformas.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txttotalformas.Location = New System.Drawing.Point(923, 441)
        Me.txttotalformas.Name = "txttotalformas"
        Me.txttotalformas.Size = New System.Drawing.Size(85, 23)
        Me.txttotalformas.TabIndex = 325
        Me.txttotalformas.Text = "0.00"
        Me.txttotalformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grdCanceñlaciones
        '
        Me.grdCanceñlaciones.AllowUserToAddRows = False
        Me.grdCanceñlaciones.AllowUserToDeleteRows = False
        Me.grdCanceñlaciones.BackgroundColor = System.Drawing.Color.White
        Me.grdCanceñlaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCanceñlaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.grdCanceñlaciones.Location = New System.Drawing.Point(6, 22)
        Me.grdCanceñlaciones.Name = "grdCanceñlaciones"
        Me.grdCanceñlaciones.ReadOnly = True
        Me.grdCanceñlaciones.RowHeadersVisible = False
        Me.grdCanceñlaciones.Size = New System.Drawing.Size(237, 81)
        Me.grdCanceñlaciones.TabIndex = 326
        '
        'Column3
        '
        Me.Column3.HeaderText = "Forma de pago"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 134
        '
        'Column4
        '
        Me.Column4.HeaderText = "Total"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(745, 502)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(172, 15)
        Me.Label20.TabIndex = 328
        Me.Label20.Text = "Cancelaciones formas de pago:"
        '
        'txtcancelacionestotales
        '
        Me.txtcancelacionestotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcancelacionestotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtcancelacionestotales.Location = New System.Drawing.Point(923, 501)
        Me.txtcancelacionestotales.Name = "txtcancelacionestotales"
        Me.txtcancelacionestotales.Size = New System.Drawing.Size(85, 23)
        Me.txtcancelacionestotales.TabIndex = 327
        Me.txtcancelacionestotales.Text = "0.00"
        Me.txtcancelacionestotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(750, 564)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(167, 15)
        Me.Label21.TabIndex = 330
        Me.Label21.Text = "Devoluciones formas de pago:"
        '
        'txtdevolucionesformas
        '
        Me.txtdevolucionesformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdevolucionesformas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtdevolucionesformas.Location = New System.Drawing.Point(923, 561)
        Me.txtdevolucionesformas.Name = "txtdevolucionesformas"
        Me.txtdevolucionesformas.Size = New System.Drawing.Size(85, 23)
        Me.txtdevolucionesformas.TabIndex = 329
        Me.txtdevolucionesformas.Text = "0.00"
        Me.txtdevolucionesformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdpagos)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 405)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 108)
        Me.GroupBox1.TabIndex = 333
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingresos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grdCanceñlaciones)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(273, 406)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 118)
        Me.GroupBox2.TabIndex = 334
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cancelaciones"
        '
        'grddevoluciones
        '
        Me.grddevoluciones.AllowUserToAddRows = False
        Me.grddevoluciones.AllowUserToDeleteRows = False
        Me.grddevoluciones.BackgroundColor = System.Drawing.Color.White
        Me.grddevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grddevoluciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6})
        Me.grddevoluciones.Location = New System.Drawing.Point(5, 16)
        Me.grddevoluciones.Name = "grddevoluciones"
        Me.grddevoluciones.ReadOnly = True
        Me.grddevoluciones.RowHeadersVisible = False
        Me.grddevoluciones.Size = New System.Drawing.Size(238, 84)
        Me.grddevoluciones.TabIndex = 335
        '
        'Column5
        '
        Me.Column5.HeaderText = "Forma de pago"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 134
        '
        'Column6
        '
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.grddevoluciones)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(5, 524)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 109)
        Me.GroupBox3.TabIndex = 336
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Devoluciones"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.FormattingEnabled = True
        Me.cboFormaPago.Location = New System.Drawing.Point(572, 601)
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(145, 23)
        Me.cboFormaPago.TabIndex = 337
        Me.cboFormaPago.Visible = False
        '
        'frmRepEntradas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1015, 640)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtdevolucionesformas)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtcancelacionestotales)
        Me.Controls.Add(Me.txttotalformas)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSalTarj)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtEfeCaja)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtTotalAbono)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtEgresos)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtIngresos)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDevoefectivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCancelaefectivo)
        Me.Controls.Add(Me.optEgresosTransferencia)
        Me.Controls.Add(Me.optAbonosTransferencia)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.optEgresosTarjeta)
        Me.Controls.Add(Me.optAbonosTarjeta)
        Me.Controls.Add(Me.optCargosEfectivo)
        Me.Controls.Add(Me.optAbonoEfectivo)
        Me.Controls.Add(Me.optVendedor)
        Me.Controls.Add(Me.MC2)
        Me.Controls.Add(Me.MC1)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboFormaPago)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepEntradas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de ingresos y egresos"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdpagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCanceñlaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grddevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSalTarj As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtEfeCaja As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtTotalAbono As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtEgresos As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtIngresos As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDevoefectivo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCancelaefectivo As TextBox
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents optEgresosTransferencia As RadioButton
    Friend WithEvents optAbonosTransferencia As RadioButton
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents optEgresosTarjeta As RadioButton
    Friend WithEvents optAbonosTarjeta As RadioButton
    Friend WithEvents optCargosEfectivo As RadioButton
    Friend WithEvents optAbonoEfectivo As RadioButton
    Friend WithEvents optVendedor As RadioButton
    Friend WithEvents MC2 As MonthCalendar
    Friend WithEvents MC1 As MonthCalendar
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents btnExportar As Button
    Friend WithEvents grdpagos As DataGridView
    Friend WithEvents Label19 As Label
    Friend WithEvents txttotalformas As TextBox
    Friend WithEvents grdCanceñlaciones As DataGridView
    Friend WithEvents Label20 As Label
    Friend WithEvents txtcancelacionestotales As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtdevolucionesformas As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents grddevoluciones As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboFormaPago As ComboBox
End Class
