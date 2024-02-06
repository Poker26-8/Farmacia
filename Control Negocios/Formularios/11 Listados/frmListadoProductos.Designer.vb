<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoProductos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.optord_grupo = New System.Windows.Forms.RadioButton()
        Me.optord_depto = New System.Windows.Forms.RadioButton()
        Me.optord_nombre = New System.Windows.Forms.RadioButton()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.cbofiltro = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.opttodos = New System.Windows.Forms.RadioButton()
        Me.optgrupo = New System.Windows.Forms.RadioButton()
        Me.optdepartamento = New System.Windows.Forms.RadioButton()
        Me.optproveedor = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bardatos = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.BackgroundImage = CType(resources.GetObject("btnexportar.BackgroundImage"), System.Drawing.Image)
        Me.btnexportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Location = New System.Drawing.Point(781, 48)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(82, 63)
        Me.btnexportar.TabIndex = 258
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtCod)
        Me.GroupBox3.Location = New System.Drawing.Point(230, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(104, 66)
        Me.GroupBox3.TabIndex = 255
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Omitir los códigos que contengan:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCod
        '
        Me.txtCod.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCod.Location = New System.Drawing.Point(5, 39)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(94, 22)
        Me.txtCod.TabIndex = 0
        '
        'optord_grupo
        '
        Me.optord_grupo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_grupo.AutoSize = True
        Me.optord_grupo.Location = New System.Drawing.Point(605, 491)
        Me.optord_grupo.Name = "optord_grupo"
        Me.optord_grupo.Size = New System.Drawing.Size(124, 19)
        Me.optord_grupo.TabIndex = 254
        Me.optord_grupo.TabStop = True
        Me.optord_grupo.Text = "Ordenar por grupo"
        Me.optord_grupo.UseVisualStyleBackColor = True
        '
        'optord_depto
        '
        Me.optord_depto.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_depto.AutoSize = True
        Me.optord_depto.Location = New System.Drawing.Point(358, 491)
        Me.optord_depto.Name = "optord_depto"
        Me.optord_depto.Size = New System.Drawing.Size(167, 19)
        Me.optord_depto.TabIndex = 253
        Me.optord_depto.TabStop = True
        Me.optord_depto.Text = "Ordenar por departamento"
        Me.optord_depto.UseVisualStyleBackColor = True
        '
        'optord_nombre
        '
        Me.optord_nombre.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_nombre.AutoSize = True
        Me.optord_nombre.Location = New System.Drawing.Point(144, 491)
        Me.optord_nombre.Name = "optord_nombre"
        Me.optord_nombre.Size = New System.Drawing.Size(134, 19)
        Me.optord_nombre.TabIndex = 252
        Me.optord_nombre.TabStop = True
        Me.optord_nombre.Text = "Ordenar por nombre"
        Me.optord_nombre.UseVisualStyleBackColor = True
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(9, 153)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.RowTemplate.Height = 24
        Me.grdcaptura.Size = New System.Drawing.Size(854, 328)
        Me.grdcaptura.TabIndex = 251
        '
        'cbofiltro
        '
        Me.cbofiltro.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofiltro.FormattingEnabled = True
        Me.cbofiltro.Location = New System.Drawing.Point(230, 122)
        Me.cbofiltro.Name = "cbofiltro"
        Me.cbofiltro.Size = New System.Drawing.Size(249, 25)
        Me.cbofiltro.TabIndex = 250
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.opttodos)
        Me.GroupBox1.Controls.Add(Me.optgrupo)
        Me.GroupBox1.Controls.Add(Me.optdepartamento)
        Me.GroupBox1.Controls.Add(Me.optproveedor)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 113)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        '
        'opttodos
        '
        Me.opttodos.AutoSize = True
        Me.opttodos.Location = New System.Drawing.Point(8, 86)
        Me.opttodos.Name = "opttodos"
        Me.opttodos.Size = New System.Drawing.Size(149, 19)
        Me.opttodos.TabIndex = 60
        Me.opttodos.TabStop = True
        Me.opttodos.Text = "Ver todos los productos"
        Me.opttodos.UseVisualStyleBackColor = True
        '
        'optgrupo
        '
        Me.optgrupo.AutoSize = True
        Me.optgrupo.Location = New System.Drawing.Point(8, 62)
        Me.optgrupo.Name = "optgrupo"
        Me.optgrupo.Size = New System.Drawing.Size(58, 19)
        Me.optgrupo.TabIndex = 59
        Me.optgrupo.TabStop = True
        Me.optgrupo.Text = "Grupo"
        Me.optgrupo.UseVisualStyleBackColor = True
        '
        'optdepartamento
        '
        Me.optdepartamento.AutoSize = True
        Me.optdepartamento.Location = New System.Drawing.Point(8, 38)
        Me.optdepartamento.Name = "optdepartamento"
        Me.optdepartamento.Size = New System.Drawing.Size(101, 19)
        Me.optdepartamento.TabIndex = 58
        Me.optdepartamento.TabStop = True
        Me.optdepartamento.Text = "Departamento"
        Me.optdepartamento.UseVisualStyleBackColor = True
        '
        'optproveedor
        '
        Me.optproveedor.AutoSize = True
        Me.optproveedor.Location = New System.Drawing.Point(8, 14)
        Me.optproveedor.Name = "optproveedor"
        Me.optproveedor.Size = New System.Drawing.Size(90, 19)
        Me.optproveedor.TabIndex = 57
        Me.optproveedor.TabStop = True
        Me.optproveedor.Text = "Proveedores"
        Me.optproveedor.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(873, 31)
        Me.Label1.TabIndex = 248
        Me.Label1.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bardatos
        '
        Me.bardatos.Location = New System.Drawing.Point(9, 458)
        Me.bardatos.Name = "bardatos"
        Me.bardatos.Size = New System.Drawing.Size(854, 23)
        Me.bardatos.TabIndex = 261
        Me.bardatos.Visible = False
        '
        'frmListadoProductos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(873, 516)
        Me.Controls.Add(Me.bardatos)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.optord_grupo)
        Me.Controls.Add(Me.optord_depto)
        Me.Controls.Add(Me.optord_nombre)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.cbofiltro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de productos"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents optord_grupo As System.Windows.Forms.RadioButton
    Friend WithEvents optord_depto As System.Windows.Forms.RadioButton
    Friend WithEvents optord_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents cbofiltro As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents opttodos As System.Windows.Forms.RadioButton
    Friend WithEvents optgrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optdepartamento As System.Windows.Forms.RadioButton
    Friend WithEvents optproveedor As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bardatos As System.Windows.Forms.ProgressBar
End Class
