<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEtiquetas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optPCP = New System.Windows.Forms.RadioButton()
        Me.optPC = New System.Windows.Forms.RadioButton()
        Me.optPP = New System.Windows.Forms.RadioButton()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtcopias = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtgrupo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboimpresora = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pPP = New System.Drawing.Printing.PrintDocument()
        Me.pPC = New System.Drawing.Printing.PrintDocument()
        Me.pPCP = New System.Drawing.Printing.PrintDocument()
        Me.pPP2x4 = New System.Drawing.Printing.PrintDocument()
        Me.pPC2x4 = New System.Drawing.Printing.PrintDocument()
        Me.pPCP2x4 = New System.Drawing.Printing.PrintDocument()
        Me.pPP5x25 = New System.Drawing.Printing.PrintDocument()
        Me.pPC5x25 = New System.Drawing.Printing.PrintDocument()
        Me.pPCP5x25 = New System.Drawing.Printing.PrintDocument()
        Me.pPP65x27 = New System.Drawing.Printing.PrintDocument()
        Me.pPC65x27 = New System.Drawing.Printing.PrintDocument()
        Me.pPCP65x27 = New System.Drawing.Printing.PrintDocument()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.pPCP5x3 = New System.Drawing.Printing.PrintDocument()
        Me.pPC5x3 = New System.Drawing.Printing.PrintDocument()
        Me.pPP5x3 = New System.Drawing.Printing.PrintDocument()
        Me.pPCP25x38 = New System.Drawing.Printing.PrintDocument()
        Me.pPC25X38 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(440, 31)
        Me.Label1.TabIndex = 230
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optPCP
        '
        Me.optPCP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPCP.AutoSize = True
        Me.optPCP.Location = New System.Drawing.Point(8, 243)
        Me.optPCP.Name = "optPCP"
        Me.optPCP.Size = New System.Drawing.Size(213, 19)
        Me.optPCP.TabIndex = 233
        Me.optPCP.TabStop = True
        Me.optPCP.Text = "Producto, código de barras y precio"
        Me.optPCP.UseVisualStyleBackColor = True
        '
        'optPC
        '
        Me.optPC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPC.AutoSize = True
        Me.optPC.Location = New System.Drawing.Point(8, 219)
        Me.optPC.Name = "optPC"
        Me.optPC.Size = New System.Drawing.Size(174, 19)
        Me.optPC.TabIndex = 232
        Me.optPC.TabStop = True
        Me.optPC.Text = "Producto y código de barras"
        Me.optPC.UseVisualStyleBackColor = True
        '
        'optPP
        '
        Me.optPP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPP.AutoSize = True
        Me.optPP.Location = New System.Drawing.Point(8, 195)
        Me.optPP.Name = "optPP"
        Me.optPP.Size = New System.Drawing.Size(119, 19)
        Me.optPP.TabIndex = 231
        Me.optPP.TabStop = True
        Me.optPP.Text = "Producto y precio"
        Me.optPP.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(373, 199)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 242
        Me.btnnuevo.Text = "Limpiar"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'btnImprime
        '
        Me.btnImprime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprime.BackgroundImage = CType(resources.GetObject("btnImprime.BackgroundImage"), System.Drawing.Image)
        Me.btnImprime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprime.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.Location = New System.Drawing.Point(307, 199)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(60, 63)
        Me.btnImprime.TabIndex = 243
        Me.btnImprime.Text = "Imprimir"
        Me.btnImprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprime.UseVisualStyleBackColor = True
        '
        'cbonombre
        '
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(7, 57)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(321, 23)
        Me.cbonombre.TabIndex = 244
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 15)
        Me.Label13.TabIndex = 245
        Me.Label13.Text = "Descripción:"
        '
        'txtcopias
        '
        Me.txtcopias.Location = New System.Drawing.Point(331, 57)
        Me.txtcopias.Name = "txtcopias"
        Me.txtcopias.Size = New System.Drawing.Size(103, 23)
        Me.txtcopias.TabIndex = 246
        Me.txtcopias.Text = "1"
        Me.txtcopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(331, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "No. Copias:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 249
        Me.Label3.Text = "Código:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(7, 104)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(100, 23)
        Me.txtcodigo.TabIndex = 248
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Código de barras:"
        '
        'txtbarras
        '
        Me.txtbarras.Location = New System.Drawing.Point(110, 104)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(201, 23)
        Me.txtbarras.TabIndex = 250
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(314, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 15)
        Me.Label5.TabIndex = 253
        Me.Label5.Text = "Grupo:"
        '
        'txtgrupo
        '
        Me.txtgrupo.Location = New System.Drawing.Point(314, 104)
        Me.txtgrupo.Name = "txtgrupo"
        Me.txtgrupo.ReadOnly = True
        Me.txtgrupo.Size = New System.Drawing.Size(120, 23)
        Me.txtgrupo.TabIndex = 252
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboimpresora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 55)
        Me.GroupBox1.TabIndex = 254
        Me.GroupBox1.TabStop = False
        '
        'cboimpresora
        '
        Me.cboimpresora.FormattingEnabled = True
        Me.cboimpresora.Location = New System.Drawing.Point(85, 20)
        Me.cboimpresora.Name = "cboimpresora"
        Me.cboimpresora.Size = New System.Drawing.Size(332, 23)
        Me.cboimpresora.TabIndex = 255
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Impresora:"
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(456, 177)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(100, 23)
        Me.txtprecio.TabIndex = 255
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(496, 177)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(250, 43)
        Me.PictureBox2.TabIndex = 257
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(496, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(428, 132)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 256
        Me.PictureBox1.TabStop = False
        '
        'pPP
        '
        '
        'pPC
        '
        '
        'pPCP
        '
        '
        'pPP2x4
        '
        '
        'pPC2x4
        '
        '
        'pPCP2x4
        '
        '
        'pPP5x25
        '
        '
        'pPC5x25
        '
        '
        'pPCP5x25
        '
        '
        'pPP65x27
        '
        '
        'pPC65x27
        '
        '
        'pPCP65x27
        '
        '
        'piclogo
        '
        Me.piclogo.BackColor = System.Drawing.Color.White
        Me.piclogo.Location = New System.Drawing.Point(496, 238)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(71, 49)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.piclogo.TabIndex = 258
        Me.piclogo.TabStop = False
        '
        'pPCP5x3
        '
        '
        'pPC5x3
        '
        '
        'pPP5x3
        '
        '
        'pPCP25x38
        '
        '
        'frmEtiquetas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(440, 271)
        Me.Controls.Add(Me.piclogo)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtprecio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtgrupo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtbarras)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcopias)
        Me.Controls.Add(Me.cbonombre)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnImprime)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.optPCP)
        Me.Controls.Add(Me.optPC)
        Me.Controls.Add(Me.optPP)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(447, 299)
        Me.Name = "frmEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de etiquetas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optPCP As System.Windows.Forms.RadioButton
    Friend WithEvents optPC As System.Windows.Forms.RadioButton
    Friend WithEvents optPP As System.Windows.Forms.RadioButton
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents btnImprime As System.Windows.Forms.Button
    Friend WithEvents cbonombre As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtcopias As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbarras As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtgrupo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboimpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtprecio As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pPP As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPC As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPCP As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPP2x4 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPC2x4 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPCP2x4 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPP5x25 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPC5x25 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPCP5x25 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPP65x27 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPC65x27 As System.Drawing.Printing.PrintDocument
    Friend WithEvents pPCP65x27 As System.Drawing.Printing.PrintDocument
    Friend WithEvents piclogo As PictureBox
    Friend WithEvents pPCP5x3 As Printing.PrintDocument
    Friend WithEvents pPC5x3 As Printing.PrintDocument
    Friend WithEvents pPP5x3 As Printing.PrintDocument
    Friend WithEvents pPCP25x38 As Printing.PrintDocument
    Friend WithEvents pPC25X38 As Printing.PrintDocument
End Class
