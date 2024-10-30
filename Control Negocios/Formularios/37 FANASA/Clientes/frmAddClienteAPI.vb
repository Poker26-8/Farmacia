Imports System.Net.Http


Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class frmAddClienteAPI
    Private Sub frmAddClienteAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Async Function RegistrarClientes5() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

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
                        ""birthDate"": """ & txtNacimiento.Text & """,
                        ""enrollmentChannel"": """ & txtInscripcion.Text & """,
                        ""email"": """ & txtEmail.Text & """,
                        ""sex"": """ & cboSex.Text & """,
                        ""status"": """ & cboStatus.Text & """,
                        ""contactType"": ""Paciente"",
                        ""segment"": ""MOSTRADOR"",
                        ""operativeUnit"": ""FANASA"",
                        ""pos"": ""SAV"",
                        ""phoneList"": {
                            ""phone"": [
                                {
                                    ""id"": """",
                                    ""phone"": """ & txtTelefono.Text & """,
                                    ""extension"": """ & txtExtension.Text & """,
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
                                    ""latitude"": " & txtLatitud.Text & ",
                                    ""longitude"": " & txtLongitud.Text & ",
                                    ""references"": null,
                                    ""isMainAddress"": true,
                                    ""type"": """ & cboTipoDir.Text & """,
                                    ""status"": """ & cboStatusDir.Text & """
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
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RegistrarClientes5()
    End Sub
End Class