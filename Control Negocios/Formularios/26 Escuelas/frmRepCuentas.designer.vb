<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepCuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepCuentas))
        Me.cbo = New System.Windows.Forms.ComboBox()
        Me.optpendientes_grupo = New System.Windows.Forms.RadioButton()
        Me.opttodos = New System.Windows.Forms.RadioButton()
        Me.optpendientes_alumno = New System.Windows.Forms.RadioButton()
        Me.optestadocuenta = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcobrar = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnexportar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.grdcaptura = New System.Windows.Forms.DataGridView()
        Me.optgrupo = New System.Windows.Forms.RadioButton()
        Me.mCalendar2 = New System.Windows.Forms.MonthCalendar()
        Me.mCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbo
        '
        Me.cbo.FormattingEnabled = True
        Me.cbo.Location = New System.Drawing.Point(15, 175)
        Me.cbo.Name = "cbo"
        Me.cbo.Size = New System.Drawing.Size(284, 23)
        Me.cbo.TabIndex = 215
        '
        'optpendientes_grupo
        '
        Me.optpendientes_grupo.AutoSize = True
        Me.optpendientes_grupo.Location = New System.Drawing.Point(15, 145)
        Me.optpendientes_grupo.Name = "optpendientes_grupo"
        Me.optpendientes_grupo.Size = New System.Drawing.Size(180, 19)
        Me.optpendientes_grupo.TabIndex = 214
        Me.optpendientes_grupo.TabStop = True
        Me.optpendientes_grupo.Text = "Cobros pendientes por grupo"
        Me.optpendientes_grupo.UseVisualStyleBackColor = True
        '
        'opttodos
        '
        Me.opttodos.AutoSize = True
        Me.opttodos.Location = New System.Drawing.Point(15, 44)
        Me.opttodos.Name = "opttodos"
        Me.opttodos.Size = New System.Drawing.Size(123, 19)
        Me.opttodos.TabIndex = 213
        Me.opttodos.TabStop = True
        Me.opttodos.Text = "Todos los alumnos"
        Me.opttodos.UseVisualStyleBackColor = True
        '
        'optpendientes_alumno
        '
        Me.optpendientes_alumno.AutoSize = True
        Me.optpendientes_alumno.Location = New System.Drawing.Point(15, 119)
        Me.optpendientes_alumno.Name = "optpendientes_alumno"
        Me.optpendientes_alumno.Size = New System.Drawing.Size(189, 19)
        Me.optpendientes_alumno.TabIndex = 212
        Me.optpendientes_alumno.TabStop = True
        Me.optpendientes_alumno.Text = "Cobros pendientes por alumno"
        Me.optpendientes_alumno.UseVisualStyleBackColor = True
        '
        'optestadocuenta
        '
        Me.optestadocuenta.AutoSize = True
        Me.optestadocuenta.Location = New System.Drawing.Point(15, 94)
        Me.optestadocuenta.Name = "optestadocuenta"
        Me.optestadocuenta.Size = New System.Drawing.Size(180, 19)
        Me.optestadocuenta.TabIndex = 210
        Me.optestadocuenta.TabStop = True
        Me.optestadocuenta.Text = "Estado de cuenta por alumno"
        Me.optestadocuenta.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(1019, 31)
        Me.Label1.TabIndex = 218
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(15, 452)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(989, 20)
        Me.barcarga.TabIndex = 225
        Me.barcarga.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(824, 522)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Total a cobrar:"
        '
        'txtcobrar
        '
        Me.txtcobrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcobrar.Location = New System.Drawing.Point(911, 518)
        Me.txtcobrar.Name = "txtcobrar"
        Me.txtcobrar.ReadOnly = True
        Me.txtcobrar.Size = New System.Drawing.Size(93, 23)
        Me.txtcobrar.TabIndex = 223
        Me.txtcobrar.Text = "0.00"
        Me.txtcobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(15, 478)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 222
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
        Me.btnexportar.Location = New System.Drawing.Point(81, 478)
        Me.btnexportar.Name = "btnexportar"
        Me.btnexportar.Size = New System.Drawing.Size(60, 63)
        Me.btnexportar.TabIndex = 221
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
        Me.btnNuevo.Location = New System.Drawing.Point(147, 478)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 220
        Me.btnNuevo.Text = "Limpiar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
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
        Me.grdcaptura.Location = New System.Drawing.Point(15, 204)
        Me.grdcaptura.Name = "grdcaptura"
        Me.grdcaptura.ReadOnly = True
        Me.grdcaptura.RowHeadersVisible = False
        Me.grdcaptura.Size = New System.Drawing.Size(989, 268)
        Me.grdcaptura.TabIndex = 219
        '
        'optgrupo
        '
        Me.optgrupo.AutoSize = True
        Me.optgrupo.Location = New System.Drawing.Point(15, 69)
        Me.optgrupo.Name = "optgrupo"
        Me.optgrupo.Size = New System.Drawing.Size(129, 19)
        Me.optgrupo.TabIndex = 226
        Me.optgrupo.TabStop = True
        Me.optgrupo.Text = "Alumnos por grupo"
        Me.optgrupo.UseVisualStyleBackColor = True
        '
        'mCalendar2
        '
        Me.mCalendar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar2.Location = New System.Drawing.Point(756, 36)
        Me.mCalendar2.Name = "mCalendar2"
        Me.mCalendar2.TabIndex = 228
        '
        'mCalendar1
        '
        Me.mCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mCalendar1.Location = New System.Drawing.Point(499, 36)
        Me.mCalendar1.Name = "mCalendar1"
        Me.mCalendar1.TabIndex = 227
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(238, 69)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(52, 19)
        Me.RadioButton1.TabIndex = 230
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Bajas"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(238, 44)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(94, 19)
        Me.RadioButton2.TabIndex = 229
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Inscripciones"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'frmRepCuentas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1019, 553)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.mCalendar2)
        Me.Controls.Add(Me.mCalendar1)
        Me.Controls.Add(Me.optgrupo)
        Me.Controls.Add(Me.barcarga)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcobrar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnexportar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.grdcaptura)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbo)
        Me.Controls.Add(Me.optpendientes_grupo)
        Me.Controls.Add(Me.opttodos)
        Me.Controls.Add(Me.optpendientes_alumno)
        Me.Controls.Add(Me.optestadocuenta)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estados de cuenta"
        CType(Me.grdcaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo As ComboBox
    Friend WithEvents optpendientes_grupo As RadioButton
    Friend WithEvents opttodos As RadioButton
    Friend WithEvents optpendientes_alumno As RadioButton
    Friend WithEvents optestadocuenta As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents barcarga As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcobrar As TextBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnexportar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents grdcaptura As DataGridView
    Friend WithEvents optgrupo As RadioButton
    Friend WithEvents mCalendar2 As MonthCalendar
    Friend WithEvents mCalendar1 As MonthCalendar
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
