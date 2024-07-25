Public Class frmGastos
    Private Sub frmGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFecha.Value = Date.Now
        dtpFecha_P.Value = Date.Now
    End Sub

    Private Sub cboiPlaca_DropDown(sender As Object, e As EventArgs) Handles cboiPlaca.DropDown
        Try
            cboiPlaca.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Placas FROM transporte WHERE Placas<>'' ORDER BY placas"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboiPlaca.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub



    Private Sub cbotpago_DropDown(sender As Object, e As EventArgs) Handles cbotpago.DropDown
        Try
            cbotpago.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cbotpago.Items.Add(rd5(0).ToString)
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

    Private Sub cboCuentaRecepcion_DropDown(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.DropDown
        Try
            cboCuentaRecepcion.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCuentaRecepcion.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboArea.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboiPlaca.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboiPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboiPlaca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtChofer.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtChofer_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChofer.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMarca.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtMarca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMarca.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtModelo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFactura.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFactura.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboConcepto.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboConcepto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboConcepto.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            rtbObservaciones.Focus.Equals(True)
        End If
    End Sub

    Private Sub rtbObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rtbObservaciones.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEfectivo.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtEfectivo.Text) Then
                btnGuardar.Focus.Equals(True)
            Else
                txtEfectivo.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub cbotpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotpago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus.Equals(True)
        End If
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
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
                txtComentarioPago.Focus.Equals(True)
            Else
                txtMonto.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txtComentarioPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuentaRecepcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuentaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuentaRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnPagos.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuentaRecepcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuentaRecepcion.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCuentaRecepcion.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboBancoRecepcion.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim tipo As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim referencia As String = txtReferencia.Text
        Dim monto As Double = txtMonto.Text
        Dim fecha As Date = Format(dtpFecha_P.Value, "yyyy-MM-dd")
        Dim cuenta As String = cboCuentaRecepcion.Text
        Dim bancoref As String = cboBancoRecepcion.Text
        Dim comentario As String = txtComentarioPago.Text
        Dim totalpagos As Double = 0

        If tipo = "MONEDERO" Then
            If referencia = "" Then
                MsgBox("Debe ingresar una refrencia", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If monto = 0 Then
                MsgBox("Debe ingresar un monto", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
        Else
            If tipo = "" Then
                MsgBox("Debe seleccionar una forma de pago", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If banco = "" Then
                MsgBox("Debe seleccionar una banco", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If referencia = "" Then
                MsgBox("Debe ingresar una refrencia", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If

            If monto = 0 Then
                MsgBox("Debe ingresar un monto", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
        End If

        grdpago.Rows.Add(tipo, banco, referencia, monto, fecha, comentario, cuenta, bancoref)

        totalpagos = txtPagos.Text + monto
        txtPagos.Text = FormatNumber(totalpagos, 2)


        limpiarforma()
    End Sub

    Public Sub limpiarforma()
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtReferencia.Text = ""
        txtMonto.Text = "0.00"
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        txtComentarioPago.Text = ""
    End Sub

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim index As Integer = grdpago.CurrentRow.Index

        Dim importe = grdpago.Rows(index).Cells(3).Value.ToString

        grdpago.Rows.Remove(grdpago.Rows(index))
        txtPagos.Text = txtPagos.Text - CDec(importe)
        txtPagos.Text = FormatNumber(txtPagos.Text, 2)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        cboArea.Text = ""
        cboiPlaca.Text = ""
        txtChofer.Text = ""
        txtMarca.Text = ""
        txtModelo.Text = ""
        txtFactura.Text = ""
        cboConcepto.Text = ""
        rtbObservaciones.Text = ""
        txtRemision.Text = ""
        dtpFecha.Value = Date.Now
        txtTotal.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtPagos.Text = "0.00"

        cbotpago.Text = ""
        cbobanco.Text = ""
        txtReferencia.Text = ""
        txtMonto.Text = "0.00"
        txtComentarioPago.Text = ""
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
        dtpFecha_P.Value = Date.Now
        grdpago.Rows.Clear()
        cboArea.Focus.Equals(True)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtContraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Alias from Usuarios where Clave='" & txtContraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblUsuario.Text = rd1("Alias").ToString()
                        btnGuardar.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No se encuentra el usuario, revisa la contraseña.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtContraseña.Focus().Equals(True) : Exit Sub
                    rd1.Close() : cnn1.Close()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub
End Class