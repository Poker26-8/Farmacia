Public Class frmRepConsignacion
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Cliente from Ventas where Status='RESTA' and Consignar=1 order by Cliente"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                ComboBox1.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Public Sub creaCliente()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 0
        My.Application.DoEvents()
        DataGridView1.ColumnCount = 9
        With DataGridView1
            With .Columns(0)
                .HeaderText = "Folio"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "Codigo"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Descripcion"
                .Width = 350

                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Unidad de medida"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Consignado"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Pagado"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Pendiente de pago"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Cantidad"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "Total"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With

    End Sub

    Public Sub creaTodos()
        DataGridView1.Rows.Clear()
        DataGridView1.ColumnCount = 0
        My.Application.DoEvents()
        DataGridView1.ColumnCount = 10
        With DataGridView1
            With .Columns(0)
                .HeaderText = "Folio"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(1)
                .HeaderText = "Cliente"
                .Width = 280
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(2)
                .HeaderText = "Codigo"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Descripcion"
                .Width = 280
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Unidad de medida"
                .Width = 60
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(5)
                .HeaderText = "Consignado"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(6)
                .HeaderText = "Pagado"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(7)
                .HeaderText = "Pendiente de pago"
                .Width = 70
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(8)
                .HeaderText = "Cantidad "
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(9)
                .HeaderText = "Total"
                .Width = 75
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then
            creaTodos()
            My.Application.DoEvents()

            Try
                Dim cantidad As Double = 0
                Dim pagadas As Double = 0
                Dim precio As Double = 0
                Dim total As Double = 0
                Dim totalpagasdas As Double = 0
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Folio,Cliente from Ventas where Status='RESTA' and Consignar=1"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Cantidad,CantidadC,Codigo,Nombre,Unidad,Precio from VentasDetalle where Folio=" & rd1("Folio").ToString & ""
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        Dim resta As Double = 0
                        resta = rd2("Cantidad").ToString - CDec(rd2("CantidadC").ToString)
                        DataGridView1.Rows.Add(rd1("Folio").ToString, rd1("Cliente").ToString, rd2("Codigo").ToString, rd2("Nombre").ToString, rd2("Unidad").ToString, rd2("Cantidad").ToString, rd2("CantidadC").ToString, resta, FormatNumber(rd2("Precio").ToString, 2), FormatNumber(rd2("Total").ToString), 2)
                        precio = rd2("Precio").ToString
                        cantidad = rd2("Cantidad").ToString
                        pagadas = rd2("CantidadC").ToString

                        total = total + FormatNumber(CDec(precio * cantidad), 2)
                        totalpagasdas = totalpagasdas + FormatNumber(CDec(precio * pagadas), 2)
                    Loop
                    rd2.Close()
                    cnn2.Close()
                    txtvendidos.Text = FormatNumber(total, 2)
                    txtpagados.Text = FormatNumber(totalpagasdas, 2)
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn2.Close()
                cnn1.Close()
            End Try
        Else
            creaCliente()
            My.Application.DoEvents()

            Dim cantidad As Double = 0
            Dim pagadas As Double = 0
            Dim precio As Double = 0
            Dim total As Double = 0
            Dim totalpagasdas As Double = 0

            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Select Folio from Ventas where Cliente='" & ComboBox1.Text & "' and Status='RESTA' and Consignar=1"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    cnn2.Close()
                    cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "Select Cantidad,CantidadC,Codigo,Nombre,Unidad,Precio,Total from VentasDetalle where Folio=" & rd1("Folio").ToString & ""
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        Dim resta As Double = 0
                        resta = rd2("Cantidad").ToString - CDec(rd2("CantidadC").ToString)
                        DataGridView1.Rows.Add(rd1("Folio").ToString, rd2("Codigo").ToString, rd2("Nombre").ToString, rd2("Unidad").ToString, rd2("Cantidad").ToString, rd2("CantidadC").ToString, resta, FormatNumber(rd2("Precio").ToString, 2), FormatNumber(rd2("Total").ToString), 2)

                        precio = rd2("Precio").ToString
                        cantidad = rd2("Cantidad").ToString
                        pagadas = rd2("CantidadC").ToString

                        total = total + FormatNumber(CDec(precio * cantidad), 2)
                        totalpagasdas = totalpagasdas + FormatNumber(CDec(precio * pagadas), 2)
                    Loop
                    rd2.Close()
                    cnn2.Close()
                    txtvendidos.Text = FormatNumber(total, 2)
                    txtpagados.Text = FormatNumber(totalpagasdas, 2)
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn2.Close()
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        DataGridView1.Rows.Clear()
        ComboBox1.Text = ""
        txtpagados.Text = "0.00"
        txtvendidos.Text = "0.00"
    End Sub

    Private Sub btncatalogo_Click(sender As Object, e As EventArgs) Handles btncatalogo.Click
        If DataGridView1.Rows.Count = 0 Then
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

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = DataGridView1.ColumnCount
            Dim NRow As Integer = DataGridView1.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = DataGridView1.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = DataGridView1.Rows(Fila).Cells(Col).Value.ToString
                Next
            Next

            Dim Fila2 As Integer = Fila + 2
            Dim Col2 As Integer = Col

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

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        txtvendidos.Text = "0.00"
        txtpagados.Text = "0.00"
        DataGridView1.Rows.Clear()
        Button3.Focus.Equals(True)
    End Sub

    Private Sub frmRepConsignacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class