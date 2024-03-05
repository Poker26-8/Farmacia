<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCopeo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCopeo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbGrupo = New System.Windows.Forms.RadioButton()
        Me.rbDepartamento = New System.Windows.Forms.RadioButton()
        Me.rbProveedor = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.FinaCosteo = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IniCosteo = New System.Windows.Forms.DateTimePicker()
        Me.cbofiltro = New System.Windows.Forms.ComboBox()
        Me.btnetiquetas = New System.Windows.Forms.Button()
        Me.btnsalida = New System.Windows.Forms.Button()
        Me.btnentrada = New System.Windows.Forms.Button()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtregistros = New System.Windows.Forms.TextBox()
        Me.txtVentaTot = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCompraTot = New System.Windows.Forms.TextBox()
        Me.btncardex = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblexportar = New System.Windows.Forms.Label()
        Me.barCarga = New System.Windows.Forms.ProgressBar()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdestado = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdestado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbGrupo)
        Me.GroupBox1.Controls.Add(Me.rbDepartamento)
        Me.GroupBox1.Controls.Add(Me.rbProveedor)
        Me.GroupBox1.Controls.Add(Me.rbTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 129)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbGrupo
        '
        Me.rbGrupo.AutoSize = True
        Me.rbGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGrupo.Location = New System.Drawing.Point(6, 70)
        Me.rbGrupo.Name = "rbGrupo"
        Me.rbGrupo.Size = New System.Drawing.Size(62, 20)
        Me.rbGrupo.TabIndex = 57
        Me.rbGrupo.TabStop = True
        Me.rbGrupo.Text = "Grupo"
        Me.rbGrupo.UseVisualStyleBackColor = True
        '
        'rbDepartamento
        '
        Me.rbDepartamento.AutoSize = True
        Me.rbDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDepartamento.Location = New System.Drawing.Point(6, 44)
        Me.rbDepartamento.Name = "rbDepartamento"
        Me.rbDepartamento.Size = New System.Drawing.Size(111, 20)
        Me.rbDepartamento.TabIndex = 56
        Me.rbDepartamento.TabStop = True
        Me.rbDepartamento.Text = "Departamento"
        Me.rbDepartamento.UseVisualStyleBackColor = True
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProveedor.Location = New System.Drawing.Point(6, 19)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(104, 20)
        Me.rbProveedor.TabIndex = 54
        Me.rbProveedor.TabStop = True
        Me.rbProveedor.Text = "Proveedores"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(6, 96)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(167, 20)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Ver todos los productos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.cbofiltro)
        Me.Panel1.Controls.Add(Me.btnetiquetas)
        Me.Panel1.Controls.Add(Me.btnsalida)
        Me.Panel1.Controls.Add(Me.btnentrada)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnexcel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1103, 153)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnreporte)
        Me.GroupBox2.Controls.Add(Me.FinaCosteo)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.IniCosteo)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(201, 13)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(258, 80)
        Me.GroupBox2.TabIndex = 242
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estado de resultados"
        Me.GroupBox2.Visible = False
        '
        'btnreporte
        '
        Me.btnreporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnreporte.BackgroundImage = CType(resources.GetObject("btnreporte.BackgroundImage"), System.Drawing.Image)
        Me.btnreporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreporte.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporte.Location = New System.Drawing.Point(166, 19)
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(82, 51)
        Me.btnreporte.TabIndex = 234
        Me.btnreporte.Text = "Reporte"
        Me.btnreporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreporte.UseVisualStyleBackColor = True
        '
        'FinaCosteo
        '
        Me.FinaCosteo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FinaCosteo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FinaCosteo.Location = New System.Drawing.Point(51, 47)
        Me.FinaCosteo.Margin = New System.Windows.Forms.Padding(2)
        Me.FinaCosteo.Name = "FinaCosteo"
        Me.FinaCosteo.Size = New System.Drawing.Size(110, 23)
        Me.FinaCosteo.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 51)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Final"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 23)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Inicial"
        '
        'IniCosteo
        '
        Me.IniCosteo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IniCosteo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.IniCosteo.Location = New System.Drawing.Point(51, 19)
        Me.IniCosteo.Margin = New System.Windows.Forms.Padding(2)
        Me.IniCosteo.Name = "IniCosteo"
        Me.IniCosteo.Size = New System.Drawing.Size(110, 23)
        Me.IniCosteo.TabIndex = 0
        '
        'cbofiltro
        '
        Me.cbofiltro.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofiltro.FormattingEnabled = True
        Me.cbofiltro.Location = New System.Drawing.Point(201, 107)
        Me.cbofiltro.Name = "cbofiltro"
        Me.cbofiltro.Size = New System.Drawing.Size(258, 25)
        Me.cbofiltro.TabIndex = 240
        '
        'btnetiquetas
        '
        Me.btnetiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnetiquetas.BackgroundImage = CType(resources.GetObject("btnetiquetas.BackgroundImage"), System.Drawing.Image)
        Me.btnetiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnetiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnetiquetas.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnetiquetas.Location = New System.Drawing.Point(924, 79)
        Me.btnetiquetas.Name = "btnetiquetas"
        Me.btnetiquetas.Size = New System.Drawing.Size(82, 63)
        Me.btnetiquetas.TabIndex = 238
        Me.btnetiquetas.Text = "Etiquetas"
        Me.btnetiquetas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnetiquetas.UseVisualStyleBackColor = True
        '
        'btnsalida
        '
        Me.btnsalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsalida.BackgroundImage = CType(resources.GetObject("btnsalida.BackgroundImage"), System.Drawing.Image)
        Me.btnsalida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnsalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsalida.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalida.Location = New System.Drawing.Point(1012, 79)
        Me.btnsalida.Name = "btnsalida"
        Me.btnsalida.Size = New System.Drawing.Size(82, 63)
        Me.btnsalida.TabIndex = 237
        Me.btnsalida.Text = "Traspaso Salida"
        Me.btnsalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsalida.UseVisualStyleBackColor = True
        '
        'btnentrada
        '
        Me.btnentrada.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnentrada.BackgroundImage = CType(resources.GetObject("btnentrada.BackgroundImage"), System.Drawing.Image)
        Me.btnentrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnentrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnentrada.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnentrada.Location = New System.Drawing.Point(1012, 6)
        Me.btnentrada.Name = "btnentrada"
        Me.btnentrada.Size = New System.Drawing.Size(82, 63)
        Me.btnentrada.TabIndex = 236
        Me.btnentrada.Text = "Traspaso Entrada"
        Me.btnentrada.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnentrada.UseVisualStyleBackColor = True
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexcel.BackgroundImage = CType(resources.GetObject("btnexcel.BackgroundImage"), System.Drawing.Image)
        Me.btnexcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexcel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexcel.Location = New System.Drawing.Point(924, 6)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(82, 61)
        Me.btnexcel.TabIndex = 241
        Me.btnexcel.Text = "Exportar"
        Me.btnexcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexcel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtregistros)
        Me.Panel2.Controls.Add(Me.txtVentaTot)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtCompraTot)
        Me.Panel2.Controls.Add(Me.btncardex)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1103, 82)
        Me.Panel2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(767, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 250
        Me.Label4.Text = "Total de registros"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtregistros
        '
        Me.txtregistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtregistros.BackColor = System.Drawing.Color.White
        Me.txtregistros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtregistros.Location = New System.Drawing.Point(767, 39)
        Me.txtregistros.Margin = New System.Windows.Forms.Padding(2)
        Me.txtregistros.Name = "txtregistros"
        Me.txtregistros.ReadOnly = True
        Me.txtregistros.Size = New System.Drawing.Size(97, 23)
        Me.txtregistros.TabIndex = 249
        Me.txtregistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVentaTot
        '
        Me.txtVentaTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVentaTot.BackColor = System.Drawing.Color.White
        Me.txtVentaTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaTot.Location = New System.Drawing.Point(984, 39)
        Me.txtVentaTot.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVentaTot.Name = "txtVentaTot"
        Me.txtVentaTot.ReadOnly = True
        Me.txtVentaTot.Size = New System.Drawing.Size(112, 23)
        Me.txtVentaTot.TabIndex = 246
        Me.txtVentaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(984, 18)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 19)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "V. Venta total:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(868, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 19)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "V. Compra total:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCompraTot
        '
        Me.txtCompraTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompraTot.BackColor = System.Drawing.Color.White
        Me.txtCompraTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompraTot.Location = New System.Drawing.Point(868, 39)
        Me.txtCompraTot.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompraTot.Name = "txtCompraTot"
        Me.txtCompraTot.ReadOnly = True
        Me.txtCompraTot.Size = New System.Drawing.Size(112, 23)
        Me.txtCompraTot.TabIndex = 245
        Me.txtCompraTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btncardex
        '
        Me.btncardex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncardex.BackgroundImage = CType(resources.GetObject("btncardex.BackgroundImage"), System.Drawing.Image)
        Me.btncardex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncardex.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncardex.Location = New System.Drawing.Point(7, 7)
        Me.btncardex.Name = "btncardex"
        Me.btncardex.Size = New System.Drawing.Size(60, 63)
        Me.btncardex.TabIndex = 242
        Me.btncardex.Text = "Cárdex"
        Me.btncardex.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncardex.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblexportar)
        Me.Panel3.Controls.Add(Me.barCarga)
        Me.Panel3.Controls.Add(Me.grdCaptura)
        Me.Panel3.Controls.Add(Me.grdestado)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 184)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1103, 365)
        Me.Panel3.TabIndex = 3
        '
        'lblexportar
        '
        Me.lblexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblexportar.BackColor = System.Drawing.Color.Transparent
        Me.lblexportar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexportar.Location = New System.Drawing.Point(3, 343)
        Me.lblexportar.Name = "lblexportar"
        Me.lblexportar.Size = New System.Drawing.Size(516, 19)
        Me.lblexportar.TabIndex = 249
        Me.lblexportar.Text = "Productos"
        Me.lblexportar.Visible = False
        '
        'barCarga
        '
        Me.barCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barCarga.Location = New System.Drawing.Point(12, 175)
        Me.barCarga.Name = "barCarga"
        Me.barCarga.Size = New System.Drawing.Size(1079, 18)
        Me.barCarga.TabIndex = 248
        Me.barCarga.Visible = False
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column8, Me.Column5, Me.Column6, Me.Column7})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(1103, 365)
        Me.grdCaptura.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 84
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Existencia"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Precio de compra"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Precio de venta"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 120
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Valor de compra"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 137
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Valor de venta"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 124
        '
        'grdestado
        '
        Me.grdestado.AllowUserToAddRows = False
        Me.grdestado.AllowUserToDeleteRows = False
        Me.grdestado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdestado.BackgroundColor = System.Drawing.Color.White
        Me.grdestado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdestado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.Column9, Me.Column10})
        Me.grdestado.Location = New System.Drawing.Point(106, 56)
        Me.grdestado.Name = "grdestado"
        Me.grdestado.ReadOnly = True
        Me.grdestado.RowHeadersVisible = False
        Me.grdestado.Size = New System.Drawing.Size(891, 253)
        Me.grdestado.TabIndex = 250
        Me.grdestado.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Inv. Inicial"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cant. Compra"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cant. Devuelta"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Inv. Final"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cant. Vendida"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Precio"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Valor de Venta total"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Valor de Compra total"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(1103, 31)
        Me.Label1.TabIndex = 240
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmRepCopeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1103, 631)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepCopeo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Copeo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdestado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnexcel As Button
    Friend WithEvents btncardex As Button
    Friend WithEvents barCarga As ProgressBar
    Friend WithEvents lblexportar As Label
    Friend WithEvents btnsalida As Button
    Friend WithEvents btnentrada As Button
    Friend WithEvents btnetiquetas As Button
    Friend WithEvents txtVentaTot As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCompraTot As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtregistros As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbofiltro As ComboBox
    Friend WithEvents rbProveedor As RadioButton
    Friend WithEvents rbGrupo As RadioButton
    Friend WithEvents rbDepartamento As RadioButton
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnreporte As Button
    Friend WithEvents FinaCosteo As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents IniCosteo As DateTimePicker
    Friend WithEvents grdestado As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
End Class
