Public Class frmMesasNueva

    Friend WithEvents btnMesaN As System.Windows.Forms.Button
    Private Sub frmMesasNueva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Propias FROM permisosm"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = 1 Then
                        pubicacion.Visible = True
                        Mesas()
                    Else
                        pubicacion.Visible = False
                        Mesas()
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

    Public Sub Mesas()

        Try

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try

    End Sub
End Class