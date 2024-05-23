<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevo
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
        Me.pmesas = New System.Windows.Forms.Panel()
        Me.psuperior = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.grdCaptura2 = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assasa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aaa = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCaptura2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.btnPdf)
        Me.Panel1.Controls.Add(Me.grdCaptura)
        Me.Panel1.Controls.Add(Me.grdCaptura2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(447, 100)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(483, 540)
        Me.Panel1.TabIndex = 1
        '
        'btnPdf
        '
        Me.btnPdf.Location = New System.Drawing.Point(304, 220)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(95, 55)
        Me.btnPdf.TabIndex = 3
        Me.btnPdf.Text = "PDF"
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.assasa, Me.aaa})
        Me.grdCaptura.Location = New System.Drawing.Point(44, 18)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(240, 150)
        Me.grdCaptura.TabIndex = 2
        '
        'grdCaptura2
        '
        Me.grdCaptura2.AllowUserToAddRows = False
        Me.grdCaptura2.AllowUserToDeleteRows = False
        Me.grdCaptura2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4})
        Me.grdCaptura2.Location = New System.Drawing.Point(15, 352)
        Me.grdCaptura2.Name = "grdCaptura2"
        Me.grdCaptura2.Size = New System.Drawing.Size(456, 150)
        Me.grdCaptura2.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "NOMBRE"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "OTRO NOMBRE"
        Me.Column4.Name = "Column4"
        '
        'assasa
        '
        Me.assasa.HeaderText = "nombre"
        Me.assasa.Name = "assasa"
        '
        'aaa
        '
        Me.aaa.HeaderText = "Traspasar"
        Me.aaa.Name = "aaa"
        Me.aaa.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.aaa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        CType(Me.grdCaptura2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pmesas As Panel
    Friend WithEvents psuperior As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdCaptura1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents grdCaptura2 As DataGridView
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnPdf As Button
    Friend WithEvents assasa As DataGridViewTextBoxColumn
    Friend WithEvents aaa As DataGridViewButtonColumn
End Class
