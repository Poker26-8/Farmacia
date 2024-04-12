Public Class frmMarcas
    Private Sub btnAlmacenar_Click(sender As Object, e As EventArgs) Handles btnAlmacenar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM marcas WHERE Nombre='" & txtmarca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO marcas(Nombre) VALUES('" & txtmarca.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Marca agregada correctamente", vbInformation + vbInformation, titulorefaccionaria)
                    txtmarca.Text = ""
                    txtmarca.Focus.Equals(True)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "DELETE FROM marcas WHERE Nombre='" & txtmarca.Text & "'"
            cmd2.ExecuteNonQuery()
            cnn2.Close()
            txtmarca.Text = ""
            txtmarca.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class