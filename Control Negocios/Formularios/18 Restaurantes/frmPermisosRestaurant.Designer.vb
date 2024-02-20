<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPermisosRestaurant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPermisosRestaurant))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.txtarea = New System.Windows.Forms.TextBox()
        Me.txtcontra = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblid_usu = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnguardartolerancia = New System.Windows.Forms.Button()
        Me.txttolerancia = New System.Windows.Forms.TextBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbminuto = New System.Windows.Forms.RadioButton()
        Me.rbhora = New System.Windows.Forms.RadioButton()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.btnporcentage = New System.Windows.Forms.Button()
        Me.txtPorcentage = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbCobrar = New System.Windows.Forms.CheckBox()
        Me.cbJuntar = New System.Windows.Forms.CheckBox()
        Me.chkSinComensal = New System.Windows.Forms.CheckBox()
        Me.cbSeparadas = New System.Windows.Forms.CheckBox()
        Me.cbCortesia = New System.Windows.Forms.CheckBox()
        Me.cbCancelarComanda = New System.Windows.Forms.CheckBox()
        Me.cbCambioM = New System.Windows.Forms.CheckBox()
        Me.cbPrecuentas = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.cboImpre_Comanda = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Área:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(201, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contraseña:"
        '
        'cboNombre
        '
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(82, 12)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(346, 21)
        Me.cboNombre.TabIndex = 3
        '
        'txtarea
        '
        Me.txtarea.Location = New System.Drawing.Point(82, 44)
        Me.txtarea.Name = "txtarea"
        Me.txtarea.Size = New System.Drawing.Size(113, 20)
        Me.txtarea.TabIndex = 4
        '
        'txtcontra
        '
        Me.txtcontra.Location = New System.Drawing.Point(298, 44)
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(100, 20)
        Me.txtcontra.TabIndex = 5
        Me.txtcontra.UseSystemPasswordChar = True
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Image = CType(resources.GetObject("Label12.Image"), System.Drawing.Image)
        Me.Label12.Location = New System.Drawing.Point(404, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 23)
        Me.Label12.TabIndex = 114
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblid_usu
        '
        Me.lblid_usu.BackColor = System.Drawing.Color.Transparent
        Me.lblid_usu.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid_usu.Location = New System.Drawing.Point(434, 42)
        Me.lblid_usu.Name = "lblid_usu"
        Me.lblid_usu.Size = New System.Drawing.Size(71, 23)
        Me.lblid_usu.TabIndex = 115
        Me.lblid_usu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblid_usu.Visible = False
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(434, 10)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(91, 23)
        Me.lblusuario.TabIndex = 230
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontraseña
        '
        Me.txtcontraseña.ForeColor = System.Drawing.Color.Silver
        Me.txtcontraseña.Location = New System.Drawing.Point(531, 12)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(99, 20)
        Me.txtcontraseña.TabIndex = 229
        Me.txtcontraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblusuario)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtcontraseña)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblid_usu)
        Me.Panel1.Controls.Add(Me.cboNombre)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtarea)
        Me.Panel1.Controls.Add(Me.txtcontra)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(639, 80)
        Me.Panel1.TabIndex = 231
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.White
        Me.btnguardar.BackgroundImage = CType(resources.GetObject("btnguardar.BackgroundImage"), System.Drawing.Image)
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Location = New System.Drawing.Point(556, 193)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(80, 71)
        Me.btnguardar.TabIndex = 233
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'btnnuevo
        '
        Me.btnnuevo.BackColor = System.Drawing.Color.White
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(470, 193)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(78, 71)
        Me.btnnuevo.TabIndex = 234
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnguardartolerancia)
        Me.GroupBox7.Controls.Add(Me.txttolerancia)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(470, 120)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(166, 67)
        Me.GroupBox7.TabIndex = 236
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tolerancia para el Billar"
        '
        'btnguardartolerancia
        '
        Me.btnguardartolerancia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnguardartolerancia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardartolerancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardartolerancia.Location = New System.Drawing.Point(100, 29)
        Me.btnguardartolerancia.Name = "btnguardartolerancia"
        Me.btnguardartolerancia.Size = New System.Drawing.Size(60, 23)
        Me.btnguardartolerancia.TabIndex = 1
        Me.btnguardartolerancia.Text = "Guardar"
        Me.btnguardartolerancia.UseVisualStyleBackColor = False
        '
        'txttolerancia
        '
        Me.txttolerancia.Location = New System.Drawing.Point(6, 31)
        Me.txttolerancia.Name = "txttolerancia"
        Me.txttolerancia.Size = New System.Drawing.Size(71, 22)
        Me.txttolerancia.TabIndex = 0
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.Label5)
        Me.GroupBox19.Controls.Add(Me.rbminuto)
        Me.GroupBox19.Controls.Add(Me.rbhora)
        Me.GroupBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox19.Location = New System.Drawing.Point(191, 120)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(273, 94)
        Me.GroupBox19.TabIndex = 237
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Tipo de Cobro Billar"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(261, 49)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = """Cuando se selecciona el tipo hora, después de la primera hora se empieza a cobra" &
    "r por minuto"""
        '
        'rbminuto
        '
        Me.rbminuto.AutoSize = True
        Me.rbminuto.Location = New System.Drawing.Point(169, 19)
        Me.rbminuto.Name = "rbminuto"
        Me.rbminuto.Size = New System.Drawing.Size(64, 20)
        Me.rbminuto.TabIndex = 1
        Me.rbminuto.TabStop = True
        Me.rbminuto.Text = "Minuto"
        Me.rbminuto.UseVisualStyleBackColor = True
        '
        'rbhora
        '
        Me.rbhora.AutoSize = True
        Me.rbhora.Location = New System.Drawing.Point(35, 19)
        Me.rbhora.Name = "rbhora"
        Me.rbhora.Size = New System.Drawing.Size(55, 20)
        Me.rbhora.TabIndex = 0
        Me.rbhora.TabStop = True
        Me.rbhora.Text = "Hora"
        Me.rbhora.UseVisualStyleBackColor = True
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.btnporcentage)
        Me.GroupBox20.Controls.Add(Me.txtPorcentage)
        Me.GroupBox20.Controls.Add(Me.Label69)
        Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox20.Location = New System.Drawing.Point(191, 220)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(273, 55)
        Me.GroupBox20.TabIndex = 238
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Porcentage de Propinas"
        '
        'btnporcentage
        '
        Me.btnporcentage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnporcentage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnporcentage.Location = New System.Drawing.Point(192, 21)
        Me.btnporcentage.Name = "btnporcentage"
        Me.btnporcentage.Size = New System.Drawing.Size(75, 24)
        Me.btnporcentage.TabIndex = 2
        Me.btnporcentage.Text = "Guardar"
        Me.btnporcentage.UseVisualStyleBackColor = False
        '
        'txtPorcentage
        '
        Me.txtPorcentage.Location = New System.Drawing.Point(90, 24)
        Me.txtPorcentage.Name = "txtPorcentage"
        Me.txtPorcentage.Size = New System.Drawing.Size(84, 22)
        Me.txtPorcentage.TabIndex = 1
        '
        'Label69
        '
        Me.Label69.Location = New System.Drawing.Point(6, 27)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(78, 22)
        Me.Label69.TabIndex = 0
        Me.Label69.Text = "Porcentage"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cbCobrar)
        Me.Panel2.Controls.Add(Me.cbJuntar)
        Me.Panel2.Controls.Add(Me.chkSinComensal)
        Me.Panel2.Controls.Add(Me.cbSeparadas)
        Me.Panel2.Controls.Add(Me.cbCortesia)
        Me.Panel2.Controls.Add(Me.cbCancelarComanda)
        Me.Panel2.Controls.Add(Me.cbCambioM)
        Me.Panel2.Controls.Add(Me.cbPrecuentas)
        Me.Panel2.Location = New System.Drawing.Point(4, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(170, 258)
        Me.Panel2.TabIndex = 240
        '
        'cbCobrar
        '
        Me.cbCobrar.AutoSize = True
        Me.cbCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCobrar.Location = New System.Drawing.Point(3, 143)
        Me.cbCobrar.Name = "cbCobrar"
        Me.cbCobrar.Size = New System.Drawing.Size(112, 20)
        Me.cbCobrar.TabIndex = 238
        Me.cbCobrar.Text = "Cobrar Cuenta"
        Me.cbCobrar.UseVisualStyleBackColor = True
        '
        'cbJuntar
        '
        Me.cbJuntar.AutoSize = True
        Me.cbJuntar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbJuntar.Location = New System.Drawing.Point(3, 117)
        Me.cbJuntar.Name = "cbJuntar"
        Me.cbJuntar.Size = New System.Drawing.Size(94, 20)
        Me.cbJuntar.TabIndex = 237
        Me.cbJuntar.Text = "Unir Mesas"
        Me.cbJuntar.UseVisualStyleBackColor = True
        '
        'chkSinComensal
        '
        Me.chkSinComensal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSinComensal.Location = New System.Drawing.Point(3, 191)
        Me.chkSinComensal.Name = "chkSinComensal"
        Me.chkSinComensal.Size = New System.Drawing.Size(147, 49)
        Me.chkSinComensal.TabIndex = 236
        Me.chkSinComensal.Text = "Imprimir sin número de comensal"
        Me.chkSinComensal.UseVisualStyleBackColor = True
        '
        'cbSeparadas
        '
        Me.cbSeparadas.AutoSize = True
        Me.cbSeparadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSeparadas.Location = New System.Drawing.Point(3, 171)
        Me.cbSeparadas.Name = "cbSeparadas"
        Me.cbSeparadas.Size = New System.Drawing.Size(146, 20)
        Me.cbSeparadas.TabIndex = 0
        Me.cbSeparadas.Text = "Cuentas Separadas"
        Me.cbSeparadas.UseVisualStyleBackColor = True
        '
        'cbCortesia
        '
        Me.cbCortesia.AutoSize = True
        Me.cbCortesia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCortesia.Location = New System.Drawing.Point(3, 91)
        Me.cbCortesia.Name = "cbCortesia"
        Me.cbCortesia.Size = New System.Drawing.Size(83, 20)
        Me.cbCortesia.TabIndex = 235
        Me.cbCortesia.Text = "Cortesias"
        Me.cbCortesia.UseVisualStyleBackColor = True
        '
        'cbCancelarComanda
        '
        Me.cbCancelarComanda.AutoSize = True
        Me.cbCancelarComanda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCancelarComanda.Location = New System.Drawing.Point(3, 65)
        Me.cbCancelarComanda.Name = "cbCancelarComanda"
        Me.cbCancelarComanda.Size = New System.Drawing.Size(142, 20)
        Me.cbCancelarComanda.TabIndex = 234
        Me.cbCancelarComanda.Text = "Cancelar Comanda"
        Me.cbCancelarComanda.UseVisualStyleBackColor = True
        '
        'cbCambioM
        '
        Me.cbCambioM.AutoSize = True
        Me.cbCambioM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCambioM.Location = New System.Drawing.Point(3, 39)
        Me.cbCambioM.Name = "cbCambioM"
        Me.cbCambioM.Size = New System.Drawing.Size(129, 20)
        Me.cbCambioM.TabIndex = 233
        Me.cbCambioM.Text = "Cambio de Mesa"
        Me.cbCambioM.UseVisualStyleBackColor = True
        '
        'cbPrecuentas
        '
        Me.cbPrecuentas.AutoSize = True
        Me.cbPrecuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPrecuentas.Location = New System.Drawing.Point(3, 13)
        Me.cbPrecuentas.Name = "cbPrecuentas"
        Me.cbPrecuentas.Size = New System.Drawing.Size(144, 20)
        Me.cbPrecuentas.TabIndex = 0
        Me.cbPrecuentas.Text = "Imprimir Precuentas"
        Me.cbPrecuentas.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button24)
        Me.GroupBox1.Controls.Add(Me.Label71)
        Me.GroupBox1.Controls.Add(Me.cboImpre_Comanda)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(191, 281)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 79)
        Me.GroupBox1.TabIndex = 243
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto Ocasional"
        '
        'Button24
        '
        Me.Button24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button24.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button24.Location = New System.Drawing.Point(168, 10)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(90, 29)
        Me.Button24.TabIndex = 241
        Me.Button24.Text = "Guardar"
        Me.Button24.UseVisualStyleBackColor = False
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(9, 17)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(82, 20)
        Me.Label71.TabIndex = 240
        Me.Label71.Text = "Impresora:"
        '
        'cboImpre_Comanda
        '
        Me.cboImpre_Comanda.FormattingEnabled = True
        Me.cboImpre_Comanda.Location = New System.Drawing.Point(9, 43)
        Me.cboImpre_Comanda.Name = "cboImpre_Comanda"
        Me.cboImpre_Comanda.Size = New System.Drawing.Size(249, 24)
        Me.cboImpre_Comanda.TabIndex = 239
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(639, 37)
        Me.Label6.TabIndex = 244
        Me.Label6.Text = "Permisos para restaurantes"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(639, 37)
        Me.Panel3.TabIndex = 245
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.White
        Me.btnclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Image = CType(resources.GetObject("btnclose.Image"), System.Drawing.Image)
        Me.btnclose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnclose.Location = New System.Drawing.Point(556, 270)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(80, 71)
        Me.btnclose.TabIndex = 246
        Me.btnclose.Text = "Salir"
        Me.btnclose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'frmPermisosRestaurant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(639, 392)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox20)
        Me.Controls.Add(Me.GroupBox19)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.btnguardar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPermisosRestaurant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "S"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboNombre As ComboBox
    Friend WithEvents txtarea As TextBox
    Friend WithEvents txtcontra As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblid_usu As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtcontraseña As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnguardar As Button
    Friend WithEvents btnnuevo As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents btnguardartolerancia As Button
    Friend WithEvents txttolerancia As TextBox
    Friend WithEvents GroupBox19 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rbminuto As RadioButton
    Friend WithEvents rbhora As RadioButton
    Friend WithEvents GroupBox20 As GroupBox
    Friend WithEvents btnporcentage As Button
    Friend WithEvents txtPorcentage As TextBox
    Friend WithEvents Label69 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cbCobrar As CheckBox
    Friend WithEvents cbJuntar As CheckBox
    Friend WithEvents chkSinComensal As CheckBox
    Friend WithEvents cbSeparadas As CheckBox
    Friend WithEvents cbCortesia As CheckBox
    Friend WithEvents cbCancelarComanda As CheckBox
    Friend WithEvents cbCambioM As CheckBox
    Friend WithEvents cbPrecuentas As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button24 As Button
    Friend WithEvents Label71 As Label
    Friend WithEvents cboImpre_Comanda As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnclose As Button
End Class
