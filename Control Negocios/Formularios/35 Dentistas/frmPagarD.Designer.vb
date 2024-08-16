<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagarD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagarD))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalP = New System.Windows.Forms.Label()
        Me.lblLetras = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblTarjeta = New System.Windows.Forms.Label()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.lblTransferencia = New System.Windows.Forms.Label()
        Me.txtTransferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblOtros = New System.Windows.Forms.Label()
        Me.txtOtros = New System.Windows.Forms.TextBox()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblCreditoCli = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pCredito = New System.Windows.Forms.Panel()
        Me.lblSaldoFavor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAdeudo = New System.Windows.Forms.Label()
        Me.lblcredito = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pCredito.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(484, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total a Pagar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalP
        '
        Me.lblTotalP.BackColor = System.Drawing.Color.White
        Me.lblTotalP.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTotalP.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblTotalP.Location = New System.Drawing.Point(0, 27)
        Me.lblTotalP.Name = "lblTotalP"
        Me.lblTotalP.Size = New System.Drawing.Size(484, 57)
        Me.lblTotalP.TabIndex = 1
        Me.lblTotalP.Text = "150.00"
        Me.lblTotalP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLetras
        '
        Me.lblLetras.BackColor = System.Drawing.Color.White
        Me.lblLetras.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLetras.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLetras.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.lblLetras.Location = New System.Drawing.Point(0, 84)
        Me.lblLetras.Name = "lblLetras"
        Me.lblLetras.Size = New System.Drawing.Size(484, 35)
        Me.lblLetras.TabIndex = 2
        Me.lblLetras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEfectivo
        '
        Me.lblEfectivo.BackColor = System.Drawing.Color.White
        Me.lblEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivo.Image = CType(resources.GetObject("lblEfectivo.Image"), System.Drawing.Image)
        Me.lblEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblEfectivo.Location = New System.Drawing.Point(10, 3)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(112, 73)
        Me.lblEfectivo.TabIndex = 3
        Me.lblEfectivo.Text = "Efectivo"
        Me.lblEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblTarjeta
        '
        Me.lblTarjeta.BackColor = System.Drawing.Color.White
        Me.lblTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTarjeta.Image = CType(resources.GetObject("lblTarjeta.Image"), System.Drawing.Image)
        Me.lblTarjeta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTarjeta.Location = New System.Drawing.Point(128, 3)
        Me.lblTarjeta.Name = "lblTarjeta"
        Me.lblTarjeta.Size = New System.Drawing.Size(112, 73)
        Me.lblTarjeta.TabIndex = 4
        Me.lblTarjeta.Text = "Tarjeta"
        Me.lblTarjeta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.Location = New System.Drawing.Point(10, 79)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(112, 22)
        Me.txtEfectivo.TabIndex = 5
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.Location = New System.Drawing.Point(128, 79)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(112, 22)
        Me.txtTarjeta.TabIndex = 6
        Me.txtTarjeta.Text = "0.00"
        Me.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTransferencia
        '
        Me.lblTransferencia.BackColor = System.Drawing.Color.White
        Me.lblTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferencia.Image = CType(resources.GetObject("lblTransferencia.Image"), System.Drawing.Image)
        Me.lblTransferencia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblTransferencia.Location = New System.Drawing.Point(246, 3)
        Me.lblTransferencia.Name = "lblTransferencia"
        Me.lblTransferencia.Size = New System.Drawing.Size(112, 73)
        Me.lblTransferencia.TabIndex = 7
        Me.lblTransferencia.Text = "Transferencia"
        Me.lblTransferencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtTransferencia
        '
        Me.txtTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransferencia.Location = New System.Drawing.Point(246, 79)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(112, 22)
        Me.txtTransferencia.TabIndex = 8
        Me.txtTransferencia.Text = "0.00"
        Me.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 24)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Referencia:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReferencia
        '
        Me.txtReferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencia.Location = New System.Drawing.Point(113, 114)
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(363, 24)
        Me.txtReferencia.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(463, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "____________________________________________________________________________"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 138)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(463, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "____________________________________________________________________________"
        '
        'lblOtros
        '
        Me.lblOtros.BackColor = System.Drawing.Color.White
        Me.lblOtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOtros.Image = CType(resources.GetObject("lblOtros.Image"), System.Drawing.Image)
        Me.lblOtros.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblOtros.Location = New System.Drawing.Point(364, 3)
        Me.lblOtros.Name = "lblOtros"
        Me.lblOtros.Size = New System.Drawing.Size(112, 73)
        Me.lblOtros.TabIndex = 13
        Me.lblOtros.Text = "Otros"
        Me.lblOtros.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtOtros
        '
        Me.txtOtros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtros.Location = New System.Drawing.Point(364, 79)
        Me.txtOtros.Name = "txtOtros"
        Me.txtOtros.Size = New System.Drawing.Size(112, 22)
        Me.txtOtros.TabIndex = 14
        Me.txtOtros.Text = "0.00"
        Me.txtOtros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbltitulo
        '
        Me.lbltitulo.BackColor = System.Drawing.Color.White
        Me.lbltitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.lbltitulo.Location = New System.Drawing.Point(367, 3)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(109, 23)
        Me.lbltitulo.TabIndex = 15
        Me.lbltitulo.Text = "Cambio"
        Me.lbltitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCambio
        '
        Me.lblCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.lblCambio.Location = New System.Drawing.Point(292, 26)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(184, 57)
        Me.lblCambio.TabIndex = 16
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(3, 3)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(277, 23)
        Me.lblCliente.TabIndex = 17
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(469, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "_____________________________________________________________________________"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(195, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(137, 46)
        Me.btnAceptar.TabIndex = 19
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(339, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 46)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 456)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(484, 69)
        Me.Panel1.TabIndex = 21
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblLetras)
        Me.Panel2.Controls.Add(Me.lblTotalP)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(484, 137)
        Me.Panel2.TabIndex = 22
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblEfectivo)
        Me.Panel3.Controls.Add(Me.lblTarjeta)
        Me.Panel3.Controls.Add(Me.txtEfectivo)
        Me.Panel3.Controls.Add(Me.txtTarjeta)
        Me.Panel3.Controls.Add(Me.lblTransferencia)
        Me.Panel3.Controls.Add(Me.txtTransferencia)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtOtros)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.lblOtros)
        Me.Panel3.Controls.Add(Me.txtReferencia)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 137)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(484, 158)
        Me.Panel3.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblCreditoCli)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.lblCliente)
        Me.Panel4.Controls.Add(Me.lblCambio)
        Me.Panel4.Controls.Add(Me.lbltitulo)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 295)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(484, 95)
        Me.Panel4.TabIndex = 24
        '
        'lblCreditoCli
        '
        Me.lblCreditoCli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreditoCli.ForeColor = System.Drawing.Color.Red
        Me.lblCreditoCli.Location = New System.Drawing.Point(128, 26)
        Me.lblCreditoCli.Name = "lblCreditoCli"
        Me.lblCreditoCli.Size = New System.Drawing.Size(119, 24)
        Me.lblCreditoCli.TabIndex = 24
        Me.lblCreditoCli.Text = "0.00"
        Me.lblCreditoCli.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(3, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 24)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Total a crédito:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(4, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 35)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Credito"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pCredito
        '
        Me.pCredito.Controls.Add(Me.lblSaldoFavor)
        Me.pCredito.Controls.Add(Me.Label9)
        Me.pCredito.Controls.Add(Me.lblAdeudo)
        Me.pCredito.Controls.Add(Me.lblcredito)
        Me.pCredito.Controls.Add(Me.Label3)
        Me.pCredito.Controls.Add(Me.Label2)
        Me.pCredito.Controls.Add(Me.Button3)
        Me.pCredito.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pCredito.Location = New System.Drawing.Point(0, 394)
        Me.pCredito.Name = "pCredito"
        Me.pCredito.Size = New System.Drawing.Size(484, 62)
        Me.pCredito.TabIndex = 25
        Me.pCredito.Visible = False
        '
        'lblSaldoFavor
        '
        Me.lblSaldoFavor.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblSaldoFavor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFavor.ForeColor = System.Drawing.Color.Black
        Me.lblSaldoFavor.Location = New System.Drawing.Point(236, 32)
        Me.lblSaldoFavor.Name = "lblSaldoFavor"
        Me.lblSaldoFavor.Size = New System.Drawing.Size(125, 23)
        Me.lblSaldoFavor.TabIndex = 27
        Me.lblSaldoFavor.Text = "0.00"
        Me.lblSaldoFavor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(236, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 24)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Saldo a favor"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAdeudo
        '
        Me.lblAdeudo.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblAdeudo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdeudo.ForeColor = System.Drawing.Color.Black
        Me.lblAdeudo.Location = New System.Drawing.Point(128, 32)
        Me.lblAdeudo.Name = "lblAdeudo"
        Me.lblAdeudo.Size = New System.Drawing.Size(102, 23)
        Me.lblAdeudo.TabIndex = 25
        Me.lblAdeudo.Text = "0.00"
        Me.lblAdeudo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcredito
        '
        Me.lblcredito.BackColor = System.Drawing.Color.PaleTurquoise
        Me.lblcredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcredito.ForeColor = System.Drawing.Color.Black
        Me.lblcredito.Location = New System.Drawing.Point(6, 32)
        Me.lblcredito.Name = "lblcredito"
        Me.lblcredito.Size = New System.Drawing.Size(116, 23)
        Me.lblcredito.TabIndex = 24
        Me.lblcredito.Text = "0.00"
        Me.lblcredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(128, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 24)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Adeudo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 24)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Crédito máximo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(433, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(43, 46)
        Me.Button3.TabIndex = 21
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frmPagarD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(484, 525)
        Me.Controls.Add(Me.pCredito)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPagarD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagar"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.pCredito.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalP As Label
    Friend WithEvents lblLetras As Label
    Friend WithEvents lblEfectivo As Label
    Friend WithEvents lblTarjeta As Label
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents txtTarjeta As TextBox
    Friend WithEvents lblTransferencia As Label
    Friend WithEvents txtTransferencia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblOtros As Label
    Friend WithEvents txtOtros As TextBox
    Friend WithEvents lbltitulo As Label
    Friend WithEvents lblCambio As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents pCredito As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblAdeudo As Label
    Friend WithEvents lblcredito As Label
    Friend WithEvents lblSaldoFavor As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCreditoCli As Label
End Class
