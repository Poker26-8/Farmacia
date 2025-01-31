<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepAuditoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepAuditoria))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbLotes = New System.Windows.Forms.RadioButton()
        Me.rbprecios = New System.Windows.Forms.RadioButton()
        Me.rbexistencias = New System.Windows.Forms.RadioButton()
        Me.mcdesde = New System.Windows.Forms.MonthCalendar()
        Me.mchasta = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbofiltro = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(927, 36)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Reporte de Auditoria"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(927, 36)
        Me.Panel1.TabIndex = 228
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbLotes)
        Me.GroupBox1.Controls.Add(Me.rbprecios)
        Me.GroupBox1.Controls.Add(Me.rbexistencias)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(166, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbLotes
        '
        Me.rbLotes.AutoSize = True
        Me.rbLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLotes.Location = New System.Drawing.Point(6, 76)
        Me.rbLotes.Name = "rbLotes"
        Me.rbLotes.Size = New System.Drawing.Size(72, 24)
        Me.rbLotes.TabIndex = 3
        Me.rbLotes.TabStop = True
        Me.rbLotes.Text = "Lotes"
        Me.rbLotes.UseVisualStyleBackColor = True
        '
        'rbprecios
        '
        Me.rbprecios.AutoSize = True
        Me.rbprecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbprecios.Location = New System.Drawing.Point(6, 46)
        Me.rbprecios.Name = "rbprecios"
        Me.rbprecios.Size = New System.Drawing.Size(86, 24)
        Me.rbprecios.TabIndex = 2
        Me.rbprecios.TabStop = True
        Me.rbprecios.Text = "Precios"
        Me.rbprecios.UseVisualStyleBackColor = True
        '
        'rbexistencias
        '
        Me.rbexistencias.AutoSize = True
        Me.rbexistencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbexistencias.Location = New System.Drawing.Point(6, 16)
        Me.rbexistencias.Name = "rbexistencias"
        Me.rbexistencias.Size = New System.Drawing.Size(118, 24)
        Me.rbexistencias.TabIndex = 1
        Me.rbexistencias.TabStop = True
        Me.rbexistencias.Text = "Existencias"
        Me.rbexistencias.UseVisualStyleBackColor = True
        '
        'mcdesde
        '
        Me.mcdesde.Location = New System.Drawing.Point(275, 27)
        Me.mcdesde.Name = "mcdesde"
        Me.mcdesde.TabIndex = 1
        '
        'mchasta
        '
        Me.mchasta.Location = New System.Drawing.Point(530, 27)
        Me.mchasta.Name = "mchasta"
        Me.mchasta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(526, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Hasta"
        '
        'btnReporte
        '
        Me.btnReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReporte.BackgroundImage = CType(resources.GetObject("btnReporte.BackgroundImage"), System.Drawing.Image)
        Me.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReporte.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Location = New System.Drawing.Point(7, 30)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(60, 63)
        Me.btnReporte.TabIndex = 230
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.BackgroundImage = CType(resources.GetObject("btnexportar.BackgroundImage"), System.Drawing.Image)
        Me.btnexportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Location = New System.Drawing.Point(73, 30)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(60, 63)
        Me.btnexportar.TabIndex = 233
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.cbofiltro)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.mchasta)
        Me.Panel3.Controls.Add(Me.mcdesde)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 36)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(927, 206)
        Me.Panel3.TabIndex = 230
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 20)
        Me.Label4.TabIndex = 237
        Me.Label4.Text = "Filtro"
        '
        'cbofiltro
        '
        Me.cbofiltro.FormattingEnabled = True
        Me.cbofiltro.Location = New System.Drawing.Point(10, 162)
        Me.cbofiltro.Name = "cbofiltro"
        Me.cbofiltro.Size = New System.Drawing.Size(225, 21)
        Me.cbofiltro.TabIndex = 236
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnReporte)
        Me.Panel2.Controls.Add(Me.btnexportar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(783, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 206)
        Me.Panel2.TabIndex = 235
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(73, 99)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 234
        Me.btnNuevo.Text = "Limpiar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 242)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(927, 322)
        Me.grdCaptura.TabIndex = 231
        '
        'frmRepAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(927, 564)
        Me.Controls.Add(Me.grdCaptura)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepAuditoria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Auditoria"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbexistencias As RadioButton
    Friend WithEvents mcdesde As MonthCalendar
    Friend WithEvents mchasta As MonthCalendar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnReporte As Button
    Friend WithEvents btnexportar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnNuevo As Button
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents cbofiltro As ComboBox
    Friend WithEvents rbprecios As RadioButton
    Friend WithEvents rbLotes As RadioButton
End Class
