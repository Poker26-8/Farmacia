Public Class frmNuevoPagar

    Public subtotalmapeo As Double = 0
    Public focomapeo As Integer = 0
    Public contraseñamesero As String = ""
    Public COMENSALES As String = ""

    Dim vercomanda As String = ""
    Dim vercodigo As String = ""
    Dim verdescripcion As String = ""
    Dim verunidad As String = ""
    Dim vercantidad As Double = 0
    Dim verprecio As Double = 0
    Dim vertotal As Double = 0
    Dim vercomensal As String = ""
    Dim vermesero As String = ""
    Dim verid As Integer = 0

    Dim Montocobromapeo As Double = 0

    Dim propina As Double = 0
    Dim percent_propina As String = ""
    Dim myope As Double = 0

    Private Sub frmNuevoPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdcomanda.Rows.Clear()
        TFolio.Start()

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then
                    vercomanda = rd2("IDC").ToString
                    vercodigo = rd2("Codigo").ToString
                    verdescripcion = rd2("Nombre").ToString
                    verunidad = rd2("UVenta").ToString
                    vercantidad = rd2("Cantidad").ToString
                    verprecio = rd2("Precio").ToString
                    vertotal = rd2("Total").ToString
                    vercomensal = rd2("Comensal").ToString
                    vermesero = rd2("CUsuario").ToString
                    verid = rd2("Id").ToString
                    lblMesero.Text = rd2("CUsuario").ToString

                    grdComanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, FormatNumber(verprecio, 2), FormatNumber(vertotal, 2), vercomensal, vermesero, verid)

                    Montocobromapeo = Montocobromapeo + vertotal
                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub TFolio_Tick(sender As Object, e As EventArgs) Handles TFolio.Tick
        TFolio.Stop()

        cnntimer.Close() : cnntimer.Open()
        cmdtimer = cnntimer.CreateCommand
        cmdtimer.CommandText = "SELECT MAX(Folio) from Ventas"
        rdtimer = cmdtimer.ExecuteReader
        If rdtimer.HasRows Then
            If rdtimer.Read Then
                lblfolio.Text = CDbl(IIf(rdtimer(0).ToString = "", "0", rdtimer(0).ToString)) + 1
            Else
                lblfolio.Text = "1"
            End If
        Else
            lblfolio.Text = "1"
        End If
        rdtimer.Close()
        cnntimer.Close()
        TFolio.Start()
    End Sub

    Private Sub frmNuevoPagar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMesas.Close()
        frmMesas.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtSubtotalmapeo_TextChanged(sender As Object, e As EventArgs) Handles txtSubtotalmapeo.TextChanged
        If Not IsNumeric(txtSubtotalmapeo.Text) Then txtSubtotalmapeo.Text = "0.00" : Exit Sub
        If Strings.Left(txtSubtotalmapeo.Text, 1) = "," Or Strings.Left(txtSubtotalmapeo.Text, 1) = "." Then Exit Sub

        ' percent_propina = IIf(percent_propina = "", 0, percent_propina)
        percent_propina = DatosRecarga("Propina")
        propina = CDec(txtSubtotalmapeo.Text) * (percent_propina / 100)
        txtPropina.Text = FormatNumber(propina, 2)

        txtTotal.Text = CDec(txtSubtotalmapeo.Text) + CDec(txtPropina.Text)
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)

        lblTotal.Text = CDec(txtSubtotalmapeo.Text) + CDec(txtPropina.Text)
        lblTotal.Text = FormatNumber(txtTotal.Text, 2)
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        txtResta.Text = txtTotal.Text
        txtResta.Text = FormatNumber(txtResta.Text, 2)
        Montocobromapeo = FormatNumber(txtTotal.Text, 2)
    End Sub

    Private Sub txtEfectivo_Click(sender As Object, e As EventArgs) Handles txtEfectivo.Click
        txtEfectivo.SelectionStart = 0
        txtEfectivo.SelectionLength = Len(txtEfectivo.Text)
        focomapeo = 1
    End Sub

    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged

        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
        If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub


        myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(txtEfectivo.Text) + CDbl(txtpagos.Text))

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
    End Sub

    Private Sub txtDescuento_Click(sender As Object, e As EventArgs) Handles txtDescuento.Click
        txtDescuento.SelectionStart = 0
        txtDescuento.SelectionLength = Len(txtDescuento.Text)
        focomapeo = 2
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        If Not IsNumeric(txtDescuento.Text) Then txtDescuento.Text = "0.00" : Exit Sub
        If Strings.Left(txtDescuento.Text, 1) = "," Or Strings.Left(txtDescuento.Text, 1) = "." Then Exit Sub

        If txtDescuento.Text > 0 Then
            myope = Montocobromapeo - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(txtpagos.Text) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)) + CDbl(txtPropina.Text))
        Else
            myope = Montocobromapeo - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(txtpagos.Text) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)) + CDbl(IIf(txtPropina.Text = "", 0, txtPropina.Text)))
        End If


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

                lblTotal.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text))
                lblTotal.Text = FormatNumber(txtTotal.Text, 2)
            Else
                txtTotal.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) + CDec(txtPropina.Text)
                txtTotal.Text = FormatNumber(lblTotal.Text, 2)

                lblTotal.Text = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) + CDec(txtPropina.Text)
                lblTotal.Text = FormatNumber(lblTotal.Text, 2)

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

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click

        txtSubtotalmapeo.Text = FormatNumber(subtotalmapeo, 2)
        txtEfectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        txtDescuento.Text = "0.00"
        txtPorcentaje.Text = "0"
        txtCambio.Text = "0.00"
        grdPagos.Rows.Clear()

        cboComensal.Text = ""
        cboComanda.Text = ""
        grdComanda.Rows.Clear()
        '  traercomanda()
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

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

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

    Private Sub cboComanda_DropDown(sender As Object, e As EventArgs) Handles cboComanda.DropDown
        Try
            cboComanda.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Id FROM Comandas WHERE Nmesa='" & lblmesa.Text & "'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboComanda.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn5.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub

    Private Sub cboComensal_DropDown(sender As Object, e As EventArgs) Handles cboComensal.DropDown
        Try
            cboComensal.Items.Clear()

            cnn5.Close() : cnn5.Open()
            cmd5 = cnn5.CreateCommand
            cmd5.CommandText = "SELECT DISTINCT Comensal FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd5 = cmd5.ExecuteReader
            Do While rd5.Read
                If rd5.HasRows Then
                    cboComensal.Items.Add(rd5(0).ToString)
                End If
            Loop
            rd5.Close()
            cnn1.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
End Class