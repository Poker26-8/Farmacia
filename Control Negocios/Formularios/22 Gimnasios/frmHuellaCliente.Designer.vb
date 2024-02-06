<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHuellaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHuellaCliente))
        Me.visor = New AForge.Controls.VideoSourcePlayer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtnombre = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCredencial = New System.Windows.Forms.TextBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.txtMuestras = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.picHuella = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'visor
        '
        Me.visor.Location = New System.Drawing.Point(19, 188)
        Me.visor.Name = "visor"
        Me.visor.Size = New System.Drawing.Size(167, 177)
        Me.visor.TabIndex = 100
        Me.visor.Text = "VideoSourcePlayer1"
        Me.visor.VideoSource = Nothing
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(412, 188)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(10, 10)
        Me.Button2.TabIndex = 97
        Me.Button2.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(192, 188)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(167, 177)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 98
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(362, 285)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 80)
        Me.Button1.TabIndex = 96
        Me.Button1.Text = "Capturar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtnombre
        '
        Me.txtnombre.FormattingEnabled = True
        Me.txtnombre.Location = New System.Drawing.Point(124, 74)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(293, 21)
        Me.txtnombre.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Muestras restantes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCredencial
        '
        Me.txtCredencial.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredencial.Location = New System.Drawing.Point(124, 101)
        Me.txtCredencial.Name = "txtCredencial"
        Me.txtCredencial.ReadOnly = True
        Me.txtCredencial.Size = New System.Drawing.Size(106, 25)
        Me.txtCredencial.TabIndex = 93
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnguardar.Enabled = False
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(299, 101)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(57, 74)
        Me.btnguardar.TabIndex = 92
        Me.btnguardar.Text = "Guardar huella"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnlimpiar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Image = CType(resources.GetObject("btnlimpiar.Image"), System.Drawing.Image)
        Me.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpiar.Location = New System.Drawing.Point(362, 101)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Padding = New System.Windows.Forms.Padding(0, 10, 0, 0)
        Me.btnlimpiar.Size = New System.Drawing.Size(60, 74)
        Me.btnlimpiar.TabIndex = 91
        Me.btnlimpiar.Text = "Salir"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = False
        '
        'txtMuestras
        '
        Me.txtMuestras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMuestras.Location = New System.Drawing.Point(124, 154)
        Me.txtMuestras.Name = "txtMuestras"
        Me.txtMuestras.ReadOnly = True
        Me.txtMuestras.Size = New System.Drawing.Size(106, 21)
        Me.txtMuestras.TabIndex = 90
        Me.txtMuestras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(124, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Nombre:"
        '
        'picHuella
        '
        Me.picHuella.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picHuella.Location = New System.Drawing.Point(19, 46)
        Me.picHuella.Name = "picHuella"
        Me.picHuella.Size = New System.Drawing.Size(97, 129)
        Me.picHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picHuella.TabIndex = 88
        Me.picHuella.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(-84, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(785, 35)
        Me.Label2.TabIndex = 87
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Button3.Location = New System.Drawing.Point(362, 188)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(60, 85)
        Me.Button3.TabIndex = 99
        Me.Button3.Text = "Activar Camara"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = False
        '
        'frmHuellaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(432, 390)
        Me.Controls.Add(Me.visor)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCredencial)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.txtMuestras)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.picHuella)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.MaximumSize = New System.Drawing.Size(448, 429)
        Me.MinimumSize = New System.Drawing.Size(448, 429)
        Me.Name = "frmHuellaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Huella Digital"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHuella, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents visor As AForge.Controls.VideoSourcePlayer
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtnombre As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCredencial As TextBox
    Friend WithEvents btnguardar As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents txtMuestras As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents picHuella As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
End Class
