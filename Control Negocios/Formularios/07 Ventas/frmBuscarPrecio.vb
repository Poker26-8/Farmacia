Public Class frmBuscarPrecio
    Public pantalla As String = ""
    Public codigop As String = ""
    Public nombrep As String = ""

    Dim precioseleccionado As Double = 0
    Private Sub frmBuscarPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PrecioVentaIVA1,PrecioVentaIVA2,PrecioVentaIVA3 FROM productos WHERE Codigo='" & codigop & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    grdPrecio.Rows.Add(codigop,
                                       nombrep,
                                       rd1(0).ToString,
                                       rd1(1).ToString,
                                       rd1(2).ToString
                                       )
                End If
            End If

            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub grdPrecio_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPrecio.CellClick

        Dim celda As DataGridViewCellEventArgs = e
        precioseleccionado = 0
        If celda.ColumnIndex = 2 Then
            precioseleccionado = grdPrecio.CurrentRow.Cells(2).Value.ToString
        End If

        If celda.ColumnIndex = 3 Then
            precioseleccionado = grdPrecio.CurrentRow.Cells(3).Value.ToString
        End If

        If celda.ColumnIndex = 4 Then
            precioseleccionado = grdPrecio.CurrentRow.Cells(4).Value.ToString
        End If

        MsgBox(precioseleccionado)

        If pantalla = "Ventas Series" Then
            frmVentas_Series.txtprecio.Text = precioseleccionado
            Me.Close()
        End If


    End Sub
End Class