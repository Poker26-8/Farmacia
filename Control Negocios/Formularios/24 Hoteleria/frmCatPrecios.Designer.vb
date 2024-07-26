<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatPrecios))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDescripcion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPrecio1 = New System.Windows.Forms.TextBox()
        Me.txtPrecio2 = New System.Windows.Forms.TextBox()
        Me.txtPrecio3 = New System.Windows.Forms.TextBox()
        Me.txtPrecio4 = New System.Windows.Forms.TextBox()
        Me.txtPrecio5 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtHoras = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 32)
        Me.Panel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtHoras)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtPrecio5)
        Me.Panel2.Controls.Add(Me.txtPrecio4)
        Me.Panel2.Controls.Add(Me.txtPrecio3)
        Me.Panel2.Controls.Add(Me.txtPrecio2)
        Me.Panel2.Controls.Add(Me.txtPrecio1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cboDescripcion)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(248, 374)
        Me.Panel2.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripción"
        '
        'cboDescripcion
        '
        Me.cboDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDescripcion.FormattingEnabled = True
        Me.cboDescripcion.Location = New System.Drawing.Point(7, 30)
        Me.cboDescripcion.Name = "cboDescripcion"
        Me.cboDescripcion.Size = New System.Drawing.Size(234, 26)
        Me.cboDescripcion.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Precio 1:"
        '
        'txtPrecio1
        '
        Me.txtPrecio1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio1.Location = New System.Drawing.Point(98, 99)
        Me.txtPrecio1.Name = "txtPrecio1"
        Me.txtPrecio1.Size = New System.Drawing.Size(143, 22)
        Me.txtPrecio1.TabIndex = 3
        Me.txtPrecio1.Text = "0.00"
        Me.txtPrecio1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio2
        '
        Me.txtPrecio2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio2.Location = New System.Drawing.Point(98, 138)
        Me.txtPrecio2.Name = "txtPrecio2"
        Me.txtPrecio2.Size = New System.Drawing.Size(143, 22)
        Me.txtPrecio2.TabIndex = 4
        Me.txtPrecio2.Text = "0.00"
        Me.txtPrecio2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio3
        '
        Me.txtPrecio3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio3.Location = New System.Drawing.Point(98, 176)
        Me.txtPrecio3.Name = "txtPrecio3"
        Me.txtPrecio3.Size = New System.Drawing.Size(143, 22)
        Me.txtPrecio3.TabIndex = 5
        Me.txtPrecio3.Text = "0.00"
        Me.txtPrecio3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio4
        '
        Me.txtPrecio4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio4.Location = New System.Drawing.Point(98, 213)
        Me.txtPrecio4.Name = "txtPrecio4"
        Me.txtPrecio4.Size = New System.Drawing.Size(143, 22)
        Me.txtPrecio4.TabIndex = 6
        Me.txtPrecio4.Text = "0.00"
        Me.txtPrecio4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrecio5
        '
        Me.txtPrecio5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio5.Location = New System.Drawing.Point(98, 252)
        Me.txtPrecio5.Name = "txtPrecio5"
        Me.txtPrecio5.Size = New System.Drawing.Size(143, 22)
        Me.txtPrecio5.TabIndex = 7
        Me.txtPrecio5.Text = "0.00"
        Me.txtPrecio5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Precio 2:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 24)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Precio 3:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 24)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Precio 4:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 24)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Precio 5:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Horas:"
        '
        'txtHoras
        '
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.Location = New System.Drawing.Point(98, 62)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(143, 22)
        Me.txtHoras.TabIndex = 16
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(23, 289)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 74)
        Me.btnLimpiar.TabIndex = 14
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(98, 289)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(69, 74)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(172, 289)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(69, 74)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmCatPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(248, 412)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatPrecios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cboDescripcion As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPrecio5 As TextBox
    Friend WithEvents txtPrecio4 As TextBox
    Friend WithEvents txtPrecio3 As TextBox
    Friend WithEvents txtPrecio2 As TextBox
    Friend WithEvents txtPrecio1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents txtHoras As TextBox
    Friend WithEvents Label7 As Label
End Class
