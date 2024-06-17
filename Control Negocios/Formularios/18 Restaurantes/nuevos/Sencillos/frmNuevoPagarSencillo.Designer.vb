<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoPagarSencillo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoPagarSencillo))
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.BTNsALIR = New System.Windows.Forms.Button()
        Me.btnIntro = New System.Windows.Forms.Button()
        Me.btnPrecuenta = New System.Windows.Forms.Button()
        Me.btnDividir = New System.Windows.Forms.Button()
        Me.btnCortesia = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btnPunto = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblusuario2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblmesa = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblMesero = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblfolio = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboComanda = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboComensal = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtMontoMonedero = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.picQR = New System.Windows.Forms.PictureBox()
        Me.btn20 = New System.Windows.Forms.Button()
        Me.btn1000 = New System.Windows.Forms.Button()
        Me.btn50 = New System.Windows.Forms.Button()
        Me.btn500 = New System.Windows.Forms.Button()
        Me.btn200 = New System.Windows.Forms.Button()
        Me.btn100 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTransferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTarjeta = New System.Windows.Forms.TextBox()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txttotalpropina = New System.Windows.Forms.TextBox()
        Me.txtMonedero = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSubtotalmapeo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPropina = New System.Windows.Forms.TextBox()
        Me.txtResta = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdComanda = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TFolio = New System.Windows.Forms.Timer(Me.components)
        Me.pVentaMapeo80 = New System.Drawing.Printing.PrintDocument()
        Me.pVentaMapeo58 = New System.Drawing.Printing.PrintDocument()
        Me.Precuenta80 = New System.Drawing.Printing.PrintDocument()
        Me.Precuenta58 = New System.Drawing.Printing.PrintDocument()
        Me.Cancelacion80 = New System.Drawing.Printing.PrintDocument()
        Me.Cancelacion58 = New System.Drawing.Printing.PrintDocument()
        Me.pCortesia80 = New System.Drawing.Printing.PrintDocument()
        Me.pCortesia58 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdComanda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btn0)
        Me.Panel1.Controls.Add(Me.btnPunto)
        Me.Panel1.Controls.Add(Me.btn3)
        Me.Panel1.Controls.Add(Me.btn2)
        Me.Panel1.Controls.Add(Me.btn1)
        Me.Panel1.Controls.Add(Me.btn6)
        Me.Panel1.Controls.Add(Me.btn5)
        Me.Panel1.Controls.Add(Me.btn4)
        Me.Panel1.Controls.Add(Me.btn9)
        Me.Panel1.Controls.Add(Me.btn8)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btn7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(784, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 649)
        Me.Panel1.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.BTNsALIR)
        Me.Panel6.Controls.Add(Me.btnIntro)
        Me.Panel6.Controls.Add(Me.btnPrecuenta)
        Me.Panel6.Controls.Add(Me.btnDividir)
        Me.Panel6.Controls.Add(Me.btnCortesia)
        Me.Panel6.Controls.Add(Me.btnCancelar)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 427)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(302, 222)
        Me.Panel6.TabIndex = 4
        '
        'BTNsALIR
        '
        Me.BTNsALIR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BTNsALIR.FlatAppearance.BorderSize = 0
        Me.BTNsALIR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BTNsALIR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNsALIR.Image = CType(resources.GetObject("BTNsALIR.Image"), System.Drawing.Image)
        Me.BTNsALIR.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNsALIR.Location = New System.Drawing.Point(205, 3)
        Me.BTNsALIR.Name = "BTNsALIR"
        Me.BTNsALIR.Size = New System.Drawing.Size(92, 71)
        Me.BTNsALIR.TabIndex = 80
        Me.BTNsALIR.Text = "SALIR"
        Me.BTNsALIR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNsALIR.UseVisualStyleBackColor = False
        '
        'btnIntro
        '
        Me.btnIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnIntro.FlatAppearance.BorderSize = 0
        Me.btnIntro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnIntro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIntro.Image = CType(resources.GetObject("btnIntro.Image"), System.Drawing.Image)
        Me.btnIntro.Location = New System.Drawing.Point(104, 3)
        Me.btnIntro.Name = "btnIntro"
        Me.btnIntro.Size = New System.Drawing.Size(95, 74)
        Me.btnIntro.TabIndex = 77
        Me.btnIntro.Text = "PAGAR"
        Me.btnIntro.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIntro.UseVisualStyleBackColor = False
        '
        'btnPrecuenta
        '
        Me.btnPrecuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPrecuenta.FlatAppearance.BorderSize = 0
        Me.btnPrecuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrecuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrecuenta.Image = CType(resources.GetObject("btnPrecuenta.Image"), System.Drawing.Image)
        Me.btnPrecuenta.Location = New System.Drawing.Point(5, 3)
        Me.btnPrecuenta.Name = "btnPrecuenta"
        Me.btnPrecuenta.Size = New System.Drawing.Size(94, 74)
        Me.btnPrecuenta.TabIndex = 75
        Me.btnPrecuenta.Text = "PRECUENTA"
        Me.btnPrecuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrecuenta.UseVisualStyleBackColor = False
        '
        'btnDividir
        '
        Me.btnDividir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDividir.FlatAppearance.BorderSize = 0
        Me.btnDividir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDividir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDividir.Image = CType(resources.GetObject("btnDividir.Image"), System.Drawing.Image)
        Me.btnDividir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDividir.Location = New System.Drawing.Point(6, 80)
        Me.btnDividir.Name = "btnDividir"
        Me.btnDividir.Size = New System.Drawing.Size(93, 74)
        Me.btnDividir.TabIndex = 78
        Me.btnDividir.Text = "DIVIDIR CUENTA"
        Me.btnDividir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDividir.UseVisualStyleBackColor = False
        '
        'btnCortesia
        '
        Me.btnCortesia.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCortesia.FlatAppearance.BorderSize = 0
        Me.btnCortesia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCortesia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCortesia.Image = CType(resources.GetObject("btnCortesia.Image"), System.Drawing.Image)
        Me.btnCortesia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCortesia.Location = New System.Drawing.Point(104, 80)
        Me.btnCortesia.Name = "btnCortesia"
        Me.btnCortesia.Size = New System.Drawing.Size(95, 74)
        Me.btnCortesia.TabIndex = 79
        Me.btnCortesia.Text = "CORTESIA"
        Me.btnCortesia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCortesia.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderSize = 0
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(6, 158)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(193, 59)
        Me.btnCancelar.TabIndex = 76
        Me.btnCancelar.Text = "CANCELAR COMANDA"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLimpiar.FlatAppearance.BorderSize = 0
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Location = New System.Drawing.Point(205, 349)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(94, 72)
        Me.btnLimpiar.TabIndex = 79
        Me.btnLimpiar.Text = "C0"
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn0.FlatAppearance.BorderSize = 0
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(105, 349)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(94, 72)
        Me.btn0.TabIndex = 78
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btnPunto
        '
        Me.btnPunto.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPunto.FlatAppearance.BorderSize = 0
        Me.btnPunto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPunto.Location = New System.Drawing.Point(5, 349)
        Me.btnPunto.Name = "btnPunto"
        Me.btnPunto.Size = New System.Drawing.Size(94, 72)
        Me.btnPunto.TabIndex = 77
        Me.btnPunto.Text = "."
        Me.btnPunto.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPunto.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn3.FlatAppearance.BorderSize = 0
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(205, 271)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(94, 72)
        Me.btn3.TabIndex = 76
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn2.FlatAppearance.BorderSize = 0
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(105, 271)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(94, 72)
        Me.btn2.TabIndex = 75
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn1.FlatAppearance.BorderSize = 0
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(5, 271)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(94, 72)
        Me.btn1.TabIndex = 74
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn6.FlatAppearance.BorderSize = 0
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(205, 193)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(94, 72)
        Me.btn6.TabIndex = 73
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn5.FlatAppearance.BorderSize = 0
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(105, 193)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(94, 72)
        Me.btn5.TabIndex = 72
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn4.FlatAppearance.BorderSize = 0
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(5, 193)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(94, 72)
        Me.btn4.TabIndex = 71
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn9.FlatAppearance.BorderSize = 0
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(205, 115)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(94, 72)
        Me.btn9.TabIndex = 70
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn8.FlatAppearance.BorderSize = 0
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(105, 115)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(94, 72)
        Me.btn8.TabIndex = 69
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Controls.Add(Me.lblusuario2)
        Me.Panel3.Controls.Add(Me.Label20)
        Me.Panel3.Controls.Add(Me.lblmesa)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(302, 109)
        Me.Panel3.TabIndex = 68
        '
        'lblusuario2
        '
        Me.lblusuario2.BackColor = System.Drawing.Color.Gainsboro
        Me.lblusuario2.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblusuario2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario2.Location = New System.Drawing.Point(0, 78)
        Me.lblusuario2.Name = "lblusuario2"
        Me.lblusuario2.Size = New System.Drawing.Size(302, 31)
        Me.lblusuario2.TabIndex = 28
        Me.lblusuario2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(0, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(302, 21)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Usuario"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblmesa
        '
        Me.lblmesa.BackColor = System.Drawing.Color.Gainsboro
        Me.lblmesa.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblmesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmesa.Location = New System.Drawing.Point(0, 30)
        Me.lblmesa.Name = "lblmesa"
        Me.lblmesa.Size = New System.Drawing.Size(302, 27)
        Me.lblmesa.TabIndex = 26
        Me.lblmesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(302, 30)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Mesa"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn7.FlatAppearance.BorderSize = 0
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(5, 115)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(94, 72)
        Me.btn7.TabIndex = 67
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblTotal)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(784, 78)
        Me.Panel2.TabIndex = 1
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(482, 5)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(282, 63)
        Me.lblTotal.TabIndex = 37
        Me.lblTotal.Text = "ADMIN"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(203, 5)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(273, 63)
        Me.Label26.TabIndex = 38
        Me.Label26.Text = "TOTAL A PAGAR"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(186, 78)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblMesero)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Controls.Add(Me.lblfolio)
        Me.Panel4.Controls.Add(Me.Label22)
        Me.Panel4.Controls.Add(Me.cboComanda)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.cboComensal)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 78)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(784, 41)
        Me.Panel4.TabIndex = 2
        '
        'lblMesero
        '
        Me.lblMesero.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblMesero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesero.Location = New System.Drawing.Point(666, 11)
        Me.lblMesero.Name = "lblMesero"
        Me.lblMesero.Size = New System.Drawing.Size(110, 21)
        Me.lblMesero.TabIndex = 43
        Me.lblMesero.Text = "ADMIN"
        Me.lblMesero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(576, 11)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 21)
        Me.Label23.TabIndex = 42
        Me.Label23.Text = "Mesero"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblfolio
        '
        Me.lblfolio.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblfolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfolio.Location = New System.Drawing.Point(473, 11)
        Me.lblfolio.Name = "lblfolio"
        Me.lblfolio.Size = New System.Drawing.Size(97, 21)
        Me.lblfolio.TabIndex = 41
        Me.lblfolio.Text = "100000"
        Me.lblfolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(365, 11)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 21)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Folio Venta"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboComanda
        '
        Me.cboComanda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.cboComanda.FormattingEnabled = True
        Me.cboComanda.Location = New System.Drawing.Point(85, 10)
        Me.cboComanda.Name = "cboComanda"
        Me.cboComanda.Size = New System.Drawing.Size(86, 21)
        Me.cboComanda.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(3, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 21)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Comanda:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboComensal
        '
        Me.cboComensal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.cboComensal.FormattingEnabled = True
        Me.cboComensal.Location = New System.Drawing.Point(251, 11)
        Me.cboComensal.Name = "cboComensal"
        Me.cboComensal.Size = New System.Drawing.Size(108, 21)
        Me.cboComensal.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(172, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 21)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Comensal:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtMontoMonedero)
        Me.Panel5.Controls.Add(Me.Label25)
        Me.Panel5.Controls.Add(Me.picQR)
        Me.Panel5.Controls.Add(Me.btn20)
        Me.Panel5.Controls.Add(Me.btn1000)
        Me.Panel5.Controls.Add(Me.btn50)
        Me.Panel5.Controls.Add(Me.btn500)
        Me.Panel5.Controls.Add(Me.btn200)
        Me.Panel5.Controls.Add(Me.btn100)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Controls.Add(Me.txtTransferencia)
        Me.Panel5.Controls.Add(Me.Label4)
        Me.Panel5.Controls.Add(Me.txtTarjeta)
        Me.Panel5.Controls.Add(Me.txtDescuento)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.txttotalpropina)
        Me.Panel5.Controls.Add(Me.txtMonedero)
        Me.Panel5.Controls.Add(Me.Label24)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.txtSubtotalmapeo)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.txtPropina)
        Me.Panel5.Controls.Add(Me.txtResta)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Controls.Add(Me.txtCambio)
        Me.Panel5.Controls.Add(Me.txtTotal)
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Controls.Add(Me.txtPorcentaje)
        Me.Panel5.Controls.Add(Me.txtEfectivo)
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 424)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(784, 225)
        Me.Panel5.TabIndex = 3
        '
        'txtMontoMonedero
        '
        Me.txtMontoMonedero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoMonedero.Location = New System.Drawing.Point(384, 83)
        Me.txtMontoMonedero.Name = "txtMontoMonedero"
        Me.txtMontoMonedero.Size = New System.Drawing.Size(125, 24)
        Me.txtMontoMonedero.TabIndex = 213
        Me.txtMontoMonedero.Text = "0.00"
        Me.txtMontoMonedero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMontoMonedero.Visible = False
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(262, 121)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(244, 30)
        Me.Label25.TabIndex = 212
        Me.Label25.Text = "Ingresa número telefonico del cliente para el monedero"
        '
        'picQR
        '
        Me.picQR.BackColor = System.Drawing.Color.White
        Me.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picQR.Location = New System.Drawing.Point(422, 161)
        Me.picQR.Margin = New System.Windows.Forms.Padding(10)
        Me.picQR.Name = "picQR"
        Me.picQR.Padding = New System.Windows.Forms.Padding(5, 5, 0, 0)
        Me.picQR.Size = New System.Drawing.Size(87, 56)
        Me.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picQR.TabIndex = 211
        Me.picQR.TabStop = False
        Me.picQR.Visible = False
        '
        'btn20
        '
        Me.btn20.BackgroundImage = CType(resources.GetObject("btn20.BackgroundImage"), System.Drawing.Image)
        Me.btn20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn20.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn20.Location = New System.Drawing.Point(515, 4)
        Me.btn20.Name = "btn20"
        Me.btn20.Size = New System.Drawing.Size(131, 67)
        Me.btn20.TabIndex = 80
        Me.btn20.UseVisualStyleBackColor = True
        '
        'btn1000
        '
        Me.btn1000.BackgroundImage = CType(resources.GetObject("btn1000.BackgroundImage"), System.Drawing.Image)
        Me.btn1000.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1000.Location = New System.Drawing.Point(652, 150)
        Me.btn1000.Name = "btn1000"
        Me.btn1000.Size = New System.Drawing.Size(129, 67)
        Me.btn1000.TabIndex = 85
        Me.btn1000.UseVisualStyleBackColor = True
        '
        'btn50
        '
        Me.btn50.BackgroundImage = CType(resources.GetObject("btn50.BackgroundImage"), System.Drawing.Image)
        Me.btn50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn50.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn50.Location = New System.Drawing.Point(652, 4)
        Me.btn50.Name = "btn50"
        Me.btn50.Size = New System.Drawing.Size(129, 67)
        Me.btn50.TabIndex = 81
        Me.btn50.UseVisualStyleBackColor = True
        '
        'btn500
        '
        Me.btn500.BackgroundImage = CType(resources.GetObject("btn500.BackgroundImage"), System.Drawing.Image)
        Me.btn500.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn500.Location = New System.Drawing.Point(515, 150)
        Me.btn500.Name = "btn500"
        Me.btn500.Size = New System.Drawing.Size(131, 67)
        Me.btn500.TabIndex = 84
        Me.btn500.UseVisualStyleBackColor = True
        '
        'btn200
        '
        Me.btn200.BackgroundImage = CType(resources.GetObject("btn200.BackgroundImage"), System.Drawing.Image)
        Me.btn200.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn200.Location = New System.Drawing.Point(652, 77)
        Me.btn200.Name = "btn200"
        Me.btn200.Size = New System.Drawing.Size(129, 67)
        Me.btn200.TabIndex = 83
        Me.btn200.UseVisualStyleBackColor = True
        '
        'btn100
        '
        Me.btn100.BackgroundImage = CType(resources.GetObject("btn100.BackgroundImage"), System.Drawing.Image)
        Me.btn100.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn100.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn100.Location = New System.Drawing.Point(515, 77)
        Me.btn100.Name = "btn100"
        Me.btn100.Size = New System.Drawing.Size(131, 67)
        Me.btn100.TabIndex = 82
        Me.btn100.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(2, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 21)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "Transferencia"
        '
        'txtTransferencia
        '
        Me.txtTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransferencia.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtTransferencia.Location = New System.Drawing.Point(125, 199)
        Me.txtTransferencia.Name = "txtTransferencia"
        Me.txtTransferencia.Size = New System.Drawing.Size(124, 21)
        Me.txtTransferencia.TabIndex = 74
        Me.txtTransferencia.Text = "0.00"
        Me.txtTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 21)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Tarjeta"
        '
        'txtTarjeta
        '
        Me.txtTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTarjeta.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtTarjeta.Location = New System.Drawing.Point(125, 171)
        Me.txtTarjeta.Name = "txtTarjeta"
        Me.txtTarjeta.Size = New System.Drawing.Size(124, 21)
        Me.txtTarjeta.TabIndex = 72
        Me.txtTarjeta.Text = "0.00"
        Me.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Orange
        Me.txtDescuento.Location = New System.Drawing.Point(203, 31)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(47, 21)
        Me.txtDescuento.TabIndex = 69
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(178, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(23, 20)
        Me.Label21.TabIndex = 70
        Me.Label21.Text = "%"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(2, 115)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(117, 21)
        Me.Label27.TabIndex = 67
        Me.Label27.Text = "Total a pagar:"
        '
        'txttotalpropina
        '
        Me.txttotalpropina.BackColor = System.Drawing.Color.White
        Me.txttotalpropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalpropina.Location = New System.Drawing.Point(125, 115)
        Me.txttotalpropina.Name = "txttotalpropina"
        Me.txttotalpropina.ReadOnly = True
        Me.txttotalpropina.Size = New System.Drawing.Size(124, 21)
        Me.txttotalpropina.TabIndex = 68
        Me.txttotalpropina.Text = "0.00"
        Me.txttotalpropina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonedero
        '
        Me.txtMonedero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonedero.Location = New System.Drawing.Point(384, 55)
        Me.txtMonedero.Name = "txtMonedero"
        Me.txtMonedero.Size = New System.Drawing.Size(125, 22)
        Me.txtMonedero.TabIndex = 66
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(261, 55)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(117, 22)
        Me.Label24.TabIndex = 65
        Me.Label24.Text = "Monedero:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 21)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Subtotal:"
        '
        'txtSubtotalmapeo
        '
        Me.txtSubtotalmapeo.BackColor = System.Drawing.Color.White
        Me.txtSubtotalmapeo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotalmapeo.Location = New System.Drawing.Point(125, 3)
        Me.txtSubtotalmapeo.Name = "txtSubtotalmapeo"
        Me.txtSubtotalmapeo.ReadOnly = True
        Me.txtSubtotalmapeo.Size = New System.Drawing.Size(125, 21)
        Me.txtSubtotalmapeo.TabIndex = 50
        Me.txtSubtotalmapeo.Text = "0.00"
        Me.txtSubtotalmapeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(262, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 21)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "Resta:"
        '
        'txtPropina
        '
        Me.txtPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropina.Location = New System.Drawing.Point(125, 87)
        Me.txtPropina.Name = "txtPropina"
        Me.txtPropina.Size = New System.Drawing.Size(124, 21)
        Me.txtPropina.TabIndex = 51
        Me.txtPropina.Text = "0.00"
        Me.txtPropina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtResta
        '
        Me.txtResta.BackColor = System.Drawing.Color.White
        Me.txtResta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResta.ForeColor = System.Drawing.Color.Red
        Me.txtResta.Location = New System.Drawing.Point(385, 30)
        Me.txtResta.Name = "txtResta"
        Me.txtResta.ReadOnly = True
        Me.txtResta.Size = New System.Drawing.Size(124, 21)
        Me.txtResta.TabIndex = 63
        Me.txtResta.Text = "0.00"
        Me.txtResta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 21)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Propina:"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(262, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(117, 21)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Cambio:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 21)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Total:"
        '
        'txtCambio
        '
        Me.txtCambio.BackColor = System.Drawing.Color.White
        Me.txtCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambio.ForeColor = System.Drawing.Color.ForestGreen
        Me.txtCambio.Location = New System.Drawing.Point(385, 4)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(124, 21)
        Me.txtCambio.TabIndex = 61
        Me.txtCambio.Text = "0.00"
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(125, 59)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(124, 21)
        Me.txtTotal.TabIndex = 54
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(117, 21)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Efectivo:"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.ForeColor = System.Drawing.Color.Orange
        Me.txtPorcentaje.Location = New System.Drawing.Point(125, 30)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(47, 21)
        Me.txtPorcentaje.TabIndex = 60
        Me.txtPorcentaje.Text = "0"
        Me.txtPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivo.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.txtEfectivo.Location = New System.Drawing.Point(125, 143)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(124, 21)
        Me.txtEfectivo.TabIndex = 56
        Me.txtEfectivo.Text = "0.00"
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 21)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Descuento:"
        '
        'grdComanda
        '
        Me.grdComanda.AllowUserToAddRows = False
        Me.grdComanda.AllowUserToDeleteRows = False
        Me.grdComanda.BackgroundColor = System.Drawing.Color.White
        Me.grdComanda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdComanda.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column10, Me.Column9})
        Me.grdComanda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComanda.Location = New System.Drawing.Point(0, 119)
        Me.grdComanda.Name = "grdComanda"
        Me.grdComanda.ReadOnly = True
        Me.grdComanda.RowHeadersVisible = False
        Me.grdComanda.Size = New System.Drawing.Size(784, 305)
        Me.grdComanda.TabIndex = 4
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column1.HeaderText = "Comanda"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 77
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column2.HeaderText = "Codigo"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 65
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "Descripción"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column4.HeaderText = "Unidad"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 66
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column5.HeaderText = "Cantidad"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 74
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle31
        Me.Column6.HeaderText = "Precio"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 62
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle32
        Me.Column7.HeaderText = "Total"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 56
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column8.HeaderText = "Comensal"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 78
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column10.HeaderText = "Mesero"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 67
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column9.HeaderText = "Id"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 41
        '
        'TFolio
        '
        '
        'pVentaMapeo80
        '
        '
        'pVentaMapeo58
        '
        '
        'Precuenta80
        '
        '
        'Precuenta58
        '
        '
        'Cancelacion80
        '
        '
        'Cancelacion58
        '
        '
        'pCortesia80
        '
        '
        'pCortesia58
        '
        '
        'frmNuevoPagarSencillo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1086, 649)
        Me.Controls.Add(Me.grdComanda)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNuevoPagarSencillo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagar Mesas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.picQR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdComanda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btn7 As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents lblmesa As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnPunto As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents lblusuario2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblMesero As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblfolio As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents cboComanda As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cboComensal As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents btn1000 As Button
    Friend WithEvents btn500 As Button
    Friend WithEvents btn200 As Button
    Friend WithEvents btn100 As Button
    Friend WithEvents btn50 As Button
    Friend WithEvents btn20 As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents grdComanda As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Label27 As Label
    Friend WithEvents txttotalpropina As TextBox
    Friend WithEvents txtMonedero As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSubtotalmapeo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPropina As TextBox
    Friend WithEvents txtResta As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCambio As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPorcentaje As TextBox
    Friend WithEvents txtEfectivo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTransferencia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTarjeta As TextBox
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents btnIntro As Button
    Friend WithEvents btnPrecuenta As Button
    Friend WithEvents BTNsALIR As Button
    Friend WithEvents btnDividir As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnCortesia As Button
    Friend WithEvents picQR As PictureBox
    Friend WithEvents Label25 As Label
    Friend WithEvents TFolio As Timer
    Friend WithEvents pVentaMapeo80 As Printing.PrintDocument
    Friend WithEvents pVentaMapeo58 As Printing.PrintDocument
    Friend WithEvents Precuenta80 As Printing.PrintDocument
    Friend WithEvents Precuenta58 As Printing.PrintDocument
    Friend WithEvents Cancelacion80 As Printing.PrintDocument
    Friend WithEvents Cancelacion58 As Printing.PrintDocument
    Friend WithEvents pCortesia80 As Printing.PrintDocument
    Friend WithEvents pCortesia58 As Printing.PrintDocument
    Friend WithEvents txtMontoMonedero As TextBox
End Class
