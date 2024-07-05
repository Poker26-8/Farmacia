<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehiculos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVehiculos))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtchofer = New System.Windows.Forms.TextBox()
        Me.cboarea = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtplacas = New System.Windows.Forms.TextBox()
        Me.cbomarca = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbomodelo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtcontacto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtagente = New System.Windows.Forms.TextBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.dtpvencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtpoliza = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtseguros = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpaceite_prox = New System.Windows.Forms.DateTimePicker()
        Me.dtpafinacion_prox = New System.Windows.Forms.DateTimePicker()
        Me.dtpaceite_ant = New System.Windows.Forms.DateTimePicker()
        Me.dtpafinacion_ant = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbovencimiento2 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbovencimiento1 = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbonocircula = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtchofer)
        Me.GroupBox1.Controls.Add(Me.cboarea)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtplacas)
        Me.GroupBox1.Controls.Add(Me.cbomarca)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbomodelo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(247, 159)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vehículo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 15)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Chofer:"
        '
        'txtchofer
        '
        Me.txtchofer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchofer.Location = New System.Drawing.Point(72, 125)
        Me.txtchofer.Name = "txtchofer"
        Me.txtchofer.Size = New System.Drawing.Size(166, 23)
        Me.txtchofer.TabIndex = 8
        '
        'cboarea
        '
        Me.cboarea.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboarea.FormattingEnabled = True
        Me.cboarea.Location = New System.Drawing.Point(72, 99)
        Me.cboarea.Name = "cboarea"
        Me.cboarea.Size = New System.Drawing.Size(166, 23)
        Me.cboarea.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 15)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Área:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Placas:"
        '
        'txtplacas
        '
        Me.txtplacas.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplacas.Location = New System.Drawing.Point(72, 73)
        Me.txtplacas.Name = "txtplacas"
        Me.txtplacas.Size = New System.Drawing.Size(124, 23)
        Me.txtplacas.TabIndex = 4
        '
        'cbomarca
        '
        Me.cbomarca.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomarca.FormattingEnabled = True
        Me.cbomarca.Location = New System.Drawing.Point(72, 47)
        Me.cbomarca.Name = "cbomarca"
        Me.cbomarca.Size = New System.Drawing.Size(166, 23)
        Me.cbomarca.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Marca:"
        '
        'cbomodelo
        '
        Me.cbomodelo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomodelo.FormattingEnabled = True
        Me.cbomodelo.Location = New System.Drawing.Point(72, 21)
        Me.cbomodelo.Name = "cbomodelo"
        Me.cbomodelo.Size = New System.Drawing.Size(166, 23)
        Me.cbomodelo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Modelo:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtcontacto)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtagente)
        Me.GroupBox2.Controls.Add(Me.txttelefono)
        Me.GroupBox2.Controls.Add(Me.dtpvencimiento)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtpoliza)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtseguros)
        Me.GroupBox2.Location = New System.Drawing.Point(264, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 185)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seguro"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 155)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(59, 15)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Contacto:"
        '
        'txtcontacto
        '
        Me.txtcontacto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontacto.Location = New System.Drawing.Point(77, 151)
        Me.txtcontacto.Name = "txtcontacto"
        Me.txtcontacto.Size = New System.Drawing.Size(145, 23)
        Me.txtcontacto.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 129)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Agente:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 103)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 15)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Teléfono:"
        '
        'txtagente
        '
        Me.txtagente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtagente.Location = New System.Drawing.Point(71, 125)
        Me.txtagente.Name = "txtagente"
        Me.txtagente.Size = New System.Drawing.Size(151, 23)
        Me.txtagente.TabIndex = 11
        '
        'txttelefono
        '
        Me.txttelefono.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttelefono.Location = New System.Drawing.Point(77, 99)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(145, 23)
        Me.txttelefono.TabIndex = 16
        '
        'dtpvencimiento
        '
        Me.dtpvencimiento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpvencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpvencimiento.Location = New System.Drawing.Point(139, 73)
        Me.dtpvencimiento.Name = "dtpvencimiento"
        Me.dtpvencimiento.Size = New System.Drawing.Size(83, 23)
        Me.dtpvencimiento.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 15)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Vencimiento:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Póliza:"
        '
        'txtpoliza
        '
        Me.txtpoliza.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpoliza.Location = New System.Drawing.Point(71, 47)
        Me.txtpoliza.Name = "txtpoliza"
        Me.txtpoliza.Size = New System.Drawing.Size(151, 23)
        Me.txtpoliza.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Seguros:"
        '
        'txtseguros
        '
        Me.txtseguros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtseguros.Location = New System.Drawing.Point(71, 21)
        Me.txtseguros.Name = "txtseguros"
        Me.txtseguros.Size = New System.Drawing.Size(151, 23)
        Me.txtseguros.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtpaceite_prox)
        Me.GroupBox3.Controls.Add(Me.dtpafinacion_prox)
        Me.GroupBox3.Controls.Add(Me.dtpaceite_ant)
        Me.GroupBox3.Controls.Add(Me.dtpafinacion_ant)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 192)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(247, 131)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mantenimiento"
        '
        'dtpaceite_prox
        '
        Me.dtpaceite_prox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpaceite_prox.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpaceite_prox.Location = New System.Drawing.Point(143, 98)
        Me.dtpaceite_prox.Name = "dtpaceite_prox"
        Me.dtpaceite_prox.Size = New System.Drawing.Size(95, 23)
        Me.dtpaceite_prox.TabIndex = 13
        '
        'dtpafinacion_prox
        '
        Me.dtpafinacion_prox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpafinacion_prox.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpafinacion_prox.Location = New System.Drawing.Point(143, 72)
        Me.dtpafinacion_prox.Name = "dtpafinacion_prox"
        Me.dtpafinacion_prox.Size = New System.Drawing.Size(95, 23)
        Me.dtpafinacion_prox.TabIndex = 12
        '
        'dtpaceite_ant
        '
        Me.dtpaceite_ant.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpaceite_ant.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpaceite_ant.Location = New System.Drawing.Point(143, 46)
        Me.dtpaceite_ant.Name = "dtpaceite_ant"
        Me.dtpaceite_ant.Size = New System.Drawing.Size(95, 23)
        Me.dtpaceite_ant.TabIndex = 11
        '
        'dtpafinacion_ant
        '
        Me.dtpafinacion_ant.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpafinacion_ant.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpafinacion_ant.Location = New System.Drawing.Point(143, 20)
        Me.dtpafinacion_ant.Name = "dtpafinacion_ant"
        Me.dtpafinacion_ant.Size = New System.Drawing.Size(95, 23)
        Me.dtpafinacion_ant.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Próximo c. de aceite:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 15)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Próxima afinación:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 15)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "C. de aceite anterior:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 15)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Afinación anterior:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cbovencimiento2)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.cbovencimiento1)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.cbonocircula)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Location = New System.Drawing.Point(264, 220)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(231, 103)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Verificación"
        '
        'cbovencimiento2
        '
        Me.cbovencimiento2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbovencimiento2.FormattingEnabled = True
        Me.cbovencimiento2.Location = New System.Drawing.Point(106, 18)
        Me.cbovencimiento2.Name = "cbovencimiento2"
        Me.cbovencimiento2.Size = New System.Drawing.Size(116, 23)
        Me.cbovencimiento2.TabIndex = 15
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 15)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Vencimiento 2:"
        '
        'cbovencimiento1
        '
        Me.cbovencimiento1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbovencimiento1.FormattingEnabled = True
        Me.cbovencimiento1.Location = New System.Drawing.Point(106, 44)
        Me.cbovencimiento1.Name = "cbovencimiento1"
        Me.cbovencimiento1.Size = New System.Drawing.Size(116, 23)
        Me.cbovencimiento1.TabIndex = 13
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(8, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 15)
        Me.Label18.TabIndex = 12
        Me.Label18.Text = "Vencimiento 1:"
        '
        'cbonocircula
        '
        Me.cbonocircula.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonocircula.FormattingEnabled = True
        Me.cbonocircula.Location = New System.Drawing.Point(84, 70)
        Me.cbonocircula.Name = "cbonocircula"
        Me.cbonocircula.Size = New System.Drawing.Size(138, 23)
        Me.cbonocircula.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 15)
        Me.Label17.TabIndex = 10
        Me.Label17.Text = "No circula:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-25, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(555, 31)
        Me.Label1.TabIndex = 42
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(369, 325)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 139
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.White
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(303, 325)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 140
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(435, 325)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 141
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'frmVehiculos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(504, 390)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVehiculos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de vehículos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
     Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
     Friend WithEvents cbomodelo As System.Windows.Forms.ComboBox
     Friend WithEvents Label2 As System.Windows.Forms.Label
     Friend WithEvents cboarea As System.Windows.Forms.ComboBox
     Friend WithEvents Label5 As System.Windows.Forms.Label
     Friend WithEvents Label4 As System.Windows.Forms.Label
     Friend WithEvents txtplacas As System.Windows.Forms.TextBox
     Friend WithEvents cbomarca As System.Windows.Forms.ComboBox
     Friend WithEvents Label3 As System.Windows.Forms.Label
     Friend WithEvents Label6 As System.Windows.Forms.Label
     Friend WithEvents txtchofer As System.Windows.Forms.TextBox
     Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
     Friend WithEvents dtpaceite_prox As System.Windows.Forms.DateTimePicker
     Friend WithEvents dtpafinacion_prox As System.Windows.Forms.DateTimePicker
     Friend WithEvents dtpaceite_ant As System.Windows.Forms.DateTimePicker
     Friend WithEvents dtpafinacion_ant As System.Windows.Forms.DateTimePicker
     Friend WithEvents Label8 As System.Windows.Forms.Label
     Friend WithEvents Label9 As System.Windows.Forms.Label
     Friend WithEvents Label10 As System.Windows.Forms.Label
     Friend WithEvents Label11 As System.Windows.Forms.Label
     Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
     Friend WithEvents Label16 As System.Windows.Forms.Label
     Friend WithEvents txtcontacto As System.Windows.Forms.TextBox
     Friend WithEvents Label15 As System.Windows.Forms.Label
     Friend WithEvents Label14 As System.Windows.Forms.Label
     Friend WithEvents txtagente As System.Windows.Forms.TextBox
     Friend WithEvents txttelefono As System.Windows.Forms.TextBox
     Friend WithEvents dtpvencimiento As System.Windows.Forms.DateTimePicker
     Friend WithEvents Label13 As System.Windows.Forms.Label
     Friend WithEvents Label12 As System.Windows.Forms.Label
     Friend WithEvents txtpoliza As System.Windows.Forms.TextBox
     Friend WithEvents Label7 As System.Windows.Forms.Label
     Friend WithEvents txtseguros As System.Windows.Forms.TextBox
     Friend WithEvents cbovencimiento2 As System.Windows.Forms.ComboBox
     Friend WithEvents Label19 As System.Windows.Forms.Label
     Friend WithEvents cbovencimiento1 As System.Windows.Forms.ComboBox
     Friend WithEvents Label18 As System.Windows.Forms.Label
     Friend WithEvents cbonocircula As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnNuevo As Button
End Class
