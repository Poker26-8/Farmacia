Public Class frmTraspasarProducto

    Private filaSeleccionada As New Dictionary(Of Integer, Boolean)()
    Private Sub frmTraspasarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cantidad,Codigo,Nombre FROM comandas WHERE Nmesa='" & lblOrigen.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
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
End Class