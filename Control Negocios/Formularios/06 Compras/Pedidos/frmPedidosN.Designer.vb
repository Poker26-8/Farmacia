<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPedidosN
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidosN))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.chk_mPrecio = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtexistencia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtNumPed = New System.Windows.Forms.ComboBox()
        Me.dtpFpedido = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboProveedor = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TFolio = New System.Windows.Forms.Timer(Me.components)
        Me.pPedidos80 = New System.Drawing.Printing.PrintDocument()
        Me.pPedidos58 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(839, 42)
        Me.Label1.TabIndex = 100
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(630, 9)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(98, 23)
        Me.lblusuario.TabIndex = 232
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtmoneda
        '
        Me.txtmoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtmoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmoneda.Location = New System.Drawing.Point(567, 9)
        Me.txtmoneda.Name = "txtmoneda"
        Me.txtmoneda.Size = New System.Drawing.Size(59, 23)
        Me.txtmoneda.TabIndex = 231
        Me.txtmoneda.Text = "0.00"
        Me.txtmoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbomoneda
        '
        Me.cbomoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbomoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomoneda.FormattingEnabled = True
        Me.cbomoneda.Location = New System.Drawing.Point(473, 9)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(90, 23)
        Me.cbomoneda.TabIndex = 230
        Me.cbomoneda.Text = "PESO"
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(732, 9)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(98, 23)
        Me.txtusuario.TabIndex = 229
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblValor
        '
        Me.lblValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblValor.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.Black
        Me.lblValor.Location = New System.Drawing.Point(78, 21)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(92, 17)
        Me.lblValor.TabIndex = 236
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoneda
        '
        Me.lblMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblMoneda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.Black
        Me.lblMoneda.Location = New System.Drawing.Point(78, 7)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(92, 17)
        Me.lblMoneda.TabIndex = 235
        Me.lblMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(1, 23)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 234
        Me.Label34.Text = "Valor:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(1, 9)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 13)
        Me.Label33.TabIndex = 233
        Me.Label33.Text = "Costo en:"
        '
        'chk_mPrecio
        '
        Me.chk_mPrecio.AutoSize = True
        Me.chk_mPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_mPrecio.Location = New System.Drawing.Point(571, 29)
        Me.chk_mPrecio.Name = "chk_mPrecio"
        Me.chk_mPrecio.Size = New System.Drawing.Size(157, 19)
        Me.chk_mPrecio.TabIndex = 247
        Me.chk_mPrecio.Text = "Mejor precio de compra"
        Me.chk_mPrecio.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(547, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Existencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(622, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 245
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(489, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 21)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "Unidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtexistencia
        '
        Me.txtexistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtexistencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexistencia.Location = New System.Drawing.Point(547, 74)
        Me.txtexistencia.Name = "txtexistencia"
        Me.txtexistencia.Size = New System.Drawing.Size(76, 23)
        Me.txtexistencia.TabIndex = 243
        Me.txtexistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(64, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 21)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 21)
        Me.Label3.TabIndex = 241
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(622, 74)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(73, 23)
        Me.txtcantidad.TabIndex = 240
        Me.txtcantidad.Text = "1"
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtunidad
        '
        Me.txtunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(489, 74)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(59, 23)
        Me.txtunidad.TabIndex = 239
        Me.txtunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbonombre
        '
        Me.cbonombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(64, 74)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(426, 23)
        Me.cbonombre.TabIndex = 238
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(3, 74)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(62, 23)
        Me.txtcodigo.TabIndex = 237
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdCaptura)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 147)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(839, 220)
        Me.Panel1.TabIndex = 248
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle9
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(839, 220)
        Me.grdCaptura.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 76
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Cod Barra"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 93
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Unidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 76
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Existencia"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 93
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Cantidad"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 86
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Sugerencia"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 101
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Precio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 71
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Total"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 63
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNumPed)
        Me.Panel2.Controls.Add(Me.dtpFpedido)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.lblFolio)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.cboProveedor)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtcodigo)
        Me.Panel2.Controls.Add(Me.chk_mPrecio)
        Me.Panel2.Controls.Add(Me.cbonombre)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtunidad)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtcantidad)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtexistencia)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(839, 105)
        Me.Panel2.TabIndex = 249
        '
        'txtNumPed
        '
        Me.txtNumPed.FormattingEnabled = True
        Me.txtNumPed.Location = New System.Drawing.Point(438, 29)
        Me.txtNumPed.Name = "txtNumPed"
        Me.txtNumPed.Size = New System.Drawing.Size(125, 21)
        Me.txtNumPed.TabIndex = 255
        '
        'dtpFpedido
        '
        Me.dtpFpedido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFpedido.Location = New System.Drawing.Point(732, 77)
        Me.dtpFpedido.Name = "dtpFpedido"
        Me.dtpFpedido.Size = New System.Drawing.Size(98, 20)
        Me.dtpFpedido.TabIndex = 254
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(732, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 21)
        Me.Label13.TabIndex = 253
        Me.Label13.Text = "F Pedido"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(438, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 21)
        Me.Label11.TabIndex = 252
        Me.Label11.Text = "Num Pedido"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolio
        '
        Me.lblFolio.BackColor = System.Drawing.Color.LightBlue
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Black
        Me.lblFolio.Location = New System.Drawing.Point(732, 26)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(98, 27)
        Me.lblFolio.TabIndex = 251
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Arial Unicode MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(732, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 21)
        Me.Label10.TabIndex = 250
        Me.Label10.Text = "Folio"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProveedor
        '
        Me.cboProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProveedor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedor.FormattingEnabled = True
        Me.cboProveedor.Location = New System.Drawing.Point(3, 28)
        Me.cboProveedor.Name = "cboProveedor"
        Me.cboProveedor.Size = New System.Drawing.Size(429, 23)
        Me.cboProveedor.TabIndex = 249
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Arial Unicode MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(4, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(428, 21)
        Me.Label6.TabIndex = 248
        Me.Label6.Text = "Proveedor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtEfectivo)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.lblCantidad)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.btnCargar)
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Controls.Add(Me.txtSubtotal)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 367)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(839, 83)
        Me.Panel3.TabIndex = 250
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(254, 8)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(100, 22)
        Me.txtEfectivo.TabIndex = 8
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(183, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 18)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Efectivo:"
        Me.Label12.Visible = False
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.LightBlue
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.Black
        Me.lblCantidad.Location = New System.Drawing.Point(500, 5)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(93, 27)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "0"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(361, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 18)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Cantidad productos:"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(599, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 75)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Limpiar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCargar.Location = New System.Drawing.Point(680, 5)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(75, 75)
        Me.btnCargar.TabIndex = 3
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(761, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 75)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(77, 8)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 22)
        Me.txtSubtotal.TabIndex = 1
        Me.txtSubtotal.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Subtotal"
        '
        'TFolio
        '
        Me.TFolio.Interval = 5000
        '
        'pPedidos80
        '
        '
        'pPedidos58
        '
        '
        'frmPedidosN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(839, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtmoneda)
        Me.Controls.Add(Me.cbomoneda)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPedidosN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtmoneda As TextBox
    Friend WithEvents cbomoneda As ComboBox
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents lblValor As Label
    Friend WithEvents lblMoneda As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents chk_mPrecio As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtexistencia As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents txtunidad As TextBox
    Friend WithEvents cbonombre As ComboBox
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboProveedor As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnCargar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblCantidad As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TFolio As Timer
    Friend WithEvents Label11 As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNumPed As ComboBox
    Friend WithEvents dtpFpedido As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents pPedidos80 As Printing.PrintDocument
    Friend WithEvents pPedidos58 As Printing.PrintDocument
End Class
