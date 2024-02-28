<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMesasNueva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMesasNueva))
        Me.PSUPERIOR = New System.Windows.Forms.Panel()
        Me.pSDerecha = New System.Windows.Forms.Panel()
        Me.btnMesa = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMesero = New System.Windows.Forms.TextBox()
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.pubicacion = New System.Windows.Forms.Panel()
        Me.PSUPERIOR.SuspendLayout()
        Me.pSDerecha.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PSUPERIOR
        '
        Me.PSUPERIOR.BackColor = System.Drawing.Color.Red
        Me.PSUPERIOR.Controls.Add(Me.pubicacion)
        Me.PSUPERIOR.Controls.Add(Me.pSDerecha)
        Me.PSUPERIOR.Controls.Add(Me.Panel3)
        Me.PSUPERIOR.Dock = System.Windows.Forms.DockStyle.Top
        Me.PSUPERIOR.Location = New System.Drawing.Point(0, 0)
        Me.PSUPERIOR.Name = "PSUPERIOR"
        Me.PSUPERIOR.Size = New System.Drawing.Size(960, 100)
        Me.PSUPERIOR.TabIndex = 0
        '
        'pSDerecha
        '
        Me.pSDerecha.BackColor = System.Drawing.Color.White
        Me.pSDerecha.Controls.Add(Me.btnMesa)
        Me.pSDerecha.Dock = System.Windows.Forms.DockStyle.Right
        Me.pSDerecha.Location = New System.Drawing.Point(616, 0)
        Me.pSDerecha.Name = "pSDerecha"
        Me.pSDerecha.Size = New System.Drawing.Size(344, 100)
        Me.pSDerecha.TabIndex = 1
        '
        'btnMesa
        '
        Me.btnMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMesa.Image = CType(resources.GetObject("btnMesa.Image"), System.Drawing.Image)
        Me.btnMesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMesa.Location = New System.Drawing.Point(18, 12)
        Me.btnMesa.Name = "btnMesa"
        Me.btnMesa.Size = New System.Drawing.Size(82, 73)
        Me.btnMesa.TabIndex = 0
        Me.btnMesa.Text = "Mesas"
        Me.btnMesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMesa.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 100)
        Me.Panel3.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 100)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtMesero)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(734, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(226, 509)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesero"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtMesero
        '
        Me.txtMesero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMesero.Location = New System.Drawing.Point(3, 45)
        Me.txtMesero.Name = "txtMesero"
        Me.txtMesero.Size = New System.Drawing.Size(211, 29)
        Me.txtMesero.TabIndex = 1
        '
        'pmesas
        '
        Me.pmesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pmesas.Location = New System.Drawing.Point(0, 100)
        Me.pmesas.Name = "pmesas"
        Me.pmesas.Size = New System.Drawing.Size(734, 509)
        Me.pmesas.TabIndex = 2
        '
        'pubicacion
        '
        Me.pubicacion.BackColor = System.Drawing.Color.LightSeaGreen
        Me.pubicacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pubicacion.Location = New System.Drawing.Point(200, 0)
        Me.pubicacion.Name = "pubicacion"
        Me.pubicacion.Size = New System.Drawing.Size(416, 100)
        Me.pubicacion.TabIndex = 2
        '
        'frmMesasNueva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(960, 609)
        Me.Controls.Add(Me.pmesas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PSUPERIOR)
        Me.Name = "frmMesasNueva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mesas Nueva"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PSUPERIOR.ResumeLayout(False)
        Me.pSDerecha.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PSUPERIOR As Panel
    Friend WithEvents btnMesa As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pSDerecha As Panel
    Friend WithEvents txtMesero As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pmesas As Panel
    Friend WithEvents pubicacion As Panel
End Class
