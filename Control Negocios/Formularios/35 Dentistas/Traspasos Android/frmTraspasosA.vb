
Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class frmTraspasosA
    Dim banderaentra As Integer = 0
    Private configA As datosAndroid
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long
    Private Sub frmTraspasosA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sTargett = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"

        If IO.File.Exists(ARCHIVO_DE_CONFIGURACION_A) Then

            banderaentra = 1

            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_DE_CONFIGURACION_A, OpenMode.Random, OpenAccess.ReadWrite)
            recordLen = Len(configA)
            FileGet(filenum, configA, 1)
            ipserverA = Trim(configA.ipr)
            databaseA = Trim(configA.baser)
            userbdA = Trim(configA.usuarior)
            passbdA = Trim(configA.passr)
            If ipserverA = "" Or databaseA = "" Or userbdA = "" Or passbdA = "" Then
                sTargetNube = ""
            Else
                'sTargetNube = "server=" & ipserverA & ";uid=" & userbdA & ";password=" & passbdA & ";database=" & databaseA & ";persist security info=false;connect timeout=300"
                sTargetNube = "server=72.167.50.81;uid=delsincro1_Android;password=Delsscom22;database=delsincro1_AndroidP;persist security info=false;connect timeout=300"
            End If

            'Dim cnnp As MySqlConnection = New MySqlConnection
            'Dim sinfop As String = ""
            'Dim drp As DataRow
            'Dim odata As New ToolKitSQL.myssql
            'With odata
            '    If .dbOpen(cnnp, sTargetNube, sinfop) Then
            '        If .getDr(cnnp, drp, "select nombre from sucursales where Id = 1 or nombre = 'MATRIZ'", sinfop) Then
            '            lblconexion.Text = "Conexión: exitosa"
            '        Else
            '            lblconexion.Text = "ERROR de Conexión"
            '        End If
            '        cnnp.Close()
            '    Else
            '        lblconexion.Text = "ERROR de Conexión"
            '    End If
            'End With


            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sSQL As String = ""
            sSQL = "select nombre from sucursales where Id = 1 or nombre = 'MATRIZ'"
            Dim ds As New DataSet
            Dim sinfo As String = ""
            Dim oData1 As New ToolKitSQL.myssql
            With oData1
                If .dbOpen(cnn, sTargetNube, sinfo) Then

                    Try
                        If oData1.getDs(cnn, ds, sSQL, "edos", sinfo) Then

                        Else
                        End If
                    Catch ex As Exception
                    End Try

                    cnn.Close()
                Else
                End If
            End With

            FileClose()

        Else
            ipserverA = ""
            databaseA = ""
            userbdA = ""
            passbdA = ""

        End If

        btnNuevoProd.PerformClick()

        'llena_Usuarios(cboRuta)
    End Sub
End Class