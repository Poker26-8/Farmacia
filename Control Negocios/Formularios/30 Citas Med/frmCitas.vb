Public Class frmCitas
    Private Sub frmCitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim fecha As Date = Nothing
            Dim fecham As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM citas ORDER BY Fecha"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    fecha = rd1("Fecha").ToString
                    fecham = Format(fecha, "yyyy-MM-dd")

                    grdCitas.Rows.Add(rd1("Medico").ToString,
                                      rd1("Cedula").ToString,
                                      rd1("Paciente").ToString,
                                      rd1("Telefono").ToString,
                                      rd1("Motivo").ToString,
                                      fecham,
                                      rd1("Hora").ToString
)

                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboMedico_DropDown(sender As Object, e As EventArgs) Handles cboMedico.DropDown
        Try
            cboMedico.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre from ctmedicos WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboMedico.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboMedico_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMedico.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Cedula from ctmedicos WHERE Nombre='" & cboMedico.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtCedula.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cboPaciente.Text = ""
        txtTelefono.Text = ""
        cboMedico.Text = ""
        txtCedula.Text = ""
        txtMotivo.Text = ""
        dtpFecha.Value = Date.Now
        dtoHora.Value = Date.Now
    End Sub

    Private Sub cboPaciente_DropDown(sender As Object, e As EventArgs) Handles cboPaciente.DropDown
        Try
            cboPaciente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboPaciente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboPaciente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboPaciente.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Telefono FROM clientes WHERE Nombre='" & cboPaciente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtTelefono.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnAgendar_Click(sender As Object, e As EventArgs) Handles btnAgendar.Click
        Try
            If cboPaciente.Text = "" Then MsgBox("Debe seleccionar un paciente") : cboPaciente.Focus.Equals(True) : Exit Sub

            If cboMedico.Text = "" Then MsgBox("Debe seleccionar un medico") : cboMedico.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO citas(Medico,Cedula,Paciente,Telefono,Motivo,Fecha,Hora,Usuario) VALUES('" & cboMedico.Text & "','" & txtCedula.Text & "','" & cboPaciente.Text & "','" & txtTelefono.Text & "','" & txtMotivo.Text & "','" & Format(dtpFecha.Value, "yyyy/MM/dd") & "','" & Format(dtoHora.Value, "HH:mm:ss") & "','" & lblUsuario.Text & "')"
            If cmd1.ExecuteNonQuery() Then
                MsgBox("Cita asignada correctamente", vbInformation + vbOKOnly, titulocentral)
            End If
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtClave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1(1).ToString = "1" Then
                            lblUsuario.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario esta inactivo contacte a su administrador", vbInformation + vbOKOnly, titulocentral)
                            txtClave.Focus.Equals(True)
                            txtClave.Text = ""
                            lblUsuario.Text = "Usuario"
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("La contraseña es incorrecta", vbInformation + vbOKOnly, titulocentral)
                    txtClave.Focus.Equals(True)
                    txtClave.Text = ""
                    lblUsuario.Text = "Usuario"
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmCorte3.Show()
    End Sub
End Class