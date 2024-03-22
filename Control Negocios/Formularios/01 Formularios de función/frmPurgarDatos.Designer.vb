<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurgarDatos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurgarDatos))
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnCompras = New System.Windows.Forms.Button()
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnExistencias = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnVentas
        '
        Me.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentas.Image = CType(resources.GetObject("btnVentas.Image"), System.Drawing.Image)
        Me.btnVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVentas.Location = New System.Drawing.Point(12, 12)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(93, 89)
        Me.btnVentas.TabIndex = 0
        Me.btnVentas.Text = "Ventas"
        Me.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnCompras
        '
        Me.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCompras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompras.Image = CType(resources.GetObject("btnCompras.Image"), System.Drawing.Image)
        Me.btnCompras.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCompras.Location = New System.Drawing.Point(111, 12)
        Me.btnCompras.Name = "btnCompras"
        Me.btnCompras.Size = New System.Drawing.Size(102, 89)
        Me.btnCompras.TabIndex = 1
        Me.btnCompras.Text = "Compras"
        Me.btnCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCompras.UseVisualStyleBackColor = True
        '
        'btnProductos
        '
        Me.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductos.Image = CType(resources.GetObject("btnProductos.Image"), System.Drawing.Image)
        Me.btnProductos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProductos.Location = New System.Drawing.Point(219, 12)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(113, 89)
        Me.btnProductos.TabIndex = 2
        Me.btnProductos.Text = "Productos"
        Me.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(219, 107)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(113, 89)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnExistencias
        '
        Me.btnExistencias.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExistencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExistencias.Image = CType(resources.GetObject("btnExistencias.Image"), System.Drawing.Image)
        Me.btnExistencias.Location = New System.Drawing.Point(12, 107)
        Me.btnExistencias.Name = "btnExistencias"
        Me.btnExistencias.Size = New System.Drawing.Size(93, 89)
        Me.btnExistencias.TabIndex = 4
        Me.btnExistencias.Text = "Existencias"
        Me.btnExistencias.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExistencias.UseVisualStyleBackColor = True
        '
        'frmPurgarDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(343, 213)
        Me.Controls.Add(Me.btnExistencias)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnProductos)
        Me.Controls.Add(Me.btnCompras)
        Me.Controls.Add(Me.btnVentas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPurgarDatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purgar  Datos"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnVentas As Button
    Friend WithEvents btnCompras As Button
    Friend WithEvents btnProductos As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnExistencias As Button
End Class
