Public Class frmAdministracion
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuHabitaciones.Show()
    End Sub

    Private Sub cbousuario_DropDown(sender As Object, e As EventArgs) Handles cbousuario.DropDown
        Try
            cbousuario.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM usuarios WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbousuario.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbousuario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbousuario.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Nombre='" & cbousuario.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidu.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Desocupar,Cambiar,PreciosHab FROM Permisos WHERE IdEmpleado=" & lblidu.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString = True Then cbDesbloqueo.Checked = True Else cbDesbloqueo.Checked = False
                    If rd1(1).ToString = True Then cbCambioH.Checked = True Else cbCambioH.Checked = False
                    If rd1(2).ToString = True Then cbPrecios.Checked = True Else cbPrecios.Checked = False
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try

            If lblusuario.Text = "" Then MsgBox("Debe de ingresar la contraseña de administrador para continuar", vbInformation + vbOKOnly, titulohotelriaa) : txtContra.Focus.Equals(True) : Exit Sub


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM permisos WHERE IdEmpleado='" & lblidu.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE permisos SET Desocupar=" & IIf(cbDesbloqueo.Checked, 1, 0) & ",Cambiar=" & IIf(cbCambioH.Checked, 1, 0) & ",PreciosHab=" & IIf(cbPrecios.Checked, 1, 0) & " WHERE IdEmpleado=" & lblidu.Text & ""
                    If cmd2.ExecuteNonQuery() Then
                        MsgBox("Permisos asignados correctamente", vbInformation + vbOKOnly, titulohotelriaa)
                    End If
                    cnn2.Close()
                End If
            Else
                MsgBox("Tienes que asignar los permisos en la pantalla de permisos del sistema", vbInformation + vbOKOnly, titulohotelriaa)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

            btnLimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                Dim area As String = ""

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Status,Area,Alias FROM Usuarios WHERE Clave='" & txtContra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        If rd1(0).ToString = 1 Then
                            area = rd1(1).ToString

                            If area = "ADMINISTRACIÓN" Then
                                lblusuario.Text = rd1(2).ToString
                            Else
                                MsgBox("El usuario no es administrador no puedes asignar estos permisos, intenta con el usuario administrador", vbInformation + vbOKOnly, titulohotelriaa)
                                txtContra.Text = ""
                                txtContra.Focus.Equals(True)
                                lblusuario.Text = ""
                                Exit Sub

                            End If
                        Else
                            MsgBox("El usuario no esta activo contacte a su administrador", vbInformation + vbOKOnly, titulohotelriaa)
                            txtContra.Text = ""
                            txtContra.Focus.Equals(True)
                            lblusuario.Text = ""
                            Exit Sub
                        End If

                    End If
                Else
                    MsgBox("La contraseña es incorrecta", vbInformation + vbOKOnly, titulohotelriaa)
                    txtContra.Text = ""
                    txtContra.Focus.Equals(True)
                    lblusuario.Text = ""
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbousuario.Focus.Equals(True)
        cbousuario.Text = ""
        lblidu.Text = ""
        cbDesbloqueo.Checked = False
        cbPrecios.Checked = False
        cbCambioH.Checked = False
    End Sub


End Class