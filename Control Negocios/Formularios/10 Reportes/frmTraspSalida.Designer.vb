<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraspSalida
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTraspSalida))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btncopia = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbodocumento = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.cbo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtexistencia = New System.Windows.Forms.TextBox()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbodesc = New System.Windows.Forms.ComboBox()
        Me.cbocodigo = New System.Windows.Forms.TextBox()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtcoment = New System.Windows.Forms.RichTextBox()
        Me.pSalida80 = New System.Drawing.Printing.PrintDocument()
        Me.pSalida58 = New System.Drawing.Printing.PrintDocument()
        Me.pSalidaMediaCarta = New System.Drawing.Printing.PrintDocument()
        Me.pSalidaCarta = New System.Drawing.Printing.PrintDocument()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(804, 31)
        Me.Label1.TabIndex = 260
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btncopia
        '
        Me.btncopia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btncopia.BackgroundImage = CType(resources.GetObject("btncopia.BackgroundImage"), System.Drawing.Image)
        Me.btncopia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btncopia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncopia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncopia.Location = New System.Drawing.Point(8, 407)
        Me.btncopia.Name = "btncopia"
        Me.btncopia.Size = New System.Drawing.Size(60, 63)
        Me.btncopia.TabIndex = 290
        Me.btncopia.Text = "Copia"
        Me.btncopia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btncopia.UseVisualStyleBackColor = True
        Me.btncopia.Visible = False
        '
        'btnguardar
        '
        Me.btnguardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnguardar.BackgroundImage = CType(resources.GetObject("btnguardar.BackgroundImage"), System.Drawing.Image)
        Me.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Location = New System.Drawing.Point(670, 407)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(60, 63)
        Me.btnguardar.TabIndex = 318
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(736, 407)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 317
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(712, 39)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(84, 23)
        Me.lblusuario.TabIndex = 314
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(576, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 316
        Me.Label15.Text = "Usuario:"
        '
        'txtusuario
        '
        Me.txtusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtusuario.Location = New System.Drawing.Point(628, 39)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtusuario.Size = New System.Drawing.Size(81, 23)
        Me.txtusuario.TabIndex = 315
        Me.txtusuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblfolio
        '
        Me.lblfolio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfolio.BackColor = System.Drawing.Color.Navy
        Me.lblfolio.ForeColor = System.Drawing.Color.White
        Me.lblfolio.Location = New System.Drawing.Point(727, 69)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(69, 23)
        Me.lblfolio.TabIndex = 313
        Me.lblfolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(685, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 312
        Me.Label12.Text = "Folio:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(227, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 15)
        Me.Label10.TabIndex = 311
        Me.Label10.Text = "Fecha:"
        '
        'cbodocumento
        '
        Me.cbodocumento.BackColor = System.Drawing.Color.White
        Me.cbodocumento.FormattingEnabled = True
        Me.cbodocumento.Location = New System.Drawing.Point(375, 69)
        Me.cbodocumento.Name = "cbodocumento"
        Me.cbodocumento.Size = New System.Drawing.Size(88, 23)
        Me.cbodocumento.TabIndex = 310
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(375, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 309
        Me.Label9.Text = "Documento:"
        '
        'dtpfecha
        '
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(274, 69)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(95, 23)
        Me.dtpfecha.TabIndex = 308
        '
        'cbo
        '
        Me.cbo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbo.FormattingEnabled = True
        Me.cbo.Location = New System.Drawing.Point(8, 69)
        Me.cbo.Name = "cbo"
        Me.cbo.Size = New System.Drawing.Size(212, 23)
        Me.cbo.TabIndex = 307
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 15)
        Me.Label11.TabIndex = 306
        Me.Label11.Text = "Bodega de destino:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(729, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 21)
        Me.Label8.TabIndex = 305
        Me.Label8.Text = "Existencia"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(644, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 21)
        Me.Label7.TabIndex = 304
        Me.Label7.Text = "Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(557, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 21)
        Me.Label6.TabIndex = 303
        Me.Label6.Text = "Precio"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(495, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 21)
        Me.Label5.TabIndex = 302
        Me.Label5.Text = "Cantidad"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(439, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 21)
        Me.Label4.TabIndex = 301
        Me.Label4.Text = "Unidad"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtexistencia
        '
        Me.txtexistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtexistencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexistencia.Location = New System.Drawing.Point(729, 116)
        Me.txtexistencia.Name = "txtexistencia"
        Me.txtexistencia.Size = New System.Drawing.Size(67, 23)
        Me.txtexistencia.TabIndex = 300
        '
        'txttotal
        '
        Me.txttotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotal.Location = New System.Drawing.Point(644, 116)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(86, 23)
        Me.txttotal.TabIndex = 299
        Me.txttotal.Text = "0.00"
        Me.txttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtprecio
        '
        Me.txtprecio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtprecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtprecio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecio.Location = New System.Drawing.Point(557, 116)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.Size = New System.Drawing.Size(88, 23)
        Me.txtprecio.TabIndex = 298
        Me.txtprecio.Text = "0.00"
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(66, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(374, 21)
        Me.Label2.TabIndex = 297
        Me.Label2.Text = "Descripción"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 21)
        Me.Label3.TabIndex = 296
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcantidad
        '
        Me.txtcantidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcantidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(495, 116)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(63, 23)
        Me.txtcantidad.TabIndex = 295
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtunidad
        '
        Me.txtunidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(439, 116)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(57, 23)
        Me.txtunidad.TabIndex = 294
        Me.txtunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbodesc
        '
        Me.cbodesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbodesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbodesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbodesc.FormattingEnabled = True
        Me.cbodesc.Location = New System.Drawing.Point(66, 116)
        Me.cbodesc.Name = "cbodesc"
        Me.cbodesc.Size = New System.Drawing.Size(374, 23)
        Me.cbodesc.TabIndex = 293
        '
        'cbocodigo
        '
        Me.cbocodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocodigo.Location = New System.Drawing.Point(8, 116)
        Me.cbocodigo.Name = "cbocodigo"
        Me.cbocodigo.Size = New System.Drawing.Size(59, 23)
        Me.cbocodigo.TabIndex = 292
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ColumnHeadersVisible = False
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(8, 138)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(788, 263)
        Me.grdcaptura.TabIndex = 291
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 57
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Descipcion"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 56
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 62
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Precio"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 87
        '
        'Column6
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 85
        '
        'Column7
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column7.HeaderText = "Existencia"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 65
        '
        'txtcoment
        '
        Me.txtcoment.BackColor = System.Drawing.Color.Pink
        Me.txtcoment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtcoment.Location = New System.Drawing.Point(9, 139)
        Me.txtcoment.Name = "txtcoment"
        Me.txtcoment.Size = New System.Drawing.Size(431, 91)
        Me.txtcoment.TabIndex = 319
        Me.txtcoment.Text = ""
        Me.txtcoment.Visible = False
        '
        'pSalida80
        '
        '
        'pSalida58
        '
        '
        'frmTraspSalida
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(804, 477)
        Me.Controls.Add(Me.txtcoment)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.lblfolio)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cbodocumento)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpfecha)
        Me.Controls.Add(Me.cbo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtexistencia)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbodesc)
        Me.Controls.Add(Me.cbocodigo)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.btncopia)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(810, 506)
        Me.Name = "frmTraspSalida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Traspaso de salida"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btncopia As System.Windows.Forms.Button
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtusuario As System.Windows.Forms.TextBox
    Friend WithEvents lblfolio As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbodocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpfecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtexistencia As System.Windows.Forms.TextBox
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtunidad As System.Windows.Forms.TextBox
    Friend WithEvents cbodesc As System.Windows.Forms.ComboBox
    Friend WithEvents cbocodigo As System.Windows.Forms.TextBox
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents txtcoment As System.Windows.Forms.RichTextBox
    Friend WithEvents pSalida80 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pSalida58 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pSalidaMediaCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents pSalidaCarta As System.Drawing.Printing.PrintDocument
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
End Class
