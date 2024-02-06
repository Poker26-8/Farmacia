Public Class frmPasa_Corte

    Private Sub frmPasa_Corte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPasa_Corte_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtclave.Focus().Equals(True)
    End Sub

    Private Sub txtclave_Click(sender As System.Object, e As System.EventArgs) Handles txtclave.Click
        txtclave.SelectionStart = 0
        txtclave.SelectionLength = Len(txtclave.Text)
    End Sub

    Private Sub txtclave_GotFocus(sender As Object, e As System.EventArgs) Handles txtclave.GotFocus
        txtclave.SelectionStart = 0
        txtclave.SelectionLength = Len(txtclave.Text)
    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtclave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim id_usu As Integer = 0

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtclave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_usu = rd1(0).ToString()
                    End If
                Else
                    MsgBox("No se encuentra el registro del empleado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtclave.SelectAll()
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Permisos where IdEmpleado=" & id_usu
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Ad_Cort").ToString() = 1 Then
                            frmCorte2.Show()
                            frmCorte2.BringToFront()
                            Me.Close()
                        Else
                            MsgBox("No cuentas con permisos para consultar el corte de caja.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtclave.SelectAll()
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub
End Class