Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Xml
Imports QRCoder
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

    End Sub
End Class