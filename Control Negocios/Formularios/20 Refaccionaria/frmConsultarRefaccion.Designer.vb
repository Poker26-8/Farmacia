<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultarRefaccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultarRefaccion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PSuperior = New System.Windows.Forms.Panel()
        Me.cboMotor = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cboModelo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboaño = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdProductos = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDerecha = New System.Windows.Forms.Panel()
        Me.PicProducto = New System.Windows.Forms.PictureBox()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PSuperior.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PDerecha.SuspendLayout()
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PSuperior
        '
        Me.PSuperior.Controls.Add(Me.cboMotor)
        Me.PSuperior.Controls.Add(Me.Label5)
        Me.PSuperior.Controls.Add(Me.Panel1)
        Me.PSuperior.Controls.Add(Me.Button3)
        Me.PSuperior.Controls.Add(Me.btnLimpiar)
        Me.PSuperior.Controls.Add(Me.cboModelo)
        Me.PSuperior.Controls.Add(Me.Label3)
        Me.PSuperior.Controls.Add(Me.cboMarca)
        Me.PSuperior.Controls.Add(Me.Label2)
        Me.PSuperior.Controls.Add(Me.cboaño)
        Me.PSuperior.Controls.Add(Me.Label1)
        Me.PSuperior.Controls.Add(Me.btnClose)
        Me.PSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PSuperior.Name = "PSuperior"
        Me.PSuperior.Size = New System.Drawing.Size(928, 124)
        Me.PSuperior.TabIndex = 0
        '
        'cboMotor
        '
        Me.cboMotor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMotor.FormattingEnabled = True
        Me.cboMotor.Location = New System.Drawing.Point(419, 71)
        Me.cboMotor.Name = "cboMotor"
        Me.cboMotor.Size = New System.Drawing.Size(253, 24)
        Me.cboMotor.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(419, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(253, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Motor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 36)
        Me.Panel1.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(928, 36)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Buscar Refacción"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(679, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 74)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Buscar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(760, 42)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 74)
        Me.btnLimpiar.TabIndex = 7
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'cboModelo
        '
        Me.cboModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModelo.FormattingEnabled = True
        Me.cboModelo.Location = New System.Drawing.Point(245, 71)
        Me.cboModelo.Name = "cboModelo"
        Me.cboModelo.Size = New System.Drawing.Size(167, 24)
        Me.cboModelo.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Modelo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboMarca
        '
        Me.cboMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMarca.FormattingEnabled = True
        Me.cboMarca.Location = New System.Drawing.Point(85, 71)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(153, 24)
        Me.cboMarca.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Marca"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboaño
        '
        Me.cboaño.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboaño.FormattingEnabled = True
        Me.cboaño.Location = New System.Drawing.Point(5, 71)
        Me.cboaño.Name = "cboaño"
        Me.cboaño.Size = New System.Drawing.Size(73, 24)
        Me.cboaño.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Año"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClose.Location = New System.Drawing.Point(841, 42)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 74)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Salir"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdProductos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 124)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(608, 375)
        Me.Panel2.TabIndex = 1
        '
        'grdProductos
        '
        Me.grdProductos.AllowUserToAddRows = False
        Me.grdProductos.AllowUserToDeleteRows = False
        Me.grdProductos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Location = New System.Drawing.Point(0, 0)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.ReadOnly = True
        Me.grdProductos.RowHeadersVisible = False
        Me.grdProductos.Size = New System.Drawing.Size(608, 375)
        Me.grdProductos.TabIndex = 0
        '
        'Column6
        '
        Me.Column6.HeaderText = "Codigo"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Num Parte"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 113
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 85
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Precio"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 82
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Observaciones"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 146
        '
        'PDerecha
        '
        Me.PDerecha.Controls.Add(Me.PicProducto)
        Me.PDerecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.PDerecha.Location = New System.Drawing.Point(608, 124)
        Me.PDerecha.Name = "PDerecha"
        Me.PDerecha.Size = New System.Drawing.Size(320, 375)
        Me.PDerecha.TabIndex = 2
        '
        'PicProducto
        '
        Me.PicProducto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicProducto.Location = New System.Drawing.Point(0, 0)
        Me.PicProducto.Name = "PicProducto"
        Me.PicProducto.Size = New System.Drawing.Size(320, 375)
        Me.PicProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProducto.TabIndex = 57
        Me.PicProducto.TabStop = False
        Me.PicProducto.Visible = False
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'frmConsultarRefaccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(928, 499)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PDerecha)
        Me.Controls.Add(Me.PSuperior)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultarRefaccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Refacciones"
        Me.PSuperior.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PDerecha.ResumeLayout(False)
        CType(Me.PicProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PSuperior As Panel
    Friend WithEvents cboaño As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents cboModelo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboMarca As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdProductos As DataGridView
    Friend WithEvents PDerecha As Panel
    Public WithEvents PicProducto As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents cboMotor As ComboBox
    Friend WithEvents Label5 As Label
End Class
