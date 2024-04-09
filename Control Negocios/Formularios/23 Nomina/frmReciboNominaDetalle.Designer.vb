<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReciboNominaDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReciboNominaDetalle))
        Me.GBGenerales = New System.Windows.Forms.GroupBox()
        Me.txtImporteCalEmp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtClaveConcepto = New System.Windows.Forms.TextBox()
        Me.txtImporteCal = New System.Windows.Forms.TextBox()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.lblCurp = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GBGenerales.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBGenerales
        '
        Me.GBGenerales.BackColor = System.Drawing.Color.White
        Me.GBGenerales.Controls.Add(Me.txtImporteCalEmp)
        Me.GBGenerales.Controls.Add(Me.Label2)
        Me.GBGenerales.Controls.Add(Me.txtImporte)
        Me.GBGenerales.Controls.Add(Me.Label1)
        Me.GBGenerales.Controls.Add(Me.txtClaveConcepto)
        Me.GBGenerales.Controls.Add(Me.txtImporteCal)
        Me.GBGenerales.Controls.Add(Me.lblImporte)
        Me.GBGenerales.Controls.Add(Me.txtConcepto)
        Me.GBGenerales.Controls.Add(Me.txtCantidad)
        Me.GBGenerales.Controls.Add(Me.lblConcepto)
        Me.GBGenerales.Controls.Add(Me.lblCurp)
        Me.GBGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBGenerales.ForeColor = System.Drawing.Color.DarkRed
        Me.GBGenerales.Location = New System.Drawing.Point(12, 41)
        Me.GBGenerales.Name = "GBGenerales"
        Me.GBGenerales.Size = New System.Drawing.Size(811, 105)
        Me.GBGenerales.TabIndex = 52
        Me.GBGenerales.TabStop = False
        Me.GBGenerales.Text = "Detalle Nomina"
        '
        'txtImporteCalEmp
        '
        Me.txtImporteCalEmp.BackColor = System.Drawing.Color.White
        Me.txtImporteCalEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImporteCalEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteCalEmp.Location = New System.Drawing.Point(504, 74)
        Me.txtImporteCalEmp.Name = "txtImporteCalEmp"
        Me.txtImporteCalEmp.ReadOnly = True
        Me.txtImporteCalEmp.Size = New System.Drawing.Size(67, 22)
        Me.txtImporteCalEmp.TabIndex = 138
        Me.txtImporteCalEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(381, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 15)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Importe Empresa"
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.White
        Me.txtImporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporte.Location = New System.Drawing.Point(712, 50)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(93, 22)
        Me.txtImporte.TabIndex = 0
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(712, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Importe"
        '
        'txtClaveConcepto
        '
        Me.txtClaveConcepto.BackColor = System.Drawing.Color.White
        Me.txtClaveConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClaveConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveConcepto.Location = New System.Drawing.Point(87, 78)
        Me.txtClaveConcepto.Name = "txtClaveConcepto"
        Me.txtClaveConcepto.ReadOnly = True
        Me.txtClaveConcepto.Size = New System.Drawing.Size(35, 21)
        Me.txtClaveConcepto.TabIndex = 135
        Me.txtClaveConcepto.Visible = False
        '
        'txtImporteCal
        '
        Me.txtImporteCal.BackColor = System.Drawing.Color.White
        Me.txtImporteCal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImporteCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteCal.Location = New System.Drawing.Point(577, 50)
        Me.txtImporteCal.Name = "txtImporteCal"
        Me.txtImporteCal.ReadOnly = True
        Me.txtImporteCal.Size = New System.Drawing.Size(129, 22)
        Me.txtImporteCal.TabIndex = 134
        Me.txtImporteCal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblImporte
        '
        Me.lblImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.ForeColor = System.Drawing.Color.Black
        Me.lblImporte.Location = New System.Drawing.Point(577, 32)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(129, 15)
        Me.lblImporte.TabIndex = 133
        Me.lblImporte.Text = "Importe Calculado"
        '
        'txtConcepto
        '
        Me.txtConcepto.BackColor = System.Drawing.Color.White
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(87, 50)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ReadOnly = True
        Me.txtConcepto.Size = New System.Drawing.Size(484, 22)
        Me.txtConcepto.TabIndex = 132
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.White
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(6, 50)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(75, 22)
        Me.txtCantidad.TabIndex = 0
        '
        'lblConcepto
        '
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.Color.Black
        Me.lblConcepto.Location = New System.Drawing.Point(87, 32)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(484, 15)
        Me.lblConcepto.TabIndex = 128
        Me.lblConcepto.Text = "Concepto"
        '
        'lblCurp
        '
        Me.lblCurp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurp.ForeColor = System.Drawing.Color.Black
        Me.lblCurp.Location = New System.Drawing.Point(6, 32)
        Me.lblCurp.Name = "lblCurp"
        Me.lblCurp.Size = New System.Drawing.Size(75, 15)
        Me.lblCurp.TabIndex = 95
        Me.lblCurp.Text = "Cantidad"
        Me.lblCurp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(829, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 79)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "Guardar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 35)
        Me.Panel1.TabIndex = 54
        '
        'frmReciboNominaDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(913, 154)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GBGenerales)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReciboNominaDetalle"
        Me.Text = "Detalle Nomina"
        Me.GBGenerales.ResumeLayout(False)
        Me.GBGenerales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GBGenerales As GroupBox
    Friend WithEvents txtImporteCalEmp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtImporte As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtClaveConcepto As TextBox
    Friend WithEvents txtImporteCal As TextBox
    Friend WithEvents lblImporte As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents lblConcepto As Label
    Friend WithEvents lblCurp As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
End Class
