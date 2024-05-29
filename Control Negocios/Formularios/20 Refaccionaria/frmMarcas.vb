Public Class frmMarcas
    Private Sub btnAlmacenar_Click(sender As Object, e As EventArgs) Handles btnAlmacenar.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM marcas WHERE Nombre='" & txtmarca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE marcas SET Nombre='" & txtMarca.Text & "' WHERE Id=" & lblId.Text
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Marca agregada correctamente", vbInformation + vbInformation, titulorefaccionaria)
                        txtMarca.Text = ""
                        txtMarca.Focus.Equals(True)
                    End If
                    cnn2.Close()
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

            If MsgBox("¿Desea continuar con el proceso?", vbInformation + vbYesNo) = vbYes Then

                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM marcas WHERE Nombre='" & txtMarca.Text & "'"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Marca eliminada correctamente", vbInformation + vbOKOnly, titulorefaccionaria)
                    cnn2.Close()
                    txtMarca.Text = ""
                    txtMarca.Focus.Equals(True)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtMarca_DropDown(sender As Object, e As EventArgs) Handles txtMarca.DropDown
        Try
            txtMarca.Controls.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT(Nombre) FROM marcas WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    txtMarca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAlmacenar.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtMarca_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtMarca.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id FROM marcas WHERE Nombre='" & txtMarca.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblId.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class