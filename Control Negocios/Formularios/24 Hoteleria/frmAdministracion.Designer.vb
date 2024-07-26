<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAdministracion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdministracion))
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblidu = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtContra = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbousuario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbPrecios = New System.Windows.Forms.CheckBox()
        Me.cbCambioH = New System.Windows.Forms.CheckBox()
        Me.cbDesbloqueo = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btng2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPrecioAumento = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttole = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(284, 107)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 78)
        Me.btnLimpiar.TabIndex = 239
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblidu)
        Me.Panel2.Controls.Add(Me.lblusuario)
        Me.Panel2.Controls.Add(Me.txtContra)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbousuario)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 31)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(526, 70)
        Me.Panel2.TabIndex = 235
        '
        'lblidu
        '
        Me.lblidu.BackColor = System.Drawing.Color.RosyBrown
        Me.lblidu.Location = New System.Drawing.Point(75, 36)
        Me.lblidu.Name = "lblidu"
        Me.lblidu.Size = New System.Drawing.Size(100, 23)
        Me.lblidu.TabIndex = 97
        Me.lblidu.Visible = False
        '
        'lblusuario
        '
        Me.lblusuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblusuario.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.lblusuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.Location = New System.Drawing.Point(268, 36)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(115, 25)
        Me.lblusuario.TabIndex = 96
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtContra
        '
        Me.txtContra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContra.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContra.Location = New System.Drawing.Point(385, 37)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(136, 24)
        Me.txtContra.TabIndex = 95
        Me.txtContra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtContra.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(385, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 22)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "CONTRASEÑA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbousuario
        '
        Me.cbousuario.FormattingEnabled = True
        Me.cbousuario.Location = New System.Drawing.Point(74, 12)
        Me.cbousuario.Name = "cbousuario"
        Me.cbousuario.Size = New System.Drawing.Size(309, 21)
        Me.cbousuario.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Usuario:"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label57.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label57.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.Color.White
        Me.Label57.Location = New System.Drawing.Point(0, 0)
        Me.Label57.Name = "Label57"
        Me.Label57.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label57.Size = New System.Drawing.Size(526, 31)
        Me.Label57.TabIndex = 238
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(365, 107)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 78)
        Me.btnGuardar.TabIndex = 237
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
        Me.btnSalir.Location = New System.Drawing.Point(446, 107)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 78)
        Me.btnSalir.TabIndex = 236
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbPrecios)
        Me.Panel1.Controls.Add(Me.cbCambioH)
        Me.Panel1.Controls.Add(Me.cbDesbloqueo)
        Me.Panel1.Location = New System.Drawing.Point(4, 107)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(266, 78)
        Me.Panel1.TabIndex = 234
        '
        'cbPrecios
        '
        Me.cbPrecios.AutoSize = True
        Me.cbPrecios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPrecios.Location = New System.Drawing.Point(6, 55)
        Me.cbPrecios.Name = "cbPrecios"
        Me.cbPrecios.Size = New System.Drawing.Size(72, 20)
        Me.cbPrecios.TabIndex = 2
        Me.cbPrecios.Text = "Precios"
        Me.cbPrecios.UseVisualStyleBackColor = True
        '
        'cbCambioH
        '
        Me.cbCambioH.AutoSize = True
        Me.cbCambioH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCambioH.Location = New System.Drawing.Point(6, 29)
        Me.cbCambioH.Name = "cbCambioH"
        Me.cbCambioH.Size = New System.Drawing.Size(157, 20)
        Me.cbCambioH.TabIndex = 1
        Me.cbCambioH.Text = "Cambio de habitación"
        Me.cbCambioH.UseVisualStyleBackColor = True
        '
        'cbDesbloqueo
        '
        Me.cbDesbloqueo.AutoSize = True
        Me.cbDesbloqueo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDesbloqueo.Location = New System.Drawing.Point(6, 3)
        Me.cbDesbloqueo.Name = "cbDesbloqueo"
        Me.cbDesbloqueo.Size = New System.Drawing.Size(185, 20)
        Me.cbDesbloqueo.TabIndex = 0
        Me.cbDesbloqueo.Text = "Desbloqueo de habitación"
        Me.cbDesbloqueo.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btng2)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.txtPrecioAumento)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.dtpinicio)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txttole)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(221, 191)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(300, 184)
        Me.Panel3.TabIndex = 240
        '
        'btng2
        '
        Me.btng2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btng2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btng2.Image = CType(resources.GetObject("btng2.Image"), System.Drawing.Image)
        Me.btng2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btng2.Location = New System.Drawing.Point(220, 114)
        Me.btng2.Name = "btng2"
        Me.btng2.Size = New System.Drawing.Size(75, 58)
        Me.btng2.TabIndex = 241
        Me.btng2.Text = "Guardar"
        Me.btng2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btng2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(103, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 20)
        Me.Label6.TabIndex = 240
        Me.Label6.Text = "Configuraciones"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(300, 27)
        Me.Label5.TabIndex = 239
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPrecioAumento
        '
        Me.txtPrecioAumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioAumento.Location = New System.Drawing.Point(209, 86)
        Me.txtPrecioAumento.Name = "txtPrecioAumento"
        Me.txtPrecioAumento.Size = New System.Drawing.Size(86, 22)
        Me.txtPrecioAumento.TabIndex = 223
        Me.txtPrecioAumento.Text = "0.00"
        Me.txtPrecioAumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(31, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 18)
        Me.Label13.TabIndex = 222
        Me.Label13.Text = "Precio Dia/Hospedaje"
        '
        'dtpinicio
        '
        Me.dtpinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpinicio.Location = New System.Drawing.Point(163, 58)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.ShowUpDown = True
        Me.dtpinicio.Size = New System.Drawing.Size(132, 22)
        Me.dtpinicio.TabIndex = 217
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(161, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 18)
        Me.Label8.TabIndex = 216
        Me.Label8.Text = "Salida hospedaje"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 18)
        Me.Label3.TabIndex = 215
        Me.Label3.Text = "Minutos"
        '
        'txttole
        '
        Me.txttole.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttole.Location = New System.Drawing.Point(6, 58)
        Me.txttole.Name = "txttole"
        Me.txttole.Size = New System.Drawing.Size(151, 22)
        Me.txttole.TabIndex = 214
        Me.txttole.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 18)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Tolerancia"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(4, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 89)
        Me.Button1.TabIndex = 241
        Me.Button1.Text = "Precios"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmAdministracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(526, 379)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnLimpiar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAdministracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblidu As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents txtContra As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbousuario As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cbCambioH As CheckBox
    Friend WithEvents cbDesbloqueo As CheckBox
    Friend WithEvents cbPrecios As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txttole As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpinicio As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPrecioAumento As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btng2 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
End Class
