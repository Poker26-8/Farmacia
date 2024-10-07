Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Math.EC.ECCurve

Public Class frmRecibeTraspaso
    Dim renglon As Integer = 0
    Dim usu_copia As String = ""

    Private config As datosSincronizador
    Private configF As datosAutoFac

    Private filenum As Integer
    Private recordLen As String
    Private Sub frmRecibeTraspaso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(ARCHIVO_DE_CONFIGURACION) Then

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACION, OpenMode.Random, OpenAccess.ReadWrite)
            recordLen = Len(config)
            FileGet(filenum, config, 1)
            ipserver = Trim(config.ipr)
            database = Trim(config.baser)
            userbd = Trim(config.usuarior)
            passbd = Trim(config.passr)
            If IsNumeric(Trim(config.sucursalr)) Then
                susursalr = Trim(config.sucursalr)
            End If

            sTargetdSincro = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"

            FileClose()

            sTargetdAutoFac = ""

            If IO.File.Exists(ARCHIVO_DE_CONFIGURACION_F) Then
                filenum = FreeFile()
                FileOpen(filenum, ARCHIVO_DE_CONFIGURACION_F, OpenMode.Random, OpenAccess.ReadWrite)
                recordLen = Len(configF)
                FileGet(filenum, configF, 1)
                ipserverF = Trim(configF.ipr)
                databaseF = Trim(configF.baser)
                userbdF = Trim(configF.usuarior)
                passbdF = Trim(configF.passr)
                sTargetdAutoFac = "server=" & ipserverF & ";uid=" & userbdF & ";password=" & passbdF & ";database=" & databaseF & ";persist security info=false;connect timeout=300"

                'Label1.Text = "AutoFact base: " & databaseF
                FileClose()
            Else
                ipserverF = ""
                databaseF = ""
                userbdF = ""
                passbdF = ""
            End If
            soySucursal()
        End If
    End Sub

    Private Sub cbo_DropDown(sender As Object, e As EventArgs) Handles cbo.DropDown
        Try
            cbo.Items.Clear()
            buscaSucOrigen()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub soySucursal()
        Try
            Dim cnn As MySqlConnection = New MySqlConnection
            Dim sSQL As String = "SELECT nombre FROM sucursales where Id=" & susursalr & ""
            Dim dr As DataRow
            Dim dt1 As New DataTable
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                    If .getDt(cnn, dt1, sSQL, "etres") Then
                        For Each dr In dt1.Rows
                            lblSuc.Text = (dr("nombre").ToString)
                        Next
                    End If
                    cnn.Close()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub buscaSucOrigen()
        Try
            Dim numsucc As Integer = 0
            Dim cnn As MySqlConnection = New MySqlConnection
            Dim sSQL As String = "SELECT distinct Origen FROM traspasos where destino=" & susursalr & ""
            Dim sSQL2 As String = "SELECT nombre FROM sucursales where Id=" & numsucc & ""
            Dim dr As DataRow
            Dim dt1 As New DataTable

            Dim dr2 As DataRow
            Dim dt2 As New DataTable
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                    If .getDt(cnn, dt1, sSQL, "etres") Then
                        For Each dr In dt1.Rows
                            numsucc = (dr("Origen").ToString)
                            If .getDt(cnn, dt2, "SELECT nombre FROM sucursales where Id=" & numsucc & "", "etres") Then
                                For Each dr2 In dt2.Rows
                                    cbo.Items.Add(dr2("nombre").ToString)
                                Next
                            End If
                        Next
                    End If
                    cnn.Close()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try


    End Sub

    Public Sub buscaFolioSuc()
        Try
            Dim numsucc As Integer = 0
            Dim cnn As MySqlConnection = New MySqlConnection
            Dim sSQL As String = ""
            If cbo.Text = "" Then
                sSQL = "SELECT distinct NumTraspasosS FROM traspasos where destino=" & susursalr & ""
            Else
                sSQL = "SELECT distinct NumTraspasosS FROM traspasos where destino=" & susursalr & " and Origen=" & lblidorigen.Text & ""
            End If
            Dim dr As DataRow
            Dim dt1 As New DataTable

            Dim dr2 As DataRow
            Dim dt2 As New DataTable
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                    If .getDt(cnn, dt1, sSQL, "etres") Then
                        For Each dr In dt1.Rows
                            ComboBox1.Items.Add((dr("NumTraspasosS").ToString))
                        Next
                    End If
                    cnn.Close()
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_DropDown(sender As Object, e As EventArgs) Handles ComboBox1.DropDown
        Try
            ComboBox1.Items.Clear()
            buscaFolioSuc()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cbo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo.SelectedValueChanged
        Try
            Try
                Dim cnn As MySqlConnection = New MySqlConnection
                Dim sSQL As String = "SELECT Id FROM sucursales where nombre='" & cbo.Text & "'"
                Dim dr As DataRow
                Dim dt1 As New DataTable
                Dim sinfo As String = ""
                Dim oData As New ToolKitSQL.myssql
                With oData
                    If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                        If .getDt(cnn, dt1, sSQL, "etres") Then
                            For Each dr In dt1.Rows
                                lblidorigen.Text = (dr("Id").ToString)
                            Next
                        End If
                        cnn.Close()
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class