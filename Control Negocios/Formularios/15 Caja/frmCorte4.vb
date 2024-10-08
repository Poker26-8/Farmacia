﻿Public Class frmCorte4
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
            Dim foliov As String = ""
            Dim status As String = ""

            Dim ventascontado As Double = 0
            Dim devolucionescontado As Double = 0
            Dim ventascredito As Double = 0
            Dim devolucionescredito As Double = 0

            Dim INGRESOSEFECTIVO As Double = 0
            Dim DEVOLUCIONESEFECTIVO As Double = 0

            'sacar las ventas que estan pagadas y no pagadas
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Folio,Status FROM ventas WHERE Fecha BETWEEN '" & Format(dtpInicial.Value, "yyyy-MM-dd") & " " & Format(dtpHInicial.Value) & "' AND '" & Format(dtpFin.Value, "yyyy-MM-dd") & " " & Format(dtpHFinal.Value, "HH:mm:ss") & "' AND Usuario='" & cboCajero.Text & "'"
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


                    End If

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()

            txtVentas.Text = FormatNumber(ventascontado, 2)
            txtDevolucionesV.Text = FormatNumber(devolucionescontado, 2)
            txtTotalContado.Text = CDec(txtVentas.Text) - CDec(txtDevolucionesV.Text)

            txtVentasC.Text = FormatNumber(ventascredito, 2)
            txtDevolucionesC.Text = FormatNumber(devolucionescredito, 2)
            txtCredito.Text = FormatNumber(CDec(txtVentasC.Text) - CDec(txtDevolucionesC.Text), 2)

            txtTotal.Text = FormatNumber(CDec(txtTotalContado.Text) - CDec(txtCredito.Text), 2)


            txtIngresos.Text = FormatNumber(INGRESOSEFECTIVO, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub
End Class