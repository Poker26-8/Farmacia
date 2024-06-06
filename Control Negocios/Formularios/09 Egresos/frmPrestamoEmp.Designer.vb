<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrestamoEmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrestamoEmp))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtnss = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtsueldo = New System.Windows.Forms.TextBox()
        Me.txtarea = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtppago = New System.Windows.Forms.DateTimePicker()
        Me.txtcomentario = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtsaldo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.opttrabajo = New System.Windows.Forms.RadioButton()
        Me.optpersonal = New System.Windows.Forms.RadioButton()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txttrabajo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpersonal = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblid_usu = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cboBancoRecepcion = New System.Windows.Forms.TextBox()
        Me.txtnumref = New System.Windows.Forms.TextBox()
        Me.cboCuentaRecepcion = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtComentarioPago = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.btnPagos = New System.Windows.Forms.Button()
        Me.txtmontopago = New System.Windows.Forms.TextBox()
        Me.grdpago = New System.Windows.Forms.DataGridView()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbotpago = New System.Windows.Forms.ComboBox()
        Me.dtpFecha_P = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPagos = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(461, 31)
        Me.Label1.TabIndex = 46
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtnss)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtsueldo)
        Me.GroupBox1.Controls.Add(Me.txtarea)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.cbonombre)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 105)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empleado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(180, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "NSS:"
        '
        'txtnss
        '
        Me.txtnss.Location = New System.Drawing.Point(235, 45)
        Me.txtnss.Name = "txtnss"
        Me.txtnss.Size = New System.Drawing.Size(111, 23)
        Me.txtnss.TabIndex = 174
        Me.txtnss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 15)
        Me.Label7.TabIndex = 169
        Me.Label7.Text = "Sueldo:"
        '
        'txtsueldo
        '
        Me.txtsueldo.Location = New System.Drawing.Point(64, 72)
        Me.txtsueldo.Name = "txtsueldo"
        Me.txtsueldo.Size = New System.Drawing.Size(111, 23)
        Me.txtsueldo.TabIndex = 168
        Me.txtsueldo.Text = "0.00"
        Me.txtsueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtarea
        '
        Me.txtarea.Location = New System.Drawing.Point(64, 45)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.Size = New System.Drawing.Size(111, 23)
        Me.txtarea.TabIndex = 167
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(7, 49)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(34, 15)
        Me.Label37.TabIndex = 164
        Me.Label37.Text = "Área:"
        '
        'cbonombre
        '
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(64, 18)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(282, 23)
        Me.cbonombre.TabIndex = 150
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(7, 22)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(54, 15)
        Me.Label36.TabIndex = 149
        Me.Label36.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(604, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 15)
        Me.Label3.TabIndex = 160
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTotal)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtPagos)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.dtppago)
        Me.GroupBox2.Controls.Add(Me.txtcomentario)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtEfectivo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.dtpfecha)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtsaldo)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 201)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(447, 147)
        Me.GroupBox2.TabIndex = 176
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Préstamo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(186, 84)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(110, 20)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Fecha de pago:"
        '
        'dtppago
        '
        Me.dtppago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtppago.Location = New System.Drawing.Point(303, 82)
        Me.dtppago.Name = "dtppago"
        Me.dtppago.Size = New System.Drawing.Size(135, 23)
        Me.dtppago.TabIndex = 201
        '
        'txtcomentario
        '
        Me.txtcomentario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcomentario.Location = New System.Drawing.Point(74, 113)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.Size = New System.Drawing.Size(364, 23)
        Me.txtcomentario.TabIndex = 200
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 23)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 20)
        Me.Label21.TabIndex = 197
        Me.Label21.Text = "Efectivo:"
        '
        'txtEfectivo
        '
        Me.txtEfectivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEfectivo.Location = New System.Drawing.Point(74, 19)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(107, 23)
        Me.txtEfectivo.TabIndex = 196
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(246, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 20)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Fecha:"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(303, 50)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(135, 23)
        Me.dtpfecha.TabIndex = 192
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 112)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 20)
        Me.Label12.TabIndex = 191
        Me.Label12.Text = "Nota:"
        '
        'txtsaldo
        '
        Me.txtsaldo.Location = New System.Drawing.Point(302, 16)
        Me.txtsaldo.Name = "txtsaldo"
        Me.txtsaldo.Size = New System.Drawing.Size(136, 23)
        Me.txtsaldo.TabIndex = 173
        Me.txtsaldo.Text = "0.00"
        Me.txtsaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(199, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(97, 20)
        Me.Label10.TabIndex = 170
        Me.Label10.Text = "Saldo global:"
        '
        'opttrabajo
        '
        Me.opttrabajo.AutoSize = True
        Me.opttrabajo.Location = New System.Drawing.Point(140, 176)
        Me.opttrabajo.Name = "opttrabajo"
        Me.opttrabajo.Size = New System.Drawing.Size(131, 19)
        Me.opttrabajo.TabIndex = 182
        Me.opttrabajo.TabStop = True
        Me.opttrabajo.Text = "Préstamo de trabajo"
        Me.opttrabajo.UseVisualStyleBackColor = True
        '
        'optpersonal
        '
        Me.optpersonal.AutoSize = True
        Me.optpersonal.Location = New System.Drawing.Point(11, 176)
        Me.optpersonal.Name = "optpersonal"
        Me.optpersonal.Size = New System.Drawing.Size(123, 19)
        Me.optpersonal.TabIndex = 181
        Me.optpersonal.TabStop = True
        Me.optpersonal.Text = "Préstamo personal"
        Me.optpersonal.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(331, 3)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 63)
        Me.btnguardar.TabIndex = 178
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(395, 3)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 177
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.White
        Me.txtcontraseña.Location = New System.Drawing.Point(363, 37)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(92, 23)
        Me.txtcontraseña.TabIndex = 180
        Me.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.AliceBlue
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txttrabajo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtpersonal)
        Me.GroupBox3.Location = New System.Drawing.Point(367, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(88, 104)
        Me.GroupBox3.TabIndex = 181
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Saldo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 15)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Trabajo:"
        '
        'txttrabajo
        '
        Me.txttrabajo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txttrabajo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttrabajo.ForeColor = System.Drawing.Color.Black
        Me.txttrabajo.Location = New System.Drawing.Point(6, 76)
        Me.txttrabajo.Name = "txttrabajo"
        Me.txttrabajo.ReadOnly = True
        Me.txttrabajo.Size = New System.Drawing.Size(76, 23)
        Me.txttrabajo.TabIndex = 166
        Me.txttrabajo.Text = "0.00"
        Me.txttrabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 165
        Me.Label9.Text = "Personal:"
        '
        'txtpersonal
        '
        Me.txtpersonal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtpersonal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpersonal.ForeColor = System.Drawing.Color.Black
        Me.txtpersonal.Location = New System.Drawing.Point(6, 32)
        Me.txtpersonal.Name = "txtpersonal"
        Me.txtpersonal.ReadOnly = True
        Me.txtpersonal.Size = New System.Drawing.Size(76, 23)
        Me.txtpersonal.TabIndex = 164
        Me.txtpersonal.Text = "0.00"
        Me.txtpersonal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(265, 37)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 23)
        Me.lblusuario.TabIndex = 196
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolio
        '
        Me.lblFolio.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblFolio.Location = New System.Drawing.Point(51, 10)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(52, 15)
        Me.lblFolio.TabIndex = 197
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 15)
        Me.Label5.TabIndex = 198
        Me.Label5.Text = "Id del empleado:"
        '
        'lblid_usu
        '
        Me.lblid_usu.AutoSize = True
        Me.lblid_usu.Location = New System.Drawing.Point(109, 41)
        Me.lblid_usu.Name = "lblid_usu"
        Me.lblid_usu.Size = New System.Drawing.Size(0, 15)
        Me.lblid_usu.TabIndex = 199
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnguardar)
        Me.Panel1.Controls.Add(Me.btnnuevo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 574)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 72)
        Me.Panel1.TabIndex = 201
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(5, 357)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 19)
        Me.Label22.TabIndex = 293
        Me.Label22.Text = "Tipo pago:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(5, 436)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(59, 19)
        Me.Label43.TabIndex = 309
        Me.Label43.Text = "Cuenta:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label41.Location = New System.Drawing.Point(234, 437)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(54, 19)
        Me.Label41.TabIndex = 305
        Me.Label41.Text = "Banco:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.Location = New System.Drawing.Point(7, 463)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 19)
        Me.Label30.TabIndex = 308
        Me.Label30.Text = "Fecha:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(5, 384)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(80, 19)
        Me.Label23.TabIndex = 296
        Me.Label23.Text = "Referencia"
        '
        'cboBancoRecepcion
        '
        Me.cboBancoRecepcion.Enabled = False
        Me.cboBancoRecepcion.Location = New System.Drawing.Point(293, 435)
        Me.cboBancoRecepcion.Name = "cboBancoRecepcion"
        Me.cboBancoRecepcion.Size = New System.Drawing.Size(162, 23)
        Me.cboBancoRecepcion.TabIndex = 307
        '
        'txtnumref
        '
        Me.txtnumref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumref.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumref.Location = New System.Drawing.Point(93, 381)
        Me.txtnumref.Name = "txtnumref"
        Me.txtnumref.Size = New System.Drawing.Size(135, 25)
        Me.txtnumref.TabIndex = 297
        '
        'cboCuentaRecepcion
        '
        Me.cboCuentaRecepcion.FormattingEnabled = True
        Me.cboCuentaRecepcion.Location = New System.Drawing.Point(93, 435)
        Me.cboCuentaRecepcion.Name = "cboCuentaRecepcion"
        Me.cboCuentaRecepcion.Size = New System.Drawing.Size(135, 23)
        Me.cboCuentaRecepcion.TabIndex = 306
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(234, 357)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 19)
        Me.Label24.TabIndex = 295
        Me.Label24.Text = "Banco:"
        '
        'txtComentarioPago
        '
        Me.txtComentarioPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComentarioPago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarioPago.Location = New System.Drawing.Point(93, 408)
        Me.txtComentarioPago.Name = "txtComentarioPago"
        Me.txtComentarioPago.Size = New System.Drawing.Size(362, 25)
        Me.txtComentarioPago.TabIndex = 304
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(234, 384)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 19)
        Me.Label25.TabIndex = 298
        Me.Label25.Text = "Monto:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label40.Location = New System.Drawing.Point(5, 411)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(92, 19)
        Me.Label40.TabIndex = 303
        Me.Label40.Text = "Comentario:"
        '
        'cbobanco
        '
        Me.cbobanco.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(293, 354)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(162, 25)
        Me.cbobanco.TabIndex = 294
        '
        'btnPagos
        '
        Me.btnPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagos.Location = New System.Drawing.Point(234, 460)
        Me.btnPagos.Name = "btnPagos"
        Me.btnPagos.Size = New System.Drawing.Size(221, 24)
        Me.btnPagos.TabIndex = 302
        Me.btnPagos.Text = "Agregar pago"
        Me.btnPagos.UseVisualStyleBackColor = True
        '
        'txtmontopago
        '
        Me.txtmontopago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmontopago.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmontopago.Location = New System.Drawing.Point(293, 381)
        Me.txtmontopago.Name = "txtmontopago"
        Me.txtmontopago.Size = New System.Drawing.Size(162, 25)
        Me.txtmontopago.TabIndex = 299
        Me.txtmontopago.Text = "0.00"
        Me.txtmontopago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grdpago
        '
        Me.grdpago.AllowUserToAddRows = False
        Me.grdpago.AllowUserToDeleteRows = False
        Me.grdpago.BackgroundColor = System.Drawing.Color.White
        Me.grdpago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdpago.ColumnHeadersVisible = False
        Me.grdpago.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column9, Me.Column28, Me.Column27})
        Me.grdpago.Location = New System.Drawing.Point(7, 488)
        Me.grdpago.Name = "grdpago"
        Me.grdpago.ReadOnly = True
        Me.grdpago.RowHeadersVisible = False
        Me.grdpago.Size = New System.Drawing.Size(448, 78)
        Me.grdpago.TabIndex = 301
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column15.HeaderText = "Tipo"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column16.HeaderText = "Banco"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column17.HeaderText = "Número"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column18.HeaderText = "Monto"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        '
        'Column19
        '
        Me.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column19.HeaderText = "Fecha"
        Me.Column19.Name = "Column19"
        Me.Column19.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Comentario"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column28
        '
        Me.Column28.HeaderText = "CuentaRe"
        Me.Column28.Name = "Column28"
        Me.Column28.ReadOnly = True
        Me.Column28.Visible = False
        '
        'Column27
        '
        Me.Column27.HeaderText = "BancoRe"
        Me.Column27.Name = "Column27"
        Me.Column27.ReadOnly = True
        Me.Column27.Visible = False
        '
        'cbotpago
        '
        Me.cbotpago.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotpago.FormattingEnabled = True
        Me.cbotpago.Location = New System.Drawing.Point(93, 354)
        Me.cbotpago.Name = "cbotpago"
        Me.cbotpago.Size = New System.Drawing.Size(135, 25)
        Me.cbotpago.TabIndex = 292
        '
        'dtpFecha_P
        '
        Me.dtpFecha_P.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha_P.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha_P.Location = New System.Drawing.Point(93, 460)
        Me.dtpFecha_P.Name = "dtpFecha_P"
        Me.dtpFecha_P.Size = New System.Drawing.Size(135, 25)
        Me.dtpFecha_P.TabIndex = 300
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 20)
        Me.Label13.TabIndex = 204
        Me.Label13.Text = "Pagos:"
        '
        'txtPagos
        '
        Me.txtPagos.BackColor = System.Drawing.Color.White
        Me.txtPagos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagos.Enabled = False
        Me.txtPagos.Location = New System.Drawing.Point(74, 49)
        Me.txtPagos.Name = "txtPagos"
        Me.txtPagos.Size = New System.Drawing.Size(107, 23)
        Me.txtPagos.TabIndex = 203
        Me.txtPagos.Text = "0.00"
        Me.txtPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 20)
        Me.Label14.TabIndex = 206
        Me.Label14.Text = "Total:"
        '
        'txtTotal
        '
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.Location = New System.Drawing.Point(74, 81)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(107, 23)
        Me.txtTotal.TabIndex = 205
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPrestamoEmp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(461, 646)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.cboBancoRecepcion)
        Me.Controls.Add(Me.txtnumref)
        Me.Controls.Add(Me.cboCuentaRecepcion)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtComentarioPago)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.cbobanco)
        Me.Controls.Add(Me.btnPagos)
        Me.Controls.Add(Me.txtmontopago)
        Me.Controls.Add(Me.grdpago)
        Me.Controls.Add(Me.cbotpago)
        Me.Controls.Add(Me.dtpFecha_P)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblid_usu)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.opttrabajo)
        Me.Controls.Add(Me.optpersonal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrestamoEmp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdpago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtnss As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtsueldo As System.Windows.Forms.TextBox
    Friend WithEvents txtarea As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents txtcontraseña As System.Windows.Forms.TextBox
    Friend WithEvents opttrabajo As RadioButton
    Friend WithEvents optpersonal As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txttrabajo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtpersonal As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents txtcomentario As TextBox
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtppago As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblid_usu As System.Windows.Forms.Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label22 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents cboBancoRecepcion As TextBox
    Friend WithEvents txtnumref As TextBox
    Friend WithEvents cboCuentaRecepcion As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtComentarioPago As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents cbobanco As ComboBox
    Friend WithEvents btnPagos As Button
    Friend WithEvents txtmontopago As TextBox
    Friend WithEvents grdpago As DataGridView
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents cbotpago As ComboBox
    Friend WithEvents dtpFecha_P As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPagos As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotal As TextBox
End Class
