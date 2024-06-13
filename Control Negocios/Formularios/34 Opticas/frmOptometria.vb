Public Class frmOptometria
    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick
        Me.Text = Strings.Space(50) & Date.Now
        lblFecha.Text = FormatDateTime(Date.Now, DateFormat.ShortDate)
    End Sub

    Private Sub frmOptometria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFecha.Start()
    End Sub
End Class