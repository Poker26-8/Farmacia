Public Class frmCuentabANCARIA
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtId.Text = ""
        cbocuenta.Text = ""
        cbobanco.Text = ""
        cboTitular.Text = ""
        cbocuenta.Focus.Equals(True)
        txtSaldo.Text = "0"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cbocuenta.Text = "" Then MsgBox("Debe de ingresar una cuenta") : cbocuenta.Focus.Equals(True) : Exit Sub

            If cbocuenta.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM bancos WHERE bANCO='" & cbobanco.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO Bancos(Banco) VALUES('" & cbobanco.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()

                cnn2.Close() : cnn2.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM cuentasbancarias WHERE CuentaBan='" & cbocuenta.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE cuentasbancarias SET CuentaBan='" & cbocuenta.Text & "',Banco='" & cbobanco.Text & "',Titular='" & cboTitular.Text & "' WHERE Id=" & txtId.Text
                        If cmd2.ExecuteNonQuery Then
                            MsgBox("Cuenta actualizada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                        End If
                        cnn2.Close()
                    End If
                Else



                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO cuentasbancarias(CuentaBan,Banco,Titular) VALUES('" & cbocuenta.Text & "','" & cbobanco.Text & "','" & cboTitular.Text & "')"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Cuenta agregada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta) VALUES('INICIAL','','','SALDO'," & txtSaldo.Text & ",0,0," & txtSaldo.Text & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & cbocuenta.Text & "','" & cbobanco.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
                rd1.Close()
                cnn1.Close()

            End If
            btnNuevo.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub cbocuenta_DropDown(sender As Object, e As EventArgs) Handles cbocuenta.DropDown
        Try
            cbocuenta.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbocuenta.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbobanco_DropDown(sender As Object, e As EventArgs) Handles cbobanco.DropDown
        Try
            cbobanco.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Banco FROM bancos WHERE Banco<>'' ORDER BY Banco"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbobanco.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboTitular_DropDown(sender As Object, e As EventArgs) Handles cboTitular.DropDown
        Try
            cboTitular.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Titular FROM cuentasbancarias WHERE Titular<>'' ORDER BY Titular"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboTitular.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cbocuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocuenta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTitular.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTitular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTitular.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtSaldo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbocuenta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbocuenta.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Id,Banco,Titular FROM cuentasbancarias WHERE CuentaBan='" & cbocuenta.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtId.Text = rd1(0).ToString
                    cbobanco.Text = rd1(1).ToString
                    cboTitular.Text = rd1(2).ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cbocuenta.Text & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtSaldo.Text = IIf(rd2(0).ToString = "", 0, rd2(0).ToString)
                        End If
                    End If
                    rd2.Close()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM cuentasbancarias WHERE CuentaBan='" & cbocuenta.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "DELETE FROM cuentasbancarias WHERE CuentaBan='" & cbocuenta.Text & "' AND Id=" & txtId.Text & ""
                    rd3 = cmd3.ExecuteReader
                    If cmd3.ExecuteNonQuery Then
                        MsgBox("Cuenta eliminada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                    End If
                    cnn3.Close()

                End If
            End If
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn3.Close()
        End Try
    End Sub

    Private Sub txtSaldo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSaldo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtSaldo.Text) Then
                btnGuardar.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim idmov As Integer = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cbocuenta.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then


                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta) VALUES('ACTUALIZACION SALDO','','','SALDO'," & txtSaldo.Text & ",0,0," & txtSaldo.Text & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & cbocuenta.Text & "','" & cbobanco.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            Else


                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO movcuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Comentario,Cuenta,BancoCuenta) VALUES('ACTUALIZACION SALDO','','','SALDO'," & txtSaldo.Text & ",0,0," & txtSaldo.Text & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & cbocuenta.Text & "','" & cbobanco.Text & "')"
                cmd2.ExecuteNonQuery()

            End If
            rd1.Close()
            cnn1.Close()
            MsgBox("Saldo actualizado correctamente", vbInformation + vbOKOnly, titulocentral)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class