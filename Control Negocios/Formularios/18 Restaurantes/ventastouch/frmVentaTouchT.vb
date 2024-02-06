Public Class frmVentaTouchT

    Public Respuesta As String = ""
    Public listado As Boolean
    Public NombreCampo As String = ""
    Private Sub frmVentaTouchT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Desea Cerrar Esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            frmVentaTouchT.ActiveForm.Close()
        End If
    End Sub

    Private Sub frmVentaTouchT_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        framecampo.Text = "Clave del Vendedor"

        If framecampo.Text = "Clave del Vendedor" Then


            Respuesta = IIf(listado, txtClaveVendedor.Text, txtClaveVendedor.Text)
            If framecampo.Text = "Comentario" Or framecampo.Text = "CANTIDAD" Then
                txtClaveVendedor.Text = ""
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "select NotasCred from Formatos where Facturas='TomaContra'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(0).ToString = 1 Then
                            txtClaveVendedor.Text = ClaveUsuario
                            Respuesta = txtClaveVendedor.Text
                            Me.Close()
                        Else
                            txtClaveVendedor.Text = ""
                            txtClaveVendedor.Focus.Equals(True)
                        End If

                    End If
                End If
                rd1.Close()
                cnn1.Close()
            End If

        Else
            txtClaveVendedor.Focus.Equals(True)
        End If
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn9.Text
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btn0.Text
    End Sub

    Private Sub btnRetro_Click(sender As Object, e As EventArgs) Handles btnRetro.Click
        txtClaveVendedor.Text = ""
        txtClaveVendedor.Focus.Equals(True)
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnQ.Text
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnW.Text
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnE.Text
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnR.Text
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnT.Text
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnY.Text
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnU.Text
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnI.Text
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnO.Text
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnP.Text
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnA.Text
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnS.Text
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnD.Text
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnF.Text
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnG.Text
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnH.Text
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnJ.Text
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnK.Text
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnQ.Text
    End Sub

    Private Sub btnÑ_Click(sender As Object, e As EventArgs) Handles btnÑ.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnÑ.Text
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnZ.Text
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnX.Text
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnC.Text
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnV.Text
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnB.Text
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnN.Text
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnM.Text
    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnComa.Text
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnPunto.Text
    End Sub

    Private Sub btnGuion_Click(sender As Object, e As EventArgs) Handles btnGuion.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnGuion.Text
    End Sub

    Private Sub btnEspacio_Click(sender As Object, e As EventArgs) Handles btnEspacio.Click
        txtClaveVendedor.Text = txtClaveVendedor.Text + btnEspacio.Text
    End Sub

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click
        Dim Area_user As String = ""

        If txtClaveVendedor.Text <> "" Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtClaveVendedor.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ClaveUsuario = rd1("Clave").ToString
                    Area_user = rd1("Alias").ToString
                    id_usu_log = rd1("IdEmpleado").ToString
                    frmVTouchR.lblAtendio.Text = Area_user
                    ' TipoVenta = "MOSTRADOR"
                    'txtClaveVendedor.Text = ""

                    frmVTouchR.Show()
                    Me.Close()
                Else
                    MsgBox("La Clave del vendedor es incorrecta", vbInformation + vbOKOnly, titulomensajes)
                End If
            Else
                MsgBox("La Clave del vendedor es incorrecta", vbInformation + vbOKOnly, titulomensajes)
            End If
            rd1.Close()
            cnn1.Close()
        End If
    End Sub

    Private Sub txtClaveVendedor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClaveVendedor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnIntro.PerformClick()
        End If
    End Sub
End Class