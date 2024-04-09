<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMesero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMesero))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAcceder = New System.Windows.Forms.Button()
        Me.btnpunto = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btn0 = New System.Windows.Forms.Button()
        Me.btn5 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn8 = New System.Windows.Forms.Button()
        Me.btn6 = New System.Windows.Forms.Button()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn9 = New System.Windows.Forms.Button()
        Me.btn4 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn7 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAcceder)
        Me.Panel1.Controls.Add(Me.btnpunto)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.txtClave)
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btn0)
        Me.Panel1.Controls.Add(Me.btn5)
        Me.Panel1.Controls.Add(Me.btn2)
        Me.Panel1.Controls.Add(Me.btn8)
        Me.Panel1.Controls.Add(Me.btn6)
        Me.Panel1.Controls.Add(Me.btn3)
        Me.Panel1.Controls.Add(Me.btn9)
        Me.Panel1.Controls.Add(Me.btn4)
        Me.Panel1.Controls.Add(Me.btn1)
        Me.Panel1.Controls.Add(Me.btn7)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(345, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(279, 450)
        Me.Panel1.TabIndex = 15
        '
        'btnAcceder
        '
        Me.btnAcceder.BackColor = System.Drawing.Color.White
        Me.btnAcceder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAcceder.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAcceder.Image = CType(resources.GetObject("btnAcceder.Image"), System.Drawing.Image)
        Me.btnAcceder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAcceder.Location = New System.Drawing.Point(10, 380)
        Me.btnAcceder.Name = "btnAcceder"
        Me.btnAcceder.Size = New System.Drawing.Size(258, 61)
        Me.btnAcceder.TabIndex = 29
        Me.btnAcceder.Text = "Acceder"
        Me.btnAcceder.UseVisualStyleBackColor = False
        '
        'btnpunto
        '
        Me.btnpunto.BackColor = System.Drawing.Color.White
        Me.btnpunto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnpunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpunto.Location = New System.Drawing.Point(10, 300)
        Me.btnpunto.Name = "btnpunto"
        Me.btnpunto.Size = New System.Drawing.Size(82, 74)
        Me.btnpunto.TabIndex = 28
        Me.btnpunto.Text = "."
        Me.btnpunto.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.Color.White
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(186, 300)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(82, 74)
        Me.btnLimpiar.TabIndex = 27
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(10, 5)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(170, 40)
        Me.txtClave.TabIndex = 26
        '
        'btnBorrar
        '
        Me.btnBorrar.BackColor = System.Drawing.Color.White
        Me.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Location = New System.Drawing.Point(186, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(82, 40)
        Me.btnBorrar.TabIndex = 25
        Me.btnBorrar.Text = "C0"
        Me.btnBorrar.UseVisualStyleBackColor = False
        '
        'btn0
        '
        Me.btn0.BackColor = System.Drawing.Color.White
        Me.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn0.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn0.Location = New System.Drawing.Point(98, 300)
        Me.btn0.Name = "btn0"
        Me.btn0.Size = New System.Drawing.Size(82, 74)
        Me.btn0.TabIndex = 24
        Me.btn0.Text = "0"
        Me.btn0.UseVisualStyleBackColor = False
        '
        'btn5
        '
        Me.btn5.BackColor = System.Drawing.Color.White
        Me.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn5.Location = New System.Drawing.Point(98, 140)
        Me.btn5.Name = "btn5"
        Me.btn5.Size = New System.Drawing.Size(82, 74)
        Me.btn5.TabIndex = 23
        Me.btn5.Text = "5"
        Me.btn5.UseVisualStyleBackColor = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.White
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2.Location = New System.Drawing.Point(98, 220)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(82, 74)
        Me.btn2.TabIndex = 22
        Me.btn2.Text = "2"
        Me.btn2.UseVisualStyleBackColor = False
        '
        'btn8
        '
        Me.btn8.BackColor = System.Drawing.Color.White
        Me.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn8.Location = New System.Drawing.Point(98, 60)
        Me.btn8.Name = "btn8"
        Me.btn8.Size = New System.Drawing.Size(82, 74)
        Me.btn8.TabIndex = 21
        Me.btn8.Text = "8"
        Me.btn8.UseVisualStyleBackColor = False
        '
        'btn6
        '
        Me.btn6.BackColor = System.Drawing.Color.White
        Me.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn6.Location = New System.Drawing.Point(186, 140)
        Me.btn6.Name = "btn6"
        Me.btn6.Size = New System.Drawing.Size(82, 74)
        Me.btn6.TabIndex = 20
        Me.btn6.Text = "6"
        Me.btn6.UseVisualStyleBackColor = False
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.White
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn3.Location = New System.Drawing.Point(186, 220)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(82, 74)
        Me.btn3.TabIndex = 19
        Me.btn3.Text = "3"
        Me.btn3.UseVisualStyleBackColor = False
        '
        'btn9
        '
        Me.btn9.BackColor = System.Drawing.Color.White
        Me.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn9.Location = New System.Drawing.Point(186, 60)
        Me.btn9.Name = "btn9"
        Me.btn9.Size = New System.Drawing.Size(82, 74)
        Me.btn9.TabIndex = 18
        Me.btn9.Text = "9"
        Me.btn9.UseVisualStyleBackColor = False
        '
        'btn4
        '
        Me.btn4.BackColor = System.Drawing.Color.White
        Me.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn4.Location = New System.Drawing.Point(10, 140)
        Me.btn4.Name = "btn4"
        Me.btn4.Size = New System.Drawing.Size(82, 74)
        Me.btn4.TabIndex = 17
        Me.btn4.Text = "4"
        Me.btn4.UseVisualStyleBackColor = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.White
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn1.Location = New System.Drawing.Point(10, 220)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(82, 74)
        Me.btn1.TabIndex = 16
        Me.btn1.Text = "1"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'btn7
        '
        Me.btn7.BackColor = System.Drawing.Color.White
        Me.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn7.Location = New System.Drawing.Point(10, 60)
        Me.btn7.Name = "btn7"
        Me.btn7.Size = New System.Drawing.Size(82, 74)
        Me.btn7.TabIndex = 15
        Me.btn7.Text = "7"
        Me.btn7.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(345, 450)
        Me.Panel2.TabIndex = 16
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(345, 450)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'frmMesero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(624, 450)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMesero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SOFT CONTROL NEGOCIOS PRO"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnAcceder As Button
    Friend WithEvents btnpunto As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents txtClave As TextBox
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
