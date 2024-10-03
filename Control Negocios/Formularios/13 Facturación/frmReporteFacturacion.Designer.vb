<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteFacturacion))
        Me.mc2 = New System.Windows.Forms.MonthCalendar()
        Me.mc1 = New System.Windows.Forms.MonthCalendar()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.cbo = New System.Windows.Forms.ComboBox()
        Me.optVentas = New System.Windows.Forms.RadioButton()
        Me.optGlob = New System.Windows.Forms.RadioButton()
        Me.optDet = New System.Windows.Forms.RadioButton()
        Me.optCli = New System.Windows.Forms.RadioButton()
        Me.optTotal = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cboParci = New System.Windows.Forms.ComboBox()
        Me.optMultiCli = New System.Windows.Forms.RadioButton()
        Me.optMulti = New System.Windows.Forms.RadioButton()
        Me.optParCli = New System.Windows.Forms.RadioButton()
        Me.optParci = New System.Windows.Forms.RadioButton()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Exportar = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecFac = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txttotFac = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtivaFac = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStotFac = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtClieFact = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFolFac = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mc2
        '
        Me.mc2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mc2.Location = New System.Drawing.Point(637, 21)
        Me.mc2.Name = "mc2"
        Me.mc2.TabIndex = 3
        '
        'mc1
        '
        Me.mc1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mc1.Location = New System.Drawing.Point(371, 21)
        Me.mc1.Name = "mc1"
        Me.mc1.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(290, 196)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.RadioButton1)
        Me.TabPage1.Controls.Add(Me.cbo)
        Me.TabPage1.Controls.Add(Me.optVentas)
        Me.TabPage1.Controls.Add(Me.optGlob)
        Me.TabPage1.Controls.Add(Me.optDet)
        Me.TabPage1.Controls.Add(Me.optCli)
        Me.TabPage1.Controls.Add(Me.optTotal)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(282, 170)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "FACTURAS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(147, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(118, 17)
        Me.RadioButton1.TabIndex = 64
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Facturas canceldas"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.Visible = False
        '
        'cbo
        '
        Me.cbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo.FormattingEnabled = True
        Me.cbo.Location = New System.Drawing.Point(3, 129)
        Me.cbo.Name = "cbo"
        Me.cbo.Size = New System.Drawing.Size(270, 24)
        Me.cbo.TabIndex = 63
        Me.cbo.Visible = False
        '
        'optVentas
        '
        Me.optVentas.AutoSize = True
        Me.optVentas.Location = New System.Drawing.Point(6, 106)
        Me.optVentas.Name = "optVentas"
        Me.optVentas.Size = New System.Drawing.Size(98, 17)
        Me.optVentas.TabIndex = 58
        Me.optVentas.TabStop = True
        Me.optVentas.Text = "Notas de venta"
        Me.optVentas.UseVisualStyleBackColor = True
        '
        'optGlob
        '
        Me.optGlob.AutoSize = True
        Me.optGlob.Location = New System.Drawing.Point(6, 81)
        Me.optGlob.Name = "optGlob"
        Me.optGlob.Size = New System.Drawing.Size(108, 17)
        Me.optGlob.TabIndex = 57
        Me.optGlob.TabStop = True
        Me.optGlob.Text = "Facturas globales"
        Me.optGlob.UseVisualStyleBackColor = True
        '
        'optDet
        '
        Me.optDet.AutoSize = True
        Me.optDet.Location = New System.Drawing.Point(6, 56)
        Me.optDet.Name = "optDet"
        Me.optDet.Size = New System.Drawing.Size(142, 17)
        Me.optDet.TabIndex = 56
        Me.optDet.TabStop = True
        Me.optDet.Text = "Facturas totales (Detalle)"
        Me.optDet.UseVisualStyleBackColor = True
        '
        'optCli
        '
        Me.optCli.AutoSize = True
        Me.optCli.Location = New System.Drawing.Point(6, 31)
        Me.optCli.Name = "optCli"
        Me.optCli.Size = New System.Drawing.Size(118, 17)
        Me.optCli.TabIndex = 55
        Me.optCli.TabStop = True
        Me.optCli.Text = "Facturas por cliente"
        Me.optCli.UseVisualStyleBackColor = True
        '
        'optTotal
        '
        Me.optTotal.AutoSize = True
        Me.optTotal.Location = New System.Drawing.Point(6, 6)
        Me.optTotal.Name = "optTotal"
        Me.optTotal.Size = New System.Drawing.Size(104, 17)
        Me.optTotal.TabIndex = 54
        Me.optTotal.TabStop = True
        Me.optTotal.Text = "Facturas Totales"
        Me.optTotal.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cboParci)
        Me.TabPage2.Controls.Add(Me.optMultiCli)
        Me.TabPage2.Controls.Add(Me.optMulti)
        Me.TabPage2.Controls.Add(Me.optParCli)
        Me.TabPage2.Controls.Add(Me.optParci)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(282, 170)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PARCIALIDADES"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cboParci
        '
        Me.cboParci.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParci.FormattingEnabled = True
        Me.cboParci.Location = New System.Drawing.Point(6, 138)
        Me.cboParci.Name = "cboParci"
        Me.cboParci.Size = New System.Drawing.Size(270, 24)
        Me.cboParci.TabIndex = 64
        '
        'optMultiCli
        '
        Me.optMultiCli.AutoSize = True
        Me.optMultiCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMultiCli.Location = New System.Drawing.Point(6, 106)
        Me.optMultiCli.Name = "optMultiCli"
        Me.optMultiCli.Size = New System.Drawing.Size(185, 20)
        Me.optMultiCli.TabIndex = 57
        Me.optMultiCli.TabStop = True
        Me.optMultiCli.Text = "Multiparcialidad por cliente"
        Me.optMultiCli.UseVisualStyleBackColor = True
        '
        'optMulti
        '
        Me.optMulti.AutoSize = True
        Me.optMulti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMulti.Location = New System.Drawing.Point(5, 72)
        Me.optMulti.Name = "optMulti"
        Me.optMulti.Size = New System.Drawing.Size(120, 20)
        Me.optMulti.TabIndex = 56
        Me.optMulti.TabStop = True
        Me.optMulti.Text = "Multiparcialidad"
        Me.optMulti.UseVisualStyleBackColor = True
        '
        'optParCli
        '
        Me.optParCli.AutoSize = True
        Me.optParCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optParCli.Location = New System.Drawing.Point(5, 38)
        Me.optParCli.Name = "optParCli"
        Me.optParCli.Size = New System.Drawing.Size(174, 20)
        Me.optParCli.TabIndex = 55
        Me.optParCli.TabStop = True
        Me.optParCli.Text = "Parcialidades por cliente"
        Me.optParCli.UseVisualStyleBackColor = True
        '
        'optParci
        '
        Me.optParci.AutoSize = True
        Me.optParci.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optParci.Location = New System.Drawing.Point(6, 6)
        Me.optParci.Name = "optParci"
        Me.optParci.Size = New System.Drawing.Size(94, 20)
        Me.optParci.TabIndex = 54
        Me.optParci.TabStop = True
        Me.optParci.Text = "Parcialidad"
        Me.optParci.UseVisualStyleBackColor = True
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
        Me.grdcaptura.Location = New System.Drawing.Point(12, 248)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(867, 267)
        Me.grdcaptura.TabIndex = 49
        '
        'Exportar
        '
        Me.Exportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Exportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Exportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Exportar.Location = New System.Drawing.Point(789, 524)
        Me.Exportar.Name = "Exportar"
        Me.Exportar.Size = New System.Drawing.Size(90, 54)
        Me.Exportar.TabIndex = 204
        Me.Exportar.Text = "Exportar"
        Me.Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Exportar.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporte.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(693, 524)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(90, 54)
        Me.btnReporte.TabIndex = 203
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFecFac)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txttotFac)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtivaFac)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtStotFac)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtClieFact)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtFolFac)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 521)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 63)
        Me.GroupBox1.TabIndex = 205
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'txtFecFac
        '
        Me.txtFecFac.Enabled = False
        Me.txtFecFac.Location = New System.Drawing.Point(552, 32)
        Me.txtFecFac.Name = "txtFecFac"
        Me.txtFecFac.Size = New System.Drawing.Size(90, 20)
        Me.txtFecFac.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(552, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Fecha"
        '
        'txttotFac
        '
        Me.txttotFac.Enabled = False
        Me.txttotFac.Location = New System.Drawing.Point(479, 32)
        Me.txttotFac.Name = "txttotFac"
        Me.txttotFac.Size = New System.Drawing.Size(71, 20)
        Me.txttotFac.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(479, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Total:"
        '
        'txtivaFac
        '
        Me.txtivaFac.Enabled = False
        Me.txtivaFac.Location = New System.Drawing.Point(408, 32)
        Me.txtivaFac.Name = "txtivaFac"
        Me.txtivaFac.Size = New System.Drawing.Size(67, 20)
        Me.txtivaFac.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(408, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "IVA:"
        '
        'txtStotFac
        '
        Me.txtStotFac.Enabled = False
        Me.txtStotFac.Location = New System.Drawing.Point(317, 32)
        Me.txtStotFac.Name = "txtStotFac"
        Me.txtStotFac.Size = New System.Drawing.Size(84, 20)
        Me.txtStotFac.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(317, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Subtotal"
        '
        'txtClieFact
        '
        Me.txtClieFact.Enabled = False
        Me.txtClieFact.Location = New System.Drawing.Point(87, 32)
        Me.txtClieFact.Name = "txtClieFact"
        Me.txtClieFact.Size = New System.Drawing.Size(224, 20)
        Me.txtClieFact.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'txtFolFac
        '
        Me.txtFolFac.Enabled = False
        Me.txtFolFac.Location = New System.Drawing.Point(6, 32)
        Me.txtFolFac.Name = "txtFolFac"
        Me.txtFolFac.Size = New System.Drawing.Size(75, 20)
        Me.txtFolFac.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(891, 31)
        Me.Label7.TabIndex = 206
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mc1)
        Me.Panel1.Controls.Add(Me.mc2)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(891, 211)
        Me.Panel1.TabIndex = 207
        '
        'frmReporteFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(891, 590)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Exportar)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.grdcaptura)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporteFacturacion"
        Me.Text = "Reporte de Facturación"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mc2 As MonthCalendar
    Friend WithEvents mc1 As MonthCalendar
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents optVentas As RadioButton
    Friend WithEvents optGlob As RadioButton
    Friend WithEvents optDet As RadioButton
    Friend WithEvents optCli As RadioButton
    Friend WithEvents optTotal As RadioButton
    Friend WithEvents optMultiCli As RadioButton
    Friend WithEvents optMulti As RadioButton
    Friend WithEvents optParCli As RadioButton
    Friend WithEvents optParci As RadioButton
    Friend WithEvents cbo As ComboBox
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents cboParci As ComboBox
    Friend WithEvents Exportar As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtFecFac As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txttotFac As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtivaFac As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStotFac As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtClieFact As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFolFac As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
End Class
