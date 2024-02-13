Public Class frmPagarPoo
    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick

        TFolio.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Folio) from Ventas"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblfolio.Text = CDbl(IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString)) + 1
            Else
                lblfolio.Text = "1"
            End If
        Else
            lblfolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()

        TFolio.Start()

    End Sub

    Private Sub frmPagarPoo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFolio.Start()
    End Sub
End Class