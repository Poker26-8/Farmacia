<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscaPedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscaPedidos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.optproveedor = New System.Windows.Forms.RadioButton()
        Me.boxsalidas = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpTermina = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpInicia = New System.Windows.Forms.DateTimePicker()
        Me.optdepartamento = New System.Windows.Forms.RadioButton()
        Me.optgrupo = New System.Windows.Forms.RadioButton()
        Me.optcoincide = New System.Windows.Forms.RadioButton()
        Me.cboprod = New System.Windows.Forms.ComboBox()
        Me.txtprod = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.optsalidas = New System.Windows.Forms.RadioButton()
        Me.barCuenta = New System.Windows.Forms.ProgressBar()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.boxsalidas.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(688, 31)
        Me.Label1.TabIndex = 100
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(7, 155)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(674, 294)
        Me.grdcaptura.TabIndex = 101
        '
        'optproveedor
        '
        Me.optproveedor.AutoSize = True
        Me.optproveedor.Location = New System.Drawing.Point(12, 43)
        Me.optproveedor.Name = "optproveedor"
        Me.optproveedor.Size = New System.Drawing.Size(79, 19)
        Me.optproveedor.TabIndex = 102
        Me.optproveedor.TabStop = True
        Me.optproveedor.Text = "Proveedor"
        Me.optproveedor.UseVisualStyleBackColor = True
        '
        'boxsalidas
        '
        Me.boxsalidas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boxsalidas.Controls.Add(Me.Label3)
        Me.boxsalidas.Controls.Add(Me.dtpTermina)
        Me.boxsalidas.Controls.Add(Me.Label2)
        Me.boxsalidas.Controls.Add(Me.dtpInicia)
        Me.boxsalidas.Enabled = False
        Me.boxsalidas.Location = New System.Drawing.Point(446, 34)
        Me.boxsalidas.Name = "boxsalidas"
        Me.boxsalidas.Size = New System.Drawing.Size(235, 115)
        Me.boxsalidas.TabIndex = 103
        Me.boxsalidas.TabStop = False
        Me.boxsalidas.Text = "Salidas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Final:"
        '
        'dtpTermina
        '
        Me.dtpTermina.Location = New System.Drawing.Point(6, 84)
        Me.dtpTermina.Name = "dtpTermina"
        Me.dtpTermina.Size = New System.Drawing.Size(223, 23)
        Me.dtpTermina.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Inicio:"
        '
        'dtpInicia
        '
        Me.dtpInicia.Location = New System.Drawing.Point(6, 37)
        Me.dtpInicia.Name = "dtpInicia"
        Me.dtpInicia.Size = New System.Drawing.Size(223, 23)
        Me.dtpInicia.TabIndex = 0
        '
        'optdepartamento
        '
        Me.optdepartamento.AutoSize = True
        Me.optdepartamento.Location = New System.Drawing.Point(119, 43)
        Me.optdepartamento.Name = "optdepartamento"
        Me.optdepartamento.Size = New System.Drawing.Size(101, 19)
        Me.optdepartamento.TabIndex = 104
        Me.optdepartamento.TabStop = True
        Me.optdepartamento.Text = "Departamento"
        Me.optdepartamento.UseVisualStyleBackColor = True
        '
        'optgrupo
        '
        Me.optgrupo.AutoSize = True
        Me.optgrupo.Location = New System.Drawing.Point(12, 68)
        Me.optgrupo.Name = "optgrupo"
        Me.optgrupo.Size = New System.Drawing.Size(58, 19)
        Me.optgrupo.TabIndex = 105
        Me.optgrupo.TabStop = True
        Me.optgrupo.Text = "Grupo"
        Me.optgrupo.UseVisualStyleBackColor = True
        '
        'optcoincide
        '
        Me.optcoincide.AutoSize = True
        Me.optcoincide.Location = New System.Drawing.Point(12, 93)
        Me.optcoincide.Name = "optcoincide"
        Me.optcoincide.Size = New System.Drawing.Size(99, 19)
        Me.optcoincide.TabIndex = 106
        Me.optcoincide.TabStop = True
        Me.optcoincide.Text = "Coincidencias"
        Me.optcoincide.UseVisualStyleBackColor = True
        '
        'cboprod
        '
        Me.cboprod.Enabled = False
        Me.cboprod.FormattingEnabled = True
        Me.cboprod.Location = New System.Drawing.Point(7, 126)
        Me.cboprod.Name = "cboprod"
        Me.cboprod.Size = New System.Drawing.Size(218, 23)
        Me.cboprod.TabIndex = 107
        '
        'txtprod
        '
        Me.txtprod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtprod.Enabled = False
        Me.txtprod.Location = New System.Drawing.Point(231, 126)
        Me.txtprod.Name = "txtprod"
        Me.txtprod.Size = New System.Drawing.Size(209, 23)
        Me.txtprod.TabIndex = 108
        '
        'Button6
        '
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button6.Location = New System.Drawing.Point(312, 43)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.Button6.Size = New System.Drawing.Size(61, 77)
        Me.Button6.TabIndex = 153
        Me.Button6.Text = "Limpiar"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(379, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(61, 77)
        Me.Button2.TabIndex = 152
        Me.Button2.Text = "Reporte"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'optsalidas
        '
        Me.optsalidas.AutoSize = True
        Me.optsalidas.Location = New System.Drawing.Point(119, 68)
        Me.optsalidas.Name = "optsalidas"
        Me.optsalidas.Size = New System.Drawing.Size(61, 19)
        Me.optsalidas.TabIndex = 154
        Me.optsalidas.TabStop = True
        Me.optsalidas.Text = "Salidas"
        Me.optsalidas.UseVisualStyleBackColor = True
        '
        'barCuenta
        '
        Me.barCuenta.Location = New System.Drawing.Point(7, 426)
        Me.barCuenta.Name = "barCuenta"
        Me.barCuenta.Size = New System.Drawing.Size(674, 23)
        Me.barCuenta.TabIndex = 155
        Me.barCuenta.Visible = False
        '
        'frmBuscaPedidos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(688, 458)
        Me.Controls.Add(Me.barCuenta)
        Me.Controls.Add(Me.optsalidas)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtprod)
        Me.Controls.Add(Me.cboprod)
        Me.Controls.Add(Me.optcoincide)
        Me.Controls.Add(Me.optgrupo)
        Me.Controls.Add(Me.optdepartamento)
        Me.Controls.Add(Me.boxsalidas)
        Me.Controls.Add(Me.optproveedor)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscaPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de productos"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.boxsalidas.ResumeLayout(False)
        Me.boxsalidas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents optproveedor As System.Windows.Forms.RadioButton
    Friend WithEvents boxsalidas As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpTermina As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpInicia As System.Windows.Forms.DateTimePicker
    Friend WithEvents optdepartamento As System.Windows.Forms.RadioButton
    Friend WithEvents optgrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optcoincide As System.Windows.Forms.RadioButton
    Friend WithEvents cboprod As System.Windows.Forms.ComboBox
    Friend WithEvents txtprod As System.Windows.Forms.TextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents optsalidas As System.Windows.Forms.RadioButton
    Friend WithEvents barCuenta As System.Windows.Forms.ProgressBar
End Class
