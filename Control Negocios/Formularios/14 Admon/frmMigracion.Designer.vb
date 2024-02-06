<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMigracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMigracion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdBase = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnauto = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnmanual = New System.Windows.Forms.Button()
        Me.opfbase = New System.Windows.Forms.OpenFileDialog()
        Me.chProductos = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chUsuarios = New System.Windows.Forms.CheckBox()
        Me.chProveedores = New System.Windows.Forms.CheckBox()
        Me.chClientes = New System.Windows.Forms.CheckBox()
        Me.barmigra = New System.Windows.Forms.ProgressBar()
        CType(Me.grdBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(215, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdBase
        '
        Me.grdBase.BackgroundColor = System.Drawing.Color.White
        Me.grdBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBase.Location = New System.Drawing.Point(8, 353)
        Me.grdBase.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.grdBase.Name = "grdBase"
        Me.grdBase.Size = New System.Drawing.Size(742, 213)
        Me.grdBase.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 15)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Selecciona la base de datos de origen"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(164, 23)
        Me.TextBox1.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(177, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(29, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnauto
        '
        Me.btnauto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnauto.Location = New System.Drawing.Point(8, 245)
        Me.btnauto.Name = "btnauto"
        Me.btnauto.Size = New System.Drawing.Size(96, 43)
        Me.btnauto.TabIndex = 11
        Me.btnauto.Text = "Migración automática"
        Me.btnauto.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 224)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Selecciona la opción de migración"
        '
        'btnmanual
        '
        Me.btnmanual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmanual.Location = New System.Drawing.Point(110, 245)
        Me.btnmanual.Name = "btnmanual"
        Me.btnmanual.Size = New System.Drawing.Size(96, 43)
        Me.btnmanual.TabIndex = 13
        Me.btnmanual.Text = "Migración manual"
        Me.btnmanual.UseVisualStyleBackColor = True
        '
        'opfbase
        '
        Me.opfbase.FileName = "OpenFileDialog1"
        '
        'chProductos
        '
        Me.chProductos.AutoSize = True
        Me.chProductos.Location = New System.Drawing.Point(20, 47)
        Me.chProductos.Name = "chProductos"
        Me.chProductos.Size = New System.Drawing.Size(80, 19)
        Me.chProductos.TabIndex = 14
        Me.chProductos.Text = "Productos"
        Me.chProductos.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.chUsuarios)
        Me.GroupBox1.Controls.Add(Me.chProveedores)
        Me.GroupBox1.Controls.Add(Me.chClientes)
        Me.GroupBox1.Controls.Add(Me.chProductos)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(8, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(198, 129)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(110, 75)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "*sin saldos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(88, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 12)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "*sin permisos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(88, 25)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 12)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "*sin saldos"
        '
        'chUsuarios
        '
        Me.chUsuarios.AutoSize = True
        Me.chUsuarios.Location = New System.Drawing.Point(20, 97)
        Me.chUsuarios.Name = "chUsuarios"
        Me.chUsuarios.Size = New System.Drawing.Size(71, 19)
        Me.chUsuarios.TabIndex = 17
        Me.chUsuarios.Text = "Usuarios"
        Me.chUsuarios.UseVisualStyleBackColor = True
        '
        'chProveedores
        '
        Me.chProveedores.AutoSize = True
        Me.chProveedores.Location = New System.Drawing.Point(20, 72)
        Me.chProveedores.Name = "chProveedores"
        Me.chProveedores.Size = New System.Drawing.Size(91, 19)
        Me.chProveedores.TabIndex = 16
        Me.chProveedores.Text = "Proveedores"
        Me.chProveedores.UseVisualStyleBackColor = True
        '
        'chClientes
        '
        Me.chClientes.AutoSize = True
        Me.chClientes.Location = New System.Drawing.Point(20, 22)
        Me.chClientes.Name = "chClientes"
        Me.chClientes.Size = New System.Drawing.Size(68, 19)
        Me.chClientes.TabIndex = 15
        Me.chClientes.Text = "Clientes"
        Me.chClientes.UseVisualStyleBackColor = True
        '
        'barmigra
        '
        Me.barmigra.Location = New System.Drawing.Point(8, 296)
        Me.barmigra.Name = "barmigra"
        Me.barmigra.Size = New System.Drawing.Size(198, 20)
        Me.barmigra.TabIndex = 16
        '
        'frmMigracion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(215, 222)
        Me.Controls.Add(Me.barmigra)
        Me.Controls.Add(Me.btnmanual)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnauto)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.grdBase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(221, 251)
        Me.Name = "frmMigracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Migración de sistema anterior"
        CType(Me.grdBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents grdBase As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnauto As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnmanual As Button
    Friend WithEvents opfbase As OpenFileDialog
    Friend WithEvents chProductos As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chUsuarios As CheckBox
    Friend WithEvents chProveedores As CheckBox
    Friend WithEvents chClientes As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents barmigra As ProgressBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
