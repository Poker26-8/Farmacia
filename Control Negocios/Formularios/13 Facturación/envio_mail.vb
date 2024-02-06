Public Class envio_mail
    Public archivoadj As String = ""
    Public archivoadj2 As String = ""

    Private Sub link_archivo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_archivo.LinkClicked
        Process.Start(archivoadj)
    End Sub

    Private Sub btnenvia_Click(sender As Object, e As EventArgs) Handles btnenvia.Click
        varnomemail = frmfacturacion.cbo_emisor.Text
        envio(txtpara.Text, txtasunto.Text, txtmensaje.Text, archivoadj, archivoadj2)
        Me.Close()
    End Sub

    Private Sub btncancela_Click(sender As Object, e As EventArgs) Handles btncancela.Click
        Me.Close()
    End Sub

    Private Sub txtpara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpara.KeyPress
        e.KeyChar = Char.ToLower(e.KeyChar)
        nextPress(Asc(e.KeyChar))
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If archivoadj2 <> "" Then
            Process.Start(archivoadj2)
        Else
            MsgBox("No Hay Archivo XML")
        End If
    End Sub

    Private Sub envio_mail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class