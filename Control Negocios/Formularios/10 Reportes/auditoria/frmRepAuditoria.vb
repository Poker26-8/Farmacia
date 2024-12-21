Public Class frmRepAuditoria
    Private Sub frmRepAuditoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbofiltro.Text = ""
    End Sub

    Private Sub cbofiltro_DropDown(sender As Object, e As EventArgs) Handles cbofiltro.DropDown
        Try
            cbofiltro.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand

            If (rbexistencias.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Usuario FROM cardex WHERE Usuario<>'' ORDER BY Usuario"
            End If

            If (rbprecios.Checked) Then
                cmd5.CommandText = "SELECT DISTINCT Usuario FROM modprecios WHERE Usuario<>'' ORDER BY Usuario"
            End If

            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    cbofiltro.Items.Add(rd5(0).ToString)
                End If
            End If
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            grdCaptura.Rows.Clear()

            Dim M1 As Date = mcdesde.SelectionStart.ToShortDateString
            Dim M2 As Date = mchasta.SelectionStart.ToShortDateString

            If (rbLotes.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cbofiltro.Text = "" Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Movimiento,Final,Fecha,Usuario,Inicial FROM cardex WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' and Movimiento='Ajuste de lotes' order by Id"
                Else
                    cmd1.CommandText = "SELECT Codigo,Nombre,Movimiento,Final,Fecha,Usuario,Inicial FROM cardex WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' AND Usuario='" & cbofiltro.Text & "' and Movimiento='Ajuste de lotes' order by Id"
                End If

                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                            rd1("Nombre").ToString,
                                            rd1("Movimiento").ToString,
                                            rd1("Inicial").ToString,
                                            rd1("Final").ToString,
                                            rd1("Fecha").ToString,
                                            rd1("Usuario").ToString
)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If
            If (rbexistencias.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cbofiltro.Text = "" Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Movimiento,Final,Fecha,Usuario FROM cardex WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' and Movimiento<>'Ajuste de lotes' order by Id"
                Else
                    cmd1.CommandText = "SELECT Codigo,Nombre,Movimiento,Final,Fecha,Usuario FROM cardex WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' AND Usuario='" & cbofiltro.Text & "' and Movimiento<>'Ajuste de lotes' order by Id"
                End If

                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                            rd1("Nombre").ToString,
                                            rd1("Movimiento").ToString,
                                            rd1("Final").ToString,
                                            rd1("Fecha").ToString,
                                            rd1("Usuario").ToString
)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

            If (rbprecios.Checked) Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand

                If cbofiltro.Text = "" Then
                    cmd1.CommandText = "SELECT Codigo,Nombre,Nuevo,Fecha,Usuario FROM modprecios WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' order by Id"
                Else
                    cmd1.CommandText = "SELECT Codigo,Nombre,Nuevo,Fecha,Usuario FROM modprecios WHERE Fecha between '" & Format(M1, "yyyy-MM-dd 00:00:00") & "' and '" & Format(M2, "yyyy-MM-dd 23:59:59") & "' AND Usuario='" & cbofiltro.Text & "' order by Id"
                End If

                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        grdCaptura.Rows.Add(rd1("Codigo").ToString,
                                            rd1("Nombre").ToString,
                                            rd1("Nuevo").ToString,
                                            rd1("Fecha").ToString,
                                            rd1("Usuario").ToString()
                        )

                    End If
                Loop
                rd1.Close()
                cnn1.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub rbexistencias_CheckedChanged(sender As Object, e As EventArgs) Handles rbexistencias.CheckedChanged

        If (rbexistencias.Checked) Then
            cbofiltro.Text = ""
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0

            grdCaptura.ColumnCount = 6
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Descripción"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Movimiento"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Cantidad Actualizada"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

            End With

        End If
    End Sub

    Private Sub rbprecios_CheckedChanged(sender As Object, e As EventArgs) Handles rbprecios.CheckedChanged
        If (rbprecios.Checked) Then
            cbofiltro.Text = ""
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0

            grdCaptura.ColumnCount = 5
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Descripción"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Precio Nuevo"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(3)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
            End With
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        grdCaptura.Rows.Clear()
        cbofiltro.Text = ""
        rbexistencias.Checked = True
        rbprecios.Checked = False
        rbLotes.Checked = False
    End Sub

    Private Sub btnexportar_Click(sender As Object, e As EventArgs) Handles btnexportar.Click
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

            Dim Fila As Integer = 0
            Dim Col As Integer = 0

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = grdCaptura.ColumnCount
            Dim NRow As Integer = grdCaptura.RowCount

            exHoja.Columns("A").NumberFormat = "@"
            exHoja.Columns("B").NumberFormat = "@"
            exHoja.Columns("C").NumberFormat = "@"
            exHoja.Columns("D").NumberFormat = "@"
            exHoja.Columns("I").NumberFormat = "@"
            exHoja.Columns("G").NumberFormat = "@"
            exHoja.Columns("K").NumberFormat = "@"
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

    Private Sub rbLotes_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotes.CheckedChanged
        If (rbLotes.Checked) Then
            cbofiltro.Text = ""
            grdCaptura.Rows.Clear()
            grdCaptura.ColumnCount = 0

            grdCaptura.ColumnCount = 7
            With grdCaptura
                With .Columns(0)
                    .HeaderText = "Codigo"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(1)
                    .HeaderText = "Descripción"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(2)
                    .HeaderText = "Movimiento"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With
                With .Columns(3)
                    .HeaderText = "Cantidad Inicial"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(4)
                    .HeaderText = "Cantidad Final"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(5)
                    .HeaderText = "Fecha"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With

                With .Columns(6)
                    .HeaderText = "Usuario"
                    .Width = 80
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .Visible = True
                    .Resizable = DataGridViewTriState.False
                End With


            End With

        End If
    End Sub
End Class