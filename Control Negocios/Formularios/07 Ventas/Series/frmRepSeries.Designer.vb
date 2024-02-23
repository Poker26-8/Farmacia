<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepSeries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepSeries))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.mchasta = New System.Windows.Forms.MonthCalendar()
        Me.mcdesde = New System.Windows.Forms.MonthCalendar()
        Me.cbodatos = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbventas = New System.Windows.Forms.RadioButton()
        Me.rbcompras = New System.Windows.Forms.RadioButton()
        Me.rbproductos = New System.Windows.Forms.RadioButton()
        Me.rbseries = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdseries = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdseries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(924, 42)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(924, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reporte de Series"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.mchasta)
        Me.Panel3.Controls.Add(Me.mcdesde)
        Me.Panel3.Controls.Add(Me.cbodatos)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 42)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(924, 185)
        Me.Panel3.TabIndex = 10
        '
        'mchasta
        '
        Me.mchasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mchasta.Location = New System.Drawing.Point(667, 9)
        Me.mchasta.Name = "mchasta"
        Me.mchasta.TabIndex = 9
        '
        'mcdesde
        '
        Me.mcdesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcdesde.Location = New System.Drawing.Point(408, 9)
        Me.mcdesde.Name = "mcdesde"
        Me.mcdesde.TabIndex = 8
        '
        'cbodatos
        '
        Me.cbodatos.FormattingEnabled = True
        Me.cbodatos.Location = New System.Drawing.Point(12, 150)
        Me.cbodatos.Name = "cbodatos"
        Me.cbodatos.Size = New System.Drawing.Size(234, 21)
        Me.cbodatos.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbventas)
        Me.GroupBox2.Controls.Add(Me.rbcompras)
        Me.GroupBox2.Controls.Add(Me.rbproductos)
        Me.GroupBox2.Controls.Add(Me.rbseries)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 138)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'rbventas
        '
        Me.rbventas.AutoSize = True
        Me.rbventas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbventas.Location = New System.Drawing.Point(8, 75)
        Me.rbventas.Name = "rbventas"
        Me.rbventas.Size = New System.Drawing.Size(71, 22)
        Me.rbventas.TabIndex = 5
        Me.rbventas.TabStop = True
        Me.rbventas.Text = "Ventas"
        Me.rbventas.UseVisualStyleBackColor = True
        '
        'rbcompras
        '
        Me.rbcompras.AutoSize = True
        Me.rbcompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbcompras.Location = New System.Drawing.Point(8, 47)
        Me.rbcompras.Name = "rbcompras"
        Me.rbcompras.Size = New System.Drawing.Size(88, 22)
        Me.rbcompras.TabIndex = 4
        Me.rbcompras.TabStop = True
        Me.rbcompras.Text = "Compras"
        Me.rbcompras.UseVisualStyleBackColor = True
        '
        'rbproductos
        '
        Me.rbproductos.AutoSize = True
        Me.rbproductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbproductos.Location = New System.Drawing.Point(8, 19)
        Me.rbproductos.Name = "rbproductos"
        Me.rbproductos.Size = New System.Drawing.Size(95, 22)
        Me.rbproductos.TabIndex = 3
        Me.rbproductos.TabStop = True
        Me.rbproductos.Text = "Productos"
        Me.rbproductos.UseVisualStyleBackColor = True
        '
        'rbseries
        '
        Me.rbseries.AutoSize = True
        Me.rbseries.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbseries.Location = New System.Drawing.Point(8, 103)
        Me.rbseries.Name = "rbseries"
        Me.rbseries.Size = New System.Drawing.Size(156, 22)
        Me.rbseries.TabIndex = 2
        Me.rbseries.TabStop = True
        Me.rbseries.Text = "Ver todas las series"
        Me.rbseries.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.btnsalir)
        Me.Panel4.Controls.Add(Me.btnexportar)
        Me.Panel4.Controls.Add(Me.btnreporte)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 575)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(924, 100)
        Me.Panel4.TabIndex = 11
        '
        'btnsalir
        '
        Me.btnsalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalir.Image = CType(resources.GetObject("btnsalir.Image"), System.Drawing.Image)
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsalir.Location = New System.Drawing.Point(838, 14)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(75, 74)
        Me.btnsalir.TabIndex = 2
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnexportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Image = CType(resources.GetObject("btnexportar.Image"), System.Drawing.Image)
        Me.btnexportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnexportar.Location = New System.Drawing.Point(757, 14)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(75, 74)
        Me.btnexportar.TabIndex = 0
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnreporte
        '
        Me.btnreporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnreporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnreporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporte.Image = CType(resources.GetObject("btnreporte.Image"), System.Drawing.Image)
        Me.btnreporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnreporte.Location = New System.Drawing.Point(676, 14)
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(75, 74)
        Me.btnreporte.TabIndex = 1
        Me.btnreporte.Text = "Reporte"
        Me.btnreporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreporte.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdseries)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 227)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(924, 348)
        Me.Panel2.TabIndex = 12
        '
        'grdseries
        '
        Me.grdseries.AllowUserToAddRows = False
        Me.grdseries.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdseries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdseries.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdseries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdseries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdseries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column6, Me.Column7, Me.Column4, Me.Column9, Me.Column8})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdseries.DefaultCellStyle = DataGridViewCellStyle12
        Me.grdseries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdseries.GridColor = System.Drawing.Color.White
        Me.grdseries.Location = New System.Drawing.Point(0, 0)
        Me.grdseries.Name = "grdseries"
        Me.grdseries.ReadOnly = True
        Me.grdseries.RowHeadersVisible = False
        Me.grdseries.Size = New System.Drawing.Size(924, 348)
        Me.grdseries.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 84
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column3.HeaderText = "Serie"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 71
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column5.HeaderText = "Fecha Entrada"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 140
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column6.HeaderText = "N° Venta"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 97
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column7.HeaderText = "Fecha Salida"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 127
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle9
        Me.Column4.HeaderText = "N° Factura"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 109
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle10
        Me.Column9.HeaderText = "Fec.Factura"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 120
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle11
        Me.Column8.HeaderText = "Status"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 81
        '
        'frmRepSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(924, 675)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepSeries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Series"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdseries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents mchasta As MonthCalendar
    Friend WithEvents mcdesde As MonthCalendar
    Friend WithEvents cbodatos As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbventas As RadioButton
    Friend WithEvents rbcompras As RadioButton
    Friend WithEvents rbproductos As RadioButton
    Friend WithEvents rbseries As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnsalir As Button
    Friend WithEvents btnexportar As Button
    Friend WithEvents btnreporte As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdseries As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
End Class
