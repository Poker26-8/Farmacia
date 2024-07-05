<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCatGrupos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCatGrupos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbogrupo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTermino = New System.Windows.Forms.DateTimePicker()
        Me.txtcupo = New System.Windows.Forms.TextBox()
        Me.dtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(399, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbogrupo
        '
        Me.cbogrupo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbogrupo.FormattingEnabled = True
        Me.cbogrupo.Location = New System.Drawing.Point(69, 22)
        Me.cbogrupo.Name = "cbogrupo"
        Me.cbogrupo.Size = New System.Drawing.Size(299, 23)
        Me.cbogrupo.TabIndex = 67
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 68
        Me.Label6.Text = "Horario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Nombre:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpTermino)
        Me.GroupBox1.Controls.Add(Me.txtcupo)
        Me.GroupBox1.Controls.Add(Me.dtpInicio)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbogrupo)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 87)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Registro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(151, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 15)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "-"
        '
        'dtpTermino
        '
        Me.dtpTermino.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTermino.Location = New System.Drawing.Point(169, 49)
        Me.dtpTermino.Name = "dtpTermino"
        Me.dtpTermino.ShowUpDown = True
        Me.dtpTermino.Size = New System.Drawing.Size(74, 23)
        Me.dtpTermino.TabIndex = 72
        '
        'txtcupo
        '
        Me.txtcupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcupo.Location = New System.Drawing.Point(294, 49)
        Me.txtcupo.Name = "txtcupo"
        Me.txtcupo.Size = New System.Drawing.Size(74, 23)
        Me.txtcupo.TabIndex = 71
        Me.txtcupo.Text = "0"
        Me.txtcupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpInicio
        '
        Me.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpInicio.Location = New System.Drawing.Point(69, 49)
        Me.dtpInicio.Name = "dtpInicio"
        Me.dtpInicio.ShowUpDown = True
        Me.dtpInicio.Size = New System.Drawing.Size(74, 23)
        Me.dtpInicio.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Cupo:"
        '
        'btnlimpiar
        '
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpiar.Image = CType(resources.GetObject("btnlimpiar.Image"), System.Drawing.Image)
        Me.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpiar.Location = New System.Drawing.Point(231, 127)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(75, 83)
        Me.btnlimpiar.TabIndex = 71
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(312, 127)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 83)
        Me.btnguardar.TabIndex = 70
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'txtId
        '
        Me.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtId.Location = New System.Drawing.Point(11, 127)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(63, 23)
        Me.txtId.TabIndex = 74
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtId.Visible = False
        '
        'btneliminar
        '
        Me.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btneliminar.Image = CType(resources.GetObject("btneliminar.Image"), System.Drawing.Image)
        Me.btneliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btneliminar.Location = New System.Drawing.Point(150, 127)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(75, 83)
        Me.btneliminar.TabIndex = 75
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'frmCatGrupos
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(399, 214)
        Me.Controls.Add(Me.btneliminar)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCatGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de grupos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cbogrupo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTermino As DateTimePicker
    Friend WithEvents txtcupo As TextBox
    Friend WithEvents dtpInicio As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents txtId As TextBox
    Friend WithEvents btneliminar As Button
End Class
