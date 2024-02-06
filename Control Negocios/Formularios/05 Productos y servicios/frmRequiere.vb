Imports Microsoft.Office.Interop.Excel

Public Class frmRequiere

    Private Sub cbonombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cbonombre.DropDown
        cbonombre.Items.Clear()
        Try
            cnn1.Close()
            cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct DescripP from MiProd"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonombre.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonombre_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbonombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            txtcantidad.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonombre_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cbonombre.SelectedValueChanged
        grdcaptura.Rows.Clear()
        txttotal.Text = "0.00"
        Dim codigo As String = ""
        Dim nombre As String = ""
        Dim unidad As String = ""
        Dim cantidad As Double = 0
        Dim precio_com As Double = 0
        Dim existencia As Double = 0
        Dim multiplo As Double = 0

        Dim MyTotal As Double = 0

        Try
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn1.Open()
            cnn2.Open()
            cnn3.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from MiProd where DescripP='" & cbonombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtcodigo.Text = rd1("CodigoP").ToString
                    txtunidad.Text = rd1("UVentaP").ToString
                End If
            End If
            rd1.Close()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select * from Productos where Codigo='" & rd1("Codigo").ToString & "'"
                rd3 = cmd3.ExecuteReader
                If rd3.HasRows Then
                    If rd3.Read Then
                        precio_com = rd3("PrecioCompra").ToString
                    End If
                End If
                rd3.Close()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(rd1("Codigo").ToString, 6) & "'"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        codigo = rd1("Codigo").ToString
                        nombre = rd1("Descrip").ToString
                        unidad = rd1("UVenta").ToString
                        cantidad = rd1("Cantidad").ToString
                        existencia = rd2("Existencia").ToString
                        multiplo = rd2("Multiplo").ToString

                        MyTotal = CDec(rd2("PrecioCompra").ToString) * cantidad

                        grdcaptura.Rows.Add(
                            codigo,
                            nombre,
                            unidad,
                            FormatNumber(cantidad, 6),
                            FormatNumber(precio_com, 4),
                            FormatNumber(cantidad * precio_com, 2),
                            FormatNumber(existencia / multiplo, 2),
                            FormatNumber((existencia / multiplo) / cantidad, 2)
                            )
                    End If
                End If
                rd2.Close()
                txttotal.Text = CDec(txttotal.Text) + MyTotal
            Loop
            rd1.Close()
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            txttotal.Text = FormatNumber(txttotal.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        txtcodigo.Text = ""
        cbonombre.Items.Clear()
        cbonombre.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = "1.00"
        txttotal.Text = "0.00"
        grdcaptura.Rows.Clear()
    End Sub

    Private Sub txtcantidad_Click(sender As System.Object, e As System.EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcantidad.KeyPress
        Dim MyTotal As Double = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtcantidad.Text = "" Then Exit Sub
            If txtcantidad.Text = "." Then Exit Sub
            If Not IsNumeric(txtcantidad.Text) Then Exit Sub
            If CDec(txtcantidad.Text) = 0 Then Exit Sub
            Call cbonombre_SelectedValueChanged(cbonombre, New EventArgs())
            txttotal.Text = "0.00"
            For d As Integer = 0 To grdcaptura.Rows.Count - 1
                Dim total As Double = 0
                Dim precio As Double = grdcaptura.Rows(d).Cells(4).Value.ToString
                Dim cantidad As Double = grdcaptura.Rows(d).Cells(3).Value.ToString

                grdcaptura.Rows(d).Cells(3).Value = FormatNumber(cantidad * CDec(txtcantidad.Text), 4)
                cantidad = grdcaptura.Rows(d).Cells(3).Value.ToString
                total = cantidad * precio
                grdcaptura.Rows(d).Cells(5).Value = FormatNumber(total, 2)
                MyTotal += total
            Next
            txttotal.Text = FormatNumber(MyTotal, 2)
            btnexportar.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnexportar_Click(sender As System.Object, e As System.EventArgs) Handles btnexportar.Click
        If grdcaptura.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("¿Deseas exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim exApp As New Microsoft.Office.Interop.Excel.Application
            Dim exBook As Microsoft.Office.Interop.Excel.Workbook
            Dim exSheet As Microsoft.Office.Interop.Excel.Worksheet

            Try
                exBook = exApp.Workbooks.Add
                exSheet = exBook.Worksheets.Application.ActiveSheet

                exSheet.Columns("A").NumberFormat = "@"

                Dim Fila As Integer = 0
                Dim Colu As Integer = 0

                Dim NCol As Integer = grdcaptura.ColumnCount
                Dim NRow As Integer = grdcaptura.RowCount

                exSheet.Cells.Range("A1:G1").Merge()
                exSheet.Cells.Item(1, 1) = "REQUISICIONES POR ARTÍCULO"
                'Código del producto
                exSheet.Cells.Item(2, 1) = txtcodigo.Text
                'Descripción del productos
                exSheet.Cells.Range("B2:G2").Merge()
                exSheet.Cells.Item(2, 2) = cbonombre.Text
                'Cantidad a producir
                exSheet.Cells.Item(1, 8) = "A PRODUCIR"
                exSheet.Cells.Item(2, 8) = txtcantidad.Text
                'Costo directo de productcción
                exSheet.Cells.Item(1, 9) = "COSTO DIRECTO"
                exSheet.Cells.Item(2, 9) = txttotal.Text

                exSheet.Rows.Item(1).font.bold = 1
                exSheet.Rows.Item(1).HorizontalAlignment = 3

                'Títulos del grid
                exSheet.Cells.Item(4, 1) = "Código"
                exSheet.Cells.Item(4, 2) = "Descripción"
                exSheet.Cells.Item(4, 3) = "Unidad"
                exSheet.Cells.Item(4, 4) = "Cantidad"
                exSheet.Cells.Item(4, 5) = "Precio"
                exSheet.Cells.Item(4, 6) = "Total"
                exSheet.Cells.Item(4, 7) = "Existencia"
                exSheet.Cells.Item(4, 8) = "Exis. p/Producto"

                exSheet.Rows.Item(4).font.bold = 1
                exSheet.Rows.Item(4).HorizontalAlignment = 3

                For Fila = 0 To NRow - 1
                    For Colu = 0 To NCol - 1
                        exSheet.Cells.Item(Fila + 5, Colu + 1) = Convert.ToString(grdcaptura.Rows(Fila).Cells(Colu).Value.ToString)
                    Next
                Next

                exSheet.Columns("C").HorizontalAlignment = 3

                exApp.Application.Visible = True
                exSheet = Nothing
                exBook = Nothing
                exApp = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub
End Class