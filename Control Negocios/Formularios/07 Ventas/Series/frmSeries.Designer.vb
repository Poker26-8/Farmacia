<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeries
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeries))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtclave = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbodesc = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cbocodigo = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.btnnuevo = New System.Windows.Forms.Button()
        Me.btnserie = New System.Windows.Forms.Button()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtserie = New System.Windows.Forms.TextBox()
        Me.btnnuevos = New System.Windows.Forms.Button()
        Me.btnguardars = New System.Windows.Forms.Button()
        Me.grdseries = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdseries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblusuario)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtclave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(466, 41)
        Me.Panel1.TabIndex = 1
        '
        'txtclave
        '
        Me.txtclave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtclave.Location = New System.Drawing.Point(245, 6)
        Me.txtclave.Name = "txtclave"
        Me.txtclave.Size = New System.Drawing.Size(99, 20)
        Me.txtclave.TabIndex = 27
        Me.txtclave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtclave.UseSystemPasswordChar = True
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(170, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 20)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Usuario"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(350, 6)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(112, 20)
        Me.lblusuario.TabIndex = 182
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label48.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(397, 53)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(65, 25)
        Me.Label48.TabIndex = 80
        Me.Label48.Text = "Unidad"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtunidad
        '
        Me.txtunidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(397, 78)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(65, 23)
        Me.txtunidad.TabIndex = 79
        Me.txtunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbodesc
        '
        Me.cbodesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbodesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbodesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbodesc.FormattingEnabled = True
        Me.cbodesc.Location = New System.Drawing.Point(97, 78)
        Me.cbodesc.Name = "cbodesc"
        Me.cbodesc.Size = New System.Drawing.Size(301, 23)
        Me.cbodesc.TabIndex = 78
        '
        'Label45
        '
        Me.Label45.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(97, 53)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(301, 25)
        Me.Label45.TabIndex = 77
        Me.Label45.Text = "Descripción"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbocodigo
        '
        Me.cbocodigo.BackColor = System.Drawing.Color.White
        Me.cbocodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocodigo.FormattingEnabled = True
        Me.cbocodigo.Location = New System.Drawing.Point(12, 78)
        Me.cbocodigo.Name = "cbocodigo"
        Me.cbocodigo.Size = New System.Drawing.Size(86, 23)
        Me.cbocodigo.TabIndex = 76
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(12, 53)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(86, 25)
        Me.Label38.TabIndex = 75
        Me.Label38.Text = "Código"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(329, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 25)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Diferencia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(156, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 25)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Exis.Real"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 25)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Exis.Sistema"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 130)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(144, 23)
        Me.TextBox1.TabIndex = 84
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(156, 130)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(173, 23)
        Me.TextBox2.TabIndex = 85
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(329, 130)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(133, 23)
        Me.TextBox3.TabIndex = 86
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnnuevo
        '
        Me.btnnuevo.BackColor = System.Drawing.Color.White
        Me.btnnuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnnuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnnuevo.Location = New System.Drawing.Point(225, 159)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(75, 75)
        Me.btnnuevo.TabIndex = 89
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevo.UseVisualStyleBackColor = False
        '
        'btnserie
        '
        Me.btnserie.BackColor = System.Drawing.Color.White
        Me.btnserie.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnserie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnserie.Image = CType(resources.GetObject("btnserie.Image"), System.Drawing.Image)
        Me.btnserie.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnserie.Location = New System.Drawing.Point(387, 159)
        Me.btnserie.Name = "btnserie"
        Me.btnserie.Size = New System.Drawing.Size(75, 75)
        Me.btnserie.TabIndex = 88
        Me.btnserie.Text = "Salir"
        Me.btnserie.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnserie.UseVisualStyleBackColor = False
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.Color.White
        Me.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardar.Location = New System.Drawing.Point(306, 159)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 75)
        Me.btnguardar.TabIndex = 87
        Me.btnguardar.Text = "Guadar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnnuevos)
        Me.Panel2.Controls.Add(Me.btnguardars)
        Me.Panel2.Controls.Add(Me.grdseries)
        Me.Panel2.Controls.Add(Me.txtserie)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 240)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(466, 288)
        Me.Panel2.TabIndex = 90
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(466, 28)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Serie"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtserie
        '
        Me.txtserie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtserie.Location = New System.Drawing.Point(5, 31)
        Me.txtserie.Name = "txtserie"
        Me.txtserie.Size = New System.Drawing.Size(457, 20)
        Me.txtserie.TabIndex = 20
        '
        'btnnuevos
        '
        Me.btnnuevos.BackColor = System.Drawing.Color.White
        Me.btnnuevos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnnuevos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnnuevos.Image = CType(resources.GetObject("btnnuevos.Image"), System.Drawing.Image)
        Me.btnnuevos.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnnuevos.Location = New System.Drawing.Point(306, 227)
        Me.btnnuevos.Name = "btnnuevos"
        Me.btnnuevos.Size = New System.Drawing.Size(75, 56)
        Me.btnnuevos.TabIndex = 24
        Me.btnnuevos.Text = "Nuevo"
        Me.btnnuevos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnnuevos.UseVisualStyleBackColor = False
        '
        'btnguardars
        '
        Me.btnguardars.BackColor = System.Drawing.Color.White
        Me.btnguardars.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnguardars.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardars.Image = CType(resources.GetObject("btnguardars.Image"), System.Drawing.Image)
        Me.btnguardars.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnguardars.Location = New System.Drawing.Point(385, 227)
        Me.btnguardars.Name = "btnguardars"
        Me.btnguardars.Size = New System.Drawing.Size(78, 56)
        Me.btnguardars.TabIndex = 23
        Me.btnguardars.Text = "Guadar"
        Me.btnguardars.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnguardars.UseVisualStyleBackColor = False
        '
        'grdseries
        '
        Me.grdseries.AllowUserToAddRows = False
        Me.grdseries.AllowUserToDeleteRows = False
        Me.grdseries.BackgroundColor = System.Drawing.Color.White
        Me.grdseries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdseries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.grdseries.Location = New System.Drawing.Point(5, 57)
        Me.grdseries.Name = "grdseries"
        Me.grdseries.ReadOnly = True
        Me.grdseries.RowHeadersVisible = False
        Me.grdseries.Size = New System.Drawing.Size(457, 164)
        Me.grdseries.TabIndex = 22
        '
        'Column1
        '
        Me.Column1.HeaderText = "código"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Descripción"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 239
        '
        'Column3
        '
        Me.Column3.HeaderText = "Serie"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 120
        '
        'frmSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(466, 528)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnnuevo)
        Me.Controls.Add(Me.btnserie)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbodesc)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.cbocodigo)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSeries"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Series"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdseries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtclave As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents lblusuario As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents txtunidad As TextBox
    Friend WithEvents cbodesc As ComboBox
    Friend WithEvents Label45 As Label
    Friend WithEvents cbocodigo As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents btnnuevo As Button
    Friend WithEvents btnserie As Button
    Friend WithEvents btnguardar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnnuevos As Button
    Friend WithEvents btnguardars As Button
    Friend WithEvents grdseries As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents txtserie As TextBox
    Friend WithEvents Label8 As Label
End Class
