<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptica
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
        Me.btnDoctor = New System.Windows.Forms.Button()
        Me.btnOptica = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDoctor
        '
        Me.btnDoctor.BackColor = System.Drawing.Color.White
        Me.btnDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDoctor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDoctor.Location = New System.Drawing.Point(1, 2)
        Me.btnDoctor.Name = "btnDoctor"
        Me.btnDoctor.Size = New System.Drawing.Size(84, 78)
        Me.btnDoctor.TabIndex = 0
        Me.btnDoctor.Text = "Paciente"
        Me.btnDoctor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDoctor.UseVisualStyleBackColor = False
        '
        'btnOptica
        '
        Me.btnOptica.BackColor = System.Drawing.Color.White
        Me.btnOptica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOptica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOptica.Location = New System.Drawing.Point(91, 2)
        Me.btnOptica.Name = "btnOptica"
        Me.btnOptica.Size = New System.Drawing.Size(84, 78)
        Me.btnOptica.TabIndex = 1
        Me.btnOptica.Text = "Registros"
        Me.btnOptica.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOptica.UseVisualStyleBackColor = False
        '
        'frmOptica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(181, 87)
        Me.Controls.Add(Me.btnOptica)
        Me.Controls.Add(Me.btnDoctor)
        Me.Name = "frmOptica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opticas"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDoctor As Button
    Friend WithEvents btnOptica As Button
End Class
