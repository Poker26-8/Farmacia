Public Class frmEnviarPDF

    Public archivoadj As String = ""
    Public archivoadj2 As String = ""


    Private Sub btnenvia_Click(sender As Object, e As EventArgs) Handles btnenvia.Click
        'varnomemail = frmfacturacion.cbo_emisor.Text
        envioPDF(txtpara.Text, txtasunto.Text, txtmensaje.Text, archivoadj)
        Me.Close()
    End Sub

    Private Sub link_archivo_Click(sender As Object, e As EventArgs) Handles link_archivo.Click
        Process.Start(archivoadj)
    End Sub

    Private Sub btncancela_Click(sender As Object, e As EventArgs) Handles btncancela.Click
        Me.Close()
    End Sub

    Private Sub txtpara_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpara.KeyPress
        e.KeyChar = Char.ToLower(e.KeyChar)
        nextPress(Asc(e.KeyChar))
    End Sub



    Private Sub frmEnviarPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class