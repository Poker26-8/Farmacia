Public Class frmTecladoLog

    Private Sub frmTecladoLog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtCampo.Focus().Equals(True)
    End Sub

      Private Sub left_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles izquierda.Click
            txtCampo.Focus().Equals(True)
            My.Computer.Keyboard.SendKeys("{LEFT}", True)
      End Sub

    Private Sub txtUpChase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUpChase.Click
        txtCampo.Focus().Equals(True)
        If btnQ.Text = "q" Then
            btnQ.Text = "Q"
            btnW.Text = "W"
            btnE.Text = "E"
            btnR.Text = "R"
            btnT.Text = "T"
            btnY.Text = "Y"
            btnU.Text = "U"
            btnI.Text = "I"
            btnO.Text = "O"
            btnP.Text = "P"
            btnA.Text = "A"
            btnS.Text = "S"
            btnD.Text = "D"
            btnF.Text = "F"
            btnG.Text = "G"
            btnH.Text = "H"
            btnJ.Text = "J"
            btnK.Text = "K"
            btnL.Text = "L"
            btnÑ.Text = "Ñ"
            btnZ.Text = "Z"
            btnX.Text = "X"
            btnC.Text = "C"
            btnV.Text = "V"
            btnB.Text = "B"
            btnN.Text = "N"
            btnM.Text = "M"
        Else
            btnQ.Text = "q"
            btnW.Text = "w"
            btnE.Text = "e"
            btnR.Text = "r"
            btnT.Text = "t"
            btnY.Text = "y"
            btnU.Text = "u"
            btnI.Text = "i"
            btnO.Text = "o"
            btnP.Text = "p"
            btnA.Text = "a"
            btnS.Text = "s"
            btnD.Text = "d"
            btnF.Text = "f"
            btnG.Text = "g"
            btnH.Text = "h"
            btnJ.Text = "j"
            btnK.Text = "k"
            btnL.Text = "l"
            btnÑ.Text = "ñ"
            btnZ.Text = "z"
            btnX.Text = "x"
            btnC.Text = "c"
            btnV.Text = "v"
            btnB.Text = "b"
            btnN.Text = "n"
            btnM.Text = "m"
        End If
    End Sub

      Private Sub right_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles derecha.Click
            txtCampo.Focus().Equals(True)
            My.Computer.Keyboard.SendKeys("{RIGHT}", True)
      End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        txtCampo.Focus().Equals(True)
        My.Computer.Keyboard.SendKeys("{BACKSPACE}", True)
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        txtCampo.Text = txtCampo.Text & btn1.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        txtCampo.Text = txtCampo.Text & btn2.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click
        txtCampo.Text = txtCampo.Text & btn3.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn4.Click
        txtCampo.Text = txtCampo.Text & btn4.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn5.Click
        txtCampo.Text = txtCampo.Text & btn5.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn6.Click
        txtCampo.Text = txtCampo.Text & btn6.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn7.Click
        txtCampo.Text = txtCampo.Text & btn7.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8.Click
        txtCampo.Text = txtCampo.Text & btn8.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn9.Click
        txtCampo.Text = txtCampo.Text & btn9.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click
        txtCampo.Text = txtCampo.Text & btn0.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQ.Click
        txtCampo.Text = txtCampo.Text & btnQ.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnW.Click
        txtCampo.Text = txtCampo.Text & btnW.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnE.Click
        txtCampo.Text = txtCampo.Text & btnE.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnR.Click
        txtCampo.Text = txtCampo.Text & btnR.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT.Click
        txtCampo.Text = txtCampo.Text & btnT.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnY.Click
        txtCampo.Text = txtCampo.Text & btnY.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnU.Click
        txtCampo.Text = txtCampo.Text & btnU.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnI.Click
        txtCampo.Text = txtCampo.Text & btnI.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnO.Click
        txtCampo.Text = txtCampo.Text & btnO.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP.Click
        txtCampo.Text = txtCampo.Text & btnP.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA.Click
        txtCampo.Text = txtCampo.Text & btnA.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        txtCampo.Text = txtCampo.Text & btnS.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnD.Click
        txtCampo.Text = txtCampo.Text & btnD.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF.Click
        txtCampo.Text = txtCampo.Text & btnF.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnG.Click
        txtCampo.Text = txtCampo.Text & btnG.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnH.Click
        txtCampo.Text = txtCampo.Text & btnH.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJ.Click
        txtCampo.Text = txtCampo.Text & btnJ.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnK.Click
        txtCampo.Text = txtCampo.Text & btnK.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnL.Click
        txtCampo.Text = txtCampo.Text & btnL.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnÑ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnÑ.Click
        txtCampo.Text = txtCampo.Text & btnÑ.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZ.Click
        txtCampo.Text = txtCampo.Text & btnZ.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnX.Click
        txtCampo.Text = txtCampo.Text & btnX.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC.Click
        txtCampo.Text = txtCampo.Text & btnC.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnV.Click
        txtCampo.Text = txtCampo.Text & btnV.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnB.Click
        txtCampo.Text = txtCampo.Text & btnB.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnN.Click
        txtCampo.Text = txtCampo.Text & btnN.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub btnM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM.Click
        txtCampo.Text = txtCampo.Text & btnM.Text
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub coma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coma.Click
        txtCampo.Text = txtCampo.Text & ","
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub punto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles punto.Click
        txtCampo.Text = txtCampo.Text & "."
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub guion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles guion.Click
        txtCampo.Text = txtCampo.Text & "-"
        txtCampo.SelectionStart = Len(txtCampo.Text)
        txtCampo.Focus().Equals(True)
    End Sub

    Private Sub Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ok.Click
        If lblcampo.Text = "EMPRESA" Then
            Login.cboEmpresa.Text = txtCampo.Text
            Login.cboEmpresa.Focus().Equals(True)
        Else
            Login.txtContrasena.Text = txtCampo.Text
            Login.txtContrasena.Focus().Equals(True)
        End If
        Me.Close()
    End Sub
End Class