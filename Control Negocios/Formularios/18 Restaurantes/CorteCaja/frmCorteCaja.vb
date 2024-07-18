
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.IO
Public Class frmCorteCaja

    Dim CorteGlobal As Boolean = False
    Dim Cierre As Boolean = False
    Dim Calculo As Boolean = False

    Dim usuario As String = ""
    Dim id_usu As Integer = 0
    Private Sub frmCorteCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFecha.Value = Date.Now
        dtpHoraIni.Text = "00:00:00"
        dtpFechaFinal.Value = Date.Now
        dtpHoraFin.Text = "23:59:59"

        dtpFechaIU.Value = Date.Now
        dtpHoraIU.Text = "00:00:00"
        dtpFechaFU.Value = Date.Now
        dtpHoraFU.Text = "23:59:59"

        CorteGlobal = False
        Cierre = False
        Calculo = False

        C_Global()

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
    End Sub

    Private Sub C_Global()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM CorteCaja WHERE Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtSaldoGlobal.Text = FormatNumber(rd1("Saldo_ini").ToString, 2)
                End If
            Else
                txtSaldoGlobal.Text = "0.00"
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Function TipoCorte() As Integer
        Dim tipo As Integer = 0
        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='CorteCiego'"
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

    Private Sub btnSaldoGlobal_Click(sender As Object, e As EventArgs) Handles btnSaldoGlobal.Click
        Dim saldo_global As Double = txtSaldoGlobal.Text
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM CorteCaja WHERE Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtSaldoGlobal.Text = FormatNumber(rd1("Saldo_Ini").ToString(), 2)
                    MsgBox("Ya cuentas con un saldo inicial registrado para el día " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate), vbInformation + vbOKOnly, titulocentral)
                    btnCalcularGlobal.Focus().Equals(True)
                End If
            Else
                If MsgBox("¿Deseas registrar el saldo inicial para el día de hoy " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate) & "?", vbInformation + vbOKCancel, titulocentral) = vbOK Then
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO CorteCaja(NumCorte,Saldo_Ini,Fecha,Saldo_Fin) VALUES(0," & saldo_global & ",'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "',0)"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Saldo inicial registrado para el día " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate), vbInformation + vbOKOnly, titulocentral)
                    End If
                    cnn2.Close()
                Else
                    txtSaldoGlobal.Focus().Equals(True)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtSaldoGlobal_Click(sender As Object, e As EventArgs) Handles txtSaldoGlobal.Click
        txtSaldoGlobal.SelectionStart = 0
        txtSaldoGlobal.SelectionLength = Len(txtSaldoGlobal.Text)
    End Sub

    Private Sub txtSaldoGlobal_GotFocus(sender As Object, e As EventArgs) Handles txtSaldoGlobal.GotFocus
        txtSaldoGlobal.SelectionStart = 0
        txtSaldoGlobal.SelectionLength = Len(txtSaldoGlobal.Text)
    End Sub

    Private Sub txtSaldoGlobal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSaldoGlobal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtSaldoGlobal.Text) Then txtSaldoGlobal.Text = "0" : Exit Sub
            txtSaldoGlobal.Text = FormatNumber(txtSaldoGlobal.Text, 2)
            btnSaldoGlobal.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnLimpiarGlobal_Click(sender As Object, e As EventArgs) Handles btnLimpiarGlobal.Click
        dtpFecha.Value = Date.Now
        dtpHoraIni.Text = "00:00:00"
        dtpFechaFinal.Value = Date.Now
        dtpHoraFin.Text = "23:59:59"

        txtSaldoGlobal.Text = "0.00"

        'INGRESOS
        txtVentasG.Text = "0.00"
        txtComprasCanceG.Text = "0.00"
        txtCobroEmpG.Text = "0.00"
        txtIngresosGlobal.Text = "0.00"
        txtIngEfectivoG.Text = "0.00"
        txtingresosformas.Text = "0.00"
        txtIngresoPropina.Text = "0.00"
        TXTglobalPro.Text = "0.00"
        grdingresosglobal.Rows.Clear()
        C_Global()
        CorteGlobal = False

        'EGRESOS
        txtComprasG.Text = "0.00"
        txtPrestamoEmpG.Text = "0.00"
        txtNominaG.Text = "0.00"
        txtTransporteG.Text = "0.00"
        txtOtrosGastosG.Text = "0.00"
        txtCanceDevoG.Text = "0.00"
        txtEgresosGlobal.Text = "0.00"
        txtEgrEfectivoG.Text = "0.00"
        grdegresosglobal.Rows.Clear()
        txtegresosforma.Text = "0.00"
        MonederoCajaG.Text = "0.00"

        'FINALES
        txtSaldoFinalG.Text = "0.00"
        EfectivoCajaG.Text = "0.00"
        MonederoCajaG.Text = "0.00"
    End Sub

    Private Sub btnCalcularGlobal_Click(sender As Object, e As EventArgs) Handles btnCalcularGlobal.Click

        If CorteGlobal = True Then
            Exit Sub
        End If

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo_Ini FROM CorteCaja WHERE Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                MsgBox("Necesitas registrar un saldo inicial para generar el reporte.", vbInformation + vbOKOnly, titulocentral)
                txtSaldoGlobal.Focus().Equals(True)
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT sum(Abono) FROM AbonoI where Concepto='ABONO' AND FormaPago<>'SALDO A FAVOR' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND Status=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtVentasG.Text = rd1(0).ToString
                    If txtVentasG.Text = "" Then
                        txtVentasG.Text = "0.00"
                    End If
                    txtVentasG.Text = FormatNumber(txtVentasG.Text, 2)
                End If
            End If
            rd1.Close()

            'compras canceladas
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT SUM(Abono) FROM abonoe WHERE Concepto='CANCELACION' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtComprasCanceG.Text = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    txtComprasCanceG.Text = FormatNumber(txtComprasCanceG.Text, 2)
                End If
            End If
            rd1.Close()

            'Cobro a empleados
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT sum(Monto) FROM SaldosEmpleados where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Concepto='COBRO'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCobroEmpG.Text = IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString)
                    txtCobroEmpG.Text = FormatNumber(txtCobroEmpG.Text, 2)
                End If
            End If
            rd1.Close()

            Dim Efectivo As String = "0"
            'Efectivo
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select sum(Monto) from AbonoI where Concepto='ABONO' and Fecha BETWEEN'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND FormaPago='EFECTIVO' AND Status=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString))
                    txtIngEfectivoG.Text = FormatNumber(Efectivo, 2)
                End If
            End If
            rd1.Close()

            Dim formapagoglobal As String = ""
            Dim montoglobal As Double = 0
            Dim totalglobal As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT DISTINCT FormaPago FROM AbonoI WHERE Concepto='ABONO' AND FormaPago<>'EFECTIVO' and FormaPago<>'SALDO A FAVOR' and Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND Status='0'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    formapagoglobal = rd1(0).ToString

                    If formapagoglobal <> "" Then
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select sum(Monto) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha BETWEEN'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND FormaPago='" & formapagoglobal & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                montoglobal = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)

                                grdingresosglobal.Rows.Add(formapagoglobal, FormatNumber(montoglobal, 2))

                                totalglobal = totalglobal + CDec(montoglobal)
                            End If
                        End If
                        rd2.Close()
                    End If
                End If
            Loop
            rd1.Close()
            cnn2.Close()
            txtingresosformas.Text = FormatNumber(totalglobal, 2)


            Dim ingresospropinas As Double = 0
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT sum(Propina) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ingresospropinas = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                    txtIngresoPropina.Text = FormatNumber(ingresospropinas, 2)
                End If
            End If
            rd1.Close()
            cnn1.Close()

            Dim Ingresos As String = "0"
            Ingresos = CDec(txtVentasG.Text) + CDec(txtComprasCanceG.Text) + CDec(txtCobroEmpG.Text)
            txtIngresosGlobal.Text = FormatNumber(Ingresos, 2)

            Dim ingresospro As Double = 0
            ingresospro = CDec(txtIngEfectivoG.Text) + CDec(txtingresosformas.Text) + CDec(txtIngresoPropina.Text)
            TXTglobalPro.Text = FormatNumber(ingresospro, 2)
            '  My.Application.DoEvents()


            '------------------------------------EGRESOS-------------------------------------------------------

            'Compras
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select sum(Abono) from AbonoE where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND Abono<>0 AND Concepto='ABONO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtComprasG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtComprasG.Text = FormatNumber(txtComprasG.Text, 2)
                End If
            End If
            rd2.Close()

            'Prestamo a empleados
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT SUM(Monto) FROM SaldosEmpleados where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Concepto<>'COBRO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtPrestamoEmpG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtPrestamoEmpG.Text = FormatNumber(txtPrestamoEmpG.Text, 2)
                End If
            End If
            rd2.Close()

            'Nómina
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT sum(Total) FROM otrosgastos WHERE Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Concepto='NOMINA'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtNominaG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtNominaG.Text = FormatNumber(txtNominaG.Text, 2)
                End If
            End If
            rd2.Close()

            'Otros gastos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT SUM(Total) FROM OtrosGastos WHERE Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Concepto<>'NOMINA'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtOtrosGastosG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtOtrosGastosG.Text = FormatNumber(txtOtrosGastosG.Text, 2)
                End If
            End If
            rd2.Close()


            Dim CanceDevo As String = "0"
            Dim NotaCance As String = "0"
            Dim EgrEfectivo As String = "0"
            Dim egrEfectivodevo As Double = 0
            'Efectivo
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT SUM(Monto) FROM Abonoi WHERE Concepto='DEVOLUCION' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT SUM(Monto) FROM Abonoi WHERE Concepto='NOTA CANCELADA' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    NotaCance = CDec(NotaCance) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Monto) from OtrosGastos where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND FormaPago='EFECTIVO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Monto) from AbonoE where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND FormaPago='EFECTIVO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(nom_salario) from Nomina where nom_fecha_nomina='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT sum(Monto) FROM saldosempleados WHERE Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND FormaPago='EFECTIVO'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT sum(Monto) FROM abonoi WHERE Concepto='DEVOLUCION' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    egrEfectivodevo = CDec(egrEfectivodevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()
            txtEgrEfectivoG.Text = FormatNumber(CDbl(EgrEfectivo + egrEfectivodevo), 2)


            Dim EgrTarjeta As String = "0"
            Dim EgrTran As String = "0"
            Dim EgrOtro As Double = 0

            Dim formaglobalforma As String = ""
            Dim montoglobalforma As Double = 0
            Dim totalformaglobal As Double = 0

            cnn3.Close() : cnn3.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT FormaPago FROM AbonoI WHERE Concepto<>'ABONO' and Concepto<>'DEVOLUCION'and Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "' AND FormaPago<>'EFECTIVO'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    formaglobalforma = rd2(0).ToString

                    If formaglobalforma <> "" Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "select sum(Monto) from AbonoI where Concepto<>'ABONO' and Concepto<>'CARGO' AND Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpFechaFinal.Value, "HH:mm:ss") & "' AND FormaPago='" & formaglobalforma & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then

                                montoglobalforma = IIf(rd3(0).ToString = "", "0.00", rd3(0).ToString)
                                'CanceDevo = CDec(CanceDevo) + CDec(IIf(rd3(0).ToString = "", "0.00", rd3(0).ToString))
                                grdegresosglobal.Rows.Add(formaglobalforma, montoglobalforma)

                                totalformaglobal = totalformaglobal + CDec(montoglobalforma)
                            End If
                            rd3.Close()
                        End If

                    End If
                End If
            Loop
            rd2.Close()
            txtegresosforma.Text = FormatNumber(totalformaglobal, 2)
            cnn3.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Tarjeta) from AbonoE where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrTarjeta = CDec(EgrTarjeta) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                    txtEgrTarjetaG.Text = FormatNumber(EgrTarjeta, 2)
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Transfe) from AbonoE where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrTran = CDec(EgrTran) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                    txtEgrTransfeG.Text = FormatNumber(EgrTran, 2)
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Otro) from AbonoE where Fecha BETWEEN '" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFinal.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIni.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFin.Value, "HH:mm:ss") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrOtro = CDec(EgrOtro) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()
            cnn2.Close()

            txtEgrDepositoG.Text = FormatNumber(EgrOtro, 2)
            txtCanceDevoG.Text = FormatNumber(CDbl(CanceDevo) + CDbl(NotaCance), 2)

            Dim Egresos As String = "0"
            Egresos = CDec(txtComprasG.Text) + +CDec(txtPrestamoEmpG.Text) + CDec(txtNominaG.Text) + CDec(txtTransporteG.Text) + CDec(txtOtrosGastosG.Text) + CDec(txtCanceDevoG.Text)
            txtEgresosGlobal.Text = FormatNumber(Egresos, 2)
            My.Application.DoEvents()

            'Saldo final
            txtSaldoFinalG.Text = (CDec(txtSaldoGlobal.Text) + CDec(txtIngresosGlobal.Text)) - CDec(txtEgresosGlobal.Text)
            txtSaldoFinalG.Text = FormatNumber(txtSaldoFinalG.Text, 2)

            'Efectivo en caja
            EfectivoCajaG.Text = (CDec(txtSaldoGlobal.Text) + CDec(txtIngEfectivoG.Text)) - CDec(txtEgrEfectivoG.Text)
            EfectivoCajaG.Text = FormatNumber(EfectivoCajaG.Text, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update CorteCaja set Saldo_Fin=" & CDbl(txtSaldoFinalG.Text) & " where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try

        CorteGlobal = True

        Dim impresora As String = ""
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
                "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                impresora = rd1(0).ToString
            End If
        End If
        rd1.Close()

        If MsgBox("¿Deseas imprimir el cálculo del corte de caja?", vbInformation + vbOKCancel, "Delsscom Control Negocios 2022") = vbOK Then
            Dim tam_impre As String = IIf(DatosRecarga("TamImpre") = "", "80", DatosRecarga("TamImpre"))

            If tam_impre = "80" Then
                pCalculoGlobal80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pCalculoGlobal80.Print()
            Else
                pCalculoGlobal58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pCalculoGlobal58.Print()
            End If
            CorteGlobal = True
        End If

        If MsgBox("¿Deseas enviar el corte por correo electrónico?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Insert_Corte_G()
            PDF_Corte_G()
        End If

        cnn1.Close()

    End Sub

    Private Sub Insert_Corte_G()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim Resta As Double = 0
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from Caja_Ingresos", sinfo)
                sinfo = ""

                'Inserta ingresos
                '-Efectivo
                If CDbl(txtIngEfectivoG.Text) > 0 Then
                    If .runSp(a_cnn, "insert into Caja_Ingresos(Concepto,Monto) values('ING. EFECTIVO'," & CDbl(txtIngEfectivoG.Text) & ")", sinfo) Then
                        sinfo = ""
                    Else
                        MsgBox(sinfo)
                    End If
                End If
                '-Otros
                If grdingresosglobal.Rows.Count > 0 Then
                    For t As Integer = 0 To grdingresosglobal.Rows.Count - 1
                        Dim monto_ing As String = grdingresosglobal.Rows(t).Cells(0).Value.ToString()
                        Dim monto As Double = grdingresosglobal.Rows(t).Cells(1).Value.ToString()

                        If .runSp(a_cnn, "insert into Caja_Ingresos(Concepto,Monto) values('ING. " & monto_ing & "'," & CDbl(monto) & ")", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    Next
                End If

                'Inserta egresos
                '-Efectivo
                If CDbl(txtEgrEfectivoG.Text) > 0 Then
                    If .runSp(a_cnn, "insert into Caja_Ingresos(Concepto,Monto) values('EGR. EFECTIVO'," & CDbl(txtEgrEfectivoG.Text) & ")", sinfo) Then
                        sinfo = ""
                    Else
                        MsgBox(sinfo)
                    End If
                End If
                '-Otros
                If grdegresosglobal.Rows.Count > 0 Then
                    For t As Integer = 0 To grdegresosglobal.Rows.Count - 1
                        Dim monto_igr As String = grdegresosglobal.Rows(t).Cells(0).Value.ToString()
                        Dim monto As Double = grdegresosglobal.Rows(t).Cells(1).Value.ToString()

                        If .runSp(a_cnn, "insert into Caja_Ingresos(Concepto,Monto) values('EGR. " & monto_igr & "'," & CDbl(monto) & ")", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    Next
                End If

                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub PDF_Corte_G()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New Corte_Caja
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = "C:\ControlNegociosPro\DL1.mdb"
            .DatabaseName = "C:\ControlNegociosPro\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'Los totales los va a mandar directos
        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Saldo_Inicial").Text = "'" & FormatNumber(txtSaldoGlobal.Text, 2) & "'"
        FileNta.DataDefinition.FormulaFields("Total_Ingresos").Text = "'" & FormatNumber(txtIngresosGlobal.Text, 2) & "'"
        FileNta.DataDefinition.FormulaFields("Total_Egresos").Text = "'" & FormatNumber(txtEgresosGlobal.Text, 2) & "'"
        FileNta.DataDefinition.FormulaFields("Saldo_Final").Text = "'" & FormatNumber(txtSaldoFinalG.Text, 2) & "'"

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            Dim root_corte As String = "C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf"
            My.Application.DoEvents()
            frmEnvio_Corte.Show()
            frmEnvio_Corte.BringToFront()
            frmEnvio_Corte.archivoadj = root_corte
            frmEnvio_Corte.txtasunto.Text = "Corte de caja global del día " & Format(Date.Now, "yyyy-MM-dd") & ""

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then

            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdff")
            End If

            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\CORTES\CorteDia_" & Format(Date.Now, "yyyy-MM-dd") & ".pdf")
        End If
    End Sub

    Private Sub btnSaldoUsuario_Click(sender As Object, e As EventArgs) Handles btnSaldoUsuario.Click
        If cboUsuario.Text = "" Then MsgBox("Selecciona un usuario para registrar su saldo inicial.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") : cboUsuario.Focus().Equals(True) : Exit Sub
        If txtContrasena.Text = "" Then MsgBox("Escribe la contraseña del usuario para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") : txtContrasena.Focus().Equals(True) : Exit Sub
        If txtSaldoUsuario.Text = "" Then MsgBox("El saldo inicial no puede estar vacío.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") : txtSaldoUsuario.Focus().Equals(True) : Exit Sub

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from CorteUsuario where Usuario='" & cboUsuario.Text & "'and Saldo_Fin=0 and NumCorte=" & txtNumCorte.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("Ya cuentas con un saldo inicial registrado para el usuario " & cboUsuario.Text, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
            Else
                If MsgBox("¿Deseas registrar el saldo inicial para el usuario " & cboUsuario.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios 2022") = vbOK Then
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into CorteUsuario(NumCorte,Saldo_Ini,Calculo,Diferencia,Saldo_Fin,Usuario,Fecha) values(" & txtNumCorte.Text & "," & CDbl(txtSaldoUsuario.Text) & ",0,0,0,'" & cboUsuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Saldo inicial registrado.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                    End If
                    cnn2.Close()
                Else
                    txtSaldoUsuario.Focus().Equals(True)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboUsuario_DropDown(sender As Object, e As EventArgs) Handles cboUsuario.DropDown
        cboUsuario.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT distinct Usuario FROM AbonoI WHERE CorteU=0 and Usuario<>''"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboUsuario.Items.Add(rd5(0).ToString())
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUsuario.KeyPress
        Dim usu_alias As String = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtContrasena.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        usu_alias = rd1("Alias").ToString
                        If usu_alias = cboUsuario.Text Then
                            txtSaldoUsuario.Focus().Equals(True)
                        Else
                            MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                            txtContrasena.SelectAll()
                        End If
                    End If
                Else
                    MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                    txtContrasena.SelectAll()
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboUsuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUsuario.SelectedValueChanged
        Try
            txtContrasena.Focus().Equals(True)

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Usuarios where Alias='" & cboUsuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                End If
            Else
                MsgBox("No se encuentra un usuarios registrado con este alias por lo tanto no se puede realizar el corte de caja." & vbNewLine & "Éste error puede ser ocasionado por un cambio en el alias del producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                cboUsuario.Text = ""
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumCorte from CorteUsuario where Id=(select MAX(Id) from CorteUsuario where (Saldo_Ini<>0) and Usuario='" & cboUsuario.Text & "' and Saldo_Fin=0)"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtNumCorte.Text = rd1(0).ToString
                End If
            Else
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select MAX(NumCorte) from CorteUsuario where Usuario='" & cboUsuario.Text & "' and Saldo_Fin<>0"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        txtNumCorte.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + 1
                    End If
                Else
                    txtNumCorte.Text = "1"
                End If
                rd2.Close() : cnn2.Close()
            End If
            rd1.Close()

            Dim Saldo As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Saldo_Ini from CorteUsuario where NumCorte=" & txtNumCorte.Text & " and Usuario='" & cboUsuario.Text & "' and Saldo_Fin=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Saldo = rd1("Saldo_Ini").ToString
                    txtSaldoUsuario.Text = FormatNumber(Saldo, 2)
                    If TipoCorte() = 1 Then
                        cnn2.Close() : cnn2.Open()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select * from CorteUsuario where Usuario='" & cboUsuario.Text & "' and NumCorte=" & txtNumCorte.Text & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                If rd2("Calculo").ToString <> 0 Then
                                    gpbCiego.Visible = True
                                    txtCalculo.Text = FormatNumber(rd2(0).ToString, 2)
                                    txtDiferencia.Text = FormatNumber(rd2(1).ToString, 2)
                                    txtEnCaja.Text = FormatNumber(rd2(2).ToString, 2)
                                End If
                            End If
                        End If
                        rd2.Close() : cnn2.Close()
                    End If
                End If
            Else
                txtSaldoUsuario.Text = "0.00"
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        Dim usu_alias As String = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtContrasena.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        usu_alias = rd1("Alias").ToString
                        If usu_alias = cboUsuario.Text Then
                            txtSaldoUsuario.Focus().Equals(True)
                        Else
                            MsgBox("Contraseña incorrecta.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                            txtContrasena.SelectAll()
                        End If
                    End If
                Else
                    MsgBox("No se encuentra un usuario registrado bajo esta contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                    txtContrasena.SelectAll()
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        grdEgresos.Rows.Clear()
        grdIngresos.Rows.Clear()

        Dim Contra As Boolean = False
        Dim Usu As String = cboUsuario.Text

        If cboUsuario.Text = "" Then MsgBox("Selecciona un ususario para calcular su corte.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") : cboUsuario.Focus.Equals(True) : Exit Sub
        If txtContrasena.Text = "" Then MsgBox("Ingrese su contraseña por favor.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") : txtContrasena.Focus() : Exit Sub

        Try

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Saldo_Ini from CorteUsuario where Usuario='" & cboUsuario.Text & "' and NumCorte=" & txtNumCorte.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then

            Else
                MsgBox("Primero guarda el registro de saldo inicial.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                txtSaldoUsuario.Focus().Equals(True)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()

            If TipoCorte() = 1 Then
                If Calculo = False Then
                    If gpbCiego.Visible = False And CDec(txtCalculo.Text) = 0 Then
                        MsgBox("Para continuar realice el cálculo de su efectivo en caja.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
                        gbxCalculo.Visible = True
                        txtCant500.Focus()
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                Else
                End If
            End If

            'Aquí ya comienza a calcular los datos del corte
            cnn1.Close() : cnn1.Open()
            'Ventas
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Abono) from AbonoI where Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' AND Usuario='" & Usu & "' AND Fecha BETWEEN '" & Format(dtpFechaIU.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFU.Value, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpHoraIU.Value, "HH:mm:ss") & "' AND '" & Format(dtpHoraFU.Value, "HH:mm:ss") & "' AND CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtVentasU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                    txtVentasU.Text = FormatNumber(txtVentasU.Text, 2)
                End If
            End If
            rd1.Close()

            'Cobro a empleados
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select SUM(Monto) from SaldosEmpleados where Usuario='" & Usu & "' AND Fecha BETWEEN '" & Format(dtpFechaIU.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpFechaFU.Value, "yyyy-MM-dd") & "' and CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCobroEmpU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                    txtCobroEmpU.Text = FormatNumber(txtCobroEmpU.Text, 2)
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class