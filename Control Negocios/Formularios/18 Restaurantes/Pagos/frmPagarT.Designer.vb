<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPagarT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagarT))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPropina = New System.Windows.Forms.Button()
        Me.btnAmerican = New System.Windows.Forms.Button()
        Me.btnMaster = New System.Windows.Forms.Button()
        Me.btnVisa = New System.Windows.Forms.Button()
        Me.btnEfectivo = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdPagos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lbltotales = New System.Windows.Forms.Label()
        Me.lblpropina = New System.Windows.Forms.Label()
        Me.lblimporte = New System.Windows.Forms.Label()
        Me.lblResta = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.btnMonedero = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.lbltotalpropina = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnpagar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnpunto = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.txtMontos = New System.Windows.Forms.RichTextBox()
        Me.BTNacEPTAR = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnPropina)
        Me.Panel1.Controls.Add(Me.btnAmerican)
        Me.Panel1.Controls.Add(Me.btnMaster)
        Me.Panel1.Controls.Add(Me.btnVisa)
        Me.Panel1.Controls.Add(Me.btnEfectivo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(142, 426)
        Me.Panel1.TabIndex = 0
        '
        'btnPropina
        '
        Me.btnPropina.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPropina.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPropina.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPropina.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPropina.Location = New System.Drawing.Point(0, 314)
        Me.btnPropina.Name = "btnPropina"
        Me.btnPropina.Size = New System.Drawing.Size(142, 82)
        Me.btnPropina.TabIndex = 9
        Me.btnPropina.Text = "PROPINA"
        Me.btnPropina.UseVisualStyleBackColor = False
        '
        'btnAmerican
        '
        Me.btnAmerican.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAmerican.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnAmerican.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAmerican.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAmerican.Image = CType(resources.GetObject("btnAmerican.Image"), System.Drawing.Image)
        Me.btnAmerican.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAmerican.Location = New System.Drawing.Point(0, 236)
        Me.btnAmerican.Name = "btnAmerican"
        Me.btnAmerican.Size = New System.Drawing.Size(142, 78)
        Me.btnAmerican.TabIndex = 8
        Me.btnAmerican.Text = "AMERICAN EXPRESS"
        Me.btnAmerican.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAmerican.UseVisualStyleBackColor = False
        '
        'btnMaster
        '
        Me.btnMaster.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMaster.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMaster.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMaster.Image = CType(resources.GetObject("btnMaster.Image"), System.Drawing.Image)
        Me.btnMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMaster.Location = New System.Drawing.Point(0, 154)
        Me.btnMaster.Name = "btnMaster"
        Me.btnMaster.Size = New System.Drawing.Size(142, 82)
        Me.btnMaster.TabIndex = 7
        Me.btnMaster.Text = "MASTERCARD"
        Me.btnMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMaster.UseVisualStyleBackColor = False
        '
        'btnVisa
        '
        Me.btnVisa.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnVisa.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnVisa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVisa.Image = CType(resources.GetObject("btnVisa.Image"), System.Drawing.Image)
        Me.btnVisa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVisa.Location = New System.Drawing.Point(0, 79)
        Me.btnVisa.Name = "btnVisa"
        Me.btnVisa.Size = New System.Drawing.Size(142, 75)
        Me.btnVisa.TabIndex = 6
        Me.btnVisa.Text = "VISA"
        Me.btnVisa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVisa.UseVisualStyleBackColor = False
        '
        'btnEfectivo
        '
        Me.btnEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEfectivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEfectivo.Image = CType(resources.GetObject("btnEfectivo.Image"), System.Drawing.Image)
        Me.btnEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEfectivo.Location = New System.Drawing.Point(0, 0)
        Me.btnEfectivo.Name = "btnEfectivo"
        Me.btnEfectivo.Size = New System.Drawing.Size(142, 79)
        Me.btnEfectivo.TabIndex = 5
        Me.btnEfectivo.Text = "EFECTIVO"
        Me.btnEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEfectivo.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel2.Controls.Add(Me.grdPagos)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(142, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(570, 426)
        Me.Panel2.TabIndex = 1
        '
        'grdPagos
        '
        Me.grdPagos.AllowUserToAddRows = False
        Me.grdPagos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPagos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdPagos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdPagos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPagos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.grdPagos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPagos.GridColor = System.Drawing.Color.Black
        Me.grdPagos.Location = New System.Drawing.Point(0, 233)
        Me.grdPagos.Name = "grdPagos"
        Me.grdPagos.RowHeadersVisible = False
        Me.grdPagos.Size = New System.Drawing.Size(570, 153)
        Me.grdPagos.TabIndex = 15
        '
        'Column1
        '
        Me.Column1.HeaderText = "Descripción"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 195
        '
        'Column2
        '
        Me.Column2.HeaderText = "Importe"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 124
        '
        'Column3
        '
        Me.Column3.HeaderText = "Propina"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 124
        '
        'Column4
        '
        Me.Column4.HeaderText = "Total"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 124
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel6.Controls.Add(Me.lbltotales)
        Me.Panel6.Controls.Add(Me.lblpropina)
        Me.Panel6.Controls.Add(Me.lblimporte)
        Me.Panel6.Controls.Add(Me.lblResta)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 386)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(570, 40)
        Me.Panel6.TabIndex = 14
        '
        'lbltotales
        '
        Me.lbltotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.lbltotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotales.ForeColor = System.Drawing.Color.Black
        Me.lbltotales.Location = New System.Drawing.Point(454, 3)
        Me.lbltotales.Name = "lbltotales"
        Me.lbltotales.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbltotales.Size = New System.Drawing.Size(99, 29)
        Me.lbltotales.TabIndex = 17
        Me.lbltotales.Text = "0.00"
        Me.lbltotales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblpropina
        '
        Me.lblpropina.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblpropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpropina.ForeColor = System.Drawing.Color.Black
        Me.lblpropina.Location = New System.Drawing.Point(328, 3)
        Me.lblpropina.Name = "lblpropina"
        Me.lblpropina.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblpropina.Size = New System.Drawing.Size(104, 29)
        Me.lblpropina.TabIndex = 15
        Me.lblpropina.Text = "0.00"
        Me.lblpropina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblimporte
        '
        Me.lblimporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblimporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblimporte.ForeColor = System.Drawing.Color.Black
        Me.lblimporte.Location = New System.Drawing.Point(213, 3)
        Me.lblimporte.Name = "lblimporte"
        Me.lblimporte.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblimporte.Size = New System.Drawing.Size(93, 29)
        Me.lblimporte.TabIndex = 13
        Me.lblimporte.Text = "0.00"
        Me.lblimporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblResta
        '
        Me.lblResta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblResta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResta.ForeColor = System.Drawing.Color.Black
        Me.lblResta.Location = New System.Drawing.Point(87, 3)
        Me.lblResta.Name = "lblResta"
        Me.lblResta.Size = New System.Drawing.Size(104, 29)
        Me.lblResta.TabIndex = 11
        Me.lblResta.Text = "0.00"
        Me.lblResta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 29)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "RESTA:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtCliente)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txtNumero)
        Me.Panel3.Controls.Add(Me.btnMonedero)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 164)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(570, 69)
        Me.Panel3.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(312, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(252, 29)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Cliente"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(315, 41)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(248, 22)
        Me.txtCliente.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(117, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(189, 29)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "N° Monedero"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumero
        '
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(117, 41)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(189, 22)
        Me.txtNumero.TabIndex = 6
        '
        'btnMonedero
        '
        Me.btnMonedero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnMonedero.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMonedero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMonedero.Image = CType(resources.GetObject("btnMonedero.Image"), System.Drawing.Image)
        Me.btnMonedero.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMonedero.Location = New System.Drawing.Point(5, 3)
        Me.btnMonedero.Name = "btnMonedero"
        Me.btnMonedero.Size = New System.Drawing.Size(106, 61)
        Me.btnMonedero.TabIndex = 5
        Me.btnMonedero.Text = "MONEDERO"
        Me.btnMonedero.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMonedero.UseVisualStyleBackColor = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.lblTotal)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lblCambio)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 82)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(570, 82)
        Me.Panel5.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(296, 29)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(3, 32)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(296, 41)
        Me.lblTotal.TabIndex = 6
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(315, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(194, 29)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Cambio"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCambio
        '
        Me.lblCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.Red
        Me.lblCambio.Location = New System.Drawing.Point(315, 32)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(249, 41)
        Me.lblCambio.TabIndex = 8
        Me.lblCambio.Text = "0.00"
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.lblSubtotal)
        Me.Panel4.Controls.Add(Me.lbltotalpropina)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.btnpagar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(570, 82)
        Me.Panel4.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CONSUMO:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.Location = New System.Drawing.Point(457, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(106, 75)
        Me.Button5.TabIndex = 11
        Me.Button5.Text = "CANCELAR"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.UseVisualStyleBackColor = False
        '
        'lblSubtotal
        '
        Me.lblSubtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.ForeColor = System.Drawing.Color.Black
        Me.lblSubtotal.Location = New System.Drawing.Point(163, 4)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(165, 29)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "0.00"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltotalpropina
        '
        Me.lbltotalpropina.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbltotalpropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpropina.Location = New System.Drawing.Point(160, 42)
        Me.lbltotalpropina.Name = "lbltotalpropina"
        Me.lbltotalpropina.Size = New System.Drawing.Size(168, 29)
        Me.lbltotalpropina.TabIndex = 2
        Me.lbltotalpropina.Text = "0.00"
        Me.lbltotalpropina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 29)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "PROP. INCLUIDA:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnpagar
        '
        Me.btnpagar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnpagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnpagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpagar.Image = CType(resources.GetObject("btnpagar.Image"), System.Drawing.Image)
        Me.btnpagar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnpagar.Location = New System.Drawing.Point(345, 4)
        Me.btnpagar.Name = "btnpagar"
        Me.btnpagar.Size = New System.Drawing.Size(106, 75)
        Me.btnpagar.TabIndex = 4
        Me.btnpagar.Text = "PAGAR"
        Me.btnpagar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnpagar.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel7.Controls.Add(Me.btnQuitar)
        Me.Panel7.Controls.Add(Me.BTNacEPTAR)
        Me.Panel7.Controls.Add(Me.btnBorrar)
        Me.Panel7.Controls.Add(Me.btn0)
        Me.Panel7.Controls.Add(Me.btnpunto)
        Me.Panel7.Controls.Add(Me.btn3)
        Me.Panel7.Controls.Add(Me.btn2)
        Me.Panel7.Controls.Add(Me.btn1)
        Me.Panel7.Controls.Add(Me.btn6)
        Me.Panel7.Controls.Add(Me.btn5)
        Me.Panel7.Controls.Add(Me.btn4)
        Me.Panel7.Controls.Add(Me.btn9)
        Me.Panel7.Controls.Add(Me.btn8)
        Me.Panel7.Controls.Add(Me.btn7)
        Me.Panel7.Controls.Add(Me.txtMontos)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(712, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(286, 426)
        Me.Panel7.TabIndex = 2
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnBorrar.FlatAppearance.BorderSize = 0
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Location = New System.Drawing.Point(192, 294)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(88, 69)
        Me.btnBorrar.TabIndex = 78
        Me.btnBorrar.Text = "C0"
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn0.FlatAppearance.BorderSize = 0
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(98, 294)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(88, 69)
        Me.btn0.TabIndex = 77
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnpunto
        '
        Me.btnpunto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnpunto.FlatAppearance.BorderSize = 0
        Me.btnpunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnpunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpunto.Location = New System.Drawing.Point(4, 294)
        Me.btnpunto.Name = "btnpunto"
        Me.btnpunto.Size = New System.Drawing.Size(88, 69)
        Me.btnpunto.TabIndex = 76
        Me.btnpunto.Text = "."
        Me.btnpunto.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn3.FlatAppearance.BorderSize = 0
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(192, 219)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(88, 69)
        Me.btn3.TabIndex = 75
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(98, 219)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(88, 69)
        Me.btn2.TabIndex = 74
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(4, 219)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(88, 69)
        Me.btn1.TabIndex = 73
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn6.FlatAppearance.BorderSize = 0
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(192, 144)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(88, 69)
        Me.btn6.TabIndex = 72
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn5.FlatAppearance.BorderSize = 0
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(98, 144)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(88, 69)
        Me.btn5.TabIndex = 71
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn4.FlatAppearance.BorderSize = 0
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(4, 144)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(88, 69)
        Me.btn4.TabIndex = 70
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn9.FlatAppearance.BorderSize = 0
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(192, 69)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(88, 69)
        Me.btn9.TabIndex = 69
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn8.FlatAppearance.BorderSize = 0
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(98, 69)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(88, 69)
        Me.btn8.TabIndex = 68
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn7.FlatAppearance.BorderSize = 0
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(4, 69)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(88, 69)
        Me.btn7.TabIndex = 67
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'txtMontos
        '
        Me.txtMontos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtMontos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontos.Location = New System.Drawing.Point(3, 12)
        Me.txtMontos.Name = "txtMontos"
        Me.txtMontos.Size = New System.Drawing.Size(183, 51)
        Me.txtMontos.TabIndex = 0
        Me.txtMontos.Text = ""
        '
        'BTNacEPTAR
        '
        Me.BTNacEPTAR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BTNacEPTAR.FlatAppearance.BorderSize = 0
        Me.BTNacEPTAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNacEPTAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNacEPTAR.Location = New System.Drawing.Point(3, 369)
        Me.BTNacEPTAR.Name = "BTNacEPTAR"
        Me.BTNacEPTAR.Size = New System.Drawing.Size(277, 51)
        Me.BTNacEPTAR.TabIndex = 79
        Me.BTNacEPTAR.Text = "ENTER"
        Me.BTNacEPTAR.UseVisualStyleBackColor = False
        '
        'btnQuitar
        '
        Me.btnQuitar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnQuitar.FlatAppearance.BorderSize = 0
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Image)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnQuitar.Location = New System.Drawing.Point(192, 12)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(88, 51)
        Me.btnQuitar.TabIndex = 80
        Me.btnQuitar.Text = "Borrar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnQuitar.UseVisualStyleBackColor = False
        '
        'frmPagarT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(998, 426)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPagarT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagar Venta Touch"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltotalpropina As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents btnpagar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCambio As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnEfectivo As Button
    Friend WithEvents btnAmerican As Button
    Friend WithEvents btnMaster As Button
    Friend WithEvents btnVisa As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents btnMonedero As Button
    Friend WithEvents grdPagos As DataGridView
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents lblResta As Label
    Friend WithEvents lbltotales As Label
    Friend WithEvents lblpropina As Label
    Friend WithEvents lblimporte As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtMontos As RichTextBox
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnpunto As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btnPropina As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents BTNacEPTAR As Button
    Friend WithEvents btnQuitar As Button
End Class
