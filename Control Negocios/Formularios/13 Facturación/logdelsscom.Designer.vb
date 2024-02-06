<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class logdelsscom
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
        Me.pass_txt = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pass_txt
        '
        Me.pass_txt.Location = New System.Drawing.Point(15, 13)
        Me.pass_txt.Name = "pass_txt"
        Me.pass_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pass_txt.Size = New System.Drawing.Size(149, 20)
        Me.pass_txt.TabIndex = 3
        '
        'btn_ok
        '
        Me.btn_ok.Location = New System.Drawing.Point(170, 12)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(52, 23)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "ok"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'logdelsscom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(237, 47)
        Me.Controls.Add(Me.pass_txt)
        Me.Controls.Add(Me.btn_ok)
        Me.Name = "logdelsscom"
        Me.Text = "logdelsscom"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pass_txt As TextBox
    Friend WithEvents btn_ok As Button
End Class
