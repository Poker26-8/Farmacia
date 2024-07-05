<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosDR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosDR))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbimportar = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnSalirNormal = New System.Windows.Forms.Button()
        Me.btnGuardarNormal = New System.Windows.Forms.Button()
        Me.btnEliminarNormal = New System.Windows.Forms.Button()
        Me.btnNuevoNormal = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rboDescProductos = New System.Windows.Forms.RadioButton()
        Me.rboDescIngredientes = New System.Windows.Forms.RadioButton()
        Me.cboUnidadSat = New System.Windows.Forms.ComboBox()
        Me.txtUnidadSat = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboCodSat = New System.Windows.Forms.ComboBox()
        Me.txtCodSat = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtComision = New System.Windows.Forms.TextBox()
        Me.cboUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtMaxAlmacen = New System.Windows.Forms.TextBox()
        Me.txtMinAlmacen = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboImprimirComandaNormal = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboGrupoNormal = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboDepartamentoNormal = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboProvEme = New System.Windows.Forms.ComboBox()
        Me.cboProveedoresNormal = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.eqv2 = New System.Windows.Forms.Label()
        Me.eqv1 = New System.Windows.Forms.Label()
        Me.txtUVenta = New System.Windows.Forms.TextBox()
        Me.txtUcompra = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtVentaMinima = New System.Windows.Forms.TextBox()
        Me.txtVentaActual = New System.Windows.Forms.TextBox()
        Me.txtCompra = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboIvaNormal = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboDescripcionTicketNormal = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboCodCortoNormal = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtCodBarrasNormal = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.grdpreferencia = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbopreferencia = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.cboextras = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.grdextras = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.grdpromociones = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtcantidadpromo = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cbopromociones = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.PCopeo = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtcopas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtmilitros = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdpreferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdextras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.grdpromociones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCopeo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 23)
        Me.Label1.TabIndex = 332
        Me.Label1.Text = "%"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbimportar
        '
        Me.pbimportar.BackColor = System.Drawing.Color.White
        Me.pbimportar.Location = New System.Drawing.Point(476, 504)
        Me.pbimportar.Name = "pbimportar"
        Me.pbimportar.Size = New System.Drawing.Size(65, 12)
        Me.pbimportar.TabIndex = 330
        Me.pbimportar.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(476, 431)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 67)
        Me.Button2.TabIndex = 329
        Me.Button2.Text = "Importar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnImagen
        '
        Me.btnImagen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagen.Image = CType(resources.GetObject("btnImagen.Image"), System.Drawing.Image)
        Me.btnImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImagen.Location = New System.Drawing.Point(547, 431)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(65, 67)
        Me.btnImagen.TabIndex = 328
        Me.btnImagen.Text = "Imagen"
        Me.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImagen.UseVisualStyleBackColor = False
        '
        'picImagen
        '
        Me.picImagen.Location = New System.Drawing.Point(618, 431)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(136, 209)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 327
        Me.picImagen.TabStop = False
        '
        'btnSalirNormal
        '
        Me.btnSalirNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalirNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalirNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalirNormal.Image = CType(resources.GetObject("btnSalirNormal.Image"), System.Drawing.Image)
        Me.btnSalirNormal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalirNormal.Location = New System.Drawing.Point(689, 358)
        Me.btnSalirNormal.Name = "btnSalirNormal"
        Me.btnSalirNormal.Size = New System.Drawing.Size(65, 67)
        Me.btnSalirNormal.TabIndex = 326
        Me.btnSalirNormal.Text = "Salir"
        Me.btnSalirNormal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalirNormal.UseVisualStyleBackColor = False
        '
        'btnGuardarNormal
        '
        Me.btnGuardarNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnGuardarNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardarNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarNormal.Image = CType(resources.GetObject("btnGuardarNormal.Image"), System.Drawing.Image)
        Me.btnGuardarNormal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarNormal.Location = New System.Drawing.Point(547, 358)
        Me.btnGuardarNormal.Name = "btnGuardarNormal"
        Me.btnGuardarNormal.Size = New System.Drawing.Size(65, 67)
        Me.btnGuardarNormal.TabIndex = 325
        Me.btnGuardarNormal.Text = "Guardar"
        Me.btnGuardarNormal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarNormal.UseVisualStyleBackColor = False
        '
        'btnEliminarNormal
        '
        Me.btnEliminarNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEliminarNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminarNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarNormal.Image = CType(resources.GetObject("btnEliminarNormal.Image"), System.Drawing.Image)
        Me.btnEliminarNormal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarNormal.Location = New System.Drawing.Point(618, 358)
        Me.btnEliminarNormal.Name = "btnEliminarNormal"
        Me.btnEliminarNormal.Size = New System.Drawing.Size(65, 67)
        Me.btnEliminarNormal.TabIndex = 324
        Me.btnEliminarNormal.Text = "Eliminar"
        Me.btnEliminarNormal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminarNormal.UseVisualStyleBackColor = False
        '
        'btnNuevoNormal
        '
        Me.btnNuevoNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNuevoNormal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevoNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoNormal.Image = CType(resources.GetObject("btnNuevoNormal.Image"), System.Drawing.Image)
        Me.btnNuevoNormal.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevoNormal.Location = New System.Drawing.Point(476, 358)
        Me.btnNuevoNormal.Name = "btnNuevoNormal"
        Me.btnNuevoNormal.Size = New System.Drawing.Size(65, 67)
        Me.btnNuevoNormal.TabIndex = 323
        Me.btnNuevoNormal.Text = "Nuevo"
        Me.btnNuevoNormal.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevoNormal.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox3.Controls.Add(Me.rboDescProductos)
        Me.GroupBox3.Controls.Add(Me.rboDescIngredientes)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 352)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(458, 38)
        Me.GroupBox3.TabIndex = 322
        Me.GroupBox3.TabStop = False
        '
        'rboDescProductos
        '
        Me.rboDescProductos.AutoSize = True
        Me.rboDescProductos.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rboDescProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rboDescProductos.ForeColor = System.Drawing.Color.Black
        Me.rboDescProductos.Location = New System.Drawing.Point(6, 11)
        Me.rboDescProductos.Name = "rboDescProductos"
        Me.rboDescProductos.Size = New System.Drawing.Size(206, 21)
        Me.rboDescProductos.TabIndex = 1
        Me.rboDescProductos.TabStop = True
        Me.rboDescProductos.Text = "Descargar de Inv. Productos"
        Me.rboDescProductos.UseVisualStyleBackColor = False
        '
        'rboDescIngredientes
        '
        Me.rboDescIngredientes.AutoSize = True
        Me.rboDescIngredientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rboDescIngredientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rboDescIngredientes.ForeColor = System.Drawing.Color.Black
        Me.rboDescIngredientes.Location = New System.Drawing.Point(227, 11)
        Me.rboDescIngredientes.Name = "rboDescIngredientes"
        Me.rboDescIngredientes.Size = New System.Drawing.Size(220, 21)
        Me.rboDescIngredientes.TabIndex = 0
        Me.rboDescIngredientes.TabStop = True
        Me.rboDescIngredientes.Text = "Descargar de Inv. Ingredientes"
        Me.rboDescIngredientes.UseVisualStyleBackColor = False
        '
        'cboUnidadSat
        '
        Me.cboUnidadSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidadSat.FormattingEnabled = True
        Me.cboUnidadSat.Location = New System.Drawing.Point(385, 328)
        Me.cboUnidadSat.Name = "cboUnidadSat"
        Me.cboUnidadSat.Size = New System.Drawing.Size(369, 24)
        Me.cboUnidadSat.TabIndex = 321
        '
        'txtUnidadSat
        '
        Me.txtUnidadSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnidadSat.Location = New System.Drawing.Point(508, 302)
        Me.txtUnidadSat.Name = "txtUnidadSat"
        Me.txtUnidadSat.Size = New System.Drawing.Size(246, 22)
        Me.txtUnidadSat.TabIndex = 320
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(385, 302)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(120, 23)
        Me.Label36.TabIndex = 319
        Me.Label36.Text = "Unidad Sat"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCodSat
        '
        Me.cboCodSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodSat.FormattingEnabled = True
        Me.cboCodSat.Location = New System.Drawing.Point(12, 328)
        Me.cboCodSat.Name = "cboCodSat"
        Me.cboCodSat.Size = New System.Drawing.Size(369, 24)
        Me.cboCodSat.TabIndex = 318
        '
        'txtCodSat
        '
        Me.txtCodSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodSat.Location = New System.Drawing.Point(135, 302)
        Me.txtCodSat.Name = "txtCodSat"
        Me.txtCodSat.Size = New System.Drawing.Size(246, 22)
        Me.txtCodSat.TabIndex = 317
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(12, 302)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(120, 23)
        Me.Label33.TabIndex = 316
        Me.Label33.Text = "Codigo Sat"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(365, 250)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(137, 23)
        Me.Label34.TabIndex = 315
        Me.Label34.Text = "Comisión $"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComision
        '
        Me.txtComision.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComision.Location = New System.Drawing.Point(365, 276)
        Me.txtComision.Name = "txtComision"
        Me.txtComision.Size = New System.Drawing.Size(137, 22)
        Me.txtComision.TabIndex = 314
        Me.txtComision.Text = "0"
        '
        'cboUbicacion
        '
        Me.cboUbicacion.FormattingEnabled = True
        Me.cboUbicacion.Location = New System.Drawing.Point(506, 277)
        Me.cboUbicacion.Name = "cboUbicacion"
        Me.cboUbicacion.Size = New System.Drawing.Size(248, 21)
        Me.cboUbicacion.TabIndex = 313
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(506, 250)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(248, 23)
        Me.Label35.TabIndex = 312
        Me.Label35.Text = "Ubicación"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMaxAlmacen
        '
        Me.txtMaxAlmacen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMaxAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxAlmacen.Location = New System.Drawing.Point(244, 276)
        Me.txtMaxAlmacen.Name = "txtMaxAlmacen"
        Me.txtMaxAlmacen.Size = New System.Drawing.Size(118, 22)
        Me.txtMaxAlmacen.TabIndex = 311
        Me.txtMaxAlmacen.Text = "1"
        Me.txtMaxAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinAlmacen
        '
        Me.txtMinAlmacen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMinAlmacen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinAlmacen.Location = New System.Drawing.Point(244, 250)
        Me.txtMinAlmacen.Name = "txtMinAlmacen"
        Me.txtMinAlmacen.Size = New System.Drawing.Size(118, 22)
        Me.txtMinAlmacen.TabIndex = 310
        Me.txtMinAlmacen.Text = "1"
        Me.txtMinAlmacen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 276)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(229, 23)
        Me.Label23.TabIndex = 309
        Me.Label23.Text = "Máximo en Almacén"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 250)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(229, 23)
        Me.Label22.TabIndex = 308
        Me.Label22.Text = "Minimo en Almacén"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboImprimirComandaNormal
        '
        Me.cboImprimirComandaNormal.BackColor = System.Drawing.Color.White
        Me.cboImprimirComandaNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboImprimirComandaNormal.FormattingEnabled = True
        Me.cboImprimirComandaNormal.Location = New System.Drawing.Point(506, 223)
        Me.cboImprimirComandaNormal.Name = "cboImprimirComandaNormal"
        Me.cboImprimirComandaNormal.Size = New System.Drawing.Size(248, 24)
        Me.cboImprimirComandaNormal.TabIndex = 307
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(506, 195)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(248, 23)
        Me.Label24.TabIndex = 306
        Me.Label24.Text = "Imprimir comanda en:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboGrupoNormal
        '
        Me.cboGrupoNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboGrupoNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupoNormal.FormattingEnabled = True
        Me.cboGrupoNormal.Location = New System.Drawing.Point(506, 168)
        Me.cboGrupoNormal.Name = "cboGrupoNormal"
        Me.cboGrupoNormal.Size = New System.Drawing.Size(248, 24)
        Me.cboGrupoNormal.TabIndex = 305
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(506, 142)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(248, 23)
        Me.Label19.TabIndex = 304
        Me.Label19.Text = "Grupo  *INSUMO"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDepartamentoNormal
        '
        Me.cboDepartamentoNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDepartamentoNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamentoNormal.FormattingEnabled = True
        Me.cboDepartamentoNormal.Location = New System.Drawing.Point(506, 115)
        Me.cboDepartamentoNormal.Name = "cboDepartamentoNormal"
        Me.cboDepartamentoNormal.Size = New System.Drawing.Size(248, 24)
        Me.cboDepartamentoNormal.TabIndex = 303
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(506, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(248, 23)
        Me.Label20.TabIndex = 302
        Me.Label20.Text = "Departamento"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProvEme
        '
        Me.cboProvEme.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProvEme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvEme.FormattingEnabled = True
        Me.cboProvEme.Location = New System.Drawing.Point(506, 62)
        Me.cboProvEme.Name = "cboProvEme"
        Me.cboProvEme.Size = New System.Drawing.Size(248, 24)
        Me.cboProvEme.TabIndex = 301
        '
        'cboProveedoresNormal
        '
        Me.cboProveedoresNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProveedoresNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedoresNormal.FormattingEnabled = True
        Me.cboProveedoresNormal.Location = New System.Drawing.Point(506, 35)
        Me.cboProveedoresNormal.Name = "cboProveedoresNormal"
        Me.cboProveedoresNormal.Size = New System.Drawing.Size(248, 24)
        Me.cboProveedoresNormal.TabIndex = 300
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(506, 9)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(248, 23)
        Me.Label21.TabIndex = 299
        Me.Label21.Text = "PROVEEDORES"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'eqv2
        '
        Me.eqv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.eqv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eqv2.Location = New System.Drawing.Point(12, 223)
        Me.eqv2.Name = "eqv2"
        Me.eqv2.Size = New System.Drawing.Size(390, 24)
        Me.eqv2.TabIndex = 298
        '
        'eqv1
        '
        Me.eqv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.eqv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eqv1.Location = New System.Drawing.Point(12, 196)
        Me.eqv1.Name = "eqv1"
        Me.eqv1.Size = New System.Drawing.Size(390, 24)
        Me.eqv1.TabIndex = 297
        '
        'txtUVenta
        '
        Me.txtUVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUVenta.Location = New System.Drawing.Point(405, 223)
        Me.txtUVenta.Name = "txtUVenta"
        Me.txtUVenta.Size = New System.Drawing.Size(97, 24)
        Me.txtUVenta.TabIndex = 296
        '
        'txtUcompra
        '
        Me.txtUcompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUcompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUcompra.Location = New System.Drawing.Point(405, 196)
        Me.txtUcompra.Name = "txtUcompra"
        Me.txtUcompra.Size = New System.Drawing.Size(97, 24)
        Me.txtUcompra.TabIndex = 295
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(12, 168)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(490, 24)
        Me.Label18.TabIndex = 294
        Me.Label18.Text = "EQUIVALENCIAS"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtVentaMinima
        '
        Me.txtVentaMinima.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVentaMinima.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaMinima.Location = New System.Drawing.Point(406, 141)
        Me.txtVentaMinima.Name = "txtVentaMinima"
        Me.txtVentaMinima.Size = New System.Drawing.Size(96, 24)
        Me.txtVentaMinima.TabIndex = 293
        '
        'txtVentaActual
        '
        Me.txtVentaActual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVentaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaActual.Location = New System.Drawing.Point(270, 141)
        Me.txtVentaActual.Name = "txtVentaActual"
        Me.txtVentaActual.Size = New System.Drawing.Size(133, 24)
        Me.txtVentaActual.TabIndex = 292
        '
        'txtCompra
        '
        Me.txtCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompra.Location = New System.Drawing.Point(140, 141)
        Me.txtCompra.Name = "txtCompra"
        Me.txtCompra.Size = New System.Drawing.Size(127, 24)
        Me.txtCompra.TabIndex = 291
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(406, 115)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(96, 23)
        Me.Label25.TabIndex = 290
        Me.Label25.Text = "Venta Minima"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(270, 115)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(133, 23)
        Me.Label26.TabIndex = 289
        Me.Label26.Text = "Venta p/Cod Actual"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(140, 115)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 23)
        Me.Label27.TabIndex = 288
        Me.Label27.Text = "Compra-Venta Max"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboIvaNormal
        '
        Me.cboIvaNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboIvaNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIvaNormal.FormattingEnabled = True
        Me.cboIvaNormal.Items.AddRange(New Object() {"0", "16"})
        Me.cboIvaNormal.Location = New System.Drawing.Point(12, 141)
        Me.cboIvaNormal.Name = "cboIvaNormal"
        Me.cboIvaNormal.Size = New System.Drawing.Size(124, 24)
        Me.cboIvaNormal.TabIndex = 287
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 89)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(124, 23)
        Me.Label29.TabIndex = 286
        Me.Label29.Text = "I.V.A %"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(140, 89)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(362, 23)
        Me.Label28.TabIndex = 285
        Me.Label28.Text = "Unidad: (PZA,ORD,KG,ETC.)"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboDescripcionTicketNormal
        '
        Me.cboDescripcionTicketNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDescripcionTicketNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescripcionTicketNormal.FormattingEnabled = True
        Me.cboDescripcionTicketNormal.Location = New System.Drawing.Point(140, 62)
        Me.cboDescripcionTicketNormal.Name = "cboDescripcionTicketNormal"
        Me.cboDescripcionTicketNormal.Size = New System.Drawing.Size(362, 24)
        Me.cboDescripcionTicketNormal.TabIndex = 284
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(140, 36)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(362, 23)
        Me.Label30.TabIndex = 283
        Me.Label30.Text = "Descripción corta para ticket"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboCodCortoNormal
        '
        Me.cboCodCortoNormal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCodCortoNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodCortoNormal.FormattingEnabled = True
        Me.cboCodCortoNormal.Location = New System.Drawing.Point(12, 62)
        Me.cboCodCortoNormal.Name = "cboCodCortoNormal"
        Me.cboCodCortoNormal.Size = New System.Drawing.Size(124, 24)
        Me.cboCodCortoNormal.TabIndex = 282
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(12, 36)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 23)
        Me.Label31.TabIndex = 281
        Me.Label31.Text = "Código Corto"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCodBarrasNormal
        '
        Me.txtCodBarrasNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarrasNormal.Location = New System.Drawing.Point(140, 10)
        Me.txtCodBarrasNormal.Name = "txtCodBarrasNormal"
        Me.txtCodBarrasNormal.Size = New System.Drawing.Size(362, 22)
        Me.txtCodBarrasNormal.TabIndex = 280
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(12, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 23)
        Me.Label32.TabIndex = 279
        Me.Label32.Text = "Código de barras"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(12, 396)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(458, 248)
        Me.TabControl2.TabIndex = 278
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.grdpreferencia)
        Me.TabPage3.Controls.Add(Me.cbopreferencia)
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(450, 222)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "              Preferencias              "
        '
        'grdpreferencia
        '
        Me.grdpreferencia.AllowUserToAddRows = False
        Me.grdpreferencia.AllowUserToDeleteRows = False
        Me.grdpreferencia.BackgroundColor = System.Drawing.Color.White
        Me.grdpreferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpreferencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.grdpreferencia.Location = New System.Drawing.Point(8, 47)
        Me.grdpreferencia.Name = "grdpreferencia"
        Me.grdpreferencia.ReadOnly = True
        Me.grdpreferencia.RowHeadersVisible = False
        Me.grdpreferencia.Size = New System.Drawing.Size(435, 169)
        Me.grdpreferencia.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Descricpión"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 442
        '
        'cbopreferencia
        '
        Me.cbopreferencia.FormattingEnabled = True
        Me.cbopreferencia.Location = New System.Drawing.Point(99, 15)
        Me.cbopreferencia.Name = "cbopreferencia"
        Me.cbopreferencia.Size = New System.Drawing.Size(344, 21)
        Me.cbopreferencia.TabIndex = 1
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(8, 16)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(90, 20)
        Me.Label37.TabIndex = 0
        Me.Label37.Text = "Preferencia"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.cboextras)
        Me.TabPage4.Controls.Add(Me.Label38)
        Me.TabPage4.Controls.Add(Me.grdextras)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(450, 222)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "                   Extras                 "
        '
        'cboextras
        '
        Me.cboextras.FormattingEnabled = True
        Me.cboextras.Location = New System.Drawing.Point(62, 9)
        Me.cboextras.Name = "cboextras"
        Me.cboextras.Size = New System.Drawing.Size(382, 21)
        Me.cboextras.TabIndex = 2
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(7, 9)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(50, 18)
        Me.Label38.TabIndex = 1
        Me.Label38.Text = "Extras"
        '
        'grdextras
        '
        Me.grdextras.AllowUserToAddRows = False
        Me.grdextras.AllowUserToDeleteRows = False
        Me.grdextras.BackgroundColor = System.Drawing.Color.White
        Me.grdextras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdextras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column2})
        Me.grdextras.Location = New System.Drawing.Point(7, 41)
        Me.grdextras.Name = "grdextras"
        Me.grdextras.ReadOnly = True
        Me.grdextras.RowHeadersVisible = False
        Me.grdextras.Size = New System.Drawing.Size(437, 175)
        Me.grdextras.TabIndex = 0
        '
        'Column3
        '
        Me.Column3.HeaderText = "Codigo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 368
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.grdpromociones)
        Me.TabPage5.Controls.Add(Me.txtcantidadpromo)
        Me.TabPage5.Controls.Add(Me.Label40)
        Me.TabPage5.Controls.Add(Me.cbopromociones)
        Me.TabPage5.Controls.Add(Me.Label39)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(450, 222)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "             Promociones             "
        '
        'grdpromociones
        '
        Me.grdpromociones.AllowUserToAddRows = False
        Me.grdpromociones.AllowUserToDeleteRows = False
        Me.grdpromociones.BackgroundColor = System.Drawing.Color.White
        Me.grdpromociones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpromociones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5})
        Me.grdpromociones.Location = New System.Drawing.Point(9, 43)
        Me.grdpromociones.Name = "grdpromociones"
        Me.grdpromociones.ReadOnly = True
        Me.grdpromociones.RowHeadersVisible = False
        Me.grdpromociones.Size = New System.Drawing.Size(347, 173)
        Me.grdpromociones.TabIndex = 4
        '
        'Column4
        '
        Me.Column4.HeaderText = "Código"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Descripción"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 243
        '
        'txtcantidadpromo
        '
        Me.txtcantidadpromo.Location = New System.Drawing.Point(363, 78)
        Me.txtcantidadpromo.Name = "txtcantidadpromo"
        Me.txtcantidadpromo.Size = New System.Drawing.Size(80, 20)
        Me.txtcantidadpromo.TabIndex = 3
        Me.txtcantidadpromo.Text = "0"
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(360, 11)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(83, 64)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "Cantidad de Productos en la promoción"
        '
        'cbopromociones
        '
        Me.cbopromociones.FormattingEnabled = True
        Me.cbopromociones.Location = New System.Drawing.Point(110, 11)
        Me.cbopromociones.Name = "cbopromociones"
        Me.cbopromociones.Size = New System.Drawing.Size(246, 21)
        Me.cbopromociones.TabIndex = 1
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(6, 11)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(101, 20)
        Me.Label39.TabIndex = 0
        Me.Label39.Text = "Promociones"
        '
        'PCopeo
        '
        Me.PCopeo.Controls.Add(Me.GroupBox1)
        Me.PCopeo.Location = New System.Drawing.Point(476, 522)
        Me.PCopeo.Name = "PCopeo"
        Me.PCopeo.Size = New System.Drawing.Size(136, 121)
        Me.PCopeo.TabIndex = 333
        Me.PCopeo.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcopas)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtmilitros)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(126, 107)
        Me.GroupBox1.TabIndex = 334
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control de botellas"
        '
        'txtcopas
        '
        Me.txtcopas.Location = New System.Drawing.Point(9, 81)
        Me.txtcopas.Name = "txtcopas"
        Me.txtcopas.Size = New System.Drawing.Size(101, 20)
        Me.txtcopas.TabIndex = 3
        Me.txtcopas.Text = "0"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Botella Militros"
        '
        'txtmilitros
        '
        Me.txtmilitros.Location = New System.Drawing.Point(9, 39)
        Me.txtmilitros.Name = "txtmilitros"
        Me.txtmilitros.Size = New System.Drawing.Size(101, 20)
        Me.txtmilitros.TabIndex = 2
        Me.txtmilitros.Text = "0"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 19)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Copas"
        '
        'frmProductosDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(760, 655)
        Me.Controls.Add(Me.PCopeo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbimportar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnImagen)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnSalirNormal)
        Me.Controls.Add(Me.btnGuardarNormal)
        Me.Controls.Add(Me.btnEliminarNormal)
        Me.Controls.Add(Me.btnNuevoNormal)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cboUnidadSat)
        Me.Controls.Add(Me.txtUnidadSat)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.cboCodSat)
        Me.Controls.Add(Me.txtCodSat)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.txtComision)
        Me.Controls.Add(Me.cboUbicacion)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.txtMaxAlmacen)
        Me.Controls.Add(Me.txtMinAlmacen)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cboImprimirComandaNormal)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cboGrupoNormal)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboDepartamentoNormal)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboProvEme)
        Me.Controls.Add(Me.cboProveedoresNormal)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.eqv2)
        Me.Controls.Add(Me.eqv1)
        Me.Controls.Add(Me.txtUVenta)
        Me.Controls.Add(Me.txtUcompra)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtVentaMinima)
        Me.Controls.Add(Me.txtVentaActual)
        Me.Controls.Add(Me.txtCompra)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.cboIvaNormal)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cboDescripcionTicketNormal)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.cboCodCortoNormal)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtCodBarrasNormal)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TabControl2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductosDR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Derivados"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.grdpreferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.grdextras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.grdpromociones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCopeo.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents pbimportar As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents btnImagen As Button
    Friend WithEvents picImagen As PictureBox
    Friend WithEvents btnSalirNormal As Button
    Friend WithEvents btnGuardarNormal As Button
    Friend WithEvents btnEliminarNormal As Button
    Friend WithEvents btnNuevoNormal As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rboDescProductos As RadioButton
    Friend WithEvents rboDescIngredientes As RadioButton
    Friend WithEvents cboUnidadSat As ComboBox
    Friend WithEvents txtUnidadSat As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents cboCodSat As ComboBox
    Friend WithEvents txtCodSat As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtComision As TextBox
    Friend WithEvents cboUbicacion As ComboBox
    Friend WithEvents Label35 As Label
    Friend WithEvents txtMaxAlmacen As TextBox
    Friend WithEvents txtMinAlmacen As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cboImprimirComandaNormal As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cboGrupoNormal As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboDepartamentoNormal As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cboProvEme As ComboBox
    Friend WithEvents cboProveedoresNormal As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents eqv2 As Label
    Friend WithEvents eqv1 As Label
    Friend WithEvents txtUVenta As TextBox
    Friend WithEvents txtUcompra As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtVentaMinima As TextBox
    Friend WithEvents txtVentaActual As TextBox
    Friend WithEvents txtCompra As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents cboIvaNormal As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents cboDescripcionTicketNormal As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents cboCodCortoNormal As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents txtCodBarrasNormal As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents grdpreferencia As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents cbopreferencia As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents cboextras As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents grdextras As DataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents grdpromociones As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents txtcantidadpromo As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents cbopromociones As ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents PCopeo As Panel
    Friend WithEvents txtcopas As TextBox
    Friend WithEvents txtmilitros As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
