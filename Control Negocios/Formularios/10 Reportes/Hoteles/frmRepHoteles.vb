Public Class frmRepHoteles
    Private Sub frmRepHoteles_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        rbHabitacion.Checked = True
        grdCaptura.Rows.Clear()
        cboDatos.Text = ""
        dtpinicio.Text = "00:00:00"
        dtpFin.Text = "23:59:59"
    End Sub

    Private Sub rbHabitacion_CheckedChanged(sender As Object, e As EventArgs) Handles rbHabitacion.CheckedChanged
        If (rbHabitacion.Checked) Then
            grdCaptura.Rows.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = True
            txtTotal.Text = "0.00"
        End If
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        If (rbTodos.Checked) Then
            grdCaptura.Rows.Clear()
            cboDatos.Text = ""
            cboDatos.Visible = False
            txtTotal.Text = "0.00"
        End If
    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        Try
            cboDatos.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbHabitacion.Checked) Then
                cmd5.CommandText = "    SELECT DISTINCT NMESA FROM rep_comandas WHERE Codigo='xc3' AND Nombre='Tiempo Habitacion' AND NMESA<>'' ORDER BY NMESA"
            End If

            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboDatos.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboDatos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDatos.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnReporte.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
            Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

            Dim fecha As Date = Nothing
            Dim fechan As String = ""

            Dim acumulado As Double = 0

            grdCaptura.Rows.Clear()





            cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

            If (rbHabitacion.Checked) Then

                If cboDatos.Text = "" Then MsgBox("Seleccione la habitación", vbInformation + vbOKOnly, titulohotelriaa) : cboDatos.Focus.Equals(True) : Exit Sub

                cmd1.CommandText = "SELECT * FROM rep_comandas WHERE NMESA='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Hr BETWEEN '" & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "HH:mm:ss") & "'"
            End If

            If (rbTodos.Checked) Then
                cmd1.CommandText = "SELECT * FROM rep_comandas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "' AND Hr BETWEEN '" & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(dtpFin.Value, "HH:mm:ss") & "' AND Nombre='Tiempo Habitacion'"
            End If

            rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        fecha = rd1("Fecha").ToString
                        fechan = Format(fecha, "yyyy-MM-dd")

                        grdCaptura.Rows.Add(rd1("NMESA").ToString,
                                            rd1("Precio").ToString,
                                            rd1("Total").ToString,
                                            fechan,
                                            rd1("Hr").ToString)

                        acumulado = acumulado + rd1("Total").ToString

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            txtTotal.Text = FormatNumber(acumulado, 2)



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
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
            exHoja.Columns("D").NumberFormat = "@"
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