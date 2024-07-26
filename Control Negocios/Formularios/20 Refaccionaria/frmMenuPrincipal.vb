Public Class frmMenuPrincipal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'frmVehiculoR.Show()
        frmVehiculoTa.Show()
        frmVehiculoTa.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'frmProductoR.Show()
        frmAsignarRefa.Show()
        frmAsignarRefa.BringToFront()
        Me.Close()
    End Sub

    Private Sub btnconsultar_Click(sender As Object, e As EventArgs) Handles btnconsultar.Click

        frmConsultarRefaccion.Show()
        frmConsultarRefaccion.BringToFront()
        Me.Close()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmTallerR.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub frmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NumPart FROM formatos WHERE Facturas='Taller'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    If rd1(0).ToString = 1 Then
                        Button1.Enabled = True
                        Button5.Enabled = True
                        Me.Size = New Size(631, 132)
                    Else
                        Me.Size = New Size(431, 132)
                        Button1.Enabled = False
                        Button5.Enabled = False
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmMarcas.Show()
        frmMarcas.BringToFront()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        frmModelos.Show()
        frmModelos.BringToFront()
    End Sub
End Class