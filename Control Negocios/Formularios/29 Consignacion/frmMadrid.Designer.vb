<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMadrid
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblIdEmpleado = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.pMesas = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblIdEmpleado)
        Me.Panel1.Controls.Add(Me.lblUsuario)
        Me.Panel1.Controls.Add(Me.txtClave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(732, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 579)
        Me.Panel1.TabIndex = 0
        '
        'lblIdEmpleado
        '
        Me.lblIdEmpleado.BackColor = System.Drawing.Color.Orange
        Me.lblIdEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdEmpleado.Location = New System.Drawing.Point(18, 147)
        Me.lblIdEmpleado.Name = "lblIdEmpleado"
        Me.lblIdEmpleado.Size = New System.Drawing.Size(134, 20)
        Me.lblIdEmpleado.TabIndex = 2
        Me.lblIdEmpleado.Text = "4"
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.Orange
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(18, 115)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(135, 23)
        Me.lblUsuario.TabIndex = 1
        Me.lblUsuario.Text = "Usuario"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(22, 82)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(130, 20)
        Me.txtClave.TabIndex = 0
        '
        'pMesas
        '
        Me.pMesas.BackColor = System.Drawing.Color.White
        Me.pMesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pMesas.Location = New System.Drawing.Point(0, 0)
        Me.pMesas.Name = "pMesas"
        Me.pMesas.Size = New System.Drawing.Size(732, 579)
        Me.pMesas.TabIndex = 1
        '
        'frmMadrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 579)
        Me.Controls.Add(Me.pMesas)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMadrid"
        Me.Text = "frmMadrid"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pMesas As Panel
    Friend WithEvents lblIdEmpleado As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents txtClave As TextBox
End Class
