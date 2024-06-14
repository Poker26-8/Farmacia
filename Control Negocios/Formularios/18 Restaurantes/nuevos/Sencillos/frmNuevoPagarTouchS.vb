﻿Public Class frmNuevoPagarTouchS

    Public focomapeo As Integer = 0
    Dim percent_propina As Double = 0
    Dim propina As Double = 0
    Dim Montocobromapeo As Double = 0
    Dim myope As Double = 0

    Dim efectivo As Double = 0
    Dim tarjeta As Double = 0
    Dim transferencia As Double = 0

    Dim NewPos As String = ""
    Public dato As Integer = 0

    Dim cobroexacto As Integer = 0
    Private Sub frmNuevoPagarTouchS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtSubtotalmapeo_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotalmapeo.TextChanged

        If Not IsNumeric(txtSubtotalmapeo.Text) Then txtSubtotalmapeo.Text = "0.00" : Exit Sub
        If Strings.Left(txtSubtotalmapeo.Text, 1) = "," Or Strings.Left(txtSubtotalmapeo.Text, 1) = "." Then Exit Sub

        percent_propina = DatosRecarga("Propina")
        propina = CDec(txtSubtotalmapeo.Text) * (percent_propina / 100)
        txtPropina.Text = FormatNumber(propina, 2)

        txtTotal.Text = CDec(txtSubtotalmapeo.Text)
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)

        txttotalpropina.Text = CDec(txtSubtotalmapeo.Text) + CDec(txtPropina.Text)
        txtPropina.Text = FormatNumber(txtPropina.Text, 2)

        txtResta.Text = FormatNumber(txttotalpropina.Text, 2)
    End Sub

    Private Sub frmNuevoPagarTouchS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmVTouchR.Show()
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        txtResta.Text = txtTotal.Text
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        Montocobromapeo = FormatNumber(txtTotal.Text, 2)
        frmVTouchR.lbltotalventa.Text = Montocobromapeo
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
        focomapeo = 1
    End Sub

    Private Sub txtDescuento_Click(sender As Object, e As EventArgs) Handles txtDescuento.Click
        txtDescuento.SelectionStart = 0
        txtDescuento.SelectionLength = Len(txtDescuento.Text)
        focomapeo = 2
    End Sub

    Private Sub txtPropina_Click(sender As Object, e As EventArgs) Handles txtPropina.Click
        txtPropina.SelectionStart = 0
        txtPropina.SelectionLength = Len(txtPropina.Text)
        focomapeo = 3
    End Sub

    Private Sub txtTarjeta_Click(sender As Object, e As EventArgs) Handles txtTarjeta.Click
        txtTarjeta.SelectionStart = 0
        txtTarjeta.SelectionLength = Len(txtTarjeta.Text)
        focomapeo = 7
    End Sub

    Private Sub txtTransferencia_Click(sender As Object, e As EventArgs) Handles txtTransferencia.Click
        txtTransferencia.SelectionStart = 0
        txtTransferencia.SelectionLength = Len(txtTransferencia.Text)
        focomapeo = 8
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        '  If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
        If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub

        tarjeta = IIf(txtTarjeta.Text = "", 0, txtTarjeta.Text)
        transferencia = IIf(txtTransferencia.Text = "", 0, txtTransferencia.Text)

        myope = IIf(txttotalpropina.Text = "", 0, txttotalpropina.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)) + CDbl(tarjeta) + CDbl(transferencia))

        If myope < 0 Then
            txtCambio.Text = FormatNumber(-myope, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(myope, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        frmVTouchR.lblImporteEfectivo.Text = txtEfectivo.Text
        frmVTouchR.lblCambio.Text = txtCambio.Text
        myope = 0
    End Sub

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged
        If Strings.Left(txtTarjeta.Text, 1) = "," Or Strings.Left(txtTarjeta.Text, 1) = "." Then Exit Sub

        tarjeta = IIf(txtTarjeta.Text = "", 0, txtTarjeta.Text)
        transferencia = IIf(txtTransferencia.Text = "", 0, txtTransferencia.Text)

        myope = IIf(txttotalpropina.Text = "", 0, txttotalpropina.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)) + CDbl(tarjeta) + CDbl(transferencia))

        If myope < 0 Then
            txtCambio.Text = FormatNumber(-myope, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(myope, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        frmVTouchR.lblImporteEfectivo.Text = txtEfectivo.Text
        frmVTouchR.lblCambio.Text = txtCambio.Text
        myope = 0
    End Sub

    Private Sub txtTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferencia.TextChanged

        If Not IsNumeric(txtTransferencia.Text) Then txtTransferencia.Text = "0.00" : Exit Sub
        If Strings.Left(txtTransferencia.Text, 1) = "," Or Strings.Left(txtTransferencia.Text, 1) = "." Then Exit Sub

        tarjeta = IIf(txtTarjeta.Text = "", 0, txtTarjeta.Text)
        transferencia = IIf(txtTransferencia.Text = "", 0, txtTransferencia.Text)

        myope = IIf(txttotalpropina.Text = "", 0, txttotalpropina.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)) + CDbl(tarjeta) + CDbl(transferencia))

        If myope < 0 Then
            txtCambio.Text = FormatNumber(-myope, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(myope, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        frmVTouchR.lblImporteEfectivo.Text = txtEfectivo.Text
        frmVTouchR.lblCambio.Text = txtCambio.Text
        myope = 0
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        If Not IsNumeric(txtDescuento.Text) Then txtDescuento.Text = "0.00" : Exit Sub
        If Strings.Left(txtDescuento.Text, 1) = "," Or Strings.Left(txtDescuento.Text, 1) = "." Then Exit Sub

        myope = IIf(txtSubtotalmapeo.Text = "", 0.00, txtSubtotalmapeo.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", 0.00, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", 0.00, txtTransferencia.Text)) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)))

        If myope < 0 Then
            txtCambio.Text = FormatNumber(-myope, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(myope, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        myope = 0

        frmVTouchR.lblDescuento.Text = txtDescuento.Text
    End Sub

    Private Sub btnretro_Click(sender As Object, e As EventArgs) Handles btnretro.Click
        txtDescuento.Text = "0.00"
        txtEfectivo.Text = "0.00"
        txtTarjeta.Text = "0.00"
        txtTransferencia.Text = "0.00"
        txtCambio.Text = "0.00"
        txtTotal.Text = txtSubtotalmapeo.Text
        cboTelefono.Text = ""
        cboNombre.Text = ""
        rbtDireccion.Text = ""
        txtMaxCredito.Text = "0.00"
        txtAfavor.Text = "0.00"
        txtAdeuda.Text = "0.00"
        txtPropina.Text = "0.00"
        txtPorcentaje.Text = "0.00"

        txtmonedero.Text = ""
        txtsaldomon.Text = ""
        btnIntro.Enabled = True
        lblidcliente.Text = ""
        lblTarjeta.Text = ""
    End Sub

    Private Sub txtPropina_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPropina.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim VarRes As Double = 0
            Dim VRe As String = ""
            Dim Vre1 As String = ""
            Dim VarPropa As Double = 0
            Dim MyOpe As Double = 0
            Dim restapago As Double = 0
            Dim tmpCam As Double = 0
            Dim TotalPagar As Double = 0


            Dim subtotalvt As Double = IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)
            Dim efectivovt As Double = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)
            Dim tarjeta As Double = IIf(txtTarjeta.Text = 0, 0, txtTarjeta.Text)
            Dim transfe As Double = IIf(txtTransferencia.Text = 0, 0, txtTransferencia.Text)

            Dim pagosvt As Double = CDbl(tarjeta) + CDbl(transfe)

            VarRes = IIf(txtPropina.Text = "", 0, txtPropina.Text)
            VRe = Mid(txtPropina.Text, 1, 1)
            Vre1 = Mid(txtPropina.Text, 1, 2)

            If VRe = "." Then
                VRe = 0
                VarPropa = VRe
            ElseIf VRe = "" Then
                VRe = 0
                VarPropa = VRe
            Else
                VarPropa = txtPropina.Text
            End If


            If Vre1 = ".." Then
                Vre1 = 0
                VarPropa = Vre1
                txtPropina.Text = Vre1
                txtPropina.SelectionStart = 0
                txtPropina.SelectionLength = Len(txtPropina.Text)
            End If

            If txtPropina.Text = "0" Then
                MyOpe = CDec(CDec(subtotalvt) - (CDec(efectivovt) + CDec(pagosvt)) - CDec(VarPropa)) - CDbl(txtDescuento.Text)
            Else
                If txtDescuento.Text = "0.00" Then
                    MyOpe = CDec(subtotalvt + txtPropina.Text) - pagosvt
                Else
                    MyOpe = CDec(CDec(subtotalvt) - (pagosvt - CDec(txtPropina.Text)) - CDbl(txtDescuento.Text))
                End If

                'MyOpe = CDec(CDec(subtotalvt) - (CDec(efectivovt) + CDec(pagosvt)) - CDec(txtPropina.Text))
            End If

            If MyOpe = 0 Then
                MyOpe = 0
            End If

            If MyOpe < 0 Then
                txtResta.Text = "0.00"

                'txtPropina.Text = 0
            Else
                txtResta.Text = MyOpe
                txtCambio.Text = "0.00"
                restapago = txtResta.Text
            End If

            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)

            If CDec(txtResta.Text) = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) And CDec(txtPropina.Text) = 0 Then

                txtTotal.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text))
                txtTotal.Text = FormatNumber(txtTotal.Text, 2)

                txttotalpropina.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text))
                txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)
            Else

                txttotalpropina.Text = CDec(IIf(txtTotal.Text = "", "0", txtTotal.Text)) + CDec(txtPropina.Text)
                txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)


                tmpCam = 0

                If CDec(tmpCam) >= 0 Then
                    txtCambio.Text = FormatNumber(tmpCam, 2)

                Else
                    txtCambio.Text = "0.00"

                End If

            End If
            txtEfectivo.Focus.Equals(True)
            txtEfectivo.Text = "0.00"
            txtTransferencia.Text = "0.00"
            txtTarjeta.Text = "0.00"
        End If
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            frmVTouchR.lblImporteEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            frmVTouchR.lblCambio.Text = txtCambio.Text
            frmVTouchR.lblPagos.Text = CDbl(txtTarjeta.Text) + CDbl(txtTransferencia.Text)
            btnIntro.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTarjeta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTarjeta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            frmVTouchR.lblImporteEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            frmVTouchR.lblCambio.Text = txtCambio.Text
            frmVTouchR.lblPagos.Text = CDbl(txtTarjeta.Text) + CDbl(txtTransferencia.Text)

            cobroexacto = efectivocompleto()

            If cobroexacto = 1 Then
                txtEfectivo.Text = "0.00"
                btnIntro.Focus.Equals(True)
            Else

                btnIntro.Focus.Equals(True)
            End If


        End If
    End Sub

    Private Sub txtTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTransferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            frmVTouchR.lblImporteEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            frmVTouchR.lblCambio.Text = txtCambio.Text
            frmVTouchR.lblPagos.Text = CDbl(txtTarjeta.Text) + CDbl(txtTransferencia.Text)

            cobroexacto = efectivocompleto()

            If cobroexacto = 1 Then
                txtEfectivo.Text = "0.00"
                btnIntro.Focus.Equals(True)
            Else

                btnIntro.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub txtResta_TextChanged(sender As Object, e As EventArgs) Handles txtResta.TextChanged
        frmVTouchR.lblRestaPagar.Text = txtResta.Text
    End Sub

    Private Sub cboTelefono_DropDown(sender As Object, e As EventArgs) Handles cboTelefono.DropDown
        Try
            cboTelefono.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Telefono FROM clientes WHERE Telefono<>'' ORDER BY Telefono"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboTelefono.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
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

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Try
            Dim MySaldo As Double = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT * FROM Clientes WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboTelefono.Text = rd1("Telefono").ToString
                    txtMaxCredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                    lblidcliente.Text = rd1("Id").ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "SELECT Saldo FROM Abono where Id=(select MAX(Id) FROM Abono WHERE IdCliente='" & lblidcliente.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                    If MySaldo < 0 Then
                        txtAdeuda.Text = "0.00"
                        txtAfavor.Text = Math.Abs(MySaldo)
                        txtAfavor.Text = FormatNumber(txtAfavor.Text, 2)
                    Else
                        txtAfavor.Text = "0.00"
                        txtAdeuda.Text = Math.Abs(MySaldo)
                        txtAdeuda.Text = FormatNumber(txtAdeuda.Text, 2)
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

    Private Sub txtPropina_TextChanged(sender As Object, e As EventArgs) Handles txtPropina.TextChanged
        frmVTouchR.lblPropina.Text = txtPropina.Text
    End Sub

    Private Sub txtDescuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Dim VarRes As Double = 0
            Dim VRe As String = ""
            Dim Vre1 As String = ""
            Dim VarPropa As Double = 0
            Dim MyOpe As Double = 0
            Dim restapago As Double = 0
            Dim tmpCam As Double = 0
            Dim TotalPagar As Double = 0

            VarRes = IIf(txtDescuento.Text = "", 0, txtDescuento.Text)
            VRe = Mid(txtDescuento.Text, 1, 1)
            Vre1 = Mid(txtDescuento.Text, 1, 2)

            If VRe = "." Then
                VRe = 0
                VarPropa = VRe
            ElseIf VRe = "" Then
                VRe = 0
                VarPropa = VRe
            Else
                VarPropa = txtDescuento.Text
            End If


            If Vre1 = ".." Then
                Vre1 = 0
                VarPropa = Vre1
                txtDescuento.Text = Vre1
                txtDescuento.SelectionStart = 0
                txtDescuento.SelectionLength = Len(txtDescuento.Text)
            End If

            If txtDescuento.Text = "0" Then
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) + CDec(IIf(txtPropina.Text = 0, 0, txtPropina.Text)) - (CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) + CDec(IIf(txtTarjeta.Text = 0, 0, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = 0, 0, txtTransferencia.Text)) - CDec(VarPropa)))
            Else
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) + CDec(IIf(txtPropina.Text = 0, 0, txtPropina.Text)) - CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) + CDec(IIf(txtTarjeta.Text = 0, 0, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = 0, 0, txtTransferencia.Text))) - CDec(IIf(txtDescuento.Text = 0, 0, txtDescuento.Text)))

            End If

            If MyOpe = 0 Then
                MyOpe = 0
            End If

            If MyOpe < 0 Then
                txtResta.Text = "0.00"

                txtDescuento.Text = 0
            Else
                txtResta.Text = MyOpe
                txtCambio.Text = "0.00"
                restapago = txtResta.Text
                txtTotal.Text = MyOpe
            End If

            txtEfectivo.Focus.Equals(True)
            focomapeo = 1
        End If
    End Sub

    Private Function PosCad(CadOrg As String, Car As String, Pos As Integer, TamCad As Integer) As String

        Dim Part1 As String
        Dim NewPart1 As String

        If CadOrg = "0.00" Or CadOrg = 0 Or CadOrg = "" Then
            PosCad = Car
        ElseIf Pos = 0 Then
            PosCad = CDec(CadOrg) + CDec(Car)
        ElseIf Pos <> TamCad Then
            Part1 = Strings.Left(CadOrg, Pos)
            NewPart1 = Part1 & Car
            PosCad = Replace(CadOrg, Part1, NewPart1)
        Else
            PosCad = CadOrg & Car
        End If

    End Function

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPorcentaje.Text) Then

                If IIf(txtPorcentaje.Text = "", 0, txtPorcentaje.Text) > 100 Then
                    txtPorcentaje.Text = "0"
                    Exit Sub
                End If

                Dim total As Double = IIf(txtTotal.Text = "", 0, txtTotal.Text)
                Dim propina As Double = IIf(txtPropina.Text = "", 0, txtPropina.Text)
                Dim SALDO As Double = IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)
                Dim totalpro As Double = IIf(txttotalpropina.Text = "", "0", txttotalpropina.Text)
                Dim PORCENTAJE As Double = (txtPorcentaje.Text / 100)
                Dim porcentajetot As Double = CDbl(SALDO) * CDbl(PORCENTAJE)
                txtDescuento.Text = FormatNumber(porcentajetot, 2)

                Dim subtotal As Double = 0
                subtotal = SALDO - CDbl(porcentajetot)
                txtTotal.Text = FormatNumber(subtotal, 2)
                txttotalpropina.Text = FormatNumber(CDbl(total) + CDbl(propina), 2)
                txtResta.Text = FormatNumber(txttotalpropina.Text, 2)

                txtEfectivo.Text = "0.00"
                txtTarjeta.Text = "0.00"
                txtTransferencia.Text = "0.00"


            End If
        End If
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As Object, e As EventArgs) Handles txtPorcentaje.TextChanged

        If Not IsNumeric(txtPorcentaje.Text) Then txtPorcentaje.Text = "0.00" : Exit Sub
        If Strings.Left(txtPorcentaje.Text, 1) = "," Or Strings.Left(txtPorcentaje.Text, 1) = "." Then Exit Sub

        If IIf(txtPorcentaje.Text = "", 0, txtPorcentaje.Text) > 100 Then
            txtPorcentaje.Text = "0"
            Exit Sub
        End If

        Dim total As Double = IIf(txtTotal.Text = "", 0, txtTotal.Text)
        Dim propina As Double = IIf(txtPropina.Text = "", 0, txtPropina.Text)
        Dim SALDO As Double = IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)
        Dim totalpro As Double = IIf(txttotalpropina.Text = "", "0", txttotalpropina.Text)
        Dim PORCENTAJE As Double = (txtPorcentaje.Text / 100)
        Dim porcentajetot As Double = CDbl(SALDO) * CDbl(PORCENTAJE)
        txtDescuento.Text = FormatNumber(porcentajetot, 2)

        Dim subtotal As Double = 0
        subtotal = SALDO - CDbl(porcentajetot)
        txtTotal.Text = FormatNumber(subtotal, 2)
        txttotalpropina.Text = FormatNumber(CDbl(txtTotal.Text) + CDbl(propina), 2)
        txtResta.Text = FormatNumber(txttotalpropina.Text, 2)

        txtEfectivo.Text = "0.00"
        txtTarjeta.Text = "0.00"
        txtTransferencia.Text = "0.00"
    End Sub

    Private Sub txtmonedero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonedero.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Saldo,Cliente FROM monedero WHERE Barras='" & txtmonedero.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtsaldomon.Text = rd1(0).ToString
                    ' txtcliente.Text = rd1(1).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

        End If
    End Sub

    Private Sub cboTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTelefono.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            Try
                Dim MySaldo As Double = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT * FROM Clientes WHERE Telefono='" & cboTelefono.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cboNombre.Text = rd1("Nombre").ToString
                        txtMaxCredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                        lblidcliente.Text = rd1("Id").ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "SELECT Saldo FROM Abonoi where Id=(select MAX(Id) FROM Abonoi WHERE IdCliente='" & lblidcliente.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                        If MySaldo < 0 Then
                            txtAdeuda.Text = "0.00"
                            txtAfavor.Text = Math.Abs(MySaldo)
                            txtAfavor.Text = FormatNumber(txtAfavor.Text, 2)
                        Else
                            txtAfavor.Text = "0.00"
                            txtAdeuda.Text = Math.Abs(MySaldo)
                            txtAdeuda.Text = FormatNumber(txtAdeuda.Text, 2)
                        End If
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                cboNombre.Focus.Equals(True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try

        End If
    End Sub

    Private Sub cboTelefono_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTelefono.SelectedValueChanged
        cboTelefono_KeyPress(cboTelefono, New KeyPressEventArgs(ControlChars.Cr))
    End Sub

    Private Sub btnTel_Click(sender As Object, e As EventArgs) Handles btnTel.Click
        frmTecladoPagar.telefono = 1
        dato = 1
        frmTecladoPagar.Show()
        frmTecladoPagar.BringToFront()
    End Sub

    Private Sub btnTecNombre_Click(sender As Object, e As EventArgs) Handles btnTecNombre.Click
        frmTecladoPagar.nombre = 1
        dato = 2
        frmTecladoPagar.Show()
        frmTecladoPagar.BringToFront()
    End Sub

    Private Sub btnDir_Click(sender As Object, e As EventArgs) Handles btnDir.Click
        frmTecladoPagar.direccion = 1
        dato = 3
        frmTecladoPagar.Show()
        frmTecladoPagar.BringToFront()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focomapeo

            Case Is = 1 'efectivo
                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn1.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2 'descuento

                Dim MONTO As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim NUEVO = MONTO + btn1.Text
                txtDescuento.Text = FormatNumber(NUEVO, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn1.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 7 'tarjeta

                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn1.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos
                txtTarjeta.Focus.Equals(True)

            Case Is = 8 'transferencia

                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn1.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
                txtTransferencia.Focus.Equals(True)


        End Select
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn2.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn2.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn2.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn2.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'tramsferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn2.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn3.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn3.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn3.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn3.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn3.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn4.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn4.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn4.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn4.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn4.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn5.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn5.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn5.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn5.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn5.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn6.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn6.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn6.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn6.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn6.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn7.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn7.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn7.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn7.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn7.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn8.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn8.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn8.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn8.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn8.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn9.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn9.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn9.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn9.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn9.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btnPunto.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                txtDescuento.Text = txtDescuento.Text + btnPunto.Text

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btnPunto.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btnPunto.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btnPunto.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focomapeo
            Case Is = 1 'efectivo

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn0.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn0.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina

                txtPropina.Focus.Equals(True)
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn0.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos

            Case Is = 7 'tarjeta

                txtTarjeta.Focus.Equals(True)
                NewPos = txtTarjeta.SelectionStart
                txtTarjeta.Text = PosCad(txtTarjeta.Text, btn0.Text, txtTarjeta.SelectionStart, Len(txtTarjeta.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTarjeta.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTarjeta.SelectionStart = NewPos

            Case Is = 8 'transferencia

                txtTransferencia.Focus.Equals(True)
                NewPos = txtTransferencia.SelectionStart
                txtTransferencia.Text = PosCad(txtTransferencia.Text, btn0.Text, txtTransferencia.SelectionStart, Len(txtTransferencia.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtTransferencia.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtTransferencia.SelectionStart = NewPos
        End Select
    End Sub

    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "20"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "20"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "20"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "20"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "20"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn50_Click(sender As Object, e As EventArgs) Handles btn50.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "50"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "50"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "50"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "50"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "50"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "100"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "100"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "100"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "100"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "100"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn200_Click(sender As Object, e As EventArgs) Handles btn200.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "200"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "200"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "200"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "200"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "200"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub


    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "500"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "500"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "500"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "500"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "500"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = txtEfectivo.Text
                Dim nuevo As Double = monto + "1000"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2
                Dim monto As Double = txtDescuento.Text
                Dim nuevo As Double = monto + "1000"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = txtPropina.Text
                Dim nuevo As Double = monto + "1000"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

            Case Is = 7
                Dim monto As Double = txtTarjeta.Text
                Dim nuevo As Double = monto + "1000"
                txtTarjeta.Text = FormatNumber(nuevo, 2)
                txtTarjeta.Focus.Equals(True)

            Case Is = 8
                Dim monto As Double = txtTransferencia.Text
                Dim nuevo As Double = monto + "1000"
                txtTransferencia.Text = FormatNumber(nuevo, 2)
                txtTransferencia.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click

        If cboNombre.Text = "" Then
            frmVTouchR.lblCliente.Text = "MOSTRADOR"
            frmVTouchR.lblTelefono.Text = ""
            frmVTouchR.lblTipoVenta.Text = "MOSTRADOR"
            frmVTouchR.lblTelefono.Text = ""
            frmVTouchR.lblDireccion.Text = ""
        Else

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM clientes WHERE Nombre='" & cboNombre.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    lblidcliente.Text = rd1("Id").ToString
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO clientes(Nombre,RazonSocial,Tipo,Credito,Telefono,Calle) VALUES('" & cboNombre.Text & "','" & cboNombre.Text & "','Lista',10000,'" & cboTelefono.Text & "','" & rbtDireccion.Text & "')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()


            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT Id FROM clientes WHERE Nombre='" & cboNombre.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    lblidcliente.Text = rd3(0).ToString
                End If
            End If
            rd3.Close()
            cnn3.Close()


            frmVTouchR.lblCliente.Text = cboNombre.Text
            frmVTouchR.lblTelefono.Text = cboTelefono.Text
            frmVTouchR.lblNumCliente.Text = lblidcliente.Text
            frmVTouchR.lblTipoVenta.Text = lblidcliente.Text
            frmVTouchR.lblTelefono.Text = cboTelefono.Text
            frmVTouchR.lblDireccion.Text = rbtDireccion.Text
        End If
        btnIntro.Enabled = False
        frmVTouchR.GuardarVenta()

    End Sub

    Private Sub btnVisa_Click(sender As Object, e As EventArgs) Handles btnVisa.Click

        If txtTarjeta.Text > 0 OR txtTransferencia.Text>0 Then
            lblTarjeta.Text = ""
            lblTarjeta.Text = "VISA"
        End If

    End Sub

    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        If txtTarjeta.Text > 0 Or txtTransferencia.Text > 0 Then
            lblTarjeta.Text = ""
            lblTarjeta.Text = "MASTER"
        End If

    End Sub

    Private Sub btnAmerica_Click(sender As Object, e As EventArgs) Handles btnAmerica.Click
        If txtTarjeta.Text > 0 Or txtTransferencia.Text > 0 Then
            lblTarjeta.Text = ""
            lblTarjeta.Text = "AMERICAN"
        End If

    End Sub
End Class