﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosSR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosSR))
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BTNpORMOCIONES = New System.Windows.Forms.Button()
        Me.txtrutaimagen = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rboDescProductos = New System.Windows.Forms.RadioButton()
        Me.rboDescIngredientes = New System.Windows.Forms.RadioButton()
        Me.pbimportar = New System.Windows.Forms.ProgressBar()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.txtExistencia = New System.Windows.Forms.TextBox()
        Me.lblexistencia = New System.Windows.Forms.Label()
        Me.chkKit = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtCodBarras = New System.Windows.Forms.TextBox()
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
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboComanda = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecioDomicilio = New System.Windows.Forms.TextBox()
        Me.txtPrecioLocal = New System.Windows.Forms.TextBox()
        Me.txtPrecioCompra = New System.Windows.Forms.TextBox()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboIva = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboDescripcion = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCodCorto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdsql = New System.Windows.Forms.DataGridView()
        Me.btnMigrar = New System.Windows.Forms.Button()
        Me.box_tienda = New System.Windows.Forms.GroupBox()
        Me.btn_guardar = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_descripcion = New System.Windows.Forms.RichTextBox()
        Me.txt_resumen = New System.Windows.Forms.TextBox()
        Me.btn_tienda = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdpreferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.grdextras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.grdpromociones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdsql, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.box_tienda.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label17.Size = New System.Drawing.Size(1114, 31)
        Me.Label17.TabIndex = 226
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BTNpORMOCIONES
        '
        Me.BTNpORMOCIONES.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BTNpORMOCIONES.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTNpORMOCIONES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNpORMOCIONES.Image = CType(resources.GetObject("BTNpORMOCIONES.Image"), System.Drawing.Image)
        Me.BTNpORMOCIONES.Location = New System.Drawing.Point(563, 374)
        Me.BTNpORMOCIONES.Name = "BTNpORMOCIONES"
        Me.BTNpORMOCIONES.Size = New System.Drawing.Size(136, 64)
        Me.BTNpORMOCIONES.TabIndex = 233
        Me.BTNpORMOCIONES.Text = "Promociones"
        Me.BTNpORMOCIONES.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNpORMOCIONES.UseVisualStyleBackColor = False
        '
        'txtrutaimagen
        '
        Me.txtrutaimagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtrutaimagen.BackColor = System.Drawing.Color.White
        Me.txtrutaimagen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrutaimagen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrutaimagen.Location = New System.Drawing.Point(563, 504)
        Me.txtrutaimagen.Name = "txtrutaimagen"
        Me.txtrutaimagen.Size = New System.Drawing.Size(65, 23)
        Me.txtrutaimagen.TabIndex = 232
        Me.txtrutaimagen.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rboDescProductos)
        Me.GroupBox2.Controls.Add(Me.rboDescIngredientes)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 263)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(548, 36)
        Me.GroupBox2.TabIndex = 222
        Me.GroupBox2.TabStop = False
        '
        'rboDescProductos
        '
        Me.rboDescProductos.AutoSize = True
        Me.rboDescProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rboDescProductos.Location = New System.Drawing.Point(25, 9)
        Me.rboDescProductos.Name = "rboDescProductos"
        Me.rboDescProductos.Size = New System.Drawing.Size(214, 22)
        Me.rboDescProductos.TabIndex = 222
        Me.rboDescProductos.TabStop = True
        Me.rboDescProductos.Text = "Descargar de Inv. Productos"
        Me.rboDescProductos.UseVisualStyleBackColor = True
        '
        'rboDescIngredientes
        '
        Me.rboDescIngredientes.AutoSize = True
        Me.rboDescIngredientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rboDescIngredientes.Location = New System.Drawing.Point(299, 9)
        Me.rboDescIngredientes.Name = "rboDescIngredientes"
        Me.rboDescIngredientes.Size = New System.Drawing.Size(224, 22)
        Me.rboDescIngredientes.TabIndex = 223
        Me.rboDescIngredientes.TabStop = True
        Me.rboDescIngredientes.Text = "Descargar de Inv. Ingredientes"
        Me.rboDescIngredientes.UseVisualStyleBackColor = True
        '
        'pbimportar
        '
        Me.pbimportar.BackColor = System.Drawing.Color.White
        Me.pbimportar.Location = New System.Drawing.Point(563, 444)
        Me.pbimportar.Name = "pbimportar"
        Me.pbimportar.Size = New System.Drawing.Size(136, 12)
        Me.pbimportar.TabIndex = 219
        Me.pbimportar.Visible = False
        '
        'btnImportar
        '
        Me.btnImportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImportar.FlatAppearance.BorderSize = 0
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImportar.Location = New System.Drawing.Point(918, 301)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(65, 67)
        Me.btnImportar.TabIndex = 218
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'txtExistencia
        '
        Me.txtExistencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtExistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExistencia.Location = New System.Drawing.Point(563, 215)
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(278, 22)
        Me.txtExistencia.TabIndex = 38
        Me.txtExistencia.Text = "0"
        Me.txtExistencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblexistencia
        '
        Me.lblexistencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblexistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblexistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexistencia.Location = New System.Drawing.Point(563, 189)
        Me.lblexistencia.Name = "lblexistencia"
        Me.lblexistencia.Size = New System.Drawing.Size(278, 23)
        Me.lblexistencia.TabIndex = 36
        Me.lblexistencia.Text = "Existencias"
        Me.lblexistencia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkKit
        '
        Me.chkKit.AutoSize = True
        Me.chkKit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKit.Location = New System.Drawing.Point(607, 241)
        Me.chkKit.Name = "chkKit"
        Me.chkKit.Size = New System.Drawing.Size(191, 24)
        Me.chkKit.TabIndex = 35
        Me.chkKit.Text = "Este producto es un kit"
        Me.chkKit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(989, 302)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 67)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Imagen"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(847, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(263, 267)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 33
        Me.PictureBox1.TabStop = False
        '
        'txtCodBarras
        '
        Me.txtCodBarras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodBarras.Location = New System.Drawing.Point(139, 32)
        Me.txtCodBarras.Name = "txtCodBarras"
        Me.txtCodBarras.Size = New System.Drawing.Size(421, 22)
        Me.txtCodBarras.TabIndex = 32
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Location = New System.Drawing.Point(12, 305)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(548, 248)
        Me.TabControl2.TabIndex = 31
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
        Me.TabPage3.Size = New System.Drawing.Size(540, 222)
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
        Me.grdpreferencia.Location = New System.Drawing.Point(6, 47)
        Me.grdpreferencia.Name = "grdpreferencia"
        Me.grdpreferencia.ReadOnly = True
        Me.grdpreferencia.RowHeadersVisible = False
        Me.grdpreferencia.Size = New System.Drawing.Size(528, 169)
        Me.grdpreferencia.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Descricpión"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 450
        '
        'cbopreferencia
        '
        Me.cbopreferencia.FormattingEnabled = True
        Me.cbopreferencia.Location = New System.Drawing.Point(99, 15)
        Me.cbopreferencia.Name = "cbopreferencia"
        Me.cbopreferencia.Size = New System.Drawing.Size(435, 21)
        Me.cbopreferencia.TabIndex = 1
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(3, 16)
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
        Me.TabPage4.Size = New System.Drawing.Size(540, 222)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "                     Extras                   "
        '
        'cboextras
        '
        Me.cboextras.FormattingEnabled = True
        Me.cboextras.Location = New System.Drawing.Point(62, 9)
        Me.cboextras.Name = "cboextras"
        Me.cboextras.Size = New System.Drawing.Size(472, 21)
        Me.cboextras.TabIndex = 2
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(6, 9)
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
        Me.grdextras.Location = New System.Drawing.Point(9, 41)
        Me.grdextras.Name = "grdextras"
        Me.grdextras.ReadOnly = True
        Me.grdextras.RowHeadersVisible = False
        Me.grdextras.Size = New System.Drawing.Size(525, 175)
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
        Me.Column2.Width = 375
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
        Me.TabPage5.Size = New System.Drawing.Size(540, 222)
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
        Me.grdpromociones.Size = New System.Drawing.Size(431, 173)
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
        Me.txtcantidadpromo.Location = New System.Drawing.Point(446, 78)
        Me.txtcantidadpromo.Name = "txtcantidadpromo"
        Me.txtcantidadpromo.Size = New System.Drawing.Size(88, 20)
        Me.txtcantidadpromo.TabIndex = 3
        Me.txtcantidadpromo.Text = "0"
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(443, 11)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(91, 64)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "Cantidad de Productos en la promoción"
        '
        'cbopromociones
        '
        Me.cbopromociones.FormattingEnabled = True
        Me.cbopromociones.Location = New System.Drawing.Point(110, 11)
        Me.cbopromociones.Name = "cbopromociones"
        Me.cbopromociones.Size = New System.Drawing.Size(330, 21)
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
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(352, 18)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "*Es obligatorio llenar los campos color amarillo."
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.FlatAppearance.BorderSize = 0
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(705, 301)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(65, 67)
        Me.btnSalir.TabIndex = 30
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnGuardar.FlatAppearance.BorderSize = 0
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(634, 301)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(65, 67)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEliminar.FlatAppearance.BorderSize = 0
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(776, 301)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(65, 67)
        Me.btnEliminar.TabIndex = 28
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnNuevo.FlatAppearance.BorderSize = 0
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(563, 301)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(65, 67)
        Me.btnNuevo.TabIndex = 27
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(563, 269)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(278, 29)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "El departamento ""INSUMO"" no se mostrara en las comanderas."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboComanda
        '
        Me.cboComanda.BackColor = System.Drawing.Color.White
        Me.cboComanda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComanda.FormattingEnabled = True
        Me.cboComanda.Location = New System.Drawing.Point(563, 162)
        Me.cboComanda.Name = "cboComanda"
        Me.cboComanda.Size = New System.Drawing.Size(278, 24)
        Me.cboComanda.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(563, 136)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(278, 23)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Imprimir comanda en:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboGrupo
        '
        Me.cboGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(563, 109)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(278, 24)
        Me.cboGrupo.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(563, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(278, 23)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Grupo *PROMOCIONES, *EXTRAS,*INSUMO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDepartamento
        '
        Me.cboDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.FormattingEnabled = True
        Me.cboDepartamento.Location = New System.Drawing.Point(563, 56)
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.Size = New System.Drawing.Size(278, 24)
        Me.cboDepartamento.TabIndex = 21
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(563, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(278, 23)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Departamento *INSUMO, *PROMOCIONES"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProveedores
        '
        Me.cboProveedores.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProveedores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProveedores.FormattingEnabled = True
        Me.cboProveedores.Location = New System.Drawing.Point(12, 241)
        Me.cboProveedores.Name = "cboProveedores"
        Me.cboProveedores.Size = New System.Drawing.Size(548, 24)
        Me.cboProveedores.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 215)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(548, 23)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Proveedores"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 189)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(548, 23)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Precios deben ser con iva incluido."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPrecioDomicilio
        '
        Me.txtPrecioDomicilio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPrecioDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioDomicilio.Location = New System.Drawing.Point(434, 162)
        Me.txtPrecioDomicilio.Name = "txtPrecioDomicilio"
        Me.txtPrecioDomicilio.Size = New System.Drawing.Size(126, 24)
        Me.txtPrecioDomicilio.TabIndex = 16
        Me.txtPrecioDomicilio.Text = "0.00"
        Me.txtPrecioDomicilio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioLocal
        '
        Me.txtPrecioLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPrecioLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioLocal.Location = New System.Drawing.Point(332, 162)
        Me.txtPrecioLocal.Name = "txtPrecioLocal"
        Me.txtPrecioLocal.Size = New System.Drawing.Size(99, 24)
        Me.txtPrecioLocal.TabIndex = 15
        Me.txtPrecioLocal.Text = "0.00"
        Me.txtPrecioLocal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecioCompra
        '
        Me.txtPrecioCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPrecioCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioCompra.Location = New System.Drawing.Point(212, 162)
        Me.txtPrecioCompra.Name = "txtPrecioCompra"
        Me.txtPrecioCompra.Size = New System.Drawing.Size(117, 24)
        Me.txtPrecioCompra.TabIndex = 14
        Me.txtPrecioCompra.Text = "0.00"
        Me.txtPrecioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUnidad
        '
        Me.txtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnidad.Location = New System.Drawing.Point(139, 162)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(70, 24)
        Me.txtUnidad.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(434, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 23)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Precio Domicilio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(332, 136)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 23)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Precio Local"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(212, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Precio Compra"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(139, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Unidad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(548, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Unidad: (PZA,ORD,KG,ETC.)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboIva
        '
        Me.cboIva.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIva.FormattingEnabled = True
        Me.cboIva.Items.AddRange(New Object() {"0", "16"})
        Me.cboIva.Location = New System.Drawing.Point(12, 162)
        Me.cboIva.Name = "cboIva"
        Me.cboIva.Size = New System.Drawing.Size(124, 24)
        Me.cboIva.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "I.V.A %"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboDescripcion
        '
        Me.cboDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescripcion.FormattingEnabled = True
        Me.cboDescripcion.Location = New System.Drawing.Point(139, 83)
        Me.cboDescripcion.Name = "cboDescripcion"
        Me.cboDescripcion.Size = New System.Drawing.Size(421, 24)
        Me.cboDescripcion.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(139, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(421, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Descripción corta para ticket"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboCodCorto
        '
        Me.cboCodCorto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCodCorto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodCorto.FormattingEnabled = True
        Me.cboCodCorto.Location = New System.Drawing.Point(12, 83)
        Me.cboCodCorto.Name = "cboCodCorto"
        Me.cboCodCorto.Size = New System.Drawing.Size(124, 24)
        Me.cboCodCorto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Código Corto"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código de barras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdsql
        '
        Me.grdsql.AllowUserToAddRows = False
        Me.grdsql.AllowUserToDeleteRows = False
        Me.grdsql.BackgroundColor = System.Drawing.Color.White
        Me.grdsql.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdsql.Location = New System.Drawing.Point(566, 462)
        Me.grdsql.Name = "grdsql"
        Me.grdsql.ReadOnly = True
        Me.grdsql.Size = New System.Drawing.Size(28, 36)
        Me.grdsql.TabIndex = 227
        Me.grdsql.Visible = False
        '
        'btnMigrar
        '
        Me.btnMigrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMigrar.FlatAppearance.BorderSize = 0
        Me.btnMigrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMigrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrar.Image = CType(resources.GetObject("btnMigrar.Image"), System.Drawing.Image)
        Me.btnMigrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMigrar.Location = New System.Drawing.Point(847, 301)
        Me.btnMigrar.Name = "btnMigrar"
        Me.btnMigrar.Size = New System.Drawing.Size(65, 67)
        Me.btnMigrar.TabIndex = 234
        Me.btnMigrar.Text = "Migrar"
        Me.btnMigrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMigrar.UseVisualStyleBackColor = False
        '
        'box_tienda
        '
        Me.box_tienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.box_tienda.Controls.Add(Me.btn_guardar)
        Me.box_tienda.Controls.Add(Me.Label28)
        Me.box_tienda.Controls.Add(Me.Label20)
        Me.box_tienda.Controls.Add(Me.txt_descripcion)
        Me.box_tienda.Controls.Add(Me.txt_resumen)
        Me.box_tienda.Location = New System.Drawing.Point(108, 219)
        Me.box_tienda.Name = "box_tienda"
        Me.box_tienda.Size = New System.Drawing.Size(633, 122)
        Me.box_tienda.TabIndex = 255
        Me.box_tienda.TabStop = False
        Me.box_tienda.Text = "Datos tienda en linea"
        Me.box_tienda.Visible = False
        '
        'btn_guardar
        '
        Me.btn_guardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_guardar.BackColor = System.Drawing.Color.White
        Me.btn_guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_guardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_guardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_guardar.Location = New System.Drawing.Point(9, 86)
        Me.btn_guardar.Name = "btn_guardar"
        Me.btn_guardar.Size = New System.Drawing.Size(114, 26)
        Me.btn_guardar.TabIndex = 253
        Me.btn_guardar.Text = "Guardar"
        Me.btn_guardar.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 45)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(111, 13)
        Me.Label28.TabIndex = 251
        Me.Label28.Text = "Descripción producto:"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 13)
        Me.Label20.TabIndex = 250
        Me.Label20.Text = "Resumen producto:"
        '
        'txt_descripcion
        '
        Me.txt_descripcion.Location = New System.Drawing.Point(134, 46)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(493, 66)
        Me.txt_descripcion.TabIndex = 1
        Me.txt_descripcion.Text = ""
        '
        'txt_resumen
        '
        Me.txt_resumen.Location = New System.Drawing.Point(134, 17)
        Me.txt_resumen.Name = "txt_resumen"
        Me.txt_resumen.Size = New System.Drawing.Size(493, 20)
        Me.txt_resumen.TabIndex = 0
        '
        'btn_tienda
        '
        Me.btn_tienda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_tienda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_tienda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btn_tienda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_tienda.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_tienda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_tienda.Location = New System.Drawing.Point(705, 374)
        Me.btn_tienda.Name = "btn_tienda"
        Me.btn_tienda.Size = New System.Drawing.Size(65, 64)
        Me.btn_tienda.TabIndex = 256
        Me.btn_tienda.Text = "Datos tienda"
        Me.btn_tienda.UseVisualStyleBackColor = False
        Me.btn_tienda.Visible = False
        '
        'frmProductosSR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1114, 560)
        Me.Controls.Add(Me.box_tienda)
        Me.Controls.Add(Me.btn_tienda)
        Me.Controls.Add(Me.btnMigrar)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.txtrutaimagen)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BTNpORMOCIONES)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.pbimportar)
        Me.Controls.Add(Me.grdsql)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkKit)
        Me.Controls.Add(Me.txtCodBarras)
        Me.Controls.Add(Me.txtExistencia)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblexistencia)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cboCodCorto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.cboDescripcion)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboDepartamento)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboProveedores)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboComanda)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboIva)
        Me.Controls.Add(Me.txtUnidad)
        Me.Controls.Add(Me.txtPrecioCompra)
        Me.Controls.Add(Me.txtPrecioDomicilio)
        Me.Controls.Add(Me.txtPrecioLocal)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductosSR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Productos Sencillo"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.grdsql, System.ComponentModel.ISupportInitialize).EndInit()
        Me.box_tienda.ResumeLayout(False)
        Me.box_tienda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rboDescProductos As RadioButton
    Friend WithEvents rboDescIngredientes As RadioButton
    Friend WithEvents pbimportar As ProgressBar
    Friend WithEvents btnImportar As Button
    Friend WithEvents txtExistencia As TextBox
    Friend WithEvents lblexistencia As Label
    Friend WithEvents chkKit As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtCodBarras As TextBox
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
    Friend WithEvents Label16 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cboComanda As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cboDepartamento As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cboProveedores As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrecioDomicilio As TextBox
    Friend WithEvents txtPrecioLocal As TextBox
    Friend WithEvents txtPrecioCompra As TextBox
    Friend WithEvents txtUnidad As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboIva As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboDescripcion As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCodCorto As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grdsql As DataGridView
    Friend WithEvents txtrutaimagen As TextBox
    Friend WithEvents BTNpORMOCIONES As Button
    Friend WithEvents btnMigrar As Button
    Friend WithEvents box_tienda As GroupBox
    Friend WithEvents btn_guardar As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents txt_descripcion As RichTextBox
    Friend WithEvents txt_resumen As TextBox
    Friend WithEvents btn_tienda As Button
End Class
