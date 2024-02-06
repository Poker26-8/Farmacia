<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNomina_Empleado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNomina_Empleado))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbo_origenrec = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbo_periodicidad = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbo_tiponomina = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_antiguedad = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtultimo_folio = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.dtfecha_pago = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtdiaspagados = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.lblAl = New System.Windows.Forms.Label()
        Me.DTAl = New System.Windows.Forms.DateTimePicker()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.DTDel = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtRegFiscal = New System.Windows.Forms.TextBox()
        Me.txtRFCEmisor = New System.Windows.Forms.TextBox()
        Me.lblRegFiscal = New System.Windows.Forms.Label()
        Me.lblRFC = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_guarda_nomina = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_retenidos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_deducciones = New System.Windows.Forms.TextBox()
        Me.txttotalpagar = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtDiasInc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboTipoInca = New System.Windows.Forms.ComboBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_otros_pagos = New System.Windows.Forms.TextBox()
        Me.txt_percepciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_percepciones_gravado = New System.Windows.Forms.TextBox()
        Me.txt_percepciones_exento = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.grid_otrosp = New System.Windows.Forms.DataGridView()
        Me.concepto_otros = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grid_deducciones = New System.Windows.Forms.DataGridView()
        Me.consepto_deduccion = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnagrega_percepcion = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grid_percepciones = New System.Windows.Forms.DataGridView()
        Me.concepto_precepcion = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPeriodo = New System.Windows.Forms.ComboBox()
        Me.btnTimbrarMasivo = New System.Windows.Forms.Button()
        Me.btnTimbrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_evento = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.grid_empleados = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.grid_otrosp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grid_deducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnagrega_percepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grid_percepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid_empleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txt_antiguedad)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtultimo_folio)
        Me.Panel1.Controls.Add(Me.GroupBox12)
        Me.Panel1.Controls.Add(Me.GroupBox11)
        Me.Panel1.Controls.Add(Me.GroupBox10)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1174, 149)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.GroupBox16)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(855, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(319, 149)
        Me.Panel5.TabIndex = 29
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.Label11)
        Me.GroupBox16.Controls.Add(Me.cbo_origenrec)
        Me.GroupBox16.Controls.Add(Me.Label9)
        Me.GroupBox16.Controls.Add(Me.cbo_periodicidad)
        Me.GroupBox16.Controls.Add(Me.Label8)
        Me.GroupBox16.Controls.Add(Me.cbo_tiponomina)
        Me.GroupBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox16.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(319, 149)
        Me.GroupBox16.TabIndex = 28
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "Datos de Recibo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Periodicidad"
        '
        'cbo_origenrec
        '
        Me.cbo_origenrec.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.cbo_origenrec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_origenrec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_origenrec.FormattingEnabled = True
        Me.cbo_origenrec.Location = New System.Drawing.Point(118, 107)
        Me.cbo_origenrec.Name = "cbo_origenrec"
        Me.cbo_origenrec.Size = New System.Drawing.Size(178, 23)
        Me.cbo_origenrec.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Origen del Recurso"
        '
        'cbo_periodicidad
        '
        Me.cbo_periodicidad.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cbo_periodicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_periodicidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_periodicidad.FormattingEnabled = True
        Me.cbo_periodicidad.Location = New System.Drawing.Point(14, 75)
        Me.cbo_periodicidad.Name = "cbo_periodicidad"
        Me.cbo_periodicidad.Size = New System.Drawing.Size(282, 23)
        Me.cbo_periodicidad.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Tipo de Nomina"
        '
        'cbo_tiponomina
        '
        Me.cbo_tiponomina.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.cbo_tiponomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_tiponomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_tiponomina.FormattingEnabled = True
        Me.cbo_tiponomina.Location = New System.Drawing.Point(10, 31)
        Me.cbo_tiponomina.Name = "cbo_tiponomina"
        Me.cbo_tiponomina.Size = New System.Drawing.Size(286, 23)
        Me.cbo_tiponomina.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(693, 84)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Antiguedad"
        '
        'txt_antiguedad
        '
        Me.txt_antiguedad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_antiguedad.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_antiguedad.Location = New System.Drawing.Point(693, 100)
        Me.txt_antiguedad.Name = "txt_antiguedad"
        Me.txt_antiguedad.Size = New System.Drawing.Size(61, 29)
        Me.txt_antiguedad.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(622, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Ultimo Folio"
        '
        'txtultimo_folio
        '
        Me.txtultimo_folio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtultimo_folio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.txtultimo_folio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtultimo_folio.Location = New System.Drawing.Point(622, 101)
        Me.txtultimo_folio.Name = "txtultimo_folio"
        Me.txtultimo_folio.ReadOnly = True
        Me.txtultimo_folio.Size = New System.Drawing.Size(61, 29)
        Me.txtultimo_folio.TabIndex = 24
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.dtfecha_pago)
        Me.GroupBox12.Location = New System.Drawing.Point(497, 85)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(119, 53)
        Me.GroupBox12.TabIndex = 12
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Fecha de Pago"
        '
        'dtfecha_pago
        '
        Me.dtfecha_pago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtfecha_pago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfecha_pago.Location = New System.Drawing.Point(6, 22)
        Me.dtfecha_pago.Name = "dtfecha_pago"
        Me.dtfecha_pago.Size = New System.Drawing.Size(97, 21)
        Me.dtfecha_pago.TabIndex = 175
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtdiaspagados)
        Me.GroupBox11.Location = New System.Drawing.Point(396, 85)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(95, 53)
        Me.GroupBox11.TabIndex = 11
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Dias Pagados"
        '
        'txtdiaspagados
        '
        Me.txtdiaspagados.Location = New System.Drawing.Point(7, 21)
        Me.txtdiaspagados.Name = "txtdiaspagados"
        Me.txtdiaspagados.Size = New System.Drawing.Size(82, 20)
        Me.txtdiaspagados.TabIndex = 0
        Me.txtdiaspagados.Text = "0"
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.White
        Me.GroupBox10.Controls.Add(Me.lblAl)
        Me.GroupBox10.Controls.Add(Me.DTAl)
        Me.GroupBox10.Controls.Add(Me.lblDel)
        Me.GroupBox10.Controls.Add(Me.DTDel)
        Me.GroupBox10.Location = New System.Drawing.Point(122, 85)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(268, 53)
        Me.GroupBox10.TabIndex = 10
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Periodo de Pago"
        '
        'lblAl
        '
        Me.lblAl.AutoSize = True
        Me.lblAl.Location = New System.Drawing.Point(141, 29)
        Me.lblAl.Name = "lblAl"
        Me.lblAl.Size = New System.Drawing.Size(15, 13)
        Me.lblAl.TabIndex = 175
        Me.lblAl.Text = "al"
        '
        'DTAl
        '
        Me.DTAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTAl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTAl.Location = New System.Drawing.Point(162, 22)
        Me.DTAl.Name = "DTAl"
        Me.DTAl.Size = New System.Drawing.Size(97, 21)
        Me.DTAl.TabIndex = 174
        '
        'lblDel
        '
        Me.lblDel.AutoSize = True
        Me.lblDel.Location = New System.Drawing.Point(6, 24)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(21, 13)
        Me.lblDel.TabIndex = 173
        Me.lblDel.Text = "del"
        '
        'DTDel
        '
        Me.DTDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTDel.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTDel.Location = New System.Drawing.Point(33, 23)
        Me.DTDel.Name = "DTDel"
        Me.DTDel.Size = New System.Drawing.Size(102, 21)
        Me.DTDel.TabIndex = 172
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtRegFiscal)
        Me.GroupBox1.Controls.Add(Me.txtRFCEmisor)
        Me.GroupBox1.Controls.Add(Me.lblRegFiscal)
        Me.GroupBox1.Controls.Add(Me.lblRFC)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboEmpresa)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkRed
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(846, 76)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del Emisor"
        '
        'txtRegFiscal
        '
        Me.txtRegFiscal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRegFiscal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.txtRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegFiscal.Location = New System.Drawing.Point(119, 50)
        Me.txtRegFiscal.Name = "txtRegFiscal"
        Me.txtRegFiscal.ReadOnly = True
        Me.txtRegFiscal.Size = New System.Drawing.Size(530, 22)
        Me.txtRegFiscal.TabIndex = 10
        '
        'txtRFCEmisor
        '
        Me.txtRFCEmisor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRFCEmisor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.txtRFCEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRFCEmisor.Location = New System.Drawing.Point(707, 49)
        Me.txtRFCEmisor.Name = "txtRFCEmisor"
        Me.txtRFCEmisor.ReadOnly = True
        Me.txtRFCEmisor.Size = New System.Drawing.Size(124, 22)
        Me.txtRFCEmisor.TabIndex = 9
        '
        'lblRegFiscal
        '
        Me.lblRegFiscal.AutoSize = True
        Me.lblRegFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegFiscal.ForeColor = System.Drawing.Color.Black
        Me.lblRegFiscal.Location = New System.Drawing.Point(34, 55)
        Me.lblRegFiscal.Name = "lblRegFiscal"
        Me.lblRegFiscal.Size = New System.Drawing.Size(79, 15)
        Me.lblRegFiscal.TabIndex = 8
        Me.lblRegFiscal.Text = "Reg. Fiscal"
        '
        'lblRFC
        '
        Me.lblRFC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblRFC.AutoSize = True
        Me.lblRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRFC.ForeColor = System.Drawing.Color.Black
        Me.lblRFC.Location = New System.Drawing.Point(655, 54)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(46, 15)
        Me.lblRFC.TabIndex = 7
        Me.lblRFC.Text = "R.F.C."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(104, 24)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(725, 21)
        Me.cboEmpresa.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btn_guarda_nomina)
        Me.Panel2.Controls.Add(Me.GroupBox7)
        Me.Panel2.Controls.Add(Me.GroupBox6)
        Me.Panel2.Controls.Add(Me.GroupBox15)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.btnagrega_percepcion)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 504)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1174, 334)
        Me.Panel2.TabIndex = 1
        '
        'btn_guarda_nomina
        '
        Me.btn_guarda_nomina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_guarda_nomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guarda_nomina.Image = CType(resources.GetObject("btn_guarda_nomina.Image"), System.Drawing.Image)
        Me.btn_guarda_nomina.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_guarda_nomina.Location = New System.Drawing.Point(1068, 214)
        Me.btn_guarda_nomina.Name = "btn_guarda_nomina"
        Me.btn_guarda_nomina.Size = New System.Drawing.Size(100, 59)
        Me.btn_guarda_nomina.TabIndex = 27
        Me.btn_guarda_nomina.Text = "        Guardar Nomina"
        Me.btn_guarda_nomina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_guarda_nomina.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.txt_retenidos)
        Me.GroupBox7.Controls.Add(Me.Label3)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.txt_deducciones)
        Me.GroupBox7.Controls.Add(Me.txttotalpagar)
        Me.GroupBox7.Location = New System.Drawing.Point(786, 198)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(237, 113)
        Me.GroupBox7.TabIndex = 26
        Me.GroupBox7.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "IMPUESTOS RETENIDOS"
        '
        'txt_retenidos
        '
        Me.txt_retenidos.Location = New System.Drawing.Point(152, 36)
        Me.txt_retenidos.Name = "txt_retenidos"
        Me.txt_retenidos.Size = New System.Drawing.Size(78, 20)
        Me.txt_retenidos.TabIndex = 5
        Me.txt_retenidos.Text = "0"
        Me.txt_retenidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SUMA DE DEDUCCIONES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "TOTAL A PAGAR"
        '
        'txt_deducciones
        '
        Me.txt_deducciones.Location = New System.Drawing.Point(149, 9)
        Me.txt_deducciones.Name = "txt_deducciones"
        Me.txt_deducciones.Size = New System.Drawing.Size(81, 20)
        Me.txt_deducciones.TabIndex = 1
        Me.txt_deducciones.Text = "0"
        Me.txt_deducciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txttotalpagar
        '
        Me.txttotalpagar.Location = New System.Drawing.Point(112, 87)
        Me.txttotalpagar.Name = "txttotalpagar"
        Me.txttotalpagar.Size = New System.Drawing.Size(112, 20)
        Me.txttotalpagar.TabIndex = 3
        Me.txttotalpagar.Text = "0"
        Me.txttotalpagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtDiasInc)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.cboTipoInca)
        Me.GroupBox6.Location = New System.Drawing.Point(625, 149)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(542, 44)
        Me.GroupBox6.TabIndex = 25
        Me.GroupBox6.TabStop = False
        '
        'txtDiasInc
        '
        Me.txtDiasInc.Location = New System.Drawing.Point(418, 14)
        Me.txtDiasInc.Name = "txtDiasInc"
        Me.txtDiasInc.Size = New System.Drawing.Size(115, 20)
        Me.txtDiasInc.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(322, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 13)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Días Incapacidad"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Tipo de Incapacidad"
        '
        'cboTipoInca
        '
        Me.cboTipoInca.BackColor = System.Drawing.Color.White
        Me.cboTipoInca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoInca.FormattingEnabled = True
        Me.cboTipoInca.Location = New System.Drawing.Point(119, 14)
        Me.cboTipoInca.Name = "cboTipoInca"
        Me.cboTipoInca.Size = New System.Drawing.Size(198, 21)
        Me.cboTipoInca.TabIndex = 0
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label12)
        Me.GroupBox15.Controls.Add(Me.Label2)
        Me.GroupBox15.Controls.Add(Me.Label5)
        Me.GroupBox15.Controls.Add(Me.txt_otros_pagos)
        Me.GroupBox15.Controls.Add(Me.txt_percepciones)
        Me.GroupBox15.Controls.Add(Me.Label6)
        Me.GroupBox15.Controls.Add(Me.txt_percepciones_gravado)
        Me.GroupBox15.Controls.Add(Me.txt_percepciones_exento)
        Me.GroupBox15.Location = New System.Drawing.Point(475, 198)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(305, 115)
        Me.GroupBox15.TabIndex = 23
        Me.GroupBox15.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(82, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(123, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "TOTAL OTROS PAGOS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "TOTAL DE PERCEPCIONES"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(184, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "TOTAL GRAVADO PERCEPCIONES"
        '
        'txt_otros_pagos
        '
        Me.txt_otros_pagos.Location = New System.Drawing.Point(211, 63)
        Me.txt_otros_pagos.Name = "txt_otros_pagos"
        Me.txt_otros_pagos.Size = New System.Drawing.Size(94, 20)
        Me.txt_otros_pagos.TabIndex = 2
        Me.txt_otros_pagos.Text = "0"
        Me.txt_otros_pagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_percepciones
        '
        Me.txt_percepciones.Location = New System.Drawing.Point(211, 89)
        Me.txt_percepciones.Name = "txt_percepciones"
        Me.txt_percepciones.Size = New System.Drawing.Size(94, 20)
        Me.txt_percepciones.TabIndex = 0
        Me.txt_percepciones.Text = "0"
        Me.txt_percepciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(175, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "TOTAL EXENTO PERCEPCIONES"
        '
        'txt_percepciones_gravado
        '
        Me.txt_percepciones_gravado.Location = New System.Drawing.Point(211, 9)
        Me.txt_percepciones_gravado.Name = "txt_percepciones_gravado"
        Me.txt_percepciones_gravado.Size = New System.Drawing.Size(94, 20)
        Me.txt_percepciones_gravado.TabIndex = 0
        Me.txt_percepciones_gravado.Text = "0"
        Me.txt_percepciones_gravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_percepciones_exento
        '
        Me.txt_percepciones_exento.Location = New System.Drawing.Point(211, 35)
        Me.txt_percepciones_exento.Name = "txt_percepciones_exento"
        Me.txt_percepciones_exento.Size = New System.Drawing.Size(94, 20)
        Me.txt_percepciones_exento.TabIndex = 0
        Me.txt_percepciones_exento.Text = "0"
        Me.txt_percepciones_exento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.Control_Negocios.My.Resources.Resources.edit_add
        Me.PictureBox2.Location = New System.Drawing.Point(435, 165)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(34, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grid_otrosp)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(15, 148)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(414, 121)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Otros Pagos"
        '
        'grid_otrosp
        '
        Me.grid_otrosp.AllowUserToAddRows = False
        Me.grid_otrosp.BackgroundColor = System.Drawing.Color.White
        Me.grid_otrosp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_otrosp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.concepto_otros, Me.DataGridViewTextBoxColumn5})
        Me.grid_otrosp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_otrosp.Location = New System.Drawing.Point(3, 17)
        Me.grid_otrosp.Name = "grid_otrosp"
        Me.grid_otrosp.Size = New System.Drawing.Size(408, 101)
        Me.grid_otrosp.TabIndex = 2
        '
        'concepto_otros
        '
        Me.concepto_otros.HeaderText = "CONCEPTO"
        Me.concepto_otros.Name = "concepto_otros"
        Me.concepto_otros.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.concepto_otros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.concepto_otros.Width = 270
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.grid_deducciones)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(622, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(545, 137)
        Me.GroupBox4.TabIndex = 18
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Deducciones"
        '
        'grid_deducciones
        '
        Me.grid_deducciones.AllowUserToAddRows = False
        Me.grid_deducciones.BackgroundColor = System.Drawing.Color.White
        Me.grid_deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_deducciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.consepto_deduccion, Me.DataGridViewTextBoxColumn4})
        Me.grid_deducciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_deducciones.Location = New System.Drawing.Point(3, 17)
        Me.grid_deducciones.Name = "grid_deducciones"
        Me.grid_deducciones.Size = New System.Drawing.Size(539, 117)
        Me.grid_deducciones.TabIndex = 2
        '
        'consepto_deduccion
        '
        Me.consepto_deduccion.HeaderText = "CONCEPTO"
        Me.consepto_deduccion.Name = "consepto_deduccion"
        Me.consepto_deduccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.consepto_deduccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.consepto_deduccion.Width = 400
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Control_Negocios.My.Resources.Resources.edit_add
        Me.PictureBox1.Location = New System.Drawing.Point(583, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'btnagrega_percepcion
        '
        Me.btnagrega_percepcion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnagrega_percepcion.Image = Global.Control_Negocios.My.Resources.Resources.edit_add
        Me.btnagrega_percepcion.Location = New System.Drawing.Point(582, 23)
        Me.btnagrega_percepcion.Name = "btnagrega_percepcion"
        Me.btnagrega_percepcion.Size = New System.Drawing.Size(34, 29)
        Me.btnagrega_percepcion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnagrega_percepcion.TabIndex = 16
        Me.btnagrega_percepcion.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grid_percepciones)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(564, 137)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Percepciones"
        '
        'grid_percepciones
        '
        Me.grid_percepciones.AllowUserToAddRows = False
        Me.grid_percepciones.BackgroundColor = System.Drawing.Color.White
        Me.grid_percepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_percepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.concepto_precepcion, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.grid_percepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_percepciones.Location = New System.Drawing.Point(3, 17)
        Me.grid_percepciones.Name = "grid_percepciones"
        Me.grid_percepciones.Size = New System.Drawing.Size(558, 117)
        Me.grid_percepciones.TabIndex = 1
        '
        'concepto_precepcion
        '
        Me.concepto_precepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.concepto_precepcion.HeaderText = "CONCEPTO"
        Me.concepto_precepcion.Name = "concepto_precepcion"
        Me.concepto_precepcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.concepto_precepcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.concepto_precepcion.Width = 106
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "GRAVADO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "EXENTO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.cboPeriodo)
        Me.Panel3.Controls.Add(Me.btnTimbrarMasivo)
        Me.Panel3.Controls.Add(Me.btnTimbrar)
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1064, 149)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(110, 355)
        Me.Panel3.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Tipo de Recibo"
        Me.Label7.Visible = False
        '
        'cboPeriodo
        '
        Me.cboPeriodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboPeriodo.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodo.FormattingEnabled = True
        Me.cboPeriodo.Location = New System.Drawing.Point(5, 326)
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(99, 23)
        Me.cboPeriodo.TabIndex = 7
        Me.cboPeriodo.Visible = False
        '
        'btnTimbrarMasivo
        '
        Me.btnTimbrarMasivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimbrarMasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTimbrarMasivo.Image = CType(resources.GetObject("btnTimbrarMasivo.Image"), System.Drawing.Image)
        Me.btnTimbrarMasivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTimbrarMasivo.Location = New System.Drawing.Point(3, 108)
        Me.btnTimbrarMasivo.Name = "btnTimbrarMasivo"
        Me.btnTimbrarMasivo.Size = New System.Drawing.Size(102, 104)
        Me.btnTimbrarMasivo.TabIndex = 2
        Me.btnTimbrarMasivo.Text = "Timbrar Todos"
        Me.btnTimbrarMasivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTimbrarMasivo.UseVisualStyleBackColor = True
        '
        'btnTimbrar
        '
        Me.btnTimbrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTimbrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTimbrar.Image = CType(resources.GetObject("btnTimbrar.Image"), System.Drawing.Image)
        Me.btnTimbrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTimbrar.Location = New System.Drawing.Point(3, 6)
        Me.btnTimbrar.Name = "btnTimbrar"
        Me.btnTimbrar.Size = New System.Drawing.Size(102, 86)
        Me.btnTimbrar.TabIndex = 1
        Me.btnTimbrar.Text = "Timbrar Seleccionado"
        Me.btnTimbrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTimbrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(3, 230)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(102, 74)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 149)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1064, 355)
        Me.Panel4.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_evento)
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.grid_empleados)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1064, 355)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Empleado Nomina"
        '
        'lbl_evento
        '
        Me.lbl_evento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_evento.Location = New System.Drawing.Point(12, 298)
        Me.lbl_evento.Name = "lbl_evento"
        Me.lbl_evento.Size = New System.Drawing.Size(147, 25)
        Me.lbl_evento.TabIndex = 19
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 329)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1052, 23)
        Me.ProgressBar1.TabIndex = 20
        Me.ProgressBar1.Visible = False
        '
        'grid_empleados
        '
        Me.grid_empleados.AllowUserToAddRows = False
        Me.grid_empleados.AllowUserToDeleteRows = False
        Me.grid_empleados.BackgroundColor = System.Drawing.Color.White
        Me.grid_empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_empleados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.grid_empleados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_empleados.Location = New System.Drawing.Point(3, 17)
        Me.grid_empleados.Name = "grid_empleados"
        Me.grid_empleados.ReadOnly = True
        Me.grid_empleados.RowHeadersVisible = False
        Me.grid_empleados.Size = New System.Drawing.Size(1058, 335)
        Me.grid_empleados.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "id_empleado"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 116
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Empleado"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 97
        '
        'Column3
        '
        Me.Column3.HeaderText = "CURP"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "NSS"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Num. Empleado"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Departamento"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 123
        '
        'Column7
        '
        Me.Column7.HeaderText = "Puesto"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "RFC"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Sueldo"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Fecha Timbre"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Estatus"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column12.HeaderText = "Fecha Ingreso"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 113
        '
        'frmNomina_Empleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1174, 838)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNomina_Empleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nomina de Empleados"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.grid_otrosp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grid_deducciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnagrega_percepcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grid_percepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grid_empleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnTimbrarMasivo As Button
    Friend WithEvents btnTimbrar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grid_empleados As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnagrega_percepcion As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents grid_percepciones As DataGridView
    Friend WithEvents concepto_precepcion As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents grid_deducciones As DataGridView
    Friend WithEvents consepto_deduccion As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents btn_guarda_nomina As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txt_retenidos As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_deducciones As TextBox
    Friend WithEvents txttotalpagar As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtDiasInc As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cboTipoInca As ComboBox
    Friend WithEvents GroupBox15 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_otros_pagos As TextBox
    Friend WithEvents txt_percepciones As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_percepciones_gravado As TextBox
    Friend WithEvents txt_percepciones_exento As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboPeriodo As ComboBox
    Friend WithEvents GroupBox16 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbo_origenrec As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbo_periodicidad As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cbo_tiponomina As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txt_antiguedad As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtultimo_folio As TextBox
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents dtfecha_pago As DateTimePicker
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents txtdiaspagados As TextBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents lblAl As Label
    Friend WithEvents DTAl As DateTimePicker
    Friend WithEvents lblDel As Label
    Friend WithEvents DTDel As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtRegFiscal As TextBox
    Friend WithEvents txtRFCEmisor As TextBox
    Friend WithEvents lblRegFiscal As Label
    Friend WithEvents lblRFC As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboEmpresa As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grid_otrosp As DataGridView
    Friend WithEvents concepto_otros As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents lbl_evento As Label
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
