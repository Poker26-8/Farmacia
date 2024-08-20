<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductosSSerie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosSSerie))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtrutaimagen = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtpcompra2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtutilidad = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.barsube = New System.Windows.Forms.ProgressBar()
        Me.txtClaveSAT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodigoSAT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkKIT = New System.Windows.Forms.CheckBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboDepto = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtpventa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtpcompra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.cboProvP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboIVA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCodigo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtn_serie = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboubicacion = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboComanda = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(835, 31)
        Me.Label1.TabIndex = 176
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtrutaimagen
        '
        Me.txtrutaimagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtrutaimagen.BackColor = System.Drawing.Color.White
        Me.txtrutaimagen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrutaimagen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrutaimagen.Location = New System.Drawing.Point(76, 300)
        Me.txtrutaimagen.Name = "txtrutaimagen"
        Me.txtrutaimagen.Size = New System.Drawing.Size(175, 23)
        Me.txtrutaimagen.TabIndex = 273
        Me.txtrutaimagen.Visible = False
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(274, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 21)
        Me.Label17.TabIndex = 272
        Me.Label17.Text = "P. Compra con IVA"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpcompra2
        '
        Me.txtpcompra2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtpcompra2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpcompra2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpcompra2.Location = New System.Drawing.Point(274, 165)
        Me.txtpcompra2.Name = "txtpcompra2"
        Me.txtpcompra2.Size = New System.Drawing.Size(100, 23)
        Me.txtpcompra2.TabIndex = 271
        Me.txtpcompra2.Text = "0.00"
        Me.txtpcompra2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(171, 191)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 21)
        Me.Label16.TabIndex = 270
        Me.Label16.Text = "Porcentaje (%)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(11, 389)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(577, 141)
        Me.DataGridView1.TabIndex = 269
        '
        'txtutilidad
        '
        Me.txtutilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtutilidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtutilidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad.Location = New System.Drawing.Point(171, 215)
        Me.txtutilidad.Name = "txtutilidad"
        Me.txtutilidad.Size = New System.Drawing.Size(100, 23)
        Me.txtutilidad.TabIndex = 268
        Me.txtutilidad.Text = "0"
        Me.txtutilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(565, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 21)
        Me.Label14.TabIndex = 267
        Me.Label14.Text = "?"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'barsube
        '
        Me.barsube.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.barsube.Location = New System.Drawing.Point(76, 329)
        Me.barsube.Name = "barsube"
        Me.barsube.Size = New System.Drawing.Size(62, 14)
        Me.barsube.TabIndex = 266
        '
        'txtClaveSAT
        '
        Me.txtClaveSAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtClaveSAT.BackColor = System.Drawing.Color.White
        Me.txtClaveSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveSAT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveSAT.Location = New System.Drawing.Point(415, 271)
        Me.txtClaveSAT.Name = "txtClaveSAT"
        Me.txtClaveSAT.Size = New System.Drawing.Size(170, 23)
        Me.txtClaveSAT.TabIndex = 259
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(298, 271)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 23)
        Me.Label18.TabIndex = 258
        Me.Label18.Text = "Unidad SAT"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCodigoSAT
        '
        Me.txtCodigoSAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoSAT.BackColor = System.Drawing.Color.White
        Me.txtCodigoSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSAT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoSAT.Location = New System.Drawing.Point(125, 271)
        Me.txtCodigoSAT.Name = "txtCodigoSAT"
        Me.txtCodigoSAT.Size = New System.Drawing.Size(170, 23)
        Me.txtCodigoSAT.TabIndex = 257
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 271)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 23)
        Me.Label13.TabIndex = 256
        Me.Label13.Text = "Código SAT"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkKIT
        '
        Me.chkKIT.AutoSize = True
        Me.chkKIT.Location = New System.Drawing.Point(11, 194)
        Me.chkKIT.Name = "chkKIT"
        Me.chkKIT.Size = New System.Drawing.Size(140, 19)
        Me.chkKIT.TabIndex = 255
        Me.chkKIT.Text = "Este registro es un KIT"
        Me.chkKIT.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(377, 163)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(208, 23)
        Me.cboGrupo.TabIndex = 254
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(377, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 21)
        Me.Label11.TabIndex = 253
        Me.Label11.Text = "Grupo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboDepto
        '
        Me.cboDepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDepto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepto.FormattingEnabled = True
        Me.cboDepto.Location = New System.Drawing.Point(377, 113)
        Me.cboDepto.Name = "cboDepto"
        Me.cboDepto.Size = New System.Drawing.Size(208, 23)
        Me.cboDepto.TabIndex = 252
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(377, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(208, 21)
        Me.Label9.TabIndex = 251
        Me.Label9.Text = "Departamento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(274, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 21)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "P. Venta con IVA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpventa
        '
        Me.txtpventa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtpventa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpventa.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpventa.Location = New System.Drawing.Point(274, 215)
        Me.txtpventa.Name = "txtpventa"
        Me.txtpventa.Size = New System.Drawing.Size(100, 23)
        Me.txtpventa.TabIndex = 249
        Me.txtpventa.Text = "0.00"
        Me.txtpventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(171, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 21)
        Me.Label7.TabIndex = 248
        Me.Label7.Text = "P. Compra sin IVA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtpcompra
        '
        Me.txtpcompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtpcompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpcompra.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpcompra.Location = New System.Drawing.Point(171, 165)
        Me.txtpcompra.Name = "txtpcompra"
        Me.txtpcompra.Size = New System.Drawing.Size(100, 23)
        Me.txtpcompra.TabIndex = 247
        Me.txtpcompra.Text = "0.00"
        Me.txtpcompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(96, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 21)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "Unidad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUnidad
        '
        Me.txtUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUnidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnidad.Location = New System.Drawing.Point(96, 165)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(72, 23)
        Me.txtUnidad.TabIndex = 245
        Me.txtUnidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboProvP
        '
        Me.cboProvP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProvP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvP.FormattingEnabled = True
        Me.cboProvP.Location = New System.Drawing.Point(377, 63)
        Me.cboProvP.Name = "cboProvP"
        Me.cboProvP.Size = New System.Drawing.Size(208, 23)
        Me.cboProvP.TabIndex = 244
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(377, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 21)
        Me.Label5.TabIndex = 243
        Me.Label5.Text = "Proveedor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboIVA
        '
        Me.cboIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboIVA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIVA.FormattingEnabled = True
        Me.cboIVA.Items.AddRange(New Object() {"0", "0.16"})
        Me.cboIVA.Location = New System.Drawing.Point(8, 165)
        Me.cboIVA.Name = "cboIVA"
        Me.cboIVA.Size = New System.Drawing.Size(85, 23)
        Me.cboIVA.TabIndex = 242
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 21)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "IVA (%)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(96, 89)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(278, 23)
        Me.cboNombre.TabIndex = 240
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(96, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(278, 21)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "Descripción corta para ticket"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbarras
        '
        Me.txtbarras.BackColor = System.Drawing.Color.White
        Me.txtbarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbarras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarras.Location = New System.Drawing.Point(125, 39)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(249, 23)
        Me.txtbarras.TabIndex = 238
        Me.txtbarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 23)
        Me.Label3.TabIndex = 237
        Me.Label3.Text = "Código de barras"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCodigo
        '
        Me.cboCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodigo.FormattingEnabled = True
        Me.cboCodigo.Location = New System.Drawing.Point(8, 89)
        Me.cboCodigo.Name = "cboCodigo"
        Me.cboCodigo.Size = New System.Drawing.Size(85, 23)
        Me.cboCodigo.TabIndex = 236
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(8, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 21)
        Me.Label12.TabIndex = 235
        Me.Label12.Text = "Código"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtn_serie
        '
        Me.txtn_serie.BackColor = System.Drawing.Color.White
        Me.txtn_serie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtn_serie.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtn_serie.Location = New System.Drawing.Point(125, 115)
        Me.txtn_serie.Name = "txtn_serie"
        Me.txtn_serie.Size = New System.Drawing.Size(249, 23)
        Me.txtn_serie.TabIndex = 275
        Me.txtn_serie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 23)
        Me.Label10.TabIndex = 274
        Me.Label10.Text = "Número de parte"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboubicacion
        '
        Me.cboubicacion.BackColor = System.Drawing.Color.White
        Me.cboubicacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboubicacion.FormattingEnabled = True
        Me.cboubicacion.Location = New System.Drawing.Point(448, 189)
        Me.cboubicacion.Name = "cboubicacion"
        Me.cboubicacion.Size = New System.Drawing.Size(137, 23)
        Me.cboubicacion.TabIndex = 293
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(377, 189)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(68, 23)
        Me.Label23.TabIndex = 292
        Me.Label23.Text = "Ubicación"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboComanda
        '
        Me.cboComanda.BackColor = System.Drawing.Color.White
        Me.cboComanda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComanda.FormattingEnabled = True
        Me.cboComanda.Location = New System.Drawing.Point(406, 241)
        Me.cboComanda.Name = "cboComanda"
        Me.cboComanda.Size = New System.Drawing.Size(179, 23)
        Me.cboComanda.TabIndex = 295
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(219, 241)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(184, 23)
        Me.Label15.TabIndex = 294
        Me.Label15.Text = "Imprimir comanda en:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picImagen
        '
        Me.picImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picImagen.Location = New System.Drawing.Point(591, 39)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(239, 255)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 265
        Me.picImagen.TabStop = False
        '
        'btnImagen
        '
        Me.btnImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImagen.BackColor = System.Drawing.Color.White
        Me.btnImagen.BackgroundImage = CType(resources.GetObject("btnImagen.BackgroundImage"), System.Drawing.Image)
        Me.btnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImagen.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagen.Location = New System.Drawing.Point(572, 300)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(60, 63)
        Me.btnImagen.TabIndex = 264
        Me.btnImagen.Text = "Imagen"
        Me.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImagen.UseVisualStyleBackColor = False
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.BackColor = System.Drawing.Color.White
        Me.btnImportar.BackgroundImage = CType(resources.GetObject("btnImportar.BackgroundImage"), System.Drawing.Image)
        Me.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Location = New System.Drawing.Point(8, 300)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(62, 63)
        Me.btnImportar.TabIndex = 263
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(704, 300)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 262
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(770, 300)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 261
        Me.btnNuevo.Text = "Limpiar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(638, 300)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 260
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'frmProductosSSerie
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(835, 371)
        Me.Controls.Add(Me.cboComanda)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cboubicacion)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtn_serie)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtrutaimagen)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtpcompra2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtutilidad)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.barsube)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnImagen)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.txtClaveSAT)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCodigoSAT)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.chkKIT)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboDepto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtpventa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtpcompra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUnidad)
        Me.Controls.Add(Me.cboProvP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboIVA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbarras)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboCodigo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductosSSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura (sencilla) de productos"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtrutaimagen As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtpcompra2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtutilidad As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents barsube As ProgressBar
    Friend WithEvents picImagen As PictureBox
    Friend WithEvents btnImagen As Button
    Friend WithEvents btnImportar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents txtClaveSAT As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCodigoSAT As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents chkKIT As CheckBox
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cboDepto As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtpventa As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtpcompra As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUnidad As TextBox
    Friend WithEvents cboProvP As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboIVA As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboNombre As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtbarras As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCodigo As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtn_serie As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboubicacion As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents cboComanda As ComboBox
    Friend WithEvents Label15 As Label
End Class
