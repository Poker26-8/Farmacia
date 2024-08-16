<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepMac
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepMac))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker()
        Me.mcDesde = New System.Windows.Forms.MonthCalendar()
        Me.mcHasta = New System.Windows.Forms.MonthCalendar()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.rbVentasTotales = New System.Windows.Forms.RadioButton()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbVentasTotales)
        Me.Panel1.Controls.Add(Me.dtpinicio)
        Me.Panel1.Controls.Add(Me.mcDesde)
        Me.Panel1.Controls.Add(Me.mcHasta)
        Me.Panel1.Controls.Add(Me.dtpFin)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 206)
        Me.Panel1.TabIndex = 0
        '
        'dtpinicio
        '
        Me.dtpinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpinicio.Location = New System.Drawing.Point(138, 177)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.ShowUpDown = True
        Me.dtpinicio.Size = New System.Drawing.Size(101, 26)
        Me.dtpinicio.TabIndex = 212
        '
        'mcDesde
        '
        Me.mcDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcDesde.Location = New System.Drawing.Point(136, 9)
        Me.mcDesde.Name = "mcDesde"
        Me.mcDesde.TabIndex = 211
        '
        'mcHasta
        '
        Me.mcHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcHasta.Location = New System.Drawing.Point(391, 9)
        Me.mcHasta.Name = "mcHasta"
        Me.mcHasta.TabIndex = 210
        '
        'dtpFin
        '
        Me.dtpFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpFin.Location = New System.Drawing.Point(541, 177)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.ShowUpDown = True
        Me.dtpFin.Size = New System.Drawing.Size(100, 26)
        Me.dtpFin.TabIndex = 213
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtDescuento)
        Me.Panel2.Controls.Add(Me.lblDescuento)
        Me.Panel2.Controls.Add(Me.txtSubtotal)
        Me.Panel2.Controls.Add(Me.lblSubtotal)
        Me.Panel2.Controls.Add(Me.txtIVA)
        Me.Panel2.Controls.Add(Me.lblIva)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.btnExcel)
        Me.Panel2.Controls.Add(Me.btnReporte)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 476)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(650, 82)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.barcarga)
        Me.Panel3.Controls.Add(Me.grdCaptura)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 206)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(650, 270)
        Me.Panel3.TabIndex = 2
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.grdCaptura.RowHeadersVisible = False
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.grdCaptura.Size = New System.Drawing.Size(650, 270)
        Me.grdCaptura.TabIndex = 0
        '
        'btnReporte
        '
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(3, 6)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(90, 74)
        Me.btnReporte.TabIndex = 214
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(99, 6)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(90, 74)
        Me.btnExcel.TabIndex = 215
        Me.btnExcel.Text = "Exportar"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(220, 29)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 24)
        Me.txtSubtotal.TabIndex = 221
        Me.txtSubtotal.Text = "0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(220, 6)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(100, 24)
        Me.lblSubtotal.TabIndex = 220
        Me.lblSubtotal.Text = "Subtotal:"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIVA
        '
        Me.txtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.Location = New System.Drawing.Point(432, 29)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(100, 24)
        Me.txtIVA.TabIndex = 219
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.Location = New System.Drawing.Point(432, 3)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(55, 24)
        Me.lblIva.TabIndex = 218
        Me.lblIva.Text = "IVA:"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(538, 29)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 24)
        Me.txtTotal.TabIndex = 217
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(538, 3)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(74, 24)
        Me.lblTotal.TabIndex = 216
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(326, 29)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(100, 24)
        Me.txtDescuento.TabIndex = 223
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuento
        '
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(326, 2)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(91, 24)
        Me.lblDescuento.TabIndex = 222
        Me.lblDescuento.Text = "Descuento:"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbVentasTotales
        '
        Me.rbVentasTotales.AutoSize = True
        Me.rbVentasTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasTotales.Location = New System.Drawing.Point(12, 12)
        Me.rbVentasTotales.Name = "rbVentasTotales"
        Me.rbVentasTotales.Size = New System.Drawing.Size(119, 22)
        Me.rbVentasTotales.TabIndex = 214
        Me.rbVentasTotales.TabStop = True
        Me.rbVentasTotales.Text = "Ventas totales"
        Me.rbVentasTotales.UseVisualStyleBackColor = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Subtotal"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "IVA"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Descuento"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Totales"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(3, 244)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(644, 20)
        Me.barcarga.TabIndex = 207
        Me.barcarga.Visible = False
        '
        'frmRepMac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(650, 558)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepMac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Mac"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpinicio As DateTimePicker
    Friend WithEvents mcDesde As MonthCalendar
    Friend WithEvents mcHasta As MonthCalendar
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtIVA As TextBox
    Friend WithEvents lblIva As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents lblDescuento As Label
    Friend WithEvents rbVentasTotales As RadioButton
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents barcarga As ProgressBar
End Class
