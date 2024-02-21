Public Class frmPasa_Mesa
    Private Sub frmPasa_Mesa_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtclave.Focus.Equals(True)
    End Sub

    Private Sub txtclave_Click(sender As Object, e As EventArgs) Handles txtclave.Click
        txtclave.SelectionStart = 0
        txtclave.SelectionLength = Len(txtclave.Text)
    End Sub
End Class