<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtexistencia = New System.Windows.Forms.TextBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbopedido = New System.Windows.Forms.ComboBox()
        Me.txtid_prov = New System.Windows.Forms.TextBox()
        Me.txtcorreo = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.cboprov = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtminimo = New System.Windows.Forms.TextBox()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btncancela = New System.Windows.Forms.Button()
        Me.btnguarda = New System.Windows.Forms.Button()
        Me.btnlimpia = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtProds = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btncopia = New System.Windows.Forms.Button()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.pCorreo = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.link_archivo = New System.Windows.Forms.LinkLabel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtMensaje = New System.Windows.Forms.RichTextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ppdPedidos = New System.Windows.Forms.PrintPreviewDialog()
        Me.pCarta = New System.Drawing.Printing.PrintDocument()
        Me.pMediaCarta = New System.Drawing.Printing.PrintDocument()
        Me.pTicket80 = New System.Drawing.Printing.PrintDocument()
        Me.pTicket58 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboTpago = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pCorreo.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(630, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Existencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(541, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 21)
        Me.Label6.TabIndex = 96
        Me.Label6.Text = "Precio compra"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(469, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 21)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(411, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 21)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Unidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtexistencia
        '
        Me.txtexistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtexistencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexistencia.Location = New System.Drawing.Point(630, 97)
        Me.txtexistencia.Name = "txtexistencia"
        Me.txtexistencia.Size = New System.Drawing.Size(76, 23)
        Me.txtexistencia.TabIndex = 93
        Me.txtexistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtprecio
        '
        Me.txtprecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtprecio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtprecio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecio.Location = New System.Drawing.Point(541, 97)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(90, 23)
        Me.txtprecio.TabIndex = 91
        Me.txtprecio.Text = "0.00"
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(69, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 21)
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
        Me.Label3.Location = New System.Drawing.Point(8, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 21)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(469, 97)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(73, 23)
        Me.txtcantidad.TabIndex = 88
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtunidad
        '
        Me.txtunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(411, 97)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(59, 23)
        Me.txtunidad.TabIndex = 87
        Me.txtunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbonombre
        '
        Me.cbonombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(69, 97)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(343, 23)
        Me.cbonombre.TabIndex = 86
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(8, 97)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(62, 23)
        Me.txtcodigo.TabIndex = 85
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.Label1.Size = New System.Drawing.Size(803, 31)
        Me.Label1.TabIndex = 99
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbopedido)
        Me.GroupBox1.Controls.Add(Me.txtid_prov)
        Me.GroupBox1.Controls.Add(Me.txtcorreo)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.txtmoneda)
        Me.GroupBox1.Controls.Add(Me.cbomoneda)
        Me.GroupBox1.Controls.Add(Me.cboprov)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(788, 43)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'cbopedido
        '
        Me.cbopedido.FormattingEnabled = True
        Me.cbopedido.Location = New System.Drawing.Point(446, 14)
        Me.cbopedido.Name = "cbopedido"
        Me.cbopedido.Size = New System.Drawing.Size(90, 23)
        Me.cbopedido.TabIndex = 156
        '
        'txtid_prov
        '
        Me.txtid_prov.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid_prov.Location = New System.Drawing.Point(12, 70)
        Me.txtid_prov.Name = "txtid_prov"
        Me.txtid_prov.Size = New System.Drawing.Size(62, 23)
        Me.txtid_prov.TabIndex = 151
        Me.txtid_prov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcorreo
        '
        Me.txtcorreo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcorreo.Location = New System.Drawing.Point(80, 70)
        Me.txtcorreo.Name = "txtcorreo"
        Me.txtcorreo.Size = New System.Drawing.Size(234, 23)
        Me.txtcorreo.TabIndex = 152
        Me.txtcorreo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(393, 18)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 15)
        Me.Label31.TabIndex = 155
        Me.Label31.Text = "Pedido:"
        '
        'txtmoneda
        '
        Me.txtmoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtmoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmoneda.Location = New System.Drawing.Point(724, 14)
        Me.txtmoneda.Name = "txtmoneda"
        Me.txtmoneda.Size = New System.Drawing.Size(59, 23)
        Me.txtmoneda.TabIndex = 146
        Me.txtmoneda.Text = "0.00"
        Me.txtmoneda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbomoneda
        '
        Me.cbomoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbomoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomoneda.FormattingEnabled = True
        Me.cbomoneda.Location = New System.Drawing.Point(629, 14)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(90, 23)
        Me.cbomoneda.TabIndex = 145
        Me.cbomoneda.Text = "PESO"
        '
        'cboprov
        '
        Me.cboprov.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboprov.FormattingEnabled = True
        Me.cboprov.Location = New System.Drawing.Point(80, 14)
        Me.cboprov.Name = "cboprov"
        Me.cboprov.Size = New System.Drawing.Size(307, 23)
        Me.cboprov.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Proveedor:"
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(701, 4)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(98, 23)
        Me.txtusuario.TabIndex = 143
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(705, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 21)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "Mínimo Al."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtminimo
        '
        Me.txtminimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtminimo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtminimo.Location = New System.Drawing.Point(705, 97)
        Me.txtminimo.Name = "txtminimo"
        Me.txtminimo.Size = New System.Drawing.Size(91, 23)
        Me.txtminimo.TabIndex = 145
        Me.txtminimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ColumnHeadersVisible = False
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(8, 119)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(788, 219)
        Me.grdcaptura.TabIndex = 147
        '
        'Column1
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 57
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column5
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "Compra"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 90
        '
        'Column6
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column6.HeaderText = "Existencia"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 74
        '
        'Column7
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column7.HeaderText = "Minimo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 89
        '
        'btncancela
        '
        Me.btncancela.BackgroundImage = CType(resources.GetObject("btncancela.BackgroundImage"), System.Drawing.Image)
        Me.btncancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancela.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancela.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncancela.Location = New System.Drawing.Point(601, 347)
        Me.btncancela.Name = "btncancela"
        Me.btncancela.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btncancela.Size = New System.Drawing.Size(61, 68)
        Me.btncancela.TabIndex = 150
        Me.btncancela.Text = "Cancelar"
        Me.btncancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncancela.UseVisualStyleBackColor = True
        '
        'btnguarda
        '
        Me.btnguarda.BackgroundImage = CType(resources.GetObject("btnguarda.BackgroundImage"), System.Drawing.Image)
        Me.btnguarda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguarda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguarda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguarda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguarda.Location = New System.Drawing.Point(668, 347)
        Me.btnguarda.Name = "btnguarda"
        Me.btnguarda.Size = New System.Drawing.Size(61, 68)
        Me.btnguarda.TabIndex = 149
        Me.btnguarda.Text = "Guardar"
        Me.btnguarda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguarda.UseVisualStyleBackColor = True
        '
        'btnlimpia
        '
        Me.btnlimpia.BackgroundImage = CType(resources.GetObject("btnlimpia.BackgroundImage"), System.Drawing.Image)
        Me.btnlimpia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnlimpia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpia.Location = New System.Drawing.Point(735, 347)
        Me.btnlimpia.Name = "btnlimpia"
        Me.btnlimpia.Size = New System.Drawing.Size(61, 68)
        Me.btnlimpia.TabIndex = 148
        Me.btnlimpia.Text = "Nuevo"
        Me.btnlimpia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpia.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.txtProds)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 340)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 75)
        Me.GroupBox2.TabIndex = 151
        Me.GroupBox2.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(9, 48)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(44, 13)
        Me.Label32.TabIndex = 83
        Me.Label32.Text = "Prodts:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProds
        '
        Me.txtProds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProds.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProds.Location = New System.Drawing.Point(61, 43)
        Me.txtProds.Name = "txtProds"
        Me.txtProds.Size = New System.Drawing.Size(86, 23)
        Me.txtProds.TabIndex = 82
        Me.txtProds.Text = "0"
        Me.txtProds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(9, 20)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(35, 15)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Total:"
        '
        'txtTotal
        '
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Location = New System.Drawing.Point(61, 16)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(86, 23)
        Me.txtTotal.TabIndex = 14
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btncopia
        '
        Me.btncopia.BackgroundImage = CType(resources.GetObject("btncopia.BackgroundImage"), System.Drawing.Image)
        Me.btncopia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncopia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncopia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncopia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncopia.Location = New System.Drawing.Point(534, 347)
        Me.btncopia.Name = "btncopia"
        Me.btncopia.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btncopia.Size = New System.Drawing.Size(61, 68)
        Me.btncopia.TabIndex = 152
        Me.btncopia.Text = "Imprimir copia"
        Me.btncopia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncopia.UseVisualStyleBackColor = True
        '
        'lblValor
        '
        Me.lblValor.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblValor.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.White
        Me.lblValor.Location = New System.Drawing.Point(89, 14)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(92, 17)
        Me.lblValor.TabIndex = 156
        Me.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoneda
        '
        Me.lblMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblMoneda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.White
        Me.lblMoneda.Location = New System.Drawing.Point(89, 0)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(92, 17)
        Me.lblMoneda.TabIndex = 155
        Me.lblMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label34.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(12, 16)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 154
        Me.Label34.Text = "Valor:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label33.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.White
        Me.Label33.Location = New System.Drawing.Point(12, 2)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 13)
        Me.Label33.TabIndex = 153
        Me.Label33.Text = "Costo en:"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtDestino)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(0, 28)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 51)
        Me.GroupBox3.TabIndex = 157
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Para:"
        Me.GroupBox3.Visible = False
        '
        'txtDestino
        '
        Me.txtDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDestino.Location = New System.Drawing.Point(8, 19)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(231, 22)
        Me.txtDestino.TabIndex = 0
        '
        'pCorreo
        '
        Me.pCorreo.BackColor = System.Drawing.Color.LightSeaGreen
        Me.pCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pCorreo.Controls.Add(Me.btnCancelar)
        Me.pCorreo.Controls.Add(Me.link_archivo)
        Me.pCorreo.Controls.Add(Me.GroupBox5)
        Me.pCorreo.Controls.Add(Me.GroupBox4)
        Me.pCorreo.Controls.Add(Me.btnEnviar)
        Me.pCorreo.Controls.Add(Me.GroupBox3)
        Me.pCorreo.Controls.Add(Me.Panel2)
        Me.pCorreo.Location = New System.Drawing.Point(868, 77)
        Me.pCorreo.Name = "pCorreo"
        Me.pCorreo.Size = New System.Drawing.Size(249, 313)
        Me.pCorreo.TabIndex = 158
        Me.pCorreo.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.Color.White
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(127, 261)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btnCancelar.Size = New System.Drawing.Size(111, 41)
        Me.btnCancelar.TabIndex = 165
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'link_archivo
        '
        Me.link_archivo.AutoSize = True
        Me.link_archivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.link_archivo.Location = New System.Drawing.Point(167, 135)
        Me.link_archivo.Name = "link_archivo"
        Me.link_archivo.Size = New System.Drawing.Size(72, 15)
        Me.link_archivo.TabIndex = 164
        Me.link_archivo.TabStop = True
        Me.link_archivo.Text = "Archivo PDF"
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtMensaje)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(0, 155)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(247, 95)
        Me.GroupBox5.TabIndex = 163
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Mensaje:"
        Me.GroupBox5.Visible = False
        '
        'txtMensaje
        '
        Me.txtMensaje.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMensaje.Location = New System.Drawing.Point(8, 21)
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(231, 61)
        Me.txtMensaje.TabIndex = 0
        Me.txtMensaje.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txtAsunto)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(0, 79)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(247, 51)
        Me.GroupBox4.TabIndex = 161
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Asunto:"
        Me.GroupBox4.Visible = False
        '
        'txtAsunto
        '
        Me.txtAsunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAsunto.Location = New System.Drawing.Point(8, 19)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(231, 22)
        Me.txtAsunto.TabIndex = 0
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.BackColor = System.Drawing.Color.White
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnviar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnviar.Location = New System.Drawing.Point(8, 261)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btnEnviar.Size = New System.Drawing.Size(111, 41)
        Me.btnEnviar.TabIndex = 160
        Me.btnEnviar.Text = "ENVIAR"
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Teal
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(247, 28)
        Me.Panel2.TabIndex = 162
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(56, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "ENVÍO DE PEDIDOS"
        '
        'ppdPedidos
        '
        Me.ppdPedidos.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.ppdPedidos.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.ppdPedidos.ClientSize = New System.Drawing.Size(400, 300)
        Me.ppdPedidos.Enabled = True
        Me.ppdPedidos.Icon = CType(resources.GetObject("ppdPedidos.Icon"), System.Drawing.Icon)
        Me.ppdPedidos.Name = "ppdPedidos"
        Me.ppdPedidos.Visible = False
        '
        'pCarta
        '
        '
        'pMediaCarta
        '
        '
        'pTicket80
        '
        '
        'pTicket58
        '
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label14)
        Me.GroupBox6.Controls.Add(Me.txtmonto)
        Me.GroupBox6.Controls.Add(Me.cboBanco)
        Me.GroupBox6.Controls.Add(Me.Label13)
        Me.GroupBox6.Controls.Add(Me.cboTpago)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.txtref)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(168, 340)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(358, 75)
        Me.GroupBox6.TabIndex = 152
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Anticipo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(213, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 88
        Me.Label14.Text = "Monto:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmonto
        '
        Me.txtmonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmonto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonto.ForeColor = System.Drawing.Color.Green
        Me.txtmonto.Location = New System.Drawing.Point(264, 43)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(87, 23)
        Me.txtmonto.TabIndex = 87
        Me.txtmonto.Text = "0.00"
        Me.txtmonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboBanco
        '
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(78, 43)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(127, 23)
        Me.cboBanco.TabIndex = 86
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 15)
        Me.Label13.TabIndex = 85
        Me.Label13.Text = "Banco:"
        '
        'cboTpago
        '
        Me.cboTpago.FormattingEnabled = True
        Me.cboTpago.Location = New System.Drawing.Point(78, 16)
        Me.cboTpago.Name = "cboTpago"
        Me.cboTpago.Size = New System.Drawing.Size(127, 23)
        Me.cboTpago.TabIndex = 84
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(213, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Ref.:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtref
        '
        Me.txtref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtref.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtref.Location = New System.Drawing.Point(264, 16)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(87, 23)
        Me.txtref.TabIndex = 82
        Me.txtref.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Tipo pago:"
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(600, 4)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(98, 23)
        Me.lblusuario.TabIndex = 228
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPedidos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(803, 423)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.pCorreo)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.btncopia)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btncancela)
        Me.Controls.Add(Me.btnguarda)
        Me.Controls.Add(Me.btnlimpia)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtminimo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtexistencia)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbonombre)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de pedidos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pCorreo.ResumeLayout(False)
        Me.pCorreo.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtexistencia As System.Windows.Forms.TextBox
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtunidad As System.Windows.Forms.TextBox
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbopedido As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtmoneda As System.Windows.Forms.TextBox
    Friend WithEvents cbomoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents cboprov As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtminimo As System.Windows.Forms.TextBox
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btncancela As System.Windows.Forms.Button
    Friend WithEvents btnguarda As System.Windows.Forms.Button
    Friend WithEvents btnlimpia As System.Windows.Forms.Button
    Friend WithEvents txtid_prov As System.Windows.Forms.TextBox
    Friend WithEvents txtcorreo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtProds As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents btncopia As System.Windows.Forms.Button
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents pCorreo As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents link_archivo As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMensaje As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ppdPedidos As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents pMediaCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents pTicket80 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pTicket58 As System.Drawing.Printing.PrintDocument
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboTpago As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtmonto As System.Windows.Forms.TextBox
    Friend WithEvents cboBanco As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblusuario As Label
End Class
