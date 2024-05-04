Imports System.Net.Http
Imports Newtonsoft.Json
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq
Public Class frmRecargas
    Public Sub limpiaTodo()
        cboCompañia.Text = ""
        cboTipo.Text = ""
        txtTel1.Text = ""
        txtTel2.Text = ""
        lblrequest.Text = ""
        lblCodigo.Text = ""
        lblMonto.Text = "0"
    End Sub
    Public Async Function recargaaaxdAsync() As Threading.Tasks.Task
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
                        lblSaldo.Text = tiempo
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
    Private Sub cboCompañia_DropDown(sender As Object, e As EventArgs) Handles cboCompañia.DropDown
        Try
            cboCompañia.Items.Clear()
            cboTipo.Text = ""
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Nombre from Recargas where Nombre<>'' order by Nombre asc"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboCompañia.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboTipo_DropDown(sender As Object, e As EventArgs) Handles cboTipo.DropDown
        Try
            cboTipo.Items.Clear()
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select distinct Descripcion from Recargas where Nombre='" & cboCompañia.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                cboTipo.Items.Add(rd1(0).ToString)
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboCompañia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCompañia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipo.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTel1.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTel1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtTel1.Text = "" Then Exit Sub
            txtTel2.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTel2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTel2.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtTel2.Text = "" Then Exit Sub
            btnRecargar.Focus.Equals(True)
        End If
    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        If cboCompañia.Text = "" Then MsgBox("Selecciona la Compañia para continuar", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : cboCompañia.Focus.Equals(True) : Exit Sub
        If cboTipo.Text = "" Then MsgBox("Selecciona el tipo de recarga para continuar", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : cboTipo.Equals(True) : Exit Sub
        If txtTel1.Text.Length <> 10 Then MsgBox("El número de télefono debe de ser de 10 digitos", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtTel1.Focus.Equals(True) : Exit Sub
        If txtTel2.Text.Length <> 10 Then MsgBox("El número de télefono debe de ser de 10 digitos", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtTel2.Focus.Equals(True) : Exit Sub
        If txtTel1.Text = "" Then MsgBox("Ingresa el número de télefono para continuar", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtTel1.Focus.Equals(True) : Exit Sub
        If txtTel2.Text = "" Then MsgBox("Confirma el número de telefono para continuar", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtTel2.Focus.Equals(True) : Exit Sub
        If txtTel1.Text <> txtTel2.Text Then MsgBox("Los número de télefono ingresados no coinciden", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtTel1.Focus.Equals(True) : Exit Sub
        If MsgBox("¿Deseas realizar la recarga telefonica con los datos ingresados?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
            Exit Sub
        Else
            varcompañia = cboCompañia.Text
            varmonto = lblMonto.Text
            vartelefono = txtTel1.Text
            reservarRecargaAsync()
        End If
    End Sub

    Private Sub cboTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedValueChanged
        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select Codigo, Monto from Recargas where Nombre='" & cboCompañia.Text & "' and Descripcion='" & cboTipo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                lblCodigo.Text = rd1(0).ToString
                lblMonto.Text = rd1(1).ToString
            Else
                MsgBox("Tipo de recarga no encontrada, revisa la información", vbCritical + vbOKOnly, "Delsscom Control Negocios")
                rd1.Close()
                cnn1.Close()
                Exit Sub
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub
    Public Async Function insertaRecargasAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/obtenerProductos"

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
                    Dim valor3 As String = item("descripcion").ToString()
                    Dim valor4 As String = item("monto").ToString()
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Insert into Recargas(Nombre,Codigo,Descripcion,Monto) values('" & valor1 & "','" & valor2 & "','" & valor3 & "','" & valor4 & "')"
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
            cmd1.CommandText = "Delete from Recargas"
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub frmRecargas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recargaaaxdAsync()
    End Sub
    Public Async Function reservarRecargaAsync() As Threading.Tasks.Task
        Using httpClient As New HttpClient()
            Dim apiUrl As String = "https://app.sivetel.com/ApiWS/reservarTransaccion"

            Dim parametros As New Dictionary(Of String, String)()
            parametros.Add("cuenta", varnumero)
            parametros.Add("usuario", varusuario)
            parametros.Add("password", varcontra)
            parametros.Add("numero", txtTel1.Text)
            parametros.Add("producto", lblCodigo.Text)

            Dim contenido As New FormUrlEncodedContent(parametros)

            Try
                Dim respuesta As HttpResponseMessage = Await httpClient.PostAsync(apiUrl, contenido)
                If respuesta.IsSuccessStatusCode Then
                    Dim respuestaComoTexto As String = Await respuesta.Content.ReadAsStringAsync()
                    Dim jsonParsed As JObject = JObject.Parse(respuestaComoTexto)
                    Dim jsonObject As JObject = JObject.Parse(respuestaComoTexto)
                    Dim errorValue As Integer = CInt(jsonObject("error"))
                    Dim messageValue As String = jsonObject("message").ToString()
                    'MsgBox(respuestaComoTexto)
                    If errorValue = 0 Then
                        Dim requestID As String = jsonParsed("data")("requestid").ToString()
                        lblrequest.Text = requestID
                        varfolrecarga = requestID
                        realizarRecargaAsync()
                    Else
                        MsgBox(messageValue, vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function

    Public Async Function realizarRecargaAsync() As Threading.Tasks.Task
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
                    'MsgBox(respuestaComoTexto)
                    finaliza()
                Else
                    MsgBox("Error: " & respuesta.StatusCode.ToString())
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        End Using
    End Function

    Public Sub finaliza()
        frmVentas1.cbocodigo.Text = "RECARG"
        frmVentas1.cbodesc.Text = "Recarga telefonica"
        frmVentas1.txtunidad.Text = "SERV"
        frmVentas1.txtcantidad.Text = "1"
        frmVentas1.txtprecio.Text = lblMonto.Text
        frmVentas1.txtexistencia.Text = "0"
        frmVentas1.txtprecio.Focus.Equals(True)
        My.Application.DoEvents()
        limpiaTodo()
        recargaaaxdAsync()
        Me.Close()
    End Sub

    Private Sub cboCompañia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCompañia.SelectedValueChanged
        'If cboCompañia.Text = "Telcel" Then
        '    PictureBox1.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\logos\" & cboCompañia.Text & ".jpg")
        'End If
        'If cboCompañia.Text = "Movistar" Then
        '    PictureBox1.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\logos\" & cboCompañia.Text & ".png")
        'End If
        'If cboCompañia.Text = "Nextel - ATT" Then
        '    PictureBox1.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\logos\" & cboCompañia.Text & ".png")
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRecargaC.Show()
    End Sub
End Class