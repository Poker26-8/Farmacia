﻿
Imports System.IO
Public Class frmPagar

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

    Dim propina As Double = 0
    Dim percent_propina As Double = 0
    Dim Montocobromapeo As Double = 0
    Dim montopropina As Double = 0

    Dim myope As Double = 0

    Dim idusuario As Integer = 0
    Dim estadousuario As Integer = 0
    Dim SinNumComensal As Integer = 0

    Dim ideliminar As Integer = 0
    Dim comandaeliminar As Integer = 0
    Dim codigoeliminar As String = ""
    Dim descripcioneliminar As String = ""
    Dim unidadeliminar As String = ""
    Dim cantidadeliminar As Double = 0
    Dim precioeliminar As Double = 0
    Dim comensaleliminar As String = ""

    Dim folio As String = ""

    Dim foliomonedero As String = ""

    Private Sub frmPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                    grdcomanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, vercomensal, vermesero, verid)

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

    Private Sub frmPagar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        frmMesas.Close()
        frmMesas.Show()

    End Sub

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        Me.Close()
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
        grdcomanda.Rows.Clear()
        traercomanda()

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

    Private Sub cboforma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboforma.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboforma.Text = "" Then
                Exit Sub
            Else
                cboBanco.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub cboBanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboBanco.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If cboforma.Text = "MONEDERO" Then
                txtreferencia.Focus.Equals(True)
            Else
                If cboBanco.Text = "" Then
                    Exit Sub
                Else
                    txtreferencia.Focus.Equals(True)
                End If
            End If
        End If
    End Sub

    Private Sub txtreferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtreferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtreferencia.Text = "" Then
                Exit Sub
            Else

                If cboforma.Text = "MONEDERO" Then

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "SELECT Saldo FROM monedero WHERE Barras='" & txtreferencia.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            txtSaldoM.Text = rd1(0).ToString

                            MsgBox("El saldo del monedero es $ " & rd1(0).ToString & "", vbInformation + vbOKOnly, titulomensajes)

                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()

                End If

                txtmonto.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If txtmonto.Text = "" Then
                Exit Sub
            Else
                txtComentario.Focus.Equals(True)
            End If

        End If
    End Sub

    Private Sub cboCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCuenta.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtRecepcion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtRecepcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecepcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnagregarpago.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnagregarpago_Click(sender As Object, e As EventArgs) Handles btnagregarpago.Click

        Dim tipo As String = cboforma.Text
        Dim banco As String = cboBanco.Text
        Dim referencia As String = txtreferencia.Text
        Dim monto As Double = txtmonto.Text
        Dim fecha As Date = Format(dtpfechapago.Value, "yyyy-MM-dd")
        Dim cuenta As String = cboCuenta.Text
        Dim bancoref As String = txtRecepcion.Text
        Dim comentario As String = txtComentario.Text
        Dim totalpagos As Double = 0
        Dim TOTALEFECTIVO As Double = 0


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

        grdPagos.Rows.Add(tipo, banco, referencia, monto, fecha, comentario, cuenta, bancoref)



        'If tipo = "EFECTIVO" Then
        '    TOTALEFECTIVO = txtpagos.Text + monto
        '    txtEfectivo.Text = FormatNumber(TOTALEFECTIVO, 2)
        'Else
        totalpagos = txtpagos.Text + monto
        txtpagos.Text = FormatNumber(totalpagos, 2)
        '  End If

        limpiarforma()

    End Sub

    Public Sub limpiarforma()
        cboforma.Text = ""
        cboBanco.Text = ""
        txtreferencia.Text = ""
        txtmonto.Text = "0.00"
        cboCuenta.Text = ""
        txtRecepcion.Text = ""
        txtComentario.Text = ""
    End Sub

    Private Sub grdPagos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPagos.CellDoubleClick

        Dim index As Integer = grdPagos.CurrentRow.Index

        Dim importe = grdPagos.Rows(index).Cells(3).Value.ToString

        grdPagos.Rows.Remove(grdPagos.Rows(index))
        txtpagos.Text = txtpagos.Text - CDec(importe)
        txtpagos.Text = FormatNumber(txtpagos.Text, 2)

    End Sub

    Private Sub cboComanda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComanda.SelectedValueChanged

        Try

            txtSubtotalmapeo.Text = "0.00"
            grdcomanda.Rows.Clear()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Comandas WHERE Id='" & cboComanda.Text & "' AND NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    grdcomanda.Rows.Add(rd2("IDC").ToString,
                                       rd2("Codigo").ToString,
                                       rd2("Nombre").ToString,
                                       rd2("UVenta").ToString,
                                       rd2("Cantidad").ToString,
                                       rd2("Precio").ToString,
                                       rd2("Total").ToString,
                                       rd2("Comensal").ToString,
                                       rd2("CUsuario").ToString,
                                       rd2("Id").ToString
)

                    txtSubtotalmapeo.Text = txtSubtotalmapeo.Text + CDec(rd2("Total").ToString)
                End If
            Loop
            rd2.Close()
            cnn2.Close()
            txtSubtotalmapeo.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub cboComensal_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComensal.SelectedValueChanged

        Try
            txtSubtotalmapeo.Text = "0.00"
            grdcomanda.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Comandas WHERE Comensal='" & cboComensal.Text & "' AND NMESA='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdcomanda.Rows.Add(rd1("IDC").ToString,
                                      rd1("Codigo").ToString,
                                      rd1("Nombre").ToString,
                                      rd1("UVenta").ToString,
                                      rd1("Cantidad").ToString,
                                      rd1("Precio").ToString,
                                      rd1("Total").ToString,
                                      rd1("Comensal").ToString,
                                      rd1("CUsuario").ToString,
                                      rd1("Id").ToString
)
                    txtSubtotalmapeo.Text = IIf(txtSubtotalmapeo.Text = "", "0.000", txtSubtotalmapeo.Text) + CDec(rd1("Total").ToString)
                End If
            Loop
            rd1.Close()
            cnn1.Close()
            txtSubtotalmapeo.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Public Sub traercomanda()

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
                    grdcomanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, vercomensal, vermesero, verid)
                End If
            Loop
            rd2.Close()
            cnn2.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

    End Sub

    Public Sub traernumerocomensal()

        cnn2.Close() : cnn2.Open()
        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='SinNumComensal'"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                SinNumComensal = rd2(0).ToString
            End If
        End If
        rd2.Close()
        cnn2.Close()

    End Sub

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click

        Dim varieps As String = ""
        Dim vartotal As String = ""
        Dim mypago As Double = 0


        Dim tipopago As String = ""
        Dim montopagomonedero As Double = 0


        Dim CLIENTE As String = ""
        Dim SALDOMONEDERO As Double = 0
        Dim PORCENTAJEMONEDERO As Double = 0
        Dim IDMON As Integer = 0


        Dim Tiva As Double = 0
        Dim Cuenta As Double = 0

        Dim saldomonnuevo As Double = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM VtaImpresion"
        cmd1.ExecuteNonQuery()
        cnn1.Close()
        btnIntro.Enabled = True
        ' mypago = CDec(txtEfectivo.Text) + CDec(txtpagos.Text) - CDec(txtCambio.Text) - CDec(txtDescuento.Text)
        mypago = CDec(txtEfectivo.Text) + CDec(txtpagos.Text) + CDbl(txtDescuento.Text) - CDec(txtCambio.Text)

        If mypago < CDec(txtTotal.Text) Then
            MsgBox("Debe cerrar la cuenta!.", vbInformation + vbOKOnly, titulomensajes)
            Exit Sub
        End If

        If grdPagos.Rows.Count > 0 Then

            For pago = 0 To grdPagos.Rows.Count - 1
                tipopago = grdPagos.Rows(pago).Cells(0).Value.ToString


                If tipopago = "MONEDERO" Then
                    foliomonedero = grdPagos.Rows(pago).Cells(2).Value.ToString
                    montopagomonedero = grdPagos.Rows(pago).Cells(3).Value.ToString

                    If foliomonedero <> "" Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Monedero WHERE Barras='" & foliomonedero & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                IDMON = rd2("Id").ToString
                                SALDOMONEDERO = rd2("Saldo").ToString
                                PORCENTAJEMONEDERO = rd2("Porcentaje").ToString
                                'nummonedero = IIf(rd2("Folio").ToString = "", "", rd2("Folio").ToString)
                            End If
                        End If
                        rd2.Close()


                        Dim cuantosporoductos As Integer = 0
                        Dim porcentajenuevo As Double = 0
                        Dim siiiu As Integer = 0

                        saldomonnuevo = CDec(CDec(txtTotal.Text) - CDec(montopagomonedero)) * CDec(PORCENTAJEMONEDERO / 100)

                        Dim conversaldo As String = ""
                        conversaldo = ""
                        For i = 1 To Len(saldomonnuevo)
                            If Mid(saldomonnuevo, i, 1) = "." Then
                                Exit For
                            End If
                            conversaldo = saldomonnuevo
                        Next i
                        saldomonnuevo = conversaldo
                    End If
                    cnn2.Close()

                End If

            Next
        End If

        Dim mypagomonedero As Double = 0
        mypagomonedero = mypagomonedero + montopagomonedero

        Dim myidcliente As Integer = 0

        If MsgBox("¿Desea guardar los datos de esta venta?", vbQuestion + vbYesNo + vbDefaultButton1) = vbNo Then
            Exit Sub
        End If

        Dim Subtotales1 As Double = 0
        Dim SubtotalVenta As Double = 0
        Dim totcomi As Double = 0
        Dim CODIGO As String = ""
        Dim CANTI As Double = 0

        Cuenta = CDec(txtEfectivo.Text) + CDec(txtpagos.Text) + CDec(txtDescuento.Text) - CDec(txtCambio.Text)

        If CDec(txtTotal.Text) <= CDec(Cuenta) Then
            Cuenta = txtTotal.Text
            txtResta.Text = 0
        End If

        Cuenta = FormatNumber(Cuenta, 2)
        Subtotales1 = FormatNumber(txtSubtotalmapeo.Text / 1.16, 2)

        Dim ivaproducto As Double = 0
        Dim restaiva As Double = 0

        For zi As Integer = 0 To grdcomanda.Rows.Count - 1

            CODIGO = grdcomanda.Rows(zi).Cells(1).Value.ToString
            CANTI = grdcomanda.Rows(zi).Cells(4).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & CODIGO & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    totcomi = totcomi + CDec(CDec(CANTI) * CDec(rd2("Comision").ToString))
                    If rd2("IVA").ToString > 0 Then
                        Subtotales1 = grdcomanda.Rows(zi).Cells(6).Value.ToString
                        ivaproducto = Subtotales1 / (1 + rd2("IVA").ToString)
                        restaiva = CDbl(Subtotales1) - CDbl(ivaproducto)
                        Tiva = Tiva + CDbl(restaiva)
                        Tiva = FormatNumber(Tiva, 2)
                    End If

                End If
            End If

            rd2.Close()
            cnn2.Close()
        Next

        If Tiva > 0 Then
            SubtotalVenta = CDbl(txtTotal.Text) - CDbl(Tiva)
        Else
            SubtotalVenta = txtTotal.Text
        End If
        SubtotalVenta = FormatNumber(SubtotalVenta, 2)
