Imports System.IO
Imports System.Net
Imports System.Math
Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.Management
Imports System.Net.NetworkInformation
Imports System.Security.Cryptography
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient
Imports System.Windows
Imports MySql.Data
Imports System.Data.OleDb

Structure datosSincronizador
    Dim rutar As String
    Dim sucursalr As String
    Dim ipr As String
    Dim baser As String
    Dim usuarior As String
    Dim passr As String
End Structure
Structure datosAndroid
    Dim ipr As String
    Dim baser As String
    Dim usuarior As String
    Dim passr As String
End Structure

Structure datosAutoFac
    Dim rutar As String
    Dim sucursalr As String
    Dim ipr As String
    Dim baser As String
    Dim usuarior As String
    Dim passr As String
End Structure

Module Module1
    'android
    Public ARCHIVO_DE_CONFIGURACION_A = My.Application.Info.DirectoryPath & "\ConfiguraAndroid.dat"

    Public vienede As String = ""
    Public farmaciaseleccionada As String = ""

    Public sTargett As String = ""
    Public sTargetNube As String = ""

    Public ipserverA As String = ""
    Public databaseA As String = ""
    Public userbdA As String = ""
    Public passbdA As String = ""


    Public tokenglobal As String = ""
    Public empresaseleccionadaw As Integer = 0
    Public baseseleccionada As String = ""

    'datos nomina
    Public sello As String

    Private configlocal As datos_c
    Private filenumlocal As Integer

    Public varnumero As String = ""
    Public varusuario As String = ""
    Public varcontra As String = ""

    Public varcompañia As String = ""
    Public varmonto As String = ""
    Public vartelefono As String = ""
    Public varfolrecarga As String = ""

    Public titulonomina As String = "Delsscom® Control Nomina"
    Public titulohotelriaa As String = "Delsscom® Control Hotelero"
    Public titulomensajes As String = "Delsscom® Restaurant Pro"
    Public titulotaller As String = "Delsscom® Control Taller"
    Public titulorefaccionaria As String = "Delsscom® Control Refaccionaria"
    Public titulocentral As String = "Delsscom® Farmacias"

    Public titulorestaurante As String = "Delsscom® Control Negocios Restaurant"
    Public tomacontralog As Integer = 0

    'variables para factura global
    Public sumaprodSinIva As Double = 0
    Public sumaprodConIva As Double = 0
    ''''''''''''''''''''''' 

    'variables para bloquear los text_changes
    Public bandera_emisor As Integer = 0
    ''''''''''''''''''''''''''''''''''''''''

    Public bandera_timbres As Integer = 0
    Public varnomemail As String = ""
    Public espunto As Integer
    Public strsql As String
    Public total_empresAs As Integer = 1
    Public FolFacts As String = ""
    Public FoliosFacGlobal As String = ""
    'Public sTarget As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\ControlNegociosV2022\DL1.mdb;Persist Security Info=True;Jet OLEDB:Database Password=jipl22" 'password=jipl22n;"
    Public varnumbase As String = ""
    Public varrutabase As String = ""
    Public sTarget As String = ""
    Public sTargetmensajeswhatsapp As String = ""
    'Public sTargetlocal As String = ""
    Public vempresa As Integer = 1
    Public uidcancel As String
    Public refccancel As String
    Public directoriof As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & ""
    Public cadena_pagos1 As String = ""
    Public metodo_p_ac As String = ""
    Public Const ESTATUS_FACTURA = 1
    Public Const ESTATUS_PREFACTURA = 2
    Public Const ESTATUS_ARRENDAMIENTO = 4
    Public Const ESTATUS_HONORARIOS = 5
    Public Const ESTATUS_NOTASCREDITO = 6
    Public Const ESTATUS_FACTURA_ERROR = 3

    Public numero_MAC As String = ""

    Public tienda_enlinea As Integer = 0

    Public ipserverF As String = ""
    Public databaseF As String = ""
    Public userbdF As String = ""
    Public passbdF As String = ""

    Public susursalr As Integer = 0

    Public ARCHIVO_DE_CONFIGURACIONW = My.Application.Info.DirectoryPath & "\ConfiguraW.dat"
    Public ARCHIVO_DE_CONFIGURACIONR = My.Application.Info.DirectoryPath & "\ConfiguraRenta.dat"

    Public Grupo_Impresion_Tienda As String = ""

    Public Tiempo(2) As Integer
    Public Fechita(3) As Integer
    Public refer As String

    Public Function QuitaSaltos(ByVal texto As String, ByRef caracter As String) As String
        QuitaSaltos = Replace(Replace(texto, Chr(10), caracter), Chr(13), caracter)
    End Function

    Public Sub Estado()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Agenda set Activo=0 where Anio<=" & CDec(Fechita(3)) & " and Mes<=" & CDec(Fechita(2)) & " and Dia<" & CDec(Fechita(1)) & ""
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Agenda set Activo=0 where Anio<=" & CDec(Fechita(3)) & " and Mes<=" & CDec(Fechita(2)) & " and Dia<=" & CDec(Fechita(1)) & " and Hora<" & CDec(Tiempo(1)) & ""
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Agenda set Activo=0 where Anio<=" & CDec(Fechita(3)) & " and Mes<=" & CDec(Fechita(2)) & " and Dia<=" & CDec(Fechita(1)) & " and Hora<=" & CDec(Tiempo(1)) & " and Minuto<" & CDec(Tiempo(2)) & ""
            cmd1.ExecuteNonQuery()

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Public Sub ActualHora(ByRef grid As DataGridView, ByRef usuario As String)
        grid.Rows.Clear()
        Dim minuto As String = ""
        Dim hora As String = ""

        Try
            cnn2.Close() : cnn2.Open()

            For field As Integer = 0 To 60
                If field = 60 Then Exit For
                minuto = field
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Hora,Minuto,Id,Asunto,Activo from Agenda where Minuto=" & minuto & " and Hora=" & Tiempo(1) & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & usuario & "' and Activo=-1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        If rd2("Hora").ToString < 10 Then
                            hora = "0" & rd2("Hora").ToString
                        Else
                            hora = rd2("Hora").ToString
                        End If

                        If rd2("Minuto").ToString < 10 Then
                            minuto = "0" & rd2("Minuto").ToString
                        Else
                            minuto = rd2("Minuto").ToString
                        End If

                        grid.Rows.Add(rd2("Id").ToString, hora & ":" & minuto, rd2("Asunto").ToString, rd2("Activo").ToString)
                    End If
                Else
                    If field < 10 Then
                        minuto = "0" & field
                    Else
                        minuto = field
                    End If

                    If CDec(Tiempo(1)) < 10 Then
                        hora = "0" & Tiempo(1)
                    Else
                        hora = Tiempo(1)
                    End If

                    grid.Rows.Add("0", hora & ":" & minuto, "", "0")
                End If
                rd2.Close()
            Next
            cnn2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
        End Try
    End Sub

    Public Sub ActualDia(ByRef grid As DataGridView, ByRef usuario As String)
        grid.Rows.Clear()
        Dim hora As String = ""
        Dim horx As String = ""
        Dim evento As String = ""

        Try
            cnn2.Close() : cnn2.Open()
            cnn3.Close()
            cnn3.Open()

            For field As Integer = 0 To 23
                If field < 10 Then
                    hora = "0" & field
                Else
                    hora = field
                End If

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Hora,Id,Minuto,Activo from Agenda where Hora=" & hora & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & usuario & "' and Activo=-1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                            "select Asunto from Agenda where Hora=" & hora & " and Dia=" & Fechita(1) & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & usuario & "' and Activo=-1"
                        rd3 = cmd3.ExecuteReader
                        Do While rd3.Read
                            If rd3.HasRows Then
                                evento = evento & " - " & rd3(0).ToString
                            End If
                        Loop
                        rd3.Close()
                        evento = Mid(evento, 4, 99000)

                        If rd2("Hora").ToString < 10 Then
                            horx = "0" & rd2("Hora").ToString
                        Else
                            horx = rd2("Hora").ToString
                        End If

                        grid.Rows.Add(rd2("Id").ToString, rd2("Hora").ToString & ":" & rd2("Minuto").ToString, evento, rd2("Activo").ToString)
                    End If
                Else
                    If hora < 10 Then
                        horx = "0" & field
                    Else
                        horx = field
                    End If
                    grid.Rows.Add("0", hora & ":00", "", "0")
                End If
                rd2.Close()
            Next
            cnn2.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
            cnn3.Close()
        End Try
    End Sub

    Public Sub ActualMes(ByRef grid As DataGridView, ByRef usuario As String)
        grid.Rows.Clear()
        Dim dia As String = ""
        Dim evento As String = ""

        Try
            cnn2.Close() : cnn2.Open()
            cnn3.Close()
            cnn3.Open()

            For field As Integer = 1 To Date.DaysInMonth(Now.Year, Now.Month)
                dia = field

                cmd2 = conexion.CreateCommand
                cmd2.CommandText =
                    "select Id,Dia,Activo from Agenda where Dia=" & dia & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & usuario & "' and Activo=-1"
                rd2 = cmd2.ExecuteReader
                If rd2.HasRows Then
                    If rd2.Read Then
                        cmd3 = cnn3.CreateCommand
                        cmd3.CommandText =
                            "select Asunto from Agenda where Dia=" & dia & " and Mes=" & Fechita(2) & " and Anio=" & Fechita(3) & " and Usuario='" & usuario & "' and Activo=-1"
                        rd3 = cmd3.ExecuteReader
                        Do While rd3.Read
                            If rd3.HasRows Then
                                evento = evento & " - " & rd3(0).ToString
                            End If
                        Loop
                        rd3.Close()
                        evento = Mid(evento, 4, 99000)

                        grid.Rows.Add(rd2("Id").ToString, rd2("Dia").ToString, evento, rd2("Activo").ToString)
                    End If
                Else
                    grid.Rows.Add("0", dia, "", "0")
                End If

                My.Application.DoEvents()
                rd2.Close()
            Next
            cnn2.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            conexion.Close()
            cnn3.Close()
        End Try
    End Sub

    Public Function ConvertCero(ByVal vl As String) As Double
        If Not IsNumeric(vl) Then
            ConvertCero = 0
        Else
            ConvertCero = CDbl(vl)
        End If

    End Function
    Public Sub muestra_datos()
        FileGet(filenumlocal, configlocal, 1)

        ipserver = Trim(configlocal.ip_configuracion)
        database = Trim(configlocal.base_configuracion)
        userbd = Trim(configlocal.usuario_configuracion)
        passbd = Trim(configlocal.password_configuracion)
    End Sub

    Structure datosMensajeria
        Dim rutar As String
        Dim sucursalr As String
        Dim ipr As String
        Dim baser As String
        Dim usuarior As String
        Dim passr As String
    End Structure

    Structure datosRenta
        Dim empresa As String
        Dim token As String
    End Structure

    'Public sTargetlocal As String = "Data Source=" & dameIP2() & "; Integrated Security=true; initial catalog=CN1; user id=Delsscom; password=jipl22; timeout=300"
    ' Public sTargetlocal As String = "Server=" & ipserver & ";Database=" & database & ";User ID=" & userbd & ";Password=" & passbd & ";Connect Timeout=300;"
    ' Public sTargetlocal As String = ""
    Public sTargetlocal As String = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"


    Public Function conexionlocal()

        Dim cnn As OleDbConnection = New OleDbConnection
        Dim sSQL As String = ""
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.oledbdata
        Dim dr As DataRow
        sTarget = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\CIAS.mdb;"
        sSQL = "select base,Servidor from Server"
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    varnumbase = 1 'dr(0).ToString
                    varrutabase = dr(1).ToString
                    If varrutabase = "" Then

                        sTargetlocal = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn" & varnumbase & ";persist security info=false;connect timeout=300"
                    Else

                        sTargetlocal = "server=" & varrutabase & ";uid=Delsscom;password=jipl22;database=cn" & varnumbase & ";persist security info=false;connect timeout=300"
                    End If
                End If
                cnn.Close()
            End If
        End With

    End Function


    ' sTargetlocal = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"

    Public ARCHIVO_CONF_FACTURAS = My.Application.Info.DirectoryPath & "\Configurapdv.dat"
    Public ARCHIVO_DE_CONFIGURACION = My.Application.Info.DirectoryPath & "\Configurapdvf.dat"
    Public ARCHIVO_DE_CONFIGURACION_F = My.Application.Info.DirectoryPath & "\Configurapdvfac.dat"

    Public sTargetdSincro As String = ""

    Public sTargetdWaht As String = "server=" & ipserverW & ";uid=" & userbdW & ";password=" & passbdW & ";database=" & databaseW & ";persist security info=false;connect timeout=30"
    Public sTargetMYSQL As String = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"
    Public sTargetdAutoFac As String = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"

    Public ipserver As String = ""
    Public database As String = ""
    Public userbd As String = ""
    Public passbd As String = ""


    'datos para la mensajeria de whatsapp
    Public ipserverW As String = ""
    Public databaseW As String = ""
    Public userbdW As String = ""
    Public passbdW As String = ""

    'datos para la renta de whatsap
    Public empresaw As String = ""
    Public tokenw As String = ""
    Public timbrew As String = ""
    Public idempw As String = ""

    Public serie_gen As String = ""
    Public timbres_totales As Integer = 0
    Public timbres_timbrados As Integer = 0
    Public var_cotb As Integer = 1

    Public servidor As String = ""
    Public base As String = ""
    Public empresa_activa As String = ""
    Public zinc As Integer = 0

    Public equipo_servidor As String = ""
    Public ruta_servidor As String = ""
    Public MyIP As String = ""
    Public MyNumPC As String = ""
    Public adicional As Boolean = False

    Public PrimeraConfig As String = ""

    Public cnn1 As MySqlConnection = New MySqlConnection()
    Public cnn2 As MySqlConnection = New MySqlConnection()
    Public cnn3 As MySqlConnection = New MySqlConnection()
    Public cnn4 As MySqlConnection = New MySqlConnection()
    Public cnn5 As MySqlConnection = New MySqlConnection()

    Public cnn7 As MySqlConnection = New MySqlConnection()
    Public cnn8 As MySqlConnection = New MySqlConnection()
    Public cnn9 As MySqlConnection = New MySqlConnection()
    Public cnntimer As MySqlConnection = New MySqlConnection()
    Public cnntimer2 As MySqlConnection = New MySqlConnection()

    Public Direcc_Access As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & My.Application.Info.DirectoryPath & "\DL1.mdb;Persist Security Info=True;Jet OLEDB:Database Password=jipl22"

    Public cmd1, cmd2, cmd3, cmd4, cmd5, cmd9, cmd8, cmd7, cmdtimer, cmdtimer2 As MySqlCommand
    Public rd1, rd2, rd3, rd4, rd5, rd9, rd8, rd7, rdtimer, rdtimer2 As MySqlDataReader

    Structure datos_c
        Dim ip_configuracion As String
        Dim usuario_configuracion As String
        Dim password_configuracion As String
        Dim base_configuracion As String
    End Structure

    Public Sub solonumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And espunto = 0 Then
            e.Handled = False
            espunto = 1
        Else
            e.Handled = True
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    'Enter para siguiente campo
    Public Sub validaenter(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub crea_dir(ByVal rutaaaaa As String)

        If Directory.Exists(Replace(rutaaaaa, Chr(34), "")) Then
        Else
            Directory.CreateDirectory(Replace(rutaaaaa, Chr(34), ""))
        End If

    End Sub


    Public Sub eliminacomillas(ByVal datoxd As String)
        datoxd = datoxd.Replace("'", "")
        frmClientes.cboNombre.Text = datoxd
    End Sub

    Sub SendSerialData(ByVal data As String, ByVal puerto As String)
        Dim objFSO
        Dim objStream
        objFSO = CreateObject("Scripting.FileSystemObject")
        objStream = objFSO.CreateTextFile(puerto) 'Puerto al cual se envía la impresión  

        Try
            '  objStream.Writeline(Chr(27) & Chr(99) & Chr(48) & Chr(3)) 'Le pedimos que imprima tanto en el rollo Receipt como en el Journal  
            objStream.Writeline(Chr(27) & Chr(122) & Chr(0)) 'Ponemos en Off la impresion paralela  
            Dim Texto As String = ""

            Texto = data

            objStream.Writeline(Texto)
            objStream.Writeline("") 'Espacio en blanco  
            objStream.Writeline("")
            objStream.Writeline(Chr(27) & Chr(109)) ' este es un corte de ticket, no completo  
            objStream.Writeline(Chr(27) & "p" & Chr(&H0) & Chr(&H64) & Chr(&H64)) ' este abre el cajon del dinero  
        Catch ex As Exception

        Finally
            objStream.Writeline(Chr(27) & Chr(64)) ' limpia Buffer de la impresora  
            objStream.Writeline(Chr(27) & Chr(60)) ' la deja en Posicion Stand BY  

            objStream.Close()

            objFSO = Nothing
            objStream = Nothing


        End Try
    End Sub

    Private Function CheckFiles_Dlib_DCont() As Boolean
        Dim rootDlib As String = Environment.SystemDirectory & "\facl.dll"
        Dim rootDCont As String = Environment.SystemDirectory & "\FCCont1.dll"

        If FileIO.FileSystem.FileExists(rootDlib) And FileIO.FileSystem.FileExists(rootDCont) Then
            CheckFiles_Dlib_DCont = True
        Else
            CheckFiles_Dlib_DCont = False
        End If
    End Function

    Public Function ReadFileLib(rootFile As String) As String
        Dim cantAcceso As Integer = 0
        Dim strStream As StreamReader

        If FileIO.FileSystem.FileExists(rootFile) Then
            strStream = New StreamReader(rootFile)
            cantAcceso = strStream.ReadLine
            strStream.Close()
            cantAcceso += 1
            CreateWriteFileLib(rootFile, Convert.ToString(cantAcceso))
            ReadFileLib = cantAcceso.ToString
        Else
            cantAcceso = cantAcceso + 1
            CreateWriteFileLib(rootFile, cantAcceso.ToString)
            ReadFileLib = cantAcceso.ToString
        End If
    End Function

    Public Sub CreateWriteFileLib(rootFile As String, vDato As String)
#Disable Warning BC42024 ' Variable local sin usar: 'strCreateWrite'.
        Dim strCreateWrite As StreamWriter
#Enable Warning BC42024 ' Variable local sin usar: 'strCreateWrite'.

        File.WriteAllText(rootFile, vDato)
    End Sub

    Public Function GetDriveSerialNumber() As String
        Dim DriveSerial As Long
        Dim fso As Object, Drv As Object
        'Create a FileSystemObject object
        fso = CreateObject("Scripting.FileSystemObject")
        Drv = fso.GetDrive(fso.GetDriveName(AppDomain.CurrentDomain.BaseDirectory))
        With Drv
            If .IsReady Then
                DriveSerial = .SerialNumber
            Else    '"Drive Not Ready!"
                DriveSerial = -1
            End If
        End With
        'Clean up
        Drv = Nothing
        fso = Nothing
        GetDriveSerialNumber = Math.Abs(DriveSerial) + 1 'Hex(DriveSerial)
    End Function

    Public Sub nextPress(key As Integer)
        If key = 13 Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Function obtienepiva(ByVal preciosiva As Double, ByVal porcentajeiva As Double) As Double
        Dim pconiva As Double
        If IsNumeric(preciosiva) Then
            If porcentajeiva = "0" Then
                pconiva = preciosiva
            Else
                Dim tiva As Double = 0
                tiva = CDbl(porcentajeiva) / 100
                tiva = tiva + 1
                tiva = FormatNumber(CDbl(preciosiva) * tiva, 6)
                pconiva = tiva
            End If
        End If
        Return pconiva
    End Function

    Public Function checat(ByVal rfcem As String)
        timbres_totales = 0
        timbres_timbrados = 0
        If frmfacturacion.CheckBox1.Checked = False Then

            Dim sInfo As String
            Dim cnn123 As MySql.Data.MySqlClient.MySqlConnection = New MySql.Data.MySqlClient.MySqlConnection
            Dim dr As DataRow
            Dim sSQL As String = "SELECT * FROM Panel_Principal where rfc='" & rfcem & "'"
            Dim odata3 As New ToolKitSQL.myssql

            With odata3
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If .dbOpen(cnn123, sTargetMYSQL, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
#Disable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If .getDr(cnn123, dr, sSQL, sInfo) Then
#Enable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        timbres_totales = CInt(dr("N_Timbres_Agregados").ToString)
                        timbres_timbrados = CInt(dr("Timbres_Consumidos").ToString)
                        If bandera_timbres = 1 Then
                            MsgBox("Timbres restantes " & timbres_totales - timbres_timbrados & "")
                        End If
                        If timbres_totales > timbres_timbrados Then
                            cnn123.Close()
                            Return True
                        Else
                            MsgBox("Cantidad de timbres Terminados Consulte a delsscom")
                            cnn123.Close()
                            Return False
                        End If
                    Else
                        MsgBox("Emisor No Se Encontro en la Base de Datos ")
                        cnn123.Close()
                        Return False
                        ' MsgBox("Error al guardar, " & sInfo)
                    End If
                    cnn123.Close()
                Else
                    MessageBox.Show("Hubo un error en la conexion verifique los datos o su conexion a Internet")
                    cnn123.Close()
                    Return False
                End If
            End With
            Return False
        Else
            Return True
        End If
    End Function

    Public Function checatnom(ByVal rfcem As String)
        timbres_totales = 0
        timbres_timbrados = 0
        '   If facprueba = False Then


        Dim sInfo As String
        Dim cnn As MySqlConnection = New MySqlConnection

        Dim dr As DataRow
        Dim sSQL As String = "SELECT * FROM Panel_Principal where rfc='" & rfcem & "'"

        Dim odata As New ToolKitSQL.myssql


        With odata

            If odata.dbOpen(cnn, sTargetd2, sInfo) Then

                If odata.getDr(cnn, dr, sSQL, sInfo) Then

                    timbres_totales = CInt(dr("N_Timbres_Agregados").ToString)

                    timbres_timbrados = CInt(dr("Timbres_Consumidos").ToString)

                    If timbres_totales > timbres_timbrados Then
                        cnn.Close()
                        Return True
                    Else
                        MsgBox("Cantidad de timbres Terminados Consulte a delsscom")
                        'MsgBox("Cantidad de timbres Terminados Consulte a delsscom")
                        cnn.Close()
                        Return False
                    End If

                Else
                    MsgBox("Emisor No Se Encontro en la Base de Datos ")
                    'MsgBox("Emisor No Se Encontro en la Base de Datos ")
                    cnn.Close()
                    Return False
                    ' MsgBox("Error al guardar, " & sInfo)
                End If

                cnn.Close()
            Else
                MessageBox.Show("Hubo un error en la conexion verifique los datos o su conexion a Internet")
                Return False


            End If

        End With
        Return False
        '
    End Function

    Public Function conecta()
        Dim sInfo As String = ""
        Dim cnn As MySqlConnection = New MySqlConnection
        Dim dr As DataRow
        Dim odata As New ToolKitSQL.myssql
        Dim tta As Integer = 1
        Dim ssql As String = "Select * from sucursales where id=" & susursalr
        With odata
            If odata.dbOpen(cnn, sTargetdSincro, sInfo) Then
                If odata.getDr(cnn, dr, ssql, sInfo) Then
                    frmSincro.lbl_nombre.Text = dr("nombre").ToString
                    frmSincro.lbl_direccion.Text = dr("direccion").ToString
                    frmSincro.grid_eventos.Rows.Insert(0, "Conectado a Delsscom", Date.Now)
                End If
                cnn.Close()
            Else
                frmSincro.grid_eventos.Rows.Insert(0, "No se pudo Conectar a Delsscom", Date.Now)
                Return False
            End If
        End With

        Return True

    End Function

    Public Function dameIP2() As String
        Dim nombrePC As String
        Dim entradasIP As Net.IPHostEntry
        nombrePC = Dns.GetHostName
#Disable Warning BC40000
        entradasIP = Dns.GetHostByName(nombrePC)
#Enable Warning BC40000
        Dim direccion_Ip As String = entradasIP.AddressList(0).ToString

        Return direccion_Ip
    End Function

    Public Function TamImpre()
        Try
            Dim tam As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='TamImpre'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    tam = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return tam
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Function PreguntaImprime()
        Try
            Dim preg As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NoPrint FROM ticket WHERE Id=1"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    preg = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return preg
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Function ImpresoraImprimir()
        Try
            Dim impre As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Impresora from rutasimpresion WHERE Tipo='TICKET' AND Equipo='" & ObtenerNombreEquipo() & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impre = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return impre
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Function TraerNumCopias()
        Try
            Dim copias As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Copias from ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    copias = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return copias
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Function efectivocompleto()
        Try
            Dim impre As Integer = 0
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='CobroExacto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    impre = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return impre
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Function TraerSimbolo()
        Try
            Dim simbo As String = ""
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Simbolo'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    simbo = rd1(0).ToString
                End If
            End If
            rd1.Close()
            cnn1.Close()
            Return simbo
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Function

    Public Structure validaciones
        Shared audita As String = ""
    End Structure

    Public Structure P
        REM Catalogos
        Shared C_Empleados As Boolean = False '
        Shared C_Clientes As Boolean = False '
        Shared C_Proveedores As Boolean = False '
        Shared C_Monederos As Boolean = False '
        Shared C_Acreedores As Boolean = False '
        Shared C_Deudores As Boolean = False '
        Shared C_Gastos As Boolean = False '
        Shared C_CarAbo As Boolean = False '

        REM Asistencia
        Shared A_Horarios As Boolean = False '
        Shared A_Huella As Boolean = False '
        Shared A_Reporte As Boolean = False '
        Shared A_Asistencia As Boolean = False '

        REM Productos
        Shared P_Productos As Boolean = False '
        Shared P_Servicios As Boolean = False '
        Shared P_Precios As Boolean = False '
        Shared P_Promociones As Boolean = False '
        Shared P_Kits As Boolean = False '

        REM Compras
        Shared C_Pedidos As Boolean = False '
        Shared C_CPedidos As Boolean = False '
        Shared C_Compras As Boolean = False '
        Shared C_CCompras As Boolean = False '
        Shared C_NotasCred As Boolean = False '
        Shared C_CPagar As Boolean = False '
        Shared C_Abonos As Boolean = False '
        Shared C_Anticipos As Boolean = False '

        REM Ventas
        Shared V_Mostrador As Boolean = False '
        Shared V_Touch As Boolean = False '
        Shared V_Ventas As Boolean = False '
        Shared V_Cotizaciones As Boolean = False '
        Shared V_Pedidos As Boolean = False '
        Shared V_Devoluciones As Boolean = False '
        Shared V_Folios As Boolean = False '
        Shared V_Abonos As Boolean = False '
        Shared V_Cancelaciones As Boolean = False '
        Shared V_Precios As Boolean = False '

        REM Ingresos
        Shared I_CobroE As Boolean = False '
        Shared I_CobroD As Boolean = False '
        Shared I_Creditos As Boolean = False '
        Shared I_DocumentosC As Boolean = False '

        REM Egresos
        Shared E_PrestamoE As Boolean = False '
        Shared E_PrestamoD As Boolean = False '
        Shared E_Creditos As Boolean = False '
        Shared E_DocumentosP As Boolean = False '
        Shared E_Nomina As Boolean = False '
        Shared E_Transporte As Boolean = False '
        Shared E_Otro As Boolean = False '

        REM Reportes
        Shared R_Ventas As Boolean = False '
        Shared R_VentasG As Boolean = False '
        Shared R_Compras As Boolean = False '
        Shared R_CuentasC As Boolean = False '
        Shared R_CuentasP As Boolean = False '
        Shared R_Entradas As Boolean = False '
        Shared R_Salidas As Boolean = False '
        Shared R_Inventario As Boolean = False '
        Shared R_Ajuste As Boolean = False '

        REM Listados
        Shared L_Precios As Boolean = False '
        Shared L_Productos As Boolean = False '
        Shared L_Faltantes As Boolean = False '

        REM Facturas
        Shared F_Facturas As Boolean = False '
        Shared F_Reporte As Boolean = False '

        REM Administración
        Shared Ad_Permisos As Boolean = False '
        Shared Ad_Configs As Boolean = False '
        Shared Ad_Utilidades As Boolean = False '
        Shared Ad_Corte As Boolean = False '
    End Structure

    Public Function dameIP() As String

        Dim nombrePC As String
        Dim entradasIP As Net.IPHostEntry
        nombrePC = Dns.GetHostName
        entradasIP = Dns.GetHostEntry(nombrePC)
        Dim direccion_Ip As String = entradasIP.AddressList(0).ToString
        Return direccion_Ip

    End Function

    'Función para quitar los saltos de línea de un texto
    Public Function EliminarSaltosLinea(ByVal texto As String, caracterReemplazar As String) As String
        EliminarSaltosLinea = Replace(Replace(texto, Chr(10), caracterReemplazar), Chr(13), caracterReemplazar)
    End Function

    Public Sub crea_ruta(ByVal rutx As String)
        If Directory.Exists(rutx) Then
        Else
            Directory.CreateDirectory(rutx)
        End If
    End Sub

    'Numeros a letras (funciones que se tienen que revisar)
    Public Function Letras(ByVal numero As String) As String
        Dim palabras, entero, dec, flag As String
        Dim num, x, y As Integer

        flag = "N"

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"
        palabras = ""

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "CIEN "
                                Else
                                    palabras = palabras & "CIENTO "
                                End If
                            Case "2"
                                palabras = palabras & "DOSCIENTOS "
                            Case "3"
                                palabras = palabras & "TRESCIENTOS "
                            Case "4"
                                palabras = palabras & "CUATROCIENTOS "
                            Case "5"
                                palabras = palabras & "QUINIENTOS "
                            Case "6"
                                palabras = palabras & "SEISCIENTOS "
                            Case "7"
                                palabras = palabras & "SETECIENTOS "
                            Case "8"
                                palabras = palabras & "OTROCIENTOS "
                            Case "9"
                                palabras = palabras & "NOVECIENTOS "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "DIEZ "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "ONCE "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "DOCE "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "TRECE "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "CATORCE "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "QUINCE "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "DIECI"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "VEINTE "
                                    flag = "S"
                                Else
                                    palabras = palabras & "VEINTI"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "TREINTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "TREINTA Y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "CUARENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "CUARENTA Y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "CINCUENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "CINCUENTA Y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "SESENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "SESENTA Y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "SETENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "SETENTA Y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "OCHENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "OCHENTA Y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "NOVENTA "
                                    flag = "S"
                                Else
                                    palabras = palabras & "NOVENTA Y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "UNO "
                                    Else
                                        palabras = palabras & "UN "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "DOS "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "TRES "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "CUATRO "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "CINCO "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "SEIS "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "SIETE "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "OCHO "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "NUEVE "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                    Len(entero) <= 6) Then palabras = palabras & "MIL "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & "MILLÓN "
                    Else
                        palabras = palabras & "MILLONES "
                    End If
                End If
            Next y

            ''**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & dec & "/100 M.N."
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If
    End Function

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Public Function convLetras(ByVal numero As Double) As String
        Dim impTotal As String
        Dim cuenta As Integer
        Dim enteros As Integer
        Dim decimales As String

        Dim moneda As String = DatosRecarga("Moneda")

        Dim totalLetras As String

        impTotal = CStr(Format(numero, "##0.00"))
        cuenta = InStr(impTotal, ".")
        If cuenta = 0 Then
            cuenta = Len(impTotal)
        End If
        enteros = CInt(Mid(impTotal, 1, cuenta))
        decimales = Mid(impTotal, cuenta + 1, 4)
        totalLetras = Num2Text(enteros)
        totalLetras = UCase(totalLetras + " " & moneda & " ") + decimales + "/100 M.N."

        convLetras = totalLetras

    End Function

    'Funciones para la generación del número de mother y las sesiones de prueba
    Public Function SerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object =
            wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers =
            serial_numbers.Substring(2)

        Return serial_numbers
    End Function

    Public Function redSerie(ByVal root As String) As String
        Dim readFile As New StreamReader(root)
        Dim datos As String

        datos = readFile.ReadLine
        readFile.Close()
        redSerie = datos
    End Function

    Public Function redCont(ByVal root As String) As Integer
        Dim readFile As New StreamReader(root)
        Dim datos As Integer

        datos = readFile.ReadLine
        readFile.Close()
        redCont = datos
    End Function

    Public Function WriteCont(ByVal linea As Integer, ByVal root_file As String) As Boolean
        Dim Datos As Stream
        Dim StrWrite As StreamWriter

        Try
            Datos = File.Open(root_file, IO.FileMode.Create, IO.FileAccess.Write)
            Datos.Seek(0, IO.SeekOrigin.Begin)
            StrWrite = New StreamWriter(Datos)
            StrWrite.WriteLine(linea)
            StrWrite.Close()
            WriteCont = True

        Catch e As IOException
            MsgBox(e.Message)
            WriteCont = False
        End Try
    End Function

    'Función para corroborar sí existe o no un campo
    Public Function ColumnaExiste(connection As MySqlClient.MySqlConnection, tableName As String, columnName As String) As Boolean
        ' Verificar si la columna ya existe en la tabla
        Dim sql As String = $"SHOW COLUMNS FROM {tableName} LIKE '{columnName}';"
        Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand(sql, connection)
            Using reader As MySqlClient.MySqlDataReader = command.ExecuteReader()
                Return reader.HasRows
            End Using
        End Using

    End Function

    Public Function TablaExiste(connection As MySqlClient.MySqlConnection, tableName As String) As Boolean
        Try
            Dim sql As String = $"SHOW TABLES LIKE '{tableName}'"

            Using command As MySqlClient.MySqlCommand = New MySqlClient.MySqlCommand(sql, connection)
                Using reader As MySqlClient.MySqlDataReader = command.ExecuteReader()
                    Return reader.HasRows
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Genera códigos de barras
    Public Sub GeneraBarras(ByVal pic As PictureBox, ByVal codigo As String)
        Dim barcod As New Barcode128

        barcod.BarHeight = 200
        barcod.Code = codigo
        barcod.GenerateChecksum = True
        barcod.CodeType = Barcode.CODE128

        Try
            Dim bmp As New Bitmap(barcod.CreateDrawingImage(Color.Black, Color.White))
            Dim img As Image = New Bitmap(bmp.Width, bmp.Height)
            Dim grf As Graphics = Graphics.FromImage(img)

            grf.FillRectangle(New SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height)
            grf.DrawImage(bmp, 0, 0)
            pic.Image = img
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub GeneraBarras2(ByVal pic2 As PictureBox, ByVal codigo2 As String)
        Dim barcod2 As New Barcode128

        barcod2.BarHeight = 200
        barcod2.Code = codigo2
        barcod2.GenerateChecksum = True
        barcod2.CodeType = Barcode.CODE128

        Try
            Dim bmp2 As New Bitmap(barcod2.CreateDrawingImage(Color.Black, Color.White))
            Dim img2 As Image = New Bitmap(bmp2.Width, bmp2.Height)
            Dim grf2 As Graphics = Graphics.FromImage(img2)

            grf2.FillRectangle(New SolidBrush(Color.White), 0, 0, bmp2.Width, bmp2.Height)
            grf2.DrawImage(bmp2, 0, 0)
            pic2.Image = img2
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Module
