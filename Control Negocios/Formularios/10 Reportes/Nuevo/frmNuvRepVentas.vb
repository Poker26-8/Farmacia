Public Class frmNuvRepVentas

    Dim Partes As Boolean = False
    Private Sub frmNuvRepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mcDesde.SetDate(Now)
        mcHasta.SetDate(Now)
        grdCaptura.Rows.Clear()
        rbVentasTotales.PerformClick()

        dtpinicio.Text = "00:00:00"
        dtpFin.Text = "23:59:59"

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Partes'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 1 Then
                        Partes = True
                    Else
                        Partes = False
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub rbVentasTotales_Click(sender As Object, e As EventArgs) Handles rbVentasTotales.Click

        If (rbVentasTotales.Checked) Then

            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            grdCaptura.ColumnCount = 15

            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Folio"
                    .Width = 70
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(1)
                    .HeaderText = "Cliente"
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(2)
                    .HeaderText = "Subtotal"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Iva"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(4)
                    .HeaderText = "Totales"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(5)
                    .HeaderText = "Propina"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(6)
                    .HeaderText = "Descuento"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(7)
                    .HeaderText = "Devolución"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(8)
                    .HeaderText = "A cuenta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(9)
                    .HeaderText = "Resta"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(10)
                    .HeaderText = "IEEPS"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(11)
                    .HeaderText = "Forma Pago"
                    .Width = 75
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(12)
                    .HeaderText = "Estado"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(13)
                    .HeaderText = "Fecha"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(14)
                    .HeaderText = "N° Factura"
                    .Width = 110
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With

            btnExcel.Enabled = False
        End If

    End Sub

    Private Sub rbVentasDetalle_Click(sender As Object, e As EventArgs) Handles rbVentasDetalle.Click
        If (rbVentasDetalle.Checked) Then
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0
            cboDatos.Text = ""
            cboDatos.Items.Clear()
            cboDatos.Visible = False

            txtPropina.Text = "0.00"
            txtSuma.Text = "0.00"
            txtCosto.Text = "0.00"
            txtCostoUtilidad.Text = "0.00"
            txtSubtotal.Text = "0.00"
            txtDescuento.Text = "0.00"
            txtIeps.Text = "0.00"
            txtIVA.Text = "0.00"
            txtTotal.Text = "0.00"
            txtAcuenta.Text = "0.00"
            txtResta.Text = "0.00"

            If (Partes) Then
                grdCaptura.ColumnCount = 17
                With grdCaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(1)
                        .HeaderText = "Cliente"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(2)
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "N. Parte"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Costo"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(14)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(15)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(16)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            Else
                grdCaptura.ColumnCount = 16
                With grdCaptura
                    With .Columns(0)
                        .HeaderText = "Folio"
                        .Width = 70
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(1)
                        .HeaderText = "Cliente"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(2)
                        .HeaderText = "Código"
                        .Width = 80
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(3)
                        .HeaderText = "Cod. Barras"
                        .Width = 120
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(4)
                        .HeaderText = "Descripción"
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(5)
                        .HeaderText = "Unidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(6)
                        .HeaderText = "Cantidad"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(7)
                        .HeaderText = "Costo"
                        .Width = 85
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(8)
                        .HeaderText = "Precio"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(9)
                        .HeaderText = "Subtotal"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(10)
                        .HeaderText = "IVA"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(11)
                        .HeaderText = "Total"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(12)
                        .HeaderText = "Descuento"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(13)
                        .HeaderText = "IEPS"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With

                    With .Columns(14)
                        .HeaderText = "Fecha"
                        .Width = 110
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                    With .Columns(15)
                        .HeaderText = "Ultilidad"
                        .Width = 75
                        .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Visible = True
                        .Resizable = DataGridViewTriState.False
                    End With
                End With
            End If
            btnExcel.Enabled = False
        End If

    End Sub

    Private Sub rbVentasClientes_Click(sender As Object, e As EventArgs) Handles rbVentasClientes.Click

    End Sub

    Private Sub rbVentasCliDetalle_Click(sender As Object, e As EventArgs) Handles rbVentasCliDetalle.Click

    End Sub

    Private Sub rbVentasDepa_Click(sender As Object, e As EventArgs) Handles rbVentasDepa.Click

    End Sub

    Private Sub rbVentasGrupo_Click(sender As Object, e As EventArgs) Handles rbVentasGrupo.Click

    End Sub

    Private Sub rbVentasPago_Click(sender As Object, e As EventArgs) Handles rbVentasPago.Click

    End Sub

    Private Sub rbVentasProducto_Click(sender As Object, e As EventArgs) Handles rbVentasProducto.Click

    End Sub

    Private Sub rbVentasVendedor_Click(sender As Object, e As EventArgs) Handles rbVentasVendedor.Click

    End Sub

    Private Sub rbDevoluciones_Click(sender As Object, e As EventArgs) Handles rbDevoluciones.Click

    End Sub

    Private Sub rbProductoVendido_Click(sender As Object, e As EventArgs) Handles rbProductoVendido.Click

    End Sub

    Private Sub rbVendidoProveedor_Click(sender As Object, e As EventArgs) Handles rbVendidoProveedor.Click

    End Sub

    Private Sub rbVentasFormato_Click(sender As Object, e As EventArgs) Handles rbVentasFormato.Click

    End Sub

    Private Sub rbVentasPorcentaje_Click(sender As Object, e As EventArgs) Handles rbVentasPorcentaje.Click

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

        Dim cuantos As Double = 0

        Dim T_Propina As Double = 0
        Dim T_Suma As Double = 0
        Dim T_Costo As Double = 0
        Dim T_Subtotal As Double = 0
        Dim T_Descuento As Double = 0
        Dim T_IEPS As Double = 0
        Dim T_IVA As Double = 0
        Dim T_Total As Double = 0
        Dim T_ACuenta As Double = 0
        Dim T_Resta As Double = 0

        Dim folio As String = ""
        Dim cliente As String = ""
        Dim subtotal As Double = 0
        Dim Iva As Double = 0
        Dim total As Double = 0
        Dim propina As Double = 0
        Dim descuento As Double = 0
        Dim devolucion As Double = 0
        Dim acuenta As Double = 0
        Dim resta As Double = 0
        Dim ieps As Double = 0
        Dim formapago As String = ""
        Dim status As String = ""
        Dim fecha As Date = Nothing
        Dim fechanueva As String = ""
        Dim facturado As Integer = 0

        Dim codigo As String = ""
        Dim barras As String = ""
        Dim parte As String = ""
        Dim descripcion As String = ""
        Dim uventa As String = ""
        Dim cantidad As Double = 0
        Dim costo As Double = 0
        Dim precio As Double = 0
        Dim utilidad As Double = 0

        txtPropina.Text = "0.00"
        txtSuma.Text = "0.00"
        txtCosto.Text = "0.00"
        txtCostoUtilidad.Text = "0.00"
        txtSubtotal.Text = "0.00"
        txtDescuento.Text = "0.00"
        txtIeps.Text = "0.00"
        txtIVA.Text = "0.00"
        txtTotal.Text = "0.00"
        txtAcuenta.Text = "0.00"
        txtResta.Text = "0.00"

        grdCaptura.Rows.Clear()
        btnExcel.Enabled = False

        If (rbVentasTotales.Checked) Then

            folio = ""
            cliente = ""
            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0
            devolucion = 0
            acuenta = 0
            resta = 0
            ieps = 0
            formapago = ""
            status = ""
            fecha = Nothing
            fechanueva = ""
            facturado = 0
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM Ventas WHERE Fventa BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT COUNT(Folio) FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "'"
                End If

                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "" Then
                    cmd1.CommandText = "SELECT * FROM ventas WHERE Fventa BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                Else
                    cmd1.CommandText = "SELECT * FROM ventas WHERE Fventa BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status='" & cboDatos.Text & "' ORDER BY Folio"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString
                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("totales").ToString = "", 0, rd1("totales").ToString)
                        propina = IIf(rd1("Propina").ToString = "", 0, rd1("Propina").ToString)
                        descuento = IIf(rd1("Descuento").ToString = "", 0, rd1("Descuento").ToString)
                        devolucion = IIf(rd1("Devolucion").ToString = "", 0, rd1("Devolucion").ToString)
                        acuenta = IIf(rd1("ACuenta").ToString = "", 0, rd1("ACuenta").ToString)
                        resta = IIf(rd1("Resta").ToString = "", 0, rd1("Resta").ToString)
                        status = IIf(rd1("Status").ToString = "", "", rd1("Status").ToString)
                        fecha = rd1("FVenta").ToString
                        fechanueva = Format(fecha, "yyyy-MM-dd HH:mm:ss")
                        facturado = IIf(rd1("Facturado").ToString = "", 0, rd1("Facturado").ToString)

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                        "select sum(TotalIEPS) as ipes from VentasDetalle where Folio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ieps = IIf(rd2("ipes").ToString() = "", 0, rd2("ipes").ToString())
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT FormaPago FROM abonoi WHERE NumFolio='" & folio & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                formapago = rd2(0).ToString
                            End If
                        End If
                        rd2.Close()

                        grdCaptura.Rows.Add(folio, cliente, subtotal, Iva, total, propina, descuento, devolucion, acuenta, resta, ieps, formapago, status, fechanueva, facturado)

                        T_Subtotal = T_Subtotal + subtotal
                        T_IVA = T_IVA + Iva
                        T_Total = T_Total + total
                        T_Propina = T_Propina + propina
                        T_Descuento = T_Descuento + descuento
                        T_ACuenta = T_ACuenta + acuenta
                        T_Resta = T_Resta + resta
                        T_IEPS = T_IEPS + ieps

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtPropina.Text = FormatNumber(T_Propina, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)
                txtAcuenta.Text = FormatNumber(T_ACuenta, 2)
                txtResta.Text = FormatNumber(T_Resta, 2)

                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If


        If (rbVentasDetalle.Checked) Then

            folio = ""
            cliente = ""
            codigo = ""
            barras = ""
            parte = ""
            descripcion = ""
            uventa = ""
            cantidad = 0
            costo = 0
            precio = 0
            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0
            ieps = 0
            fecha = Nothing
            fechanueva = ""
            utilidad = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = ""
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        propina = rd1("Propina").ToString
                        descuento = rd1("Descuento").ToString

                        T_Propina = T_Propina + CDbl(propina)
                    End If
                Loop
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Ventas WHERE Fventa BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        folio = rd1("Folio").ToString
                        cliente = rd1("Cliente").ToString

                        If (Partes) Then
                        Else
                            grdCaptura.Rows.Add(folio, cliente)
                        End If
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If
    End Sub
End Class