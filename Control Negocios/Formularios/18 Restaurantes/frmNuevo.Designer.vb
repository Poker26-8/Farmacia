<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevo
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
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'pmesas
        '
        Me.pmesas.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pmesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pmesas.Location = New System.Drawing.Point(0, 100)
        Me.pmesas.Name = "pmesas"
        Me.pmesas.Size = New System.Drawing.Size(730, 540)
        Me.pmesas.TabIndex = 0
        '
        'psuperior
        '
        Me.psuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.psuperior.Location = New System.Drawing.Point(0, 0)
        Me.psuperior.Name = "psuperior"
        Me.psuperior.Size = New System.Drawing.Size(930, 100)
        Me.psuperior.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(730, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 540)
        Me.Panel1.TabIndex = 1
        '
        'frmNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 640)
        Me.Controls.Add(Me.pmesas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.psuperior)
        Me.Name = "frmNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNuevo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pmesas As Panel
    Friend WithEvents psuperior As Panel
    Friend WithEvents Panel1 As Panel
End Class