#Region "CODIGO AUTOFACTURAR"
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

        Dim totalventa22 As Double = 0
        totalventa22 = txtTotal.Text

        Dim restaventa22 As Double = 0
        restaventa22 = txtResta.Text

        Dim propinaventa22 As Double = 0
        propinaventa22 = txtPropina.Text

        Dim descuentoventa22 As Double = 0
        descuentoventa22 = txtDescuento.Text

        Dim nuevosubtotal As Double = 0
        Dim nuevototal As Double = 0
        Dim nuevoacuenta As Double = 0

        nuevosubtotal = SubtotalVenta - CDbl(descuentoventa22)
        nuevototal = totalventa22 - CDbl(descuentoventa22)
        nuevoacuenta = Cuenta - CDbl(descuentoventa22)

        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Propina,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,TComensales,Corte,CorteU,CodFactura,Formato) VALUES('','" & lblmesa.Text & "',''," & SubtotalVenta & "," & Tiva & "," & totalventa22 & "," & Cuenta & "," & restaventa22 & "," & propinaventa22 & ",'" & lblusuario2.Text & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "','PAGADO'," & descuentoventa22 & ",'" & totcomi & "','" & COMENSALES & "','1','0','" & lic & "','TICKET')"
        cmd3.ExecuteNonQuery()
        cnn3.Close()


        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT MAX(Folio) FROM Ventas"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                folio = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        If montopagomonedero > 0 Then

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE Monedero SET Saldo=Saldo + " & CDec(saldomonnuevo) & ", Cargado='0' WHERE Id=" & IDMON & ""
            cmd2.ExecuteNonQuery()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE Monedero SET Cargado='0' WHERE Folio='" & foliomonedero & "'"
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        End If

        Dim idc As Integer = 0
        Dim mycodigo As String = ""
        Dim mydescripcion As String = ""
        Dim myunidad As String = ""
        Dim mycantidad As Double = 0
        Dim myprecio As Double = 0
        Dim mytotal As Double = 0
        Dim mycomensal As String = ""
        Dim mymesero As String = ""

        Dim COSTVUE1 As Double = 0
        Dim PRECIOSINIVA1 As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO As String = ""
        Dim MULTIPLO As Double = 0

        Dim TOTALSIVA As Double = 0

        Dim kreaper As Integer = 0

        Do While kreaper <> grdcomanda.Rows.Count

            idc = grdcomanda.Rows(kreaper).Cells(0).Value.ToString
            mycodigo = grdcomanda.Rows(kreaper).Cells(1).Value.ToString
            mydescripcion = grdcomanda.Rows(kreaper).Cells(2).Value.ToString
            myunidad = grdcomanda.Rows(kreaper).Cells(3).Value.ToString
            mycantidad = grdcomanda.Rows(kreaper).Cells(4).Value.ToString
            myprecio = grdcomanda.Rows(kreaper).Cells(5).Value.ToString
            mytotal = grdcomanda.Rows(kreaper).Cells(6).Value.ToString
            mycomensal = grdcomanda.Rows(kreaper).Cells(7).Value.ToString
            mymesero = grdcomanda.Rows(kreaper).Cells(8).Value.ToString


            mycantidad = FormatNumber(mycantidad, 2)
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & mycodigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    COSTVUE1 = rd2("PrecioCompra").ToString
                    PRECIOSINIVA1 = FormatNumber(rd2("PrecioVentaIVA").ToString / CDec(rd2("IVA").ToString + 1), 2)
                    DEPA = rd2("Departamento").ToString
                    GRUPO = rd2("Grupo").ToString
                    MULTIPLO = rd2("Multiplo").ToString
                    If CDec(rd2("IVA").ToString) > 0 Then
                        TOTALSIVA = FormatNumber(mytotal / 1.16, 2)
                    Else
                        TOTALSIVA = mytotal
                    End If
                End If
            Else
                If mycodigo = "WXYZ" Then
                    COSTVUE1 = 0
                    PRECIOSINIVA1 = FormatNumber(myprecio, 2)
                    DEPA = "UNICO"
                    GRUPO = "UNICO"
                    MULTIPLO = 1
                    TOTALSIVA = FormatNumber(mytotal, 2)
                End If
            End If
            rd2.Close()
            cnn2.Close()

            varieps = 0
            vartotal = 0

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,TasaIEPS,TotalIEPS,Descto,Facturado) VALUES('" & folio & "','" & mycodigo & "','" & mydescripcion & "'," & mycantidad & ",'" & myunidad & "'," & myprecio & "," & COSTVUE1 & "," & myprecio & "," & mytotal & "," & PRECIOSINIVA1 & "," & TOTALSIVA & ",'" & mymesero & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & DEPA & "','" & GRUPO & "','" & mycomensal & "'," & varieps & "," & vartotal & ",'0','0')"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            If saldomonnuevo <> 0 Then
                Dim saldomonderopro As Double = 0
                saldomonderopro = 0
                saldomonderopro = CDec(CDec(txtTotal.Text) - CDec(montopagomonedero)) * CDec(PORCENTAJEMONEDERO / 100)

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & foliomonedero & "','Asigna Puntos','" & saldomonderopro & "'," & montopagomonedero & "," & saldomonnuevo & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & folio & ")"
                cmd3.ExecuteNonQuery()
                cnn3.Close()
            End If

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO VtaImpresion(Folio,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,comensal,Propina) VALUES(" & folio & ",'" & mycodigo & "','" & mydescripcion & "'," & mycantidad & ",'" & myunidad & "'," & myprecio & "," & COSTVUE1 & "," & myprecio & "," & mytotal & "," & PRECIOSINIVA1 & "," & TOTALSIVA & ",'" & mymesero & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & DEPA & "','" & GRUPO & "','" & mycomensal & "'," & txtPropina.Text & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            If cboComensal.Text = "" Then
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "UPDATE Rep_Comandas SET Status='PAGADO' WHERE NMESA='" & lblmesa.Text & "' AND Status<>'CANCELADA' AND Codigo='" & mycodigo & "' AND Nombre='" & mydescripcion & "'"
                cmd3.ExecuteNonQuery()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "DELETE FROM Comandas WHERE NMESA='" & lblmesa.Text & "' AND Codigo='" & mycodigo & "' AND Nombre='" & mydescripcion & "' AND IDC=" & idc & ""
                cmd3.ExecuteNonQuery()
                cnn3.Close()


            Else
                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "UPDATE Rep_Comandas SET Status='PAGADO' WHERE NMESA='" & lblmesa.Text & "' AND Status<>'CANCELADA' AND Codigo='" & mycodigo & "' AND Nombre='" & mydescripcion & "'"
                cmd3.ExecuteNonQuery()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "DELETE FROM Comandas WHERE NMESA='" & lblmesa.Text & "' AND Codigo='" & mycodigo & "' AND Nombre='" & mydescripcion & "' AND IDC=" & idc & ""
                cmd3.ExecuteNonQuery()
                cnn3.Close()
            End If

            kreaper = kreaper + 1
        Loop

        Dim MontoEffe As Double = 0
        Dim SLD1 As Double = 0
        Dim SLD As Double = 0
        Dim Abon As Double = 0
        Dim MySaldo As Double = 0
        Dim MyAcuenta As Double = 0
        Dim montoefectivo As Double = 0
        Dim cambioventa22 As Double = 0
        MontoEffe = (IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)) - (CDec(txtCambio.Text))

        SLD1 = (CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text)) + CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)))

        If CDec(SLD1) >= CDec(txtTotal.Text) Then
            SLD = 0
        End If

        Abon = CDec(IIf(txtEfectivo.Text = 0, "0", txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, "0", txtpagos.Text)) + CDec(IIf(txtPropina.Text = 0, "0", txtPropina.Text)) - (CDec(txtCambio.Text + CDbl(IIf(txtDescuento.Text = 0, "0", txtDescuento.Text))))

        Abon = CDec(IIf(txtEfectivo.Text = 0, "0", txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, "0", txtpagos.Text)) - CDbl(IIf(txtCambio.Text = 0, "0", txtCambio.Text))

        If Abon < 0 Then Exit Sub : Abon = 0

        ' MyAcuenta = FormatNumber(IIf(MontoEffe = 0, 0, MontoEffe) + CDec(txtpagos.Text), 2)
        MyAcuenta = FormatNumber(IIf(MontoEffe = 0, 0, MontoEffe), 2)
        montoefectivo = txtEfectivo.Text
        cambioventa22 = txtCambio.Text


        If grdPagos.Rows.Count > 0 Then
            For luffy = 0 To grdPagos.Rows.Count - 1

                Dim formapago As String = grdPagos.Rows(luffy).Cells(0).Value.ToString
                Dim bancoforma As String = grdPagos.Rows(luffy).Cells(1).Value.ToString
                Dim referencia As String = grdPagos.Rows(luffy).Cells(2).Value.ToString
                Dim montopago As Double = grdPagos.Rows(luffy).Cells(3).Value.ToString
                Dim comentario As String = grdPagos.Rows(luffy).Cells(5).Value.ToString
                Dim cuentarep As String = grdPagos.Rows(luffy).Cells(6).Value.ToString
                Dim bancorep As String = grdPagos.Rows(luffy).Cells(7).Value.ToString

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                            "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Fecha,Hora,Folio,Comentario) values('" & formapago & "','" & bancoforma & "','" & referencia & "','Venta'," & montopago & ",0," & montopago & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MyFolio & "','" & comentario & "')"
                cmd1.ExecuteNonQuery()
                cnn1.Close()

                If CDec(montopago) > 0 Then

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Propina,Monto,Banco,Referencia,Comentario,Usuario,Comisiones,Mesero,Descuento) VALUES(" & folio & ",0,'" & lblmesa.Text & "','ABONO','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','0'," & Abon & "," & SLD & ",'" & formapago & "'," & txtPropina.Text & "," & montopago & ",'" & bancoforma & "','" & referencia & "','" & comentario & "','" & lblusuario2.Text & "'," & totcomi & ",'" & lblMesero.Text & "'," & descuentoventa22 & ")"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()
                End If

                If formapago = "MONEDERO" Then
                    If CDec(montopago) > 0 Then
                        cnn3.Close() : cnn3.Open()
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "UPDATE Monedero SET Saldo=Saldo-" & CDec(montopago) & ",Cargado='0' WHERE Id=" & IDMON & ""
                        cmd3.ExecuteNonQuery()
                        cnn3.Close()
                    End If
                End If

            Next
        End If

        If CDec(Abon) > 0 Then

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,Cargo,Abono,Saldo,FormaPago,Propina,Monto,Banco,Referencia,Comentario,Usuario,Comisiones,Mesero,Descuento) VALUES(" & folio & ",0,'" & lblmesa.Text & "','ABONO','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','0'," & Abon & "," & SLD & ",'EFECTIVO'," & txtPropina.Text & "," & MontoEffe & ",'','','','" & lblusuario2.Text & "'," & totcomi & ",'" & lblMesero.Text & "'," & descuentoventa22 & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()
        End If

        Dim existencia_inicial As Double = 0
        Dim opeCantReal As Double = 0
        Dim opediferencia As Double = 0


        Dim VarCodigo As String = ""
        Dim VarDesc As String = ""
        Dim VarCanti As Double = 0


        For koni = 0 To grdcomanda.Rows.Count - 1

            existencia_inicial = 0
            opeCantReal = 0
            opediferencia = 0

            Dim MYCODIGOP As String = grdcomanda.Rows(koni).Cells(1).Value.ToString
            Dim MYCANT = grdcomanda.Rows(koni).Cells(4).Value.ToString

            Dim MyCostVUE As Double = 0
            Dim MyProm As Double = 0
            Dim MyDepto As String = ""
            Dim MyGrupo As String = ""
            Dim Kit As Integer = 0
            Dim MyMCD As Double = 0
            Dim MyMulti2 As Double = 0
            Dim UNICO As Integer = 0
            Dim gprint As String = ""

            Dim MyMultiplo As Double = 0
            Dim Existencia As Double = 0
            Dim Pre_Comp As Double = 0

            Dim existe As Double = 0

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & mycodigo & "' "
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MULTIPLO = rd1("Multiplo").ToString

                    If rd1("Modo_Almacen").ToString = 1 Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT CodigoP,Codigo,Descrip,Cantidad FROM MiProd WHERE CodigoP='" & Strings.Left(MYCODIGOP, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        Do While rd2.Read
                            If rd2.HasRows Then


                                VarCodigo = rd2("Codigo").ToString
                                VarDesc = rd2("Descrip").ToString
                                VarCanti = rd2("Cantidad").ToString * grdcomanda.Rows(koni).Cells(4).Value.ToString

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & VarCodigo & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then

                                        MyCostVUE = 0
                                        MyProm = 0
                                        MyDepto = rd3("Departamento").ToString()
                                        MyGrupo = rd3("Grupo").ToString()
                                        Kit = rd3("ProvRes").ToString()
                                        MyMCD = rd3("MCD").ToString()
                                        MyMulti2 = rd3("Multiplo").ToString()
                                        UNICO = rd3("Unico").ToString()
                                        gprint = rd3("GPrint").ToString
                                        If CStr(rd3("Departamento").ToString()) = "SERVICIOS" Then
                                            rd3.Close() : cnn3.Close()
                                            GoTo Door
                                        End If

                                    End If
                                End If
                                rd3.Close()


                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(VarCodigo, 6) & "'"
                                rd3 = cmd3.ExecuteReader
                                If rd3.HasRows Then
                                    If rd3.Read Then
                                        existe = rd3("Existencia").ToString()
                                        MyMultiplo = rd3("MCD").ToString()
                                        Existencia = existe / MyMultiplo
                                        If rd3("Departamento").ToString() <> "SERVICIOS" Then
                                            Pre_Comp = rd3("PrecioCompra").ToString()
                                            MyCostVUE = Pre_Comp * (MYCANT / MyMCD)
                                        End If
                                    End If
                                End If
                                rd3.Close()

                                opeCantReal = CDbl(VarCanti) * CDbl(MyMulti2)
                                Dim nueva_existe As Double = 0
                                nueva_existe = Existencia - (VarCanti / MyMCD)


                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & VarCodigo & "','" & VarDesc & "','Venta-Ingrediente'," & opeCantReal & "," & Pre_Comp & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblusuario2.Text & "'," & Existencia & "," & nueva_existe & "," & folio & ")"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "UPDATE Productos SET Cargado=0,CargadoInv=0,Existencia=" & nueva_existe & " WHERE Codigo='" & Strings.Left(VarCodigo, 6) & "'"
                                cmd4.ExecuteNonQuery()

                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "INSERT INTO Mov_Ingre(Codigo,Descripcion,Cantidad,Fecha) VALUES('" & VarCodigo & "','" & VarDesc & "'," & VarCanti & ",'" & Format(Date.Now, "yyyy/MM/dd") & "')"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        Loop
                        rd2.Close()
                        cnn2.Close()
                        cnn3.Close()

                    Else
                        If grdcomanda.Rows(koni).Cells(0).Value.ToString = "" Then GoTo Door

                        Dim mycodigod As String = grdcomanda.Rows(koni).Cells(1).Value.ToString

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & mycodigo & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                MyCostVUE = 0
                                MyProm = 0
                                MyDepto = rd2("Departamento").ToString()
                                MyGrupo = rd2("Grupo").ToString()
                                Kit = rd2("ProvRes").ToString()
                                MyMCD = rd2("MCD").ToString()
                                MyMulti2 = rd2("Multiplo").ToString()
                                UNICO = rd2("Unico").ToString()
                                gprint = rd2("GPrint").ToString
                                If CStr(rd2("Departamento").ToString()) = "SERVICIOS" Then
                                    rd2.Close() : cnn2.Close()
                                    GoTo Door
                                End If
                            End If
                        End If
                        rd2.Close()


                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Productos WHERE Codigo='" & Strings.Left(mycodigo, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                existe = rd2("Existencia").ToString()
                                MyMultiplo = rd2("MCD").ToString()
                                Existencia = existe / MyMultiplo
                                If rd2("Departamento").ToString() <> "SERVICIOS" Then
                                    Pre_Comp = rd2("PrecioCompra").ToString()
                                    MyCostVUE = Pre_Comp * (MYCANT / MyMCD)
                                End If
                            End If
                        End If
                        rd2.Close()
Door:

                        opeCantReal = 0



                        opeCantReal = CDbl(MYCANT) * CDbl(MyMulti2)
                        Dim nueva_existe As Double = 0
                        nueva_existe = Existencia - (MYCANT / MyMCD)


                        cnn4.Close() : cnn4.Open()
                        cmd4 = cnn4.CreateCommand
                        cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & VarCodigo & "','" & VarDesc & "','Venta-Ingrediente'," & opeCantReal & "," & Pre_Comp & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblusuario2.Text & "'," & Existencia & "," & nueva_existe & "," & folio & ")"
                        cmd4.ExecuteNonQuery()

                        cmd4 = cnn4.CreateCommand
                        cmd4.CommandText = "UPDATE Productos SET Existencia=" & nueva_existe & ",Cargado=0,CargadoInv=0 WHERE Codigo='" & Strings.Left(mycodigo, 6) & "'"
                        cmd4.ExecuteNonQuery()
                        cnn4.Close()

                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            'Dim necesito As Double = MYCANT / MyMCD
            'Dim tengo As Double = 0
            'Dim cuanto_cuestan As Double = 0
            'Dim id_peps As Integer = 0
            'Dim utilidad As Double = 0

            'Dim quedan As Double = 0
            'Dim v_costo As Double = 0
            'Dim v_venta As Double = 0

            'cnn1.Close() : cnn1.Open()
            'If DEPA <> "SERVICIOS" Then
            '    'Cálculos de PePs
            '    Do While necesito > 0
            '        cmd1 = cnn1.CreateCommand
            '        cmd1.CommandText =
            '                    "select Id,Saldo,Costo from Costeo where Id=(select MIN(Id) from Costeo where (Concepto='COMPRA' or Concepto='ENTRADA') and Saldo>0 and Codigo='" & Strings.Left(mycodigo, 6) & "')"
            '        rd1 = cmd1.ExecuteReader
            '        If rd1.HasRows Then
            '            If rd1.Read Then
            '                id_peps = rd1("Id").ToString()
            '                tengo = rd1("Saldo").ToString()
            '                cuanto_cuestan = rd1("Costo").ToString()
            '            End If
            '        Else
            '            'Esto para evitar un bucle cuando no hay una compra previa
            '            rd1.Close()
            '            Exit Do
            '        End If
            '        rd1.Close()

            '        'En todo va a hacer los cálculos de la utilidad
            '        If tengo >= necesito Then
            '            quedan = tengo - necesito
            '            cmd1 = cnn1.CreateCommand
            '            cmd1.CommandText =
            '                        "update Costeo set Saldo=" & quedan & " where Id=" & id_peps
            '            cmd1.ExecuteNonQuery()

            '            v_costo = necesito * cuanto_cuestan
            '            v_venta = necesito * myprecio
            '            utilidad = utilidad + (v_venta - v_costo)

            '            Exit Do
            '        ElseIf tengo < necesito Then
            '            cmd1 = cnn1.CreateCommand
            '            cmd1.CommandText =
            '                        "update Costeo set Saldo=0 where Id=" & id_peps
            '            cmd1.ExecuteNonQuery()

            '            v_costo = tengo * cuanto_cuestan
            '            v_venta = tengo * myprecio
            '            utilidad = (v_venta - v_costo)
            '            necesito = necesito - tengo

            '            cmd1 = cnn1.CreateCommand
            '            cmd1.CommandText =
            '                        "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycodigo, 6) & "','" & mydescripcion & "','" & myunidad & "',0," & (tengo * MULTIPLO) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario2.Text & "')"
            '            cmd1.ExecuteNonQuery()
            '            utilidad = 0
            '        End If
            '    Loop

            '    'Sí alcanzan las que tengo en el primer registro, entonces guarda y avanza

            '    If mycodigo <> "xc3" Then
            '        cmd1 = cnn1.CreateCommand
            '        cmd1.CommandText =
            '                    "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','VENTA','" & MyFolio & "','" & Strings.Left(mycodigo, 6) & "','" & mydescripcion & "','" & myunidad & "',0," & (necesito * MULTIPLO) & ",0," & cuanto_cuestan & "," & myprecio & "," & utilidad & ",'" & lblusuario2.Text & "')"
            '        cmd1.ExecuteNonQuery()
            '    End If



            'End If
            'rd1.Close()
            'cnn1.Close()
        Next

        If montopagomonedero <> 0 Then
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "INSERT INTO Mov_Monedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & foliomonedero & "','Pago Puntos'," & saldomonnuevo & "," & saldomonnuevo & "," & montopagomonedero & ",'" & Format(Date.Now, "yyyy/MM/dd") & "'," & folio & ")"
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        End If

        If CDec(txtResta.Text) > 0 Then
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "UPDATE Ventas SET Status='RESTA' WHERE Folio=" & folio & ""
            cmd2.ExecuteNonQuery()
            cnn2.Close()
        End If

        If CDec(txtResta.Text) = 0 Then
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM comandas WHERE Nmesa='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM Mesa WHERE Nombre_mesa='" & lblmesa.Text & "' AND Temporal='1'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM MesasxEmpleados WHERE Mesa='" & lblmesa.Text & "' AND Temporal='1'"
                cmd2.ExecuteNonQuery()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "DELETE FROM Comanda1 WHERE Nombre='" & lblmesa.Text & "'"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
        End If

