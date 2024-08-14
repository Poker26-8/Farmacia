Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Xml
Imports Gma.QrCodeNet.Encoding.Windows.Forms
Public Class frmNuevoPagar

    ''' variablesm para terminal bancaria
    Public valorxd As Integer = 0
    Public SiPago As Integer = 0
    Public hayTerminal As Integer = 0
    Public validaTarjeta As Double = 0

    Dim numTerminal As String = ""
    Dim numClave As String = ""
    Dim URLsolicitud As String = ""
    Dim URLresultado As String = ""

    Public subtotalmapeo As Double = 0
    Public focomapeo As Integer = 0
    Public contraseñamesero As String = ""
    Public COMENSALES As String = ""

    Dim idborrado As Integer = 0

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
    Dim montopropina As Double = 0
    Dim myope As Double = 0

    Dim idusuario As Integer = 0
    Dim estadousuario As Integer = 0
    Dim SinNumComensal As Integer = 0

    Dim folio As String = ""

    Dim ideliminar As Integer = 0
    Dim comandaeliminar As Integer = 0
    Dim codigoeliminar As String = ""
    Dim descripcioneliminar As String = ""
    Dim unidadeliminar As String = ""
    Dim cantidadeliminar As Double = 0
    Dim precioeliminar As Double = 0
    Dim comensaleliminar As String = ""

    Public cadenafact As String = ""
    Dim cortesia_venta As Integer = 0
    Dim NewPos As String = ""

    'Dim tim As New Timer()
    Dim tim As New System.Windows.Forms.Timer()

    Dim sumacomandas As Double = 0
    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        tim.Stop()

        Try
            grdComanda.Rows.Clear()
            sumacomandas = 0
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand

            If cboComensal.Text <> "" Then
                cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "' AND Comensal='" & cboComensal.Text & "'"

            End If

            If cboComanda.Text <> "" Then
                cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "' AND Id=" & cboComanda.Text

            End If

            If cboComanda.Text = "" And cboComensal.Text = "" Then
                cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            End If


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

                    Dim PU As Double = CDbl(vertotal) / (1 + IvaDSC(vercodigo))
                    Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(vercodigo)))
                    Dim ieps As Double = ProdsIEPS(vercodigo)

                    IvaIeps = IIf(IvaIeps = 0, 0, IvaIeps)
                    ieps = IIf(ieps = 0, 0, ieps)

                    grdComanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, FormatNumber(verprecio, 2), FormatNumber(vertotal, 2), vercomensal, vermesero, verid, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2))

                    sumacomandas = sumacomandas + vertotal
                End If
            Loop
            rd2.Close()
            cnn2.Close()
            txtSubtotalmapeo.Text = FormatNumber(sumacomandas, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try

        tim.Start()
    End Sub
    Private Sub frmNuevoPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Terminal,Clave,Solicitud,Resultado from DatosProsepago"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                hayTerminal = 1
                numTerminal = rd1("Terminal").ToString
                numClave = rd1("Clave").ToString
                URLsolicitud = rd1("Solicitud").ToString
                URLresultado = rd1("Resultado").ToString
            Else
                hayTerminal = 0
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        grdComanda.Rows.Clear()
        TFolio.Start()

        tim.Interval = 5000
        AddHandler tim.Tick, AddressOf Timer_Tick
        tim.Start()

        Try
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id,CUsuario FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id,CUsuario FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
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

                    Dim PU As Double = CDbl(vertotal) / (1 + IvaDSC(vercodigo))
                    Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(vercodigo)))
                    Dim ieps As Double = ProdsIEPS(vercodigo)

                    IvaIeps = IIf(IvaIeps = 0, 0, IvaIeps)
                    ieps = IIf(ieps = 0, 0, ieps)

                    grdComanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, FormatNumber(verprecio, 2), FormatNumber(vertotal, 2), vercomensal, vermesero, verid, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2))

                    Montocobromapeo = Montocobromapeo
                End If
            Loop
            rd2.Close()
            cnn2.Close()

            txtSubtotalmapeo.Text = FormatNumber(Montocobromapeo, 2)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn2.Close()
        End Try
    End Sub

    Public Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IVA from Productos where Codigo='" & cod & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IvaDSC = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                IvaDSC = 0
            End If
            rd3.Close()
            cnn3.Close()
            Return IvaDSC
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function

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

        percent_propina = DatosRecarga("Propina")
        propina = CDec(txtSubtotalmapeo.Text) * (percent_propina / 100)
        txtPropina.Text = FormatNumber(propina, 2)

        txtTotal.Text = CDec(txtSubtotalmapeo.Text)
        txtTotal.Text = FormatNumber(txtTotal.Text, 2)

        txttotalpropina.Text = CDec(txtTotal.Text) + CDec(txtPropina.Text)
        txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)

        lblTotal.Text = CDec(txtTotal.Text) + CDec(txtPropina.Text)
        lblTotal.Text = FormatNumber(lblTotal.Text, 2)

        txtResta.Text = txttotalpropina.Text
        txtResta.Text = FormatNumber(txtResta.Text, 2)
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged

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

        If idborrado = 0 Then
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0.00, txtpagos.Text)) - txtPropina.Text)
        Else
            myope = txttotalpropina.Text
        End If


        If myope <0 Then
            txtCambio.Text= FormatNumber(-myope, 2)
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
            'myope = Montocobromapeo - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(txtpagos.Text) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)) + CDbl(txtPropina.Text))
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text)
        Else
            'myope = Montocobromapeo - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0.00, txtpagos.Text)) + CDbl(IIf(txtDescuento.Text = "", 0.00, txtDescuento.Text)) + CDbl(IIf(txtPropina.Text = "", 0, txtPropina.Text)))
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text)
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


            Dim subtotalventa As Double = IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)
            Dim efectivoventa As Double = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)
            Dim pagosventa As Double = IIf(txtpagos.Text = 0, 0, txtpagos.Text)
            Dim propinaventa As Double = IIf(txtPropina.Text = 0, 0, txtPropina.Text)
            Dim totalventa As Double = IIf(txtTotal.Text = 0, 0, txtTotal.Text)

            Dim sumapagos As Double = CDbl(efectivoventa) + CDbl(pagosventa)

            If txtPropina.Text = "0" Then

                MyOpe = CDec(CDec(subtotalventa) - (sumapagos - CDec(VarPropa)) - CDbl(txtDescuento.Text))
            Else

                If txtDescuento.Text = "0.00" Then
                    MyOpe = CDec(subtotalventa + propinaventa) - sumapagos
                Else
                    MyOpe = CDec(CDec(subtotalventa) - (sumapagos - CDec(propinaventa)) - CDbl(txtDescuento.Text))
                End If

            End If

            If MyOpe = 0 Then
                MyOpe = 0
            End If


            If MyOpe < 0 Then
                txtResta.Text = "0.00"

                txtCambio.Text = -MyOpe
            Else
                txtResta.Text = MyOpe
                txtCambio.Text = "0.00"
            End If

            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)

            If CDec(txtResta.Text) = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) And CDec(txtPropina.Text) = 0 Then

                txttotalpropina.Text = CDec(totalventa) + CDec(txtPropina.Text)
                txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)

                lblTotal.Text = CDec(subtotalventa)
                lblTotal.Text = FormatNumber(txtTotal.Text, 2)
            Else


                txttotalpropina.Text = CDec(totalventa) + CDec(txtPropina.Text)
                txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)

                lblTotal.Text = CDec(totalventa) + CDbl(txtPropina.Text)
                lblTotal.Text = FormatNumber(lblTotal.Text, 2)

                txtEfectivo.Text = "0.00"
                txtpagos.Text = "0.00"
                grdPagos.Rows.Clear()
            End If
            txtEfectivo.Focus.Equals(True)
            focomapeo = 1
        End If
    End Sub

    Private Sub btnlimpiar_Click(sender As Object, e As EventArgs) Handles btnlimpiar.Click

        idborrado = 1
        txtSubtotalmapeo.Text = FormatNumber(subtotalmapeo, 2)
        txtTotal.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        txttotalpropina.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        lblTotal.Text = FormatNumber(txtTotal.Text, 2)
        txtResta.Text = FormatNumber(txttotalpropina.Text, 2)

        txtEfectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        txtDescuento.Text = "0.00"
        txtPorcentaje.Text = "0"
        txtCambio.Text = "0.00"
        grdPagos.Rows.Clear()
        txtPropina.Text = "0.00"
        txtmonto.Text = "0.00"

        percent_propina = DatosRecarga("Propina")

        If percent_propina > 0 Then
            propina = CDec(txtSubtotalmapeo.Text) * (percent_propina / 100)
            txtPropina.Text = FormatNumber(propina, 2)
            txttotalpropina.Text = CDbl(txtTotal.Text) + CDbl(txtPropina.Text)
            txtPropina.Text = FormatNumber(txtPropina.Text, 2)
            txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)
            txtResta.Text = FormatNumber(txttotalpropina.Text, 2)
            lblTotal.Text = FormatNumber(txttotalpropina.Text, 2)
        End If


        cboComensal.Text = ""
        cboComanda.Text = ""
        grdComanda.Rows.Clear()
        traercomanda()
    End Sub

    Private Sub txtpagos_TextChanged(sender As Object, e As EventArgs) Handles txtpagos.TextChanged

        Dim Resta As Double = 0

        Try
            Resta = CDec(IIf(txtpagos.Text = "", "0", txtpagos.Text)) + CDec(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)) - CDec(IIf(txtTotal.Text = "", "0", txtTotal.Text))
            Resta = FormatNumber(Resta, 2)

            myope = CDec(IIf(txttotalpropina.Text = "", "0", txttotalpropina.Text)) - (CDec(IIf(txtpagos.Text = "", "0", txtpagos.Text)) + CDec(IIf(txtEfectivo.Text = "", "0", txtEfectivo.Text)))

            'If myope < 0 Then
            '    Resta = -myope
            '    txtResta.Text = "0.00"
            'Else
            '    txtResta.Text = myope
            '    Resta = "0.00"
            ' End If

            If myope < 0 Then
                txtCambio.Text = FormatNumber(-myope, 2)
                txtResta.Text = "0.00"
            Else
                txtResta.Text = FormatNumber(myope, 2)
                txtCambio.Text = "0.00"
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
            btnagregarpago.Focus.Equals(True)
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

        totalpagos = txtpagos.Text + monto
        txtpagos.Text = FormatNumber(totalpagos, 2)

        Dim totalventa As Double = 0
        Dim resta As Double = 0
        Dim efectivo As Double = 0


        totalventa = lblTotal.Text
        efectivo = txtEfectivo.Text
        resta = CDbl(totalventa) - CDbl(efectivo)


        If CDbl(txtpagos.Text) > CDec(resta) Then
            grdPagos.Rows.Clear()
            txtpagos.Text = "0.00"
            ' txtResta.Text = FormatNumber(resta, 2)
            MsgBox("El monto a revasado el total de la venta", vbInformation + vbOKOnly, titulocentral)
        Else
            validaMontosTarjeta()

            limpiarforma()
        End If





    End Sub
    Public Sub validaMontosTarjeta()
        Try
            Dim cuantopaga As Double = 0
            For xxx As Integer = 0 To grdPagos.Rows.Count - 1
                Dim primer As String = grdPagos.Rows(xxx).Cells(0).Value.ToString
                If primer.ToUpper().Contains("TARJETA") Then
                    cuantopaga = cuantopaga + CDec(grdPagos.Rows(xxx).Cells(3).Value)
                End If
            Next
            validaTarjeta = cuantopaga
            'MsgBox("La suma de pagos con tarjeta es: " & cuantopaga)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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
            grdComanda.Rows.Clear()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Total,Codigo,IDC,Nombre,UVenta,Cantidad,Precio,Comensal,CUsuario,Id FROM Comandas WHERE Id='" & cboComanda.Text & "' AND NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    Dim PU As Double = CDbl(rd2("Total").ToString) / (1 + IvaDSC(rd2("Codigo").ToString))
                    Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(rd2("Codigo").ToString)))
                    Dim ieps As Double = ProdsIEPS(rd2("Codigo").ToString)

                    IvaIeps = IIf(IvaIeps = 0, 0, IvaIeps)
                    ieps = IIf(ieps = 0, 0, ieps)

                    grdComanda.Rows.Add(rd2("IDC").ToString,
                                       rd2("Codigo").ToString,
                                       rd2("Nombre").ToString,
                                       rd2("UVenta").ToString,
                                       FormatNumber(rd2("Cantidad").ToString, 2),
                                       FormatNumber(rd2("Precio").ToString, 2),
                                       FormatNumber(rd2("Total").ToString, 2),
                                       rd2("Comensal").ToString,
                                       rd2("CUsuario").ToString,
                                       rd2("Id").ToString,
                                       FormatNumber(IvaIeps, 2),
                                       FormatNumber(ieps, 2))

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
            grdComanda.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE Comensal='" & cboComensal.Text & "' AND NMESA='" & lblmesa.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    grdComanda.Rows.Add(rd1("IDC").ToString,
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
            cmd2.CommandText = "SELECT IDC,Codigo,Nombre,UVenta,Cantidad,Precio,Total,Comensal,CUsuario,Id FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
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
                    grdComanda.Rows.Add(vercomanda, vercodigo, verdescripcion, verunidad, vercantidad, verprecio, vertotal, vercomensal, vermesero, verid)
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

    Async Function EnviarSolicitudAPI() As Task

        ' Label1.Visible = True
        ' Valores a enviar a la API
        Dim TipoPlan As String = "00"
        Dim Terminal As String = numTerminal
        Dim Importe As String = validaTarjeta
        Dim pv As String = "DELSSCOM"
        Dim nombre As String = cboComensal.Text
        Dim concepto As String = "Venta"
        Dim referencia As String = lblfolio.Text & FormatDateTime(Date.Now, DateFormat.ShortDate) & FormatDateTime(Date.Now, DateFormat.ShortTime) ' se recomienda poner el folio de la venta y la fecha, asi me dijo el wey de procepago, dice que no se debe de repetir

        Dim correo As String = ""
        Dim membresia As String = "false"
        Dim clave As String = numClave

        Dim cadenatexto As String = TipoPlan & Terminal & Importe & nombre & concepto & referencia & correo & clave
        ' MsgBox(cadenatexto)
        Dim CadenaEncriptada As String = CalculateSHA1(cadenatexto)

        ' URL de la API
        Dim url As String = URLsolicitud

        ' Construye la solicitud HTTP
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' datos a enviar con metodo post
        Dim postData As String = $"&tipoPlan={TipoPlan}&terminal={Terminal}&importe={Importe}&nombre={nombre}&concepto={concepto}&referencia={referencia}&correo={correo}&pv={pv}&CadenaEncriptada={CadenaEncriptada}"
        'MsgBox(postData)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = byteArray.Length

        Try
            ' Aqui se activa el pago en la terminal
            Using dataStream As Stream = Await request.GetRequestStreamAsync()
                Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
            End Using


            ' Envía la solicitud y procesa la respuesta

            Dim response As WebResponse = Await request.GetResponseAsync()

            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = Await reader.ReadToEndAsync()
                ' MessageBox.Show("Respuesta de la API: " & responseFromServer)
                valorxd = responseFromServer
                'Thread.Sleep(4000)
                EnviarSolicitudAPI2()
            End Using
        Catch ex As WebException
            MessageBox.Show("Error en la solicitud: " & ex.Message)
        End Try
    End Function

    Private Function CalculateSHA1(input As String) As String
        Try
            Dim sha1Obj As New System.Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(input)
            bytesToHash = sha1Obj.ComputeHash(bytesToHash)
            Dim strResult As String = ""
            For Each b As Byte In bytesToHash
                strResult += b.ToString("x2")
            Next
            Return strResult
        Catch ex As Exception
            MessageBox.Show("Funcion getSHA1Hash: | " & ex.ToString)
        End Try

    End Function


    Async Function EnviarSolicitudAPI2() As Task
        ' Valores a enviar a la API
        Dim idsolicitud As String = valorxd
        Dim clave As String = numClave

        ' Genera el hash SHA-1 de los valores
        Dim CadenaEncriptada As String = CalculateSHA1(idsolicitud & clave)

        ' URL de la API

        Dim url As String = URLresultado

        ' Construye la solicitud HTTP
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Construye los datos a enviar en la solicitud
        Dim postData As String = $"&idsolicitud={idsolicitud}&cadenaEncriptada={CadenaEncriptada}"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = byteArray.Length

        ' Escribe los datos en el cuerpo de la solicitud

        Using dataStream As Stream = Await request.GetRequestStreamAsync()
            Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
        End Using


        ' Envía la solicitud y procesa la respuesta
        Try
            Dim response As WebResponse = Await request.GetResponseAsync()
            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim responseFromServer As String = Await reader.ReadToEndAsync()

                If responseFromServer = "901" Then
                    EnviarSolicitudAPI2()
                End If

                Dim xmlDoc As New XmlDocument()
                xmlDoc.LoadXml(responseFromServer)
                Dim descripcionValue2 As String = ""
                ' Obtener el valor de la etiqueta <descripcion>
                Dim descripcionValue As String = xmlDoc.SelectSingleNode("/PVresultado/descripcion").InnerText
                If descripcionValue = "0" Then
                Else
                    descripcionValue2 = xmlDoc.SelectSingleNode("/PVresultado/causaDenegada").InnerText
                End If

                If descripcionValue = "0" Then
                    MsgBox("El proceso de la transacción no ah sido completado", vbCritical + vbOKOnly, "Operación Incomppleta")
                    SiPago = 0
                ElseIf descripcionValue = "1" Then
                    MsgBox("La operación es rechazada por el banco o cancelada por el usuario", vbCritical + vbOKOnly, "Operación Denegada")
                    SiPago = 0
                ElseIf descripcionValue = "2" Then
                    If descripcionValue2 = "Denegada, Saldo insuficiente" Then
                        MsgBox("Tarjeta Denegada, Saldo insuficiente", vbCritical + vbOKOnly, "Operación Fallida")
                        SiPago = 0
                    Else
                        SiPago = 1
                        btnIntro.PerformClick()
                    End If
                ElseIf descripcionValue = "3" Then
                    MsgBox("Ya se llevo a cabo el proceso por parte de Pprosepago", vbInformation + vbOKOnly, "Operación Liquidada")
                    SiPago = 0
                End If

                'MessageBox.Show("Respuesta de la API: " & responseFromServer)
            End Using
        Catch ex As WebException
            MessageBox.Show("Error en la solicitud: " & ex.Message)
        End Try
    End Function

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

        Dim idemp As Integer = 0

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT IdEmpleado FROM usuarios WHERE Alias='" & lblusuario2.Text & "'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                idemp = rd1(0).ToString

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT CobrarM FROM permisosm WHERE IdEmpleado=" & idemp
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2(0).ToString = 1 Then
                        Else
                            MsgBox("No cuentas con permiso para cerrar la cuenta", vbInformation + vbOKOnly, titulorestaurante)
                            Exit Sub
                        End If
                    End If
                Else
                    MsgBox("No cuentas con permiso para cerrar la cuenta", vbInformation + vbOKOnly, titulorestaurante)
                    Exit Sub
                End If
                rd2.Close()

            End If
        Else
            MsgBox("No tienes asignados permisos contacta a tu administrador", vbInformation + vbOKOnly, titulorestaurante)
            Exit Sub
        End If
        rd1.Close()
        cnn2.Close()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "DELETE FROM VtaImpresion"
        cmd1.ExecuteNonQuery()
        cnn1.Close()
        btnIntro.Enabled = True

        Dim efectivocom As Double = 0
        efectivocom = txtEfectivo.Text

        Dim pagoscom As Double = 0
        pagoscom = txtpagos.Text

        Dim descuentocom As Double = 0
        descuentocom = txtDescuento.Text

        Dim cambiocom As Double = 0
        cambiocom = txtCambio.Text

        mypago = CDec(txtEfectivo.Text) + CDec(txtpagos.Text) - CDec(txtCambio.Text)

        If mypago < CDec(txtTotal.Text) Then
            MsgBox("Debe cerrar la cuenta!.", vbInformation + vbOKOnly, titulomensajes)
            Exit Sub
        End If

        If txtMonedero.Text <> "" Then
            Dim sal_monedero As Double = 0
            Dim tipo_mone As Integer = 0
            Dim porcentaje_mone As Double = 0

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT NumPart,NotasCred FROM formatos WHERE Facturas='Porc_Mone'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    tipo_mone = rd2("NumPart").ToString()
                    porcentaje_mone = IIf(rd2("NotasCred").ToString() = "", 0, rd2("NotasCred").ToString())
                End If
            End If

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Saldo FROM Monedero WHERE Barras='" & txtMonedero.Text & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    SALDOMONEDERO = rd2("Saldo").ToString
                End If
            End If
            rd2.Close()

            If validaTarjeta = 0 Then
                If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub
            Else
                If SiPago = 0 Then
                    If MsgBox("¿Deseas guardar los datos de esta venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub
                End If
            End If

            'Comienza proceso de guardado de la venta
            If validaTarjeta <> 0 Then
                If hayTerminal = 0 Then
                    GoTo kakaxd
                End If
            End If

            If SiPago = 0 Then
                If validaTarjeta <> 0 Then
                    EnviarSolicitudAPI()
                    Exit Sub
                ElseIf SiPago = 1 Then
                    GoTo kakaxd
                End If
            Else
                GoTo kakaxd
            End If



kakaxd:

            Dim porc_mone As Double = 0
            Dim precio_prod As Double = 0
            Dim cantid_prod As Double = 0
            Dim nvo_saldo As Double = 0
            Dim porcentaje As Double = 0
            Dim ope As Double = 0

            Dim total_venta As Double = 0
            Dim total_bono As Double = 0

            'Por venta
            If tipo_mone = 1 Then
                total_venta = txtTotal.Text
                total_bono = (porcentaje_mone * total_venta) / 100

                nvo_saldo = total_bono + SALDOMONEDERO
            End If

            'Por producto
            If tipo_mone = 0 Then
                For denji As Integer = 0 To grdComanda.Rows.Count - 1
                    porc_mone = grdComanda(14, denji).Value
                    precio_prod = grdComanda(5, denji).Value
                    cantid_prod = grdComanda(4, denji).Value

                    total_bono = (porc_mone * precio_prod) / 100
                    ope = ope + (total_bono * cantid_prod)
                Next
                nvo_saldo = ope + SALDOMONEDERO
            End If

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText =
                "update Monedero set Saldo=" & nvo_saldo & " where Barras='" & txtMonedero.Text & "'"
            cmd2.ExecuteNonQuery()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "insert into MovMonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) values('" & txtMonedero.Text & "','Venta'," & ope & "," & total_bono & "," & nvo_saldo & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MyFolio & ")"
            cmd2.ExecuteNonQuery()
            cnn2.Close()

        End If

        Dim myidcliente As Integer = 0

        'If MsgBox("¿Desea guardar los datos de esta venta?", vbQuestion + vbYesNo + vbDefaultButton1) = vbNo Then
        '    Exit Sub
        'End If

        Dim Subtotales1 As Double = 0
        Dim SubtotalVenta As Double = 0
        Dim totcomi As Double = 0
        Dim CODIGO As String = ""
        Dim CANTI As Double = 0

        Cuenta = CDec(efectivocom) + CDec(pagoscom) - CDec(txtCambio.Text)
        Cuenta = Cuenta - CDbl(txtPropina.Text)

        If CDec(txtTotal.Text) <= CDec(Cuenta) Then
            Cuenta = txtTotal.Text
            txtResta.Text = 0
        End If

        Cuenta = FormatNumber(Cuenta, 2)

        Dim ivaproducto As Double = 0
        Dim restaiva As Double = 0

        For zi As Integer = 0 To grdComanda.Rows.Count - 1

            CODIGO = grdComanda.Rows(zi).Cells(1).Value.ToString
            CANTI = grdComanda.Rows(zi).Cells(4).Value.ToString

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT Comision,IVA FROM Productos WHERE Codigo='" & CODIGO & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    totcomi = totcomi + CDec(CDec(CANTI) * CDec(rd2("Comision").ToString))
                    If rd2("IVA").ToString > 0 Then
                        Subtotales1 = grdComanda.Rows(zi).Cells(6).Value.ToString
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
        Dim opee As Double = 0
        Dim lic As String = ""
        Dim numeros As String
        Dim car As String
        Dim CodCadena As String = ""
        Dim cadenaa As String = ""
        Dim ope1 As Double = 0
        ope1 = Math.Cos(CDbl(lblfolio.Text))
        If ope1 > 0 Then
            cadenaa = Strings.Left(Replace(CStr(ope1), ".", "9"), 10)
        Else
            cadenaa = Strings.Left(Replace(CStr(Math.Abs(ope1)), ".", "8"), 10)
        End If
        For i = 1 To 10
            car = Mid(cadenaa, i, 1)
            Select Case car
                Case Is = 0
                    letters = letters & "Y"
                Case Is = 1
                    letters = letters & "Z"
                Case Is = 2
                    letters = letters & "W"
                Case Is = 3
                    letters = letters & "H"
                Case Is = 4
                    letters = letters & "S"
                Case Is = 5
                    letters = letters & "B"
                Case Is = 6
                    letters = letters & "C"
                Case Is = 7
                    letters = letters & "P"
                Case Is = 8
                    letters = letters & "Q"
                Case Is = 9
                    letters = letters & "A"
                Case Else
                    letters = letters & car
            End Select
        Next
        For w = 1 To 10 Step 2
            numeros = Mid(lblfolio.Text, w, 4)
            letras = Mid(letters, w, 4)
            lic = lic & numeros & letras & "-"
        Next
        lic = Strings.Left(lic, Len(lic) - 1)
        CodCadena = lic
        cadenafact = Trim(CodCadena)
#End Region

        Dim totalventa22 As Double = 0
        'totalventa22 = txtTotal.Text
        totalventa22 = txtTotal.Text

        Dim restaventa22 As Double = 0
        restaventa22 = txtResta.Text

        Dim propinaventa22 As Double = 0
        propinaventa22 = txtPropina.Text

        Dim descuentoventa22 As Double = 0
        descuentoventa22 = txtDescuento.Text

        cnn3.Close() : cnn3.Open()
        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "UPDATE hismesa SET Cerro='" & lblusuario2.Text & "', FCerrado='" & Format(Date.Now, "yyyy-MM-dd") & "',HCerrado='" & Format(Date.Now, "HH:mm:ss") & "',FH='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',Status=1 WHERE Status=0 AND Mesa='" & lblmesa.Text & "'"
        cmd3.ExecuteNonQuery()

        cmd3 = cnn3.CreateCommand
        cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Propina,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,TComensales,Corte,CorteU,CodFactura,Formato,IP,Fecha) VALUES('','" & lblmesa.Text & "',''," & SubtotalVenta & "," & Tiva & "," & totalventa22 & "," & Cuenta & "," & restaventa22 & "," & propinaventa22 & ",'" & lblusuario2.Text & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "','PAGADO'," & descuentoventa22 & ",'" & totcomi & "','" & COMENSALES & "','1','0','" & cadenafact & "','TICKET','" & dameIP2() & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
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

        Dim IEPS As Double = 0
        Dim TASIEPS As Double = 0

        Do While kreaper <> grdComanda.Rows.Count

            idc = grdComanda.Rows(kreaper).Cells(0).Value.ToString
            mycodigo = grdComanda.Rows(kreaper).Cells(1).Value.ToString
            mydescripcion = grdComanda.Rows(kreaper).Cells(2).Value.ToString
            myunidad = grdComanda.Rows(kreaper).Cells(3).Value.ToString
            mycantidad = grdComanda.Rows(kreaper).Cells(4).Value.ToString
            myprecio = grdComanda.Rows(kreaper).Cells(5).Value.ToString
            mytotal = grdComanda.Rows(kreaper).Cells(6).Value.ToString
            mycomensal = grdComanda.Rows(kreaper).Cells(7).Value.ToString
            mymesero = grdComanda.Rows(kreaper).Cells(8).Value.ToString
            IEPS = grdComanda.Rows(kreaper).Cells(10).Value.ToString
            TASIEPS = grdComanda.Rows(kreaper).Cells(11).Value.ToString

            mycantidad = FormatNumber(mycantidad, 2)
            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT PrecioCompra,IVA,Departamento,Grupo,Multiplo FROM Productos WHERE Codigo='" & mycodigo & "'"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    COSTVUE1 = rd2("PrecioCompra").ToString
                    PRECIOSINIVA1 = FormatNumber(myprecio / CDec(rd2("IVA").ToString + 1), 2)
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
            cmd3.CommandText = "INSERT INTO VentasDetalle(Folio,Codigo,Nombre,Cantidad,Unidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,FechaCompleta,Depto,Grupo,Comensal,Descto,Facturado,TotalIEPS,TasaIEPS) VALUES('" & folio & "','" & mycodigo & "','" & mydescripcion & "'," & mycantidad & ",'" & myunidad & "'," & COSTVUE1 & "," & COSTVUE1 & "," & myprecio & "," & mytotal & "," & PRECIOSINIVA1 & "," & TOTALSIVA & ",'" & mymesero & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "yyyy-mm-dd HH:mm:ss") & "','" & DEPA & "','" & GRUPO & "','" & mycomensal & "','0','0'," & IEPS & "," & TASIEPS & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

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



        If txtCambio.Text > 0 Then
            If txtPropina.Text > 0 Then
                MontoEffe = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) - CDec(txtCambio.Text) - CDec(txtPropina.Text)
            Else
                MontoEffe = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) - CDec(txtCambio.Text)

            End If

        Else
            If txtPropina.Text > 0 Then
                MontoEffe = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) - CDec(txtCambio.Text) - CDbl(txtPropina.Text)
            Else
                MontoEffe = IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text) - CDec(txtCambio.Text)
            End If

        End If



        SLD1 = (CDec(IIf(txtpagos.Text = 0, 0, txtpagos.Text)) + CDec(IIf(txtEfectivo.Text = 0, 0, txtEfectivo.Text)))

        If CDec(SLD1) >= CDec(txtTotal.Text) Then
            SLD = 0
        End If

        Abon = CDec(IIf(txtEfectivo.Text = 0, "0", txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, "0", txtpagos.Text)) + CDec(IIf(txtPropina.Text = 0, "0", txtPropina.Text)) - (CDec(txtCambio.Text + CDbl(IIf(txtDescuento.Text = 0, "0", txtDescuento.Text))))

        Abon = CDec(IIf(txtEfectivo.Text = 0, "0", txtEfectivo.Text)) + CDec(IIf(txtpagos.Text = 0, "0", txtpagos.Text)) - CDbl(IIf(txtCambio.Text = 0, "0", txtCambio.Text)) - txtPropina.Text

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

                Dim saldocuneta As Double = 0
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "SELECT Saldo FROM movCuenta WHERE Id=(SELECT MAX(Id) FROM movcuenta WHERE Cuenta='" & cuentarep & "')"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        saldocuneta = IIf(rd2(0).ToString = "", 0, rd2(0).ToString) + montopago

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                                    "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) values('" & formapago & "','" & bancoforma & "','" & referencia & "','VENTA'," & montopago & ",0," & montopago & "," & saldocuneta & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MyFolio & "','MOSTRADOR','" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()

                    End If
                Else
                    saldocuneta = -montopago

                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                                "insert into MovCuenta(Tipo,Banco,Referencia,Concepto,Total,Retiro,Deposito,Saldo,Fecha,Hora,Folio,Cliente,Comentario,Cuenta,BancoCuenta) values('" & formapago & "','" & bancoforma & "','" & referencia & "','VENTA'," & montopago & ",0," & montopago & "," & saldocuneta & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & MyFolio & "','MOSTRADOR','" & comentario & "','" & cuentarep & "','" & bancorep & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()

                End If
                rd2.Close()
                cnn2.Close()



                If formapago = "MONEDERO" Then
                    If montopago > 0 Then

                        Dim SALDOMON As Double = 0
                        Dim nuevosaldo As Double = 0

                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "SELECT Saldo FROM monedero WHERE Barras='" & referencia & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                SALDOMON = rd1(0).ToString
                                nuevosaldo = SALDOMON - CDbl(montopago)
                                nuevosaldo = FormatNumber(nuevosaldo, 2)

                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "UPDATE monedero set Saldo=" & nuevosaldo & " WHERE Barras='" & referencia & "'"
                                cmd2.ExecuteNonQuery()

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "INSERT INTO movmonedero(Monedero,Concepto,Abono,Cargo,Saldo,Fecha,Hora,Folio) VALUES('" & referencia & "','Venta',0," & montopago & "," & nuevosaldo & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "'," & MyFolio & ")"
                                cmd2.ExecuteNonQuery()
                                cnn2.Close()
                            End If
                        End If
                        rd1.Close()
                        cnn1.Close()

                    End If
                End If


                If CDec(montopago) > 0 Then
                    Dim nuvmontopago As Double = 0

                    If txtPropina.Text > 0 Then

                        If txtCambio.Text > 0 Then
                            If txtEfectivo.Text > 0 Then
                                nuvmontopago = montopago

                            Else
                                nuvmontopago = montopago - txtPropina.Text
                            End If


                        Else

                            If txtEfectivo.Text > 0 Then
                                nuvmontopago = montopago
                                propina = 0
                            Else
                                nuvmontopago = montopago - txtPropina.Text
                            End If



                        End If

                    Else
                        nuvmontopago = montopago
                    End If

                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,FormaPago,Propina,Monto,Banco,Referencia,Comentario,Usuario,Comisiones,Mesero,Descuento) VALUES(" & folio & ",0,'" & lblmesa.Text & "','ABONO','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','0'," & nuvmontopago & "," & SLD & ",'" & formapago & "'," & txtPropina.Text & "," & nuvmontopago & ",'" & bancoforma & "','" & referencia & "','" & comentario & "','" & lblusuario2.Text & "'," & totcomi & ",'" & lblMesero.Text & "'," & descuentoventa22 & ")"
                    cmd3.ExecuteNonQuery()
                    cnn3.Close()

                    If txtEfectivo.Text > 0 Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT * FROM abonoi WHERE NumFolio=" & folio
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "UPDATE abonoi SET Propina=0 WHERE NumFolio=" & folio & " AND FormaPago<>'EFECTIVO'"
                                cmd3.ExecuteNonQuery()
                                cnn3.Close()
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    End If

                End If
            Next
        End If



        If CDec(txtEfectivo.Text) > 0 Then

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Abonoi(NumFolio,IdCliente,Cliente,Concepto,Fecha,Hora,FechaCompleta,Cargo,Abono,Saldo,FormaPago,Propina,Monto,Banco,Referencia,Comentario,Usuario,Comisiones,Mesero,Descuento) VALUES(" & folio & ",0,'" & lblmesa.Text & "','ABONO','" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','0'," & MontoEffe & "," & SLD & ",'EFECTIVO'," & txtPropina.Text & "," & MontoEffe & ",'','','','" & lblusuario2.Text & "'," & totcomi & ",'" & lblMesero.Text & "'," & descuentoventa22 & ")"
            cmd3.ExecuteNonQuery()
            cnn3.Close()
        End If




        Dim existencia_inicial As Double = 0
        Dim opeCantReal As Double = 0
        Dim opediferencia As Double = 0


        Dim VarCodigo As String = ""
        Dim VarDesc As String = ""
        Dim VarCanti As Double = 0


        For koni = 0 To grdComanda.Rows.Count - 1

            existencia_inicial = 0
            opeCantReal = 0
            opediferencia = 0

            Dim MYCODIGOP As String = grdComanda.Rows(koni).Cells(1).Value.ToString
            Dim mydesc2 As String = grdComanda.Rows(koni).Cells(2).Value.ToString
            Dim MYCANT = grdComanda.Rows(koni).Cells(4).Value.ToString

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
            cmd1.CommandText = "SELECT Multiplo,Modo_Almacen FROM Productos WHERE Codigo='" & mycodigo & "' "
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
                                VarCanti = rd2("Cantidad").ToString * grdComanda.Rows(koni).Cells(4).Value.ToString

                                cnn3.Close() : cnn3.Open()
                                cmd3 = cnn3.CreateCommand
                                cmd3.CommandText = "SELECT Departamento,Grupo,ProvRes,MCD,Multiplo,Unico,GPrint FROM Productos WHERE Codigo='" & VarCodigo & "'"
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
                                cmd3.CommandText = "SELECT Existencia,MCD,Departamento,PrecioCompra FROM Productos WHERE Codigo='" & Strings.Left(VarCodigo, 6) & "'"
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
                        If grdComanda.Rows(koni).Cells(0).Value.ToString = "" Then GoTo Door

                        Dim mycodigod As String = grdComanda.Rows(koni).Cells(1).Value.ToString

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "SELECT Departamento,Grupo,ProvRes,MCD,Multiplo,Unico,GPrint FROM Productos WHERE Codigo='" & mycodigo & "'"
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
                        cmd2.CommandText = "SELECT Existencia,MCD,Departamento,PrecioCompra FROM Productos WHERE Codigo='" & Strings.Left(mycodigo, 6) & "'"
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
                        cmd4.CommandText = "INSERT INTO Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,Fecha,Usuario,Inicial,Final,Folio) VALUES('" & mycodigod & "','" & mydesc2 & "','Venta'," & opeCantReal & "," & Pre_Comp & ",'" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & lblusuario2.Text & "'," & Existencia & "," & nueva_existe & "," & folio & ")"
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
        Next

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
            cmd1.CommandText = "SELECT IDC FROM comandas WHERE Nmesa='" & lblmesa.Text & "'"
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



        '--------------------REINICIAR LA LETRA SI YA NO HAY DEPENDENCIAS DE ESA MESA---------------------------------------------------

        Dim cadena As String = lblmesa.Text

        Dim partes() As String = cadena.Split("_"c)
        Dim parteDeseada As String = partes(0)


        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT  IdMesa from mesa WHERE Nombre_mesa LIKE '%" & parteDeseada & "_" & "%'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
            End If
        Else
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "UPDATE mesasxempleados SET Letra='' WHERE Mesa='" & parteDeseada & "'"
            cmd3.ExecuteNonQuery()
            cnn3.Close()
        End If
        rd1.Close()
        cnn1.Close()

        ' btnlimpiar.PerformClick()
        tim.Stop()
        My.Application.DoEvents()

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

        If impresora = "" Then
            MsgBox("Impresora no configurada", vbInformation + vbOKOnly, titulorestaurante)
            GoTo deku
        End If

        If imprime = 1 Then

            If MessageBox.Show("Desea imprimir esta Ventana", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then


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
                    If PVentaMapeo80.DefaultPageSettings.PrinterSettings.PrinterName = impresora Then
                        Dim ps As New System.Drawing.Printing.PaperSize("Custom", 310, 3100)
                        PVentaMapeo80.DefaultPageSettings.PaperSize = ps
                        PVentaMapeo80.Print()
                    End If

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

deku:

        Me.Close()

    End Sub

    Private Sub btnPrecuenta_Click(sender As Object, e As EventArgs) Handles btnPrecuenta.Click
        If grdComanda.Rows.Count <> 0 Then

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

            Do While zi <> grdComanda.Rows.Count
                codi = grdComanda.Rows(zi).Cells(1).Value.ToString
                nom = grdComanda.Rows(zi).Cells(2).Value.ToString
                udv = grdComanda.Rows(zi).Cells(3).Value.ToString
                canti = grdComanda.Rows(zi).Cells(4).Value.ToString
                puvciva = grdComanda.Rows(zi).Cells(5).Value.ToString
                TOTALL = grdComanda.Rows(zi).Cells(6).Value.ToString
                comen = grdComanda.Rows(zi).Cells(7).Value.ToString
                mesero = grdComanda.Rows(zi).Cells(8).Value.ToString
                idcoma = grdComanda.Rows(zi).Cells(9).Value.ToString

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT PrecioCompra,PrecioVentaIVA,IVA,Departamento,Grupo FROM Productos WHERE Codigo='" & codi & "'"
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
            cmd1.CommandText = "SELECT Impresora FROM rutasimpresion WHERE Tipo='TICKET' AND Equipo='" & ObtenerNombreEquipo() & "'"
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
                Precuenta58.Print()
            End If
            Me.BringToFront()
        End If
    End Sub

    Private Sub Precuenta80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Precuenta80.PrintPage
        Try
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

            Dim Logotipo As Drawing.Image = Nothing
            Dim nLogo As String = DatosRecarga("LogoG")
            Dim tLogo As String = DatosRecarga("TipoLogo")

            cnn2.Close() : cnn2.Open()
            cnn4.Close() : cnn4.Open()
            cnn3.Close() : cnn3.Open()
            cnn1.Close() : cnn1.Open()

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
            cmd2.CommandText = "select Pie3,Pie2,Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
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
                cmd3.CommandText = "SELECT Nombre,Precio,Total,Cantidad FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
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

                        Dim caracteresPorLinea As Integer = 27
                        Dim texto As String = descri
                        Dim inicio As Integer = 0
                        Dim longitudTexto As Integer = texto.Length

                        While inicio < longitudTexto
                            Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                            Dim bloque As String = texto.Substring(inicio, longitudBloque)
                            e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 30, Y)
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

                            Dim caracteresPorLinea As Integer = 27
                            Dim texto As String = descri
                            Dim inicio As Integer = 0
                            Dim longitudTexto As Integer = texto.Length

                            While inicio < longitudTexto
                                Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                                Dim bloque As String = texto.Substring(inicio, longitudBloque)
                                e.Graphics.DrawString(bloque, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 30, Y)
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
                                Y += 15

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

            e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txtSubtotalmapeo.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
            Y += 20

            If txtPropina.Text > 0 Then
                e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(txtPropina.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            If txtDescuento.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(txtDescuento.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 20
            End If

            e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(txttotalpropina.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
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

            Dim caracteresPorLinea1 As Integer = 36
            Dim texto1 As String = pie1
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                inicio1 += caracteresPorLinea1
            End While

            e.Graphics.DrawString("Le atiende: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)

            cnn4.Close()
            cnn3.Close()
            cnn1.Close()
            cnn2.Close()

            e.HasMorePages = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
            cnn3.Close()
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub Precuenta58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Precuenta58.PrintPage
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
            cmd2.CommandText = "select Pie3,Pie2,Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
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
                cmd3.CommandText = "SELECT Nombre,Precio,Total FROM Comandas WHERE NMESA='" & lblmesa.Text & "'"
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

            e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
            e.Graphics.DrawString(FormatNumber(totalcuenta + servicio, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            Y += 15

            If txtPropina.Text > 0 Then
                e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

            If txtDescuento.Text > 0 Then
                e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15

                e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15
            End If

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
            Y += 3

            e.Graphics.DrawString("Le atiende: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)

            cnn4.Close()
            cnn3.Close()
            cnn1.Close()
            cnn2.Close()

            e.HasMorePages = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
            cnn3.Close()
            cnn1.Close()
            cnn2.Close()
        End Try
    End Sub

    Private Sub grdComanda_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdComanda.CellClick

        Dim celda As DataGridViewCellEventArgs = e

        If celda.ColumnIndex = 0 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

        End If

        If celda.ColumnIndex = 1 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 2 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 3 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

        End If


        If celda.ColumnIndex = 4 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

        End If

        If celda.ColumnIndex = 5 Then

            comandaeliminar = grdComanda.CurrentRow.Cells(0).Value.ToString
            codigoeliminar = grdComanda.CurrentRow.Cells(1).Value.ToString
            descripcioneliminar = grdComanda.CurrentRow.Cells(2).Value.ToString
            unidadeliminar = grdComanda.CurrentRow.Cells(3).Value.ToString
            cantidadeliminar = grdComanda.CurrentRow.Cells(4).Value.ToString
            precioeliminar = grdComanda.CurrentRow.Cells(5).Value.ToString
            comensaleliminar = grdComanda.CurrentRow.Cells(7).Value.ToString
            ideliminar = grdComanda.CurrentRow.Cells(9).Value.ToString

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
                                If rd2(0).ToString = 1 Then
                                Else
                                    MsgBox("El usuario no cuenta con permisos para realizar esta accion", vbInformation + vbOKOnly, titulorestaurante)
                                    Exit Sub
                                End If
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

            If grdComanda.Rows.Count < 0 Then Exit Sub

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
                    cmd3.CommandText = "SELECT PrecioCompra,PrecioVentaIVA,IVA,Departamento,Grupo FROM Productos WHERE Codigo='" & codigoeliminar & "'"
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

                    Call PRINT1(comandaeliminar, codigoeliminar)

                    If cantidadeliminar = CantidadP Then

                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "UPDATE Rep_Comandas SET Status='CANCELADA',Hr='" & Format(Date.Now, "HH:mm:ss") & "' WHERE Id=" & ideliminar & " AND Codigo='" & codigoeliminar & "' AND Nombre='" & descripcioneliminar & "'"
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
                        'Me.Close()
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
                        cmd2.CommandText = "SELECT Id FROM Rep_Comandas WHERE Id=" & verid & " AND Codigo='" & vercodigo & "' AND Status<>'CANCELADA'"
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

                Else
                    MsgBox("No es posible cancelar una cantidad mayor a este producto.", vbInformation + vbOKOnly, titulomensajes)
                End If
            End If
            cnn3.Close()
            '  Me.Close()
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
            cmd2.CommandText = "select Pie3,Pie2,Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
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
            cmd4.CommandText = "SELECT IDC FROM Comandas WHERE IDC='" & comandaeliminar & "'"
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
            cnn4.Close() : cnn4.Open()

            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "select Pie3,Pie2,Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
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
            cmd4.CommandText = "SELECT IDC FROM Comandas WHERE IDC=" & comandaeliminar & ""
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
        Dim fuente_c As New Font("Lucida Sans Typewriter", 10, FontStyle.Regular)
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
        Dim DesglosaIVA As String = IIf(DatosRecarga("Desglosa") = "", 0, DatosRecarga("Desglosa"))
        Dim facLinea As Integer = IIf(DatosRecarga("AutoFac") = "", 0, DatosRecarga("AutoFac"))
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

        Dim siqr As String = DatosRecarga2("LinkAuto")
        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim whats As String = DatosRecarga("Whatsapp")
        Dim ligaqr As String = ""

        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If

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
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie1 = rd2("Pie1").ToString
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
            Y += 5
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

                        Dim caracteresPorLinea As Integer = 30
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
                        Y += 5
                        e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 200, Y, derecha)
                        e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                        Y += 13

                        articulos = articulos + cantidadpro

                    End If
                Loop
                rd4.Close()

                e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                Y += 15
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
                        cmd1.CommandText = "SELECT Id from VtaImpresion where comensal='" & comensal & "'"
                        rd1 = cmd1.ExecuteReader
                        Do While rd1.Read
                            conta = conta + 1
                        Loop
                        rd1.Close()

                        Do While rd3.Read
                            If rd3.HasRows Then
                                conta = conta
                                contband = contband + 1
                                Y += 15
                                If comen_sal <> rd3("Comensal").ToString Then
                                    e.Graphics.DrawString("Detalle Comensal:", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(rd3("Comensal").ToString, fuente_b, Brushes.Black, 120, Y)
                                    TOTALCOM = 0
                                    Y += 20
                                End If


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
                                        If rd1(0).ToString > 0 Then
                                            ope = importepro / (1 + rd1(0).ToString)
                                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd1(0).ToString)
                                            TotalIVA = FormatNumber(TotalIVA, 2)
                                        End If

                                    End If
                                Loop
                                rd1.Close()

                                e.Graphics.DrawString(FormatNumber(cantidadpro, 2), New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)

                                Dim caracteresPorLinea As Integer = 30
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
                                Y += 5
                                e.Graphics.DrawString(simbolo & " " & preciopro, fuente_p, Brushes.Black, 195, Y, derecha)
                                e.Graphics.DrawString(simbolo & " " & FormatNumber(importepro, 2), fuente_p, Brushes.Black, 270, Y, derecha)
                                Y += 10

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
                                    Y += 10
                                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TOTALCOM, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                                    Y += 10

                                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                                    Y += 10
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

            articulos = IIf(articulos = 0, 0, articulos)
            Y += 10
            e.Graphics.DrawString("Cantidad de articulos: " & articulos, fuente_r, Brushes.Black, 1, Y)
            Y += 25

            If TotalIVA <> 0 Then

                If DesglosaIVA = 1 Then

                    e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                    Y += 15
                End If

                If CDec(txtDescuento.Text) <> 0 Then
                    e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CON DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CON PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                e.Graphics.DrawString("TOTAL A PAGAR", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txttotalpropina.Text), 2), fuente_a, Brushes.Black, 270, Y, derecha)
                Y += 20

            Else

                e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20

                If CDec(txtDescuento.Text) <> 0 Then
                    e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CON DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20

                    e.Graphics.DrawString("TOTAL CON PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                    Y += 20
                End If

                If SinNumComensal = 1 Then
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                    Y += 25
                Else
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_a, Brushes.Black, 270, Y, derecha)
                    Y += 25
                End If
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
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

                        'e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        'e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 150, Y)
                        'Y += 20
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

            Dim caracteresPorLinea1 As Integer = 36
            Dim texto1 As String = Pie1
            Dim inicio1 As Integer = 0
            Dim longitudTexto1 As Integer = texto1.Length

            While inicio1 < longitudTexto1
                Dim longitudBloque1 As Integer = Math.Min(caracteresPorLinea1, longitudTexto1 - inicio1)
                Dim bloque1 As String = texto1.Substring(inicio1, longitudBloque1)
                e.Graphics.DrawString(bloque1, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 1, Y)
                Y += 15
                inicio1 += caracteresPorLinea1
            End While

            e.Graphics.DrawString("Mesero: " & lblMesero.Text, fuente_r, Brushes.Black, 5, Y)
            e.Graphics.DrawString("Cajero: " & lblusuario2.Text, fuente_r, Brushes.Black, 270, Y, derecha)
            Y += 20

            Dim autofac As Integer = 0
            Dim linkauto As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    autofac = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    linkauto = rd1(0).ToString
                    siqr = rd1(1).ToString
                End If
            End If
            rd1.Close()

            Dim siqrwhats As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    siqrwhats = rd1(1).ToString
                End If
            End If
            rd1.Close()

            cnn1.Close()
            If siqrwhats = 1 Then
                If ligaqr <> "" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = ligaqr
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_c, Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawImage(ima, 50, CInt(Y), 85, 85)
                    Y += 85
                End If

            End If

            If autofac = 1 Then

                If siqr = "1" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = linkauto
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Codigo para facturar:", fuente_c, Brushes.Black, 1, Y)
                    Y += 20
                    e.Graphics.DrawString(Trim(cadenafact), fuente_c, Brushes.Black, 1, Y)
                    Y += 20
                    ' Usa Using para garantizar la liberación de recursos de la fuente
                    e.Graphics.DrawString("Realiza tu factura aqui", fuente_c, Brushes.Black, 1, Y)
                    Y += 10
                    ' Dibuja la imagen en el contexto gráfico
                    e.Graphics.DrawImage(ima, 50, CInt(Y + 15), 85, 85)
                    Y += 20
                End If

            Else

            End If

            e.HasMorePages = False

            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
            btnlimpiar.PerformClick()
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

        Dim ligaqr As String = ""
        Dim whats As String = DatosRecarga("Whatsapp")

        Dim autofact As String = DatosRecarga("LinkAuto")
        Dim siqr As String = DatosRecarga2("LinkAuto")

        If whats <> "" Then
            ligaqr = "http://wa.me/" & whats
        End If

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
                "select Pie1,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
            rd2 = cmd2.ExecuteReader
            If rd2.HasRows Then
                If rd2.Read Then
                    Pie1 = rd2("Pie1").ToString
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
                        cmd1.CommandText = "SELECT Id from VtaImpresion where comensal='" & comensal & "'"
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
                                        If rd1(0).ToString > 0 Then
                                            ope = importepro / (1 + rd1(0).ToString)
                                            TotalIVA = TotalIVA + CDec(ope) * CDec(rd1(0).ToString)
                                            TotalIVA = FormatNumber(TotalIVA, 2)
                                        End If

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

                If DesglosaIVA = 1 Then

                    e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("IVA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(TotalIVA, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtSubtotalmapeo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                    e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
                    Y += 15
                End If

                e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15

                If CDec(txtDescuento.Text) <> 0 Then
                    e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("TOTAL CON DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("TOTAL CON PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                e.Graphics.DrawString("TOTAL A PAGAR", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txttotalpropina.Text), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15

            Else
                e.Graphics.DrawString("SUBTOTAL: ", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(CDec(txtSubtotalmapeo.Text) - CDec(TotalIVA), 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 15

                If CDec(txtDescuento.Text) <> 0 Then
                    e.Graphics.DrawString("DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtDescuento.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("TOTAL CON DESCUENTO: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                If CDec(txtPropina.Text) <> 0 Then
                    e.Graphics.DrawString("PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txtPropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15

                    e.Graphics.DrawString("TOTAL CON PROPINA: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If

                If SinNumComensal = 1 Then
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                Else
                    e.Graphics.DrawString("TOTAL A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
                    e.Graphics.DrawString(simbolo & " " & FormatNumber(txttotalpropina.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                    Y += 15
                End If
            End If

            If CDec(txtEfectivo.Text) Then
                e.Graphics.DrawString("EFECTIVO", fuente_b, Brushes.Black, 1, Y)
                e.Graphics.DrawString(simbolo & " " & FormatNumber(txtEfectivo.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
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

                        'e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
                        'e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 100, Y)
                        'Y += 15
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

            Dim autofac As Integer = 0
            Dim linkauto As String = ""

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    autofac = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='LinkAuto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    linkauto = rd1(0).ToString
                    siqr = rd1(1).ToString
                End If
            End If
            rd1.Close()

            Dim siqrwhats As Integer = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred,NumPart FROM formatos WHERE Facturas='WhatsApp'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    siqrwhats = rd1(1).ToString
                End If
            End If
            rd1.Close()

            cnn1.Close()
            If siqrwhats = 1 Then
                If ligaqr <> "" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = ligaqr
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Escríbenos por Whatsapp", fuente_c, Brushes.Black, 1, Y)
                    Y += 15
                    e.Graphics.DrawImage(ima, 30, CInt(Y), 85, 85)
                    Y += 60

                End If

            End If

            Y += 35
            If autofac = 1 Then

                If siqr = "1" Then
                    Dim qre As New QrCodeImgControl
                    qre.Size = New System.Drawing.Size(200, 200)
                    qre.Text = linkauto
                    Dim ima As Image = DirectCast(qre.Image.Clone, Image)

                    e.Graphics.DrawString("Codigo para facturar:", fuente_c, Brushes.Black, 1, Y)
                    Y += 25
                    e.Graphics.DrawString(Trim(cadenafact), fuente_c, Brushes.Black, 1, Y)
                    Y += 25
                    ' Usa Using para garantizar la liberación de recursos de la fuente
                    e.Graphics.DrawString("Realiza tu factura aqui", fuente_c, Brushes.Black, 1, Y)
                    Y += 10
                    ' Dibuja la imagen en el contexto gráfico
                    e.Graphics.DrawImage(ima, 30, CInt(Y + 15), 85, 85)
                    Y += 20
                End If

            Else

            End If

            e.HasMorePages = False

            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()

            btnlimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        End Try
    End Sub

    Private Sub txtPropina_Click(sender As Object, e As EventArgs) Handles txtPropina.Click
        txtPropina.SelectionStart = 0
        txtPropina.SelectionLength = Len(txtPropina.Text)
        ' txtPropina.Text = "0.00"
        focomapeo = 3
    End Sub

    Private Sub txtEfectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEfectivo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
            If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub


            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtpagos.Text = "", 0.00, txtpagos.Text)) - txtPropina.Text)

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


            btnIntro.Focus.Equals(True)
        End If
    End Sub

    Private Function PosCad(CadOrg As String, Car As String, Pos As Integer, TamCad As Integer) As String

        Dim Part1 As String
        Dim NewPart1 As String

        If CadOrg = "0.00" Or CadOrg = 0 Or CadOrg = "" Then
            PosCad = Car
        ElseIf Pos = 0 Then
            txtEfectivo.Focus.Equals(True)
            PosCad = CDec(CadOrg) + CDec(Car)
        ElseIf Pos <> TamCad Then
            Part1 = Strings.Left(CadOrg, Pos)
            NewPart1 = Part1 & Car
            PosCad = Replace(CadOrg, Part1, NewPart1)
        Else
            txtEfectivo.Focus.Equals(True)
            PosCad = CadOrg & Car
        End If

    End Function

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Select Case focomapeo
            Case Is = 1


                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn1.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
                txtEfectivo.Focus.Equals(True)
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "1"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)

            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn1.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "1"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4


                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn1.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn2.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "2"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3


                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn2.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If
                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "2"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn2.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn3.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "3"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn3.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "3"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn3.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn4.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "4"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3


                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn4.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "4"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn4.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn5.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "5"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn5.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "5"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn5.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn6.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "6"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn6.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "6"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn6.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn7.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "7"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn7.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If
                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "7"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn7.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn8.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos

            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "8"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn8.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "8"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn8.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn9.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "9"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn9.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "9"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn9.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btn0.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "0"
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3

                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btn0.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "0"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4

                txtmonto.Focus.Equals(True)
                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btn0.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "20"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "20"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "20"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "50"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "50"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "50"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "100"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "100"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)

            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "100"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "200"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "200"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "200"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "500"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "500"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "500"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
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
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                'Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                'Dim nuevo = monto + "1000"
                'txtPropina.Text = FormatNumber(nuevo, 2)
                'txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "1000"
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
            Case Is = 4
                Dim monto As Double = IIf(txtmonto.Text = "", "0.00", txtmonto.Text)
                Dim nuevo = monto + "1000"
                txtmonto.Text = FormatNumber(nuevo, 2)
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click
        frmDividir.Show()
        frmDividir.BringToFront()
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
                Dim subtotal As Double = IIf(txtSubtotalmapeo.Text = 0, 0, txtSubtotalmapeo.Text)
                Dim sumapagos As Double = CDbl(efectivo) + CDbl(pagos)

                Dim saldo As Double = txtSubtotalmapeo.Text
                Dim porcentaje As Double = (txtPorcentaje.Text / 100)
                Dim porcentajetot As Double = CDbl(saldo) * CDbl(porcentaje)
                montopropina = txtDescuento.Text

                txtDescuento.Text = FormatNumber(porcentajetot, 2)

                If txtDescuento.Text = "0.00" Then
                    MyOpe = CDbl(subtotalmapeo) - sumapagos + CDbl(txtPropina.Text)
                    txtResta.Text = FormatNumber(MyOpe, 2)
                    txtTotal.Text = CDbl(txtSubtotalmapeo.Text) - CDbl(txtDescuento.Text)

                    txttotalpropina.Text = CDbl(subtotal) - CDbl(txtDescuento.Text) + CDbl(txtPropina.Text)


                Else
                    MyOpe = (CDec(subtotal) - CDbl(txtDescuento.Text)) - (sumapagos) + CDbl(txtPropina.Text)
                    txtResta.Text = FormatNumber(MyOpe, 2)
                    txtTotal.Text = CDbl(txtSubtotalmapeo.Text) - CDbl(txtDescuento.Text)

                    txttotalpropina.Text = CDbl(subtotal) + CDbl(txtPropina.Text) - CDbl(txtDescuento.Text)
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
                lblTotal.Text = FormatNumber(txttotalpropina.Text, 2)
                txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)
                tmpCam = 0

                txtEfectivo.Text = "0.00"
                txtpagos.Text = "0.00"
                grdPagos.Rows.Clear()

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


        Dim VarRes As Double = 0
        Dim VRe As String = ""
        Dim Vre1 As String = ""
        Dim VarPropa As Double = 0
        Dim MyOpe As Double = 0
        Dim restapago As Double = 0
        Dim tmpCam As Double = 0
        Dim TotalPagar As Double = 0

        Dim efectivo As Double = IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)
        Dim pagos As Double = IIf(txtpagos.Text = "", 0, txtpagos.Text)
        Dim total As Double = IIf(txtTotal.Text = "", 0, txtTotal.Text)
        Dim subtotal As Double = IIf(txtSubtotalmapeo.Text = "", 0, txtSubtotalmapeo.Text)
        Dim sumapagos As Double = CDbl(efectivo) + CDbl(pagos)

        Dim saldo As Double = txtSubtotalmapeo.Text
        Dim porcentaje As Double = (txtPorcentaje.Text / 100)
        Dim porcentajetot As Double = CDbl(saldo) * CDbl(porcentaje)
        montopropina = txtDescuento.Text

        txtDescuento.Text = FormatNumber(porcentajetot, 2)

        If txtDescuento.Text = "0.00" Then
            MyOpe = CDbl(subtotalmapeo) - sumapagos + CDbl(txtPropina.Text)
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtTotal.Text = CDbl(txtSubtotalmapeo.Text) - CDbl(txtDescuento.Text)

            txttotalpropina.Text = CDbl(subtotal) - CDbl(txtDescuento.Text) + CDbl(txtPropina.Text)


        Else
            MyOpe = (CDec(subtotal) - CDbl(txtDescuento.Text)) - (sumapagos) + CDbl(txtPropina.Text)
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtTotal.Text = CDbl(txtSubtotalmapeo.Text) - CDbl(txtDescuento.Text)

            txttotalpropina.Text = CDbl(subtotal) + CDbl(txtPropina.Text) - CDbl(txtDescuento.Text)
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
        lblTotal.Text = FormatNumber(txttotalpropina.Text, 2)
        txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)
        tmpCam = 0

        txtEfectivo.Text = "0.00"
        txtpagos.Text = "0.00"
        grdPagos.Rows.Clear()

        If CDec(tmpCam) >= 0 Then
            txtCambio.Text = FormatNumber(tmpCam, 2)

        Else
            txtCambio.Text = "0.00"

        End If

    End Sub

    Private Sub txtPorcentaje_Click(sender As Object, e As EventArgs) Handles txtPorcentaje.Click
        txtPorcentaje.SelectionStart = 0
        txtPorcentaje.SelectionLength = Len(txtPorcentaje.Text)
        focomapeo = 29
    End Sub

    Private Sub btnCortesia_Click(sender As Object, e As EventArgs) Handles btnCortesia.Click
        Dim VarId As Integer = 0
        Dim VarCortesia As Integer = 0

        Dim cuenta As Double = 0
        Dim CODIG As String = ""
        Dim DESC1 As String = ""
        Dim cant As Double = 0
        Dim PUVCIVA As Double = 0
        Dim TOTAL1 As Double = 0
        Dim UDV As String = ""
        Dim Comen As String = ""
        Dim CostVUE1 As Double = 0
        Dim PrecioSinIVA1 As Double = 0
        Dim TOTALSIVA As Double = 0
        Dim DEPA As String = ""
        Dim GRUPO1 As String = ""

        Dim subb As Double = 0

        Try
            cortesia_venta = 1
            txtResta.Text = "0.00"

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT idEmpleado FROM Usuarios WHERE Alias='" & lblusuario2.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    VarId = rd1(0).ToString

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "select CortesiaM from permisosm where IdEmpleado=" & VarId & ""
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            VarCortesia = rd2(0).ToString
                        End If
                    End If
                    rd2.Close()
                    cnn2.Close()

                End If
            End If
            rd1.Close()
            cnn1.Close()

            If VarCortesia = 0 Then
                MsgBox("Usuario sin privilegios para la cortesia", vbInformation + vbOKOnly, "Delsscom® Restaurant")
                Exit Sub
            End If

            If MsgBox("¿Desea continuar con el proceso, si continua no podra cancelarce el proceso?", vbInformation + vbYesNo, titulorestaurante) = vbNo Then Exit Sub

            subb = CDec(txtTotal.Text) * 0.16
            cuenta = CDec(CDec(txtEfectivo.Text) + CDec(txtpagos.Text)) - CDec(txtCambio.Text)

            subb = 0
            cuenta = FormatNumber(cuenta, 2)

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,Concepto,MntoCortesia,Fecha) values(" & IIf(VarId, 0, VarId) & ",'" & lblmesa.Text & "','',0," & subb & ",0," & cuenta & "," & txtResta.Text & ",'" & lblusuario2.Text & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & "PAGADO" & "',0,0,'" & "CORTESIA" & "'," & CDec(txtTotal.Text) & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "')"
            cmd3.ExecuteNonQuery()
            cnn3.Close()

            cnn4.Close() : cnn4.Open()
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT MAX(Folio) from Ventas"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    folio = IIf(rd4(0).ToString = "", 1, rd4(0).ToString)
                Else
                    folio = 0
                End If
            Else
                folio = 0
            End If
            rd4.Close()
            cnn4.Close()

            For LUFFY As Integer = 0 To grdComanda.Rows.Count - 1

                CODIG = grdComanda.Rows(LUFFY).Cells(1).Value.ToString
                DESC1 = grdComanda.Rows(LUFFY).Cells(2).Value.ToString
                cant = grdComanda.Rows(LUFFY).Cells(4).Value.ToString
                PUVCIVA = grdComanda.Rows(LUFFY).Cells(5).Value.ToString
                Comen = grdComanda.Rows(LUFFY).Cells(7).Value
                TOTAL1 = 0

                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText = "SELECT PrecioCompra,Departamento,Grupo,UVenta FROM Productos WHERE Codigo='" & CODIG & "'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows <> 0 Then
                    If rd5.Read Then
                        CostVUE1 = rd5("PrecioCompra").ToString
                        PrecioSinIVA1 = 0
                        TOTALSIVA = 0
                        DEPA = Trim(rd5("Departamento").ToString)
                        GRUPO1 = rd5("Grupo").ToString
                        UDV = rd5("UVenta").ToString
                    End If
                End If
                rd5.Close()
                cnn5.Close()

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO VentasDetalle(Codigo,Folio,Nombre,Unidad,Cantidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,FechaCompleta,Comisionista,Depto,Grupo,TotalIEPS,TasaIEPS) VALUES('" & CODIG & "'," & folio & ",'" & DESC1 & "','" & UDV & "'," & cant & "," & PUVCIVA & "," & CostVUE1 & "," & PUVCIVA & "," & TOTAL1 & "," & PrecioSinIVA1 & "," & TOTALSIVA & ",'" & Format(Date.Now, "yyyy/MM/dd") & "','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "',0,'" & DEPA & "','" & GRUPO1 & "',0,0)"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "INSERT INTO VtaImpresion(Folio,Codigo,Nombre,Cantidad,UVenta,CostVUE,CostVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Comisionista,Fecha,Depto,Grupo) VALUES(" & folio & ",'" & CODIG & "','" & DESC1 & "'," & cant & ",'" & UDV & "'," & PUVCIVA & "," & CostVUE1 & "," & PUVCIVA & "," & TOTAL1 & "," & PrecioSinIVA1 & "," & TOTALSIVA & ",0,'" & Format(Date.Now, "yyyy/MM/dd") & "','" & DEPA & "','" & GRUPO1 & "')"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "UPDATE Productos SET Existencia=Existencia -" & CDec(cant) & " WHERE Codigo='" & CODIG & "'"
                cnn1.Close()

            Next
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "DELETE FROM comanda1 WHERE Nombre='" & lblmesa.Text & "'"
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "DELETE FROM comandas WHERE NMesa='" & lblmesa.Text & "'"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
            MsgBox("Cortesia agregada correctamente", vbInformation + vbOKOnly, titulomensajes)

            Dim tamimpresion As Integer = 0
            Dim impresora As String = ""

            tamimpresion = TamImpre()
            impresora = ImpresoraImprimir()


            If tamimpresion = "80" Then
                pCortesia80.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pCortesia80.Print()
            ElseIf tamimpresion = "58" Then
                pCortesia58.DefaultPageSettings.PrinterSettings.PrinterName = impresora
                pCortesia58.Print()
            End If
            cnn1.Close()

            cortesia_venta = 0
            btnlimpiar.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Open()
            cnn3.Close()
            cnn5.Close()
            cnn4.Close()
        End Try
    End Sub

    Private Sub pCortesia80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCortesia80.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 90
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 90
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select Pie1,Pie2,Pie3,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, centro)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 140, Y, centro)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 135, Y, centro)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CLIENTE: " & lblmesa.Text, fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("FOLIO: " & folio, fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 11
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 35, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 215, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 20
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        If grdComanda.Rows.Count > 0 Then
            For barbi As Integer = 0 To grdComanda.Rows.Count - 1

                Dim codigo As String = grdComanda.Rows(barbi).Cells(1).Value.ToString
                Dim descripcion As String = grdComanda.Rows(barbi).Cells(2).Value.ToString
                Dim cantidad As Double = grdComanda.Rows(barbi).Cells(4).Value.ToString
                Dim precio As Double = grdComanda.Rows(barbi).Cells(5).Value.ToString
                Dim total As Double = grdComanda.Rows(barbi).Cells(6).Value.ToString

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 30
                Dim texto As String = descripcion
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, 25, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While

                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 215, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 270, Y, derecha)
                Y += 20

            Next
        End If
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 16

        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 15

        e.Graphics.DrawString("TOTAl A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("0.00", fuente_b, Brushes.Black, 270, Y, derecha)
        Y += 15

        Dim CantidaLetra As String = ""
        CantidaLetra = "Son: " & convLetras(txtTotal.Text)
        Y += 15

        If Mid(CantidaLetra, 1, 30) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 30), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Mid(CantidaLetra, 31, 60) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 31, 60), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 38), fuente_r, Brushes.Black, 1, Y)
            Y += 20
        End If

        e.Graphics.DrawString("Lo atendio: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)
        Y += 20

        e.HasMorePages = False
    End Sub

    Private Sub pCortesia58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pCortesia58.PrintPage
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_r As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_b As New Font("Lucida Sans Typewriter", 8, FontStyle.Bold)
        Dim fuente_c As New Font("Lucida Sans Typewriter", 8, FontStyle.Regular)
        Dim fuente_p As New Font("Lucida Sans Typewriter", 7, FontStyle.Regular)
        Dim derecha As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim centro As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim hoja As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0

        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""
        Dim Pie2 As String = ""
        Dim Pie3 As String = ""
        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 45, 5, 110, 110)
                Y += 90
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 12, 5, 160, 80)
                Y += 90
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn4.Close() : cnn4.Open()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText =
                "select Pie1,Pie2,Pie3,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                Pie = rd4("Pie1").ToString
                Pie2 = rd4("Pie2").ToString
                Pie3 = rd4("Pie3").ToString
                'Razón social
                If rd4("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab0").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'RFC
                If rd4("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab1").ToString, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 90, Y, centro)
                    Y += 11
                End If
                'Calle  N°.
                If rd4("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab2").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Colonia
                If rd4("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab3").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Delegación / Municipio - Entidad
                If rd4("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab4").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Teléfono
                If rd4("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab5").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                'Correo
                If rd4("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd4("Cab6").ToString, New Drawing.Font(tipografia, 8, FontStyle.Regular), Brushes.Gray, 90, Y, centro)
                    Y += 10
                End If
                Y += 12
            End If
        Else
            Y += 0
        End If
        rd4.Close()
        cnn4.Close()

        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 11
        e.Graphics.DrawString("C O R T E S I A", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "dd/MM/dd"), fuente_r, Brushes.Black, 1, Y)
        e.Graphics.DrawString("Hora: " & Format(Date.Now, "HH:mm"), fuente_r, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("-----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("CLIENTE: " & lblmesa.Text, fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("FOLIO: " & folio, fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 11
        e.Graphics.DrawString("----------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        e.Graphics.DrawString("DESCRIPION", fuente_b, Brushes.Black, 90, Y, centro)
        Y += 10
        e.Graphics.DrawString("CANT", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO", fuente_b, Brushes.Black, 103, Y, derecha)
        e.Graphics.DrawString("IMPORTE", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15
        e.Graphics.DrawString("---------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 15

        If grdComanda.Rows.Count > 0 Then
            For barbi As Integer = 0 To grdComanda.Rows.Count - 1



                Dim codigo As String = grdComanda.Rows(barbi).Cells(1).Value.ToString
                Dim descripcion As String = grdComanda.Rows(barbi).Cells(2).Value.ToString
                Dim cantidad As Double = grdComanda.Rows(barbi).Cells(4).Value.ToString
                Dim precio As Double = grdComanda.Rows(barbi).Cells(5).Value.ToString
                Dim total As Double = grdComanda.Rows(barbi).Cells(6).Value.ToString

                e.Graphics.DrawString(cantidad, fuente_b, Brushes.Black, 1, Y)

                Dim caracteresPorLinea As Integer = 25
                Dim texto As String = descripcion
                Dim inicio As Integer = 0
                Dim longitudTexto As Integer = texto.Length

                While inicio < longitudTexto
                    Dim longitudBloque As Integer = Math.Min(caracteresPorLinea, longitudTexto - inicio)
                    Dim bloque As String = texto.Substring(inicio, longitudBloque)
                    e.Graphics.DrawString(bloque, New Font("Arial", 8, FontStyle.Regular), Brushes.Black, 20, Y)
                    Y += 15
                    inicio += caracteresPorLinea
                End While


                e.Graphics.DrawString(FormatNumber(precio, 2), fuente_b, Brushes.Black, 133, Y, derecha)
                e.Graphics.DrawString(FormatNumber(total, 2), fuente_b, Brushes.Black, 180, Y, derecha)
                Y += 20

            Next
        End If
        e.Graphics.DrawString("--------------------------------------------------------------------------------------------", fuente_b, Brushes.Black, 1, Y)
        Y += 16

        e.Graphics.DrawString("TOTAL: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString(FormatNumber(txtTotal.Text, 2), fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        e.Graphics.DrawString("TOTAl A PAGAR: ", fuente_b, Brushes.Black, 1, Y)
        e.Graphics.DrawString("0.00", fuente_b, Brushes.Black, 180, Y, derecha)
        Y += 15

        Dim CantidaLetra As String = ""
        CantidaLetra = "Son: " & convLetras(txtTotal.Text)
        Y += 15

        If Mid(CantidaLetra, 1, 30) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 1, 30), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Mid(CantidaLetra, 31, 60) <> "" Then
            e.Graphics.DrawString(Mid(CantidaLetra, 31, 60), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        If Trim(Pie2) <> "" Then
            e.Graphics.DrawString(Mid(Pie2, 1, 38), fuente_r, Brushes.Black, 1, Y)
            Y += 15
        End If

        e.Graphics.DrawString("Lo atendio: " & lblusuario2.Text, fuente_r, Brushes.Black, 1, Y)


        e.HasMorePages = False
    End Sub

    Private Sub txtEfectivo_Enter(sender As Object, e As EventArgs) Handles txtEfectivo.Enter
        focomapeo = 1
    End Sub

    Private Sub Panel7_Click(sender As Object, e As EventArgs) Handles Panel7.Click
        Select Case focomapeo
            Case Is = 1

                txtEfectivo.Focus.Equals(True)
                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btnpunto.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
            Case Is = 2
                Dim monto As Double = IIf(txtDescuento.Text = "", "0.00", txtDescuento.Text)
                Dim nuevo = monto + "."
                txtDescuento.Text = FormatNumber(nuevo, 2)
                txtDescuento.Focus.Equals(True)
            Case Is = 3
                Dim monto As Double = IIf(txtPropina.Text = "", "0.00", txtPropina.Text)
                Dim nuevo = monto + "."
                txtPropina.Text = FormatNumber(nuevo, 2)
                txtPropina.Focus.Equals(True)
            Case Is = 29
                Dim monto As Double = IIf(txtPorcentaje.Text = "", "0.00", txtPorcentaje.Text)
                Dim nuevo = monto + "."
                txtPorcentaje.Text = FormatNumber(nuevo, 2)
                txtPorcentaje.Focus.Equals(True)
        End Select
    End Sub

    Private Sub txtPropina_Enter(sender As Object, e As EventArgs) Handles txtPropina.Enter
        focomapeo = 3
    End Sub

    Private Sub txtPropina_TextChanged(sender As Object, e As EventArgs) Handles txtPropina.TextChanged
        If Not IsNumeric(txtPropina.Text) Then txtPropina.Text = "0.00" : Exit Sub
        If Strings.Left(txtPropina.Text, 1) = "," Or Strings.Left(txtPropina.Text, 1) = "." Then Exit Sub


        Dim VarRes As Double = 0
        Dim VRe As String = ""
        Dim Vre1 As String = ""
        Dim VarPropa As Double = 0
        Dim MyOpe As Double = 0
        Dim restapago As Double = 0
        Dim tmpCam As Double = 0
        Dim TotalPagar As Double = 0

        Dim subtotalventa As Double = IIf(txtSubtotalmapeo.Text = "", 0, txtSubtotalmapeo.Text)
        Dim efectivoventa As Double = IIf(txtEfectivo.Text = "", 0, txtEfectivo.Text)
        Dim pagosventa As Double = IIf(txtpagos.Text = "", 0, txtpagos.Text)
        Dim propinaventa As Double = IIf(txtPropina.Text = "", 0, txtPropina.Text)
        Dim totalventa As Double = IIf(txtTotal.Text = "", 0, txtTotal.Text)

        Dim sumapagos As Double = CDbl(efectivoventa) + CDbl(pagosventa)

        If txtPropina.Text = "0" Then

            MyOpe = CDec(CDec(subtotalventa) - (sumapagos - CDec(VarPropa)) - CDbl(txtDescuento.Text))
        Else

            If txtDescuento.Text = "0.00" Then
                MyOpe = CDec(subtotalventa + propinaventa) - sumapagos
            Else
                MyOpe = CDec(CDec(subtotalventa) - (sumapagos - CDec(propinaventa)) - CDbl(IIf(txtDescuento.Text = "", 0, txtDescuento.Text)))
            End If

        End If

        If MyOpe = 0 Then
            MyOpe = 0
        End If


        If MyOpe < 0 Then
            txtResta.Text = "0.00"

            txtCambio.Text = -MyOpe
        Else
            txtResta.Text = MyOpe
            txtCambio.Text = "0.00"
        End If

        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)

        If CDec(txtResta.Text) = CDec(IIf(txtSubtotalmapeo.Text = "", "0", txtSubtotalmapeo.Text)) And CDec(txtPropina.Text) = 0 Then

            txttotalpropina.Text = CDec(totalventa) + CDec(txtPropina.Text)
            txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)

            lblTotal.Text = CDec(subtotalventa)
            lblTotal.Text = FormatNumber(IIf(txtTotal.Text = "", 0, txtTotal.Text), 2)
        Else


            txttotalpropina.Text = CDec(totalventa) + CDec(IIf(txtPropina.Text = "", 0, txtPropina.Text))
            txttotalpropina.Text = FormatNumber(txttotalpropina.Text, 2)

            lblTotal.Text = CDec(totalventa) + CDbl(txtPropina.Text)
            lblTotal.Text = FormatNumber(lblTotal.Text, 2)

            txtEfectivo.Text = "0.00"
            txtpagos.Text = "0.00"
            grdPagos.Rows.Clear()
        End If
        focomapeo = 1

    End Sub

    Private Sub btnpunto_Click(sender As Object, e As EventArgs) Handles btnpunto.Click

        Select Case focomapeo
            Case Is = 1

                NewPos = txtEfectivo.SelectionStart
                txtEfectivo.Text = PosCad(txtEfectivo.Text, btnpunto.Text, txtEfectivo.SelectionStart, Len(txtEfectivo.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtEfectivo.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtEfectivo.SelectionStart = NewPos
                txtEfectivo.Focus.Equals(True)

            Case Is = 3
                NewPos = txtPropina.SelectionStart
                txtPropina.Text = PosCad(txtPropina.Text, btnpunto.Text, txtPropina.SelectionStart, Len(txtPropina.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtPropina.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtPropina.SelectionStart = NewPos
                txtPropina.Focus.Equals(True)

            Case Is = 4

                NewPos = txtmonto.SelectionStart
                txtmonto.Text = PosCad(txtmonto.Text, btnpunto.Text, txtmonto.SelectionStart, Len(txtmonto.Text))

                If NewPos = 0 Then
                    NewPos = Len(txtmonto.Text)
                Else
                    NewPos = NewPos + 1
                End If

                txtmonto.SelectionStart = NewPos
                txtmonto.Focus.Equals(True)
        End Select
    End Sub

    Private Sub frmNuevoPagar_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.F2 Then
            btnIntro.PerformClick()
        End If
    End Sub

    Private Sub cboCuenta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuenta.SelectedValueChanged
        Try
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

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmNuevoPagar_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        tim.Stop()
    End Sub

    Private Sub txtmonto_Click(sender As Object, e As EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
        focomapeo = 4
    End Sub

    Private Sub txtmonto_Enter(sender As Object, e As EventArgs) Handles txtmonto.Enter
        focomapeo = 4
    End Sub
End Class