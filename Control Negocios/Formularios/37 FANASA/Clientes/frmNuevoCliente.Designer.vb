<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoCliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboSex = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtExtDir = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtIntDir = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtCpDir = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDelegacion = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboTipoTel = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboStatusTel = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboTipoDir = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblEstatus = New System.Windows.Forms.Label()
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
        Me.Label1.Size = New System.Drawing.Size(561, 31)
        Me.Label1.TabIndex = 262
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(106, 81)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(449, 22)
        Me.txtNombre.TabIndex = 264
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "NOMBRE:"
        '
        'txtApellido1
        '
        Me.txtApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellido1.Location = New System.Drawing.Point(106, 109)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(175, 22)
        Me.txtApellido1.TabIndex = 266
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "A. PATERNO:"
        '
        'txtApellido2
        '
        Me.txtApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApellido2.Location = New System.Drawing.Point(380, 109)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(175, 22)
        Me.txtApellido2.TabIndex = 268
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(286, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 16)
        Me.Label4.TabIndex = 267
        Me.Label4.Text = "A. MATERNO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 16)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "FECHA NAC."
        '
        'txtNacimiento
        '
        Me.txtNacimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtNacimiento.Location = New System.Drawing.Point(106, 139)
        Me.txtNacimiento.Name = "txtNacimiento"
        Me.txtNacimiento.Size = New System.Drawing.Size(175, 22)
        Me.txtNacimiento.TabIndex = 270
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(287, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "GENERO:"
        '
        'cboSex
        '
        Me.cboSex.BackColor = System.Drawing.Color.IndianRed
        Me.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSex.FormattingEnabled = True
        Me.cboSex.Items.AddRange(New Object() {"Masculino", "Femenino", "Otro"})
        Me.cboSex.Location = New System.Drawing.Point(380, 137)
        Me.cboSex.Name = "cboSex"
        Me.cboSex.Size = New System.Drawing.Size(175, 24)
        Me.cboSex.TabIndex = 272
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(106, 167)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(175, 22)
        Me.txtEmail.TabIndex = 274
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 273
        Me.Label7.Text = "CORREO:"
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(380, 167)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(175, 22)
        Me.txtTelefono.TabIndex = 276
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(286, 173)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "TELEFONO:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(150, 20)
        Me.Label10.TabIndex = 279
        Me.Label10.Text = "FOLIO TARJETA:"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTarjeta.Enabled = False
        Me.txtTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.Location = New System.Drawing.Point(168, 35)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(224, 26)
        Me.txtTarjeta.TabIndex = 280
        '
        'txtCalle
        '
        Me.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalle.Location = New System.Drawing.Point(86, 247)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(175, 22)
        Me.txtCalle.TabIndex = 282
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 253)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 16)
        Me.Label11.TabIndex = 281
        Me.Label11.Text = "CALLE:"
        '
        'txtExtDir
        '
        Me.txtExtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtDir.Location = New System.Drawing.Point(340, 247)
        Me.txtExtDir.Name = "txtExtDir"
        Me.txtExtDir.Size = New System.Drawing.Size(59, 22)
        Me.txtExtDir.TabIndex = 284
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(267, 253)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 16)
        Me.Label12.TabIndex = 283
        Me.Label12.Text = "NUM. EXT.:"
        '
        'txtIntDir
        '
        Me.txtIntDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIntDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIntDir.Location = New System.Drawing.Point(478, 247)
        Me.txtIntDir.Name = "txtIntDir"
        Me.txtIntDir.Size = New System.Drawing.Size(71, 22)
        Me.txtIntDir.TabIndex = 286
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(405, 250)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 285
        Me.Label13.Text = "NUM. INT.:"
        '
        'txtColonia
        '
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColonia.Location = New System.Drawing.Point(86, 275)
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(229, 22)
        Me.txtColonia.TabIndex = 288
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 281)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 16)
        Me.Label14.TabIndex = 287
        Me.Label14.Text = "COLONIA:"
        '
        'txtCpDir
        '
        Me.txtCpDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCpDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCpDir.Location = New System.Drawing.Point(374, 275)
        Me.txtCpDir.Name = "txtCpDir"
        Me.txtCpDir.Size = New System.Drawing.Size(175, 22)
        Me.txtCpDir.TabIndex = 290
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(340, 281)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 16)
        Me.Label15.TabIndex = 289
        Me.Label15.Text = "CP:"
        '
        'txtDelegacion
        '
        Me.txtDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelegacion.Location = New System.Drawing.Point(183, 303)
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.Size = New System.Drawing.Size(366, 22)
        Me.txtDelegacion.TabIndex = 292
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 309)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(171, 16)
        Me.Label16.TabIndex = 291
        Me.Label16.Text = "DELEGACION / MUNICIPIO"
        '
        'txtCiudad
        '
        Me.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiudad.Location = New System.Drawing.Point(86, 331)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(201, 22)
        Me.txtCiudad.TabIndex = 294
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 337)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 16)
        Me.Label17.TabIndex = 293
        Me.Label17.Text = "CIUDAD:"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Items.AddRange(New Object() {"AGUASCALIENTES", "BAJA CALIFORNIA", "BAJA CALIFORNIA SUR", "CAMPECHE", "CHIAPAS", "CHIHUAHUA", "CIUDAD DE MEXICO", "COAHUILA", "COLIMA", "DURANGO", "EXTRANJERO", "GUANAJUATO", "GUERRERO", "HIDALGO", "JALISCO", "MEXICO", "MICHOACAN", "MORELOS", "NAYARIT", "NUEVO LEON", "OAXACA", "PUEBLA", "QUERETARO", "QUINTANA ROO", "SAN LUIS POTOSI", "SINALOA", "SONORA", "TABASCO", "TAMAULIPAS", "TLAXCALA", "VERACRUZ", "YUCATAN", "ZACATECAS"})
        Me.cboEstado.Location = New System.Drawing.Point(374, 329)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(175, 24)
        Me.cboEstado.TabIndex = 296
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(293, 337)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 16)
        Me.Label18.TabIndex = 295
        Me.Label18.Text = "ESTADO:"
        '
        'txtPais
        '
        Me.txtPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPais.Location = New System.Drawing.Point(86, 359)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(201, 22)
        Me.txtPais.TabIndex = 298
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 365)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(40, 16)
        Me.Label19.TabIndex = 297
        Me.Label19.Text = "PAIS:"
        '
        'cboTipoTel
        '
        Me.cboTipoTel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoTel.FormattingEnabled = True
        Me.cboTipoTel.Items.AddRange(New Object() {"Casa", "Celular", "Trabajo", "Recados", "Otros"})
        Me.cboTipoTel.Location = New System.Drawing.Point(380, 195)
        Me.cboTipoTel.Name = "cboTipoTel"
        Me.cboTipoTel.Size = New System.Drawing.Size(175, 24)
        Me.cboTipoTel.TabIndex = 300
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(230, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(138, 16)
        Me.Label9.TabIndex = 299
        Me.Label9.Text = "TIPO DE TELEFONO:"
        '
        'cboStatusTel
        '
        Me.cboStatusTel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusTel.FormattingEnabled = True
        Me.cboStatusTel.Items.AddRange(New Object() {"Activo", "Inactivo"})
        Me.cboStatusTel.Location = New System.Drawing.Point(106, 195)
        Me.cboStatusTel.Name = "cboStatusTel"
        Me.cboStatusTel.Size = New System.Drawing.Size(118, 24)
        Me.cboStatusTel.TabIndex = 302
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 203)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 16)
        Me.Label20.TabIndex = 301
        Me.Label20.Text = "ESTATUS:"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(397, 396)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 68)
        Me.Button2.TabIndex = 303
        Me.Button2.Text = "Guardar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cboTipoDir
        '
        Me.cboTipoDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDir.FormattingEnabled = True
        Me.cboTipoDir.Items.AddRange(New Object() {"Envíos", "Facturación"})
        Me.cboTipoDir.Location = New System.Drawing.Point(374, 359)
        Me.cboTipoDir.Name = "cboTipoDir"
        Me.cboTipoDir.Size = New System.Drawing.Size(175, 24)
        Me.cboTipoDir.TabIndex = 305
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(293, 367)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(41, 16)
        Me.Label21.TabIndex = 304
        Me.Label21.Text = "TIPO:"
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(317, 396)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 68)
        Me.Button3.TabIndex = 307
        Me.Button3.Text = "Limpiar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(478, 396)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 68)
        Me.Button1.TabIndex = 306
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblEstatus.Location = New System.Drawing.Point(10, 420)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(300, 25)
        Me.lblEstatus.TabIndex = 308
        Me.lblEstatus.Text = "GUARDANDO REGISTRO..."
        Me.lblEstatus.Visible = False
        '
        'frmNuevoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(561, 476)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboTipoDir)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cboStatusTel)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboTipoTel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPais)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCiudad)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtDelegacion)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtCpDir)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtColonia)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtIntDir)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtExtDir)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCalle)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtTarjeta)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSex)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNacimiento)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtApellido2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtApellido1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(577, 515)
        Me.MinimumSize = New System.Drawing.Size(577, 515)
        Me.Name = "frmNuevoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Cliente FANASA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtApellido1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtApellido2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNacimiento As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents cboSex As ComboBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTarjeta As TextBox
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtExtDir As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtIntDir As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtColonia As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCpDir As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtDelegacion As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtCiudad As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPais As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboTipoTel As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cboStatusTel As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents cboTipoDir As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblEstatus As Label
End Class
