<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcula))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblpc = New System.Windows.Forms.Label()
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BillarCobro80 = New System.Drawing.Printing.PrintDocument()
        Me.BillarCobro58 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 38)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mesa:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblpc
        '
        Me.lblpc.BackColor = System.Drawing.Color.White
        Me.lblpc.Enabled = False
        Me.lblpc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpc.Location = New System.Drawing.Point(166, 42)
        Me.lblpc.Name = "lblpc"
        Me.lblpc.Size = New System.Drawing.Size(184, 38)
        Me.lblpc.TabIndex = 2
        Me.lblpc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(283, 222)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Horas"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(142, 24)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "Tiempo de Uso:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtHoras
        '
        Me.txtHoras.BackColor = System.Drawing.Color.White
        Me.txtHoras.Enabled = False
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.Location = New System.Drawing.Point(166, 216)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(111, 24)
        Me.txtHoras.TabIndex = 32
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(275, 335)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 60)
        Me.btnSalir.TabIndex = 31
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnDesocupar
        '
        Me.btnDesocupar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDesocupar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDesocupar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesocupar.Location = New System.Drawing.Point(139, 335)
        Me.btnDesocupar.Name = "btnDesocupar"
        Me.btnDesocupar.Size = New System.Drawing.Size(130, 60)
        Me.btnDesocupar.TabIndex = 30
        Me.btnDesocupar.Text = "Desocupar Mesa"
        Me.btnDesocupar.UseVisualStyleBackColor = False
        '
        'txtHorFin
        '
        Me.txtHorFin.BackColor = System.Drawing.Color.White
        Me.txtHorFin.Enabled = False
        Me.txtHorFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorFin.Location = New System.Drawing.Point(166, 136)
        Me.txtHorFin.Name = "txtHorFin"
        Me.txtHorFin.Size = New System.Drawing.Size(184, 24)
        Me.txtHorFin.TabIndex = 29
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(155, 23)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Hora Final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(283, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 20)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Minutos"
        '
        'txtTotalPag
        '
        Me.txtTotalPag.BackColor = System.Drawing.Color.White
        Me.txtTotalPag.Enabled = False
        Me.txtTotalPag.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPag.Location = New System.Drawing.Point(166, 296)
        Me.txtTotalPag.Name = "txtTotalPag"
        Me.txtTotalPag.Size = New System.Drawing.Size(111, 24)
        Me.txtTotalPag.TabIndex = 26
        '
        'txtPrecioHora
        '
        Me.txtPrecioHora.BackColor = System.Drawing.Color.White
        Me.txtPrecioHora.Enabled = False
        Me.txtPrecioHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioHora.Location = New System.Drawing.Point(166, 256)
        Me.txtPrecioHora.Name = "txtPrecioHora"
        Me.txtPrecioHora.Size = New System.Drawing.Size(111, 24)
        Me.txtPrecioHora.TabIndex = 25
        '
        'txtTiempoUso
        '
        Me.txtTiempoUso.BackColor = System.Drawing.Color.White
        Me.txtTiempoUso.Enabled = False
        Me.txtTiempoUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTiempoUso.Location = New System.Drawing.Point(166, 176)
        Me.txtTiempoUso.Name = "txtTiempoUso"
        Me.txtTiempoUso.Size = New System.Drawing.Size(111, 24)
        Me.txtTiempoUso.TabIndex = 24
        '
        'txtHorIni
        '
        Me.txtHorIni.BackColor = System.Drawing.Color.White
        Me.txtHorIni.Enabled = False
        Me.txtHorIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorIni.Location = New System.Drawing.Point(166, 96)
        Me.txtHorIni.Name = "txtHorIni"
        Me.txtHorIni.Size = New System.Drawing.Size(184, 24)
        Me.txtHorIni.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 298)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 23)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Total a Pagar: $"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 258)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 23)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Precio por Hora: $"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 23)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Tiempo de Uso:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 23)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Hora Inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(360, 31)
        Me.Label14.TabIndex = 224
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BillarCobro80
        '
        '
        'BillarCobro58
        '
        '
        'frmCalcula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(360, 407)
        Me.Controls.Add(Me.Label14)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Tiempo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblpc As Label
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
    Friend WithEvents Label14 As Label
    Friend WithEvents BillarCobro80 As Printing.PrintDocument
    Friend WithEvents BillarCobro58 As Printing.PrintDocument
End Class
