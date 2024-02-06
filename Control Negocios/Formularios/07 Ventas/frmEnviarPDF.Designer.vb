<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnviarPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnviarPDF))
        Me.btnenvia = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btncancela = New System.Windows.Forms.Button()
        Me.link_archivo = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtasunto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpara = New System.Windows.Forms.TextBox()
        Me.txtmensaje = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnenvia
        '
        Me.btnenvia.BackColor = System.Drawing.Color.White
        Me.btnenvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnenvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnenvia.Image = CType(resources.GetObject("btnenvia.Image"), System.Drawing.Image)
        Me.btnenvia.Location = New System.Drawing.Point(14, 351)
        Me.btnenvia.Name = "btnenvia"
        Me.btnenvia.Size = New System.Drawing.Size(173, 56)
        Me.btnenvia.TabIndex = 13
        Me.btnenvia.Text = "Enviar"
        Me.btnenvia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnenvia.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(111, 176)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(68, 13)
        Me.LinkLabel1.TabIndex = 21
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Archivo XML"
        Me.LinkLabel1.Visible = False
        '
        'btncancela
        '
        Me.btncancela.BackColor = System.Drawing.Color.White
        Me.btncancela.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancela.Image = CType(resources.GetObject("btncancela.Image"), System.Drawing.Image)
        Me.btncancela.Location = New System.Drawing.Point(194, 351)
        Me.btncancela.Name = "btncancela"
        Me.btncancela.Size = New System.Drawing.Size(173, 56)
        Me.btncancela.TabIndex = 20
        Me.btncancela.Text = "Cancelar"
        Me.btncancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btncancela.UseVisualStyleBackColor = False
        '
        'link_archivo
        '
        Me.link_archivo.AutoSize = True
        Me.link_archivo.Location = New System.Drawing.Point(15, 176)
        Me.link_archivo.Name = "link_archivo"
        Me.link_archivo.Size = New System.Drawing.Size(67, 13)
        Me.link_archivo.TabIndex = 18
        Me.link_archivo.TabStop = True
        Me.link_archivo.Text = "Archivo PDF"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtasunto)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 108)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 53)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Asunto:"
        '
        'txtasunto
        '
        Me.txtasunto.Location = New System.Drawing.Point(7, 20)
        Me.txtasunto.Name = "txtasunto"
        Me.txtasunto.Size = New System.Drawing.Size(349, 20)
        Me.txtasunto.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.txtpara)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 53)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Para:"
        '
        'txtpara
        '
        Me.txtpara.Location = New System.Drawing.Point(7, 20)
        Me.txtpara.Name = "txtpara"
        Me.txtpara.Size = New System.Drawing.Size(349, 20)
        Me.txtpara.TabIndex = 0
        '
        'txtmensaje
        '
        Me.txtmensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtmensaje.Location = New System.Drawing.Point(3, 16)
        Me.txtmensaje.Name = "txtmensaje"
        Me.txtmensaje.Size = New System.Drawing.Size(356, 122)
        Me.txtmensaje.TabIndex = 0
        Me.txtmensaje.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtmensaje)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(362, 141)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensaje:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(385, 36)
        Me.Label1.TabIndex = 15
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmEnviarPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(385, 416)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btncancela)
        Me.Controls.Add(Me.link_archivo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnenvia)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEnviarPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enviar Correo"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnenvia As Button
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents btncancela As Button
    Friend WithEvents link_archivo As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtasunto As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtpara As TextBox
    Friend WithEvents txtmensaje As RichTextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label1 As Label
End Class
