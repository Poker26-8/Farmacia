<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepAsistenciaGym
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepAsistenciaGym))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.lbl_proceso = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RbTodos = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MonthCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.GridCaptura = New System.Windows.Forms.DataGridView()
        Me.Col0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Col4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CboEmpleado = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(785, 35)
        Me.Label2.TabIndex = 84
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(688, 555)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(74, 79)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "SALIR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnexportar
        '
        Me.btnexportar.BackColor = System.Drawing.Color.White
        Me.btnexportar.Image = CType(resources.GetObject("btnexportar.Image"), System.Drawing.Image)
        Me.btnexportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnexportar.Location = New System.Drawing.Point(607, 557)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(74, 79)
        Me.btnexportar.TabIndex = 82
        Me.btnexportar.Text = "EXPORTAR"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(527, 557)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 79)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "GENERAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.Color.LimeGreen
        Me.ProgressBar2.Location = New System.Drawing.Point(26, 526)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(720, 23)
        Me.ProgressBar2.TabIndex = 80
        Me.ProgressBar2.Visible = False
        '
        'lbl_proceso
        '
        Me.lbl_proceso.AutoSize = True
        Me.lbl_proceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_proceso.Location = New System.Drawing.Point(28, 499)
        Me.lbl_proceso.Name = "lbl_proceso"
        Me.lbl_proceso.Size = New System.Drawing.Size(146, 24)
        Me.lbl_proceso.TabIndex = 79
        Me.lbl_proceso.Text = "Procesando ..."
        Me.lbl_proceso.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbTodos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(26, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 89)
        Me.GroupBox2.TabIndex = 78
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Reportes"
        '
        'RbTodos
        '
        Me.RbTodos.AutoSize = True
        Me.RbTodos.Checked = True
        Me.RbTodos.Location = New System.Drawing.Point(18, 29)
        Me.RbTodos.Name = "RbTodos"
        Me.RbTodos.Size = New System.Drawing.Size(84, 24)
        Me.RbTodos.TabIndex = 0
        Me.RbTodos.TabStop = True
        Me.RbTodos.Text = "Clientes"
        Me.RbTodos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.MonthCalendar2)
        Me.GroupBox1.Controls.Add(Me.MonthCalendar1)
        Me.GroupBox1.Location = New System.Drawing.Point(247, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 205)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(472, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "HASTA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "DESDE"
        '
        'MonthCalendar2
        '
        Me.MonthCalendar2.Location = New System.Drawing.Point(267, 33)
        Me.MonthCalendar2.Name = "MonthCalendar2"
        Me.MonthCalendar2.TabIndex = 2
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(12, 33)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 1
        '
        'GridCaptura
        '
        Me.GridCaptura.AllowUserToAddRows = False
        Me.GridCaptura.AllowUserToDeleteRows = False
        Me.GridCaptura.BackgroundColor = System.Drawing.Color.White
        Me.GridCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Col0, Me.Col1, Me.Col2, Me.Col3, Me.Col4})
        Me.GridCaptura.Location = New System.Drawing.Point(22, 264)
        Me.GridCaptura.Name = "GridCaptura"
        Me.GridCaptura.ReadOnly = True
        Me.GridCaptura.RowHeadersVisible = False
        Me.GridCaptura.Size = New System.Drawing.Size(733, 287)
        Me.GridCaptura.TabIndex = 76
        '
        'Col0
        '
        Me.Col0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col0.DefaultCellStyle = DataGridViewCellStyle1
        Me.Col0.HeaderText = "Número de Empleado"
        Me.Col0.Name = "Col0"
        Me.Col0.ReadOnly = True
        Me.Col0.Visible = False
        '
        'Col1
        '
        Me.Col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Col1.HeaderText = "Empleado"
        Me.Col1.Name = "Col1"
        Me.Col1.ReadOnly = True
        Me.Col1.Width = 79
        '
        'Col2
        '
        Me.Col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col2.DefaultCellStyle = DataGridViewCellStyle3
        Me.Col2.HeaderText = "Tipo"
        Me.Col2.Name = "Col2"
        Me.Col2.ReadOnly = True
        Me.Col2.Width = 53
        '
        'Col3
        '
        Me.Col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col3.DefaultCellStyle = DataGridViewCellStyle4
        Me.Col3.HeaderText = "Fecha"
        Me.Col3.Name = "Col3"
        Me.Col3.ReadOnly = True
        Me.Col3.Width = 62
        '
        'Col4
        '
        Me.Col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Col4.DefaultCellStyle = DataGridViewCellStyle5
        Me.Col4.HeaderText = "Hora"
        Me.Col4.Name = "Col4"
        Me.Col4.ReadOnly = True
        Me.Col4.Width = 55
        '
        'CboEmpleado
        '
        Me.CboEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEmpleado.FormattingEnabled = True
        Me.CboEmpleado.Location = New System.Drawing.Point(12, 205)
        Me.CboEmpleado.Name = "CboEmpleado"
        Me.CboEmpleado.Size = New System.Drawing.Size(235, 26)
        Me.CboEmpleado.TabIndex = 75
        '
        'frmRepAsistenciaGym
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(783, 644)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.lbl_proceso)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridCaptura)
        Me.Controls.Add(Me.CboEmpleado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(799, 683)
        Me.MinimumSize = New System.Drawing.Size(799, 683)
        Me.Name = "frmRepAsistenciaGym"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Asistencia"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents btnexportar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents lbl_proceso As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RbTodos As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents MonthCalendar2 As MonthCalendar
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents GridCaptura As DataGridView
    Friend WithEvents Col0 As DataGridViewTextBoxColumn
    Friend WithEvents Col1 As DataGridViewTextBoxColumn
    Friend WithEvents Col2 As DataGridViewTextBoxColumn
    Friend WithEvents Col3 As DataGridViewTextBoxColumn
    Friend WithEvents Col4 As DataGridViewTextBoxColumn
    Friend WithEvents CboEmpleado As ComboBox
End Class
