<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoAgregarProductos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoAgregarProductos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pDepartamento = New System.Windows.Forms.Panel()
        Me.pgrupo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pProductos = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTotalVenta)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1156, 59)
        Me.Panel1.TabIndex = 0
        '
        'pDepartamento
        '
        Me.pDepartamento.AutoScroll = True
        Me.pDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pDepartamento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pDepartamento.Location = New System.Drawing.Point(0, 59)
        Me.pDepartamento.Name = "pDepartamento"
        Me.pDepartamento.Size = New System.Drawing.Size(112, 721)
        Me.pDepartamento.TabIndex = 5
        '
        'pgrupo
        '
        Me.pgrupo.AutoScroll = True
        Me.pgrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.pgrupo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgrupo.Location = New System.Drawing.Point(112, 59)
        Me.pgrupo.Name = "pgrupo"
        Me.pgrupo.Size = New System.Drawing.Size(125, 721)
        Me.pgrupo.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdCaptura)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(768, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(388, 721)
        Me.Panel2.TabIndex = 7
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle5
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 370)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(388, 351)
        Me.grdCaptura.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Button15)
        Me.Panel3.Controls.Add(Me.Button14)
        Me.Panel3.Controls.Add(Me.Button13)
        Me.Panel3.Controls.Add(Me.Button12)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Button11)
        Me.Panel3.Controls.Add(Me.Button10)
        Me.Panel3.Controls.Add(Me.Button9)
        Me.Panel3.Controls.Add(Me.Button8)
        Me.Panel3.Controls.Add(Me.lblCantidad)
        Me.Panel3.Controls.Add(Me.Button7)
        Me.Panel3.Controls.Add(Me.Button6)
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(388, 370)
        Me.Panel3.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(198, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 84)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "CANCELAR"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(102, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 84)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "COMANDA"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 84)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "RESUMEN"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pProductos
        '
        Me.pProductos.BackColor = System.Drawing.Color.White
        Me.pProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pProductos.Location = New System.Drawing.Point(237, 59)
        Me.pProductos.Name = "pProductos"
        Me.pProductos.Size = New System.Drawing.Size(531, 721)
        Me.pProductos.TabIndex = 8
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(294, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 84)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "CANCELAR"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.Location = New System.Drawing.Point(6, 97)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(90, 84)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "TECLADO"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.Location = New System.Drawing.Point(102, 96)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(90, 84)
        Me.Button6.TabIndex = 5
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.Location = New System.Drawing.Point(198, 96)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(90, 84)
        Me.Button7.TabIndex = 6
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.UseVisualStyleBackColor = False
        '
        'lblCantidad
        '
        Me.lblCantidad.BackColor = System.Drawing.Color.MistyRose
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(294, 96)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(88, 84)
        Me.lblCantidad.TabIndex = 7
        Me.lblCantidad.Text = "1.00"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button8.Location = New System.Drawing.Point(6, 188)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(90, 84)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "COMENSAL"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button9.Location = New System.Drawing.Point(102, 188)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(90, 85)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "1° TIEMPO"
        Me.Button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button10.Location = New System.Drawing.Point(198, 281)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(90, 84)
        Me.Button10.TabIndex = 10
        Me.Button10.Text = "DESC PRODUCTO"
        Me.Button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button11.Location = New System.Drawing.Point(294, 188)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(88, 85)
        Me.Button11.TabIndex = 11
        Me.Button11.Text = "3° TIEMPO"
        Me.Button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 35)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "0"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 65
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Desc"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 57
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Cant"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 54
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "P.U."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 53
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Desc"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 57
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 56
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column6.HeaderText = "Com"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 53
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column7.HeaderText = "PEP"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 53
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Comen"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 65
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button12.Image = CType(resources.GetObject("Button12.Image"), System.Drawing.Image)
        Me.Button12.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button12.Location = New System.Drawing.Point(6, 280)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(90, 84)
        Me.Button12.TabIndex = 13
        Me.Button12.Text = "ELIMINAR PROD"
        Me.Button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.Image = CType(resources.GetObject("Button13.Image"), System.Drawing.Image)
        Me.Button13.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button13.Location = New System.Drawing.Point(102, 280)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(90, 85)
        Me.Button13.TabIndex = 14
        Me.Button13.Text = "ELIMINAR TODO"
        Me.Button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button14.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button14.Location = New System.Drawing.Point(198, 189)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(90, 84)
        Me.Button14.TabIndex = 15
        Me.Button14.Text = "2° TIEMPO"
        Me.Button14.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button15.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button15.Location = New System.Drawing.Point(294, 280)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(88, 85)
        Me.Button15.TabIndex = 17
        Me.Button15.Text = "COMENTARIO"
        Me.Button15.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(850, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 47)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "TOTAL:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.PeachPuff
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.Location = New System.Drawing.Point(966, 9)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(186, 47)
        Me.lblTotalVenta.TabIndex = 1
        Me.lblTotalVenta.Text = "0.00"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmNuevoAgregarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1156, 780)
        Me.Controls.Add(Me.pProductos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pgrupo)
        Me.Controls.Add(Me.pDepartamento)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNuevoAgregarProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Agrega rProductos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pDepartamento As Panel
    Friend WithEvents pgrupo As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pProductos As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents lblCantidad As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Button15 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents Label3 As Label
End Class
