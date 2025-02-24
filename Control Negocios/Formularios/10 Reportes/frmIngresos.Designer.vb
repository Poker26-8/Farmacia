<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdpagos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtdevolucionesformas = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtcancelacionestotales = New System.Windows.Forms.TextBox()
        Me.txttotalformas = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.optVendedor = New System.Windows.Forms.RadioButton()
        Me.MC2 = New System.Windows.Forms.MonthCalendar()
        Me.MC1 = New System.Windows.Forms.MonthCalendar()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdpagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.TabIndex = 228
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(9, 75)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(128, 17)
        Me.RadioButton2.TabIndex = 371
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Ver todos los registros"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdpagos)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 474)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 108)
        Me.GroupBox1.TabIndex = 370
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingresos"
        '
        'grdpagos
        '
        Me.grdpagos.AllowUserToAddRows = False
        Me.grdpagos.AllowUserToDeleteRows = False
        Me.grdpagos.BackgroundColor = System.Drawing.Color.White
        Me.grdpagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.grdpagos.Location = New System.Drawing.Point(4, 18)
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
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(751, 632)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(151, 13)
        Me.Label21.TabIndex = 369
        Me.Label21.Text = "Devoluciones formas de pago:"
        '
        'txtdevolucionesformas
        '
        Me.txtdevolucionesformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdevolucionesformas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtdevolucionesformas.Location = New System.Drawing.Point(924, 629)
        Me.txtdevolucionesformas.Name = "txtdevolucionesformas"
        Me.txtdevolucionesformas.Size = New System.Drawing.Size(85, 20)
        Me.txtdevolucionesformas.TabIndex = 368
        Me.txtdevolucionesformas.Text = "0.00"
        Me.txtdevolucionesformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(746, 570)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(156, 13)
        Me.Label20.TabIndex = 367
        Me.Label20.Text = "Cancelaciones formas de pago:"
        '
        'txtcancelacionestotales
        '
        Me.txtcancelacionestotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcancelacionestotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtcancelacionestotales.Location = New System.Drawing.Point(924, 569)
        Me.txtcancelacionestotales.Name = "txtcancelacionestotales"
        Me.txtcancelacionestotales.Size = New System.Drawing.Size(85, 20)
        Me.txtcancelacionestotales.TabIndex = 366
        Me.txtcancelacionestotales.Text = "0.00"
        Me.txtcancelacionestotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalformas
        '
        Me.txttotalformas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotalformas.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txttotalformas.Location = New System.Drawing.Point(924, 509)
        Me.txttotalformas.Name = "txttotalformas"
        Me.txttotalformas.Size = New System.Drawing.Size(85, 20)
        Me.txttotalformas.TabIndex = 365
        Me.txttotalformas.Text = "0.00"
        Me.txttotalformas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(767, 513)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 13)
        Me.Label19.TabIndex = 364
        Me.Label19.Text = "Ingreso en formas de pago:"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.Location = New System.Drawing.Point(522, 597)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 18)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "Saldo Formas Pago:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSalTarj
        '
        Me.txtSalTarj.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalTarj.Location = New System.Drawing.Point(645, 594)
        Me.txtSalTarj.Name = "txtSalTarj"
        Me.txtSalTarj.Size = New System.Drawing.Size(85, 20)
        Me.txtSalTarj.TabIndex = 361
        Me.txtSalTarj.Text = "0.00"
        Me.txtSalTarj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(547, 569)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 360
        Me.Label10.Text = "Efectivo en caja:"
        '
        'txtEfeCaja
        '
        Me.txtEfeCaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfeCaja.Location = New System.Drawing.Point(645, 566)
        Me.txtEfeCaja.Name = "txtEfeCaja"
        Me.txtEfeCaja.Size = New System.Drawing.Size(85, 20)
        Me.txtEfeCaja.TabIndex = 359
        Me.txtEfeCaja.Text = "0.00"
        Me.txtEfeCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(570, 541)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 13)
        Me.Label16.TabIndex = 358
        Me.Label16.Text = "Saldo final:"
        '
        'txtTotalAbono
        '
        Me.txtTotalAbono.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalAbono.BackColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotalAbono.ForeColor = System.Drawing.Color.White
        Me.txtTotalAbono.Location = New System.Drawing.Point(645, 538)
        Me.txtTotalAbono.Name = "txtTotalAbono"
        Me.txtTotalAbono.Size = New System.Drawing.Size(85, 20)
        Me.txtTotalAbono.TabIndex = 357
        Me.txtTotalAbono.Text = "0.00"
        Me.txtTotalAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(557, 513)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 356
        Me.Label17.Text = "Total egresos:"
        '
        'txtEgresos
        '
        Me.txtEgresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEgresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtEgresos.Location = New System.Drawing.Point(645, 510)
        Me.txtEgresos.Name = "txtEgresos"
        Me.txtEgresos.Size = New System.Drawing.Size(85, 20)
        Me.txtEgresos.TabIndex = 355
        Me.txtEgresos.Text = "0.00"
        Me.txtEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(557, 485)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 13)
        Me.Label18.TabIndex = 354
        Me.Label18.Text = "Total ingresos:"
        '
        'txtIngresos
        '
        Me.txtIngresos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIngresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txtIngresos.Location = New System.Drawing.Point(645, 482)
        Me.txtIngresos.Name = "txtIngresos"
        Me.txtIngresos.Size = New System.Drawing.Size(85, 20)
        Me.txtIngresos.TabIndex = 353
        Me.txtIngresos.Text = "0.00"
        Me.txtIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(819, 482)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 13)
        Me.Label15.TabIndex = 352
        Me.Label15.Text = "Ingresos efectivo:"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer))
        Me.txtEfectivo.Location = New System.Drawing.Point(924, 479)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(85, 20)
        Me.txtEfectivo.TabIndex = 351
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(792, 602)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 350
        Me.Label3.Text = "Devoluciones efectivo:"
        '
        'txtDevoefectivo
        '
        Me.txtDevoefectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDevoefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtDevoefectivo.Location = New System.Drawing.Point(924, 600)
        Me.txtDevoefectivo.Name = "txtDevoefectivo"
        Me.txtDevoefectivo.Size = New System.Drawing.Size(85, 20)
        Me.txtDevoefectivo.TabIndex = 349
        Me.txtDevoefectivo.Text = "0.00"
        Me.txtDevoefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(787, 542)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 348
        Me.Label2.Text = "Cancelaciones efectivo:"
        '
        'txtCancelaefectivo
        '
        Me.txtCancelaefectivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCancelaefectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtCancelaefectivo.Location = New System.Drawing.Point(924, 539)
        Me.txtCancelaefectivo.Name = "txtCancelaefectivo"
        Me.txtCancelaefectivo.Size = New System.Drawing.Size(85, 20)
        Me.txtCancelaefectivo.TabIndex = 347
        Me.txtCancelaefectivo.Text = "0.00"
        Me.txtCancelaefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 104)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(246, 21)
        Me.ComboBox1.TabIndex = 343
        '
        'optVendedor
        '
        Me.optVendedor.AutoSize = True
        Me.optVendedor.Location = New System.Drawing.Point(9, 50)
        Me.optVendedor.Name = "optVendedor"
        Me.optVendedor.Size = New System.Drawing.Size(150, 17)
        Me.optVendedor.TabIndex = 342
        Me.optVendedor.TabStop = True
        Me.optVendedor.Text = "Movimientos por vendedor"
        Me.optVendedor.UseVisualStyleBackColor = True
        '
        'MC2
        '
        Me.MC2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MC2.Location = New System.Drawing.Point(761, 50)
        Me.MC2.Name = "MC2"
        Me.MC2.TabIndex = 341
        '
        'MC1
        '
        Me.MC1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MC1.Location = New System.Drawing.Point(495, 50)
        Me.MC1.Name = "MC1"
        Me.MC1.TabIndex = 340
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
        Me.grdcaptura.Location = New System.Drawing.Point(11, 224)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(998, 229)
        Me.grdcaptura.TabIndex = 344
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.Location = New System.Drawing.Point(357, 50)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(60, 63)
        Me.btnExportar.TabIndex = 363
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(291, 50)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 346
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
        Me.btnNuevo.Location = New System.Drawing.Point(423, 50)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 345
        Me.btnNuevo.Text = "Limpiar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmIngresos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1015, 661)
        Me.Controls.Add(Me.RadioButton2)
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
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.optVendedor)
        Me.Controls.Add(Me.MC2)
        Me.Controls.Add(Me.MC1)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIngresos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de ingresos"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdpagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdpagos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Label21 As Label
    Friend WithEvents txtdevolucionesformas As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtcancelacionestotales As TextBox
    Friend WithEvents txttotalformas As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
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
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents optVendedor As RadioButton
    Friend WithEvents MC2 As MonthCalendar
    Friend WithEvents MC1 As MonthCalendar
    Friend WithEvents grdcaptura As DataGridView
End Class
