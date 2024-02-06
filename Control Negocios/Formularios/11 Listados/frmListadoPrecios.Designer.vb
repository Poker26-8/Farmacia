<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoPrecios))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.opttodos = New System.Windows.Forms.RadioButton()
        Me.optgrupo = New System.Windows.Forms.RadioButton()
        Me.optdepto = New System.Windows.Forms.RadioButton()
        Me.optproveedores = New System.Windows.Forms.RadioButton()
        Me.cbofiltro = New System.Windows.Forms.ComboBox()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.optord_nombre = New System.Windows.Forms.RadioButton()
        Me.optord_depto = New System.Windows.Forms.RadioButton()
        Me.optord_grupo = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCod = New System.Windows.Forms.TextBox()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnimportar = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblprod = New System.Windows.Forms.Label()
        Me.grdimporta = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.grdimporta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(867, 31)
        Me.Label1.TabIndex = 230
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.opttodos)
        Me.GroupBox1.Controls.Add(Me.optgrupo)
        Me.GroupBox1.Controls.Add(Me.optdepto)
        Me.GroupBox1.Controls.Add(Me.optproveedores)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 113)
        Me.GroupBox1.TabIndex = 231
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
        'optdepto
        '
        Me.optdepto.AutoSize = True
        Me.optdepto.Location = New System.Drawing.Point(8, 38)
        Me.optdepto.Name = "optdepto"
        Me.optdepto.Size = New System.Drawing.Size(101, 19)
        Me.optdepto.TabIndex = 58
        Me.optdepto.TabStop = True
        Me.optdepto.Text = "Departamento"
        Me.optdepto.UseVisualStyleBackColor = True
        '
        'optproveedores
        '
        Me.optproveedores.AutoSize = True
        Me.optproveedores.Location = New System.Drawing.Point(8, 14)
        Me.optproveedores.Name = "optproveedores"
        Me.optproveedores.Size = New System.Drawing.Size(90, 19)
        Me.optproveedores.TabIndex = 57
        Me.optproveedores.TabStop = True
        Me.optproveedores.Text = "Proveedores"
        Me.optproveedores.UseVisualStyleBackColor = True
        '
        'cbofiltro
        '
        Me.cbofiltro.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbofiltro.FormattingEnabled = True
        Me.cbofiltro.Location = New System.Drawing.Point(230, 121)
        Me.cbofiltro.Name = "cbofiltro"
        Me.cbofiltro.Size = New System.Drawing.Size(215, 25)
        Me.cbofiltro.TabIndex = 238
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
        Me.grdcaptura.RowTemplate.Height = 25
        Me.grdcaptura.Size = New System.Drawing.Size(848, 304)
        Me.grdcaptura.TabIndex = 239
        '
        'optord_nombre
        '
        Me.optord_nombre.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_nombre.AutoSize = True
        Me.optord_nombre.Location = New System.Drawing.Point(141, 466)
        Me.optord_nombre.Name = "optord_nombre"
        Me.optord_nombre.Size = New System.Drawing.Size(134, 19)
        Me.optord_nombre.TabIndex = 240
        Me.optord_nombre.TabStop = True
        Me.optord_nombre.Text = "Ordenar por nombre"
        Me.optord_nombre.UseVisualStyleBackColor = True
        '
        'optord_depto
        '
        Me.optord_depto.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_depto.AutoSize = True
        Me.optord_depto.Location = New System.Drawing.Point(355, 466)
        Me.optord_depto.Name = "optord_depto"
        Me.optord_depto.Size = New System.Drawing.Size(167, 19)
        Me.optord_depto.TabIndex = 241
        Me.optord_depto.TabStop = True
        Me.optord_depto.Text = "Ordenar por departamento"
        Me.optord_depto.UseVisualStyleBackColor = True
        '
        'optord_grupo
        '
        Me.optord_grupo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.optord_grupo.AutoSize = True
        Me.optord_grupo.Location = New System.Drawing.Point(602, 466)
        Me.optord_grupo.Name = "optord_grupo"
        Me.optord_grupo.Size = New System.Drawing.Size(124, 19)
        Me.optord_grupo.TabIndex = 242
        Me.optord_grupo.TabStop = True
        Me.optord_grupo.Text = "Ordenar por grupo"
        Me.optord_grupo.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtCod)
        Me.GroupBox3.Location = New System.Drawing.Point(230, 34)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(104, 66)
        Me.GroupBox3.TabIndex = 243
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
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.BackgroundImage = CType(resources.GetObject("btnexportar.BackgroundImage"), System.Drawing.Image)
        Me.btnexportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Location = New System.Drawing.Point(687, 45)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(82, 63)
        Me.btnexportar.TabIndex = 247
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnimportar
        '
        Me.btnimportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnimportar.BackgroundImage = CType(resources.GetObject("btnimportar.BackgroundImage"), System.Drawing.Image)
        Me.btnimportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnimportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnimportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnimportar.Location = New System.Drawing.Point(775, 45)
        Me.btnimportar.Name = "btnimportar"
        Me.btnimportar.Size = New System.Drawing.Size(82, 63)
        Me.btnimportar.TabIndex = 246
        Me.btnimportar.Text = "Importar"
        Me.btnimportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnimportar.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 434)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(848, 23)
        Me.ProgressBar1.TabIndex = 248
        Me.ProgressBar1.Visible = False
        '
        'lblprod
        '
        Me.lblprod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblprod.Location = New System.Drawing.Point(11, 416)
        Me.lblprod.Name = "lblprod"
        Me.lblprod.Size = New System.Drawing.Size(436, 18)
        Me.lblprod.TabIndex = 249
        Me.lblprod.Text = "Label2"
        Me.lblprod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblprod.Visible = False
        '
        'grdimporta
        '
        Me.grdimporta.AllowUserToAddRows = False
        Me.grdimporta.AllowUserToDeleteRows = False
        Me.grdimporta.BackgroundColor = System.Drawing.Color.White
        Me.grdimporta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdimporta.GridColor = System.Drawing.Color.White
        Me.grdimporta.Location = New System.Drawing.Point(463, 204)
        Me.grdimporta.Name = "grdimporta"
        Me.grdimporta.ReadOnly = True
        Me.grdimporta.Size = New System.Drawing.Size(386, 188)
        Me.grdimporta.TabIndex = 250
        '
        'frmListadoPrecios
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(867, 492)
        Me.Controls.Add(Me.lblprod)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.btnimportar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.optord_grupo)
        Me.Controls.Add(Me.optord_depto)
        Me.Controls.Add(Me.optord_nombre)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.cbofiltro)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdimporta)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListadoPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de precios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.grdimporta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents opttodos As System.Windows.Forms.RadioButton
    Friend WithEvents optgrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optdepto As System.Windows.Forms.RadioButton
    Friend WithEvents optproveedores As System.Windows.Forms.RadioButton
    Friend WithEvents cbofiltro As System.Windows.Forms.ComboBox
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents optord_nombre As System.Windows.Forms.RadioButton
    Friend WithEvents optord_depto As System.Windows.Forms.RadioButton
    Friend WithEvents optord_grupo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents btnimportar As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblprod As System.Windows.Forms.Label
    Friend WithEvents grdimporta As System.Windows.Forms.DataGridView
End Class