#Region "TICKET"

        Dim copias As Integer = 0
        Dim TamImpre As Integer = 0
        Dim impresora As String = ""
        Dim imprime As Integer = 0

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Copias FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                copias = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                TamImpre = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NoPrint FROM Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                imprime = rd1(0).ToString
            End If
        End If
        rd1.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Equipo='" & ObtenerNombreEquipo() & "' AND Tipo='TICKET'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                impresora = rd1(0).ToString
            End If
        Else
            MsgBox("No tienes una impresora configurada para imprimir en formato Ticket.", vbInformation + vbOKOnly, titulomensajes)
            cnn1.Close()
        End If
        rd1.Close()
        cnn1.Close()

        If imprime = 1 Then

            If MessageBox.Show("Desea Cerrar esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then

                If TamImpre = "80" Then
                    For naruto As Integer = 1 To copias
                        PVentaMapeo80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        Dim ps As New System.Drawing.Printing.PaperSize("Custom", 310, 3100)
                        PVentaMapeo80.DefaultPageSettings.PaperSize = ps
                        PVentaMapeo80.Print()
                    Next
                End If

                If TamImpre = "58" Then
                    For naruto As Integer = 1 To copias
                        PVentaMapeo58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                        PVentaMapeo58.Print()
                    Next
                End If
            End If

        Else
            If TamImpre = "80" Then
                For naruto As Integer = 1 To copias
                    PVentaMapeo80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    Dim ps As New System.Drawing.Printing.PaperSize("Custom", 310, 3100)
                    PVentaMapeo80.DefaultPageSettings.PaperSize = ps
                    PVentaMapeo80.Print()
                Next
            End If

            If TamImpre = "58" Then
                For naruto As Integer = 1 To copias
                    PVentaMapeo58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                    PVentaMapeo58.Print()
                Next
            End If

        End If


#End Region

        btnlimpiar.PerformClick()
        Me.Close()

        frmMesas.Close()
        frmMesas.Show()
        frmMesas.Show()
    End Sub

    Private Sub btnPrecuenta_Click(sender As Object, e As EventArgs) Handles btnPrecuenta.Click

        If grdcomanda.Rows.Count <> 0 Then

            If lblusuario2.Text = "" Then
                MsgBox("Digite la clave de usuario", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            Else
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT IdEmpleado,Status from Usuarios WHERE Alias='" & lblusuario2.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        idusuario = rd1(0).ToString
                        estadousuario = rd1(1).ToString

                        If estadousuario = 1 Then

                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText = "SELECT Precuenta FROM permisosm WHERE IdEmpleado=" & idusuario & ""
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then

                                End If
                            Else
                                MsgBox("Este usuario no cuenta con permisos para realizar la accion", vbInformation + vbOKOnly, titulomensajes)
                                Exit Sub
                            End If
                            rd2.Close()
                            cnn2.Close()
                        Else
                            MsgBox("El usuario no esta activo", vbInformation + vbOKOnly, titulomensajes)
                            Exit Sub
                            cnn1.Close()
                        End If

                    End If
                Else
                    MsgBox("El usuario no se encuntra registrado", vbInformation + vbOKOnly, titulomensajes)
                    Exit Sub
                    cnn1.Close()
                End If
                rd1.Close()
                cnn1.Close()
            End If

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "DELETE FROM vtaimpresion"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            Dim zi As Integer = 0
            Dim codi As String = ""
            Dim nom As String = ""
            Dim udv As String = ""
            Dim canti As Double = 0
            Dim puvciva As Double = 0
            Dim TOTALL As Double = 0
            Dim comen As String = ""
            Dim mesero As String = ""
            Dim idcoma As Integer = 0

            Dim CostVUE1 As Double = 0
            Dim PrecioSinIVA11 As Double = 0
            Dim TotalSinIVA11 As Double = 0
            Dim Depa11 As String = ""
            Dim Grupo11 As String = ""

            Do While zi <> grdcomanda.Rows.Count
                codi = grdcomanda.Rows(zi).Cells(1).Value.ToString
                nom = grdcomanda.Rows(zi).Cells(2).Value.ToString
                udv = grdcomanda.Rows(zi).Cells(3).Value.ToString
                canti = grdcomanda.Rows(zi).Cells(4).Value.ToString
                puvciva = grdcomanda.Rows(zi).Cells(5).Value.ToString
                TOTALL = grdcomanda.Rows(zi).Cells(6).Value.ToString
                comen = grdcomanda.Rows(zi).Cells(7).Value.ToString
                mesero = grdcomanda.Rows(zi).Cells(8).Value.ToString
                idcoma = grdcomanda.Rows(zi).Cells(9).Value.ToString

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codi & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        CostVUE1 = rd1("PrecioCompra").ToString
                        PrecioSinIVA11 = FormatNumber((rd1("PrecioVentaIVA").ToString) / CDec(rd1("IVA").ToString + 1), 2)
                        TotalSinIVA11 = FormatNumber(CDec(PrecioSinIVA11) * (canti), 2)
                        Depa11 = rd1("Departamento").ToString
                        Grupo11 = rd1("Grupo").ToString
                    End If
                End If
                rd1.Close()

                cnn3.Close() : cnn3.Open()
                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "INSERT INTO VtaImpresion(Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo,Comensal,Mesa) VALUES('" & codi & "','" & nom & "'," & canti & ",'" & udv & "'," & puvciva & "," & CostVUE1 & "," & puvciva & "," & TOTALL & "," & PrecioSinIVA11 & "," & TotalSinIVA11 & ",'" & mesero & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Depa11 & "','" & Grupo11 & "','" & comen & "','" & lblmesa.Text & "')"
                cmd3.ExecuteNonQuery()
                cnn3.Close()

                zi = zi + 1
            Loop
            cnn1.Close()

            Dim tamimpre As Integer = 0
            Dim impresora As String = ""


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
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='TICKET'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impresora = rd1(0).ToString
                End If
            Else
                MsgBox("No tienes una impresora configurada para imprimir en formato ticket.", vbInformation + vbOKOnly, titulomensajes)
                cnn1.Close()
            End If
            rd1.Close()
            cnn1.Close()


            If tamimpre = "80" Then
                Precuenta80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                Dim ps As New System.Drawing.Printing.PaperSize("Custom", 310, 3100)
                Precuenta80.DefaultPageSettings.PaperSize = ps
                Precuenta80.Print()

            End If

            If tamimpre = "58" Then
                Precuenta58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                'Dim ps As New System.Drawing.Printing.PaperSize("Custom", 200, 3100)
                'Precuenta58.DefaultPageSettings.PaperSize = ps
                Precuenta58.Print()
            End If
            Me.BringToFront()
        End If

    End Sub

    Private Sub Precuenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Precuenta80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        Dim cantidad As Double = 0
        Dim descri As String = ""
        Dim precio As Double = 0
        Dim TOTAL As Double = 0
        Dim ope As Double = 0
        Dim TotalIVA As Double = 0
        Dim totalcuenta As Double = 0
        Dim porcentaje As Double = 0
        Dim servicio As Double = 0

        Dim conta As Double = 0
        Dim contband As Double = 0
        Dim comen_sal As String = ""
        Dim TOTALCOM As Double = 0
        Dim numdec As String = ""

        cnn2.Close() : cnn2.Open()
        cnn4.Close() : cnn4.Open()
        cnn3.Close() : cnn3.Open()
        cnn1.Close() : cnn1.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select * from Ticket"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                pie3 = rd2("Pie3").ToString
                pie2 = rd2("Pie2").ToString
                pie1 = rd2("Pie1").ToString
                'Razón social
                If rd2("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'RFC
                If rd2("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd2("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Colonia
                If rd2("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd2("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Teléfono
                If rd2("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Correo
                If rd2("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If

        rd2.Close()
        cnn2.Close()

        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("P R E C U E N T A", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("MESA: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 18
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 20

        traernumerocomensal()

        If SinNumComensal = 1 Then

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    descri = rd3("Nombre").ToString
                    precio = rd3("Precio").ToString
                    TOTAL = rd3("Total").ToString
                    cantidad = rd3("Cantidad").ToString

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd3("Codigo").ToString & "'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then
                            ope = TOTAL / 1.16
                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                            TotalIVA = FormatNumber(TotalIVA, 2)
                        End If
                    Loop
                    rd4.Close()

                    cantidad = FormatNumber(cantidad, 2)

                    e.Graphics.DrawString(cantidad, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 40
                    Dim texto As String = descri
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, Y)
                        Y += 17
                        inicio += caracteresPorLinea
                    End While

                    e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 215, Y, derecha)
                    e.Graphics.DrawString(FormatNumber(TOTAL, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                    Y += 13

                    totalcuenta = totalcuenta + TOTAL


                End If
            Loop
            rd3.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='BAKSHEESH'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    porcentaje = rd3(0).ToString
                    servicio = FormatNumber(CDec(totalcuenta) * CDec(porcentaje) / 100, 2)
                End If
            End If
            rd3.Close()

            cnn3.Close()

        Else
            Dim comensal As String = 0

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT Comensal FROM VtaImpresion"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                comensal = rd4(0).ToString

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Codigo,Nombre,Precio,Sum(Cantidad) as cant,Sum(Total) as tot,Comensal FROM VtaImpresion WHERE Mesa='" & lblmesa.Text & "' AND Comensal='" & comensal & "' group by Comensal,Codigo,Nombre,Precio order by Comensal"
                rd3 = cmd3.ExecuteReader

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Nombre,Precio,Sum(Cantidad) as cant,Sum(Total) as tot,Comensal FROM VtaImpresion WHERE Mesa='" & lblmesa.Text & "' AND Comensal='" & comensal & "' group by Comensal,Codigo,Nombre,Precio order by Comensal"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    conta = conta + 1
                Loop
                rd1.Close()

                Do While rd3.Read
                    If rd3.HasRows Then

                        conta = conta
                        contband = contband + 1

                        If comen_sal <> rd3("Comensal").ToString Then
                            e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                            e.Graphics.DrawString(rd3("comensal").ToString, fuente_b, Brushes.Black, 120, Y)
                            TOTALCOM = 0
                        End If
                        Y += 20


                        cantidad = rd3("Cant").ToString
                        descri = rd3("Nombre").ToString
                        precio = rd3("Precio").ToString
                        TOTAL = rd3("tot").ToString
                        cantidad = FormatNumber(cantidad, 2)

                        e.Graphics.DrawString(cantidad, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 40
                        Dim texto As String = descri
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While

                        e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 215, Y, derecha)
                        e.Graphics.DrawString(FormatNumber(TOTAL, 2), fuente_p, Brushes.Black, 270, Y, derecha)

                        TOTALCOM = CDec(TOTALCOM) + CDec(TOTAL)

                        If contband < conta Then

                            comen_sal = rd3("comensal").ToString
                        ElseIf contband = conta Then
                            comen_sal = 0
                        End If

                        If comen_sal <> rd3("comensal").ToString Then
                            If numdec <> "" Then
                                TOTALCOM = FormatNumber(TOTALCOM, CInt(numdec), 2)
                            Else
                                TOTALCOM = FormatNumber(TOTALCOM, 2)
                            End If
                            'TOTALCOM = FormatNumber(TOTALCOM, 2)
                            Y += 20

                            e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                            e.Graphics.DrawString(FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                            Y += 10

                            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)

                        End If
                        Y += 15
                        comen_sal = rd3("Comensal").ToString
                        totalcuenta = totalcuenta + TOTAL

                    End If
                Loop
                rd3.Close()
            Loop
            rd4.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "select NotasCred from Formatos where Facturas='BAKSHEESH'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    porcentaje = rd3(0).ToString

                    servicio = FormatNumber(CDec(TOTALCOM) * CDec(porcentaje) / 100, 2)

                End If
            End If
            rd3.Close()
        End If

        If servicio > 0 Then
            e.Graphics.DrawString("Servicio: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(servicio, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20
        End If

        e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(totalcuenta + servicio, 2), fuente_a, Brushes.Black, 270, Y, derecha)
        Y += 20

        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11

        Dim CantidaLetra As String = ""

        If SinNumComensal = 0 Then
            CantidaLetra = "Son: " & convLetras(totalcuenta + servicio)
        Else
            CantidaLetra = "Son: " & convLetras(totalcuenta + servicio)
        End If

        If Mid(CantidaLetra, 1, 38) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 39, 500)
            Y += 20
        End If

        If Mid(CantidaLetra, 39, 76) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 39, 76), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 77, 500)
            Y += 20
        End If

        If Mid(pie1, 1, 36) <> "" Then
            e.Graphics.DrawString(Mid(pie1, 1, 36), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If

        If Mid(pie1, 37, 72) <> "" Then
            e.Graphics.DrawString(Mid(pie1, 36, 72), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If
        Y += 12

        e.Graphics.DrawString("Le atiende: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 20


        cnn4.Close()
        cnn3.Close()
        cnn1.Close()
        cnn2.Close()

        e.HasMorePages = False

    End Sub

    Private Sub Precuenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Precuenta58.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)

        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim pie1 As String = ""
        Dim pie2 As String = ""
        Dim pie3 As String = ""

        Dim cantidad As Double = 0
        Dim descri As String = ""
        Dim precio As Double = 0
        Dim TOTAL As Double = 0
        Dim ope As Double = 0
        Dim TotalIVA As Double = 0
        Dim totalcuenta As Double = 0
        Dim porcentaje As Double = 0
        Dim servicio As Double = 0

        Dim conta As Double = 0
        Dim contband As Double = 0
        Dim comen_sal As String = ""
        Dim TOTALCOM As Double = 0
        Dim numdec As String = ""

        cnn2.Close() : cnn2.Open()
        cnn4.Close() : cnn4.Open()
        cnn3.Close() : cnn3.Open()
        cnn1.Close() : cnn1.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select * from Ticket"
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                pie3 = rd2("Pie3").ToString
                pie2 = rd2("Pie2").ToString
                pie1 = rd2("Pie1").ToString

                'Razón social
                If rd2("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'RFC
                If rd2("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'Calle  N°.
                If rd2("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Colonia
                If rd2("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd2("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Teléfono
                If rd2("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Correo
                If rd2("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                Y += 12
            End If
        Else
            Y += 0
        End If

        rd2.Close()
        cnn2.Close()

        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("P R E C U E N T A", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 11
        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("MESA: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString(Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        traernumerocomensal()

        If SinNumComensal = 1 Then

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT * FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            rd3 = cmd3.ExecuteReader
            Do While rd3.Read
                If rd3.HasRows Then

                    descri = rd3("Nombre").ToString
                    precio = rd3("Precio").ToString
                    TOTAL = rd3("Total").ToString

                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd2("Codigo").ToString & "'"
                    rd4 = cmd4.ExecuteReader
                    Do While rd4.Read
                        If rd4.HasRows Then
                            ope = TOTAL / 1.16
                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                            TotalIVA = FormatNumber(TotalIVA, 2)
                        End If
                    Loop
                    rd4.Close()

                    e.Graphics.DrawString(cantidad, fuente_p, Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 25
                    Dim texto As String = descri
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                        Y += 15
                        inicio += caracteresPorLinea
                    End While

                    e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 133, Y, derecha)
                    e.Graphics.DrawString(FormatNumber(TOTAL, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                    Y += 13

                    totalcuenta = totalcuenta + TOTAL


                End If
            Loop
            rd3.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='BAKSHEESH'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    porcentaje = rd3(0).ToString
                    servicio = FormatNumber(CDec(totalcuenta) * CDec(porcentaje) / 100, 2)
                End If
            End If
            rd3.Close()
            cnn3.Close()

        Else
            Dim comensal As String = 0

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT DISTINCT Comensal FROM VtaImpresion"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                comensal = rd4(0).ToString

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText = "SELECT Codigo,Nombre,Precio,Sum(Cantidad) as cant,Sum(Total) as tot,Comensal FROM VtaImpresion WHERE Mesa='" & lblmesa.Text & "' AND Comensal='" & comensal & "' group by Comensal,Codigo,Nombre,Precio order by Comensal"
                rd3 = cmd3.ExecuteReader

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Codigo,Nombre,Precio,Sum(Cantidad) as cant,Sum(Total) as tot,Comensal FROM VtaImpresion WHERE Mesa='" & lblmesa.Text & "' AND Comensal='" & comensal & "' group by Comensal,Codigo,Nombre,Precio order by Comensal"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    conta = conta + 1
                Loop
                rd1.Close()

                Do While rd3.Read
                    If rd3.HasRows Then

                        conta = conta
                        contband = contband + 1

                        If comen_sal <> rd3("Comensal").ToString Then
                            e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                            e.Graphics.DrawString(rd3("comensal").ToString, fuente_b, Brushes.Black, 100, Y)
                            TOTALCOM = 0
                        End If
                        Y += 15


                        cantidad = rd3("Cant").ToString
                        descri = rd3("Nombre").ToString
                        precio = rd3("Precio").ToString
                        TOTAL = rd3("tot").ToString

                        e.Graphics.DrawString(cantidad, fuente_p, Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 25
                        Dim texto As String = descri
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While

                        e.Graphics.DrawString(FormatNumber(precio, 2), fuente_p, Brushes.Black, 133, Y, derecha)
                        e.Graphics.DrawString(FormatNumber(TOTAL, 2), fuente_p, Brushes.Black, 180, Y, derecha)

                        TOTALCOM = CDec(TOTALCOM) + CDec(TOTAL)

                        If contband < conta Then

                            comen_sal = rd3("comensal").ToString
                        ElseIf contband = conta Then
                            comen_sal = 0
                        End If

                        If comen_sal <> rd3("comensal").ToString Then
                            If numdec <> "" Then
                                TOTALCOM = FormatNumber(TOTALCOM, CInt(numdec), 2)
                            Else
                                TOTALCOM = FormatNumber(TOTALCOM, 2)
                            End If
                            'TOTALCOM = FormatNumber(TOTALCOM, 2)
                            Y += 20

                            e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                            e.Graphics.DrawString(FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                            Y += 15

                            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)

                        End If
                        Y += 10
                        comen_sal = rd3("Comensal").ToString
                        totalcuenta = totalcuenta + TOTAL

                    End If
                Loop
                rd3.Close()
            Loop
            rd4.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "select NotasCred from Formatos where Facturas='BAKSHEESH'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    porcentaje = rd3(0).ToString

                    servicio = FormatNumber(CDec(TOTALCOM) * CDec(porcentaje) / 100, 2)

                End If
            End If
            rd3.Close()
        End If

        If servicio > 0 Then
            e.Graphics.DrawString("Servicio: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(servicio, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15
        End If

        e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(totalcuenta + servicio, 2), fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11

        Dim CantidaLetra As String = ""

        If SinNumComensal = 0 Then
            CantidaLetra = "Son: " & convLetras(totalcuenta + servicio)
        Else
            CantidaLetra = "Son: " & convLetras(totalcuenta + servicio)
        End If

        If Mid(CantidaLetra, 1, 24) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 24), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 25, 500)
            Y += 15
        End If

        If Mid(CantidaLetra, 25, 48) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 25, 48), fuente_r, Brushes.Black, 1, Y)
            CantidaLetra = Mid(CantidaLetra, 49, 500)
            Y += 15
        End If

        If Mid(pie1, 1, 36) <> "" Then
            e.Graphics.DrawString(Mid(pie1, 1, 36), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If

        If Mid(pie1, 37, 72) <> "" Then
            e.Graphics.DrawString(Mid(pie1, 37, 72), fuente_r, Brushes.Black, 1, Y)
            Y += 12
        End If
        Y += 12

        e.Graphics.DrawString("Le atiende: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)

        cnn4.Close()
        cnn3.Close()
        cnn1.Close()
        cnn2.Close()

        e.HasMorePages = False

    End Sub

    Private Sub grdcomanda_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcomanda.CellClick

        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 0 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If

        If celda.ColumnIndex = 1 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 2 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 3 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 4 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If

        If celda.ColumnIndex = 5 Then

            comandaeliminar = grdcomanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdcomanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdcomanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdcomanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdcomanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdcomanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdcomanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdcomanda.CurrentRow.Cells(9).Value.ToString

        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim CancelComand As Integer = 0
        Dim CantidadP As String = ""
        Dim canc As String = ""

        Dim COSTVUE1 As Double = 0
        Dim PRECIOSINIVA1 As Double = 0
        Dim IVA As Double = 0
        Dim PRECIOSINIVA11 As Double = 0
        Dim TOTALSINIVA As Double = 0
        Dim TOTAL1 As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO1 As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cnn2.Close() : cnn2.Open()


            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IdEmpleado,Status FROM Usuarios WHERE Alias='" & lblusuario2.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    idusuario = rd1(0).ToString
                    estadousuario = rd1(1).ToString

                    If estadousuario = 1 Then

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT CancelarM FROM permisosm WHERE IdEmpleado=" & idusuario & ""
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                            End If
                        Else
                            MsgBox("El usuario no cuenta con permisos para realizar esta accion", vbInformation + vbOKOnly, titulomensajes)
                            Exit Sub
                        End If
                        rd2.Close()
                        cnn2.Close()
                    Else
                        MsgBox("El usuario no esta activo contacte a su administrador", vbInformation + vbOKOnly, titulomensajes)
                        Exit Sub
                    End If

                End If
            Else
                MsgBox("El usuario no esta registrado", vbInformation + vbOKOnly, titulomensajes)
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()

            If grdcomanda.Rows.Count < 0 Then Exit Sub

            CantidadP = InputBox("Ingrese cantidad a cancelar para el producto " & descripcioneliminar, "Cancelar Producto", 1)
            My.Application.DoEvents()

            If CantidadP <> "" Then
                If cantidadeliminar >= CantidadP Then
                    If MsgBox("¿Seguro que desea continuar con la cancelacion?", vbInformation + vbOKCancel, "Delsscom® Restaurant") = vbCancel Then
                        Exit Sub
                    End If
                    canc = Val(CantidadP)
                    'Call PRINT1(comandaeliminar, codigoeliminar)

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT * FROM Productos WHERE Codigo='" & codigoeliminar & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.Read Then
                        If rd3.HasRows Then

                            COSTVUE1 = rd3("PrecioCompra").ToString
                            PRECIOSINIVA1 = rd3("PrecioVentaIVA").ToString
                            IVA = rd3("IVA").ToString
                            PRECIOSINIVA11 = FormatNumber(PRECIOSINIVA1 / IVA, 2)
                            TOTALSINIVA = FormatNumber(CDec(CantidadP * precioeliminar / 1.6), 2)
                            TOTAL1 = FormatNumber(CDec(CantidadP * precioeliminar), 2)
                            DEPA = rd3("Departamento").ToString
                            GRUPO1 = rd3("Grupo").ToString

                        End If
                    End If
                    rd3.Close()

                    cnn4.Close() : cnn4.Open()
                    cmd4 = cnn4.CreateCommand
                    cmd4.CommandText = "INSERT INTO Devoluciones(Folio,Codigo,Nombre,UVenta,Cantidad,CostVR,CostVP,CostoVUE,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Facturado,Depto,Grupo,ImporteEfec,NMESA,CUsuario,Hr,TipoMov) VALUES(" & ideliminar & ",'" & codigoeliminar & "','" & descripcioneliminar & "','" & unidadeliminar & "'," & CantidadP & ",0,0," & COSTVUE1 & "," & precioeliminar & "," & TOTAL1 & "," & PRECIOSINIVA1 & "," & TOTALSINIVA & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','',0,'" & DEPA & "','" & GRUPO1 & "',0,'" & lblmesa.Text & "','" & lblusuario2.Text & "','" & Format(Date.Now, "HH:mm:ss") & "','CANCELACION')"
                    cmd4.ExecuteNonQuery()
                    cnn4.Close()

                    If cantidadeliminar = CantidadP Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Status='CANCELADA' WHERE Id=" & ideliminar & " AND IDC=" & comandaeliminar & ""
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "DELETE FROM Comandas WHERE Id=" & ideliminar & " AND IDC=" & comandaeliminar & ""
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT NMESA FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                            End If
                        Else
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "DELETE FROM Comanda1 WHERE Nombre='" & lblmesa.Text & "'"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Nombre FROM Comanda1 WHERE Nombre='" & lblmesa.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then



                            End If
                        Else
                            cnn3.Close() : cnn3.Open()
                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "DELETE FROM Mesa WHERE Nombre_Mesa='" & lblmesa.Text & "' AND Temporal=1"
                            cmd3.ExecuteNonQuery()

                            cmd3 = cnn3.CreateCommand
                            cmd3.CommandText = "DELETE FROM MesasxEmpleados WHERE Mesa='" & lblmesa.Text & "' AND Temporal=1"
                            cmd3.ExecuteNonQuery()
                            cnn3.Close()
                        End If
                        rd2.Close()
                        cnn2.Close()

                        MsgBox("Cancelación realizada correctamente.", vbInformation + vbOKOnly, titulomensajes)
                        Me.Close()
                    Else

                        HrTiempo = Format(Date.Now, "yyyy/MM/dd")
                        HrEntrega = Format(Date.Now, "yyyy/MM/dd")

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE Id=" & ideliminar & " AND Codigo='" & codigoeliminar & "'"
                        cmd2.ExecuteNonQuery()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Total=Cantidad * Precio WHERE Id=" & ideliminar & " AND Codigo='" & codigoeliminar & "'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM Rep_Comandas WHERE Id=" & verid & " AND Codigo='" & vercodigo & "' AND Status<>'CANCELADA'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                cnn4.Close() : cnn4.Open()
                                cmd4 = cnn4.CreateCommand
                                cmd4.CommandText = "INSERT INTO Rep_Comandas(NMESA,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Comensal,Status,Comentario,GPrint,CUsuario,Total_comensales,Grupo,EstatusT,Hr,EntregaT) VALUES('" & lblmesa.Text & "','" & rd2("Codigo").ToString & "','" & rd2("Nombre").ToString & "'," & CantidadP & ",'" & rd2("UVenta").ToString & "'," & rd2("CostVUE").ToString & "," & rd2("CostVP").ToString & "," & rd2("Precio").ToString & "," & rd2("Total").ToString & "," & rd2("PrecioSinIVA").ToString & "," & rd2("TotalSinIVA").ToString & ",'" & rd2("Comisionista").ToString & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & rd2("Depto").ToString & "','" & rd2("Comensal").ToString & "','CANCELADA','" & rd2("Comentario").ToString & "','" & rd2("GPrint").ToString & "','" & rd2("CUsuario").ToString & "','" & rd2("Total_comensales").ToString & "','" & rd2("Grupo").ToString & "',0,'" & HrTiempo & "','" & HrEntrega & "')"
                                cmd4.ExecuteNonQuery()
                                cnn4.Close()

                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()

                    End If

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comandas SET Cantidad=" & cantidadeliminar - CantidadP & " WHERE IDC=" & comandaeliminar & ""
                    cmd2.ExecuteNonQuery()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE Comandas SET Total= Cantidad * Precio  WHERE IDC=" & comandaeliminar & ""
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                    cnn3.Close()
                    Call PRINT1(comandaeliminar, codigoeliminar)
                Else
                    MsgBox("No es posible cancelar una cantidad mayor a este producto.", vbInformation + vbOKOnly, titulomensajes)
                End If
            End If
            cnn3.Close()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
        End Try

    End Sub

    Public Function PRINT1(IDComanda As String, CodigoProd As String) As Boolean

        Dim impre As String = ""
        Dim impresoracomanda As String = ""
        Dim tamimpre As Integer = 0


        Try
            cnn2.Close() : cnn2.Open()
            cnn3.Close() : cnn3.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TamImpre'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    tamimpre = rd2(0).ToString
                End If
            End If
            rd2.Close()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT DISTINCT Gprint FROM Comandas WHERE IDC=" & IDComanda & " AND Codigo='" & CodigoProd & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    impre = rd2(0).ToString

                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "SELECT Impresora FROM RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & impre & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            impresoracomanda = rd3(0).ToString
                        End If
                    Else
                        MsgBox("No se tiene instalada ninguna impresora!", vbCritical, titulomensajes)
                        PRINT1 = False
                        ' imprime = False
                        Exit Function
                    End If
                    rd3.Close()
                    cnn3.Close()

                    If tamimpre = "80" Then
                        Cancelacion80.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        Cancelacion80.Print()

                    End If

                    If tamimpre = "58" Then
                        Cancelacion58.DefaultPageSettings.PrinterSettings.PrinterName = impresoracomanda
                        Cancelacion58.Print()
                    End If
                End If
            End If
            rd2.Close()
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Function

    Private Sub Cancelacion80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Cancelacion80.PrintPage

        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim pie1 As String = ""
            Dim pie2 As String = ""
            Dim pie3 As String = ""
            Dim CveUsr As String = ""

            cnn2.Close() : cnn2.Open()
            cnn4.Close() : cnn4.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie3 = rd2("Pie3").ToString
                    pie2 = rd2("Pie2").ToString
                    pie1 = rd2("Pie1").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                        Y += 12.5
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                        Y += 12.5
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                        Y += 12
                    End If
                    Y += 17
                End If
            Else
                Y += 0
            End If
            rd2.Close()
            cnn2.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O M A N D A   C A N C E L A D A", fuente_b, Brushes.Black, 135, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & comandaeliminar, fuente_r, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
            e.Graphics.DrawString("COMENSAL", fuente_b, Brushes.Black, 270, Y, derecha)
            Y += 20

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT * FROM Comandas WHERE IDC='" & comandaeliminar & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then

                    e.Graphics.DrawString(cantidadeliminar, fuente_b, Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 40
                    Dim texto As String = descripcioneliminar
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                        Y += 15
                        inicio += caracteresPorLinea
                    End While

                    e.Graphics.DrawString(comensaleliminar, fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 15

                End If
            Loop
            rd4.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("MESA: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("MESERO: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)

            cnn4.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
            cnn4.Close()
        End Try

    End Sub

    Private Sub Cancelacion58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Cancelacion58.PrintPage
        Try
            Dim tipografia As String = "Lucida Sans Typewriter"
            Dim fuente_r As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_b As New Font("Lucida Sans Typewriter", 7, FontStyle.Bold)
            Dim fuente_c As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
            Dim fuente_p As New Font("Lucida Sans Typewriter", 6, FontStyle.Regular)
            Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim hoja As New Pen(Brushes.Black, 1)
            Dim Y As Double = 0

            Dim pie1 As String = ""
            Dim pie2 As String = ""
            Dim pie3 As String = ""

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    pie3 = rd2("Pie3").ToString
                    pie2 = rd2("Pie2").ToString
                    pie1 = rd2("Pie1").ToString
                    'Razón social
                    If rd2("Cab0").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                        Y += 11
                    End If
                    'RFC
                    If rd2("Cab1").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                        Y += 11
                    End If
                    'Calle  N°.
                    If rd2("Cab2").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                        Y += 10
                    End If
                    'Colonia
                    If rd2("Cab3").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                        Y += 10
                    End If
                    'Delegación / Municipio - Entidad
                    If rd2("Cab4").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                        Y += 10
                    End If
                    'Teléfono
                    If rd2("Cab5").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                        Y += 10
                    End If
                    'Correo
                    If rd2("Cab6").ToString() <> "" Then
                        e.Graphics.DrawString(rd2("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                        Y += 10
                    End If
                    Y += 2
                End If
            Else
                Y += 0
            End If
            cnn2.Close()
            cnn2.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("C O M A N D A   C A N C E L A D A", fuente_b, Brushes.Black, 90, Y, centro)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Folio: " & comandaeliminar, fuente_r, Brushes.Black, 1, Y)
            Y += 18
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "yyyy/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Format(Date.Now, "HH:mm:ss"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("COMENSAL", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT * FROM Comandas WHERE IDC='" & comandaeliminar & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then
                    e.Graphics.DrawString(cantidadeliminar, fuente_b, Brushes.Black, 1, Y)

                    Dim caracteresPorLinea As Integer = 25
                    Dim texto As String = descripcioneliminar
                    Dim inicio As Integer = 0
                    Dim longitudTexto As Integer = texto.Length

                    While inicio < longitudTexto
                        Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                        Dim bloque As String = texto.Substring(inicio, longitudBloque)
                        e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                        Y += 15
                        inicio += caracteresPorLinea
                    End While

                    e.Graphics.DrawString(comensaleliminar, fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                End If
            Loop
            rd4.Close()

            e.Graphics.DrawString("------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("MESA: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
            Y += 15
            e.Graphics.DrawString("MESERO: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)

            cnn4.Close()
            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Private Sub txtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboCuenta.Focus.Equals(True)
        End If
    End Sub

    Private Sub PVentaMapeo80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVentaMapeo80.PrintPage

        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim fuente_a As New Font("Lucida Sans Typewriter", 12, FontStyle.Bold)

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

        Dim nombrepro As String = ""
        Dim preciopro As Double = 0
        Dim importepro As Double = 0
        Dim cantidadpro As Double = 0
        Dim propina As Double = 0
        Dim usuario As String = ""

        Dim ope As Double = 0
        Dim TotalIVA As Double = 0
        Dim articulos As Integer = 0
        Dim acumuladocortesia As Double = 0

        Dim comen_sal As String = ""
        Dim TOTALCOM As Double = 0
        Dim totalventa As Double = 0
        Dim numdec As String = ""

        Dim Pie1 As String = ""

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()
        cnn3.Close() : cnn3.Open()
        cnn4.Close() : cnn4.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folio
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                foliofactura = rd2(0).ToString
            End If
        End If
        rd2.Close()


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
                    Y += 17
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

            e.Graphics.DrawString("Mesa: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString("Folio: " & folio, fuente_r, Brushes.Black, 270, Y, derecha)
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
            traernumerocomensal()

            If SinNumComensal = 1 Then

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "Select Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, comensal,Propina from VtaImpresion where Folio=" & folio & " Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        nombrepro = rd4("Nombre").ToString
                        preciopro = rd4("Precio").ToString
                        importepro = rd4("Tot").ToString
                        cantidadpro = rd4("Cant").ToString
                        propina = rd4("Propina").ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd4("Codigo").ToString & "'"
                        rd3 = cmd3.ExecuteReader
                        Do While rd3.Read
                            If rd3.HasRows Then
                                ope = importepro / 1.16
                                TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                            End If
                        Loop
                        rd3.Close()

                        acumuladocortesia = acumuladocortesia + (preciopro * cantidadpro)

                        e.Graphics.DrawString(FormatNumber(cantidadpro, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                        Dim caracteresPorLinea As Integer = 40
                        Dim texto As String = nombrepro
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                            Y += 13
                            inicio += caracteresPorLinea
                        End While

                        e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 200, Y, derecha)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                        Y += 13

                        articulos = articulos + cantidadpro

                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Else
                Dim conta As Integer = 0
                Dim contband As Integer = 0
                Dim comensal As String = ""

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "SELECT DISTINCT comensal FROM VtaImpresion"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then

                        comensal = rd4(0).ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, Comensal,Propina FROM VtaImpresion where Folio=" & folio & " and Comensal='" & comensal & "' Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                        rd3 = cmd3.ExecuteReader

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * from VtaImpresion where comensal='" & comensal & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            conta = conta + 1
                        Loop
                        rd1.Close()

                        Do While rd3.Read
                            If rd3.HasRows Then
                                conta = conta
                                contband = contband + 1

                                If comen_sal <> rd3("Comensal").ToString Then
                                    e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(rd3("Comensal").ToString, fuente_b, Brushes.Black, 120, Y)
                                    TOTALCOM = 0
                                End If
                                Y += 20

                                nombrepro = rd3("Nombre").ToString
                                preciopro = rd3("Precio").ToString
                                importepro = rd3("Tot").ToString
                                cantidadpro = rd3("Cant").ToString
                                propina = rd3("Propina").ToString

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "SELECT IVA FROM Productos where Codigo='" & rd3("Codigo").ToString & "'"
                                rd1 = cmd1.ExecuteReader
                                Do While rd1.Read
                                    If rd1.HasRows Then
                                        ope = importepro / 1.16
                                        TotalIVA = TotalIVA + CDec(ope) * CDec(rd1(0).ToString)
                                        TotalIVA = FormatNumber(TotalIVA, 2)
                                    End If
                                Loop
                                rd1.Close()

                                e.Graphics.DrawString(FormatNumber(cantidadpro, 2), New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 40
                                Dim texto As String = nombrepro
                                Dim inicio As Integer = 0
                                Dim longitudTexto As Integer = texto.Length

                                While inicio < longitudTexto
                                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 40, Y)
                                    Y += 13
                                    inicio += caracteresPorLinea
                                End While

                                e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 195, Y, derecha)
                                e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                                Y += 13

                                articulos = articulos + cantidadpro
                                TOTALCOM = CDec(TOTALCOM) + CDec(importepro)

                                If contband < conta Then

                                    comen_sal = rd3("Comensal").ToString
                                ElseIf contband = conta Then
                                    comen_sal = ""
                                End If

                                If comen_sal <> rd3("Comensal").ToString Then
                                    If numdec <> "" Then
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    Else
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    End If
                                    Y += 20
                                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                                    Y += 15

                                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                                    Y += 16
                                End If
                                comen_sal = rd3("Comensal").ToString
                                totalventa = totalventa + importepro

                            End If
                        Loop
                        rd3.Close()

                    End If
                Loop
                rd4.Close()

            End If
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 25

            If TotalIVA <> 0 Then

                If DesglosaIVA = False Then

                    e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 30

                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtTotal.Text), 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 20

            Else

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                If SinNumComensal = 1 Then
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(totalventa + CDec(propina) - txtDescuento.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                    Y += 20
                Else
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(totalventa + CDec(propina) - txtDescuento.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            If CDec(txtDescuento.Text) <> 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            For deku As Integer = 0 To grdPagos.Rows.Count - 1

                Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString


                If formapago = "EFECTIVO" Then
                Else
                    If formapago = "MONEDERO" Then

                        e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                        Y += 20

                        e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 150, Y)
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

            If Mid(cantidadLetra, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(cantidadLetra, 39, 70) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 39, 70), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(Pie1, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(Pie1, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 14
            End If

            If Mid(Pie1, 39, 78) <> "" Then
                e.Graphics.DrawString(Mid(Pie1, 39, 78), fuente_r, Brushes.Black, 1, Y)
                Y += 14
            End If
            Y += 2

            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 5, Y)
            e.Graphics.DrawString("Cajero: " & lblusuario2.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 135, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 135, Y, sc)
            Else

            End If

            e.HasMorePages = False

            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        End Try

    End Sub

    Private Sub PVentaMapeo58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PVentaMapeo58.PrintPage
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

        Dim nombrepro As String = ""
        Dim preciopro As Double = 0
        Dim importepro As Double = 0
        Dim cantidadpro As Double = 0
        Dim propina As Double = 0
        Dim usuario As String = ""

        Dim ope As Double = 0
        Dim TotalIVA As Double = 0
        Dim articulos As Integer = 0
        Dim acumuladocortesia As Double = 0

        Dim comen_sal As String = ""
        Dim TOTALCOM As Double = 0
        Dim totalventa As Double = 0
        Dim numdec As String = ""

        Dim Pie1 As String = ""

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()
        cnn3.Close() : cnn3.Open()
        cnn4.Close() : cnn4.Open()

        cmd2 = cnn2.CreateCommand
        cmd2.CommandText = "select CodFactura FROM Ventas WHERE Folio=" & folio
        rd2 = cmd2.ExecuteReader
        If rd2.HasRows Then
            If rd2.Read Then
                foliofactura = rd2(0).ToString
            End If
        End If
        rd2.Close()


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


            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "select * from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie1 = rd2("Pie3").ToString
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

            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 11
            e.Graphics.DrawString("N O T A   D E   V E N T A", fuente_b, Brushes.Black, 90, Y, sc)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("Mesa: " & lblmesa.Text, fuente_r, Brushes.Black, 1, Y)

            e.Graphics.DrawString("Folio: " & folio, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 23
            e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 11
            e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
            Y += 15

            e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 30, Y)
            e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 133, Y, derecha)
            e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 20
            traernumerocomensal()

            If SinNumComensal = 1 Then

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "Select Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, comensal,Propina from VtaImpresion where Folio=" & folio & " Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then
                        nombrepro = rd4("Nombre").ToString
                        preciopro = rd4("Precio").ToString
                        importepro = rd4("Tot").ToString
                        cantidadpro = rd4("Cant").ToString
                        propina = rd4("Propina").ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT IVA FROM Productos WHERE Codigo='" & rd4("Codigo").ToString & "'"
                        rd3 = cmd3.ExecuteReader
                        Do While rd3.Read
                            If rd3.HasRows Then
                                ope = importepro / 1.16
                                TotalIVA = TotalIVA + CDec(ope) * CDec(rd3(0).ToString)
                            End If
                        Loop
                        rd3.Close()

                        acumuladocortesia = acumuladocortesia + (preciopro * cantidadpro)

                        e.Graphics.DrawString(cantidadpro, fuente_p, Brushes.Black, 1, Y)


                        Dim caracteresPorLinea As Integer = 25
                        Dim texto As String = nombrepro
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                            Y += 15
                            inicio += caracteresPorLinea
                        End While


                        e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 133, Y, derecha)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                        Y += 13

                        articulos = articulos + cantidadpro

                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 11
            Else
                Dim conta As Integer = 0
                Dim contband As Integer = 0
                Dim comensal As String = ""

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "SELECT DISTINCT comensal FROM VtaImpresion"
                rd4 = cmd4.ExecuteReader
                Do While rd4.Read
                    If rd4.HasRows Then

                        comensal = rd4(0).ToString

                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText = "SELECT Codigo,Nombre,UVenta,SUM(Cantidad)as Cant ,Precio, Sum(Total)as Tot, Comensal,Propina FROM VtaImpresion where Folio=" & folio & " and Comensal='" & comensal & "' Group by Comensal, Codigo,Nombre,UVenta,Precio,Propina Order By Comensal"
                        rd3 = cmd3.ExecuteReader

                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT * from VtaImpresion where comensal='" & comensal & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            conta = conta + 1
                        Loop
                        rd1.Close()

                        Do While rd3.Read
                            If rd3.HasRows Then
                                conta = conta
                                contband = contband + 1

                                If comen_sal <> rd3("Comensal").ToString Then
                                    e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(rd3("Comensal").ToString, fuente_b, Brushes.Black, 150, Y)
                                    TOTALCOM = 0
                                End If
                                Y += 20

                                nombrepro = rd3("Nombre").ToString
                                preciopro = rd3("Precio").ToString
                                importepro = rd3("Tot").ToString
                                cantidadpro = rd3("Cant").ToString
                                propina = rd3("Propina").ToString

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "SELECT IVA FROM Productos where Codigo='" & rd3("Codigo").ToString & "'"
                                rd1 = cmd1.ExecuteReader
                                Do While rd1.Read
                                    If rd1.HasRows Then
                                        ope = importepro / 1.16
                                        TotalIVA = TotalIVA + CDec(ope) * CDec(rd1(0).ToString)
                                        TotalIVA = FormatNumber(TotalIVA, 2)
                                    End If
                                Loop
                                rd1.Close()

                                e.Graphics.DrawString(cantidadpro, fuente_p, Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 25
                                Dim texto As String = nombrepro
                                Dim inicio As Integer = 0
                                Dim longitudTexto As Integer = texto.Length

                                While inicio < longitudTexto
                                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                    e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 25, Y)
                                    Y += 15
                                    inicio += caracteresPorLinea
                                End While

                                e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 133, Y, derecha)
                                e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 180, Y, derecha)
                                Y += 13

                                articulos = articulos + cantidadpro
                                TOTALCOM = CDec(TOTALCOM) + CDec(importepro)

                                If contband < conta Then

                                    comen_sal = rd3("Comensal").ToString
                                ElseIf contband = conta Then
                                    comen_sal = ""
                                End If

                                If comen_sal <> rd3("Comensal").ToString Then
                                    If numdec <> "" Then
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    Else
                                        TOTALCOM = FormatNumber(TOTALCOM, 2)
                                    End If
                                    Y += 20
                                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                                    Y += 15

                                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                                    Y += 16
                                End If
                                comen_sal = rd3("Comensal").ToString
                                totalventa = totalventa + importepro

                            End If
                        Loop
                        rd3.Close()

                    End If
                Loop
                rd4.Close()

            End If
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 15

            If TotalIVA <> 0 Then

                If DesglosaIVA = False Then

                    e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                e.Graphics.DrawString("TOTAL A PAGAR", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtTotal.Text), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15

            Else

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                If SinNumComensal = 1 Then
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(totalventa + CDec(propina) - txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                Else
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(totalventa + CDec(propina) - txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            If CDec(txtDescuento.Text) <> 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            For deku As Integer = 0 To grdPagos.Rows.Count - 1

                Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
                Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
                Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
                Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString

                If formapago = "EFECTIVO" Then
                Else
                    If formapago = "MONEDERO" Then

                        e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                        Y += 15

                        e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 100, Y)
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
                End If


            Next

            If CDec(txtResta.Text) <> 0 Then
                e.Graphics.DrawString("RESTA: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtResta.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            If CDec(txtCambio.Text) <> 0 Then
                e.Graphics.DrawString("CAMBIO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtCambio.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 10
            End If
            Y += 10

            Dim cantidadLetra As String = ""
            cantidadLetra = convLetras(txtTotal.Text)

            If Mid(cantidadLetra, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(cantidadLetra, 39, 70) <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 39, 70), fuente_r, Brushes.Black, 1, Y)
                Y += 15
            End If

            If Mid(Pie1, 1, 38) <> "" Then
                e.Graphics.DrawString(Mid(Pie1, 1, 38), fuente_r, Brushes.Black, 1, Y)
                Y += 14
            End If

            If Mid(Pie1, 39, 78) <> "" Then
                e.Graphics.DrawString(Mid(Pie1, 39, 78), fuente_r, Brushes.Black, 1, Y)
                Y += 14
            End If
            Y += 2

            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 5, Y)
            e.Graphics.DrawString("Cajero: " & lblusuario2.Text, fuente_r, Brushes.Black, 180, Y, derecha)
            Y += 15

            If facLinea = 1 Then
                e.Graphics.DrawString("Folio para Facturar", fuente_b, Brushes.Black, 90, Y, sc)
                Y += 15
                e.Graphics.DrawString(foliofactura, fuente_b, Brushes.Black, 90, Y, sc)
            Else

            End If

            e.HasMorePages = False

            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        End Try
    End Sub

    Private Sub txtPropina_Click(sender As Object, e As EventArgs) Handles txtPropina.Click
        focomapeo = 3
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            btnIntro.Focus.Equals(True)
        End If
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "1"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "1"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)

            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "1"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "1"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "2"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "2"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "2"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "2"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "3"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "3"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "3"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "3"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "4"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "4"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "4"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "4"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "5"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "5"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "5"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "5"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "6"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "6"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "6"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "6"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "7"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "7"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "7"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "7"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "8"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "8"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "8"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "8"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "9"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "9"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "9"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "9"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "0"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "0"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "0"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "0"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn20_Click(sender As Object, e As EventArgs) Handles btn20.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "20"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "20"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "20"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "20"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn50_Click(sender As Object, e As EventArgs) Handles btn50.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "50"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "50"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "50"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "50"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "100"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "100"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "100"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "100"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn200_Click(sender As Object, e As EventArgs) Handles btn200.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "200"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "200"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "200"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "200"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn500_Click(sender As Object, e As EventArgs) Handles btn500.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "500"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "500"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "500"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "500"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn1000_Click(sender As Object, e As EventArgs) Handles btn1000.Click
        Select Case focomapeo
            Case Is = 1
                Dim monto As Double = IIf(txtEfectivo.Text = "", "0.00", txtEfectivo.Text)
                Dim nuevo = monto + "1000"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "1000"
                txtEfectivo.Text = FormatNumber(nuevo, 2)
                txtEfectivo.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "1000"
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "1000"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click
        frmDividirCuenta.mesa = lblmesa.Text
        frmDividirCuenta.Show()
    End Sub

    Private Sub txtPorcentaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtPorcentaje.Text) Then

                Dim VarRes As Double = 0
                Dim VRe As String = ""
                Dim Vre1 As String = ""
                Dim VarPropa As Double = 0
                Dim MyOpe As Double = 0
                Dim restapago As Double = 0
                Dim tmpCam As Double = 0
                Dim TotalPagar As Double = 0

                Dim efectivo As Double = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)
                Dim pagos As Double = IIf(txtpagos.Text = 0, 0, txtpagos.Text)
                Dim total As Double = IIf(txtTotal.Text = 0, 0, txtTotal.Text)
                Dim subtotal As Double = IIf(txtSubtotalmapeo.Text, 0, txtSubtotalmapeo.Text)

                Dim saldo As Double = txtTotal.Text
                Dim porcentaje As Double = (txtPorcentaje.Text / 100)
                Dim porcentajetot As Double = CDbl(saldo) * CDbl(porcentaje)
                montopropina = txtDescuento.Text

                txtDescuento.Text = FormatNumber(porcentajetot, 2)

                If txtDescuento.Text = "0.00" Then
                    MyOpe = CDbl(subtotalmapeo) + (CDbl(efectivo) + CDbl(pagos) + CDec(txtPropina.Text))
                    txtTotal.Text = MyOpe
                Else
                    MyOpe = (CDec(subtotalmapeo) + +CDbl(propina)) - (CDbl(efectivo) + CDbl(pagos)) - CDbl(txtDescuento.Text)
                    txtTotal.Text = MyOpe
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
                txtTotal.Text = FormatNumber(txtTotal.Text, 2)
                tmpCam = 0

                If CDec(tmpCam) >= 0 Then
                    txtCambio.Text = FormatNumber(tmpCam, 2)

                Else
                    txtCambio.Text = "0.00"

                End If

                txtEfectivo.Focus.Equals(True)



            End If
        End If
    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As Object, e As EventArgs) Handles txtPorcentaje.TextChanged

        If Not IsNumeric(txtPorcentaje.Text) Then txtPorcentaje.Text = "0.00" : Exit Sub
        If Strings.Left(txtPorcentaje.Text, 1) = "," Or Strings.Left(txtPorcentaje.Text, 1) = "." Then Exit Sub


    End Sub

    Private Sub txtPorcentaje_Click(sender As Object, e As EventArgs) Handles txtPorcentaje.Click
        txtPorcentaje.SelectionStart = 0
        txtPorcentaje.SelectionLength = Len(txtPorcentaje.Text)
        focomapeo = 29
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class