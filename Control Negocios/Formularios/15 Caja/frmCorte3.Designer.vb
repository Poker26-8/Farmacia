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
        Me.PCorte80 = New System.Drawing.Printing.PrintDocument()
        Me.pCorte58 = New System.Drawing.Printing.PrintDocument()
        Me.pMesa80 = New System.Drawing.Printing.PrintDocument()
        Me.pMesa58 = New System.Drawing.Printing.PrintDocument()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnCorteZ = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInicial = New System.Windows.Forms.TextBox()
        Me.btnSalIni = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCajero = New System.Windows.Forms.ComboBox()
        Me.btnMesa = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpHoraIni = New System.Windows.Forms.DateTimePicker()
        Me.dtpHoraFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicial:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(101, 5)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(110, 22)
        Me.dtpFecha.TabIndex = 1
        '
        'btnCorteZ
        '
        Me.btnCorteZ.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCorteZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorteZ.Image = CType(resources.GetObject("btnCorteZ.Image"), System.Drawing.Image)
        Me.btnCorteZ.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCorteZ.Location = New System.Drawing.Point(416, 5)
        Me.btnCorteZ.Name = "btnCorteZ"
        Me.btnCorteZ.Size = New System.Drawing.Size(75, 89)
        Me.btnCorteZ.TabIndex = 2
        Me.btnCorteZ.Text = "Corte Z"
        Me.btnCorteZ.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCorteZ.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Saldo Inicial:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInicial
        '
        Me.txtInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInicial.Location = New System.Drawing.Point(101, 61)
        Me.txtInicial.Name = "txtInicial"
        Me.txtInicial.Size = New System.Drawing.Size(100, 22)
        Me.txtInicial.TabIndex = 4
        Me.txtInicial.Text = "0.00"
        Me.txtInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalIni
        '
        Me.btnSalIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalIni.Image = CType(resources.GetObject("btnSalIni.Image"), System.Drawing.Image)
        Me.btnSalIni.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalIni.Location = New System.Drawing.Point(335, 5)
        Me.btnSalIni.Name = "btnSalIni"
        Me.btnSalIni.Size = New System.Drawing.Size(75, 89)
        Me.btnSalIni.TabIndex = 5
        Me.btnSalIni.Text = "Saldo Inicial"
        Me.btnSalIni.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalIni.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 21)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cajero:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCajero
        '
        Me.cboCajero.FormattingEnabled = True
        Me.cboCajero.Location = New System.Drawing.Point(101, 89)
        Me.cboCajero.Name = "cboCajero"
        Me.cboCajero.Size = New System.Drawing.Size(100, 21)
        Me.cboCajero.TabIndex = 7
        '
        'btnMesa
        '
        Me.btnMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMesa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMesa.Image = CType(resources.GetObject("btnMesa.Image"), System.Drawing.Image)
        Me.btnMesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnMesa.Location = New System.Drawing.Point(497, 5)
        Me.btnMesa.Name = "btnMesa"
        Me.btnMesa.Size = New System.Drawing.Size(75, 89)
        Me.btnMesa.TabIndex = 8
        Me.btnMesa.Text = "Corte Mesas"
        Me.btnMesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMesa.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpHoraFin)
        Me.Panel1.Controls.Add(Me.dtpFechaFin)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpHoraIni)
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
        Me.Panel1.Size = New System.Drawing.Size(576, 118)
        Me.Panel1.TabIndex = 0
        '
        'dtpHoraIni
        '
        Me.dtpHoraIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHoraIni.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraIni.Location = New System.Drawing.Point(217, 5)
        Me.dtpHoraIni.Name = "dtpHoraIni"
        Me.dtpHoraIni.ShowUpDown = True
        Me.dtpHoraIni.Size = New System.Drawing.Size(100, 22)
        Me.dtpHoraIni.TabIndex = 164
        '
        'dtpHoraFin
        '
        Me.dtpHoraFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpHoraFin.Location = New System.Drawing.Point(217, 33)
        Me.dtpHoraFin.Name = "dtpHoraFin"
        Me.dtpHoraFin.ShowUpDown = True
        Me.dtpHoraFin.Size = New System.Drawing.Size(100, 22)
        Me.dtpHoraFin.TabIndex = 167
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(101, 33)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(110, 22)
        Me.dtpFechaFin.TabIndex = 166
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 22)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "Fecha Inicial:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCorte3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(576, 121)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCorte3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultar Corte"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCorte80 As Printing.PrintDocument
    Friend WithEvents pCorte58 As Printing.PrintDocument
    Friend WithEvents pMesa80 As Printing.PrintDocument
    Friend WithEvents pMesa58 As Printing.PrintDocument
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents btnCorteZ As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtInicial As TextBox
    Friend WithEvents btnSalIni As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCajero As ComboBox
    Friend WithEvents btnMesa As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpHoraFin As DateTimePicker
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpHoraIni As DateTimePicker
End Class
