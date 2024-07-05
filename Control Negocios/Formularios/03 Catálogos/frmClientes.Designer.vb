<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientes))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboRazon = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCredito = New System.Windows.Forms.TextBox()
        Me.chkSusp = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboRFC = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDias = New System.Windows.Forms.TextBox()
        Me.btnDomicilios = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuveo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Info = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtnexterior = New System.Windows.Forms.TextBox()
        Me.barsube = New System.Windows.Forms.ProgressBar()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtninterior = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtEntidad = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtDelegacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboregimen = New System.Windows.Forms.ComboBox()
        Me.txtClaveRegFis = New System.Windows.Forms.TextBox()
        Me.btnmigra = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnMsj = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtreferencia = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(878, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.Label1, "Los campos en amarillo son obligatorios")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre:"
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboNombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(76, 40)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(462, 23)
        Me.cboNombre.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Razón S:"
        '
        'cboRazon
        '
        Me.cboRazon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboRazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRazon.FormattingEnabled = True
        Me.cboRazon.Location = New System.Drawing.Point(76, 66)
        Me.cboRazon.Name = "cboRazon"
        Me.cboRazon.Size = New System.Drawing.Size(462, 23)
        Me.cboRazon.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(567, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tipo:"
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(606, 36)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(265, 23)
        Me.cboTipo.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(383, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 15)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Crédito:"
        '
        'txtCredito
        '
        Me.txtCredito.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCredito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCredito.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredito.Location = New System.Drawing.Point(438, 93)
        Me.txtCredito.Name = "txtCredito"
        Me.txtCredito.Size = New System.Drawing.Size(100, 23)
        Me.txtCredito.TabIndex = 11
        Me.txtCredito.Text = "0.00"
        Me.txtCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkSusp
        '
        Me.chkSusp.AutoSize = True
        Me.chkSusp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSusp.Location = New System.Drawing.Point(8, 179)
        Me.chkSusp.Name = "chkSusp"
        Me.chkSusp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSusp.Size = New System.Drawing.Size(113, 19)
        Me.chkSusp.TabIndex = 23
        Me.chkSusp.Text = "Suspender venta"
        Me.chkSusp.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(567, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "RFC:"
        '
        'cboRFC
        '
        Me.cboRFC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboRFC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRFC.FormattingEnabled = True
        Me.cboRFC.Location = New System.Drawing.Point(606, 63)
        Me.cboRFC.Name = "cboRFC"
        Me.cboRFC.Size = New System.Drawing.Size(265, 23)
        Me.cboRFC.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 15)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Días cred:"
        '
        'txtDias
        '
        Me.txtDias.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDias.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDias.Location = New System.Drawing.Point(76, 92)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.Size = New System.Drawing.Size(91, 23)
        Me.txtDias.TabIndex = 26
        Me.txtDias.Text = "0"
        Me.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDomicilios
        '
        Me.btnDomicilios.BackgroundImage = CType(resources.GetObject("btnDomicilios.BackgroundImage"), System.Drawing.Image)
        Me.btnDomicilios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnDomicilios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDomicilios.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDomicilios.Location = New System.Drawing.Point(606, 173)
        Me.btnDomicilios.Name = "btnDomicilios"
        Me.btnDomicilios.Size = New System.Drawing.Size(70, 63)
        Me.btnDomicilios.TabIndex = 31
        Me.btnDomicilios.Text = "Domicilios"
        Me.btnDomicilios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDomicilios.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(681, 173)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 30
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(746, 173)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 29
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuveo
        '
        Me.btnNuveo.BackgroundImage = CType(resources.GetObject("btnNuveo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuveo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuveo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuveo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuveo.Location = New System.Drawing.Point(811, 173)
        Me.btnNuveo.Name = "btnNuveo"
        Me.btnNuveo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuveo.TabIndex = 28
        Me.btnNuveo.Text = "Nuevo"
        Me.btnNuveo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuveo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(541, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Vendedor:"
        '
        'cboVendedor
        '
        Me.cboVendedor.BackColor = System.Drawing.Color.White
        Me.cboVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVendedor.FormattingEnabled = True
        Me.cboVendedor.Location = New System.Drawing.Point(606, 90)
        Me.cboVendedor.Name = "cboVendedor"
        Me.cboVendedor.Size = New System.Drawing.Size(265, 23)
        Me.cboVendedor.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 122)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Teléfono:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.Color.White
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(76, 118)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(462, 23)
        Me.txtTelefono.TabIndex = 34
        '
        'Info
        '
        Me.Info.AutoSize = True
        Me.Info.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Info.Location = New System.Drawing.Point(8, 225)
        Me.Info.Name = "Info"
        Me.Info.Size = New System.Drawing.Size(104, 13)
        Me.Info.TabIndex = 36
        Me.Info.Text = "> Más información"
        '
        'txtCorreo
        '
        Me.txtCorreo.BackColor = System.Drawing.Color.White
        Me.txtCorreo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtCorreo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorreo.Location = New System.Drawing.Point(76, 199)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(237, 23)
        Me.txtCorreo.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.txtCorreo, "Correo para el envío de facturas")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Correos:"
        Me.ToolTip1.SetToolTip(Me.Label10, "Correo para el envío de facturas")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtnexterior)
        Me.GroupBox1.Controls.Add(Me.barsube)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtninterior)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtPais)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtEntidad)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtCP)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtDelegacion)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtColonia)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 248)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(868, 143)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(389, 55)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 15)
        Me.Label18.TabIndex = 44
        Me.Label18.Text = "N. Exterior:"
        '
        'txtnexterior
        '
        Me.txtnexterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnexterior.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnexterior.Location = New System.Drawing.Point(460, 52)
        Me.txtnexterior.Name = "txtnexterior"
        Me.txtnexterior.Size = New System.Drawing.Size(174, 23)
        Me.txtnexterior.TabIndex = 43
        '
        'barsube
        '
        Me.barsube.Location = New System.Drawing.Point(306, -6)
        Me.barsube.Name = "barsube"
        Me.barsube.Size = New System.Drawing.Size(66, 14)
        Me.barsube.TabIndex = 221
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 15)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "N. Interior:"
        '
        'txtninterior
        '
        Me.txtninterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtninterior.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtninterior.Location = New System.Drawing.Point(76, 49)
        Me.txtninterior.Name = "txtninterior"
        Me.txtninterior.Size = New System.Drawing.Size(310, 23)
        Me.txtninterior.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(423, 112)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 15)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Pais:"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.Location = New System.Drawing.Point(460, 109)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(402, 23)
        Me.txtPais.TabIndex = 39
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(50, 15)
        Me.Label16.TabIndex = 38
        Me.Label16.Text = "Entidad:"
        '
        'txtEntidad
        '
        Me.txtEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEntidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntidad.Location = New System.Drawing.Point(76, 109)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.Size = New System.Drawing.Size(310, 23)
        Me.txtEntidad.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(640, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 15)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "CP:"
        '
        'txtCP
        '
        Me.txtCP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCP.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCP.Location = New System.Drawing.Point(677, 52)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(185, 23)
        Me.txtCP.TabIndex = 35
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(402, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 15)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "Alcaldía:"
        '
        'txtDelegacion
        '
        Me.txtDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelegacion.Location = New System.Drawing.Point(460, 81)
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.Size = New System.Drawing.Size(402, 23)
        Me.txtDelegacion.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Colonia:"
        '
        'txtColonia
        '
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColonia.Location = New System.Drawing.Point(76, 79)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(310, 23)
        Me.txtColonia.TabIndex = 30
        '
        'txtCalle
        '
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalle.Location = New System.Drawing.Point(76, 20)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(786, 23)
        Me.txtCalle.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Calle:"
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.White
        Me.txtId.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(1028, 206)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(56, 23)
        Me.txtId.TabIndex = 40
        Me.txtId.Visible = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 148)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 19)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "Regimen Fiscal:"
        '
        'cboregimen
        '
        Me.cboregimen.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboregimen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboregimen.FormattingEnabled = True
        Me.cboregimen.Location = New System.Drawing.Point(103, 144)
        Me.cboregimen.Name = "cboregimen"
        Me.cboregimen.Size = New System.Drawing.Size(768, 23)
        Me.cboregimen.TabIndex = 41
        '
        'txtClaveRegFis
        '
        Me.txtClaveRegFis.BackColor = System.Drawing.Color.White
        Me.txtClaveRegFis.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveRegFis.Location = New System.Drawing.Point(1028, 179)
        Me.txtClaveRegFis.Name = "txtClaveRegFis"
        Me.txtClaveRegFis.Size = New System.Drawing.Size(56, 23)
        Me.txtClaveRegFis.TabIndex = 43
        Me.txtClaveRegFis.Visible = False
        '
        'btnmigra
        '
        Me.btnmigra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnmigra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnmigra.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmigra.Image = CType(resources.GetObject("btnmigra.Image"), System.Drawing.Image)
        Me.btnmigra.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnmigra.Location = New System.Drawing.Point(386, 173)
        Me.btnmigra.Name = "btnmigra"
        Me.btnmigra.Size = New System.Drawing.Size(70, 63)
        Me.btnmigra.TabIndex = 48
        Me.btnmigra.Text = "Migración"
        Me.btnmigra.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnmigra.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(541, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 63)
        Me.Button1.TabIndex = 216
        Me.Button1.Text = "Reporte"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(127, 177)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(186, 19)
        Me.Label20.TabIndex = 217
        Me.Label20.Text = "correo@gmail.com,c@gamil.com"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(1030, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(311, 123)
        Me.DataGridView1.TabIndex = 219
        Me.DataGridView1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(316, 173)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 63)
        Me.Button2.TabIndex = 222
        Me.Button2.Text = "Importar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnMsj
        '
        Me.btnMsj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMsj.Enabled = False
        Me.btnMsj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMsj.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMsj.Image = CType(resources.GetObject("btnMsj.Image"), System.Drawing.Image)
        Me.btnMsj.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMsj.Location = New System.Drawing.Point(460, 173)
        Me.btnMsj.Name = "btnMsj"
        Me.btnMsj.Size = New System.Drawing.Size(78, 63)
        Me.btnMsj.TabIndex = 223
        Me.btnMsj.Text = "Whatsapp"
        Me.btnMsj.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMsj.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(538, 122)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 15)
        Me.Label21.TabIndex = 225
        Me.Label21.Text = "Referencia"
        '
        'txtreferencia
        '
        Me.txtreferencia.BackColor = System.Drawing.Color.White
        Me.txtreferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtreferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreferencia.Location = New System.Drawing.Point(606, 118)
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(267, 23)
        Me.txtreferencia.TabIndex = 224
        '
        'frmClientes
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 260)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtreferencia)
        Me.Controls.Add(Me.btnMsj)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnmigra)
        Me.Controls.Add(Me.txtClaveRegFis)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboregimen)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCorreo)
        Me.Controls.Add(Me.Info)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboVendedor)
        Me.Controls.Add(Me.btnDomicilios)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuveo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboRFC)
        Me.Controls.Add(Me.chkSusp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCredito)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboRazon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboNombre)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(837, 290)
        Me.Name = "frmClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de clientes constantes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboRazon As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCredito As System.Windows.Forms.TextBox
    Friend WithEvents chkSusp As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboRFC As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDias As System.Windows.Forms.TextBox
    Friend WithEvents btnDomicilios As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuveo As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Info As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtEntidad As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboregimen As System.Windows.Forms.ComboBox
    Friend WithEvents txtClaveRegFis As System.Windows.Forms.TextBox
    Friend WithEvents btnmigra As System.Windows.Forms.Button
    Friend WithEvents Label18 As Label
    Friend WithEvents txtnexterior As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtninterior As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents barsube As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents btnMsj As Button
    Friend WithEvents Label21 As Label
    Friend WithEvents txtreferencia As TextBox
End Class
