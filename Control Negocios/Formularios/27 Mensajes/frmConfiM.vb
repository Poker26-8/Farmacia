Public Class frmConfiM

    Private configSincro As datosMensajeria
    Private configRenta As datosRenta
    Private filenum As Integer
    Private recordLen As String
    Private Sub frmConfiM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACIONW) Then

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACIONW, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(configSincro)

            FileGet(filenum, configSincro, 1)

            ipserverW = Trim(configSincro.ipr)
            databaseW = Trim(configSincro.baser)
            userbdW = Trim(configSincro.usuarior)
            passbdW = Trim(configSincro.passr)
            If IsNumeric(Trim(configSincro.sucursalr)) Then
                susursalr = Trim(configSincro.sucursalr)
            End If

            txt_servidor.Text = Trim(configSincro.ipr)
            txt_base.Text = Trim(configSincro.baser)
            txt_usuario.Text = Trim(configSincro.usuarior)
            txt_contrasena.Text = Trim(configSincro.passr)

            FileClose()
            'guardar el registro en la tabla

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACIONR, OpenMode.Random, OpenAccess.ReadWrite)
            recordLen = Len(configRenta)

            FileGet(filenum, configRenta, 1)

            empresaw = Trim(configRenta.empresa)
            tokenw = Trim(configRenta.token)

            txtEmpresa.Text = Trim(configRenta.empresa)
            txtToken.Text = Trim(configRenta.token)


            sTargetdWaht = "server=" & ipserverW & ";uid=" & userbdW & ";password=" & passbdW & ";database=" & databaseW & ";persist security info=false;connect timeout=30"

            Dim empresa As Integer = 0
            Dim timbres As Integer = 0

            Dim cnn1 As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
            Dim sinfo1 As String = ""
            Dim dr1 As DataRow
            Dim odata1 As New ToolKitSQL.myssql
            Dim sql As String = "SELECT * FROM Renta WHERE Empresa='" & txtEmpresa.Text & "'"

            With odata1
                If .dbOpen(cnn1, sTargetdWaht, sinfo1) Then
                    If .getDr(cnn1, dr1, sql, sinfo1) Then

                        empresa = dr1("Id").ToString
                        timbres = dr1("NumM").ToString

                        txtIdEmpresa.Text = empresa
                        txtTimbres.Text = timbres
                        empresaseleccionadaw = txtIdEmpresa.Text
                    End If
                    cnn1.Close()
                End If
            End With

            FileClose()

        End If
    End Sub

    Public Sub salva_datos()

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACIONW) Then
            IO.File.Delete(ARCHIVO_DE_CONFIGURACIONW)
        End If


        Try
            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACIONW, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(configSincro)
            FileGet(filenum, configSincro, 1)

            configSincro.ipr = txt_servidor.Text
            configSincro.baser = txt_base.Text
            configSincro.usuarior = txt_usuario.Text
            configSincro.passr = txt_contrasena.Text

            ipserverW = Trim(configSincro.ipr)
            databaseW = Trim(configSincro.baser)
            userbdW = Trim(configSincro.usuarior)
            passbdW = Trim(configSincro.passr)

            FilePut(filenum, configSincro, 1)

            FileClose()

            sTargetdWaht = "server=" & ipserverW & ";uid=" & userbdW & ";password=" & passbdW & ";database=" & databaseW & ";persist security info=false;connect timeout=30"


            Dim idempresa As Integer = 0

            Dim cnn As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dr As DataRow

            Dim odata As New ToolKitSQL.myssql
            Dim sql As String = "SELECT * FROM Renta WHERE Empresa='" & txtEmpresa.Text & "'"
            With odata
                If odata.dbOpen(cnn, sTargetdWaht, sinfo) Then
                    If odata.getDr(cnn, dr, sql, sinfo) Then

                        idempresa = dr("Id").ToString

                        If odata.runSp(cnn, "UPDATE tokenQR='" & txtToken.Text & "' WHERE Empresa='" & txtEmpresa.Text & "' AND Id=" & idempresa & "", sinfo) Then

                        End If
                    Else

                        If odata.runSp(cnn, "INSERT INTO Renta(Empresa,tokenQR,NumM,FechaInicio,FechaTermino) VALUES('" & txtEmpresa.Text & "','" & txtToken.Text & "'," & txtTimbres.Text & ",'" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "yyyy-MM-dd") & "')", sinfo) Then

                        End If

                    End If
                    cnn.Close()
                End If
            End With

            'datos para la tabla
            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACIONR, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(configRenta)
            FileGet(filenum, configRenta, 1)

            configRenta.empresa = txtEmpresa.Text
            configRenta.token = txtToken.Text


            empresaw = Trim(configRenta.empresa)
            tokenw = Trim(configRenta.token)

            FilePut(filenum, configRenta, 1)
            FileClose()

            MsgBox("guadado correctamente")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        salva_datos()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtEmpresa.Text = ""
        txtToken.Text = ""
        txtTimbres.Text = ""
        txtIdEmpresa.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmMensajeW.Show()
    End Sub
End Class