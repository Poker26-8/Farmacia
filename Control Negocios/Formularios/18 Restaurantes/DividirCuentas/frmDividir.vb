Public Class frmDividir
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frmDivProducto.lblmesa.Text = frmNuevoPagar.lblmesa.Text
        frmDivProducto.lblorigen.Text = frmNuevoPagar.lblmesa.Text
        frmDivProducto.lblmesero.Text = frmNuevoPagar.lblMesero.Text

        frmDivProducto.Show()
        frmDivProducto.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmDivPartes.lblMesa.Text = frmNuevoPagar.lblmesa.Text
        frmDivPartes.Show()
        frmDivPartes.BringToFront()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmDividirCuenta.mesa = frmNuevoPagar.lblmesa.Text
        frmDividirCuenta.Show()
        Me.Close()
    End Sub
End Class