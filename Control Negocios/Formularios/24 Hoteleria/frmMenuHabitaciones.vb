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
End Class