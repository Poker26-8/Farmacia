<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAjusteInv
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjusteInv))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbodesc = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cbocodigo = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtunidad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtsistema = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtfisica = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdiferencia = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.cmsElimina = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminaLoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnlimpia_lote = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpcaduca = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.btnguarda_lote = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtlote = New System.Windows.Forms.TextBox()
        Me.chkmerma = New System.Windows.Forms.CheckBox()
        Me.lblusuario = New System.Windows.Forms.Label()
        Me.txtcontraseña = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsElimina.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(450, 31)
        Me.Label1.TabIndex = 5
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbodesc
        '
        Me.cbodesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbodesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cbodesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbodesc.FormattingEnabled = True
        Me.cbodesc.Location = New System.Drawing.Point(92, 54)
        Me.cbodesc.Name = "cbodesc"
        Me.cbodesc.Size = New System.Drawing.Size(286, 23)
        Me.cbodesc.TabIndex = 56
        '
        'Label45
        '
        Me.Label45.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label45.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.White
        Me.Label45.Location = New System.Drawing.Point(92, 40)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(286, 15)
        Me.Label45.TabIndex = 55
        Me.Label45.Text = "Descripción"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbocodigo
        '
        Me.cbocodigo.BackColor = System.Drawing.Color.White
        Me.cbocodigo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbocodigo.FormattingEnabled = True
        Me.cbocodigo.Location = New System.Drawing.Point(7, 54)
        Me.cbocodigo.Name = "cbocodigo"
        Me.cbocodigo.Size = New System.Drawing.Size(86, 23)
        Me.cbocodigo.TabIndex = 54
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.White
        Me.Label38.Location = New System.Drawing.Point(7, 40)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(86, 15)
        Me.Label38.TabIndex = 53
        Me.Label38.Text = "Código"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label48.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label48.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.Color.White
        Me.Label48.Location = New System.Drawing.Point(377, 40)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(65, 15)
        Me.Label48.TabIndex = 74
        Me.Label48.Text = "Unidad"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtunidad
        '
        Me.txtunidad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtunidad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunidad.Location = New System.Drawing.Point(377, 54)
        Me.txtunidad.Name = "txtunidad"
        Me.txtunidad.Size = New System.Drawing.Size(65, 23)
        Me.txtunidad.TabIndex = 73
        Me.txtunidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 15)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "Existencia en sistema"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtsistema
        '
        Me.txtsistema.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsistema.Location = New System.Drawing.Point(7, 94)
        Me.txtsistema.Name = "txtsistema"
        Me.txtsistema.Size = New System.Drawing.Size(124, 23)
        Me.txtsistema.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(130, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 15)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Existencia física"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtfisica
        '
        Me.txtfisica.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfisica.Location = New System.Drawing.Point(130, 94)
        Me.txtfisica.Name = "txtfisica"
        Me.txtfisica.Size = New System.Drawing.Size(124, 23)
        Me.txtfisica.TabIndex = 77
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(253, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 15)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Diferencia"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtdiferencia
        '
        Me.txtdiferencia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiferencia.Location = New System.Drawing.Point(253, 94)
        Me.txtdiferencia.Name = "txtdiferencia"
        Me.txtdiferencia.Size = New System.Drawing.Size(124, 23)
        Me.txtdiferencia.TabIndex = 79
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackgroundImage = CType(resources.GetObject("btnGuardar.BackgroundImage"), System.Drawing.Image)
        Me.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(382, 83)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 63)
        Me.btnGuardar.TabIndex = 82
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
        Me.btnNuevo.Location = New System.Drawing.Point(382, 152)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 81
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtid)
        Me.GroupBox2.Controls.Add(Me.grdcaptura)
        Me.GroupBox2.Controls.Add(Me.btnlimpia_lote)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpcaduca)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtcantidad)
        Me.GroupBox2.Controls.Add(Me.btnguarda_lote)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtlote)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 143)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 176)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(160, 45)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(41, 23)
        Me.txtid.TabIndex = 131
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ContextMenuStrip = Me.cmsElimina
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(10, 74)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(350, 91)
        Me.grdcaptura.TabIndex = 130
        '
        'cmsElimina
        '
        Me.cmsElimina.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminaLoteToolStripMenuItem})
        Me.cmsElimina.Name = "cmsElimina"
        Me.cmsElimina.Size = New System.Drawing.Size(137, 26)
        '
        'EliminaLoteToolStripMenuItem
        '
        Me.EliminaLoteToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EliminaLoteToolStripMenuItem.Name = "EliminaLoteToolStripMenuItem"
        Me.EliminaLoteToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.EliminaLoteToolStripMenuItem.Text = "Elimina lote"
        '
        'btnlimpia_lote
        '
        Me.btnlimpia_lote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnlimpia_lote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlimpia_lote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpia_lote.Location = New System.Drawing.Point(218, 44)
        Me.btnlimpia_lote.Name = "btnlimpia_lote"
        Me.btnlimpia_lote.Size = New System.Drawing.Size(68, 24)
        Me.btnlimpia_lote.TabIndex = 129
        Me.btnlimpia_lote.Text = "Limpiar"
        Me.btnlimpia_lote.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(192, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Caducidad:"
        '
        'dtpcaduca
        '
        Me.dtpcaduca.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpcaduca.Location = New System.Drawing.Point(265, 16)
        Me.dtpcaduca.Name = "dtpcaduca"
        Me.dtpcaduca.Size = New System.Drawing.Size(95, 23)
        Me.dtpcaduca.TabIndex = 127
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Cantidad:"
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(71, 45)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(83, 23)
        Me.txtcantidad.TabIndex = 125
        '
        'btnguarda_lote
        '
        Me.btnguarda_lote.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnguarda_lote.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguarda_lote.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguarda_lote.Location = New System.Drawing.Point(292, 44)
        Me.btnguarda_lote.Name = "btnguarda_lote"
        Me.btnguarda_lote.Size = New System.Drawing.Size(68, 24)
        Me.btnguarda_lote.TabIndex = 124
        Me.btnguarda_lote.Text = "Guardar"
        Me.btnguarda_lote.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Lote:"
        '
        'txtlote
        '
        Me.txtlote.Location = New System.Drawing.Point(46, 16)
        Me.txtlote.Name = "txtlote"
        Me.txtlote.Size = New System.Drawing.Size(139, 23)
        Me.txtlote.TabIndex = 4
        '
        'chkmerma
        '
        Me.chkmerma.AutoSize = True
        Me.chkmerma.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmerma.Location = New System.Drawing.Point(7, 125)
        Me.chkmerma.Name = "chkmerma"
        Me.chkmerma.Size = New System.Drawing.Size(140, 19)
        Me.chkmerma.TabIndex = 84
        Me.chkmerma.Text = "Afecta costo de venta"
        Me.chkmerma.UseVisualStyleBackColor = True
        '
        'lblusuario
        '
        Me.lblusuario.BackColor = System.Drawing.Color.Navy
        Me.lblusuario.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusuario.ForeColor = System.Drawing.Color.White
        Me.lblusuario.Location = New System.Drawing.Point(350, 5)
        Me.lblusuario.Name = "lblusuario"
        Me.lblusuario.Size = New System.Drawing.Size(92, 22)
        Me.lblusuario.TabIndex = 181
        Me.lblusuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcontraseña
        '
        Me.txtcontraseña.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtcontraseña.Location = New System.Drawing.Point(263, 5)
        Me.txtcontraseña.Name = "txtcontraseña"
        Me.txtcontraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontraseña.Size = New System.Drawing.Size(85, 22)
        Me.txtcontraseña.TabIndex = 182
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(207, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 15)
        Me.Label12.TabIndex = 183
        Me.Label12.Text = "Usuario:"
        '
        'frmAjusteInv
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(450, 327)
        Me.ContextMenuStrip = Me.cmsElimina
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtcontraseña)
        Me.Controls.Add(Me.lblusuario)
        Me.Controls.Add(Me.chkmerma)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtdiferencia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtfisica)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtsistema)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.txtunidad)
        Me.Controls.Add(Me.cbodesc)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.cbocodigo)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjusteInv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de inventario"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsElimina.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbodesc As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cbocodigo As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtunidad As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtsistema As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtfisica As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdiferencia As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btnlimpia_lote As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpcaduca As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents btnguarda_lote As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtlote As System.Windows.Forms.TextBox
    Friend WithEvents chkmerma As System.Windows.Forms.CheckBox
    Friend WithEvents lblusuario As System.Windows.Forms.Label
    Friend WithEvents txtcontraseña As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmsElimina As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminaLoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtid As System.Windows.Forms.TextBox
End Class
