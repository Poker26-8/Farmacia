Public Class frmMovCuentas
    Private Sub frmMovCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFolio.Start()
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        Try
            cnntimer.Close() : cnntimer.Open()
            cmdtimer = cnntimer.CreateCommand
            cmdtimer.CommandText = "SELECT MAX(Id) FROM movcuenta"
            rdtimer = cmdtimer.ExecuteReader
            If rdtimer.HasRows Then
                If rdtimer.Read Then
                    lblFolio.Text = IIf(rdtimer(0).ToString = "", 0, rdtimer(0).ToString) + 1
                Else
                    lblFolio.Text = "1"
                End If
            Else
                lblFolio.Text = "1"
            End If
            rdtimer.Close()
            cnntimer.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnntimer.Close()
        End Try
    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM usuarios WHERE Clave='" & txtContra.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1("Status").ToString = 1 Then
                        lblUsuario.Text = rd1("Alias").ToString
                    Else
                        MsgBox("El usuario esta inactivo, Contacte a su administrador", vbInformation + vbOKOnly, titulocentral)
                        txtContra.Text = ""
                        lblUsuario.Text = ""
                        txtContra.Focus.Equals(True)
                        Exit Sub
                    End If
                End If
            Else
                MsgBox("Contraseña incoreecta", vbInformation + vbOKOnly, titulocentral)
                txtContra.Text = ""
                lblUsuario.Text = ""
                txtContra.Focus.Equals(True)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        cboFolio.Text = ""
        rtobservacion.Text = ""
        cboCuneta.Text = ""
        txtBancoC.Text = ""
        cboNombre.Text = ""
        dtpFecha.Value = Now
        cboForma.Text = ""
        cboBanco.Text = ""
        txtReferencia.Text = ""
        txtMonto.Text = ""
    End Sub

    Private Sub cboForma_DropDown(sender As Object, e As EventArgs) Handles cboForma.DropDown
        Try
            cboForma.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboForma.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()

        End Try
    End Sub

    Private Sub cboBanco_DropDown(sender As Object, e As EventArgs) Handles cboBanco.DropDown
        Try
            cboBanco.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Banco FROM bancos WHERE Banco<>'' ORDER BY Banco"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboBanco.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCuneta_DropDown(sender As Object, e As EventArgs) Handles cboCuneta.DropDown
        Try
            cboCuneta.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCuneta.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCuneta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuneta.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCuneta.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtBancoC.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        Try
            cboNombre.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Cliente FROM movcuenta WHERE Cliente<>'' ORDER BY Cliente"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboNombre.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        Try
            cboFolio.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Id FROM movcuenta WHERE Concepto='OTROS' AND Id<>'' ORDER BY Id"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboFolio.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub frmMovCuentas_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        cboNombre.Focus.Equals(True)
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboForma.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboForma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboForma.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboBanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtReferencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtMonto.Text) Then
                cboCuneta.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboCuneta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuneta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then

            btnguardar.Focus.Equals(True)
        End If
    End Sub




    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim saldocuenta As Double = 0
            Dim nuevosaldo As Double = 0
            Dim monto As Double = 0

            monto = txtMonto.Text

            If cboFolio.Text <> "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM movcuenta WHERE Id" & cboFolio.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cboCuneta.Text & "')"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then


                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "UPDATE movcuenta SET Total=" & txtMonto.Text & ",Retiro="",Saldo="" WHERE Id=" & cboFolio.Text
                                cmd3.ExecuteNonQuery()
                                cnn3.Close()

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If
                End If
                rd1.Close()
                cnn1.Close()

            End If

            If cboFolio.Text = "" Then

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM movcuenta WHERE Cuenta='" & cboCuneta.Text & "' AND Id=" & lblFolio.Text & ""
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                    End If
                Else

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cboCuneta.Text & "')"
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            saldocuenta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + monto

                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "INSERT INTO movCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & cboForma.Text & "','" & cboBanco.Text & "','" & txtReferencia.Text & "','OTROS'," & txtMonto.Text & ",0," & txtMonto.Text & "," & saldocuenta & ",'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & lblFolio.Text & "','" & cboNombre.Text & "','" & rtobservacion.Text & "','" & cboCuneta.Text & "','" & txtBancoC.Text & "')"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()

                        End If
                    Else
                        saldocuenta = monto

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "INSERT INTO movCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) VALUES('" & cboForma.Text & "','" & cboBanco.Text & "','" & txtReferencia.Text & "','OTROS'," & txtMonto.Text & ",0," & txtMonto.Text & "," & saldocuenta & ",'" & Format(dtpFecha.Value, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & lblFolio.Text & "','" & cboNombre.Text & "','" & rtobservacion.Text & "','" & cboCuneta.Text & "','" & txtBancoC.Text & "')"
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()

                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
                rd1.Close()
                cnn1.Close()

            End If


            MsgBox("Ingreso registrado correctamente", vbInformation + vbOKOnly, titulocentral)
            btnnuevo.PerformClick()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM movcuenta WHERE Id=" & cboFolio.Text
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cboNombre.Text = rd1("Cliente").ToString
                    cboForma.Text = rd1("Tipo").ToString
                    cboBanco.Text = rd1("Banco").ToString
                    txtReferencia.Text = rd1("Referencia").ToString
                    txtMonto.Text = FormatNumber(rd1("Total").ToString, 2)
                    cboCuneta.Text = rd1("Cuenta").ToString
                    txtBancoC.Text = rd1("BancoCuenta").ToString
                    rtobservacion.Text = rd1("Comentario").ToString

                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
End Class