Imports ClosedXML.Excel

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
        Dim barras As String = ""
        Dim lote As String = ""
        Dim fcaduca As String = ""

        Dim subtotal As Double = 0
        Try
            If cboDatos.Text = "" Then
                MsgBox("Selecciona una opción para continuar", vbExclamation + vbOKOnly, "Delsscom Control Negocios Pro")
                Exit Sub
            End If

            grdCaptura.Rows.Clear()

            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand

            If cboDatos.Text = "SALIDA" Then
                cmd1.CommandText = "Select Folio,FVenta,Comisionista,NUM_TRASLADO from Traslados where Concepto='SALIDA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
            Else
                cmd1.CommandText = "Select Folio,FVenta,Comisionista,NUM_TRASLADO from Traslados where Concepto='ENTRADA' and FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                Dim idtraspaso As Integer = rd1("Folio").ToString
                Dim fechatraspaso As Date = rd1("FVenta").ToString
                Dim Comisionistaxd As String = rd1("Comisionista").ToString
                Dim folioxd As String = rd1("NUM_TRASLADO").ToString

                fechanueva = Format(fechatraspaso, "dd-MM-yyyy")

                cnn2.Close()
                cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "Select Codigo,Nombre,Cantidad,Unidad,Precio,Total,Lote,FCaduca from TrasladosDet where Folio=" & idtraspaso & " and Concepto='" & cboDatos.Text & "' order by Id"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    codigo = rd2("Codigo").ToString
                    descripcion = rd2("Nombre").ToString
                    cantidad = rd2("Cantidad").ToString
                    uventa = rd2("Unidad").ToString
                    precio = rd2("Precio").ToString
                    total = rd2("Total").ToString
                    lote = rd2("Lote").ToString
                    fcaduca = rd2("FCaduca").ToString

                    cnn3.Close()
                    cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "Select CodBarra from Productos where COdigo='" & codigo & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.Read Then
                        barras = rd3(0).ToString
                    End If
                    rd3.Close()
                    cnn3.Close()

                    grdCaptura.Rows.Add(codigo, barras, descripcion, cantidad & " " & uventa, precio, total, fechanueva, Comisionistaxd, lote, fcaduca, folioxd)
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
        ExportarDataGridViewAExcel(grdCaptura)
    End Sub

    Public Sub ExportarDataGridViewAExcel(dgv As DataGridView)
        If grdCaptura.Rows.Count = 0 Then MsgBox("Genera el reporte para poder exportar los datos a Excel.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
        If MsgBox("¿Deseas exportar la información a un archivo de Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            Dim voy As Integer = 0
            ' Crea un nuevo libro de trabajo de Excel
            Using workbook As New XLWorkbook()

                ' Añade una nueva hoja de trabajo
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Datos")

                ' Escribe los encabezados de columna
                For colIndex As Integer = 0 To dgv.Columns.Count - 1
                    Dim headerCell As IXLCell = worksheet.Cell(1, colIndex + 1)
                    worksheet.Cell(1, colIndex + 1).Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Value = dgv.Columns(colIndex).HeaderText
                    headerCell.Style.Font.Bold = True  ' Aplica negrita a los encabezados
                Next


                For rowIndex As Integer = 0 To dgv.Rows.Count - 1
                    For colIndex As Integer = 0 To dgv.Columns.Count - 1
                        Dim cellValue As Object = dgv.Rows(rowIndex).Cells(colIndex).Value
                        Dim cellValueString As String = If(cellValue Is Nothing, String.Empty, cellValue.ToString())
                        worksheet.Cell(rowIndex + 2, colIndex + 1).Value = cellValueString
                        Dim cell As IXLCell = worksheet.Cell(rowIndex + 2, colIndex + 1)
                        cell.Value = cellValueString
                        cell.Style.NumberFormat.Format = "@"
                    Next
                    voy = voy + 1
                    My.Application.DoEvents()
                Next

                worksheet.Columns().AdjustToContents()
                ' Usa MemoryStream para guardar el archivo en memoria y abrirlo
                Using memoryStream As New System.IO.MemoryStream()
                    ' Guarda el libro de trabajo en el MemoryStream
                    workbook.SaveAs(memoryStream)

                    ' Guarda el MemoryStream en un archivo temporal para abrirlo
                    Dim tempFilePath As String = IO.Path.GetTempPath() & Guid.NewGuid().ToString() & ".xlsx"
                    System.IO.File.WriteAllBytes(tempFilePath, memoryStream.ToArray())

                    ' Abre el archivo temporal en Excel
                    Process.Start(tempFilePath)
                End Using

                'workbook.SaveAs(filePath)
            End Using
            MessageBox.Show("Datos exportados exitosamente")

        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdCaptura.Rows.Clear()
        cboDatos.Text = ""
    End Sub

    Private Sub frmRepTraspasos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboDatos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDatos.SelectedValueChanged
        grdCaptura.Rows.Clear()
    End Sub
End Class