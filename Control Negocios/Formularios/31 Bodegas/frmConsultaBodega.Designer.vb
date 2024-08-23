<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaBodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaBodega))
        Me.lbldescripcion = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtprecio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnext = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtinicio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtid_cliente = New System.Windows.Forms.TextBox()
        Me.txtdueño = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdimensiones = New System.Windows.Forms.TextBox()
        Me.txtplanta = New System.Windows.Forms.TextBox()
        Me.txtbodega = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbovisitas = New System.Windows.Forms.ComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbldescripcion
        '
        Me.lbldescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.lbldescripcion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescripcion.ForeColor = System.Drawing.Color.White
        Me.lbldescripcion.Location = New System.Drawing.Point(3, 29)
        Me.lbldescripcion.Name = "lbldescripcion"
        Me.lbldescripcion.Size = New System.Drawing.Size(609, 22)
        Me.lbldescripcion.TabIndex = 33
        Me.lbldescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(7, 6)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(65, 20)
        Me.txtID.TabIndex = 45
        Me.txtID.Visible = False
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(424, 4)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 22)
        Me.lblusuario.TabIndex = 51
        Me.lblusuario.Text = "USUARIO"
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(524, 6)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsuario.Size = New System.Drawing.Size(88, 20)
        Me.txtUsuario.TabIndex = 50
        Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtprecio)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtnext)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtinicio)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtid_cliente)
        Me.Panel1.Controls.Add(Me.txtdueño)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtdimensiones)
        Me.Panel1.Controls.Add(Me.txtplanta)
        Me.Panel1.Controls.Add(Me.txtbodega)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(610, 106)
        Me.Panel1.TabIndex = 52
        '
        'txtprecio
        '
        Me.txtprecio.Location = New System.Drawing.Point(512, 69)
        Me.txtprecio.Name = "txtprecio"
        Me.txtprecio.ReadOnly = True
        Me.txtprecio.Size = New System.Drawing.Size(91, 25)
        Me.txtprecio.TabIndex = 25
        Me.txtprecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(421, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Precio x mes:"
        '
        'txtnext
        '
        Me.txtnext.Location = New System.Drawing.Point(315, 69)
        Me.txtnext.Name = "txtnext"
        Me.txtnext.ReadOnly = True
        Me.txtnext.Size = New System.Drawing.Size(98, 25)
        Me.txtnext.TabIndex = 23
        Me.txtnext.Text = "12/58/2022"
        Me.txtnext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(215, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Próximo pago:"
        '
        'txtinicio
        '
        Me.txtinicio.Location = New System.Drawing.Point(109, 69)
        Me.txtinicio.Name = "txtinicio"
        Me.txtinicio.ReadOnly = True
        Me.txtinicio.Size = New System.Drawing.Size(98, 25)
        Me.txtinicio.TabIndex = 21
        Me.txtinicio.Text = "12/58/2022"
        Me.txtinicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Inicio de renta:"
        '
        'txtid_cliente
        '
        Me.txtid_cliente.Location = New System.Drawing.Point(545, 38)
        Me.txtid_cliente.Name = "txtid_cliente"
        Me.txtid_cliente.ReadOnly = True
        Me.txtid_cliente.Size = New System.Drawing.Size(58, 25)
        Me.txtid_cliente.TabIndex = 19
        '
        'txtdueño
        '
        Me.txtdueño.Location = New System.Drawing.Point(96, 38)
        Me.txtdueño.Name = "txtdueño"
        Me.txtdueño.ReadOnly = True
        Me.txtdueño.Size = New System.Drawing.Size(443, 25)
        Me.txtdueño.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Titular:"
        '
        'txtdimensiones
        '
        Me.txtdimensiones.Location = New System.Drawing.Point(474, 7)
        Me.txtdimensiones.Name = "txtdimensiones"
        Me.txtdimensiones.ReadOnly = True
        Me.txtdimensiones.Size = New System.Drawing.Size(129, 25)
        Me.txtdimensiones.TabIndex = 16
        Me.txtdimensiones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtplanta
        '
        Me.txtplanta.Location = New System.Drawing.Point(267, 7)
        Me.txtplanta.Name = "txtplanta"
        Me.txtplanta.ReadOnly = True
        Me.txtplanta.Size = New System.Drawing.Size(110, 25)
        Me.txtplanta.TabIndex = 15
        '
        'txtbodega
        '
        Me.txtbodega.Location = New System.Drawing.Point(96, 7)
        Me.txtbodega.Name = "txtbodega"
        Me.txtbodega.ReadOnly = True
        Me.txtbodega.Size = New System.Drawing.Size(88, 25)
        Me.txtbodega.TabIndex = 14
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(383, 11)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 17)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Dimensiones:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(193, 11)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 17)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Ubicación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 17)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "No. Bodega:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(367, 20)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "¿Deseas terminar el servicio de renta de esta bodega?"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.MistyRose
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(470, 209)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 28)
        Me.Button3.TabIndex = 58
        Me.Button3.Text = "Terminar renta"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(339, 166)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(129, 23)
        Me.lblFecha.TabIndex = 53
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightCoral
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(546, 166)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 37)
        Me.Button2.TabIndex = 57
        Me.Button2.Text = "Salida"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PaleGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(470, 166)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 37)
        Me.Button1.TabIndex = 56
        Me.Button1.Text = "Entrada"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 17)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Visitante:"
        '
        'cbovisitas
        '
        Me.cbovisitas.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbovisitas.FormattingEnabled = True
        Me.cbovisitas.Location = New System.Drawing.Point(72, 166)
        Me.cbovisitas.Name = "cbovisitas"
        Me.cbovisitas.Size = New System.Drawing.Size(261, 23)
        Me.cbovisitas.TabIndex = 54
        '
        'Timer1
        '
        '
        'frmConsultaBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(620, 247)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbovisitas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lbldescripcion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Bodega"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbldescripcion As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtprecio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtnext As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtinicio As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtid_cliente As TextBox
    Friend WithEvents txtdueño As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtdimensiones As TextBox
    Friend WithEvents txtplanta As TextBox
    Friend WithEvents txtbodega As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents lblFecha As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cbovisitas As ComboBox
    Friend WithEvents Timer1 As Timer
End Class
