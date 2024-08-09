Public Class frmPagarD

    Private Sub frmPagarD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim MYSALDO As Double = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Credito,SaldoFavor FROM clientes WHERE Nombre='" & lblCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblcredito.Text = rd1("Credito").ToString
                    lblSaldoFavor.Text = FormatNumber(rd1("SaldoFavor").ToString(), 4)
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM AbonoI WHERE Id=(SELECT max(Id) FROM AbonoI WHERE Cliente='" & lblCliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.HasRows Then
                    MYSALDO = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                    If MYSALDO > 0 Then
                        lblAdeudo.Text = Math.Abs(MYSALDO)
                        lblAdeudo.Text = FormatNumber(lblAdeudo.Text, 4)
                    Else
                        lblAdeudo.Text = "0.00"
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Private Sub lblTotal_TextChanged(sender As Object, e As EventArgs) Handles lblTotalP.TextChanged

        If lblTotalP.Text = "" Then Exit Sub
        Dim TotalImporte As Double = lblTotalP.Text
        Dim CantidadLetra As String = ""
        If TotalImporte > 0 Then

            CantidadLetra = UCase(convLetras(TotalImporte))
        Else

            CantidadLetra = ""
        End If
        lblLetras.Text = CantidadLetra

    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferencia.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtOtros_TextChanged(sender As Object, e As EventArgs) Handles txtOtros.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.Text = "Cambio"
            lblCreditoCli.Text = "0.00"
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.Text = "Resta"
            lblCreditoCli.Text = FormatNumber(MyOpe, 2)
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        pCredito.Visible = True
        Me.Size = New Size(500, 562)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pCredito.Visible = False
        Me.Size = New Size(500, 487)
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtOtros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtros.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnAceptar.Focus.Equals(True)
        End If
    End Sub
End Class