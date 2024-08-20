<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAjusteSerie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjusteSerie))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.cbodesc = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cbocodigo = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cboserie = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grdSerie = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdiferencia = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtfisica = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsistema = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.btnlimpia_lote = New System.Windows.Forms.Button()
        Me.btnguarda_lote = New System.Windows.Forms.Button()
        Me.chkmerma = New System.Windows.Forms.CheckBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        CType(Me.grdSerie, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Size = New System.Drawing.Size(485, 31)
        Me.Label1.TabIndex = 6
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label48
        '
        Me.Label48.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label48.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(417, 41)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(59, 15)
        Me.Label48.TabIndex = 80
        Me.Label48.Text = "Unidad"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtunidad
        '
        Me.txtunidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(417, 55)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(60, 23)
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
        Me.cbodesc.Location = New System.Drawing.Point(98, 55)
        Me.cbodesc.Name = "cbodesc"
        Me.cbodesc.Size = New System.Drawing.Size(319, 23)
        Me.cbodesc.TabIndex = 78
        '
        'Label45
        '
        Me.Label45.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(98, 41)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(319, 15)
        Me.Label45.TabIndex = 77
        Me.Label45.Text = "Descripción"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbocodigo
        '
        Me.cbocodigo.BackColor = System.Drawing.Color.White
        Me.cbocodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocodigo.FormattingEnabled = True
        Me.cbocodigo.Location = New System.Drawing.Point(12, 55)
        Me.cbocodigo.Name = "cbocodigo"
        Me.cbocodigo.Size = New System.Drawing.Size(86, 23)
        Me.cbocodigo.TabIndex = 76
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(12, 41)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(86, 15)
        Me.Label38.TabIndex = 75
        Me.Label38.Text = "Código"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboserie
        '
        Me.cboserie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboserie.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cboserie.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboserie.FormattingEnabled = True
        Me.cboserie.Location = New System.Drawing.Point(12, 164)
        Me.cboserie.Name = "cboserie"
        Me.cboserie.Size = New System.Drawing.Size(404, 23)
        Me.cboserie.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(404, 15)
        Me.Label3.TabIndex = 83
        Me.Label3.Text = "Serie"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grdSerie
        '
        Me.grdSerie.AllowUserToAddRows = False
        Me.grdSerie.AllowUserToDeleteRows = False
        Me.grdSerie.BackgroundColor = System.Drawing.Color.White
        Me.grdSerie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSerie.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column1})
        Me.grdSerie.Location = New System.Drawing.Point(12, 193)
        Me.grdSerie.Name = "grdSerie"
        Me.grdSerie.ReadOnly = True
        Me.grdSerie.RowHeadersVisible = False
        Me.grdSerie.Size = New System.Drawing.Size(404, 128)
        Me.grdSerie.TabIndex = 85
        '
        'Column2
        '
        Me.Column2.HeaderText = "Código"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column1
        '
        Me.Column1.HeaderText = "Serie"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 320
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(418, 81)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 87
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(418, 150)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(59, 63)
        Me.btnNuevo.TabIndex = 86
        Me.btnNuevo.Text = "Limpiar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(289, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 15)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Diferencia"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtdiferencia
        '
        Me.txtdiferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiferencia.Location = New System.Drawing.Point(289, 95)
        Me.txtdiferencia.Name = "txtdiferencia"
        Me.txtdiferencia.Size = New System.Drawing.Size(128, 23)
        Me.txtdiferencia.TabIndex = 92
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(135, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 15)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Existencia física"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtfisica
        '
        Me.txtfisica.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfisica.Location = New System.Drawing.Point(135, 95)
        Me.txtfisica.Name = "txtfisica"
        Me.txtfisica.Size = New System.Drawing.Size(154, 23)
        Me.txtfisica.TabIndex = 90
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(123, 15)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Existencia en sistema"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtsistema
        '
        Me.txtsistema.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsistema.Location = New System.Drawing.Point(12, 95)
        Me.txtsistema.Name = "txtsistema"
        Me.txtsistema.Size = New System.Drawing.Size(123, 23)
        Me.txtsistema.TabIndex = 88
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(237, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 15)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "Usuario:"
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcontraseña.Location = New System.Drawing.Point(293, 6)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(85, 20)
        Me.txtcontraseña.TabIndex = 185
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(382, 6)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 20)
        Me.lblusuario.TabIndex = 184
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnlimpia_lote
        '
        Me.btnlimpia_lote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnlimpia_lote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpia_lote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpia_lote.Location = New System.Drawing.Point(419, 232)
        Me.btnlimpia_lote.Name = "btnlimpia_lote"
        Me.btnlimpia_lote.Size = New System.Drawing.Size(58, 24)
        Me.btnlimpia_lote.TabIndex = 188
        Me.btnlimpia_lote.Text = "Limpiar"
        Me.btnlimpia_lote.UseVisualStyleBackColor = False
        '
        'btnguarda_lote
        '
        Me.btnguarda_lote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnguarda_lote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguarda_lote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguarda_lote.Location = New System.Drawing.Point(419, 262)
        Me.btnguarda_lote.Name = "btnguarda_lote"
        Me.btnguarda_lote.Size = New System.Drawing.Size(59, 24)
        Me.btnguarda_lote.TabIndex = 187
        Me.btnguarda_lote.Text = "Guardar"
        Me.btnguarda_lote.UseVisualStyleBackColor = False
        '
        'chkmerma
        '
        Me.chkmerma.AutoSize = True
        Me.chkmerma.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmerma.Location = New System.Drawing.Point(12, 124)
        Me.chkmerma.Name = "chkmerma"
        Me.chkmerma.Size = New System.Drawing.Size(140, 19)
        Me.chkmerma.TabIndex = 189
        Me.chkmerma.Text = "Afecta costo de venta"
        Me.chkmerma.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(419, 292)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(59, 24)
        Me.btnEliminar.TabIndex = 190
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        Me.btnEliminar.Visible = False
        '
        'frmAjusteSerie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(485, 329)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.chkmerma)
        Me.Controls.Add(Me.btnlimpia_lote)
        Me.Controls.Add(Me.btnguarda_lote)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtdiferencia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtfisica)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtsistema)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.grdSerie)
        Me.Controls.Add(Me.cboserie)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbodesc)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.cbocodigo)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAjusteSerie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de Series"
        CType(Me.grdSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents txtunidad As TextBox
    Friend WithEvents cbodesc As ComboBox
    Friend WithEvents Label45 As Label
    Friend WithEvents cbocodigo As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents cboserie As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents grdSerie As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtdiferencia As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtfisica As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsistema As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtcontraseña As TextBox
    Friend WithEvents lblusuario As Label
    Friend WithEvents btnlimpia_lote As Button
    Friend WithEvents btnguarda_lote As Button
    Friend WithEvents chkmerma As CheckBox
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents btnEliminar As Button
End Class
