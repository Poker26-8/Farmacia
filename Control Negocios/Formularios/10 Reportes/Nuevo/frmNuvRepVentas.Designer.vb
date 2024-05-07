<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuvRepVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuvRepVentas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtAcuenta = New System.Windows.Forms.TextBox()
        Me.lblAcuenta = New System.Windows.Forms.Label()
        Me.txtCostoUtilidad = New System.Windows.Forms.TextBox()
        Me.lblUtilidad = New System.Windows.Forms.Label()
        Me.txtResta = New System.Windows.Forms.TextBox()
        Me.lblResta = New System.Windows.Forms.Label()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.txtSuma = New System.Windows.Forms.TextBox()
        Me.lblSuma = New System.Windows.Forms.Label()
        Me.txtPropina = New System.Windows.Forms.TextBox()
        Me.lblPropina = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.txtIeps = New System.Windows.Forms.TextBox()
        Me.lblIeps = New System.Windows.Forms.Label()
        Me.txtIVA = New System.Windows.Forms.TextBox()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAntibiotico = New System.Windows.Forms.Button()
        Me.btnControlado = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cboDatos = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dtpinicio = New System.Windows.Forms.DateTimePicker()
        Me.mcDesde = New System.Windows.Forms.MonthCalendar()
        Me.mcHasta = New System.Windows.Forms.MonthCalendar()
        Me.dtpFin = New System.Windows.Forms.DateTimePicker()
        Me.rbVentasPorcentaje = New System.Windows.Forms.RadioButton()
        Me.rbVentasFormato = New System.Windows.Forms.RadioButton()
        Me.rbVendidoProveedor = New System.Windows.Forms.RadioButton()
        Me.rbProductoVendido = New System.Windows.Forms.RadioButton()
        Me.rbDevoluciones = New System.Windows.Forms.RadioButton()
        Me.rbVentasVendedor = New System.Windows.Forms.RadioButton()
        Me.rbVentasProducto = New System.Windows.Forms.RadioButton()
        Me.rbVentasPago = New System.Windows.Forms.RadioButton()
        Me.rbVentasGrupo = New System.Windows.Forms.RadioButton()
        Me.rbVentasDepa = New System.Windows.Forms.RadioButton()
        Me.rbVentasCliDetalle = New System.Windows.Forms.RadioButton()
        Me.rbVentasClientes = New System.Windows.Forms.RadioButton()
        Me.rbVentasDetalle = New System.Windows.Forms.RadioButton()
        Me.rbVentasTotales = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.barcarga = New System.Windows.Forms.ProgressBar()
        Me.grdCaptura = New System.Windows.Forms.DataGridView()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 35)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 591)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1068, 166)
        Me.Panel2.TabIndex = 1
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtAcuenta)
        Me.Panel7.Controls.Add(Me.lblAcuenta)
        Me.Panel7.Controls.Add(Me.txtCostoUtilidad)
        Me.Panel7.Controls.Add(Me.lblUtilidad)
        Me.Panel7.Controls.Add(Me.txtResta)
        Me.Panel7.Controls.Add(Me.lblResta)
        Me.Panel7.Controls.Add(Me.txtCosto)
        Me.Panel7.Controls.Add(Me.lblCosto)
        Me.Panel7.Controls.Add(Me.txtSuma)
        Me.Panel7.Controls.Add(Me.lblSuma)
        Me.Panel7.Controls.Add(Me.txtPropina)
        Me.Panel7.Controls.Add(Me.lblPropina)
        Me.Panel7.Controls.Add(Me.txtSubtotal)
        Me.Panel7.Controls.Add(Me.lblSubtotal)
        Me.Panel7.Controls.Add(Me.txtDescuento)
        Me.Panel7.Controls.Add(Me.lblDescuento)
        Me.Panel7.Controls.Add(Me.txtIeps)
        Me.Panel7.Controls.Add(Me.lblIeps)
        Me.Panel7.Controls.Add(Me.txtIVA)
        Me.Panel7.Controls.Add(Me.lblIva)
        Me.Panel7.Controls.Add(Me.txtTotal)
        Me.Panel7.Controls.Add(Me.lblTotal)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(319, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(749, 166)
        Me.Panel7.TabIndex = 17
        '
        'txtAcuenta
        '
        Me.txtAcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcuenta.Location = New System.Drawing.Point(537, 135)
        Me.txtAcuenta.Name = "txtAcuenta"
        Me.txtAcuenta.Size = New System.Drawing.Size(100, 24)
        Me.txtAcuenta.TabIndex = 37
        Me.txtAcuenta.Text = "0.00"
        Me.txtAcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAcuenta
        '
        Me.lblAcuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcuenta.Location = New System.Drawing.Point(537, 112)
        Me.lblAcuenta.Name = "lblAcuenta"
        Me.lblAcuenta.Size = New System.Drawing.Size(100, 24)
        Me.lblAcuenta.TabIndex = 36
        Me.lblAcuenta.Text = "A Cuenta:"
        Me.lblAcuenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostoUtilidad
        '
        Me.txtCostoUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoUtilidad.Location = New System.Drawing.Point(643, 26)
        Me.txtCostoUtilidad.Name = "txtCostoUtilidad"
        Me.txtCostoUtilidad.Size = New System.Drawing.Size(100, 24)
        Me.txtCostoUtilidad.TabIndex = 35
        Me.txtCostoUtilidad.Text = "0.00"
        Me.txtCostoUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUtilidad
        '
        Me.lblUtilidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilidad.Location = New System.Drawing.Point(410, 27)
        Me.lblUtilidad.Name = "lblUtilidad"
        Me.lblUtilidad.Size = New System.Drawing.Size(227, 20)
        Me.lblUtilidad.TabIndex = 34
        Me.lblUtilidad.Text = "Utilidad en ralación al método de costeo establecido:"
        Me.lblUtilidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResta
        '
        Me.txtResta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtResta.Location = New System.Drawing.Point(643, 135)
        Me.txtResta.Name = "txtResta"
        Me.txtResta.Size = New System.Drawing.Size(100, 24)
        Me.txtResta.TabIndex = 33
        Me.txtResta.Text = "0.00"
        Me.txtResta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblResta
        '
        Me.lblResta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResta.Location = New System.Drawing.Point(643, 112)
        Me.lblResta.Name = "lblResta"
        Me.lblResta.Size = New System.Drawing.Size(100, 24)
        Me.lblResta.TabIndex = 32
        Me.lblResta.Text = "Resta:"
        Me.lblResta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCosto
        '
        Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.Location = New System.Drawing.Point(304, 26)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(100, 24)
        Me.txtCosto.TabIndex = 31
        Me.txtCosto.Text = "0.00"
        Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCosto
        '
        Me.lblCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCosto.Location = New System.Drawing.Point(304, 3)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(100, 24)
        Me.lblCosto.TabIndex = 30
        Me.lblCosto.Text = "Costo:"
        Me.lblCosto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSuma
        '
        Me.txtSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuma.Location = New System.Drawing.Point(198, 26)
        Me.txtSuma.Name = "txtSuma"
        Me.txtSuma.Size = New System.Drawing.Size(100, 24)
        Me.txtSuma.TabIndex = 29
        Me.txtSuma.Text = "0.00"
        Me.txtSuma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSuma
        '
        Me.lblSuma.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuma.Location = New System.Drawing.Point(198, 3)
        Me.lblSuma.Name = "lblSuma"
        Me.lblSuma.Size = New System.Drawing.Size(100, 24)
        Me.lblSuma.TabIndex = 28
        Me.lblSuma.Text = "Suma:"
        Me.lblSuma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPropina
        '
        Me.txtPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPropina.Location = New System.Drawing.Point(92, 26)
        Me.txtPropina.Name = "txtPropina"
        Me.txtPropina.Size = New System.Drawing.Size(100, 24)
        Me.txtPropina.TabIndex = 27
        Me.txtPropina.Text = "0.00"
        Me.txtPropina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPropina
        '
        Me.lblPropina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropina.Location = New System.Drawing.Point(92, 3)
        Me.lblPropina.Name = "lblPropina"
        Me.lblPropina.Size = New System.Drawing.Size(100, 24)
        Me.lblPropina.TabIndex = 26
        Me.lblPropina.Text = "Propina:"
        Me.lblPropina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(219, 82)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(100, 24)
        Me.txtSubtotal.TabIndex = 25
        Me.txtSubtotal.Text = "0.00"
        Me.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubtotal
        '
        Me.lblSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotal.Location = New System.Drawing.Point(219, 59)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(100, 24)
        Me.lblSubtotal.TabIndex = 24
        Me.lblSubtotal.Text = "Subtotal:"
        Me.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescuento
        '
        Me.txtDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.Location = New System.Drawing.Point(325, 82)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(100, 24)
        Me.txtDescuento.TabIndex = 23
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDescuento
        '
        Me.lblDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.Location = New System.Drawing.Point(325, 55)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(91, 24)
        Me.lblDescuento.TabIndex = 22
        Me.lblDescuento.Text = "Descuento:"
        Me.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIeps
        '
        Me.txtIeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIeps.Location = New System.Drawing.Point(431, 82)
        Me.txtIeps.Name = "txtIeps"
        Me.txtIeps.Size = New System.Drawing.Size(100, 24)
        Me.txtIeps.TabIndex = 21
        Me.txtIeps.Text = "0.00"
        Me.txtIeps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIeps
        '
        Me.lblIeps.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIeps.Location = New System.Drawing.Point(431, 56)
        Me.lblIeps.Name = "lblIeps"
        Me.lblIeps.Size = New System.Drawing.Size(63, 24)
        Me.lblIeps.TabIndex = 20
        Me.lblIeps.Text = "IEPS:"
        Me.lblIeps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIVA
        '
        Me.txtIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIVA.Location = New System.Drawing.Point(537, 82)
        Me.txtIVA.Name = "txtIVA"
        Me.txtIVA.Size = New System.Drawing.Size(100, 24)
        Me.txtIVA.TabIndex = 19
        Me.txtIVA.Text = "0.00"
        Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblIva
        '
        Me.lblIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIva.Location = New System.Drawing.Point(537, 56)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(55, 24)
        Me.lblIva.TabIndex = 18
        Me.lblIva.Text = "IVA:"
        Me.lblIva.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(643, 82)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(100, 24)
        Me.txtTotal.TabIndex = 17
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(643, 56)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(74, 24)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnReporte)
        Me.Panel6.Controls.Add(Me.btnImprimir)
        Me.Panel6.Controls.Add(Me.btnExcel)
        Me.Panel6.Controls.Add(Me.btnNuevo)
        Me.Panel6.Controls.Add(Me.btnAntibiotico)
        Me.Panel6.Controls.Add(Me.btnControlado)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1068, 166)
        Me.Panel6.TabIndex = 16
        '
        'btnReporte
        '
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnReporte.Location = New System.Drawing.Point(3, 6)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(90, 74)
        Me.btnReporte.TabIndex = 0
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnImprimir.Location = New System.Drawing.Point(99, 6)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(90, 74)
        Me.btnImprimir.TabIndex = 1
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(3, 86)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(90, 74)
        Me.btnExcel.TabIndex = 2
        Me.btnExcel.Text = "Exportar"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNuevo.Location = New System.Drawing.Point(99, 86)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(90, 74)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAntibiotico
        '
        Me.btnAntibiotico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAntibiotico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAntibiotico.Image = CType(resources.GetObject("btnAntibiotico.Image"), System.Drawing.Image)
        Me.btnAntibiotico.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAntibiotico.Location = New System.Drawing.Point(195, 6)
        Me.btnAntibiotico.Name = "btnAntibiotico"
        Me.btnAntibiotico.Size = New System.Drawing.Size(102, 74)
        Me.btnAntibiotico.TabIndex = 4
        Me.btnAntibiotico.Text = "Antibióticos"
        Me.btnAntibiotico.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAntibiotico.UseVisualStyleBackColor = True
        '
        'btnControlado
        '
        Me.btnControlado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnControlado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnControlado.Image = CType(resources.GetObject("btnControlado.Image"), System.Drawing.Image)
        Me.btnControlado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnControlado.Location = New System.Drawing.Point(195, 86)
        Me.btnControlado.Name = "btnControlado"
        Me.btnControlado.Size = New System.Drawing.Size(102, 74)
        Me.btnControlado.TabIndex = 5
        Me.btnControlado.Text = "Controlados"
        Me.btnControlado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnControlado.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cboDatos)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.rbVentasPorcentaje)
        Me.Panel3.Controls.Add(Me.rbVentasFormato)
        Me.Panel3.Controls.Add(Me.rbVendidoProveedor)
        Me.Panel3.Controls.Add(Me.rbProductoVendido)
        Me.Panel3.Controls.Add(Me.rbDevoluciones)
        Me.Panel3.Controls.Add(Me.rbVentasVendedor)
        Me.Panel3.Controls.Add(Me.rbVentasProducto)
        Me.Panel3.Controls.Add(Me.rbVentasPago)
        Me.Panel3.Controls.Add(Me.rbVentasGrupo)
        Me.Panel3.Controls.Add(Me.rbVentasDepa)
        Me.Panel3.Controls.Add(Me.rbVentasCliDetalle)
        Me.Panel3.Controls.Add(Me.rbVentasClientes)
        Me.Panel3.Controls.Add(Me.rbVentasDetalle)
        Me.Panel3.Controls.Add(Me.rbVentasTotales)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1068, 228)
        Me.Panel3.TabIndex = 2
        '
        'cboDatos
        '
        Me.cboDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDatos.FormattingEnabled = True
        Me.cboDatos.Location = New System.Drawing.Point(3, 194)
        Me.cboDatos.Name = "cboDatos"
        Me.cboDatos.Size = New System.Drawing.Size(252, 24)
        Me.cboDatos.TabIndex = 218
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dtpinicio)
        Me.Panel5.Controls.Add(Me.mcDesde)
        Me.Panel5.Controls.Add(Me.mcHasta)
        Me.Panel5.Controls.Add(Me.dtpFin)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(550, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(518, 228)
        Me.Panel5.TabIndex = 217
        '
        'dtpinicio
        '
        Me.dtpinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpinicio.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpinicio.Location = New System.Drawing.Point(9, 174)
        Me.dtpinicio.Name = "dtpinicio"
        Me.dtpinicio.ShowUpDown = True
        Me.dtpinicio.Size = New System.Drawing.Size(101, 26)
        Me.dtpinicio.TabIndex = 208
        '
        'mcDesde
        '
        Me.mcDesde.Location = New System.Drawing.Point(9, 6)
        Me.mcDesde.Name = "mcDesde"
        Me.mcDesde.TabIndex = 8
        '
        'mcHasta
        '
        Me.mcHasta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mcHasta.Location = New System.Drawing.Point(264, 6)
        Me.mcHasta.Name = "mcHasta"
        Me.mcHasta.TabIndex = 7
        '
        'dtpFin
        '
        Me.dtpFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpFin.Location = New System.Drawing.Point(412, 174)
        Me.dtpFin.Name = "dtpFin"
        Me.dtpFin.ShowUpDown = True
        Me.dtpFin.Size = New System.Drawing.Size(100, 26)
        Me.dtpFin.TabIndex = 209
        '
        'rbVentasPorcentaje
        '
        Me.rbVentasPorcentaje.AutoSize = True
        Me.rbVentasPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasPorcentaje.Location = New System.Drawing.Point(229, 166)
        Me.rbVentasPorcentaje.Name = "rbVentasPorcentaje"
        Me.rbVentasPorcentaje.Size = New System.Drawing.Size(258, 22)
        Me.rbVentasPorcentaje.TabIndex = 216
        Me.rbVentasPorcentaje.TabStop = True
        Me.rbVentasPorcentaje.Text = "Ventas de derivados por porcentaje"
        Me.rbVentasPorcentaje.UseVisualStyleBackColor = True
        '
        'rbVentasFormato
        '
        Me.rbVentasFormato.AutoSize = True
        Me.rbVentasFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasFormato.Location = New System.Drawing.Point(229, 138)
        Me.rbVentasFormato.Name = "rbVentasFormato"
        Me.rbVentasFormato.Size = New System.Drawing.Size(153, 22)
        Me.rbVentasFormato.TabIndex = 215
        Me.rbVentasFormato.TabStop = True
        Me.rbVentasFormato.Text = "Ventas por formato"
        Me.rbVentasFormato.UseVisualStyleBackColor = True
        '
        'rbVendidoProveedor
        '
        Me.rbVendidoProveedor.AutoSize = True
        Me.rbVendidoProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVendidoProveedor.Location = New System.Drawing.Point(229, 110)
        Me.rbVendidoProveedor.Name = "rbVendidoProveedor"
        Me.rbVendidoProveedor.Size = New System.Drawing.Size(257, 22)
        Me.rbVendidoProveedor.TabIndex = 214
        Me.rbVendidoProveedor.TabStop = True
        Me.rbVendidoProveedor.Text = "Producto más vendido x proveedor"
        Me.rbVendidoProveedor.UseVisualStyleBackColor = True
        '
        'rbProductoVendido
        '
        Me.rbProductoVendido.AutoSize = True
        Me.rbProductoVendido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbProductoVendido.Location = New System.Drawing.Point(229, 83)
        Me.rbProductoVendido.Name = "rbProductoVendido"
        Me.rbProductoVendido.Size = New System.Drawing.Size(175, 22)
        Me.rbProductoVendido.TabIndex = 213
        Me.rbProductoVendido.TabStop = True
        Me.rbProductoVendido.Text = "Producto más vendido"
        Me.rbProductoVendido.UseVisualStyleBackColor = True
        '
        'rbDevoluciones
        '
        Me.rbDevoluciones.AutoSize = True
        Me.rbDevoluciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDevoluciones.Location = New System.Drawing.Point(229, 55)
        Me.rbDevoluciones.Name = "rbDevoluciones"
        Me.rbDevoluciones.Size = New System.Drawing.Size(116, 22)
        Me.rbDevoluciones.TabIndex = 212
        Me.rbDevoluciones.TabStop = True
        Me.rbDevoluciones.Text = "Devoluciones"
        Me.rbDevoluciones.UseVisualStyleBackColor = True
        '
        'rbVentasVendedor
        '
        Me.rbVentasVendedor.AutoSize = True
        Me.rbVentasVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasVendedor.Location = New System.Drawing.Point(229, 30)
        Me.rbVentasVendedor.Name = "rbVentasVendedor"
        Me.rbVentasVendedor.Size = New System.Drawing.Size(162, 22)
        Me.rbVentasVendedor.TabIndex = 211
        Me.rbVentasVendedor.TabStop = True
        Me.rbVentasVendedor.Text = "Ventas por vendedor"
        Me.rbVentasVendedor.UseVisualStyleBackColor = True
        '
        'rbVentasProducto
        '
        Me.rbVentasProducto.AutoSize = True
        Me.rbVentasProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasProducto.Location = New System.Drawing.Point(229, 6)
        Me.rbVentasProducto.Name = "rbVentasProducto"
        Me.rbVentasProducto.Size = New System.Drawing.Size(160, 22)
        Me.rbVentasProducto.TabIndex = 210
        Me.rbVentasProducto.TabStop = True
        Me.rbVentasProducto.Text = "Ventas por producto"
        Me.rbVentasProducto.UseVisualStyleBackColor = True
        '
        'rbVentasPago
        '
        Me.rbVentasPago.AutoSize = True
        Me.rbVentasPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasPago.Location = New System.Drawing.Point(3, 166)
        Me.rbVentasPago.Name = "rbVentasPago"
        Me.rbVentasPago.Size = New System.Drawing.Size(215, 22)
        Me.rbVentasPago.TabIndex = 6
        Me.rbVentasPago.TabStop = True
        Me.rbVentasPago.Text = "Ventas totales (Detalle pago)"
        Me.rbVentasPago.UseVisualStyleBackColor = True
        '
        'rbVentasGrupo
        '
        Me.rbVentasGrupo.AutoSize = True
        Me.rbVentasGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasGrupo.Location = New System.Drawing.Point(3, 138)
        Me.rbVentasGrupo.Name = "rbVentasGrupo"
        Me.rbVentasGrupo.Size = New System.Drawing.Size(139, 22)
        Me.rbVentasGrupo.TabIndex = 5
        Me.rbVentasGrupo.TabStop = True
        Me.rbVentasGrupo.Text = "Ventas por grupo"
        Me.rbVentasGrupo.UseVisualStyleBackColor = True
        '
        'rbVentasDepa
        '
        Me.rbVentasDepa.AutoSize = True
        Me.rbVentasDepa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasDepa.Location = New System.Drawing.Point(3, 110)
        Me.rbVentasDepa.Name = "rbVentasDepa"
        Me.rbVentasDepa.Size = New System.Drawing.Size(192, 22)
        Me.rbVentasDepa.TabIndex = 4
        Me.rbVentasDepa.TabStop = True
        Me.rbVentasDepa.Text = "Ventas por departamento"
        Me.rbVentasDepa.UseVisualStyleBackColor = True
        '
        'rbVentasCliDetalle
        '
        Me.rbVentasCliDetalle.AutoSize = True
        Me.rbVentasCliDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasCliDetalle.Location = New System.Drawing.Point(3, 83)
        Me.rbVentasCliDetalle.Name = "rbVentasCliDetalle"
        Me.rbVentasCliDetalle.Size = New System.Drawing.Size(202, 22)
        Me.rbVentasCliDetalle.TabIndex = 3
        Me.rbVentasCliDetalle.TabStop = True
        Me.rbVentasCliDetalle.Text = "Ventas por cliente (Detalle)"
        Me.rbVentasCliDetalle.UseVisualStyleBackColor = True
        '
        'rbVentasClientes
        '
        Me.rbVentasClientes.AutoSize = True
        Me.rbVentasClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasClientes.Location = New System.Drawing.Point(3, 55)
        Me.rbVentasClientes.Name = "rbVentasClientes"
        Me.rbVentasClientes.Size = New System.Drawing.Size(143, 22)
        Me.rbVentasClientes.TabIndex = 2
        Me.rbVentasClientes.TabStop = True
        Me.rbVentasClientes.Text = "Ventas por cliente"
        Me.rbVentasClientes.UseVisualStyleBackColor = True
        '
        'rbVentasDetalle
        '
        Me.rbVentasDetalle.AutoSize = True
        Me.rbVentasDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasDetalle.Location = New System.Drawing.Point(3, 30)
        Me.rbVentasDetalle.Name = "rbVentasDetalle"
        Me.rbVentasDetalle.Size = New System.Drawing.Size(178, 22)
        Me.rbVentasDetalle.TabIndex = 1
        Me.rbVentasDetalle.TabStop = True
        Me.rbVentasDetalle.Text = "Ventas totales (Detalle)"
        Me.rbVentasDetalle.UseVisualStyleBackColor = True
        '
        'rbVentasTotales
        '
        Me.rbVentasTotales.AutoSize = True
        Me.rbVentasTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVentasTotales.Location = New System.Drawing.Point(3, 6)
        Me.rbVentasTotales.Name = "rbVentasTotales"
        Me.rbVentasTotales.Size = New System.Drawing.Size(119, 22)
        Me.rbVentasTotales.TabIndex = 0
        Me.rbVentasTotales.TabStop = True
        Me.rbVentasTotales.Text = "Ventas totales"
        Me.rbVentasTotales.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.barcarga)
        Me.Panel4.Controls.Add(Me.grdCaptura)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 263)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1068, 328)
        Me.Panel4.TabIndex = 3
        '
        'barcarga
        '
        Me.barcarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.barcarga.Location = New System.Drawing.Point(0, 305)
        Me.barcarga.Name = "barcarga"
        Me.barcarga.Size = New System.Drawing.Size(1065, 20)
        Me.barcarga.TabIndex = 206
        Me.barcarga.Visible = False
        '
        'grdCaptura
        '
        Me.grdCaptura.AllowUserToAddRows = False
        Me.grdCaptura.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(220, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdCaptura.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCaptura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCaptura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdCaptura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCaptura.DefaultCellStyle = DataGridViewCellStyle3
        Me.grdCaptura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaptura.Location = New System.Drawing.Point(0, 0)
        Me.grdCaptura.Name = "grdCaptura"
        Me.grdCaptura.ReadOnly = True
        Me.grdCaptura.RowHeadersVisible = False
        Me.grdCaptura.Size = New System.Drawing.Size(1068, 328)
        Me.grdCaptura.TabIndex = 0
        '
        'frmNuvRepVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1068, 757)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNuvRepVentas"
        Me.Text = "Reporte de Ventas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdCaptura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbVentasPago As RadioButton
    Friend WithEvents rbVentasGrupo As RadioButton
    Friend WithEvents rbVentasDepa As RadioButton
    Friend WithEvents rbVentasCliDetalle As RadioButton
    Friend WithEvents rbVentasClientes As RadioButton
    Friend WithEvents rbVentasDetalle As RadioButton
    Friend WithEvents rbVentasTotales As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents mcDesde As MonthCalendar
    Friend WithEvents mcHasta As MonthCalendar
    Friend WithEvents rbVentasPorcentaje As RadioButton
    Friend WithEvents rbVentasFormato As RadioButton
    Friend WithEvents rbVendidoProveedor As RadioButton
    Friend WithEvents rbProductoVendido As RadioButton
    Friend WithEvents rbDevoluciones As RadioButton
    Friend WithEvents rbVentasVendedor As RadioButton
    Friend WithEvents rbVentasProducto As RadioButton
    Friend WithEvents dtpFin As DateTimePicker
    Friend WithEvents dtpinicio As DateTimePicker
    Friend WithEvents cboDatos As ComboBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grdCaptura As DataGridView
    Friend WithEvents btnControlado As Button
    Friend WithEvents btnAntibiotico As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents btnReporte As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents txtDescuento As TextBox
    Friend WithEvents lblDescuento As Label
    Friend WithEvents txtIeps As TextBox
    Friend WithEvents lblIeps As Label
    Friend WithEvents txtIVA As TextBox
    Friend WithEvents lblIva As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtResta As TextBox
    Friend WithEvents lblResta As Label
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents lblCosto As Label
    Friend WithEvents txtSuma As TextBox
    Friend WithEvents lblSuma As Label
    Friend WithEvents txtPropina As TextBox
    Friend WithEvents lblPropina As Label
    Friend WithEvents txtCostoUtilidad As TextBox
    Friend WithEvents lblUtilidad As Label
    Friend WithEvents txtAcuenta As TextBox
    Friend WithEvents lblAcuenta As Label
    Friend WithEvents barcarga As ProgressBar
End Class
