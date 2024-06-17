Public Class frmOptica
    Private Sub btnDoctor_Click(sender As Object, e As EventArgs) Handles btnDoctor.Click
        frmPaciente.Show()
        frmPaciente.BringToFront()
    End Sub

    Private Sub btnOptica_Click(sender As Object, e As EventArgs) Handles btnOptica.Click
        frmRegistros.Show()
        frmRegistros.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class