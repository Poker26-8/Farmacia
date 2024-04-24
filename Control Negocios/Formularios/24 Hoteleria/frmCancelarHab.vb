Public Class frmCancelarHab
    Private Sub frmCancelarHab_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboHabitacion_DropDown(sender As Object, e As EventArgs) Handles cboHabitacion.DropDown
        Try
            cboHabitacion.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT N_Habitacion FROM habitacion WHERE N_Habitacion<>'' AND Estado='Ocupada'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboHabitacion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub btndesocupar_Click(sender As Object, e As EventArgs) Handles btndesocupar.Click
        Try
            If MsgBox("¿Desea eliminar el tiempo de la habitación " & cboHabitacion.Text & "?", vbInformation + vbYesNo, titulohotelriaa) = vbYes Then

                If lblusuario.Text = "" Then MsgBox("Necesita ingresar la contraseña", vbInformation + vbOKOnly, titulohotelriaa) : txtContra.Focus.Equals(True) : Exit Sub

                cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "DELETE FROM asigpc WHERE Nombre='" & cboHabitacion.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & cboHabitacion.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "DELETE FROM comandas WHERE Nmesa='" & cboHabitacion.Text & "' AND Codigo='xc3'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "DELETE FROM detallehotel WHERE Habitacion='" & cboHabitacion.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & cboHabitacion.Text & "'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "UPDATE rep_comandas SET Status='CANCELADA' WHERE NMesa='" & cboHabitacion.Text & "' AND Codigo='xc3'"
                    If cmd1.ExecuteNonQuery() Then
                        MsgBox("Habitación actualizada correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                    End If
                cnn1.Close()
                Me.Close()
                frmManejo.TRAERUBICACION()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtContra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(1).ToString = "1" Then
                            lblusuario.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario esta inactivo", vbInformation + vbOKOnly, titulohotelriaa)
                        End If

                    End If
                Else
                    MsgBox("La clave es incorrecta", vbInformation + vbOKOnly, titulohotelriaa)
                End If
                rd1.Close()
                cnn1.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class