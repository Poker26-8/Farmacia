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
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        'frmRepBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(886, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepBodegas"
        Me.Text = "Reporte"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
End Class
