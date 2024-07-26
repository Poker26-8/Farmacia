<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehiculoTa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVehiculoTa))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbomarca = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbomodelo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboA = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rtObservaciones = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.txtSubmarca = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Historic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(546, 31)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Entrada de vehiculo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbomarca
        '
        Me.cbomarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbomarca.FormattingEnabled = True
        Me.cbomarca.Location = New System.Drawing.Point(78, 11)
        Me.cbomarca.Name = "cbomarca"
        Me.cbomarca.Size = New System.Drawing.Size(200, 21)
        Me.cbomarca.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 23)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Marca:"
        '
        'cbomodelo
        '
        Me.cbomodelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbomodelo.FormattingEnabled = True
        Me.cbomodelo.Location = New System.Drawing.Point(78, 38)
        Me.cbomodelo.Name = "cbomodelo"
        Me.cbomodelo.Size = New System.Drawing.Size(200, 21)
        Me.cbomodelo.TabIndex = 81
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 23)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Modelo:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 23)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Año:"
        '
        'cboA
        '
        Me.cboA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboA.FormattingEnabled = True
        Me.cboA.Location = New System.Drawing.Point(371, 40)
        Me.cboA.Name = "cboA"
        Me.cboA.Size = New System.Drawing.Size(170, 21)
        Me.cboA.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(284, 11)
        Me.Label1.MaximumSize = New System.Drawing.Size(88, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Submarca:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rtObservaciones)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.btnlimpiar)
        Me.Panel1.Controls.Add(Me.txtSubmarca)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnguardar)
        Me.Panel1.Controls.Add(Me.txtPlacas)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboCliente)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cbomarca)
        Me.Panel1.Controls.Add(Me.cboA)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cbomodelo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 31)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 406)
        Me.Panel1.TabIndex = 88
        '
        'rtObservaciones
        '
        Me.rtObservaciones.Location = New System.Drawing.Point(12, 165)
        Me.rtObservaciones.Name = "rtObservaciones"
        Me.rtObservaciones.Size = New System.Drawing.Size(522, 160)
        Me.rtObservaciones.TabIndex = 99
        Me.rtObservaciones.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 142)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(171, 20)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "Observaciones"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackColor = System.Drawing.Color.White
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnlimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Image = CType(resources.GetObject("btnlimpiar.Image"), System.Drawing.Image)
        Me.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpiar.Location = New System.Drawing.Point(305, 330)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(71, 72)
        Me.btnlimpiar.TabIndex = 95
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = False
        '
        'txtSubmarca
        '
        Me.txtSubmarca.Location = New System.Drawing.Point(371, 11)
        Me.txtSubmarca.Name = "txtSubmarca"
        Me.txtSubmarca.Size = New System.Drawing.Size(170, 20)
        Me.txtSubmarca.TabIndex = 97
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(463, 331)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 72)
        Me.Button1.TabIndex = 96
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.White
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(382, 331)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 72)
        Me.btnguardar.TabIndex = 94
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'txtPlacas
        '
        Me.txtPlacas.Location = New System.Drawing.Point(78, 111)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(200, 20)
        Me.txtPlacas.TabIndex = 91
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 20)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Placa:"
        '
        'cboCliente
        '
        Me.cboCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(78, 80)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(463, 21)
        Me.cboCliente.TabIndex = 89
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 23)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Cliente:"
        '
        'frmVehiculoTa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(546, 443)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVehiculoTa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehiculos Taller"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents cbomarca As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbomodelo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cboA As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPlacas As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents txtSubmarca As TextBox
    Friend WithEvents rtObservaciones As RichTextBox
    Friend WithEvents Label7 As Label
End Class
