Public Class frmConfiM

    Private configSincro As datosMensajeria
    Private filenum As Integer
    Private recordLen As String
    Private Sub frmConfiM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACIONW) Then

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACIONW, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(configSincro)

            FileGet(filenum, configSincro, 1)

            ipserver = Trim(configSincro.ipr)
            database = Trim(configSincro.baser)
            userbd = Trim(configSincro.usuarior)
            passbd = Trim(configSincro.passr)
            If IsNumeric(Trim(configSincro.sucursalr)) Then
                susursalr = Trim(configSincro.sucursalr)
            End If

            txt_servidor.Text = Trim(configSincro.ipr)
            txt_base.Text = Trim(configSincro.baser)
            txt_usuario.Text = Trim(configSincro.usuarior)
            txt_contrasena.Text = Trim(configSincro.passr)


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

            sTargetdWaht = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=30"
            MsgBox("guadado correctamente")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        salva_datos()
    End Sub
End Class