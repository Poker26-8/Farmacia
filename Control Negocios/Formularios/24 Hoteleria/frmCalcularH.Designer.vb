<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcularH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcularH))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHoras = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnDesocupar = New System.Windows.Forms.Button()
        Me.txtHorFin = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalPag = New System.Windows.Forms.TextBox()
        Me.txtPrecioHora = New System.Windows.Forms.TextBox()
        Me.txtTiempoUso = New System.Windows.Forms.TextBox()
        Me.txtHorIni = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblpc = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(283, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 71
        Me.Label8.Text = "Horas"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 207)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 24)
        Me.Label9.TabIndex = 70
        Me.Label9.Text = "Tiempo de Uso:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtHoras
        '
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.Location = New System.Drawing.Point(166, 206)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(111, 24)
        Me.txtHoras.TabIndex = 69
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.White
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(275, 325)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 63)
        Me.btnSalir.TabIndex = 68
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnDesocupar
        '
        Me.btnDesocupar.BackColor = System.Drawing.Color.White
        Me.btnDesocupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDesocupar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesocupar.Location = New System.Drawing.Point(139, 325)
        Me.btnDesocupar.Name = "btnDesocupar"
        Me.btnDesocupar.Size = New System.Drawing.Size(130, 60)
        Me.btnDesocupar.TabIndex = 67
        Me.btnDesocupar.Text = "Desocupar Habitación"
        Me.btnDesocupar.UseVisualStyleBackColor = False
        '
        'txtHorFin
        '
        Me.txtHorFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorFin.Location = New System.Drawing.Point(166, 126)
        Me.txtHorFin.Name = "txtHorFin"
        Me.txtHorFin.Size = New System.Drawing.Size(184, 24)
        Me.txtHorFin.TabIndex = 66
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 23)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Hora Final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(283, 171)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 20)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "Minutos"
        '
        'txtTotalPag
        '
        Me.txtTotalPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPag.Location = New System.Drawing.Point(166, 286)
        Me.txtTotalPag.Name = "txtTotalPag"
        Me.txtTotalPag.Size = New System.Drawing.Size(111, 24)
        Me.txtTotalPag.TabIndex = 63
        '
        'txtPrecioHora
        '
        Me.txtPrecioHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioHora.Location = New System.Drawing.Point(166, 246)
        Me.txtPrecioHora.Name = "txtPrecioHora"
        Me.txtPrecioHora.Size = New System.Drawing.Size(111, 24)
        Me.txtPrecioHora.TabIndex = 62
        '
        'txtTiempoUso
        '
        Me.txtTiempoUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempoUso.Location = New System.Drawing.Point(166, 166)
        Me.txtTiempoUso.Name = "txtTiempoUso"
        Me.txtTiempoUso.Size = New System.Drawing.Size(111, 24)
        Me.txtTiempoUso.TabIndex = 61
        '
        'txtHorIni
        '
        Me.txtHorIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorIni.Location = New System.Drawing.Point(166, 86)
        Me.txtHorIni.Name = "txtHorIni"
        Me.txtHorIni.Size = New System.Drawing.Size(184, 24)
        Me.txtHorIni.TabIndex = 60
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 288)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 23)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Total a Pagar: $"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 23)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Precio: $"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 23)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Tiempo de Uso:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 23)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Hora Inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 38)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Habitacion:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblpc
        '
        Me.lblpc.BackColor = System.Drawing.Color.White
        Me.lblpc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpc.Location = New System.Drawing.Point(166, 40)
        Me.lblpc.Name = "lblpc"
        Me.lblpc.Size = New System.Drawing.Size(184, 38)
        Me.lblpc.TabIndex = 54
        Me.lblpc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(365, 37)
        Me.Panel1.TabIndex = 53
        '
        'frmCalcularH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(365, 396)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtHoras)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnDesocupar)
        Me.Controls.Add(Me.txtHorFin)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTotalPag)
        Me.Controls.Add(Me.txtPrecioHora)
        Me.Controls.Add(Me.txtTiempoUso)
        Me.Controls.Add(Me.txtHorIni)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblpc)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcularH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Tiempo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHoras As TextBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnDesocupar As Button
    Friend WithEvents txtHorFin As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtTotalPag As TextBox
    Friend WithEvents txtPrecioHora As TextBox
    Friend WithEvents txtTiempoUso As TextBox
    Friend WithEvents txtHorIni As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblpc As Label
    Friend WithEvents Panel1 As Panel
End Class
