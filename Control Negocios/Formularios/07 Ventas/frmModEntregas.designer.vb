<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModEntregas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModEntregas))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.opttodas = New System.Windows.Forms.RadioButton()
        Me.optpendientes = New System.Windows.Forms.RadioButton()
        Me.optrealizadas = New System.Windows.Forms.RadioButton()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConsultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpini = New System.Windows.Forms.DateTimePicker()
        Me.dtpfini = New System.Windows.Forms.DateTimePicker()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbEntrega = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboFolio = New System.Windows.Forms.ComboBox()
        Me.btnEntrega = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombreClave = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Historic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1102, 31)
        Me.Label1.TabIndex = 69
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'opttodas
        '
        Me.opttodas.AutoSize = True
        Me.opttodas.Location = New System.Drawing.Point(-115, 38)
        Me.opttodas.Name = "opttodas"
        Me.opttodas.Size = New System.Drawing.Size(122, 19)
        Me.opttodas.TabIndex = 70
        Me.opttodas.TabStop = True
        Me.opttodas.Text = "Todos los registros"
        Me.opttodas.UseVisualStyleBackColor = True
        Me.opttodas.Visible = False
        '
        'optpendientes
        '
        Me.optpendientes.AutoSize = True
        Me.optpendientes.Location = New System.Drawing.Point(12, 68)
        Me.optpendientes.Name = "optpendientes"
        Me.optpendientes.Size = New System.Drawing.Size(131, 19)
        Me.optpendientes.TabIndex = 71
        Me.optpendientes.TabStop = True
        Me.optpendientes.Text = "Entregas pendientes"
        Me.optpendientes.UseVisualStyleBackColor = True
        '
        'optrealizadas
        '
        Me.optrealizadas.AutoSize = True
        Me.optrealizadas.Location = New System.Drawing.Point(12, 93)
        Me.optrealizadas.Name = "optrealizadas"
        Me.optrealizadas.Size = New System.Drawing.Size(124, 19)
        Me.optrealizadas.TabIndex = 72
        Me.optrealizadas.TabStop = True
        Me.optrealizadas.Text = "Entregas realizadas"
        Me.optrealizadas.UseVisualStyleBackColor = True
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grdcaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdcaptura.DefaultCellStyle = DataGridViewCellStyle2
        Me.grdcaptura.GridColor = System.Drawing.Color.White
        Me.grdcaptura.Location = New System.Drawing.Point(12, 125)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(1078, 474)
        Me.grdcaptura.TabIndex = 73
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsultarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 26)
        '
        'ConsultarToolStripMenuItem
        '
        Me.ConsultarToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.ConsultarToolStripMenuItem.Name = "ConsultarToolStripMenuItem"
        Me.ConsultarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem.Text = "Consultar"
        '
        'dtpini
        '
        Me.dtpini.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpini.Location = New System.Drawing.Point(692, 150)
        Me.dtpini.Name = "dtpini"
        Me.dtpini.Size = New System.Drawing.Size(97, 23)
        Me.dtpini.TabIndex = 74
        Me.dtpini.Visible = False
        '
        'dtpfini
        '
        Me.dtpfini.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpfini.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfini.Location = New System.Drawing.Point(795, 150)
        Me.dtpfini.Name = "dtpfini"
        Me.dtpfini.Size = New System.Drawing.Size(97, 23)
        Me.dtpfini.TabIndex = 75
        Me.dtpfini.Visible = False
        '
        'btnreporte
        '
        Me.btnreporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreporte.Image = CType(resources.GetObject("btnreporte.Image"), System.Drawing.Image)
        Me.btnreporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnreporte.Location = New System.Drawing.Point(1013, 42)
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(77, 76)
        Me.btnreporte.TabIndex = 76
        Me.btnreporte.Text = "Generar reporte"
        Me.btnreporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreporte.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(689, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Desde"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(792, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Hasta"
        Me.Label3.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(67, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(348, 23)
        Me.ComboBox1.TabIndex = 79
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 80
        Me.Label4.Text = "Cliente:"
        '
        'rbEntrega
        '
        Me.rbEntrega.AutoSize = True
        Me.rbEntrega.Location = New System.Drawing.Point(12, 43)
        Me.rbEntrega.Name = "rbEntrega"
        Me.rbEntrega.Size = New System.Drawing.Size(108, 19)
        Me.rbEntrega.TabIndex = 81
        Me.rbEntrega.TabStop = True
        Me.rbEntrega.Text = "Asignar Entrega"
        Me.rbEntrega.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Folio:"
        '
        'cboFolio
        '
        Me.cboFolio.FormattingEnabled = True
        Me.cboFolio.Location = New System.Drawing.Point(67, 51)
        Me.cboFolio.Name = "cboFolio"
        Me.cboFolio.Size = New System.Drawing.Size(119, 23)
        Me.cboFolio.TabIndex = 83
        '
        'btnEntrega
        '
        Me.btnEntrega.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrega.Image = CType(resources.GetObject("btnEntrega.Image"), System.Drawing.Image)
        Me.btnEntrega.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEntrega.Location = New System.Drawing.Point(930, 42)
        Me.btnEntrega.Name = "btnEntrega"
        Me.btnEntrega.Size = New System.Drawing.Size(77, 76)
        Me.btnEntrega.TabIndex = 84
        Me.btnEntrega.Text = "Asignar Entrega"
        Me.btnEntrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEntrega.UseVisualStyleBackColor = True
        Me.btnEntrega.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.cboFolio)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(481, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 84)
        Me.GroupBox1.TabIndex = 85
        Me.GroupBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(421, 26)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 84
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtNombreClave)
        Me.Panel2.Location = New System.Drawing.Point(67, 8)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(348, 66)
        Me.Panel2.TabIndex = 213
        Me.Panel2.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(14, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 15)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "PALABRA CLAVE"
        '
        'txtNombreClave
        '
        Me.txtNombreClave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNombreClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreClave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreClave.Location = New System.Drawing.Point(14, 27)
        Me.txtNombreClave.Name = "txtNombreClave"
        Me.txtNombreClave.Size = New System.Drawing.Size(320, 29)
        Me.txtNombreClave.TabIndex = 0
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(329, 51)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(107, 23)
        Me.dtpFecha.TabIndex = 85
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(223, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 86
        Me.Label6.Text = "Fecha de Entrega:"
        '
        'frmModEntregas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1102, 611)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEntrega)
        Me.Controls.Add(Me.rbEntrega)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnreporte)
        Me.Controls.Add(Me.dtpfini)
        Me.Controls.Add(Me.dtpini)
        Me.Controls.Add(Me.optrealizadas)
        Me.Controls.Add(Me.optpendientes)
        Me.Controls.Add(Me.opttodas)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModEntregas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entregas en parcialidades"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents opttodas As System.Windows.Forms.RadioButton
    Friend WithEvents optpendientes As System.Windows.Forms.RadioButton
    Friend WithEvents optrealizadas As System.Windows.Forms.RadioButton
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents dtpini As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfini As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnreporte As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ConsultarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents rbEntrega As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents cboFolio As ComboBox
    Friend WithEvents btnEntrega As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNombreClave As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFecha As DateTimePicker
End Class
