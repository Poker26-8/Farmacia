<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmcortemesero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmcortemesero))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbomesero = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfecha = New System.Windows.Forms.DateTimePicker()
        Me.rbturno = New System.Windows.Forms.RadioButton()
        Me.rbperiodo = New System.Windows.Forms.RadioButton()
        Me.pperiodo = New System.Windows.Forms.Panel()
        Me.dtpfhal = New System.Windows.Forms.DateTimePicker()
        Me.dtpfechaal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpht = New System.Windows.Forms.DateTimePicker()
        Me.PCorte80 = New System.Drawing.Printing.PrintDocument()
        Me.PCorteU80 = New System.Drawing.Printing.PrintDocument()
        Me.pCortePe80 = New System.Drawing.Printing.PrintDocument()
        Me.pperiodo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mesero"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(392, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "El corte es del mesero al cual se le asigno la venta"
        '
        'cbomesero
        '
        Me.cbomesero.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomesero.FormattingEnabled = True
        Me.cbomesero.Location = New System.Drawing.Point(98, 9)
        Me.cbomesero.Name = "cbomesero"
        Me.cbomesero.Size = New System.Drawing.Size(396, 26)
        Me.cbomesero.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(420, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 69)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(339, 41)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 69)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha"
        '
        'dtpfecha
        '
        Me.dtpfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfecha.Location = New System.Drawing.Point(67, 40)
        Me.dtpfecha.Name = "dtpfecha"
        Me.dtpfecha.Size = New System.Drawing.Size(119, 26)
        Me.dtpfecha.TabIndex = 6
        '
        'rbturno
        '
        Me.rbturno.AutoSize = True
        Me.rbturno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbturno.Location = New System.Drawing.Point(6, 10)
        Me.rbturno.Name = "rbturno"
        Me.rbturno.Size = New System.Drawing.Size(68, 24)
        Me.rbturno.TabIndex = 7
        Me.rbturno.TabStop = True
        Me.rbturno.Text = "Turno"
        Me.rbturno.UseVisualStyleBackColor = True
        '
        'rbperiodo
        '
        Me.rbperiodo.AutoSize = True
        Me.rbperiodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbperiodo.Location = New System.Drawing.Point(86, 10)
        Me.rbperiodo.Name = "rbperiodo"
        Me.rbperiodo.Size = New System.Drawing.Size(81, 24)
        Me.rbperiodo.TabIndex = 8
        Me.rbperiodo.TabStop = True
        Me.rbperiodo.Text = "Periodo"
        Me.rbperiodo.UseVisualStyleBackColor = True
        '
        'pperiodo
        '
        Me.pperiodo.Controls.Add(Me.dtpfhal)
        Me.pperiodo.Controls.Add(Me.dtpfechaal)
        Me.pperiodo.Controls.Add(Me.Label4)
        Me.pperiodo.Location = New System.Drawing.Point(6, 72)
        Me.pperiodo.Name = "pperiodo"
        Me.pperiodo.Size = New System.Drawing.Size(309, 38)
        Me.pperiodo.TabIndex = 9
        Me.pperiodo.Visible = False
        '
        'dtpfhal
        '
        Me.dtpfhal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfhal.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpfhal.Location = New System.Drawing.Point(186, 8)
        Me.dtpfhal.Name = "dtpfhal"
        Me.dtpfhal.Size = New System.Drawing.Size(107, 26)
        Me.dtpfhal.TabIndex = 12
        '
        'dtpfechaal
        '
        Me.dtpfechaal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfechaal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechaal.Location = New System.Drawing.Point(61, 8)
        Me.dtpfechaal.Name = "dtpfechaal"
        Me.dtpfechaal.Size = New System.Drawing.Size(119, 26)
        Me.dtpfechaal.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Al"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpht)
        Me.GroupBox1.Controls.Add(Me.dtpfecha)
        Me.GroupBox1.Controls.Add(Me.pperiodo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rbturno)
        Me.GroupBox1.Controls.Add(Me.rbperiodo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 117)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'dtpht
        '
        Me.dtpht.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpht.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpht.Location = New System.Drawing.Point(192, 39)
        Me.dtpht.Name = "dtpht"
        Me.dtpht.Size = New System.Drawing.Size(107, 26)
        Me.dtpht.TabIndex = 13
        Me.dtpht.Visible = False
        '
        'PCorte80
        '
        '
        'PCorteU80
        '
        '
        'pCortePe80
        '
        '
        'frmcortemesero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(506, 186)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbomesero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmcortemesero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corte por mesero"
        Me.pperiodo.ResumeLayout(False)
        Me.pperiodo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbomesero As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpfecha As DateTimePicker
    Friend WithEvents rbturno As RadioButton
    Friend WithEvents rbperiodo As RadioButton
    Friend WithEvents pperiodo As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpfhal As DateTimePicker
    Friend WithEvents dtpfechaal As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpht As DateTimePicker
    Friend WithEvents PCorte80 As Printing.PrintDocument
    Friend WithEvents PCorteU80 As Printing.PrintDocument
    Friend WithEvents pCortePe80 As Printing.PrintDocument
End Class
