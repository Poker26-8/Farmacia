<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCorte3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCorte3))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMesa = New System.Windows.Forms.Button()
        Me.cboCajero = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalIni = New System.Windows.Forms.Button()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCorteZ = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PCorte80 = New System.Drawing.Printing.PrintDocument()
        Me.pCorte58 = New System.Drawing.Printing.PrintDocument()
        Me.pMesa80 = New System.Drawing.Printing.PrintDocument()
        Me.pMesa58 = New System.Drawing.Printing.PrintDocument()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMesa)
        Me.Panel1.Controls.Add(Me.cboCajero)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnSalIni)
        Me.Panel1.Controls.Add(Me.txtInicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnCorteZ)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 102)
        Me.Panel1.TabIndex = 0
        '
        'btnMesa
        '
        Me.btnMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMesa.Image = CType(resources.GetObject("btnMesa.Image"), System.Drawing.Image)
        Me.btnMesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMesa.Location = New System.Drawing.Point(369, 3)
        Me.btnMesa.Name = "btnMesa"
        Me.btnMesa.Size = New System.Drawing.Size(75, 89)
        Me.btnMesa.TabIndex = 8
        Me.btnMesa.Text = "Corte Mesas"
        Me.btnMesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMesa.UseVisualStyleBackColor = True
        '
        'cboCajero
        '
        Me.cboCajero.FormattingEnabled = True
        Me.cboCajero.Location = New System.Drawing.Point(101, 71)
        Me.cboCajero.Name = "cboCajero"
        Me.cboCajero.Size = New System.Drawing.Size(100, 21)
        Me.cboCajero.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cajero:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSalIni
        '
        Me.btnSalIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalIni.Image = CType(resources.GetObject("btnSalIni.Image"), System.Drawing.Image)
        Me.btnSalIni.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalIni.Location = New System.Drawing.Point(207, 3)
        Me.btnSalIni.Name = "btnSalIni"
        Me.btnSalIni.Size = New System.Drawing.Size(75, 89)
        Me.btnSalIni.TabIndex = 5
        Me.btnSalIni.Text = "Saldo Inicial"
        Me.btnSalIni.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalIni.UseVisualStyleBackColor = True
        '
        'txtInicial
        '
        Me.txtInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicial.Location = New System.Drawing.Point(101, 43)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(100, 22)
        Me.txtInicial.TabIndex = 4
        Me.txtInicial.Text = "0.00"
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Saldo Inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCorteZ
        '
        Me.btnCorteZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorteZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorteZ.Image = CType(resources.GetObject("btnCorteZ.Image"), System.Drawing.Image)
        Me.btnCorteZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCorteZ.Location = New System.Drawing.Point(288, 3)
        Me.btnCorteZ.Name = "btnCorteZ"
        Me.btnCorteZ.Size = New System.Drawing.Size(75, 89)
        Me.btnCorteZ.TabIndex = 2
        Me.btnCorteZ.Text = "Corte Z"
        Me.btnCorteZ.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCorteZ.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(91, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(110, 22)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PCorte80
        '
        '
        'pCorte58
        '
        '
        'pMesa80
        '
        '
        'pMesa58
        '
        '
        'frmCorte3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(452, 106)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCorte3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corte"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCorteZ As Button
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents PCorte80 As Printing.PrintDocument
    Friend WithEvents pCorte58 As Printing.PrintDocument
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSalIni As Button
    Friend WithEvents txtInicial As TextBox
    Friend WithEvents cboCajero As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMesa As Button
    Friend WithEvents pMesa80 As Printing.PrintDocument
    Friend WithEvents pMesa58 As Printing.PrintDocument
End Class
