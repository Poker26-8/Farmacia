<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCtsPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCtsPagar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtid_prov = New System.Windows.Forms.TextBox()
        Me.optfacturas = New System.Windows.Forms.RadioButton()
        Me.cbofactura = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboremision = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtanticipo = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtresta = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtpagos = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtefectivo = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtapagar = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtdesc2 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtiva = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtsub2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtdesc1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtsub1 = New System.Windows.Forms.TextBox()
        Me.btnasignar = New System.Windows.Forms.Button()
        Me.btnabono = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(622, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(524, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 21)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(437, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 21)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Precio"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(383, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 21)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(330, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 21)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Unidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(67, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 21)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 21)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ColumnHeadersVisible = False
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.grdcaptura.Location = New System.Drawing.Point(9, 133)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(604, 188)
        Me.grdcaptura.TabIndex = 84
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 57
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descipcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 53
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 54
        '
        'Column5
        '
        Me.Column5.HeaderText = "Precio"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 87
        '
        'Column6
        '
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 87
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtid_prov)
        Me.GroupBox1.Controls.Add(Me.optfacturas)
        Me.GroupBox1.Controls.Add(Me.cbofactura)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.cboremision)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cbonombre)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(605, 76)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta"
        '
        'txtid_prov
        '
        Me.txtid_prov.Location = New System.Drawing.Point(339, 44)
        Me.txtid_prov.Name = "txtid_prov"
        Me.txtid_prov.Size = New System.Drawing.Size(82, 23)
        Me.txtid_prov.TabIndex = 148
        Me.txtid_prov.Visible = False
        '
        'optfacturas
        '
        Me.optfacturas.AutoSize = True
        Me.optfacturas.Location = New System.Drawing.Point(78, 46)
        Me.optfacturas.Name = "optfacturas"
        Me.optfacturas.Size = New System.Drawing.Size(182, 19)
        Me.optfacturas.TabIndex = 14
        Me.optfacturas.TabStop = True
        Me.optfacturas.Text = "Ver remisiones con facturadas"
        Me.optfacturas.UseVisualStyleBackColor = True
        '
        'cbofactura
        '
        Me.cbofactura.FormattingEnabled = True
        Me.cbofactura.Location = New System.Drawing.Point(500, 44)
        Me.cbofactura.Name = "cbofactura"
        Me.cbofactura.Size = New System.Drawing.Size(95, 23)
        Me.cbofactura.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(433, 48)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Factura:"
        '
        'cboremision
        '
        Me.cboremision.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboremision.FormattingEnabled = True
        Me.cboremision.Location = New System.Drawing.Point(500, 18)
        Me.cboremision.Name = "cboremision"
        Me.cboremision.Size = New System.Drawing.Size(95, 23)
        Me.cboremision.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(433, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Remisión:"
        '
        'cbonombre
        '
        Me.cbonombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(78, 18)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(343, 23)
        Me.cbonombre.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 15)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Proveedor:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpfecha)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtanticipo)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.txtresta)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.txtpagos)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtefectivo)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtapagar)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.txtdesc2)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txttotal)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtiva)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtsub2)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtdesc1)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtsub1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 319)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 126)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        '
        'dtpfecha
        '
        Me.dtpfecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(234, 93)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(82, 23)
        Me.dtpfecha.TabIndex = 79
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(164, 97)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 15)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "Fecha:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(322, 71)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(55, 15)
        Me.Label29.TabIndex = 27
        Me.Label29.Text = "Anticipo:"
        '
        'txtanticipo
        '
        Me.txtanticipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtanticipo.Location = New System.Drawing.Point(382, 67)
        Me.txtanticipo.Name = "txtanticipo"
        Me.txtanticipo.Size = New System.Drawing.Size(82, 23)
        Me.txtanticipo.TabIndex = 26
        Me.txtanticipo.Text = "0.00"
        Me.txtanticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(322, 97)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(38, 15)
        Me.Label30.TabIndex = 25
        Me.Label30.Text = "Resta:"
        '
        'txtresta
        '
        Me.txtresta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtresta.ForeColor = System.Drawing.Color.Red
        Me.txtresta.Location = New System.Drawing.Point(382, 93)
        Me.txtresta.Name = "txtresta"
        Me.txtresta.Size = New System.Drawing.Size(82, 23)
        Me.txtresta.TabIndex = 24
        Me.txtresta.Text = "0.00"
        Me.txtresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(322, 19)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(42, 15)
        Me.Label31.TabIndex = 23
        Me.Label31.Text = "Pagos:"
        '
        'txtpagos
        '
        Me.txtpagos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpagos.Location = New System.Drawing.Point(382, 15)
        Me.txtpagos.Name = "txtpagos"
        Me.txtpagos.Size = New System.Drawing.Size(82, 23)
        Me.txtpagos.TabIndex = 22
        Me.txtpagos.Text = "0.00"
        Me.txtpagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(322, 45)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(52, 15)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Efectivo:"
        '
        'txtefectivo
        '
        Me.txtefectivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtefectivo.Location = New System.Drawing.Point(382, 41)
        Me.txtefectivo.Name = "txtefectivo"
        Me.txtefectivo.Size = New System.Drawing.Size(82, 23)
        Me.txtefectivo.TabIndex = 20
        Me.txtefectivo.Text = "0.00"
        Me.txtefectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(164, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(51, 15)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "A pagar:"
        '
        'txtapagar
        '
        Me.txtapagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapagar.Location = New System.Drawing.Point(234, 67)
        Me.txtapagar.Name = "txtapagar"
        Me.txtapagar.Size = New System.Drawing.Size(82, 23)
        Me.txtapagar.TabIndex = 18
        Me.txtapagar.Text = "0.00"
        Me.txtapagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(164, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(66, 15)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Descuento:"
        '
        'txtdesc2
        '
        Me.txtdesc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesc2.Location = New System.Drawing.Point(234, 41)
        Me.txtdesc2.Name = "txtdesc2"
        Me.txtdesc2.Size = New System.Drawing.Size(82, 23)
        Me.txtdesc2.TabIndex = 16
        Me.txtdesc2.Text = "0.00"
        Me.txtdesc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(164, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(35, 15)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Total:"
        '
        'txttotal
        '
        Me.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal.Location = New System.Drawing.Point(234, 15)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(82, 23)
        Me.txttotal.TabIndex = 14
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 97)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 15)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "IVA:"
        '
        'txtiva
        '
        Me.txtiva.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtiva.Location = New System.Drawing.Point(76, 93)
        Me.txtiva.Name = "txtiva"
        Me.txtiva.Size = New System.Drawing.Size(82, 23)
        Me.txtiva.TabIndex = 12
        Me.txtiva.Text = "0.00"
        Me.txtiva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 71)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 15)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Subtotal:"
        '
        'txtsub2
        '
        Me.txtsub2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsub2.Location = New System.Drawing.Point(76, 67)
        Me.txtsub2.Name = "txtsub2"
        Me.txtsub2.Size = New System.Drawing.Size(82, 23)
        Me.txtsub2.TabIndex = 10
        Me.txtsub2.Text = "0.00"
        Me.txtsub2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 45)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 15)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "Descuento:"
        '
        'txtdesc1
        '
        Me.txtdesc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesc1.Location = New System.Drawing.Point(76, 41)
        Me.txtdesc1.Name = "txtdesc1"
        Me.txtdesc1.Size = New System.Drawing.Size(82, 23)
        Me.txtdesc1.TabIndex = 8
        Me.txtdesc1.Text = "0.00"
        Me.txtdesc1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 19)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(54, 15)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Subtotal:"
        '
        'txtsub1
        '
        Me.txtsub1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsub1.Location = New System.Drawing.Point(76, 15)
        Me.txtsub1.Name = "txtsub1"
        Me.txtsub1.Size = New System.Drawing.Size(82, 23)
        Me.txtsub1.TabIndex = 6
        Me.txtsub1.Text = "0.00"
        Me.txtsub1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnasignar
        '
        Me.btnasignar.Enabled = False
        Me.btnasignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnasignar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnasignar.Image = CType(resources.GetObject("btnasignar.Image"), System.Drawing.Image)
        Me.btnasignar.Location = New System.Drawing.Point(553, 327)
        Me.btnasignar.Name = "btnasignar"
        Me.btnasignar.Size = New System.Drawing.Size(60, 63)
        Me.btnasignar.TabIndex = 144
        Me.btnasignar.Text = "Asignar"
        Me.btnasignar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnasignar.UseVisualStyleBackColor = True
        Me.btnasignar.Visible = False
        '
        'btnabono
        '
        Me.btnabono.BackgroundImage = CType(resources.GetObject("btnabono.BackgroundImage"), System.Drawing.Image)
        Me.btnabono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnabono.Enabled = False
        Me.btnabono.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnabono.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnabono.Location = New System.Drawing.Point(486, 327)
        Me.btnabono.Name = "btnabono"
        Me.btnabono.Size = New System.Drawing.Size(60, 63)
        Me.btnabono.TabIndex = 143
        Me.btnabono.Text = "Abono"
        Me.btnabono.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnabono.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnnuevo.Location = New System.Drawing.Point(486, 396)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.btnnuevo.Size = New System.Drawing.Size(127, 48)
        Me.btnnuevo.TabIndex = 146
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(534, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(82, 23)
        Me.TextBox1.TabIndex = 147
        Me.TextBox1.Visible = False
        '
        'frmCtsPagar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(622, 455)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.btnasignar)
        Me.Controls.Add(Me.btnabono)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCtsPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas por pagar a proveedores"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbofactura As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboremision As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtanticipo As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtresta As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtpagos As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtefectivo As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtapagar As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtdesc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtiva As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtsub2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtdesc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtsub1 As System.Windows.Forms.TextBox
    Friend WithEvents optfacturas As System.Windows.Forms.RadioButton
    Friend WithEvents btnasignar As System.Windows.Forms.Button
    Friend WithEvents btnabono As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtid_prov As System.Windows.Forms.TextBox
End Class
