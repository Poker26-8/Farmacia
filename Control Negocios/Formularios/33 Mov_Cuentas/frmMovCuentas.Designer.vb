<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovCuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovCuentas))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.cboFolio = New System.Windows.Forms.ComboBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtBancoC = New System.Windows.Forms.TextBox()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboCuneta = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.rtobservacion = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboForma = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnEliminarE = New System.Windows.Forms.Button()
        Me.btnGuardarE = New System.Windows.Forms.Button()
        Me.btnSalirE = New System.Windows.Forms.Button()
        Me.btnNuevoE = New System.Windows.Forms.Button()
        Me.cboFolioE = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBancoCE = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboCuentaE = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rtObservacionesE = New System.Windows.Forms.RichTextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMontoE = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtReferenciaE = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboBancoE = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboFormaE = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpFechaE = New System.Windows.Forms.DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboNombreE = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TFolio = New System.Windows.Forms.Timer(Me.components)
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(6, 53)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(553, 362)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnEliminar)
        Me.TabPage1.Controls.Add(Me.cboFolio)
        Me.TabPage1.Controls.Add(Me.btnguardar)
        Me.TabPage1.Controls.Add(Me.btnSalir)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtBancoC)
        Me.TabPage1.Controls.Add(Me.btnnuevo)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.cboCuneta)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.rtobservacion)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtMonto)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtReferencia)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cboBanco)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cboForma)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.dtpFecha)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cboNombre)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(545, 329)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "          Ingresos          "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.Location = New System.Drawing.Point(344, 262)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 278
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'cboFolio
        '
        Me.cboFolio.BackColor = System.Drawing.Color.White
        Me.cboFolio.FormattingEnabled = True
        Me.cboFolio.Location = New System.Drawing.Point(72, 6)
        Me.cboFolio.Name = "cboFolio"
        Me.cboFolio.Size = New System.Drawing.Size(110, 24)
        Me.cboFolio.TabIndex = 19
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(410, 262)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 63)
        Me.btnguardar.TabIndex = 276
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(476, 262)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(60, 63)
        Me.btnSalir.TabIndex = 277
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 24)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Folio:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBancoC
        '
        Me.txtBancoC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtBancoC.Enabled = False
        Me.txtBancoC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancoC.Location = New System.Drawing.Point(356, 144)
        Me.txtBancoC.Name = "txtBancoC"
        Me.txtBancoC.Size = New System.Drawing.Size(180, 24)
        Me.txtBancoC.TabIndex = 17
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(278, 262)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 275
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(299, 144)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 24)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Banco:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCuneta
        '
        Me.cboCuneta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboCuneta.FormattingEnabled = True
        Me.cboCuneta.Location = New System.Drawing.Point(113, 144)
        Me.cboCuneta.Name = "cboCuneta"
        Me.cboCuneta.Size = New System.Drawing.Size(180, 24)
        Me.cboCuneta.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 24)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Cuenta Destino:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtobservacion
        '
        Me.rtobservacion.Location = New System.Drawing.Point(114, 174)
        Me.rtobservacion.Name = "rtobservacion"
        Me.rtobservacion.Size = New System.Drawing.Size(423, 82)
        Me.rtobservacion.TabIndex = 13
        Me.rtobservacion.Text = ""
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 24)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Observaciones:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(356, 114)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(180, 24)
        Me.txtMonto.TabIndex = 11
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(299, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 24)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Monto:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferencia
        '
        Me.txtReferencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(113, 114)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(180, 24)
        Me.txtReferencia.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 24)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Referencia:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBanco
        '
        Me.cboBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(356, 84)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(180, 24)
        Me.cboBanco.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(299, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 24)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Banco:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboForma
        '
        Me.cboForma.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboForma.FormattingEnabled = True
        Me.cboForma.Location = New System.Drawing.Point(113, 84)
        Me.cboForma.Name = "cboForma"
        Me.cboForma.Size = New System.Drawing.Size(180, 24)
        Me.cboForma.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Forma Pago:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(412, 42)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(125, 24)
        Me.dtpFecha.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(363, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNombre
        '
        Me.cboNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(72, 42)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(285, 24)
        Me.cboNombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnEliminarE)
        Me.TabPage2.Controls.Add(Me.btnGuardarE)
        Me.TabPage2.Controls.Add(Me.btnSalirE)
        Me.TabPage2.Controls.Add(Me.btnNuevoE)
        Me.TabPage2.Controls.Add(Me.cboFolioE)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtBancoCE)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.cboCuentaE)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.rtObservacionesE)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtMontoE)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtReferenciaE)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.cboBancoE)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.cboFormaE)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.dtpFechaE)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.cboNombreE)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(545, 329)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "          Egresos          "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnEliminarE
        '
        Me.btnEliminarE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminarE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarE.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarE.Image = CType(resources.GetObject("btnEliminarE.Image"), System.Drawing.Image)
        Me.btnEliminarE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminarE.Location = New System.Drawing.Point(344, 262)
        Me.btnEliminarE.Name = "btnEliminarE"
        Me.btnEliminarE.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminarE.TabIndex = 282
        Me.btnEliminarE.Text = "Eliminar"
        Me.btnEliminarE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminarE.UseVisualStyleBackColor = True
        '
        'btnGuardarE
        '
        Me.btnGuardarE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardarE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardarE.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarE.Image = CType(resources.GetObject("btnGuardarE.Image"), System.Drawing.Image)
        Me.btnGuardarE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardarE.Location = New System.Drawing.Point(410, 262)
        Me.btnGuardarE.Name = "btnGuardarE"
        Me.btnGuardarE.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardarE.TabIndex = 280
        Me.btnGuardarE.Text = "Guardar"
        Me.btnGuardarE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardarE.UseVisualStyleBackColor = True
        '
        'btnSalirE
        '
        Me.btnSalirE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalirE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSalirE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalirE.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalirE.Image = CType(resources.GetObject("btnSalirE.Image"), System.Drawing.Image)
        Me.btnSalirE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalirE.Location = New System.Drawing.Point(476, 262)
        Me.btnSalirE.Name = "btnSalirE"
        Me.btnSalirE.Size = New System.Drawing.Size(60, 63)
        Me.btnSalirE.TabIndex = 281
        Me.btnSalirE.Text = "Salir"
        Me.btnSalirE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalirE.UseVisualStyleBackColor = True
        '
        'btnNuevoE
        '
        Me.btnNuevoE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevoE.BackgroundImage = CType(resources.GetObject("btnNuevoE.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevoE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevoE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevoE.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevoE.Location = New System.Drawing.Point(278, 262)
        Me.btnNuevoE.Name = "btnNuevoE"
        Me.btnNuevoE.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevoE.TabIndex = 279
        Me.btnNuevoE.Text = "Nuevo"
        Me.btnNuevoE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevoE.UseVisualStyleBackColor = True
        '
        'cboFolioE
        '
        Me.cboFolioE.BackColor = System.Drawing.Color.White
        Me.cboFolioE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFolioE.FormattingEnabled = True
        Me.cboFolioE.Location = New System.Drawing.Point(72, 6)
        Me.cboFolioE.Name = "cboFolioE"
        Me.cboFolioE.Size = New System.Drawing.Size(110, 24)
        Me.cboFolioE.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 24)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Folio:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBancoCE
        '
        Me.txtBancoCE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtBancoCE.Enabled = False
        Me.txtBancoCE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBancoCE.Location = New System.Drawing.Point(356, 144)
        Me.txtBancoCE.Name = "txtBancoCE"
        Me.txtBancoCE.Size = New System.Drawing.Size(180, 24)
        Me.txtBancoCE.TabIndex = 37
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(299, 144)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 24)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "Banco:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCuentaE
        '
        Me.cboCuentaE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboCuentaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuentaE.FormattingEnabled = True
        Me.cboCuentaE.Location = New System.Drawing.Point(113, 144)
        Me.cboCuentaE.Name = "cboCuentaE"
        Me.cboCuentaE.Size = New System.Drawing.Size(180, 24)
        Me.cboCuentaE.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 24)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Cuenta Destino:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rtObservacionesE
        '
        Me.rtObservacionesE.Location = New System.Drawing.Point(114, 174)
        Me.rtObservacionesE.Name = "rtObservacionesE"
        Me.rtObservacionesE.Size = New System.Drawing.Size(423, 82)
        Me.rtObservacionesE.TabIndex = 33
        Me.rtObservacionesE.Text = ""
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 195)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(112, 24)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Observaciones:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMontoE
        '
        Me.txtMontoE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMontoE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoE.Location = New System.Drawing.Point(356, 114)
        Me.txtMontoE.Name = "txtMontoE"
        Me.txtMontoE.Size = New System.Drawing.Size(180, 24)
        Me.txtMontoE.TabIndex = 31
        Me.txtMontoE.Text = "0.00"
        Me.txtMontoE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(299, 114)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(61, 24)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Monto:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferenciaE
        '
        Me.txtReferenciaE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtReferenciaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenciaE.Location = New System.Drawing.Point(113, 114)
        Me.txtReferenciaE.Name = "txtReferenciaE"
        Me.txtReferenciaE.Size = New System.Drawing.Size(180, 24)
        Me.txtReferenciaE.TabIndex = 29
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(3, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 24)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "Referencia:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBancoE
        '
        Me.cboBancoE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboBancoE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBancoE.FormattingEnabled = True
        Me.cboBancoE.Location = New System.Drawing.Point(356, 84)
        Me.cboBancoE.Name = "cboBancoE"
        Me.cboBancoE.Size = New System.Drawing.Size(180, 24)
        Me.cboBancoE.TabIndex = 27
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(299, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 24)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Banco:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboFormaE
        '
        Me.cboFormaE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboFormaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormaE.FormattingEnabled = True
        Me.cboFormaE.Location = New System.Drawing.Point(113, 84)
        Me.cboFormaE.Name = "cboFormaE"
        Me.cboFormaE.Size = New System.Drawing.Size(180, 24)
        Me.cboFormaE.TabIndex = 25
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(3, 84)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(104, 24)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "Forma Pago:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFechaE
        '
        Me.dtpFechaE.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaE.Location = New System.Drawing.Point(412, 42)
        Me.dtpFechaE.Name = "dtpFechaE"
        Me.dtpFechaE.Size = New System.Drawing.Size(125, 24)
        Me.dtpFechaE.TabIndex = 23
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(363, 42)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(57, 24)
        Me.Label22.TabIndex = 22
        Me.Label22.Text = "Fecha:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNombreE
        '
        Me.cboNombreE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cboNombreE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNombreE.FormattingEnabled = True
        Me.cboNombreE.Location = New System.Drawing.Point(72, 42)
        Me.cboNombreE.Name = "cboNombreE"
        Me.cboNombreE.Size = New System.Drawing.Size(285, 24)
        Me.cboNombreE.TabIndex = 21
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(3, 42)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 24)
        Me.Label23.TabIndex = 20
        Me.Label23.Text = "Nombre:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TFolio
        '
        '
        'lblFolio
        '
        Me.lblFolio.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.White
        Me.lblFolio.Location = New System.Drawing.Point(63, 8)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(129, 23)
        Me.lblFolio.TabIndex = 7
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 24)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Folio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContra
        '
        Me.txtContra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContra.Location = New System.Drawing.Point(432, 32)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(123, 24)
        Me.txtContra.TabIndex = 10
        Me.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtContra.UseSystemPasswordChar = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(432, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(123, 24)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Contraseña"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.DodgerBlue
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(300, 33)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(129, 23)
        Me.lblUsuario.TabIndex = 12
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(300, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(129, 24)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Usuario"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMovCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(560, 418)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtContra)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento de  Cuentas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents cboNombre As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TFolio As Timer
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboBanco As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboForma As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBancoC As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cboCuneta As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents rtobservacion As RichTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents btnnuevo As Button
    Friend WithEvents txtContra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cboFolio As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cboFolioE As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtBancoCE As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cboCuentaE As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents rtObservacionesE As RichTextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMontoE As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtReferenciaE As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cboBancoE As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cboFormaE As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpFechaE As DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents cboNombreE As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents btnEliminarE As Button
    Friend WithEvents btnGuardarE As Button
    Friend WithEvents btnSalirE As Button
    Friend WithEvents btnNuevoE As Button
End Class
