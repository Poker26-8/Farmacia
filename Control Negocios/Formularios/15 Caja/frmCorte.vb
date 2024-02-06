Imports System.Drawing.Printing
Imports System.IO
Imports System.Net

Public Class frmCorte

    Dim usuario As String = ""
    Dim id_usu As Integer = 0

    Dim CorteGlobal As Boolean = False
    Dim Cierre As Boolean = False
    Dim Calculo As Boolean = False

    Private Sub txtSaldoGlobal_Click(sender As System.Object, e As System.EventArgs) Handles txtSaldoGlobal.Click
        txtSaldoGlobal.SelectionStart = 0
        txtSaldoGlobal.SelectionLength = Len(txtSaldoGlobal.Text)
    End Sub

    Private Sub txtSaldoGlobal_GotFocus(sender As Object, e As System.EventArgs) Handles txtSaldoGlobal.GotFocus
        txtSaldoGlobal.SelectionStart = 0
        txtSaldoGlobal.SelectionLength = Len(txtSaldoGlobal.Text)
    End Sub

    Private Sub txtSaldoGlobal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSaldoGlobal.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Not IsNumeric(txtSaldoGlobal.Text) Then txtSaldoGlobal.Text = "0" : Exit Sub
            txtSaldoGlobal.Text = FormatNumber(txtSaldoGlobal.Text, 2)
            btnSaldoGlobal.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnSaldoGlobal_Click(sender As System.Object, e As System.EventArgs) Handles btnSaldoGlobal.Click
        Dim saldo_global As Double = txtSaldoGlobal.Text
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from CorteCaja where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.HasRows Then
                    txtSaldoGlobal.Text = FormatNumber(rd1("Saldo_Ini").ToString(), 2)
                    MsgBox("Ya cuentas con un saldo inicial registrado para el día " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate), vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                    btnCalcularGlobal.Focus().Equals(True)
                End If
            Else
                If MsgBox("¿Deseas registrar el saldo inicial para el día de hoy " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate) & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into CorteCaja(NumCorte,Saldo_Ini,Fecha,Saldo_Fin) values(0," & saldo_global & ",'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "',0)"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Saldo inicial registrado para el día " & FormatDateTime(dtpFecha.Value, DateFormat.ShortDate), vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                    cnn2.Close()
                Else
                    txtSaldoGlobal.Focus().Equals(True)
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmCorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now

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
            cmd1.CommandText =
                "select * from CorteCaja where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
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

    Private Sub btnLimpiarGlobal_Click(sender As Object, e As EventArgs) Handles btnLimpiarGlobal.Click
        dtpFecha.Value = Date.Now
        txtSaldoGlobal.Text = "0.00"
        'Ingresos
        txtVentasG.Text = "0.00"
        txtComprasCanceG.Text = "0.00"
        txtCobroEmpG.Text = "0.00"
        txtIngresosGlobal.Text = "0.00"
        txtIngEfectivoG.Text = "0.00"
        txtIngTarjetaG.Text = "0.00"
        txtIngTransfeG.Text = "0.00"
        txtIngDepositoG.Text = "0.00"
        txtIngMonederoG.Text = "0.00"
        'Egresos
        txtComprasG.Text = "0.00"
        txtPrestamoEmpG.Text = "0.00"
        txtNominaG.Text = "0.00"
        txtTransporteG.Text = "0.00"
        txtOtrosGastosG.Text = "0.00"
        txtCanceDevoG.Text = "0.00"
        txtEgresosGlobal.Text = "0.00"
        txtEgrEfectivoG.Text = "0.00"
        txtEgrTarjetaG.Text = "0.00"
        txtEgrTransfeG.Text = "0.00"
        txtEgrDepositoG.Text = "0.00"
        txtEgrMonederoG.Text = "0.00"

        'Finales
        txtSaldoFinalG.Text = "0.00"
        EfectivoCajaG.Text = "0.00"
        TarjetaCajaG.Text = "0.00"
        TranfeCajaG.Text = "0.00"
        MonederoCajaG.Text = "0.00"
        DepositoCajaG.Text = "0.00"
        C_Global()
        CorteGlobal = False
    End Sub

    Private Sub btnCalcularGlobal_Click(sender As Object, e As EventArgs) Handles btnCalcularGlobal.Click
        If CorteGlobal = True Then
            Exit Sub
        End If

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Saldo_Ini from CorteCaja where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
            Else
                MsgBox("Necesitas registrar un saldo inicial para generar el reporte.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtSaldoGlobal.Focus().Equals(True)
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        Try
            cnn1.Close() : cnn1.Open()

            ' Abonos
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select sum(Abono) from AbonoI where Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
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


            'Compras canceladas
            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select sum(MontoEfecCanc) from Compras where FCancela=#" & Format(dtpFecha.Value, "MM/dd/yyyy") & "#"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        txtComprasCanceG.Text = rd1(0).ToString
            '        If txtComprasCanceG.Text = "" Then
            '            txtComprasCanceG.Text = "0.00"
            '        End If
            '        txtComprasCanceG.Text = FormatNumber(txtComprasCanceG.Text, 2)
            '    End If
            'End If
            'rd1.Close()

            'Cobro a empleados
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select sum(Monto) from SaldosEmpleados where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' and Concepto='COBRO'"
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
                "select sum(Efectivo) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString))
                End If
            End If
            rd1.Close()



            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select sum(MontoEfecCanc) from Compras where FCancela=#" & Format(dtpFecha.Value, "MM/dd/yyyy") & "#"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        Efectivo = CDec(Efectivo) + CDec(IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString))
            '    End If
            'End If
            'rd1.Close()

            txtIngEfectivoG.Text = FormatNumber(Efectivo, 2)

            'Monedero
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select sum(Monedero) from AbonoI where Concepto<>'CARGO' and Concepto<>'NOTA CANCELADA' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtIngMonederoG.Text = IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString)
                    txtIngMonederoG.Text = FormatNumber(txtIngMonederoG.Text, 2)
                End If
            End If
            rd1.Close()


            'Trajeta
            cmd1.CommandText = "select sum(Tarjeta) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtIngTarjetaG.Text = IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString)
                txtIngTarjetaG.Text = FormatNumber(txtIngTarjetaG.Text, 2)
            End If
            rd1.Close()


            'Deposito
            cmd1.CommandText = "select sum(Otro) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtIngDepositoG.Text = IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString)
                txtIngDepositoG.Text = FormatNumber(txtIngDepositoG.Text, 2)
            End If
            rd1.Close()


            'Transferencia
            cmd1.CommandText = "select sum(Transfe) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtIngTransfeG.Text = IIf(rd1(0).ToString = "", "0.00", rd1(0).ToString)
                    txtIngTransfeG.Text = FormatNumber(txtIngTransfeG.Text, 2)
                End If
            End If
            rd1.Close()
            'cnn1.Close()

            Dim Ingresos As String = "0"
            Ingresos = CDec(txtIngEfectivoG.Text) + CDec(txtIngTarjetaG.Text) + CDec(txtIngTransfeG.Text) + CDec(txtIngDepositoG.Text) + CDec(txtIngMonederoG.Text)
            txtIngresosGlobal.Text = FormatNumber(Ingresos, 2)
            My.Application.DoEvents()

            cnn2.Close() : cnn2.Open()
            'Compras
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Abono) from AbonoE where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' and Abono<>0"
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
            cmd2.CommandText =
                "select sum(Monto) from SaldosEmpleados where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
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
            cmd2.CommandText =
                "select sum(SueldoNeto) from Nomina where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtNominaG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtNominaG.Text = FormatNumber(txtNominaG.Text, 2)
                End If
            End If
            rd2.Close()

            ''Transporte
            'cmd2 = cnn2.CreateCommand
            'cmd2.CommandText =
            '    "select sum(Total) from OtrosGastos where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            'rd2 = cmd2.ExecuteReader
            'If rd2.HasRows Then
            '    If rd2.Read Then
            '        txtTransporteG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
            '        txtTransporteG.Text = FormatNumber(txtTransporteG.Text, 2)
            '    End If
            'End If
            'rd2.Close()


            'Otros gastos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Total) from OtrosGastos where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtOtrosGastosG.Text = IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    txtOtrosGastosG.Text = FormatNumber(txtOtrosGastosG.Text, 2)
                End If
            End If
            rd2.Close()

            '---Egresos

            Dim CanceDevo As String = "0"
            Dim EgrEfectivo As String = "0"
            'Efectivo
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Efectivo) from AbonoI where Concepto='DEVOLUCION' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()



            'cmd2 = cnn2.CreateCommand
            'cmd2.CommandText =
            '    "select sum(Efectivo) from AbonoI where Concepto<>'ABONO' and Concepto<>'DEVOLUCION' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            'rd2 = cmd2.ExecuteReader
            'If rd2.HasRows Then
            '    If rd2.Read Then
            '        EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
            '        CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
            '    End If
            'End If
            'rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Efectivo) from Abonoi where Concepto<>'ABONO' and Concepto<>'DEVOLUCION' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Efectivo) from OtrosGastos where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Efectivo) from AbonoE where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(SueldoNeto) from Nomina where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrEfectivo = CDec(EgrEfectivo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()
            txtEgrEfectivoG.Text = FormatNumber(EgrEfectivo, 2)


            Dim EgrTarjeta As String = "0"
            Dim EgrTran As String = "0"

            'Tarjeta
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                        "select sum(Tarjeta) from AbonoI where Concepto<>'ABONO' and Concepto<>'DEVOLUCION'and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrTarjeta = CDec(EgrTarjeta) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

                    'Transferencia
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                "select sum(Transfe) from AbonoI where Concepto<>'ABONO' and Concepto<>'DEVOLUCION'and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            EgrTran = CDec(EgrTran) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()


                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Tarjeta) from AbonoI where Concepto<>'ABONO' and Concepto<>'NOTA CANCELADA'and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            EgrTarjeta = CDec(EgrTarjeta) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()


                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select sum(Transfe) from AbonoI where Concepto<>'ABONO' and Concepto<>'NOTA CANCELADA'and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            EgrTran = CDec(EgrTran) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Tarjeta) from AbonoE where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrTarjeta = CDec(EgrTarjeta) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            txtEgrTarjetaG.Text = FormatNumber(EgrTarjeta, 2)

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Transfe) from AbonoE where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrTran = CDec(EgrTran) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            txtEgrTransfeG.Text = FormatNumber(EgrTran, 2)


            Dim EgrOtro As Double = 0
            'Deposito
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Otro) from Abonoi where Concepto<>'ABONO' and Concepto<>'CARGO' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrOtro = EgrOtro + IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString)
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select sum(Otro) from AbonoE where Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    EgrOtro = CDec(EgrOtro) + CDec(IIf(rd2(0).ToString = "", "0.00", rd2(0).ToString))
                End If
            End If
            rd2.Close()
            cnn2.Close()

            txtEgrDepositoG.Text = FormatNumber(EgrOtro, 2)
            txtCanceDevoG.Text = FormatNumber(CanceDevo, 2)

            Dim Egresos As String = "0"
            Egresos = CDec(txtEgrEfectivoG.Text) + CDec(txtEgrTarjetaG.Text) + CDec(txtEgrTransfeG.Text) + CDec(txtEgrDepositoG.Text) + CDec(txtEgrMonederoG.Text)
            txtEgresosGlobal.Text = FormatNumber(Egresos, 2)
            My.Application.DoEvents()

            'Saldo final
            txtSaldoFinalG.Text = (CDec(txtSaldoGlobal.Text) + CDec(txtIngresosGlobal.Text)) - CDec(txtEgresosGlobal.Text)
            txtSaldoFinalG.Text = FormatNumber(txtSaldoFinalG.Text, 2)

            'Efectivo en caja
            EfectivoCajaG.Text = (CDec(txtSaldoGlobal.Text) + CDec(txtIngEfectivoG.Text)) - CDec(txtEgrEfectivoG.Text)
            EfectivoCajaG.Text = FormatNumber(EfectivoCajaG.Text, 2)

            'Tarjetas en caja
            TarjetaCajaG.Text = CDec(txtIngTarjetaG.Text) - CDec(txtEgrTarjetaG.Text)
            TarjetaCajaG.Text = FormatNumber(TarjetaCajaG.Text, 2)

            'Transfe en caja
            TranfeCajaG.Text = CDec(txtIngTransfeG.Text) - CDec(txtEgrTransfeG.Text)
            TranfeCajaG.Text = FormatNumber(TranfeCajaG.Text, 2)

            'Monedero en caja
            MonederoCajaG.Text = CDec(txtIngMonederoG.Text) - CDec(txtEgrMonederoG.Text)
            MonederoCajaG.Text = FormatNumber(MonederoCajaG.Text, 2)

            'Deposito en caja
            DepositoCajaG.Text = CDec(txtIngDepositoG.Text) - CDec(txtEgrDepositoG.Text)
            DepositoCajaG.Text = FormatNumber(DepositoCajaG.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
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

        If MsgBox("¿Deseas imprimir el cálculo del corte de caja?", vbInformation + vbOKCancel, "Delsscom Control Negocios 2022") = vbOK Then
            Dim tam_impre As String = IIf(DatosRecarga("TamImpre") = "", "80", DatosRecarga("TamImpre"))

            If tam_impre = "80" Then
                pCalculoGlobal80.Print()
            Else
                pCalculoGlobal58.Print()
            End If
            CorteGlobal = True
        End If
    End Sub

    Private Sub cboUsuario_DropDown(sender As Object, e As EventArgs) Handles cboUsuario.DropDown
        cboUsuario.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Usuario from Abonoi where CorteU=0 and Usuario<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboUsuario.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
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
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboUsuario.KeyPress
        Dim usu_alias As String = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtContrasena.Text & "'"
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

    Private Sub txtSaldoUsuario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSaldoUsuario.KeyPress
        If Not IsNumeric(txtSaldoUsuario.Text) Then txtSaldoUsuario.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            btnSaldoUsuario.Focus().Equals(True)
            txtSaldoUsuario.Text = FormatNumber(txtSaldoUsuario.Text, 2)
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

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
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
                txtSaldoGlobal.Focus().Equals(True)
                rd1.Close() : cnn1.Close()
                Exit Sub
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

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

        Try
            'Aquí ya comienza a calcular los datos del corte
            cnn1.Close() : cnn1.Open()

            '----------[Ingresos]
            'Ventas
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Abono) from AbonoI where Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' and Usuario='" & Usu & "' and CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtVentasU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                    txtVentasU.Text = FormatNumber(txtVentasU.Text, 2)
                End If
            End If
            rd1.Close()

            ''Compras canceladas
            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select sum(MontoEfecCanc) from Compras where CorteU=0 and Usuario='" & Usu & "'"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        txtComprasCanceU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
            '        txtComprasCanceU.Text = FormatNumber(txtComprasCanceU.Text, 2)
            '    End If
            'End If
            'rd1.Close()

            'Cobro a empleados
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Monto) from SaldosEmpleados where Usuario='" & Usu & "' and CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCobroEmpU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                    txtCobroEmpU.Text = FormatNumber(txtCobroEmpU.Text, 2)
                End If
            End If
            rd1.Close()

            'Efectivo
            Dim EfectivoU As String = "0"
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Monto) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Usuario='" & Usu & "' and CorteU=0 AND FormaPago='EFECTIVO'"
            '"select SUM(Efectivo) from AbonoI where Concepto<>'DEVOLUCION' and Concepto<>'NOTA CANCELADA' and Usuario='" & Usu & "' and CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Dim Efec As String = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                    EfectivoU = CDec(EfectivoU) + CDec(Efec)
                End If
            End If
            rd1.Close()

            'cmd1 = cnn1.CreateCommand
            'cmd1.CommandText =
            '    "select SUM(MontoEfecCanc) from Compras where Usuario='" & Usu & "' and CorteU=0"
            'rd1 = cmd1.ExecuteReader
            'If rd1.HasRows Then
            '    If rd1.Read Then
            '        EfectivoU = CDec(EfectivoU) + CDec(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
            '    End If
            'End If
            'rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select SUM(Monto) from SaldosEmpleados where Usuario='" & Usu & "' and CorteU=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    EfectivoU = CDec(EfectivoU) + CDec(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                End If
            End If
            rd1.Close()

            txtIngEfectivoU.Text = FormatNumber(EfectivoU, 2)



            'Monedero
            cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select SUM(Monedero) from AbonoI where Monedero<>0 and Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' and Usuario='" & Usu & "' and CorteU=0"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtIngMonederoU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                            txtIngMonederoU.Text = FormatNumber(txtIngMonederoU.Text, 2)
                        End If
                    End If
                    rd1.Close()

                    'Tarjeta
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select SUM(Tarjeta) from AbonoI where Tarjeta<>0 and Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' and Usuario='" & Usu & "' and CorteU=0"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtIngTarjetaU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                            txtIngTarjetaU.Text = FormatNumber(txtIngTarjetaU.Text, 2)
                        End If
                    End If
                    rd1.Close()

                    'Transferencia
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select sum(Transfe) from AbonoI where Transfe<>0 and Concepto <> 'NOTA CANCELADA' and Concepto <> 'DEVOLUCION' and Usuario='" & Usu & "' and CorteU=0"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtIngTransfeU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                            txtIngTransfeU.Text = FormatNumber(txtIngTransfeU.Text, 2)
                        End If
                    End If
                    rd1.Close()

                    'Deposito
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select SUM(Otro) from AbonoI where Otro<>0 and Concepto<>'NOTA CANCELADA' and Concepto<>'DEVOLUCION' and Usuario='" & Usu & "'and CorteU=0"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtIngDepositoU.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                            txtIngDepositoU.Text = FormatNumber(txtIngDepositoU.Text, 2)
                        End If
                    End If
                    rd1.Close()

            cnn3.Close()
            cnn1.Close()
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Dim IngresosU As String = ""
        IngresosU = CDec(txtIngEfectivoU.Text) + CDec(txtIngTarjetaU.Text) + CDec(txtIngTransfeU.Text) + CDec(txtIngMonederoU.Text) + CDec(txtIngDepositoU.Text)
        txtIngresosUsuario.Text = FormatNumber(IngresosU, 2)

        Try
            cnn2.Close()
            cnn2.Open()

            '-------[Egresos]
            'Compras
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Efectivo) from AbonoE where Usuario='" & Usu & "' and Abono<>0 and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtComprasU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                    txtComprasU.Text = FormatNumber(txtComprasU.Text, 2)
                End If
            End If
            rd2.Close()

            'Prestamo empleados
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Monto) from SaldosEmpleados where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtPresEmpU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                    txtPresEmpU.Text = FormatNumber(txtPresEmpU.Text, 2)
                End If
            End If
            rd2.Close()

            'Nómina
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(SueldoNeto) from Nomina where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtNominaU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                    txtNominaU.Text = FormatNumber(txtNominaU.Text, 2)
                End If
            End If
            rd2.Close()

            ''Transporte
            'cmd2 = cnn2.CreateCommand
            'cmd2.CommandText =
            '        "select SUM(Total) from OtrosGastos where Usuario='" & Usu & "' and TipoGasto='TRANSPORTE' and CorteU=0"
            'rd2 = cmd2.ExecuteReader
            'If rd2.HasRows Then
            '    If rd2.Read Then
            '        txtTransporteU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
            '        txtTransporteU.Text = FormatNumber(txtTransporteU.Text, 2)
            '    End If
            'End If
            'rd2.Close()

            'Otros gastos
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Total) from OtrosGastos where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    txtOtrosGastosU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                    txtOtrosGastosU.Text = FormatNumber(txtOtrosGastosU.Text, 2)
                End If
            End If
            rd2.Close()

            'Efectivo
            Dim CanceDevo As String = "0"
            Dim Efectivo As String = "0"

            'Devoluciones
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Efectivo) from AbonoI where Concepto<>'ABONO' and Concepto<>'NOTA VENTA' and Concepto<>'NOTA CANCELADA' and Concepto<>'CARGO' and Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            'Cancelaciones
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Efectivo) from AbonoI where Concepto<>'ABONO' and Concepto<>'NOTA VENTA' and Concepto<>'DEVOLUCION' and Concepto<>'CARGO' and Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                    CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Efectivo) from AbonoE where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(SueldoNeto) from Nomina where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Efectivo) from OtrosGastos where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Efectivo = CDec(Efectivo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                End If
            End If
            rd2.Close()

            txtEgrEfectivoU.Text = FormatNumber(Efectivo, 2)


            Dim Tarjeta As Double = 0
            Dim Transfe As Double = 0
            Dim Otros As Double = 0


            'Tarjeta
            cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(Tarjeta) from AbonoI where Tarjeta<>0 and Concepto<>'ABONO' and Concepto<>'CARGO' and Concepto<>'NOTA VENTA' and Usuario='" & Usu & "' and CorteU=0"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            Tarjeta = Tarjeta + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()

                    'Transferencia
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(Transfe) from AbonoI where Transfe<>0 and Concepto<>'ABONO' and Concepto<>'CARGO' and Concepto<>'NOTA VENTA' and Usuario='" & Usu & "' and CorteU=0"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            Transfe = Transfe + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()

                    'Monedero
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(Monedero) from AbonoI where Monedero<>0 and Concepto<>'ABONO' and Concepto<>'CARGO' and Concepto<>'NOTA VENTA' and Usuario='" & Usu & "' and CorteU=0"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtEgrMonederoU.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                            txtEgrMonederoU.Text = FormatNumber(txtEgrMonederoU.Text, 2)
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()

                    'Deposito
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                            "select SUM(Otro) from AbonoI where Otro<>0 and Concepto<>'ABONO' and Concepto<>'CARGO' and Concepto<>'NOTA VENTA' and Usuario='" & Usu & "' and CorteU=0"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            Otros = Otros + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                            CanceDevo = CDec(CanceDevo) + CDec(IIf(rd2(0).ToString = "", "0", rd2(0).ToString))
                        End If
                    End If
                    rd2.Close()



            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Tarjeta) from AbonoE where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Tarjeta = Tarjeta + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Tarjeta) from OtrosGastos where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Tarjeta = Tarjeta + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                End If
            End If
            rd2.Close()
            txtEgrTarjetaU.Text = FormatNumber(Tarjeta, 2)


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Transfe) from AbonoE where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Transfe = Transfe + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Transfe) from OtrosGastos where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Transfe = Transfe + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                End If
            End If
            rd2.Close()
            txtEgrTransfeU.Text = FormatNumber(Transfe, 2)



            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                    "select SUM(Otro) from AbonoE where Usuario='" & Usu & "' and CorteU=0"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Otros = Otros + IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                End If
            End If
            rd2.Close()
            txtEgrDepositoU.Text = FormatNumber(Otros, 2)

            cnn2.Close()

            Dim Egresos As String = ""
            Egresos = CDec(txtEgrEfectivoU.Text) + CDec(txtEgrTarjetaU.Text) + CDec(txtEgrTransfeU.Text) + CDec(txtEgrDepositoU.Text) + CDec(txtEgrMonederoU.Text)
            txtEgresosUsuario.Text = FormatNumber(Egresos, 2)
            txtCanceDevoU.Text = FormatNumber(CanceDevo, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

        If TipoCorte() = 1 Then
            Dim EnCaja As String = "0"
            Dim Dife As String = "0"

            EnCaja = (CDec(txtSaldoUsuario.Text) + CDec(txtIngEfectivoU.Text)) - CDec(txtEgrEfectivoU.Text)
            txtEnCaja.Text = FormatNumber(EnCaja, 2)
            Dife = CDec(txtCalculo.Text) - CDec(txtEnCaja.Text)

            If Dife < 0 Then
                txtDiferencia.Text = FormatNumber(Dife, 2)
            Else
                txtDiferencia.Text = FormatNumber(Dife, 2)
            End If
        End If

        txtSaldoFinalU.Text = (CDec(txtSaldoUsuario.Text) + CDec(txtIngresosUsuario.Text)) - CDec(txtEgresosUsuario.Text)
        txtSaldoFinalU.Text = FormatNumber(txtSaldoFinalU.Text, 2)

        txtEfectivoCajaU.Text = (CDec(txtSaldoUsuario.Text) + CDec(txtIngEfectivoU.Text)) - CDec(txtEgrEfectivoU.Text)
        txtEfectivoCajaU.Text = FormatNumber(txtEfectivoCajaU.Text, 2)

        txtTrajetasU.Text = CDec(txtIngTarjetaU.Text) - CDec(txtEgrTarjetaU.Text)
        txtTrajetasU.Text = FormatNumber(txtTrajetasU.Text, 2)

        txtTransferU.Text = CDec(txtIngTransfeU.Text) - CDec(txtEgrTransfeU.Text)
        txtTransferU.Text = FormatNumber(txtTransferU.Text, 2)

        txtDepositosU.Text = CDec(txtIngDepositoU.Text) - CDec(txtEgrDepositoU.Text)
        txtDepositosU.Text = FormatNumber(txtDepositosU.Text, 2)

        txtMonederosU.Text = CDec(txtIngMonederoU.Text) - CDec(txtEgrMonederoU.Text)
        txtMonederosU.Text = FormatNumber(txtMonederosU.Text, 2)


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
        If MsgBox("¿Deseas imprimir el reporte de caja del usuario " & cboUsuario.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim tam_impre As String = DatosRecarga("TamImpre")

            If tam_impre = "80" Then
                pCalculoUsuario80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pCalculoUsuario80.Print()
            Else
                pCalculoUsuario58.Print()
            End If
        End If
        cnn1.Close()
        cnn2.Close()
        cnn3.Close()
    End Sub

    'Quinientos
    Private Sub txtCant500_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant500.GotFocus
        txtCant500.SelectAll()
    End Sub

    Private Sub txtCant500_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant500.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant500.Text = "" Then txtCant500.Text = "0"
            txtCant200.Focus()
        End If
    End Sub

    Private Sub txtCant500_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant500.TextChanged
        If txtCant500.Text = "" Then
            txtCant500.Text = "0"
        End If
        txtTotal500.Text = CDec(txtCant500.Text) * 500
        txtTotal500.Text = FormatNumber(txtTotal500.Text, 2)
    End Sub

    Private Sub txtTotal500_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal500.TextChanged
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

    'Doscientos
    Private Sub txtCant200_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant200.GotFocus
        txtCant200.SelectAll()
    End Sub

    Private Sub txtCant200_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant200.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant200.Text = "" Then txtCant200.Text = "0"
            txtCant100.Focus()
        End If
    End Sub

    Private Sub txtCant200_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant200.TextChanged
        If txtCant200.Text = "" Then
            txtCant200.Text = "0"
        End If
        txtTotal200.Text = CDec(txtCant200.Text) * 200
        txtTotal200.Text = FormatNumber(txtTotal200.Text, 2)
    End Sub

    Private Sub txtTotal200_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal200.TextChanged
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

    'Cien
    Private Sub txtCant100_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant100.GotFocus
        txtCant100.SelectAll()
    End Sub

    Private Sub txtCant100_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant100.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtCant100.Text = "" Then txtCant100.Text = "0"
            txtCant50.Focus()
        End If
    End Sub

    Private Sub txtCant100_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant100.TextChanged
        If txtCant100.Text = "" Then
            txtCant100.Text = "0"
        End If
        txtTotal100.Text = CDec(txtCant100.Text) * 100
        txtTotal100.Text = FormatNumber(txtTotal100.Text, 2)
    End Sub

    Private Sub txtTotal100_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal100.TextChanged
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


    'Cincuenta
    Private Sub txtCant50_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant50.GotFocus
        txtCant50.SelectAll()
    End Sub

    Private Sub txtCant50_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant50.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant50.Text = "" Then txtCant50.Text = "0"
            txtCant20.Focus()
        End If
    End Sub

    Private Sub txtCant50_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant50.TextChanged
        If txtCant50.Text = "" Then
            txtCant50.Text = "0"
        End If
        txtTotal50.Text = CDec(txtCant50.Text) * 50
        txtTotal50.Text = FormatNumber(txtTotal50.Text, 2)
    End Sub

    Private Sub txtTotal50_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal50.TextChanged
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

    'Veinte
    Private Sub txtCant20_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant20.GotFocus
        txtCant20.SelectAll()
    End Sub

    Private Sub txtCant20_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant20.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant20.Text = "" Then txtCant20.Text = "0"
            txtCant10.Focus()
        End If
    End Sub

    Private Sub txtCant20_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant20.TextChanged
        If txtCant20.Text = "" Then
            txtCant20.Text = "0"
        End If
        txtTotal20.Text = CDec(txtCant20.Text) * 20
        txtTotal20.Text = FormatNumber(txtTotal20.Text, 2)
    End Sub

    Private Sub txtTotal20_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal20.TextChanged
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

    'Diez
    Private Sub txtCant10_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant10.GotFocus
        txtCant5.SelectAll()
    End Sub

    Private Sub txtCant10_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant10.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant10.Text = "" Then txtCant10.Text = "0"
            txtCant5.Focus()
        End If
    End Sub

    Private Sub txtCant10_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant10.TextChanged
        If txtCant10.Text = "" Then
            txtCant10.Text = "0"
        End If
        txtTotal10.Text = CDec(txtCant10.Text) * 10
        txtTotal10.Text = FormatNumber(txtTotal10.Text, 2)
    End Sub

    Private Sub txtTotal10_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal10.TextChanged
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

    'Cinco
    Private Sub txtCant5_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant5.GotFocus
        txtCant5.SelectAll()
    End Sub

    Private Sub txtCant5_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant5.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant5.Text = "" Then txtCant5.Text = "0"
            txtCant2.Focus()
        End If
    End Sub

    Private Sub txtCant5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant5.TextChanged
        If txtCant5.Text = "" Then
            txtCant5.Text = "0"
        End If
        txtTotal5.Text = CDec(txtCant5.Text) * 5
        txtTotal5.Text = FormatNumber(txtTotal5.Text, 2)
    End Sub

    Private Sub txtTotal5_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal5.TextChanged
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

    'Dos
    Private Sub txtCant2_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant2.GotFocus
        txtCant2.SelectAll()
    End Sub

    Private Sub txtCant2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant2.Text = "" Then txtCant2.Text = "0"
            txtCant1.Focus()
        End If
    End Sub

    Private Sub txtCant2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant2.TextChanged
        If txtCant2.Text = "" Then
            txtCant2.Text = "0"
        End If
        txtTotal2.Text = CDec(txtCant2.Text) * 2
        txtTotal2.Text = FormatNumber(txtTotal2.Text, 2)
    End Sub

    Private Sub txtTotal2_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal2.TextChanged
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

    'Uno
    Private Sub txtCant1_GotFocus(sender As Object, e As System.EventArgs) Handles txtCant1.GotFocus
        txtCant1.SelectAll()
    End Sub

    Private Sub txtCant1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCant1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtCant1.Text = "" Then txtCant1.Text = "0"
            txtCantCentavos.Focus()
        End If
    End Sub

    Private Sub txtCant1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant1.TextChanged
        If txtCant1.Text = "" Then
            txtCant1.Text = "0"
        End If
        txtTotal1.Text = CDec(txtCant1.Text) * 1
        txtTotal1.Text = FormatNumber(txtTotal1.Text, 2)
    End Sub

    Private Sub txtTotal1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal1.TextChanged
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

    'Centavos
    Private Sub txtCantCentavos_GotFocus(sender As Object, e As System.EventArgs) Handles txtCantCentavos.GotFocus
        txtCantCentavos.SelectAll()
    End Sub

    Private Sub txtCantCentavos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantCentavos.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtCantCentavos.Text = "" Then txtCantCentavos.Text = "0"
            btnOKCalculo.Focus()
        End If
    End Sub

    Private Sub txtCantCentavos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCantCentavos.TextChanged
        If txtCantCentavos.Text = "" Then
            txtCantCentavos.Text = "0"
        End If
        txtTotalCentavos.Text = CDec(txtCantCentavos.Text) * 0.5
        txtTotalCentavos.Text = FormatNumber(txtTotalCentavos.Text, 2)
    End Sub

    Private Sub txtTotalCentavos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalCentavos.TextChanged
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

    Private Sub btnOKCalculo_Click(sender As Object, e As EventArgs) Handles btnOKCalculo.Click
        If CDec(txtTotalCalculo.Text) = 0 Then
            MsgBox("No ha ingresado un cálculo válido", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If

        If MsgBox("Su cálculo de efectivo en caja es de: $" & FormatNumber(txtTotalCalculo.Text, 2) & vbNewLine & "¿La cantidad es correcta? Esta acción no se puede deshacer.", vbInformation + vbOKCancel, "Delsscom Control Negocios 2022") = vbCancel Then
            txtTotalCalculo.Focus()
            txtTotalCalculo.SelectAll()
            Exit Sub
        Else
            Calculo = True
            txtCalculo.Text = txtTotalCalculo.Text
            gpbCiego.Visible = True
            gbxCalculo.Visible = False
            btnCalcular.PerformClick()
        End If
    End Sub

    Private Sub btnLimpiarUsuario_Click(sender As Object, e As EventArgs) Handles btnLimpiarUsuario.Click
        gpbCiego.Visible = False
        gpbCiego.Enabled = True
        txtEnCaja.Text = "0.00"
        txtCalculo.Text = "0.00"
        txtDiferencia.Text = "0.00"
        Calculo = False
        Cierre = False
        txtContrasena.Visible = True

        '-------------------------
        txtCant1.Text = "0"
        txtCantCentavos.Text = "0"
        txtCant2.Text = "0"
        txtCant5.Text = "0"
        txtCant10.Text = "0"
        txtCant20.Text = "0"
        txtCant50.Text = "0"
        txtCant100.Text = "0"
        txtCant200.Text = "0"
        txtCant500.Text = "0"

        '------------------------
        txtTotalCentavos.Text = "0.00"
        txtTotal1.Text = "0.00"
        txtTotal2.Text = "0.00"
        txtTotal5.Text = "0.00"
        txtTotal10.Text = "0.00"
        txtTotal20.Text = "0.00"
        txtTotal50.Text = "0.00"
        txtTotal100.Text = "0.00"
        txtTotal200.Text = "0.00"
        txtTotal500.Text = "0.00"

        '-------------------------
        cboUsuario.Text = ""
        txtContrasena.Text = ""
        txtNumCorte.Text = ""

        txtEfectivoCajaU.Text = "0.00"

        '-------------------------
        txtVentasU.Text = "0.00"
        txtComprasCanceU.Text = "0.00"
        txtCobroEmpU.Text = "0.00"

        txtIngresosUsuario.Text = "0.00"

        txtIngEfectivoU.Text = "0.00"
        txtIngTarjetaU.Text = "0.00"
        txtIngTransfeU.Text = "0.00"
        txtIngDepositoU.Text = "0.00"
        txtIngMonederoU.Text = "0.00"

        '-------------------------
        txtComprasU.Text = "0.00"
        txtPresEmpU.Text = "0.00"
        txtNominaU.Text = "0.00"
        txtTransporteU.Text = "0.00"
        txtOtrosGastosU.Text = "0.00"
        txtCanceDevoU.Text = "0.00"

        txtEgresosUsuario.Text = "0.00"

        txtEgrEfectivoU.Text = "0.00"
        txtEgrTarjetaU.Text = "0.00"
        txtEgrTransfeU.Text = "0.00"
        txtEgrMonederoU.Text = "0.00"
        txtEgrDepositoU.Text = "0.00"
        '-------------------------
        txtSaldoUsuario.Text = "0.00"
        txtEfectivoCajaU.Text = "0.00"
        txtTrajetasU.Text = "0.00"
        txtTransferU.Text = "0.00"
        txtDepositosU.Text = "0.00"
        txtMonederosU.Text = "0.00"

        txtSaldoFinalU.Text = "0.00"
    End Sub

    Private Sub txtContrasena_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContrasena.KeyPress
        Dim usu_alias As String = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtContrasena.Text & "'"
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

    Private Sub btnCierre_Click(sender As Object, e As EventArgs) Handles btnCierre.Click
        If Cierre = True Then
            MsgBox("Ya se ha realizado el cierre para éste usuario", vbInformation + vbOKOnly)
            Exit Sub
        End If
        If cboUsuario.Text = "" Then
            MsgBox("Seleccione un usuario para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If
        If txtNumCorte.Text = "" Then
            MsgBox("Procedimiento no valido.", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022")
            Exit Sub
        End If
        If MsgBox("¿Desea realizar un corte de caja para el usuario: " & cboUsuario.Text & "?", vbInformation + vbOKCancel, "Delsscom Control Negocios 2022") = vbCancel Then
            Exit Sub
        End If

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update AbonoI set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update Compras set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update SaldosEmpleados set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update AbonoE set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update Nomina set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                    "update OtrosGastos set CorteU=" & txtNumCorte.Text & " where CorteU=0 and Usuario='" & cboUsuario.Text & "'"
            cmd1.ExecuteNonQuery()

            If TipoCorte() = 1 Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "update CorteUsuario set Calculo=" & CDbl(txtCalculo.Text) & ", Diferencia=" & CDbl(txtDiferencia.Text) & ", Saldo_Fin=" & CDbl(txtEnCaja.Text) & " where NumCorte=" & txtNumCorte.Text & "and Usuario='" & cboUsuario.Text & "'"
                cmd1.ExecuteNonQuery()
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "update CorteCajaUsu set Calculo=0, EfeDife=0, Saldo_Fin=" & CDbl(txtEfectivoCajaU.Text) & " where NumCorte=" & txtNumCorte.Text & "and Usuario='" & cboUsuario.Text & "'"
                cmd1.ExecuteNonQuery()
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        If MsgBox("¿Deseas imprimir el cierre del usuario " & cboUsuario.Text & "?", vbInformation + vbOKOnly, "Delsscom Control Negocios 2022") = vbOK Then
            Dim tam_impre As String = DatosRecarga("TamImpre")

            If tam_impre = "80" Then
                pCierreUsuario80.Print()
            Else
                pCierreUsuario58.Print()
            End If
        Else
            Cierre = True
            Exit Sub
        End If
    End Sub

    Private Sub pCalculoGlobal80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCalculoGlobal80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
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
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CÁLCULO GLOBAL", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18

            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 23
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 20

            e.Graphics.DrawString("SALDO INICIAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoGlobal.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 28

            e.Graphics.DrawString("TOTAL DE INGRESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtIngresosGlobal.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngEfectivoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTarjetaG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TRANSFERE", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTransfeG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. DEPOSITOS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngDepositoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngMonederoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 34

            e.Graphics.DrawString("TOTAL DE EGRESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtEgresosGlobal.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrEfectivoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTarjetaG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TRANSFERE", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTransfeG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. DEPOSITOS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrDepositoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrMonederoG.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 34

            e.Graphics.DrawString("SALDO FINAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoFinalG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 21

            e.Graphics.DrawString("EFECTIVO EN CAJA", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(EfectivoCajaG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TarjetaCajaG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TRANSFERENCIAS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TranfeCajaG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(MonederoCajaG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO DEPÓSITOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(DepositoCajaG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Label3_DoubleClick(sender As Object, e As EventArgs) Handles Label3.DoubleClick
        pCalculoGlobal80.Print()
    End Sub

    Private Sub pCalculoUsuario80_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pCalculoUsuario80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
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
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("CÁLCULO USUARIO", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
            Y += 12
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Usuario: " & cboUsuario.Text, fuente_datos, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 23
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 20

            e.Graphics.DrawString("SALDO INICIAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoUsuario.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 28

            e.Graphics.DrawString("TOTAL DE INGRESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtIngresosUsuario.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngEfectivoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTarjetaU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TRANSFERE", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTransfeU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. DEPOSITOS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngDepositoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngMonederoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 34

            e.Graphics.DrawString("TOTAL DE EGRESOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtEgresosUsuario.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. EFECTIVO", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrEfectivoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTarjetaU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TRANSFERE", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTransfeU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. DEPOSITOS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrDepositoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrMonederoU.Text, 2), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 34

            e.Graphics.DrawString("SALDO FINAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoFinalU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 21

            e.Graphics.DrawString("EFECTIVO EN CAJA", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEfectivoCajaU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TARJETAS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtTrajetasU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TRANSFERENCIAS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtTransferU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO MONEDEROS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtMonederosU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO DEPÓSITOS", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtDepositosU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 285, Y, sf)
            Y += 15
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCalculoUsuario58_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pCalculoUsuario58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("CÁLCULO USUARIO", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Usuario: " & cboUsuario.Text, fuente_datos, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("SALDO INICIAL", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoUsuario.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString("TOTAL DE INGRESOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtIngresosUsuario.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. EFECTIVO", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngEfectivoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTarjetaU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TRANSFERE", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTransfeU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. DEPOSITOS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngDepositoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngMonederoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 20

            e.Graphics.DrawString("TOTAL DE EGRESOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtEgresosUsuario.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. EFECTIVO", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrEfectivoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTarjetaU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TRANSFERE", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTransfeU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. DEPOSITOS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrDepositoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrMonederoU.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 20

            e.Graphics.DrawString("SALDO FINAL", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoFinalU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("EFECTIVO EN CAJA", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEfectivoCajaU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtTrajetasU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TRANSFERENCIAS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtTransferU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtMonederosU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO DEPÓSITOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtDepositosU.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCierreUsuario80_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pCierreUsuario80.PrintPage

    End Sub

    Private Sub pCalculoGlobal58_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pCalculoGlobal58.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 7, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            '[°]. Logotipo
            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 120)
                    Y += 115
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 5, 160, 110)
                    Y += 90
                End If
            Else
                Y = 0
            End If

            '[°]. Datos del negocio
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Pie = rd1("Pie3").ToString
                    'Razón social
                    If rd1("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'RFC
                    If rd1("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd1("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Colonia
                    If rd1("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd1("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Teléfono
                    If rd1("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    'Correo
                    If rd1("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            rd1.Close() : cnn1.Close()

            '[1]. Datos de la venta
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 14
            e.Graphics.DrawString("CÁLCULO GLOBAL", New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
            Y += 7
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Fecha: " & FormatDateTime(Date.Now, DateFormat.ShortDate), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & FormatDateTime(Date.Now, DateFormat.LongTime), New Drawing.Font(tipografia, 6, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("SALDO INICIAL", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoGlobal.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString("TOTAL DE INGRESOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtIngresosGlobal.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. EFECTIVO", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngEfectivoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTarjetaG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. TRANSFERE", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngTransfeG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. DEPOSITOS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngDepositoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" ING. MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtIngMonederoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15

            e.Graphics.DrawString("TOTAL DE EGRESOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtEgresosGlobal.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. EFECTIVO", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrEfectivoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTarjetaG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. TRANSFERE", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrTransfeG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. DEPOSITOS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrDepositoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString(" EGR. MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtEgrMonederoG.Text, 2), fuente_prods, Brushes.Black, 180, Y, sf)
            Y += 34

            e.Graphics.DrawString("SALDO FINAL", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(txtSaldoFinalG.Text, 2), New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("EFECTIVO EN CAJA", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(EfectivoCajaG.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TARJETAS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TarjetaCajaG.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO TRANSFERENCIAS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(TranfeCajaG.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO MONEDEROS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(MonederoCajaG.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
            e.Graphics.DrawString("SALDO DEPÓSITOS", New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(DepositoCajaG.Text, 2), New Drawing.Font(tipografia, 7, FontStyle.Bold), Brushes.Black, 180, Y, sf)
            Y += 15
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub pCierreUsuario58_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pCierreUsuario58.PrintPage

    End Sub
End Class