<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtiquetas2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEtiquetas2))
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtgrupo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtbarras = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcopias = New System.Windows.Forms.TextBox()
        Me.cbonombre = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.optPCP = New System.Windows.Forms.RadioButton()
        Me.optPC = New System.Windows.Forms.RadioButton()
        Me.optPP = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboimpresora = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.piclogo = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.GroupBox1.SuspendLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(463, 156)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(100, 20)
        Me.txtprecio.TabIndex = 275
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(321, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 273
        Me.Label5.Text = "Cantidad:"
        '
        'txtgrupo
        '
        Me.txtgrupo.Location = New System.Drawing.Point(321, 83)
        Me.txtgrupo.Name = "txtgrupo"
        Me.txtgrupo.Size = New System.Drawing.Size(120, 20)
        Me.txtgrupo.TabIndex = 272
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(117, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 271
        Me.Label4.Text = "Código de barras:"
        '
        'txtbarras
        '
        Me.txtbarras.Location = New System.Drawing.Point(117, 83)
        Me.txtbarras.Name = "txtbarras"
        Me.txtbarras.Size = New System.Drawing.Size(201, 20)
        Me.txtbarras.TabIndex = 270
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Código:"
        '
        'txtcodigo
        '
        Me.txtcodigo.Location = New System.Drawing.Point(14, 83)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.ReadOnly = True
        Me.txtcodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtcodigo.TabIndex = 268
        Me.txtcodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(338, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "No. Copias:"
        '
        'txtcopias
        '
        Me.txtcopias.Location = New System.Drawing.Point(338, 36)
        Me.txtcopias.Name = "txtcopias"
        Me.txtcopias.Size = New System.Drawing.Size(103, 20)
        Me.txtcopias.TabIndex = 266
        Me.txtcopias.Text = "1"
        Me.txtcopias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbonombre
        '
        Me.cbonombre.FormattingEnabled = True
        Me.cbonombre.Location = New System.Drawing.Point(14, 36)
        Me.cbonombre.Name = "cbonombre"
        Me.cbonombre.Size = New System.Drawing.Size(321, 21)
        Me.cbonombre.TabIndex = 264
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 13)
        Me.Label13.TabIndex = 265
        Me.Label13.Text = "Descripción:"
        '
        'optPCP
        '
        Me.optPCP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPCP.AutoSize = True
        Me.optPCP.Location = New System.Drawing.Point(6, 232)
        Me.optPCP.Name = "optPCP"
        Me.optPCP.Size = New System.Drawing.Size(193, 17)
        Me.optPCP.TabIndex = 261
        Me.optPCP.TabStop = True
        Me.optPCP.Text = "Producto, código de barras y precio"
        Me.optPCP.UseVisualStyleBackColor = True
        Me.optPCP.Visible = False
        '
        'optPC
        '
        Me.optPC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPC.AutoSize = True
        Me.optPC.Location = New System.Drawing.Point(6, 208)
        Me.optPC.Name = "optPC"
        Me.optPC.Size = New System.Drawing.Size(158, 17)
        Me.optPC.TabIndex = 260
        Me.optPC.TabStop = True
        Me.optPC.Text = "Producto y código de barras"
        Me.optPC.UseVisualStyleBackColor = True
        Me.optPC.Visible = False
        '
        'optPP
        '
        Me.optPP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.optPP.AutoSize = True
        Me.optPP.Location = New System.Drawing.Point(6, 184)
        Me.optPP.Name = "optPP"
        Me.optPP.Size = New System.Drawing.Size(108, 17)
        Me.optPP.TabIndex = 259
        Me.optPP.TabStop = True
        Me.optPP.Text = "Producto y precio"
        Me.optPP.UseVisualStyleBackColor = True
        Me.optPP.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboimpresora)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(427, 55)
        Me.GroupBox1.TabIndex = 274
        Me.GroupBox1.TabStop = False
        '
        'cboimpresora
        '
        Me.cboimpresora.FormattingEnabled = True
        Me.cboimpresora.Location = New System.Drawing.Point(85, 20)
        Me.cboimpresora.Name = "cboimpresora"
        Me.cboimpresora.Size = New System.Drawing.Size(332, 21)
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
        'piclogo
        '
        Me.piclogo.BackColor = System.Drawing.Color.White
        Me.piclogo.Location = New System.Drawing.Point(503, 217)
        Me.piclogo.Name = "piclogo"
        Me.piclogo.Size = New System.Drawing.Size(71, 49)
        Me.piclogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.piclogo.TabIndex = 278
        Me.piclogo.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(503, 156)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(250, 81)
        Me.PictureBox2.TabIndex = 277
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(503, 18)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(428, 132)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 276
        Me.PictureBox1.TabStop = False
        '
        'btnImprime
        '
        Me.btnImprime.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnImprime.BackgroundImage = CType(resources.GetObject("btnImprime.BackgroundImage"), System.Drawing.Image)
        Me.btnImprime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnImprime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprime.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.Location = New System.Drawing.Point(309, 184)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(60, 63)
        Me.btnImprime.TabIndex = 263
        Me.btnImprime.Text = "Imprimir"
        Me.btnImprime.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprime.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnnuevo.BackgroundImage = CType(resources.GetObject("btnnuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnnuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Location = New System.Drawing.Point(375, 184)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnnuevo.TabIndex = 262
        Me.btnnuevo.Text = "Limpiar"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.Location = New System.Drawing.Point(496, 346)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(428, 132)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 279
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(496, 524)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(250, 81)
        Me.PictureBox4.TabIndex = 280
        Me.PictureBox4.TabStop = False
        '
        'PrintDocument1
        '
        '
        'frmEtiquetas2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(455, 259)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
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
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmEtiquetas2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresión de Etiquetas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.piclogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents piclogo As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtgrupo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtbarras As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcopias As TextBox
    Friend WithEvents cbonombre As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnImprime As Button
    Friend WithEvents btnnuevo As Button
    Friend WithEvents optPCP As RadioButton
    Friend WithEvents optPC As RadioButton
    Friend WithEvents optPP As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboimpresora As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
