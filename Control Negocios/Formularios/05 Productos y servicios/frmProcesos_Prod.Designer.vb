<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesos_Prod
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcesos_Prod))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbolote = New System.Windows.Forms.ComboBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.boxInicio = New System.Windows.Forms.GroupBox()
        Me.txtcod = New System.Windows.Forms.TextBox()
        Me.cboEncargado = New System.Windows.Forms.ComboBox()
        Me.btninicio = New System.Windows.Forms.Button()
        Me.grdInicio = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRequiere = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCant1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUnidad1 = New System.Windows.Forms.TextBox()
        Me.cboDesc1 = New System.Windows.Forms.ComboBox()
        Me.txtproceso = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.boxFin = New System.Windows.Forms.GroupBox()
        Me.txtencargado = New System.Windows.Forms.TextBox()
        Me.cboproceso = New System.Windows.Forms.ComboBox()
        Me.btnfin = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtmerma = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grdFin = New System.Windows.Forms.DataGridView()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnterminar = New System.Windows.Forms.Button()
        Me.btnencargado = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.boxInicio.SuspendLayout()
        CType(Me.grdInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxFin.SuspendLayout()
        CType(Me.grdFin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(637, 31)
        Me.Label1.TabIndex = 156
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbolote)
        Me.GroupBox1.Controls.Add(Me.txtcodigo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtcantidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtunidad)
        Me.GroupBox1.Controls.Add(Me.cbonombre)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(631, 62)
        Me.GroupBox1.TabIndex = 157
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Artículo"
        '
        'cbolote
        '
        Me.cbolote.BackColor = System.Drawing.Color.White
        Me.cbolote.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbolote.FormattingEnabled = True
        Me.cbolote.Location = New System.Drawing.Point(511, 32)
        Me.cbolote.Name = "cbolote"
        Me.cbolote.Size = New System.Drawing.Size(113, 23)
        Me.cbolote.TabIndex = 102
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcodigo.Location = New System.Drawing.Point(7, 32)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(72, 23)
        Me.txtcodigo.TabIndex = 95
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(511, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 18)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Lote"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(444, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 18)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcantidad
        '
        Me.txtcantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(444, 32)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(68, 23)
        Me.txtcantidad.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(384, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Unidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(78, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(307, 18)
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
        Me.Label3.Location = New System.Drawing.Point(7, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtunidad
        '
        Me.txtunidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(384, 32)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(61, 23)
        Me.txtunidad.TabIndex = 84
        '
        'cbonombre
        '
        Me.cbonombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbonombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(78, 32)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(307, 23)
        Me.cbonombre.TabIndex = 83
        '
        'boxInicio
        '
        Me.boxInicio.Controls.Add(Me.txtcod)
        Me.boxInicio.Controls.Add(Me.cboEncargado)
        Me.boxInicio.Controls.Add(Me.btninicio)
        Me.boxInicio.Controls.Add(Me.grdInicio)
        Me.boxInicio.Controls.Add(Me.Label8)
        Me.boxInicio.Controls.Add(Me.txtRequiere)
        Me.boxInicio.Controls.Add(Me.Label9)
        Me.boxInicio.Controls.Add(Me.txtCant1)
        Me.boxInicio.Controls.Add(Me.Label11)
        Me.boxInicio.Controls.Add(Me.Label12)
        Me.boxInicio.Controls.Add(Me.Label13)
        Me.boxInicio.Controls.Add(Me.txtUnidad1)
        Me.boxInicio.Controls.Add(Me.cboDesc1)
        Me.boxInicio.Controls.Add(Me.txtproceso)
        Me.boxInicio.Controls.Add(Me.Label6)
        Me.boxInicio.Controls.Add(Me.Label7)
        Me.boxInicio.Enabled = False
        Me.boxInicio.Location = New System.Drawing.Point(6, 95)
        Me.boxInicio.Name = "boxInicio"
        Me.boxInicio.Size = New System.Drawing.Size(631, 197)
        Me.boxInicio.TabIndex = 158
        Me.boxInicio.TabStop = False
        Me.boxInicio.Text = "Inicio de proceso"
        '
        'txtcod
        '
        Me.txtcod.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcod.Location = New System.Drawing.Point(7, 78)
        Me.txtcod.Name = "txtcod"
        Me.txtcod.Size = New System.Drawing.Size(72, 23)
        Me.txtcod.TabIndex = 109
        '
        'cboEncargado
        '
        Me.cboEncargado.BackColor = System.Drawing.Color.White
        Me.cboEncargado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEncargado.FormattingEnabled = True
        Me.cboEncargado.Location = New System.Drawing.Point(391, 35)
        Me.cboEncargado.Name = "cboEncargado"
        Me.cboEncargado.Size = New System.Drawing.Size(92, 23)
        Me.cboEncargado.TabIndex = 108
        '
        'btninicio
        '
        Me.btninicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btninicio.Image = CType(resources.GetObject("btninicio.Image"), System.Drawing.Image)
        Me.btninicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btninicio.Location = New System.Drawing.Point(489, 18)
        Me.btninicio.Name = "btninicio"
        Me.btninicio.Size = New System.Drawing.Size(135, 40)
        Me.btninicio.TabIndex = 107
        Me.btninicio.Text = "Iniciar proceso"
        Me.btninicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btninicio.UseVisualStyleBackColor = True
        '
        'grdInicio
        '
        Me.grdInicio.AllowUserToAddRows = False
        Me.grdInicio.AllowUserToDeleteRows = False
        Me.grdInicio.BackgroundColor = System.Drawing.Color.White
        Me.grdInicio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInicio.Location = New System.Drawing.Point(7, 105)
        Me.grdInicio.Name = "grdInicio"
        Me.grdInicio.ReadOnly = True
        Me.grdInicio.RowHeadersVisible = False
        Me.grdInicio.Size = New System.Drawing.Size(617, 86)
        Me.grdInicio.TabIndex = 106
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(511, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(113, 18)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Requiere"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRequiere
        '
        Me.txtRequiere.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRequiere.Location = New System.Drawing.Point(511, 78)
        Me.txtRequiere.Name = "txtRequiere"
        Me.txtRequiere.Size = New System.Drawing.Size(113, 23)
        Me.txtRequiere.TabIndex = 104
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(444, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 18)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Cantidad"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCant1
        '
        Me.txtCant1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant1.Location = New System.Drawing.Point(444, 78)
        Me.txtCant1.Name = "txtCant1"
        Me.txtCant1.Size = New System.Drawing.Size(68, 23)
        Me.txtCant1.TabIndex = 102
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(384, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 18)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Unidad"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(78, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(307, 18)
        Me.Label12.TabIndex = 99
        Me.Label12.Text = "Descripción"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(7, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 18)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Código"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUnidad1
        '
        Me.txtUnidad1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnidad1.Location = New System.Drawing.Point(384, 78)
        Me.txtUnidad1.Name = "txtUnidad1"
        Me.txtUnidad1.Size = New System.Drawing.Size(61, 23)
        Me.txtUnidad1.TabIndex = 97
        '
        'cboDesc1
        '
        Me.cboDesc1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDesc1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDesc1.FormattingEnabled = True
        Me.cboDesc1.Location = New System.Drawing.Point(78, 78)
        Me.cboDesc1.Name = "cboDesc1"
        Me.cboDesc1.Size = New System.Drawing.Size(307, 23)
        Me.cboDesc1.TabIndex = 96
        '
        'txtproceso
        '
        Me.txtproceso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtproceso.Location = New System.Drawing.Point(7, 35)
        Me.txtproceso.Name = "txtproceso"
        Me.txtproceso.Size = New System.Drawing.Size(385, 23)
        Me.txtproceso.TabIndex = 94
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(391, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 18)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "Encargado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(7, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(385, 18)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Proceso"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtusuario
        '
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(545, 4)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(85, 23)
        Me.txtusuario.TabIndex = 159
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.MidnightBlue
        Me.lblusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(450, 4)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(96, 23)
        Me.lblusuario.TabIndex = 95
        Me.lblusuario.Text = "USUARIO"
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boxFin
        '
        Me.boxFin.Controls.Add(Me.txtencargado)
        Me.boxFin.Controls.Add(Me.cboproceso)
        Me.boxFin.Controls.Add(Me.btnfin)
        Me.boxFin.Controls.Add(Me.Label14)
        Me.boxFin.Controls.Add(Me.txtmerma)
        Me.boxFin.Controls.Add(Me.Label19)
        Me.boxFin.Controls.Add(Me.Label20)
        Me.boxFin.Controls.Add(Me.grdFin)
        Me.boxFin.Enabled = False
        Me.boxFin.Location = New System.Drawing.Point(6, 292)
        Me.boxFin.Name = "boxFin"
        Me.boxFin.Size = New System.Drawing.Size(631, 197)
        Me.boxFin.TabIndex = 160
        Me.boxFin.TabStop = False
        Me.boxFin.Text = "Fin de proceso"
        '
        'txtencargado
        '
        Me.txtencargado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtencargado.Location = New System.Drawing.Point(391, 35)
        Me.txtencargado.Name = "txtencargado"
        Me.txtencargado.Size = New System.Drawing.Size(84, 23)
        Me.txtencargado.TabIndex = 109
        '
        'cboproceso
        '
        Me.cboproceso.BackColor = System.Drawing.Color.White
        Me.cboproceso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboproceso.FormattingEnabled = True
        Me.cboproceso.Location = New System.Drawing.Point(7, 35)
        Me.cboproceso.Name = "cboproceso"
        Me.cboproceso.Size = New System.Drawing.Size(385, 23)
        Me.cboproceso.TabIndex = 108
        '
        'btnfin
        '
        Me.btnfin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnfin.Image = CType(resources.GetObject("btnfin.Image"), System.Drawing.Image)
        Me.btnfin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnfin.Location = New System.Drawing.Point(481, 18)
        Me.btnfin.Name = "btnfin"
        Me.btnfin.Size = New System.Drawing.Size(143, 40)
        Me.btnfin.TabIndex = 107
        Me.btnfin.Text = "Terminar proceso"
        Me.btnfin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnfin.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(511, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 18)
        Me.Label14.TabIndex = 105
        Me.Label14.Text = "Total"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtmerma
        '
        Me.txtmerma.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmerma.Location = New System.Drawing.Point(511, 168)
        Me.txtmerma.Name = "txtmerma"
        Me.txtmerma.Size = New System.Drawing.Size(113, 23)
        Me.txtmerma.TabIndex = 104
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(391, 18)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 18)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "Encargado"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(7, 18)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(385, 18)
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
        Me.grdFin.Location = New System.Drawing.Point(7, 61)
        Me.grdFin.Name = "grdFin"
        Me.grdFin.ReadOnly = True
        Me.grdFin.RowHeadersVisible = False
        Me.grdFin.Size = New System.Drawing.Size(617, 86)
        Me.grdFin.TabIndex = 106
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(504, 492)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 73)
        Me.btnguardar.TabIndex = 162
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnnuevo.Location = New System.Drawing.Point(570, 492)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 73)
        Me.btnnuevo.TabIndex = 161
        Me.btnnuevo.Text = "Limpiar"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnterminar
        '
        Me.btnterminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnterminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnterminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnterminar.Image = CType(resources.GetObject("btnterminar.Image"), System.Drawing.Image)
        Me.btnterminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnterminar.Location = New System.Drawing.Point(415, 492)
        Me.btnterminar.Name = "btnterminar"
        Me.btnterminar.Size = New System.Drawing.Size(83, 73)
        Me.btnterminar.TabIndex = 163
        Me.btnterminar.Text = "Finalizar produccción"
        Me.btnterminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnterminar.UseVisualStyleBackColor = True
        '
        'btnencargado
        '
        Me.btnencargado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnencargado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnencargado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnencargado.Image = CType(resources.GetObject("btnencargado.Image"), System.Drawing.Image)
        Me.btnencargado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnencargado.Location = New System.Drawing.Point(324, 492)
        Me.btnencargado.Name = "btnencargado"
        Me.btnencargado.Size = New System.Drawing.Size(85, 73)
        Me.btnencargado.TabIndex = 164
        Me.btnencargado.Text = "Cambiar encargado"
        Me.btnencargado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnencargado.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(6, 495)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(312, 40)
        Me.Label15.TabIndex = 165
        Me.Label15.Text = "Registra y lleva el control de cada proceso en la producción de un producto."
        '
        'frmProcesos_Prod
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(637, 567)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnencargado)
        Me.Controls.Add(Me.btnterminar)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxInicio)
        Me.Controls.Add(Me.boxFin)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcesos_Prod"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de procesos de producción"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.boxInicio.ResumeLayout(False)
        Me.boxInicio.PerformLayout()
        CType(Me.grdInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxFin.ResumeLayout(False)
        Me.boxFin.PerformLayout()
        CType(Me.grdFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtunidad As System.Windows.Forms.TextBox
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents boxInicio As System.Windows.Forms.GroupBox
    Friend WithEvents txtproceso As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRequiere As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCant1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtUnidad1 As System.Windows.Forms.TextBox
    Friend WithEvents cboDesc1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents grdInicio As System.Windows.Forms.DataGridView
    Friend WithEvents btninicio As System.Windows.Forms.Button
    Friend WithEvents cboEncargado As System.Windows.Forms.ComboBox
    Friend WithEvents boxFin As System.Windows.Forms.GroupBox
    Friend WithEvents txtencargado As System.Windows.Forms.TextBox
    Friend WithEvents cboproceso As System.Windows.Forms.ComboBox
    Friend WithEvents btnfin As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtmerma As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents grdFin As System.Windows.Forms.DataGridView
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnterminar As System.Windows.Forms.Button
    Friend WithEvents btnencargado As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents cbolote As System.Windows.Forms.ComboBox
    Friend WithEvents txtcod As System.Windows.Forms.TextBox
End Class
