Public Class frmEnvio_Corte
    Public archivoadj As String = ""
    Public archivoadj2 As String = ""

    Private Sub frmEnvio_Corte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub link_archivo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_archivo.LinkClicked
        Process.Start(archivoadj)
    End Sub

    Private Sub btnenvia_Click(sender As Object, e As EventArgs) Handles btnenvia.Click
        varnomemail = "SISTEMA"
        envio_Corte(txtpara.Text, txtasunto.Text, txtmensaje.Text, archivoadj)
        Me.Close()
    End Sub
End Class