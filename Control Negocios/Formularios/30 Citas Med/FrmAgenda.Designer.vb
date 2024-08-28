<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAgenda
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAgenda))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optHora = New System.Windows.Forms.RadioButton()
        Me.optDia = New System.Windows.Forms.RadioButton()
        Me.optMes = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.lblDía = New System.Windows.Forms.Label()
        Me.lblHora = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.tHora = New System.Windows.Forms.Timer(Me.components)
        Me.tActuales = New System.Windows.Forms.Timer(Me.components)
        Me.tEstado = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 139)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(308, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(234, 121)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMes)
        Me.GroupBox1.Controls.Add(Me.lblDía)
        Me.GroupBox1.Controls.Add(Me.lblHora)
        Me.GroupBox1.Controls.Add(Me.cboUsuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.optMes)
        Me.GroupBox1.Controls.Add(Me.optDia)
        Me.GroupBox1.Controls.Add(Me.optHora)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 128)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'optHora
        '
        Me.optHora.AutoSize = True
        Me.optHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optHora.Location = New System.Drawing.Point(7, 52)
        Me.optHora.Name = "optHora"
        Me.optHora.Size = New System.Drawing.Size(55, 20)
        Me.optHora.TabIndex = 0
        Me.optHora.TabStop = True
        Me.optHora.Text = "Hora"
        Me.optHora.UseVisualStyleBackColor = True
        '
        'optDia
        '
        Me.optDia.AutoSize = True
        Me.optDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optDia.Location = New System.Drawing.Point(6, 77)
        Me.optDia.Name = "optDia"
        Me.optDia.Size = New System.Drawing.Size(46, 20)
        Me.optDia.TabIndex = 1
        Me.optDia.TabStop = True
        Me.optDia.Text = "Día"
        Me.optDia.UseVisualStyleBackColor = True
        '
        'optMes
        '
        Me.optMes.AutoSize = True
        Me.optMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMes.Location = New System.Drawing.Point(6, 102)
        Me.optMes.Name = "optMes"
        Me.optMes.Size = New System.Drawing.Size(51, 20)
        Me.optMes.TabIndex = 2
        Me.optMes.TabStop = True
        Me.optMes.Text = "Mes"
        Me.optMes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Usuario"
        '
        'cboUsuario
        '
        Me.cboUsuario.FormattingEnabled = True
        Me.cboUsuario.Location = New System.Drawing.Point(6, 25)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(286, 21)
        Me.cboUsuario.TabIndex = 4
        '
        'lblMes
        '
        Me.lblMes.BackColor = System.Drawing.Color.MediumTurquoise
        Me.lblMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMes.ForeColor = System.Drawing.Color.Black
        Me.lblMes.Location = New System.Drawing.Point(173, 99)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(119, 23)
        Me.lblMes.TabIndex = 36
        Me.lblMes.Text = "Label3"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDía
        '
        Me.lblDía.BackColor = System.Drawing.Color.MediumTurquoise
        Me.lblDía.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDía.ForeColor = System.Drawing.Color.Black
        Me.lblDía.Location = New System.Drawing.Point(173, 74)
        Me.lblDía.Name = "lblDía"
        Me.lblDía.Size = New System.Drawing.Size(119, 23)
        Me.lblDía.TabIndex = 35
        Me.lblDía.Text = "Label2"
        Me.lblDía.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHora
        '
        Me.lblHora.BackColor = System.Drawing.Color.MediumTurquoise
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.ForeColor = System.Drawing.Color.Black
        Me.lblHora.Location = New System.Drawing.Point(173, 49)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(119, 23)
        Me.lblHora.TabIndex = 34
        Me.lblHora.Text = "Label1"
        Me.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnModificar)
        Me.Panel2.Controls.Add(Me.btnAgregar)
        Me.Panel2.Controls.Add(Me.btnDetalle)
        Me.Panel2.Controls.Add(Me.btnConsultar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 544)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 52)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdCaptura)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 139)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(545, 405)
        Me.Panel3.TabIndex = 2
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.Size = New System.Drawing.Size(545, 405)
        Me.grdCaptura.TabIndex = 0
        '
        'btnConsultar
        '
        Me.btnConsultar.BackColor = System.Drawing.Color.LightBlue
        Me.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.Location = New System.Drawing.Point(400, 9)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(133, 31)
        Me.btnConsultar.TabIndex = 0
        Me.btnConsultar.Text = "Consultar posteriores"
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'btnDetalle
        '
        Me.btnDetalle.BackColor = System.Drawing.Color.LightBlue
        Me.btnDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.Location = New System.Drawing.Point(308, 9)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(86, 31)
        Me.btnDetalle.TabIndex = 1
        Me.btnDetalle.Text = "Detalle"
        Me.btnDetalle.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.LightBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(10, 9)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(86, 31)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnModificar
        '
        Me.btnModificar.BackColor = System.Drawing.Color.LightBlue
        Me.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(102, 9)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(86, 31)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = False
        '
        'tHora
        '
        Me.tHora.Interval = 10
        '
        'tActuales
        '
        Me.tActuales.Interval = 60000
        '
        'tEstado
        '
        Me.tEstado.Interval = 10000
        '
        'FrmAgenda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(545, 596)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmAgenda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda de citas"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents optMes As RadioButton
    Friend WithEvents optDia As RadioButton
    Friend WithEvents optHora As RadioButton
    Friend WithEvents lblMes As Label
    Friend WithEvents lblDía As Label
    Friend WithEvents lblHora As Label
    Friend WithEvents cboUsuario As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnDetalle As Button
    Friend WithEvents btnConsultar As Button
    Friend WithEvents tHora As Timer
    Friend WithEvents tActuales As Timer
    Friend WithEvents tEstado As Timer
End Class
