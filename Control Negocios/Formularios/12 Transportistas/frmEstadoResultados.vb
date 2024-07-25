Imports System.Security.Cryptography
Imports Core.Addendas
Imports Microsoft.Office.Interop

Public Class frmEstadoResultados
    Private Sub frmEstadoResultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim exApp As New Excel.Application
        Dim exLibro As Excel.Workbook
        Dim exHoja As Excel.Worksheet

        'Variables del primer grid [1]
        Dim Fila1 As Integer = 0
        Dim Col1 As Integer = 0
        Dim NCol1 As Integer = dg1.ColumnCount
        Dim NRow1 As Integer = dg1.RowCount

        'Variables del segundo grid [2]
        Dim Fila2 As Integer = 0
        Dim Col2 As Integer = 0
        Dim NCol2 As Integer = dg2.ColumnCount
        Dim NRow2 As Integer = dg2.RowCount

        If dg1.RowCount = 0 And dg2.RowCount = 0 Then
            MsgBox("No hay datos para mostrar, Genere un Reporte Para Exportarlo!!!.", vbInformation + vbOKOnly, "Delsscom® Facturador")
            Exit Sub
        End If

        If MsgBox("¿Desea exportar la información a un documento de excel?", vbInformation + vbOKCancel, "Delsscom® Facturador") = vbOK Then
            'Caso 1 - Egresos
            If dg1.RowCount = 0 And dg2.RowCount <> 0 Then
                'Creamos las variables
                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                pbb.Visible = True
                pbb.Minimum = 0
                pbb.Value = 0
                pbb.Maximum = dg2.Rows.Count
                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exApp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Application.ActiveSheet
                    exHoja.Columns("A").numberformat = "@"
                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = dg2.ColumnCount
                    Dim NRow As Integer = dg2.RowCount

                    exHoja.Range("A1:G1").Merge()
                    exHoja.Cells.Item(1, 1) = lblEgresos.Text

                    '[1] Títulos el primer grid

                    For i As Integer = 1 To NCol
                        exHoja.Cells.Item(2, i) = dg2.Columns(i - 1).HeaderText.ToString
                    Next


                    For Fila1 = 0 To NRow - 1
                        For Col1 = 0 To NCol - 1
                            exHoja.Cells.Item(Fila1 + 3, Col1 + 1) = dg2.Rows(Fila1).Cells(Col1).Value
                        Next
                        pbb.Value += 1
                        My.Application.DoEvents()

                    Next
                    Dim fila22 As Integer = Fila1 + 2
                    Dim col22 As Integer = Col1

                    exHoja.Cells.Item(fila22 + 2, col22 - 1) = "SUBTOTAL:"
                    exHoja.Cells.Item(fila22 + 2, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 2, col22) = FormatNumber(txtSubtotalE.Text, 2)

                    exHoja.Cells.Item(fila22 + 3, col22 - 1) = "IVA:"
                    exHoja.Cells.Item(fila22 + 3, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 3, col22) = FormatNumber(txtIvaE.Text, 2)

                    exHoja.Cells.Item(fila22 + 4, col22 - 1) = "TOTAL:"
                    exHoja.Cells.Item(fila22 + 4, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 4, col22) = FormatNumber(txtTotalE.Text, 2)

                    exHoja.Cells.Item(fila22 + 5, col22 - 1) = "UTILIDAD:"
                    exHoja.Cells.Item(fila22 + 5, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 5, col22) = FormatNumber(txtUtilidad.Text, 2)

                    If CDec(txtUtilidad.Text) < 0 Then
                        exHoja.Rows(fila22 + 5).columns("G").NumberFormat = "$#,##0.00_)[Red]"
                    Else
                        exHoja.Rows(fila22 + 5).columns("G").NumberFormat = "$#,##0.00_)[Blue]"
                    End If


                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    exHoja.Rows.Item(1).Font.Bold = 1
                    exHoja.Rows.Item(1).HorizontalAlignment = 3
                    exHoja.Rows.Item(2).Font.Bold = 1
                    exHoja.Rows.Item(2).HorizontalAlignment = 3
                    exHoja.Columns.AutoFit()

                    MsgBox("Datos Exportados Correctamente", vbInformation + vbOKOnly, "Delsscom® Facturador")

                    'Aplicación visible
                    exApp.Application.Visible = True
                    pbb.Value = 0
                    pbb.Visible = False

                    exHoja = Nothing
                    exLibro = Nothing
                    exApp = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                End Try
            End If

            'Caso 2 - Ingresos
            If dg1.RowCount <> 0 And dg2.RowCount = 0 Then
                'Creamos las variables
                Dim Fila As Integer = 0
                Dim Col As Integer = 0

                pbb.Visible = True
                pbb.Minimum = 0
                pbb.Value = 0
                pbb.Maximum = dg1.Rows.Count
                My.Application.DoEvents()
                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exApp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Application.ActiveSheet
                    exHoja.Columns("A").numberformat = "@"
                    ' ¿Cuantas columnas y cuantas filas?
                    Dim NCol As Integer = dg1.ColumnCount
                    Dim NRow As Integer = dg1.RowCount

                    exHoja.Range("A1:E1").Merge()
                    exHoja.Cells.Item(1, 1) = lblIngresos.Text

                    '[1] Títulos el primer grid

                    For i As Integer = 1 To NCol1
                        exHoja.Cells.Item(2, i) = dg1.Columns(i - 1).HeaderText.ToString
                    Next

                    For Fila1 = 0 To NRow1 - 1
                        For Col1 = 0 To NCol1 - 1
                            exHoja.Cells.Item(Fila1 + 3, Col1 + 1) = dg1.Rows(Fila1).Cells(Col1).Value
                        Next
                        pbb.Value += 1
                        My.Application.DoEvents()
                    Next
                    Dim fila22 As Integer = Fila1 + 3
                    Dim col22 As Integer = Col1

                    exHoja.Cells.Item(fila22 + 2, col22 - 1) = "SUBTOTAL:"
                    exHoja.Cells.Item(fila22 + 2, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 2, col22) = FormatNumber(txtSubtotalI.Text, 2)

                    exHoja.Cells.Item(fila22 + 3, col22 - 1) = "IVA:"
                    exHoja.Cells.Item(fila22 + 3, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 3, col22) = FormatNumber(txtIvaI.Text, 2)

                    exHoja.Cells.Item(fila22 + 4, col22 - 1) = "TOTAL:"
                    exHoja.Cells.Item(fila22 + 4, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 4, col22) = FormatNumber(txtTotalI.Text, 2)

                    exHoja.Cells.Item(fila22 + 5, col22 - 1) = "UTILIDAD:"
                    exHoja.Cells.Item(fila22 + 5, col22 - 1).font.bold = 1
                    exHoja.Cells.Item(fila22 + 5, col22) = FormatNumber(txtUtilidad.Text, 2)

                    If CDec(txtUtilidad.Text) < 0 Then
                        exHoja.Rows(fila22 + 5).columns("E").NumberFormat = "$#,##0.00_)[Red]"
                    Else
                        exHoja.Rows(fila22 + 5).columns("E").NumberFormat = "$#,##0.00_)[Blue]"
                    End If

                    Fila2 = Fila + 2
                    Col2 = Col

                    'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
                    exHoja.Rows.Item(1).Font.Bold = 1
                    exHoja.Rows.Item(1).HorizontalAlignment = 3
                    exHoja.Rows.Item(2).Font.Bold = 1
                    exHoja.Rows.Item(2).HorizontalAlignment = 3
                    exHoja.Columns.AutoFit()
                    MsgBox("Datos Exportados Correctamente", vbInformation + vbOKOnly, "Delsscom® Facturador")

                    'Aplicación visible
                    exApp.Application.Visible = True
                    pbb.Value = 0
                    pbb.Visible = False

                    exHoja = Nothing
                    exLibro = Nothing
                    exApp = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                End Try
            End If

            'Caso 3 - Ingreso y Egresos
            If dg1.RowCount <> 0 And dg2.RowCount <> 0 Then
                'Creamos las variables
                pbb.Visible = True
                pbb.Minimum = 0
                pbb.Value = 0
                pbb.Maximum = dg1.Rows.Count + dg2.Rows.Count

                Try
                    'Añadimos el Libro al programa, y la hoja al libro
                    exLibro = exApp.Workbooks.Add
                    exHoja = exLibro.Worksheets.Application.ActiveSheet
                    exHoja.Columns("A").numberformat = "@"
                    '[1] Título del primer grid
                    exHoja.Range("A1:E1").Merge()
                    exHoja.Cells.Item(1, 1) = lblIngresos.Text

                    '[1] Títulos el primer grid

                    For i As Integer = 1 To NCol1
                        exHoja.Cells.Item(2, i) = dg1.Columns(i - 1).HeaderText.ToString
                    Next

                    For Fila1 = 0 To NRow1 - 1
                        For Col1 = 0 To NCol1 - 1
                            exHoja.Cells.Item(Fila1 + 3, Col1 + 1) = dg1.Rows(Fila1).Cells(Col1).Value
                        Next
                        pbb.Value += 1
                        My.Application.DoEvents()
                    Next

                    Fila2 = Fila1 + 2
                    Col2 = Col1

                    exHoja.Cells.Item(Fila2 + 2, Col2) = lblEgresos.Text
                    exHoja.Range("A" & Fila2 + 2 & ":G" & Fila2 + 2).Merge()
                    Dim titulos As Integer = Fila2 + 2

                    For i As Integer = 1 To NCol2
                        exHoja.Cells.Item(titulos + 1, i) = dg2.Columns(i - 1).HeaderText.ToString
                    Next

                    Dim rows1 As Integer = 0
                    Dim column As Integer = 0

                    rows1 = titulos + 2

                    For rows1 = 0 To NRow2 - 1
                        For column = 0 To NCol2 - 1
                            exHoja.Cells.Item(rows1 + titulos + 2, column + 1) = dg2.Rows(rows1).Cells(column).Value
                        Next
                        pbb.Value += 1
                        My.Application.DoEvents()
                    Next

                    Dim row_fin As Integer = 0
                    Dim col_fin As Integer = 0

                    row_fin = rows1 + titulos + 3
                    col_fin = column

                    exHoja.Cells.Item(row_fin, 1) = "INGRESOS"

                    exHoja.Cells.Item(row_fin + 1, 1) = "SUBTOTAL:"
                    exHoja.Cells.Item(row_fin + 1, Col2 - 3) = FormatNumber(txtSubtotalI.Text, 2)
                    exHoja.Cells.Item(row_fin + 2, 1) = "IVA:"
                    exHoja.Cells.Item(row_fin + 2, Col2 - 3) = FormatNumber(txtIvaI.Text, 2)
                    exHoja.Cells.Item(row_fin + 3, 1) = "TOTAL:"
                    exHoja.Cells.Item(row_fin + 3, Col2 - 3) = FormatNumber(txtTotalI.Text, 2)

                    exHoja.Cells.Item(row_fin, col_fin - 3) = "EGRESOS"

                    exHoja.Cells.Item(row_fin + 1, col_fin - 3) = "SUBTOTAL:"
                    exHoja.Cells.Item(row_fin + 1, Col2) = FormatNumber(txtSubtotalE.Text, 2)
                    exHoja.Cells.Item(row_fin + 2, col_fin - 3) = "IVA:"
                    exHoja.Cells.Item(row_fin + 2, Col2) = FormatNumber(txtIvaE.Text, 2)
                    exHoja.Cells.Item(row_fin + 3, col_fin - 3) = "TOTAL:"
                    exHoja.Cells.Item(row_fin + 3, Col2) = FormatNumber(txtTotalE.Text, 2)

                    exHoja.Cells.Item(row_fin + 1, col_fin) = "UTILIDAD"
                    exHoja.Cells.Item(row_fin + 2, col_fin) = FormatNumber(txtUtilidad.Text, 2)
                    If CDec(txtUtilidad.Text) < 0 Then
                        exHoja.Rows(row_fin + 2).columns("G").NumberFormat = "$#,##0.00_)[Red]"
                    Else
                        exHoja.Rows(row_fin + 2).columns("G").NumberFormat = "$#,##0.00_)[Blue]"
                    End If


                    ''Modificacione spara los títulos
                    exHoja.Rows.Item(1).Font.Bold = 1
                    exHoja.Rows.Item(1).HorizontalAlignment = 3
                    exHoja.Rows.Item(2).Font.Bold = 1
                    exHoja.Rows.Item(2).HorizontalAlignment = 3
                    exHoja.Rows.Item(titulos).Font.Bold = 1
                    exHoja.Rows.Item(titulos).HorizontalAlignment = 3
                    exHoja.Rows.Item(titulos + 1).Font.Bold = 1
                    exHoja.Rows.Item(titulos + 1).HorizontalAlignment = 3
                    exHoja.Rows.Item(row_fin).Font.Bold = 1
                    exHoja.Rows.Item(row_fin).HorizontalAlignment = 3
                    exHoja.Cells.Item(row_fin + 1, col_fin).Font.Bold = 1
                    exHoja.Cells.Item(row_fin + 1, col_fin).HorizontalAlignment = 3

                    MsgBox("Datos Exportados Correctamente", vbInformation + vbOKOnly, "Delsscom® Facturador")

                    'Aplicación visible
                    exApp.Application.Visible = True
                    pbb.Value = 0
                    pbb.Visible = False


                    exHoja = Nothing
                    exLibro = Nothing
                    exApp = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
                End Try
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

        Dim sum As Double = 0
        Dim iva As Double = 0
        Dim subtotal As Double = 0
        Dim cli As String = ""
        Dim t As Double = 0
        Dim f As Date = Date.Now

        Dim total As Double = 0
        Dim areas As String = ""
        Dim concepto As String = ""
        Dim factura As String = ""
        Dim subt As Double = 0
        Dim ivaa As Double = 0
        Dim totall As Double = 0
        Dim fechaa As Date = Date.Now

        dg1.Rows.Clear()
        dg2.Rows.Clear()
        lblIngresos.Text = ""
        lblEgresos.Text = ""

        Try
            If (rbPlacas.Checked) Then

                If cboDatos.Text = "" Then
                    MsgBox("Debe seleccionar una Placa para continuar!!!", vbInformation + vbOKOnly, titulocentral)
                    cboDatos.DroppedDown = True
                End If

                txtTotalI.Text = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT SUM(IVA) FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                        txtIvaI.Text = "$ " & sum
                    End If
                Else
                    txtIvaI.Text = "0"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT SUM(Subtotal) FROM ventas WHERE Fventa BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                        txtSubtotalI.Text = "$ " & sum
                    End If
                Else

                    txtSubtotalI.Text = "0"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IVA,Subtotal,Cliente,FVenta FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        iva = rd1("IVA").ToString
                        subtotal = rd1("Subtotal").ToString
                        cli = rd1("Cliente").ToString
                        f = rd1("FVenta").ToString
                        t = subtotal + iva
                        txtTotalI.Text = "$ " & CDec(txtTotalI.Text) + t
                        lblIngresos.Text = "INGRESOS " & "DEL " & m1 & " AL " & m2
                        dg1.Rows.Add(cli, subtotal, iva, t, FormatDateTime(f, DateFormat.ShortDate))
                    End If
                Loop
                rd1.Close()

                '---------------------------------------------------EGRESOS POR PLACAS---------------------------------------------------------------
                txtSubtotalE.Text = 0


                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT SUM(IVA) FROM otrosgastos WHERE Placas='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                        txtIvaE.Text = "$ " & sum
                    End If
                Else
                    txtIvaE.Text = "0"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT SUM(subtotal) FROM otrosgastos WHERE Placas='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                        txtSubtotalE.Text = "$ " & sum
                    End If
                Else
                    txtSubtotalE.Text = "0"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Total,Tipo,Concepto,Folio,Subtotal,Iva,Fecha FROM otrosgastos WHERE placas='" & cboDatos.Text & "' AND Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        total = rd1("Total").ToString
                        areas = rd1("Tipo").ToString
                        concepto = rd1("Concepto").ToString
                        factura = rd1("Folio").ToString
                        subt = rd1("Subtotal").ToString
                        ivaa = rd1("Iva").ToString
                        fechaa = rd1("Fecha").ToString

                        txtTotalE.Text = "$ " & CDec(txtTotalE.Text) + total
                        lblEgresos.Text = "EGRESOS " & "DEL " & m1 & " AL " & m2
                        dg2.Rows.Add(areas, concepto, factura, subt, ivaa, total, FormatDateTime(fechaa, DateFormat.ShortDate))
                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

            If (rbGlobal.Checked) Then
                Try
                    txtTotalI.Text = 0

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT SUM(IVA) FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            txtIvaI.Text = "$ " & sum
                        End If
                    Else
                        txtIvaI.Text = "0"
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT SUM(Subtotal) FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            txtSubtotalI.Text = "$ " & sum
                        End If
                    Else
                        txtSubtotalI.Text = "0"
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT IVA,Subtotal,Cliente,FVenta FROM ventas WHERE FVenta BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            iva = rd1("IVA").ToString
                            subtotal = rd1("Subtotal").ToString
                            cli = rd1("Cliente").ToString
                            f = rd1("FVenta").ToString
                            t = subtotal + iva
                            txtTotalI.Text = "$ " & CDec(txtTotalI.Text) + t
                            lblIngresos.Text = "INGRESOS " & "DEL " & m1 & " AL " & m2
                            dg1.Rows.Add(cli, subtotal, iva, t, FormatDateTime(f, DateFormat.ShortDate))
                        End If
                    Loop
                    rd1.Close()

                    '   --------------------------------------EGRESOS GLOBALES--------------------------------
                    txtTotalE.Text = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT SUM(IVA) FROM otrosgastos WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            txtIvaE.Text = "$ " & sum
                        End If
                    Else

                        txtIvaE.Text = "0"
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT SUM(Subtotal) FROM otrosgastos WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            sum = IIf(rd1(0).ToString = "", 0, rd1(0).ToString)
                            txtSubtotalE.Text = "$ " & sum
                        End If
                    Else
                        txtSubtotalE.Text = "0"
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Total,Tipo,Concepto,Folio,Subtotal,Iva,Fecha FROM otrosgastos WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then
                            total = rd1("Total").ToString
                            areas = rd1("Tipo").ToString
                            concepto = rd1("Concepto").ToString
                            factura = rd1("Folio").ToString
                            subt = rd1("Subtotal").ToString
                            ivaa = rd1("Iva").ToString
                            fechaa = rd1("Fecha").ToString
                            txtTotalE.Text = "$ " & CDec(txtTotalE.Text) + total
                            lblEgresos.Text = "EGRESOS " & "DEL " & m1 & " AL " & m2
                            dg2.Rows.Add(areas, concepto, factura, subt, ivaa, total, FormatDateTime(fechaa, DateFormat.ShortDate))
                        End If
                    Loop
                    rd1.Close()
                    cnn1.Close()

                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If

            txtUtilidad.Text = txtTotalI.Text - txtTotalE.Text
            txtIvaI.Text = FormatNumber(txtIvaI.Text, 2)
            txtSubtotalI.Text = FormatNumber(txtSubtotalI.Text, 2)
            txtTotalI.Text = FormatNumber(txtTotalI.Text, 2)

            txtIvaE.Text = FormatNumber(txtIvaE.Text, 2)
            txtSubtotalE.Text = FormatNumber(txtSubtotalE.Text, 2)
            txtTotalE.Text = FormatNumber(txtTotalE.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cboDatos.Text = ""
        mcDesde.SelectionStart = Now
        mcHasta.SelectionStart = Now

        dg1.Rows.Clear()
        dg2.Rows.Clear()

        txtSubtotalI.Text = "0.00"
        txtIvaI.Text = "0.00"
        txtTotalI.Text = "0.00"

        txtSubtotalE.Text = "0.00"
        txtIvaE.Text = "0.00"
        txtTotalE.Text = "0.00"

        txtUtilidad.Text = "0.00"

        lblIngresos.Text = ""
        lblEgresos.Text = ""
    End Sub

    Private Sub rbPlacas_Click(sender As Object, e As EventArgs) Handles rbPlacas.Click
        If (rbPlacas.Checked) Then
            rbGlobal.Checked = False
            cboDatos.Text = ""
            cboDatos.Visible = True
            lblIngresos.Text = ""
            lblEgresos.Text = ""
            dg1.Rows.Clear()
            dg2.Rows.Clear()
            txtSubtotalI.Text = "0.00"
            txtIvaI.Text = "0.00"
            txtTotalI.Text = "0.00"
            txtSubtotalE.Text = "0.00"
            txtIvaE.Text = "0.00"
            txtTotalI.Text = "0.00"
            txtUtilidad.Text = "0.00"
        End If
    End Sub

    Private Sub rbGlobal_Click(sender As Object, e As EventArgs) Handles rbGlobal.Click
        If (rbGlobal.Checked) Then
            rbPlacas.Checked = False
            cboDatos.Text = ""
            cboDatos.Visible = False
            lblIngresos.Text = ""
            lblEgresos.Text = ""
            dg1.Rows.Clear()
            dg2.Rows.Clear()
            txtSubtotalI.Text = "0.00"
            txtIvaI.Text = "0.00"
            txtTotalI.Text = "0.00"
            txtSubtotalE.Text = "0.00"
            txtIvaE.Text = "0.00"
            txtTotalI.Text = "0.00"
            txtUtilidad.Text = "0.00"
        End If

    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        Try
            cboDatos.Items.Clear()

            Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
            Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placas FROM otrosgastos WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & "' AND '" & Format(m2, "yyyy-MM-dd") & "'"
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
End Class