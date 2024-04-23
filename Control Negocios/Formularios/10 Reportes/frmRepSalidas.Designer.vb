<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRepSalidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepSalidas))
        Me.rbGastosOperacion = New System.Windows.Forms.RadioButton()
        Me.rbGastosAdministracion = New System.Windows.Forms.RadioButton()
        Me.rbGastosVenta = New System.Windows.Forms.RadioButton()
        Me.rbAbonoCredito = New System.Windows.Forms.RadioButton()
        Me.rbAnticipoProveedor = New System.Windows.Forms.RadioButton()
        Me.rbPrestamoEmpleado = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mchasta = New System.Windows.Forms.MonthCalendar()
        Me.mcdesde = New System.Windows.Forms.MonthCalendar()
        Me.cboDatos = New System.Windows.Forms.ComboBox()
        Me.rbTodosGastos = New System.Windows.Forms.RadioButton()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbotres = New System.Windows.Forms.ComboBox()
        Me.optNomina = New System.Windows.Forms.RadioButton()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbGastosOperacion
        '
        Me.rbGastosOperacion.AutoSize = True
        Me.rbGastosOperacion.Location = New System.Drawing.Point(10, 148)
        Me.rbGastosOperacion.Name = "rbGastosOperacion"
        Me.rbGastosOperacion.Size = New System.Drawing.Size(132, 19)
        Me.rbGastosOperacion.TabIndex = 62
        Me.rbGastosOperacion.TabStop = True
        Me.rbGastosOperacion.Text = "Gastos de operación"
        Me.rbGastosOperacion.UseVisualStyleBackColor = True
        '
        'rbGastosAdministracion
        '
        Me.rbGastosAdministracion.AutoSize = True
        Me.rbGastosAdministracion.Location = New System.Drawing.Point(10, 123)
        Me.rbGastosAdministracion.Name = "rbGastosAdministracion"
        Me.rbGastosAdministracion.Size = New System.Drawing.Size(158, 19)
        Me.rbGastosAdministracion.TabIndex = 61
        Me.rbGastosAdministracion.TabStop = True
        Me.rbGastosAdministracion.Text = "Gastos de administración"
        Me.rbGastosAdministracion.UseVisualStyleBackColor = True
        '
        'rbGastosVenta
        '
        Me.rbGastosVenta.AutoSize = True
        Me.rbGastosVenta.Location = New System.Drawing.Point(10, 94)
        Me.rbGastosVenta.Name = "rbGastosVenta"
        Me.rbGastosVenta.Size = New System.Drawing.Size(108, 19)
        Me.rbGastosVenta.TabIndex = 60
        Me.rbGastosVenta.TabStop = True
        Me.rbGastosVenta.Text = "Gastos de venta"
        Me.rbGastosVenta.UseVisualStyleBackColor = True
        '
        'rbAbonoCredito
        '
        Me.rbAbonoCredito.AutoSize = True
        Me.rbAbonoCredito.Location = New System.Drawing.Point(223, 154)
        Me.rbAbonoCredito.Name = "rbAbonoCredito"
        Me.rbAbonoCredito.Size = New System.Drawing.Size(115, 19)
        Me.rbAbonoCredito.TabIndex = 59
        Me.rbAbonoCredito.TabStop = True
        Me.rbAbonoCredito.Text = "Abono a créditos"
        Me.rbAbonoCredito.UseVisualStyleBackColor = True
        Me.rbAbonoCredito.Visible = False
        '
        'rbAnticipoProveedor
        '
        Me.rbAnticipoProveedor.AutoSize = True
        Me.rbAnticipoProveedor.Location = New System.Drawing.Point(10, 69)
        Me.rbAnticipoProveedor.Name = "rbAnticipoProveedor"
        Me.rbAnticipoProveedor.Size = New System.Drawing.Size(147, 19)
        Me.rbAnticipoProveedor.TabIndex = 58
        Me.rbAnticipoProveedor.TabStop = True
        Me.rbAnticipoProveedor.Text = "Anticipo a proveedores"
        Me.rbAnticipoProveedor.UseVisualStyleBackColor = True
        '
        'rbPrestamoEmpleado
        '
        Me.rbPrestamoEmpleado.AutoSize = True
        Me.rbPrestamoEmpleado.Location = New System.Drawing.Point(10, 42)
        Me.rbPrestamoEmpleado.Name = "rbPrestamoEmpleado"
        Me.rbPrestamoEmpleado.Size = New System.Drawing.Size(145, 19)
        Me.rbPrestamoEmpleado.TabIndex = 57
        Me.rbPrestamoEmpleado.TabStop = True
        Me.rbPrestamoEmpleado.Text = "Préstamo a empleados"
        Me.rbPrestamoEmpleado.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(993, 31)
        Me.Label1.TabIndex = 228
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'mchasta
        '
        Me.mchasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mchasta.Location = New System.Drawing.Point(736, 40)
        Me.mchasta.Name = "mchasta"
        Me.mchasta.TabIndex = 230
        '
        'mcdesde
        '
        Me.mcdesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcdesde.Location = New System.Drawing.Point(479, 40)
        Me.mcdesde.Name = "mcdesde"
        Me.mcdesde.TabIndex = 229
        '
        'cboDatos
        '
        Me.cboDatos.FormattingEnabled = True
        Me.cboDatos.Location = New System.Drawing.Point(10, 179)
        Me.cboDatos.Name = "cboDatos"
        Me.cboDatos.Size = New System.Drawing.Size(185, 23)
        Me.cboDatos.TabIndex = 234
        '
        'rbTodosGastos
        '
        Me.rbTodosGastos.AutoSize = True
        Me.rbTodosGastos.Location = New System.Drawing.Point(227, 69)
        Me.rbTodosGastos.Name = "rbTodosGastos"
        Me.rbTodosGastos.Size = New System.Drawing.Size(111, 19)
        Me.rbTodosGastos.TabIndex = 235
        Me.rbTodosGastos.TabStop = True
        Me.rbTodosGastos.Text = "Todos los gastos"
        Me.rbTodosGastos.UseVisualStyleBackColor = True
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        Me.grdCaptura.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCaptura.Location = New System.Drawing.Point(10, 208)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(973, 318)
        Me.grdCaptura.TabIndex = 237
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackgroundImage = CType(resources.GetObject("btnEliminar.BackgroundImage"), System.Drawing.Image)
        Me.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(412, 41)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 63)
        Me.btnEliminar.TabIndex = 241
        Me.btnEliminar.Text = "Reporte"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackgroundImage = CType(resources.GetObject("btnNuevo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Location = New System.Drawing.Point(412, 110)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(60, 63)
        Me.btnNuevo.TabIndex = 240
        Me.btnNuevo.Text = "Exportar"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'cbotres
        '
        Me.cbotres.FormattingEnabled = True
        Me.cbotres.Items.AddRange(New Object() {"Nómina", "Otros Gastos"})
        Me.cbotres.Location = New System.Drawing.Point(10, 179)
        Me.cbotres.Name = "cbotres"
        Me.cbotres.Size = New System.Drawing.Size(185, 23)
        Me.cbotres.TabIndex = 242
        '
        'optNomina
        '
        Me.optNomina.AutoSize = True
        Me.optNomina.Location = New System.Drawing.Point(227, 42)
        Me.optNomina.Name = "optNomina"
        Me.optNomina.Size = New System.Drawing.Size(68, 19)
        Me.optNomina.TabIndex = 243
        Me.optNomina.TabStop = True
        Me.optNomina.Text = "Nomina"
        Me.optNomina.UseVisualStyleBackColor = True
        '
        'frmRepSalidas
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(993, 538)
        Me.Controls.Add(Me.optNomina)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.grdCaptura)
        Me.Controls.Add(Me.cboDatos)
        Me.Controls.Add(Me.mchasta)
        Me.Controls.Add(Me.mcdesde)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rbGastosOperacion)
        Me.Controls.Add(Me.rbGastosAdministracion)
        Me.Controls.Add(Me.rbGastosVenta)
        Me.Controls.Add(Me.rbAnticipoProveedor)
        Me.Controls.Add(Me.rbPrestamoEmpleado)
        Me.Controls.Add(Me.rbAbonoCredito)
        Me.Controls.Add(Me.rbTodosGastos)
        Me.Controls.Add(Me.cbotres)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(999, 567)
        Me.Name = "frmRepSalidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de salidas"
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbGastosOperacion As System.Windows.Forms.RadioButton
    Friend WithEvents rbGastosAdministracion As System.Windows.Forms.RadioButton
    Friend WithEvents rbGastosVenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbAbonoCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbAnticipoProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrestamoEmpleado As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mchasta As System.Windows.Forms.MonthCalendar
    Friend WithEvents mcdesde As System.Windows.Forms.MonthCalendar
    Friend WithEvents cboDatos As System.Windows.Forms.ComboBox
    Friend WithEvents rbTodosGastos As System.Windows.Forms.RadioButton
    Friend WithEvents grdCaptura As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents cbotres As ComboBox
    Friend WithEvents optNomina As RadioButton
End Class
