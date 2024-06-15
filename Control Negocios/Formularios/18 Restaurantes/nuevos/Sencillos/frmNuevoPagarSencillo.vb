Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Xml
Imports Gma.QrCodeNet.Encoding.Windows.Forms
Public Class frmNuevoPagarSencillo

    Public subtotalmapeo As Double = 0
    Public focomapeo As Integer = 0
    Public contraseñamesero As String = ""
    Public COMENSALES As String = ""

    ''' variablesm para terminal bancaria
    Public valorxd As Integer = 0
    Public SiPago As Integer = 0
    Public hayTerminal As Integer = 0
    Public validaTarjeta As Double = 0

    Dim numTerminal As String = ""
    Dim numClave As String = ""
    Dim URLsolicitud As String = ""
    Dim URLresultado As String = ""

    Dim tim As New System.Windows.Forms.Timer()

    Dim sumacomandas As Double = 0
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
    Dim idborrado As Integer = 0

    Dim propina As Double = 0
    Dim percent_propina As String = ""
    Dim montopropina As Double = 0
    Dim myope As Double = 0

    Dim SinNumComensal As Integer = 0
    Dim idusuario As Integer = 0
    Dim estadousuario As Integer = 0

    Dim ideliminar As Integer = 0
    Dim comandaeliminar As Integer = 0
    Dim codigoeliminar As String = ""
    Dim descripcioneliminar As String = ""
    Dim unidadeliminar As String = ""
    Dim cantidadeliminar As Double = 0
    Dim precioeliminar As Double = 0
    Dim comensaleliminar As String = ""

    Public cadenafact As String = ""
    Dim folio As String = ""
    Dim cortesia_venta As Integer = 0
    Private Sub BTNsALIR_Click(sender As Object, e As EventArgs) Handles BTNsALIR.Click
        Me.Close()
    End Sub

    Private Sub frmNuevoPagarSencillo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from DatosProsepago"
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

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        tim.Stop()

        Try
            grdComanda.Rows.Clear()
            sumacomandas = 0
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

    Private Sub frmNuevoPagarSencillo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        frmMesas.Close()
        frmMesas.Show()
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

    Private Sub txtDescuento_Click(sender As Object, e As EventArgs) Handles txtDescuento.Click
        txtDescuento.SelectionStart = 0
        txtDescuento.SelectionLength = Len(txtDescuento.Text)
        focomapeo = 2
    End Sub
    Private Sub txtEfectivo_TextChanged(sender As Object, e As EventArgs) Handles txtEfectivo.TextChanged
        If Not IsNumeric(txtEfectivo.Text) Then txtEfectivo.Text = "0.00" : Exit Sub
        If Strings.Left(txtEfectivo.Text, 1) = "," Or Strings.Left(txtEfectivo.Text, 1) = "." Then Exit Sub

        If idborrado = 0 Then
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", 0.00, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", 0.00, txtTransferencia.Text)) - txtPropina.Text)
        Else
            myope = txttotalpropina.Text
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

    Private Sub txtTarjeta_TextChanged(sender As Object, e As EventArgs) Handles txtTarjeta.TextChanged

        If Not IsNumeric(txtTarjeta.Text) Then txtTarjeta.Text = "0.00" : Exit Sub
        If Strings.Left(txtTarjeta.Text, 1) = "," Or Strings.Left(txtTarjeta.Text, 1) = "." Then Exit Sub

        If idborrado = 0 Then
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", 0.00, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", 0.00, txtTransferencia.Text)) - txtPropina.Text)
        Else
            myope = txttotalpropina.Text
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

    Private Sub txtTransferencia_TextChanged(sender As Object, e As EventArgs) Handles txtTransferencia.TextChanged

        If Not IsNumeric(txtTransferencia.Text) Then txtTransferencia.Text = "0.00" : Exit Sub
        If Strings.Left(txtTransferencia.Text, 1) = "," Or Strings.Left(txtTransferencia.Text, 1) = "." Then Exit Sub

        If idborrado = 0 Then
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", 0.00, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", 0.00, txtTransferencia.Text)) - txtPropina.Text)
        Else
            myope = txttotalpropina.Text
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
    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged

        If Not IsNumeric(txtDescuento.Text) Then txtDescuento.Text = "0.00" : Exit Sub
        If Strings.Left(txtDescuento.Text, 1) = "," Or Strings.Left(txtDescuento.Text, 1) = "." Then Exit Sub

        If txtDescuento.Text > 0 Then
            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text)
        Else
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
            Dim tarjetaventa As Double = IIf(txtTarjeta.Text = 0, 0, txtTarjeta.Text)
            Dim transferenciaventa As Double = IIf(txtTransferencia.Text = 0, 0, txtTransferencia.Text)
            Dim pagosventa As Double = CDbl(tarjetaventa) + CDbl(transferenciaventa)
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
                txtTarjeta.Text = "0.00"
                txtTransferencia.Text = "0.00"
            End If
            txtEfectivo.Focus.Equals(True)
            focomapeo = 1
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        idborrado = 1
        txtSubtotalmapeo.Text = FormatNumber(subtotalmapeo, 2)
        txtTotal.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        txttotalpropina.Text = FormatNumber(txtSubtotalmapeo.Text, 2)
        lblTotal.Text = FormatNumber(txtTotal.Text, 2)
        txtResta.Text = FormatNumber(txttotalpropina.Text, 2)

        txtEfectivo.Text = "0.00"
        txtTarjeta.Text = "0.00"
        txtTransferencia.Text = "0.00"
        txtDescuento.Text = "0.00"
        txtPorcentaje.Text = "0"
        txtCambio.Text = "0.00"
        txtPropina.Text = "0.00"

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

    Public Sub validaMontosTarjeta()
    End Sub

    Private Sub cboComanda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboComanda.SelectedValueChanged
        Try

            txtSubtotalmapeo.Text = "0.00"
            grdComanda.Rows.Clear()

            cnn2.Close() : cnn2.Open()
            cmd2 = cnn2.CreateCommand
            cmd2.CommandText = "SELECT * FROM Comandas WHERE Id='" & cboComanda.Text & "' AND NMESA='" & lblmesa.Text & "'"
            rd2 = cmd2.ExecuteReader
            Do While rd2.Read
                If rd2.HasRows Then

                    grdComanda.Rows.Add(rd2("IDC").ToString,
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
            grdComanda.Rows.Clear()

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Comandas WHERE Comensal='" & cboComensal.Text & "' AND NMESA='" & lblmesa.Text & "'"
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

    'Async Function EnviarSolicitudAPI() As Task

    '    ' Label1.Visible = True
    '    ' Valores a enviar a la API
    '    Dim TipoPlan As String = "00"
    '    Dim Terminal As String = numTerminal
    '    Dim Importe As String = validaTarjeta
    '    Dim pv As String = "DELSSCOM"
    '    Dim nombre As String = cboComensal.Text
    '    Dim concepto As String = "Venta"
    '    Dim referencia As String = lblfolio.Text & FormatDateTime(Date.Now, DateFormat.ShortDate) & FormatDateTime(Date.Now, DateFormat.ShortTime) ' se recomienda poner el folio de la venta y la fecha, asi me dijo el wey de procepago, dice que no se debe de repetir

    '    Dim correo As String = ""
    '    Dim membresia As String = "false"
    '    Dim clave As String = numClave

    '    Dim cadenatexto As String = TipoPlan & Terminal & Importe & nombre & concepto & referencia & correo & clave
    '    ' MsgBox(cadenatexto)
    '    Dim CadenaEncriptada As String = CalculateSHA1(cadenatexto)

    '    ' URL de la API
    '    Dim url As String = URLsolicitud

    '    ' Construye la solicitud HTTP
    '    Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
    '    request.Method = "POST"
    '    request.ContentType = "application/x-www-form-urlencoded"

    '    ' datos a enviar con metodo post
    '    Dim postData As String = $"&tipoPlan={TipoPlan}&terminal={Terminal}&importe={Importe}&nombre={nombre}&concepto={concepto}&referencia={referencia}&correo={correo}&pv={pv}&CadenaEncriptada={CadenaEncriptada}"
    '    'MsgBox(postData)
    '    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    '    request.ContentLength = byteArray.Length

    '    Try
    '        ' Aqui se activa el pago en la terminal
    '        Using dataStream As Stream = Await request.GetRequestStreamAsync()
    '            Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
    '        End Using


    '        ' Envía la solicitud y procesa la respuesta

    '        Dim response As WebResponse = Await request.GetResponseAsync()

    '        Using dataStream As Stream = response.GetResponseStream()
    '            Dim reader As New StreamReader(dataStream)
    '            Dim responseFromServer As String = Await reader.ReadToEndAsync()
    '            ' MessageBox.Show("Respuesta de la API: " & responseFromServer)
    '            valorxd = responseFromServer
    '            'Thread.Sleep(4000)
    '            EnviarSolicitudAPI2()
    '        End Using
    '    Catch ex As WebException
    '        MessageBox.Show("Error en la solicitud: " & ex.Message)
    '    End Try
    'End Function

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

    'Async Function EnviarSolicitudAPI2() As Task
    '    ' Valores a enviar a la API
    '    Dim idsolicitud As String = valorxd
    '    Dim clave As String = numClave

    '    ' Genera el hash SHA-1 de los valores
    '    Dim CadenaEncriptada As String = CalculateSHA1(idsolicitud & clave)

    '    ' URL de la API

    '    Dim url As String = URLresultado

    '    ' Construye la solicitud HTTP
    '    Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
    '    request.Method = "POST"
    '    request.ContentType = "application/x-www-form-urlencoded"

    '    ' Construye los datos a enviar en la solicitud
    '    Dim postData As String = $"&idsolicitud={idsolicitud}&cadenaEncriptada={CadenaEncriptada}"
    '    Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
    '    request.ContentLength = byteArray.Length

    '    ' Escribe los datos en el cuerpo de la solicitud

    '    Using dataStream As Stream = Await request.GetRequestStreamAsync()
    '        Await dataStream.WriteAsync(byteArray, 0, byteArray.Length)
    '    End Using


    '    ' Envía la solicitud y procesa la respuesta
    '    Try
    '        Dim response As WebResponse = Await request.GetResponseAsync()
    '        Using dataStream As Stream = response.GetResponseStream()
    '            Dim reader As New StreamReader(dataStream)
    '            Dim responseFromServer As String = Await reader.ReadToEndAsync()

    '            If responseFromServer = "901" Then
    '                EnviarSolicitudAPI2()
    '            End If

    '            Dim xmlDoc As New XmlDocument()
    '            xmlDoc.LoadXml(responseFromServer)
    '            Dim descripcionValue2 As String = ""
    '            ' Obtener el valor de la etiqueta <descripcion>
    '            Dim descripcionValue As String = xmlDoc.SelectSingleNode("/PVresultado/descripcion").InnerText
    '            If descripcionValue = "0" Then
    '            Else
    '                descripcionValue2 = xmlDoc.SelectSingleNode("/PVresultado/causaDenegada").InnerText
    '            End If

    '            If descripcionValue = "0" Then
    '                MsgBox("El proceso de la transacción no ah sido completado", vbCritical + vbOKOnly, "Operación Incomppleta")
    '                SiPago = 0
    '            ElseIf descripcionValue = "1" Then
    '                MsgBox("La operación es rechazada por el banco o cancelada por el usuario", vbCritical + vbOKOnly, "Operación Denegada")
    '                SiPago = 0
    '            ElseIf descripcionValue = "2" Then
    '                If descripcionValue2 = "Denegada, Saldo insuficiente" Then
    '                    MsgBox("Tarjeta Denegada, Saldo insuficiente", vbCritical + vbOKOnly, "Operación Fallida")
    '                    SiPago = 0
    '                Else
    '                    SiPago = 1
    '                    btnIntro.PerformClick()
    '                End If
    '            ElseIf descripcionValue = "3" Then
    '                MsgBox("Ya se llevo a cabo el proceso por parte de Pprosepago", vbInformation + vbOKOnly, "Operación Liquidada")
    '                SiPago = 0
    '            End If

    '            'MessageBox.Show("Respuesta de la API: " & responseFromServer)
    '        End Using
    '    Catch ex As WebException
    '        MessageBox.Show("Error en la solicitud: " & ex.Message)
    '    End Try
    'End Function

    Private Sub btnIntro_Click(sender As Object, e As EventArgs) Handles btnIntro.Click

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

            If Mid(pie1, 1, 36) <> "" Then
                e.Graphics.DrawString(Mid(pie1, 1, 36), fuente_r, Brushes.Black, 1, Y)
                Y += 12
            End If

            If Mid(pie1, 37, 72) <> "" Then
                e.Graphics.DrawString(Mid(pie1, 36, 72), fuente_r, Brushes.Black, 1, Y)
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
            cmd4.CommandText = "SELECT * FROM Comandas WHERE IDC=" & comandaeliminar & ""
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

    Private Sub pVentaMapeo80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVentaMapeo80.PrintPage
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



            'For deku As Integer = 0 To grdPagos.Rows.Count - 1

            '    Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
            '    Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
            '    Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
            '    Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString


            '    If formapago = "EFECTIVO" Then
            '    Else
            '        If formapago = "MONEDERO" Then

            '            e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
            '            e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            '            Y += 20

            '            'e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
            '            'e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 150, Y)
            '            'Y += 20
            '        Else
            '            If montopago > 0 Then
            '                e.Graphics.DrawString("PAGO EN " & formapago & ":", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 270, Y, derecha)
            '                Y += 20
            '                e.Graphics.DrawString("BANCO: ", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(bancopago, fuente_b, Brushes.Black, 100, Y)
            '                Y += 20
            '                e.Graphics.DrawString("NUM TARJ", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 100, Y)
            '                Y += 20
            '            End If
            '        End If
            '    End If

            'Next

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
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
            cnn2.Close()
            cnn3.Close()
            cnn4.Close()
        End Try
    End Sub

    Private Sub pVentaMapeo58_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pVentaMapeo58.PrintPage
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



            'For deku As Integer = 0 To grdPagos.Rows.Count - 1

            '    Dim formapago As String = grdPagos.Rows(deku).Cells(0).Value.ToString
            '    Dim bancopago As String = grdPagos.Rows(deku).Cells(1).Value.ToString
            '    Dim refenciapago As String = grdPagos.Rows(deku).Cells(2).Value.ToString
            '    Dim montopago As Double = grdPagos.Rows(deku).Cells(3).Value.ToString

            '    If formapago = "EFECTIVO" Then
            '    Else
            '        If formapago = "MONEDERO" Then

            '            e.Graphics.DrawString("MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
            '            e.Graphics.DrawString(FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            '            Y += 15

            '            'e.Graphics.DrawString("FOLIO DEL MONEDERO: ", fuente_b, Brushes.Black, 1, Y)
            '            'e.Graphics.DrawString(foliomonedero, fuente_b, Brushes.Black, 100, Y)
            '            'Y += 15
            '        Else
            '            If montopago > 0 Then
            '                e.Graphics.DrawString("PAGO EN " & formapago & ":", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(simbolo & " " & FormatNumber(montopago, 2), fuente_b, Brushes.Black, 180, Y, derecha)
            '                Y += 15
            '                e.Graphics.DrawString("BANCO: ", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(bancopago, fuente_b, Brushes.Black, 80, Y)
            '                Y += 15
            '                e.Graphics.DrawString("NUM TARJ", fuente_b, Brushes.Black, 1, Y)
            '                e.Graphics.DrawString(refenciapago, fuente_b, Brushes.Black, 80, Y)
            '                Y += 15
            '            End If
            '        End If
            '    End If


            'Next

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


            myope = IIf(txtTotal.Text = "", 0, txtTotal.Text) - (CDbl(IIf(txtEfectivo.Text = "", 0.00, txtEfectivo.Text)) + CDbl(IIf(txtTarjeta.Text = "", 0.00, txtTarjeta.Text)) + CDbl(IIf(txtTransferencia.Text = "", 0.00, txtTransferencia.Text)) - txtPropina.Text)

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
                Dim tarjeta As Double = IIf(txtTarjeta.Text = 0, 0, txtTarjeta.Text)
                Dim transferencia As Double = IIf(txtTransferencia.Text = 0, 0, txtTransferencia.Text)
                Dim pagos As Double = CDbl(tarjeta) + CDbl(transferencia)
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
                txtTarjeta.Text = "0.00"
                txtTransferencia.Text = "0.00"

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
        Dim tarjeta As Double = IIf(txtTarjeta.Text = "", 0, txtTarjeta.Text)
        Dim transferencia As Double = IIf(txtTransferencia.Text = "", 0, txtTransferencia.Text)
        Dim pagos As Double = CDbl(tarjeta) + CDbl(transferencia)
        Dim total As Double = IIf(txtTotal.Text = "", 0, txtTotal.Text)
        Dim subtotal As Double = IIf(txtSubtotalmapeo.Text = "", 0, txtSubtotalmapeo.Text)
        Dim sumapagos As Double = CDbl(efectivo) + CDbl(pagos)

        Dim saldo As Double = txtSubtotalmapeo.Text
        Dim porcentaje As Double = (txtPorcentaje.Text / 100)
        Dim porcentajetot As Double = CDbl(saldo) * CDbl(porcentaje)
        montopropina = IIf(txtDescuento.Text = "", 0, txtDescuento.Text)

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
        txtTransferencia.Text = "0.00"
        txtTarjeta.Text = "0.00"

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

            subb = CDec(txtTotal.Text) * 0.16
            cuenta = CDec(CDec(txtEfectivo.Text) + CDec(txtTarjeta.Text) + CDbl(txtTarjeta.Text)) - CDec(txtCambio.Text)

            subb = 0
            cuenta = FormatNumber(cuenta, 2)

            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText = "INSERT INTO Ventas(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,FVenta,HVenta,FPago,Status,Descuento,Comisionista,Concepto,MntoCortesia) values(" & IIf(VarId, 0, VarId) & ",'" & lblmesa.Text & "','',0," & subb & ",0," & cuenta & "," & txtResta.Text & ",'" & lblusuario2.Text & "','" & Format(Date.Now, "yyyy/MM/dd HH:mm:ss") & "','" & Format(Date.Now, "HH:mm:ss") & "','" & Format(Date.Now, "yyyy/MM/dd") & "','" & "PAGADO" & "',0,0,'" & "CORTESIA" & "'," & CDec(txtTotal.Text) & ")"
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
                cmd5.CommandText = "SELECT * FROM Productos WHERE Codigo='" & CODIG & "'"
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
                cmd1.CommandText = "INSERT INTO VentasDetalle(Codigo,Folio,Nombre,Unidad,Cantidad,CostoVUE,CostoVP,Precio,Total,PrecioSinIVA,TotalSinIVA,Fecha,Comisionista,Depto,Grupo,TotalIEPS,TasaIEPS) VALUES('" & CODIG & "'," & folio & ",'" & DESC1 & "','" & UDV & "'," & cant & "," & PUVCIVA & "," & CostVUE1 & "," & PUVCIVA & "," & TOTAL1 & "," & PrecioSinIVA1 & "," & TOTALSIVA & ",'" & Format(Date.Now, "yyyy/MM/dd") & "',0,'" & DEPA & "','" & GRUPO1 & "',0,0)"
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
            btnLimpiar.PerformClick()
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
                "select * from Ticket"
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
                "select * from Ticket"
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
        Dim tarjetaventa As Double = IIf(txtTarjeta.Text = "", 0, txtTarjeta.Text)
        Dim transferenciaventa As Double = IIf(txtTransferencia.Text = "", 0, txtTransferencia.Text)
        Dim pagosventa As Double = CDbl(tarjetaventa) + CDbl(transferenciaventa)
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
            txtTarjeta.Text = "0.00"
            txtTransferencia.Text = "0.00"
        End If
        focomapeo = 1
    End Sub

    Private Sub btn100_Click(sender As Object, e As EventArgs) Handles btn100.Click

    End Sub
End Class