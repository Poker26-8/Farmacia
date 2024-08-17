Public Class frmRepTraspasos
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString


        Dim fechanueva As String = ""
        Dim codigo As String = ""
        Dim descripcion As String = ""

        Dim cantidad As Double = 0
        Dim uventa As String = ""
        Dim precio As Double = 0
        Dim total As Double = 0

        Dim subtotal As Double = 0
        Try
                If cboDatos.Text = "" Then
                    MsgBox("Selecciona una opción para continuar", vbExclamation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If

                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cboDatos.Text = "SALIDA" Then
                    cmd1.CommandText = "Select Folio,FVenta from Traslados where Concepto='SALIDA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                Else
                    cmd1.CommandText = "Select Folio,FVenta from Traslados where Concepto='ENTRADA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    Dim idtraspaso As Integer = rd1("Folio").ToString
                    Dim fechatraspaso As Date = rd1("FVenta").ToString

                    fechanueva = Format(fechatraspaso, "dd-MM-yyyy")

                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Codigo,Nombre,Cantidad,Unidad,Precio,Total from TrasladosDet where Folio=" & idtraspaso & " and Concepto='" & cboDatos.Text & "'"
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        codigo = rd2("Codigo").ToString
                        descripcion = rd2("Nombre").ToString
                        cantidad = rd2("Cantidad").ToString
                        uventa = rd2("Unidad").ToString
                        precio = rd2("Precio").ToString
                        total = rd2("Total").ToString

                        grdCaptura.Rows.Add(codigo, descripcion, cantidad & " " & uventa, precio, total, fechanueva)
                        subtotal = subtotal + total
                    Loop
                    rd2.Close()
                    cnn2.Close()
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()
                txtTotal.Text = FormatNumber(subtotal, 2)
                txtSubtotal.Text = FormatNumber(subtotal, 2)
            Catch ex As Exception
                cnn1.Close()
                MessageBox.Show(ex.ToString)
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdCaptura.Rows.Clear()
        cboDatos.Text = ""
    End Sub

    Private Sub frmRepTraspasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class