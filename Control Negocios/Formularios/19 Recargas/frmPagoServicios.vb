Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Text.RegularExpressions

Public Class frmPagoServicios
    Private Sub frmPagoServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recargaaaAsync()
    End Sub
    Public Async Function recargaaaAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/consultarSaldos"

            Dim parametros As New Dictionary(Of String, String)()
            parametros.Add("cuenta", varnumero)
            parametros.Add("usuario", varusuario)
            parametros.Add("password", varcontra)

            Dim contenido As New FormUrlEncodedContent(parametros)

            Try
                Dim respuesta As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, contenido)

                If respuesta.IsSuccessStatusCode Then
                    Dim respuestaComoTexto As String = Await respuesta.Content.ReadAsStringAsync()
                    Dim jsonParsed As JObject = JObject.Parse(respuestaComoTexto)
                    Dim jsonObject As JObject = JObject.Parse(respuestaComoTexto)
                    Dim errorValue As Integer = CInt(jsonObject("error"))
                    Dim messageValue As String = jsonObject("message").ToString()

                    If errorValue = 0 Then
                        Dim tiempo As String = jsonParsed("data")("tiempoaire").ToString()
                        Dim servi As String = jsonParsed("data")("pagoservicios").ToString()
                        lblSaldo.Text = servi
                        insertaRecargasAsync()
                    Else
                        MsgBox(messageValue, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                        Me.Close()
                    End If
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function

    Public Async Function insertaRecargasAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/obtenerServicios"

            Dim parametros As New Dictionary(Of String, String)()
            parametros.Add("cuenta", varnumero)
            parametros.Add("usuario", varusuario)
            parametros.Add("password", varcontra)
            Dim contenido As New FormUrlEncodedContent(parametros)
            Try
                Dim respuesta As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, contenido)
                If respuesta.IsSuccessStatusCode Then
                    Dim respuestaComoTexto As String = Await respuesta.Content.ReadAsStringAsync()
                    MostrarJSONEnComboBox(respuestaComoTexto)
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function

    Private Sub MostrarJSONEnComboBox(jsonString As String)
        Try
            Dim match As Match = Regex.Match(jsonString, "\[{.*}\]")
            If match.Success Then

                Dim dataSection As String = match.Value
                Dim listaDatos As List(Of Object) = JsonConvert.DeserializeObject(Of List(Of Object))(dataSection)
                eliminarecargas()
                For Each item In listaDatos
                    Dim valor1 As String = item("nombre").ToString()
                    Dim valor2 As String = item("codigo").ToString()
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Insert into Servicios(Nombre,Codigo) values('" & valor1 & "','" & valor2 & "')"
                    cmd1.ExecuteNonQuery()
                    cnn1.Close()
                Next
                My.Application.DoEvents()
            Else
                MsgBox("No se encontró la sección de datos en la respuesta JSON.")
            End If
        Catch ex As Exception
            MsgBox("Error al procesar la respuesta JSON: " & ex.Message)
        End Try
    End Sub
    Public Sub eliminarecargas()
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Delete from Servicios"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboServicio_DropDown(sender As Object, e As EventArgs) Handles cboServicio.DropDown
        Try
            cboServicio.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Servicios where nombre<>'' order by Nombre"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboServicio.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo from Servicios where Nombre='" & cboServicio.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                lblCodigo.Text = rd1(0).ToString
                txtReferencia.Focus.Equals(True)
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtReferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReferencia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtReferencia.Text = "" Then
                Exit Sub
            Else
                txtMonto.Focus.Equals(True)
            End If
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtMonto.Text = "" Then
                Exit Sub
            Else
                btnPagar.Focus.Equals(True)
            End If
        End If
    End Sub

    Public Async Function reservarServicioAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/reservarTransaccion"

            Dim parametros As New Dictionary(Of String, String)()
            parametros.Add("cuenta", varnumero)
            parametros.Add("usuario", varusuario)
            parametros.Add("password", varcontra)
            parametros.Add("referencia", txtReferencia.Text)
            parametros.Add("producto", lblCodigo.Text)
            parametros.Add("monto", txtMonto.Text)

            Dim contenido As New FormUrlEncodedContent(parametros)

            Try
                Dim respuesta As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, contenido)
                If respuesta.IsSuccessStatusCode Then
                    Dim respuestaComoTexto As String = Await respuesta.Content.ReadAsStringAsync()
                    Dim jsonParsed As JObject = JObject.Parse(respuestaComoTexto)
                    'MsgBox(respuestaComoTexto)
                    Dim requestID As String = jsonParsed("data")("requestid").ToString()
                    Dim nuevoFormato As String = "[{""valor"": """ & requestID & """}]"
                    MostrarJSONReservaServicio(nuevoFormato)
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function
    Private Sub MostrarJSONReservaServicio(jsonStringg As String)
        Try
            Dim match As Match = Regex.Match(jsonStringg, "\[{.*}\]")
            If match.Success Then
                Dim dataSection As String = match.Value
                Dim listaDatos As List(Of Object) = JsonConvert.DeserializeObject(Of List(Of Object))(dataSection)
                For Each item In listaDatos
                    ' Supongamos que el campo que deseas mostrar se llama "valor" en el JSON
                    Dim valor1 As String = item("valor").ToString()
                    lblrequest.Text = valor1
                    My.Application.DoEvents()
                    pagarServicioAsync()
                Next
            Else
                MsgBox("No se encontró la sección de datos en la respuesta JSON.")
            End If
        Catch ex As Exception
            MsgBox("Error al procesar la respuesta JSON: " & ex.Message)
        End Try
    End Sub

    Public Async Function pagarServicioAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/procesarTransaccion"

            Dim parametros As New Dictionary(Of String, String)()
            parametros.Add("cuenta", varnumero)
            parametros.Add("usuario", varusuario)
            parametros.Add("password", varcontra)
            parametros.Add("requestid", lblrequest.Text)

            Dim contenido As New FormUrlEncodedContent(parametros)
            Try
                Dim respuesta As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, contenido)
                If respuesta.IsSuccessStatusCode Then
                    Dim respuestaComoTexto As String = Await respuesta.Content.ReadAsStringAsync()
                    Dim jsonParsed As JObject = JObject.Parse(respuestaComoTexto)
                    Dim requestID As String = jsonParsed("data")("requestid").ToString()
                    MsgBox("Pago de servicio realizado Correctamente", vbInformation + vbOKOnly, "Delsscom Control Negocios PRO")
                    finaliza()
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function

    Private Sub btnPagar_Click(sender As Object, e As EventArgs) Handles btnPagar.Click
        reservarServicioAsync()
    End Sub
    Public Sub limpiaTodo()
        cboServicio.Text = ""
        txtMonto.Text = "0"
        txtReferencia.Text = ""
        lblrequest.Text = ""
        lblCodigo.Text = ""
    End Sub
    Private Sub Formulario1_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Lógica que se ejecutará cuando se presione una tecla en el TextBox de Formulario1
        MessageBox.Show("Se ha activado el evento KeyPress del TextBox en Formulario1 desde Formulario2")
    End Sub

    Public Sub finaliza()

        frmVentas1.cbocodigo.Text = "COMISI"
        frmVentas1.cbodesc.Text = "COMISION PAGO DE SERVICIOS"
        frmVentas1.txtunidad.Text = "SERV"
        frmVentas1.txtcantidad.Text = "1"
        frmVentas1.txtprecio.Text = "10"
        frmVentas1.txtexistencia.Text = "0"
        frmVentas1.txtprecio.Focus.Equals(True)
        My.Application.DoEvents()
        frmVentas1.txtprecio.Focus.Equals(True)
        frmVentas1.txtprecio_KeyPress(frmVentas1.txtprecio, New KeyPressEventArgs(ChrW(Keys.Enter)))

        frmVentas1.cbocodigo.Text = "PAGOSE"
        frmVentas1.cbodesc.Text = "PAGO DE SERVICIOS"
        frmVentas1.txtunidad.Text = "SERV"
        frmVentas1.txtcantidad.Text = "1"
        frmVentas1.txtprecio.Text = txtMonto.Text
        frmVentas1.txtexistencia.Text = "0"
        frmVentas1.txtprecio.Focus.Equals(True)
        My.Application.DoEvents()
        frmVentas1.txtprecio.Focus.Equals(True)
        frmVentas1.txtprecio_KeyPress(frmVentas1.txtprecio, New KeyPressEventArgs(ChrW(Keys.Enter)))
        My.Application.DoEvents()

        limpiaTodo()
        recargaaaAsync()
        Me.Close()
    End Sub
End Class