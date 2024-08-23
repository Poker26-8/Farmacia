<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepBodegas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepBodegas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.cbobodega = New System.Windows.Forms.ComboBox()
        Me.cbogeneral = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optbodega = New System.Windows.Forms.RadioButton()
        Me.optcliente = New System.Windows.Forms.RadioButton()
        Me.optvisitas = New System.Windows.Forms.RadioButton()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.barra = New System.Windows.Forms.ProgressBar()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mCalendar2)
        Me.Panel1.Controls.Add(Me.mCalendar1)
        Me.Panel1.Controls.Add(Me.cbobodega)
        Me.Panel1.Controls.Add(Me.cbogeneral)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.lblusuario)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(886, 189)
        Me.Panel1.TabIndex = 60
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(629, 12)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 65
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(363, 12)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 64
        '
        'cbobodega
        '
        Me.cbobodega.FormattingEnabled = True
        Me.cbobodega.Location = New System.Drawing.Point(268, 149)
        Me.cbobodega.Name = "cbobodega"
        Me.cbobodega.Size = New System.Drawing.Size(73, 21)
        Me.cbobodega.TabIndex = 63
        Me.cbobodega.Visible = False
        '
        'cbogeneral
        '
        Me.cbogeneral.FormattingEnabled = True
        Me.cbogeneral.Location = New System.Drawing.Point(12, 149)
        Me.cbogeneral.Name = "cbogeneral"
        Me.cbogeneral.Size = New System.Drawing.Size(250, 21)
        Me.cbogeneral.TabIndex = 62
        Me.cbogeneral.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optbodega)
        Me.GroupBox1.Controls.Add(Me.optcliente)
        Me.GroupBox1.Controls.Add(Me.optvisitas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 105)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'optbodega
        '
        Me.optbodega.AutoSize = True
        Me.optbodega.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optbodega.Location = New System.Drawing.Point(12, 23)
        Me.optbodega.Name = "optbodega"
        Me.optbodega.Size = New System.Drawing.Size(175, 20)
        Me.optbodega.TabIndex = 5
        Me.optbodega.TabStop = True
        Me.optbodega.Text = "Movimientos por bodega"
        Me.optbodega.UseVisualStyleBackColor = True
        '
        'optcliente
        '
        Me.optcliente.AutoSize = True
        Me.optcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optcliente.Location = New System.Drawing.Point(12, 48)
        Me.optcliente.Name = "optcliente"
        Me.optcliente.Size = New System.Drawing.Size(166, 20)
        Me.optcliente.TabIndex = 6
        Me.optcliente.TabStop = True
        Me.optcliente.Text = "Movimientos por cliente"
        Me.optcliente.UseVisualStyleBackColor = True
        '
        'optvisitas
        '
        Me.optvisitas.AutoSize = True
        Me.optvisitas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optvisitas.Location = New System.Drawing.Point(12, 73)
        Me.optvisitas.Name = "optvisitas"
        Me.optvisitas.Size = New System.Drawing.Size(139, 20)
        Me.optvisitas.TabIndex = 7
        Me.optvisitas.TabStop = True
        Me.optvisitas.Text = "Visitas por bodega"
        Me.optvisitas.UseVisualStyleBackColor = True
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(12, 13)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(330, 26)
        Me.lblusuario.TabIndex = 60
        Me.lblusuario.Text = "REPORTES"
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnreporte)
        Me.Panel2.Controls.Add(Me.btnexportar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 425)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(886, 81)
        Me.Panel2.TabIndex = 61
        '
        'btnreporte
        '
        Me.btnreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporte.Image = CType(resources.GetObject("btnreporte.Image"), System.Drawing.Image)
        Me.btnreporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnreporte.Location = New System.Drawing.Point(722, 3)
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(72, 75)
        Me.btnreporte.TabIndex = 6
        Me.btnreporte.Text = "Generar"
        Me.btnreporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreporte.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Image = CType(resources.GetObject("btnexportar.Image"), System.Drawing.Image)
        Me.btnexportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnexportar.Location = New System.Drawing.Point(805, 3)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(72, 75)
        Me.btnexportar.TabIndex = 5
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.barra)
        Me.Panel3.Controls.Add(Me.grdCaptura)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 189)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(886, 236)
        Me.Panel3.TabIndex = 62
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(886, 236)
        Me.grdCaptura.TabIndex = 0
        '
        'barra
        '
        Me.barra.Location = New System.Drawing.Point(12, 213)
        Me.barra.Name = "barra"
        Me.barra.Size = New System.Drawing.Size(865, 20)
        Me.barra.TabIndex = 57
        Me.barra.Visible = False
        '
        'frmRepBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(886, 506)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepBodegas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents mCalendar2 As MonthCalendar
    Friend WithEvents mCalendar1 As MonthCalendar
    Friend WithEvents cbobodega As ComboBox
    Friend WithEvents cbogeneral As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optbodega As RadioButton
    Friend WithEvents optcliente As RadioButton
    Friend WithEvents optvisitas As RadioButton
    Friend WithEvents lblusuario As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnreporte As Button
    Friend WithEvents btnexportar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents barra As ProgressBar
    Friend WithEvents grdCaptura As DataGridView
End Class
