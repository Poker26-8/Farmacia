﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtmoneda = New System.Windows.Forms.TextBox()
        Me.cbomoneda = New System.Windows.Forms.ComboBox()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ppdPedidos = New System.Windows.Forms.PrintPreviewDialog()
        Me.pCarta = New System.Drawing.Printing.PrintDocument()
        Me.pMediaCarta = New System.Drawing.Printing.PrintDocument()
        Me.pTicket80 = New System.Drawing.Printing.PrintDocument()
        Me.pTicket58 = New System.Drawing.Printing.PrintDocument()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btncopia = New System.Windows.Forms.Button()
        Me.btncancela = New System.Windows.Forms.Button()
        Me.btnguarda = New System.Windows.Forms.Button()
        Me.btnlimpia = New System.Windows.Forms.Button()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(552, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 21)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Existencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(627, 65)
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
        Me.Label4.Location = New System.Drawing.Point(494, 65)
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
        Me.txtexistencia.Location = New System.Drawing.Point(552, 85)
        Me.txtexistencia.Name = "txtexistencia"
        Me.txtexistencia.Size = New System.Drawing.Size(76, 23)
        Me.txtexistencia.TabIndex = 93
        Me.txtexistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(69, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(426, 21)
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
        Me.Label3.Location = New System.Drawing.Point(8, 65)
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
        Me.txtcantidad.Location = New System.Drawing.Point(627, 85)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(73, 23)
        Me.txtcantidad.TabIndex = 88
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtunidad
        '
        Me.txtunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(494, 85)
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
        Me.cbonombre.Location = New System.Drawing.Point(69, 85)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(426, 23)
        Me.cbonombre.TabIndex = 86
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(8, 85)
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
        Me.Label1.Size = New System.Drawing.Size(1202, 31)
        Me.Label1.TabIndex = 99
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 405)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1182, 235)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'txtmoneda
        '
        Me.txtmoneda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtmoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmoneda.Location = New System.Drawing.Point(934, 4)
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
        Me.cbomoneda.Location = New System.Drawing.Point(839, 4)
        Me.cbomoneda.Name = "cbomoneda"
        Me.cbomoneda.Size = New System.Drawing.Size(90, 23)
        Me.cbomoneda.TabIndex = 145
        Me.cbomoneda.Text = "PESO"
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(1100, 4)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(98, 23)
        Me.txtusuario.TabIndex = 143
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column4, Me.Column8, Me.Column9, Me.Column10, Me.Column5, Me.Column7})
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(8, 114)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(1182, 220)
        Me.grdcaptura.TabIndex = 147
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
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(999, 4)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(98, 23)
        Me.lblusuario.TabIndex = 228
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(706, 89)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(148, 17)
        Me.CheckBox1.TabIndex = 232
        Me.CheckBox1.Text = "Mejor precio de compra"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(8, 40)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(77, 17)
        Me.RadioButton1.TabIndex = 233
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Inventario"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(286, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton2.TabIndex = 234
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Salidas"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(91, 38)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(189, 21)
        Me.ComboBox2.TabIndex = 235
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
        'Column6
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column6.HeaderText = "Existencia"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 74
        '
        'Column4
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 73
        '
        'Column8
        '
        Me.Column8.HeaderText = "Sugerencia"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Min / Max"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Salidas"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column5.HeaderText = "Precio"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 90
        '
        'Column7
        '
        Me.Column7.HeaderText = "Importe"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(1129, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 68)
        Me.Button1.TabIndex = 231
        Me.Button1.Text = "Nuevo"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btncopia
        '
        Me.btncopia.BackgroundImage = CType(resources.GetObject("btncopia.BackgroundImage"), System.Drawing.Image)
        Me.btncopia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncopia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncopia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncopia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncopia.Location = New System.Drawing.Point(928, 340)
        Me.btncopia.Name = "btncopia"
        Me.btncopia.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btncopia.Size = New System.Drawing.Size(61, 68)
        Me.btncopia.TabIndex = 152
        Me.btncopia.Text = "Imprimir copia"
        Me.btncopia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncopia.UseVisualStyleBackColor = True
        '
        'btncancela
        '
        Me.btncancela.BackgroundImage = CType(resources.GetObject("btncancela.BackgroundImage"), System.Drawing.Image)
        Me.btncancela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancela.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancela.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncancela.Location = New System.Drawing.Point(995, 340)
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
        Me.btnguarda.Location = New System.Drawing.Point(1062, 340)
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
        Me.btnlimpia.Location = New System.Drawing.Point(1129, 340)
        Me.btnlimpia.Name = "btnlimpia"
        Me.btnlimpia.Size = New System.Drawing.Size(61, 68)
        Me.btnlimpia.TabIndex = 148
        Me.btnlimpia.Text = "Nuevo"
        Me.btnlimpia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpia.UseVisualStyleBackColor = True
        '
        'frmPedidos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1202, 652)
        Me.Controls.Add(Me.btncopia)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.btncancela)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.btnguarda)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.btnlimpia)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.lblValor)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.txtmoneda)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbomoneda)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtexistencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbonombre)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de pedidos"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtexistencia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtunidad As System.Windows.Forms.TextBox
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmoneda As System.Windows.Forms.TextBox
    Friend WithEvents cbomoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btncancela As System.Windows.Forms.Button
    Friend WithEvents btnguarda As System.Windows.Forms.Button
    Friend WithEvents btnlimpia As System.Windows.Forms.Button
    Friend WithEvents btncopia As System.Windows.Forms.Button
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ppdPedidos As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents pMediaCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents pTicket80 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pTicket58 As System.Drawing.Printing.PrintDocument
    Friend WithEvents lblusuario As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
