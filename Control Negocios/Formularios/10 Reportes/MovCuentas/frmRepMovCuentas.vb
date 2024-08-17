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
            Dim cliente As String = ""

            Dim fechan As String = ""


            If (rbTodos.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta,Cliente FROM movcuenta WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Hora BETWEEN '" & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "HH:mm:ss") & "'"
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
                        cliente = rd1("Cliente").ToString

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
                                            cliente,
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If grdCaptura.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Application.ActiveSheet

            'exHoja.Columns("A").NumberFormat = "@"
            'exHoja.Columns("B").NumberFormat = "@"
            'exHoja.Columns("C").NumberFormat = "@"
            'exHoja.Columns("D").NumberFormat = "@"
            'exHoja.Columns("I").NumberFormat = "@"
            'exHoja.Columns("G").NumberFormat = "@"
            'exHoja.Columns("K").NumberFormat = "@"

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = grdCaptura.ColumnCount
            Dim NRow As Integer = grdCaptura.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = grdCaptura.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdCaptura.Rows(Fila).Cells(Col).Value.ToString

                Next
            Next

            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
        End Try
    End Sub
End Class