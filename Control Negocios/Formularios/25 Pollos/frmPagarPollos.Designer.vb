<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagarPollos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagarPollos))
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubtotalmapeo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdComandas = New System.Windows.Forms.DataGridView()
        Me.btnIntro = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboComanda = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblusuario2 = New System.Windows.Forms.Label()
        Me.btnPagar = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblmesa = New System.Windows.Forms.Label()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.btnPrecuenta = New System.Windows.Forms.Button()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdComandas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel6)
        Me.Panel7.Controls.Add(Me.btnPrecuenta)
        Me.Panel7.Controls.Add(Me.cboComanda)
        Me.Panel7.Controls.Add(Me.lblfolio)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.lblusuario2)
        Me.Panel7.Controls.Add(Me.Button2)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.Button1)
        Me.Panel7.Controls.Add(Me.txtTotal)
        Me.Panel7.Controls.Add(Me.btnIntro)
        Me.Panel7.Controls.Add(Me.Label2)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.txtSubtotalmapeo)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.lblmesa)
        Me.Panel7.Controls.Add(Me.Label19)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(908, 303)
        Me.Panel7.TabIndex = 8
        '
        'lblfolio
        '
        Me.lblfolio.BackColor = System.Drawing.Color.Gainsboro
        Me.lblfolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolio.Location = New System.Drawing.Point(5, 28)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(212, 21)
        Me.lblfolio.TabIndex = 32
        Me.lblfolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(212, 21)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "Folio Venta"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.Red
        Me.txtTotal.Location = New System.Drawing.Point(114, 96)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(100, 21)
        Me.txtTotal.TabIndex = 4
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total Pagar:"
        '
        'txtSubtotalmapeo
        '
        Me.txtSubtotalmapeo.BackColor = System.Drawing.Color.White
        Me.txtSubtotalmapeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotalmapeo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtSubtotalmapeo.Location = New System.Drawing.Point(114, 67)
        Me.txtSubtotalmapeo.Name = "txtSubtotalmapeo"
        Me.txtSubtotalmapeo.ReadOnly = True
        Me.txtSubtotalmapeo.Size = New System.Drawing.Size(100, 21)
        Me.txtSubtotalmapeo.TabIndex = 2
        Me.txtSubtotalmapeo.Text = "0.00"
        Me.txtSubtotalmapeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Subtotal:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdComandas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 309)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(908, 303)
        Me.Panel1.TabIndex = 9
        '
        'grdComandas
        '
        Me.grdComandas.AllowUserToAddRows = False
        Me.grdComandas.AllowUserToDeleteRows = False
        Me.grdComandas.BackgroundColor = System.Drawing.Color.White
        Me.grdComandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdComandas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.grdComandas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComandas.Location = New System.Drawing.Point(0, 0)
        Me.grdComandas.Name = "grdComandas"
        Me.grdComandas.ReadOnly = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdComandas.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdComandas.RowHeadersVisible = False
        Me.grdComandas.Size = New System.Drawing.Size(908, 303)
        Me.grdComandas.TabIndex = 0
        '
        'btnIntro
        '
        Me.btnIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnIntro.FlatAppearance.BorderSize = 0
        Me.btnIntro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIntro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIntro.Image = CType(resources.GetObject("btnIntro.Image"), System.Drawing.Image)
        Me.btnIntro.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnIntro.Location = New System.Drawing.Point(232, 132)
        Me.btnIntro.Name = "btnIntro"
        Me.btnIntro.Size = New System.Drawing.Size(104, 62)
        Me.btnIntro.TabIndex = 32
        Me.btnIntro.Text = "Transferencia"
        Me.btnIntro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIntro.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(122, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 62)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Tarjeta"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(12, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 62)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "Efectivo"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cboComanda
        '
        Me.cboComanda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.cboComanda.FormattingEnabled = True
        Me.cboComanda.Location = New System.Drawing.Point(310, 64)
        Me.cboComanda.Name = "cboComanda"
        Me.cboComanda.Size = New System.Drawing.Size(127, 21)
        Me.cboComanda.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(223, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 21)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Comanda:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel6.Controls.Add(Me.btnPagar)
        Me.Panel6.Controls.Add(Me.btn0)
        Me.Panel6.Controls.Add(Me.btnlimpiar)
        Me.Panel6.Controls.Add(Me.btn3)
        Me.Panel6.Controls.Add(Me.btn2)
        Me.Panel6.Controls.Add(Me.btn1)
        Me.Panel6.Controls.Add(Me.btn6)
        Me.Panel6.Controls.Add(Me.btn5)
        Me.Panel6.Controls.Add(Me.btn4)
        Me.Panel6.Controls.Add(Me.btn9)
        Me.Panel6.Controls.Add(Me.btn8)
        Me.Panel6.Controls.Add(Me.btn7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(657, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(251, 303)
        Me.Panel6.TabIndex = 37
        '
        'lblusuario2
        '
        Me.lblusuario2.BackColor = System.Drawing.Color.Gainsboro
        Me.lblusuario2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario2.Location = New System.Drawing.Point(443, 28)
        Me.lblusuario2.Name = "lblusuario2"
        Me.lblusuario2.Size = New System.Drawing.Size(208, 21)
        Me.lblusuario2.TabIndex = 26
        Me.lblusuario2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPagar
        '
        Me.btnPagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPagar.FlatAppearance.BorderSize = 0
        Me.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPagar.Location = New System.Drawing.Point(167, 241)
        Me.btnPagar.Name = "btnPagar"
        Me.btnPagar.Size = New System.Drawing.Size(65, 48)
        Me.btnPagar.TabIndex = 0
        Me.btnPagar.Text = "Salir"
        Me.btnPagar.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(443, 4)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(208, 21)
        Me.Label20.TabIndex = 25
        Me.Label20.Text = "Usuario"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmesa
        '
        Me.lblmesa.BackColor = System.Drawing.Color.Gainsboro
        Me.lblmesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesa.Location = New System.Drawing.Point(223, 28)
        Me.lblmesa.Name = "lblmesa"
        Me.lblmesa.Size = New System.Drawing.Size(214, 21)
        Me.lblmesa.TabIndex = 24
        Me.lblmesa.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn0.FlatAppearance.BorderSize = 0
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(95, 241)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(66, 48)
        Me.btn0.TabIndex = 12
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(223, 4)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(214, 21)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Empleado"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnlimpiar.FlatAppearance.BorderSize = 0
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Location = New System.Drawing.Point(18, 241)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(71, 48)
        Me.btnlimpiar.TabIndex = 10
        Me.btnlimpiar.Text = "C0"
        Me.btnlimpiar.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn3.FlatAppearance.BorderSize = 0
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(167, 187)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(65, 48)
        Me.btn3.TabIndex = 8
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(95, 187)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(66, 48)
        Me.btn2.TabIndex = 7
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(18, 186)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(71, 48)
        Me.btn1.TabIndex = 6
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn6.FlatAppearance.BorderSize = 0
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(167, 131)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(65, 48)
        Me.btn6.TabIndex = 5
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn5.FlatAppearance.BorderSize = 0
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(95, 131)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(66, 48)
        Me.btn5.TabIndex = 4
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn4.FlatAppearance.BorderSize = 0
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(18, 132)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(71, 48)
        Me.btn4.TabIndex = 3
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn9.FlatAppearance.BorderSize = 0
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(167, 73)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(65, 48)
        Me.btn9.TabIndex = 2
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn8.FlatAppearance.BorderSize = 0
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(95, 73)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(66, 48)
        Me.btn8.TabIndex = 1
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn7.FlatAppearance.BorderSize = 0
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(18, 73)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(71, 48)
        Me.btn7.TabIndex = 0
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'btnPrecuenta
        '
        Me.btnPrecuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrecuenta.FlatAppearance.BorderSize = 0
        Me.btnPrecuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrecuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrecuenta.Image = CType(resources.GetObject("btnPrecuenta.Image"), System.Drawing.Image)
        Me.btnPrecuenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrecuenta.Location = New System.Drawing.Point(335, 200)
        Me.btnPrecuenta.Name = "btnPrecuenta"
        Me.btnPrecuenta.Size = New System.Drawing.Size(80, 62)
        Me.btnPrecuenta.TabIndex = 38
        Me.btnPrecuenta.Text = "Precuenta"
        Me.btnPrecuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrecuenta.UseVisualStyleBackColor = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Comanda"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Código"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 60
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 88
        '
        'Column4
        '
        Me.Column4.HeaderText = "Unidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Cantidad"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 75
        '
        'Column6
        '
        Me.Column6.HeaderText = "Precio"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 75
        '
        'Column7
        '
        Me.Column7.HeaderText = "Total"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 75
        '
        'Column8
        '
        Me.Column8.HeaderText = "Id"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 50
        '
        'frmPagarPollos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(908, 612)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPagarPollos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagar Pollos"
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdComandas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblfolio As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSubtotalmapeo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdComandas As DataGridView
    Friend WithEvents btnIntro As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cboComanda As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnPagar As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents lblusuario2 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblmesa As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents btnPrecuenta As Button
End Class
