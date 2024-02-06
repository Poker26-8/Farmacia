<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigRecargas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigRecargas))
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.txtusuario = New System.Windows.Forms.TextBox()
        Me.txtcontra = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtnumero
        '
        Me.txtnumero.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumero.Location = New System.Drawing.Point(138, 41)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(178, 23)
        Me.txtnumero.TabIndex = 27
        '
        'Button25
        '
        Me.Button25.BackColor = System.Drawing.Color.White
        Me.Button25.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button25.Image = CType(resources.GetObject("Button25.Image"), System.Drawing.Image)
        Me.Button25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button25.Location = New System.Drawing.Point(223, 128)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(93, 44)
        Me.Button25.TabIndex = 26
        Me.Button25.Text = "Guardar"
        Me.Button25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button25.UseVisualStyleBackColor = False
        '
        'txtusuario
        '
        Me.txtusuario.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusuario.Location = New System.Drawing.Point(138, 70)
        Me.txtusuario.Name = "txtusuario"
        Me.txtusuario.Size = New System.Drawing.Size(178, 23)
        Me.txtusuario.TabIndex = 25
        '
        'txtcontra
        '
        Me.txtcontra.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcontra.Location = New System.Drawing.Point(138, 99)
        Me.txtcontra.Name = "txtcontra"
        Me.txtcontra.Size = New System.Drawing.Size(178, 23)
        Me.txtcontra.TabIndex = 24
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(14, 103)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(70, 15)
        Me.Label75.TabIndex = 23
        Me.Label75.Text = "Contraseña:"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(14, 74)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(50, 15)
        Me.Label74.TabIndex = 22
        Me.Label74.Text = "Usuario:"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(14, 45)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(110, 15)
        Me.Label72.TabIndex = 21
        Me.Label72.Text = "Numero telefonico:"
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
        Me.Label57.Size = New System.Drawing.Size(331, 31)
        Me.Label57.TabIndex = 232
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid.Location = New System.Drawing.Point(134, 132)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(0, 21)
        Me.lblid.TabIndex = 233
        '
        'frmConfigRecargas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(331, 173)
        Me.Controls.Add(Me.lblid)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.txtnumero)
        Me.Controls.Add(Me.Button25)
        Me.Controls.Add(Me.txtusuario)
        Me.Controls.Add(Me.txtcontra)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Label74)
        Me.Controls.Add(Me.Label72)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfigRecargas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de acceso a recargas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtnumero As TextBox
    Friend WithEvents Button25 As Button
    Friend WithEvents txtusuario As TextBox
    Friend WithEvents txtcontra As TextBox
    Friend WithEvents Label75 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents lblid As Label
End Class
