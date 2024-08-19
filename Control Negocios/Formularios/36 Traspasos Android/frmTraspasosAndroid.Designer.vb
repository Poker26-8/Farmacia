<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraspasosAndroid
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspasosAndroid))
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgProd = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cboFolio = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_exist = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCodigo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.lblconexion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevoProd = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnReportes
        '
        Me.btnReportes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReportes.Location = New System.Drawing.Point(471, 577)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(81, 68)
        Me.btnReportes.TabIndex = 83
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(384, 577)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 68)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "Asignar Usuarios a Sucursal"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(297, 577)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 68)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "Catalogo de sucursales"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.txtTotal)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(566, 579)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(139, 66)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total Prod."
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(11, 26)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(117, 24)
        Me.txtTotal.TabIndex = 104
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgProd)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(18, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(690, 296)
        Me.GroupBox2.TabIndex = 76
        Me.GroupBox2.TabStop = False
        '
        'dgProd
        '
        Me.dgProd.AllowUserToAddRows = False
        Me.dgProd.BackgroundColor = System.Drawing.Color.White
        Me.dgProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column8})
        Me.dgProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProd.Location = New System.Drawing.Point(3, 20)
        Me.dgProd.Name = "dgProd"
        Me.dgProd.ReadOnly = True
        Me.dgProd.RowHeadersVisible = False
        Me.dgProd.Size = New System.Drawing.Size(684, 273)
        Me.dgProd.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "Código"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 81
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 112
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column8.HeaderText = "Cantidad"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 91
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox11.Controls.Add(Me.cboFolio)
        Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox11.ForeColor = System.Drawing.Color.Black
        Me.GroupBox11.Location = New System.Drawing.Point(589, 34)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(119, 58)
        Me.GroupBox11.TabIndex = 75
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Fol. Cons."
        '
        'cboFolio
        '
        Me.cboFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFolio.FormattingEnabled = True
        Me.cboFolio.Location = New System.Drawing.Point(9, 22)
        Me.cboFolio.Name = "cboFolio"
        Me.cboFolio.Size = New System.Drawing.Size(100, 26)
        Me.cboFolio.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbl_exist)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboProducto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboCodigo)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(18, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(690, 107)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Productos"
        '
        'lbl_exist
        '
        Me.lbl_exist.AutoSize = True
        Me.lbl_exist.Font = New System.Drawing.Font("Modern No. 20", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_exist.ForeColor = System.Drawing.Color.Black
        Me.lbl_exist.Location = New System.Drawing.Point(331, 66)
        Me.lbl_exist.Name = "lbl_exist"
        Me.lbl_exist.Size = New System.Drawing.Size(0, 24)
        Me.lbl_exist.TabIndex = 104
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(94, 66)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(117, 24)
        Me.txtCantidad.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 18)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Cantidad:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(244, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 18)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Exitencia:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cboProducto
        '
        Me.cboProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(328, 27)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(348, 26)
        Me.cboProducto.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(219, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 18)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Descripción:"
        '
        'cboCodigo
        '
        Me.cboCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodigo.FormattingEnabled = True
        Me.cboCodigo.Location = New System.Drawing.Point(94, 27)
        Me.cboCodigo.Name = "cboCodigo"
        Me.cboCodigo.Size = New System.Drawing.Size(117, 26)
        Me.cboCodigo.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(11, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 18)
        Me.Label23.TabIndex = 39
        Me.Label23.Text = "Código:"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.cboRuta)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(18, 88)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(690, 58)
        Me.GroupBox6.TabIndex = 73
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Sucursal"
        '
        'cboRuta
        '
        Me.cboRuta.BackColor = System.Drawing.Color.White
        Me.cboRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.FormattingEnabled = True
        Me.cboRuta.Location = New System.Drawing.Point(14, 22)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(401, 26)
        Me.cboRuta.TabIndex = 0
        '
        'lblconexion
        '
        Me.lblconexion.AutoSize = True
        Me.lblconexion.BackColor = System.Drawing.Color.Transparent
        Me.lblconexion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconexion.ForeColor = System.Drawing.Color.Black
        Me.lblconexion.Location = New System.Drawing.Point(15, 50)
        Me.lblconexion.Name = "lblconexion"
        Me.lblconexion.Size = New System.Drawing.Size(75, 16)
        Me.lblconexion.TabIndex = 72
        Me.lblconexion.Text = "Conexión:"
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
        Me.Label1.Size = New System.Drawing.Size(720, 31)
        Me.Label1.TabIndex = 71
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(199, 577)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(81, 68)
        Me.btnSalir.TabIndex = 80
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnGuardar.FlatAppearance.BorderSize = 10
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.Color.Black
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(111, 577)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(81, 68)
        Me.btnGuardar.TabIndex = 78
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnNuevoProd
        '
        Me.btnNuevoProd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNuevoProd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoProd.ForeColor = System.Drawing.Color.Black
        Me.btnNuevoProd.Image = CType(resources.GetObject("btnNuevoProd.Image"), System.Drawing.Image)
        Me.btnNuevoProd.Location = New System.Drawing.Point(22, 577)
        Me.btnNuevoProd.Name = "btnNuevoProd"
        Me.btnNuevoProd.Size = New System.Drawing.Size(81, 68)
        Me.btnNuevoProd.TabIndex = 79
        Me.btnNuevoProd.Text = "Limpiar"
        Me.btnNuevoProd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevoProd.UseVisualStyleBackColor = False
        '
        'frmTraspasosAndroid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(720, 670)
        Me.Controls.Add(Me.btnReportes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevoProd)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.lblconexion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTraspasosAndroid"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTraspasosAndroid"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnReportes As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevoProd As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgProd As DataGridView
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents cboFolio As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbl_exist As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCodigo As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cboRuta As ComboBox
    Friend WithEvents lblconexion As Label
    Friend WithEvents Label1 As Label
End Class
