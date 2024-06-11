Public Class frmVentasTouchPago3
    Dim Foco As Byte = 0
    Public resta As Double = 0

    Private Sub txttarjeta_GotFocus(sender As Object, e As System.EventArgs) Handles txttarjeta.GotFocus
        txttarjeta.SelectionStart = 0
        txttarjeta.SelectionLength = Len(txttarjeta.Text)
        boxBilletes.Enabled = False
        Foco = 2
    End Sub

    Private Sub txttarjeta_LostFocus(sender As Object, e As System.EventArgs) Handles txttarjeta.LostFocus
        boxBilletes.Enabled = True
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
        boxBilletes.Enabled = True
        Foco = 1
    End Sub

    Private Sub txtefectivo_LostFocus(sender As Object, e As System.EventArgs) Handles txtefectivo.LostFocus
        boxBilletes.Enabled = True
    End Sub

    Private Sub TextBox6_GotFocus(sender As Object, e As System.EventArgs) Handles txtmone.GotFocus
        txtmone.SelectionStart = 0
        txtmone.SelectionLength = Len(txtmone.Text)
        boxBilletes.Enabled = False
        Foco = 3
    End Sub

    Private Sub TextBox6_LostFocus(sender As Object, e As System.EventArgs) Handles txtmone.LostFocus
        boxBilletes.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles btnIntro.Click
        frmVentasTouch3.MontoEfectivo = txtefectivo.Text
        frmVentasTouch3.MontoTarjeta = txttarjeta.Text
        frmVentasTouch3.MontoMonedero = txtmone.Text
        frmVentasTouch3.Cambio = txtcambio.Text
        frmVentasTouch3.Resta = txtresta.Text
        frmVentasTouch3.Cliente = cboNombre.Text
        frmVentasTouch3.Id_Cliente = MyIdCliente
        frmVentasTouch3.Direccion = txtDireccion.Text
        frmVentasTouch3.Monedero = txtMonedero.Text
        Dim cuantopaga As Double = 0
        cuantopaga = txttarjeta.Text
        frmVentasTouch3.validaTarjeta = cuantopaga
        Refresh()
        frmVentasTouch3.GuardarVenta()
    End Sub

    Private Sub txtefectivo_Click(sender As System.Object, e As System.EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
        Foco = 1
    End Sub

    Private Sub txttarjeta_Click(sender As System.Object, e As System.EventArgs) Handles txttarjeta.Click
        txttarjeta.SelectionStart = 0
        txttarjeta.SelectionLength = Len(txttarjeta.Text)
        Foco = 2
    End Sub

    Private Sub txtmone_Click(sender As System.Object, e As System.EventArgs) Handles txtmone.Click
        txtmone.SelectionStart = 0
        txtmone.SelectionLength = Len(txtmone.Text)
        Foco = 3
    End Sub

    Private Sub btnpuntito_Click(sender As System.Object, e As System.EventArgs) Handles btnpuntito.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "."
                Else
                    txtefectivo.Text = "0."
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "."
                Else
                    txttarjeta.Text = "0."
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "."
                Else
                    txtmone.Text = "0."
                End If
        End Select
    End Sub

    Private Sub btn1_Click(sender As System.Object, e As System.EventArgs) Handles btn1.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "1"
                Else
                    txtefectivo.Text = "1"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "1"
                Else
                    txttarjeta.Text = "1"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "1"
                Else
                    txtmone.Text = "1"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "1"
                Else
                    txtMonedero.Text = "1"
                End If
        End Select
    End Sub

    Private Sub btn2_Click(sender As System.Object, e As System.EventArgs) Handles btn2.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "2"
                Else
                    txtefectivo.Text = "2"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "2"
                Else
                    txttarjeta.Text = "2"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "2"
                Else
                    txtmone.Text = "2"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "2"
                Else
                    txtMonedero.Text = "2"
                End If
        End Select
    End Sub

    Private Sub btn3_Click(sender As System.Object, e As System.EventArgs) Handles btn3.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "3"
                Else
                    txtefectivo.Text = "3"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "3"
                Else
                    txttarjeta.Text = "3"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "3"
                Else
                    txtmone.Text = "3"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "3"
                Else
                    txtMonedero.Text = "3"
                End If
        End Select
    End Sub

    Private Sub btn4_Click(sender As System.Object, e As System.EventArgs) Handles btn4.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "4"
                Else
                    txtefectivo.Text = "4"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "4"
                Else
                    txttarjeta.Text = "4"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "4"
                Else
                    txtmone.Text = "4"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "4"
                Else
                    txtMonedero.Text = "4"
                End If
        End Select
    End Sub

    Private Sub btn5_Click(sender As System.Object, e As System.EventArgs) Handles btn5.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "5"
                Else
                    txtefectivo.Text = "5"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "5"
                Else
                    txttarjeta.Text = "5"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "5"
                Else
                    txtmone.Text = "5"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "5"
                Else
                    txtMonedero.Text = "5"
                End If
        End Select
    End Sub

    Private Sub btn6_Click(sender As System.Object, e As System.EventArgs) Handles btn6.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "6"
                Else
                    txtefectivo.Text = "6"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "6"
                Else
                    txttarjeta.Text = "6"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "6"
                Else
                    txtmone.Text = "6"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "6"
                Else
                    txtMonedero.Text = "6"
                End If
        End Select
    End Sub

    Private Sub btn7_Click(sender As System.Object, e As System.EventArgs) Handles btn7.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "7"
                Else
                    txtefectivo.Text = "7"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "7"
                Else
                    txttarjeta.Text = "7"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "7"
                Else
                    txtmone.Text = "7"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "7"
                Else
                    txtMonedero.Text = "7"
                End If
        End Select
    End Sub

    Private Sub btn8_Click(sender As System.Object, e As System.EventArgs) Handles btn8.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "8"
                Else
                    txtefectivo.Text = "8"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "8"
                Else
                    txttarjeta.Text = "8"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "8"
                Else
                    txtmone.Text = "8"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "8"
                Else
                    txtMonedero.Text = "8"
                End If
        End Select
    End Sub

    Private Sub btn9_Click(sender As System.Object, e As System.EventArgs) Handles btn9.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "9"
                Else
                    txtefectivo.Text = "9"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "9"
                Else
                    txttarjeta.Text = "9"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "9"
                Else
                    txtmone.Text = "9"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "9"
                Else
                    txtMonedero.Text = "9"
                End If
        End Select
    End Sub

    Private Sub btn0_Click(sender As System.Object, e As System.EventArgs) Handles btn0.Click
        Select Case Foco
            Case Is = 1
                If txtefectivo.Text <> "0.00" And txtefectivo.Text <> "" And txtefectivo.Text <> "0" And txtefectivo.Text <> "0.00" Then
                    txtefectivo.Text = txtefectivo.Text & "0"
                Else
                    txtefectivo.Text = "0"
                End If
            Case Is = 2
                If txttarjeta.Text <> "0.00" And txttarjeta.Text <> "" And txttarjeta.Text <> "0" And txttarjeta.Text <> "0.00" Then
                    txttarjeta.Text = txttarjeta.Text & "0"
                Else
                    txttarjeta.Text = "0"
                End If
            Case Is = 3
                If txtmone.Text <> "0.00" And txtmone.Text <> "" And txtmone.Text <> "0" And txtmone.Text <> "0.00" Then
                    txtmone.Text = txtmone.Text & "0"
                Else
                    txtmone.Text = "0"
                End If
            Case Is = 4
                If txtMonedero.Text <> "0.00" And txtMonedero.Text <> "" And txtMonedero.Text <> "0" And txtMonedero.Text <> "0.00" Then
                    txtMonedero.Text = txtMonedero.Text & "0"
                Else
                    txtMonedero.Text = "0"
                End If
        End Select
    End Sub

    Private Sub btnc0_Click(sender As System.Object, e As System.EventArgs) Handles btnc0.Click
        Select Case Foco
            Case Is = 1
                txtefectivo.Text = "0.00"
            Case Is = 2
                txttarjeta.Text = "0.00"
            Case Is = 3
                txtmone.Text = "0.00"
            Case Is = 4
                txtMonedero.Text = ""
        End Select
    End Sub

    Private Sub btn20_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 20
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn50_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 50
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn100_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 100
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn200_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 200
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn500_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 500
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn1000_Click(sender As System.Object, e As System.EventArgs)
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 1000
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub txtmone_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmone.TextChanged
        If txtmone.Text = "" Then Exit Sub
        If CDbl(txtmone.Text) > 0 Then
            If txtMonedero.Text = "" Then MsgBox("Ingesa el número de monedero para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmone.Text = "0.00" : Exit Sub
            If CDbl(txtsaldo.Text) <= 0 Then MsgBox("No cuentas con saldo en tu monedero para realizar pagos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmone.Text = "0.00" : Exit Sub

            If CDbl(txtmone.Text) > CDbl(txtsaldo.Text) Then
                MsgBox("No cuentas con el saldo suficiente en tu monedero para realizar el pago.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtmone.Text = "0.00" : Exit Sub
            End If
            If txtefectivo.Text = "" Then Exit Sub
            If txttarjeta.Text = "" Then Exit Sub
            If txtmone.Text = "" Then Exit Sub
            If txtafavor.Text = "" Then Exit Sub
            If txtresta.Text = "" Then Exit Sub
            If txtcambio.Text = "" Then Exit Sub

            Dim MyOpe As Double = resta - (CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txtmone.Text))
            If MyOpe < 0 Then
                txtcambio.Text = FormatNumber(-MyOpe, 2)
                txtresta.Text = "0.00"
            Else
                txtresta.Text = FormatNumber(MyOpe, 2)
                txtcambio.Text = "0.00"
            End If
            txtcambio.Text = FormatNumber(txtcambio.Text, 2)
            txtresta.Text = FormatNumber(txtresta.Text, 2)
        End If
    End Sub

    Private Sub btnBORRA_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtMonedero_Click(sender As Object, e As System.EventArgs) Handles txtMonedero.Click
        txtMonedero.SelectionStart = 0
        txtMonedero.SelectionLength = Len(txtMonedero.Text)
        Foco = 4
        boxBilletes.Enabled = False
    End Sub

    Private Sub txtMonedero_GotFocus(sender As Object, e As System.EventArgs) Handles txtMonedero.GotFocus
        txtMonedero.SelectionStart = 0
        txtMonedero.SelectionLength = Len(txtMonedero.Text)
        Foco = 4
        boxBilletes.Enabled = False
    End Sub

    Private Sub btnENTER_Click(sender As System.Object, e As System.EventArgs) Handles btnENTER.Click
        Dim existe As Boolean = False
        Select Case Foco
            Case Is = 1
                txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
                txttarjeta.Focus().Equals(True)
            Case Is = 2
                txttarjeta.Text = FormatNumber(txttarjeta.Text, 2)
                txtMonedero.Focus().Equals(True)
            Case Is = 4
                'Busca el monedero
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Monedero where Barras='" & txtMonedero.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            existe = True
                            txtsaldo.Text = FormatNumber(rd1("Saldo").ToString, 2)
                        End If
                    End If
                    rd1.Close()

                    If (existe) Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Saldo from MovMonedero where Id=(select max(Id) from MovMonedero where Monedero='" & txtMonedero.Text & "')"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                txtsaldo.Text = IIf(rd1(0).ToString = "", "0", rd1(0).ToString)
                                txtsaldo.Text = FormatNumber(txtsaldo.Text, 2)
                            End If
                        Else
                            txtsaldo.Text = "0.00"
                        End If
                        rd1.Close()
                        txtmone.Focus().Equals(True)
                    Else
                        btnIntro.Focus().Equals(True)
                    End If
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            Case Is = 3
                txtmone.Text = FormatNumber(txtmone.Text, 2)
                btnIntro.Focus().Equals(True)
        End Select
    End Sub

    Private Sub cboNombre_DropDown(sender As System.Object, e As System.EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Nombre from Clientes order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboNombre.Items.Add(
                        rd1(0).ToString
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

    Private Sub txtefectivo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtefectivo.TextChanged
        If txtefectivo.Text = "" Then Exit Sub
        If txttarjeta.Text = "" Then Exit Sub
        If txtmone.Text = "" Then Exit Sub
        If txtafavor.Text = "" Then Exit Sub
        If txtresta.Text = "" Then Exit Sub
        If txtcambio.Text = "" Then Exit Sub

        Dim MyOpe As Double = resta - (CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txtmone.Text))
        If MyOpe < 0 Then
            txtcambio.Text = FormatNumber(-MyOpe, 2)
            txtresta.Text = "0.00"
        Else
            txtresta.Text = FormatNumber(MyOpe, 2)
            txtcambio.Text = "0.00"
        End If
        txtcambio.Text = FormatNumber(txtcambio.Text, 2)
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Dim MyIdCliente As Integer = 0

    Private Sub cboNombre_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboNombre.SelectedValueChanged
        Dim MySaldo As Double = 0

        On Error GoTo 345
        If cboNombre.Text = "" Then Exit Sub

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select * from Clientes where Nombre='" & cboNombre.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                If (rd1("Suspender").ToString) Then MsgBox("Venta suspendida a este cliente." & vbNewLine & "Consulta con el administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : rd1.Close() : cnn1.Close() : Exit Sub
                MyIdCliente = rd1("Id").ToString
                txtcredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                frmVentasTouch3.lbltipoventa.Text = MyIdCliente
                Label20.Visible = True
                txtcredito.Visible = True
                Label17.Visible = True
                txtafavor.Visible = True
                Label18.Visible = True
                txtadeuda.Visible = True

                Dim dire(9) As String
                Dim direccion As String = ""

                dire(0) = rd1("Calle").ToString()       'Calle
                dire(1) = rd1("NInterior").ToString()   'Numero Int
                dire(2) = rd1("NExterior").ToString()   'Numero Ext
                dire(3) = rd1("Colonia").ToString()     'Colonia
                dire(4) = rd1("Delegacion").ToString()  'Delegacion
                dire(5) = rd1("Entidad").ToString()     'Entidad
                dire(6) = rd1("Pais").ToString()        'Pais
                dire(7) = rd1("CP").ToString()          'CP

                'Calle
                If Trim(dire(0)) <> "" Then
                    direccion = direccion & dire(0) & " "
                End If
                'Numero Int
                If Trim(dire(1)) <> "" Then
                    direccion = direccion & dire(1) & " "
                End If
                'Numero Ext
                If Trim(dire(2)) <> "" Then
                    direccion = direccion & dire(2) & " "
                End If
                'Colonia
                If Trim(dire(3)) <> "" Then
                    direccion = direccion & dire(3) & " "
                End If
                'Delegacion
                If Trim(dire(4)) <> "" Then
                    direccion = direccion & dire(4) & " "
                End If
                'Entidad
                If Trim(dire(5)) <> "" Then
                    direccion = direccion & dire(5) & " "
                End If
                'Pais
                If Trim(dire(6)) <> "" Then
                    direccion = direccion & dire(6) & " "
                End If
                'CP
                If Trim(dire(7)) <> "" Then
                    direccion = direccion & "CP " & dire(7) & " "
                End If

                txtDireccion.Text = ""
                txtDireccion.Text = direccion
                txtDireccion.Focus().Equals(True)

            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where IdCliente=" & MyIdCliente & ")"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                If MySaldo < 0 Then
                    txtadeuda.Text = "0.00"
                    txtafavor.Text = Math.Abs(MySaldo)
                    txtafavor.Text = FormatNumber(txtafavor.Text, 2)
                Else
                    txtafavor.Text = "0.00"
                    txtadeuda.Text = Math.Abs(MySaldo)
                    txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
                End If
            End If
        Else
            txtadeuda.Text = "0.00"
            txtafavor.Text = "0.00"
        End If
        rd1.Close()
        cnn1.Close()
        If cboNombre.Text = "" Then frmVentasTouch3.lbltipoventa.Text = "MOSTRADOR" : MyIdCliente = 0
        txtDireccion.Focus().Equals(True)
        Exit Sub
345:
        MsgBox(Err.Number & " - " & Err.Description)
        cnn1.Close()
    End Sub

    Private Sub txttarjeta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txttarjeta.TextChanged
        If txtefectivo.Text = "" Then Exit Sub
        If txttarjeta.Text = "" Then Exit Sub
        If txtmone.Text = "" Then Exit Sub
        If txtafavor.Text = "" Then Exit Sub
        If txtresta.Text = "" Then Exit Sub
        If txtcambio.Text = "" Then Exit Sub

        Dim MyOpe As Double = resta - (CDbl(txtefectivo.Text) + CDbl(txttarjeta.Text) + CDbl(txtmone.Text))
        If MyOpe < 0 Then
            txtcambio.Text = FormatNumber(-MyOpe, 2)
            txtresta.Text = "0.00"
        Else
            txtresta.Text = FormatNumber(MyOpe, 2)
            txtcambio.Text = "0.00"
        End If
        txtcambio.Text = FormatNumber(txtcambio.Text, 2)
        txtresta.Text = FormatNumber(txtresta.Text, 2)
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub txtDireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDireccion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub btn50_Click_1(sender As Object, e As EventArgs) Handles btn50.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 50
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn20_Click_1(sender As Object, e As EventArgs) Handles btn20.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 20
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn100_Click_1(sender As Object, e As EventArgs) Handles btn100.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 100
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn200_Click_1(sender As Object, e As EventArgs) Handles btn200.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 200
        txtefectivo.Text = FormatNumber(Nuevo, 2)

    End Sub

    Private Sub btn500_Click_1(sender As Object, e As EventArgs) Handles btn500.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 500
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub btn1000_Click_1(sender As Object, e As EventArgs) Handles btn1000.Click
        Dim Monto As Double = txtefectivo.Text
        Dim Nuevo As Double = Monto + 1000
        txtefectivo.Text = FormatNumber(Nuevo, 2)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmVentasTouchPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class