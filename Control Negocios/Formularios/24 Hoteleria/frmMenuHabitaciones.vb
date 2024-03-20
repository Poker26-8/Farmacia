Public Class frmMenuHabitaciones
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmManejo.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmAdministracion.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnprecios.Click
        frmPrecioH.Show()
        frmPrecioH.BringToFront()
    End Sub

    Private Sub frmMenuHabitaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreciosHab FROM permisos WHERE IdEmpleado=" & id_usu_log
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = "1" Then
                        btnprecios.Enabled = True
                    Else
                        btnprecios.Enabled = False
                    End If
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