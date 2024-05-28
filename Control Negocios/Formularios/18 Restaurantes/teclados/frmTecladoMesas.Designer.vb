<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTecladoMesas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTecladoMesas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cboMesero = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.cboMesero)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 60)
        Me.Panel1.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(187, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancelar.Location = New System.Drawing.Point(492, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(155, 57)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'cboMesero
        '
        Me.cboMesero.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesero.FormattingEnabled = True
        Me.cboMesero.Location = New System.Drawing.Point(108, 9)
        Me.cboMesero.Name = "cboMesero"
        Me.cboMesero.Size = New System.Drawing.Size(247, 32)
        Me.cboMesero.TabIndex = 1
        Me.cboMesero.Text = "TODOS"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesero"
        '
        'pmesas
        '
        Me.pmesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pmesas.Location = New System.Drawing.Point(0, 60)
        Me.pmesas.Name = "pmesas"
        Me.pmesas.Size = New System.Drawing.Size(650, 390)
        Me.pmesas.TabIndex = 1
        '
        'frmTecladoMesas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(650, 450)
        Me.Controls.Add(Me.pmesas)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTecladoMesas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar mesa"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents pmesas As Panel
    Friend WithEvents cboMesero As ComboBox
    Friend WithEvents btnCancelar As Button
End Class
