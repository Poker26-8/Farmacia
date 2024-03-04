<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepVentas))
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.opttotales = New System.Windows.Forms.RadioButton()
        Me.opttotalesdet = New System.Windows.Forms.RadioButton()
        Me.optcliente = New System.Windows.Forms.RadioButton()
        Me.optclientedet = New System.Windows.Forms.RadioButton()
        Me.optdepto = New System.Windows.Forms.RadioButton()
        Me.optgrupo = New System.Windows.Forms.RadioButton()
        Me.optproducto = New System.Windows.Forms.RadioButton()
        Me.optvendedor = New System.Windows.Forms.RadioButton()
        Me.optdevoluciones = New System.Windows.Forms.RadioButton()
        Me.optmasvendido = New System.Windows.Forms.RadioButton()
        Me.optmasvendidoprov = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.opttraspasos = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtutilidad = New System.Windows.Forms.TextBox()
        Me.lblutilidad = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lblresta = New System.Windows.Forms.Label()
        Me.txtresta = New System.Windows.Forms.TextBox()
        Me.lblacuenta = New System.Windows.Forms.Label()
        Me.txtacuenta = New System.Windows.Forms.TextBox()
        Me.lbliva = New System.Windows.Forms.Label()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.lblpeso = New System.Windows.Forms.Label()
        Me.txtpeso = New System.Windows.Forms.TextBox()
        Me.lblieps = New System.Windows.Forms.Label()
        Me.txtieps = New System.Windows.Forms.TextBox()
        Me.lblsubtotal = New System.Windows.Forms.Label()
        Me.txtsubtotal = New System.Windows.Forms.TextBox()
        Me.lbldescuento = New System.Windows.Forms.Label()
        Me.txtdescuento = New System.Windows.Forms.TextBox()
        Me.Exportar = New System.Windows.Forms.Button()
        Me.btnprint = New System.Windows.Forms.Button()
        Me.btnuevo = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpfin = New System.Windows.Forms.DateTimePicker()
        Me.optdetalle2 = New System.Windows.Forms.RadioButton()
        Me.optDerivados = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVendido = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrestante = New System.Windows.Forms.TextBox()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(486, 40)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 0
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(743, 40)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 1
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
        Me.Label1.Size = New System.Drawing.Size(1001, 31)
        Me.Label1.TabIndex = 47
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcaptura.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(10, 235)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(981, 257)
        Me.grdcaptura.TabIndex = 48
        '
        'opttotales
        '
        Me.opttotales.AutoSize = True
        Me.opttotales.Location = New System.Drawing.Point(12, 40)
        Me.opttotales.Name = "opttotales"
        Me.opttotales.Size = New System.Drawing.Size(97, 19)
        Me.opttotales.TabIndex = 49
        Me.opttotales.TabStop = True
        Me.opttotales.Text = "Ventas totales"
        Me.opttotales.UseVisualStyleBackColor = True
        '
        'opttotalesdet
        '
        Me.opttotalesdet.AutoSize = True
        Me.opttotalesdet.Location = New System.Drawing.Point(12, 63)
        Me.opttotalesdet.Name = "opttotalesdet"
        Me.opttotalesdet.Size = New System.Drawing.Size(144, 19)
        Me.opttotalesdet.TabIndex = 50
        Me.opttotalesdet.TabStop = True
        Me.opttotalesdet.Text = "Ventas totales (Detalle)"
        Me.opttotalesdet.UseVisualStyleBackColor = True
        '
        'optcliente
        '
        Me.optcliente.AutoSize = True
        Me.optcliente.Location = New System.Drawing.Point(12, 86)
        Me.optcliente.Name = "optcliente"
        Me.optcliente.Size = New System.Drawing.Size(118, 19)
        Me.optcliente.TabIndex = 51
        Me.optcliente.TabStop = True
        Me.optcliente.Text = "Ventas por cliente"
        Me.optcliente.UseVisualStyleBackColor = True
        '
        'optclientedet
        '
        Me.optclientedet.AutoSize = True
        Me.optclientedet.Location = New System.Drawing.Point(12, 109)
        Me.optclientedet.Name = "optclientedet"
        Me.optclientedet.Size = New System.Drawing.Size(165, 19)
        Me.optclientedet.TabIndex = 52
        Me.optclientedet.TabStop = True
        Me.optclientedet.Text = "Ventas por cliente (Detalle)"
        Me.optclientedet.UseVisualStyleBackColor = True
        '
        'optdepto
        '
        Me.optdepto.AutoSize = True
        Me.optdepto.Location = New System.Drawing.Point(12, 132)
        Me.optdepto.Name = "optdepto"
        Me.optdepto.Size = New System.Drawing.Size(158, 19)
        Me.optdepto.TabIndex = 53
        Me.optdepto.TabStop = True
        Me.optdepto.Text = "Ventas por departamento"
        Me.optdepto.UseVisualStyleBackColor = True
        '
        'optgrupo
        '
        Me.optgrupo.AutoSize = True
        Me.optgrupo.Location = New System.Drawing.Point(12, 155)
        Me.optgrupo.Name = "optgrupo"
        Me.optgrupo.Size = New System.Drawing.Size(115, 19)
        Me.optgrupo.TabIndex = 54
        Me.optgrupo.TabStop = True
        Me.optgrupo.Text = "Ventas por grupo"
        Me.optgrupo.UseVisualStyleBackColor = True
        '
        'optproducto
        '
        Me.optproducto.AutoSize = True
        Me.optproducto.Location = New System.Drawing.Point(225, 40)
        Me.optproducto.Name = "optproducto"
        Me.optproducto.Size = New System.Drawing.Size(132, 19)
        Me.optproducto.TabIndex = 55
        Me.optproducto.TabStop = True
        Me.optproducto.Text = "Ventas por producto"
        Me.optproducto.UseVisualStyleBackColor = True
        '
        'optvendedor
        '
        Me.optvendedor.AutoSize = True
        Me.optvendedor.Location = New System.Drawing.Point(225, 63)
        Me.optvendedor.Name = "optvendedor"
        Me.optvendedor.Size = New System.Drawing.Size(133, 19)
        Me.optvendedor.TabIndex = 56
        Me.optvendedor.TabStop = True
        Me.optvendedor.Text = "Ventas por vendedor"
        Me.optvendedor.UseVisualStyleBackColor = True
        '
        'optdevoluciones
        '
        Me.optdevoluciones.AutoSize = True
        Me.optdevoluciones.Location = New System.Drawing.Point(225, 86)
        Me.optdevoluciones.Name = "optdevoluciones"
        Me.optdevoluciones.Size = New System.Drawing.Size(96, 19)
        Me.optdevoluciones.TabIndex = 58
        Me.optdevoluciones.TabStop = True
        Me.optdevoluciones.Text = "Devoluciones"
        Me.optdevoluciones.UseVisualStyleBackColor = True
        '
        'optmasvendido
        '
        Me.optmasvendido.AutoSize = True
        Me.optmasvendido.Location = New System.Drawing.Point(225, 109)
        Me.optmasvendido.Name = "optmasvendido"
        Me.optmasvendido.Size = New System.Drawing.Size(145, 19)
        Me.optmasvendido.TabIndex = 59
        Me.optmasvendido.TabStop = True
        Me.optmasvendido.Text = "Producto más vendido"
        Me.optmasvendido.UseVisualStyleBackColor = True
        '
        'optmasvendidoprov
        '
        Me.optmasvendidoprov.AutoSize = True
        Me.optmasvendidoprov.Location = New System.Drawing.Point(225, 132)
        Me.optmasvendidoprov.Name = "optmasvendidoprov"
        Me.optmasvendidoprov.Size = New System.Drawing.Size(211, 19)
        Me.optmasvendidoprov.TabIndex = 60
        Me.optmasvendidoprov.TabStop = True
        Me.optmasvendidoprov.Text = "Producto más vendido x proveedor"
        Me.optmasvendidoprov.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(10, 206)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(252, 23)
        Me.ComboBox1.TabIndex = 61
        '
        'opttraspasos
        '
        Me.opttraspasos.AutoSize = True
        Me.opttraspasos.Location = New System.Drawing.Point(405, 40)
        Me.opttraspasos.Name = "opttraspasos"
        Me.opttraspasos.Size = New System.Drawing.Size(75, 19)
        Me.opttraspasos.TabIndex = 62
        Me.opttraspasos.TabStop = True
        Me.opttraspasos.Text = "Traspasos"
        Me.opttraspasos.UseVisualStyleBackColor = True
        Me.opttraspasos.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(10, 499)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 54)
        Me.Button2.TabIndex = 180
        Me.Button2.Text = "Reporte"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(202, 499)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 54)
        Me.Button1.TabIndex = 179
        Me.Button1.Text = "Antibióticos"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtutilidad
        '
        Me.txtutilidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtutilidad.Location = New System.Drawing.Point(898, 499)
        Me.txtutilidad.Name = "txtutilidad"
        Me.txtutilidad.Size = New System.Drawing.Size(93, 23)
        Me.txtutilidad.TabIndex = 181
        Me.txtutilidad.Text = "0.00"
        Me.txtutilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblutilidad
        '
        Me.lblutilidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblutilidad.AutoSize = True
        Me.lblutilidad.Location = New System.Drawing.Point(606, 503)
        Me.lblutilidad.Name = "lblutilidad"
        Me.lblutilidad.Size = New System.Drawing.Size(286, 15)
        Me.lblutilidad.TabIndex = 182
        Me.lblutilidad.Text = "Utilidad en relación al método de costeo establecido:"
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.Location = New System.Drawing.Point(898, 544)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(93, 23)
        Me.txttotal.TabIndex = 183
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotal
        '
        Me.lbltotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Location = New System.Drawing.Point(898, 526)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(35, 15)
        Me.lbltotal.TabIndex = 184
        Me.lbltotal.Text = "Total:"
        '
        'lblresta
        '
        Me.lblresta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblresta.AutoSize = True
        Me.lblresta.Location = New System.Drawing.Point(898, 570)
        Me.lblresta.Name = "lblresta"
        Me.lblresta.Size = New System.Drawing.Size(35, 15)
        Me.lblresta.TabIndex = 186
        Me.lblresta.Text = "Resta"
        '
        'txtresta
        '
        Me.txtresta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtresta.Location = New System.Drawing.Point(898, 588)
        Me.txtresta.Name = "txtresta"
        Me.txtresta.Size = New System.Drawing.Size(93, 23)
        Me.txtresta.TabIndex = 185
        Me.txtresta.Text = "0.00"
        Me.txtresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblacuenta
        '
        Me.lblacuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblacuenta.AutoSize = True
        Me.lblacuenta.Location = New System.Drawing.Point(799, 570)
        Me.lblacuenta.Name = "lblacuenta"
        Me.lblacuenta.Size = New System.Drawing.Size(54, 15)
        Me.lblacuenta.TabIndex = 190
        Me.lblacuenta.Text = "A cuenta"
        '
        'txtacuenta
        '
        Me.txtacuenta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtacuenta.Location = New System.Drawing.Point(799, 588)
        Me.txtacuenta.Name = "txtacuenta"
        Me.txtacuenta.Size = New System.Drawing.Size(93, 23)
        Me.txtacuenta.TabIndex = 189
        Me.txtacuenta.Text = "0.00"
        Me.txtacuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbliva
        '
        Me.lbliva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbliva.AutoSize = True
        Me.lbliva.Location = New System.Drawing.Point(799, 526)
        Me.lbliva.Name = "lbliva"
        Me.lbliva.Size = New System.Drawing.Size(24, 15)
        Me.lbliva.TabIndex = 188
        Me.lbliva.Text = "IVA"
        '
        'txtiva
        '
        Me.txtiva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtiva.Location = New System.Drawing.Point(799, 544)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(93, 23)
        Me.txtiva.TabIndex = 187
        Me.txtiva.Text = "0.00"
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblpeso
        '
        Me.lblpeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblpeso.AutoSize = True
        Me.lblpeso.Location = New System.Drawing.Point(761, 570)
        Me.lblpeso.Name = "lblpeso"
        Me.lblpeso.Size = New System.Drawing.Size(32, 15)
        Me.lblpeso.TabIndex = 194
        Me.lblpeso.Text = "Peso"
        '
        'txtpeso
        '
        Me.txtpeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpeso.Location = New System.Drawing.Point(700, 588)
        Me.txtpeso.Name = "txtpeso"
        Me.txtpeso.Size = New System.Drawing.Size(93, 23)
        Me.txtpeso.TabIndex = 193
        Me.txtpeso.Text = "0.00"
        Me.txtpeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblieps
        '
        Me.lblieps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblieps.AutoSize = True
        Me.lblieps.Location = New System.Drawing.Point(700, 526)
        Me.lblieps.Name = "lblieps"
        Me.lblieps.Size = New System.Drawing.Size(29, 15)
        Me.lblieps.TabIndex = 192
        Me.lblieps.Text = "IEPS"
        '
        'txtieps
        '
        Me.txtieps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtieps.Location = New System.Drawing.Point(700, 544)
        Me.txtieps.Name = "txtieps"
        Me.txtieps.Size = New System.Drawing.Size(93, 23)
        Me.txtieps.TabIndex = 191
        Me.txtieps.Text = "0.00"
        Me.txtieps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblsubtotal
        '
        Me.lblsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblsubtotal.AutoSize = True
        Me.lblsubtotal.Location = New System.Drawing.Point(502, 526)
        Me.lblsubtotal.Name = "lblsubtotal"
        Me.lblsubtotal.Size = New System.Drawing.Size(54, 15)
        Me.lblsubtotal.TabIndex = 196
        Me.lblsubtotal.Text = "Subtotal:"
        '
        'txtsubtotal
        '
        Me.txtsubtotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtsubtotal.Location = New System.Drawing.Point(502, 544)
        Me.txtsubtotal.Name = "txtsubtotal"
        Me.txtsubtotal.Size = New System.Drawing.Size(93, 23)
        Me.txtsubtotal.TabIndex = 195
        Me.txtsubtotal.Text = "0.00"
        Me.txtsubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbldescuento
        '
        Me.lbldescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldescuento.AutoSize = True
        Me.lbldescuento.Location = New System.Drawing.Point(601, 526)
        Me.lbldescuento.Name = "lbldescuento"
        Me.lbldescuento.Size = New System.Drawing.Size(66, 15)
        Me.lbldescuento.TabIndex = 200
        Me.lbldescuento.Text = "Descuento:"
        '
        'txtdescuento
        '
        Me.txtdescuento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdescuento.Location = New System.Drawing.Point(601, 544)
        Me.txtdescuento.Name = "txtdescuento"
        Me.txtdescuento.Size = New System.Drawing.Size(93, 23)
        Me.txtdescuento.TabIndex = 199
        Me.txtdescuento.Text = "0.00"
        Me.txtdescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Exportar
        '
        Me.Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Exportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exportar.Image = CType(resources.GetObject("Exportar.Image"), System.Drawing.Image)
        Me.Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Exportar.Location = New System.Drawing.Point(10, 559)
        Me.Exportar.Name = "Exportar"
        Me.Exportar.Size = New System.Drawing.Size(90, 54)
        Me.Exportar.TabIndex = 202
        Me.Exportar.Text = "Exportar"
        Me.Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Exportar.UseVisualStyleBackColor = True
        '
        'btnprint
        '
        Me.btnprint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprint.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnprint.Image = CType(resources.GetObject("btnprint.Image"), System.Drawing.Image)
        Me.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnprint.Location = New System.Drawing.Point(106, 499)
        Me.btnprint.Name = "btnprint"
        Me.btnprint.Size = New System.Drawing.Size(90, 54)
        Me.btnprint.TabIndex = 201
        Me.btnprint.Text = "Imprimir"
        Me.btnprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnprint.UseVisualStyleBackColor = True
        Me.btnprint.Visible = False
        '
        'btnuevo
        '
        Me.btnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnuevo.Image = CType(resources.GetObject("btnuevo.Image"), System.Drawing.Image)
        Me.btnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnuevo.Location = New System.Drawing.Point(106, 559)
        Me.btnuevo.Name = "btnuevo"
        Me.btnuevo.Size = New System.Drawing.Size(90, 54)
        Me.btnuevo.TabIndex = 204
        Me.btnuevo.Text = "Nuevo"
        Me.btnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnuevo.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(202, 559)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(90, 54)
        Me.Button6.TabIndex = 203
        Me.Button6.Text = "Controlados"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(10, 473)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(981, 20)
        Me.barcarga.TabIndex = 205
        Me.barcarga.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(225, 155)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(126, 19)
        Me.RadioButton1.TabIndex = 206
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Ventas por formato"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'dtpinicio
        '
        Me.dtpinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpinicio.Location = New System.Drawing.Point(486, 206)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.ShowUpDown = True
        Me.dtpinicio.Size = New System.Drawing.Size(90, 23)
        Me.dtpinicio.TabIndex = 207
        '
        'dtpfin
        '
        Me.dtpfin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpfin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpfin.Location = New System.Drawing.Point(911, 206)
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.ShowUpDown = True
        Me.dtpfin.Size = New System.Drawing.Size(80, 23)
        Me.dtpfin.TabIndex = 208
        '
        'optdetalle2
        '
        Me.optdetalle2.AutoSize = True
        Me.optdetalle2.Location = New System.Drawing.Point(12, 178)
        Me.optdetalle2.Name = "optdetalle2"
        Me.optdetalle2.Size = New System.Drawing.Size(174, 19)
        Me.optdetalle2.TabIndex = 209
        Me.optdetalle2.TabStop = True
        Me.optdetalle2.Text = "Ventas totales (Detalle pago)"
        Me.optdetalle2.UseVisualStyleBackColor = True
        '
        'optDerivados
        '
        Me.optDerivados.AutoSize = True
        Me.optDerivados.Location = New System.Drawing.Point(225, 178)
        Me.optDerivados.Name = "optDerivados"
        Me.optDerivados.Size = New System.Drawing.Size(209, 19)
        Me.optDerivados.TabIndex = 210
        Me.optDerivados.TabStop = True
        Me.optDerivados.Text = "Ventas de derivados por porcentaje"
        Me.optDerivados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(464, 569)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 15)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Porcentaje vendido:"
        '
        'txtVendido
        '
        Me.txtVendido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendido.Location = New System.Drawing.Point(463, 587)
        Me.txtVendido.Name = "txtVendido"
        Me.txtVendido.Size = New System.Drawing.Size(93, 23)
        Me.txtVendido.TabIndex = 211
        Me.txtVendido.Text = "0.00"
        Me.txtVendido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(582, 570)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 15)
        Me.Label3.TabIndex = 216
        Me.Label3.Text = "Porcentaje restante:"
        '
        'txtrestante
        '
        Me.txtrestante.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtrestante.Location = New System.Drawing.Point(585, 591)
        Me.txtrestante.Name = "txtrestante"
        Me.txtrestante.Size = New System.Drawing.Size(93, 23)
        Me.txtrestante.TabIndex = 215
        Me.txtrestante.Text = "0.00"
        Me.txtrestante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmRepVentas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1001, 622)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtrestante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtVendido)
        Me.Controls.Add(Me.optDerivados)
        Me.Controls.Add(Me.optdetalle2)
        Me.Controls.Add(Me.dtpfin)
        Me.Controls.Add(Me.dtpinicio)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.barcarga)
        Me.Controls.Add(Me.btnuevo)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Exportar)
        Me.Controls.Add(Me.btnprint)
        Me.Controls.Add(Me.lbldescuento)
        Me.Controls.Add(Me.txtdescuento)
        Me.Controls.Add(Me.lblsubtotal)
        Me.Controls.Add(Me.txtsubtotal)
        Me.Controls.Add(Me.lblpeso)
        Me.Controls.Add(Me.txtpeso)
        Me.Controls.Add(Me.lblieps)
        Me.Controls.Add(Me.txtieps)
        Me.Controls.Add(Me.lblacuenta)
        Me.Controls.Add(Me.txtacuenta)
        Me.Controls.Add(Me.lbliva)
        Me.Controls.Add(Me.txtiva)
        Me.Controls.Add(Me.lblresta)
        Me.Controls.Add(Me.txtresta)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.lblutilidad)
        Me.Controls.Add(Me.txtutilidad)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.optmasvendidoprov)
        Me.Controls.Add(Me.optmasvendido)
        Me.Controls.Add(Me.optdevoluciones)
        Me.Controls.Add(Me.optvendedor)
        Me.Controls.Add(Me.optproducto)
        Me.Controls.Add(Me.optgrupo)
        Me.Controls.Add(Me.optdepto)
        Me.Controls.Add(Me.optclientedet)
        Me.Controls.Add(Me.optcliente)
        Me.Controls.Add(Me.opttotalesdet)
        Me.Controls.Add(Me.opttotales)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mCalendar2)
        Me.Controls.Add(Me.mCalendar1)
        Me.Controls.Add(Me.opttraspasos)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1017, 651)
        Me.Name = "frmRepVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de ventas"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents mCalendar2 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents opttotales As System.Windows.Forms.RadioButton
    Friend WithEvents opttotalesdet As System.Windows.Forms.RadioButton
    Friend WithEvents optcliente As System.Windows.Forms.RadioButton
    Friend WithEvents optclientedet As System.Windows.Forms.RadioButton
    Friend WithEvents optdepto As System.Windows.Forms.RadioButton
    Friend WithEvents optgrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optproducto As System.Windows.Forms.RadioButton
    Friend WithEvents optvendedor As System.Windows.Forms.RadioButton
    Friend WithEvents optdevoluciones As System.Windows.Forms.RadioButton
    Friend WithEvents optmasvendido As System.Windows.Forms.RadioButton
    Friend WithEvents optmasvendidoprov As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents opttraspasos As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtutilidad As System.Windows.Forms.TextBox
    Friend WithEvents lblutilidad As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents lblresta As System.Windows.Forms.Label
    Friend WithEvents txtresta As System.Windows.Forms.TextBox
    Friend WithEvents lblacuenta As System.Windows.Forms.Label
    Friend WithEvents txtacuenta As System.Windows.Forms.TextBox
    Friend WithEvents lbliva As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents lblpeso As System.Windows.Forms.Label
    Friend WithEvents txtpeso As System.Windows.Forms.TextBox
    Friend WithEvents lblieps As System.Windows.Forms.Label
    Friend WithEvents txtieps As System.Windows.Forms.TextBox
    Friend WithEvents lblsubtotal As System.Windows.Forms.Label
    Friend WithEvents txtsubtotal As System.Windows.Forms.TextBox
    Friend WithEvents lbldescuento As System.Windows.Forms.Label
    Friend WithEvents txtdescuento As System.Windows.Forms.TextBox
    Friend WithEvents Exportar As System.Windows.Forms.Button
    Friend WithEvents btnprint As System.Windows.Forms.Button
    Friend WithEvents btnuevo As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents barcarga As System.Windows.Forms.ProgressBar
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents dtpinicio As DateTimePicker
    Friend WithEvents dtpfin As DateTimePicker
    Friend WithEvents optdetalle2 As RadioButton
    Friend WithEvents optDerivados As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents txtVendido As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtrestante As TextBox
End Class
