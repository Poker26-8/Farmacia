Public Class frmTeTemp
    Public mesatemp As Integer = 0
    Private Sub frmTeTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Focus.Equals(True)
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

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            btnAceptar.Focus.Equals(True)

        End If


    End Sub

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

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        txtNombre.Text = txtNombre.Text + btnW.Text
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        txtNombre.Text = txtNombre.Text + btnE.Text
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        txtNombre.Text = txtNombre.Text + btnR.Text
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        txtNombre.Text = txtNombre.Text + btnT.Text
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        txtNombre.Text = txtNombre.Text + btnY.Text
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        txtNombre.Text = txtNombre.Text + btnU.Text
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        txtNombre.Text = txtNombre.Text + btnI.Text
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        txtNombre.Text = txtNombre.Text + btnO.Text
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        txtNombre.Text = txtNombre.Text + btnP.Text
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        txtNombre.Text = txtNombre.Text + btnA.Text
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        txtNombre.Text = txtNombre.Text + btnS.Text
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        txtNombre.Text = txtNombre.Text + btnD.Text
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        txtNombre.Text = txtNombre.Text + btnF.Text
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        txtNombre.Text = txtNombre.Text + btnG.Text
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        txtNombre.Text = txtNombre.Text + btnH.Text
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        txtNombre.Text = txtNombre.Text + btnJ.Text
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        txtNombre.Text = txtNombre.Text + btnK.Text
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        txtNombre.Text = txtNombre.Text + btnL.Text
    End Sub

    Private Sub btnñ_Click(sender As Object, e As EventArgs) Handles btnñ.Click
        txtNombre.Text = txtNombre.Text + btnñ.Text
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        txtNombre.Text = txtNombre.Text + btnZ.Text
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        txtNombre.Text = txtNombre.Text + btnX.Text
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        txtNombre.Text = txtNombre.Text + btnC.Text
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        txtNombre.Text = txtNombre.Text + btnV.Text
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        txtNombre.Text = txtNombre.Text + btnB.Text
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        txtNombre.Text = txtNombre.Text + btnN.Text
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        txtNombre.Text = txtNombre.Text + btnM.Text
    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click
        txtNombre.Text = txtNombre.Text + btnComa.Text
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        txtNombre.Text = txtNombre.Text + btnPunto.Text
    End Sub

    Private Sub btnGuion_Click(sender As Object, e As EventArgs) Handles btnGuion.Click
        txtNombre.Text = txtNombre.Text + btnGuion.Text
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        txtNombre.Text = txtNombre.Text.TrimEnd()

        If mesatemp = 1 Then

            If txtNombre.Text = "" Then MsgBox("Favor de escribir el nombre de la mesa", vbInformation + vbOKOnly, titulorestaurante) : Exit Sub : txtNombre.Focus.Equals(True)

            Dim orden As Double = 0
            Dim idmesero As Integer = 0
            Try

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & frmMesas.lblusuario.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        idmesero = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT MAX(Orden) FROM mesa"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        orden = IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + 1
                    Else
                        orden = "1"
                    End If
                Else
                    orden = "1"
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM mesa WHERE Nombre_mesa='" & txtNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        MsgBox("El nombre de la mesa ya esta registrado", vbInformation + vbOKOnly, titulorestaurante)
                        txtNombre.Text = ""
                        txtNombre.Focus.Equals(True)
                        Exit Sub
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesa(Nombre_mesa,Temporal,Status,Contabiliza,Precio,Orden,TempNom,IdEmpleado,Mesero,Ubicacion,X,Y,Tipo,Impresion) VALUES('" & txtNombre.Text & "',1,'Desocupada',0,0," & orden & ",''," & idmesero & ",'" & frmMesas.lblusuario.Text & "','TEMPORALES',0,0,'2',0)"
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO mesasxempleados(Mesa,IdEmpleado,Grupo,Temporal) VALUES('" & txtNombre.Text & "'," & idmesero & ",'',1)"
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Mesa agregada correctamente", vbInformation + vbOKOnly, titulorestaurante)
                        cnn2.Close()
                        txtNombre.Text = ""
                        If frmMesas.mapearmesas = 1 Then
                            frmMesas.Show()
                            frmMesas.BringToFront()
                            frmMesas.TRAERLUGAR()
                            frmMesas.primerBoton()
                        Else
                            'frmMesas.CrearBD_MesaNM()
                            frmMesas.TRAERLUGAR()
                            frmMesas.primerBoton()
                            frmMesas.Show()
                            frmMesas.BringToFront()
                        End If

                        Me.Close()
                        End If


                    End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If

    End Sub

    Private Sub BTNESP_Click(sender As Object, e As EventArgs) Handles BTNESP.Click
        txtNombre.Text = txtNombre.Text + " "
    End Sub
End Class