Public Class frmcofepris
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim M1 As Date = mCalendar1.SelectionStart.ToShortDateString
        Dim M2 As Date = mCalendar2.SelectionStart.ToShortDateString

        'Dim fcaduca As Date = Nothing
        Dim f As String = ""
        Try
            cnn1.Close() : cnn1.Open()

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT VE.Folio, PR.Codigo, PR.Nombre, SUM(VD.Cantidad) as Cantidad, PR.Existencia, VD.Fecha, RA.Receta, RA.Status, RA.me_id,VD.Lote,VD.Caducidad FROM (((VentasDetalle VD INNER JOIN Productos PR ON VD.Codigo=PR.Codigo) INNER JOIN Ventas VE ON VD.Folio=VE.Folio) INNER JOIN rep_antib RA ON RA.Folio=VE.Folio) WHERE (VD.Antibiotico=1) AND FVenta>='" & Format(M1, "yyyy-MM-dd") & "' AND FVenta<='" & Format(M2, "yyyy-MM-dd") & "' GROUP BY VE.Folio, PR.Codigo, PR.Nombre, VD.Cantidad, PR.Existencia, VD.Fecha, RA.Receta, RA.Status, RA.me_id"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim cedula, nombre, direccion As String

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "Select CM.Cedula, CM.Nombre, CM.Domicilio FROM (ctmedicos CM INNER JOIN rep_antib RES ON CM.Id=RES.me_id AND RES.Folio=" & rd1("Folio").ToString() & ")"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cedula = rd2("Cedula").ToString()
                            nombre = rd2("Nombre").ToString()
                            direccion = rd2("Domicilio").ToString()
                        End If
                    End If
                    rd2.Close()

                    f = rd1("Caducidad").ToString
                    'f = Format(fcaduca, "yyyy-MM-dd")

                    grdcaptura.Rows.Add(rd1("Folio").ToString(), rd1("Codigo").ToString(), rd1("Nombre").ToString(), rd1("Cantidad").ToString(), rd1("Existencia").ToString(), "", FormatDateTime(rd1("Fecha").ToString(), DateFormat.ShortDate), rd1("Lote").ToString(), f, rd1("Receta").ToString(), cedula, nombre, direccion)
                    My.Application.DoEvents()
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Exportar_Click(sender As Object, e As EventArgs) Handles Exportar.Click
        If grdcaptura.Rows.Count = 0 Then
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
            Dim NCol As Integer = grdcaptura.ColumnCount
            Dim NRow As Integer = grdcaptura.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = grdcaptura.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdcaptura.Rows(Fila).Cells(Col).Value.ToString

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

    Private Sub frmcofepris_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class