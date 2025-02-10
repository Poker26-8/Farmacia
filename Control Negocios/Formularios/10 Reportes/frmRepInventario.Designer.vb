<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepInventario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepInventario))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tcOpt = New System.Windows.Forms.TabControl()
        Me.tpInv = New System.Windows.Forms.TabPage()
        Me.rbLotes = New System.Windows.Forms.RadioButton()
        Me.rbAjuste = New System.Windows.Forms.RadioButton()
        Me.optperdidas = New System.Windows.Forms.RadioButton()
        Me.optTodos = New System.Windows.Forms.RadioButton()
        Me.optGrupo = New System.Windows.Forms.RadioButton()
        Me.optDepartamento = New System.Windows.Forms.RadioButton()
        Me.optProveedor = New System.Windows.Forms.RadioButton()
        Me.tpCad = New System.Windows.Forms.TabPage()
        Me.optCaducidades = New System.Windows.Forms.RadioButton()
        Me.optCaducidad = New System.Windows.Forms.RadioButton()
        Me.optCaducos = New System.Windows.Forms.RadioButton()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.boxcaduca = New System.Windows.Forms.GroupBox()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCaduc = New System.Windows.Forms.Button()
        Me.dtpIni = New System.Windows.Forms.DateTimePicker()
        Me.cbofiltro = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtregistros = New System.Windows.Forms.TextBox()
        Me.txtVentaTot = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCompraTot = New System.Windows.Forms.TextBox()
        Me.barCarga = New System.Windows.Forms.ProgressBar()
        Me.lblexportar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.FinaCosteo = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.IniCosteo = New System.Windows.Forms.DateTimePicker()
        Me.grdestado = New System.Windows.Forms.DataGridView()
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnExistencia = New System.Windows.Forms.Button()
        Me.btnImpExis = New System.Windows.Forms.Button()
        Me.btnExpExis = New System.Windows.Forms.Button()
        Me.btnexcel = New System.Windows.Forms.Button()
        Me.btncardex = New System.Windows.Forms.Button()
        Me.btnetiquetas = New System.Windows.Forms.Button()
        Me.btncatalogo = New System.Windows.Forms.Button()
        Me.btnCaracteristicas = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNegativas = New System.Windows.Forms.RadioButton()
        Me.rbPositivas = New System.Windows.Forms.RadioButton()
        Me.rbListaLotes = New System.Windows.Forms.RadioButton()
        Me.tcOpt.SuspendLayout()
        Me.tpInv.SuspendLayout()
        Me.tpCad.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxcaduca.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdestado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(1004, 31)
        Me.Label1.TabIndex = 229
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tcOpt
        '
        Me.tcOpt.Controls.Add(Me.tpInv)
        Me.tcOpt.Controls.Add(Me.tpCad)
        Me.tcOpt.Location = New System.Drawing.Point(8, 38)
        Me.tcOpt.Name = "tcOpt"
        Me.tcOpt.SelectedIndex = 0
        Me.tcOpt.Size = New System.Drawing.Size(284, 159)
        Me.tcOpt.TabIndex = 230
        '
        'tpInv
        '
        Me.tpInv.Controls.Add(Me.rbListaLotes)
        Me.tpInv.Controls.Add(Me.rbLotes)
        Me.tpInv.Controls.Add(Me.rbAjuste)
        Me.tpInv.Controls.Add(Me.optperdidas)
        Me.tpInv.Controls.Add(Me.optTodos)
        Me.tpInv.Controls.Add(Me.optGrupo)
        Me.tpInv.Controls.Add(Me.optDepartamento)
        Me.tpInv.Controls.Add(Me.optProveedor)
        Me.tpInv.Location = New System.Drawing.Point(4, 24)
        Me.tpInv.Name = "tpInv"
        Me.tpInv.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInv.Size = New System.Drawing.Size(276, 131)
        Me.tpInv.TabIndex = 0
        Me.tpInv.Text = "      Inventario      "
        Me.tpInv.UseVisualStyleBackColor = True
        '
        'rbLotes
        '
        Me.rbLotes.AutoSize = True
        Me.rbLotes.Location = New System.Drawing.Point(125, 37)
        Me.rbLotes.Name = "rbLotes"
        Me.rbLotes.Size = New System.Drawing.Size(114, 19)
        Me.rbLotes.TabIndex = 59
        Me.rbLotes.TabStop = True
        Me.rbLotes.Text = "Faltantes de Lote"
        Me.rbLotes.UseVisualStyleBackColor = True
        '
        'rbAjuste
        '
        Me.rbAjuste.AutoSize = True
        Me.rbAjuste.Location = New System.Drawing.Point(125, 8)
        Me.rbAjuste.Name = "rbAjuste"
        Me.rbAjuste.Size = New System.Drawing.Size(145, 19)
        Me.rbAjuste.TabIndex = 58
        Me.rbAjuste.TabStop = True
        Me.rbAjuste.Text = "Preajuste de Inventario"
        Me.rbAjuste.UseVisualStyleBackColor = True
        '
        'optperdidas
        '
        Me.optperdidas.AutoSize = True
        Me.optperdidas.Location = New System.Drawing.Point(8, 104)
        Me.optperdidas.Name = "optperdidas"
        Me.optperdidas.Size = New System.Drawing.Size(142, 19)
        Me.optperdidas.TabIndex = 57
        Me.optperdidas.TabStop = True
        Me.optperdidas.Text = "Pérdidas de inventario"
        Me.optperdidas.UseVisualStyleBackColor = True
        '
        'optTodos
        '
        Me.optTodos.AutoSize = True
        Me.optTodos.Location = New System.Drawing.Point(8, 80)
        Me.optTodos.Name = "optTodos"
        Me.optTodos.Size = New System.Drawing.Size(149, 19)
        Me.optTodos.TabIndex = 56
        Me.optTodos.TabStop = True
        Me.optTodos.Text = "Ver todos los productos"
        Me.optTodos.UseVisualStyleBackColor = True
        '
        'optGrupo
        '
        Me.optGrupo.AutoSize = True
        Me.optGrupo.Location = New System.Drawing.Point(8, 56)
        Me.optGrupo.Name = "optGrupo"
        Me.optGrupo.Size = New System.Drawing.Size(58, 19)
        Me.optGrupo.TabIndex = 55
        Me.optGrupo.TabStop = True
        Me.optGrupo.Text = "Grupo"
        Me.optGrupo.UseVisualStyleBackColor = True
        '
        'optDepartamento
        '
        Me.optDepartamento.AutoSize = True
        Me.optDepartamento.Location = New System.Drawing.Point(8, 32)
        Me.optDepartamento.Name = "optDepartamento"
        Me.optDepartamento.Size = New System.Drawing.Size(101, 19)
        Me.optDepartamento.TabIndex = 54
        Me.optDepartamento.TabStop = True
        Me.optDepartamento.Text = "Departamento"
        Me.optDepartamento.UseVisualStyleBackColor = True
        '
        'optProveedor
        '
        Me.optProveedor.AutoSize = True
        Me.optProveedor.Location = New System.Drawing.Point(8, 8)
        Me.optProveedor.Name = "optProveedor"
        Me.optProveedor.Size = New System.Drawing.Size(90, 19)
        Me.optProveedor.TabIndex = 53
        Me.optProveedor.TabStop = True
        Me.optProveedor.Text = "Proveedores"
        Me.optProveedor.UseVisualStyleBackColor = True
        '
        'tpCad
        '
        Me.tpCad.Controls.Add(Me.optCaducidades)
        Me.tpCad.Controls.Add(Me.optCaducidad)
        Me.tpCad.Controls.Add(Me.optCaducos)
        Me.tpCad.Location = New System.Drawing.Point(4, 22)
        Me.tpCad.Name = "tpCad"
        Me.tpCad.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCad.Size = New System.Drawing.Size(276, 133)
        Me.tpCad.TabIndex = 1
        Me.tpCad.Text = "   Caducidades   "
        Me.tpCad.UseVisualStyleBackColor = True
        '
        'optCaducidades
        '
        Me.optCaducidades.AutoSize = True
        Me.optCaducidades.Location = New System.Drawing.Point(9, 69)
        Me.optCaducidades.Name = "optCaducidades"
        Me.optCaducidades.Size = New System.Drawing.Size(166, 19)
        Me.optCaducidades.TabIndex = 59
        Me.optCaducidades.TabStop = True
        Me.optCaducidades.Text = "Caducidades por producto"
        Me.optCaducidades.UseVisualStyleBackColor = True
        '
        'optCaducidad
        '
        Me.optCaducidad.AutoSize = True
        Me.optCaducidad.Location = New System.Drawing.Point(9, 45)
        Me.optCaducidad.Name = "optCaducidad"
        Me.optCaducidad.Size = New System.Drawing.Size(93, 19)
        Me.optCaducidad.TabIndex = 58
        Me.optCaducidad.TabStop = True
        Me.optCaducidad.Text = "Caducidades"
        Me.optCaducidad.UseVisualStyleBackColor = True
        '
        'optCaducos
        '
        Me.optCaducos.AutoSize = True
        Me.optCaducos.Location = New System.Drawing.Point(9, 21)
        Me.optCaducos.Name = "optCaducos"
        Me.optCaducos.Size = New System.Drawing.Size(139, 19)
        Me.optCaducos.TabIndex = 57
        Me.optCaducos.TabStop = True
        Me.optCaducos.Text = "Productos caducados"
        Me.optCaducos.UseVisualStyleBackColor = True
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Location = New System.Drawing.Point(8, 203)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(986, 311)
        Me.grdcaptura.TabIndex = 231
        '
        'boxcaduca
        '
        Me.boxcaduca.Controls.Add(Me.dtpFin)
        Me.boxcaduca.Controls.Add(Me.Label6)
        Me.boxcaduca.Controls.Add(Me.Label5)
        Me.boxcaduca.Controls.Add(Me.btnCaduc)
        Me.boxcaduca.Controls.Add(Me.dtpIni)
        Me.boxcaduca.Enabled = False
        Me.boxcaduca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boxcaduca.Location = New System.Drawing.Point(294, 38)
        Me.boxcaduca.Margin = New System.Windows.Forms.Padding(2)
        Me.boxcaduca.Name = "boxcaduca"
        Me.boxcaduca.Padding = New System.Windows.Forms.Padding(2)
        Me.boxcaduca.Size = New System.Drawing.Size(247, 80)
        Me.boxcaduca.TabIndex = 236
        Me.boxcaduca.TabStop = False
        '
        'dtpFin
        '
        Me.dtpFin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFin.Location = New System.Drawing.Point(55, 46)
        Me.dtpFin.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.Size = New System.Drawing.Size(110, 23)
        Me.dtpFin.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 50)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Final"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Inicial"
        '
        'btnCaduc
        '
        Me.btnCaduc.BackColor = System.Drawing.Color.MintCream
        Me.btnCaduc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCaduc.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaduc.ForeColor = System.Drawing.Color.Black
        Me.btnCaduc.Location = New System.Drawing.Point(172, 18)
        Me.btnCaduc.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCaduc.Name = "btnCaduc"
        Me.btnCaduc.Size = New System.Drawing.Size(62, 51)
        Me.btnCaduc.TabIndex = 8
        Me.btnCaduc.Text = "Reporte"
        Me.btnCaduc.UseVisualStyleBackColor = False
        '
        'dtpIni
        '
        Me.dtpIni.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIni.Location = New System.Drawing.Point(55, 18)
        Me.dtpIni.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpIni.Name = "dtpIni"
        Me.dtpIni.Size = New System.Drawing.Size(110, 23)
        Me.dtpIni.TabIndex = 0
        '
        'cbofiltro
        '
        Me.cbofiltro.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofiltro.FormattingEnabled = True
        Me.cbofiltro.Location = New System.Drawing.Point(294, 123)
        Me.cbofiltro.Name = "cbofiltro"
        Me.cbofiltro.Size = New System.Drawing.Size(247, 25)
        Me.cbofiltro.TabIndex = 237
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(666, 541)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 19)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Total de registros"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtregistros
        '
        Me.txtregistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtregistros.BackColor = System.Drawing.Color.White
        Me.txtregistros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtregistros.Location = New System.Drawing.Point(666, 562)
        Me.txtregistros.Margin = New System.Windows.Forms.Padding(2)
        Me.txtregistros.Name = "txtregistros"
        Me.txtregistros.ReadOnly = True
        Me.txtregistros.Size = New System.Drawing.Size(97, 23)
        Me.txtregistros.TabIndex = 245
        Me.txtregistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVentaTot
        '
        Me.txtVentaTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVentaTot.BackColor = System.Drawing.Color.White
        Me.txtVentaTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaTot.Location = New System.Drawing.Point(883, 562)
        Me.txtVentaTot.Margin = New System.Windows.Forms.Padding(2)
        Me.txtVentaTot.Name = "txtVentaTot"
        Me.txtVentaTot.ReadOnly = True
        Me.txtVentaTot.Size = New System.Drawing.Size(112, 23)
        Me.txtVentaTot.TabIndex = 242
        Me.txtVentaTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(883, 541)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 19)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "V. Venta total:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(767, 541)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 19)
        Me.Label2.TabIndex = 243
        Me.Label2.Text = "V. Compra total:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCompraTot
        '
        Me.txtCompraTot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCompraTot.BackColor = System.Drawing.Color.White
        Me.txtCompraTot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompraTot.Location = New System.Drawing.Point(767, 562)
        Me.txtCompraTot.Margin = New System.Windows.Forms.Padding(2)
        Me.txtCompraTot.Name = "txtCompraTot"
        Me.txtCompraTot.ReadOnly = True
        Me.txtCompraTot.Size = New System.Drawing.Size(112, 23)
        Me.txtCompraTot.TabIndex = 241
        Me.txtCompraTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'barCarga
        '
        Me.barCarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barCarga.Location = New System.Drawing.Point(27, 338)
        Me.barCarga.Name = "barCarga"
        Me.barCarga.Size = New System.Drawing.Size(949, 18)
        Me.barCarga.TabIndex = 247
        Me.barCarga.Visible = False
        '
        'lblexportar
        '
        Me.lblexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblexportar.BackColor = System.Drawing.Color.Transparent
        Me.lblexportar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexportar.Location = New System.Drawing.Point(10, 493)
        Me.lblexportar.Name = "lblexportar"
        Me.lblexportar.Size = New System.Drawing.Size(516, 19)
        Me.lblexportar.TabIndex = 248
        Me.lblexportar.Text = "Productos"
        Me.lblexportar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnreporte)
        Me.GroupBox1.Controls.Add(Me.FinaCosteo)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.IniCosteo)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(650, 38)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(258, 80)
        Me.GroupBox1.TabIndex = 237
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado de resultados"
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
        'grdestado
        '
        Me.grdestado.AllowUserToAddRows = False
        Me.grdestado.AllowUserToDeleteRows = False
        Me.grdestado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdestado.BackgroundColor = System.Drawing.Color.White
        Me.grdestado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdestado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
        Me.grdestado.Location = New System.Drawing.Point(41, 227)
        Me.grdestado.Name = "grdestado"
        Me.grdestado.ReadOnly = True
        Me.grdestado.RowHeadersVisible = False
        Me.grdestado.Size = New System.Drawing.Size(922, 253)
        Me.grdestado.TabIndex = 249
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nombre"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Inv. Inicial"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cant. Compra"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Cant. Devuelta"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Inv. Final"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Cant. Vendida"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Precio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
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
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(546, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(23, 15)
        Me.DataGridView1.TabIndex = 253
        Me.DataGridView1.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(144, 522)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 63)
        Me.Button2.TabIndex = 255
        Me.Button2.Text = "Mínimos y máximos"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnExistencia
        '
        Me.btnExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExistencia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExistencia.Image = CType(resources.GetObject("btnExistencia.Image"), System.Drawing.Image)
        Me.btnExistencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExistencia.Location = New System.Drawing.Point(833, 124)
        Me.btnExistencia.Name = "btnExistencia"
        Me.btnExistencia.Size = New System.Drawing.Size(75, 61)
        Me.btnExistencia.TabIndex = 252
        Me.btnExistencia.Text = "Existencias"
        Me.btnExistencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExistencia.UseVisualStyleBackColor = True
        '
        'btnImpExis
        '
        Me.btnImpExis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImpExis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImpExis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpExis.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImpExis.Image = CType(resources.GetObject("btnImpExis.Image"), System.Drawing.Image)
        Me.btnImpExis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImpExis.Location = New System.Drawing.Point(348, 520)
        Me.btnImpExis.Name = "btnImpExis"
        Me.btnImpExis.Size = New System.Drawing.Size(95, 65)
        Me.btnImpExis.TabIndex = 251
        Me.btnImpExis.Text = "Importar Existencias"
        Me.btnImpExis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImpExis.UseVisualStyleBackColor = True
        '
        'btnExpExis
        '
        Me.btnExpExis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExpExis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExpExis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpExis.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpExis.Image = CType(resources.GetObject("btnExpExis.Image"), System.Drawing.Image)
        Me.btnExpExis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpExis.Location = New System.Drawing.Point(251, 520)
        Me.btnExpExis.Name = "btnExpExis"
        Me.btnExpExis.Size = New System.Drawing.Size(91, 65)
        Me.btnExpExis.TabIndex = 250
        Me.btnExpExis.Text = "Exportar Existencias"
        Me.btnExpExis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExpExis.UseVisualStyleBackColor = True
        '
        'btnexcel
        '
        Me.btnexcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnexcel.BackgroundImage = CType(resources.GetObject("btnexcel.BackgroundImage"), System.Drawing.Image)
        Me.btnexcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexcel.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexcel.Location = New System.Drawing.Point(12, 522)
        Me.btnexcel.Name = "btnexcel"
        Me.btnexcel.Size = New System.Drawing.Size(60, 63)
        Me.btnexcel.TabIndex = 240
        Me.btnexcel.Text = "Exportar"
        Me.btnexcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexcel.UseVisualStyleBackColor = True
        '
        'btncardex
        '
        Me.btncardex.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncardex.BackgroundImage = CType(resources.GetObject("btncardex.BackgroundImage"), System.Drawing.Image)
        Me.btncardex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncardex.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncardex.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncardex.Location = New System.Drawing.Point(78, 522)
        Me.btncardex.Name = "btncardex"
        Me.btncardex.Size = New System.Drawing.Size(60, 63)
        Me.btncardex.TabIndex = 239
        Me.btncardex.Text = "Cárdex"
        Me.btncardex.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncardex.UseVisualStyleBackColor = True
        '
        'btnetiquetas
        '
        Me.btnetiquetas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnetiquetas.BackgroundImage = CType(resources.GetObject("btnetiquetas.BackgroundImage"), System.Drawing.Image)
        Me.btnetiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnetiquetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnetiquetas.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnetiquetas.Location = New System.Drawing.Point(912, 124)
        Me.btnetiquetas.Name = "btnetiquetas"
        Me.btnetiquetas.Size = New System.Drawing.Size(82, 63)
        Me.btnetiquetas.TabIndex = 233
        Me.btnetiquetas.Text = "Etiquetas"
        Me.btnetiquetas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnetiquetas.UseVisualStyleBackColor = True
        '
        'btncatalogo
        '
        Me.btncatalogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btncatalogo.BackgroundImage = CType(resources.GetObject("btncatalogo.BackgroundImage"), System.Drawing.Image)
        Me.btncatalogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncatalogo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncatalogo.Location = New System.Drawing.Point(913, 52)
        Me.btncatalogo.Name = "btncatalogo"
        Me.btncatalogo.Size = New System.Drawing.Size(82, 63)
        Me.btncatalogo.TabIndex = 232
        Me.btncatalogo.Text = "Exportar catálogo"
        Me.btncatalogo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncatalogo.UseVisualStyleBackColor = True
        '
        'btnCaracteristicas
        '
        Me.btnCaracteristicas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCaracteristicas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCaracteristicas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCaracteristicas.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCaracteristicas.Image = CType(resources.GetObject("btnCaracteristicas.Image"), System.Drawing.Image)
        Me.btnCaracteristicas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCaracteristicas.Location = New System.Drawing.Point(449, 520)
        Me.btnCaracteristicas.Name = "btnCaracteristicas"
        Me.btnCaracteristicas.Size = New System.Drawing.Size(95, 65)
        Me.btnCaracteristicas.TabIndex = 256
        Me.btnCaracteristicas.Text = "Importar Caracteristicas"
        Me.btnCaracteristicas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCaracteristicas.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNegativas)
        Me.GroupBox2.Controls.Add(Me.rbPositivas)
        Me.GroupBox2.Location = New System.Drawing.Point(294, 152)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(275, 45)
        Me.GroupBox2.TabIndex = 257
        Me.GroupBox2.TabStop = False
        '
        'rbNegativas
        '
        Me.rbNegativas.AutoSize = True
        Me.rbNegativas.Location = New System.Drawing.Point(138, 18)
        Me.rbNegativas.Name = "rbNegativas"
        Me.rbNegativas.Size = New System.Drawing.Size(130, 19)
        Me.rbNegativas.TabIndex = 55
        Me.rbNegativas.TabStop = True
        Me.rbNegativas.Text = "Existencia negativas"
        Me.rbNegativas.UseVisualStyleBackColor = True
        '
        'rbPositivas
        '
        Me.rbPositivas.AutoSize = True
        Me.rbPositivas.Location = New System.Drawing.Point(6, 18)
        Me.rbPositivas.Name = "rbPositivas"
        Me.rbPositivas.Size = New System.Drawing.Size(126, 19)
        Me.rbPositivas.TabIndex = 54
        Me.rbPositivas.TabStop = True
        Me.rbPositivas.Text = "Existencia positivas"
        Me.rbPositivas.UseVisualStyleBackColor = True
        '
        'rbListaLotes
        '
        Me.rbListaLotes.AutoSize = True
        Me.rbListaLotes.Location = New System.Drawing.Point(125, 67)
        Me.rbListaLotes.Name = "rbListaLotes"
        Me.rbListaLotes.Size = New System.Drawing.Size(108, 19)
        Me.rbListaLotes.TabIndex = 60
        Me.rbListaLotes.TabStop = True
        Me.rbListaLotes.Text = "Reporte de Lote"
        Me.rbListaLotes.UseVisualStyleBackColor = True
        '
        'frmRepInventario
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1004, 595)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnCaracteristicas)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnExistencia)
        Me.Controls.Add(Me.btnImpExis)
        Me.Controls.Add(Me.btnExpExis)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblexportar)
        Me.Controls.Add(Me.barCarga)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtregistros)
        Me.Controls.Add(Me.txtVentaTot)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCompraTot)
        Me.Controls.Add(Me.btnexcel)
        Me.Controls.Add(Me.btncardex)
        Me.Controls.Add(Me.cbofiltro)
        Me.Controls.Add(Me.boxcaduca)
        Me.Controls.Add(Me.btnetiquetas)
        Me.Controls.Add(Me.btncatalogo)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.tcOpt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdestado)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(981, 624)
        Me.Name = "frmRepInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de inventario"
        Me.tcOpt.ResumeLayout(False)
        Me.tpInv.ResumeLayout(False)
        Me.tpInv.PerformLayout()
        Me.tpCad.ResumeLayout(False)
        Me.tpCad.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxcaduca.ResumeLayout(False)
        Me.boxcaduca.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdestado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tcOpt As System.Windows.Forms.TabControl
    Friend WithEvents tpInv As System.Windows.Forms.TabPage
    Friend WithEvents tpCad As System.Windows.Forms.TabPage
    Friend WithEvents optTodos As System.Windows.Forms.RadioButton
    Friend WithEvents optGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optDepartamento As System.Windows.Forms.RadioButton
    Friend WithEvents optProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents optCaducidades As System.Windows.Forms.RadioButton
    Friend WithEvents optCaducidad As System.Windows.Forms.RadioButton
    Friend WithEvents optCaducos As System.Windows.Forms.RadioButton
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btnetiquetas As System.Windows.Forms.Button
    Friend WithEvents btncatalogo As System.Windows.Forms.Button
    Friend WithEvents boxcaduca As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCaduc As System.Windows.Forms.Button
    Friend WithEvents dtpIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbofiltro As System.Windows.Forms.ComboBox
    Friend WithEvents btnexcel As System.Windows.Forms.Button
    Friend WithEvents btncardex As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtregistros As System.Windows.Forms.TextBox
    Friend WithEvents txtVentaTot As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCompraTot As System.Windows.Forms.TextBox
    Friend WithEvents barCarga As System.Windows.Forms.ProgressBar
    Friend WithEvents lblexportar As System.Windows.Forms.Label
    Friend WithEvents optperdidas As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FinaCosteo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents IniCosteo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnreporte As System.Windows.Forms.Button
    Friend WithEvents grdestado As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnExpExis As Button
    Friend WithEvents btnImpExis As Button
    Friend WithEvents btnExistencia As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents rbAjuste As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents btnCaracteristicas As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbNegativas As RadioButton
    Friend WithEvents rbPositivas As RadioButton
    Friend WithEvents rbLotes As RadioButton
    Friend WithEvents rbListaLotes As RadioButton
End Class
