<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehiculoR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVehiculoR))
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.lblcliente = New System.Windows.Forms.Label()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.lblplaca = New System.Windows.Forms.Label()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.chkTaller = New System.Windows.Forms.CheckBox()
        Me.cbodescripcion = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbodesplazamiento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbomodelo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbosubmarca = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbomarca = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtversion = New System.Windows.Forms.TextBox()
        Me.cbocilindros = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(357, 169)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(98, 20)
        Me.txtid.TabIndex = 92
        Me.txtid.Visible = False
        '
        'cboCliente
        '
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(159, 142)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(296, 21)
        Me.cboCliente.TabIndex = 91
        Me.cboCliente.Visible = False
        '
        'lblcliente
        '
        Me.lblcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcliente.Location = New System.Drawing.Point(91, 142)
        Me.lblcliente.Name = "lblcliente"
        Me.lblcliente.Size = New System.Drawing.Size(62, 23)
        Me.lblcliente.TabIndex = 90
        Me.lblcliente.Text = "Cliente:"
        Me.lblcliente.Visible = False
        '
        'txtPlacas
        '
        Me.txtPlacas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPlacas.Location = New System.Drawing.Point(159, 169)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(154, 20)
        Me.txtPlacas.TabIndex = 89
        Me.txtPlacas.Visible = False
        '
        'lblplaca
        '
        Me.lblplaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblplaca.Location = New System.Drawing.Point(91, 166)
        Me.lblplaca.Name = "lblplaca"
        Me.lblplaca.Size = New System.Drawing.Size(66, 23)
        Me.lblplaca.TabIndex = 88
        Me.lblplaca.Text = "Placa:"
        Me.lblplaca.Visible = False
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackColor = System.Drawing.Color.White
        Me.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnlimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.Image = CType(resources.GetObject("btnlimpiar.Image"), System.Drawing.Image)
        Me.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlimpiar.Location = New System.Drawing.Point(461, 141)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(71, 72)
        Me.btnlimpiar.TabIndex = 87
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnlimpiar.UseVisualStyleBackColor = False
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.White
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(538, 142)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 72)
        Me.btnguardar.TabIndex = 86
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'chkTaller
        '
        Me.chkTaller.AutoSize = True
        Me.chkTaller.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTaller.Location = New System.Drawing.Point(16, 142)
        Me.chkTaller.Name = "chkTaller"
        Me.chkTaller.Size = New System.Drawing.Size(69, 22)
        Me.chkTaller.TabIndex = 85
        Me.chkTaller.Text = "Taller"
        Me.chkTaller.UseVisualStyleBackColor = True
        '
        'cbodescripcion
        '
        Me.cbodescripcion.FormattingEnabled = True
        Me.cbodescripcion.Location = New System.Drawing.Point(108, 44)
        Me.cbodescripcion.Name = "cbodescripcion"
        Me.cbodescripcion.Size = New System.Drawing.Size(582, 21)
        Me.cbodescripcion.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 23)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Descripción:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(517, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 22)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Version:"
        '
        'cbodesplazamiento
        '
        Me.cbodesplazamiento.BackColor = System.Drawing.Color.White
        Me.cbodesplazamiento.FormattingEnabled = True
        Me.cbodesplazamiento.Location = New System.Drawing.Point(389, 111)
        Me.cbodesplazamiento.Name = "cbodesplazamiento"
        Me.cbodesplazamiento.Size = New System.Drawing.Size(122, 21)
        Me.cbodesplazamiento.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(261, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 23)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "Desplazamiento:"
        '
        'cbomodelo
        '
        Me.cbomodelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbomodelo.FormattingEnabled = True
        Me.cbomodelo.Location = New System.Drawing.Point(84, 110)
        Me.cbomodelo.Name = "cbomodelo"
        Me.cbomodelo.Size = New System.Drawing.Size(171, 21)
        Me.cbomodelo.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(517, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 23)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Cilindros:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 23)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Modelo:"
        '
        'cbosubmarca
        '
        Me.cbosubmarca.BackColor = System.Drawing.Color.White
        Me.cbosubmarca.FormattingEnabled = True
        Me.cbosubmarca.Location = New System.Drawing.Point(357, 79)
        Me.cbosubmarca.Name = "cbosubmarca"
        Me.cbosubmarca.Size = New System.Drawing.Size(154, 21)
        Me.cbosubmarca.TabIndex = 76
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 23)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Submarca:"
        '
        'cbomarca
        '
        Me.cbomarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbomarca.FormattingEnabled = True
        Me.cbomarca.Location = New System.Drawing.Point(84, 79)
        Me.cbomarca.Name = "cbomarca"
        Me.cbomarca.Size = New System.Drawing.Size(171, 21)
        Me.cbomarca.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 23)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Marca:"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Historic", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(699, 31)
        Me.Label8.TabIndex = 72
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(619, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 72)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtversion
        '
        Me.txtversion.Location = New System.Drawing.Point(593, 113)
        Me.txtversion.Name = "txtversion"
        Me.txtversion.Size = New System.Drawing.Size(97, 20)
        Me.txtversion.TabIndex = 95
        '
        'cbocilindros
        '
        Me.cbocilindros.BackColor = System.Drawing.Color.White
        Me.cbocilindros.FormattingEnabled = True
        Me.cbocilindros.Location = New System.Drawing.Point(593, 81)
        Me.cbocilindros.Name = "cbocilindros"
        Me.cbocilindros.Size = New System.Drawing.Size(97, 21)
        Me.cbocilindros.TabIndex = 94
        '
        'frmVehiculoR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 225)
        Me.Controls.Add(Me.txtversion)
        Me.Controls.Add(Me.cbocilindros)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.cboCliente)
        Me.Controls.Add(Me.lblcliente)
        Me.Controls.Add(Me.txtPlacas)
        Me.Controls.Add(Me.lblplaca)
        Me.Controls.Add(Me.btnlimpiar)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.chkTaller)
        Me.Controls.Add(Me.cbodescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbodesplazamiento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbomodelo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbosubmarca)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbomarca)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVehiculoR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehiculos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtid As TextBox
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents lblcliente As Label
    Friend WithEvents txtPlacas As TextBox
    Friend WithEvents lblplaca As Label
    Friend WithEvents btnlimpiar As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents chkTaller As CheckBox
    Friend WithEvents cbodescripcion As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cbodesplazamiento As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbomodelo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbosubmarca As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbomarca As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents txtversion As TextBox
    Friend WithEvents cbocilindros As ComboBox
End Class
