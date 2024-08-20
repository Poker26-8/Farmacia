<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnvio_Corte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnvio_Corte))
        Me.btnenvia = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtmensaje = New System.Windows.Forms.RichTextBox()
        Me.link_archivo = New System.Windows.Forms.LinkLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtasunto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpara = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnenvia
        '
        Me.btnenvia.BackColor = System.Drawing.Color.White
        Me.btnenvia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnenvia.Location = New System.Drawing.Point(200, 336)
        Me.btnenvia.Name = "btnenvia"
        Me.btnenvia.Size = New System.Drawing.Size(173, 56)
        Me.btnenvia.TabIndex = 19
        Me.btnenvia.Text = "Enviar"
        Me.btnenvia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnenvia.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtmensaje)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 189)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(362, 141)
        Me.GroupBox3.TabIndex = 18
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Mensaje:"
        '
        'txtmensaje
        '
        Me.txtmensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtmensaje.Location = New System.Drawing.Point(3, 19)
        Me.txtmensaje.Name = "txtmensaje"
        Me.txtmensaje.Size = New System.Drawing.Size(356, 119)
        Me.txtmensaje.TabIndex = 0
        Me.txtmensaje.Text = ""
        '
        'link_archivo
        '
        Me.link_archivo.AutoSize = True
        Me.link_archivo.Location = New System.Drawing.Point(15, 161)
        Me.link_archivo.Name = "link_archivo"
        Me.link_archivo.Size = New System.Drawing.Size(72, 15)
        Me.link_archivo.TabIndex = 17
        Me.link_archivo.TabStop = True
        Me.link_archivo.Text = "Archivo PDF"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtasunto)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(362, 53)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Asunto:"
        '
        'txtasunto
        '
        Me.txtasunto.Location = New System.Drawing.Point(7, 20)
        Me.txtasunto.Name = "txtasunto"
        Me.txtasunto.Size = New System.Drawing.Size(349, 23)
        Me.txtasunto.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBox1.Controls.Add(Me.txtpara)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(362, 53)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Para:"
        '
        'txtpara
        '
        Me.txtpara.Location = New System.Drawing.Point(7, 20)
        Me.txtpara.Name = "txtpara"
        Me.txtpara.Size = New System.Drawing.Size(349, 23)
        Me.txtpara.TabIndex = 0
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
        Me.Label1.Size = New System.Drawing.Size(384, 36)
        Me.Label1.TabIndex = 22
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmEnvio_Corte
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 404)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnenvia)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.link_archivo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEnvio_Corte"
        Me.Text = "Enviar Corte"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnenvia As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtmensaje As RichTextBox
    Friend WithEvents link_archivo As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtasunto As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtpara As TextBox
    Friend WithEvents Label1 As Label
End Class
