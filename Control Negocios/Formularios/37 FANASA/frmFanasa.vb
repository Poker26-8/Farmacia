Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class frmFanasa
    Private Sub frmFanasa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsumirAPIAsync2()
    End Sub


    Public Async Function ConsumirAPIAsync2() As Task

        Dim url As String = "https://tsoagobiernogrfe-pub-oci.opc.oracleoutsourcing.com/Farmacos/Programs/LoyaltyFanFanasa/v2/cards"

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
End Class