<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadoResultados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadoResultados))
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboDatos = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbGlobal = New System.Windows.Forms.RadioButton()
        Me.rbPlacas = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mcDesde = New System.Windows.Forms.MonthCalendar()
        Me.mcHasta = New System.Windows.Forms.MonthCalendar()
        Me.lblIngresos = New System.Windows.Forms.Label()
        Me.lblEgresos = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dg2 = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSubtotalI = New System.Windows.Forms.TextBox()
        Me.txtIvaI = New System.Windows.Forms.TextBox()
        Me.txtTotalI = New System.Windows.Forms.TextBox()
        Me.txtTotalE = New System.Windows.Forms.TextBox()
        Me.txtIvaE = New System.Windows.Forms.TextBox()
        Me.txtSubtotalE = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtUtilidad = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pbb = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(857, 41)
        Me.Label20.TabIndex = 146
        Me.Label20.Text = "Estado de resultados"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboDatos)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.mcDesde)
        Me.Panel1.Controls.Add(Me.mcHasta)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(857, 206)
        Me.Panel1.TabIndex = 147
        '
        'cboDatos
        '
        Me.cboDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDatos.FormattingEnabled = True
        Me.cboDatos.Location = New System.Drawing.Point(14, 150)
        Me.cboDatos.Name = "cboDatos"
        Me.cboDatos.Size = New System.Drawing.Size(323, 23)
        Me.cboDatos.TabIndex = 5
        Me.cboDatos.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbGlobal)
        Me.GroupBox1.Controls.Add(Me.rbPlacas)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 120)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo de reporte"
        '
        'rbGlobal
        '
        Me.rbGlobal.AutoSize = True
        Me.rbGlobal.Location = New System.Drawing.Point(6, 84)
        Me.rbGlobal.Name = "rbGlobal"
        Me.rbGlobal.Size = New System.Drawing.Size(82, 28)
        Me.rbGlobal.TabIndex = 1
        Me.rbGlobal.TabStop = True
        Me.rbGlobal.Text = "Global"
        Me.rbGlobal.UseVisualStyleBackColor = True
        '
        'rbPlacas
        '
        Me.rbPlacas.AutoSize = True
        Me.rbPlacas.Location = New System.Drawing.Point(6, 40)
        Me.rbPlacas.Name = "rbPlacas"
        Me.rbPlacas.Size = New System.Drawing.Size(83, 28)
        Me.rbPlacas.TabIndex = 0
        Me.rbPlacas.TabStop = True
        Me.rbPlacas.Text = "Placas"
        Me.rbPlacas.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(599, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(345, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Desde"
        '
        'mcDesde
        '
        Me.mcDesde.Location = New System.Drawing.Point(349, 35)
        Me.mcDesde.Name = "mcDesde"
        Me.mcDesde.TabIndex = 1
        '
        'mcHasta
        '
        Me.mcHasta.Location = New System.Drawing.Point(603, 35)
        Me.mcHasta.Name = "mcHasta"
        Me.mcHasta.TabIndex = 0
        '
        'lblIngresos
        '
        Me.lblIngresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngresos.ForeColor = System.Drawing.Color.White
        Me.lblIngresos.Location = New System.Drawing.Point(5, 250)
        Me.lblIngresos.Name = "lblIngresos"
        Me.lblIngresos.Size = New System.Drawing.Size(432, 24)
        Me.lblIngresos.TabIndex = 148
        '
        'lblEgresos
        '
        Me.lblEgresos.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEgresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEgresos.ForeColor = System.Drawing.Color.White
        Me.lblEgresos.Location = New System.Drawing.Point(443, 250)
        Me.lblEgresos.Name = "lblEgresos"
        Me.lblEgresos.Size = New System.Drawing.Size(408, 24)
        Me.lblEgresos.TabIndex = 149
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.BackgroundColor = System.Drawing.Color.White
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.dg1.Location = New System.Drawing.Point(5, 277)
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersVisible = False
        Me.dg1.Size = New System.Drawing.Size(432, 168)
        Me.dg1.TabIndex = 150
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Cliente"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 64
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Subtotal"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 71
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Iva"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 47
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Total"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 56
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Fecha"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 62
        '
        'dg2
        '
        Me.dg2.AllowUserToAddRows = False
        Me.dg2.AllowUserToDeleteRows = False
        Me.dg2.BackgroundColor = System.Drawing.Color.White
        Me.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12})
        Me.dg2.Location = New System.Drawing.Point(442, 277)
        Me.dg2.Name = "dg2"
        Me.dg2.ReadOnly = True
        Me.dg2.RowHeadersVisible = False
        Me.dg2.Size = New System.Drawing.Size(409, 168)
        Me.dg2.TabIndex = 151
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Área"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 54
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "Concepto"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 78
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Factura"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 68
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Subtotal"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 71
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column10.HeaderText = "Iva"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 47
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column11.HeaderText = "Total"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 56
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column12.HeaderText = "Fecha"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 62
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.YellowGreen
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 460)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 23)
        Me.Label5.TabIndex = 153
        Me.Label5.Text = "Ingresos"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Tomato
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(209, 460)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(190, 23)
        Me.Label6.TabIndex = 154
        Me.Label6.Text = "EGRESOS"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Aqua
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(406, 460)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 23)
        Me.Label7.TabIndex = 155
        Me.Label7.Text = "UTILIDAD"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 495)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 18)
        Me.Label8.TabIndex = 156
        Me.Label8.Text = "Subtotal:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 528)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 18)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "IVA:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 561)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 18)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Total:"
        '
        'txtSubtotalI
        '
        Me.txtSubtotalI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotalI.Location = New System.Drawing.Point(87, 495)
        Me.txtSubtotalI.Name = "txtSubtotalI"
        Me.txtSubtotalI.Size = New System.Drawing.Size(110, 22)
        Me.txtSubtotalI.TabIndex = 159
        Me.txtSubtotalI.Text = "0.00"
        Me.txtSubtotalI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaI
        '
        Me.txtIvaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIvaI.Location = New System.Drawing.Point(87, 527)
        Me.txtIvaI.Name = "txtIvaI"
        Me.txtIvaI.Size = New System.Drawing.Size(110, 22)
        Me.txtIvaI.TabIndex = 160
        Me.txtIvaI.Text = "0.00"
        Me.txtIvaI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalI
        '
        Me.txtTotalI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalI.Location = New System.Drawing.Point(87, 557)
        Me.txtTotalI.Name = "txtTotalI"
        Me.txtTotalI.Size = New System.Drawing.Size(110, 22)
        Me.txtTotalI.TabIndex = 161
        Me.txtTotalI.Text = "0.00"
        Me.txtTotalI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalE
        '
        Me.txtTotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalE.Location = New System.Drawing.Point(289, 556)
        Me.txtTotalE.Name = "txtTotalE"
        Me.txtTotalE.Size = New System.Drawing.Size(110, 22)
        Me.txtTotalE.TabIndex = 167
        Me.txtTotalE.Text = "0.00"
        Me.txtTotalE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIvaE
        '
        Me.txtIvaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIvaE.Location = New System.Drawing.Point(289, 526)
        Me.txtIvaE.Name = "txtIvaE"
        Me.txtIvaE.Size = New System.Drawing.Size(110, 22)
        Me.txtIvaE.TabIndex = 166
        Me.txtIvaE.Text = "0.00"
        Me.txtIvaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubtotalE
        '
        Me.txtSubtotalE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotalE.Location = New System.Drawing.Point(289, 494)
        Me.txtSubtotalE.Name = "txtSubtotalE"
        Me.txtSubtotalE.Size = New System.Drawing.Size(110, 22)
        Me.txtSubtotalE.TabIndex = 165
        Me.txtSubtotalE.Text = "0.00"
        Me.txtSubtotalE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(208, 560)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 18)
        Me.Label11.TabIndex = 164
        Me.Label11.Text = "Total:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(208, 527)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 18)
        Me.Label12.TabIndex = 163
        Me.Label12.Text = "IVA:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(208, 494)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 18)
        Me.Label13.TabIndex = 162
        Me.Label13.Text = "Subtotal:"
        '
        'txtUtilidad
        '
        Me.txtUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUtilidad.Location = New System.Drawing.Point(407, 490)
        Me.txtUtilidad.Name = "txtUtilidad"
        Me.txtUtilidad.Size = New System.Drawing.Size(121, 22)
        Me.txtUtilidad.TabIndex = 168
        Me.txtUtilidad.Text = "0.00"
        Me.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(777, 451)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 76)
        Me.btnSalir.TabIndex = 169
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.Location = New System.Drawing.Point(696, 451)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 76)
        Me.btnExportar.TabIndex = 170
        Me.btnExportar.Text = "Exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(615, 451)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 76)
        Me.btnReporte.TabIndex = 171
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(534, 451)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 76)
        Me.btnLimpiar.TabIndex = 172
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'pbb
        '
        Me.pbb.Location = New System.Drawing.Point(5, 422)
        Me.pbb.Name = "pbb"
        Me.pbb.Size = New System.Drawing.Size(847, 23)
        Me.pbb.TabIndex = 173
        Me.pbb.Visible = False
        '
        'frmEstadoResultados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(857, 588)
        Me.Controls.Add(Me.pbb)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtUtilidad)
        Me.Controls.Add(Me.txtTotalE)
        Me.Controls.Add(Me.txtIvaE)
        Me.Controls.Add(Me.txtSubtotalE)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtTotalI)
        Me.Controls.Add(Me.txtIvaI)
        Me.Controls.Add(Me.txtSubtotalI)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dg2)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.lblEgresos)
        Me.Controls.Add(Me.lblIngresos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label20)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstadoResultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Resultados"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label20 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbGlobal As RadioButton
    Friend WithEvents rbPlacas As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents mcDesde As MonthCalendar
    Friend WithEvents mcHasta As MonthCalendar
    Friend WithEvents cboDatos As ComboBox
    Friend WithEvents lblIngresos As Label
    Friend WithEvents lblEgresos As Label
    Friend WithEvents dg1 As DataGridView
    Friend WithEvents dg2 As DataGridView
    Friend WithEvents pb As ProgressBar
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
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSubtotalI As TextBox
    Friend WithEvents txtIvaI As TextBox
    Friend WithEvents txtTotalI As TextBox
    Friend WithEvents txtTotalE As TextBox
    Friend WithEvents txtIvaE As TextBox
    Friend WithEvents txtSubtotalE As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtUtilidad As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents pbb As ProgressBar
End Class
