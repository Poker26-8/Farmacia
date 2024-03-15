Imports System.Data.SqlClient
Imports Gma.QrCodeNet.Encoding.DataEncodation
Imports MySql.Data.MySqlClient

Public Class datos_delsscom

    Private config As datos_c
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long
    Dim servidor As String = ""
    Dim puerto As String = ""
    Dim seguridad As Boolean = False

    Private Sub guarda_btn_Click(sender As Object, e As EventArgs) Handles guarda_btn.Click
        salva_datos()
    End Sub

    Public Sub salva_datos()
        Try
            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_CONF_FACTURAS, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(config)
            config.ip_configuracion = txt_server.Text
            config.base_configuracion = txt_base.Text
            config.usuario_configuracion = txt_usuario.Text
            config.password_configuracion = txt_contraseña.Text

            ipserver = Trim(config.ip_configuracion)
            database = Trim(config.base_configuracion)
            userbd = Trim(config.usuario_configuracion)
            passbd = Trim(config.password_configuracion)

            FilePut(filenum, config, 1)

            FileClose()
            sTargetMYSQL = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=300"

            MsgBox("Guardado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnguarda_Click(sender As Object, e As EventArgs) Handles btnguarda.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub chkFactGob_Click(sender As Object, e As EventArgs) Handles chkFactGob.Click
        Dim cnn As MySqlConnection = New MySqlConnection
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            Dim comando As SqlCommand
            If chkFactGob.Checked = True Then
                If .dbOpen(cnn, sTarget, sinfo) Then
                    Dim ssql2 As String = "update Formatos set NumPart = 1 where Facturas = 'SHIBBOLETH'"
                    If oData.runSp(cnn, ssql2, sinfo) Then
                        MsgBox("Actualizado Correctamente")
                    Else
                        MsgBox(sinfo)
                    End If
                    cnn.Close()
                End If
            Else
                If .dbOpen(cnn, sTarget, sinfo) Then
                    Dim ssql2 As String = "update Formatos set NumPart = 0 where Facturas = 'SHIBBOLETH'"
                    If oData.runSp(cnn, ssql2, sinfo) Then
                        MsgBox("Actualizado Correctamente")
                    Else
                        MsgBox(sinfo)
                    End If
                    cnn.Close()
                End If
            End If
            cnn.Close()
        End With
    End Sub

    Private Sub datos_delsscom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cnn As MySqlConnection = New MySqlConnection
        ' Dim sSQL As String = "Select Id from Clientes where RFC = '" & Trim(Cmb_RFC.Text) & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "Select NumPart from Formatos where Facturas = 'SHIBBOLETH'", sinfo) Then
                    If CDec(dr(0).ToString) = 1 Then
                        chkFactGob.Checked = True
                    Else
                        chkFactGob.Checked = False
                    End If
                End If
            End If
        End With

        consultaaa()
    End Sub

    Private Sub consultaaa()
        Dim connectionString As String = "server=" & servidor & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Dim query As String = "SHOW DATABASES LIKE '%cn%'"
                Using command As New MySqlCommand(query, connection)
                    Using reader As MySqlDataReader = command.ExecuteReader()
                        Dim count As Integer = 0
                        While reader.Read()
                            Dim dbName As String = reader.GetString(0)
                            count += 1
                        End While
                        lblsoy.Text = count
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then Exit Sub
        lblproceso.Visible = True
        Button4.Enabled = False
        crea()
        lblproceso.Visible = False
        Button4.Enabled = True
        MsgBox("Base Creada Correctamente")
    End Sub

    Public Sub crea()
        Try
            Dim empieza As Integer = lblsoy.Text
            empieza = empieza + 1
            Dim final As Integer = lblsoy.Text
            final = final + TextBox1.Text
            Dim soy As Integer = TextBox1.Text
            For xxx = empieza To final
                Process.Start(My.Application.Info.DirectoryPath & "\CreateDB_Users" & xxx & ".bat")

                System.Threading.Thread.Sleep(5000)
                Dim cnnprueba As MySqlConnection = New MySqlConnection
                Dim sinfo As String = ""
                Dim odata As New ToolKitSQL.myssql
                Dim sTargetprueba = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn" & xxx & ";persist security info=false;connect timeout=300"
                'Dim sTargetprueba = "Server=localhost;user id = root; password=;"
                With odata
                    If .dbOpen(cnnprueba, sTargetprueba, sinfo) Then

                        'promos
                        .runSp(cnnprueba, vartablapromos, sinfo)
                        .runSp(cnnprueba, varKeypromos, sinfo)
                        .runSp(cnnprueba, varAutopromos, sinfo)

                        'clienteeliminado
                        .runSp(cnnprueba, vartablaclienteeliminado, sinfo)
                        .runSp(cnnprueba, varKeyclienteeliminado, sinfo)
                        .runSp(cnnprueba, varAutoclienteeliminado, sinfo)

                        'productoeliminado
                        .runSp(cnnprueba, vartablaproductoeliminado, sinfo)
                        .runSp(cnnprueba, varKeyproductoeliminado, sinfo)
                        .runSp(cnnprueba, varAutoproductoeliminado, sinfo)

                        'pedidostemporal
                        .runSp(cnnprueba, vartablapedidostemporal, sinfo)
                        .runSp(cnnprueba, varKeypedidostemporal, sinfo)
                        .runSp(cnnprueba, varAutopedidostemporal, sinfo)

                        ' pedidoeliminado
                        .runSp(cnnprueba, vartablaPedidoEliminado, sinfo)
                        .runSp(cnnprueba, varKeypedidoeliminado, sinfo)
                        .runSp(cnnprueba, varAutopedidoeliminado, sinfo)

                        'detalle_nomina
                        .runSp(cnnprueba, vartabladetallenomina, sinfo)
                        .runSp(cnnprueba, varKeydetallenomina, sinfo)
                        .runSp(cnnprueba, varAutodetallenomina, sinfo)

                        'tipoincapacidadsat
                        .runSp(cnnprueba, vartablatipoincapacidadsat, sinfo)
                        Dim dtprueba11 As New DataTable
                        If .getDt(cnnprueba, dtprueba11, "SELECT * from tipoincapacidadsat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatipoincapacidadsat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyotipoincapacidadsat, sinfo)
                        .runSp(cnnprueba, varAutotipoincapacidadsat, sinfo)

                        'tiponomina
                        .runSp(cnnprueba, vartablatiponomina, sinfo)
                        Dim dtprueba10 As New DataTable
                        If .getDt(cnnprueba, dtprueba10, "SELECT * from tiponomina", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatiponomina, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyotiponomina, sinfo)
                        .runSp(cnnprueba, varAutotiponomina, sinfo)


                        'otrospagos
                        .runSp(cnnprueba, vartablaotrospagos, sinfo)
                        Dim dtprueba9 As New DataTable
                        If .getDt(cnnprueba, dtprueba9, "SELECT * from otrospagos", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaotrospagos, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyotrospagos, sinfo)
                        .runSp(cnnprueba, varAutootrospagos, sinfo)

                        'tipopercepcioncontable
                        .runSp(cnnprueba, vartablatipopercepcioncontable, sinfo)
                        Dim dtprueba8 As New DataTable
                        If .getDt(cnnprueba, dtprueba8, "SELECT * from tipo_percepcion_contable", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatipopercepcioncontable, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytipopercepcioncontable, sinfo)
                        .runSp(cnnprueba, varAutotipopercepcioncontable, sinfo)

                        'tipodeduccioncontable
                        .runSp(cnnprueba, vartablatipodeduccioncontable, sinfo)
                        Dim dtprueba7 As New DataTable
                        If .getDt(cnnprueba, dtprueba7, "SELECT * from tipo_deduccion_contable", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatipodeduccioncontable, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytipodeduccioncontable, sinfo)
                        .runSp(cnnprueba, varAutotipodeduccioncontable, sinfo)

                        'riesgopuesto
                        .runSp(cnnprueba, vartablariesgopuesto, sinfo)
                        Dim dtprueba6 As New DataTable
                        If .getDt(cnnprueba, dtprueba6, "SELECT * from riesgo_puesto", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertariesgopuesto, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyriesgopuesto, sinfo)
                        .runSp(cnnprueba, varAutoriesgopuesto, sinfo)

                        'tipocontrato
                        .runSp(cnnprueba, vartablatipocontrato, sinfo)
                        Dim dtprueba5 As New DataTable
                        If .getDt(cnnprueba, dtprueba5, "SELECT * from tipo_contrato", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatipocontrato, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytipocontrato, sinfo)
                        .runSp(cnnprueba, varAutotipocontrato, sinfo)

                        'tipojornada
                        .runSp(cnnprueba, vartablatipojornada, sinfo)
                        Dim dtprueba4 As New DataTable
                        If .getDt(cnnprueba, dtprueba4, "SELECT * from tipo_jornada", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatipojornada, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytipojornada, sinfo)
                        .runSp(cnnprueba, varAutotipojornada, sinfo)

                        'periodicidad_pago
                        .runSp(cnnprueba, vartablaperiodicidadpago, sinfo)
                        Dim dtprueba3 As New DataTable
                        If .getDt(cnnprueba, dtprueba3, "SELECT * from periodicidad_pago", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaperiodicidadpago, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyperiodicidadpago, sinfo)
                        .runSp(cnnprueba, varAutoperiodicidadpago, sinfo)

                        'regimencontrataciontrabajador
                        .runSp(cnnprueba, vartablaregimencontrataciontrabajador, sinfo)
                        Dim dtprueba2 As New DataTable
                        If .getDt(cnnprueba, dtprueba2, "SELECT * from regimen_contratacion_trabajador", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaregimencontrataciontrabajador, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyregimencontrataciontrabajador, sinfo)
                        .runSp(cnnprueba, varAutoregimencontrataciontrabajador, sinfo)


                        'habitacion
                        .runSp(cnnprueba, vartablahabitacion, sinfo)
                        .runSp(cnnprueba, varKeyhabitacion, sinfo)
                        .runSp(cnnprueba, varAutohabitacion, sinfo)

                        'detallehotel
                        .runSp(cnnprueba, vartabladetallehotel, sinfo)
                        .runSp(cnnprueba, varKeydetallehotel, sinfo)
                        .runSp(cnnprueba, varAutodetallehotel, sinfo)

                        'controlserviciodet
                        .runSp(cnnprueba, vartablacontrolserviciosdet, sinfo)
                        .runSp(cnnprueba, varKeycontrolserviciodet, sinfo)
                        .runSp(cnnprueba, varAutocontrolserviciodet, sinfo)

                        'controlservicio
                        .runSp(cnnprueba, vartablacontrolservicios, sinfo)
                        .runSp(cnnprueba, varKeycontrolservicio, sinfo)
                        .runSp(cnnprueba, varAutocontrolservicio, sinfo)

                        .runSp(cnnprueba, vartablahisasigpc, sinfo)
                        .runSp(cnnprueba, varKeyhisasigpc, sinfo)
                        .runSp(cnnprueba, varAutohisasigpc, sinfo)

                        'vtaimpresion
                        .runSp(cnnprueba, vartablavtaimpresion, sinfo)
                        .runSp(cnnprueba, varKeyvtaimpresion, sinfo)
                        .runSp(cnnprueba, varAutovtaimpresion, sinfo)


                        'REP_COMANDAS
                        .runSp(cnnprueba, vartablarepcomandas, sinfo)
                        .runSp(cnnprueba, varKeyrepcomandas, sinfo)
                        .runSp(cnnprueba, varAutorepcomandas, sinfo)

                        .runSp(cnnprueba, vartablarefaccionaria, sinfo)
                        .runSp(cnnprueba, varKeyrefaccionaria, sinfo)
                        .runSp(cnnprueba, varAutorefaccionaria, sinfo)

                        .runSp(cnnprueba, vartablavehiculo, sinfo)
                        .runSp(cnnprueba, varKeyvehiculo, sinfo)
                        .runSp(cnnprueba, varAutovehiculo, sinfo)

                        .runSp(cnnprueba, vartablacomandasveh, sinfo)
                        .runSp(cnnprueba, varKeycomandasveh, sinfo)
                        .runSp(cnnprueba, varAutocomandasveh, sinfo)

                        .runSp(cnnprueba, vartablapromociones, sinfo)
                        .runSp(cnnprueba, varKeypromociones, sinfo)
                        .runSp(cnnprueba, varAutopromociones, sinfo)

                        .runSp(cnnprueba, vartablalumnos, sinfo)
                        .runSp(cnnprueba, varKeyalumnos, sinfo)
                        .runSp(cnnprueba, varAutoalumnos, sinfo)

                        .runSp(cnnprueba, vartablagrupos, sinfo)
                        .runSp(cnnprueba, varKeygrupos, sinfo)
                        .runSp(cnnprueba, varAutogrupos, sinfo)

                        .runSp(cnnprueba, vartablaextras, sinfo)
                        .runSp(cnnprueba, varKeyextras, sinfo)
                        .runSp(cnnprueba, varAutoextras, sinfo)

                        .runSp(cnnprueba, vartablapreferencias, sinfo)
                        .runSp(cnnprueba, varKeyprefecia, sinfo)
                        .runSp(cnnprueba, varAutopreferencias, sinfo)

                        .runSp(cnnprueba, vartablahisasigpc, sinfo)
                        .runSp(cnnprueba, varKeyhisasigpc, sinfo)
                        .runSp(cnnprueba, varAutohisasigpc, sinfo)

                        .runSp(cnnprueba, vartablamesa, sinfo)
                        .runSp(cnnprueba, varKeymesa, sinfo)
                        .runSp(cnnprueba, varAutomesa, sinfo)

                        .runSp(cnnprueba, vartablaasigpc, sinfo)
                        .runSp(cnnprueba, varKeyasigpc, sinfo)
                        .runSp(cnnprueba, varAutoasigpc, sinfo)

                        .runSp(cnnprueba, vartablacomandas1, sinfo)
                        .runSp(cnnprueba, varKeycomandas1, sinfo)
                        .runSp(cnnprueba, varAutocomandas1, sinfo)

                        .runSp(cnnprueba, vartablacomandas, sinfo)
                        .runSp(cnnprueba, varKeycomandas, sinfo)
                        .runSp(cnnprueba, varAutocomandas, sinfo)

                        .runSp(cnnprueba, vartablaabonoe, sinfo)
                        .runSp(cnnprueba, varKeyabonoe, sinfo)
                        .runSp(cnnprueba, varAutoabonoe, sinfo)

                        .runSp(cnnprueba, vartablaabonoi, sinfo)
                        .runSp(cnnprueba, varKeyabonoi, sinfo)
                        .runSp(cnnprueba, varAutoabonoi, sinfo)

                        .runSp(cnnprueba, vartablaAcreedores, sinfo)
                        .runSp(cnnprueba, varKeyacreedores, sinfo)
                        .runSp(cnnprueba, varAutoacreedores, sinfo)

                        .runSp(cnnprueba, vartablaasistencia, sinfo)
                        .runSp(cnnprueba, varKeyasistencia, sinfo)
                        .runSp(cnnprueba, varAutoasistencia, sinfo)

                        .runSp(cnnprueba, vartablaasistenciagym, sinfo)
                        .runSp(cnnprueba, varKeyasistenciagym, sinfo)
                        .runSp(cnnprueba, varAutoasistenciagym, sinfo)

                        .runSp(cnnprueba, vartablaauditoria, sinfo)
                        .runSp(cnnprueba, varKeyauditoria, sinfo)
                        .runSp(cnnprueba, varAutoauditoria, sinfo)

                        .runSp(cnnprueba, vartablaauxcompras, sinfo)
                        .runSp(cnnprueba, varKeyauxcompras, sinfo)
                        .runSp(cnnprueba, varAutoauxcompras, sinfo)

                        .runSp(cnnprueba, vartablaauxcomprasseries, sinfo)
                        .runSp(cnnprueba, varKeyauxcomprasseries, sinfo)
                        .runSp(cnnprueba, varAutoauxcomprasseries, sinfo)

                        .runSp(cnnprueba, vartablaauxpedidos, sinfo)
                        .runSp(cnnprueba, varKeyauxpedidos, sinfo)
                        .runSp(cnnprueba, varAutoauxpedidos, sinfo)

                        .runSp(cnnprueba, vartablabancos, sinfo)
                        Dim dtprueba As New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from bancos", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertabancos, sinfo)
                        End If

                        .runSp(cnnprueba, vartablacardex, sinfo)
                        .runSp(cnnprueba, varKeycardex, sinfo)
                        .runSp(cnnprueba, varAutocardex, sinfo)

                        .runSp(cnnprueba, vartablacargosabonos, sinfo)

                        .runSp(cnnprueba, vartablacartaporte, sinfo)
                        .runSp(cnnprueba, varKeycartaporte, sinfo)
                        .runSp(cnnprueba, varAutocartaporte, sinfo)

                        .runSp(cnnprueba, vartablacuentasbancarias, sinfo)
                        .runSp(cnnprueba, varKeycuentasbancarias, sinfo)
                        .runSp(cnnprueba, varAutocuentasbancarias, sinfo)

                        .runSp(cnnprueba, vartablacartaportedet, sinfo)
                        .runSp(cnnprueba, varKeycartaportedet, sinfo)
                        .runSp(cnnprueba, varAutocartaportedet, sinfo)

                        .runSp(cnnprueba, vartablacartaportedeti, sinfo)
                        .runSp(cnnprueba, varKeycartaportedeti, sinfo)
                        .runSp(cnnprueba, varAutocartaportedeti, sinfo)

                        .runSp(cnnprueba, vartablacartaportei, sinfo)
                        .runSp(cnnprueba, varKeycartaportei, sinfo)
                        .runSp(cnnprueba, varAutocartaportei, sinfo)

                        .runSp(cnnprueba, vartablaclientes, sinfo)
                        .runSp(cnnprueba, varKeyclientes, sinfo)
                        .runSp(cnnprueba, varAutoclientes, sinfo)

                        .runSp(cnnprueba, vartablacompras, sinfo)
                        .runSp(cnnprueba, varKeycompras, sinfo)
                        .runSp(cnnprueba, varAutocompras, sinfo)

                        .runSp(cnnprueba, vartablacomprasdet, sinfo)
                        .runSp(cnnprueba, varKeycomprasdet, sinfo)
                        .runSp(cnnprueba, varAutocomprasdet, sinfo)
                        .runSp(cnnprueba, varForKcomprasdet, sinfo)

                        .runSp(cnnprueba, vartablacortecaja, sinfo)
                        .runSp(cnnprueba, varKeycortecaja, sinfo)
                        .runSp(cnnprueba, varAutocortecaja, sinfo)

                        .runSp(cnnprueba, vartablacorteusuario, sinfo)
                        .runSp(cnnprueba, varKeycorteusuario, sinfo)
                        .runSp(cnnprueba, varAutocorteusuario, sinfo)

                        .runSp(cnnprueba, vartablacotped, sinfo)
                        .runSp(cnnprueba, varKeycotped, sinfo)
                        .runSp(cnnprueba, varAutocotped, sinfo)

                        .runSp(cnnprueba, vartablaccotpeddet, sinfo)
                        .runSp(cnnprueba, varKeycotpeddet, sinfo)
                        .runSp(cnnprueba, varAutocotpeddet, sinfo)

                        .runSp(cnnprueba, vartablactmedicos, sinfo)
                        .runSp(cnnprueba, varKeyctmedicos, sinfo)
                        .runSp(cnnprueba, varAutoctmedicos, sinfo)

                        .runSp(cnnprueba, vartabladatosnegocio, sinfo)
                        .runSp(cnnprueba, varKeydatosnegocio, sinfo)
                        .runSp(cnnprueba, varAutodatosnegocio, sinfo)

                        .runSp(cnnprueba, vartabladdetalle_factura, sinfo)

                        .runSp(cnnprueba, vartabladeudores, sinfo)
                        .runSp(cnnprueba, varKeydeudores, sinfo)
                        .runSp(cnnprueba, varAutodeudores, sinfo)

                        .runSp(cnnprueba, vartabladevoluciones, sinfo)
                        .runSp(cnnprueba, varKeydevoluciones, sinfo)
                        .runSp(cnnprueba, varAutodevoluciones, sinfo)

                        .runSp(cnnprueba, vartablaentregas, sinfo)
                        .runSp(cnnprueba, varKeyentregas, sinfo)
                        .runSp(cnnprueba, varAutoentregas, sinfo)

                        .runSp(cnnprueba, vartablafacturas, sinfo)
                        .runSp(cnnprueba, varKeyfacturas, sinfo)
                        .runSp(cnnprueba, varAutofacturas, sinfo)

                        .runSp(cnnprueba, vartablaformapagosat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from formapagosat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaformapagosat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyformapagosat, sinfo)
                        .runSp(cnnprueba, varAutoformapagosat, sinfo)

                        .runSp(cnnprueba, vartablaformaspago, sinfo)
                        .runSp(cnnprueba, varKeyformaspago, sinfo)
                        .runSp(cnnprueba, varAutoformapagos, sinfo)

                        .runSp(cnnprueba, vartablaformatos, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from formatos", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaformatos, sinfo)
                        End If

                        .runSp(cnnprueba, vartablaformatos, sinfo)
                        .runSp(cnnprueba, varKeyformatos, sinfo)
                        .runSp(cnnprueba, varAutoformatos, sinfo)

                        .runSp(cnnprueba, vartablagastos, sinfo)

                        .runSp(cnnprueba, vartablaheresultados, sinfo)

                        .runSp(cnnprueba, vartablahorarios, sinfo)

                        .runSp(cnnprueba, vartablaimpuestosat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from impuestosat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaimpuestosat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyimpuestosat, sinfo)
                        .runSp(cnnprueba, varAutoimpuestosat, sinfo)

                        .runSp(cnnprueba, vartablaiva, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from iva", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaiva, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyiva, sinfo)
                        .runSp(cnnprueba, varAutoiva, sinfo)

                        .runSp(cnnprueba, vartablakits, sinfo)


                        .runSp(cnnprueba, vartablaloginrecargas, sinfo)
                        .runSp(cnnprueba, varKeyloginrecargas, sinfo)
                        .runSp(cnnprueba, varAutologinrecargas, sinfo)


                        .runSp(cnnprueba, vartablalotecaducidad, sinfo)
                        .runSp(cnnprueba, varKeylotecaducidad, sinfo)
                        .runSp(cnnprueba, varAutolotecaducidad, sinfo)

                        .runSp(cnnprueba, vartablamembresiasgym, sinfo)
                        .runSp(cnnprueba, varKeymembresiasgym, sinfo)
                        .runSp(cnnprueba, varAutomembresiasgym, sinfo)

                        .runSp(cnnprueba, vartablamerma, sinfo)
                        .runSp(cnnprueba, varKeymerma, sinfo)
                        .runSp(cnnprueba, varAutomerma, sinfo)

                        .runSp(cnnprueba, vartablamesessat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from mesessat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertamesessat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeymesessat, sinfo)
                        .runSp(cnnprueba, varAutomesessat, sinfo)

                        .runSp(cnnprueba, vartablametodopagosat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from metodopagosat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertametodopagosat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeymetodopagosat, sinfo)
                        .runSp(cnnprueba, varAutometodopagosat, sinfo)

                        .runSp(cnnprueba, vartablamiprod, sinfo)

                        .runSp(cnnprueba, vartablamodentregas, sinfo)
                        .runSp(cnnprueba, varKeymodentregas, sinfo)
                        .runSp(cnnprueba, varAutomodentregas, sinfo)

                        .runSp(cnnprueba, vartablamodentregasdet, sinfo)
                        .runSp(cnnprueba, varKeymodentregasdet, sinfo)
                        .runSp(cnnprueba, varAutomodentregasdet, sinfo)

                        .runSp(cnnprueba, vartablamodprecios, sinfo)
                        .runSp(cnnprueba, varKeymodprecios, sinfo)
                        .runSp(cnnprueba, varAutomodprecios, sinfo)

                        .runSp(cnnprueba, vartablamonedero, sinfo)
                        .runSp(cnnprueba, varKeymonedero, sinfo)
                        .runSp(cnnprueba, varAutomonedero, sinfo)

                        .runSp(cnnprueba, vartablamovcuenta, sinfo)
                        .runSp(cnnprueba, varKeymovcuenta, sinfo)
                        .runSp(cnnprueba, varAutomovcuenta, sinfo)

                        .runSp(cnnprueba, vartablamovmonedero, sinfo)
                        .runSp(cnnprueba, varKeymovmonedero, sinfo)
                        .runSp(cnnprueba, varAutomovmonedero, sinfo)

                        .runSp(cnnprueba, vartablanomina, sinfo)
                        .runSp(cnnprueba, varKeynomina, sinfo)
                        .runSp(cnnprueba, varAutonomina, sinfo)

                        .runSp(cnnprueba, vartablanota, sinfo)
                        .runSp(cnnprueba, varKeynota, sinfo)
                        .runSp(cnnprueba, varAutonota, sinfo)

                        .runSp(cnnprueba, vartablaotrosgastos, sinfo)
                        .runSp(cnnprueba, varKeyotrosgastos, sinfo)
                        .runSp(cnnprueba, varAutootrosgastos, sinfo)

                        .runSp(cnnprueba, vartablaparametros, sinfo)
                        .runSp(cnnprueba, varinsertaparametros, sinfo)
                        .runSp(cnnprueba, varKeyparametros, sinfo)

                        .runSp(cnnprueba, vartablaparcialidades, sinfo)
                        .runSp(cnnprueba, varKeyparcialidades, sinfo)
                        .runSp(cnnprueba, varAutoparcialidades, sinfo)

                        .runSp(cnnprueba, vartablaparcialidadesdetalle, sinfo)
                        .runSp(cnnprueba, varKeyparcialidadesdetalle, sinfo)
                        .runSp(cnnprueba, varAutoparcialidadesdetalle, sinfo)

                        .runSp(cnnprueba, vartablaparcialidadesdetallemulti, sinfo)
                        .runSp(cnnprueba, varKeyparcialidadesdetallemulti, sinfo)
                        .runSp(cnnprueba, varAutoparcialidadesdetallemulti, sinfo)

                        .runSp(cnnprueba, vartablaparcialidadesmulti, sinfo)
                        .runSp(cnnprueba, varKeyparcialidadesmulti, sinfo)
                        .runSp(cnnprueba, varAutoparcialidadesmulti, sinfo)

                        .runSp(cnnprueba, vartablapedidos, sinfo)
                        .runSp(cnnprueba, varKeypedidos, sinfo)
                        .runSp(cnnprueba, varAutopedidos, sinfo)

                        .runSp(cnnprueba, vartablapedidosdet, sinfo)
                        .runSp(cnnprueba, varKeypedidosdet, sinfo)
                        .runSp(cnnprueba, varAutopedidosdet, sinfo)

                        .runSp(cnnprueba, vartablapeps, sinfo)
                        .runSp(cnnprueba, varKeypeps, sinfo)
                        .runSp(cnnprueba, varAutopeps, sinfo)

                        .runSp(cnnprueba, vartablaperiodicidadsat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from periodicidadsat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaperiodicidadsat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyperiodicidadsat, sinfo)
                        .runSp(cnnprueba, varAutoperiodicidadsat, sinfo)

                        .runSp(cnnprueba, vartablapermisos, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from permisos", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertapermisos, sinfo)
                        End If
                        .runSp(cnnprueba, varKeypermisos, sinfo)
                        .runSp(cnnprueba, varAutopermisos, sinfo)

                        .runSp(cnnprueba, vartablapermisosm, sinfo)
                        .runSp(cnnprueba, varKeypermisosm, sinfo)
                        .runSp(cnnprueba, varAutopermisosm, sinfo)

                        .runSp(cnnprueba, vartablaporteclavestcc, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from porteclavestcc", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaporteclavestcc, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyporteclavestcc, sinfo)
                        .runSp(cnnprueba, varAutoporteclavestcc, sinfo)

                        .runSp(cnnprueba, vartablaportecolonia, sinfo)
                        .runSp(cnnprueba, varKeyportecolonia, sinfo)
                        .runSp(cnnprueba, varAutoportecolonia, sinfo)

                        .runSp(cnnprueba, vartablaporteconfigautotrans, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from porteconfigautotrans", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaporteconfigautotrans, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyporteconfigautotrans, sinfo)
                        .runSp(cnnprueba, varAutoporteconfigautotrans, sinfo)

                        .runSp(cnnprueba, vartablaportedestino, sinfo)
                        .runSp(cnnprueba, varKeyportedestino, sinfo)
                        .runSp(cnnprueba, varAutoportedestino, sinfo)

                        .runSp(cnnprueba, vartablaporteestados, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from porteestados", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaporteestados, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyporteestados, sinfo)
                        .runSp(cnnprueba, varAutoporteestados, sinfo)

                        .runSp(cnnprueba, vartablaportefigura, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from portefigura", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaportefigura, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyportefigura, sinfo)
                        .runSp(cnnprueba, varAutoportefigura, sinfo)

                        .runSp(cnnprueba, vartablaportelocalidad, sinfo)
                        .runSp(cnnprueba, varKeyportelocalidad, sinfo)
                        .runSp(cnnprueba, varAutoportelocalidad, sinfo)

                        .runSp(cnnprueba, vartablaportematpeligrosos, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from portematpeligrosos", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaportematpeligrosos, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyportematpeligrosos, sinfo)
                        .runSp(cnnprueba, varAutoportematpeligrosos, sinfo)

                        .runSp(cnnprueba, vartablaportemercancia, sinfo)
                        .runSp(cnnprueba, varKeyportemercancia, sinfo)
                        .runSp(cnnprueba, varAutoportemercancia, sinfo)

                        .runSp(cnnprueba, vartablaportemunicipios, sinfo)
                        .runSp(cnnprueba, varKeyportemunicipios, sinfo)
                        .runSp(cnnprueba, varAutoportemunicipios, sinfo)

                        .runSp(cnnprueba, vartablaporteoperador, sinfo)
                        .runSp(cnnprueba, varKeyporteoperador, sinfo)
                        .runSp(cnnprueba, varAutoporteoperador, sinfo)

                        .runSp(cnnprueba, vartablaporteorigen, sinfo)
                        .runSp(cnnprueba, varKeyporteorigen, sinfo)
                        .runSp(cnnprueba, varAutoporteorigen, sinfo)

                        .runSp(cnnprueba, vartablaportepais, sinfo)
                        .runSp(cnnprueba, varKeyportepais, sinfo)
                        .runSp(cnnprueba, varAutoportepais, sinfo)

                        .runSp(cnnprueba, vartablaporteproducto, sinfo)
                        .runSp(cnnprueba, varKeyporteproducto, sinfo)
                        .runSp(cnnprueba, varAutoporteproducto, sinfo)

                        .runSp(cnnprueba, vartablaporteproductosat, sinfo)
                        .runSp(cnnprueba, varKeyporteproductosat, sinfo)
                        .runSp(cnnprueba, varAutoporteproductosat, sinfo)

                        .runSp(cnnprueba, vartablaportepropietario, sinfo)
                        .runSp(cnnprueba, varKeyportepropietario, sinfo)
                        .runSp(cnnprueba, varAutoportepropietario, sinfo)

                        .runSp(cnnprueba, vartablaportetipocarga, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from portetipocarga", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaportetipocarga, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyportetipocarga, sinfo)
                        .runSp(cnnprueba, varAutoportetipocarga, sinfo)

                        .runSp(cnnprueba, vartablaportetipocarro, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from portetipocarro", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaportetipocarro, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyportetipocarro, sinfo)
                        .runSp(cnnprueba, varAutoportetipocarro, sinfo)

                        .runSp(cnnprueba, vartablaportetipocontenedor, sinfo)
                        .runSp(cnnprueba, varKeyportetipocontenedor, sinfo)
                        .runSp(cnnprueba, varAutoportetipocontenedor, sinfo)

                        .runSp(cnnprueba, vartablaportetipoembalaje, sinfo)
                        .runSp(cnnprueba, varKeyportetipoembalaje, sinfo)
                        .runSp(cnnprueba, varAutoportetipoembalaje, sinfo)

                        .runSp(cnnprueba, vartablaportetipopermiso, sinfo)
                        .runSp(cnnprueba, varKeyportetipopermiso, sinfo)
                        .runSp(cnnprueba, varAutoportetipopermiso, sinfo)

                        .runSp(cnnprueba, vartablaportetiporemolque, sinfo)
                        .runSp(cnnprueba, varKeyportetiporemolque, sinfo)
                        .runSp(cnnprueba, varAutoportetiporemolque, sinfo)

                        .runSp(cnnprueba, vartablaportetransporte, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from portetransporte", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaportetransporte, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyportetransporte, sinfo)
                        .runSp(cnnprueba, varAutoportetransporte, sinfo)

                        .runSp(cnnprueba, vartablaporteunidadmedemb, sinfo)
                        .runSp(cnnprueba, varKeyporteunidadmedemb, sinfo)
                        .runSp(cnnprueba, varAutoporteunidadmedemb, sinfo)

                        .runSp(cnnprueba, vartablaprocesos_prod, sinfo)
                        .runSp(cnnprueba, varKeyprocesos_prod, sinfo)
                        .runSp(cnnprueba, varAutoprocesos_prod, sinfo)

                        .runSp(cnnprueba, vartablaproductos, sinfo)
                        .runSp(cnnprueba, varKeyproductos, sinfo)
                        .runSp(cnnprueba, varAutoproductos, sinfo)

                        .runSp(cnnprueba, vartablapromasven, sinfo)

                        .runSp(cnnprueba, vartablaproveedores, sinfo)
                        .runSp(cnnprueba, varKeyproveedores, sinfo)
                        .runSp(cnnprueba, varAutoproveedores, sinfo)

                        .runSp(cnnprueba, vartablarecargas, sinfo)
                        .runSp(cnnprueba, varKeyrecargas, sinfo)
                        .runSp(cnnprueba, varAutorecargas, sinfo)

                        .runSp(cnnprueba, vartablaregimenfiscalsat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from regimenfiscalsat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaregimenfiscalsat, sinfo)
                        End If

                        .runSp(cnnprueba, vartablarepfactura, sinfo)

                        .runSp(cnnprueba, vartablarepomen, sinfo)

                        .runSp(cnnprueba, vartablarepsalidas, sinfo)

                        .runSp(cnnprueba, vartablarep_antib, sinfo)
                        .runSp(cnnprueba, varKeyrep_antib, sinfo)
                        .runSp(cnnprueba, varAutorep_antib, sinfo)

                        .runSp(cnnprueba, vartablarep_salidas, sinfo)

                        .runSp(cnnprueba, vartablarutasimpresion, sinfo)
                        .runSp(cnnprueba, varKeyrutasimpresion, sinfo)
                        .runSp(cnnprueba, varAutorutasimpresion, sinfo)

                        .runSp(cnnprueba, vartablasaldosempleados, sinfo)
                        .runSp(cnnprueba, varKeysaldosempleados, sinfo)
                        .runSp(cnnprueba, varAutosaldosempleados, sinfo)

                        .runSp(cnnprueba, vartablasseries, sinfo)
                        .runSp(cnnprueba, varKeyseries, sinfo)
                        .runSp(cnnprueba, varAutoseries, sinfo)

                        .runSp(cnnprueba, vartablaservicios, sinfo)
                        .runSp(cnnprueba, varKeyservicios, sinfo)
                        .runSp(cnnprueba, varAutoservicios, sinfo)

                        .runSp(cnnprueba, vartablatalmacen, sinfo)
                        .runSp(cnnprueba, varKeytalmacen, sinfo)
                        .runSp(cnnprueba, varAutotalmacen, sinfo)

                        .runSp(cnnprueba, vartablatb_moneda, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from tb_moneda", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatb_moneda, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytb_moneda, sinfo)
                        .runSp(cnnprueba, varAutotb_moneda, sinfo)

                        .runSp(cnnprueba, vartablaticket, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from ticket", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertaticket, sinfo)
                        End If

                        .runSp(cnnprueba, vartablatipofactorsat, sinfo)
                        .runSp(cnnprueba, varKeytipofactorsat, sinfo)
                        .runSp(cnnprueba, varAutotipofactorsat, sinfo)

                        .runSp(cnnprueba, vartablatiposcomprobantesat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from tiposcomprobantesat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatiposcomprobantesat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytiposcomprobantesat, sinfo)
                        .runSp(cnnprueba, varAutotiposcomprobantesat, sinfo)

                        .runSp(cnnprueba, vartablatiprelacioncfdisat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from tiprelacioncfdisat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertatiprelacioncfdisat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeytiprelacioncfdisat, sinfo)
                        .runSp(cnnprueba, varAutotiprelacioncfdisat, sinfo)

                        .runSp(cnnprueba, vartablatransporte, sinfo)
                        .runSp(cnnprueba, varKeytransporte, sinfo)
                        .runSp(cnnprueba, varAutotransporte, sinfo)

                        .runSp(cnnprueba, vartablatraslados, sinfo)
                        .runSp(cnnprueba, varKeytraslados, sinfo)
                        .runSp(cnnprueba, varAutotraslados, sinfo)

                        .runSp(cnnprueba, vartablatrasladosdet, sinfo)
                        .runSp(cnnprueba, varKeytrasladosdet, sinfo)
                        .runSp(cnnprueba, varAutotrasladosdet, sinfo)

                        .runSp(cnnprueba, vartablaumtblcfds, sinfo)
                        .runSp(cnnprueba, varKeyumtblcfds, sinfo)
                        .runSp(cnnprueba, varAutoumtblcfds, sinfo)

                        .runSp(cnnprueba, vartablausocfdisat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from usocfdisat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertausocfdisat, sinfo)
                        End If

                        .runSp(cnnprueba, vartablausocomprocfdisat, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from usocomprocfdisat", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertausocomprocfdisat, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyusocomprocfdisat, sinfo)
                        .runSp(cnnprueba, varAutousocomprocfdisat, sinfo)

                        .runSp(cnnprueba, vartablausuarios, sinfo)
                        dtprueba = New DataTable
                        If .getDt(cnnprueba, dtprueba, "select * from usuarios", sinfo) Then
                        Else
                            .runSp(cnnprueba, varinsertausuarios, sinfo)
                        End If
                        .runSp(cnnprueba, varKeyusuarios, sinfo)
                        .runSp(cnnprueba, varAutousuarios, sinfo)

                        .runSp(cnnprueba, vartablauuidrelacion, sinfo)
                        .runSp(cnnprueba, varKeyuuidrelacion, sinfo)
                        .runSp(cnnprueba, varAutouuidrelacion, sinfo)

                        .runSp(cnnprueba, vartablaventas, sinfo)
                        .runSp(cnnprueba, varKeyventas, sinfo)
                        .runSp(cnnprueba, varAutoventas, sinfo)

                        .runSp(cnnprueba, vartablaventasdetalle, sinfo)
                        .runSp(cnnprueba, varKeyventasdetalle, sinfo)
                        .runSp(cnnprueba, varAutoventasdetalle, sinfo)
                        .runSp(cnnprueba, varForKventasdetalle, sinfo)


                        .runSp(cnnprueba, vartablavtaimpresion, sinfo)
                        .runSp(cnnprueba, varKeyvtaimpresion, sinfo)
                        .runSp(cnnprueba, varAutovtaimpresion, sinfo)

                        cnnprueba.Close()

                    Else
                        MsgBox("Error al crear la base")
                        MsgBox(sinfo)
                        Continue For
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox("El Archivo CreateDB_Users no existe hay que colocarlo en la carpeta correspondiente")
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class