<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductos_Escuelas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductos_Escuelas))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.cms1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.elimina_concepto = New System.Windows.Forms.ToolStripMenuItem()
        Me.edita_concepto = New System.Windows.Forms.ToolStripMenuItem()
        Me.edita_fecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.edita_monto = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtconcepto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.boxConcepto = New System.Windows.Forms.GroupBox()
        Me.btn_concepto = New System.Windows.Forms.Button()
        Me.txtnuevo_concepto = New System.Windows.Forms.TextBox()
        Me.boxFecha = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtfecha_actual = New System.Windows.Forms.TextBox()
        Me.dtpnuevo_fecha = New System.Windows.Forms.DateTimePicker()
        Me.btn_fecha = New System.Windows.Forms.Button()
        Me.boxMonto = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtnuevo_monto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtmonto_actual = New System.Windows.Forms.TextBox()
        Me.btn_monto = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtregistros = New System.Windows.Forms.TextBox()
        Me.lblanterior_concepto = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblnombre_fecha = New System.Windows.Forms.Label()
        Me.lblnombre_monto = New System.Windows.Forms.Label()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms1.SuspendLayout()
        Me.boxConcepto.SuspendLayout()
        Me.boxFecha.SuspendLayout()
        Me.boxMonto.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(596, 31)
        Me.Label1.TabIndex = 175
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(525, 447)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 216
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(459, 447)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 215
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(393, 447)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 214
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(82, 38)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(503, 23)
        Me.cboNombre.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 23)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "NOMBRE:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttotal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(71, 447)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(102, 23)
        Me.txttotal.TabIndex = 179
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 23)
        Me.Label12.TabIndex = 176
        Me.Label12.Text = "CONCEPTO:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.grdcaptura.ContextMenuStrip = Me.cms1
        Me.grdcaptura.Location = New System.Drawing.Point(12, 126)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(573, 314)
        Me.grdcaptura.TabIndex = 226
        '
        'cms1
        '
        Me.cms1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.elimina_concepto, Me.edita_concepto, Me.edita_fecha, Me.edita_monto})
        Me.cms1.Name = "cms1"
        Me.cms1.Size = New System.Drawing.Size(183, 92)
        '
        'elimina_concepto
        '
        Me.elimina_concepto.BackColor = System.Drawing.Color.White
        Me.elimina_concepto.Name = "elimina_concepto"
        Me.elimina_concepto.Size = New System.Drawing.Size(182, 22)
        Me.elimina_concepto.Text = "Eliminar concepto"
        '
        'edita_concepto
        '
        Me.edita_concepto.BackColor = System.Drawing.Color.White
        Me.edita_concepto.Name = "edita_concepto"
        Me.edita_concepto.Size = New System.Drawing.Size(182, 22)
        Me.edita_concepto.Text = "Editar concepto"
        '
        'edita_fecha
        '
        Me.edita_fecha.BackColor = System.Drawing.Color.White
        Me.edita_fecha.Name = "edita_fecha"
        Me.edita_fecha.Size = New System.Drawing.Size(182, 22)
        Me.edita_fecha.Text = "Editar fecha de pago"
        '
        'edita_monto
        '
        Me.edita_monto.BackColor = System.Drawing.Color.White
        Me.edita_monto.Name = "edita_monto"
        Me.edita_monto.Size = New System.Drawing.Size(182, 22)
        Me.edita_monto.Text = "Editar monto"
        '
        'txtconcepto
        '
        Me.txtconcepto.BackColor = System.Drawing.Color.White
        Me.txtconcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconcepto.Location = New System.Drawing.Point(82, 71)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(503, 23)
        Me.txtconcepto.TabIndex = 209
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(190, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 23)
        Me.Label10.TabIndex = 231
        Me.Label10.Text = "MONTO:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmonto
        '
        Me.txtmonto.BackColor = System.Drawing.Color.White
        Me.txtmonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmonto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.Location = New System.Drawing.Point(253, 97)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(113, 23)
        Me.txtmonto.TabIndex = 232
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(12, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 23)
        Me.Label15.TabIndex = 233
        Me.Label15.Text = "FECHA:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(82, 97)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(102, 23)
        Me.dtpfecha.TabIndex = 234
        '
        'btnagregar
        '
        Me.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnagregar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregar.Location = New System.Drawing.Point(471, 97)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(114, 23)
        Me.btnagregar.TabIndex = 235
        Me.btnagregar.Text = "Agregar concepto"
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 447)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 23)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "TOTAL:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'boxConcepto
        '
        Me.boxConcepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.boxConcepto.Controls.Add(Me.lblanterior_concepto)
        Me.boxConcepto.Controls.Add(Me.btn_concepto)
        Me.boxConcepto.Controls.Add(Me.txtnuevo_concepto)
        Me.boxConcepto.Location = New System.Drawing.Point(67, 221)
        Me.boxConcepto.Name = "boxConcepto"
        Me.boxConcepto.Size = New System.Drawing.Size(463, 80)
        Me.boxConcepto.TabIndex = 237
        Me.boxConcepto.TabStop = False
        Me.boxConcepto.Text = "Edita concepto"
        Me.boxConcepto.Visible = False
        '
        'btn_concepto
        '
        Me.btn_concepto.BackColor = System.Drawing.Color.White
        Me.btn_concepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_concepto.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_concepto.Location = New System.Drawing.Point(379, 49)
        Me.btn_concepto.Name = "btn_concepto"
        Me.btn_concepto.Size = New System.Drawing.Size(76, 23)
        Me.btn_concepto.TabIndex = 236
        Me.btn_concepto.Text = "Actualizar"
        Me.btn_concepto.UseVisualStyleBackColor = False
        '
        'txtnuevo_concepto
        '
        Me.txtnuevo_concepto.BackColor = System.Drawing.Color.White
        Me.txtnuevo_concepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnuevo_concepto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnuevo_concepto.Location = New System.Drawing.Point(8, 22)
        Me.txtnuevo_concepto.Name = "txtnuevo_concepto"
        Me.txtnuevo_concepto.Size = New System.Drawing.Size(447, 23)
        Me.txtnuevo_concepto.TabIndex = 210
        '
        'boxFecha
        '
        Me.boxFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.boxFecha.Controls.Add(Me.lblnombre_fecha)
        Me.boxFecha.Controls.Add(Me.Label5)
        Me.boxFecha.Controls.Add(Me.Label4)
        Me.boxFecha.Controls.Add(Me.txtfecha_actual)
        Me.boxFecha.Controls.Add(Me.dtpnuevo_fecha)
        Me.boxFecha.Controls.Add(Me.btn_fecha)
        Me.boxFecha.Location = New System.Drawing.Point(130, 221)
        Me.boxFecha.Name = "boxFecha"
        Me.boxFecha.Size = New System.Drawing.Size(337, 80)
        Me.boxFecha.TabIndex = 238
        Me.boxFecha.TabStop = False
        Me.boxFecha.Text = "Edita concepto"
        Me.boxFecha.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(177, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 240
        Me.Label5.Text = "Nueva:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 15)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Actual:"
        '
        'txtfecha_actual
        '
        Me.txtfecha_actual.BackColor = System.Drawing.Color.White
        Me.txtfecha_actual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfecha_actual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha_actual.Location = New System.Drawing.Point(58, 22)
        Me.txtfecha_actual.Name = "txtfecha_actual"
        Me.txtfecha_actual.Size = New System.Drawing.Size(113, 23)
        Me.txtfecha_actual.TabIndex = 238
        Me.txtfecha_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpnuevo_fecha
        '
        Me.dtpnuevo_fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpnuevo_fecha.Location = New System.Drawing.Point(227, 22)
        Me.dtpnuevo_fecha.Name = "dtpnuevo_fecha"
        Me.dtpnuevo_fecha.Size = New System.Drawing.Size(102, 23)
        Me.dtpnuevo_fecha.TabIndex = 237
        '
        'btn_fecha
        '
        Me.btn_fecha.BackColor = System.Drawing.Color.White
        Me.btn_fecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_fecha.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_fecha.Location = New System.Drawing.Point(253, 49)
        Me.btn_fecha.Name = "btn_fecha"
        Me.btn_fecha.Size = New System.Drawing.Size(76, 23)
        Me.btn_fecha.TabIndex = 236
        Me.btn_fecha.Text = "Actualizar"
        Me.btn_fecha.UseVisualStyleBackColor = False
        '
        'boxMonto
        '
        Me.boxMonto.BackColor = System.Drawing.Color.DodgerBlue
        Me.boxMonto.Controls.Add(Me.lblnombre_monto)
        Me.boxMonto.Controls.Add(Me.Label6)
        Me.boxMonto.Controls.Add(Me.txtnuevo_monto)
        Me.boxMonto.Controls.Add(Me.Label7)
        Me.boxMonto.Controls.Add(Me.txtmonto_actual)
        Me.boxMonto.Controls.Add(Me.btn_monto)
        Me.boxMonto.Location = New System.Drawing.Point(161, 221)
        Me.boxMonto.Name = "boxMonto"
        Me.boxMonto.Size = New System.Drawing.Size(275, 80)
        Me.boxMonto.TabIndex = 239
        Me.boxMonto.TabStop = False
        Me.boxMonto.Text = "Edita concepto"
        Me.boxMonto.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(140, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Nuevo:"
        '
        'txtnuevo_monto
        '
        Me.txtnuevo_monto.BackColor = System.Drawing.Color.White
        Me.txtnuevo_monto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnuevo_monto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnuevo_monto.Location = New System.Drawing.Point(190, 22)
        Me.txtnuevo_monto.Name = "txtnuevo_monto"
        Me.txtnuevo_monto.Size = New System.Drawing.Size(76, 23)
        Me.txtnuevo_monto.TabIndex = 240
        Me.txtnuevo_monto.Text = "0.00"
        Me.txtnuevo_monto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 15)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = "Actual:"
        '
        'txtmonto_actual
        '
        Me.txtmonto_actual.BackColor = System.Drawing.Color.White
        Me.txtmonto_actual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmonto_actual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto_actual.Location = New System.Drawing.Point(58, 22)
        Me.txtmonto_actual.Name = "txtmonto_actual"
        Me.txtmonto_actual.Size = New System.Drawing.Size(76, 23)
        Me.txtmonto_actual.TabIndex = 238
        Me.txtmonto_actual.Text = "0.00"
        Me.txtmonto_actual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btn_monto
        '
        Me.btn_monto.BackColor = System.Drawing.Color.White
        Me.btn_monto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_monto.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_monto.Location = New System.Drawing.Point(190, 49)
        Me.btn_monto.Name = "btn_monto"
        Me.btn_monto.Size = New System.Drawing.Size(76, 23)
        Me.btn_monto.TabIndex = 236
        Me.btn_monto.Text = "Actualizar"
        Me.btn_monto.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(188, 447)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 23)
        Me.Label8.TabIndex = 241
        Me.Label8.Text = "No. PAGOS:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtregistros
        '
        Me.txtregistros.BackColor = System.Drawing.Color.White
        Me.txtregistros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtregistros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtregistros.Location = New System.Drawing.Point(263, 447)
        Me.txtregistros.Name = "txtregistros"
        Me.txtregistros.Size = New System.Drawing.Size(96, 23)
        Me.txtregistros.TabIndex = 240
        Me.txtregistros.Text = "0"
        Me.txtregistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblanterior_concepto
        '
        Me.lblanterior_concepto.Location = New System.Drawing.Point(8, 49)
        Me.lblanterior_concepto.Name = "lblanterior_concepto"
        Me.lblanterior_concepto.Size = New System.Drawing.Size(365, 23)
        Me.lblanterior_concepto.TabIndex = 237
        Me.lblanterior_concepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Concepto"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Fecha de pago"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 130
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.HeaderText = "Monto"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'lblnombre_fecha
        '
        Me.lblnombre_fecha.Location = New System.Drawing.Point(12, 49)
        Me.lblnombre_fecha.Name = "lblnombre_fecha"
        Me.lblnombre_fecha.Size = New System.Drawing.Size(235, 23)
        Me.lblnombre_fecha.TabIndex = 241
        Me.lblnombre_fecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblnombre_fecha.Visible = False
        '
        'lblnombre_monto
        '
        Me.lblnombre_monto.Location = New System.Drawing.Point(8, 49)
        Me.lblnombre_monto.Name = "lblnombre_monto"
        Me.lblnombre_monto.Size = New System.Drawing.Size(176, 23)
        Me.lblnombre_monto.TabIndex = 242
        Me.lblnombre_monto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblnombre_monto.Visible = False
        '
        'frmProductos_Escuelas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(596, 522)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtregistros)
        Me.Controls.Add(Me.boxMonto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnagregar)
        Me.Controls.Add(Me.dtpfecha)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtmonto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.txtconcepto)
        Me.Controls.Add(Me.cboNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxFecha)
        Me.Controls.Add(Me.boxConcepto)
        Me.Controls.Add(Me.grdcaptura)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductos_Escuelas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conceptos de pago"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms1.ResumeLayout(False)
        Me.boxConcepto.ResumeLayout(False)
        Me.boxConcepto.PerformLayout()
        Me.boxFecha.ResumeLayout(False)
        Me.boxFecha.PerformLayout()
        Me.boxMonto.ResumeLayout(False)
        Me.boxMonto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents cboNombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents txtconcepto As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtmonto As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents dtpfecha As DateTimePicker
    Friend WithEvents btnagregar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cms1 As ContextMenuStrip
    Friend WithEvents elimina_concepto As ToolStripMenuItem
    Friend WithEvents edita_concepto As ToolStripMenuItem
    Friend WithEvents edita_fecha As ToolStripMenuItem
    Friend WithEvents edita_monto As ToolStripMenuItem
    Friend WithEvents boxConcepto As GroupBox
    Friend WithEvents btn_concepto As Button
    Friend WithEvents txtnuevo_concepto As TextBox
    Friend WithEvents boxFecha As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtfecha_actual As TextBox
    Friend WithEvents dtpnuevo_fecha As DateTimePicker
    Friend WithEvents btn_fecha As Button
    Friend WithEvents boxMonto As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtnuevo_monto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtmonto_actual As TextBox
    Friend WithEvents btn_monto As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents txtregistros As TextBox
    Friend WithEvents lblanterior_concepto As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents lblnombre_fecha As Label
    Friend WithEvents lblnombre_monto As Label
End Class
