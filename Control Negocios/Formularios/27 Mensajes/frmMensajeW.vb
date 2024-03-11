Imports System.Runtime.InteropServices
Imports System.Threading.Tasks
Imports Chilkat
Imports WhatsAppDLL
Public Class frmMensajeW

    Dim token As String = ""
    Dim TIMBRES As Integer = 0

    Private Sub frmMensajeW_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        sTargetdWaht = "server=" & ipserverW & ";uid=" & userbdW & ";password=" & passbdW & ";database=" & databaseW & ";persist security info=false;connect timeout=300"

        Dim cnn12 As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim sinfo12 As String = ""
        Dim dr As DataRow
        Dim odata12 As New ToolKitSQL.myssql
        Dim sql12 As String = "SELECT * FROM Renta WHERE Id=" & empresaseleccionadaw & ""
        With odata12
            If .dbOpen(cnn12, sTargetdWaht, sinfo12) Then
                If .getDr(cnn12, dr, sql12, sinfo12) Then

                    token = dr("tokenQR").ToString

                End If
                cnn12.Close()
            End If
        End With
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        If checat() Then
            If 1 > TIMBRES Then
                MsgBox("El número de mensajes que quiere enviar es mayor al número de mensajes disponibles " & TIMBRES)
                Exit Sub
            End If

            If Trim(txtMensaje.Text) = "" Then MsgBox("Ha que registrar almenos un caracter en el mensaje") : txtMensaje.Focus() : Exit Sub
            If Trim(txtCel.Text) = "" Then MsgBox("El campo celular no puede estar vacío") : txtCel.Focus() : Exit Sub
            If IsNumeric(Trim(txtCel.Text)) = False Then MsgBox("El celular debe de ser un valor numérico") : txtCel.Focus() : Exit Sub
            If Len(txtCel.Text) < 10 Then MsgBox("El celular debe de contener 10 caracteres") : txtCel.Focus() : Exit Sub

            mandar_el_mensaje_async(Trim(txtCel.Text), Trim(txtMensaje.Text))

            actualiza_timbres(1)
        End If
    End Sub

    Async Function mandar_el_mensaje_async(ByVal varcel As String, ByVal varmensaje As String) As Task
        Try
            Dim newenvio As WhatsappEnvio = New WhatsappEnvio(token, "")
            Dim mensajerespuesta As String = Await newenvio.SendTextMessageWebHook("52" & Trim(varcel), Trim(varmensaje))
            ' Mostrar un MsgBox después de la espera

            MessageBox.Show(Mid(mensajerespuesta, 1, 31), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            ' Manejar cualquier excepción aquí
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Function checat()

        Dim cnn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim dr As DataRow
        Dim sql As String = "SELECT * FROM Renta WHERE Id=" & empresaseleccionadaw & ""
        Dim odata As New ToolKitSQL.myssql

        With odata
            If .dbOpen(cnn, sTargetdWaht, sinfo) Then
                If odata.getDr(cnn, dr, sql, sinfo) Then
                    TIMBRES = CInt(dr("NumM").ToString)

                    If CInt(dr("NumM").ToString) > 0 Then
                        cnn.Close()
                        Return True
                    Else
                        MsgBox("Mensajes Terminados Consulte a su asesor Delsscom para adquirir un nuevo paquete", vbInformation + vbOKOnly, titulocentral)
                        cnn.Close()
                        Return False
                    End If

                Else
                    MsgBox("Empresa No existe en la Base de Datos, contacte con su asesor Delsscom", vbInformation + vbOKOnly, titulocentral)
                    cnn.Close()
                    Return False
                End If
                cnn.Close()
            End If
        End With

    End Function

    Public Sub actualiza_timbres(ByVal mensajesconsumidos As Integer)
        Dim sinfo As String = ""
        Dim cnn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        With odata
            If odata.dbOpen(cnn, sTargetdWaht, sinfo) Then
                If odata.runSp(cnn, "update Renta set NumM = NumM - " & mensajesconsumidos & " where Id=" & empresaseleccionadaw & "", sinfo) Then
                End If
                cnn.Close()
            End If
        End With
    End Sub
End Class