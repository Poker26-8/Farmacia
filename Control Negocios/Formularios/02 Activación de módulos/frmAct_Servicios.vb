Public Class frmAct_Servicios
    Private Sub frmAct_Servicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SFormatos("Control_Servicios", "")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("¿Deseas activar el módulo de control de servicios?", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") = vbOK Then

            If txtcontra.Text = "" Then MsgBox("Escribe la contraseña de activación." & vbNewLine & "Para generarla conmunícate con tu proveedor de software.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub

            If txtcontra.Text = "jipl2211*" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Formatos set NotasCred='" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "', NumPart=1 where Facturas='Control_Servicios'"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("El módulo de control de servicios ha sido activado de manera correcta." & vbNewLine & "El sistema se cerrará para completar el proceso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End
                    End If

                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            Else
                MsgBox("La clave de activación no es correcta.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtcontra.SelectAll() : Exit Sub
            End If
        End If
    End Sub
End Class