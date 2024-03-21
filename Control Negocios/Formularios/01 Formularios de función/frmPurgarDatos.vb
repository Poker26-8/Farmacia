Public Class frmPurgarDatos
    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Try
            cnn1.Close() : cnn1.Open()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class