<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCtsCobrar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCtsCobrar))
        Me.cbo = New System.Windows.Forms.ComboBox()
        Me.optfechacobro = New System.Windows.Forms.RadioButton()
        Me.opttodos = New System.Windows.Forms.RadioButton()
        Me.optnotascliente = New System.Windows.Forms.RadioButton()
        Me.optvencimientos = New System.Windows.Forms.RadioButton()
        Me.optestadocuenta = New System.Windows.Forms.RadioButton()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcobrar = New System.Windows.Forms.TextBox()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbo
        '
        Me.cbo.FormattingEnabled = True
        Me.cbo.Location = New System.Drawing.Point(8, 179)
        Me.cbo.Name = "cbo"
        Me.cbo.Size = New System.Drawing.Size(284, 23)
        Me.cbo.TabIndex = 67
        '
        'optfechacobro
        '
        Me.optfechacobro.AutoSize = True
        Me.optfechacobro.Location = New System.Drawing.Point(8, 154)
        Me.optfechacobro.Name = "optfechacobro"
        Me.optfechacobro.Size = New System.Drawing.Size(106, 19)
        Me.optfechacobro.TabIndex = 66
        Me.optfechacobro.TabStop = True
        Me.optfechacobro.Text = "Fecha de cobro"
        Me.optfechacobro.UseVisualStyleBackColor = True
        '
        'opttodos
        '
        Me.opttodos.AutoSize = True
        Me.opttodos.Location = New System.Drawing.Point(8, 126)
        Me.opttodos.Name = "opttodos"
        Me.opttodos.Size = New System.Drawing.Size(117, 19)
        Me.opttodos.TabIndex = 65
        Me.opttodos.TabStop = True
        Me.opttodos.Text = "Todos los clientes"
        Me.opttodos.UseVisualStyleBackColor = True
        '
        'optnotascliente
        '
        Me.optnotascliente.AutoSize = True
        Me.optnotascliente.Location = New System.Drawing.Point(8, 98)
        Me.optnotascliente.Name = "optnotascliente"
        Me.optnotascliente.Size = New System.Drawing.Size(163, 19)
        Me.optnotascliente.TabIndex = 64
        Me.optnotascliente.TabStop = True
        Me.optnotascliente.Text = "Notas de venta por cliente"
        Me.optnotascliente.UseVisualStyleBackColor = True
        '
        'optvencimientos
        '
        Me.optvencimientos.AutoSize = True
        Me.optvencimientos.Location = New System.Drawing.Point(8, 70)
        Me.optvencimientos.Name = "optvencimientos"
        Me.optvencimientos.Size = New System.Drawing.Size(155, 19)
        Me.optvencimientos.TabIndex = 63
        Me.optvencimientos.TabStop = True
        Me.optvencimientos.Text = "Vencimientos por cliente"
        Me.optvencimientos.UseVisualStyleBackColor = True
        '
        'optestadocuenta
        '
        Me.optestadocuenta.AutoSize = True
        Me.optestadocuenta.Location = New System.Drawing.Point(8, 42)
        Me.optestadocuenta.Name = "optestadocuenta"
        Me.optestadocuenta.Size = New System.Drawing.Size(174, 19)
        Me.optestadocuenta.TabIndex = 62
        Me.optestadocuenta.TabStop = True
        Me.optestadocuenta.Text = "Estado de cuenta por cliente"
        Me.optestadocuenta.UseVisualStyleBackColor = True
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(638, 40)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 209
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(381, 40)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 208
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
        Me.Label1.Size = New System.Drawing.Size(894, 31)
        Me.Label1.TabIndex = 210
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.grdcaptura.GridColor = System.Drawing.Color.WhiteSmoke
        Me.grdcaptura.Location = New System.Drawing.Point(8, 208)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(878, 308)
        Me.grdcaptura.TabIndex = 211
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(8, 522)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 214
        Me.btnEliminar.Text = "Reporte"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnexportar
        '
        Me.btnexportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnexportar.BackgroundImage = CType(resources.GetObject("btnexportar.BackgroundImage"), System.Drawing.Image)
        Me.btnexportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnexportar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnexportar.Location = New System.Drawing.Point(74, 522)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(60, 63)
        Me.btnexportar.TabIndex = 213
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
        Me.btnNuevo.Location = New System.Drawing.Point(140, 522)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 212
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(706, 526)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Total a cobrar:"
        '
        'txtcobrar
        '
        Me.txtcobrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcobrar.Location = New System.Drawing.Point(793, 522)
        Me.txtcobrar.Name = "txtcobrar"
        Me.txtcobrar.ReadOnly = True
        Me.txtcobrar.Size = New System.Drawing.Size(93, 23)
        Me.txtcobrar.TabIndex = 215
        Me.txtcobrar.Text = "0.00"
        Me.txtcobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(8, 496)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(878, 20)
        Me.barcarga.TabIndex = 217
        Me.barcarga.Visible = False
        '
        'frmRepCtsCobrar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(894, 595)
        Me.Controls.Add(Me.barcarga)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcobrar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.mCalendar2)
        Me.Controls.Add(Me.mCalendar1)
        Me.Controls.Add(Me.cbo)
        Me.Controls.Add(Me.optfechacobro)
        Me.Controls.Add(Me.opttodos)
        Me.Controls.Add(Me.optnotascliente)
        Me.Controls.Add(Me.optvencimientos)
        Me.Controls.Add(Me.optestadocuenta)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(903, 565)
        Me.Name = "frmRepCtsCobrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de cuentas por cobrar"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo As System.Windows.Forms.ComboBox
    Friend WithEvents optfechacobro As System.Windows.Forms.RadioButton
    Friend WithEvents opttodos As System.Windows.Forms.RadioButton
    Friend WithEvents optnotascliente As System.Windows.Forms.RadioButton
    Friend WithEvents optvencimientos As System.Windows.Forms.RadioButton
    Friend WithEvents optestadocuenta As System.Windows.Forms.RadioButton
    Friend WithEvents mCalendar2 As System.Windows.Forms.MonthCalendar
    Friend WithEvents mCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdcaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnexportar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcobrar As System.Windows.Forms.TextBox
    Friend WithEvents barcarga As System.Windows.Forms.ProgressBar
End Class
