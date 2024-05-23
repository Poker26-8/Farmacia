Public Class frmDividir
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frmDivProducto.lblmesa.Text = frmNuevoPagar.lblmesa.Text
        frmDivProducto.lblorigen.Text = frmNuevoPagar.lblmesa.Text
        frmDivProducto.Show()
        frmDivProducto.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmNuevo.Show()
        frmNuevo.BringToFront()
    End Sub
End Class