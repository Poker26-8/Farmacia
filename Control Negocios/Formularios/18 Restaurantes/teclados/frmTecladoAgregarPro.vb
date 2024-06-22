Public Class frmTecladoAgregarPro

    Public comentario As String = ""
    Public CODIGO As String = ""
    Public COMANDA As String = ""

    Private Sub frmTecladoAgregarPro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If comentario = 1 Then
            lblTitulo.Text = "COMENTARIO"
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        txtNombre.Text = CutCad(txtNombre.Text)
    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtNombre.Text = txtNombre.Text + btn0.Text
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtNombre.Text = txtNombre.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtNombre.Text = txtNombre.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtNombre.Text = txtNombre.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtNombre.Text = txtNombre.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtNombre.Text = txtNombre.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtNombre.Text = txtNombre.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtNombre.Text = txtNombre.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtNombre.Text = txtNombre.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtNombre.Text = txtNombre.Text + btn9.Text
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        txtNombre.Text = txtNombre.Text + btnQ.Text
    End Sub

    Private Sub BTNW_Click(sender As Object, e As EventArgs) Handles BTNW.Click
        txtNombre.Text = txtNombre.Text + BTNW.Text
    End Sub

    Private Sub NTNE_Click(sender As Object, e As EventArgs) Handles NTNE.Click
        txtNombre.Text = txtNombre.Text + NTNE.Text
    End Sub

    Private Sub BTNR_Click(sender As Object, e As EventArgs) Handles BTNR.Click
        txtNombre.Text = txtNombre.Text + BTNR.Text
    End Sub

    Private Sub BTNT_Click(sender As Object, e As EventArgs) Handles BTNT.Click
        txtNombre.Text = txtNombre.Text + BTNT.Text
    End Sub

    Private Sub BTNY_Click(sender As Object, e As EventArgs) Handles BTNY.Click
        txtNombre.Text = txtNombre.Text + BTNY.Text
    End Sub

    Private Sub BTNU_Click(sender As Object, e As EventArgs) Handles BTNU.Click
        txtNombre.Text = txtNombre.Text + BTNU.Text
    End Sub

    Private Sub BTNI_Click(sender As Object, e As EventArgs) Handles BTNI.Click
        txtNombre.Text = txtNombre.Text + BTNI.Text
    End Sub

    Private Sub BTNO_Click(sender As Object, e As EventArgs) Handles BTNO.Click
        txtNombre.Text = txtNombre.Text + BTNO.Text
    End Sub

    Private Sub BTNP_Click(sender As Object, e As EventArgs) Handles BTNP.Click
        txtNombre.Text = txtNombre.Text + BTNP.Text
    End Sub

    Private Sub BTNA_Click(sender As Object, e As EventArgs) Handles BTNA.Click
        txtNombre.Text = txtNombre.Text + BTNA.Text
    End Sub

    Private Sub BTNS_Click(sender As Object, e As EventArgs) Handles BTNS.Click
        txtNombre.Text = txtNombre.Text + BTNS.Text
    End Sub

    Private Sub BTND_Click(sender As Object, e As EventArgs) Handles BTND.Click
        txtNombre.Text = txtNombre.Text + BTND.Text
    End Sub

    Private Sub BTNF_Click(sender As Object, e As EventArgs) Handles BTNF.Click
        txtNombre.Text = txtNombre.Text + BTNF.Text
    End Sub

    Private Sub BTNG_Click(sender As Object, e As EventArgs) Handles BTNG.Click
        txtNombre.Text = txtNombre.Text + BTNG.Text
    End Sub

    Private Sub BTNH_Click(sender As Object, e As EventArgs) Handles BTNH.Click
        txtNombre.Text = txtNombre.Text + BTNH.Text
    End Sub

    Private Sub BTNJ_Click(sender As Object, e As EventArgs) Handles BTNJ.Click
        txtNombre.Text = txtNombre.Text + BTNJ.Text
    End Sub

    Private Sub BTNK_Click(sender As Object, e As EventArgs) Handles BTNK.Click
        txtNombre.Text = txtNombre.Text + BTNK.Text
    End Sub

    Private Sub BTNL_Click(sender As Object, e As EventArgs) Handles BTNL.Click
        txtNombre.Text = txtNombre.Text + BTNL.Text
    End Sub

    Private Sub BTNÑ_Click(sender As Object, e As EventArgs) Handles BTNÑ.Click
        txtNombre.Text = txtNombre.Text + BTNÑ.Text
    End Sub

    Private Sub BTNZ_Click(sender As Object, e As EventArgs) Handles BTNZ.Click
        txtNombre.Text = txtNombre.Text + BTNZ.Text
    End Sub

    Private Sub BTNX_Click(sender As Object, e As EventArgs) Handles BTNX.Click
        txtNombre.Text = txtNombre.Text + BTNX.Text
    End Sub

    Private Sub BTNC_Click(sender As Object, e As EventArgs) Handles BTNC.Click
        txtNombre.Text = txtNombre.Text + BTNC.Text
    End Sub

    Private Sub BTNV_Click(sender As Object, e As EventArgs) Handles BTNV.Click
        txtNombre.Text = txtNombre.Text + BTNV.Text
    End Sub

    Private Sub BTNB_Click(sender As Object, e As EventArgs) Handles BTNB.Click
        txtNombre.Text = txtNombre.Text + BTNB.Text
    End Sub

    Private Sub BTNN_Click(sender As Object, e As EventArgs) Handles BTNN.Click
        txtNombre.Text = txtNombre.Text + BTNN.Text
    End Sub

    Private Sub BTNM_Click(sender As Object, e As EventArgs) Handles BTNM.Click
        txtNombre.Text = txtNombre.Text + BTNM.Text
    End Sub

    Private Sub BTNCOMA_Click(sender As Object, e As EventArgs) Handles BTNCOMA.Click
        txtNombre.Text = txtNombre.Text + BTNCOMA.Text
    End Sub

    Private Sub BTNPUNTO_Click(sender As Object, e As EventArgs) Handles BTNPUNTO.Click
        txtNombre.Text = txtNombre.Text + BTNPUNTO.Text
    End Sub

    Private Sub BTNGUION_Click(sender As Object, e As EventArgs) Handles BTNGUION.Click
        txtNombre.Text = txtNombre.Text + BTNGUION.Text
    End Sub

    Private Sub BTNESPACIO_Click(sender As Object, e As EventArgs) Handles BTNESPACIO.Click
        txtNombre.Text = txtNombre.Text + " "
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If comentario = 1 Then

            For q As Integer = 0 To frmNuevoAgregarProductos.grdCaptura.Rows.Count - 1

                If frmNuevoAgregarProductos.grdCaptura.Rows(q).Cells(0).Value = CODIGO Then
                    frmNuevoAgregarProductos.grdCaptura.Rows(q).Cells(8).Value = txtNombre.Text
                End If

            Next

        End If
        Me.Close()
    End Sub
End Class