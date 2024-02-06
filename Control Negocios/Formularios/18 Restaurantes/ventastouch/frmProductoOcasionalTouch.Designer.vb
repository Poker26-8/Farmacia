<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductoOcasionalTouch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductoOcasionalTouch))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblcodigo = New System.Windows.Forms.Label()
        Me.btnsaliroca = New System.Windows.Forms.Button()
        Me.btnlimpiaroca = New System.Windows.Forms.Button()
        Me.btnagregaroca = New System.Windows.Forms.Button()
        Me.txtcantidadocasional = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtprecioocasional = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdescripcionocasional = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 38)
        Me.Panel1.TabIndex = 58
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(175, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Producto Ocasional"
        '
        'lblcodigo
        '
        Me.lblcodigo.AutoSize = True
        Me.lblcodigo.Location = New System.Drawing.Point(13, 171)
        Me.lblcodigo.Name = "lblcodigo"
        Me.lblcodigo.Size = New System.Drawing.Size(39, 13)
        Me.lblcodigo.TabIndex = 57
        Me.lblcodigo.Text = "WXYZ"
        Me.lblcodigo.Visible = False
        '
        'btnsaliroca
        '
        Me.btnsaliroca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnsaliroca.FlatAppearance.BorderSize = 0
        Me.btnsaliroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsaliroca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsaliroca.Image = CType(resources.GetObject("btnsaliroca.Image"), System.Drawing.Image)
        Me.btnsaliroca.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnsaliroca.Location = New System.Drawing.Point(240, 171)
        Me.btnsaliroca.Name = "btnsaliroca"
        Me.btnsaliroca.Size = New System.Drawing.Size(75, 73)
        Me.btnsaliroca.TabIndex = 56
        Me.btnsaliroca.Text = "Salir"
        Me.btnsaliroca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnsaliroca.UseVisualStyleBackColor = False
        '
        'btnlimpiaroca
        '
        Me.btnlimpiaroca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnlimpiaroca.FlatAppearance.BorderSize = 0
        Me.btnlimpiaroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiaroca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiaroca.Image = CType(resources.GetObject("btnlimpiaroca.Image"), System.Drawing.Image)
        Me.btnlimpiaroca.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpiaroca.Location = New System.Drawing.Point(159, 171)
        Me.btnlimpiaroca.Name = "btnlimpiaroca"
        Me.btnlimpiaroca.Size = New System.Drawing.Size(75, 73)
        Me.btnlimpiaroca.TabIndex = 55
        Me.btnlimpiaroca.Text = "Limpiar"
        Me.btnlimpiaroca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiaroca.UseVisualStyleBackColor = False
        '
        'btnagregaroca
        '
        Me.btnagregaroca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnagregaroca.FlatAppearance.BorderSize = 0
        Me.btnagregaroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnagregaroca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnagregaroca.Image = CType(resources.GetObject("btnagregaroca.Image"), System.Drawing.Image)
        Me.btnagregaroca.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnagregaroca.Location = New System.Drawing.Point(78, 171)
        Me.btnagregaroca.Name = "btnagregaroca"
        Me.btnagregaroca.Size = New System.Drawing.Size(75, 73)
        Me.btnagregaroca.TabIndex = 54
        Me.btnagregaroca.Text = "Agregar"
        Me.btnagregaroca.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnagregaroca.UseVisualStyleBackColor = False
        '
        'txtcantidadocasional
        '
        Me.txtcantidadocasional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidadocasional.Location = New System.Drawing.Point(134, 134)
        Me.txtcantidadocasional.Name = "txtcantidadocasional"
        Me.txtcantidadocasional.Size = New System.Drawing.Size(181, 22)
        Me.txtcantidadocasional.TabIndex = 53
        Me.txtcantidadocasional.Text = "0.00"
        Me.txtcantidadocasional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 22)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Cantidad:"
        '
        'txtprecioocasional
        '
        Me.txtprecioocasional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprecioocasional.Location = New System.Drawing.Point(134, 92)
        Me.txtprecioocasional.Name = "txtprecioocasional"
        Me.txtprecioocasional.Size = New System.Drawing.Size(181, 22)
        Me.txtprecioocasional.TabIndex = 51
        Me.txtprecioocasional.Text = "0.00"
        Me.txtprecioocasional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 22)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Precio:"
        '
        'txtdescripcionocasional
        '
        Me.txtdescripcionocasional.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescripcionocasional.Location = New System.Drawing.Point(134, 53)
        Me.txtdescripcionocasional.Name = "txtdescripcionocasional"
        Me.txtdescripcionocasional.Size = New System.Drawing.Size(181, 22)
        Me.txtdescripcionocasional.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 22)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Descripción:"
        '
        'frmProductoOcasionalTouch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(329, 254)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblcodigo)
        Me.Controls.Add(Me.btnsaliroca)
        Me.Controls.Add(Me.btnlimpiaroca)
        Me.Controls.Add(Me.btnagregaroca)
        Me.Controls.Add(Me.txtcantidadocasional)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtprecioocasional)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtdescripcionocasional)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProductoOcasionalTouch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto Ocasional"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblcodigo As Label
    Friend WithEvents btnsaliroca As Button
    Friend WithEvents btnlimpiaroca As Button
    Friend WithEvents btnagregaroca As Button
    Friend WithEvents txtcantidadocasional As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtprecioocasional As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtdescripcionocasional As TextBox
    Friend WithEvents Label1 As Label
End Class
