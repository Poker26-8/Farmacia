Imports DocumentFormat.OpenXml.Drawing
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks

Public Class frmNuevoCliente
    Private Sub frmNuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegistrarClientes5()
    End Sub

    Public Async Function RegistrarClientes5() As Task
        Try


            Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts"
            Dim usuario As String = "userTest"
            Dim contraseña As String = "Vwq5MYEUtesVwYtK"
            Dim fechamal As Date =txtNacimiento.Text
            Dim fechaformateada As String = Format(fechamal, "yyyy-MM-dd")

            Using client As New HttpClient()
                ' Crear el encabezado de autenticación en Base64
                Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
                client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

                ' Crear el contenido JSON con los datos proporcionados
                Dim jsonData As String = "{
            ""contactList"": {
                ""contact"": [
                    {
                        ""origin"": ""fanasa"",
                        ""idCRM"": """",
                        ""name"": """ & txtNombre.Text & """,
                        ""lastName1"": """ & txtApellido1.Text & """,
                        ""lastName2"": """ & txtApellido2.Text & """,
                        ""birthDate"": """ & fechaformateada & """,
                        ""enrollmentChannel"": ""99997"",
                        ""email"": """ & txtEmail.Text & """,
                        ""sex"": """ & cboSex.Text & """,
                        ""status"": """ & cboStatusTel.Text & """,
                        ""contactType"": ""Paciente"",
                        ""segment"": ""MOSTRADOR"",
                        ""operativeUnit"": ""FANASA"",
                        ""pos"": ""SAV"",
                        ""phoneList"": {
                            ""phone"": [
                                {
                                    ""id"": """",
                                    ""phone"": """ & txtTelefono.Text & """,
                                    ""extension"": """",
                                    ""phoneType"": """ & cboTipoTel.Text & """,
                                    ""status"": """ & cboStatusTel.Text & """,
                                    ""mainPhone"": true
                                }
                            ]
                        },
                        ""addressList"": {
                            ""address"": [
                                {
                                    ""id"": """",
                                    ""street"": """ & txtCalle.Text & """,
                                    ""externalNum"": """ & txtExtDir.Text & """,
                                    ""internalNum"": """ & txtIntDir.Text & """,
                                    ""suburb"": """ & txtColonia.Text & """,
                                    ""cityHall"": """ & txtDelegacion.Text & """,
                                    ""city"": """ & txtCiudad.Text & """,
                                    ""state"": """ & cboEstado.Text & """,
                                    ""country"": """ & txtPais.Text & """,
                                    ""zipCode"": """ & txtCpDir.Text & """,
                                    ""latitude"": 19.7071694,
                                    ""longitude"": -103.4654868,
                                    ""references"": null,
                                    ""isMainAddress"": true,
                                    ""type"": """ & cboTipoDir.Text & """,
                                    ""status"": """ & cboStatusTel.Text & """
                                }
                            ]
                        }
                    }
                ]
            }
        }"

                ' Crear el contenido para el PUT con JSON
                Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

                ' Realizar la solicitud PUT
                Dim response As HttpResponseMessage = Await client.PutAsync(url, content)

                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()
                    MsgBox("Respuesta de la API: " & responseData)

                    Dim jsonObject As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData)
                    Dim detail As String = jsonObject("detail").ToString()
                    txtTarjeta.Text = detail
                    My.Application.DoEvents()
                Else
                    MsgBox("Error al consumir la API: " & response.ReasonPhrase)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtCpDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCpDir.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class