Public Class frmCorte4
    Private Sub frmCorte4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCalculadora_Click(sender As Object, e As EventArgs) Handles btnCalculadora.Click

    End Sub

    Private Sub cboCajero_DropDown(sender As Object, e As EventArgs) Handles cboCajero.DropDown
        cboCajero.Items.Clear()
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = ""
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCajero.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try

    End Sub
End Class