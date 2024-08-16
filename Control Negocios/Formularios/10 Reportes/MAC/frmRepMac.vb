Imports Core.DAL.DE
Imports Microsoft.Office.Interop.Excel

Public Class frmRepMac
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        'If grdCaptura.Rows.Count = 0 Then
        '    Exit Sub
        'End If

        If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet
        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add
            exHoja = exLibro.Worksheets.Application.ActiveSheet
            ' Título
            exHoja.Cells(1, 1).Value = "HOJA ELECTRONICA"
            ' Combinar celdas A1 hasta B1 (o más, dependiendo de cuántas columnas quieras abarcar)
            exHoja.Range("A1:D1").Merge()
            ' Centrar el texto en la celda combinada
            exHoja.Range("A1:D1").HorizontalAlignment = XlHAlign.xlHAlignCenter
            ' Poner la fuente en negrita
            exHoja.Range("A1:D1").Font.Bold = True
            ' Cambiar el tamaño de la letra
            exHoja.Range("A1:D1").Font.Size = 16

            ' Encabezados de la tabla
            exHoja.Cells(4, 1).Value = "CUENTA SOLICITADAS:"
            exHoja.Cells(5, 1).Value = "CUENTA CONTABLE"
            exHoja.Cells(5, 2).Value = "CONCEPTO:"

            ' Celdas con datos
            exHoja.Cells(6, 1).Value = "44-001-0021-000"
            exHoja.Cells(6, 2).Value = "SUBTOTAL"
            exHoja.Cells(6, 3).Value = FormatNumber(txtSubtotal.Text, 2)

            exHoja.Cells(7, 1).Value = "32-008-0004-000"
            exHoja.Cells(7, 2).Value = "IVA POR CAUSAR"
            exHoja.Cells(7, 3).Value = FormatNumber(txtIVA.Text, 2)

            exHoja.Cells(8, 1).Value = "05-001-0004-001"
            exHoja.Cells(8, 2).Value = "CLIENTES FARMACIA"

            exHoja.Cells(9, 1).Value = "47-001-0003-000"
            exHoja.Cells(9, 2).Value = "DESCUENTO"
            exHoja.Cells(9, 3).Value = FormatNumber(txtDescuento.Text, 2)
            ' Total
            exHoja.Cells(10, 2).Value = "Totales"
            exHoja.Cells(10, 3).Value = FormatNumber(txtTotal.Text, 2)

            exHoja.Cells(11, 1).Value = "Cuenta"
            ' Centrar el texto en la celda combinada
            exHoja.Range("A11").HorizontalAlignment = XlHAlign.xlHAlignCenter
            ' Poner la fuente en negrita
            exHoja.Range("A11").Font.Bold = True
            ' Cambiar el tamaño de la letra
            exHoja.Range("A11").Font.Size = 16

            exHoja.Cells(11, 2).Value = "Nombre"
            ' Centrar el texto en la celda combinada
            exHoja.Range("B11").HorizontalAlignment = XlHAlign.xlHAlignCenter
            ' Poner la fuente en negrita
            exHoja.Range("B11").Font.Bold = True
            ' Cambiar el tamaño de la letra
            exHoja.Range("B11").Font.Size = 16

            exHoja.Cells(11, 3).Value = "Cargo"
            ' Centrar el texto en la celda combinada
            exHoja.Range("C11").HorizontalAlignment = XlHAlign.xlHAlignCenter
            ' Poner la fuente en negrita
            exHoja.Range("C11").Font.Bold = True
            ' Cambiar el tamaño de la letra
            exHoja.Range("C11").Font.Size = 16

            ' Ajustar ancho de columnas
            exHoja.Columns(1).AutoFit()
            exHoja.Columns(2).AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        grdCaptura.Rows.Clear()
        Dim m1 As Date = mcDesde.SelectionStart.ToShortDateString
        Dim m2 As Date = mcHasta.SelectionStart.ToShortDateString

        Dim cuantos As Double = 0
        Dim subtotal As Double = 0
        Dim Iva As Double = 0
        Dim total As Double = 0
        Dim descuento As Double = 0

        Dim T_Subtotal As Double = 0
        Dim T_IVA As Double = 0
        Dim T_Descuento As Double = 0
        Dim T_Total As Double = 0

        If (rbVentasTotales.Checked) Then

            subtotal = 0
            Iva = 0
            total = 0
            descuento = 0

            T_Subtotal = 0
            T_IVA = 0
            T_Total = 0
            T_Descuento = 0


            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Folio) FROM Ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA'"


                    rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cuantos = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                barcarga.Visible = True
                barcarga.Value = 0
                barcarga.Maximum = cuantos

                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand


                cmd1.CommandText = "SELECT Folio,Cliente,Subtotal,IVA,totales,Propina,Descuento,Devolucion,ACuenta,Resta,Status,Fecha,Facturado FROM ventas WHERE Fecha BETWEEN '" & Format(m1, "yyyy-MM-dd") & " " & Format(dtpinicio.Value, "HH:mm:ss") & "' AND '" & Format(m2, "yyyy-MM-dd") & " " & Format(dtpFin.Value, "HH:mm:ss") & "' AND Status<>'CANCELADA' ORDER BY Folio"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then


                        subtotal = IIf(rd1("Subtotal").ToString = "", 0, rd1("Subtotal").ToString)
                        Iva = IIf(rd1("IVA").ToString = "", 0, rd1("IVA").ToString)
                        total = IIf(rd1("totales").ToString = "", 0, rd1("totales").ToString)
                        descuento = IIf(rd1("Descuento").ToString = "", 0, rd1("Descuento").ToString)

                        grdCaptura.Rows.Add(subtotal, Iva, descuento, total)

                        T_Subtotal = T_Subtotal + subtotal
                        T_IVA = T_IVA + Iva
                        T_Total = T_Total + total

                        T_Descuento = T_Descuento + descuento


                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                cnn2.Close()

                txtSubtotal.Text = FormatNumber(T_Subtotal, 2)
                txtIVA.Text = FormatNumber(T_IVA, 2)
                txtTotal.Text = FormatNumber(T_Total, 2)
                txtDescuento.Text = FormatNumber(T_Descuento, 2)


                barcarga.Visible = False
                barcarga.Value = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
                cnn2.Close()
            End Try

        End If

    End Sub

    Private Sub frmRepMac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbVentasTotales.Checked = True

        mcDesde.SetDate(Now)
        mcHasta.SetDate(Now)
        dtpinicio.Text = "00:00:00"
        dtpFin.Text = "23:59:59"
    End Sub
End Class