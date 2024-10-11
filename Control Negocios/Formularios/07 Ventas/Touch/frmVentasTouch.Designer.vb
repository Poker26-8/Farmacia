<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasTouch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasTouch))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tFecha = New System.Windows.Forms.Timer(Me.components)
        Me.tFolio = New System.Windows.Forms.Timer(Me.components)
        Me.pVenta80 = New System.Drawing.Printing.PrintDocument()
        Me.pVenta58 = New System.Drawing.Printing.PrintDocument()
        Me.panCantidad = New System.Windows.Forms.Panel()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.btnpoint = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnc0 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.pProductos = New System.Windows.Forms.Panel()
        Me.pGrupos = New System.Windows.Forms.Panel()
        Me.pDeptos = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.btnpagar = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbltipoventa = New System.Windows.Forms.Label()
        Me.lblatiende = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.panDerecha = New System.Windows.Forms.Panel()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdProducto = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblcantidadletra = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panCantidad.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panDerecha.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'tFecha
        '
        Me.tFecha.Interval = 1
        '
        'tFolio
        '
        '
        'pVenta80
        '
        '
        'pVenta58
        '
        '
        'panCantidad
        '
        Me.panCantidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.panCantidad.Controls.Add(Me.btnsalir)
        Me.panCantidad.Controls.Add(Me.btnaceptar)
        Me.panCantidad.Controls.Add(Me.btnpoint)
        Me.panCantidad.Controls.Add(Me.btn0)
        Me.panCantidad.Controls.Add(Me.btnc0)
        Me.panCantidad.Controls.Add(Me.btn9)
        Me.panCantidad.Controls.Add(Me.btn8)
        Me.panCantidad.Controls.Add(Me.btn7)
        Me.panCantidad.Controls.Add(Me.btn6)
        Me.panCantidad.Controls.Add(Me.btn5)
        Me.panCantidad.Controls.Add(Me.btn4)
        Me.panCantidad.Controls.Add(Me.btn3)
        Me.panCantidad.Controls.Add(Me.btn2)
        Me.panCantidad.Controls.Add(Me.btn1)
        Me.panCantidad.Controls.Add(Me.txtcantidad)
        Me.panCantidad.Location = New System.Drawing.Point(414, 150)
        Me.panCantidad.Name = "panCantidad"
        Me.panCantidad.Size = New System.Drawing.Size(189, 305)
        Me.panCantidad.TabIndex = 13
        Me.panCantidad.Visible = False
        '
        'btnsalir
        '
        Me.btnsalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnsalir.Location = New System.Drawing.Point(98, 269)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(84, 28)
        Me.btnsalir.TabIndex = 24
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = False
        '
        'btnaceptar
        '
        Me.btnaceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnaceptar.Location = New System.Drawing.Point(8, 269)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(84, 28)
        Me.btnaceptar.TabIndex = 23
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = False
        '
        'btnpoint
        '
        Me.btnpoint.BackColor = System.Drawing.Color.White
        Me.btnpoint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnpoint.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpoint.Location = New System.Drawing.Point(128, 215)
        Me.btnpoint.Name = "btnpoint"
        Me.btnpoint.Size = New System.Drawing.Size(54, 48)
        Me.btnpoint.TabIndex = 21
        Me.btnpoint.Text = "."
        Me.btnpoint.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn0.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(68, 215)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(54, 48)
        Me.btn0.TabIndex = 20
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnc0
        '
        Me.btnc0.BackColor = System.Drawing.Color.White
        Me.btnc0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnc0.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnc0.Location = New System.Drawing.Point(8, 215)
        Me.btnc0.Name = "btnc0"
        Me.btnc0.Size = New System.Drawing.Size(54, 48)
        Me.btnc0.TabIndex = 19
        Me.btnc0.Text = "C0"
        Me.btnc0.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn9.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(128, 162)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(54, 48)
        Me.btn9.TabIndex = 18
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn8.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(68, 162)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(54, 48)
        Me.btn8.TabIndex = 17
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn7.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(8, 162)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(54, 48)
        Me.btn7.TabIndex = 16
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn6.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(127, 109)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(54, 48)
        Me.btn6.TabIndex = 15
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(68, 109)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(54, 48)
        Me.btn5.TabIndex = 14
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn4.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(8, 109)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(54, 48)
        Me.btn4.TabIndex = 13
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(128, 56)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(54, 48)
        Me.btn3.TabIndex = 12
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(68, 56)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(54, 48)
        Me.btn2.TabIndex = 11
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(8, 56)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(54, 48)
        Me.btn1.TabIndex = 10
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'txtcantidad
        '
        Me.txtcantidad.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(8, 7)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(174, 43)
        Me.txtcantidad.TabIndex = 9
        Me.txtcantidad.Text = "0"
        Me.txtcantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pProductos
        '
        Me.pProductos.AutoScroll = True
        Me.pProductos.BackColor = System.Drawing.Color.White
        Me.pProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pProductos.Location = New System.Drawing.Point(208, 79)
        Me.pProductos.Name = "pProductos"
        Me.pProductos.Size = New System.Drawing.Size(560, 437)
        Me.pProductos.TabIndex = 12
        '
        'pGrupos
        '
        Me.pGrupos.AutoScroll = True
        Me.pGrupos.BackColor = System.Drawing.Color.LemonChiffon
        Me.pGrupos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pGrupos.Location = New System.Drawing.Point(104, 79)
        Me.pGrupos.Name = "pGrupos"
        Me.pGrupos.Size = New System.Drawing.Size(104, 437)
        Me.pGrupos.TabIndex = 11
        '
        'pDeptos
        '
        Me.pDeptos.AutoScroll = True
        Me.pDeptos.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.pDeptos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pDeptos.Location = New System.Drawing.Point(0, 79)
        Me.pDeptos.Name = "pDeptos"
        Me.pDeptos.Size = New System.Drawing.Size(104, 437)
        Me.pDeptos.TabIndex = 10
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel3.Controls.Add(Me.btnpagar)
        Me.Panel3.Controls.Add(Me.btnlimpiar)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(768, 79)
        Me.Panel3.TabIndex = 9
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Panel6, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.txtbarras, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(208, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.09997!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.17926!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72076!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(410, 79)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Panel6
        '
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(14, 16)
        Me.Panel6.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label15, 2)
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(23, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(232, 26)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Código de barras"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbarras
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.txtbarras, 2)
        Me.txtbarras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtbarras.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbarras.Location = New System.Drawing.Point(23, 29)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(232, 27)
        Me.txtbarras.TabIndex = 8
        Me.txtbarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnpagar
        '
        Me.btnpagar.BackgroundImage = CType(resources.GetObject("btnpagar.BackgroundImage"), System.Drawing.Image)
        Me.btnpagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnpagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnpagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnpagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpagar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpagar.Location = New System.Drawing.Point(618, 0)
        Me.btnpagar.Name = "btnpagar"
        Me.btnpagar.Size = New System.Drawing.Size(75, 79)
        Me.btnpagar.TabIndex = 7
        Me.btnpagar.Text = "PAGAR"
        Me.btnpagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnpagar.UseVisualStyleBackColor = True
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackgroundImage = CType(resources.GetObject("btnlimpiar.BackgroundImage"), System.Drawing.Image)
        Me.btnlimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnlimpiar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Location = New System.Drawing.Point(693, 0)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(75, 79)
        Me.btnlimpiar.TabIndex = 6
        Me.btnlimpiar.Text = "LIMPIAR"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.PictureBox1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(208, 79)
        Me.Panel7.TabIndex = 4
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(193, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 516)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(768, 89)
        Me.Panel2.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbltipoventa, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblatiende, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblfecha, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFolio, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 4, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.71899!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28101!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.71899!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28101!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(768, 89)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label18, 2)
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(150, 60)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(148, 29)
        Me.Label18.TabIndex = 14
        Me.Label18.Text = "Lista"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label17, 2)
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.Location = New System.Drawing.Point(150, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(148, 17)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Tipo de precio:"
        '
        'lbltipoventa
        '
        Me.lbltipoventa.BackColor = System.Drawing.Color.White
        Me.lbltipoventa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbltipoventa.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipoventa.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbltipoventa.Location = New System.Drawing.Point(3, 60)
        Me.lbltipoventa.Name = "lbltipoventa"
        Me.lbltipoventa.Size = New System.Drawing.Size(141, 29)
        Me.lbltipoventa.TabIndex = 9
        Me.lbltipoventa.Text = "MOSTRADOR"
        Me.lbltipoventa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblatiende
        '
        Me.lblatiende.BackColor = System.Drawing.Color.White
        Me.lblatiende.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblatiende.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblatiende.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblatiende.Location = New System.Drawing.Point(304, 17)
        Me.lblatiende.Name = "lblatiende"
        Me.lblatiende.Size = New System.Drawing.Size(145, 26)
        Me.lblatiende.TabIndex = 8
        Me.lblatiende.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblfecha
        '
        Me.lblfecha.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblfecha, 2)
        Me.lblfecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblfecha.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfecha.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblfecha.Location = New System.Drawing.Point(150, 17)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(148, 26)
        Me.lblfecha.TabIndex = 7
        Me.lblfecha.Text = "DD/MM/YYYY"
        Me.lblfecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFolio
        '
        Me.lblFolio.BackColor = System.Drawing.Color.White
        Me.lblFolio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFolio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblFolio.Location = New System.Drawing.Point(3, 17)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(141, 26)
        Me.lblFolio.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(304, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 17)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Le atiende:"
        '
        'Label6
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(150, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 17)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(3, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Tipo de venta:"
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Folio:"
        '
        'Panel1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(455, 3)
        Me.Panel1.Name = "Panel1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Panel1, 4)
        Me.Panel1.Size = New System.Drawing.Size(344, 83)
        Me.Panel1.TabIndex = 15
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(221, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 40)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "VENTAS 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(216, 49)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(91, 29)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(207, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Porcentage de descuento:"
        '
        'Button4
        '
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(111, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(107, 40)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "CANTIDAD"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "BUSCAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'panDerecha
        '
        Me.panDerecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.panDerecha.Controls.Add(Me.grdcaptura)
        Me.panDerecha.Controls.Add(Me.grdProducto)
        Me.panDerecha.Controls.Add(Me.lblcantidadletra)
        Me.panDerecha.Controls.Add(Me.Panel8)
        Me.panDerecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.panDerecha.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panDerecha.Location = New System.Drawing.Point(768, 0)
        Me.panDerecha.Name = "panDerecha"
        Me.panDerecha.Size = New System.Drawing.Size(249, 605)
        Me.panDerecha.TabIndex = 7
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdcaptura.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.FloralWhite
        Me.grdcaptura.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdcaptura.DefaultCellStyle = DataGridViewCellStyle5
        Me.grdcaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdcaptura.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdcaptura.Location = New System.Drawing.Point(0, 120)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.RowTemplate.Height = 40
        Me.grdcaptura.Size = New System.Drawing.Size(249, 396)
        Me.grdcaptura.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column1.HeaderText = "Item"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column2.HeaderText = "Cant."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 52
        '
        'Column3
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column3.HeaderText = "Precio"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 57
        '
        'Column4
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column4.FillWeight = 70.0!
        Me.Column4.HeaderText = "Total"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 50
        '
        'grdProducto
        '
        Me.grdProducto.AllowUserToAddRows = False
        Me.grdProducto.AllowUserToDeleteRows = False
        Me.grdProducto.BackgroundColor = System.Drawing.Color.AliceBlue
        Me.grdProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProducto.ColumnHeadersVisible = False
        Me.grdProducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column6})
        Me.grdProducto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdProducto.GridColor = System.Drawing.Color.AliceBlue
        Me.grdProducto.Location = New System.Drawing.Point(0, 516)
        Me.grdProducto.Name = "grdProducto"
        Me.grdProducto.ReadOnly = True
        Me.grdProducto.RowHeadersVisible = False
        Me.grdProducto.RowTemplate.Height = 20
        Me.grdProducto.Size = New System.Drawing.Size(249, 89)
        Me.grdProducto.TabIndex = 4
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'lblcantidadletra
        '
        Me.lblcantidadletra.BackColor = System.Drawing.Color.White
        Me.lblcantidadletra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblcantidadletra.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblcantidadletra.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcantidadletra.Location = New System.Drawing.Point(0, 79)
        Me.lblcantidadletra.Name = "lblcantidadletra"
        Me.lblcantidadletra.Size = New System.Drawing.Size(249, 41)
        Me.lblcantidadletra.TabIndex = 3
        Me.lblcantidadletra.Text = "CANTIDAD CON LETRA"
        Me.lblcantidadletra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.Controls.Add(Me.lblTotal)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(249, 79)
        Me.Panel8.TabIndex = 2
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.White
        Me.lblTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI Semilight", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(0, 19)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(249, 60)
        Me.lblTotal.TabIndex = 4
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(249, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VENTA TOTAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmVentasTouch
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1017, 605)
        Me.Controls.Add(Me.panCantidad)
        Me.Controls.Add(Me.pProductos)
        Me.Controls.Add(Me.pGrupos)
        Me.Controls.Add(Me.pDeptos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.panDerecha)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1023, 634)
        Me.Name = "frmVentasTouch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delsscom® Control Negocios Pro - Ventas touch"
        Me.panCantidad.ResumeLayout(False)
        Me.panCantidad.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panDerecha.ResumeLayout(False)
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tFecha As System.Windows.Forms.Timer
    Friend WithEvents tFolio As System.Windows.Forms.Timer
    Friend WithEvents pVenta80 As Printing.PrintDocument
    Friend WithEvents pVenta58 As Printing.PrintDocument
    Friend WithEvents panCantidad As Panel
    Friend WithEvents btnsalir As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents btnpoint As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnc0 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents pProductos As Panel
    Friend WithEvents pGrupos As Panel
    Friend WithEvents pDeptos As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents txtbarras As TextBox
    Friend WithEvents btnpagar As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lbltipoventa As Label
    Friend WithEvents lblatiende As Label
    Friend WithEvents lblfecha As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents panDerecha As Panel
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents grdProducto As DataGridView
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents lblcantidadletra As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label1 As Label
End Class
