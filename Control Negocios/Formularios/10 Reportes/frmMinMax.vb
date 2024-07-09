Public Class frmMinMax
    Private Sub optProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles optProveedor.CheckedChanged
        If (optProveedor.Checked) Then
            Limpia()
            cbofiltro.Enabled = True
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optDepartamento_CheckedChanged(sender As Object, e As EventArgs) Handles optDepartamento.CheckedChanged
        If (optDepartamento.Checked) Then
            Limpia()
            cbofiltro.Enabled = True
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles optGrupo.CheckedChanged
        If (optGrupo.Checked) Then
            Limpia()
            cbofiltro.Enabled = True
            cbofiltro.Focus().Equals(True)
        End If
    End Sub

    Private Sub optTodos_CheckedChanged(sender As Object, e As EventArgs) Handles optTodos.CheckedChanged
        If (optTodos.Checked) Then
            Limpia()
            cbofiltro.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (optProveedor.Checked = True Or optDepartamento.Checked = True Or optGrupo.Checked = True) And cbofiltro.Text = "" Then MsgBox("Selecciona un registro para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbofiltro.Focus().Equals(True) : Exit Sub

        Dim fecha_inicio As Date = Nothing
        Dim fecha_final As Date = Date.Now

        Dim diferencia_dias As Integer = 0

        'Primero consulta la fecha del último reporte.
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='MinMax'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = "" Then
                        If MsgBox("No se asignó una fecha de inicio para el cálculo." & vbNewLine & "Se tomará la fecha de inicio de operaciones ¿desea continuar?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") Then
                            fecha_inicio = Asigna_Inicio(fecha_inicio)
                        End If
                    Else
                        fecha_inicio = rd1(0).ToString()
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        If fecha_inicio = Nothing Then Exit Sub

        'Saca los días de diferencia
        diferencia_dias = DateDiff(DateInterval.Day, fecha_inicio, fecha_final)

        Label2.Text = "Dias consultados: " & diferencia_dias
        My.Application.DoEvents()

        grdcaptura.ColumnHeadersVisible = True

        'Comienza la consulta de productos vendidos (dependiendo la opción seleccionada)
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If optProveedor.Checked = True Then
                cmd1.CommandText =
                "SELECT DISTINCT(V.Codigo) FROM VentasDetalle V INNER JOIN Productos P WHERE V.Codigo=P.Codigo AND P.ProvPri='" & cbofiltro.Text & "' and (V.Fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_final, "yyyy-MM-dd") & "')"
            End If
            If optDepartamento.Checked = True Then
                cmd1.CommandText =
                "SELECT DISTINCT(V.Codigo) FROM VentasDetalle WHERE Depto='" & cbofiltro.Text & "' and (Fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_final, "yyyy-MM-dd") & "')"
            End If
            If optGrupo.Checked = True Then
                cmd1.CommandText =
                "SELECT DISTINCT(Codigo) FROM VentasDetalle WHERE Grupo='" & cbofiltro.Text & "' and (Fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_final, "yyyy-MM-dd") & "')"
            End If
            If optTodos.Checked = True Then
                cmd1.CommandText =
                "SELECT DISTINCT(Codigo) FROM VentasDetalle WHERE (Fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_final, "yyyy-MM-dd") & "')"
            End If

            cnn2.Close() : cnn2.Open()

            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    Dim Codigo As String = rd1(0).ToString()
                    Dim nombre As String = ""
                    Dim unidad As String = ""
                    Dim existencia As Double = 0
                    Dim cantidad As Double = 0

                    Dim t_entrega As Double = 0

                    Dim promedio_venta As Double = 0

                    Dim min_r As Double = 0
                    Dim max_r As Double = 0

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select * from Productos where Codigo='" & Codigo & "'"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            nombre = rd2("Nombre").ToString()
                            unidad = rd2("UVenta").ToString()
                            existencia = rd2("Existencia").ToString()
                            t_entrega = rd2("T_Entrega").ToString()
                        End If
                    End If
                    rd2.Close()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "select SUM(Cantidad) from VentasDetalle where Codigo='" & Codigo & "' and (Fecha BETWEEN '" & Format(fecha_inicio, "yyyy-MM-dd") & "' AND '" & Format(fecha_final, "yyyy-MM-dd") & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            cantidad = rd2(0).ToString()
                        End If
                    End If
                    rd2.Close()

                    promedio_venta = cantidad / diferencia_dias
                    min_r = promedio_venta * t_entrega
                    max_r = min_r * 2

                    grdcaptura.Rows.Add(Codigo, nombre, unidad, existencia, cantidad, FormatNumber(promedio_venta, 2), t_entrega, FormatNumber(min_r, 0), FormatNumber(max_r, 0))
                End If
            Loop
            rd1.Close()

            cnn2.Close()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

    End Sub

    Private Function Asigna_Inicio(ByRef fecha As Date)
        Dim folio As Integer = 0

        Try
            cnn2.Close() : cnn2.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select MIN(Folio) from Ventas"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    folio = rd2(0).ToString()
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select FVenta from Ventas where Folio=" & folio
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    fecha = rd2(0).ToString()
                End If
            Else
                MsgBox("No fue posible asignar la fecha de inicio del cálculo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn2.Close()
        End Try
        Return fecha
    End Function

    Private Sub Limpia()
        cbofiltro.Items.Clear()
        cbofiltro.Text = ""
        grdcaptura.Rows.Clear()
        Label2.Text = "Dias consultados:"
    End Sub

    Private Sub frmMinMax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SFormatos("MinMax", "")
    End Sub

    Private Sub cbofiltro_DropDown(sender As Object, e As EventArgs) Handles cbofiltro.DropDown
        cbofiltro.Items.Clear()
        Limpia()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            If (optProveedor.Checked) Then
                cmd1.CommandText =
                    "select distinct ProvPri from Productos where ProvPri<>''"
            End If
            If (optDepartamento.Checked) Then
                cmd1.CommandText =
                    "select distinct Departamento from Productos where Departamento <> 'SERVICIOS' and Departamento<>''"
            End If
            If (optGrupo.Checked) Then
                cmd1.CommandText =
                    "select distinct Grupo from Productos where Grupo<>''"
            End If
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cbofiltro.Items.Add(rd1(0).ToString)
                End If
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbofiltro_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbofiltro.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button1.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbofiltro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbofiltro.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            If (optProveedor.Checked) Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select SUM(T_Entrega) from Productos where ProvPri='" & cbofiltro.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString() = 0 Then
                            Button3.Visible = True
                        Else
                            Button3.Visible = False
                        End If
                    End If
                Else
                    Button3.Visible = True
                End If
            End If
            rd1.Close()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox1.Visible = True
        TextBox1.Focus().Equals(True)
        lblprove.Text = cbofiltro.Text
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox1.Text = "0" Then MsgBox("Ingrese un tiempo de entrega válido.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : TextBox1.Focus().Equals(True) : TextBox1.SelectAll() : Exit Sub

        If MsgBox("¿Deseas asignar el tiempo de entrega a este proveedor?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand

                If (optProveedor.Checked) Then
                    cmd2.CommandText =
                   "update Productos set T_Entrega=" & TextBox1.Text & " where ProvPri='" & cbofiltro.Text & "'"
                End If

                If (optDepartamento.Checked) Then
                    cmd2.CommandText = "UPDATE Productos SET T_Entrega=" & TextBox1.Text & " WHERE Departamento='" & cbofiltro.Text & "'"
                End If

                If (optGrupo.Checked) Then
                    cmd2.CommandText = "UPDATE Productos SET T_Entrega=" & TextBox1.Text & " WHERE Grupo='" & cbofiltro.Text & "'"
                End If

                If (optTodos.Checked) Then
                    cmd2.CommandText = "UPDATE Productos SET T_Entrega=" & TextBox1.Text & ""
                End If

                If cmd2.ExecuteNonQuery() Then
                    lblprove.Text = ""
                    TextBox1.Text = "0"
                    GroupBox1.Visible = False
                End If

                GroupBox1.Visible = False
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gbFecha.Visible = True
    End Sub

    Private Sub btnGFecha_Click(sender As Object, e As EventArgs) Handles btnGFecha.Click

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "select NotasCred from Formatos where Facturas='MinMax'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE Formatos SET NotasCred='" & dtpFecha.Value & "' WHERE Facturas='MinMax'"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Fecha de inicio actualizada", vbInformation + vbOKOnly, titulocentral)
                    gbFecha.Visible = False
                End If
                cnn2.Close()
            End If
        End If
        rd1.Close()
        cnn1.Close()

    End Sub

    Private Sub btnCance_Click(sender As Object, e As EventArgs) Handles btnCance.Click
        GroupBox1.Visible = False
    End Sub

    Private Sub btnCanceF_Click(sender As Object, e As EventArgs) Handles btnCanceF.Click
        gbFecha.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
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

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim INDEX As Integer = grdcaptura.CurrentRow.Index
        Dim COD As String = grdcaptura.Rows(INDEX).Cells(0).Value.ToString

        Dim codbarra As String = ""

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT CodBarra FROM productos WHERE Codigo='" & COD & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                codbarra = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        frmComparador.txtCodBarra.Text = codbarra
        frmComparador.Show()
        frmComparador.BringToFront()
    End Sub
End Class