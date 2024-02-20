<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPolleria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPolleria))
        Me.plateral = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLLETRA = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblAtiende = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnAsiganar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pEmpleado = New System.Windows.Forms.Panel()
        Me.pDepartamento = New System.Windows.Forms.Panel()
        Me.pgrupo = New System.Windows.Forms.Panel()
        Me.pProductos = New System.Windows.Forms.Panel()
        Me.ppeso = New System.Windows.Forms.Panel()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BTNINTRO = New System.Windows.Forms.Button()
        Me.btnp = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.BTN7 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.btnlimpia = New System.Windows.Forms.Button()
        Me.plateral.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.psuperior.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ppeso.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'plateral
        '
        Me.plateral.Controls.Add(Me.grdCaptura)
        Me.plateral.Controls.Add(Me.Panel2)
        Me.plateral.Location = New System.Drawing.Point(864, 0)
        Me.plateral.Name = "plateral"
        Me.plateral.Size = New System.Drawing.Size(290, 682)
        Me.plateral.TabIndex = 0
        Me.plateral.Visible = False
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.grdCaptura.Location = New System.Drawing.Point(0, 309)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.RowHeadersWidth = 62
        Me.grdCaptura.Size = New System.Drawing.Size(290, 373)
        Me.grdCaptura.TabIndex = 68
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod"
        Me.Column1.MinimumWidth = 8
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "Desc."
        Me.Column2.MinimumWidth = 8
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 110
        '
        'Column3
        '
        Me.Column3.HeaderText = "Cant."
        Me.Column3.MinimumWidth = 8
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "P.U."
        Me.Column4.MinimumWidth = 8
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "Importe"
        Me.Column5.MinimumWidth = 8
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 70
        '
        'Column6
        '
        Me.Column6.HeaderText = "Comentario"
        Me.Column6.MinimumWidth = 8
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 150
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.LBLLETRA)
        Me.Panel2.Controls.Add(Me.lblTotalVenta)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(290, 100)
        Me.Panel2.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(288, 30)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "VENTA TOTAL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LBLLETRA
        '
        Me.LBLLETRA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LBLLETRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLETRA.ForeColor = System.Drawing.Color.Black
        Me.LBLLETRA.Location = New System.Drawing.Point(0, 61)
        Me.LBLLETRA.Name = "LBLLETRA"
        Me.LBLLETRA.Size = New System.Drawing.Size(288, 39)
        Me.LBLLETRA.TabIndex = 66
        Me.LBLLETRA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVenta.ForeColor = System.Drawing.Color.Black
        Me.lblTotalVenta.Location = New System.Drawing.Point(0, 30)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(288, 31)
        Me.lblTotalVenta.TabIndex = 65
        Me.lblTotalVenta.Text = "0.00"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'psuperior
        '
        Me.psuperior.Controls.Add(Me.Panel4)
        Me.psuperior.Controls.Add(Me.Panel3)
        Me.psuperior.Controls.Add(Me.Panel1)
        Me.psuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.psuperior.Location = New System.Drawing.Point(0, 0)
        Me.psuperior.Name = "psuperior"
        Me.psuperior.Size = New System.Drawing.Size(1154, 100)
        Me.psuperior.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblAtiende)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(299, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(505, 100)
        Me.Panel4.TabIndex = 2
        '
        'lblAtiende
        '
        Me.lblAtiende.BackColor = System.Drawing.Color.Khaki
        Me.lblAtiende.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAtiende.Location = New System.Drawing.Point(81, 9)
        Me.lblAtiende.Name = "lblAtiende"
        Me.lblAtiende.Size = New System.Drawing.Size(171, 21)
        Me.lblAtiende.TabIndex = 1
        Me.lblAtiende.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Atiende"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnLimpiar)
        Me.Panel3.Controls.Add(Me.btnAsiganar)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(804, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(350, 100)
        Me.Panel3.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(188, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 82)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnAsiganar
        '
        Me.btnAsiganar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAsiganar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsiganar.Image = CType(resources.GetObject("btnAsiganar.Image"), System.Drawing.Image)
        Me.btnAsiganar.Location = New System.Drawing.Point(20, 12)
        Me.btnAsiganar.Name = "btnAsiganar"
        Me.btnAsiganar.Size = New System.Drawing.Size(75, 82)
        Me.btnAsiganar.TabIndex = 2
        Me.btnAsiganar.Text = "Asignar"
        Me.btnAsiganar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAsiganar.UseVisualStyleBackColor = True
        Me.btnAsiganar.Visible = False
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(102, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 82)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Pagar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(269, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 82)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(299, 100)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(299, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(83, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'pEmpleado
        '
        Me.pEmpleado.BackColor = System.Drawing.Color.White
        Me.pEmpleado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pEmpleado.Location = New System.Drawing.Point(0, 100)
        Me.pEmpleado.Name = "pEmpleado"
        Me.pEmpleado.Size = New System.Drawing.Size(299, 582)
        Me.pEmpleado.TabIndex = 8
        '
        'pDepartamento
        '
        Me.pDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pDepartamento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pDepartamento.Location = New System.Drawing.Point(299, 100)
        Me.pDepartamento.Name = "pDepartamento"
        Me.pDepartamento.Size = New System.Drawing.Size(124, 582)
        Me.pDepartamento.TabIndex = 9
        '
        'pgrupo
        '
        Me.pgrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.pgrupo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgrupo.Location = New System.Drawing.Point(423, 100)
        Me.pgrupo.Name = "pgrupo"
        Me.pgrupo.Size = New System.Drawing.Size(220, 582)
        Me.pgrupo.TabIndex = 10
        '
        'pProductos
        '
        Me.pProductos.BackColor = System.Drawing.Color.White
        Me.pProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pProductos.Location = New System.Drawing.Point(643, 100)
        Me.pProductos.Name = "pProductos"
        Me.pProductos.Size = New System.Drawing.Size(511, 582)
        Me.pProductos.TabIndex = 11
        '
        'ppeso
        '
        Me.ppeso.BackColor = System.Drawing.Color.Bisque
        Me.ppeso.Controls.Add(Me.btnlimpia)
        Me.ppeso.Controls.Add(Me.Button4)
        Me.ppeso.Controls.Add(Me.BTNINTRO)
        Me.ppeso.Controls.Add(Me.btnp)
        Me.ppeso.Controls.Add(Me.btn3)
        Me.ppeso.Controls.Add(Me.btn6)
        Me.ppeso.Controls.Add(Me.btn9)
        Me.ppeso.Controls.Add(Me.btn2)
        Me.ppeso.Controls.Add(Me.btn5)
        Me.ppeso.Controls.Add(Me.btn8)
        Me.ppeso.Controls.Add(Me.btn0)
        Me.ppeso.Controls.Add(Me.btn1)
        Me.ppeso.Controls.Add(Me.btn4)
        Me.ppeso.Controls.Add(Me.BTN7)
        Me.ppeso.Controls.Add(Me.GroupBox1)
        Me.ppeso.Location = New System.Drawing.Point(600, 200)
        Me.ppeso.Name = "ppeso"
        Me.ppeso.Size = New System.Drawing.Size(449, 464)
        Me.ppeso.TabIndex = 0
        Me.ppeso.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Linen
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(322, 373)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(115, 78)
        Me.Button4.TabIndex = 13
        Me.Button4.Text = "Salir"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'BTNINTRO
        '
        Me.BTNINTRO.BackColor = System.Drawing.Color.Linen
        Me.BTNINTRO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTNINTRO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNINTRO.Location = New System.Drawing.Point(322, 92)
        Me.BTNINTRO.Name = "BTNINTRO"
        Me.BTNINTRO.Size = New System.Drawing.Size(115, 275)
        Me.BTNINTRO.TabIndex = 12
        Me.BTNINTRO.Text = "INTRO"
        Me.BTNINTRO.UseVisualStyleBackColor = False
        '
        'btnp
        '
        Me.btnp.BackColor = System.Drawing.Color.Linen
        Me.btnp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnp.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnp.Location = New System.Drawing.Point(120, 373)
        Me.btnp.Name = "btnp"
        Me.btnp.Size = New System.Drawing.Size(92, 78)
        Me.btnp.TabIndex = 11
        Me.btnp.Text = "."
        Me.btnp.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.Linen
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(218, 280)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(98, 87)
        Me.btn3.TabIndex = 10
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.Linen
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(218, 185)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(98, 87)
        Me.btn6.TabIndex = 9
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.Linen
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(218, 92)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(98, 87)
        Me.btn9.TabIndex = 8
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.Linen
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(120, 280)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(92, 87)
        Me.btn2.TabIndex = 7
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.Linen
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(120, 185)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(92, 87)
        Me.btn5.TabIndex = 6
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.Linen
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(120, 92)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(92, 87)
        Me.btn8.TabIndex = 5
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.Linen
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(23, 373)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(91, 78)
        Me.btn0.TabIndex = 4
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.Linen
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(23, 280)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(91, 87)
        Me.btn1.TabIndex = 3
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.Linen
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(23, 185)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(91, 87)
        Me.btn4.TabIndex = 2
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'BTN7
        '
        Me.BTN7.BackColor = System.Drawing.Color.Linen
        Me.BTN7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTN7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN7.Location = New System.Drawing.Point(23, 92)
        Me.BTN7.Name = "BTN7"
        Me.BTN7.Size = New System.Drawing.Size(91, 87)
        Me.BTN7.TabIndex = 1
        Me.BTN7.Text = "7"
        Me.BTN7.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPeso)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Peso"
        '
        'txtPeso
        '
        Me.txtPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeso.Location = New System.Drawing.Point(17, 29)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(389, 26)
        Me.txtPeso.TabIndex = 0
        '
        'btnlimpia
        '
        Me.btnlimpia.BackColor = System.Drawing.Color.Linen
        Me.btnlimpia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnlimpia.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpia.Location = New System.Drawing.Point(218, 373)
        Me.btnlimpia.Name = "btnlimpia"
        Me.btnlimpia.Size = New System.Drawing.Size(98, 78)
        Me.btnlimpia.TabIndex = 14
        Me.btnlimpia.Text = "C0"
        Me.btnlimpia.UseVisualStyleBackColor = False
        '
        'frmPolleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1154, 682)
        Me.Controls.Add(Me.ppeso)
        Me.Controls.Add(Me.pProductos)
        Me.Controls.Add(Me.pgrupo)
        Me.Controls.Add(Me.pDepartamento)
        Me.Controls.Add(Me.pEmpleado)
        Me.Controls.Add(Me.psuperior)
        Me.Controls.Add(Me.plateral)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPolleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Polleria"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.plateral.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.psuperior.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ppeso.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents plateral As Panel
    Friend WithEvents psuperior As Panel
    Friend WithEvents pEmpleado As Panel
    Friend WithEvents pDepartamento As Panel
    Friend WithEvents pgrupo As Panel
    Friend WithEvents pProductos As Panel
    Friend WithEvents LBLLETRA As Label
    Friend WithEvents lblTotalVenta As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblAtiende As Label
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btnAsiganar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents ppeso As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtPeso As TextBox
    Friend WithEvents btn3 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents BTN7 As Button
    Friend WithEvents BTNINTRO As Button
    Friend WithEvents btnp As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btnlimpia As Button
End Class
