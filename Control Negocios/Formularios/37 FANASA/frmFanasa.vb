Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class frmFanasa
    Private Sub frmFanasa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Async Function RegistrarSucursales() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/subsidiaries"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""subsidiaryId"": ""99998"",
            ""pos"": ""SAV, PHARMACYLITE, PHARMACYSOFT, STOKEWARE, ETC"",
            ""address"": ""TOLUCA"",
            ""status"": ""Activo"",
            ""token"": ""1235""
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
    Public Async Function ConsultaPrograma2() As Task


        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/programs/details?idProgram=529"

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
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    'Public Async Function ConsultaCliente4() As Task


    '    Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/contacts?origin=fanasa&idCRM=4954390"

    '    Dim usuario As String = "userTest"
    '    Dim contraseña As String = "Vwq5MYEUtesVwYtK"

    '    Using client As New HttpClient()
    '        ' Crear el encabezado de autenticación en Base64
    '        Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
    '        client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

    '        ' Realizar la solicitud GET
    '        Dim response As HttpResponseMessage = Await client.GetAsync(url)

    '        ' Verificar si la solicitud fue exitosa
    '        If response.IsSuccessStatusCode Then
    '            Dim responseData As String = Await response.Content.ReadAsStringAsync()
    '            MsgBox("Respuesta de la API: " & responseData)
    '        Else
    '            MsgBox("Error al consumir la API: " & response.ReasonPhrase)
    '        End If
    '    End Using
    'End Function

    Public Async Function ConsultaCliente4() As Task
        Dim origin As String = "fanasa"
        Dim idCRM As String = "4954390"


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
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

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
                        ""name"": ""ALECKS"",
                        ""lastName1"": ""GARCIA"",
                        ""lastName2"": ""ARELLANO"",
                        ""birthDate"": ""1999-10-10"",
                        ""enrollmentChannel"": ""99997"",
                        ""email"": ""alex2539@gmail.com"",
                        ""sex"": ""Masculino"",
                        ""status"": ""Activo"",
                        ""contactType"": ""Paciente"",
                        ""segment"": ""MOSTRADOR"",
                        ""operativeUnit"": ""FANASA"",
                        ""pos"": ""SAV"",
                        ""phoneList"": {
                            ""phone"": [
                                {
                                    ""id"": """",
                                    ""phone"": ""7226619871"",
                                    ""extension"": """",
                                    ""phoneType"": ""Celular"",
                                    ""status"": ""Activo"",
                                    ""mainPhone"": true
                                }
                            ]
                        },
                        ""addressList"": {
                            ""address"": [
                                {
                                    ""id"": """",
                                    ""street"": ""1"",
                                    ""externalNum"": ""1"",
                                    ""internalNum"": """",
                                    ""suburb"": ""1"",
                                    ""cityHall"": ""1"",
                                    ""city"": ""CDMX"",
                                    ""state"": ""CIUDAD DE MEXICO"",
                                    ""country"": ""MX"",
                                    ""zipCode"": ""44670"",
                                    ""latitude"": 19.7071694,
                                    ""longitude"": -103.4654868,
                                    ""references"": null,
                                    ""isMainAddress"": true,
                                    ""type"": ""Envíos"",
                                    ""status"": ""Activo""
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

    Public Async Function ValidarTarjeta6() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/cards"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)
            Dim xd As String = "132245"
            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""transaction"": ""COT869439"",
            ""segment"": ""MOSTRADOR"",
            ""subSegment"": ""MOSTRADOR"",
            ""operativeUnit"": ""FANASA"",
            ""subsidiaryId"": ""99997"",
            ""user"": ""alecks.garcia"",
            ""folio"": ""4954390"",
            ""programData"": {
                ""id"": ""529"",
                ""type"": ""Laboratorios exclusivos""
            },
            ""laboratory"": ""Varios"",
            ""channel"": ""Sucursal"",
            ""pos"": ""SAV""
        }"

            ' Crear el contenido para el POST con JSON
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Realizar la solicitud POST
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

            ' Verificar si la solicitud fue exitosa
            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Public Async Function obtenerbeneficios7() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/gifts"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""transaction"": ""COT869439"",
            ""programData"": {
                ""id"": ""529"",
                ""type"": ""Laboratorios exclusivos""
            },
            ""subsidiaryId"": ""99997"",
            ""user"": ""alecks.garcia"",
            ""cardAuthNum"": ""1943771"",
            ""folio"": ""4954390"",
            ""channel"": ""99997"",
            ""level1"": ""0"",
            ""level2"": ""0"",
            ""itemList"": {
                ""item"": [
                    {
                        ""sku"": ""7501125189111"",
                        ""quantity"": ""1"",
                        ""originQuantity"": ""1"",
                        ""unitPrice"": ""1000""
                    }
                ]
            }
        }"

            ' Crear el contenido para el POST con JSON
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Realizar la solicitud POST
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

            ' Verificar si la solicitud fue exitosa
            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Public Async Function AplicarVenta8() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/sales"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""transaction"": ""COT-35635"",
            ""programData"": {
                ""id"": ""529"",
                ""type"": ""Laboratorios exclusivos""
            },
            ""user"": ""alecks.garcia"",
            ""cardAuthNum"": ""1943771"",
            ""giftAuthNum"": ""56156735"",
            ""itemList"": {
                ""item"": [
                    {
                        ""sku"": ""7501125189111"",
                        ""quantity"": 3,
                        ""originQuantity"": 3,
                        ""unitPrice"": 1000
                    }
                ]
            },
            ""giftList"": {
                ""combo"": [
                    {
                        ""idCombo"": ""1"",
                        ""giftType"": ""Pieza"",
                        ""selection"": ""Todos"",
                        ""skuPurchase"": ""7501125189111"",
                        ""giftItemList"": {
                            ""giftItem"": [
                                {
                                    ""sku"": ""7501125189111"",
                                    ""discount"": 0,
                                    ""minGiftPieces"": 1,
                                    ""maxGiftPieces"": 1
                                }
                            ]
                        }
                    }
                ]
            }
        }"

            ' Crear el contenido para el POST con JSON
            Dim content As New StringContent(jsonData, Encoding.UTF8, "application/json")

            ' Realizar la solicitud POST
            Dim response As HttpResponseMessage = Await client.PostAsync(url, content)

            ' Verificar si la solicitud fue exitosa
            If response.IsSuccessStatusCode Then
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Public Async Function CancelarVenta9() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/sales"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""transaction"": ""COT-35635"",
            ""user"": ""alecks.garcia"",
            ""cardAuthNum"": ""1943771"",
            ""giftAuthNum"": ""56156735""
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

    Public Async Function RechazarBeneficios10() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/gifts"
        Dim usuario As String = "userTest"
        Dim contraseña As String = "Vwq5MYEUtesVwYtK"

        Using client As New HttpClient()
            ' Crear el encabezado de autenticación en Base64
            Dim credenciales As String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{usuario}:{contraseña}"))
            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Basic", credenciales)

            ' Crear el contenido JSON con los datos proporcionados
            Dim jsonData As String = "{
            ""transaction"": ""COT-35635"",
            ""cardAuthNum"": ""1943771"",
            ""giftAuthNum"": ""56156735"",
            ""giftList"": {
                ""combo"": [
                    {
                        ""idCombo"": ""1"",
                        ""giftItemList"": {
                            ""giftItem"": [
                                {
                                    ""sku"": ""7501089801173"",
                                    ""minGiftPieces"": 1
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

    Public Async Function ReglasdelProducto11() As Task
        Dim idProgram As String = "529"
        Dim idCX As String = "4954390"
        Dim url As String = $"https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/products/rules?idProgram={idProgram}&idCX={idCX}"

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
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Public Async Function DetalleProducto12() As Task
        Dim idProgram As String = "529"
        Dim idCX As String = "3985009"
        Dim sku As String = "7501125189111"
        Dim url As String = $"https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/products/details?idProgram={idProgram}&idCX={idCX}"

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
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function


    Public Async Function ConsultarSaldo13() As Task
        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/balances/99997?&pos=SAV"
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
                Dim responseData As String = Await response.Content.ReadAsStringAsync()
                MsgBox("Respuesta de la API: " & responseData)
            Else
                MsgBox("Error al consumir la API: " & response.ReasonPhrase)
            End If
        End Using
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ValidarTarjeta6()
    End Sub
End Class