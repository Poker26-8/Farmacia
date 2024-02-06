<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCompras))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.optabonosproves = New System.Windows.Forms.RadioButton()
        Me.optreibidosgrupo = New System.Windows.Forms.RadioButton()
        Me.optrecibidosdepto = New System.Windows.Forms.RadioButton()
        Me.optrecibidos = New System.Windows.Forms.RadioButton()
        Me.optproveedor = New System.Windows.Forms.RadioButton()
        Me.opttotales = New System.Windows.Forms.RadioButton()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optabonosprove = New System.Windows.Forms.RadioButton()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.cms1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminarCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnreporte = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.optnotascred = New System.Windows.Forms.RadioButton()
        Me.optdevueltos = New System.Windows.Forms.RadioButton()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        Me.optnotascredprov = New System.Windows.Forms.RadioButton()
        Me.optconcentrado = New System.Windows.Forms.RadioButton()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cms1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 179)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(231, 23)
        Me.ComboBox1.TabIndex = 70
        Me.ComboBox1.Visible = False
        '
        'optabonosproves
        '
        Me.optabonosproves.AutoSize = True
        Me.optabonosproves.Location = New System.Drawing.Point(259, 41)
        Me.optabonosproves.Name = "optabonosproves"
        Me.optabonosproves.Size = New System.Drawing.Size(143, 19)
        Me.optabonosproves.TabIndex = 69
        Me.optabonosproves.TabStop = True
        Me.optabonosproves.Text = "Abonos a proveedores"
        Me.optabonosproves.UseVisualStyleBackColor = True
        '
        'optreibidosgrupo
        '
        Me.optreibidosgrupo.AutoSize = True
        Me.optreibidosgrupo.Location = New System.Drawing.Point(11, 151)
        Me.optreibidosgrupo.Name = "optreibidosgrupo"
        Me.optreibidosgrupo.Size = New System.Drawing.Size(186, 19)
        Me.optreibidosgrupo.TabIndex = 68
        Me.optreibidosgrupo.TabStop = True
        Me.optreibidosgrupo.Text = "Productos recibidos por grupo"
        Me.optreibidosgrupo.UseVisualStyleBackColor = True
        '
        'optrecibidosdepto
        '
        Me.optrecibidosdepto.AutoSize = True
        Me.optrecibidosdepto.Location = New System.Drawing.Point(11, 129)
        Me.optrecibidosdepto.Name = "optrecibidosdepto"
        Me.optrecibidosdepto.Size = New System.Drawing.Size(229, 19)
        Me.optrecibidosdepto.TabIndex = 67
        Me.optrecibidosdepto.TabStop = True
        Me.optrecibidosdepto.Text = "Productos recibidos por departamento"
        Me.optrecibidosdepto.UseVisualStyleBackColor = True
        '
        'optrecibidos
        '
        Me.optrecibidos.AutoSize = True
        Me.optrecibidos.Location = New System.Drawing.Point(11, 85)
        Me.optrecibidos.Name = "optrecibidos"
        Me.optrecibidos.Size = New System.Drawing.Size(130, 19)
        Me.optrecibidos.TabIndex = 66
        Me.optrecibidos.TabStop = True
        Me.optrecibidos.Text = "Productos recibidos"
        Me.optrecibidos.UseVisualStyleBackColor = True
        '
        'optproveedor
        '
        Me.optproveedor.AutoSize = True
        Me.optproveedor.Location = New System.Drawing.Point(11, 63)
        Me.optproveedor.Name = "optproveedor"
        Me.optproveedor.Size = New System.Drawing.Size(151, 19)
        Me.optproveedor.TabIndex = 65
        Me.optproveedor.TabStop = True
        Me.optproveedor.Text = "Compras por proveedor"
        Me.optproveedor.UseVisualStyleBackColor = True
        '
        'opttotales
        '
        Me.opttotales.AutoSize = True
        Me.opttotales.Location = New System.Drawing.Point(11, 41)
        Me.opttotales.Name = "opttotales"
        Me.opttotales.Size = New System.Drawing.Size(111, 19)
        Me.opttotales.TabIndex = 64
        Me.opttotales.TabStop = True
        Me.opttotales.Text = "Compras totales"
        Me.opttotales.UseVisualStyleBackColor = True
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(719, 40)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 63
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(462, 40)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 62
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
        Me.Label1.Size = New System.Drawing.Size(977, 31)
        Me.Label1.TabIndex = 71
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'optabonosprove
        '
        Me.optabonosprove.AutoSize = True
        Me.optabonosprove.Location = New System.Drawing.Point(259, 63)
        Me.optabonosprove.Name = "optabonosprove"
        Me.optabonosprove.Size = New System.Drawing.Size(144, 19)
        Me.optabonosprove.TabIndex = 72
        Me.optabonosprove.TabStop = True
        Me.optabonosprove.Text = "Abonos por proveedor"
        Me.optabonosprove.UseVisualStyleBackColor = True
        '
        'grdcaptura
        '
        Me.grdcaptura.AllowUserToAddRows = False
        Me.grdcaptura.AllowUserToDeleteRows = False
        Me.grdcaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdcaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdcaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdcaptura.ContextMenuStrip = Me.cms1
        Me.grdcaptura.Location = New System.Drawing.Point(9, 208)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(958, 255)
        Me.grdcaptura.TabIndex = 73
        '
        'cms1
        '
        Me.cms1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminarCompraToolStripMenuItem})
        Me.cms1.Name = "cms1"
        Me.cms1.Size = New System.Drawing.Size(162, 26)
        '
        'EliminarCompraToolStripMenuItem
        '
        Me.EliminarCompraToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.EliminarCompraToolStripMenuItem.Name = "EliminarCompraToolStripMenuItem"
        Me.EliminarCompraToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.EliminarCompraToolStripMenuItem.Text = "Eliminar compra"
        '
        'btnreporte
        '
        Me.btnreporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnreporte.BackgroundImage = CType(resources.GetObject("btnreporte.BackgroundImage"), System.Drawing.Image)
        Me.btnreporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnreporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreporte.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnreporte.Location = New System.Drawing.Point(9, 469)
        Me.btnreporte.Name = "btnreporte"
        Me.btnreporte.Size = New System.Drawing.Size(60, 63)
        Me.btnreporte.TabIndex = 76
        Me.btnreporte.Text = "Reporte"
        Me.btnreporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnreporte.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.BackgroundImage = CType(resources.GetObject("btnexportar.BackgroundImage"), System.Drawing.Image)
        Me.btnexportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Location = New System.Drawing.Point(75, 469)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(60, 63)
        Me.btnexportar.TabIndex = 75
        Me.btnexportar.Text = "Exportar"
        Me.btnexportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnexportar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(141, 469)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 74
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'optnotascred
        '
        Me.optnotascred.AutoSize = True
        Me.optnotascred.Location = New System.Drawing.Point(259, 85)
        Me.optnotascred.Name = "optnotascred"
        Me.optnotascred.Size = New System.Drawing.Size(112, 19)
        Me.optnotascred.TabIndex = 78
        Me.optnotascred.TabStop = True
        Me.optnotascred.Text = "Notas de crédito"
        Me.optnotascred.UseVisualStyleBackColor = True
        '
        'optdevueltos
        '
        Me.optdevueltos.AutoSize = True
        Me.optdevueltos.Location = New System.Drawing.Point(259, 129)
        Me.optdevueltos.Name = "optdevueltos"
        Me.optdevueltos.Size = New System.Drawing.Size(133, 19)
        Me.optdevueltos.TabIndex = 77
        Me.optdevueltos.TabStop = True
        Me.optdevueltos.Text = "Productos devueltos"
        Me.optdevueltos.UseVisualStyleBackColor = True
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(9, 443)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(958, 20)
        Me.barcarga.TabIndex = 206
        Me.barcarga.Visible = False
        '
        'optnotascredprov
        '
        Me.optnotascredprov.AutoSize = True
        Me.optnotascredprov.Location = New System.Drawing.Point(259, 107)
        Me.optnotascredprov.Name = "optnotascredprov"
        Me.optnotascredprov.Size = New System.Drawing.Size(190, 19)
        Me.optnotascredprov.TabIndex = 207
        Me.optnotascredprov.TabStop = True
        Me.optnotascredprov.Text = "Notas de crédito por proveedor"
        Me.optnotascredprov.UseVisualStyleBackColor = True
        '
        'optconcentrado
        '
        Me.optconcentrado.AutoSize = True
        Me.optconcentrado.Location = New System.Drawing.Point(11, 107)
        Me.optconcentrado.Name = "optconcentrado"
        Me.optconcentrado.Size = New System.Drawing.Size(208, 19)
        Me.optconcentrado.TabIndex = 208
        Me.optconcentrado.TabStop = True
        Me.optconcentrado.Text = "Productos recibidos (concentrado)"
        Me.optconcentrado.UseVisualStyleBackColor = True
        '
        'frmRepCompras
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(977, 540)
        Me.Controls.Add(Me.optconcentrado)
        Me.Controls.Add(Me.optnotascredprov)
        Me.Controls.Add(Me.barcarga)
        Me.Controls.Add(Me.optnotascred)
        Me.Controls.Add(Me.optdevueltos)
        Me.Controls.Add(Me.btnreporte)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.optabonosprove)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.optabonosproves)
        Me.Controls.Add(Me.optreibidosgrupo)
        Me.Controls.Add(Me.optrecibidosdepto)
        Me.Controls.Add(Me.optrecibidos)
        Me.Controls.Add(Me.optproveedor)
        Me.Controls.Add(Me.opttotales)
        Me.Controls.Add(Me.mCalendar2)
        Me.Controls.Add(Me.mCalendar1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(983, 569)
        Me.Name = "frmRepCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de compras"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cms1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents optabonosproves As System.Windows.Forms.RadioButton
    Friend WithEvents optreibidosgrupo As System.Windows.Forms.RadioButton
    Friend WithEvents optrecibidosdepto As System.Windows.Forms.RadioButton
    Friend WithEvents optrecibidos As System.Windows.Forms.RadioButton
    Friend WithEvents optproveedor As System.Windows.Forms.RadioButton
    Friend WithEvents opttotales As System.Windows.Forms.RadioButton
    Friend WithEvents mCalendar2 As System.Windows.Forms.MonthCalendar
    Friend WithEvents mCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optabonosprove As System.Windows.Forms.RadioButton
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btnreporte As System.Windows.Forms.Button
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents optnotascred As System.Windows.Forms.RadioButton
    Friend WithEvents optdevueltos As System.Windows.Forms.RadioButton
    Friend WithEvents barcarga As System.Windows.Forms.ProgressBar
    Friend WithEvents optnotascredprov As System.Windows.Forms.RadioButton
    Friend WithEvents optconcentrado As RadioButton
    Friend WithEvents cms1 As ContextMenuStrip
    Friend WithEvents EliminarCompraToolStripMenuItem As ToolStripMenuItem
End Class
