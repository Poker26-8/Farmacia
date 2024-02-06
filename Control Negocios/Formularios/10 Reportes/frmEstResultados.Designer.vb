<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstResultados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstResultados))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtventas = New System.Windows.Forms.TextBox()
        Me.txtdevos = New System.Windows.Forms.TextBox()
        Me.txtdescu = New System.Windows.Forms.TextBox()
        Me.txtventas_n = New System.Windows.Forms.TextBox()
        Me.txtcosto = New System.Windows.Forms.TextBox()
        Me.txtutilidad_bruta = New System.Windows.Forms.TextBox()
        Me.txtgastos_ad = New System.Windows.Forms.TextBox()
        Me.txtgastos_op = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtgastos_ve = New System.Windows.Forms.TextBox()
        Me.txtutilidad_im = New System.Windows.Forms.TextBox()
        Me.txtimpuestos = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtutilidad = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker()
        Me.dtpfinal = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
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
        Me.Label1.Size = New System.Drawing.Size(341, 31)
        Me.Label1.TabIndex = 230
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtventas
        '
        Me.txtventas.BackColor = System.Drawing.Color.White
        Me.txtventas.Location = New System.Drawing.Point(228, 175)
        Me.txtventas.Name = "txtventas"
        Me.txtventas.ReadOnly = True
        Me.txtventas.Size = New System.Drawing.Size(100, 23)
        Me.txtventas.TabIndex = 231
        Me.txtventas.Text = "0.00"
        Me.txtventas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdevos
        '
        Me.txtdevos.BackColor = System.Drawing.Color.White
        Me.txtdevos.Location = New System.Drawing.Point(228, 120)
        Me.txtdevos.Name = "txtdevos"
        Me.txtdevos.ReadOnly = True
        Me.txtdevos.Size = New System.Drawing.Size(100, 23)
        Me.txtdevos.TabIndex = 232
        Me.txtdevos.Text = "0.00"
        Me.txtdevos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdescu
        '
        Me.txtdescu.BackColor = System.Drawing.Color.White
        Me.txtdescu.Location = New System.Drawing.Point(228, 148)
        Me.txtdescu.Name = "txtdescu"
        Me.txtdescu.ReadOnly = True
        Me.txtdescu.Size = New System.Drawing.Size(100, 23)
        Me.txtdescu.TabIndex = 233
        Me.txtdescu.Text = "0.00"
        Me.txtdescu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtventas_n
        '
        Me.txtventas_n.BackColor = System.Drawing.Color.White
        Me.txtventas_n.Location = New System.Drawing.Point(228, 93)
        Me.txtventas_n.Name = "txtventas_n"
        Me.txtventas_n.ReadOnly = True
        Me.txtventas_n.Size = New System.Drawing.Size(100, 23)
        Me.txtventas_n.TabIndex = 234
        Me.txtventas_n.Text = "0.00"
        Me.txtventas_n.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcosto
        '
        Me.txtcosto.BackColor = System.Drawing.Color.White
        Me.txtcosto.Location = New System.Drawing.Point(228, 204)
        Me.txtcosto.Name = "txtcosto"
        Me.txtcosto.ReadOnly = True
        Me.txtcosto.Size = New System.Drawing.Size(100, 23)
        Me.txtcosto.TabIndex = 235
        Me.txtcosto.Text = "0.00"
        Me.txtcosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtutilidad_bruta
        '
        Me.txtutilidad_bruta.BackColor = System.Drawing.Color.White
        Me.txtutilidad_bruta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad_bruta.Location = New System.Drawing.Point(228, 232)
        Me.txtutilidad_bruta.Name = "txtutilidad_bruta"
        Me.txtutilidad_bruta.ReadOnly = True
        Me.txtutilidad_bruta.Size = New System.Drawing.Size(100, 23)
        Me.txtutilidad_bruta.TabIndex = 236
        Me.txtutilidad_bruta.Text = "0.00"
        Me.txtutilidad_bruta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgastos_ad
        '
        Me.txtgastos_ad.BackColor = System.Drawing.Color.White
        Me.txtgastos_ad.Location = New System.Drawing.Point(228, 260)
        Me.txtgastos_ad.Name = "txtgastos_ad"
        Me.txtgastos_ad.ReadOnly = True
        Me.txtgastos_ad.Size = New System.Drawing.Size(100, 23)
        Me.txtgastos_ad.TabIndex = 237
        Me.txtgastos_ad.Text = "0.00"
        Me.txtgastos_ad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgastos_op
        '
        Me.txtgastos_op.BackColor = System.Drawing.Color.White
        Me.txtgastos_op.Location = New System.Drawing.Point(228, 288)
        Me.txtgastos_op.Name = "txtgastos_op"
        Me.txtgastos_op.ReadOnly = True
        Me.txtgastos_op.Size = New System.Drawing.Size(100, 23)
        Me.txtgastos_op.TabIndex = 238
        Me.txtgastos_op.Text = "0.00"
        Me.txtgastos_op.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 239
        Me.Label2.Text = "Ventas"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 15)
        Me.Label4.TabIndex = 241
        Me.Label4.Text = "Devoluciones sobre ventas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 15)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Descuentos sobre ventas"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 180)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 243
        Me.Label6.Text = "Ventas netas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 208)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 15)
        Me.Label7.TabIndex = 244
        Me.Label7.Text = "Costo de ventas"
        '
        'txtgastos_ve
        '
        Me.txtgastos_ve.BackColor = System.Drawing.Color.White
        Me.txtgastos_ve.Location = New System.Drawing.Point(228, 316)
        Me.txtgastos_ve.Name = "txtgastos_ve"
        Me.txtgastos_ve.ReadOnly = True
        Me.txtgastos_ve.Size = New System.Drawing.Size(100, 23)
        Me.txtgastos_ve.TabIndex = 245
        Me.txtgastos_ve.Text = "0.00"
        Me.txtgastos_ve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtutilidad_im
        '
        Me.txtutilidad_im.BackColor = System.Drawing.Color.White
        Me.txtutilidad_im.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad_im.Location = New System.Drawing.Point(228, 344)
        Me.txtutilidad_im.Name = "txtutilidad_im"
        Me.txtutilidad_im.ReadOnly = True
        Me.txtutilidad_im.Size = New System.Drawing.Size(100, 23)
        Me.txtutilidad_im.TabIndex = 246
        Me.txtutilidad_im.Text = "0.00"
        Me.txtutilidad_im.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtimpuestos
        '
        Me.txtimpuestos.Location = New System.Drawing.Point(228, 372)
        Me.txtimpuestos.Name = "txtimpuestos"
        Me.txtimpuestos.Size = New System.Drawing.Size(100, 23)
        Me.txtimpuestos.TabIndex = 247
        Me.txtimpuestos.Text = "0.00"
        Me.txtimpuestos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 236)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 15)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Utilidad bruta"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 264)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 15)
        Me.Label9.TabIndex = 249
        Me.Label9.Text = "Gastos administrativos"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 292)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 15)
        Me.Label10.TabIndex = 250
        Me.Label10.Text = "Gastos operativos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 320)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 251
        Me.Label11.Text = "Gastos de venta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 348)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(160, 15)
        Me.Label12.TabIndex = 252
        Me.Label12.Text = "Utilidad antes de impuestos"
        '
        'txtutilidad
        '
        Me.txtutilidad.BackColor = System.Drawing.Color.White
        Me.txtutilidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilidad.Location = New System.Drawing.Point(228, 400)
        Me.txtutilidad.Name = "txtutilidad"
        Me.txtutilidad.ReadOnly = True
        Me.txtutilidad.Size = New System.Drawing.Size(100, 23)
        Me.txtutilidad.TabIndex = 253
        Me.txtutilidad.Text = "0.00"
        Me.txtutilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 376)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 254
        Me.Label13.Text = "Impuestos"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 404)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(78, 15)
        Me.Label14.TabIndex = 255
        Me.Label14.Text = "Utilidad neta"
        '
        'dtpinicio
        '
        Me.dtpinicio.Location = New System.Drawing.Point(12, 60)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.Size = New System.Drawing.Size(152, 23)
        Me.dtpinicio.TabIndex = 257
        '
        'dtpfinal
        '
        Me.dtpfinal.Location = New System.Drawing.Point(176, 60)
        Me.dtpfinal.Name = "dtpfinal"
        Me.dtpfinal.Size = New System.Drawing.Size(152, 23)
        Me.dtpfinal.TabIndex = 258
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 42)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 15)
        Me.Label15.TabIndex = 259
        Me.Label15.Text = "Fecha inicial"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(179, 42)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 15)
        Me.Label16.TabIndex = 260
        Me.Label16.Text = "Fecha final"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(264, 432)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 73)
        Me.Button1.TabIndex = 261
        Me.Button1.Text = "Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(194, 432)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(64, 73)
        Me.Button2.TabIndex = 262
        Me.Button2.Text = "Generar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(124, 432)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(64, 73)
        Me.Button3.TabIndex = 263
        Me.Button3.Text = "Limpiar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmEstResultados
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(341, 517)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dtpfinal)
        Me.Controls.Add(Me.dtpinicio)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtutilidad)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtimpuestos)
        Me.Controls.Add(Me.txtutilidad_im)
        Me.Controls.Add(Me.txtgastos_ve)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtgastos_op)
        Me.Controls.Add(Me.txtgastos_ad)
        Me.Controls.Add(Me.txtutilidad_bruta)
        Me.Controls.Add(Me.txtcosto)
        Me.Controls.Add(Me.txtventas_n)
        Me.Controls.Add(Me.txtdescu)
        Me.Controls.Add(Me.txtdevos)
        Me.Controls.Add(Me.txtventas)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstResultados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de resultados"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtventas As System.Windows.Forms.TextBox
    Friend WithEvents txtdevos As System.Windows.Forms.TextBox
    Friend WithEvents txtdescu As System.Windows.Forms.TextBox
    Friend WithEvents txtventas_n As System.Windows.Forms.TextBox
    Friend WithEvents txtcosto As System.Windows.Forms.TextBox
    Friend WithEvents txtutilidad_bruta As System.Windows.Forms.TextBox
    Friend WithEvents txtgastos_ad As System.Windows.Forms.TextBox
    Friend WithEvents txtgastos_op As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtgastos_ve As System.Windows.Forms.TextBox
    Friend WithEvents txtutilidad_im As System.Windows.Forms.TextBox
    Friend WithEvents txtimpuestos As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtutilidad As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
