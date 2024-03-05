<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProductos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductos))
        Me.cboCodigo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboIVA = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboProvP = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboProvE = New System.Windows.Forms.ComboBox()
        Me.txtMaxima = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtActual = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMinima = New System.Windows.Forms.TextBox()
        Me.cboDepto = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNombreL = New System.Windows.Forms.TextBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblexistencia = New System.Windows.Forms.Label()
        Me.txtMinimo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMaximo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtComi = New System.Windows.Forms.TextBox()
        Me.chkKIT = New System.Windows.Forms.CheckBox()
        Me.txtCodigoSAT = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtClaveSAT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.barsube = New System.Windows.Forms.ProgressBar()
        Me.tip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtmultiplo = New System.Windows.Forms.TextBox()
        Me.lblConv2 = New System.Windows.Forms.Label()
        Me.txtmcd = New System.Windows.Forms.TextBox()
        Me.lblConv1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboMoneda = New System.Windows.Forms.ComboBox()
        Me.txtIEPS = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtRetIVA = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.txtrutaimagen = New System.Windows.Forms.TextBox()
        Me.chkUnico = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboubicacion = New System.Windows.Forms.ComboBox()
        Me.cboComanda = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCodigo
        '
        Me.cboCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodigo.FormattingEnabled = True
        Me.cboCodigo.Location = New System.Drawing.Point(8, 91)
        Me.cboCodigo.Name = "cboCodigo"
        Me.cboCodigo.Size = New System.Drawing.Size(85, 23)
        Me.cboCodigo.TabIndex = 77
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 21)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 23)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Código de barras"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbarras
        '
        Me.txtbarras.BackColor = System.Drawing.Color.White
        Me.txtbarras.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbarras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarras.Location = New System.Drawing.Point(125, 41)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(393, 23)
        Me.txtbarras.TabIndex = 92
        Me.txtbarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(96, 91)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(422, 23)
        Me.cboNombre.TabIndex = 94
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(96, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(423, 21)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Descripción corta para ticket"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboIVA
        '
        Me.cboIVA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboIVA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIVA.FormattingEnabled = True
        Me.cboIVA.Items.AddRange(New Object() {"0", "0.16"})
        Me.cboIVA.Location = New System.Drawing.Point(8, 215)
        Me.cboIVA.Name = "cboIVA"
        Me.cboIVA.Size = New System.Drawing.Size(78, 23)
        Me.cboIVA.TabIndex = 96
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 21)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "IVA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProvP
        '
        Me.cboProvP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboProvP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvP.FormattingEnabled = True
        Me.cboProvP.Location = New System.Drawing.Point(525, 65)
        Me.cboProvP.Name = "cboProvP"
        Me.cboProvP.Size = New System.Drawing.Size(208, 23)
        Me.cboProvP.TabIndex = 98
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(525, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(208, 21)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Proveedor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboProvE
        '
        Me.cboProvE.BackColor = System.Drawing.Color.White
        Me.cboProvE.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProvE.FormattingEnabled = True
        Me.cboProvE.Location = New System.Drawing.Point(525, 91)
        Me.cboProvE.Name = "cboProvE"
        Me.cboProvE.Size = New System.Drawing.Size(208, 23)
        Me.cboProvE.TabIndex = 99
        '
        'txtMaxima
        '
        Me.txtMaxima.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMaxima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaxima.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxima.Location = New System.Drawing.Point(89, 215)
        Me.txtMaxima.Name = "txtMaxima"
        Me.txtMaxima.Size = New System.Drawing.Size(93, 23)
        Me.txtMaxima.TabIndex = 100
        Me.txtMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(89, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 21)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Unidad Máxima"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.tip.SetToolTip(Me.Label6, "Se refiere a la máxima unidad del producto," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "esta generalmente es la unidad de co" &
        "mpra" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "del mismo.")
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(89, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(285, 21)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Unidades (PZA, TON, KG, BLT, PAQ, etc.)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtActual
        '
        Me.txtActual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtActual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtActual.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActual.Location = New System.Drawing.Point(185, 215)
        Me.txtActual.Name = "txtActual"
        Me.txtActual.Size = New System.Drawing.Size(93, 23)
        Me.txtActual.TabIndex = 102
        Me.txtActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(281, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 21)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Unidad Mínima"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.tip.SetToolTip(Me.Label8, "Se refiere a la mínima unidad del producto," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "esta generalmente es la unidad más p" &
        "equeña" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "permitida de venta para el producto.")
        '
        'txtMinima
        '
        Me.txtMinima.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMinima.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMinima.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinima.Location = New System.Drawing.Point(281, 215)
        Me.txtMinima.Name = "txtMinima"
        Me.txtMinima.Size = New System.Drawing.Size(93, 23)
        Me.txtMinima.TabIndex = 104
        Me.txtMinima.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboDepto
        '
        Me.cboDepto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDepto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepto.FormattingEnabled = True
        Me.cboDepto.Location = New System.Drawing.Point(525, 141)
        Me.cboDepto.Name = "cboDepto"
        Me.cboDepto.Size = New System.Drawing.Size(208, 23)
        Me.cboDepto.TabIndex = 107
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(525, 117)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(208, 21)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Departamento"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(510, 21)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Descripción larga (COINCIDENCIAS)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNombreL
        '
        Me.txtNombreL.BackColor = System.Drawing.Color.White
        Me.txtNombreL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreL.Location = New System.Drawing.Point(8, 141)
        Me.txtNombreL.Name = "txtNombreL"
        Me.txtNombreL.Size = New System.Drawing.Size(510, 23)
        Me.txtNombreL.TabIndex = 108
        '
        'cboGrupo
        '
        Me.cboGrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboGrupo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(525, 191)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(208, 23)
        Me.cboGrupo.TabIndex = 111
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(525, 167)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(185, 21)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Grupo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(713, 167)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(20, 21)
        Me.Label12.TabIndex = 112
        Me.Label12.Text = "?"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.tip.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
        '
        'lblexistencia
        '
        Me.lblexistencia.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblexistencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblexistencia.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblexistencia.ForeColor = System.Drawing.Color.White
        Me.lblexistencia.Location = New System.Drawing.Point(525, 217)
        Me.lblexistencia.Name = "lblexistencia"
        Me.lblexistencia.Size = New System.Drawing.Size(208, 21)
        Me.lblexistencia.TabIndex = 116
        Me.lblexistencia.Text = "Moneda"
        Me.lblexistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMinimo
        '
        Me.txtMinimo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMinimo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMinimo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimo.Location = New System.Drawing.Point(380, 192)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Size = New System.Drawing.Size(139, 22)
        Me.txtMinimo.TabIndex = 118
        Me.txtMinimo.Text = "0"
        Me.txtMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(380, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(138, 22)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "Mínimo en almacén:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(380, 266)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 21)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "Comisión ($):"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMaximo
        '
        Me.txtMaximo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMaximo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaximo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaximo.Location = New System.Drawing.Point(379, 241)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Size = New System.Drawing.Size(140, 22)
        Me.txtMaximo.TabIndex = 121
        Me.txtMaximo.Text = "0"
        Me.txtMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(380, 217)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(138, 22)
        Me.Label17.TabIndex = 120
        Me.Label17.Text = "Máximo en almacén:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtComi
        '
        Me.txtComi.BackColor = System.Drawing.Color.White
        Me.txtComi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComi.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComi.Location = New System.Drawing.Point(380, 292)
        Me.txtComi.Name = "txtComi"
        Me.txtComi.Size = New System.Drawing.Size(139, 23)
        Me.txtComi.TabIndex = 122
        Me.txtComi.Text = "0"
        Me.txtComi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkKIT
        '
        Me.chkKIT.AutoSize = True
        Me.chkKIT.Location = New System.Drawing.Point(593, 375)
        Me.chkKIT.Name = "chkKIT"
        Me.chkKIT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkKIT.Size = New System.Drawing.Size(140, 19)
        Me.chkKIT.TabIndex = 123
        Me.chkKIT.Text = "Este registro es un KIT"
        Me.chkKIT.UseVisualStyleBackColor = True
        '
        'txtCodigoSAT
        '
        Me.txtCodigoSAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCodigoSAT.BackColor = System.Drawing.Color.White
        Me.txtCodigoSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSAT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoSAT.Location = New System.Drawing.Point(125, 351)
        Me.txtCodigoSAT.Name = "txtCodigoSAT"
        Me.txtCodigoSAT.Size = New System.Drawing.Size(170, 23)
        Me.txtCodigoSAT.TabIndex = 125
        Me.txtCodigoSAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(8, 351)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 23)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "Código SAT"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtClaveSAT
        '
        Me.txtClaveSAT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtClaveSAT.BackColor = System.Drawing.Color.White
        Me.txtClaveSAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveSAT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveSAT.Location = New System.Drawing.Point(415, 351)
        Me.txtClaveSAT.Name = "txtClaveSAT"
        Me.txtClaveSAT.Size = New System.Drawing.Size(170, 23)
        Me.txtClaveSAT.TabIndex = 127
        Me.txtClaveSAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label18.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(298, 351)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 23)
        Me.Label18.TabIndex = 126
        Me.Label18.Text = "Unidad SAT"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(459, 400)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 137
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
        Me.btnNuevo.Location = New System.Drawing.Point(525, 400)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 136
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(393, 400)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 135
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnImportar
        '
        Me.btnImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImportar.BackColor = System.Drawing.Color.White
        Me.btnImportar.BackgroundImage = CType(resources.GetObject("btnImportar.BackgroundImage"), System.Drawing.Image)
        Me.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Location = New System.Drawing.Point(8, 400)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(62, 49)
        Me.btnImportar.TabIndex = 138
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.tip.SetToolTip(Me.btnImportar, "En esta pantalla se importa el archivo:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "'Importar productos completo'")
        Me.btnImportar.UseVisualStyleBackColor = False
        '
        'btnImagen
        '
        Me.btnImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImagen.BackColor = System.Drawing.Color.White
        Me.btnImagen.BackgroundImage = CType(resources.GetObject("btnImagen.BackgroundImage"), System.Drawing.Image)
        Me.btnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImagen.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagen.Location = New System.Drawing.Point(327, 400)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(60, 63)
        Me.btnImagen.TabIndex = 139
        Me.btnImagen.Text = "Imagen"
        Me.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImagen.UseVisualStyleBackColor = False
        '
        'picImagen
        '
        Me.picImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picImagen.Location = New System.Drawing.Point(257, 400)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(64, 63)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 140
        Me.picImagen.TabStop = False
        '
        'barsube
        '
        Me.barsube.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.barsube.Location = New System.Drawing.Point(8, 449)
        Me.barsube.Name = "barsube"
        Me.barsube.Size = New System.Drawing.Size(62, 14)
        Me.barsube.TabIndex = 141
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(185, 191)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 21)
        Me.Label19.TabIndex = 177
        Me.Label19.Text = "Unidad Actual"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.tip.SetToolTip(Me.Label19, "Se refiera a la unidad empleada para el código" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "actual, es decir, la unidad de ve" &
        "nta de este" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "producto.")
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(737, 31)
        Me.Label14.TabIndex = 176
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(8, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(78, 21)
        Me.Label20.TabIndex = 178
        Me.Label20.Text = "(0, 0.16)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtmultiplo)
        Me.Panel1.Controls.Add(Me.lblConv2)
        Me.Panel1.Controls.Add(Me.txtmcd)
        Me.Panel1.Controls.Add(Me.lblConv1)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Location = New System.Drawing.Point(8, 241)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(366, 73)
        Me.Panel1.TabIndex = 179
        '
        'txtmultiplo
        '
        Me.txtmultiplo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmultiplo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmultiplo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmultiplo.Location = New System.Drawing.Point(289, 47)
        Me.txtmultiplo.Name = "txtmultiplo"
        Me.txtmultiplo.Size = New System.Drawing.Size(73, 22)
        Me.txtmultiplo.TabIndex = 182
        Me.txtmultiplo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConv2
        '
        Me.lblConv2.BackColor = System.Drawing.Color.White
        Me.lblConv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConv2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConv2.ForeColor = System.Drawing.Color.Black
        Me.lblConv2.Location = New System.Drawing.Point(2, 47)
        Me.lblConv2.Name = "lblConv2"
        Me.lblConv2.Size = New System.Drawing.Size(284, 22)
        Me.lblConv2.TabIndex = 181
        Me.lblConv2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtmcd
        '
        Me.txtmcd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtmcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmcd.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmcd.Location = New System.Drawing.Point(289, 23)
        Me.txtmcd.Name = "txtmcd"
        Me.txtmcd.Size = New System.Drawing.Size(73, 22)
        Me.txtmcd.TabIndex = 180
        Me.txtmcd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConv1
        '
        Me.lblConv1.BackColor = System.Drawing.Color.White
        Me.lblConv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblConv1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConv1.ForeColor = System.Drawing.Color.Black
        Me.lblConv1.Location = New System.Drawing.Point(2, 23)
        Me.lblConv1.Name = "lblConv1"
        Me.lblConv1.Size = New System.Drawing.Size(284, 22)
        Me.lblConv1.TabIndex = 179
        Me.lblConv1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(364, 21)
        Me.Label21.TabIndex = 178
        Me.Label21.Text = "EQUIVALENCIAS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboMoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.FormattingEnabled = True
        Me.cboMoneda.Location = New System.Drawing.Point(525, 241)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(208, 23)
        Me.cboMoneda.TabIndex = 180
        '
        'txtIEPS
        '
        Me.txtIEPS.BackColor = System.Drawing.Color.White
        Me.txtIEPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIEPS.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIEPS.Location = New System.Drawing.Point(646, 318)
        Me.txtIEPS.Name = "txtIEPS"
        Me.txtIEPS.Size = New System.Drawing.Size(87, 22)
        Me.txtIEPS.TabIndex = 184
        Me.txtIEPS.Text = "0"
        Me.txtIEPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(525, 318)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(118, 22)
        Me.Label24.TabIndex = 183
        Me.Label24.Text = "IEPS (%)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRetIVA
        '
        Me.txtRetIVA.BackColor = System.Drawing.Color.White
        Me.txtRetIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRetIVA.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetIVA.Location = New System.Drawing.Point(646, 293)
        Me.txtRetIVA.Name = "txtRetIVA"
        Me.txtRetIVA.Size = New System.Drawing.Size(87, 22)
        Me.txtRetIVA.TabIndex = 182
        Me.txtRetIVA.Text = "0"
        Me.txtRetIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label25.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(525, 293)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(118, 22)
        Me.Label25.TabIndex = 181
        Me.Label25.Text = "Retención de IVA (%)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Location = New System.Drawing.Point(8, 528)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.Size = New System.Drawing.Size(577, 144)
        Me.grdcaptura.TabIndex = 227
        '
        'txtrutaimagen
        '
        Me.txtrutaimagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtrutaimagen.BackColor = System.Drawing.Color.White
        Me.txtrutaimagen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtrutaimagen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrutaimagen.Location = New System.Drawing.Point(76, 440)
        Me.txtrutaimagen.Name = "txtrutaimagen"
        Me.txtrutaimagen.Size = New System.Drawing.Size(175, 23)
        Me.txtrutaimagen.TabIndex = 232
        '
        'chkUnico
        '
        Me.chkUnico.AutoSize = True
        Me.chkUnico.Location = New System.Drawing.Point(625, 343)
        Me.chkUnico.Name = "chkUnico"
        Me.chkUnico.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkUnico.Size = New System.Drawing.Size(108, 19)
        Me.chkUnico.TabIndex = 233
        Me.chkUnico.Text = "Producto único"
        Me.chkUnico.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(525, 267)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 23)
        Me.Label22.TabIndex = 234
        Me.Label22.Text = "Ubicación"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboubicacion
        '
        Me.cboubicacion.BackColor = System.Drawing.Color.White
        Me.cboubicacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboubicacion.FormattingEnabled = True
        Me.cboubicacion.Location = New System.Drawing.Point(596, 267)
        Me.cboubicacion.Name = "cboubicacion"
        Me.cboubicacion.Size = New System.Drawing.Size(137, 23)
        Me.cboubicacion.TabIndex = 235
        '
        'cboComanda
        '
        Me.cboComanda.BackColor = System.Drawing.Color.White
        Me.cboComanda.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComanda.FormattingEnabled = True
        Me.cboComanda.Location = New System.Drawing.Point(195, 320)
        Me.cboComanda.Name = "cboComanda"
        Me.cboComanda.Size = New System.Drawing.Size(179, 23)
        Me.cboComanda.TabIndex = 243
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(8, 318)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(184, 23)
        Me.Label23.TabIndex = 242
        Me.Label23.Text = "Imprimir orden de entrega en:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmProductos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(737, 475)
        Me.Controls.Add(Me.cboComanda)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cboubicacion)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.chkUnico)
        Me.Controls.Add(Me.txtrutaimagen)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.txtIEPS)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtRetIVA)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cboMoneda)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
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
        Me.Controls.Add(Me.txtComi)
        Me.Controls.Add(Me.txtMaximo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtMinimo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblexistencia)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNombreL)
        Me.Controls.Add(Me.cboDepto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtMinima)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtActual)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMaxima)
        Me.Controls.Add(Me.cboProvE)
        Me.Controls.Add(Me.cboProvP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboIVA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtbarras)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboCodigo)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de productos (derivados)"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtbarras As System.Windows.Forms.TextBox
    Friend WithEvents cboNombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboIVA As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboProvP As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboProvE As System.Windows.Forms.ComboBox
    Friend WithEvents txtMaxima As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtActual As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMinima As System.Windows.Forms.TextBox
    Friend WithEvents cboDepto As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNombreL As System.Windows.Forms.TextBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblexistencia As System.Windows.Forms.Label
    Friend WithEvents txtMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMaximo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtComi As System.Windows.Forms.TextBox
    Friend WithEvents chkKIT As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodigoSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtClaveSAT As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnImagen As System.Windows.Forms.Button
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents barsube As System.Windows.Forms.ProgressBar
    Friend WithEvents tip As System.Windows.Forms.ToolTip
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtmultiplo As System.Windows.Forms.TextBox
    Friend WithEvents lblConv2 As System.Windows.Forms.Label
    Friend WithEvents txtmcd As System.Windows.Forms.TextBox
    Friend WithEvents lblConv1 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents txtIEPS As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtRetIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents txtrutaimagen As System.Windows.Forms.TextBox
    Friend WithEvents chkUnico As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents cboubicacion As ComboBox
    Friend WithEvents cboComanda As ComboBox
    Friend WithEvents Label23 As Label
End Class
