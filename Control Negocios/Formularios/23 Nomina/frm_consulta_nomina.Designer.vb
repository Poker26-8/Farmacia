<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_consulta_nomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_consulta_nomina))
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.grid_otrospagos = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.t_opagos = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tpagado = New System.Windows.Forms.TextBox()
        Me.t_deducciones = New System.Windows.Forms.TextBox()
        Me.t_percepcion = New System.Windows.Forms.TextBox()
        Me.t_exento = New System.Windows.Forms.TextBox()
        Me.t_gravado = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.grid_deducciones = New System.Windows.Forms.DataGridView()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.grid_percepciones = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbl_restantes = New System.Windows.Forms.Label()
        Me.lbl_consumidos = New System.Windows.Forms.Label()
        Me.lbl_contratados = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.btn_consulta = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grid_nominas = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_fechas = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dt_al = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dt_del = New System.Windows.Forms.DateTimePicker()
        Me.chk_empleados = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbo_empleado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbo_empresa = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox7.SuspendLayout()
        CType(Me.grid_otrospagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.grid_deducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.grid_percepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grid_nominas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.grid_otrospagos)
        Me.GroupBox7.Location = New System.Drawing.Point(654, 508)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(490, 120)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Otros Pagos"
        '
        'grid_otrospagos
        '
        Me.grid_otrospagos.AllowUserToAddRows = False
        Me.grid_otrospagos.AllowUserToDeleteRows = False
        Me.grid_otrospagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_otrospagos.BackgroundColor = System.Drawing.Color.White
        Me.grid_otrospagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_otrospagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.grid_otrospagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_otrospagos.Location = New System.Drawing.Point(3, 16)
        Me.grid_otrospagos.Name = "grid_otrospagos"
        Me.grid_otrospagos.ReadOnly = True
        Me.grid_otrospagos.RowHeadersVisible = False
        Me.grid_otrospagos.Size = New System.Drawing.Size(484, 101)
        Me.grid_otrospagos.TabIndex = 3
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Clave"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 59
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 78
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 56
        '
        'gb1
        '
        Me.gb1.Controls.Add(Me.t_opagos)
        Me.gb1.Controls.Add(Me.Label13)
        Me.gb1.Controls.Add(Me.tpagado)
        Me.gb1.Controls.Add(Me.t_deducciones)
        Me.gb1.Controls.Add(Me.t_percepcion)
        Me.gb1.Controls.Add(Me.t_exento)
        Me.gb1.Controls.Add(Me.t_gravado)
        Me.gb1.Controls.Add(Me.Label12)
        Me.gb1.Controls.Add(Me.Label11)
        Me.gb1.Controls.Add(Me.Label10)
        Me.gb1.Controls.Add(Me.Label9)
        Me.gb1.Controls.Add(Me.Label8)
        Me.gb1.Location = New System.Drawing.Point(763, 208)
        Me.gb1.Name = "gb1"
        Me.gb1.Size = New System.Drawing.Size(379, 187)
        Me.gb1.TabIndex = 13
        Me.gb1.TabStop = False
        Me.gb1.Text = "Resumen"
        '
        't_opagos
        '
        Me.t_opagos.Location = New System.Drawing.Point(155, 97)
        Me.t_opagos.Name = "t_opagos"
        Me.t_opagos.Size = New System.Drawing.Size(166, 20)
        Me.t_opagos.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 101)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 16)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Total Otros Pagos"
        '
        'tpagado
        '
        Me.tpagado.Location = New System.Drawing.Point(155, 149)
        Me.tpagado.Name = "tpagado"
        Me.tpagado.Size = New System.Drawing.Size(166, 20)
        Me.tpagado.TabIndex = 9
        '
        't_deducciones
        '
        Me.t_deducciones.Location = New System.Drawing.Point(155, 123)
        Me.t_deducciones.Name = "t_deducciones"
        Me.t_deducciones.Size = New System.Drawing.Size(166, 20)
        Me.t_deducciones.TabIndex = 8
        '
        't_percepcion
        '
        Me.t_percepcion.Location = New System.Drawing.Point(155, 71)
        Me.t_percepcion.Name = "t_percepcion"
        Me.t_percepcion.Size = New System.Drawing.Size(166, 20)
        Me.t_percepcion.TabIndex = 7
        '
        't_exento
        '
        Me.t_exento.Location = New System.Drawing.Point(155, 45)
        Me.t_exento.Name = "t_exento"
        Me.t_exento.Size = New System.Drawing.Size(166, 20)
        Me.t_exento.TabIndex = 6
        '
        't_gravado
        '
        Me.t_gravado.Location = New System.Drawing.Point(155, 19)
        Me.t_gravado.Name = "t_gravado"
        Me.t_gravado.Size = New System.Drawing.Size(166, 20)
        Me.t_gravado.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 155)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Total Pagado"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(138, 16)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Total Deducciones"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 74)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Total Percepciones"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 16)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Percepciones Exento"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 16)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Percepciones Grabado"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.grid_deducciones)
        Me.GroupBox6.Location = New System.Drawing.Point(653, 385)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(490, 120)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Deducciones"
        '
        'grid_deducciones
        '
        Me.grid_deducciones.AllowUserToAddRows = False
        Me.grid_deducciones.AllowUserToDeleteRows = False
        Me.grid_deducciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_deducciones.BackgroundColor = System.Drawing.Color.White
        Me.grid_deducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_deducciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column19, Me.Column20, Me.Column21})
        Me.grid_deducciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_deducciones.Location = New System.Drawing.Point(3, 16)
        Me.grid_deducciones.Name = "grid_deducciones"
        Me.grid_deducciones.ReadOnly = True
        Me.grid_deducciones.RowHeadersVisible = False
        Me.grid_deducciones.Size = New System.Drawing.Size(484, 101)
        Me.grid_deducciones.TabIndex = 3
        '
        'Column19
        '
        Me.Column19.HeaderText = "Clave"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        Me.Column19.Width = 59
        '
        'Column20
        '
        Me.Column20.HeaderText = "Concepto"
        Me.Column20.Name = "Column20"
        Me.Column20.ReadOnly = True
        Me.Column20.Width = 78
        '
        'Column21
        '
        Me.Column21.HeaderText = "Total"
        Me.Column21.Name = "Column21"
        Me.Column21.ReadOnly = True
        Me.Column21.Width = 56
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.grid_percepciones)
        Me.GroupBox5.Location = New System.Drawing.Point(21, 385)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(630, 243)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Percepciones"
        '
        'grid_percepciones
        '
        Me.grid_percepciones.AllowUserToAddRows = False
        Me.grid_percepciones.AllowUserToDeleteRows = False
        Me.grid_percepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_percepciones.BackgroundColor = System.Drawing.Color.White
        Me.grid_percepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_percepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18})
        Me.grid_percepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_percepciones.Location = New System.Drawing.Point(3, 16)
        Me.grid_percepciones.Name = "grid_percepciones"
        Me.grid_percepciones.ReadOnly = True
        Me.grid_percepciones.RowHeadersVisible = False
        Me.grid_percepciones.Size = New System.Drawing.Size(624, 224)
        Me.grid_percepciones.TabIndex = 3
        '
        'Column14
        '
        Me.Column14.HeaderText = "Clave"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 59
        '
        'Column15
        '
        Me.Column15.HeaderText = "Concepto"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 78
        '
        'Column16
        '
        Me.Column16.HeaderText = "Exento"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 65
        '
        'Column17
        '
        Me.Column17.HeaderText = "Gravado"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 73
        '
        'Column18
        '
        Me.Column18.HeaderText = "Total"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 56
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_restantes)
        Me.GroupBox4.Controls.Add(Me.lbl_consumidos)
        Me.GroupBox4.Controls.Add(Me.lbl_contratados)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.btnSalir)
        Me.GroupBox4.Controls.Add(Me.btnCancela)
        Me.GroupBox4.Controls.Add(Me.btn_consulta)
        Me.GroupBox4.Location = New System.Drawing.Point(851, 52)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(303, 150)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Comandos"
        '
        'lbl_restantes
        '
        Me.lbl_restantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_restantes.ForeColor = System.Drawing.Color.Blue
        Me.lbl_restantes.Location = New System.Drawing.Point(143, 124)
        Me.lbl_restantes.Name = "lbl_restantes"
        Me.lbl_restantes.Size = New System.Drawing.Size(150, 23)
        Me.lbl_restantes.TabIndex = 8
        Me.lbl_restantes.Text = "0"
        Me.lbl_restantes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_consumidos
        '
        Me.lbl_consumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_consumidos.ForeColor = System.Drawing.Color.Blue
        Me.lbl_consumidos.Location = New System.Drawing.Point(143, 82)
        Me.lbl_consumidos.Name = "lbl_consumidos"
        Me.lbl_consumidos.Size = New System.Drawing.Size(150, 23)
        Me.lbl_consumidos.TabIndex = 7
        Me.lbl_consumidos.Text = "0"
        Me.lbl_consumidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_contratados
        '
        Me.lbl_contratados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contratados.ForeColor = System.Drawing.Color.Blue
        Me.lbl_contratados.Location = New System.Drawing.Point(143, 34)
        Me.lbl_contratados.Name = "lbl_contratados"
        Me.lbl_contratados.Size = New System.Drawing.Size(150, 23)
        Me.lbl_contratados.TabIndex = 6
        Me.lbl_contratados.Text = "0"
        Me.lbl_contratados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(145, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 16)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Timbres Restantes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(145, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(153, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Timbres Consumidos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(145, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Timbres Contratados"
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(6, 101)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(127, 37)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancela.Image = CType(resources.GetObject("btnCancela.Image"), System.Drawing.Image)
        Me.btnCancela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancela.Location = New System.Drawing.Point(6, 61)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(127, 34)
        Me.btnCancela.TabIndex = 1
        Me.btnCancela.Text = "Cancelar Recibo"
        Me.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'btn_consulta
        '
        Me.btn_consulta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_consulta.Image = CType(resources.GetObject("btn_consulta.Image"), System.Drawing.Image)
        Me.btn_consulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_consulta.Location = New System.Drawing.Point(6, 19)
        Me.btn_consulta.Name = "btn_consulta"
        Me.btn_consulta.Size = New System.Drawing.Size(127, 36)
        Me.btn_consulta.TabIndex = 0
        Me.btn_consulta.Text = "Ver Recibo"
        Me.btn_consulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_consulta.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.grid_nominas)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 165)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(736, 214)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Nominas"
        '
        'grid_nominas
        '
        Me.grid_nominas.AllowUserToAddRows = False
        Me.grid_nominas.AllowUserToDeleteRows = False
        Me.grid_nominas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_nominas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grid_nominas.BackgroundColor = System.Drawing.Color.White
        Me.grid_nominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_nominas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column8, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column2, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13})
        Me.grid_nominas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid_nominas.Location = New System.Drawing.Point(3, 16)
        Me.grid_nominas.Name = "grid_nominas"
        Me.grid_nominas.ReadOnly = True
        Me.grid_nominas.RowHeadersVisible = False
        Me.grid_nominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_nominas.Size = New System.Drawing.Size(730, 195)
        Me.grid_nominas.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "id_Nomina"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 82
        '
        'Column8
        '
        Me.Column8.HeaderText = "Folio"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 54
        '
        'Column3
        '
        Me.Column3.HeaderText = "Empleado"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 79
        '
        'Column4
        '
        Me.Column4.HeaderText = "Total"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 56
        '
        'Column5
        '
        Me.Column5.HeaderText = "Percepciones"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 97
        '
        'Column6
        '
        Me.Column6.HeaderText = "Deducciones"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 95
        '
        'Column7
        '
        Me.Column7.HeaderText = "Fecha"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 62
        '
        'Column2
        '
        Me.Column2.HeaderText = "Estatus"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 67
        '
        'Column9
        '
        Me.Column9.HeaderText = "uuid"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 52
        '
        'Column10
        '
        Me.Column10.HeaderText = "folio"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        Me.Column10.Width = 51
        '
        'Column11
        '
        Me.Column11.HeaderText = "idemp"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        Me.Column11.Width = 60
        '
        'Column12
        '
        Me.Column12.HeaderText = "fecha_sat"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        Me.Column12.Width = 79
        '
        'Column13
        '
        Me.Column13.HeaderText = "mpag"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Visible = False
        Me.Column13.Width = 58
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.chk_empleados)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cbo_empleado)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbo_empresa)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(837, 101)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Para Consulta"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chk_fechas)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dt_al)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dt_del)
        Me.GroupBox2.Location = New System.Drawing.Point(556, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(277, 80)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fechas"
        '
        'chk_fechas
        '
        Me.chk_fechas.AutoSize = True
        Me.chk_fechas.Checked = True
        Me.chk_fechas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_fechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_fechas.Location = New System.Drawing.Point(163, 19)
        Me.chk_fechas.Name = "chk_fechas"
        Me.chk_fechas.Size = New System.Drawing.Size(66, 20)
        Me.chk_fechas.TabIndex = 6
        Me.chk_fechas.Text = "Todos"
        Me.chk_fechas.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Al"
        '
        'dt_al
        '
        Me.dt_al.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_al.Location = New System.Drawing.Point(51, 45)
        Me.dt_al.Name = "dt_al"
        Me.dt_al.Size = New System.Drawing.Size(106, 20)
        Me.dt_al.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Del"
        '
        'dt_del
        '
        Me.dt_del.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_del.Location = New System.Drawing.Point(51, 19)
        Me.dt_del.Name = "dt_del"
        Me.dt_del.Size = New System.Drawing.Size(106, 20)
        Me.dt_del.TabIndex = 0
        '
        'chk_empleados
        '
        Me.chk_empleados.AutoSize = True
        Me.chk_empleados.Checked = True
        Me.chk_empleados.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_empleados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_empleados.Location = New System.Drawing.Point(491, 60)
        Me.chk_empleados.Name = "chk_empleados"
        Me.chk_empleados.Size = New System.Drawing.Size(60, 19)
        Me.chk_empleados.TabIndex = 4
        Me.chk_empleados.Text = "Todos"
        Me.chk_empleados.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Empleado"
        '
        'cbo_empleado
        '
        Me.cbo_empleado.FormattingEnabled = True
        Me.cbo_empleado.Location = New System.Drawing.Point(83, 58)
        Me.cbo_empleado.Name = "cbo_empleado"
        Me.cbo_empleado.Size = New System.Drawing.Size(402, 21)
        Me.cbo_empleado.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empresa"
        '
        'cbo_empresa
        '
        Me.cbo_empresa.FormattingEnabled = True
        Me.cbo_empresa.Location = New System.Drawing.Point(83, 21)
        Me.cbo_empresa.Name = "cbo_empresa"
        Me.cbo_empresa.Size = New System.Drawing.Size(402, 21)
        Me.cbo_empresa.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1157, 46)
        Me.Panel1.TabIndex = 14
        '
        'frm_consulta_nomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1157, 636)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_consulta_nomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Nominas"
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.grid_otrospagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.grid_deducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.grid_percepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.grid_nominas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents grid_otrospagos As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents gb1 As GroupBox
    Friend WithEvents t_opagos As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents tpagado As TextBox
    Friend WithEvents t_deducciones As TextBox
    Friend WithEvents t_percepcion As TextBox
    Friend WithEvents t_exento As TextBox
    Friend WithEvents t_gravado As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents grid_deducciones As DataGridView
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents grid_percepciones As DataGridView
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_restantes As Label
    Friend WithEvents lbl_consumidos As Label
    Friend WithEvents lbl_contratados As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCancela As Button
    Friend WithEvents btn_consulta As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents grid_nominas As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chk_fechas As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dt_al As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dt_del As DateTimePicker
    Friend WithEvents chk_empleados As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbo_empleado As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbo_empresa As ComboBox
    Friend WithEvents Panel1 As Panel
End Class
