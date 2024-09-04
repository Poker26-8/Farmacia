<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPediatria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPediatria))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpAlergia = New System.Windows.Forms.DateTimePicker()
        Me.dtpNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMedida = New System.Windows.Forms.ComboBox()
        Me.txtTemperatura = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxMas = New System.Windows.Forms.CheckBox()
        Me.cbxFem = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtAlergias = New System.Windows.Forms.RichTextBox()
        Me.gbxMotivo = New System.Windows.Forms.GroupBox()
        Me.txtMotivo = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtT = New System.Windows.Forms.TextBox()
        Me.txtTelP = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTelM = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTutor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPapa = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMama = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboUrgencia = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboMedico = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.barsube = New System.Windows.Forms.ProgressBar()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbxMotivo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpAlergia)
        Me.GroupBox1.Controls.Add(Me.dtpNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cboMedida)
        Me.GroupBox1.Controls.Add(Me.txtTemperatura)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtPeso)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbxMas)
        Me.GroupBox1.Controls.Add(Me.cbxFem)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCliente)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 190)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paciente"
        '
        'dtpAlergia
        '
        Me.dtpAlergia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAlergia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAlergia.Location = New System.Drawing.Point(115, 156)
        Me.dtpAlergia.Name = "dtpAlergia"
        Me.dtpAlergia.Size = New System.Drawing.Size(146, 26)
        Me.dtpAlergia.TabIndex = 258
        '
        'dtpNacimiento
        '
        Me.dtpNacimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNacimiento.Location = New System.Drawing.Point(115, 124)
        Me.dtpNacimiento.Name = "dtpNacimiento"
        Me.dtpNacimiento.Size = New System.Drawing.Size(146, 26)
        Me.dtpNacimiento.TabIndex = 257
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 26)
        Me.Label6.TabIndex = 256
        Me.Label6.Text = "F.Alergia:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 26)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "F.Nacimiento:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMedida
        '
        Me.cboMedida.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMedida.FormattingEnabled = True
        Me.cboMedida.Items.AddRange(New Object() {"°C", "°F"})
        Me.cboMedida.Location = New System.Drawing.Point(224, 97)
        Me.cboMedida.Name = "cboMedida"
        Me.cboMedida.Size = New System.Drawing.Size(37, 22)
        Me.cboMedida.TabIndex = 254
        Me.cboMedida.Text = "°C"
        '
        'txtTemperatura
        '
        Me.txtTemperatura.BackColor = System.Drawing.Color.White
        Me.txtTemperatura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperatura.Location = New System.Drawing.Point(84, 92)
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.Size = New System.Drawing.Size(134, 26)
        Me.txtTemperatura.TabIndex = 253
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 26)
        Me.Label4.TabIndex = 252
        Me.Label4.Text = "TEMP:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(224, 68)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(33, 17)
        Me.Label23.TabIndex = 251
        Me.Label23.Text = "Kg."
        '
        'txtPeso
        '
        Me.txtPeso.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.Location = New System.Drawing.Point(84, 60)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(134, 26)
        Me.txtPeso.TabIndex = 250
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 26)
        Me.Label3.TabIndex = 249
        Me.Label3.Text = "PESO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxMas
        '
        Me.cbxMas.AutoSize = True
        Me.cbxMas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxMas.Location = New System.Drawing.Point(388, 66)
        Me.cbxMas.Name = "cbxMas"
        Me.cbxMas.Size = New System.Drawing.Size(41, 24)
        Me.cbxMas.TabIndex = 248
        Me.cbxMas.Text = "M"
        Me.cbxMas.UseVisualStyleBackColor = True
        '
        'cbxFem
        '
        Me.cbxFem.AutoSize = True
        Me.cbxFem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxFem.Location = New System.Drawing.Point(341, 65)
        Me.cbxFem.Name = "cbxFem"
        Me.cbxFem.Size = New System.Drawing.Size(38, 24)
        Me.cbxFem.TabIndex = 247
        Me.cbxFem.Text = "F"
        Me.cbxFem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(276, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "SEXO:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCliente
        '
        Me.cboCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(84, 28)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(355, 26)
        Me.cboCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.GroupBox4.Controls.Add(Me.txtAlergias)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(3, 199)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(445, 166)
        Me.GroupBox4.TabIndex = 244
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Alergias"
        '
        'txtAlergias
        '
        Me.txtAlergias.Font = New System.Drawing.Font("Bahnschrift SemiLight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlergias.Location = New System.Drawing.Point(6, 23)
        Me.txtAlergias.Name = "txtAlergias"
        Me.txtAlergias.Size = New System.Drawing.Size(433, 135)
        Me.txtAlergias.TabIndex = 0
        Me.txtAlergias.Text = ""
        '
        'gbxMotivo
        '
        Me.gbxMotivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.gbxMotivo.Controls.Add(Me.txtMotivo)
        Me.gbxMotivo.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!)
        Me.gbxMotivo.ForeColor = System.Drawing.Color.Black
        Me.gbxMotivo.Location = New System.Drawing.Point(3, 371)
        Me.gbxMotivo.Name = "gbxMotivo"
        Me.gbxMotivo.Size = New System.Drawing.Size(445, 174)
        Me.gbxMotivo.TabIndex = 245
        Me.gbxMotivo.TabStop = False
        Me.gbxMotivo.Text = "Ingrese el motivo de la consulta"
        '
        'txtMotivo
        '
        Me.txtMotivo.Font = New System.Drawing.Font("Bahnschrift SemiLight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.Location = New System.Drawing.Point(6, 23)
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(433, 145)
        Me.txtMotivo.TabIndex = 0
        Me.txtMotivo.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtT)
        Me.GroupBox2.Controls.Add(Me.txtTelP)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtTelM)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtTutor)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtPapa)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtMama)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(454, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(585, 130)
        Me.GroupBox2.TabIndex = 246
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Responsables"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(397, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 25)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Tel:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtT
        '
        Me.txtT.BackColor = System.Drawing.Color.White
        Me.txtT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT.Location = New System.Drawing.Point(435, 97)
        Me.txtT.Name = "txtT"
        Me.txtT.Size = New System.Drawing.Size(144, 26)
        Me.txtT.TabIndex = 263
        '
        'txtTelP
        '
        Me.txtTelP.BackColor = System.Drawing.Color.White
        Me.txtTelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelP.Location = New System.Drawing.Point(435, 62)
        Me.txtTelP.Name = "txtTelP"
        Me.txtTelP.Size = New System.Drawing.Size(144, 26)
        Me.txtTelP.TabIndex = 262
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(397, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 25)
        Me.Label11.TabIndex = 261
        Me.Label11.Text = "Tel:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTelM
        '
        Me.txtTelM.BackColor = System.Drawing.Color.White
        Me.txtTelM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelM.Location = New System.Drawing.Point(435, 27)
        Me.txtTelM.Name = "txtTelM"
        Me.txtTelM.Size = New System.Drawing.Size(144, 26)
        Me.txtTelM.TabIndex = 260
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(397, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 25)
        Me.Label10.TabIndex = 259
        Me.Label10.Text = "Tel:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTutor
        '
        Me.txtTutor.BackColor = System.Drawing.Color.White
        Me.txtTutor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTutor.Location = New System.Drawing.Point(63, 96)
        Me.txtTutor.Name = "txtTutor"
        Me.txtTutor.Size = New System.Drawing.Size(328, 26)
        Me.txtTutor.TabIndex = 258
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 26)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Tutor:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPapa
        '
        Me.txtPapa.BackColor = System.Drawing.Color.White
        Me.txtPapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPapa.Location = New System.Drawing.Point(63, 62)
        Me.txtPapa.Name = "txtPapa"
        Me.txtPapa.Size = New System.Drawing.Size(328, 26)
        Me.txtPapa.TabIndex = 256
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 27)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "Papá:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMama
        '
        Me.txtMama.BackColor = System.Drawing.Color.White
        Me.txtMama.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMama.Location = New System.Drawing.Point(63, 28)
        Me.txtMama.Name = "txtMama"
        Me.txtMama.Size = New System.Drawing.Size(328, 26)
        Me.txtMama.TabIndex = 254
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 26)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Mamá:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboUrgencia)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.cboMedico)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(454, 139)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(585, 97)
        Me.GroupBox3.TabIndex = 247
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Médico"
        '
        'cboUrgencia
        '
        Me.cboUrgencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUrgencia.FormattingEnabled = True
        Me.cboUrgencia.Location = New System.Drawing.Point(145, 60)
        Me.cboUrgencia.Name = "cboUrgencia"
        Me.cboUrgencia.Size = New System.Drawing.Size(200, 26)
        Me.cboUrgencia.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 60)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(140, 26)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Nivel de Urgencia:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMedico
        '
        Me.cboMedico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMedico.FormattingEnabled = True
        Me.cboMedico.Location = New System.Drawing.Point(83, 29)
        Me.cboMedico.Name = "cboMedico"
        Me.cboMedico.Size = New System.Drawing.Size(496, 26)
        Me.cboMedico.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 26)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Nombre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ForeColor = System.Drawing.Color.Black
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(892, 242)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(71, 86)
        Me.btnLimpiar.TabIndex = 253
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(968, 242)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(71, 86)
        Me.btnSalir.TabIndex = 252
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(804, 242)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(83, 86)
        Me.btnSave.TabIndex = 249
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'barsube
        '
        Me.barsube.Location = New System.Drawing.Point(580, 242)
        Me.barsube.Margin = New System.Windows.Forms.Padding(2)
        Me.barsube.Name = "barsube"
        Me.barsube.Size = New System.Drawing.Size(90, 10)
        Me.barsube.TabIndex = 251
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(649, 259)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(21, 19)
        Me.DataGridView1.TabIndex = 250
        Me.DataGridView1.Visible = False
        '
        'btnExportar
        '
        Me.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExportar.Location = New System.Drawing.Point(674, 242)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(125, 86)
        Me.btnExportar.TabIndex = 248
        Me.btnExportar.Text = "Importar padecimientos"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmPediatria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1041, 550)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.barsube)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbxMotivo)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPediatria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Regsitro de paciente"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.gbxMotivo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbxMas As CheckBox
    Friend WithEvents cbxFem As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpAlergia As DateTimePicker
    Friend WithEvents dtpNacimiento As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cboMedida As ComboBox
    Friend WithEvents txtTemperatura As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtAlergias As RichTextBox
    Friend WithEvents gbxMotivo As GroupBox
    Friend WithEvents txtMotivo As RichTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtT As TextBox
    Friend WithEvents txtTelP As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTelM As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTutor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtPapa As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMama As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboUrgencia As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboMedico As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents barsube As ProgressBar
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnExportar As Button
End Class
