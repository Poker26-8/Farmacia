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
                    "select IdEmpleado,Alias from Usuarios where Clave='" & txtclave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        id_usu = rd1(0).ToString()
                        sobrenombre = rd1("Alias").ToString
                    End If
                Else
                    MsgBox("No se encuentra el registro del empleado.", vbInformation + vbOKOnly, titulorestaurante)
                    txtclave.SelectAll()
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

                If id_usu <> 0 Then
                    frmTeTemp.mesatemp = 1
                    frmTeTemp.Show()
                    frmTeTemp.BringToFront()
                    Me.Close()
                Else
                    MsgBox("Ingresa una contraseña para continuar", vbInformation + vbOKOnly, titulorestaurante)
                    Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try

            End If

    End Sub

    Private Sub frmPasa_Mesa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class