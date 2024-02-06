<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicioCuarto
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServicioCuarto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCantidadLetra = New System.Windows.Forms.Label()
        Me.lblTotalPagar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblNumCliente = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblAtendio = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblHabitacion = New System.Windows.Forms.Label()
        Me.btnOcacional = New System.Windows.Forms.Button()
        Me.btnCortesia = New System.Windows.Forms.Button()
        Me.btnCantidad = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.pdepa = New System.Windows.Forms.Panel()
        Me.PGrupo = New System.Windows.Forms.Panel()
        Me.pproductos = New System.Windows.Forms.Panel()
        Me.TFecha = New System.Windows.Forms.Timer(Me.components)
        Me.TFolio = New System.Windows.Forms.Timer(Me.components)
        Me.PComandaH80 = New System.Drawing.Printing.PrintDocument()
        Me.PComandaH58 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdCaptura)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(888, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 831)
        Me.Panel1.TabIndex = 0
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column9})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 122)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.RowTemplate.Height = 40
        Me.grdCaptura.Size = New System.Drawing.Size(342, 709)
        Me.grdCaptura.TabIndex = 88
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Desc."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cant."
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "P.U."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "Importe"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 65
        '
        'Column6
        '
        Me.Column6.HeaderText = "Com"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "PEP"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Comentario"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblCantidadLetra)
        Me.Panel3.Controls.Add(Me.lblTotalPagar)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(342, 122)
        Me.Panel3.TabIndex = 1
        '
        'lblCantidadLetra
        '
        Me.lblCantidadLetra.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblCantidadLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadLetra.ForeColor = System.Drawing.Color.Black
        Me.lblCantidadLetra.Location = New System.Drawing.Point(0, 76)
        Me.lblCantidadLetra.Name = "lblCantidadLetra"
        Me.lblCantidadLetra.Size = New System.Drawing.Size(338, 41)
        Me.lblCantidadLetra.TabIndex = 86
        Me.lblCantidadLetra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPagar
        '
        Me.lblTotalPagar.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPagar.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPagar.Location = New System.Drawing.Point(0, 23)
        Me.lblTotalPagar.Name = "lblTotalPagar"
        Me.lblTotalPagar.Size = New System.Drawing.Size(338, 53)
        Me.lblTotalPagar.TabIndex = 85
        Me.lblTotalPagar.Text = "0.00"
        Me.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(338, 23)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "VENTA TOTAL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.btnEnviar)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(888, 100)
        Me.Panel2.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(708, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 73)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(789, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 73)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnEnviar
        '
        Me.btnEnviar.BackColor = System.Drawing.Color.White
        Me.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Image = CType(resources.GetObject("btnEnviar.Image"), System.Drawing.Image)
        Me.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEnviar.Location = New System.Drawing.Point(627, 12)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 73)
        Me.btnEnviar.TabIndex = 1
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEnviar.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.piclogo)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(226, 100)
        Me.Panel5.TabIndex = 0
        '
        'piclogo
        '
        Me.piclogo.BackColor = System.Drawing.Color.White
        Me.piclogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.piclogo.Location = New System.Drawing.Point(0, 0)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(226, 100)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.piclogo.TabIndex = 0
        Me.piclogo.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.89773!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.252084!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.89772!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0289!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.78613!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.60308!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblCliente, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNumCliente, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblfolio, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblFecha, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTipoVenta, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblTelefono, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDireccion, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAtendio, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblHabitacion, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOcacional, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCortesia, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCantidad, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtUsuario, 5, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 665)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.56863!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.60784!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.60784!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.60784!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.60784!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(888, 166)
        Me.TableLayoutPanel1.TabIndex = 4
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblCliente, 2)
        Me.lblCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(206, 131)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(301, 35)
        Me.lblCliente.TabIndex = 3
        Me.lblCliente.Text = "MOSTRADOR"
        '
        'lblNumCliente
        '
        Me.lblNumCliente.AutoSize = True
        Me.lblNumCliente.BackColor = System.Drawing.Color.SkyBlue
        Me.lblNumCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNumCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumCliente.ForeColor = System.Drawing.Color.Black
        Me.lblNumCliente.Location = New System.Drawing.Point(178, 131)
        Me.lblNumCliente.Name = "lblNumCliente"
        Me.lblNumCliente.Size = New System.Drawing.Size(22, 35)
        Me.lblNumCliente.TabIndex = 2
        Me.lblNumCliente.Text = "0"
        Me.lblNumCliente.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(178, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(197, 32)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Fecha:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.SkyBlue
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 32)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Folio:"
        '
        'lblfolio
        '
        Me.lblfolio.AutoSize = True
        Me.lblfolio.BackColor = System.Drawing.Color.SkyBlue
        Me.lblfolio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblfolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolio.ForeColor = System.Drawing.Color.Black
        Me.lblfolio.Location = New System.Drawing.Point(3, 67)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(169, 32)
        Me.lblfolio.TabIndex = 4
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.lblFecha, 2)
        Me.lblFecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(178, 67)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(197, 32)
        Me.lblFecha.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SkyBlue
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label9, 2)
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(178, 99)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(197, 32)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Cliente:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SkyBlue
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 32)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Tipo de Venta"
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.BackColor = System.Drawing.Color.SkyBlue
        Me.lblTipoVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoVenta.ForeColor = System.Drawing.Color.Black
        Me.lblTipoVenta.Location = New System.Drawing.Point(3, 131)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(169, 35)
        Me.lblTipoVenta.TabIndex = 8
        Me.lblTipoVenta.Text = "MOSTRADOR"
        '
        'lblTelefono
        '
        Me.lblTelefono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.ForeColor = System.Drawing.Color.Black
        Me.lblTelefono.Location = New System.Drawing.Point(513, 131)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(160, 35)
        Me.lblTelefono.TabIndex = 9
        '
        'lblDireccion
        '
        Me.lblDireccion.BackColor = System.Drawing.Color.SkyBlue
        Me.lblDireccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(679, 131)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(206, 35)
        Me.lblDireccion.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SkyBlue
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(381, 67)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 32)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Le Atiende:"
        '
        'lblAtendio
        '
        Me.lblAtendio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAtendio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtendio.ForeColor = System.Drawing.Color.Black
        Me.lblAtendio.Location = New System.Drawing.Point(381, 99)
        Me.lblAtendio.Name = "lblAtendio"
        Me.lblAtendio.Size = New System.Drawing.Size(126, 32)
        Me.lblAtendio.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SkyBlue
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(513, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 32)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Habitación"
        '
        'lblHabitacion
        '
        Me.lblHabitacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHabitacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHabitacion.ForeColor = System.Drawing.Color.Black
        Me.lblHabitacion.Location = New System.Drawing.Point(513, 99)
        Me.lblHabitacion.Name = "lblHabitacion"
        Me.lblHabitacion.Size = New System.Drawing.Size(160, 32)
        Me.lblHabitacion.TabIndex = 14
        '
        'btnOcacional
        '
        Me.btnOcacional.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOcacional.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOcacional.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOcacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOcacional.Location = New System.Drawing.Point(679, 3)
        Me.btnOcacional.Name = "btnOcacional"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnOcacional, 2)
        Me.btnOcacional.Size = New System.Drawing.Size(206, 61)
        Me.btnOcacional.TabIndex = 15
        Me.btnOcacional.Text = "Producto Ocasional"
        Me.btnOcacional.UseVisualStyleBackColor = False
        '
        'btnCortesia
        '
        Me.btnCortesia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCortesia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCortesia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCortesia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCortesia.Location = New System.Drawing.Point(513, 3)
        Me.btnCortesia.Name = "btnCortesia"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnCortesia, 2)
        Me.btnCortesia.Size = New System.Drawing.Size(160, 61)
        Me.btnCortesia.TabIndex = 16
        Me.btnCortesia.Text = "Cortesia"
        Me.btnCortesia.UseVisualStyleBackColor = False
        '
        'btnCantidad
        '
        Me.btnCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCantidad.Location = New System.Drawing.Point(381, 3)
        Me.btnCantidad.Name = "btnCantidad"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnCantidad, 2)
        Me.btnCantidad.Size = New System.Drawing.Size(126, 61)
        Me.btnCantidad.TabIndex = 17
        Me.btnCantidad.Text = "Cantidad"
        Me.btnCantidad.UseVisualStyleBackColor = False
        '
        'txtUsuario
        '
        Me.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsuario.Location = New System.Drawing.Point(679, 70)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(206, 20)
        Me.txtUsuario.TabIndex = 18
        Me.txtUsuario.Visible = False
        '
        'pdepa
        '
        Me.pdepa.BackColor = System.Drawing.Color.LightSeaGreen
        Me.pdepa.Dock = System.Windows.Forms.DockStyle.Left
        Me.pdepa.Location = New System.Drawing.Point(0, 100)
        Me.pdepa.Name = "pdepa"
        Me.pdepa.Size = New System.Drawing.Size(113, 565)
        Me.pdepa.TabIndex = 68
        '
        'PGrupo
        '
        Me.PGrupo.BackColor = System.Drawing.Color.PaleTurquoise
        Me.PGrupo.Dock = System.Windows.Forms.DockStyle.Left
        Me.PGrupo.Location = New System.Drawing.Point(113, 100)
        Me.PGrupo.Name = "PGrupo"
        Me.PGrupo.Size = New System.Drawing.Size(113, 565)
        Me.PGrupo.TabIndex = 69
        '
        'pproductos
        '
        Me.pproductos.BackColor = System.Drawing.Color.White
        Me.pproductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pproductos.Location = New System.Drawing.Point(226, 100)
        Me.pproductos.Name = "pproductos"
        Me.pproductos.Size = New System.Drawing.Size(662, 565)
        Me.pproductos.TabIndex = 70
        '
        'TFecha
        '
        '
        'TFolio
        '
        '
        'PComandaH80
        '
        '
        'PComandaH58
        '
        '
        'frmServicioCuarto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1230, 831)
        Me.Controls.Add(Me.pproductos)
        Me.Controls.Add(Me.PGrupo)
        Me.Controls.Add(Me.pdepa)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmServicioCuarto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Productos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCantidadLetra As Label
    Friend WithEvents lblTotalPagar As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnEnviar As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents piclogo As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblNumCliente As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblfolio As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTipoVenta As Label
    Friend WithEvents lblTelefono As Label
    Friend WithEvents lblDireccion As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblAtendio As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblHabitacion As Label
    Friend WithEvents btnOcacional As Button
    Friend WithEvents btnCortesia As Button
    Friend WithEvents btnCantidad As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents pdepa As Panel
    Friend WithEvents PGrupo As Panel
    Friend WithEvents pproductos As Panel
    Friend WithEvents TFecha As Timer
    Friend WithEvents TFolio As Timer
    Friend WithEvents PComandaH80 As Printing.PrintDocument
    Friend WithEvents PComandaH58 As Printing.PrintDocument
End Class
