Imports System.Security.Cryptography

Public Class frmRepSeries

    Dim id As Integer = 0
    Dim Codigo As String = ""
    Dim nombre As String = ""
    Dim serie As String = ""
    Dim Factura As String = ""
    Dim ffactura As String = ""
    Dim nota As String = ""
    Dim fnota As String = ""
    Dim status As String = ""
    Dim esta As String = ""


    Dim desde As Date = Nothing
    Dim hasta As Date = Nothing
    Private Sub frmRepSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbproductos.Checked = True
    End Sub

    Private Sub rbseries_Click(sender As Object, e As EventArgs) Handles rbseries.Click

        Try
            If rbseries.Checked = True Then
                grdseries.Rows.Clear()
                rbproductos.Checked = False
                rbcompras.Checked = False
                rbventas.Checked = False
                cbodatos.Items.Clear()
                cbodatos.Text = ""
                cbodatos.Visible = False

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select * from Series"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        id = rd1("Id").ToString
                        Codigo = rd1("Codigo").ToString
                        serie = rd1("Serie").ToString
                        Factura = rd1("Factura").ToString
                        status = rd1("Status").ToString

                        If status = 1 Then
                            esta = "VENDIDO"
                        Else
                            esta = "DISPONIBLE"
                        End If


                        If rd1("FFactura").ToString = "" Then
                            ffactura = ""
                        Else
                            ffactura = FormatDateTime(rd1("FFactura").ToString, DateFormat.ShortDate)
                        End If
                        nota = rd1("NumNota").ToString
                        If rd1("FechaEliminado").ToString = "" Then
                            fnota = ""
                        Else
                            fnota = FormatDateTime(rd1("FechaEliminado").ToString, DateFormat.ShortDate)
                        End If
                        grdseries.Rows.Add(Codigo, serie, Factura, ffactura, nota, fnota, esta)
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

    Private Sub rbproductos_Click(sender As Object, e As EventArgs) Handles rbproductos.Click

        If rbproductos.Checked = True Then
            grdseries.Rows.Clear()
            rbseries.Checked = False
            rbcompras.Checked = False
            rbventas.Checked = False
            cbodatos.Items.Clear()
            cbodatos.Text = ""
            cbodatos.Visible = True
        End If

    End Sub

    Private Sub rbcompras_Click(sender As Object, e As EventArgs) Handles rbcompras.Click
        If rbcompras.Checked = True Then
            grdseries.Rows.Clear()
            rbventas.Checked = False
            rbseries.Checked = False
            rbventas.Checked = False
            cbodatos.Items.Clear()
            cbodatos.Text = ""
            cbodatos.Visible = True
        End If
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
        If grdseries.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("¿Desea exportar la información a Excel?", vbInformation + vbOKCancel, "Delsscom® control Negocios 2022") = vbCancel Then Exit Sub

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
            Dim NCol As Integer = grdseries.ColumnCount
            Dim NRow As Integer = grdseries.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = grdseries.Columns(i - 1).HeaderText.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila = 0 To NRow - 1
                For Col = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = grdseries.Rows(Fila).Cells(Col).Value.ToString
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

    Private Sub cbodatos_DropDown(sender As Object, e As EventArgs) Handles cbodatos.DropDown

        cbodatos.Items.Clear()

        Try
            If rbproductos.Checked = True Then
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT DISTINCT Nombre FROM Series where Nombre<>'' order by Nombre"
                rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cbodatos.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()

            End If

            If rbcompras.Checked = True Then
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT DISTINCT Factura FROM Series order by Factura"
                rd5 = cmd5.ExecuteReader
                Do While rd5.Read
                    If rd5.HasRows Then
                        cbodatos.Items.Add(rd5(0).ToString)
                    End If
                Loop
                rd5.Close()
                cnn5.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try


    End Sub

    Private Sub cbodatos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodatos.SelectedValueChanged

        grdseries.Rows.Clear()

        Try
            If rbproductos.Checked = True Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT * FROM Series WHERE Nombre='" & cbodatos.Text & "' order by Codigo"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then
                        Codigo = rd2("Codigo").ToString
                        nombre = rd2("Nombre").ToString
                        serie = rd2("Serie").ToString
                        Factura = rd2("Factura").ToString
                        status = rd2("Status").ToString

                        If status = 1 Then
                            esta = "VENDIDO"
                        Else
                            esta = "DISPONIBLE"
                        End If

                        If rd2("FFactura").ToString = "" Then
                        Else

                            ffactura = FormatDateTime(rd2("FFactura").ToString, DateFormat.ShortDate)
                        End If
                        nota = rd2("NumNota").ToString

                        If rd2("FSalida").ToString = "" Then
                        Else

                            fnota = FormatDateTime(rd2("FSalida").ToString, DateFormat.ShortDate)
                        End If


                        grdseries.Rows.Add(Codigo, nombre, serie, Factura, ffactura, nota, fnota, esta)
                    End If
                Loop
                rd2.Close()
                cnn2.Close()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click

        desde = mcdesde.SelectionStart.ToShortDateString
        hasta = mchasta.SelectionStart.ToShortDateString
        Try
            If rbcompras.Checked = True Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Series WHERE FFactura>='" & Format(desde, "dd/MM/yyyy") & "' AND FFactura<='" & Format(hasta, "dd/MM/yyyy") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Codigo = rd1("Codigo").ToString
                        nombre = rd1("Nombre").ToString
                        serie = rd1("Serie").ToString
                        Factura = rd1("Factura").ToString
                        ffactura = rd1("FFactura").ToString
                        nota = rd1("NumNota").ToString
                        fnota = rd1("FSalida").ToString
                        status = rd1("Status").ToString

                        If status = 1 Then
                            esta = "VENDIDO"
                        Else
                            esta = "DISPONIBLE"
                        End If

                        grdseries.Rows.Add(Codigo, nombre, serie, Factura, ffactura, nota, fnota, esta)
                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            End If


            If rbventas.Checked = True Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Series WHERE FSalida>='" & Format(desde, "dd/MM/yyyy") & "' AND FSalida<='" & Format(hasta, "dd/MM/yyyy") & "'"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then
                        Codigo = rd1("Codigo").ToString
                        nombre = rd2("Nombre").ToString
                        serie = rd1("Serie").ToString
                        Factura = rd1("Factura").ToString
                        ffactura = rd1("FFactura").ToString
                        nota = rd1("NumNota").ToString
                        fnota = rd1("FSalida").ToString
                        status = rd1("Status").ToString

                        If status = 1 Then
                            esta = "VENDIDO"
                        Else
                            esta = "DISPONIBLE"
                        End If

                        grdseries.Rows.Add(Codigo, nombre, serie, Factura, ffactura, nota, fnota, esta)
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

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub rbventas_Click(sender As Object, e As EventArgs) Handles rbventas.Click
        If rbventas.Checked = True Then
            grdseries.Rows.Clear()
            rbproductos.Checked = False
            rbseries.Checked = False
            rbcompras.Checked = False
            cbodatos.Items.Clear()
            cbodatos.Text = ""
            cbodatos.Visible = False
            TABLAS()

            cnn1.Close() : cnn1.Open()

            cnn2.Close() : cnn2.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM VentasDetalle WHERE Serie<>'' ORDER BY Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT * FROM Ventas WHERE Folio=" & rd1("Folio").ToString & ""
                    rd2 = cmd2.ExecuteReader
                    Do While rd2.Read
                        If rd2.HasRows Then
                            grdseries.Rows.Add(rd1("Folio").ToString,
                                      rd1("Codigo").ToString,
                                      rd1("Nombre").ToString,
                                      FormatNumber(rd1("Precio").ToString, 2),
                                      rd1("Serie").ToString,
                                      rd2("Usuario").ToString,
                                      FormatDateTime(rd1("Fecha").ToString, DateFormat.ShortDate)
                   )
                        End If
                    Loop
                    rd2.Close()

                End If
            Loop
        End If
        cnn2.Close()
        rd1.Close()
        cnn1.Close()

    End Sub

    Public Sub TABLAS()
        grdseries.Rows.Clear()
        grdseries.ColumnCount = 0
        My.Application.DoEvents()

        grdseries.ColumnCount = 7

        With grdseries
            With .Columns(0)
                .HeaderText = "Folio"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(1)
                .HeaderText = "Código"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(2)
                .HeaderText = "Descripción"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(3)
                .HeaderText = "Precio"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
            With .Columns(4)
                .HeaderText = "Serie"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(5)
                .HeaderText = "Usuario"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With

            With .Columns(6)
                .HeaderText = "Fecha"
                .Width = "50"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .Visible = True
                .Resizable = DataGridViewTriState.False
            End With
        End With
    End Sub
End Class