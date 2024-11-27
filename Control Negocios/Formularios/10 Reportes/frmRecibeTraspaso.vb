Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO
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
            If varrutabase = "" Then
                sTargetlocal = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"
            Else
                sTargetlocal = "server=" & varrutabase & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"
            End If
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
            Dim sSQL As String = "SELECT distinct Origen FROM traspasos where destino=" & susursalr & " and CargadoE=0"
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
                sSQL = "SELECT distinct NumTraspasosS FROM traspasos where destino=" & susursalr & " and CargadoE=0"
            Else
                sSQL = "SELECT distinct NumTraspasosS FROM traspasos where destino=" & susursalr & " and Origen=" & lblidorigen.Text & " and CargadoE=0"
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

    Private Sub btnreporte_Click(sender As Object, e As EventArgs) Handles btnreporte.Click
        Try
            btnreporte.Enabled = False
            btnGuardar.Enabled = False
            Label5.Visible = True
            grdcaptura.Rows.Clear()
            My.Application.DoEvents()
            consultaTraspasosEntrada()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub consultaTraspasosEntrada()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select T.*, S.nombre as XD from traspasos T, sucursales S  where S.id = T.Origen and T.CargadoE=0 and T.Destino = " & susursalr & " and T.Origen=" & lblidorigen.Text & " and NumTraspasosS=" & ComboBox1.Text & ""
        Dim ssqlinsertal As String = ""
        Dim ssql3 As String = ""
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim odata2 As New ToolKitSQL.myssql

        Dim maxIdTraspaso As Integer = 0

        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata2.dbOpen(cnn2, sTargetdSincro, sinfo) Then
                If odata2.getDt(cnn2, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        My.Application.DoEvents()

                        consultaDetalleTraspaso(dr("Id").ToString)
                    Next
                Else
                    'MsgBox(sinfo)
                End If
                cnn2.Close()
            Else
                'MsgBox(sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub


    Public Sub consultaDetalleTraspaso(ByVal Folio As String)
        Dim cnn3 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn4 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from traspasosdetalle where IdTraspaso=" & Folio
        Dim sSQL2 As String = ""
        Dim ssqlinsertal As String = ""
        Dim dt3 As New DataTable
        Dim dt4 As New DataTable
        Dim dt5 As New DataTable
        Dim d3 As DataRow
        Dim dr4 As DataRow
        Dim dr5 As DataRow
        Dim sinfo As String = ""
        Dim odata3 As New ToolKitSQL.myssql
        Dim odata4 As New ToolKitSQL.myssql
        Dim barras As String = ""

        If odata3.dbOpen(cnn3, sTargetlocal, sinfo) Then
            If odata4.dbOpen(cnn4, sTargetdSincro, sinfo) Then
                If odata4.getDt(cnn4, dt4, sSQL, sinfo) Then
                    For Each dr4 In dt4.Rows
                        If odata4.getDt(cnn4, dt5, "Select CodBarra from productos where COdigo='" & dr4("Codigo").ToString & "'", sinfo) Then
                            For Each dr5 In dt5.Rows
                                barras = dr5(0).ToString
                            Next
                        Else

                        End If
                        My.Application.DoEvents()
                        grdcaptura.Rows.Add(dr4("Codigo").ToString, dr4("Nombre").ToString, dr4("UVenta").ToString, dr4("Cantidad").ToString, dr4("Precio").ToString, dr4("Total").ToString, dr4("Fecha").ToString, dr4("Lote").ToString, dr4("FechaCad").ToString, barras)
                    Next
                Else
                    'MsgBox(sinfo)
                End If
                cnn4.Close()
            Else
                ' MsgBox(sinfo)
            End If
            cnn3.Close()
            My.Application.DoEvents()
            btnreporte.Enabled = True
            Label5.Visible = False
            btnGuardar.Enabled = True
            My.Application.DoEvents()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If grdcaptura.Rows.Count = 0 Then
                Exit Sub
            End If
            If MsgBox("¿Deseas Guardar el Traspaso Entrante?", vbQuestion + vbOKCancel, "Delsscom Farmacias") = vbCancel Then
                Exit Sub
            End If
            If lblusuario.Text = "" Then
                MsgBox("Ingresa tu contraseña para continuar", vbInformation + vbOKOnly, "Delsscom Farmacias")
                txtcontraseña.Focus.Equals(True)
                Exit Sub
            End If
            btnGuardar.Enabled = False
            My.Application.DoEvents()
            bajaTraspasosEntrada()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub bajaTraspasosEntrada()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select T.*, S.nombre as XD from traspasos T, sucursales S  where S.id = T.Origen and T.CargadoE=0 and T.Destino = " & susursalr & " And T.NumTraspasosS=" & ComboBox1.Text & " and T.Origen=" & lblidorigen.Text & ""

        Dim ssqlinsertal As String = ""
        Dim ssql3 As String = ""
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim odata2 As New ToolKitSQL.myssql

        Dim maxIdTraspaso As Integer = 0

        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata2.dbOpen(cnn2, sTargetdSincro, sinfo) Then
                If odata2.getDt(cnn2, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        My.Application.DoEvents()
                        ssqlinsertal = ""
                        'grid_eventos.Rows.Insert(0, "Bajando Traspaso Entrada folio " & dr("NumTraspasosE").ToString, Date.Now)
                        My.Application.DoEvents()
                        Dim fechapago As Date = dr("Fecha").ToString
                        Dim fechahora As Date = dr("Hora").ToString

                        If odata.runSp(cnn, "SELECT NUM_TRASLADO FROM traslados WHERE NUM_TRASLADO=" & ComboBox1.Text & "", sinfo) Then

                            If odata.runSp(cnn, "DELETE FROM traslados WHERE NUM_TRASLADO=" & ComboBox1.Text & "", sinfo) Then

                            End If
                        End If

                        ssqlinsertal = "INSERT INTO Traslados(Cargado,Nombre,Direccion,Usuario,FVenta,HVenta,FPago,FCancelado,Status,Comisionista,concepto,NUM_TRASLADO) " &
                                                 " VALUES (1,'INGRESO','0','0','" & Format(fechapago, "yyyy-MM-dd") & "','" & Format(fechahora, "yyyy-MM-dd HH:mm:ss") & "','" & Format(fechapago, "yyyy-MM-dd") & "','" & Format(fechapago, "yyyy-MM-dd HH:mm:ss") & "','PAGADO','" & dr("XD").ToString & "','ENTRADA'," & dr("NumTraspasosE").ToString & ")"

                        If odata.runSp(cnn, ssqlinsertal, sinfo) Then
                            odata.getDr(cnn, dr2, "select max(Folio) as XD from Traslados", "drdos")
                            maxIdTraspaso = dr2(0).ToString
                            bajaTrasEDetalle(dr("Id").ToString, maxIdTraspaso, dr("NumTraspasosE").ToString, dr("XD").ToString)
                            ssql3 = "update traspasos set CargadoE=1 where Id=" & dr("Id").ToString
                            If odata2.runSp(cnn2, ssql3, sinfo) Then
                                'grid_eventos.Rows.Insert(0, "Finaliza Traspaso Entrada folio " & dr("NumTraspasosE").ToString, Date.Now)
                                odata2.runSp(cnn2, "DELETE FROM actuinvtraspasos WHERE Cargado=1", sinfo)
                            End If
                        Else
                            'MsgBox("inserta " & sinfo)
                        End If

                    Next
                    MsgBox("Traspaso Registrado Correctamente")
                    btnGuardar.Enabled = True
                    My.Application.DoEvents()
                    Dim TPrint As String = "TICKET"
                    Dim Impresora As String = ""
                    cnn1.Close()
                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Impresora = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                    pSalida80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    pSalida80.Print()
                    My.Application.DoEvents()
                    btnNuevo.PerformClick()
                    My.Application.DoEvents()

                Else
                    'MsgBox("con consulta " & sinfo)
                End If
                cnn2.Close()
            Else
                'MsgBox("con sincro " & sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox("con local " & sinfo)
        End If
    End Sub

    Private Sub bajaTrasEDetalle(ByVal Folio As String, ByVal maxId As String, ByVal numTras As String, ByVal vardestino As String)
        Dim cnn3 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn4 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from traspasosdetalle where IdTraspaso=" & Folio
        Dim sSQL2 As String = ""
        Dim ssqlinsertal As String = ""
        Dim sqlactualizarcargado As String = ""
        Dim SQLBUSCADETALLE As String = ""
        Dim sqlactualizafoliodetalle As String = ""
        Dim sqlbuscarlote As String = ""
        Dim dt3 As New DataTable
        Dim dt4 As New DataTable
        Dim d3 As DataRow
        Dim dr4 As DataRow
        Dim dr44 As DataRow
        Dim sinfo As String = ""
        Dim odata3 As New ToolKitSQL.myssql
        Dim odata4 As New ToolKitSQL.myssql


        If odata3.dbOpen(cnn3, sTargetlocal, sinfo) Then
            If odata4.dbOpen(cnn4, sTargetdSincro, sinfo) Then
                If odata4.getDt(cnn4, dt4, sSQL, sinfo) Then
                    For Each dr4 In dt4.Rows
                        My.Application.DoEvents()
                        ssqlinsertal = ""
                        Dim fecha As Date = dr4("Fecha").ToString

                        SQLBUSCADETALLE = "SELECT Codigo,Num_Traslado FROM trasladosdet WHERE Codigo='" & dr4("Codigo").ToString & "' AND Num_Traslado=" & numTras & ""

                        If odata3.getDt(cnn3, dt3, SQLBUSCADETALLE, sinfo) Then

                            sqlactualizafoliodetalle = "UPDATE trasladosdet SET Folio=" & maxId & " WHERE Codigo='" & dr4("Codigo").ToString & "' AND Num_Traslado=" & numTras & ""
                            If odata3.runSp(cnn3, sqlactualizafoliodetalle, sinfo) Then

                                If odata4.runSp(cnn4, "UPDATE traspasosdetalle SET Cargado=1 WHERE IdTraspaso=" & Folio & " AND Codigo='" & dr4("Codigo").ToString & "'", sinfo) Then

                                End If
                            End If

                            sqlbuscarlote = "SELECT Codigo,Lote,Cantidad,FechaCad FROM actuinvtraspasos WHERE Codigo='" & dr4("Codigo").ToString & "' AND Cargado=1"

                            If odata4.getDr(cnn4, dr44, sqlbuscarlote, sinfo) Then

                                If odata3.getDr(cnn3, d3, "SELECT * FROM lotecaducidad WHERE Codigo='" & dr44("Codigo").ToString & "' AND Lote='" & dr44("Lote").ToString & "'", sinfo) Then
                                Else

                                    If dr44("Lote").ToString <> "" Then

                                        Dim fcad As Date = dr44("FechaCad").ToString
                                        Dim fechaca2 As String = ""
                                        fechaca2 = Format(fcad, "yyyy-MM")

                                        If odata3.runSp(cnn3, "INSERT INTO lotecaducidad(Codigo,Lote,Caducidad,Cantidad) VALUES('" & dr44("Codigo").ToString & "','" & dr44("Lote").ToString & "','" & fechaca2 & "'," & dr44("Cantidad").ToString & ")", sinfo) Then

                                        End If

                                    End If

                                End If


                            End If

                        Else

                            ssqlinsertal = "INSERT INTO TrasladosDet(Folio, Codigo, Nombre, Unidad, Cantidad, Precio, Total, Fecha, Comisionista, Depto, Grupo, concepto, num_traslado,Lote,FCaduca)" &
                                       " VALUES (" & maxId & ",'" & dr4("Codigo").ToString & "','" & dr4("Nombre").ToString & "','" & dr4("UVenta").ToString & "'," & dr4("Cantidad").ToString & "," & dr4("Precio").ToString &
                                       "," & dr4("Total").ToString & ",'" & Format(fecha, "yyyy-MM-dd") & "','" & vardestino &
                                       "','" & dr4("Depto").ToString & "','" & dr4("Grupo").ToString & "','ENTRADA'," & numTras & ",'" & dr4("Lote").ToString & "','" & dr4("FechaCad").ToString & "')"

                            If odata3.runSp(cnn3, ssqlinsertal, sinfo) Then

                                sqlactualizarcargado = "UPDATE traspasosdetalle SET Cargado=1 WHERE Codigo='" & dr4("Codigo").ToString & "' AND IdTraspaso=" & Folio & ""
                                If odata4.runSp(cnn4, sqlactualizarcargado, sinfo) Then

                                End If

                            End If
                            bajaExitTrasEntrada(dr4("Codigo").ToString)

                        End If



                    Next
                End If
                cnn4.Close()
            End If
            cnn3.Close()
        End If

    End Sub


    Private Sub bajaExitTrasEntrada(ByRef codxd As String)

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata2 As New ToolKitSQL.myssql
        Dim sSQL As String = "Select * from actuinvtraspasos where NumSuc = " & susursalr & " and Tipo = 'ENTRADA' and Codigo='" & codxd & "' AND Cargado=0"
        Dim ssql2 As String = ""
        Dim ssql3 As String = ""
        Dim sinfo As String = ""
        Dim ssqlinsertal As String = ""
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim dr As DataRow
        Dim dr2 As DataRow
        Dim dr3 As DataRow
        Dim MyExist As String = ""
        Dim MyNewEsist As String = ""

        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTargetlocal, sinfo) Then
                If odata2.dbOpen(cnn2, sTargetdSincro, sinfo) Then
                    If odata2.getDt(cnn2, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            My.Application.DoEvents()
                            If oData.getDr(cnn, dr2, "select Codigo,Existencia,Multiplo from Productos where Codigo = '" & Mid(dr("Codigo").ToString, 1, 6) & "'", "drDOS") Then
                                MyExist = 0
                                If CDec(dr2("Multiplo").ToString) > 1 And CDec(dr2("Existencia").ToString) > 0 Then
                                    MyExist = FormatNumber(CDec(dr2("Existencia").ToString), 2)
                                    If Len(dr("Codigo").ToString) > 6 Then
                                        MyNewEsist = CDec(MyExist) + CDec(dr("Cantidad").ToString)
                                    Else
                                        MyNewEsist = CDec(MyExist) + CDec(CDec(dr("Cantidad").ToString) * CDec(dr2("Multiplo").ToString))
                                    End If

                                Else
                                    MyExist = dr2("Existencia").ToString
                                    MyNewEsist = CDec(MyExist) + CDec(dr("Cantidad").ToString)
                                End If

                                Dim sqlnew As String = ""

                                If Len(dr("Codigo").ToString) > 6 Then
                                    sqlnew = "update Productos set Existencia = Existencia + " & CDec(dr("Cantidad").ToString) & ", CargadoInv = 0  where Codigo = '" & Mid(dr("Codigo").ToString, 1, 6) & "'"
                                Else
                                    sqlnew = "update Productos set Existencia = Existencia + " & CDec(CDec(dr("Cantidad").ToString) * CDec(dr2("Multiplo").ToString)) & ", CargadoInv = 0  where Codigo = '" & Mid(dr("Codigo").ToString, 1, 6) & "'"
                                End If



                                If oData.runSp(cnn, sqlnew, sinfo) Then
                                    If Len(dr("Codigo").ToString) > 6 Then
                                        ssql3 = "insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,fecha,Usuario,Inicial,Final,Folio) values('" & dr("Codigo").ToString & "','" & dr("Descripcion").ToString & "','Entrada por Traspaso Nube'," & CDec(dr("Cantidad").ToString) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','Nube','" & MyExist & "','" & MyNewEsist & "','')"
                                    Else
                                        ssql3 = "insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,fecha,Usuario,Inicial,Final,Folio) values('" & dr("Codigo").ToString & "','" & dr("Descripcion").ToString & "','Entrada por Traspaso Nube'," & CDec(CDec(dr("Cantidad").ToString) * CDec(dr2("Multiplo").ToString)) & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','Nube','" & MyExist & "','" & MyNewEsist & "','')"
                                    End If

                                    If odata2.runSp(cnn2, "UPDATE actuinvtraspasos SET Cargado=1 where Codigo='" & dr("Codigo").ToString & "' AND Id = " & dr("Id").ToString & "", sinfo) Then

                                    End If

                                    oData.runSp(cnn, ssql3, sinfo)
                                    If Trim(dr("Lote").ToString) <> "" Then
                                        actualizarLoteCad(dr("Codigo").ToString, dr("Lote").ToString, dr("FechaCad").ToString, dr("Cantidad").ToString, 1)
                                    End If
                                    If odata2.runSp(cnn2, "delete from actuinvtraspasos where Cargado=1 AND Id = " & dr("Id").ToString & "", sinfo) Then

                                    End If
                                End If



                            Else
                                If odata2.getDr(cnn2, dr3, "Select * from productos where Codigo='" & dr("Codigo").ToString & "'", sinfo) Then
                                    ssqlinsertal = "Insert Into Productos(Codigo,Nombre,ProvPri,ProvRes,UCompra,UVenta,VentaMin,MCD,Multiplo,Departamento,Grupo,PrecioCompra,PorcentageMin,Porcentage,PrecioVenta,PrecioVentaIVA,PecioVentaMinIVA,IVA,Existencia,id_tbMoneda,PercentIVAret,NombreLargo,IIEPS,isr,ClaveSat,ClaveUnidadSat,MSeries,CargadoInv) " &
                                                            "VALUES('" & dr3("Codigo").ToString & "','" & dr3("Nombre").ToString & "','" & dr3("proveedor").ToString & "',0,'" & dr3("UVenta").ToString & "','" & dr3("UVenta").ToString &
                                                           "','" & dr3("UVenta").ToString & "',1,1,'" & dr3("Depto").ToString & "','" & dr3("Grupo").ToString & "','" & dr3("PrecioCompra").ToString &
                                                          "','0','0','0','" & dr3("PrecioVentaIVA").ToString & "','0','" & dr3("IVA").ToString & "'," & dr("Cantidad").ToString &
                                                         ",1,0,'',0,0,'" & dr3("clavesat").ToString & "','" & dr3("claveunisat").ToString & "',0,0)"
                                    If oData.runSp(cnn, ssqlinsertal, sinfo) Then
                                        MyExist = 0
                                        MyNewEsist = CDec(MyExist) + CDec(dr("Cantidad").ToString)
                                        ssql3 = "insert into Cardex(Codigo,Nombre,Movimiento,Cantidad,Precio,fecha,Usuario,Inicial,Final,Folio) values('" & dr3("Codigo").ToString & "','" & dr3("Nombre").ToString & "','Entrada por Traspaso Nube'," & dr("Cantidad").ToString & ",'0','" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','Nube','" & MyExist & "','" & MyNewEsist & "','')"
                                        oData.runSp(cnn, ssql3, sinfo)
                                        If Trim(dr("Lote").ToString) <> "" Then
                                            actualizarLoteCad(dr("Codigo").ToString, dr("Lote").ToString, dr("FechaCad").ToString, dr("Cantidad").ToString, 1)
                                        End If
                                        If odata2.runSp(cnn2, "delete from actuinvtraspasos where Id = " & dr("Id").ToString & "", sinfo) Then

                                        End If
                                        'grid_eventos.Rows.Insert(0, "Finaliza Ajuste de Inventario " & dr3("Nombre").ToString, Date.Now)
                                    End If
                                End If
                            End If
                        Next
                    End If
                    cnn2.Close()
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub actualizarLoteCad(ByVal codigo As String, ByVal lote As String, ByVal fechacad As String, ByVal cantidad As Integer, ByVal tipo As Integer)

        Dim cnn100 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn2100 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from LoteCaducidad where Codigo = '" & Trim(codigo) & "' and Cantidad > 0 and Lote='" & lote & "'"
        Dim ssqlinsertal As String = ""
        Dim ssql3 As String = ""
        Dim dt100 As New DataTable
        Dim dt2100 As New DataTable
        Dim dr100 As DataRow
        Dim sinfo As String = ""
        Dim odata100 As New ToolKitSQL.myssql
        Dim odata2100 As New ToolKitSQL.myssql
        Dim banderaentra As Integer = 0

        If odata100.dbOpen(cnn100, sTargetlocal, sinfo) Then
            If odata2100.dbOpen(cnn2100, sTargetdSincro, sinfo) Then
                If odata100.getDt(cnn100, dt100, sSQL, sinfo) Then
                    For Each dr100 In dt100.Rows
                        My.Application.DoEvents()
                        ssqlinsertal = ""
                        If tipo = 1 Then
                            If Trim(dr100("Lote").ToString) = Trim(lote) Then
                                banderaentra = 1
                                ssqlinsertal = "Update LoteCaducidad set Cantidad = " & CInt(dr100("Cantidad").ToString) + cantidad & " where id = " & dr100("id").ToString & ""
                            End If
                        Else
                            If Trim(dr100("Lote").ToString) = Trim(lote) Then
                                banderaentra = 1
                                ssqlinsertal = "Update LoteCaducidad set Cantidad = " & CInt(dr100("Cantidad").ToString) - cantidad & " where id = " & dr100("id").ToString & ""
                            End If
                        End If
                        If banderaentra = 1 Then
                            If odata100.runSp(cnn100, ssqlinsertal, sinfo) Then
                            Else
                                MsgBox(sinfo)
                            End If
                        End If

                        If banderaentra = 0 Then
                            ssqlinsertal = "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & Trim(codigo) & "','" & Trim(lote) & "','" & Trim(fechacad) & "'," & Trim(cantidad) & ")"
                            If odata100.runSp(cnn100, ssqlinsertal, sinfo) Then

                            End If
                        End If
                    Next

                Else
                    ssqlinsertal = ""
                    If tipo = 1 Then
                        Dim fcad As Date = fechacad
                        fechacad = Format(fcad, "yyyy-MM")
                        ssqlinsertal = "insert into LoteCaducidad(Codigo,Lote,Caducidad,Cantidad) values('" & Trim(codigo) & "','" & Trim(lote) & "','" & Trim(fechacad) & "'," & Trim(cantidad) & ")"
                    Else
                    End If
                    If odata100.runSp(cnn100, ssqlinsertal, sinfo) Then
                    End If
                End If
                cnn2100.Close()
            End If
            cnn100.Close()
        End If
    End Sub

    Public Sub limpiaTodo()
        grdcaptura.Rows.Clear()
        ComboBox1.Text = ""
        cbo.Text = ""
        lblidorigen.Text = ""
        txtcontraseña.Text = ""
        lblusuario.Text = ""
        Label5.Visible = False
        ComboBox1.Items.Clear()
        cbo.Items.Clear()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        limpiaTodo()
    End Sub

    Private Sub pSalida80_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles pSalida80.PrintPage
        'Fuentes prederminadas
        Dim tipografia As String = "Lucida Sans Typewriter"
        Dim fuente_datos As New Drawing.Font(tipografia, 10, FontStyle.Regular)
        Dim fuente_prods As New Drawing.Font(tipografia, 9, FontStyle.Regular)
        Dim fuente_fecha As New Drawing.Font(tipografia, 8, FontStyle.Regular)
        'Variables
        Dim sc As New StringFormat With {.Alignment = StringAlignment.Center}
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}
        Dim pen As New Pen(Brushes.Black, 1)
        Dim Y As Double = 0
        Dim nLogo As String = DatosRecarga("LogoG")
        Dim Logotipo As Drawing.Image = Nothing
        Dim tLogo As String = DatosRecarga("TipoLogo")
        Dim simbolo As String = DatosRecarga("Simbolo")
        Dim Pie As String = ""

        On Error GoTo milky

        '[°]. Logotipo
        If tLogo <> "SIN" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                Logotipo = Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
            End If
            If tLogo = "CUAD" Then
                e.Graphics.DrawImage(Logotipo, 80, 0, 120, 120)
                Y += 130
            End If
            If tLogo = "RECT" Then
                e.Graphics.DrawImage(Logotipo, 30, 0, 240, 110)
                Y += 120
            End If
        Else
            Y = 0
        End If

        '[°]. Datos del negocio
        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select Pie2,Cab0,Cab1,Cab2,Cab3,Cab4,Cab5,Cab6 from Ticket"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                Pie = rd1("Pie2").ToString
                'Razón social
                If rd1("Cab0").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab0").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'RFC
                If rd1("Cab1").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab1").ToString, New Drawing.Font(tipografia, 10, FontStyle.Bold), Brushes.Black, 140, Y, sc)
                    Y += 12.5
                End If
                'Calle  N°.
                If rd1("Cab2").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab2").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Colonia
                If rd1("Cab3").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab3").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Delegación / Municipio - Entidad
                If rd1("Cab4").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab4").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Teléfono
                If rd1("Cab5").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab5").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                'Correo
                If rd1("Cab6").ToString() <> "" Then
                    e.Graphics.DrawString(rd1("Cab6").ToString, New Drawing.Font(tipografia, 9, FontStyle.Regular), Brushes.Gray, 140, Y, sc)
                    Y += 12
                End If
                Y += 17
            End If
        Else
            Y += 0
        End If
        rd1.Close()

        '[1]. Datos de la venta
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString(" - T R A S P A S O - ", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 14
        e.Graphics.DrawString("E N T R A D A", New Drawing.Font(tipografia, 12, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 12
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        e.Graphics.DrawString("Folio: " & ComboBox1.Text, fuente_fecha, Brushes.Black, 285, Y, sf)
        e.Graphics.DrawString("Fecha: " & Format(Date.Now, "d/MM/yyyy HH:mm:ss"), fuente_fecha, Brushes.Black, 1, Y)

        Y += 17
        e.Graphics.DrawString("Origen: " & cbo.Text, fuente_fecha, Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("Destino: " & lblSuc.Text, fuente_fecha, Brushes.Black, 1, Y)
        Y += 12

        Y += 4
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 12


        e.Graphics.DrawString("PRODUCTO", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 15
        e.Graphics.DrawString("CANTIDAD", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 1, Y)
        e.Graphics.DrawString("PRECIO U.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 184, Y, sf)
        e.Graphics.DrawString("TOTAL.", New Drawing.Font(tipografia, 9, FontStyle.Bold), Brushes.Black, 235, Y)
        Y += 6
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Dim total_prods As Double = 0

        For miku As Integer = 0 To grdcaptura.Rows.Count - 1
            If grdcaptura.Rows(miku).Cells(1).Value.ToString() <> "" And grdcaptura.Rows(miku).Cells(0).Value.ToString = "" Then
                Y -= 5
                e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 1, 25), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                If Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 26, 50) <> "" Then
                    Y += 11
                    e.Graphics.DrawString(Mid(grdcaptura.Rows(miku).Cells(1).Value.ToString(), 26, 50), New Drawing.Font(tipografia, 7, FontStyle.Italic), Brushes.Black, 1, Y)
                End If
                Y += 21
                Continue For
            End If
            Dim codigo As String = grdcaptura.Rows(miku).Cells(0).Value.ToString()
            Dim nombre As String = grdcaptura.Rows(miku).Cells(1).Value.ToString()
            Dim unidad As String = grdcaptura.Rows(miku).Cells(2).Value.ToString()
            Dim canti As Double = grdcaptura.Rows(miku).Cells(3).Value.ToString()
            Dim precio As Double = grdcaptura.Rows(miku).Cells(4).Value.ToString()
            Dim total As Double = grdcaptura.Rows(miku).Cells(5).Value.ToString()
            Dim barras As String = grdcaptura.Rows(miku).Cells(9).Value.ToString()
            'Dim existencia As Double = grdcaptura.Rows(miku).Cells(6).Value.ToString()
            'Dim barras As String = grdcaptura.Rows(miku).Cells(7).Value.ToString()
            Dim lote As String = grdcaptura.Rows(miku).Cells(7).Value.ToString()
            Dim caducidad As Date = Date.Now
            Dim cantidadlote As Double = 0

            If lote <> "" Then
                lote = grdcaptura.Rows(miku).Cells(7).Value.ToString()
                caducidad = grdcaptura.Rows(miku).Cells(8).Value.ToString()
            End If
            e.Graphics.DrawString(barras, fuente_prods, Brushes.Black, 1, Y)
            e.Graphics.DrawString(Mid(nombre, 1, 28), fuente_prods, Brushes.Black, 120, Y)
            Y += 15

            e.Graphics.DrawString(canti, fuente_prods, Brushes.Black, 50, Y, sf)
            e.Graphics.DrawString(unidad, fuente_prods, Brushes.Black, 55, Y)
            e.Graphics.DrawString(simbolo & FormatNumber(precio, 1), fuente_prods, Brushes.Black, 180, Y, sf)
            e.Graphics.DrawString(simbolo & FormatNumber(total, 1), fuente_prods, Brushes.Black, 285, Y, sf)
            Y += 17

            If lote <> "" Then
                e.Graphics.DrawString("Lote: " & lote, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 1, Y)
                e.Graphics.DrawString("Caducidad: " & Format(caducidad, "MM-yyyy"), New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 93, Y)
                e.Graphics.DrawString("Cant.: " & canti, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 285, Y, sf)
                Y += 18
            End If
            total_prods = total_prods + canti
        Next
        Y -= 1
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 15
        e.Graphics.DrawString("TOTAL DE PRODUCTOS " & total_prods, New Drawing.Font(tipografia, 8, FontStyle.Bold), Brushes.Black, 140, Y, sc)
        Y += 7
        e.Graphics.DrawString("--------------------------------------------------------", New Drawing.Font(tipografia, 12, FontStyle.Regular), Brushes.Black, 1, Y)
        Y += 18

        Y += 18
        e.Graphics.DrawString("Traspaso aceptado por " & lblusuario.Text, New Drawing.Font(tipografia, 7, FontStyle.Regular), Brushes.Black, 142.5, Y, sc)

        e.HasMorePages = False
        Exit Sub
milky:
        MsgBox("No se pudo generar el documento, a continuación se muestra la descripción del error." & vbNewLine & vbNewLine & Err.Number & " - " & Err.Description)
        cnn1.Close()
        Exit Sub
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        Try
            If AscW(e.KeyChar) = Keys.Enter Then
                If txtcontraseña.Text <> "" Then
                    Try
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select Alias,IdEmpleado from Usuarios where Clave='" & txtcontraseña.Text & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then
                                lblusuario.Text = rd1("Alias").ToString
                            End If
                        Else
                            MsgBox("Contraseña incorrecta, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtcontraseña.SelectAll()
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                        rd1.Close()
                        cnn1.Close()

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                    btnGuardar.Focus().Equals(True)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        pSalida80.Print()
    End Sub
End Class