Public Class logdelsscom
    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        If pass_txt.Text = "jipl22" Then
            datos_delsscom.Show()
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub logdelsscom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class