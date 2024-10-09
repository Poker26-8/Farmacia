Public Class frmCorte4

    Dim Calculo As Boolean = False
    Private Sub frmCorte4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpInicial.Value = Date.Now
        dtpHInicial.Text = "00:00:00"
        dtpFin.Value = Date.Now
        dtpHFinal.Text = "23:59:59"
    End Sub

    Private Sub cboCajero_DropDown(sender As Object, e As EventArgs) Handles cboCajero.DropDown
        cboCajero.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Usuario FROM abonoi WHERE Usuario<>'' AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' ORDER BY Usuario"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCajero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub

    Private Sub btnCalculadora_Click(sender As Object, e As EventArgs) Handles btnCalculadora.Click
        Try

            Dim corteciego As Integer = DatosRecarga("CorteCiego")

            If corteciego = 1 Then
                If Calculo = False Then
                    MsgBox("Para continuar realice el cálculo de su efectivo en caja.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                    gbxCalculo.Visible = True
                    txtCant500.Focus()
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
            End If
                Dim foliov As String = ""
            Dim status As String = ""

            Dim ventascontado As Double = 0
            Dim devolucionescontado As Double = 0

            Dim ventascredito As Double = 0
            Dim devolucionescredito As Double = 0
            Dim abonoscreditos As Double = 0

            Dim INGRESOSEFECTIVO As Double = 0
            Dim DEVOLUCIONESEFECTIVO As Double = 0

            Dim retiros As Double = 0

            Dim INGRESOSFORMAS As Double = 0
            'sacar las ventas que estan pagadas y no pagadas
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Folio,Status FROM ventas WHERE Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Usuario='" & cboCajero.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    foliov = rd1(0).ToString
                    status = rd1(1).ToString


                    If status = "PAGADO" Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ventascontado = ventascontado + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Cargo FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='DEVOLUCION'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                devolucionescontado = devolucionescontado + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago='EFECTIVO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                INGRESOSEFECTIVO = INGRESOSEFECTIVO + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        'Formas de pago
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago<>'EFECTIVO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                INGRESOSFORMAS = INGRESOSFORMAS + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                    Else
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Saldo FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Concepto='NOTA VENTA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                ventascredito = ventascredito + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='DEVOLUCION'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                devolucionescredito = devolucionescredito + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago='EFECTIVO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                INGRESOSEFECTIVO = INGRESOSEFECTIVO + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                abonoscreditos = abonoscreditos + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()

                        'Formas de pago
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Abono FROM abonoi WHERE NumFolio=" & foliov & " AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Concepto='ABONO' AND FormaPago<>'EFECTIVO'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                INGRESOSFORMAS = INGRESOSFORMAS + CDec(rd2(0).ToString)
                            End If
                        End If
                        rd2.Close()


                    End If

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT SUM(Monto) FROM otrosgastos WHERE Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    retiros = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                End If
            End If
            rd1.Close()


            cnn1.Close()

            txtVentas.Text = FormatNumber(ventascontado, 2)
            txtDevolucionesV.Text = FormatNumber(devolucionescontado, 2)
            txtTotalContado.Text = CDec(txtVentas.Text) - CDec(txtDevolucionesV.Text)

            txtVentasC.Text = FormatNumber(ventascredito, 2)
            txtAbonosCreditos.Text = FormatNumber(abonoscreditos, 2)
            txtDevolucionesC.Text = FormatNumber(devolucionescredito, 2)
            txtCredito.Text = FormatNumber(CDec(txtVentasC.Text) - CDec(txtDevolucionesC.Text), 2)

            txtTotal.Text = FormatNumber(CDec(txtTotalContado.Text) + CDec(txtCredito.Text), 2)

            txtIngresosTar.Text = FormatNumber(INGRESOSFORMAS, 2)

            txtDevoluciones.Text = FormatNumber(CDec(txtDevolucionesC.Text) + CDec(txtDevolucionesV.Text), 2)
            txtRetiros.Text = FormatNumber(retiros, 2)
            txtIngresos.Text = FormatNumber(INGRESOSEFECTIVO, 2)


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtIngresos_TextChanged(sender As Object, e As EventArgs) Handles txtIngresos.TextChanged
        Dim total As Double = CDbl(IIf(txtIngresos.Text = "", "0", txtIngresos.Text)) + CDbl(IIf(txtSaldoInicial.Text = "", "0", txtSaldoInicial.Text)) - CDbl(IIf(txtRetiros.Text = "", "0", txtRetiros.Text)) - CDbl(IIf(txtDevoluciones.Text = "", "0", txtDevoluciones.Text))
        txtSumSistema.Text = FormatNumber(total, 2)
        txtTotalSistema.Text = FormatNumber(total, 2)
    End Sub

    Private Sub txtSaldoInicial_TextChanged(sender As Object, e As EventArgs) Handles txtSaldoInicial.TextChanged

        If txtSaldoInicial.Text = "" Then
            txtSaldoInicial.Text = "0.00"
            txtSaldoInicial.SelectAll()
            Exit Sub
        End If


        Dim total As Double = CDbl(IIf(txtIngresos.Text = "", "0", txtIngresos.Text)) + CDbl(IIf(txtSaldoInicial.Text = "", "0", txtSaldoInicial.Text)) - CDbl(IIf(txtRetiros.Text = "", "0", txtRetiros.Text)) - CDbl(IIf(txtDevoluciones.Text = "", "0", txtDevoluciones.Text))
        txtSumSistema.Text = FormatNumber(total, 2)
        txtTotalSistema.Text = FormatNumber(total, 2)
    End Sub

    Private Function TipoCorte() As Integer
        Dim tipo As Integer = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='CorteCiego'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    If rd3(0).ToString = "0" Then
                        tipo = 0
                    Else
                        tipo = 1
                    End If
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return tipo
    End Function

    Private Sub txtCant500_TextChanged(sender As Object, e As EventArgs) Handles txtCant500.TextChanged
        If txtCant500.Text = "" Then
            txtCant500.Text = "0"
        End If
        txtTotal500.Text = CDec(txtCant500.Text) * 500
        txtTotal500.Text = FormatNumber(txtTotal500.Text, 2)
    End Sub

    Private Sub txtCant500_GotFocus(sender As Object, e As EventArgs) Handles txtCant500.GotFocus
        txtCant500.SelectAll()
    End Sub

    Private Sub txtCant500_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant500.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant500.Text = "" Then txtCant500.Text = "0"
            txtCant200.Focus()
        End If
    End Sub

    Private Sub txtTotal500_TextChanged(sender As Object, e As EventArgs) Handles txtTotal500.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub btnNOCalculo_Click(sender As Object, e As EventArgs) Handles btnNOCalculo.Click
        Calculo = False
        gbxCalculo.Visible = False
    End Sub

    Private Sub txtCant200_TextChanged(sender As Object, e As EventArgs) Handles txtCant200.TextChanged
        If txtCant200.Text = "" Then
            txtCant200.Text = "0"
        End If
        txtTotal200.Text = CDec(txtCant200.Text) * 200
        txtTotal200.Text = FormatNumber(txtTotal200.Text, 2)
    End Sub

    Private Sub txtCant200_GotFocus(sender As Object, e As EventArgs) Handles txtCant200.GotFocus
        txtCant200.SelectAll()
    End Sub

    Private Sub txtCant200_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant200.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant200.Text = "" Then txtCant200.Text = "0"
            txtCant100.Focus()
        End If
    End Sub

    Private Sub txtTotal200_TextChanged(sender As Object, e As EventArgs) Handles txtTotal200.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant100_TextChanged(sender As Object, e As EventArgs) Handles txtCant100.TextChanged
        If txtCant100.Text = "" Then
            txtCant100.Text = "0"
        End If
        txtTotal100.Text = CDec(txtCant100.Text) * 100
        txtTotal100.Text = FormatNumber(txtTotal100.Text, 2)
    End Sub

    Private Sub txtCant100_GotFocus(sender As Object, e As EventArgs) Handles txtCant100.GotFocus
        txtCant100.SelectAll()
    End Sub

    Private Sub txtCant100_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant100.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtCant100.Text = "" Then txtCant100.Text = "0"
            txtCant50.Focus()
        End If
    End Sub

    Private Sub txtTotal100_TextChanged(sender As Object, e As EventArgs) Handles txtTotal100.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant50_TextChanged(sender As Object, e As EventArgs) Handles txtCant50.TextChanged
        If txtCant50.Text = "" Then
            txtCant50.Text = "0"
        End If
        txtTotal50.Text = CDec(txtCant50.Text) * 50
        txtTotal50.Text = FormatNumber(txtTotal50.Text, 2)
    End Sub

    Private Sub txtCant50_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant50.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant50.Text = "" Then txtCant50.Text = "0"
            txtCant20.Focus()
        End If
    End Sub

    Private Sub txtCant50_GotFocus(sender As Object, e As EventArgs) Handles txtCant50.GotFocus
        txtCant50.SelectAll()
    End Sub

    Private Sub txtTotal50_TextChanged(sender As Object, e As EventArgs) Handles txtTotal50.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant20_TextChanged(sender As Object, e As EventArgs) Handles txtCant20.TextChanged
        txtCant20.SelectAll()
    End Sub

    Private Sub txtCant20_GotFocus(sender As Object, e As EventArgs) Handles txtCant20.GotFocus
        If txtCant20.Text = "" Then
            txtCant20.Text = "0"
        End If
        txtTotal20.Text = CDec(txtCant20.Text) * 20
        txtTotal20.Text = FormatNumber(txtTotal20.Text, 2)
    End Sub

    Private Sub txtCant20_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant20.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant20.Text = "" Then txtCant20.Text = "0"
            txtCant10.Focus()
        End If
    End Sub

    Private Sub txtTotal20_TextChanged(sender As Object, e As EventArgs) Handles txtTotal20.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub
    Private Sub txtCant10_GotFocus(sender As Object, e As EventArgs) Handles txtCant10.GotFocus
        txtCant10.SelectAll()
    End Sub

    Private Sub txtCant10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant10.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant10.Text = "" Then txtCant10.Text = "0"
            txtCant5.Focus()
        End If
    End Sub

    Private Sub txtCant10_TextChanged(sender As Object, e As EventArgs) Handles txtCant10.TextChanged
        If txtCant10.Text = "" Then
            txtCant10.Text = "0"
        End If
        txtTotal10.Text = CDec(txtCant10.Text) * 10
        txtTotal10.Text = FormatNumber(txtTotal10.Text, 2)
    End Sub

    Private Sub txtTotal10_TextChanged(sender As Object, e As EventArgs) Handles txtTotal10.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant5_TextChanged(sender As Object, e As EventArgs) Handles txtCant5.TextChanged
        If txtCant5.Text = "" Then
            txtCant5.Text = "0"
        End If
        txtTotal5.Text = CDec(txtCant5.Text) * 5
        txtTotal5.Text = FormatNumber(txtTotal5.Text, 2)
    End Sub

    Private Sub txtCant5_GotFocus(sender As Object, e As EventArgs) Handles txtCant5.GotFocus
        txtCant5.SelectAll()
    End Sub

    Private Sub txtCant5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant5.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant5.Text = "" Then txtCant5.Text = "0"
            txtCant2.Focus()
        End If
    End Sub

    Private Sub txtTotal5_TextChanged(sender As Object, e As EventArgs) Handles txtTotal5.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant2_TextChanged(sender As Object, e As EventArgs) Handles txtCant2.TextChanged
        If txtCant2.Text = "" Then
            txtCant2.Text = "0"
        End If
        txtTotal2.Text = CDec(txtCant2.Text) * 2
        txtTotal2.Text = FormatNumber(txtTotal2.Text, 2)
    End Sub

    Private Sub txtCant2_GotFocus(sender As Object, e As EventArgs) Handles txtCant2.GotFocus
        txtCant2.SelectAll()
    End Sub

    Private Sub txtCant2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant2.Text = "" Then txtCant2.Text = "0"
            txtCant1.Focus()
        End If
    End Sub

    Private Sub txtTotal2_TextChanged(sender As Object, e As EventArgs) Handles txtTotal2.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCant1_TextChanged(sender As Object, e As EventArgs) Handles txtCant1.TextChanged
        If txtCant1.Text = "" Then
            txtCant1.Text = "0"
        End If
        txtTotal1.Text = CDec(txtCant1.Text) * 1
        txtTotal1.Text = FormatNumber(txtTotal1.Text, 2)
    End Sub

    Private Sub txtCant1_GotFocus(sender As Object, e As EventArgs) Handles txtCant1.GotFocus
        txtCant1.SelectAll()
    End Sub

    Private Sub txtCant1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCant1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant1.Text = "" Then txtCant1.Text = "0"
            txtCantCentavos.Focus()
        End If
    End Sub

    Private Sub txtTotal1_TextChanged(sender As Object, e As EventArgs) Handles txtTotal1.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub txtCantCentavos_TextChanged(sender As Object, e As EventArgs) Handles txtCantCentavos.TextChanged
        If txtCantCentavos.Text = "" Then
            txtCantCentavos.Text = "0"
        End If
        txtTotalCentavos.Text = CDec(txtCantCentavos.Text) * 0.5
        txtTotalCentavos.Text = FormatNumber(txtTotalCentavos.Text, 2)
    End Sub

    Private Sub txtCantCentavos_GotFocus(sender As Object, e As EventArgs) Handles txtCantCentavos.GotFocus
        txtCantCentavos.SelectAll()
    End Sub

    Private Sub txtCantCentavos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantCentavos.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtCantCentavos.Text = "" Then txtCantCentavos.Text = "0"
            btnOKCalculo.Focus()
        End If
    End Sub

    Private Sub txtTotalCentavos_TextChanged(sender As Object, e As EventArgs) Handles txtTotalCentavos.TextChanged
        If txtTotal500.Text = "" Then
            txtTotal500.Text = "0.00"
        End If
        If txtTotal200.Text = "" Then
            txtTotal200.Text = "0.00"
        End If
        If txtTotal100.Text = "" Then
            txtTotal100.Text = "0.00"
        End If
        If txtTotal50.Text = "" Then
            txtTotal50.Text = "0.00"
        End If
        If txtTotal20.Text = "" Then
            txtTotal20.Text = "0.00"
        End If
        If txtTotal10.Text = "" Then
            txtTotal10.Text = "0.00"
        End If
        If txtTotal5.Text = "" Then
            txtTotal5.Text = "0.00"
        End If
        If txtTotal2.Text = "" Then
            txtTotal2.Text = "0.00"
        End If
        If txtTotal1.Text = "" Then
            txtTotal1.Text = "0.00"
        End If
        If txtTotalCentavos.Text = "" Then
            txtTotalCentavos.Text = "0.00"
        End If
        txtTotalCalculo.Text = CDec(txtTotal500.Text) + CDec(txtTotal200.Text) + CDec(txtTotal100.Text) + CDec(txtTotal50.Text) + CDec(txtTotal20.Text) + CDec(txtTotal10.Text) + CDec(txtTotal5.Text) + CDec(txtTotal2.Text) + CDec(txtTotal1.Text) + CDec(txtTotalCentavos.Text)
        txtTotalCalculo.Text = FormatNumber(txtTotalCalculo.Text, 2)
    End Sub

    Private Sub btnOKCalculo_Click(sender As Object, e As EventArgs) Handles btnOKCalculo.Click
        If CDec(txtTotalCalculo.Text) = 0 And CDec(txtTotalFormas.Text) = 0 Then
            MsgBox("No ha ingresado un cálculo válido", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If

        If txtTotalFormas.Text > 0 Then

            If MsgBox("Su cálculo de formas de pago en caja es de: $" & FormatNumber(txtTotalFormas.Text, 2) & vbNewLine & "¿La cantidad es correcta? Esta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
                txtTotalCalculo.Focus()
                txtTotalCalculo.SelectAll()
                Exit Sub
            Else

                Calculo = True
                txtSumCajeroTar.Text = txtTotalFormas.Text
                txtTotalCajeroTar.Text = txtTotalFormas.Text
                gbxCalculo.Visible = False
            End If

        End If

        If txtTotalCalculo.Text > 0 Then

            If MsgBox("Su cálculo de efectivo en caja es de: $" & FormatNumber(txtTotalCalculo.Text, 2) & vbNewLine & "¿La cantidad es correcta? Esta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
                txtTotalCalculo.Focus()
                txtTotalCalculo.SelectAll()
                Exit Sub
            Else

                Calculo = True
                txtSumaCajero.Text = txtTotalCalculo.Text
                txtTotalCajero.Text = txtTotalCalculo.Text
                gbxCalculo.Visible = False
            End If

        End If
        btnCalculadora.PerformClick()

    End Sub

    Private Sub txtSumSistema_TextChanged(sender As Object, e As EventArgs) Handles txtSumSistema.TextChanged
        Dim dife As Double = 0
        dife = CDbl(IIf(txtSumSistema.Text = "", "0", txtSumSistema.Text)) - CDbl(IIf(txtSumaCajero.Text = "", "0", txtSumaCajero.Text))

        If dife > 0 Then
            txtSumDife.Text = FormatNumber(dife, 2)
            txtTotalDife.Text = FormatNumber(dife, 2)
        Else
            txtSumDife.Text = FormatNumber(-dife, 2)
            txtTotalDife.Text = FormatNumber(-dife, 2)
        End If

    End Sub

    Private Sub txtIngresosTar_TextChanged(sender As Object, e As EventArgs) Handles txtIngresosTar.TextChanged
        Dim total As Double = CDbl(IIf(txtIngresosTar.Text = "", "0", txtIngresosTar.Text)) - CDbl(IIf(txtDevoluciones.Text = "", "0", txtDevoluciones.Text))
        txtSumSistemaTar.Text = FormatNumber(total, 2)
        txtTotalIngresosTar.Text = FormatNumber(total, 2)
    End Sub

    Private Sub txtformas_TextChanged(sender As Object, e As EventArgs) Handles txtformas.TextChanged
        If txtformas.Text = "" Then
            txtformas.Text = "0"
        End If
        txtTotalFormas.Text = CDec(txtformas.Text)
        txtTotalFormas.Text = FormatNumber(txtformas.Text, 2)
    End Sub

    Private Sub txtformas_GotFocus(sender As Object, e As EventArgs) Handles txtformas.GotFocus
        txtformas.SelectAll()
    End Sub

    Private Sub txtformas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtformas.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtformas.Text = "" Then txtformas.Text = "0"
            btnOKCalculo.Focus()
        End If
    End Sub

    Private Sub txtTotalFormas_TextChanged(sender As Object, e As EventArgs) Handles txtTotalFormas.TextChanged

    End Sub

    Private Sub txtSumSistemaTar_TextChanged(sender As Object, e As EventArgs) Handles txtSumSistemaTar.TextChanged
        Dim dife As Double = 0
        dife = CDbl(IIf(txtSumSistemaTar.Text = "", "0", txtSumSistemaTar.Text)) - CDbl(IIf(txtSumCajeroTar.Text = "", "0", txtSumCajeroTar.Text))

        If dife > 0 Then
            txtSumDifeTarj.Text = FormatNumber(dife, 2)
            txtTotalDifeTar.Text = FormatNumber(dife, 2)
        Else
            txtSumDifeTarj.Text = FormatNumber(-dife, 2)
            txtTotalDifeTar.Text = FormatNumber(-dife, 2)
        End If
    End Sub


End Class