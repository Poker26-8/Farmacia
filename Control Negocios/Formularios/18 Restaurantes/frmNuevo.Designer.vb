<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevo
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
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pmesas
        '
        Me.pmesas.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.pmesas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pmesas.Location = New System.Drawing.Point(0, 100)
        Me.pmesas.Name = "pmesas"
        Me.pmesas.Size = New System.Drawing.Size(447, 540)
        Me.pmesas.TabIndex = 0
        '
        'psuperior
        '
        Me.psuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.psuperior.Location = New System.Drawing.Point(0, 0)
        Me.psuperior.Name = "psuperior"
        Me.psuperior.Size = New System.Drawing.Size(930, 100)
        Me.psuperior.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdCaptura)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(447, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(483, 540)
        Me.Panel1.TabIndex = 1
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.grdCaptura.Location = New System.Drawing.Point(6, 15)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.Size = New System.Drawing.Size(465, 305)
        Me.grdCaptura.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "nombre"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'frmNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(930, 640)
        Me.Controls.Add(Me.pmesas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.psuperior)
        Me.Name = "frmNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmNuevo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pmesas As Panel
    Friend WithEvents psuperior As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
