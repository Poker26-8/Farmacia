Public Class edita_desc

    Public varidprodd As String = ""
    Public varclid As Integer = 0
    Private Sub edita_desc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmfacturacion.Enabled = False
        varidprodd = frmfacturacion.grid_prods.CurrentRow.Cells(0).Value.ToString()
        varclid = frmfacturacion.Cmb_RazonS.SelectedValue
        lbl_producto.Text = frmfacturacion.grid_prods.CurrentRow.Cells(1).Value.ToString
        recupera()
    End Sub

    Private Sub edita_desc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmfacturacion.Enabled = True
    End Sub

    Private Sub modifica()
        frmfacturacion.grid_prods.CurrentRow.Cells(12).Value = RichTextBox1.Text
        MsgBox("Guardado Correctamente")
    End Sub

    Private Sub recupera()
        RichTextBox1.Text = frmfacturacion.grid_prods.CurrentRow.Cells(12).Value
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_guarda_Click(sender As Object, e As EventArgs) Handles btn_guarda.Click
        frmfacturacion.Cmb_Nfactura.Text = ""
        modifica()
    End Sub
End Class