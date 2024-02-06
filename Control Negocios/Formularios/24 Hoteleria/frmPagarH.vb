
Imports System.IO
Imports System.Web.Services

Public Class frmPagarH

    Public focoh As Integer = 0
    Public folioventa As Integer = 0
    Private Sub frmPagarH_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
        TFecha.Start()
        Dim total As Double = 0


        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM comandas WHERE NMESA='" & lblHabitacion.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    grdComanda.Rows.Add(rd2("Codigo").ToString,
                                        rd2("Nombre").ToString,
                                        rd2("Cantidad").ToString,
                                        rd2("Precio").ToString,
                                        rd2("Total").ToString
)
                    total = total + CDbl(rd2("total").ToString)

                End If
            Loop
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Cliente FROM detallehotel WHERE Habitacion='" & lblHabitacion.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    If rd2(0).ToString <> "" Then
                        lblCliente.Text = rd2(0).ToString

                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Id FROM Clientes WHERE Nombre='" & lblCliente.Text & "'"
                        rd3 = cmd3.ExecuteReader
                        If rd3.HasRows Then
                            If rd3.Read Then
                                lblNumCliente.Text = rd3(0).ToString
                                lblTipoVenta.Text = rd3(0).ToString
                            End If
                        End If
                        rd3.Close()
                        cnn3.Close()
                    Else
                        lblTipoVenta.Text = "MOSTRADOR"
                        lblNumCliente.Text = "0"
                    End If
                End If
            Else
                lblTipoVenta.Text = "MOSTRADOR"
                lblNumCliente.Text = "0"
            End If
            rd2.Close()

            cnn2.Close()
            txtTotal.Text = total
            txtSubTotal.Text = total
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Timer1.Stop()
        foliov()
        Timer1.Start()
    End Sub

    Public Sub foliov()

        Try
            cnntimer.Close() : cnntimer.Open()
            cmdtimer = cnntimer.CreateCommand
            cmdtimer.CommandText = "SELECT MAX(Folio) FROM Ventas"
            rdtimer = cmdtimer.ExecuteReader
            If rdtimer.HasRows Then
                If rdtimer.Read Then
                    lblfolio.Text = IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString) + 1
                Else
                    lblfolio.Text = "1"
                End If
            Else
                lblfolio.Text = "1"
            End If
            rdtimer.Close()
            cnntimer.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnntimer.Close()
        End Try
    End Sub

    Private Sub TFecha_Tick(sender As Object, e As EventArgs) Handles TFecha.Tick

        TFecha.Stop()
        Me.Text = "Delsscom® Hoteleria - Orden de Salida" & Strings.Space(50) & Date.Now
        lblFecha.Text = Format(Date.Now, "yyyy/MM/dd")
        TFecha.Start()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtEfectivo.Text = "0.00"
        txtdescuento1.Text = "0"
        txtMontoP.Text = "0.00"
    End Sub

    Private Sub txtdescuento1_Click(sender As Object, e As EventArgs) Handles txtdescuento1.Click
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub

    Private Sub txtdescuento1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento1.KeyPress
        If txtdescuento1.Text = "" And AscW(e.KeyChar) = 46 Then
            txtdescuento1.Text = "0.00"
            txtdescuento1.SelectionStart = 0
            txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
            txtdescuento1.Focus().Equals(True)
        End If
        If AscW(e.KeyChar) = Keys.Enter Then

            btnCobrar.Focus().Equals(True)

        End If
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        focoh = 1
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress

        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "" : Exit Sub
        If txtEfectivo.Text = "" And AscW(e.KeyChar) = 46 Then
            txtEfectivo.Text = "0.00"
            txtEfectivo.SelectionStart = 0
            txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
            txtEfectivo.Focus().Equals(True)
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            txtEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            Dim MyOpe As Double = CDbl(IIf(txtTotal.Text = "", "0", txtTotal.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
            If MyOpe < 0 Then
                txtCambio.Text = FormatNumber(-MyOpe, 2)
                txtResta.Text = "0.00"
            Else
                txtResta.Text = FormatNumber(MyOpe, 2)
                txtCambio.Text = "0.00"
            End If
            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)
            btnCobrar.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged

        Dim MyOpe As Double = CDbl(IIf(txtTotal.Text = "", "0", txtTotal.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))
        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)

    End Sub

    Private Sub txtMontoP_TextChanged(sender As Object, e As EventArgs) Handles txtMontoP.TextChanged

        If txtMontoP.Text = "" Then txtMontoP.Text = "0.00"
        If txtEfectivo.Text = "" Then txtEfectivo.Text = "0.00"
        If txtSubTotal.Text = "" Then txtSubTotal.Text = "0.00"

        Dim MyOpe As Double = CDbl(IIf(txtTotal.Text = "", "0", txtTotal.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))

        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)

    End Sub

    Private Sub txtdescuento1_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento1.TextChanged

        If txtdescuento1.Text = "" Then
            txtdescuento1.Text = "0"
            txtTotal.Text = txtSubTotal.Text
            Exit Sub
        End If

        If CDbl(txtdescuento1.Text) > 0 Then
            If grdpago.Rows.Count > 0 Then grdpago.Rows.Clear() : txtMontoP.Text = "0.00"
        End If

        Dim CampoDsct As Double = IIf(txtdescuento1.Text = "", "0", txtdescuento1.Text)
        Dim Desc As Double = 0

        txtdescuento2.Text = (CampoDsct / 100) * CDbl(txtSubTotal.Text)
        txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 2)
        txtTotal.Text = CDbl(txtSubTotal.Text) - ((CampoDsct / 100) * CDbl(txtSubTotal.Text))
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)
        txtResta.Text = CDbl(txtSubTotal.Text) - ((CampoDsct / 100) * CDbl(txtSubTotal.Text))
        txtResta.Text = FormatNumber(txtResta.Text, 2)

        cnn5.Close() : cnn5.Open()

        cmd5 = cnn5.CreateCommand
        cmd5.CommandText =
            "select NotasCred from Formatos where Facturas='Mdescuento'"
        rd5 = cmd5.ExecuteReader
        If rd5.HasRows Then
            If rd5.Read Then
                Desc = rd5(0).ToString
                If CampoDsct = 0 Then
                    txtdescuento2.Text = "0.00"
                    txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) - (CDbl(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) - CDbl(txtCambio.Text)), 2)
                    CampoDsct = 0
                    txtTotal.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                    Exit Sub
                End If
                If CampoDsct > Desc Then
                    MsgBox("No puedes rebasar el descuento máximo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    CampoDsct = 0
                    txtdescuento2.Text = "0.00"
                    txtdescuento1.Text = "0"
                    txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtMontoP.Text), 2)
                    txtTotal.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                    txtdescuento1.SelectionStart = 0
                    txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
                    Exit Sub
                End If
            End If
        Else
            If CampoDsct <> 0 Then
                MsgBox("Establece un máximo de descuento por venta para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                CampoDsct = 0
                txtdescuento1.SelectionStart = 0
                txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
                rd5.Close() : cnn5.Close()
                Exit Sub
            End If
        End If
        rd5.Close() : cnn5.Close()

    End Sub

    Private Sub txtdescuento2_GotFocus(sender As Object, e As EventArgs) Handles txtdescuento2.GotFocus
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub

    Private Sub txtdescuento2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento2.KeyPress
        If Not IsNumeric(txtdescuento2.Text) Then txtdescuento2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 2)
            txtTotal.Text = FormatNumber(CDbl(IIf(txtTotal.Text = "", "0", txtTotal.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtResta.Text = FormatNumber(CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtEfectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdescuento2_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento2.TextChanged
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub

    Private Sub txtEfectivo_GotFocus(sender As Object, e As EventArgs) Handles txtEfectivo.GotFocus
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
    End Sub

    Private Sub txtEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyDown
        txtEfectivo.ReadOnly = False
    End Sub

    Private Sub txtContra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContra.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Alias,Status FROM usuarios WHERE Clave='" & txtContra.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.Read Then
                    If rd1.HasRows Then

                        If rd1(1).ToString = 1 Then
                            lblAtendio.Text = rd1(0).ToString
                        Else
                            MsgBox("El usuario no esta activo contacte a su administrador", vbInformation + vbOKOnly, titulohotelriaa)
                            txtContra.Text = ""
                            txtContra.Focus.Equals(True)
                        End If

                    End If
                Else
                    MsgBox("La contraseña es incorrecta.", vbInformation + vbOKOnly, titulohotelriaa)
                    txtContra.Focus.Equals(True)
                    txtContra.Text = ""
                End If
                rd1.Close()
                cnn1.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "20"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn50_Click(sender As Object, e As EventArgs) Handles btn50.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "50"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "100"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn200_Click(sender As Object, e As EventArgs) Handles btn200.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "200"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "500"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "1000"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "1"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.Close()
        frmManejo.Show()
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

    Private Sub cbotpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotpago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus.Equals(True)
        End If
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

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumref.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtComentarioPago.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtnumref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumref.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim saldo As Double = 0

            If IsNumeric(txtnumref.Text) Then

                If cbotpago.Text = "MONEDERO" Then
                    Try
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * FROM Monedero WHERE Barras='" & txtnumref.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                txtsaldo_monedero.Text = FormatNumber(IIf(rd1("Saldo").ToString() = "0", "0", rd1("Saldo").ToString()), 2)
                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                End If

                txtmonto.Focus.Equals(True)
            Else
                txtnumref.Text = ""
                txtnumref.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub txtComentarioPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentarioPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFecha_P.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpFecha_P_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFecha_P.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuentaRecepcion.Focus.Equals(True)
        End If
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

    Private Sub cboCuentaRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuentaRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBancoRecepcion.Focus.Equals(True)
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

    Private Sub cboBancoRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBancoRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnPagos.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnPagos_Click(sender As Object, e As EventArgs) Handles btnPagos.Click
        Dim tipo As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim referencia As String = txtnumref.Text
        Dim monto As Double = txtmonto.Text
        Dim comentario As String = txtComentarioPago.Text
        Dim fecha As Date = Format(dtpFecha_P.Value, "yyyy-MM-dd")
        Dim cuenta As String = cboCuentaRecepcion.Text
        Dim bancor As String = cboBancoRecepcion.Text
        Dim totalpagos As Double = 0

        grdpago.Rows.Add(tipo, banco, referencia, monto, fecha, comentario, bancor, cuenta)

        totalpagos = txtMontoP.Text + CDbl(monto)
        txtMontoP.Text = FormatNumber(totalpagos, 2)
        limpiarpagos()
    End Sub

    Public Sub limpiarpagos()
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtnumref.Text = ""
        txtmonto.Text = ""
        txtComentarioPago.Text = ""
        dtpFecha_P.Value = Date.Now
        cboCuentaRecepcion.Text = ""
        cboBancoRecepcion.Text = ""
    End Sub

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick

        Dim index As Integer = grdpago.CurrentRow.Index

        Dim importe = grdpago.Rows(index).Cells(3).Value.ToString

        grdpago.Rows.Remove(grdpago.Rows(index))
        txtMontoP.Text = txtMontoP.Text - CDec(importe)
        txtMontoP.Text = FormatNumber(txtMontoP.Text, 2)

    End Sub

    Private Sub btnCobrar_Click(sender As Object, e As EventArgs) Handles btnCobrar.Click

        Dim mypago As Double = 0
        Dim tipopago As String = ""
        Dim foliomonedro As String = ""
        Dim montomonedero As Double = 0
        Dim idmonedero As Integer = 0
        Dim saldomonedero As Double = 0
        Dim porcentajemonedero As Double = 0
        Dim saldomonnuevo As Double = 0

        Dim codigo As String = ""
        Dim cantidad As Double = 0



        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM VtaImpresion"
        cmd1.ExecuteNonQuery()
        cnn1.Close()


        mypago = CDbl(txtEfectivo.Text) + CDbl(txtMontoP.Text) - CDbl(txtCambio.Text)

        If mypago < txtTotal.Text Then
            MsgBox("Debe cerrar la cuenta!.", vbInformation + vbOKOnly, titulohotelriaa)
            Exit Sub
        End If

        If grdpago.Rows.Count > 0 Then
            For dekua As Integer = 0 To grdpago.Rows.Count - 1
                tipopago = grdpago.Rows(dekua).Cells(0).Value.ToString

                If tipopago = "MONEDERO" Then
                    foliomonedro = grdpago.Rows(dekua).Cells(2).Value.ToString
                    montomonedero = grdpago.Rows(dekua).Cells(3).Value.ToString

                    If foliomonedro <> "" Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Monedero WHERE Barras='" & foliomonedro & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                idmonedero = rd2("Id").ToString
                                saldomonedero = rd2("Saldo").ToString
                                porcentajemonedero = rd2("Porcentaje").ToString
                            End If
                        End If
                        rd2.Close()

                        Dim porcentajenuevo As Double = 0
                        saldomonnuevo = CDec(CDec(txtTotal.Text) - CDec(montomonedero)) * CDec(porcentajemonedero / 100)

                        Dim conversaldo As String = ""
                        conversaldo = ""
                        For i = 1 To Len(saldomonnuevo)
                            If Mid(saldomonnuevo, i, 1) = "." Then
                                Exit For
                            End If
                            conversaldo = saldomonnuevo
                        Next i
                        saldomonnuevo = conversaldo

                        cnn2.Close()
                    End If
                End If
            Next
        End If

        Dim mypagomonedero As Double = 0
        mypagomonedero = mypagomonedero + montomonedero

        Dim myidcliente As Integer = 0


        Dim cuenta As Double = 0
        Dim subtotal1 As Double = 0
        Dim totcomi As Double = 0
        Dim tIVA As Double = 0
        Dim OPE As Double = 0


        If CDec(txtTotal.Text) <= CDec(cuenta) Then
            cuenta = txtTotal.Text
            txtResta.Text = 0
        End If
        cuenta = FormatNumber(cuenta, 2)

        For dx As Integer = 0 To grdComanda.Rows.Count - 1
            codigo = grdComanda.Rows(dx).Cells(0).Value.ToString
            cantidad = grdComanda.Rows(dx).Cells(2).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    totcomi = totcomi + CDec(CDec(cantidad) * CDec(rd2("Comision").ToString))
                    If rd2("IVA").ToString = 0 Then

                    Else
                        If CDec(grdComanda.Rows(dx).Cells(3).Value.ToString) > 0 Then

                            ' subtotal1 = subtotal1 + CDec(grdComanda.Rows(dx).Cells(4).Value.ToString) / (1 * rd2("IVA").ToString)

                            OPE = FormatNumber(CDec(grdComanda.Rows(dx).Cells(4).Value.ToString) / 1.16, 2)
                            tIVA = tIVA + CDec(OPE)
                            tIVA = FormatNumber(tIVA, 2)
                        End If
                    End If

                End If

            End If

            rd2.Close()
            cnn2.Close()

        Next
        tIVA = FormatNumber(tIVA, 2)

        If lblCliente.Text = "" Then
            If (lblTipoVenta.Text = "MOSTRADOR" And txtResta.Text <> 0) Then
                MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, titulohotelriaa)
                Exit Sub
            End If

            If lblNumCliente.Text = 0 Then
                If txtResta.Text > 0 Then
                    MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, titulohotelriaa)
                    Exit Sub
                End If
            End If
        End If

        If txtResta.Text <> 0 Then
            If lblCliente.Text = "" Then
                MsgBox("Debes liquidar el total de la venta para continuar." & vbNewLine & "De la contrario selecciona un cliente con crédito disponible.", vbInformation + vbOKOnly, titulohotelriaa)
                frmVentasTouchPago.txtefectivo.Focus().Equals(True)
                Exit Sub
            End If
        End If


        If MsgBox("¿Desea guardar los datos de esta venta?", vbQuestion + vbYesNo + vbDefaultButton1) = vbNo Then
            Exit Sub
        End If

        Dim credito_cliente As Double = 0
        Dim afavor_cliente As Double = 0
        Dim adeuda_cliente As Double = 0
        Dim mysaldocliente As Double = 0

        cnn1.Close() : cnn1.Open()

        If lblCliente.Text = "" Then
            lblNumCliente.Text = "0"
            credito_cliente = 0
            afavor_cliente = 0
            adeuda_cliente = 0
        Else
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Clientes WHERE Nombre='" & lblCliente.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblNumCliente.Text = rd1("Id").ToString
                    credito_cliente = rd1("Credito").ToString
                End If
            Else
                lblNumCliente.Text = "0"
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM Abonoi WHERE Id=(SELECT MAX(Id) from Abonoi WHERE IdCliente=" & lblNumCliente.Text & ")"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    mysaldocliente = CDec(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                    If mysaldocliente = 0 Then
                        adeuda_cliente = 0
                        afavor_cliente = Math.Abs(mysaldocliente)
                        afavor_cliente = FormatNumber(afavor_cliente, 2)
                    Else
                        afavor_cliente = 0
                        adeuda_cliente = Math.Abs(mysaldocliente)
                        adeuda_cliente = FormatNumber(adeuda_cliente, 2)
                    End If

                End If
            Else
                adeuda_cliente = 0
                afavor_cliente = 0
            End If
            rd1.Close()
            cnn1.Close()

        End If


#Region "CODIGO AUTOFACTURACION"

        Dim letras As String
        Dim letters As String = ""
        Dim pc As String = lblfolio.Text
        Dim opee As Double = 0
        Dim lic As String = ""
        Dim numeros As String
        Dim car As String

        opee = Math.Cos(CDec(pc))
        If opee > 0 Then
            pc = Strings.Left(Replace(CStr(opee), ".", "9"), 10)
        Else
            pc = Strings.Left(Replace(CStr(Math.Abs(opee)), ".", "8"), 10)
        End If
        For i = 1 To 10
            car = Mid(lblfolio.Text, i, 1)
            Select Case car
                Case Is = 0
                    letters = letters & "Y"
                Case Is = 1
                    letters = letters & "Z"
                Case Is = 2
                    letters = letters & "W"
                Case Is = 3
                    letters = letters & "X"
                Case Is = 4
                    letters = letters & "T"
                Case Is = 5
                    letters = letters & "B"
                Case Is = 6
                    letters = letters & "A"
                Case Is = 7
                    letters = letters & "D"
                Case Is = 8
                    letters = letters & "C"
                Case Is = 9
                    letters = letters & "P"
                Case Else
                    letters = letters & car
            End Select

        Next
        For i = 1 To 10 Step 2
            numeros = Mid(pc, i, 2)
            letras = Mid(letters, i, 2)
            lic = lic & numeros & letras & "-"
        Next
        lic = Strings.Left(lic, lic.Length - 1)

#End Region

        Dim EFECTIVOVENTA As Double = 0
        EFECTIVOVENTA = txtEfectivo.Text

        Dim TOTALVENTA As Double = 0
        TOTALVENTA = txtTotal.Text

        Dim RESTAVENTA As Double = 0
        RESTAVENTA = txtResta.Text

        Dim CAMBIOVENTA As Double = 0
        CAMBIOVENTA = txtCambio.Text

        Dim DESCUENTOVENTA As Double = 0
        DESCUENTOVENTA = txtdescuento2.Text

        Dim PAGOSVENTA As Double = 0
        PAGOSVENTA = txtMontoP.Text

        Dim credito_dispo As Double = (credito_cliente + afavor_cliente) - ((CDbl(txtTotal.Text) + adeuda_cliente) - (EFECTIVOVENTA + PAGOSVENTA))

        If txtResta.Text > 0 Then
            If lblTipoVenta.Text <> "MOSTRADOR" And ((CDbl(txtTotal.Text) + adeuda_cliente) - (PAGOSVENTA + EFECTIVOVENTA)) > (credito_cliente + afavor_cliente) Then
                MsgBox("No se puede completar la operación porque se rebasaría el crédito disponible." & vbNewLine & "Crédito disponible: " & FormatNumber(credito_cliente - adeuda_cliente, 2) & ".", vbInformation + vbOKOnly, titulohotelriaa)
                cnn1.Close() : frmVentasTouchPago.txtefectivo.Focus().Equals(True) : Exit Sub
            End If
        End If

        Dim MyStatus As String = ""
        Dim ACUENTA As Double = 0
        Dim ACUENTA2 As Double = 0
        Dim mymonto As Double = 0
        Dim subtotal As Double = 0

        Select Case lblTipoVenta.Text
            Case Is = "MOSTRADOR"
                lblNumCliente.Text = "0"
                lblCliente.Text = ""
                ACUENTA = FormatNumber((EFECTIVOVENTA - CAMBIOVENTA) + PAGOSVENTA, 2)
                subtotal1 = FormatNumber(subtotal1, 2)

                If txtResta.Text = 0 Then
                    MyStatus = "PAGADO"
                Else
                    MyStatus = "RESTA"
                End If
                subtotal = TOTALVENTA - CDec(tIVA)

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Propina,Descuento,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,TComensales,Corte,CorteU,CodFactura,IP) VALUES(" & lblNumCliente.Text & ",'" & lblCliente.Text & "',''," & subtotal & "," & tIVA & "," & TOTALVENTA & "," & ACUENTA & "," & RESTAVENTA & ",0," & DESCUENTOVENTA & ",'" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & MyStatus & "','" & totcomi & "',1,1,0,'" & lic & "','" & dameIP2() & "')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()

            Case Is <> "MOSTRADOR"
                mymonto = EFECTIVOVENTA + PAGOSVENTA + afavor_cliente - CAMBIOVENTA
                subtotal1 = FormatNumber(subtotal1, 2)

                If mymonto < CDec(TOTALVENTA) Then
                    ACUENTA2 = FormatNumber(CDbl(txtTotal.Text), 2)
                    txtResta.Text = "0"
                Else
                    ACUENTA2 = FormatNumber(mymonto, 2)
                    txtResta.Text = FormatNumber(CDbl(txtTotal.Text) - mymonto, 2)
                End If

                If txtResta.Text = 0 Then
                    MyStatus = "PAGADO"
                Else
                    MyStatus = "RESTA"
                End If
                subtotal = TOTALVENTA - CDec(tIVA)

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "insert into Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,Descuento,Devolucion,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,Concepto,MontoSinDesc,FEntrega,Comentario,StatusE,IP,Propina,CodFactura) values(" & lblNumCliente.Text & ",'" & lblCliente.Text & "',''," & subtotal & "," & tIVA & "," & TOTALVENTA & "," & DESCUENTOVENTA & ",0," & ACUENTA2 & "," & RESTAVENTA & ",'" & lblAtendio.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','','" & MyStatus & "','',''," & DESCUENTOVENTA & ",'','',0,'" & dameIP2() & "',0,'" & lic & "')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()
        End Select



        If montomonedero > 0 Then
            If CDec(montomonedero) = CDec(txtTotal.Text) Then
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "UPDATE Monedero SET Saldo=Saldo + " & CDec(saldomonnuevo) & ", Cargado='0' WHERE Id=" & idmonedero & ""
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If

        Else

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "UPDATE Monedero set Saldo = Saldo + " & saldomonnuevo & " WHERE Id=" & idmonedero & ""
            cmd4.ExecuteNonQuery()
            cnn4.Close()

        End If

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT MAX(Folio) FROM Ventas"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                folioventa = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        Dim MYSALDO As Double = 0
        If lblTipoVenta.Text <> "MOSTRADOR" Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo FROM Abonoi WHERE Id=(SELECT MAX(Id) FROM Abonoi WHERE IdCliente=" & lblTipoVenta.Text & ")"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) + CDbl(txtTotal.Text), 2)
                End If
            Else
                MYSALDO = FormatNumber(txtTotal.Text, 2)
            End If
            rd1.Close()

            If RESTAVENTA > 0 And afavor_cliente > 0 And CDbl(TOTALVENTA) = txtResta.Text Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Usuario,MontoSF) values(" & folioventa & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & TOTALVENTA & ",0," & MYSALDO & ",0,'',0,'','','" & lblAtendio.Text & "'," & txtResta.Text & ")"
                cmd1.ExecuteNonQuery()
            Else
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Usuario) values(" & folioventa & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','NOTA VENTA','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & TOTALVENTA & ",0," & MYSALDO & ",0,'',0,'','','" & lblAtendio.Text & "')"
                cmd1.ExecuteNonQuery()
            End If



        End If

        ACUENTA = FormatNumber(EFECTIVOVENTA - CAMBIOVENTA + PAGOSVENTA, 2)

        If ACUENTA > 0 Then
            Dim EfectivoX As Double = FormatNumber(EFECTIVOVENTA - CAMBIOVENTA, 2)

            If grdpago.Rows.Count > 0 Then
                For tobi As Integer = 0 To grdpago.Rows.Count - 1

                    Dim formapago As String = grdpago.Rows(tobi).Cells(0).Value.ToString
                    Dim bancopago As String = grdpago.Rows(tobi).Cells(1).Value.ToString
                    Dim referenciapago As String = grdpago.Rows(tobi).Cells(2).Value.ToString
                    Dim montopago As Double = grdpago.Rows(tobi).Cells(3).Value.ToString
                    Dim comentariopago As String = grdpago.Rows(tobi).Cells(5).Value.ToString
                    Dim cuentarefe As String = grdpago.Rows(tobi).Cells(6).Value.ToString
                    Dim bancorefe As String = grdpago.Rows(tobi).Cells(7).Value.ToString

                    Select Case lblTipoVenta.Text
                        Case Is = "MOSTRADOR"

                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                        "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,,Usuario) values(" & folioventa & ",0,'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & ",0,0,'" & formapago & "'," & montopago & ",'" & bancopago & "','" & referenciapago & "','" & comentariopago & "','" & lblAtendio.Text & "')"
                            cmd1.ExecuteNonQuery()

                        Case Is <> "MOSTRADOR"
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                        "select Saldo from Abonoi where Id=(select MAX(Id) from Abonoi where IdCliente=" & lblTipoVenta.Text & ")"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then
                                    MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACUENTA, 2)
                                End If
                            Else
                                MYSALDO = FormatNumber(TOTALVENTA, 2)
                            End If
                            rd1.Close()

                            If RESTAVENTA > 0 And afavor_cliente > 0 Then
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                            "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,MontoSF) values(" & folioventa & "," & lblNumCliente.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & "," & MYSALDO & ",0,'" & formapago & "'," & montopago & ",'" & bancopago & "','" & referenciapago & "','" & cuentarefe & "'," & bancorefe & "','" & referenciapago & "','" & comentariopago & "','" & lblAtendio.Text & "'," & RESTAVENTA & ")"
                                cmd1.ExecuteNonQuery()
                            Else
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                            "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario) values(" & folioventa & "," & lblNumCliente.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & "," & MYSALDO & ",0,'" & formapago & "'," & montopago & ",'" & bancopago & "','" & referenciapago & "','" & comentariopago & "','" & lblAtendio.Text & "')"
                                cmd1.ExecuteNonQuery()
                            End If

                    End Select
                Next
            End If
            cnn1.Close()
            cnn1.Close() : cnn1.Open()

            If EfectivoX > 0 Then
                Select Case lblTipoVenta.Text
                    Case Is = "MOSTRADOR"
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                    "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario) values(" & folioventa & "," & lblNumCliente.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & ",0,0,'',0,'','','','" & lblAtendio.Text & "')"
                        cmd1.ExecuteNonQuery()

                    Case Is <> "MOSTRADOR"

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                    "select Saldo from Abonoi where Id=(select MAX(Id) from Abonoi where IdCliente=" & lblTipoVenta.Text & ")"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                MYSALDO = FormatNumber(IIf(rd1(0).ToString = "", 0, rd1(0).ToString) - ACUENTA, 2)
                            End If
                        Else
                            MYSALDO = FormatNumber(TOTALVENTA, 2)
                        End If
                        rd1.Close()

                        If RESTAVENTA > 0 And afavor_cliente > 0 Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                        "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario,MontoSF) values(" & folioventa & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & "," & MYSALDO & ",0,'',0,'','','','" & lblAtendio.Text & "'," & RESTAVENTA & ")"
                            cmd1.ExecuteNonQuery()
                        Else
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                        "insert into Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,Propina,FormaPago,Monto,Banco,Referencia,Comentario,Usuario) values(" & folioventa & "," & lblTipoVenta.Text & ",'" & lblCliente.Text & "','ABONO','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "',0," & ACUENTA & "," & MYSALDO & ",0,'',0,'','','','" & lblAtendio.Text & "')"
                            cmd1.ExecuteNonQuery()
                        End If
                End Select
            End If
        End If
        rd1.Close()
        cnn1.Close()

        If CDec(montomonedero) > 0 Then
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE Monedero SET Saldo=Saldo- " & CDec(montomonedero) & " where Id=" & idmonedero & ""
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        End If

        For pain As Integer = 0 To grdComanda.Rows.Count - 1

            Dim codigop As String = grdComanda.Rows(pain).Cells(0).Value.ToString
            Dim nombrep As String = grdComanda.Rows(pain).Cells(1).Value.ToString
            Dim cantidadp As Double = grdComanda.Rows(pain).Cells(2).Value.ToString
            Dim preciop As Double = grdComanda.Rows(pain).Cells(3).Value.ToString
            Dim totalp As Double = grdComanda.Rows(pain).Cells(4).Value.ToString


            Dim existencia_inicial As Double = 0
            Dim opeCantReal As Integer = 0
            Dim opediferencia As Integer = 0

            Dim unidadp As String = ""
            Dim ivap As Double = 0
            Dim MyPrecioSin As Double = 0
            Dim MyTotalSin As Double = 0

            Dim MyCostVUE As Double = 0
            Dim MyProm As Double = 0
            Dim MyDepto As String = ""
            Dim MyGrupo As String = ""
            Dim MyMCD As Double = 0
            Dim MyMult2 As Double = 0
            Dim GImpre As String = ""

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos where Codigo='" & codigop & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    unidadp = rd2("UVenta").ToString
                    ivap = rd2("IVA").ToString
                    MyPrecioSin = IIf(preciop = 0, 0, preciop) / (1 * ivap)
                    MyTotalSin = IIf(totalp = 0, 0, totalp) / (1 * ivap)

                    If rd2("Departamento").ToString = "SERVICIOS" Then
                        MyCostVUE = 0
                        MyProm = 0
                        MyDepto = rd2("Departamento").ToString
                        MyGrupo = rd2("Grupo").ToString
                    End If

                    MyMCD = rd2("MCD").ToString
                    MyMult2 = rd2("Multiplo").ToString
                    MyDepto = rd2("Departamento").ToString
                    MyGrupo = rd2("Grupo").ToString
                    GImpre = rd2("GPrint").ToString

                    existencia_inicial = rd2("Existencia").ToString
                    opeCantReal = CDec(grdComanda.Rows(pain).Cells(2).Value.ToString) * CDec(rd2("Multiplo").ToString)
                    opediferencia = existencia_inicial - opeCantReal

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Inicial,Cantidad,Precio,Fecha,Usuario,Final,Folio) VALUES('" & rd2("Codigo").ToString & "','" & rd2("Nombre").ToString & "','Venta'," & existencia_inicial & "," & opeCantReal & "," & rd2("PrecioCompra").ToString & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblAtendio.Text & "'," & opediferencia & ",' ')"
                    cmd4.ExecuteNonQuery()

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "UPDATE Productos SET Existencia=Existencia-" & grdComanda.Rows(pain).Cells(2).Value.ToString & "* " & MyMult2 & " where Codigo='" & grdComanda.Rows(pain).Cells(0).Value.ToString & "'"
                    cmd4.ExecuteNonQuery()
                    cnn4.Close()

                End If
            Else
                unidadp = "PZA"
                ivap = "0"
                MyMCD = "1"
                MyMult2 = "1"
                MyDepto = "HABITACION"
                MyGrupo = "HABITACION"
                MyPrecioSin = preciop
                MyTotalSin = totalp
                cantidadp = "1"
            End If
            rd2.Close()
            cnn2.Close()

            Dim vartasa As String = ""
            Dim vartotal As String = ""

            vartasa = 0
            vartotal = 0

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "INSERT INTO VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,GPrint,Comentario,TasaIeps,TotalIEPS,Comensal,Facturado) VALUES(" & folioventa & ",'" & codigop & "','" & nombrep & "'," & cantidadp & ",'" & unidadp & "'," & MyCostVUE & "," & IIf(MyProm, 0, MyProm) & "," & preciop & "," & totalp & "," & MyPrecioSin & "," & MyTotalSin & ",'0','" & Format(Date.Now, "yyyy/MM/dd") & "','" & MyDepto & "','" & MyGrupo & "','" & GImpre & "',''," & vartasa & "," & vartotal & ",'1','0')"
            cmd4.ExecuteNonQuery()
            cnn4.Close()

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "INSERT INTO vtaImpresion(Folio,Codigo,Nombre,Cantidad,UVenta,CostVR,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Facturado,Mesa) VALUES(" & folioventa & ",'" & codigop & "','" & nombrep & "'," & cantidadp & ",'" & unidadp & "',0," & MyCostVUE & "," & IIf(MyProm, 0, MyProm) & "," & preciop & "," & totalp & "," & MyPrecioSin & "," & MyTotalSin & ",'0','" & Format(Date.Now, "yyyy/MM/dd") & "','" & MyDepto & "','" & MyGrupo & "','1','0','" & lblHabitacion.Text & "')"
            cmd4.ExecuteNonQuery()
            cnn4.Close()


        Next

        If saldomonnuevo <> 0 Then

            Dim saldomonederoactual As Double = 0

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Saldo FROM monedero WHERE Barras='" & foliomonedro & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    saldomonederoactual = rd2(0).ToString
                End If
            End If
            rd2.Close()


            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & foliomonedro & "','Asigna Puntos'," & saldomonnuevo & ",0," & CDbl(saldomonederoactual) & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MyFolio & ")"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
            cnn2.Close()
        End If

        If montomonedero <> 0 Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "INSERT INTO MovMonedero(Monedero,Concepto,Abono,Cargo,Fecha,Hora,Folio) VALUES('" & foliomonedro & "','Pago Puntos',0," & montomonedero & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MyFolio & ")"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        End If


        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "DELETE FROM detallehotel WHERE Habitacion='" & lblHabitacion.Text & "'"
        cmd2.ExecuteNonQuery()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "DELETE FROM asigpc WHERE Nombre='" & lblHabitacion.Text & "'"
        cmd2.ExecuteNonQuery()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "UPDATE Rep_Comandas SET Status='PAGADA' WHERE NMESA='" & lblHabitacion.Text & "' AND Status<>'CANCELADA'"
        cmd2.ExecuteNonQuery()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & lblHabitacion.Text & "'"
        cmd2.ExecuteNonQuery()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "DELETE FROM comandas WHERE Nmesa='" & lblHabitacion.Text & "'"
        cmd2.ExecuteNonQuery()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "UPDATE habitacion SET Estado='Desocupada' WHERE N_Habitacion='" & lblHabitacion.Text & "'"
        cmd2.ExecuteNonQuery()
        cnn2.Close()

        'imprimir ticket

        Dim tamimpre As Integer = 0
        Dim imprimirticket As Integer = 0
        Dim copiasticket As Integer = 0
        Dim pasa_print As Boolean = False

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                tamimpre = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NoPrint,Copias FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                imprimirticket = rd1(0).ToString
                copiasticket = rd1(1).ToString
            End If
        End If
        rd1.Close()

        If (imprimirticket) Then
            If MsgBox("¿Deseas imprimir nota de venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                pasa_print = True
            Else
                pasa_print = False
            End If
        Else
            pasa_print = True
        End If

        If (pasa_print) Then
            Dim papel As String = ""
            Dim impresoraventa As String = ""
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Formato FROM RutasImpresion WHERE Tipo='Venta'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    papel = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='" & papel & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresoraventa = rd1(0).ToString
                End If
            End If
            rd1.Close()

            If tamimpre = "80" Then
                PVenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresoraventa
                PVenta80.Print()
            End If

            If tamimpre = "58" Then
                PVenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresoraventa
                PVenta58.Print()
            End If

        End If
        cnn1.Close()

        Me.Close()
        frmManejo.Show()
        frmManejo.pUbicaciones.Controls.Clear()
        frmManejo.pHab.Controls.Clear()
        frmManejo.TRAERUBICACION()

    End Sub

    Private Sub PVenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim facLinea As Integer = DatosRecarga("AutoFac")

        Dim foliofactura As String = ""
        Dim articulos As Integer = 0
        Dim Pie1 As String = ""

        Try

            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                    Y += 130
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                    Y += 120
                End If
            Else
                Y = 0
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    foliofactura = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie1 = rd2("Pie3").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                        Y += 12
                    End If
                    Y += 5
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 135, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Habitación: " & lblHabitacion.Text, fuente_r, Brushes.Black, 1, Y)

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            For luffy As Integer = 0 To grdComanda.Rows.Count - 1

                Dim cantidad As Double = grdComanda.Rows(luffy).Cells(2).Value.ToString
                Dim descripcion As String = grdComanda.Rows(luffy).Cells(1).Value.ToString
                Dim precio As Double = grdComanda.Rows(luffy).Cells(3).Value.ToString
                Dim total As Double = grdComanda.Rows(luffy).Cells(4).Value.ToString


                e.Graphics.DrawString(cantidad, fuente_p, Brushes.Black, 1, Y)

                Dim caracteresPorLinea3 As Integer = 27
                Dim texto3 As String = descripcion
                Dim inicio3 As Integer = 0
                Dim longitudTexto3 As Integer = texto3.Length

                While inicio3 < longitudTexto3
                    Dim longitudBloque3 As Integer = Math.Min(caracteresPorLinea3, longitudTexto3 - inicio3)
                    Dim bloque3 As String = texto3.Substring(inicio3, longitudBloque3)
                    e.Graphics.DrawString(bloque3, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 30, Y)
                    Y += 13
                    inicio3 += caracteresPorLinea3
                End While

                e.Graphics.DrawString(simbolo & " " & precio, fuente_p, Brushes.Black, 205, Y, derecha)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(total, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                Y += 13

                articulos = articulos + cantidad

                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Next
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 25

            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubTotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            If txtdescuento2.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtdescuento2.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            For deku As Integer = 0 To grdpago.Rows.Count - 1

                Dim formapago As String = grdpago.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdpago.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdpago.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdpago.Rows(deku).Cells(3).Value.ToString

                If formapago = "MONEDERO" Then

                    e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 150, Y)
                    Y += 20
                Else
                    If montopago > 0 Then
                        e.Graphics.DrawString("PAGO EN " & formapago & ":", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                        Y += 20
                        e.Graphics.DrawString("BANCO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(bancopago, fuente_b, Brushes.Black, 100, Y)
                        Y += 20
                        e.Graphics.DrawString("NUM TARJ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 100, Y)
                        Y += 20
                    End If
                End If

            Next

            If CDec(txtResta.Text) <> 0 Then
                e.Graphics.DrawString("RESTA: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtResta.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            If CDec(txtCambio.Text) <> 0 Then
                e.Graphics.DrawString("CAMBIO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtCambio.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 10
            End If
            Y += 15

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(txtTotal.Text)

            Dim caracteresPorLinea As Integer = 33
            Dim texto As String = cantidadLetra
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While
            Y += 5

            Dim caracteresPorLinea2 As Integer = 27
            Dim texto2 As String = Pie1
            Dim inicio2 As Integer = 0
            Dim longitudTexto2 As Integer = texto2.Length

            While inicio2 < longitudTexto2
                Dim longitudBloque2 As Integer = Math.Min(caracteresPorLinea2, longitudTexto2 - inicio2)
                Dim bloque2 As String = texto2.Substring(inicio2, longitudBloque2)
                e.Graphics.DrawString(bloque2, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                Y += 13
                inicio2 += caracteresPorLinea2
            End While
            Y += 5

            e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 20

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 135, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 135, Y, sc)
            Else

            End If
            cnn2.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub PVenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVenta58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim Logotipo As Drawing.Image = Nothing
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")
        Dim facLinea As Integer = DatosRecarga("AutoFac")
        Dim foliofactura As String = ""

        Dim pie1 As String = ""
        Dim articulos As Integer = 0

        Try

            If tLogo <> "SIN" Then
                If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                    Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                End If
                If tLogo = "CUAD" Then
                    e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                    Y += 90
                End If
                If tLogo = "RECT" Then
                    e.Graphics.DrawImage(Logotipo, 12, 0, 160, 80)
                    Y += 140
                End If
            Else
                Y = 0
            End If
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folioventa
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    foliofactura = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie1 = rd2("Pie3").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, sc)
                        Y += 12
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, sc)
                        Y += 11
                    End If
                    Y += 3
                End If
            Else
                Y += 0
            End If
            rd2.Close()

            e.Graphics.DrawString("-------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("--------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Habitación: " & lblHabitacion.Text, fuente_r, Brushes.Black, 1, Y)

            e.Graphics.DrawString("Folio: " & folioventa, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("--------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20

            For luffy As Integer = 0 To grdComanda.Rows.Count - 1

                Dim cantidad As Double = grdComanda.Rows(luffy).Cells(2).Value.ToString
                Dim descripcion As String = grdComanda.Rows(luffy).Cells(1).Value.ToString
                Dim precio As Double = grdComanda.Rows(luffy).Cells(3).Value.ToString
                Dim total As Double = grdComanda.Rows(luffy).Cells(4).Value.ToString


                e.Graphics.DrawString(cantidad, fuente_p, Brushes.Black, 1, Y)

                Dim caracteresPorLinea3 As Integer = 25
                Dim texto3 As String = descripcion
                Dim inicio3 As Integer = 0
                Dim longitudTexto3 As Integer = texto3.Length

                While inicio3 < longitudTexto3
                    Dim longitudBloque3 As Integer = Math.Min(caracteresPorLinea3, longitudTexto3 - inicio3)
                    Dim bloque3 As String = texto3.Substring(inicio3, longitudBloque3)
                    e.Graphics.DrawString(bloque3, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 30, Y)
                    Y += 13
                    inicio3 += caracteresPorLinea3
                End While

                e.Graphics.DrawString(simbolo & " " & precio, fuente_p, Brushes.Black, 128, Y, derecha)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(total, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                Y += 13

                articulos = articulos + cantidad

                e.Graphics.DrawString("-----------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Next
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubTotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            If txtdescuento2.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtdescuento2.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            For deku As Integer = 0 To grdpago.Rows.Count - 1

                Dim formapago As String = grdpago.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdpago.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdpago.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdpago.Rows(deku).Cells(3).Value.ToString

                If formapago = "MONEDERO" Then

                    e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 100, Y)
                    Y += 15
                Else
                    If montopago > 0 Then
                        e.Graphics.DrawString("PAGO EN " & formapago & ":", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                        Y += 15
                        e.Graphics.DrawString("BANCO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(bancopago, fuente_b, Brushes.Black, 80, Y)
                        Y += 15
                        e.Graphics.DrawString("NUM TARJ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 80, Y)
                        Y += 15
                    End If
                End If

            Next

            If CDec(txtResta.Text) <> 0 Then
                e.Graphics.DrawString("RESTA: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtResta.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 10
            End If

            If CDec(txtCambio.Text) <> 0 Then
                e.Graphics.DrawString("CAMBIO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtCambio.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 10
            End If
            Y += 10

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(txtTotal.Text)

            Dim caracteresPorLinea As Integer = 22
            Dim texto As String = cantidadLetra
            Dim inicio As Integer = 0
            Dim longitudTexto As Integer = texto.Length

            While inicio < longitudTexto
                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 13
                inicio += caracteresPorLinea
            End While
            Y += 5

            Dim caracteresPorLinea2 As Integer = 22
            Dim texto2 As String = pie1
            Dim inicio2 As Integer = 0
            Dim longitudTexto2 As Integer = texto2.Length

            While inicio2 < longitudTexto2
                Dim longitudBloque2 As Integer = Math.Min(caracteresPorLinea2, longitudTexto2 - inicio2)
                Dim bloque2 As String = texto2.Substring(inicio2, longitudBloque2)
                e.Graphics.DrawString(bloque2, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                Y += 13
                inicio2 += caracteresPorLinea2
            End While
            Y += 5

            e.Graphics.DrawString("Lo atendio: " & lblAtendio.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 90, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 90, Y, sc)
            Else

            End If

            cnn2.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "2"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "3"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "4"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "5"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "6"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "7"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "8"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "9"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focoh
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo As Double = monto + "0"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
        End Select
    End Sub
End Class