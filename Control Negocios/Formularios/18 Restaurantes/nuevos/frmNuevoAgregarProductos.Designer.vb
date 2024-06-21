<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevoAgregarProductos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoAgregarProductos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pDepartamento = New System.Windows.Forms.Panel()
        Me.pgrupo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pProductos = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1076, 59)
        Me.Panel1.TabIndex = 0
        '
        'pDepartamento
        '
        Me.pDepartamento.AutoScroll = True
        Me.pDepartamento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pDepartamento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pDepartamento.Location = New System.Drawing.Point(0, 59)
        Me.pDepartamento.Name = "pDepartamento"
        Me.pDepartamento.Size = New System.Drawing.Size(112, 622)
        Me.pDepartamento.TabIndex = 5
        '
        'pgrupo
        '
        Me.pgrupo.AutoScroll = True
        Me.pgrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.pgrupo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pgrupo.Location = New System.Drawing.Point(112, 59)
        Me.pgrupo.Name = "pgrupo"
        Me.pgrupo.Size = New System.Drawing.Size(125, 622)
        Me.pgrupo.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(785, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(291, 622)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(291, 273)
        Me.Panel3.TabIndex = 0
        '
        'pProductos
        '
        Me.pProductos.BackColor = System.Drawing.Color.White
        Me.pProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pProductos.Location = New System.Drawing.Point(237, 59)
        Me.pProductos.Name = "pProductos"
        Me.pProductos.Size = New System.Drawing.Size(548, 622)
        Me.pProductos.TabIndex = 8
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 273)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(291, 349)
        Me.DataGridView1.TabIndex = 1
        '
        'frmNuevoAgregarProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1076, 681)
        Me.Controls.Add(Me.pProductos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pgrupo)
        Me.Controls.Add(Me.pDepartamento)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNuevoAgregarProductos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo Agrega rProductos"
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pDepartamento As Panel
    Friend WithEvents pgrupo As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pProductos As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents DataGridView1 As DataGridView
End Class
