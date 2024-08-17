<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporte_CS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporte_CS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pProcesos = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdconcluidos = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdpendientes = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Exportar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.optclientedet = New System.Windows.Forms.RadioButton()
        Me.optcliente = New System.Windows.Forms.RadioButton()
        Me.opttotalesdet = New System.Windows.Forms.RadioButton()
        Me.opttotales = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.pProcesos.SuspendLayout()
        CType(Me.grdconcluidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdpendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(722, 524)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(284, 13)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "Para consultar el detalle da doble click sobre algún registro"
        '
        'pProcesos
        '
        Me.pProcesos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pProcesos.Controls.Add(Me.Label3)
        Me.pProcesos.Controls.Add(Me.Label2)
        Me.pProcesos.Controls.Add(Me.grdconcluidos)
        Me.pProcesos.Controls.Add(Me.grdpendientes)
        Me.pProcesos.Controls.Add(Me.Button1)
        Me.pProcesos.Location = New System.Drawing.Point(44, 161)
        Me.pProcesos.Name = "pProcesos"
        Me.pProcesos.Size = New System.Drawing.Size(963, 275)
        Me.pProcesos.TabIndex = 240
        Me.pProcesos.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(453, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Procesos concluidos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Procesos pendientes"
        '
        'grdconcluidos
        '
        Me.grdconcluidos.AllowUserToAddRows = False
        Me.grdconcluidos.AllowUserToDeleteRows = False
        Me.grdconcluidos.BackgroundColor = System.Drawing.Color.White
        Me.grdconcluidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdconcluidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.grdconcluidos.GridColor = System.Drawing.Color.White
        Me.grdconcluidos.Location = New System.Drawing.Point(453, 27)
        Me.grdconcluidos.Name = "grdconcluidos"
        Me.grdconcluidos.ReadOnly = True
        Me.grdconcluidos.RowHeadersVisible = False
        Me.grdconcluidos.Size = New System.Drawing.Size(505, 245)
        Me.grdconcluidos.TabIndex = 226
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Proceso"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 71
        '
        'Column4
        '
        Me.Column4.HeaderText = "Fecha de entrega"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Fecha entregado"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Comentario"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 85
        '
        'grdpendientes
        '
        Me.grdpendientes.AllowUserToAddRows = False
        Me.grdpendientes.AllowUserToDeleteRows = False
        Me.grdpendientes.BackgroundColor = System.Drawing.Color.White
        Me.grdpendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.grdpendientes.GridColor = System.Drawing.Color.White
        Me.grdpendientes.Location = New System.Drawing.Point(5, 27)
        Me.grdpendientes.Name = "grdpendientes"
        Me.grdpendientes.ReadOnly = True
        Me.grdpendientes.RowHeadersVisible = False
        Me.grdpendientes.Size = New System.Drawing.Size(442, 245)
        Me.grdpendientes.TabIndex = 225
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = "Proceso"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Fecha de entrega"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(938, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 224
        Me.Button1.Text = "X"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Exportar
        '
        Me.Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Exportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exportar.Image = CType(resources.GetObject("Exportar.Image"), System.Drawing.Image)
        Me.Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Exportar.Location = New System.Drawing.Point(106, 524)
        Me.Exportar.Name = "Exportar"
        Me.Exportar.Size = New System.Drawing.Size(90, 54)
        Me.Exportar.TabIndex = 239
        Me.Exportar.Text = "Exportar"
        Me.Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Exportar.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(10, 524)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 54)
        Me.Button2.TabIndex = 238
        Me.Button2.Text = "Reporte"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcaptura.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(10, 217)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(1028, 301)
        Me.grdcaptura.TabIndex = 237
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(10, 188)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(311, 21)
        Me.ComboBox1.TabIndex = 236
        Me.ComboBox1.Visible = False
        '
        'optclientedet
        '
        Me.optclientedet.AutoSize = True
        Me.optclientedet.Location = New System.Drawing.Point(12, 118)
        Me.optclientedet.Name = "optclientedet"
        Me.optclientedet.Size = New System.Drawing.Size(134, 17)
        Me.optclientedet.TabIndex = 235
        Me.optclientedet.TabStop = True
        Me.optclientedet.Text = "Entregados por usuario"
        Me.optclientedet.UseVisualStyleBackColor = True
        '
        'optcliente
        '
        Me.optcliente.AutoSize = True
        Me.optcliente.Location = New System.Drawing.Point(12, 95)
        Me.optcliente.Name = "optcliente"
        Me.optcliente.Size = New System.Drawing.Size(79, 17)
        Me.optcliente.TabIndex = 234
        Me.optcliente.TabStop = True
        Me.optcliente.Text = "Entregados"
        Me.optcliente.UseVisualStyleBackColor = True
        '
        'opttotalesdet
        '
        Me.opttotalesdet.AutoSize = True
        Me.opttotalesdet.Location = New System.Drawing.Point(12, 72)
        Me.opttotalesdet.Name = "opttotalesdet"
        Me.opttotalesdet.Size = New System.Drawing.Size(133, 17)
        Me.opttotalesdet.TabIndex = 233
        Me.opttotalesdet.TabStop = True
        Me.opttotalesdet.Text = "Pendientes por usuario"
        Me.opttotalesdet.UseVisualStyleBackColor = True
        '
        'opttotales
        '
        Me.opttotales.AutoSize = True
        Me.opttotales.Location = New System.Drawing.Point(12, 49)
        Me.opttotales.Name = "opttotales"
        Me.opttotales.Size = New System.Drawing.Size(78, 17)
        Me.opttotales.TabIndex = 232
        Me.opttotales.TabStop = True
        Me.opttotales.Text = "Pendientes"
        Me.opttotales.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(1050, 34)
        Me.Label1.TabIndex = 231
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(790, 49)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 230
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(533, 49)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 229
        '
        'frmReporte_CS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1050, 584)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pProcesos)
        Me.Controls.Add(Me.Exportar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.optclientedet)
        Me.Controls.Add(Me.optcliente)
        Me.Controls.Add(Me.opttotalesdet)
        Me.Controls.Add(Me.opttotales)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mCalendar2)
        Me.Controls.Add(Me.mCalendar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1066, 623)
        Me.MinimumSize = New System.Drawing.Size(1066, 623)
        Me.Name = "frmReporte_CS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de control de servicios"
        Me.pProcesos.ResumeLayout(False)
        Me.pProcesos.PerformLayout()
        CType(Me.grdconcluidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdpendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents pProcesos As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents grdconcluidos As DataGridView
    Friend WithEvents grdpendientes As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Exportar As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents optclientedet As RadioButton
    Friend WithEvents optcliente As RadioButton
    Friend WithEvents opttotalesdet As RadioButton
    Friend WithEvents opttotales As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents mCalendar2 As MonthCalendar
    Friend WithEvents mCalendar1 As MonthCalendar
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
End Class
