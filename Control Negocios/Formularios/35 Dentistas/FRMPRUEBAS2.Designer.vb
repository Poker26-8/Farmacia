<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMPRUEBAS2
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn1arr = New System.Windows.Forms.Button()
        Me.btn1cen = New System.Windows.Forms.Button()
        Me.btn1aba = New System.Windows.Forms.Button()
        Me.btn1der = New System.Windows.Forms.Button()
        Me.btn1izq = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(10, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn1arr
        '
        Me.btn1arr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1arr.Location = New System.Drawing.Point(181, 39)
        Me.btn1arr.Name = "btn1arr"
        Me.btn1arr.Size = New System.Drawing.Size(57, 14)
        Me.btn1arr.TabIndex = 2
        Me.btn1arr.UseVisualStyleBackColor = True
        '
        'btn1cen
        '
        Me.btn1cen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1cen.Location = New System.Drawing.Point(197, 57)
        Me.btn1cen.Name = "btn1cen"
        Me.btn1cen.Size = New System.Drawing.Size(25, 27)
        Me.btn1cen.TabIndex = 3
        Me.btn1cen.UseVisualStyleBackColor = True
        '
        'btn1aba
        '
        Me.btn1aba.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1aba.Location = New System.Drawing.Point(181, 88)
        Me.btn1aba.Name = "btn1aba"
        Me.btn1aba.Size = New System.Drawing.Size(57, 11)
        Me.btn1aba.TabIndex = 4
        Me.btn1aba.UseVisualStyleBackColor = True
        '
        'btn1der
        '
        Me.btn1der.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1der.Location = New System.Drawing.Point(228, 53)
        Me.btn1der.Name = "btn1der"
        Me.btn1der.Size = New System.Drawing.Size(10, 35)
        Me.btn1der.TabIndex = 5
        Me.btn1der.UseVisualStyleBackColor = True
        '
        'btn1izq
        '
        Me.btn1izq.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1izq.Location = New System.Drawing.Point(181, 53)
        Me.btn1izq.Name = "btn1izq"
        Me.btn1izq.Size = New System.Drawing.Size(10, 35)
        Me.btn1izq.TabIndex = 6
        Me.btn1izq.UseVisualStyleBackColor = True
        '
        'FRMPRUEBAS2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn1izq)
        Me.Controls.Add(Me.btn1der)
        Me.Controls.Add(Me.btn1aba)
        Me.Controls.Add(Me.btn1cen)
        Me.Controls.Add(Me.btn1arr)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FRMPRUEBAS2"
        Me.Text = "FRMPRUEBAS2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn1arr As Button
    Friend WithEvents btn1cen As Button
    Friend WithEvents btn1aba As Button
    Friend WithEvents btn1der As Button
    Friend WithEvents btn1izq As Button
End Class
