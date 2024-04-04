<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcularNuvHab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcularNuvHab))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblpc = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tfecha = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnDesocupar = New System.Windows.Forms.Button()
        Me.lblPagar = New System.Windows.Forms.Label()
        Me.lbltiempouso = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblHoras = New System.Windows.Forms.Label()
        Me.lblHorFin = New System.Windows.Forms.Label()
        Me.lblHorIni = New System.Windows.Forms.Label()
        Me.lblsalida = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblAnticipo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(352, 37)
        Me.Panel1.TabIndex = 54
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 38)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Habitación:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblpc
        '
        Me.lblpc.BackColor = System.Drawing.Color.White
        Me.lblpc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpc.Location = New System.Drawing.Point(161, 49)
        Me.lblpc.Name = "lblpc"
        Me.lblpc.Size = New System.Drawing.Size(184, 38)
        Me.lblpc.TabIndex = 56
        Me.lblpc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 23)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Hora Entrada:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 23)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Hora Actual:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 190)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 23)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Horas:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(184, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 23)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Precio:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 222)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(142, 23)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Tiempo de Uso:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 293)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(155, 23)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Total a Pagar: $"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(270, 327)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 62)
        Me.btnSalir.TabIndex = 79
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnDesocupar
        '
        Me.btnDesocupar.BackColor = System.Drawing.Color.White
        Me.btnDesocupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDesocupar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesocupar.Location = New System.Drawing.Point(114, 327)
        Me.btnDesocupar.Name = "btnDesocupar"
        Me.btnDesocupar.Size = New System.Drawing.Size(151, 62)
        Me.btnDesocupar.TabIndex = 80
        Me.btnDesocupar.Text = "Desocupar Habitación"
        Me.btnDesocupar.UseVisualStyleBackColor = False
        '
        'lblPagar
        '
        Me.lblPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagar.Location = New System.Drawing.Point(161, 291)
        Me.lblPagar.Name = "lblPagar"
        Me.lblPagar.Size = New System.Drawing.Size(184, 23)
        Me.lblPagar.TabIndex = 81
        Me.lblPagar.Text = "Label8"
        Me.lblPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbltiempouso
        '
        Me.lbltiempouso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltiempouso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltiempouso.Location = New System.Drawing.Point(161, 221)
        Me.lbltiempouso.Name = "lbltiempouso"
        Me.lbltiempouso.Size = New System.Drawing.Size(184, 23)
        Me.lbltiempouso.TabIndex = 82
        Me.lbltiempouso.Text = "Label8"
        Me.lbltiempouso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPrecio
        '
        Me.lblPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(245, 191)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(100, 23)
        Me.lblPrecio.TabIndex = 83
        Me.lblPrecio.Text = "Label8"
        Me.lblPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHoras
        '
        Me.lblHoras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoras.Location = New System.Drawing.Point(69, 191)
        Me.lblHoras.Name = "lblHoras"
        Me.lblHoras.Size = New System.Drawing.Size(109, 23)
        Me.lblHoras.TabIndex = 84
        Me.lblHoras.Text = "Label8"
        Me.lblHoras.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHorFin
        '
        Me.lblHorFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHorFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorFin.Location = New System.Drawing.Point(161, 126)
        Me.lblHorFin.Name = "lblHorFin"
        Me.lblHorFin.Size = New System.Drawing.Size(184, 23)
        Me.lblHorFin.TabIndex = 85
        Me.lblHorFin.Text = "Label8"
        Me.lblHorFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHorIni
        '
        Me.lblHorIni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHorIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorIni.Location = New System.Drawing.Point(161, 97)
        Me.lblHorIni.Name = "lblHorIni"
        Me.lblHorIni.Size = New System.Drawing.Size(184, 23)
        Me.lblHorIni.TabIndex = 87
        Me.lblHorIni.Text = "Label8"
        Me.lblHorIni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblsalida
        '
        Me.lblsalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblsalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsalida.Location = New System.Drawing.Point(161, 158)
        Me.lblsalida.Name = "lblsalida"
        Me.lblsalida.Size = New System.Drawing.Size(184, 23)
        Me.lblsalida.TabIndex = 89
        Me.lblsalida.Text = "Label8"
        Me.lblsalida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 158)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 23)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Hora Salida:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAnticipo
        '
        Me.lblAnticipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnticipo.Location = New System.Drawing.Point(161, 256)
        Me.lblAnticipo.Name = "lblAnticipo"
        Me.lblAnticipo.Size = New System.Drawing.Size(184, 23)
        Me.lblAnticipo.TabIndex = 91
        Me.lblAnticipo.Text = "Label8"
        Me.lblAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(155, 23)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "Anticipo: $"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCalcularNuvHab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(352, 399)
        Me.Controls.Add(Me.lblAnticipo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblsalida)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblHorIni)
        Me.Controls.Add(Me.lblHorFin)
        Me.Controls.Add(Me.lblHoras)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.lbltiempouso)
        Me.Controls.Add(Me.lblPagar)
        Me.Controls.Add(Me.btnDesocupar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblpc)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcularNuvHab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Tiempo"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblpc As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtHorIni As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Tfecha As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents txtHoras As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTiempoUso As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalPag As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnDesocupar As Button
    Friend WithEvents lblPagar As Label
    Friend WithEvents lbltiempouso As Label
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblHoras As Label
    Friend WithEvents lblHorFin As Label
    Friend WithEvents lblHorIni As Label
    Friend WithEvents lblsalida As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblAnticipo As Label
    Friend WithEvents Label10 As Label
End Class
