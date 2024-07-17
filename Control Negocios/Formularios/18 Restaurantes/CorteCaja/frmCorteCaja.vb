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
            cmd1.CommandText = "SELECT sum(Abono) FROM AbonoI where Concepto='ABONO' AND FormaPago<>'SALDO A FAVOR' and Fecha='" & Format(dtpFecha.Value, "yyyy-MM-dd") & "' AND Status=0"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try

    End Sub
End Class