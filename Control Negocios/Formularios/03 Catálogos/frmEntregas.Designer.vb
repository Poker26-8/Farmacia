<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntregas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.rtbDomicilio = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboConsulta = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnMigrar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(19, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(473, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(71, 41)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(428, 23)
        Me.txtNombre.TabIndex = 8
        '
        'rtbDomicilio
        '
        Me.rtbDomicilio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbDomicilio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbDomicilio.ForeColor = System.Drawing.Color.MediumBlue
        Me.rtbDomicilio.Location = New System.Drawing.Point(71, 70)
        Me.rtbDomicilio.Name = "rtbDomicilio"
        Me.rtbDomicilio.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbDomicilio.Size = New System.Drawing.Size(428, 96)
        Me.rtbDomicilio.TabIndex = 9
        Me.rtbDomicilio.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Domicilio:"
        '
        'cboConsulta
        '
        Me.cboConsulta.FormattingEnabled = True
        Me.cboConsulta.Location = New System.Drawing.Point(71, 172)
        Me.cboConsulta.Name = "cboConsulta"
        Me.cboConsulta.Size = New System.Drawing.Size(95, 23)
        Me.cboConsulta.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Consulta:"
        '
        'btnBorrar
        '
        Me.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBorrar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBorrar.Location = New System.Drawing.Point(241, 172)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(60, 63)
        Me.btnBorrar.TabIndex = 144
        Me.btnBorrar.Text = "Eliminar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(307, 172)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 143
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(373, 173)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 142
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(71, 201)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(95, 23)
        Me.txtId.TabIndex = 145
        Me.txtId.Visible = False
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(439, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 63)
        Me.Button1.TabIndex = 146
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnMigrar
        '
        Me.btnMigrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMigrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMigrar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMigrar.Image = CType(resources.GetObject("btnMigrar.Image"), System.Drawing.Image)
        Me.btnMigrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMigrar.Location = New System.Drawing.Point(175, 172)
        Me.btnMigrar.Name = "btnMigrar"
        Me.btnMigrar.Size = New System.Drawing.Size(60, 63)
        Me.btnMigrar.TabIndex = 147
        Me.btnMigrar.Text = "Access"
        Me.btnMigrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMigrar.UseVisualStyleBackColor = True
        '
        'frmEntregas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(510, 246)
        Me.Controls.Add(Me.btnMigrar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboConsulta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rtbDomicilio)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEntregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Domicilios de entrega"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
     Friend WithEvents Label2 As System.Windows.Forms.Label
     Friend WithEvents txtNombre As System.Windows.Forms.TextBox
     Friend WithEvents rtbDomicilio As System.Windows.Forms.RichTextBox
     Friend WithEvents Label3 As System.Windows.Forms.Label
     Friend WithEvents cboConsulta As System.Windows.Forms.ComboBox
     Friend WithEvents Label4 As System.Windows.Forms.Label
     Friend WithEvents btnBorrar As System.Windows.Forms.Button
     Friend WithEvents btnGuardar As System.Windows.Forms.Button
     Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnMigrar As Button
End Class
