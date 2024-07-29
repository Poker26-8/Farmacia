<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotesyCad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLotesyCad))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mcdesde = New System.Windows.Forms.MonthCalendar()
        Me.mcHasta = New System.Windows.Forms.MonthCalendar()
        Me.optCaducos = New System.Windows.Forms.RadioButton()
        Me.optCaducidades = New System.Windows.Forms.RadioButton()
        Me.optCaducidad = New System.Windows.Forms.RadioButton()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(277, 168)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.optCaducidades)
        Me.TabPage1.Controls.Add(Me.optCaducidad)
        Me.TabPage1.Controls.Add(Me.optCaducos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(269, 142)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Caducidades"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 74)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.mcHasta)
        Me.Panel1.Controls.Add(Me.mcdesde)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 178)
        Me.Panel1.TabIndex = 1
        '
        'mcdesde
        '
        Me.mcdesde.Location = New System.Drawing.Point(543, 9)
        Me.mcdesde.Name = "mcdesde"
        Me.mcdesde.TabIndex = 1
        '
        'mcHasta
        '
        Me.mcHasta.Location = New System.Drawing.Point(292, 9)
        Me.mcHasta.Name = "mcHasta"
        Me.mcHasta.TabIndex = 2
        '
        'optCaducos
        '
        Me.optCaducos.AutoSize = True
        Me.optCaducos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCaducos.Location = New System.Drawing.Point(6, 6)
        Me.optCaducos.Name = "optCaducos"
        Me.optCaducos.Size = New System.Drawing.Size(172, 22)
        Me.optCaducos.TabIndex = 58
        Me.optCaducos.TabStop = True
        Me.optCaducos.Text = "Productos caducados"
        Me.optCaducos.UseVisualStyleBackColor = True
        '
        'optCaducidades
        '
        Me.optCaducidades.AutoSize = True
        Me.optCaducidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCaducidades.Location = New System.Drawing.Point(6, 52)
        Me.optCaducidades.Name = "optCaducidades"
        Me.optCaducidades.Size = New System.Drawing.Size(201, 22)
        Me.optCaducidades.TabIndex = 61
        Me.optCaducidades.TabStop = True
        Me.optCaducidades.Text = "Caducidades por producto"
        Me.optCaducidades.UseVisualStyleBackColor = True
        '
        'optCaducidad
        '
        Me.optCaducidad.AutoSize = True
        Me.optCaducidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optCaducidad.Location = New System.Drawing.Point(6, 29)
        Me.optCaducidad.Name = "optCaducidad"
        Me.optCaducidad.Size = New System.Drawing.Size(112, 22)
        Me.optCaducidad.TabIndex = 60
        Me.optCaducidad.TabStop = True
        Me.optCaducidad.Text = "Caducidades"
        Me.optCaducidad.UseVisualStyleBackColor = True
        '
        'frmLotesyCad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLotesyCad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lotes y Caducidades"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents mcHasta As MonthCalendar
    Friend WithEvents mcdesde As MonthCalendar
    Friend WithEvents optCaducos As RadioButton
    Friend WithEvents optCaducidades As RadioButton
    Friend WithEvents optCaducidad As RadioButton
End Class
