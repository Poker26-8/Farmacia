<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoDispositivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoDispositivo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnstatus = New System.Windows.Forms.Button()
        Me.txtadeuda = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMaximo = New System.Windows.Forms.TextBox()
        Me.txtcliente = New System.Windows.Forms.TextBox()
        Me.txtFavor = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtcontra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.cboSerie = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtfallas = New System.Windows.Forms.RichTextBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtTecnico = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnCoti = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboimpresion = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtdescuento2 = New System.Windows.Forms.TextBox()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPagar = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.cboSerieP = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUnidad = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtexistencia = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cboDescripcion = New System.Windows.Forms.ComboBox()
        Me.cboCodigo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PCotiza80 = New System.Drawing.Printing.PrintDocument()
        Me.PCotiza58 = New System.Drawing.Printing.PrintDocument()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PVenta80 = New System.Drawing.Printing.PrintDocument()
        Me.PVenta58 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblfolio)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnstatus)
        Me.Panel1.Controls.Add(Me.txtadeuda)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtMaximo)
        Me.Panel1.Controls.Add(Me.txtcliente)
        Me.Panel1.Controls.Add(Me.txtFavor)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lblusuario)
        Me.Panel1.Controls.Add(Me.txtcontra)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtOrden)
        Me.Panel1.Controls.Add(Me.cboSerie)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtfallas)
        Me.Panel1.Controls.Add(Me.txtModelo)
        Me.Panel1.Controls.Add(Me.txtTecnico)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtMarca)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1063, 194)
        Me.Panel1.TabIndex = 19
        '
        'lblfolio
        '
        Me.lblfolio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblfolio.BackColor = System.Drawing.Color.Navy
        Me.lblfolio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolio.ForeColor = System.Drawing.Color.White
        Me.lblfolio.Location = New System.Drawing.Point(962, 5)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(95, 23)
        Me.lblfolio.TabIndex = 203
        Me.lblfolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(404, 67)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 19)
        Me.Label18.TabIndex = 201
        Me.Label18.Text = "Saldo a Favor:"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(583, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 18)
        Me.Label19.TabIndex = 202
        Me.Label19.Text = "Adeuda:"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(7, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 89)
        Me.Panel2.TabIndex = 187
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(190, 87)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'btnstatus
        '
        Me.btnstatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnstatus.Location = New System.Drawing.Point(233, 161)
        Me.btnstatus.Name = "btnstatus"
        Me.btnstatus.Size = New System.Drawing.Size(107, 23)
        Me.btnstatus.TabIndex = 186
        Me.btnstatus.Text = "Actualizar Estatus"
        Me.btnstatus.UseVisualStyleBackColor = False
        '
        'txtadeuda
        '
        Me.txtadeuda.Location = New System.Drawing.Point(648, 67)
        Me.txtadeuda.Name = "txtadeuda"
        Me.txtadeuda.Size = New System.Drawing.Size(70, 20)
        Me.txtadeuda.TabIndex = 199
        Me.txtadeuda.Text = "0.00"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(204, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 18)
        Me.Label17.TabIndex = 200
        Me.Label17.Text = "Crédito Máximo:"
        '
        'txtMaximo
        '
        Me.txtMaximo.Location = New System.Drawing.Point(312, 67)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Size = New System.Drawing.Size(86, 20)
        Me.txtMaximo.TabIndex = 198
        Me.txtMaximo.Text = "0.00"
        '
        'txtcliente
        '
        Me.txtcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcliente.Location = New System.Drawing.Point(279, 37)
        Me.txtcliente.Name = "txtcliente"
        Me.txtcliente.Size = New System.Drawing.Size(439, 24)
        Me.txtcliente.TabIndex = 185
        '
        'txtFavor
        '
        Me.txtFavor.Location = New System.Drawing.Point(501, 67)
        Me.txtFavor.Name = "txtFavor"
        Me.txtFavor.Size = New System.Drawing.Size(76, 20)
        Me.txtFavor.TabIndex = 197
        Me.txtFavor.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(203, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 23)
        Me.Label14.TabIndex = 184
        Me.Label14.Text = "Cliente:"
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(861, 38)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(95, 23)
        Me.lblusuario.TabIndex = 182
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontra
        '
        Me.txtcontra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcontra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontra.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontra.ForeColor = System.Drawing.Color.Black
        Me.txtcontra.Location = New System.Drawing.Point(861, 64)
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(95, 23)
        Me.txtcontra.TabIndex = 181
        Me.txtcontra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtcontra.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Serie:"
        '
        'txtOrden
        '
        Me.txtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrden.Location = New System.Drawing.Point(723, 37)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(128, 24)
        Me.txtOrden.TabIndex = 22
        '
        'cboSerie
        '
        Me.cboSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSerie.FormattingEnabled = True
        Me.cboSerie.Location = New System.Drawing.Point(279, 5)
        Me.cboSerie.Name = "cboSerie"
        Me.cboSerie.Size = New System.Drawing.Size(298, 23)
        Me.cboSerie.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(725, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 23)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "N° Orden:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtfallas
        '
        Me.txtfallas.Location = New System.Drawing.Point(537, 100)
        Me.txtfallas.Name = "txtfallas"
        Me.txtfallas.Size = New System.Drawing.Size(419, 63)
        Me.txtfallas.TabIndex = 3
        Me.txtfallas.Text = ""
        '
        'txtModelo
        '
        Me.txtModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.Location = New System.Drawing.Point(329, 131)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(127, 24)
        Me.txtModelo.TabIndex = 7
        '
        'txtTecnico
        '
        Me.txtTecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTecnico.Location = New System.Drawing.Point(73, 100)
        Me.txtTecnico.Name = "txtTecnico"
        Me.txtTecnico.Size = New System.Drawing.Size(383, 24)
        Me.txtTecnico.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(465, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fallas"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 23)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Técnico:"
        '
        'txtMarca
        '
        Me.txtMarca.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.Location = New System.Drawing.Point(73, 130)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Size = New System.Drawing.Size(170, 24)
        Me.txtMarca.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 23)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Marca:"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 161)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 23)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Status:"
        '
        'cboStatus
        '
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Equipo recibido", "En reparacion", "Equipo reparado"})
        Me.cboStatus.Location = New System.Drawing.Point(73, 160)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(154, 24)
        Me.cboStatus.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(249, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 23)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Modelo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.btnCoti)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.btnLimpiar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(962, 194)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(101, 377)
        Me.Panel4.TabIndex = 200
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(4, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 81)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Finalizar Reparación"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnCoti
        '
        Me.btnCoti.BackColor = System.Drawing.Color.White
        Me.btnCoti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCoti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCoti.Image = CType(resources.GetObject("btnCoti.Image"), System.Drawing.Image)
        Me.btnCoti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCoti.Location = New System.Drawing.Point(5, 103)
        Me.btnCoti.Name = "btnCoti"
        Me.btnCoti.Size = New System.Drawing.Size(93, 81)
        Me.btnCoti.TabIndex = 16
        Me.btnCoti.Text = "Cotizacion"
        Me.btnCoti.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCoti.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(5, 279)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 81)
        Me.Button1.TabIndex = 197
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(5, 191)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(93, 81)
        Me.btnLimpiar.TabIndex = 17
        Me.btnLimpiar.Text = "Nuevo"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cboimpresion)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.txtdescuento2)
        Me.Panel3.Controls.Add(Me.txtSubTotal)
        Me.Panel3.Controls.Add(Me.Label25)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.txtPagar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 502)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(962, 69)
        Me.Panel3.TabIndex = 201
        '
        'cboimpresion
        '
        Me.cboimpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboimpresion.FormattingEnabled = True
        Me.cboimpresion.Location = New System.Drawing.Point(99, 16)
        Me.cboimpresion.Name = "cboimpresion"
        Me.cboimpresion.Size = New System.Drawing.Size(250, 21)
        Me.cboimpresion.TabIndex = 195
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 19)
        Me.Label15.TabIndex = 196
        Me.Label15.Text = "Imprime en:"
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(733, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(104, 19)
        Me.Label26.TabIndex = 185
        Me.Label26.Text = "Descuento: ($)"
        '
        'txtdescuento2
        '
        Me.txtdescuento2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtdescuento2.BackColor = System.Drawing.Color.White
        Me.txtdescuento2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescuento2.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescuento2.ForeColor = System.Drawing.Color.Black
        Me.txtdescuento2.Location = New System.Drawing.Point(737, 29)
        Me.txtdescuento2.Name = "txtdescuento2"
        Me.txtdescuento2.ReadOnly = True
        Me.txtdescuento2.Size = New System.Drawing.Size(98, 31)
        Me.txtdescuento2.TabIndex = 184
        Me.txtdescuento2.Text = "0.00"
        Me.txtdescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.BackColor = System.Drawing.Color.White
        Me.txtSubTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSubTotal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSubTotal.Location = New System.Drawing.Point(619, 29)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(114, 31)
        Me.txtSubTotal.TabIndex = 182
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(848, 7)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(103, 19)
        Me.Label25.TabIndex = 181
        Me.Label25.Text = "Total a pagar:"
        '
        'Label27
        '
        Me.Label27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(664, 7)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(69, 19)
        Me.Label27.TabIndex = 183
        Me.Label27.Text = "Subtotal:"
        '
        'txtPagar
        '
        Me.txtPagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPagar.BackColor = System.Drawing.Color.Navy
        Me.txtPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagar.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagar.ForeColor = System.Drawing.Color.White
        Me.txtPagar.Location = New System.Drawing.Point(840, 29)
        Me.txtPagar.Name = "txtPagar"
        Me.txtPagar.Size = New System.Drawing.Size(112, 31)
        Me.txtPagar.TabIndex = 180
        Me.txtPagar.Text = "0.00"
        Me.txtPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.cboSerieP)
        Me.Panel5.Controls.Add(Me.Label20)
        Me.Panel5.Controls.Add(Me.grdCaptura)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.txtUnidad)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.txtexistencia)
        Me.Panel5.Controls.Add(Me.txtTotal)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.txtPrecio)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Controls.Add(Me.txtCantidad)
        Me.Panel5.Controls.Add(Me.cboDescripcion)
        Me.Panel5.Controls.Add(Me.cboCodigo)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 194)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(962, 308)
        Me.Panel5.TabIndex = 202
        '
        'cboSerieP
        '
        Me.cboSerieP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboSerieP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSerieP.FormattingEnabled = True
        Me.cboSerieP.Location = New System.Drawing.Point(852, 29)
        Me.cboSerieP.Name = "cboSerieP"
        Me.cboSerieP.Size = New System.Drawing.Size(107, 24)
        Me.cboSerieP.TabIndex = 203
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(849, 3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 23)
        Me.Label20.TabIndex = 202
        Me.Label20.Text = "Serie"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column12, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column13})
        Me.grdCaptura.Location = New System.Drawing.Point(12, 59)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(947, 243)
        Me.grdCaptura.TabIndex = 11
        '
        'Column1
        '
        Me.Column1.HeaderText = "Código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 85
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 320
        '
        'Column3
        '
        Me.Column3.HeaderText = "Unidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 82
        '
        'Column4
        '
        Me.Column4.HeaderText = "Cantidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 85
        '
        'Column5
        '
        Me.Column5.HeaderText = "Precio"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 72
        '
        'Column6
        '
        Me.Column6.HeaderText = "Total"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 82
        '
        'Column7
        '
        Me.Column7.HeaderText = "Existencia"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 110
        '
        'Column12
        '
        Me.Column12.HeaderText = "Column10"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "Column11"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Column12"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Visible = False
        '
        'Column10
        '
        Me.Column10.HeaderText = "Column13"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Visible = False
        '
        'Column11
        '
        Me.Column11.HeaderText = "Monedero"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column13
        '
        Me.Column13.HeaderText = "Serie"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(739, 3)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 23)
        Me.Label16.TabIndex = 201
        Me.Label16.Text = "Existencia"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtUnidad
        '
        Me.txtUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnidad.Location = New System.Drawing.Point(418, 29)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(83, 24)
        Me.txtUnidad.TabIndex = 199
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(418, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 23)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "Unidad"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtexistencia
        '
        Me.txtexistencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtexistencia.Location = New System.Drawing.Point(739, 29)
        Me.txtexistencia.Name = "txtexistencia"
        Me.txtexistencia.Size = New System.Drawing.Size(113, 24)
        Me.txtexistencia.TabIndex = 200
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(658, 29)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(81, 24)
        Me.txtTotal.TabIndex = 197
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(658, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 23)
        Me.Label10.TabIndex = 196
        Me.Label10.Text = "Total"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Location = New System.Drawing.Point(586, 29)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(72, 24)
        Me.txtPrecio.TabIndex = 195
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(586, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 23)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Pecio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(501, 29)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(86, 24)
        Me.txtCantidad.TabIndex = 193
        '
        'cboDescripcion
        '
        Me.cboDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescripcion.FormattingEnabled = True
        Me.cboDescripcion.Location = New System.Drawing.Point(99, 29)
        Me.cboDescripcion.Name = "cboDescripcion"
        Me.cboDescripcion.Size = New System.Drawing.Size(319, 24)
        Me.cboDescripcion.TabIndex = 192
        '
        'cboCodigo
        '
        Me.cboCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodigo.FormattingEnabled = True
        Me.cboCodigo.Location = New System.Drawing.Point(12, 29)
        Me.cboCodigo.Name = "cboCodigo"
        Me.cboCodigo.Size = New System.Drawing.Size(87, 24)
        Me.cboCodigo.TabIndex = 191
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(501, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 23)
        Me.Label4.TabIndex = 190
        Me.Label4.Text = "Cantidad"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 23)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "Cliente"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(99, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 23)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Descripcion"
        '
        'PCotiza80
        '
        '
        'PCotiza58
        '
        '
        'Timer1
        '
        '
        'PVenta80
        '
        '
        'PVenta58
        '
        '
        'frmIngresoDispositivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1063, 571)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIngresoDispositivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso a Taller"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblfolio As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnstatus As Button
    Friend WithEvents txtadeuda As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtMaximo As TextBox
    Friend WithEvents txtcliente As TextBox
    Friend WithEvents txtFavor As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtcontra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOrden As TextBox
    Friend WithEvents cboSerie As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtfallas As RichTextBox
    Friend WithEvents txtModelo As TextBox
    Friend WithEvents txtTecnico As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMarca As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents btnCoti As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cboimpresion As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtdescuento2 As TextBox
    Friend WithEvents txtSubTotal As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtPagar As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Label16 As Label
    Friend WithEvents txtUnidad As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtexistencia As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents cboDescripcion As ComboBox
    Friend WithEvents cboCodigo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PCotiza80 As Printing.PrintDocument
    Friend WithEvents PCotiza58 As Printing.PrintDocument
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PVenta80 As Printing.PrintDocument
    Friend WithEvents PVenta58 As Printing.PrintDocument
    Friend WithEvents cboSerieP As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
End Class
