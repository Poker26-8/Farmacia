Public Class frmPagarT
    Private Sub btnpagar_Click(sender As Object, e As EventArgs) Handles btnpagar.Click
        MsgBox("canciones pa llorar")
    End Sub

    Private Sub frmPagarT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub frmPagarT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.A) Then
            btnpagar.PerformClick()
        End If

    End Sub
End Class