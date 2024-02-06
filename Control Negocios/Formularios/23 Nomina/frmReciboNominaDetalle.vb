Public Class frmReciboNominaDetalle
    Private Sub frmReciboNominaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtImporte.Focus()
    End Sub

    Private Sub txtImporte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporte.KeyPress
        solonumeros(e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtCantidad.Text = ""
        txtConcepto.Text = ""
        txtClaveConcepto.Text = ""
        txtImporte.Text = ""
        txtImporteCal.Text = ""
        txtImporteCalEmp.Text = ""
        Me.Close()
    End Sub
End Class