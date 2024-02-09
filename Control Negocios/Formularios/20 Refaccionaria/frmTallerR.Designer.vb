<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTallerR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTallerR))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdProductos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtvehiculo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtclave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCantidadLetra = New System.Windows.Forms.Label()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cboimpresion = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbltipoprecio = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbltipoventa = New System.Windows.Forms.Label()
        Me.lblatiende = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnRefaccion = New System.Windows.Forms.Button()
        Me.lblidvehiculo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtadeuda = New System.Windows.Forms.TextBox()
        Me.txtFavor = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnpagar = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtMaximo = New System.Windows.Forms.TextBox()
        Me.pVehiculos = New System.Windows.Forms.Panel()
        Me.TVehiculo = New System.Windows.Forms.Timer(Me.components)
        Me.TVenta = New System.Windows.Forms.Timer(Me.components)
        Me.TFecha = New System.Windows.Forms.Timer(Me.components)
        Me.PVenta80 = New System.Drawing.Printing.PrintDocument()
        Me.PVenta58 = New System.Drawing.Printing.PrintDocument()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtplaca = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdProductos)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(902, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(348, 790)
        Me.Panel1.TabIndex = 0
        '
        'grdProductos
        '
        Me.grdProductos.AllowUserToAddRows = False
        Me.grdProductos.AllowUserToDeleteRows = False
        Me.grdProductos.BackgroundColor = System.Drawing.Color.White
        Me.grdProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Location = New System.Drawing.Point(0, 224)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.ReadOnly = True
        Me.grdProductos.RowHeadersVisible = False
        Me.grdProductos.Size = New System.Drawing.Size(348, 566)
        Me.grdProductos.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "Desc"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cantidad"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Precio"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 65
        '
        'Column5
        '
        Me.Column5.HeaderText = "Total"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 65
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel7.Controls.Add(Me.txtplaca)
        Me.Panel7.Controls.Add(Me.Label11)
        Me.Panel7.Controls.Add(Me.txtvehiculo)
        Me.Panel7.Controls.Add(Me.Label3)
        Me.Panel7.Controls.Add(Me.txtclave)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 108)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(348, 116)
        Me.Panel7.TabIndex = 3
        '
        'txtvehiculo
        '
        Me.txtvehiculo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtvehiculo.Location = New System.Drawing.Point(6, 86)
        Me.txtvehiculo.Name = "txtvehiculo"
        Me.txtvehiculo.Size = New System.Drawing.Size(203, 20)
        Me.txtvehiculo.TabIndex = 85
        Me.txtvehiculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 28)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Vehiculo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtclave
        '
        Me.txtclave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtclave.Location = New System.Drawing.Point(6, 32)
        Me.txtclave.Name = "txtclave"
        Me.txtclave.Size = New System.Drawing.Size(339, 20)
        Me.txtclave.TabIndex = 81
        Me.txtclave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtclave.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(300, 28)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Clave de Usuario"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblCantidadLetra)
        Me.Panel4.Controls.Add(Me.lblTotalPagar)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(348, 108)
        Me.Panel4.TabIndex = 0
        '
        'lblCantidadLetra
        '
        Me.lblCantidadLetra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCantidadLetra.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblCantidadLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadLetra.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblCantidadLetra.Location = New System.Drawing.Point(0, 65)
        Me.lblCantidadLetra.Name = "lblCantidadLetra"
        Me.lblCantidadLetra.Size = New System.Drawing.Size(394, 42)
        Me.lblCantidadLetra.TabIndex = 82
        Me.lblCantidadLetra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.lblTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPagar.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblTotalPagar.Location = New System.Drawing.Point(0, 36)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(348, 33)
        Me.lblTotalPagar.TabIndex = 81
        Me.lblTotalPagar.Text = "0.00"
        Me.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 34)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "TOTAL A PAGAR"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 666)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(902, 124)
        Me.Panel2.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 111.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboimpresion, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbltipoprecio, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lbltipoventa, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblatiende, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblfecha, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFolio, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblcliente, 4, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.71899!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28101!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.71899!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.28101!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(902, 124)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'cboimpresion
        '
        Me.cboimpresion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboimpresion.FormattingEnabled = True
        Me.cboimpresion.Location = New System.Drawing.Point(455, 27)
        Me.cboimpresion.Name = "cboimpresion"
        Me.cboimpresion.Size = New System.Drawing.Size(250, 21)
        Me.cboimpresion.TabIndex = 198
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(455, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 19)
        Me.Label15.TabIndex = 197
        Me.Label15.Text = "Imprime en:"
        '
        'lbltipoprecio
        '
        Me.lbltipoprecio.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.SetColumnSpan(Me.lbltipoprecio, 2)
        Me.lbltipoprecio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbltipoprecio.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipoprecio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbltipoprecio.Location = New System.Drawing.Point(150, 85)
        Me.lbltipoprecio.Name = "lbltipoprecio"
        Me.lbltipoprecio.Size = New System.Drawing.Size(148, 39)
        Me.lbltipoprecio.TabIndex = 14
        Me.lbltipoprecio.Text = "Lista"
        Me.lbltipoprecio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label17, 2)
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.Location = New System.Drawing.Point(150, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(148, 24)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Tipo de precio:"
        '
        'lbltipoventa
        '
        Me.lbltipoventa.BackColor = System.Drawing.Color.White
        Me.lbltipoventa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbltipoventa.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipoventa.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbltipoventa.Location = New System.Drawing.Point(3, 85)
        Me.lbltipoventa.Name = "lbltipoventa"
        Me.lbltipoventa.Size = New System.Drawing.Size(141, 39)
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
        Me.lblatiende.Location = New System.Drawing.Point(304, 24)
        Me.lblatiende.Name = "lblatiende"
        Me.lblatiende.Size = New System.Drawing.Size(145, 37)
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
        Me.lblfecha.Location = New System.Drawing.Point(150, 24)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(148, 37)
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
        Me.lblFolio.Location = New System.Drawing.Point(3, 24)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(141, 37)
        Me.lblFolio.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(304, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(145, 24)
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
        Me.Label6.Size = New System.Drawing.Size(148, 24)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(3, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 24)
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
        Me.Label4.Size = New System.Drawing.Size(141, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Folio:"
        '
        'lblcliente
        '
        Me.lblcliente.BackColor = System.Drawing.Color.White
        Me.lblcliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcliente.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblcliente.Location = New System.Drawing.Point(455, 61)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(444, 24)
        Me.lblcliente.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.btnRefaccion)
        Me.Panel3.Controls.Add(Me.lblidvehiculo)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtadeuda)
        Me.Panel3.Controls.Add(Me.txtFavor)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.btnpagar)
        Me.Panel3.Controls.Add(Me.btnlimpiar)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Controls.Add(Me.txtMaximo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(902, 108)
        Me.Panel3.TabIndex = 4
        '
        'btnRefaccion
        '
        Me.btnRefaccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefaccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnRefaccion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnRefaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefaccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefaccion.Image = CType(resources.GetObject("btnRefaccion.Image"), System.Drawing.Image)
        Me.btnRefaccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRefaccion.Location = New System.Drawing.Point(568, 9)
        Me.btnRefaccion.Name = "btnRefaccion"
        Me.btnRefaccion.Size = New System.Drawing.Size(85, 79)
        Me.btnRefaccion.TabIndex = 207
        Me.btnRefaccion.Text = "Refaccion"
        Me.btnRefaccion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRefaccion.UseVisualStyleBackColor = True
        Me.btnRefaccion.Visible = False
        '
        'lblidvehiculo
        '
        Me.lblidvehiculo.Location = New System.Drawing.Point(280, 77)
        Me.lblidvehiculo.Name = "lblidvehiculo"
        Me.lblidvehiculo.Size = New System.Drawing.Size(47, 21)
        Me.lblidvehiculo.TabIndex = 206
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(277, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 20)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = "Adeuda:"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(277, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 18)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "Saldo a Favor:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(277, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 18)
        Me.Label7.TabIndex = 203
        Me.Label7.Text = "Crédito Máximo:"
        '
        'txtadeuda
        '
        Me.txtadeuda.Location = New System.Drawing.Point(373, 58)
        Me.txtadeuda.Name = "txtadeuda"
        Me.txtadeuda.Size = New System.Drawing.Size(76, 20)
        Me.txtadeuda.TabIndex = 202
        Me.txtadeuda.Text = "0.00"
        '
        'txtFavor
        '
        Me.txtFavor.Location = New System.Drawing.Point(373, 32)
        Me.txtFavor.Name = "txtFavor"
        Me.txtFavor.Size = New System.Drawing.Size(76, 20)
        Me.txtFavor.TabIndex = 200
        Me.txtFavor.Text = "0.00"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(474, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 79)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "VEHICULO"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(821, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 79)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "SALIR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnpagar
        '
        Me.btnpagar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnpagar.BackgroundImage = CType(resources.GetObject("btnpagar.BackgroundImage"), System.Drawing.Image)
        Me.btnpagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnpagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnpagar.Enabled = False
        Me.btnpagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpagar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpagar.Location = New System.Drawing.Point(659, 9)
        Me.btnpagar.Name = "btnpagar"
        Me.btnpagar.Size = New System.Drawing.Size(75, 79)
        Me.btnpagar.TabIndex = 9
        Me.btnpagar.Text = "Pagar"
        Me.btnpagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnpagar.UseVisualStyleBackColor = True
        '
        'btnlimpiar
        '
        Me.btnlimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnlimpiar.BackgroundImage = CType(resources.GetObject("btnlimpiar.BackgroundImage"), System.Drawing.Image)
        Me.btnlimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Location = New System.Drawing.Point(740, 9)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(75, 79)
        Me.btnlimpiar.TabIndex = 8
        Me.btnlimpiar.Text = "LIMPIAR"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(274, 102)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'txtMaximo
        '
        Me.txtMaximo.Location = New System.Drawing.Point(373, 6)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Size = New System.Drawing.Size(76, 20)
        Me.txtMaximo.TabIndex = 201
        Me.txtMaximo.Text = "0.00"
        '
        'pVehiculos
        '
        Me.pVehiculos.BackColor = System.Drawing.Color.FloralWhite
        Me.pVehiculos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pVehiculos.Location = New System.Drawing.Point(0, 108)
        Me.pVehiculos.Name = "pVehiculos"
        Me.pVehiculos.Size = New System.Drawing.Size(902, 558)
        Me.pVehiculos.TabIndex = 6
        '
        'TVehiculo
        '
        Me.TVehiculo.Interval = 2000
        '
        'TVenta
        '
        '
        'TFecha
        '
        '
        'PVenta80
        '
        '
        'PVenta58
        '
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(215, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(130, 28)
        Me.Label11.TabIndex = 86
        Me.Label11.Text = "Placa"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtplaca
        '
        Me.txtplaca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtplaca.Location = New System.Drawing.Point(215, 86)
        Me.txtplaca.Name = "txtplaca"
        Me.txtplaca.Size = New System.Drawing.Size(130, 20)
        Me.txtplaca.TabIndex = 87
        Me.txtplaca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmTallerR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1250, 790)
        Me.Controls.Add(Me.pVehiculos)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTallerR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Taller"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents cboimpresion As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lbltipoprecio As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lbltipoventa As Label
    Friend WithEvents lblatiende As Label
    Friend WithEvents lblfecha As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblcliente As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblidvehiculo As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtadeuda As TextBox
    Friend WithEvents txtFavor As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnpagar As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtMaximo As TextBox
    Friend WithEvents pVehiculos As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblCantidadLetra As Label
    Friend WithEvents lblTotalPagar As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TVehiculo As Timer
    Friend WithEvents TVenta As Timer
    Friend WithEvents TFecha As Timer
    Friend WithEvents PVenta80 As Printing.PrintDocument
    Friend WithEvents PVenta58 As Printing.PrintDocument
    Friend WithEvents grdProductos As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtvehiculo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtclave As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnRefaccion As Button
    Friend WithEvents txtplaca As TextBox
    Friend WithEvents Label11 As Label
End Class
