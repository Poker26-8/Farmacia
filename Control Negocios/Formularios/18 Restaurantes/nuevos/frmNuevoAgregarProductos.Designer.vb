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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoAgregarProductos))
        Me.pDepartamento = New System.Windows.Forms.Panel()
        Me.pgrupo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblComensal = New System.Windows.Forms.Label()
        Me.btnComentario = New System.Windows.Forms.Button()
        Me.btn2Tiempo = New System.Windows.Forms.Button()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.btn3Tiempo = New System.Windows.Forms.Button()
        Me.btnDescuento = New System.Windows.Forms.Button()
        Me.btn1Tiempo = New System.Windows.Forms.Button()
        Me.btnComensal = New System.Windows.Forms.Button()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.pProductos = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMesa = New System.Windows.Forms.Label()
        Me.btnElminarTodo = New System.Windows.Forms.Button()
        Me.btnEliminarPro = New System.Windows.Forms.Button()
        Me.btnAumentar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnTeclado = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnComanda = New System.Windows.Forms.Button()
        Me.btnResumen = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblmesero = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 370)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(388, 351)
        Me.grdCaptura.TabIndex = 1
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblComensal)
        Me.Panel3.Controls.Add(Me.btnComentario)
        Me.Panel3.Controls.Add(Me.btn2Tiempo)
        Me.Panel3.Controls.Add(Me.btnElminarTodo)
        Me.Panel3.Controls.Add(Me.btnEliminarPro)
        Me.Panel3.Controls.Add(Me.lblDescuento)
        Me.Panel3.Controls.Add(Me.btn3Tiempo)
        Me.Panel3.Controls.Add(Me.btnDescuento)
        Me.Panel3.Controls.Add(Me.btn1Tiempo)
        Me.Panel3.Controls.Add(Me.btnComensal)
        Me.Panel3.Controls.Add(Me.lblCantidad)
        Me.Panel3.Controls.Add(Me.btnAumentar)
        Me.Panel3.Controls.Add(Me.btnQuitar)
        Me.Panel3.Controls.Add(Me.btnTeclado)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Controls.Add(Me.btnEnviar)
        Me.Panel3.Controls.Add(Me.btnComanda)
        Me.Panel3.Controls.Add(Me.btnResumen)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(388, 370)
        Me.Panel3.TabIndex = 0
        '
        'lblComensal
        '
        Me.lblComensal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComensal.Location = New System.Drawing.Point(12, 200)
        Me.lblComensal.Name = "lblComensal"
        Me.lblComensal.Size = New System.Drawing.Size(79, 35)
        Me.lblComensal.TabIndex = 18
        Me.lblComensal.Text = "1"
        Me.lblComensal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnComentario
        '
        Me.btnComentario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnComentario.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnComentario.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnComentario.Location = New System.Drawing.Point(294, 280)
        Me.btnComentario.Name = "btnComentario"
        Me.btnComentario.Size = New System.Drawing.Size(88, 85)
        Me.btnComentario.TabIndex = 17
        Me.btnComentario.Text = "COMENTARIO"
        Me.btnComentario.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnComentario.UseVisualStyleBackColor = False
        '
        'btn2Tiempo
        '
        Me.btn2Tiempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btn2Tiempo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2Tiempo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn2Tiempo.Location = New System.Drawing.Point(198, 189)
        Me.btn2Tiempo.Name = "btn2Tiempo"
        Me.btn2Tiempo.Size = New System.Drawing.Size(90, 84)
        Me.btn2Tiempo.TabIndex = 15
        Me.btn2Tiempo.Text = "2° TIEMPO"
        Me.btn2Tiempo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn2Tiempo.UseVisualStyleBackColor = False
        '
        'lblDescuento
        '
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(205, 292)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(50, 35)
        Me.lblDescuento.TabIndex = 12
        Me.lblDescuento.Text = "0"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn3Tiempo
        '
        Me.btn3Tiempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btn3Tiempo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3Tiempo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn3Tiempo.Location = New System.Drawing.Point(294, 188)
        Me.btn3Tiempo.Name = "btn3Tiempo"
        Me.btn3Tiempo.Size = New System.Drawing.Size(88, 85)
        Me.btn3Tiempo.TabIndex = 11
        Me.btn3Tiempo.Text = "3° TIEMPO"
        Me.btn3Tiempo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn3Tiempo.UseVisualStyleBackColor = False
        '
        'btnDescuento
        '
        Me.btnDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnDescuento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDescuento.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDescuento.Location = New System.Drawing.Point(198, 281)
        Me.btnDescuento.Name = "btnDescuento"
        Me.btnDescuento.Size = New System.Drawing.Size(90, 84)
        Me.btnDescuento.TabIndex = 10
        Me.btnDescuento.Text = "DESC PRODUCTO"
        Me.btnDescuento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDescuento.UseVisualStyleBackColor = False
        '
        'btn1Tiempo
        '
        Me.btn1Tiempo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btn1Tiempo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1Tiempo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn1Tiempo.Location = New System.Drawing.Point(102, 188)
        Me.btn1Tiempo.Name = "btn1Tiempo"
        Me.btn1Tiempo.Size = New System.Drawing.Size(90, 85)
        Me.btn1Tiempo.TabIndex = 9
        Me.btn1Tiempo.Text = "1° TIEMPO"
        Me.btn1Tiempo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn1Tiempo.UseVisualStyleBackColor = False
        '
        'btnComensal
        '
        Me.btnComensal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnComensal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnComensal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnComensal.Location = New System.Drawing.Point(6, 188)
        Me.btnComensal.Name = "btnComensal"
        Me.btnComensal.Size = New System.Drawing.Size(90, 84)
        Me.btnComensal.TabIndex = 8
        Me.btnComensal.Text = "COMENSAL"
        Me.btnComensal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnComensal.UseVisualStyleBackColor = False
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
        'pProductos
        '
        Me.pProductos.BackColor = System.Drawing.Color.White
        Me.pProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pProductos.Location = New System.Drawing.Point(237, 59)
        Me.pProductos.Name = "pProductos"
        Me.pProductos.Size = New System.Drawing.Size(531, 721)
        Me.pProductos.TabIndex = 8
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 47)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "MESA:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblmesero)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblMesa)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblTotalVenta)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1156, 59)
        Me.Panel1.TabIndex = 0
        '
        'lblMesa
        '
        Me.lblMesa.BackColor = System.Drawing.Color.PeachPuff
        Me.lblMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesa.Location = New System.Drawing.Point(112, 6)
        Me.lblMesa.Name = "lblMesa"
        Me.lblMesa.Size = New System.Drawing.Size(192, 47)
        Me.lblMesa.TabIndex = 3
        Me.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnElminarTodo
        '
        Me.btnElminarTodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnElminarTodo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnElminarTodo.Image = CType(resources.GetObject("btnElminarTodo.Image"), System.Drawing.Image)
        Me.btnElminarTodo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnElminarTodo.Location = New System.Drawing.Point(102, 280)
        Me.btnElminarTodo.Name = "btnElminarTodo"
        Me.btnElminarTodo.Size = New System.Drawing.Size(90, 85)
        Me.btnElminarTodo.TabIndex = 14
        Me.btnElminarTodo.Text = "ELIMINAR TODO"
        Me.btnElminarTodo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnElminarTodo.UseVisualStyleBackColor = False
        '
        'btnEliminarPro
        '
        Me.btnEliminarPro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnEliminarPro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminarPro.Image = CType(resources.GetObject("btnEliminarPro.Image"), System.Drawing.Image)
        Me.btnEliminarPro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarPro.Location = New System.Drawing.Point(6, 280)
        Me.btnEliminarPro.Name = "btnEliminarPro"
        Me.btnEliminarPro.Size = New System.Drawing.Size(90, 84)
        Me.btnEliminarPro.TabIndex = 13
        Me.btnEliminarPro.Text = "ELIMINAR PROD"
        Me.btnEliminarPro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminarPro.UseVisualStyleBackColor = False
        '
        'btnAumentar
        '
        Me.btnAumentar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnAumentar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAumentar.Image = CType(resources.GetObject("btnAumentar.Image"), System.Drawing.Image)
        Me.btnAumentar.Location = New System.Drawing.Point(198, 96)
        Me.btnAumentar.Name = "btnAumentar"
        Me.btnAumentar.Size = New System.Drawing.Size(90, 84)
        Me.btnAumentar.TabIndex = 6
        Me.btnAumentar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAumentar.UseVisualStyleBackColor = False
        '
        'btnQuitar
        '
        Me.btnQuitar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.Location = New System.Drawing.Point(102, 96)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(90, 84)
        Me.btnQuitar.TabIndex = 5
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnQuitar.UseVisualStyleBackColor = False
        '
        'btnTeclado
        '
        Me.btnTeclado.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnTeclado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTeclado.Image = CType(resources.GetObject("btnTeclado.Image"), System.Drawing.Image)
        Me.btnTeclado.Location = New System.Drawing.Point(6, 97)
        Me.btnTeclado.Name = "btnTeclado"
        Me.btnTeclado.Size = New System.Drawing.Size(90, 84)
        Me.btnTeclado.TabIndex = 4
        Me.btnTeclado.Text = "TECLADO"
        Me.btnTeclado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTeclado.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(294, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 84)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnEnviar
        '
        Me.btnEnviar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnviar.Location = New System.Drawing.Point(198, 6)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(90, 84)
        Me.btnEnviar.TabIndex = 2
        Me.btnEnviar.Text = "ENVIAR"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'btnComanda
        '
        Me.btnComanda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnComanda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnComanda.Image = CType(resources.GetObject("btnComanda.Image"), System.Drawing.Image)
        Me.btnComanda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnComanda.Location = New System.Drawing.Point(102, 6)
        Me.btnComanda.Name = "btnComanda"
        Me.btnComanda.Size = New System.Drawing.Size(90, 84)
        Me.btnComanda.TabIndex = 1
        Me.btnComanda.Text = "COMANDA"
        Me.btnComanda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnComanda.UseVisualStyleBackColor = False
        '
        'btnResumen
        '
        Me.btnResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.btnResumen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResumen.Image = CType(resources.GetObject("btnResumen.Image"), System.Drawing.Image)
        Me.btnResumen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnResumen.Location = New System.Drawing.Point(6, 6)
        Me.btnResumen.Name = "btnResumen"
        Me.btnResumen.Size = New System.Drawing.Size(90, 84)
        Me.btnResumen.TabIndex = 0
        Me.btnResumen.Text = "RESUMEN"
        Me.btnResumen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnResumen.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(259, 292)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 35)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "%"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(310, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 47)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Mesero:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblmesero
        '
        Me.lblmesero.BackColor = System.Drawing.Color.PeachPuff
        Me.lblmesero.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesero.Location = New System.Drawing.Point(422, 6)
        Me.lblmesero.Name = "lblmesero"
        Me.lblmesero.Size = New System.Drawing.Size(190, 47)
        Me.lblmesero.TabIndex = 5
        Me.lblmesero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pDepartamento As Panel
    Friend WithEvents pgrupo As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pProductos As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnComanda As Button
    Friend WithEvents btnResumen As Button
    Friend WithEvents btn1Tiempo As Button
    Friend WithEvents btnComensal As Button
    Friend WithEvents lblCantidad As Label
    Friend WithEvents btnAumentar As Button
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnTeclado As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblDescuento As Label
    Friend WithEvents btn3Tiempo As Button
    Friend WithEvents btnDescuento As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents btnComentario As Button
    Friend WithEvents btn2Tiempo As Button
    Friend WithEvents btnElminarTodo As Button
    Friend WithEvents btnEliminarPro As Button
    Friend WithEvents lblComensal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblMesa As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblmesero As Label
    Friend WithEvents Label4 As Label
End Class
