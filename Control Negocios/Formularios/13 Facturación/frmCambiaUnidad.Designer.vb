<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiaUnidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiaUnidad))
        Me.Label101 = New System.Windows.Forms.Label()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.rbGrupo = New System.Windows.Forms.RadioButton()
        Me.rbDepto = New System.Windows.Forms.RadioButton()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescEmpresa = New System.Windows.Forms.TextBox()
        Me.DGVEmpresAs = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDesc = New System.Windows.Forms.TextBox()
        Me.DGVUnidad = New System.Windows.Forms.DataGridView()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVEmpresAs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label101
        '
        Me.Label101.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label101.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label101.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.White
        Me.Label101.Location = New System.Drawing.Point(0, 0)
        Me.Label101.Name = "Label101"
        Me.Label101.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label101.Size = New System.Drawing.Size(904, 31)
        Me.Label101.TabIndex = 95
        Me.Label101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboEmpresa
        '
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(648, 58)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(249, 23)
        Me.cboEmpresa.TabIndex = 104
        Me.cboEmpresa.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTodos)
        Me.GroupBox1.Controls.Add(Me.rbGrupo)
        Me.GroupBox1.Controls.Add(Me.rbDepto)
        Me.GroupBox1.Location = New System.Drawing.Point(416, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 45)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtrado"
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Checked = True
        Me.rbTodos.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTodos.Location = New System.Drawing.Point(245, 15)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(62, 21)
        Me.rbTodos.TabIndex = 2
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'rbGrupo
        '
        Me.rbGrupo.AutoSize = True
        Me.rbGrupo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGrupo.Location = New System.Drawing.Point(151, 15)
        Me.rbGrupo.Name = "rbGrupo"
        Me.rbGrupo.Size = New System.Drawing.Size(63, 21)
        Me.rbGrupo.TabIndex = 1
        Me.rbGrupo.Text = "Grupo"
        Me.rbGrupo.UseVisualStyleBackColor = True
        '
        'rbDepto
        '
        Me.rbDepto.AutoSize = True
        Me.rbDepto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDepto.Location = New System.Drawing.Point(10, 15)
        Me.rbDepto.Name = "rbDepto"
        Me.rbDepto.Size = New System.Drawing.Size(110, 21)
        Me.rbDepto.TabIndex = 0
        Me.rbDepto.Text = "Departamento"
        Me.rbDepto.UseVisualStyleBackColor = True
        '
        'btnActualizar
        '
        Me.btnActualizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualizar.Location = New System.Drawing.Point(819, 84)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(78, 45)
        Me.btnActualizar.TabIndex = 102
        Me.btnActualizar.Text = "Actualizar Claves"
        Me.btnActualizar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(416, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 17)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Productos de la empresa:"
        '
        'txtDescEmpresa
        '
        Me.txtDescEmpresa.Location = New System.Drawing.Point(416, 58)
        Me.txtDescEmpresa.Name = "txtDescEmpresa"
        Me.txtDescEmpresa.Size = New System.Drawing.Size(226, 23)
        Me.txtDescEmpresa.TabIndex = 100
        '
        'DGVEmpresAs
        '
        Me.DGVEmpresAs.BackgroundColor = System.Drawing.Color.White
        Me.DGVEmpresAs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEmpresAs.Location = New System.Drawing.Point(416, 132)
        Me.DGVEmpresAs.Name = "DGVEmpresAs"
        Me.DGVEmpresAs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVEmpresAs.Size = New System.Drawing.Size(481, 462)
        Me.DGVEmpresAs.TabIndex = 99
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 17)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Claves de Unidad SAT:"
        '
        'txtDesc
        '
        Me.txtDesc.Location = New System.Drawing.Point(10, 58)
        Me.txtDesc.Name = "txtDesc"
        Me.txtDesc.Size = New System.Drawing.Size(189, 23)
        Me.txtDesc.TabIndex = 96
        '
        'DGVUnidad
        '
        Me.DGVUnidad.BackgroundColor = System.Drawing.Color.White
        Me.DGVUnidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVUnidad.Location = New System.Drawing.Point(10, 87)
        Me.DGVUnidad.MultiSelect = False
        Me.DGVUnidad.Name = "DGVUnidad"
        Me.DGVUnidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVUnidad.Size = New System.Drawing.Size(397, 507)
        Me.DGVUnidad.TabIndex = 97
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresar.Location = New System.Drawing.Point(735, 84)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(78, 45)
        Me.btnIngresar.TabIndex = 105
        Me.btnIngresar.Text = "Ingresar Claves"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'frmCambiaUnidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(904, 607)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.cboEmpresa)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescEmpresa)
        Me.Controls.Add(Me.DGVEmpresAs)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDesc)
        Me.Controls.Add(Me.DGVUnidad)
        Me.Controls.Add(Me.Label101)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCambiaUnidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clave de Unidad SAT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DGVEmpresAs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label101 As Label
    Friend WithEvents cboEmpresa As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents rbGrupo As RadioButton
    Friend WithEvents rbDepto As RadioButton
    Friend WithEvents btnActualizar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDescEmpresa As TextBox
    Friend WithEvents DGVEmpresAs As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents DGVUnidad As DataGridView
    Friend WithEvents btnIngresar As Button
End Class
