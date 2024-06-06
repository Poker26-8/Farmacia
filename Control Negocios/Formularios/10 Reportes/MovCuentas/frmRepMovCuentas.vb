Public Class frmRepMovCuentas
    Private Sub frmRepMovCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdCaptura.Rows.Clear()
        mcdesde.SetDate(Now)
        mchasta.SetDate(Now)
        dtpinicio.Text = "00:00:00"
        dtpFin.Text = "23:59:59"

        rbTodos.Checked = True
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            grdCaptura.Rows.Clear()
            Dim m1 As Date = mcdesde.SelectionStart.ToShortDateString
            Dim m2 As Date = mchasta.SelectionStart.ToShortDateString

            Dim formapago As String = ""
            Dim banco As String = ""
            Dim referencia As String = ""
            Dim concepto As String = ""
            Dim total As Double = 0
            Dim retiro As Double = 0
            Dim deposito As Double = 0
            Dim saldo As Double = 0
            Dim fecha As Date = Nothing
            Dim hora As String = Nothing
            Dim folio As String = ""
            Dim comentario As String = ""
            Dim cunta As String = ""
            Dim bancoc As String = ""

            Dim fechan As String = ""


            If (rbTodos.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM movcuenta WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "HH:mm:ss") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        formapago = rd1("Tipo").ToString
                        banco = rd1("Banco").ToString
                        referencia = rd1("Referencia").ToString
                        concepto = rd1("Concepto").ToString
                        total = rd1("Total").ToString
                        retiro = rd1("Retiro").ToString
                        deposito = rd1("Deposito").ToString
                        saldo = rd1("Saldo").ToString
                        fecha = rd1("Fecha").ToString
                        hora = rd1("Hora").ToString
                        folio = rd1("Folio").ToString
                        comentario = rd1("Comentario").ToString
                        cunta = rd1("Cuenta").ToString
                        bancoc = rd1("BancoCuenta").ToString
                        fechan = Format(fecha, "yyyy-MM-dd")

                        grdCaptura.Rows.Add(formapago,
                                            banco,
                                            referencia,
                                            concepto,
                                            FormatNumber(total, 2),
                                            FormatNumber(retiro, 2),
                                            FormatNumber(deposito, 2),
                                            FormatNumber(saldo, 2),
                                            fechan,
                                            hora,
                                            folio,
                                            comentario,
                                            cunta,
                                            bancoc)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdCaptura.Rows.Clear()
    End Sub
End Class