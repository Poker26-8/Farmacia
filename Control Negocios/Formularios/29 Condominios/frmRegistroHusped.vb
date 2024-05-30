Public Class frmRegistroHusped
    Private Sub frmRegistroHusped_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCliente.Focus.Equals(True)
    End Sub

    Private Sub frmRegistroHusped_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboCliente.Focused.Equals(True)
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado,Alias,Status FROM usuarios WHERE Clave='" & txtClave.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If rd1("Status").ToString = 1 Then
                            lblIdEmpleado.Text = rd1("IdEmpleado").ToString
                            lblEmpleado.Text = rd1("Alias").ToString
                        Else
                            MsgBox("El usuario esta inactivo contacta a tu administrador", vbInformation + vbOKOnly, titulocentral)
                            lblIdEmpleado.Text = ""
                            txtClave.Text = ""
                            lblEmpleado.Text = ""
                            txtClave.Focus.Equals(True)
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("La contraseña es incorrecta", vbInformation + vbOKOnly, titulocentral)
                    lblIdEmpleado.Text = ""
                    txtClave.Text = ""
                    lblEmpleado.Text = ""
                    txtClave.Focus.Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()

                btnGuardar.Focus.Equals(True)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        Try
            cboCliente.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCliente.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboTorre_DropDown(sender As Object, e As EventArgs) Handles cboTorre.DropDown

    End Sub

    Private Sub cboCuarto_DropDown(sender As Object, e As EventArgs) Handles cboCuarto.DropDown

    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpIngreso.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpIngreso.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpPago.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTorre.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTorre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTorre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuarto.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuarto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuarto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtMonto.Text) Then
                btnGuardar.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboCliente.Text = ""
        dtpIngreso.Value = Date.Now
        dtpPago.Value = Date.Now
        cboTorre.Text = ""
        cboCuarto.Text = ""
        txtMonto.Text = "0.00"
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If lblEmpleado.Text = "" Then MsgBox("Ingrese la contraseña del empleado") : txtClave.Focus.Equals(True) : Exit Sub

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM clientes WHERE Nombre='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO clientes(Nombre,RazonSocial) VALUES('" & cboCliente.Text & "','" & cboCliente.Text & "')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM husped WHERE Cliente='" & cboCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO husped(Cliente,FIngreso,FCobro,FSalida,Torre,Cuarto,Monto,Usuario) VALUES('" & cboCliente.Text & "','" & Format(dtpIngreso.Value, "yyyy-MM-dd") & "','" & Format(dtpPago.Value, "yyyy-MM-dd") & "','','" & cboTorre.Text & "','" & cboCuarto.Text & "'," & txtMonto.Text & ",'" & lblEmpleado.Text & "')"
                If cmd2.ExecuteNonQuery() Then
                    MsgBox("Registro agregado correctamente", vbInformation + vbOKOnly, titulocentral)
                End If
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

            btnNuevo.PerformClick()
            cboCliente.Focus.Equals(True)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class