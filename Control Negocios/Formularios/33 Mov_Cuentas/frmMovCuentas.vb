Public Class frmMovCuentas
    Private Sub frmMovCuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TFolio.Start()
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
            cmd5.CommandText = "SELECT DISTINCT Nombre FROM clientes WHERE Nombre<>'' ORDER BY Nombre"
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
End Class