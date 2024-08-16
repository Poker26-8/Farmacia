Imports Microsoft.Office.Interop

Public Class frmRepGastos
    Private Sub frmRepGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub rbArea_Click(sender As Object, e As EventArgs) Handles rbArea.Click

        If (rbArea.Checked) Then
            rbModelo.Checked = False
            rbTodos.Checked = False
            cboDatos.Text = ""
            grdCaptura.Rows.Clear()

            txtTotal.Text = "0.00"
            txtRegistros.Text = "0.00"
        End If

    End Sub

    Private Sub rbModelo_Click(sender As Object, e As EventArgs) Handles rbModelo.Click
        If (rbModelo.Checked) Then
            rbArea.Checked = False
            rbTodos.Checked = False
            cboDatos.Text = ""
            grdCaptura.Rows.Clear()

            txtTotal.Text = "0.00"
            txtRegistros.Text = "0.00"
        End If
    End Sub

    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click
        If (rbTodos.Checked) Then
            rbArea.Checked = False
            rbModelo.Checked = False
            cboDatos.Text = ""
            txtTotal.Text = "0.00"
            txtRegistros.Text = "0.00"
            grdCaptura.Rows.Clear()

            Dim tot As Double = 0

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Id) FROM otrosgastos"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        txtRegistros.Text = rd1(0).ToString
                        txtRegistros.Text = FormatNumber(txtRegistros.Text, 2)
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Fecha,Tipo,Modelo,Placas,Folio,Concepto,FormaPago,Total,Nota FROM otrosgastos"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        Dim f As Date = Nothing
                        Dim fe As String = ""
                        f = rd1("Fecha").ToString
                        fe = Format(f, "yyyy-MM-dd")

                        grdCaptura.Rows.Add(rd1("Tipo").ToString,
                                            rd1("Modelo").ToString,
                                            rd1("Placas").ToString,
                                            rd1("Folio").ToString,
                                            rd1("Concepto").ToString,
                                            rd1("FormaPago").ToString,
                                            rd1("Total").ToString,
                                            fe,
                                            rd1("Nota").ToString
                                            )
                        tot = tot + rd1("Total").ToString

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
                txtTotal.Text = FormatNumber(tot, 2)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()

            End Try
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboDatos.Text = ""
        txtRegistros.Text = "0.00"
        txtTotal.Text = "0.00"

        rbArea.Checked = True
        rbModelo.Checked = False
        rbTodos.Checked = False
        grdCaptura.Rows.Clear()
    End Sub

    Private Sub cboDatos_DropDown(sender As Object, e As EventArgs) Handles cboDatos.DropDown
        Try
            cboDatos.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbArea.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Tipo FROM otrosgastos WHERE Tipo<>'' ORDER BY Tipo"
            End If

            If (rbModelo.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Modelo FROM otrosgastos WHERE Modelo<>'' ORDER BY Modelo"
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

    Private Sub cboDatos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDatos.SelectedValueChanged
        Try
            grdCaptura.Rows.Clear()
            Dim cuantos As Integer = 0
            Dim totalgastos As Double = 0

            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()
            cmd1 = cnn1.CreateCommand
            cmd2 = cnn2.CreateCommand

            If (rbArea.Checked) Then
                cmd1.CommandText = "SELECT Tipo,Modelo,Placas,Folio,Concepto,FormaPago,Total,Nota,Fecha FROM otrosgastos WHERE Tipo='" & cboDatos.Text & "'"
                cmd2.CommandText = "SELECT COUNT(Id) FROM otrosgastos WHERE Tipo='" & cboDatos.Text & "'"
            End If

            If (rbModelo.Checked) Then
                cmd1.CommandText = "SELECT Tipo,Modelo,Placas,Folio,Concepto,FormaPago,Total,Nota,Fecha FROM otrosgastos WHERE Modelo='" & cboDatos.Text & "'"
                cmd2.CommandText = "SELECT COUNT(Id) FROM otrosgastos WHERE Modelo='" & cboDatos.Text & "'"
            End If

            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cuantos = rd2(0).ToString
                    txtRegistros.Text = FormatNumber(cuantos, 2)
                End If
            End If
            rd2.Close()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    Dim fec As Date = Nothing
                    Dim fech As String = ""

                    fec = rd1("Fecha").ToString
                    fech = Format(fec, "yyyy-MM-dd")
                    grdCaptura.Rows.Add(rd1("Tipo").ToString,
                                        rd1("Modelo").ToString,
                                        rd1("Placas").ToString,
                                        rd1("Folio").ToString,
                                        rd1("Concepto").ToString,
                                        rd1("FormaPago").ToString,
                                        rd1("Total").ToString,
                                        rd1("Nota").ToString,
                                        fech)

                    totalgastos = totalgastos + CDbl(rd1("Total").ToString)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
            txtTotal.Text = FormatNumber(totalgastos, 2)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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

            exHoja.Columns("T").NumberFormat = "@"
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