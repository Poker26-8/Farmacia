Public Class frmTraspasarProducto

    Private filaSeleccionada As New Dictionary(Of Integer, Boolean)()

    Dim fecha As Date = Nothing
    Dim fechanueva As String = ""
    Private Sub frmTraspasarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cantidad,Codigo,Nombre,Fecha FROM comandas WHERE Nmesa='" & lblOrigen.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    fecha = rd1(3).ToString
                    fechanueva = Format(fecha, "yyyy-MM-dd")

                    grdCaptura.Rows.Add(FormatNumber(rd1(0).ToString, 2),
                                        rd1(1).ToString,
                                        rd1(2).ToString,
                                        "1.00"
)
                End If
            Loop
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Function FilasSeleccionadas() As List(Of DataGridViewRow)
        Dim filas As New List(Of DataGridViewRow)()

        For Each row As DataGridViewRow In grdCaptura.Rows
            If filaSeleccionada.ContainsKey(row.Index) AndAlso filaSeleccionada(row.Index) Then
                If row.DefaultCellStyle.BackColor = Color.Red Then
                    filas.Add(row)
                End If
            End If
        Next

        Return filas
    End Function

    Private Sub grdCaptura_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdCaptura.CellContentClick
        ' Verificar si se hizo clic en la columna del botón "Eliminar"
        If e.ColumnIndex = grdCaptura.Columns(4).Index AndAlso e.RowIndex >= 0 Then
            ' Verificar si la fila ya ha sido seleccionada
            If Not filaSeleccionada.ContainsKey(e.RowIndex) Then
                ' La fila aún no ha sido seleccionada, cambiar el color de fondo a uno
                ' y registrar que ha sido seleccionada
                grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red ' Cambiar a un color
                filaSeleccionada.Add(e.RowIndex, True)
            Else
                ' La fila ya ha sido seleccionada, cambiar el color de fondo a otro
                ' y actualizar su estado
                If filaSeleccionada(e.RowIndex) Then
                    grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White ' Cambiar a otro color
                    filaSeleccionada(e.RowIndex) = False
                Else
                    grdCaptura.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red ' Cambiar a otro color
                    filaSeleccionada(e.RowIndex) = True
                End If
            End If
        End If
    End Sub

    Private Sub btnDestino_Click(sender As Object, e As EventArgs) Handles btnDestino.Click
        frmTecladoMesas.Show()
        frmTecladoMesas.BringToFront()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If lblDestino.Text = "" Then MsgBox("Debe seleccionar una mesa de destino") : btnDestino.Focus.Equals(True) : Exit Sub

        ' Obtener las filas seleccionadas con color rojo
        Dim filasSeleccionadas As List(Of DataGridViewRow) = Me.FilasSeleccionadas()

        ' Agregar las filas al otro DataGridView (grdOtro)
        For Each row As DataGridViewRow In filasSeleccionadas
            grd2.Rows.Add(row.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value).ToArray())
        Next

        ' Limpiar las filas seleccionadas en el DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            filaSeleccionada(row.Index) = False
            row.DefaultCellStyle.BackColor = grdCaptura.DefaultCellStyle.BackColor ' Cambiar al color por defecto
        Next

        ' Eliminar las filas seleccionadas del DataGridView original
        For Each row As DataGridViewRow In filasSeleccionadas
            ' Eliminar la fila del DataGridView
            grdCaptura.Rows.Remove(row)
            ' Limpiar la selección y restaurar el color de fondo en el diccionario y en la fila
            filaSeleccionada.Remove(row.Index)
        Next
        My.Application.DoEvents()



        If grd2.Rows.Count > 0 Then

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO comanda1(Folio,IdCliente,Nombre,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,TComensales) VALUES(0,0,'" & lblDestino.Text & "','',0,0,0,0,0,0,0,'','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',1)"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                For luffy As Integer = 0 To grd2.Rows.Count - 1

                    Dim cod As String = grd2.Rows(luffy).Cells(1).Value.ToString

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE comandas SET Nmesa='" & lblDestino.Text & "' WHERE Nmesa='" & lblOrigen.Text & "' AND Codigo='" & cod & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE rep_comandas SET NMESA='" & lblDestino.Text & "' WHERE NMESA='" & lblOrigen.Text & "' AND Codigo='" & cod & "' AND Fecha='" & fechanueva & "'"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()
                Next
                MsgBox("Proceso concluido correctamente", vbInformation + vbOKOnly, titulorestaurante)
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        Else
            Exit Sub
        End If

    End Sub
End Class