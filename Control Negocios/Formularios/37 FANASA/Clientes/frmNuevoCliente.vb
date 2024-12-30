Imports Core.Common
Imports DocumentFormat.OpenXml.Drawing
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading.Tasks

Public Class frmNuevoCliente
    Private Sub frmNuevoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function EsCorreoValido(ByVal correo As String) As Boolean
        ' Expresión regular para validar un correo electrónico
        Dim patron As String = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"
        Dim regex As New Regex(patron)
        Return regex.IsMatch(correo)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtNombre.Text = "" Then
            MsgBox("ingresa el nombre para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtNombre.Focus.Equals(True)
            Exit Sub
        End If
        If txtApellido1.Text = "" Then
            MsgBox("ingresa el Apellido Paterno para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtApellido1.Focus.Equals(True)
            Exit Sub
        End If
        If txtApellido2.Text = "" Then
            MsgBox("ingresa el Apellido Materno para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtApellido2.Focus.Equals(True)
            Exit Sub
        End If
        If cboSex.Text = "" Then
            MsgBox("ingresa el Genero para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            cboSex.Focus.Equals(True)
            Exit Sub
        End If
        Dim correo As String = txtEmail.Text
        If EsCorreoValido(correo) Then
        Else
            MessageBox.Show("El correo no es válido. Por favor, ingrese un correo electrónico correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtEmail.Focus.Equals(True)
            Exit Sub
        End If
        If txtTelefono.Text = "" Then
            MsgBox("ingresa el Telefono para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtTelefono.Focus.Equals(True)
            Exit Sub
        End If
        If cboStatusTel.Text = "" Then
            MsgBox("ingresa el Estatus para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            cboStatusTel.Focus.Equals(True)
            Exit Sub
        End If
        If cboTipoTel.Text = "" Then
            MsgBox("ingresa el Tipo de Telefono para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            cboTipoTel.Focus.Equals(True)
            Exit Sub
        End If
        If txtCalle.Text = "" Then
            MsgBox("ingresa la Calle para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtCalle.Focus.Equals(True)
            Exit Sub
        End If
        If txtExtDir.Text = "" Then
            MsgBox("ingresa el Numero Exterior para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtExtDir.Focus.Equals(True)
            Exit Sub
        End If
        If txtColonia.Text = "" Then
            MsgBox("ingresa la Colonia para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtColonia.Focus.Equals(True)
            Exit Sub
        End If
        If txtCpDir.Text = "" Then
            MsgBox("ingresa CP para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtCpDir.Focus.Equals(True)
            Exit Sub
        End If
        If txtDelegacion.Text = "" Then
            MsgBox("ingresa la Delegación para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtDelegacion.Focus.Equals(True)
            Exit Sub
        End If
        If txtCiudad.Text = "" Then
            MsgBox("ingresa la Ciudad para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtCiudad.Focus.Equals(True)
            Exit Sub
        End If
        If cboEstado.Text = "" Then
            MsgBox("ingresa el Estado para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            cboEstado.Focus.Equals(True)
            Exit Sub
        End If
        If txtPais.Text = "" Then
            MsgBox("ingresa el Pais para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            txtPais.Focus.Equals(True)
            Exit Sub
        End If
        If cboTipoDir.Text = "" Then
            MsgBox("ingresa el Tipo de Dirección para continuar con el proceso", vbExclamation + vbOKOnly, "Delsscom Farmacias")
            cboTipoDir.Focus.Equals(True)
            Exit Sub
        End If
        If MsgBox("¿Deseas registrar el nuevo cliente?", vbQuestion + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
            Exit Sub
        End If
        My.Application.DoEvents()
        lblEstatus.Visible = True
        Button2.Enabled = False
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
                MsgBox(jsonData)
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
                    frmBuscaCliente.txtFolio.Text = detail
                    My.Application.DoEvents()
                Else
                    MsgBox("Error al consumir la API: " & response.ReasonPhrase)
                End If
            End Using
            lblEstatus.Visible = False
            Button2.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub txtCpDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCpDir.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

        ' Limitar el TextBox a 5 dígitos
        If txtCpDir.Text.Length >= 5 AndAlso Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            txtDelegacion.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            cboStatusTel.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtApellido1.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtApellido1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtApellido2.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtApellido2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApellido2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNacimiento.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtNacimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNacimiento.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboSex.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboSex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSex.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtEmail.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtTelefono.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboStatusTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboStatusTel.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipoTel.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipoTel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoTel.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCalle.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtExtDir.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtExtDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtExtDir.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtIntDir.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtIntDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIntDir.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtColonia.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtColonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCpDir.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtDelegacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDelegacion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCiudad.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtCiudad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCiudad.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboEstado.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboEstado.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPais.Focus.Equals(True)
        End If
    End Sub

    Private Sub txtPais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPais.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboTipoDir.Focus.Equals(True)
        End If
    End Sub

    Private Sub cboTipoDir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboTipoDir.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button2.Focus.Equals(True)
        End If
    End Sub
End Class