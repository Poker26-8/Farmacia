Public Class frmPasa_Mesa
    Public PAGARCOMANDA As Integer = 0
    Private Sub frmPasa_Mesa_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtclave.Focus.Equals(True)
    End Sub

    Private Sub txtclave_Click(sender As Object, e As EventArgs) Handles txtclave.Click
        txtclave.SelectionStart = 0
        txtclave.SelectionLength = Len(txtclave.Text)
    End Sub

    Private Sub txtclave_GotFocus(sender As Object, e As EventArgs) Handles txtclave.GotFocus
        txtclave.SelectionStart = 0
        txtclave.SelectionLength = Len(txtclave.Text)
    End Sub

    Private Sub txtclave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtclave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim id_usu As Integer = 0
            Dim sobrenombre As String = ""

            Try

                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Usuarios where Clave='" & txtclave.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                        id_usu = rd1(0).ToString()
                        sobrenombre = rd1("Alias").ToString
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
                        "select * from permisosm where IdEmpleado=" & id_usu
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                    If rd1.Read Then

                        If PAGARCOMANDA = 1 Then
                            frmPagarComanda.usuarioingresado = sobrenombre
                            frmPagarComanda.Show()
                            frmPagarComanda.BringToFront()
                            Me.Close()
                        Else

                            If rd1("Mesas").ToString() = 1 Then
                                frmAgregarMesa.Show()
                                frmAgregarMesa.BringToFront()
                                Me.Close()
                            Else
                                MsgBox("No cuentas con permisos para dar de alta mesas.", vbInformation + vbOKOnly, titulorestaurante)
                                txtclave.SelectAll()
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If

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

    Private Sub frmPasa_Mesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class