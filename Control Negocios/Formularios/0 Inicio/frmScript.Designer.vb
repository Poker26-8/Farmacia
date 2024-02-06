<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScript
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScript))
        Me.txtCrear_procedimientos = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblBasededatos = New System.Windows.Forms.Label()
        Me.TXTbasededatos = New System.Windows.Forms.TextBox()
        Me.txtservidor = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtnombre_scrypt = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCrear_procedimientos
        '
        Me.txtCrear_procedimientos.Location = New System.Drawing.Point(12, 12)
        Me.txtCrear_procedimientos.Name = "txtCrear_procedimientos"
        Me.txtCrear_procedimientos.Size = New System.Drawing.Size(390, 426)
        Me.txtCrear_procedimientos.TabIndex = 0
        Me.txtCrear_procedimientos.Text = resources.GetString("txtCrear_procedimientos.Text")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtnombre_scrypt)
        Me.GroupBox1.Controls.Add(Me.lblBasededatos)
        Me.GroupBox1.Controls.Add(Me.TXTbasededatos)
        Me.GroupBox1.Location = New System.Drawing.Point(431, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(250, 118)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'lblBasededatos
        '
        Me.lblBasededatos.AutoSize = True
        Me.lblBasededatos.BackColor = System.Drawing.Color.White
        Me.lblBasededatos.ForeColor = System.Drawing.Color.Black
        Me.lblBasededatos.Location = New System.Drawing.Point(6, 26)
        Me.lblBasededatos.Name = "lblBasededatos"
        Me.lblBasededatos.Size = New System.Drawing.Size(78, 13)
        Me.lblBasededatos.TabIndex = 622
        Me.lblBasededatos.Text = "Base de datos:"
        '
        'TXTbasededatos
        '
        Me.TXTbasededatos.Location = New System.Drawing.Point(107, 23)
        Me.TXTbasededatos.Name = "TXTbasededatos"
        Me.TXTbasededatos.Size = New System.Drawing.Size(127, 20)
        Me.TXTbasededatos.TabIndex = 623
        Me.TXTbasededatos.Text = "cn1"
        '
        'txtservidor
        '
        Me.txtservidor.AutoSize = True
        Me.txtservidor.ForeColor = System.Drawing.Color.Black
        Me.txtservidor.Location = New System.Drawing.Point(772, 12)
        Me.txtservidor.Name = "txtservidor"
        Me.txtservidor.Size = New System.Drawing.Size(16, 13)
        Me.txtservidor.TabIndex = 624
        Me.txtservidor.Text = "---"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(6, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 13)
        Me.Label9.TabIndex = 625
        Me.Label9.Text = "Nombre de Scrypt:"
        '
        'txtnombre_scrypt
        '
        Me.txtnombre_scrypt.Location = New System.Drawing.Point(107, 53)
        Me.txtnombre_scrypt.Name = "txtnombre_scrypt"
        Me.txtnombre_scrypt.Size = New System.Drawing.Size(79, 20)
        Me.txtnombre_scrypt.TabIndex = 626
        Me.txtnombre_scrypt.Text = "cn1"
        '
        'frmScript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCrear_procedimientos)
        Me.Controls.Add(Me.txtservidor)
        Me.Name = "frmScript"
        Me.Text = "frmScript"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCrear_procedimientos As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblBasededatos As Label
    Friend WithEvents TXTbasededatos As TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtservidor As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtnombre_scrypt As TextBox
End Class
