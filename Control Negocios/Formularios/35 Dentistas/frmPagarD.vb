Public Class frmPagarD

    Private Sub frmPagarD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferencia.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
            lbltitulo.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.ForeColor = Color.FromArgb(194, 45, 43)
            lblCambio.Text = FormatNumber(MyOpe, 2)
        End If
        lblCambio.Text = FormatNumber(lblCambio.Text, 2)
    End Sub

    Private Sub txtOtros_TextChanged(sender As Object, e As EventArgs) Handles txtOtros.TextChanged
        Dim MyOpe As Double = CDbl(IIf(lblTotalP.Text = "", "0", lblTotalP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", "0", txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", "0", txtTransferencia.Text)) + CDbl(IIf(txtOtros.Text = "", "0", txtOtros.Text)))
        If MyOpe < 0 Then
            lbltitulo.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.ForeColor = Color.FromArgb(24, 108, 84)
            lblCambio.Text = FormatNumber(-MyOpe, 2)
        Else
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
        Me.Size = New Size(481, 630)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pCredito.Visible = False
        Me.Size = New Size(481, 505)
    End Sub
End Class