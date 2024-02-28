Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmMesero
    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress

        Dim aliass As String = ""
        Try
            If AscW(e.KeyChar) = Keys.Enter Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM usuarios WHERE Clave='" & txtClave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        aliass = rd1("Alias").ToString
                        If rd1("Puesto").ToString = "MESERO" Or rd1("Puesto").ToString = "ADMINISTRACIÓN" Then



                            frmMesasNueva.Show()
                            frmMesasNueva.BringToFront()


                            frmMesasNueva.txtMesero.Text = aliass

                            Me.Close()

                        Else
                            MsgBox("El usuario no tiene el puesto correcto", vbInformation + vbOKOnly, titulorestaurante)
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("La contraseña es incorrecta", vbInformation + vbOKOnly, titulorestaurante)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click
        txtClave_KeyPress(txtClave, New KeyPressEventArgs(ControlChars.Cr))
    End Sub
End Class