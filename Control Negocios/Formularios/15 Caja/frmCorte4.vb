Public Class frmCorte4

    Dim Calculo As Boolean = False
    Dim varcodunico As String = ""
    Dim usuario As String = ""

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
            cmd5.CommandText = "SELECT DISTINCT Usuario FROM abonoi WHERE Usuario<>'' AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND CorteU<>1 ORDER BY Usuario"
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

            If cboCajero.Text = "" Then MsgBox("Seleccione el cajero para continuar", vbInformation + vbOKOnly, titulocentral) : cboCajero.Focus.Equals(True) : Exit Sub


            Dim corteciego As Integer = DatosRecarga("CorteCiego")

            If corteciego = 1 Then
                If Calculo = False Then
                    MsgBox("Para continuar realice el cálculo de su efectivo en caja.", vbInformation + vbOKOnly, titulocentral)
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
            cmd1.CommandText = "SELECT Folio,Status FROM ventas WHERE Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Usuario='" & cboCajero.Text & "' AND CorteU<>1"
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
            cmd1.CommandText = "SELECT SUM(Monto) FROM otrosgastos WHERE Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & "' AND CorteU<>1"
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
            'txtCredito.Text = FormatNumber(CDec(txtVentasC.Text) - CDec(txtDevolucionesC.Text), 2)
            txtCredito.Text = FormatNumber(CDec(txtVentasC.Text) - (CDec(txtDevolucionesC.Text) + CDec(txtAbonosCreditos.Text)), 2)

            txtTotal.Text = FormatNumber(CDec(txtTotalContado.Text) + CDec(txtCredito.Text), 2)

            txtIngresosTar.Text = FormatNumber(INGRESOSFORMAS, 2)

            txtDevoluciones.Text = FormatNumber(CDec(txtDevolucionesC.Text) + CDec(txtDevolucionesV.Text), 2)
            txtRetiros.Text = FormatNumber(retiros, 2)
            txtIngresos.Text = FormatNumber(INGRESOSEFECTIVO, 2)


            If MsgBox("¿Deseas imprimir el calculo del corte caja?", vbInformation + vbOKCancel, "Delsscom Farmacias") = vbOK Then

                Dim tami As Integer = TamImpre()
                Dim impresora As String = ImpresoraImprimir()

                If tami = "80" Then

                    PCalculo80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PCalculo80.Print()
                End If

            End If
            Calculo = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Function QuitarCaracteresEspeciales(ByVal input As String) As String
        ' Utilizamos una expresión regular para reemplazar todos los caracteres que no son letras o números.
        Dim regex As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")
        Return regex.Replace(input, String.Empty)
    End Function

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
        If txtCant20.Text = "" Then
            txtCant20.Text = "0"
        End If
        txtTotal20.Text = CDec(txtCant20.Text) * 20
        txtTotal20.Text = FormatNumber(txtTotal20.Text, 2)
    End Sub

    Private Sub txtCant20_GotFocus(sender As Object, e As EventArgs) Handles txtCant20.GotFocus
        txtCant20.SelectAll()
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
        If CDec(txtTotalCalculo.Text) = 0 Then
            MsgBox("No ha ingresado un cálculo válido", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If

        'If txtTotalFormas.Text > 0 Then

        '    If MsgBox("Su cálculo de formas de pago en caja es de: $" & FormatNumber(txtTotalFormas.Text, 2) & vbNewLine & "¿La cantidad es correcta? Esta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
        '        txtTotalCalculo.Focus()
        '        txtTotalCalculo.SelectAll()
        '        Exit Sub
        '    Else

        '        Calculo = True
        '        txtSumCajeroTar.Text = txtTotalFormas.Text
        '        txtTotalCajeroTar.Text = txtTotalFormas.Text
        '        gbxCalculo.Visible = False
        '    End If

        'End If

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

        txtTotalIngresosTar.Text = FormatNumber(total, 2)
        txtTotalCajeroTar.Text = FormatNumber(total, 2)
        txtSumCajeroTar.Text = FormatNumber(total, 2)
        txtSumSistemaTar.Text = FormatNumber(total, 2)


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

    Private Sub PCalculo80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCalculo80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_prods2 As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim otraY As Integer = 0

        Dim fechainicial As Date = dtpHInicial.Value
        Dim horainicial As Date = dtpHInicial.Value
        Dim finiciala As String = Format(fechainicial, "yyyy/MM/dd") & " " & Format(horainicial, "HH:mm:ss")

        Dim fechafinal As Date = dtpFin.Value
        Dim horafinal As Date = dtpHFinal.Value
        Dim ffinal As String = Format(fechafinal, "yyyy/MM/dd") & " " & Format(horafinal, "HH:mm:ss")


        e.Graphics.DrawString("Nombre de la farmacia", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString(farmaciaseleccionada, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 10
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 12

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 10
                End If
                Y += 2
            End If
        Else
            Y += 0
        End If
        rd1.Close() : cnn1.Close()

        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 8
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("** CALCULO PARCIAL DE CAJA **", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 20

        e.Graphics.DrawString("FECHA: " & Format(Date.Now, "yyyy/MM/dd HH:mm:ss"), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE INICIAL: " & finiciala, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE FINAL: " & ffinal, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("CAJERO: " & cboCajero.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("VENTAS DE CONTADO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtVentas.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtDevolucionesV.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Servicios:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtServicios.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Venta de tiempo aire:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtTiempo.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CONTADO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtTotalContado.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 20

        e.Graphics.DrawString("VENTAS DE CREDITO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtVentasC.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Abonos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtAbonosCreditos.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtDevolucionesC.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CREDITO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtCredito.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL GENERAL:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotal.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("SISTEMA", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString("CAJERO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y)
        e.Graphics.DrawString("DIF", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("EFECTIVO/PESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(txtIngresos.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Saldo Inicial:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(txtSaldoInicial.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Retiros:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtRetiros.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtDevoluciones.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(txtSumSistema.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtSumaCajero.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtSumDife.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotalSistema.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtTotalCajero.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtTotalDife.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15

        e.Graphics.DrawString("DOCUMENTOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y, sc)
        Y += 15
        e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(" " & txtIngresosTar.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtDevoTarj.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(txtSumSistemaTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtSumCajeroTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtSumDifeTarj.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL DOCUMENTOS", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotalIngresosTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtTotalCajeroTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtTotalDifeTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cboCajero.Text = ""
        dtpInicial.Value = Date.Now
        dtpHInicial.Text = "00:00:00"
        dtpFin.Value = Date.Now
        dtpHFinal.Text = "23:59:59"

        txtVentas.Text = "0.00"
        txtDevolucionesV.Text = "0.00"
        txtServicios.Text = "0.00"
        txtTiempo.Text = "0.00"
        txtTotalContado.Text = "0.00"
        txtVentasC.Text = "0.00"
        txtAbonosCreditos.Text = "0.00"
        txtDevolucionesC.Text = "0.00"
        txtCredito.Text = "0.00"
        txtTotal.Text = "0.00"
        txtIngresos.Text = "0.00"
        txtSaldoInicial.Text = "0.00"
        txtRetiros.Text = "0.00"
        txtDevoluciones.Text = "0.00"
        txtSumSistema.Text = "0.00"
        txtSumaCajero.Text = "0.00"
        txtSumDife.Text = "0.00"
        txtTotalSistema.Text = "0.00"
        txtTotalCajero.Text = "0.00"
        txtTotalDife.Text = "0.00"
        txtIngresosTar.Text = "0.00"
        txtDevoTarj.Text = "0.00"
        txtSumSistemaTar.Text = "0.00"
        txtSumCajeroTar.Text = "0.00"
        txtSumDifeTarj.Text = "0.00"
        txtTotalIngresosTar.Text = "0.00"
        txtTotalCajeroTar.Text = "0.00"
        txtTotalDifeTar.Text = "0.00"

        txtCant500.Text = "0"
        txtCant200.Text = "0"
        txtCant100.Text = "0"
        txtCant50.Text = "0"
        txtCant20.Text = "0"
        txtCant10.Text = "0"
        txtCant5.Text = "0"
        txtCant2.Text = "0"
        txtCant1.Text = "0"
        txtCantCentavos.Text = "0"


        txtTotal500.Text = "0.00"
        txtTotal200.Text = "0.00"
        txtTotal100.Text = "0.00"
        txtTotal50.Text = "0.00"
        txtTotal20.Text = "0.00"
        txtTotal10.Text = "0.00"
        txtTotal5.Text = "0.00"
        txtTotal2.Text = "0.00"
        txtTotal1.Text = "0.00"
        txtTotalCentavos.Text = "0.00"
        txtTotalCalculo.Text = "0.00"

        Calculo = False
    End Sub

    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        Try

            varcodunico = Format(CDate(Date.Now), "yyyy/MM/ddHH:mm:ss.fff")
            varcodunico = QuitarCaracteresEspeciales(varcodunico)

            If usuario = "" Then
                pcontra.Visible = True
                txtContraseña.Focus.Equals(True)

            Else
                Dim foliov As Integer = 0

                If MsgBox("¿Deseas realizar el corte de los días seleccionados?", vbInformation + vbOKCancel, "Delsscom Farmacias") = vbOK Then

                    cnn1.Close() : cnn1.Open()
                    cnn2.Close() : cnn2.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Folio FROM ventas WHERE Usuario='" & cboCajero.Text & "' AND Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then

                            foliov = rd1(0).ToString

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE ventas SET CorteU=1 WHERE Folio=" & foliov & " AND CorteU=0 AND Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "'"
                            cmd2.ExecuteNonQuery()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "UPDATE Abonoi SET CorteU=1 WHERE NumFolio=" & foliov & " AND CorteU=0 AND FechaCompleta BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "'"
                            cmd2.ExecuteNonQuery()
                        End If
                    Loop
                    rd1.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE otrosgastos SET CorteU=1 WHERE CorteU=0 AND Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & "'"
                    cmd2.ExecuteNonQuery()


                    Dim ventasconta As Double = txtVentas.Text
                    Dim devoconta As Double = txtDevolucionesV.Text
                    Dim serconta As Double = txtServicios.Text
                    Dim tiempoconta As Double = txtTiempo.Text
                    Dim totalcontado As Double = txtTotalContado.Text
                    Dim ventascre As Double = txtVentasC.Text
                    Dim abonoscre As Double = txtAbonosCreditos.Text
                    Dim devolucionescre As Double = txtDevolucionesC.Text
                    Dim totalcredito As Double = txtCredito.Text
                    Dim totalgeneral As Double = txtTotal.Text
                    Dim ingresos As Double = txtIngresos.Text
                    Dim saldoinicial As Double = txtSaldoInicial.Text
                    Dim retiros As Double = txtRetiros.Text
                    Dim devoluciones As Double = txtDevoluciones.Text
                    Dim sumaingresos As Double = txtSumSistema.Text
                    Dim sumacajero As Double = txtSumaCajero.Text
                    Dim sumadiferencia As Double = txtSumDife.Text
                    Dim totalsistema As Double = txtTotalSistema.Text
                    Dim totalcajero As Double = txtTotalCajero.Text
                    Dim totaldiferencia As Double = txtTotalDife.Text
                    Dim ingresostarjeta As Double = txtIngresosTar.Text
                    Dim devolucionestarjeta As Double = txtDevoTarj.Text
                    Dim sumasistematar As Double = txtSumSistemaTar.Text
                    Dim sumacajerotar As Double = txtSumCajeroTar.Text
                    Dim sumadiferenciatar As Double = txtSumDifeTarj.Text
                    Dim totalingresostar As Double = txtTotalIngresosTar.Text
                    Dim totalcajerotar As Double = txtTotalCajeroTar.Text
                    Dim totaldiferenciatar As Double = txtTotalDifeTar.Text

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "INSERT INTO corteusuariofar(Folio,FInicial,FFinal,FCorte,Cajero,Usuario,VentasC,DevolucionesC,ServiciosC,RecargasC,TotalContado,VentasCre,AbonosCre,DevolucionesCre,TotalCredito,TotalGeneral,Ingresos,SaldoInicial,Retiros,DevolucionesT,SumaIngresos,SumaCajero,SumaDiferencia,TotalIngresos,TotalCajero,TotalDiferencia,IngresosF,DevolucionesF,SumaIngresosF,SumaCajeroF,SumaDiferenciaF,TotalIngresosF,TotalCajeroF,TotalDiferenciaF) VALUES('" & varcodunico & "','" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value, "HH:mm:ss") & "','" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & cboCajero.Text & "','" & usuario & "'," & ventasconta & "," & devoconta & "," & serconta & "," & tiempoconta & "," & totalcontado & "," & ventascre & "," & abonoscre & "," & devolucionescre & "," & totalcredito & "," & totalgeneral & "," & ingresos & "," & saldoinicial & "," & retiros & "," & devoluciones & "," & sumaingresos & "," & sumacajero & "," & sumadiferencia & "," & totalsistema & "," & totalcajero & "," & totaldiferencia & "," & ingresostarjeta & "," & devolucionestarjeta & "," & sumasistematar & "," & sumacajerotar & "," & sumadiferenciatar & "," & totalingresostar & "," & totalcajerotar & "," & totaldiferenciatar & ")"
                    If cmd1.ExecuteNonQuery() Then
                        MsgBox("Cierre realizado correctamente", vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                    cnn1.Close()

                    Dim impre As Integer = TamImpre()
                    Dim impresora As String = ImpresoraImprimir()
                    If impre = "80" Then
                        PCierre80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PCierre80.Print()
                    End If

                End If
                Button1.PerformClick()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub PCierre80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PCierre80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_prods2 As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim otraY As Integer = 0

        Dim fechainicial As Date = dtpHInicial.Value
        Dim horainicial As Date = dtpHInicial.Value
        Dim finiciala As String = Format(fechainicial, "yyyy/MM/dd") & " " & Format(horainicial, "HH:mm:ss")

        Dim fechafinal As Date = dtpFin.Value
        Dim horafinal As Date = dtpHFinal.Value
        Dim ffinal As String = Format(fechafinal, "yyyy/MM/dd") & " " & Format(horafinal, "HH:mm:ss")


        e.Graphics.DrawString("Nombre de la farmacia", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString(farmaciaseleccionada, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 12

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 10
                End If
                Y += 4
            End If
        Else
            Y += 0
        End If
        rd1.Close() : cnn1.Close()

        e.Graphics.DrawString("Atiende: " & cboCajero.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 10
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 7
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("** CORTE FINAL DE CAJERO **", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 20

        e.Graphics.DrawString("FOLIO: " & varcodunico, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA: " & Format(Date.Now, "yyyy/MM/dd HH:mm:ss"), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE INICIAL: " & finiciala, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("FECHA CORTE FINAL: " & ffinal, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 17
        e.Graphics.DrawString("CAJERO: " & cboCajero.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        Y += 12
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("VENTAS DE CONTADO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtVentas.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtDevolucionesV.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Servicios:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtServicios.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Venta de tiempo aire:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtTiempo.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CONTADO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtTotalContado.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 20

        e.Graphics.DrawString("VENTAS DE CREDITO: ", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ventas:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtVentasC.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Abonos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtAbonosCreditos.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString("-" & txtDevolucionesC.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL CREDITO:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 15, Y)
        e.Graphics.DrawString(txtCredito.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("---------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 20
        e.Graphics.DrawString("TOTAL GENERAL:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotal.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15
        e.Graphics.DrawString("SISTEMA", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString("CAJERO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y)
        e.Graphics.DrawString("DIF", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("EFECTIVO/PESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(txtIngresos.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Saldo Inicial:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(txtSaldoInicial.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Retiros:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtRetiros.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtDevoluciones.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 130, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(txtSumSistema.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtSumaCajero.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtSumDife.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotalSistema.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtTotalCajero.Text, New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtTotalDife.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 13
        e.Graphics.DrawString("-------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 5, Y)
        Y += 15

        e.Graphics.DrawString("DOCUMENTOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 190, Y, sc)
        Y += 15
        e.Graphics.DrawString("FORMAS DE PAGO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Ingresos:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString(" " & txtIngresosTar.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("Devoluciones:", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 13, Y)
        e.Graphics.DrawString("-" & txtDevoTarj.Text, New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 120, Y)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString(txtSumSistemaTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtSumCajeroTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtSumDifeTarj.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 120, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 180, Y)
        e.Graphics.DrawString("----", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 285, Y, sf)
        Y += 15
        e.Graphics.DrawString("TOTAL DOCUMENTOS", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString(txtTotalIngresosTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 120, Y)
        e.Graphics.DrawString(txtTotalCajeroTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y)
        e.Graphics.DrawString(txtTotalDifeTar.Text, New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 285, Y, sf)
        Y += 30
        otraY = Y


        GeneraBarras(PictureBox1, varcodunico)
        Dim bm As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        PictureBox1.DrawToBitmap(bm, New Rectangle(0, 0, bm.Width, bm.Height))
        e.Graphics.DrawImage(bm, 40, otraY, 210, 40)
        Y += 45
        e.Graphics.DrawString(varcodunico, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 100
        e.Graphics.DrawString("--------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString("Cajero", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)

    End Sub

    Private Sub txtSumaCajero_TextChanged(sender As Object, e As EventArgs) Handles txtSumaCajero.TextChanged
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

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                If txtContraseña.Text = "" Then
                    Exit Sub
                End If
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtContraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        usuario = rd1("Alias").ToString
                        pcontra.Visible = False
                    End If
                Else
                    MsgBox("Contraseña incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtContraseña.Text = ""
                    txtContraseña.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub
End Class