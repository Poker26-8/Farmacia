Imports Microsoft.Office.Interop
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Utilities
Imports WhatsAppDLL
Imports System.Threading.Tasks

Public Class frmClientesW

    Dim timbres As Integer = 0
    Dim TOTALREGISTROS As Integer = 0
    Private Sub frmClientesW_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sTargetdWaht = "server=" & ipserverW & ";uid=" & userbdW & ";password=" & passbdW & ";database=" & databaseW & ";persist security info=false;connect timeout=300"

    End Sub
    Private Sub rbTodos_Click(sender As Object, e As EventArgs) Handles rbTodos.Click

        Try
            If (rbTodos.Checked) Then

                TOTALREGISTROS = 0

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT COUNT(Id) FROM clientes WHERE Nombre<>'' AND Telefono<>''"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        TOTALREGISTROS = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Nombre,RazonSocial,Telefono FROM clientes WHERE Nombre<>'' AND Telefono<>'' ORDER BY Nombre"
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then

                        grdCaptura.Rows.Add(rd1(0).ToString,
                                            rd1(1).ToString,
                                            rd1(2).ToString
)

                    End If
                Loop
                rd1.Close()
                cnn1.Close()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If checat() Then

            Dim telefono As String = ""

            If 1 > timbres Then
                MsgBox("El número de mensajes que quiere enviar es mayor al número de mensajes disponibles " & timbres, vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            End If

            If Trim(txtMensaje.Text) = "" Then MsgBox("Ha que registrar almenos un caracter en el mensaje") : txtMensaje.Focus() : Exit Sub

            For dx As Integer = 0 To grdCaptura.Rows.Count - 1

                telefono = grdCaptura.Rows(dx).Cells(2).Value.ToString


                mandar_el_mensaje_async(Trim(telefono), Trim(txtMensaje.Text))

            Next



            actualiza_timbres(TOTALREGISTROS)
        End If
    End Sub

    Async Function mandar_el_mensaje_async(ByVal varcel As String, ByVal varmensaje As String) As Task
        Try
            Dim newenvio As WhatsappEnvio = New WhatsappEnvio(tokenglobal, "")
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
                    timbres = CInt(dr("NumM").ToString)

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

    Private Sub txtMensaje_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMensaje.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnEnviar.Focus.Equals(True)
        End If
    End Sub
End Class