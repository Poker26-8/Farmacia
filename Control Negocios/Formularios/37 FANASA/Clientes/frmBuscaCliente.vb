Imports Newtonsoft.Json.Linq
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json


Public Class frmBuscaCliente
    Private Sub frmBuscaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFolio.Focus.Equals(True)
        My.Application.DoEvents()
    End Sub

    Private Sub frmBuscaCliente_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtFolio.Focus.Equals(True)
        My.Application.DoEvents()
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtFolio.Text = "" Then
                txtNombre.Focus.Equals(True)
            Else
                txtFolio.Enabled = False
                My.Application.DoEvents()
                ConsultaClienteID()
                txtFolio.Focus.Equals(True)
            End If
        End If
    End Sub
    Public Async Function ConsultaCliente() As Task
        Try

            Dim origin As String = "fanasa"
            Dim nombrexd As String = txtNombre.Text
            Dim paternoxd As String = txtPaterno.Text
            Dim telefonoxd As String = txtTelefono.Text



            Dim url As String = $"https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts?origin={origin}&name={nombrexd}&lastName1={paternoxd}&phone={telefonoxd}"

            Dim usuario As String = "userTest"
            Dim contraseña As String = "Vwq5MYEUtesVwYtK"

            Using client As New HttpClient()
                ' Crear el encabezado de autenticación en Base64
                Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
                client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

                ' Realizar la solicitud GET
                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    grdcaptura.Rows.Clear()
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()

                    Dim jsonResponse As JObject = JObject.Parse(responseData)
                    For Each contact In jsonResponse("contact")
                        Dim idCRM2 As String = contact?("generalData")?("idCRM")?.ToString()
                        Dim nombre As String = contact?("generalData")?("name")?.ToString()
                        Dim paterno As String = contact?("generalData")?("lastName1")?.ToString()
                        Dim materno As String = contact?("generalData")?("lastName2")?.ToString()
                        Dim nacimiento As String = contact?("generalData")?("birthDate")?.ToString()
                        'Dim cp As String = ""
                        'If contact?("addressList") IsNot Nothing AndAlso TypeOf contact("addressList")("address") Is JArray AndAlso contact("addressList")("address").Count > 0 Then
                        '    cp = contact("addressList")("address")(0)?("zipCode")?.ToString()
                        'End If

                        Dim cp As String = contact?("addressList")?("address")?(0)?("zipCode")?.ToString()
                        Dim email As String = contact?("emailList")?("email")?(0)?.ToString()
                        Dim telefono As String = contact?("phoneList")?("phone")?(0)?("phone")?.ToString()

                        ' Agregar la fila al DataGridView
                        grdcaptura.Rows.Add(nombre, paterno, materno, nacimiento, cp, telefono, email, idCRM2)
                        My.Application.DoEvents()
                    Next
                Else
                    MsgBox("Cliente no encontrado", vbExclamation + vbOKOnly, "Delsscom Farmacias")
                End If
            End Using
            My.Application.DoEvents()
            txtFolio.Enabled = True
            txtFolio.Focus.Equals(True)
            btnBuscar.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function
    Public Async Function ConsultaClienteSinTelefono() As Task
        Try

            Dim origin As String = "fanasa"
            Dim nombrexd As String = txtNombre.Text
            Dim paternoxd As String = txtPaterno.Text



            Dim url As String = $"https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts?origin={origin}&name={nombrexd}&lastName1={paternoxd}"

            Dim usuario As String = "userTest"
            Dim contraseña As String = "Vwq5MYEUtesVwYtK"

            Using client As New HttpClient()
                ' Crear el encabezado de autenticación en Base64
                Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
                client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

                ' Realizar la solicitud GET
                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    grdcaptura.Rows.Clear()
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()
                    Dim jsonResponse As JObject = JObject.Parse(responseData)
                    For Each contact In jsonResponse("contact")
                        Dim idCRM2 As String = contact?("generalData")?("idCRM")?.ToString()
                        Dim nombre As String = contact?("generalData")?("name")?.ToString()
                        Dim paterno As String = contact?("generalData")?("lastName1")?.ToString()
                        Dim materno As String = contact?("generalData")?("lastName2")?.ToString()
                        Dim nacimiento As String = contact?("generalData")?("birthDate")?.ToString()
                        Dim cp As String = contact.SelectToken("addressList.address[0].zipCode")?.ToString()
                        If String.IsNullOrEmpty(cp) Then
                            cp = ""
                        End If

                        'Dim cp As String = contact?("addressList")?("address")?(0)?("zipCode")?.ToString()
                        Dim email As String = contact?("emailList")?("email")?(0)?.ToString()
                        Dim telefono As String = contact?("phoneList")?("phone")?(0)?("phone")?.ToString()

                        ' Agregar la fila al DataGridView
                        grdcaptura.Rows.Add(nombre, paterno, materno, nacimiento, cp, telefono, email, idCRM2)
                        My.Application.DoEvents()
                    Next
                Else
                    MsgBox("Cliente no encontrado", vbExclamation + vbOKOnly, "Delsscom Farmacias")
                End If
            End Using
            My.Application.DoEvents()
            txtFolio.Enabled = True
            txtFolio.Focus.Equals(True)
            btnBuscar.Enabled = True
        Catch ex As Exception
            btnBuscar.Enabled = True
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Public Async Function ConsultaClienteID() As Task
        Try


            Dim origin As String = "fanasa"
            Dim idCRM As String = txtFolio.Text



            Dim url As String = $"https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts?origin={origin}&idCRM={idCRM}"

            Dim usuario As String = "userTest"
            Dim contraseña As String = "Vwq5MYEUtesVwYtK"

            Using client As New HttpClient()
                ' Crear el encabezado de autenticación en Base64
                Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
                client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

                ' Realizar la solicitud GET
                Dim response As HttpResponseMessage = Await client.GetAsync(url)

                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    grdcaptura.Rows.Clear()
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()

                    Dim jsonResponse As JObject = JObject.Parse(responseData)
                    Dim idCRM2 As String = jsonResponse("contact")?(0)?("generalData")?("idCRM")?.ToString()
                    Dim nombre As String = jsonResponse("contact")?(0)?("generalData")?("name")?.ToString()
                    Dim paterno As String = jsonResponse("contact")?(0)?("generalData")?("lastName1")?.ToString()
                    Dim materno As String = jsonResponse("contact")?(0)?("generalData")?("lastName2")?.ToString()
                    Dim nacimiento As String = jsonResponse("contact")?(0)?("generalData")?("birthDate")?.ToString()
                    Dim cp As String = jsonResponse("contact")?(0)?("addressList")?("address")?(0)?("zipCode")?.ToString()
                    Dim email As String = jsonResponse("contact")?(0)?("emailList")?("email")?(0)?.ToString()
                    Dim telefono As String = jsonResponse("contact")?(0)?("phoneList")?("phone")?(0)?("phone")?.ToString()
                    My.Application.DoEvents()
                    grdcaptura.Rows.Add(nombre, paterno, materno, nacimiento, cp, telefono, email, idCRM2)
                    My.Application.DoEvents()
                Else
                    MsgBox("Error al consumir la API: " & response.ReasonPhrase)
                End If
            End Using
            txtFolio.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            txtFolio.Enabled = True
            btnBuscar.Enabled = True
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtNombre.Text = "" Then
            MsgBox("Ingresa el Nombre para continuar con la busqueda", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtNombre.Focus.Equals(True)
            Exit Sub
        End If
        If txtPaterno.Text = "" Then
            MsgBox("Ingresa el Apellido Paterno para continuar con la busqueda", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtPaterno.Focus.Equals(True)
            Exit Sub
        End If
        If txtTelefono.Text = "" Then
            My.Application.DoEvents()
            btnBuscar.Enabled = False
            ConsultaClienteSinTelefono()
        Else
            My.Application.DoEvents()
            btnBuscar.Enabled = False
            ConsultaCliente()
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            btnBuscar.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtNombre.Text = "" Then
                txtNombre.Focus.Equals(True)
                Exit Sub
            End If
            txtPaterno.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPaterno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaterno.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtPaterno.Text = "" Then
                txtPaterno.Focus.Equals(True)
                Exit Sub
            End If
            txtTelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        grdcaptura.Rows.Clear()
        txtFolio.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtTelefono.Text = ""
        txtFolio.Focus.Equals(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmNuevoCliente.Show()
        frmNuevoCliente.BringToFront()
    End Sub

    Private Async Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        If grdcaptura.Rows.Count = 0 Then
            Exit Sub
        End If
        My.Application.DoEvents()
        Dim index As Integer = grdcaptura.CurrentRow.Index
        If vienede = "Ventas1" Then

        ElseIf vienede = "Ventas2" Then

        ElseIf vienede = "Ventas3" Then
            frmVentas3.cboNombre.Text = grdcaptura.Rows(index).Cells(0).Value.ToString & " " & grdcaptura.Rows(index).Cells(1).Value.ToString & " "
            frmVentas3.lblidcmr.Text = grdcaptura.Rows(index).Cells(7).Value.ToString
            frmVentas3.txttel.Text = grdcaptura.Rows(index).Cells(5).Value.ToString
            frmVentas3.Label49.Visible = True
            My.Application.DoEvents()
            frmVentas3.Show()
            frmVentas3.BringToFront()
            My.Application.DoEvents()
            '  Await LlamarValidacionTarjeta()
            frmVentas3.btniniciar.PerformClick()
            Me.Close()
        End If
    End Sub

End Class