Public Class frmSeries
    Private Sub frmSeries_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclave.KeyPress


        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                Dim activo As Integer = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Status,Alias FROM usuarios WHERE Clave='" & txtclave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        activo = rd1(0).ToString

                        If activo = 1 Then
                            lblusuario.Text = rd1(1).ToString
                        Else
                            MsgBox("El usuario esta inactivo contacta a tu administrador", vbInformation + vbOKOnly, titulocentral)
                            txtclave.Focus.Equals(True)
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("La clave es incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtclave.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub cbodesc_DropDown(sender As Object, e As EventArgs) Handles cbodesc.DropDown
        Try
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM Productos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbodesc.Items.Add(rd5(0).ToString)
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