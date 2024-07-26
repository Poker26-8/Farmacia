<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHabitaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHabitaciones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.barsube = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtHoras = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPreDia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPrecioH = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cboUbicacion = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rtbCaracteristicas = New System.Windows.Forms.RichTextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbonumero = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(597, 37)
        Me.Panel1.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.barsube)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.btnImportar)
        Me.Panel3.Controls.Add(Me.btnLimpiar)
        Me.Panel3.Controls.Add(Me.btnGuardar)
        Me.Panel3.Controls.Add(Me.btnSalir)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 124)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(597, 90)
        Me.Panel3.TabIndex = 5
        '
        'barsube
        '
        Me.barsube.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.barsube.Location = New System.Drawing.Point(180, 40)
        Me.barsube.Name = "barsube"
        Me.barsube.Size = New System.Drawing.Size(84, 14)
        Me.barsube.TabIndex = 221
        Me.barsube.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gray
        Me.Label5.Location = New System.Drawing.Point(180, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Visible = False
        '
        'btnImportar
        '
        Me.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImportar.Location = New System.Drawing.Point(270, 14)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 74)
        Me.btnImportar.TabIndex = 3
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImportar.UseVisualStyleBackColor = True
        Me.btnImportar.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.Location = New System.Drawing.Point(351, 14)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(75, 74)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGuardar.Location = New System.Drawing.Point(432, 14)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 74)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(513, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 74)
        Me.btnSalir.TabIndex = 0
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtHoras)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.txtPreDia)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtPrecioH)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.DataGridView1)
        Me.Panel4.Controls.Add(Me.cboUbicacion)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.rtbCaracteristicas)
        Me.Panel4.Controls.Add(Me.cboTipo)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.cbonumero)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(597, 214)
        Me.Panel4.TabIndex = 4
        '
        'txtHoras
        '
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.Location = New System.Drawing.Point(68, 126)
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.Size = New System.Drawing.Size(103, 22)
        Me.txtHoras.TabIndex = 233
        Me.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHoras.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 18)
        Me.Label8.TabIndex = 232
        Me.Label8.Text = "Horas:"
        Me.Label8.Visible = False
        '
        'txtPreDia
        '
        Me.txtPreDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreDia.Location = New System.Drawing.Point(487, 126)
        Me.txtPreDia.Name = "txtPreDia"
        Me.txtPreDia.Size = New System.Drawing.Size(101, 22)
        Me.txtPreDia.TabIndex = 231
        Me.txtPreDia.Text = "0.00"
        Me.txtPreDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPreDia.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(365, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 18)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "Precio Noche:"
        Me.Label7.Visible = False
        '
        'txtPrecioH
        '
        Me.txtPrecioH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecioH.Location = New System.Drawing.Point(240, 126)
        Me.txtPrecioH.Name = "txtPrecioH"
        Me.txtPrecioH.Size = New System.Drawing.Size(105, 22)
        Me.txtPrecioH.TabIndex = 229
        Me.txtPrecioH.Text = "0.00"
        Me.txtPrecioH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPrecioH.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(177, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 18)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Precio:"
        Me.Label4.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(622, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(313, 115)
        Me.DataGridView1.TabIndex = 227
        Me.DataGridView1.Visible = False
        '
        'cboUbicacion
        '
        Me.cboUbicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUbicacion.FormattingEnabled = True
        Me.cboUbicacion.Location = New System.Drawing.Point(141, 68)
        Me.cboUbicacion.Name = "cboUbicacion"
        Me.cboUbicacion.Size = New System.Drawing.Size(123, 23)
        Me.cboUbicacion.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 20)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Ubicacion:"
        '
        'rtbCaracteristicas
        '
        Me.rtbCaracteristicas.Location = New System.Drawing.Point(270, 64)
        Me.rtbCaracteristicas.Name = "rtbCaracteristicas"
        Me.rtbCaracteristicas.Size = New System.Drawing.Size(318, 54)
        Me.rtbCaracteristicas.TabIndex = 5
        Me.rtbCaracteristicas.Text = ""
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(141, 95)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(123, 23)
        Me.cboTipo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(87, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(270, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Caracteristicas:"
        '
        'cbonumero
        '
        Me.cbonumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbonumero.FormattingEnabled = True
        Me.cbonumero.Location = New System.Drawing.Point(141, 41)
        Me.cbonumero.Name = "cbonumero"
        Me.cbonumero.Size = New System.Drawing.Size(123, 23)
        Me.cbonumero.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "N° Habitación:"
        '
        'frmHabitaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 214)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHabitaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habitaciones"
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents barsube As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents btnImportar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cboUbicacion As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents rtbCaracteristicas As RichTextBox
    Friend WithEvents cboTipo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbonumero As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPreDia As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPrecioH As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHoras As TextBox
    Friend WithEvents Label8 As Label
End Class
