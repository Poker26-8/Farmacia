<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagado))
        Me.LabelProductName = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.LabelCompanyName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblLiberacion = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtLiberacion = New System.Windows.Forms.TextBox()
        Me.lblNumPC = New System.Windows.Forms.Label()
        Me.txtNumPC = New System.Windows.Forms.TextBox()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelProductName
        '
        Me.LabelProductName.Font = New System.Drawing.Font("Segoe UI Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProductName.Location = New System.Drawing.Point(17, 280)
        Me.LabelProductName.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(402, 34)
        Me.LabelProductName.TabIndex = 3
        Me.LabelProductName.Text = "Nombre de producto"
        Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelVersion
        '
        Me.LabelVersion.BackColor = System.Drawing.Color.White
        Me.LabelVersion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.Location = New System.Drawing.Point(128, 296)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(93, 18)
        Me.LabelVersion.TabIndex = 4
        Me.LabelVersion.Text = "Versión"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelCopyright
        '
        Me.LabelCopyright.BackColor = System.Drawing.Color.White
        Me.LabelCopyright.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCopyright.Location = New System.Drawing.Point(12, 296)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(115, 18)
        Me.LabelCopyright.TabIndex = 1
        Me.LabelCopyright.Text = "Copyright"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelCompanyName
        '
        Me.LabelCompanyName.BackColor = System.Drawing.Color.White
        Me.LabelCompanyName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCompanyName.Location = New System.Drawing.Point(222, 296)
        Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCompanyName.Name = "LabelCompanyName"
        Me.LabelCompanyName.Size = New System.Drawing.Size(192, 18)
        Me.LabelCompanyName.TabIndex = 2
        Me.LabelCompanyName.Text = "Nombre de la compañía"
        Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 128)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLiberacion
        '
        Me.lblLiberacion.AutoSize = True
        Me.lblLiberacion.ForeColor = System.Drawing.Color.Black
        Me.lblLiberacion.Location = New System.Drawing.Point(9, 378)
        Me.lblLiberacion.Name = "lblLiberacion"
        Me.lblLiberacion.Size = New System.Drawing.Size(130, 19)
        Me.lblLiberacion.TabIndex = 12
        Me.lblLiberacion.Text = "Liberación Delssom:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(208, 406)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 35)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(315, 406)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtLiberacion
        '
        Me.txtLiberacion.Location = New System.Drawing.Point(149, 375)
        Me.txtLiberacion.Name = "txtLiberacion"
        Me.txtLiberacion.Size = New System.Drawing.Size(265, 25)
        Me.txtLiberacion.TabIndex = 11
        Me.txtLiberacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNumPC
        '
        Me.lblNumPC.AutoSize = True
        Me.lblNumPC.ForeColor = System.Drawing.Color.Black
        Me.lblNumPC.Location = New System.Drawing.Point(9, 319)
        Me.lblNumPC.Name = "lblNumPC"
        Me.lblNumPC.Size = New System.Drawing.Size(102, 19)
        Me.lblNumPC.TabIndex = 8
        Me.lblNumPC.Text = "Número de PC:"
        '
        'txtNumPC
        '
        Me.txtNumPC.Enabled = False
        Me.txtNumPC.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumPC.Location = New System.Drawing.Point(12, 344)
        Me.txtNumPC.Name = "txtNumPC"
        Me.txtNumPC.ReadOnly = True
        Me.txtNumPC.Size = New System.Drawing.Size(402, 25)
        Me.txtNumPC.TabIndex = 7
        Me.txtNumPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSerie
        '
        Me.lblSerie.BackColor = System.Drawing.Color.White
        Me.lblSerie.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerie.ForeColor = System.Drawing.Color.Black
        Me.lblSerie.Location = New System.Drawing.Point(12, 259)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(402, 26)
        Me.lblSerie.TabIndex = 13
        Me.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(-18, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(459, 108)
        Me.Panel1.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Location = New System.Drawing.Point(0, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(459, 95)
        Me.Panel2.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(30, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(402, 84)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'frmPagado
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(426, 454)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.lblLiberacion)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtLiberacion)
        Me.Controls.Add(Me.lblNumPC)
        Me.Controls.Add(Me.txtNumPC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LabelProductName)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelCompanyName)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPagado"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delsscom Control Negocios Pro"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelProductName As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLiberacion As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtLiberacion As System.Windows.Forms.TextBox
    Friend WithEvents lblNumPC As System.Windows.Forms.Label
    Friend WithEvents txtNumPC As System.Windows.Forms.TextBox
    Friend WithEvents lblSerie As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
