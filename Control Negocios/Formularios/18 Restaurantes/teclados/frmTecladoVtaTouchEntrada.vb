Public Class frmTecladoVtaTouchEntrada

    Public Respuesta As String = ""
    Public listado As Boolean
    Public NombreCampo As String = ""

    ' Variable para almacenar la cadena original
    Private originalText As String = ""
    Private ORI As String = ""
    Private Sub frmTecladoVtaTouchEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Focus.Equals(True)
    End Sub

    Private Sub frmTecladoVtaTouchEntrada_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated

        Respuesta = IIf(listado, txtNombre.Text, txtNombre.Text)

        cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "select NotasCred from Formatos where Facturas='TomaContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                If rd1(0).ToString = 1 Then
                    txtNombre.Text = ClaveUsuario
                    Respuesta = txtNombre.Text
                    Me.Close()
                Else
                    txtNombre.Text = ""
                    txtNombre.Focus.Equals(True)
                End If
            End If
            End If
            rd1.Close()
        cnn1.Close()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim Area_user As String = ""

        If txtNombre.Text <> "" Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Usuarios WHERE Clave='" & txtcontra.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    ClaveUsuario = rd1("Clave").ToString
                    Area_user = rd1("Alias").ToString
                    id_usu_log = rd1("IdEmpleado").ToString
                    frmVTouchR.lblAtendio.Text = Area_user

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

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress

        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            btnAceptar.Focus.Equals(True)

        End If

    End Sub

    Public Function CutCad(VAL As String) As String
        If Len(VAL) > 0 Then
            CutCad = Strings.Left(VAL, Len(VAL) - 1)
        Else
            CutCad = ""
        End If
    End Function

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        txtNombre.Text = CutCad(txtNombre.Text)
        txtcontra.Text = CutCad(txtcontra.Text)
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn0.Text
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn1.Text
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn2.Text
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn3.Text
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn4.Text
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn5.Text
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn6.Text
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn7.Text
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn8.Text
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btn9.Text
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnQ.Text
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnW.Text
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnE.Text
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnR.Text
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnT.Text
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnY.Text
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnU.Text
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnI.Text
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnO.Text
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnP.Text
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnA.Text
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnS.Text
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnD.Text
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnF.Text
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnG.Text
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnH.Text
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnJ.Text
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnK.Text
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnL.Text
    End Sub

    Private Sub btnñ_Click(sender As Object, e As EventArgs) Handles btnñ.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnñ.Text
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnZ.Text
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnX.Text
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnC.Text
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnV.Text
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnB.Text
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnN.Text
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnM.Text
    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnComa.Text
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnPunto.Text
    End Sub

    Private Sub btnGuion_Click(sender As Object, e As EventArgs) Handles btnGuion.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + btnGuion.Text
    End Sub

    Private Sub BTNESP_Click(sender As Object, e As EventArgs) Handles BTNESP.Click
        txtNombre.Text = txtNombre.Text + "*"
        txtcontra.Text = txtcontra.Text + " "
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


End Class