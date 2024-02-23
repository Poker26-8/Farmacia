<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlServicios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlServicios))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcomentario = New System.Windows.Forms.RichTextBox()
        Me.txtfecha_p = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtn_proceso = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grdPendientes = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.boxFin = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpf_proceso = New System.Windows.Forms.DateTimePicker()
        Me.cboproceso = New System.Windows.Forms.ComboBox()
        Me.btnfin = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grdFin = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.dtptermino = New System.Windows.Forms.TextBox()
        Me.dtpInicio = New System.Windows.Forms.TextBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtproceso = New System.Windows.Forms.RichTextBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtcomentarioventa = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxFin.SuspendLayout()
        CType(Me.grdFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(12, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(423, 18)
        Me.Label8.TabIndex = 253
        Me.Label8.Text = "Escribe tu contraseña para ver tus trabajos pendientes"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(910, 413)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(120, 29)
        Me.Button3.TabIndex = 252
        Me.Button3.Text = "Terminar"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(1036, 412)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 29)
        Me.Button2.TabIndex = 251
        Me.Button2.Text = "Limpiar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_id)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtcomentario)
        Me.GroupBox3.Controls.Add(Me.txtfecha_p)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtn_proceso)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(635, 226)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(521, 181)
        Me.GroupBox3.TabIndex = 250
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proceso"
        '
        'txt_id
        '
        Me.txt_id.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_id.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_id.Location = New System.Drawing.Point(8, 146)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.ReadOnly = True
        Me.txt_id.Size = New System.Drawing.Size(72, 22)
        Me.txt_id.TabIndex = 244
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(393, 146)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 29)
        Me.Button1.TabIndex = 240
        Me.Button1.Text = "Concluir proceso"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(8, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(505, 18)
        Me.Label12.TabIndex = 236
        Me.Label12.Text = "Comentario"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcomentario
        '
        Me.txtcomentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcomentario.Location = New System.Drawing.Point(8, 74)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(505, 66)
        Me.txtcomentario.TabIndex = 239
        Me.txtcomentario.Text = ""
        '
        'txtfecha_p
        '
        Me.txtfecha_p.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtfecha_p.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha_p.Location = New System.Drawing.Point(404, 32)
        Me.txtfecha_p.Name = "txtfecha_p"
        Me.txtfecha_p.ReadOnly = True
        Me.txtfecha_p.Size = New System.Drawing.Size(109, 23)
        Me.txtfecha_p.TabIndex = 91
        Me.txtfecha_p.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(397, 18)
        Me.Label10.TabIndex = 87
        Me.Label10.Text = "Nombre del proceso"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtn_proceso
        '
        Me.txtn_proceso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn_proceso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtn_proceso.Location = New System.Drawing.Point(8, 32)
        Me.txtn_proceso.Name = "txtn_proceso"
        Me.txtn_proceso.ReadOnly = True
        Me.txtn_proceso.Size = New System.Drawing.Size(397, 23)
        Me.txtn_proceso.TabIndex = 84
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(404, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 18)
        Me.Label13.TabIndex = 238
        Me.Label13.Text = "Fecha de entrega"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.grdPendientes)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 37)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(624, 181)
        Me.GroupBox2.TabIndex = 249
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pendientes"
        '
        'grdPendientes
        '
        Me.grdPendientes.AllowUserToAddRows = False
        Me.grdPendientes.AllowUserToDeleteRows = False
        Me.grdPendientes.BackgroundColor = System.Drawing.Color.White
        Me.grdPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column8})
        Me.grdPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPendientes.Location = New System.Drawing.Point(3, 16)
        Me.grdPendientes.Name = "grdPendientes"
        Me.grdPendientes.ReadOnly = True
        Me.grdPendientes.RowHeadersVisible = False
        Me.grdPendientes.Size = New System.Drawing.Size(618, 162)
        Me.grdPendientes.TabIndex = 106
        '
        'Column1
        '
        Me.Column1.HeaderText = "Id"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
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
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column4
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column4.HeaderText = "Fecha de entrega"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 120
        '
        'Column8
        '
        Me.Column8.HeaderText = "Folio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'boxFin
        '
        Me.boxFin.Controls.Add(Me.Label14)
        Me.boxFin.Controls.Add(Me.dtpf_proceso)
        Me.boxFin.Controls.Add(Me.cboproceso)
        Me.boxFin.Controls.Add(Me.btnfin)
        Me.boxFin.Controls.Add(Me.Label20)
        Me.boxFin.Controls.Add(Me.grdFin)
        Me.boxFin.Location = New System.Drawing.Point(5, 221)
        Me.boxFin.Name = "boxFin"
        Me.boxFin.Size = New System.Drawing.Size(624, 216)
        Me.boxFin.TabIndex = 248
        Me.boxFin.TabStop = False
        Me.boxFin.Text = "Procesos a realizar"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(429, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 18)
        Me.Label14.TabIndex = 240
        Me.Label14.Text = "Fecha de entrega"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpf_proceso
        '
        Me.dtpf_proceso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpf_proceso.Location = New System.Drawing.Point(429, 35)
        Me.dtpf_proceso.Name = "dtpf_proceso"
        Me.dtpf_proceso.Size = New System.Drawing.Size(109, 20)
        Me.dtpf_proceso.TabIndex = 239
        '
        'cboproceso
        '
        Me.cboproceso.BackColor = System.Drawing.Color.White
        Me.cboproceso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboproceso.FormattingEnabled = True
        Me.cboproceso.Location = New System.Drawing.Point(7, 35)
        Me.cboproceso.Name = "cboproceso"
        Me.cboproceso.Size = New System.Drawing.Size(423, 23)
        Me.cboproceso.TabIndex = 108
        '
        'btnfin
        '
        Me.btnfin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnfin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnfin.Location = New System.Drawing.Point(544, 18)
        Me.btnfin.Name = "btnfin"
        Me.btnfin.Size = New System.Drawing.Size(73, 40)
        Me.btnfin.TabIndex = 107
        Me.btnfin.Text = "Agregar"
        Me.btnfin.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(7, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(423, 18)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "Proceso"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdFin
        '
        Me.grdFin.AllowUserToAddRows = False
        Me.grdFin.AllowUserToDeleteRows = False
        Me.grdFin.BackgroundColor = System.Drawing.Color.White
        Me.grdFin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFin.ColumnHeadersVisible = False
        Me.grdFin.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6, Me.Column7})
        Me.grdFin.Location = New System.Drawing.Point(7, 61)
        Me.grdFin.Name = "grdFin"
        Me.grdFin.ReadOnly = True
        Me.grdFin.RowHeadersVisible = False
        Me.grdFin.Size = New System.Drawing.Size(610, 149)
        Me.grdFin.TabIndex = 106
        '
        'Column5
        '
        Me.Column5.HeaderText = "Id"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = "Descripcion"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column7.HeaderText = "Fecha de entrega"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 110
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.txtid)
        Me.GroupBox1.Controls.Add(Me.dtptermino)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.txtnombre)
        Me.GroupBox1.Controls.Add(Me.txtproceso)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(635, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 181)
        Me.GroupBox1.TabIndex = 247
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del servicio seleccionado"
        '
        'txtid
        '
        Me.txtid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtid.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.Location = New System.Drawing.Point(8, 129)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(72, 22)
        Me.txtid.TabIndex = 243
        '
        'dtptermino
        '
        Me.dtptermino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtptermino.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtptermino.Location = New System.Drawing.Point(404, 147)
        Me.dtptermino.Name = "dtptermino"
        Me.dtptermino.ReadOnly = True
        Me.dtptermino.Size = New System.Drawing.Size(109, 23)
        Me.dtptermino.TabIndex = 242
        Me.dtptermino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtpInicio
        '
        Me.dtpInicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dtpInicio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInicio.Location = New System.Drawing.Point(289, 147)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.ReadOnly = True
        Me.dtpInicio.Size = New System.Drawing.Size(109, 23)
        Me.dtpInicio.TabIndex = 241
        Me.dtpInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre.Location = New System.Drawing.Point(79, 32)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.ReadOnly = True
        Me.txtnombre.Size = New System.Drawing.Size(434, 23)
        Me.txtnombre.TabIndex = 240
        '
        'txtproceso
        '
        Me.txtproceso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtproceso.Location = New System.Drawing.Point(8, 61)
        Me.txtproceso.Name = "txtproceso"
        Me.txtproceso.ReadOnly = True
        Me.txtproceso.Size = New System.Drawing.Size(505, 66)
        Me.txtproceso.TabIndex = 239
        Me.txtproceso.Text = ""
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(8, 32)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(72, 23)
        Me.txtcodigo.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(79, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(434, 18)
        Me.Label2.TabIndex = 87
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(289, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 18)
        Me.Label6.TabIndex = 236
        Me.Label6.Text = "Inicio"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(404, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 18)
        Me.Label7.TabIndex = 238
        Me.Label7.Text = "Termino"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.White
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(964, 10)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(98, 23)
        Me.txtusuario.TabIndex = 245
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(1068, 10)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(98, 23)
        Me.lblusuario.TabIndex = 246
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Label1.Size = New System.Drawing.Size(1175, 34)
        Me.Label1.TabIndex = 244
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcomentarioventa
        '
        Me.txtcomentarioventa.Location = New System.Drawing.Point(635, 409)
        Me.txtcomentarioventa.Name = "txtcomentarioventa"
        Me.txtcomentarioventa.Size = New System.Drawing.Size(269, 32)
        Me.txtcomentarioventa.TabIndex = 254
        Me.txtcomentarioventa.Text = ""
        '
        'frmControlServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1175, 453)
        Me.Controls.Add(Me.txtcomentarioventa)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.boxFin)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1191, 492)
        Me.MinimumSize = New System.Drawing.Size(1191, 492)
        Me.Name = "frmControlServicios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de servicios"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxFin.ResumeLayout(False)
        CType(Me.grdFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txt_id As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents txtcomentario As RichTextBox
    Friend WithEvents txtfecha_p As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtn_proceso As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents grdPendientes As DataGridView
    Friend WithEvents boxFin As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents dtpf_proceso As DateTimePicker
    Friend WithEvents cboproceso As ComboBox
    Friend WithEvents btnfin As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents grdFin As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtid As TextBox
    Friend WithEvents dtptermino As TextBox
    Friend WithEvents dtpInicio As TextBox
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents txtproceso As RichTextBox
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents lblusuario As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcomentarioventa As RichTextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
End Class
