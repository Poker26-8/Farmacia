Public Class frmPagarTouch

    Dim propina As Double = 0
    Dim percent_propina As Double = 0
    Dim Montocobromapeo As Double = 0
    Public focomapeo As Integer = 0

    Dim myope As Double = 0
    Dim NewPos As String = ""
    Private Sub frmPagarTouch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpfechapago.Value = Format(Date.Now, "yyyy-MM-dd")
    End Sub

    Private Sub txtSubtotalmapeo_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotalmapeo.TextChanged
        If Not IsNumeric(txtSubtotalmapeo.Text) Then txtSubtotalmapeo.Text = "0.00" : Exit Sub
        If Strings.Left(txtSubtotalmapeo.Text, 1) = "," Or Strings.Left(txtSubtotalmapeo.Text, 1) = "." Then Exit Sub

        percent_propina = DatosRecarga("Propina")
        propina = CDec(txtSubtotalmapeo.Text) * (percent_propina / 100)
        txtPropina.Text = FormatNumber(propina, 2)

        txtTotal.Text = CDec(txtSubtotalmapeo.Text) + CDec(txtPropina.Text)
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)
    End Sub

    Private Sub frmPagarTouch_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged

        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
        If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub


        myope = Montocobromapeo - (CDbl(txtEfectivo.Text) + CDbl(txtpagos.Text) + CDbl(txtDescuento.Text))

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

    Private Sub txtDescuento_Click(sender As Object, e As EventArgs) Handles txtDescuento.Click
        txtDescuento.SelectionStart = 0
        txtDescuento.SelectionLength = Len(txtDescuento.Text)
        focomapeo = 2
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged

        If Not IsNumeric(txtDescuento.Text) Then txtDescuento.Text = "0.00" : Exit Sub
        If Strings.Left(txtDescuento.Text, 1) = "," Or Strings.Left(txtDescuento.Text, 1) = "." Then Exit Sub

        myope = Montocobromapeo - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(txtpagos.Text) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)))

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
        txtpagos.Text = "0.00"
        txtCambio.Text = "0.00"

        cboTelefono.Text = ""
        cboNombre.Text = ""
        rbtDireccion.Text = ""
        txtMaxCredito.Text = "0.00"
        txtAfavor.Text = "0.00"
        txtAdeuda.Text = "0.00"

        grdPagos.Rows.Clear()

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
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) - (CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text)) - CDec(VarPropa)))
            Else
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) - (CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text)) - CDec(txtPropina.Text)))
            End If

            If MyOpe = 0 Then
                MyOpe = 0
            End If

            If MyOpe < 0 Then
                txtResta.Text = "0.00"

                txtPropina.Text = 0
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
            Else
                txtTotal.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) + CDec(txtPropina.Text)
                txtTotal.Text = FormatNumber(txtTotal.Text, 2)

                tmpCam = 0

                If CDec(tmpCam) >= 0 Then
                    txtCambio.Text = FormatNumber(tmpCam, 2)

                Else
                    txtCambio.Text = "0.00"

                End If

            End If
            txtEfectivo.Focus.Equals(True)
        End If

    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            frmVTouchR.lblImporteEfectivo.Text = FormatNumber(txtEfectivo.Text, 2)
            frmVTouchR.lblCambio.Text = txtCambio.Text
            frmVTouchR.lblPagos.Text = txtpagos.Text
            btnIntro.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboforma_DropDown(sender As Object, e As EventArgs) Handles cboforma.DropDown
        Try
            cboforma.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT FormaPago FROM formaspago WHERE FormaPago<>'' ORDER BY FormaPago"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboforma.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboforma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboforma.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboBanco.Focus.Equals(True)
        End If
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

    Private Sub cboBanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBanco.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txtreferencia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtreferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtmonto.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtComentario.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuenta.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboCuenta_DropDown(sender As Object, e As EventArgs) Handles cboCuenta.DropDown
        Try
            cboCuenta.Items.Clear()
            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT CuentaBan FROM cuentasbancarias WHERE CuentaBan<>'' ORDER BY CuentaBan"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboCuenta.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuenta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Banco FROM cuentasbancarias WHERE CuentaBan='" & cboCuenta.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtRecepcion.Text = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()

            txtRecepcion.Focus.Equals(True)

        End If
    End Sub

    Private Sub txtRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpfechapago.Focus.Equals(True)
        End If
    End Sub

    Private Sub dtpfechapago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpfechapago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnagregarpago.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnagregarpago_Click(sender As Object, e As EventArgs) Handles btnagregarpago.Click

        Dim tipo As String = cboforma.Text
        Dim banco As String = cboBanco.Text
        Dim referencia As String = txtreferencia.Text
        Dim monto As Double = txtmonto.Text
        Dim comentario As String = txtComentario.Text
        Dim cuenta As String = cboCuenta.Text
        Dim recepcion As String = txtRecepcion.Text
        Dim fecha As String = dtpfechapago.Text
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

        grdPagos.Rows.Add(tipo, banco, referencia, monto, fecha, comentario, cuenta, recepcion)

        totalpagos = txtpagos.Text + monto
        txtpagos.Text = FormatNumber(totalpagos, 2)

        cboforma.Text = ""
        cboBanco.Text = ""
        txtreferencia.Text = ""
        txtmonto.Text = ""
        txtComentario.Text = ""
        cboCuenta.Text = ""
        txtRecepcion.Text = ""
        cboforma.Focus.Equals(True)

    End Sub

    Private Sub txtpagos_TextChanged(sender As Object, e As EventArgs) Handles txtpagos.TextChanged
        Dim Resta As Double = 0

        Try
            Resta = CDec(IIf(txtpagos.Text = "", "0", txtpagos.Text)) - CDec(IIf(txtTotal.Text = "", "0", txtTotal.Text))
            Resta = FormatNumber(Resta, 2)
            myope = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) - (CDec(IIf(txtpagos.Text = "", "0", txtpagos.Text)) + CDec(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) - CDec(IIf(txtPropina.Text = "", "0", txtPropina.Text)))

            If myope < 0 Then
                Resta = -myope
                txtResta.Text = "0.00"
            Else
                txtResta.Text = myope
                Resta = "0.00"
            End If
            Resta = FormatNumber(Resta, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)
            frmVTouchR.lblPagos.Text = txtpagos.Text

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub txtResta_TextChanged(sender As Object, e As EventArgs) Handles txtResta.TextChanged
        frmVTouchR.lblRestaPagar.Text = txtResta.Text
    End Sub

    Private Sub grdPagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellDoubleClick
        Dim index As Integer = grdPagos.CurrentRow.Index

        Dim importe = grdPagos.Rows(index).Cells(3).Value.ToString

        grdPagos.Rows.Remove(grdPagos.Rows(index))
        txtpagos.Text = txtpagos.Text - CDec(importe)
        txtpagos.Text = FormatNumber(txtpagos.Text, 2)
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

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click

        If cboNombre.Text = "" Then
            frmVTouchR.lblCliente.Text = "MOSTRADOR"
            frmVTouchR.lblTelefono.Text = ""
            frmVTouchR.lblTipoVenta.Text = "MOSTRADOR"
            frmVTouchR.lblTelefono.Text = ""
            frmVTouchR.lblDireccion.Text = ""
        Else
            frmVTouchR.lblCliente.Text = cboNombre.Text
            frmVTouchR.lblTelefono.Text = cboTelefono.Text
            frmVTouchR.lblNumCliente.Text = lblidcliente.Text
            frmVTouchR.lblTipoVenta.Text = lblidcliente.Text
            frmVTouchR.lblTelefono.Text = cboTelefono.Text
            frmVTouchR.lblDireccion.Text = rbtDireccion.Text
        End If

        frmVTouchR.GuardarVenta()

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
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) + CDec(IIf(txtPropina.Text = 0, 0, txtPropina.Text)) - (CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text)) - CDec(VarPropa)))
            Else
                MyOpe = CDec(CDec(IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)) + CDec(IIf(txtPropina.Text = 0, 0, txtPropina.Text)) - CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) + CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text))) - CDec(IIf(txtDescuento.Text = 0, 0, txtDescuento.Text)))

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

    Private Sub txtPropina_Click(sender As Object, e As EventArgs) Handles txtPropina.Click
        focomapeo = 3
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn1.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim MONTO As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim NUEVO = MONTO + btn1.Text
                txtDescuento.Text = FormatNumber(NUEVO, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina)
                Dim nuevo = monto + btn1.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

        End Select
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn2.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn2.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn2.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn3.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn3.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn3.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn4.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn4.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn4.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn5.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn5.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn5.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn6.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn6.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn6.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn7.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn7.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn7.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn8.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn8.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn8.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn9.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn9.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn9.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

        End Select
    End Sub

    Private Sub btnPunto_Click(sender As Object, e As EventArgs) Handles btnPunto.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                txtEfectivo.Text = txtEfectivo.Text + btnPunto.Text
            Case Is = 2 'descuento
                txtDescuento.Text = txtDescuento.Text + btnPunto.Text
            Case Is = 3 'propina
                txtPropina.Text = txtPropina.Text + btnPunto.Text
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focomapeo
            Case Is = 1 'efectivo
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + btn0.Text
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)


            Case Is = 2 'descuento
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + btn0.Text
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3 'propina
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + btn0.Text
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)

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
        End Select
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
                    txtcliente.Text = rd1(1).ToString
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
End Class