Imports System.IO
Imports System.Math
Imports System.Text
Imports System.Data.OleDb
Imports System.Threading
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Xml
Imports System.Data.SqlClient

Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data

Public Class frmfacturacion
    Private config As datos_c
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long

    Dim servidor As String = ""
    Dim puerto As String = ""
    Dim seguridad As Boolean = False

    Dim rfc_e As String = ""
    Dim calle_e As String = ""
    Dim no_exterior_e As String = ""
    Dim no_interior_e As String = ""
    Dim colonia_e As String = ""
    Dim municipio_e As String = ""
    Dim factupre As Boolean = False

    Dim estado_e As String = ""
    Dim cp_e As String = ""
    Dim regimen_e As String = ""
    Dim registro_patronal_e As String = ""

    Dim ruta_certificado_e As String = ""
    Dim ruta_key_e As String = ""
    Dim pass_key_e As String = ""
    Dim regimen_fiscal_e As String = ""

    Dim folio_actual As String = ""
    Dim folio_inicial As String = ""

    Dim razon_social As String = ""
    Dim actividad_empresa As String = ""

    Dim var_cliente As Integer = 0
    Dim var_producto As String = ""
    Dim var1 As Integer = 0
    Dim comentario1 As String = ""

    Dim var_folio As Integer = 0
    Dim var_serie1 As String = ""

    Dim var_folioarrenda As Integer = 0
    Dim var_seriearrenda As String = ""

    Dim var_foliohonorario As Integer = 0
    Dim var_seriehonorario As String = ""

    Dim var_folionotac As Integer = 0
    Dim var_serienotac As String = ""

    Dim var_idfactura As Integer = 0

    '''''factura en ticket'''''''''
    Dim FolioTicket As String = ""

    Public Sub muestra_datos()
        FileGet(filenum, config, 1)

        ipserver = Trim(config.ip_configuracion)
        database = Trim(config.base_configuracion)
        userbd = Trim(config.usuario_configuracion)
        passbd = Trim(config.password_configuracion)
    End Sub

    Private Sub frmfacturacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(ARCHIVO_CONF_FACTURAS) Then
            filenum = FreeFile()
            FileOpen(filenum, ARCHIVO_CONF_FACTURAS, OpenMode.Random, OpenAccess.ReadWrite)

            recordLen = Len(config)
            muestra_datos()
            'sTargetMYSQL = "server=" & ipserver & ";uid=" & userbd & ";password=jipl2211;database=Control_Timbres;persist security info=false;connect timeout=30"
            sTargetMYSQL = "server=" & ipserver & ";uid=" & userbd & ";password=" & passbd & ";database=" & database & ";persist security info=false;connect timeout=30"

            FileClose()
        End If

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
                        ' sTarget = "Data Source=" & dameIP2() & "; Integrated Security=false; initial catalog=CN" & varnumbase & "; user id=Delsscom; password=jipl22; timeout=300"
                        sTarget = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn" & baseseleccionada & ";persist security info=false;connect timeout=300"

                        sTargetlocal = "server=" & dameIP2() & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"
                    Else
                        ' sTarget = "Data Source=" & varrutabase & ";Integrated Security=false; initial catalog=CN" & varnumbase & "; user id=Delsscom; password=jipl22; timeout=300"
                        sTarget = "server=" & varrutabase & ";uid=Delsscom;password=jipl22;database=cn" & varnumbase & ";persist security info=false;connect timeout=300"

                        sTargetlocal = "server=" & varrutabase & ";uid=Delsscom;password=jipl22;database=cn1;persist security info=false;connect timeout=300"
                    End If
                End If
                cnn.Close()
            End If
        End With

        cnn.Close()

        sumaprodSinIva = 0
        sumaprodConIva = 0

        numero_MAC = dameIP2() ' dameIP2().ToString

        llena_TipoRelacion()
        llenaFolioUUID()

        llenarCboregimen()

        llena_emisores()
        llena_combo_metodos()
        limpia_prod()
        limpia_empresa()
        Cmb_RazonS.Text = ""
        Cmb_RFC.Text = ""
        limpia_campos()
        llena_cbofolio()
        llena_cbometodopsat()
        llena_cbousocfd()
        Btt_Nuevo.PerformClick()
        serie()
        busca_Foliofact()

        Dim ssql10 As String = ""
        ssql10 = "Delete from Facturas where nom_folio_sat_uuid is null and nom_fecha_folio_sat is null and nom_sello_emisor is null and nom_sello_sat is null and nom_cadena_original is null and nom_no_csd_sat is null "
        Dim cnn10 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo10 As String = ""
        Dim odata10 As New ToolKitSQL.myssql
        If odata10.dbOpen(cnn10, sTarget, sinfo10) Then
            If odata10.runSp(cnn10, ssql10, sinfo10) Then
            Else
                'MsgBox(sinfo)
            End If
            cnn10.Close()
        Else
            'MsgBox(sinfo)
        End If

        ssql10 = "Delete from Facturas where nom_folio_sat_uuid = '' and nom_fecha_folio_sat = '' and nom_sello_emisor = '' and nom_sello_sat = '' and nom_cadena_original = '' and nom_no_csd_sat = '' "
        sinfo10 = ""
        If odata10.dbOpen(cnn10, sTarget, sinfo10) Then
            If odata10.runSp(cnn10, ssql10, sinfo10) Then
            Else
                'MsgBox(sinfo)
            End If
            cnn10.Close()
        Else
            'MsgBox(sinfo)
        End If

        llena_unidades_SATporte()
        llena_productos_SATporte()

        llena_Material_Peligroso()
        llena_Embalaje()

        'Dim var666 As String = ""
        'busca_logo(var666)
        'PictureBox1.Image = Image.FromFile(Convert.ToString(var666))
    End Sub

    Private Sub llena_TipoRelacion()
        cboTipoRelacion.DataSource = Nothing
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT * FROM TipRelacionCFDISat order by Id"
        Dim odata As New ToolKitSQL.myssql
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                Dim ds As New DataSet
                If odata.getDs(cnn, ds, sSQL, "edos", sInfo) Then
                    With cboTipoRelacion
                        .DataSource = ds.Tables("edos")
                        .ValueMember = "ClaveTipoRel"
                        .DisplayMember = "Descripcion"
                        My.Application.DoEvents()
                    End With
                    cboTipoRelacion.SelectedIndex = -1
                Else
                    MessageBox.Show("Error al conectar con los Datos")
                End If
                cnn.Close()
            Else
                MessageBox.Show("Error al conectar con los Datos")
            End If
        End With
    End Sub

    Private Sub llenaFolioUUID()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_FACTURA & " order by nom_folio"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With cboFolio
                    Try
                        If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                            .DataSource = ds.Tables("edos")
                            .ValueMember = "nom_id"
                            .DisplayMember = "nom_folio"
                        Else
                        End If
                    Catch ex As Exception
                    End Try
                End With
                cnn.Close()
            Else
            End If
        End With
        cboFolio.Text = ""
    End Sub

    Private Sub llenarCboregimen()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * From RegimenFiscalSat"
        Dim ds As New DataSet
        Dim sinfo As String = ""

        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            With cbo_regimen
                If odata.getDs(cnn, ds, sSQL, "Empresa", sinfo) = True Then
                    .DataSource = ds.Tables("Empresa")
                    .ValueMember = "ClaveRegFis"
                    .DisplayMember = "Descripcion"
                Else
                    MsgBox(sinfo)
                End If
            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
        If cbo_regimen.Items.Count > 0 Then
            cbo_regimen.SelectedValue = 1
        End If
    End Sub

    Private Sub llena_emisores()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * From DatosNegocio"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) = True Then
            With cbo_emisor
                If odata.getDs(cnn, ds, sSQL, "Empresa", sinfo) = True Then
                    .DataSource = ds.Tables("Empresa")
                    .ValueMember = "Emisor_id"
                    .DisplayMember = "Em_RazonSocial"
                    cbo_rfc_emisor.DataSource = ds.Tables("Empresa")
                    cbo_rfc_emisor.ValueMember = "Emisor_id"
                    cbo_rfc_emisor.DisplayMember = "Em_rfc"
                Else
                    'MsgBox(sinfo)
                End If
            End With
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If

        If cbo_emisor.Items.Count > 0 Then
            cbo_emisor.SelectedValue = 1
            vempresa = 1
        End If
    End Sub

    Private Sub llena_combo_metodos()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from FormaPagoSat"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            With cbometodo_pago
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "ClavePago"
                    .DisplayMember = "Descripcion"
                Else
                    'MsgBox(sinfo)
                End If
            End With
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub limpia_prod()
        cboIeps.Text = "0"
        chkTasa.Checked = False
        chkCuota.Checked = False
        txt_piva.Text = "16"

        txt_ivaret.Text = "0"
        Text_Precio.Text = "0"
        var_producto = 0
        Cmb_Desc.SelectedValue = -1
        Cmb_Desc.Text = ""

        Text_cantidad.Text = "1"
        Text_t.Text = "0"
        txt_descuento.Text = "0"
        txt_ivaret.Text = "0"
        txt_ieps.Text = "0"
        txtIsrDet.Text = "0"

        txt_unidadventaNew.Text = ""
        txt_prodsat.Text = ""

        txt_partida.Text = grid_prods.RowCount + 1
    End Sub

    Private Sub limpia_empresa()
        txt_nombrec.Text = ""
        Text_calle.Text = ""
        Text_Num_Ex.Text = ""
        Txt_num_int.Text = ""
        Text_Email.Text = ""
        Text_Colonia.Text = ""
        Text_Delegacion.Text = ""
        Text_Edo.Text = ""
        Text_FormaPago.SelectedValue = "PUE"
        Text_CP.Text = ""
    End Sub

    Private Sub limpia_campos()
        grid_prods.Rows.Clear()
        Text_SubTotal.Text = ""
        Text_IVA.Text = ""
        Text_IVARET.Text = ""
        txt_impuestos.Text = ""
        TextBox1.Text = ""
        Text_TOTAL.Text = ""
        Cmb_Nfactura.Text = ""
        Text_FormaPago.SelectedValue = "PUE"
        Text_nCuenta.Text = ""
        Text_MotivoDes.Text = ""
        txt_leyenda_add.Text = ""
    End Sub

    Private Sub llena_cbofolio()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_FACTURA & " order by nom_folio"
            Case "PREFACTURA"
                sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_PREFACTURA & " and id_emisor=" & cbo_emisor.SelectedValue & " order by nom_folio"
            Case "RECIBO DE ARRENDAMIENTO"
                sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_ARRENDAMIENTO & "  and id_emisor=" & cbo_emisor.SelectedValue & " order by nom_folio"
            Case "RECIBO DE HONORARIOS"
                sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_HONORARIOS & "  and id_emisor=" & cbo_emisor.SelectedValue & " order by nom_folio"
            Case "NOTA DE CREDITO"
                sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_NOTASCREDITO & " order by nom_folio"
        End Select

        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With Cmb_Nfactura
                    Try
                        If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                            .DataSource = ds.Tables("edos")
                            .ValueMember = "nom_id"
                            .DisplayMember = "nom_folio"
                        Else
                            'MsgBox(sinfo)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End With
                cnn.Close()
            Else
                'MsgBox(sinfo)
            End If
        End With
        Cmb_Nfactura.Text = ""
    End Sub

    Private Sub llena_cbometodopsat()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from MetodoPagoSat "
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With Text_FormaPago
                    If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                        Text_FormaPago.DataSource = ds.Tables("edos")
                        Text_FormaPago.ValueMember = "ClaveMetPag"
                        Text_FormaPago.DisplayMember = "Descripcion"
                    Else
                        'MsgBox(sinfo)
                    End If
                End With
                cnn.Close()
            Else
                'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub llena_cbousocfd()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from UsoComproCFDISat"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With cbo_usocfdi
                    If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                        cbo_usocfdi.DataSource = ds.Tables("edos")
                        cbo_usocfdi.ValueMember = "ClaveUsoCFDI"
                        cbo_usocfdi.DisplayMember = "Descripcion"
                    Else
                        'MsgBox(sinfo)
                    End If
                End With
                cnn.Close()
            Else
                'MsgBox(sinfo)
            End If
        End With

        If cbo_usocfdi.Items.Count > 0 Then
            cbo_usocfdi.SelectedValue = "G01"
        End If
    End Sub

    Private Sub serie()
        On Error GoTo MALO
        If factupre = False Then
            If cbo_emisor.SelectedValue > 0 Then
                llena_cbofolio()
                limpia_lugarexp()
                datos_empresa_fiscales(rfc_e, calle_e, no_exterior_e, colonia_e, municipio_e,
                                              estado_e, cp_e, regimen_e, registro_patronal_e,
                                              ruta_certificado_e, ruta_key_e, pass_key_e, regimen_fiscal_e,
                                              folio_actual, folio_inicial, razon_social, actividad_empresa, no_interior_e)
                Select Case Cmb_TipoFact.Text
                    Case "FACTURA"
                        txt_serie.Text = var_serie1
                    Case "PREFACTURA"
                        txt_serie.Text = var_serie1
                    Case "RECIBO DE ARRENDAMIENTO"
                        txt_serie.Text = var_seriearrenda
                    Case "RECIBO DE HONORARIOS"
                        txt_serie.Text = var_seriehonorario
                    Case "NOTA DE CREDITO"
                        txt_serie.Text = var_serienotac
                End Select
                limpia_campos()
            End If
            llena_grid()
        End If
MALO:
    End Sub

    Private Sub busca_Foliofact()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        Dim dr As DataRow

        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                txtNotaVenta.Visible = True
                Label35.Visible = True
                sSQL = "select max(nom_folio) from Facturas where estatus_fac = 1"
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, sSQL, sinfo) Then

                            If dr(0).ToString = "" Then
                                Cmb_Nfactura.Text = 1
                            Else
                                Cmb_Nfactura.Text = CDec(dr(0).ToString) + 1
                            End If
                        Else
                        End If
                    End If
                End With
            Case "PREFACTURA"
                txtNotaVenta.Visible = True
                Label35.Visible = True
            Case "NOTA DE CREDITO"
                sSQL = "select max(nom_folio) as cont from Facturas where estatus_fac = 6"
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, sSQL, sinfo) Then
                            If dr(0).ToString = "" Then
                                Cmb_Nfactura.Text = 1
                            Else
                                Cmb_Nfactura.Text = CDec(dr(0).ToString) + 1
                            End If
                        Else
                        End If
                    End If
                End With
            Case Else
                'MsgBox("Debe Seleccionar un Tipo de Documento")
        End Select
        cnn.Close()
    End Sub

    Private Sub llena_productos_SATporte()
        cboProdServSAT.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "SELECT Descripcion FROM PorteProductoSat order by Descripcion", sinfo) Then
                    For Each dr In dt.Rows
                        cboProdServSAT.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub llena_unidades_SATporte()
        cboUniMedSAT.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "SELECT Nombre FROM PorteUnidadMedEmb order by Nombre", sinfo) Then
                    For Each dr In dt.Rows
                        cboUniMedSAT.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub llena_Material_Peligroso()
        cboMatPeligroso.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "SELECT Descripcion FROM PorteMatPeligrosos order by Descripcion", sinfo) Then
                    For Each dr In dt.Rows
                        cboMatPeligroso.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub llena_Embalaje()
        cboEmbalaje.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "SELECT Descripcion FROM PorteTipoEmbalaje order by Descripcion", sinfo) Then
                    For Each dr In dt.Rows
                        cboEmbalaje.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Function busca_logo(Optional ByRef logr As String = "")
        On Error GoTo door
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select emi_logo from DatosNegocio where Em_RazonSocial = '" & cbo_emisor.Text & "' and Em_rfc = '" & cbo_rfc_emisor.Text & "'"
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                logr = dr("emi_logo").ToString
                cnn.Close()
                Return True
            Else
                cnn.Close()
                Return False
            End If
            cnn.Close()
        Else
            MessageBox.Show("Error al conectar con los Datos")
        End If
        Return True
door:
    End Function

    Private Sub limpia_lugarexp()
        If cbo_emisor.Text <> "" Then
            cboLEdomi.Text = 1
            txtLEcalle.Text = ""
            txtLEnumext.Text = ""
            txtLEnumint.Text = ""
            txtLEcodpos.Text = ""
            txtLEcolonia.Text = ""
            txtLEalcmun.Text = ""
            txtLEedo.Text = ""

            Dim sinfo As String = ""
            Dim sSQL As String = "Select * from DatosNegocio where Emisor_id=" & cbo_emisor.SelectedValue
            Dim dr As DataRow
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim odata As New ToolKitSQL.myssql
            If odata.dbOpen(cnn, sTarget, sinfo) Then
                If odata.getDr(cnn, dr, sSQL, sinfo) Then
                    cboLEdomi.Text = cbo_emisor.SelectedValue
                    txtLEcalle.Text = dr("Em_calle").ToString
                    txtLEnumext.Text = dr("Em_NumExterior").ToString
                    txtLEnumint.Text = dr("Em_NumInterior").ToString
                    txtLEcodpos.Text = dr("Em_CP").ToString
                    txtLEcolonia.Text = dr("Em_colonia").ToString
                    txtLEalcmun.Text = dr("Em_Municipio").ToString
                    txtLEedo.Text = dr("Em_Estado").ToString
                End If
                cnn.Close()
            End If
        Else
            cboLEdomi.Text = ""
            txtLEcalle.Text = ""
            txtLEnumext.Text = ""
            txtLEnumint.Text = ""
            txtLEcodpos.Text = ""
            txtLEcolonia.Text = ""
            txtLEalcmun.Text = ""
            txtLEedo.Text = ""
        End If
    End Sub

    Private Sub datos_empresa_fiscales(ByRef rfc_e As String, ByRef calle_e As String, ByRef no_exterior_e As String, ByRef colonia_e As String, ByRef municipio_e As String,
                                         ByRef estado_e As String, ByRef cp_e As String, ByRef regimen_e As String, ByRef registro_patronal_e As String,
                                         ByRef ruta_certificado_e As String, ByRef ruta_key_e As String, ByRef pass_key_e As String, ByRef regimen_fiscal_e As String,
                                         ByRef folio_actual As String, ByRef folio_inicial As String, ByRef razon_social As String, ByRef actividad_empresa As String, ByRef no_interior_e As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "Select * from DatosNegocio where Emisor_id=" & cbo_emisor.SelectedValue
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                rfc_e = dr("Em_rfc").ToString
                calle_e = Trim(txtLEcalle.Text) 'dr("Em_calle").ToString
                no_exterior_e = Trim(txtLEnumext.Text) 'dr("Em_NumExterior").ToString
                colonia_e = Trim(txtLEcolonia.Text) 'dr("Em_colonia").ToString
                municipio_e = Trim(txtLEalcmun.Text) 'dr("Em_Municipio").ToString
                estado_e = Trim(txtLEedo.Text) 'dr("Em_Estado").ToString
                cp_e = Trim(txtLEcodpos.Text) 'dr("Em_CP").ToString
                regimen_e = dr("Em_RFiscal").ToString
                registro_patronal_e = ""

                Dim sSQL1 As String = "Select * from Formatos where Facturas = 'FILE_CERT'"
                Dim dr1 As DataRow
                Dim odata1 As New ToolKitSQL.myssql
#Disable Warning BC42030 ' La variable 'dr1' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
#Enable Warning BC42030 ' La variable 'dr1' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    ruta_certificado_e = dr1("NotasCred").ToString
                End If

                sSQL1 = "Select * from Formatos where Facturas = 'FILE_KEY'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    ruta_key_e = dr1("NotasCred").ToString
                End If
                'dudas
                sSQL1 = "Select * from Formatos where Facturas = 'Shibboleth_ML'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    glob_pass_key = dr1("NotasCred").ToString
                End If

                sSQL1 = "Select * from Formatos where Facturas = 'SHIBBOLETH'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    pass_key_e = dr1("NotasCred").ToString
                End If

                regimen_fiscal_e = dr("Em_RFiscal").ToString
                folio_actual = ""

                If Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
                    sSQL1 = "Select * from Formatos where Facturas = 'FolioNtaCredIni'"
                    If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                        folio_inicial = dr1("NotasCred").ToString
                    End If
                Else
                    sSQL1 = "Select * from Formatos where Facturas = 'FOLIOfacINI'"
                    If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                        folio_inicial = dr1("NotasCred").ToString
                    End If
                End If

                razon_social = dr("Em_RazonSocial").ToString
                actividad_empresa = dr("Em_Actividad").ToString
                no_interior_e = Trim(txtLEnumint.Text)  'dr("Em_NumInterior").ToString

                sSQL1 = "Select * from Formatos where Facturas = 'SERIE_FACT_EL'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    var_serie1 = dr1("NotasCred").ToString
                End If

                sSQL1 = "Select * from Formatos where Facturas = 'FOLIOfacINI'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    var_folionotac = dr1("NotasCred").ToString
                End If

                sSQL1 = "Select * from Formatos where Facturas = 'SERIE_NC_EL'"
                If odata1.getDr(cnn, dr1, sSQL1, sinfo) Then
                    var_serienotac = dr1("NotasCred").ToString
                End If
            Else
                'MsgBox(sinfo)
            End If
            cnn.Close()
        End If
    End Sub

    Public Sub llena_grid()

        txt_tasaiva.Text = "0"
        Dim sSQL As String = ""
        grid_prods.Rows.Clear()
        Dim client As Integer = 0
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            client = dame_IdClienteRS(Cmb_RazonS.Text)
        End If
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        If Cmb_Nfactura.Text <> "" And Cmb_Nfactura.SelectedValue > 0 Then
            sSQL = "Select * from detalle_factura where cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' Order by orden"
        Else
            sSQL = "Select * from detalle_factura where cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' Order by orden"
        End If
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    var1 = 0
                    For Each dr In dt.Rows
                        Dim unidadcivad As Double = 0
                        Dim var_totalcivad As Double = 0
                        If cboIeps.Text > 0 Then
                            unidadcivad = obtienepiva(CDec(dr("preciou").ToString), CDec(dr("porceniva").ToString))
                            var_totalcivad = obtienepiva(CDec(dr("totalsiva").ToString), CDec(dr("porceniva").ToString))
                        Else
                            unidadcivad = obtienepiva(CDbl(dr("preciou").ToString), CDbl(dr("porceniva").ToString))
                            var_totalcivad = obtienepiva(CDbl(dr("preciou").ToString) * CDbl(dr("cantidad").ToString), CDbl(dr("porceniva").ToString))
                        End If
                        Dim varisr As Double = FormatNumber(CDbl(dr("isr").ToString) / 100, 6)
                        Dim ventas_fact As Decimal = 0

                        If CDec(IIf(CStr(txt_descuento.Text) = "", 0, txt_descuento.Text)) <> 0 Then
                            Dim ivaDescuento As Double = 0
                            Dim ivaDescuentoUni As Double = 0
                            Dim DescuentoUni As Double = 0
                            If txt_piva.Text = 0 Then
                                ivaDescuento = 0 'FormatNumber(CDec(CDec(CDec(txt_descuento.Text) / 1.16) * 0.16), 6)
                                ivaDescuentoUni = 0 'FormatNumber(FormatNumber(CDec(CDec(CDec(txt_descuento.Text) / 1.16) * 0.16), 6) / dr("cantidad").ToString, 6)
                                DescuentoUni = CDec(dr("descuento").ToString) / CDec(dr("cantidad").ToString)
                            Else
                                ivaDescuento = FormatNumber(CDec(CDec(CDec(txt_descuento.Text) / 1.16) * 0.16), 6)
                                ivaDescuentoUni = FormatNumber(FormatNumber(CDec(CDec(CDec(txt_descuento.Text) / 1.16) * 0.16), 6) / dr("cantidad").ToString, 6)
                                DescuentoUni = CDec(dr("descuento").ToString) / CDec(dr("cantidad").ToString)
                            End If
                            If txt_piva.Text > 0 Then
                                ventas_fact = dr("totalsiva").ToString
                                grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString + ivaDescuentoUni, dr("totalsiva").ToString + ivaDescuento, unidadcivad - DescuentoUni, var_totalcivad - dr("descuento").ToString, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, varisr, dr("ieps_porcentaje").ToString, dr("ieps_TasaoCuota").ToString, dr("ret_iva_perc").ToString, ventas_fact)
                            Else
                                grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString + ivaDescuentoUni, dr("totalsiva").ToString + ivaDescuento, unidadcivad - DescuentoUni, var_totalcivad - dr("descuento").ToString, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, varisr, dr("ieps_porcentaje").ToString, dr("ieps_TasaoCuota").ToString, dr("ret_iva_perc").ToString, ventas_fact)
                            End If
                        Else
                            If txt_piva.Text > 0 Then
                                ventas_fact = dr("totalsiva").ToString
                                grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString, dr("totalsiva").ToString, unidadcivad, var_totalcivad, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, FormatNumber(dr("ieps").ToString, 2), dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, varisr, dr("ieps_porcentaje").ToString, dr("ieps_TasaoCuota").ToString, dr("ret_iva_perc").ToString, ventas_fact)
                            Else
                                grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString, dr("totalsiva").ToString, unidadcivad, var_totalcivad, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, FormatNumber(dr("ieps").ToString, 2), dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, varisr, dr("ieps_porcentaje").ToString, dr("ieps_TasaoCuota").ToString, dr("ret_iva_perc").ToString, ventas_fact)
                            End If
                        End If

                        If dr("porceniva").ToString > CDbl(txt_tasaiva.Text) Then
                            txt_tasaiva.Text = dr("porceniva").ToString
                        End If
                        var1 = var1 + 1
                    Next
                Else
                    ''MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
        calcula()
        txt_partida.Text = grid_prods.RowCount + 1
    End Sub

    Function dame_IdClienteRS(ByVal varRS As String) As Integer
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select Id from Clientes where RazonSocial = '" & Trim(Replace(varRS, "'", "''")) & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    cnn.Close()
                    Return CInt(dr("Id").ToString)
                Else
                    cnn.Close()
                    Return 0
                End If
            End If
        End With
#Disable Warning BC42353 ' La función 'dame_IdClienteRS' no devuelve un valor en todas las rutas de acceso de código. ¿Falta alguna instrucción 'Return'?
    End Function

    Private Sub calcula()
        Dim descuentof As Double = 0
        Dim subtotalf As Double = 0
        Dim ivaf As Double = 0
        Dim ivatf As Double = 0
        Dim ivaretf As Double = 0
        Dim iepf As Double = 0
        Dim totalf As Double = 0
        Dim ivaconcepto As Double = 0
        Dim varisr2 As Double = 0

        For i = 0 To grid_prods.RowCount - 1
            ivaconcepto = 0
            descuentof = descuentof + CDbl(grid_prods.Rows(i).Cells(9).Value.ToString)
            subtotalf = subtotalf + CDbl(grid_prods.Rows(i).Cells(5).Value.ToString)
            If grid_prods.Rows(i).Cells(8).Value.ToString / 100 > 0 Then
                If cboIeps.Text > 0 Then
                    ivaconcepto = FormatNumber((CDec(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(grid_prods.Rows(i).Cells(9).Value.ToString)) + CDec(grid_prods.Rows(i).Cells(11).Value.ToString)) * (grid_prods.Rows(i).Cells(8).Value.ToString / 100), 6)
                Else
                    If CDec(grid_prods.Rows(i).Cells(9).Value.ToString) > 0 Then
                        ivaconcepto = FormatNumber((CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(grid_prods.Rows(i).Cells(9).Value.ToString)) * (grid_prods.Rows(i).Cells(8).Value.ToString / 100), 6)
                    Else
                        ivaconcepto = FormatNumber((grid_prods.Rows(i).Cells(5).Value.ToString) * (grid_prods.Rows(i).Cells(8).Value.ToString / 100), 6)
                    End If
                End If
            Else
                ivaconcepto = 0
            End If
            ivatf = ivatf + ivaconcepto
            ivaretf = ivaretf + CDbl(grid_prods.Rows(i).Cells(10).Value.ToString)
            iepf = iepf + CDbl(grid_prods.Rows(i).Cells(11).Value.ToString)
            varisr2 = varisr2 + FormatNumber(CDec(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(grid_prods.Rows(i).Cells(9).Value.ToString)) * CDec(IIf(grid_prods.Rows(i).Cells(15).Value.ToString = "", "0", grid_prods.Rows(i).Cells(15).Value.ToString)), 6)
        Next

        txtISR.Text = FormatNumber(varisr2, 2)
        TextBox1.Text = FormatNumber(subtotalf - descuentof, 2)
        totalf = CDec(FormatNumber(subtotalf, 2)) + CDec(FormatNumber(ivatf, 2)) + CDec(FormatNumber(iepf, 2)) - CDec(FormatNumber(descuentof, 2)) - CDec(FormatNumber(ivaretf, 2)) - CDec(FormatNumber(varisr2, 2))
        Text_Descuento.Text = FormatNumber(descuentof, 2)
        Text_SubTotal.Text = FormatNumber(CDec(subtotalf), 2)
        txtISR.Text = FormatNumber(varisr2, 2)
        Text_IVA.Text = FormatNumber(ivatf, 2)
        Text_IVARET.Text = FormatNumber(ivaretf, 2)
        txt_impuestos.Text = FormatNumber(iepf, 2)
        Text_TOTAL.Text = FormatNumber(totalf, 2)
    End Sub

    Private Sub cbo_emisor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_emisor.KeyDown
        If e.KeyData = Keys.Enter Then
            If cbo_emisor.Text <> "" And Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
                Cmb_Desc.Focus()
                Exit Sub
            End If
            If cbo_emisor.Text <> "" And Cmb_TipoFact.Text <> "NOTA DE CREDITO" Then
                txtNotaVenta.Focus()
            End If
        End If
    End Sub

    Private Sub cbo_emisor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_emisor.SelectedValueChanged
        On Error GoTo malo
        vempresa = cbo_emisor.SelectedValue
        cbo_rfc_emisor.SelectedValue = cbo_emisor.SelectedValue
        llena_cbofolio()
        serie()
malo:
    End Sub

    Private Sub cbo_rfc_emisor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbo_rfc_emisor.KeyDown
        If e.KeyData = Keys.Enter Then
            If cbo_rfc_emisor.Text <> "" And Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
                Cmb_Desc.Focus()
                Exit Sub
            End If
            If cbo_rfc_emisor.Text <> "" And Cmb_TipoFact.Text <> "NOTA DE CREDITO" Then
                txtNotaVenta.Focus()
            End If
        End If
    End Sub

    Private Sub cbo_rfc_emisor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_rfc_emisor.SelectedValueChanged
        On Error GoTo malo
        cbo_emisor.SelectedValue = cbo_rfc_emisor
malo:
    End Sub

    Function dame_RFC_Cliente(ByVal varRS As String) As String
        Dim cnn10 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RFC from Clientes where RazonSocial = '" & varRS & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn10, sTarget, sinfo) Then
                If .getDr(cnn10, dr, sSQL, sinfo) Then
                    cnn10.Close()
                    Return dr("RFC").ToString
                Else
                    cnn10.Close()
                    Return ""
                End If
            End If
        End With
#Disable Warning BC42105 ' La función 'dame_RFC_Cliente' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dame_RFC_Cliente' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub muestra_datos_cliente()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from Clientes where Id=" & var_cliente
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    txt_nombrec.Text = dr("Nombre").ToString
                    Text_calle.Text = dr("Calle").ToString
                    Text_Colonia.Text = dr("Colonia").ToString
                    Text_CP.Text = dr("CP").ToString
                    Text_Delegacion.Text = dr("Delegacion").ToString
                    Text_Edo.Text = dr("Entidad").ToString
                    Text_Email.Text = dr("Correo").ToString
                    Text_Num_Ex.Text = dr("NExterior").ToString
                    Txt_num_int.Text = dr("NInterior").ToString
                    Text_Pais.Text = dr("Pais").ToString
                    cbo_regimen.SelectedValue = dr("Regfis").ToString
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub Cmb_RazonS_DropDown(sender As Object, e As EventArgs) Handles Cmb_RazonS.DropDown
        Cmb_RazonS.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RazonSocial from Clientes where RazonSocial <> '' and RFC <> '' order by RazonSocial"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        Cmb_RazonS.Items.Add(dr("RazonSocial").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub Cmb_RazonS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_RazonS.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Cmb_RazonS.Text <> "" Then
                If dame_IdClienteRS(Cmb_RazonS.Text) = 0 Then MsgBox("El cliente no existe hay que registrarlo en la base de datos") : Exit Sub
                var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                Cmb_RFC.Text = dame_RFC_Cliente(Cmb_RazonS.Text)
                muestra_datos_cliente()
                limpia_prod()
                If Cmb_RFC.Text = "XAXX010101000" Then
                    btnGlobal.Enabled = True
                Else
                    btnGlobal.Enabled = False
                End If
                abrir()
                Dim comando1 As MySqlClient.MySqlCommand
                comando1 = conexion.CreateCommand
                comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
                comando1.ExecuteNonQuery()
                conexion.Close()
            End If
            Text_calle.Focus()
        End If
    End Sub

    Private Sub Cmb_RazonS_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_RazonS.SelectedValueChanged
        On Error GoTo malo
        var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
        Cmb_RFC.Text = dame_RFC_Cliente(Cmb_RazonS.Text)
        muestra_datos_cliente()
        limpia_prod()
        If Cmb_RFC.Text = "XAXX010101000" Then
            btnGlobal.Enabled = True
        Else
            btnGlobal.Enabled = False
        End If
        abrir()
        Dim comando1 As MySqlClient.MySqlCommand
        comando1 = conexion.CreateCommand
        comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
        comando1.ExecuteNonQuery()
        conexion.Close()
malo:
    End Sub

    Private Sub llena_cbo_descripcionticket()
        Dim sSQL As String = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        sSQL = "Select * from Productos order by Nombre"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            With Cmb_Desc
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "Codigo"
                    .DisplayMember = "Nombre"
                    .SelectedValue = -1
                End If
            End With
            cnn.Close()
        End If
    End Sub

    Private Function busca_producto()
        Dim sSQL As String = "Select * from Productos where Codigo='" & var_producto & "'"
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                txt_piva.Text = CInt(CDec(dr("IVA").ToString) * 100)
                txt_ivaret.Text = IIf(dr("PercentIVAret").ToString = "", "0", dr("PercentIVAret").ToString)
                cboIeps.Text = IIf(dr("IIEPS").ToString = "", "0", dr("IIEPS").ToString)
                If CDec(cboIeps.Text) > 0 Then chkTasa.Checked = True
                Text_Precio.Text = FormatNumber(dr("PrecioVenta").ToString, 2)
                txt_unidadventaNew.Text = dr("UnidadSat").ToString
                If dr("UnidadSat").ToString Is Nothing Then
                    txt_unidadventaNew.Text = ""
                End If
                txt_prodsat.Text = dr("ClaveSat").ToString
                If dr("ClaveSat").ToString Is Nothing Then
                    txt_prodsat.Text = ""
                End If
                txtIsrDet.Text = 0
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
#Disable Warning BC42105 ' La función 'busca_producto' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'busca_producto' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub Cmb_Desc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_Desc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_unidadventaNew.Focus()
        End If
    End Sub

    Private Sub Cmb_Desc_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_Desc.SelectedValueChanged
        On Error GoTo malo
        var_producto = Cmb_Desc.SelectedValue
        busca_producto()
malo:
    End Sub

    Private Sub agrega_prod()
        If txtNotaVenta.Text = "" Then
            grid_prods.Rows.Clear()
        End If

        Dim porcentajei As Double = 0
        If Text_Precio.Text = "" Then Text_Precio.Text = "0"
        If txt_piva.Text = "" Then txt_piva.Text = "0"

        If CDec(IIf(CStr(Text_IVARET.Text) = "", 0, Text_IVARET.Text)) > 0 Then
            porcentajei = CDbl(txt_piva.Text) - (Text_IVARET.Text)
        Else
            porcentajei = CDbl(txt_piva.Text)
        End If
        Dim unidadciva As Double = 0

        If cboIeps.Text > 0 Then
            Dim valorDesc As Decimal = 0
            If CDec(txt_descuento.Text) > 0 Then
                valorDesc = CDec(txt_descuento.Text) / CDec(Text_cantidad.Text)
            End If
            cboIeps.Text = FormatNumber(CDbl(cboIeps.Text) / 100, 6)
            unidadciva = obtienepiva(CDec(CDec(CDec(Text_Precio.Text) - CDec(valorDesc)) * CDec(1 + CDec(cboIeps.Text))), CDec(porcentajei))
        Else
            Dim valorDesc As Decimal = 0
            If CDec(txt_descuento.Text) > 0 Then
                valorDesc = CDec(txt_descuento.Text) / CDec(Text_cantidad.Text)
            End If
            unidadciva = obtienepiva(CDec(CDec(Text_Precio.Text) - CDec(valorDesc)) / CDec(Text_cantidad.Text), CDec(porcentajei))
        End If

        Dim var_totalciva As Double = unidadciva * CDbl(Text_cantidad.Text)
        Dim orden As Integer = grid_prods.RowCount + 1
        inserta_prod_detalle(var_producto, var_totalciva, orden)

        txt_tasaiva.Text = "0"
        Dim sSQL As String = ""

        Dim client As Integer = 0
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            client = dame_IdClienteRS(Cmb_RazonS.Text)
        End If
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        If Cmb_Nfactura.Text <> "" And Cmb_Nfactura.SelectedValue > 0 Then
            sSQL = "Select * from detalle_factura where cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' Order by orden"
        Else
            sSQL = "Select * from detalle_factura where cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' Order by orden"
        End If
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    var1 = 0
                    For Each dr In dt.Rows
                        Dim unidadcivad As Double = 0
                        Dim var_totalcivad As Double = 0
                        If cboIeps.Text > 0 Then
                            Dim variDesc As Decimal = 0
                            If CDec(dr("descuento").ToString) > 0 Then
                                variDesc = CDec(dr("descuento").ToString) / CDec(dr("cantidad").ToString)
                            End If

                            unidadcivad = obtienepiva(CDec(CDec(dr("preciou").ToString) - variDesc) + CDec(dr("ieps").ToString), CDec(dr("porceniva").ToString))
                            var_totalcivad = obtienepiva(CDec(CDec(CDec(dr("preciou").ToString) - variDesc) + CDec(dr("ieps").ToString)) * CDec(dr("cantidad").ToString), CDec(dr("porceniva").ToString))
                        Else
                            unidadcivad = obtienepiva(CDbl(dr("preciou").ToString) - CDec(CDec(dr("descuento").ToString) / CDec(dr("cantidad").ToString)), CDbl(dr("porceniva").ToString))
                            var_totalcivad = obtienepiva(CDec(CDbl(dr("preciou").ToString) * CDbl(dr("cantidad").ToString)) - CDec(dr("descuento").ToString), CDbl(dr("porceniva").ToString))
                        End If

                        Dim varisr As Double = FormatNumber(CDbl(dr("isr").ToString) / 100, 6)
                        Dim ventas_fact As Decimal = 0
                        grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString, dr("totalsiva").ToString, unidadcivad, var_totalcivad, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, varisr, dr("ieps_porcentaje").ToString, dr("ieps_TasaoCuota").ToString, dr("ret_iva_perc").ToString, dr("totalsiva").ToString)

                        If txtNotaVenta.Text <> "" Then
                            elimina_producto(dr("id_prod").ToString, CInt(dr("orden").ToString))
                        End If

                        If dr("porceniva").ToString > CDbl(txt_tasaiva.Text) Then
                            txt_tasaiva.Text = dr("porceniva").ToString
                        End If
                        var1 = var1 + 1
                    Next
                End If
                cnn.Close()
            End If
        End With
        calcula()
        txt_partida.Text = grid_prods.RowCount + 1
        limpia_prod()
    End Sub

    Private Sub elimina_producto(ByVal id_prod As String, ByVal orden As Integer)
        Dim ssql As String = ""
        Dim client As Integer = 0
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            client = dame_IdClienteRS(Cmb_RazonS.Text)
        End If

        If Cmb_Nfactura.Text <> "" And Cmb_Nfactura.SelectedValue > 0 Then
            Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo1 As String = ""
            Dim odata1 As New ToolKitSQL.myssql
            Dim dr1 As DataRow
            With odata1
                If .dbOpen(cnn1, sTarget, sinfo1) Then
#Disable Warning BC42030 ' La variable 'dr1' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If .getDr(cnn1, dr1, "select nom_folio from Facturas where nom_folio = " & Cmb_Nfactura.Text & "", sinfo1) Then
#Enable Warning BC42030 ' La variable 'dr1' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        ssql = "Delete from detalle_factura where id_prod='" & id_prod & "' and cliente=" & client & " and orden=" & orden & " and factura=" & Cmb_Nfactura.SelectedValue
                    Else
                        ssql = "Delete from detalle_factura where id_prod='" & id_prod & "' and cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' and orden=" & orden
                    End If
                    cnn1.Close()
                End If
            End With

        Else
            ssql = "Delete from detalle_factura where id_prod='" & id_prod & "' and cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "' and orden=" & orden
        End If
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, ssql, sinfo) Then
            Else
                'MsgBox(sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub inserta_prod_detalle(ByVal id_prod As String, ByVal totaliva As Double, ByVal orden As Integer)
        Dim reten As Double = 0
        Dim clvsatp As String = ""
        Dim operacionesIeps As Decimal = 0

        If txt_ivaret.Text > 0 Then
            reten = FormatNumber(CDbl(txt_ivaret.Text) / 100, 6)
            reten = FormatNumber(CDec(CDec(Text_t.Text) - CDec(txt_descuento.Text)) - ((1 + reten) * CDec(CDec(Text_t.Text) - CDec(txt_descuento.Text))), 6)
        End If

        If cboIeps.Text > 0 Then
            operacionesIeps = CDec((CDec(Text_t.Text)) - CDec(txt_descuento.Text)) + CDec((CDec(Text_t.Text)) - CDec(txt_descuento.Text)) * CDec(cboIeps.Text)
        End If

        Dim describiendoa As String = ""
        buscar_orden()
        recupera(id_prod, describiendoa)
        busca_clvsat(id_prod, clvsatp)
        Dim ssql As String = "INSERT INTO detalle_factura (id_prod, descripcion,descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva" &
            " , descuento, ret_iva, ieps,  cliente, factura, totalsiva " &
            ", orden, clvsat, isr, ieps_porcentaje, ieps_TasaoCuota, ret_iva_perc, ip_loc) values('" & id_prod & "', '" & Cmb_Desc.Text & "','" & describiendoa & "','" & txt_unidadventaNew.Text & "'," & Replace(Text_cantidad.Text, ",", "") & "," & Replace(Text_Precio.Text, ",", "") &
            " , " & Replace(totaliva, ",", "") & "," & txt_piva.Text & ", " & txt_descuento.Text & " ," & Abs(reten) &
            "," & Replace(FormatNumber((CDbl(Text_t.Text) * CDec(cboIeps.Text)), 6), ",", "") & ", " & var_cliente & ", 0, " & Replace(Text_t.Text, ",", "") & ", " & txt_partida.Text & ", '" & txt_prodsat.Text & "'," & IIf(txtIsrDet.Text = "", 0, txtIsrDet.Text) & ",'" & IIf(cboIeps.Text = "", 0, FormatNumber(cboIeps.Text, 2)) & "', '" & IIf(chkTasa.Checked = True, "Tasa", IIf(chkCuota.Checked = True, "Cuota", "")) & "', '" & IIf(txt_ivaret.Text = "", "0", IIf(txt_ivaret.Text = 0, "0", FormatNumber(txt_ivaret.Text / 100, 6))) & "','" & numero_MAC & "')"
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, ssql, sinfo) Then
                '  MsgBox("Registro Insertado")
            Else
                MsgBox(sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub buscar_orden()
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
        Else
            var_cliente = 0
        End If
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from detalle_factura where factura=0 and ip_loc = '" & numero_MAC & "' and cliente=" & var_cliente & " and orden >= " & txt_partida.Text & " order by orden"
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        Dim contador As Integer = 1
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        Dim ssql3 As String = "update detalle_factura set orden=" & txt_partida.Text + contador & " where id_prod=" & dr("id_prod").ToString
                        oData.runSp(cnn, ssql3, sinfo)
                        contador = contador + 1
                    Next
                    ' MsgBox("Copia Lista Seleccione el tipo de Archivo ")
                Else
                    ''MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub recupera(ByVal varidprodd As String, ByRef desxc As String)
        Dim ssql As String = "Select NombreLargo from Productos where Codigo = '" & varidprodd & "'"
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, ssql, sinfo) Then
                desxc = dr("NombreLargo").ToString
            Else
                ' 'MsgBox(sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub busca_clvsat(ByVal idpsat As String, ByRef clvsat As String)
marca:
        comentario1 = ""
        Dim dr As DataRow
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        Dim ssql2 As String = "select ClaveSat from Productos where Codigo='" & idpsat & "'"
        Dim sinfo As String = ""

        If odata.dbOpen(cnn2, sTarget, sinfo) Then
            If odata.getDr(cnn2, dr, ssql2, sinfo) Then
                clvsat = dr("ClaveSat").ToString
            Else
                GoTo marca
            End If
            cnn2.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub buscappp()
        Dim clavesatp As String = ""
        Dim ssqlclv As String = ""
        Dim unisat As String = ""
marca:
        comentario1 = ""
        Dim dr As DataRow
        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        Dim ssql2 As String = "select NombreLargo, Codigo, ClaveSat, UnidadSat from Productos where Nombre='" & Cmb_Desc.Text & "'"
        Dim sinfo As String = ""

        If odata.dbOpen(cnn2, sTarget, sinfo) Then
            If odata.getDr(cnn2, dr, ssql2, sinfo) Then
                var_producto = dr("Codigo").ToString
                comentario1 = dr("NombreLargo").ToString
                clavesatp = dr("ClaveSat").ToString
                If clavesatp = "" Then
                    ssqlclv = "update Productos set ClaveSat='" & txt_prodsat.Text & "' where Codigo='" & var_producto & "'"
                    odata.runSp(cnn2, ssqlclv, sinfo)
                End If
                unisat = dr("UnidadSat").ToString
                If unisat = "" Then
                    ssqlclv = "update Productos set UnidadSat='" & txt_unidadventaNew.Text & "' where Codigo='" & var_producto & "'"
                    odata.runSp(cnn2, ssqlclv, sinfo)
                End If
            Else
                inserta_prod()
                GoTo marca
            End If
            cnn2.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub inserta_prod()
        Dim ssql As String = "INSERT INTO productos ( descripcion_corta,descripcion_larga, Unidad, iva," &
            " ret_iva, ieps, precio_venta, prod_estatus, prod_empresa, clavesat" &
            ") values('" & Cmb_Desc.Text & "','','" & txt_unidadventaNew.Text & "'," & txt_piva.Text & "," & txt_ivaret.Text &
            "," & txt_ieps.Text & "," & Text_Precio.Text & ", 1, " & vempresa & ", '" & txt_prodsat.Text & "')"
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, ssql, sinfo) Then
                '  MsgBox("Registro Insertado")
            Else
                '  'MsgBox(sinfo)
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Private Sub link_agregar_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_agregar.LinkClicked
        If valida_producto() Then
            buscappp()
            agrega_prod()
            limpia_prod()
        End If
    End Sub

    Private Function valida_producto()
        If Cmb_Desc.Text = "" Then
            MsgBox("El Campo de Producto no Puede Estar Vacio")
            Cmb_Desc.Focus()
            Return False
        End If
        If Text_cantidad.Text = "" Or Text_cantidad.Text = "0" Then
            MsgBox("El Campo de Cantidad no Puede Estar Vacio")
            Text_cantidad.Focus()
            Return False
        End If
        If txt_prodsat.Text = "" Then
            MsgBox("Seleccione Producto del SAT")
            Return False
        End If
        Return True
    End Function

    Private Sub Cmb_TipoFact_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_TipoFact.SelectedIndexChanged
        On Error GoTo MALO
        If factupre = False Then
            If cbo_emisor.SelectedValue > 0 Then
                llena_cbofolio()
                limpia_lugarexp()
                datos_empresa_fiscales(rfc_e, calle_e, no_exterior_e, colonia_e, municipio_e,
                                              estado_e, cp_e, regimen_e, registro_patronal_e,
                                              ruta_certificado_e, ruta_key_e, pass_key_e, regimen_fiscal_e,
                                              folio_actual, folio_inicial, razon_social, actividad_empresa, no_interior_e)

                Select Case Cmb_TipoFact.Text
                    Case "FACTURA"
                        txt_serie.Text = var_serie1
                    Case "PREFACTURA"
                        txt_serie.Text = var_serie1
                    Case "RECIBO DE ARRENDAMIENTO"
                        txt_serie.Text = var_seriearrenda
                    Case "RECIBO DE HONORARIOS"
                        txt_serie.Text = var_seriehonorario
                    Case "NOTA DE CREDITO"
                        txt_serie.Text = var_serienotac
                End Select
                limpia_campos()
            End If
        End If
        busca_Foliofact()
MALO:
    End Sub

    Private Sub grid_prods_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_prods.CellContentDoubleClick
        If grid_prods.RowCount > 0 Then
            Cmb_Desc.SelectedValue = -1
            Cmb_Desc.SelectedValue = grid_prods.CurrentRow.Cells(0).Value.ToString
            txt_unidadventaNew.Text = grid_prods.CurrentRow.Cells(2).Value.ToString
            Text_cantidad.Text = grid_prods.CurrentRow.Cells(3).Value.ToString
            Text_Precio.Text = grid_prods.CurrentRow.Cells(4).Value.ToString
            Text_IVA.Text = grid_prods.CurrentRow.Cells(8).Value.ToString
            txt_partida.Text = CDec(txt_partida.Text) - 1 'grid_prods.CurrentRow.Cells(13).Value.ToString
            If IsNumeric(grid_prods.CurrentRow.Cells(16).Value.ToString) Then
                If CDec(grid_prods.CurrentRow.Cells(16).Value.ToString) > 0 Then
                    cboIeps.Text = FormatNumber(grid_prods.CurrentRow.Cells(16).Value.ToString * 100, 1)
                Else
                    cboIeps.Text = 0
                End If
            Else
                cboIeps.Text = 0
            End If
            Text_Descuento.Text = grid_prods.CurrentRow.Cells(9).Value.ToString
            elimina_producto(grid_prods.CurrentRow.Cells(0).Value.ToString, grid_prods.CurrentRow.Cells(13).Value.ToString)
            Me.grid_prods.Rows.Remove(Me.grid_prods.CurrentRow)
            calcula()

            Cmb_Desc.Focus()
        End If
    End Sub

    Private Sub EliminarSeleccionadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarSeleccionadoToolStripMenuItem.Click
        If grid_prods.Rows.Count > 0 Then
            If MsgBox("Desea eliminar este producto?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Cmb_Nfactura.Text = ""
                abrir()
                Dim comando1 As MySqlClient.MySqlCommand
                comando1 = conexion.CreateCommand
                comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "' and orden = " & grid_prods.CurrentRow.Cells(13).Value.ToString & ""
                comando1.ExecuteNonQuery()
                conexion.Close()
                Me.grid_prods.Rows.Remove(Me.grid_prods.CurrentRow)
                'elimina_producto(grid_prods.CurrentRow.Cells(0).Value.ToString, grid_prods.CurrentRow.Cells(13).Value.ToString)
                'llena_grid()
                calcula()
                bfoliofac()
                Cmb_Nfactura.Text = var_folio
            End If
        Else
            MsgBox("No Existe elementos para eliminar")
        End If
    End Sub

    Private Sub EditarDescripcionLargaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarDescripcionLargaToolStripMenuItem.Click
        var_cotb = 0
        If grid_prods.Rows.Count > 0 Then
            edita_desc.Show()
        Else
            MsgBox("No Existe elementos para Editar")
        End If
    End Sub

    Private Sub Btt_Generar_Click(sender As Object, e As EventArgs) Handles Btt_Generar.Click
        If grid_prods.RowCount = 0 Then
            MsgBox("Tiene almenos que registrar un producto o servicio para realizar la factura")
            Exit Sub
        End If

        For i = 0 To grid_prods.RowCount - 1
            If grid_prods.Rows(i).Cells(2).Value.ToString = "" Then
                MsgBox("EL producto " & grid_prods.Rows(i).Cells(1).Value.ToString & " debe tener unidad de medida del SAT para poder facturar")
                Exit Sub
            ElseIf grid_prods.Rows(i).Cells(14).Value.ToString = "" Then
                MsgBox("EL producto " & grid_prods.Rows(i).Cells(1).Value.ToString & " debe tener codigo de producto o servicio del SAT para poder facturar")
                Exit Sub
            End If
        Next

        If CheckBox2.Checked = True Then
            If txtPlaca.Text = "" Then MsgBox("Para el complemento carta porte debe escribir o seleccionar una placa") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtPlaca.Focus() : Exit Sub
            If txtModeloAño.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el modelo") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtModeloAño.Focus() : Exit Sub
            If txtAseguradora.Text = "" Then MsgBox("Para el complemento carta porte debe escribir la aseguradora") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtAseguradora.Focus() : Exit Sub
            If txtNumPoliza.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el número de póliza") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtNumPoliza.Focus() : Exit Sub
            If txtNumPermisoSCT.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el número de permisoSCT") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtNumPermisoSCT.Focus() : Exit Sub
            If cboConfigV.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar un valor de Configuración Vehícular") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboConfigV.Focus() : Exit Sub
            If cboPermisoSCT.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar un valor de PermisoSCT") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboPermisoSCT.Focus() : Exit Sub
            If cboOrigRemitente.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar un valor de Remitente") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboOrigRemitente.Focus() : Exit Sub
            If txtOrigRFC.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el RFC de Remitente") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtOrigRFC.Focus() : Exit Sub
            If txtOrigCP.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el CP de Remitente") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtOrigCP.Focus() : Exit Sub
            If cboOrigEdo.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar el estado de Remitente") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboOrigEdo.Focus() : Exit Sub
            If cboDesDestinatario.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar un  Destinatario") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboDesDestinatario.Focus() : Exit Sub
            If txtDesRFC.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el RFC del Destinatario") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtDesRFC.Focus() : Exit Sub
            If txtDestinoCP.Text = "" Then MsgBox("Para el complemento carta porte debe escribir el CP del Destinatario") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : txtDestinoCP.Focus() : Exit Sub
            If cboDestinoPais.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar el país del Destinatario") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboDestinoPais.Focus() : Exit Sub
            If cboDestinoEdo.Text = "" Then MsgBox("Para el complemento carta porte debe seleccionar el estado del Destinatario") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage1 : cboDestinoEdo.Focus() : Exit Sub
            If dgProductos.RowCount = 0 Then
                MsgBox("Para el complemento carta porte debe haber mercancia registrada en los datos") : GroupBox7.Show() : TabControl1.SelectedTab = TabPage2 : cboDescripcion.Focus() : Exit Sub
            End If
        End If

        varnomemail = cbo_emisor.Text
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        Dim dr As DataRow

        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                sSQL = "select nom_folio from Facturas where estatus_fac = 1 and nom_folio = " & Cmb_Nfactura.Text & ""
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, sSQL, sinfo) Then
                            MsgBox("El folio ya fue facturado")
                            Exit Sub
                        Else
                        End If
                    End If
                End With

            Case "PREFACTURA"

                'sSQL = "select nom_folio from Facturas where estatus_fac = 2 and nom_folio = " & Cmb_Nfactura.Text & ""
                'With oData
                '    If .dbOpen(cnn, sTarget, sinfo) Then
                '        If .getDr(cnn, dr, sSQL, sinfo) Then

                '        Else
                '        End If
                '    End If
                'End With

            Case "NOTA DE CREDITO"

                sSQL = "select nom_folio from Facturas where estatus_fac = 6 and nom_folio = " & Cmb_Nfactura.Text & ""
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, sSQL, sinfo) Then
                            MsgBox("La nota de credito ya fue realizada")
                            Exit Sub
                        Else
                        End If
                    End If
                End With

            Case Else
        End Select

        ProgressBar1.Maximum = 100
        ProgressBar1.Minimum = 0
        lbl_proceso.Visible = True
        ProgressBar1.Visible = True
        ProgressBar1.Value = 1
        lbl_proceso.Text = "Procesando ..."
        My.Application.DoEvents()

        cadena_pagos1 = ""
        factupre = False
        metodo_p_ac = ""
        metodo_p_ac = cbometodo_pago.SelectedValue

        Select Case metodo_p_ac
            Case "01"
                cadena_pagos1 &= "01 Efectivo."
            Case "02"
                cadena_pagos1 &= "02 Cheque nominativo."
            Case "03"
                cadena_pagos1 &= "03 Transferencia electronica de fondos."
            Case "04"
                cadena_pagos1 &= "04 Tarjetas de crédito."
            Case "05"
                cadena_pagos1 &= "05 Monedero electrónico."
            Case "06"
                cadena_pagos1 &= "06 Dinero electrónico"
            Case "08"
                cadena_pagos1 &= "08 Vales de despensa"
            Case "12"
                cadena_pagos1 &= "12 Dación en pago"
            Case "13"
                cadena_pagos1 &= "13 Pago por subrogación"
            Case "14"
                cadena_pagos1 &= "14 Pago por consignación"
            Case "15"
                cadena_pagos1 &= "15 Condonación"
            Case "17"
                cadena_pagos1 &= "17 Compensación"
            Case "23"
                cadena_pagos1 &= "23 Novación"
            Case "24"
                cadena_pagos1 &= "24 Confusión"
            Case "25"
                cadena_pagos1 &= "25 Remisión de deuda"
            Case "26"
                cadena_pagos1 &= "26 Prescripción o caducidad"
            Case "27"
                cadena_pagos1 &= "27 A satisfacción del acreedor"
            Case "28"
                cadena_pagos1 &= "28 Tarjeta de Debito"
            Case "29"
                cadena_pagos1 &= "29 Tarjeta de Servicio"
            Case "30"
                cadena_pagos1 &= "30 Aplicación de anticipos"
            Case "99"
                cadena_pagos1 &= "99 Por definir"
            Case Else
        End Select

        ' Next
        ProgressBar1.Value = 5
        lbl_proceso.Text = "Validando Campos..."
        My.Application.DoEvents()
        If valida_datos() Then
            Select Case Cmb_TipoFact.Text
                Case "FACTURA"
                    bfoliofac()
                    prefacturar()
                Case "PREFACTURA"
                    If Cmb_Nfactura.SelectedValue > 0 And Cmb_Nfactura.Text <> "" Then
                        If MsgBox("Desea Facturar esta Prefactura?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            factupre = True
                            'duplica_detalle()
                            'llena_grid()
                            My.Application.DoEvents()
                            Cmb_TipoFact.Text = "FACTURA"
                            My.Application.DoEvents()
                            Btt_Generar.PerformClick()
                            My.Application.DoEvents()
                        End If
                    Else
                        var_idfactura = 0
                        var_folio = 0
                        bfoliofac()
                        prefacturar()
                        llena_cbofolio()

                    End If
                Case "RECIBO DE ARRENDAMIENTO"
                    bfoliofac()
                    prefacturar()
                Case "RECIBO DE HONORARIOS"
                    txt_serie.Text = var_seriehonorario
                Case "NOTA DE CREDITO"
                    txt_serie.Text = var_serienotac
                    bfoliofac()
                    prefacturar()
                Case Else
                    MsgBox("Debe Seleccionar un Tipo de Documento")
            End Select

        End If
        factupre = False

        Btt_Nuevo.PerformClick()
        lbl_proceso.Visible = False
        ProgressBar1.Visible = False
    End Sub

    Private Sub prefacturar()
        ProgressBar1.Value = 20
        lbl_proceso.Text = "Almacenando Datos ..."
        My.Application.DoEvents()
        datos_empresa_fiscales(rfc_e, calle_e, no_exterior_e, colonia_e, municipio_e,
                                          estado_e, cp_e, regimen_e, registro_patronal_e,
                                          ruta_certificado_e, ruta_key_e, pass_key_e, regimen_fiscal_e,
                                          folio_actual, folio_inicial, razon_social, actividad_empresa, no_interior_e)

        Dim folio As Integer = var_folio
        ProgressBar1.Value = 30
        lbl_proceso.Text = "Guardando Datos ..."
        My.Application.DoEvents()
        If Cmb_TipoFact.Text = "PREFACTURA" Then
            var_folio = folio  'GUARDA PREFACTURA
            If Guarda_prefac(var_folio, txt_serie.Text, Replace(Text_SubTotal.Text, ",", ""),
                        Replace(Text_TOTAL.Text, ",", ""), metodo_p_ac, Text_FormaPago.SelectedValue,
                        "México", estado_e, rfc_e, razon_social,
                        calle_e, no_exterior_e, colonia_e, municipio_e,
                        estado_e, "México", cp_e, actividad_empresa,
                        Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text,
                       Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                        "", var_cliente, regimen_e,
                        folio, regimen_fiscal_e,
                        "XXXXX", "", "XXXXXX", "XXXXX", "XXXXXX", "XXXXXXX", "XXXXXXX",
                        Text_Num_Ex.Text, var_folio, Text_Edo.Text, var_folio, Replace(Text_Descuento.Text, ",", ""), Replace(Text_IVA.Text, ",", ""), Replace(Text_TOTAL.Text, ",", ""), no_interior_e) Then

                If var_idfactura = 0 Then
                    If grid_prods.RowCount > 0 Then
                        abrir()
                        Dim comando1 As MySqlClient.MySqlCommand
                        comando1 = conexion.CreateCommand
                        comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
                        comando1.ExecuteNonQuery()
                        conexion.Close()

                        For i = 0 To grid_prods.RowCount - 1
                            abrir()
                            Dim comando2 As MySqlClient.MySqlCommand
                            Dim varDescuentoUni As Double = 0
                            varDescuentoUni = CDec(grid_prods.Rows(i).Cells(9).Value.ToString) / CDec(grid_prods.Rows(i).Cells(3).Value.ToString)
                            comando2 = conexion.CreateCommand
                            comando2.CommandText = "INSERT INTO detalle_factura (id_prod, descripcion, descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva , descuento, ret_iva, ieps, cliente, factura, totalsiva " &
                                            ", orden,clvsat,isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc) values('" & grid_prods.Rows(i).Cells(0).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(1).Value.ToString, ",", "") & "','" & Replace(grid_prods.Rows(i).Cells(12).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(2).Value.ToString & "'," & Replace(grid_prods.Rows(i).Cells(3).Value.ToString, ",", "") & "," & Replace(CDec(grid_prods.Rows(i).Cells(4).Value.ToString) - CDec(varDescuentoUni), ",", "") &
                                            " , " & Replace(grid_prods.Rows(i).Cells(7).Value.ToString, ",", "") & "," & Replace(grid_prods.Rows(i).Cells(8).Value.ToString, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(9).Value.ToString, ",", "") & " ," & Replace(grid_prods.Rows(i).Cells(10).Value.ToString, ",", "") &
                                            "," & Replace(grid_prods.Rows(i).Cells(11).Value.ToString, ",", "") & ", " & dame_IdClienteRS(Cmb_RazonS.Text) & ", '0', " & Replace(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(varDescuentoUni), ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(13).Value.ToString, ",", "") & ", '" & grid_prods.Rows(i).Cells(14).Value.ToString & "',0,'" & Replace(grid_prods.Rows(i).Cells(16).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(17).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(18).Value.ToString, ",", "") & "','" & numero_MAC & "')"
                            comando2.ExecuteNonQuery()
                            conexion.Close()
                        Next
                    End If

                    ProgressBar1.Value = 50
                    lbl_proceso.Text = "Creando PDF ..."
                    bprefac()
                    actualiza_detalle()
                    printRecibo()
                    Cmb_RazonS.Focus()
                Else
                    MsgBox(var_idfactura)
                    printRecibo()
                    Cmb_RazonS.Focus()
                End If
            End If
        End If

        If Cmb_TipoFact.Text = "FACTURA" Then 'GUARDAFACTURA
            ProgressBar1.Value = 30
            lbl_proceso.Text = "Buscando Datos en Delsscom ..."
            My.Application.DoEvents()
            If checat(rfc_e) Then
                If var_folio < folio_inicial Then
                    var_folio = folio_inicial
                End If
                ProgressBar1.Value = 40
                lbl_proceso.Text = "Guardando Datos Temporales ..."
                My.Application.DoEvents()

                Dim cartp As Integer = 0
                If CheckBox2.Checked Then
                    cartp = 1
                End If

                If Guarda_fac(var_folio, txt_serie.Text, Replace(Text_SubTotal.Text, ",", ""),
                           Replace(Text_TOTAL.Text, ",", ""), metodo_p_ac, Text_FormaPago.SelectedValue,
                            "Mexico", estado_e, rfc_e, razon_social,
                            calle_e, no_exterior_e, colonia_e, municipio_e,
                            estado_e, "Mexico", cp_e, actividad_empresa,
                            Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text,
                            Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                            "", var_cliente, regimen_e,
                            folio, regimen_fiscal_e,
                            "", "", "", "", "", "", "",
                            Text_Num_Ex.Text, var_folio, Text_Edo.Text, Cmb_Nfactura.Text, Replace(Text_Descuento.Text, ",", ""), Replace(Text_IVA.Text, ",", ""), Replace(Text_TOTAL.Text, ",", ""), cartp, no_interior_e) Then

                    bprefac()

                    ProgressBar1.Value = 45
                    lbl_proceso.Text = "Generando XML Base ..."
                    My.Application.DoEvents()

                    Dim varinter As String = "No"
                    Dim numpedimento As String = ""

                    If chkInter.Checked Then
                        varinter = "Sí"
                        If txtNumPed1.Text <> "" And txtNumPed2.Text <> "" And txtNumPed3.Text <> "" And txtNumPed4.Text <> "" Then
                            numpedimento = txtNumPed1.Text & "  " & txtNumPed2.Text & "  " & txtNumPed3.Text & "  " & txtNumPed4.Text  '"21  47  3807  8003832"
                        End If
                    End If

                    If GeneraXML4(var_folio, txt_serie.Text, Replace(Text_SubTotal.Text, ",", ""), Replace(Text_Descuento.Text, ",", ""), Text_MotivoDes.Text,
                            Replace(Text_TOTAL.Text, ",", ""), metodo_p_ac,
                            "Mexico", estado_e, rfc_e, razon_social,
                            calle_e, no_exterior_e, no_interior_e, colonia_e, municipio_e,
                            estado_e, "Mexico", cp_e, actividad_empresa,
                            Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text, Txt_num_int.Text,
                            Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                            Text_CP.Text, Text_Num_Ex.Text, regimen_e, registro_patronal_e, var_idfactura,
                            ruta_certificado_e, ruta_key_e, pass_key_e, var_folio, Cmb_Nfactura.Text, Replace(Text_SubTotal.Text, ",", ""),
                            regimen_e, Text_CondiPago.Text, "1", cartp, numpedimento) Then

                        Dim oData As New ToolKitSQL.myssql
                        Dim str As String = ""
                        Dim str1(10000) As String
                        Dim contarray As Integer = 0
                        For x = 1 To txtNotaVenta.TextLength
                            str = Mid$(txtNotaVenta.Text, x, 1)
                            If str = "," Then
                                contarray = contarray + 1
                            Else
                                str1(contarray) = str1(contarray) & str
                            End If
                        Next

                        My.Application.DoEvents()
                        busca_ultimoidfac()

                        If grid_prods.RowCount > 0 Then

                            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                            Dim sinfo As String = ""
                            Dim odata1 As New ToolKitSQL.myssql
                            With odata1
                                If .dbOpen(cnn, sTarget, sinfo) Then
                                    .runSp(cnn, "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'", sinfo)
                                    cnn.Close()
                                End If
                            End With

                            For i = 0 To grid_prods.RowCount - 1
                                Dim ValorM As String = ""
                                Dim PesoKg As String = ""
                                Dim NumPed As String = ""
                                Dim UUIDComE As String = ""
                                Dim FracArancelaria As String = ""

                                Dim varDescuentoUni As Double = 0
                                varDescuentoUni = CDec(grid_prods.Rows(i).Cells(9).Value.ToString) / CDec(grid_prods.Rows(i).Cells(3).Value.ToString)
                                With odata1
                                    If .dbOpen(cnn, sTarget, sinfo) Then
                                        .runSp(cnn, "INSERT INTO detalle_factura (id_prod, descripcion, descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva , descuento, ret_iva, ieps, cliente, factura, totalsiva " &
                                                ", orden,clvsat,isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc,ValorM,PesoKg,NumPed,UUIDComE,FracArancelaria) values('" & grid_prods.Rows(i).Cells(0).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(1).Value.ToString, ",", "") & "','" & Replace(grid_prods.Rows(i).Cells(12).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(2).Value.ToString & "'," & Replace(grid_prods.Rows(i).Cells(3).Value.ToString, ",", "") & "," & Replace(CDec(grid_prods.Rows(i).Cells(4).Value.ToString) - varDescuentoUni, ",", "") &
                                                " , " & Replace(grid_prods.Rows(i).Cells(7).Value.ToString, ",", "") & "," & Replace(grid_prods.Rows(i).Cells(8).Value.ToString, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(9).Value.ToString, ",", "") & " ," & Replace(grid_prods.Rows(i).Cells(10).Value.ToString, ",", "") &
                                                "," & Replace(grid_prods.Rows(i).Cells(11).Value.ToString, ",", "") & ", " & dame_IdClienteRS(Cmb_RazonS.Text) & ", '0', " & Replace(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - varDescuentoUni, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(13).Value.ToString, ",", "") & ", '" & grid_prods.Rows(i).Cells(14).Value.ToString & "','" & grid_prods.Rows(i).Cells(15).Value.ToString & "','" & Replace(IIf(IsNothing(grid_prods.Rows(i).Cells(16).Value), "", grid_prods.Rows(i).Cells(16).Value.ToString), ",", "") & "','" & IIf(IsNothing(grid_prods.Rows(i).Cells(17).Value), "", grid_prods.Rows(i).Cells(17).Value.ToString) & "','" & Replace(IIf(IsNothing(grid_prods.Rows(i).Cells(18).Value), "", grid_prods.Rows(i).Cells(18).Value.ToString), ",", "") & "','" & numero_MAC &
                                                "','" & Replace(ValorM, ",", "") & "','" & Replace(PesoKg, ",", "") & "','" & Replace(NumPed, ",", "") & "','" & Replace(UUIDComE, ",", "") & "','" & Replace(FracArancelaria, ",", "") & "')", sinfo)
                                        cnn.Close()
                                    End If
                                End With
                            Next
                        End If

                        actualiza_detalle()

                        Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                        Dim sinfo2 As String = ""
                        If CStr(cboTipoRelacion.Text) <> "" And CDec(dgUUID.RowCount) > 0 Then
                            If oData.dbOpen(cnn2, sTarget, sinfo2) Then
                                For i = 0 To dgUUID.RowCount - 1
                                    oData.runSp(cnn2, "insert into UUIDRelacion(IdFact, UUID, TipoRelacion) values(" & Cmb_Nfactura.Text & ", '" & dgUUID.Rows(i).Cells(1).Value.ToString() & "','" & cboTipoRelacion.Text & "')", sinfo2)
                                Next
                                cnn2.Close()
                            End If
                        End If

                        cnn2 = New MySqlClient.MySqlConnection
                        Dim sQuery2 As String = ""
                        Dim Er2 As String = ""
                        For x1 = 0 To contarray
                            If oData.dbOpen(cnn2, sTarget, "") = True Then
                                sQuery2 = "Update Ventas set Facturado= '" & Cmb_Nfactura.Text & "' where Folio=" & str1(x1) & ""
                                If oData.runSp(cnn2, sQuery2, Er2) = True Then
                                End If
                                cnn2.Close()
                            End If
                        Next

                        MsgBox("TIMBRADO CORRECTAMENTE ")

                        ProgressBar1.Value = 80
                        lbl_proceso.Text = "Actualizando Base ..."
                        Thread.Sleep(1000)
                        printRecibo()

                        If MsgBox("Desea imprimir la factura en Ticket?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Dim var666 As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\imagenes\" & Cmb_Nfactura.Text & ".jpg"
                            PictureBox2.Image = System.Drawing.Image.FromFile(Convert.ToString(var666))
                            Dim ps As New System.Drawing.Printing.PaperSize("Custom", 269, 3000)
                            PrintDocument1.DefaultPageSettings.PaperSize = ps
                            FolioTicket = Cmb_Nfactura.Text
                            PrintDocument1.Print()
                            envio_mail.BringToFront()
                        End If
                        Cmb_RazonS.Focus()
                    End If
                End If
            End If
        End If

        If Cmb_TipoFact.Text = "RECIBO DE ARRENDAMIENTO" Then 'GUARDAFACTURA

            If var_folio < folio_inicial Then
                var_folio = var_folioarrenda
            End If

            If Guarda_fac(var_folio, txt_serie.Text, Text_SubTotal.Text,
                       Text_TOTAL.Text, metodo_p_ac, Text_FormaPago.SelectedValue,
                        "Mexico", estado_e, rfc_e, razon_social,
                        calle_e, no_exterior_e, colonia_e, municipio_e,
                        estado_e, "Mexico", cp_e, actividad_empresa,
                        Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text,
                    Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                        "", dame_IdClienteRS(Cmb_RazonS.Text), regimen_e,
                        folio, regimen_fiscal_e,
                        "", "", "", "", "", "", "",
                        Text_Num_Ex.Text, var_folio, Text_Edo.Text, Cmb_Nfactura.Text, Text_Descuento.Text, Text_IVA.Text, Text_TOTAL.Text, 0, no_interior_e) Then


                bprefac()
                If GeneraXML(var_folio, txt_serie.Text, Text_SubTotal.Text, Text_Descuento.Text, Text_MotivoDes.Text,
                         Text_TOTAL.Text, metodo_p_ac,
                        "Mexico", estado_e, rfc_e, razon_social,
                        calle_e, no_exterior_e, no_interior_e, colonia_e, municipio_e,
                        estado_e, "Mexico", cp_e, actividad_empresa,
                       Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text, Txt_num_int.Text,
                        Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                        Text_CP.Text, Text_Num_Ex.Text, regimen_e, registro_patronal_e, var_idfactura,
                        ruta_certificado_e, ruta_key_e, pass_key_e, var_folio, Cmb_Nfactura.Text, Text_SubTotal.Text,
                         regimen_e, Text_CondiPago.Text, "1", 0, "") Then

                    If grid_prods.RowCount > 0 Then
                        abrir()
                        Dim comando1 As MySqlClient.MySqlCommand
                        comando1 = conexion.CreateCommand
                        comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
                        comando1.ExecuteNonQuery()
                        conexion.Close()

                        For i = 0 To grid_prods.RowCount - 1
                            abrir()
                            Dim comando2 As MySqlClient.MySqlCommand
                            comando2 = conexion.CreateCommand
                            Dim varDescuentoUni As Double = 0
                            varDescuentoUni = CDec(grid_prods.Rows(i).Cells(9).Value.ToString) / CDec(grid_prods.Rows(i).Cells(3).Value.ToString)
                            comando2.CommandText = "INSERT INTO detalle_factura (id_prod, descripcion, descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva , descuento, ret_iva, ieps, cliente, factura, totalsiva " &
                                            ", orden,clvsat,isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc) values('" & grid_prods.Rows(i).Cells(0).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(1).Value.ToString, ",", "") & "','" & Replace(grid_prods.Rows(i).Cells(12).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(2).Value.ToString & "'," & Replace(grid_prods.Rows(i).Cells(3).Value.ToString, ",", "") & "," & Replace(CDec(grid_prods.Rows(i).Cells(4).Value.ToString) - CDec(varDescuentoUni), ",", "") &
                                            " , " & Replace(grid_prods.Rows(i).Cells(7).Value.ToString, ",", "") & "," & Replace(grid_prods.Rows(i).Cells(8).Value.ToString, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(9).Value.ToString, ",", "") & " ," & Replace(grid_prods.Rows(i).Cells(10).Value.ToString, ",", "") &
                                            "," & Replace(grid_prods.Rows(i).Cells(11).Value.ToString, ",", "") & ", " & dame_IdClienteRS(Cmb_RazonS.Text) & ", '0', " & Replace(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) + varDescuentoUni, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(13).Value.ToString, ",", "") & ", '" & grid_prods.Rows(i).Cells(14).Value.ToString & "',0,'" & Replace(grid_prods.Rows(i).Cells(16).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(17).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(18).Value.ToString, ",", "") & "','" & numero_MAC & "')"
                            comando2.ExecuteNonQuery()
                            conexion.Close()
                        Next
                    End If

                    MsgBox("TIMBRADO CORRECTAMENTE ")
                    actualiza_detalle()
                    printRecibo()
                    Cmb_RazonS.Focus()
                End If
            End If
        End If

        If Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
            ProgressBar1.Value = 30
            lbl_proceso.Text = "Buscando Datos en Delsscom ..."
            My.Application.DoEvents()

            If checat(rfc_e) Then
                If var_folio < IIf(folio_inicial = "", 0, folio_inicial) Then

                    var_folio = folio_inicial
                End If
                ProgressBar1.Value = 40
                lbl_proceso.Text = "Guardando Datos Temporales ..."
                My.Application.DoEvents()

                If Guarda_fac(var_folio, txt_serie.Text, Replace(Text_SubTotal.Text, ",", ""),
                           Replace(Text_TOTAL.Text, ",", ""), metodo_p_ac, Text_FormaPago.SelectedValue,
                            "Mexico", estado_e, rfc_e, razon_social,
                            calle_e, no_exterior_e, colonia_e, municipio_e,
                            estado_e, "Mexico", cp_e, actividad_empresa,
                            Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text,
                        Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                            "", var_cliente, regimen_e,
                            folio, regimen_fiscal_e,
                            "", "", "", "", "", "", "",
                            Text_Num_Ex.Text, var_folio, Text_Edo.Text, Cmb_Nfactura.Text, Replace(Text_Descuento.Text, ",", ""), Replace(Text_IVA.Text, ",", ""), Replace(Text_TOTAL.Text, ",", ""), 0, no_interior_e) Then

                    bprefac()

                    ProgressBar1.Value = 45
                    lbl_proceso.Text = "Generando XML Base ..."
                    My.Application.DoEvents()

                    If GeneraXML(var_folio, txt_serie.Text, Replace(Text_SubTotal.Text, ",", ""), Replace(Text_Descuento.Text, ",", ""), Text_MotivoDes.Text,
                             Replace(Text_TOTAL.Text, ",", ""), metodo_p_ac,
                            "Mexico", estado_e, rfc_e, razon_social,
                            calle_e, no_exterior_e, no_interior_e, colonia_e, municipio_e,
                            estado_e, "Mexico", cp_e, actividad_empresa,
                           Cmb_RFC.Text, Cmb_RazonS.Text, Text_Num_Ex.Text, Txt_num_int.Text,
                            Text_calle.Text, Text_Colonia.Text, Text_Delegacion.Text,
                            Text_CP.Text, Text_Num_Ex.Text, regimen_e, registro_patronal_e, var_idfactura,
                            ruta_certificado_e, ruta_key_e, pass_key_e, var_folio, Cmb_Nfactura.Text, Replace(Text_SubTotal.Text, ",", ""),
                             regimen_e, Text_CondiPago.Text, "1", 0, "") Then

                        If grid_prods.RowCount > 0 Then
                            abrir()
                            Dim comando1 As MySqlClient.MySqlCommand
                            comando1 = conexion.CreateCommand
                            comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
                            comando1.ExecuteNonQuery()
                            conexion.Close()

                            For i = 0 To grid_prods.RowCount - 1
                                abrir()
                                Dim comando2 As MySqlClient.MySqlCommand
                                comando2 = conexion.CreateCommand
                                Dim varDescuentoUni As Double = 0
                                varDescuentoUni = CDec(grid_prods.Rows(i).Cells(9).Value.ToString) / CDec(grid_prods.Rows(i).Cells(3).Value.ToString)
                                comando2.CommandText = "INSERT INTO detalle_factura (id_prod, descripcion, descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva , descuento, ret_iva, ieps, cliente, factura, totalsiva " &
                                                ", orden,clvsat,isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc) values('" & grid_prods.Rows(i).Cells(0).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(1).Value.ToString, ",", "") & "','" & Replace(grid_prods.Rows(i).Cells(12).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(2).Value.ToString & "'," & Replace(grid_prods.Rows(i).Cells(3).Value.ToString, ",", "") & "," & Replace(CDec(grid_prods.Rows(i).Cells(4).Value.ToString) - CDec(varDescuentoUni), ",", "") &
                                                " , " & Replace(grid_prods.Rows(i).Cells(7).Value.ToString, ",", "") & "," & Replace(grid_prods.Rows(i).Cells(8).Value.ToString, ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(9).Value.ToString, ",", "") & " ," & Replace(grid_prods.Rows(i).Cells(10).Value.ToString, ",", "") &
                                                "," & Replace(grid_prods.Rows(i).Cells(11).Value.ToString, ",", "") & ", " & dame_IdClienteRS(Cmb_RazonS.Text) & ", '0', " & Replace(CDec(grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(varDescuentoUni), ",", "") & ", " & Replace(grid_prods.Rows(i).Cells(13).Value.ToString, ",", "") & ", '" & grid_prods.Rows(i).Cells(14).Value.ToString & "',0,'" & Replace(grid_prods.Rows(i).Cells(16).Value.ToString, ",", "") & "','" & grid_prods.Rows(i).Cells(17).Value.ToString & "','" & Replace(grid_prods.Rows(i).Cells(18).Value.ToString, ",", "") & "','" & numero_MAC & "')"
                                comando2.ExecuteNonQuery()
                                conexion.Close()
                            Next
                        End If

                        MsgBox("TIMBRADO CORRECTAMENTE ")

                        ProgressBar1.Value = 80
                        lbl_proceso.Text = "Actualizando Base ..."
                        My.Application.DoEvents()
                        busca_ultimoidfac()
                        actualiza_detalle()
                        Thread.Sleep(1000)

                        printRecibo()
                        Cmb_RazonS.Focus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub busca_ultimoidfac()
        Dim varfinalest As Integer = 0

        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                varfinalest = ESTATUS_FACTURA
            Case "PREFACTURA"
                varfinalest = ESTATUS_PREFACTURA
            Case "RECIBO DE ARRENDAMIENTO"
                varfinalest = ESTATUS_ARRENDAMIENTO
            Case "RECIBO DE HONORARIOS"
                varfinalest = ESTATUS_HONORARIOS
            Case "NOTA DE CREDITO"
                varfinalest = ESTATUS_NOTASCREDITO
        End Select

        Dim cnn As New MySqlClient.MySqlConnection(sTarget)
        Dim dr As DataRow
        Dim sQuery As String
        Dim Er As String = ""
        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, "") = True Then
            sQuery = "Select Max(nom_id) as iden  From facturas Where estatus_fac=" & varfinalest & " and id_evento= " & var_folio
            If odata.getDr(cnn, dr, sQuery, Er) = True Then
                var_idfactura = Val(dr("iden").ToString)
            Else
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub actualiza_detalle()
        Dim cnn As New MySqlClient.MySqlConnection(sTarget)
#Disable Warning BC42024 ' Variable local sin usar: 'dRow'.
        Dim dRow As DataRow
#Enable Warning BC42024 ' Variable local sin usar: 'dRow'.
        Dim sQuery As String
        Dim Er As String = ""
        Dim client As Integer = 0
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            client = dame_IdClienteRS(Cmb_RazonS.Text)
        End If
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, "") = True Then
            sQuery = "Update detalle_factura set factura= " & var_idfactura & " where cliente=" & client & " and factura=0 and ip_loc = '" & numero_MAC & "'"
            If odata.runSp(cnn, sQuery, Er) = True Then
                'var_idfactura = Val(dRow("iden").ToString)
            Else
            End If
            cnn.Close()
        End If
    End Sub

    Private Sub bprefac()
        Dim cnn As New MySqlClient.MySqlConnection(sTarget)
        Dim dRow As DataRow
        Dim sQuery As String
        Dim Er As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, "") = True Then
            sQuery = "Select Max(nom_id) as iden  From Facturas "
#Disable Warning BC42030 ' La variable 'dRow' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.getDr(cnn, dRow, sQuery, Er) = True Then
#Enable Warning BC42030 ' La variable 'dRow' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                var_idfactura = Val(dRow("iden").ToString)
            Else
            End If
            cnn.Close()
        End If
    End Sub

    Private Function valida_datos()

        If Cmb_RazonS.Text = "" Then
            MsgBox("Seleccione un Cliente")
            Cmb_RazonS.Focus()
            Return False
        End If

        If Cmb_RFC.Text = "" Then
            MsgBox("Seleccione un RFC")
            Cmb_RFC.Focus()
            Return False
        End If

        If Cmb_RFC.Text = "XAXX010101000" Or Cmb_RFC.Text = "XEXX010101000" Then
        Else
            If Text_CP.Text = "" Then
                MsgBox("Debe Escribir el Codigo Postal del Receptor")
                Text_CP.Focus()
                Return False
            End If

            If cbo_regimen.Text = "" Then
                MsgBox("Debe seleccionar el régimen fiscal del Receptor")
                cbo_regimen.Focus()
                Return False
            End If

            Dim cnn As New MySqlClient.MySqlConnection
            Dim dr As DataRow
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            With odata
                If odata.dbOpen(cnn, sTarget, "") = True Then
                    If odata.getDr(cnn, dr, "select ClaveRegFis from RegimenFiscalSat where Descripcion = '" & cbo_regimen.Text & "'", sinfo) Then
                    Else
                        MsgBox("El Régimen Fiscal del receptor no es valido, seleccionar otro del combo")
                        cbo_regimen.Focus()
                        Return False
                    End If
                    cnn.Close()
                End If
            End With
        End If
        If Text_FormaPago.Text = "" Then
            MsgBox("Debe Escribir la Forma de Pago")
            Text_FormaPago.Focus()
            Return False
        End If
        If checat(cbo_rfc_emisor.Text) Then
        Else
            Return False
        End If
        Return True
    End Function

    Private Sub bfoliofac()
        ProgressBar1.Value = 10
        lbl_proceso.Text = "Obteniendo Folio ..."
        My.Application.DoEvents()
        var_folio = 0
        Dim cnn As New MySqlClient.MySqlConnection(sTarget)
        Dim dRow As DataRow
        Dim sQuery As String
        Dim Er As String = ""

        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, Er) = True Then
            Select Case Cmb_TipoFact.Text
                Case "FACTURA"
                    sQuery = "Select Max(nom_folio) as folio  From facturas Where estatus_fac= " & ESTATUS_FACTURA & " and id_emisor=" & cbo_rfc_emisor.SelectedValue
                Case "PREFACTURA"
                    sQuery = "Select Max(nom_folio) as folio  From facturas Where estatus_fac= " & ESTATUS_PREFACTURA & " and id_emisor=" & cbo_rfc_emisor.SelectedValue
                Case "RECIBO DE ARRENDAMIENTO"
                    sQuery = "Select Max(nom_folio) as folio  From facturas Where estatus_fac= " & ESTATUS_ARRENDAMIENTO & " and id_emisor=" & cbo_rfc_emisor.SelectedValue
                Case "RECIBO DE HONORARIOS"
                    sQuery = "Select Max(nom_folio) as folio  From facturas Where estatus_fac= " & ESTATUS_HONORARIOS & " and id_emisor=" & cbo_rfc_emisor.SelectedValue
                Case "NOTA DE CREDITO"
                    sQuery = "Select Max(nom_folio) as folio  From facturas Where estatus_fac= " & ESTATUS_NOTASCREDITO & " and id_emisor=" & cbo_rfc_emisor.SelectedValue

            End Select

#Disable Warning BC42104 ' La variable 'sQuery' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
#Disable Warning BC42030 ' La variable 'dRow' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.getDr(cnn, dRow, sQuery, Er) = True Then
#Enable Warning BC42030 ' La variable 'dRow' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
#Enable Warning BC42104 ' La variable 'sQuery' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.

                var_folio = Val(dRow("folio").ToString)
            Else
            End If
            cnn.Close()
        End If
        var_folio = var_folio + 1
    End Sub

    Public Sub printRecibo()
        Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString

        If CheckBox2.Checked = True Then
            'Dim uuidrel As String = ""
            'If cboTipoRelacion.Text <> "" Then
            '    For i = 0 To dgUUID.RowCount - 2
            '        uuidrel = uuidrel & dgUUID.Rows(i).Cells(1).Value.ToString & ", "
            '    Next
            '    uuidrel = Mid(Trim(uuidrel), 1, Len(Trim(uuidrel)) - 1)
            'End If

            'Dim FileOpen As New ProcessStartInfo
            'crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\")
            'Dim root_name_recibo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"
            'If varrutabase <> "" Then
            '    crea_ruta("\\" & varrutabase & "\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\")
            '    root_name_recibo = "\\" & varrutabase & "\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"
            'End If

            'cadena_pagos1 = ""
            'metodo_p_ac = cbometodo_pago.SelectedValue

            'Select Case metodo_p_ac
            '    Case "01"
            '        cadena_pagos1 &= "01 Efectivo."
            '    Case "02"
            '        cadena_pagos1 &= "02 Cheque nominativo."
            '    Case "03"
            '        cadena_pagos1 &= "03 Transferencia electronica de fondos."
            '    Case "04"
            '        cadena_pagos1 &= "04 Tarjetas de crédito."
            '    Case "05"
            '        cadena_pagos1 &= "05 Monedero electrónico."
            '    Case "06"
            '        cadena_pagos1 &= "06 Dinero electrónico"
            '    Case "08"
            '        cadena_pagos1 &= "08 Vales de despensa"
            '    Case "12"
            '        cadena_pagos1 &= "12 Dación en pago"
            '    Case "13"
            '        cadena_pagos1 &= "13 Pago por subrogación"
            '    Case "14"
            '        cadena_pagos1 &= "14 Pago por consignación"
            '    Case "15"
            '        cadena_pagos1 &= "15 Condonación"
            '    Case "17"
            '        cadena_pagos1 &= "17 Compensación"
            '    Case "23"
            '        cadena_pagos1 &= "23 Novación"
            '    Case "24"
            '        cadena_pagos1 &= "24 Confusión"
            '    Case "25"
            '        cadena_pagos1 &= "25 Remisión de deuda"
            '    Case "26"
            '        cadena_pagos1 &= "26 Prescripción o caducidad"
            '    Case "27"
            '        cadena_pagos1 &= "27 A satisfacción del acreedor"
            '    Case "28"
            '        cadena_pagos1 &= "28 Tarjeta de Debito"
            '    Case "29"
            '        cadena_pagos1 &= "29 Tarjeta de Servicio"
            '    Case "30"
            '        cadena_pagos1 &= "30 Aplicación de anticipos"
            '    Case "99"
            '        cadena_pagos1 &= "99 Por definir"
            '    Case Else
            'End Select
            'Exit Sub
        Else

            crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\")

            Dim root_name_recibo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"

            If File.Exists(root_name_recibo) Then
                File.Delete(root_name_recibo)
            End If

            Dim varcalleemi As String = ""
            Dim varcoloniaemi As String = ""
            Dim varaclmunemi As String = ""
            Dim varentidadaemi As String = ""

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim varcalleemiS As String = ""
            Dim varcoloniaemiS As String = ""
            Dim varaclmunemiS As String = ""
            Dim varentidadaemiS As String = ""
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim varregimenemi As String = ""
            Dim varcallecli As String = ""
            Dim varcoloniacli As String = ""
            Dim varaclmuncli As String = ""
            Dim varentidadacli As String = ""
            Dim varregimencli As String = ""
            Dim varserie As String = ""
            Dim varfolio As String = ""
            Dim varfechaemision As String = ""
            Dim varfechacertifi As String = ""
            Dim varcertifsat As String = ""
            Dim varcertifemi As String = ""
            Dim vartipocomprobante As String = ""
            Dim varuuid As String = ""
            Dim varusocfdi As String = ""
            Dim vartiporelacion As String = ""
            Dim varnomid As Integer = 0
            Dim varmetodopago As String = ""
            Dim varcondiciones As String = ""
            Dim varnumerocta As String = ""
            Dim varformapago As String = ""
            Dim varnumletra As String = convLetras(CDbl(Text_TOTAL.Text))
            Dim varleyenda As String = ""
            Dim varsellocfdi As String = ""
            Dim varsellosat As String = ""
            Dim varcadenaoriginal As String = ""
            Dim varnombrecomercial_cliente As String = ""

            Dim banderaieps As Integer = 0
            Dim ieps160 As Decimal = 0 : Dim ieps53 As Decimal = 0 : Dim ieps5 As Decimal = 0
            Dim ieps304 As Decimal = 0 : Dim ieps3 As Decimal = 0 : Dim ieps265 As Decimal = 0
            Dim ieps25 As Decimal = 0 : Dim ieps09 As Decimal = 0 : Dim ieps08 As Decimal = 0
            Dim ieps07 As Decimal = 0 : Dim ieps06 As Decimal = 0 : Dim ieps03 As Decimal = 0

            Dim cuantosieps(20) As String
            For xd = 0 To 19
                cuantosieps(xd) = ""
            Next

            Dim cnn As New MySqlClient.MySqlConnection
            Dim sSql As String = "select RFS.ClaveRegFis, RFS.Descripcion from DatosNegocio DN, RegimenFiscalSat RFS where RFS.ClaveRegFis = DN.Em_RFiscal and DN.Em_RazonSocial='" & Trim(cbo_emisor.Text) & "'"
            Dim dr As DataRow
            Dim dt As New DataTable
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, sSql, sinfo) Then
                        varregimenemi = dr("ClaveRegFis").ToString() & " " & dr("Descripcion").ToString()
                    Else
                        varregimenemi = ""
                    End If
                    cnn.Close()
                End If
            End With

            If cbo_regimen.Text <> "" Then
                varregimencli = cbo_regimen.SelectedValue.ToString & " " & cbo_regimen.Text
            End If

            If IsNumeric(var_idfactura) Then
                If Cmb_Nfactura.Text = "" And var_idfactura > 0 Then

                    dt = New DataTable
                    sinfo = ""
                    With odata
                        If .dbOpen(cnn, sTarget, sinfo) Then
                            If .getDr(cnn, dr, "select nom_folio from facturas where nom_id = " & var_idfactura, sinfo) Then
                                Cmb_Nfactura.Text = dr("nom_folio").ToString()
                                lblfolioventa.Text = dr("nom_folio").ToString()
                            End If
                            cnn.Close()
                        End If
                    End With
                End If
            End If

            dt = New DataTable
            odata = New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "select nom_id,nom_fecha_factura,nom_fecha_folio_sat,nom_no_csd_sat,nom_no_csd_emp,estatus_fac,nom_folio_sat_uuid,UsoCFDI,nom_tipo_pago,nom_cpago,nom_numcuenta,nom_leyenda,nom_sello_emisor,nom_sello_sat,nom_cadena_original,nom_metodo_pago,nom_comercial_cli from Facturas where nom_folio = " & Cmb_Nfactura.Text & " and estatus_fac = " & IIf(Cmb_TipoFact.Text = "FACTURA", ESTATUS_FACTURA, IIf(Cmb_TipoFact.Text = "NOTA DE CREDITO", ESTATUS_NOTASCREDITO, ESTATUS_PREFACTURA)), sinfo) Then
                        varnomid = dr("nom_id").ToString()
                        varfolio = Cmb_Nfactura.Text
                        varfechaemision = dr("nom_fecha_factura").ToString()
                        varfechacertifi = dr("nom_fecha_folio_sat").ToString()
                        varcertifsat = dr("nom_no_csd_sat").ToString()
                        varcertifemi = dr("nom_no_csd_emp").ToString()
                        varuuid = dr("nom_folio_sat_uuid").ToString()
                        vartipocomprobante = dr("estatus_fac").ToString()
                        varusocfdi = dr("UsoCFDI").ToString()
                        If vartipocomprobante <> "6" Then
                            vartipocomprobante = "I Ingreso"
                        Else
                            vartipocomprobante = "E Egreso"
                        End If
                        If dr("nom_tipo_pago").ToString = "PUE" Then
                            varmetodopago = dr("nom_tipo_pago").ToString() & " Pago en una sola exhibición"
                        Else
                            varmetodopago = dr("nom_tipo_pago").ToString() & " Pago en parcialidades o diferido"
                        End If
                        varcondiciones = dr("nom_cpago").ToString()
                        varnumerocta = dr("nom_numcuenta").ToString()
                        varformapago = dr("nom_metodo_pago").ToString()
                        varleyenda = dr("nom_leyenda").ToString()
                        varsellosat = dr("nom_sello_sat").ToString()
                        varsellocfdi = dr("nom_sello_emisor").ToString()
                        varcadenaoriginal = dr("nom_cadena_original").ToString()
                        varnombrecomercial_cliente = dr("nom_comercial_cli").ToString()
                    End If
                    cnn.Close()
                End If
            End With

            Dim sinfo2 As String = ""
            Dim dt2 As New DataTable
            Dim dr2 As DataRow
            Dim odata2 As New ToolKitSQL.myssql
            With odata2
                If .dbOpen(cnn, sTarget, sinfo2) Then
                    If .getDr(cnn, dr2, "select nom_mdescuento from Facturas where nom_id = " & varnomid, sinfo2) Then
                        If CDec(dr2(0).ToString()) > 0 Then
                            banderaieps = 1
                        Else
                            banderaieps = 0
                        End If
                    Else
                        banderaieps = 0
                    End If
                    cnn.Close()
                End If
            End With

            sinfo2 = ""
            dt2 = New DataTable
            odata2 = New ToolKitSQL.myssql
            Dim isrporc As String = "0"
            With odata2
                If .dbOpen(cnn, sTarget, sinfo2) Then
                    If .getDt(cnn, dt2, "select isr from detalle_factura where factura = " & varnomid, sinfo2) Then
                        For Each dr2 In dt2.Rows
                            If dr2("isr").ToString() > 0 Then
                                isrporc = CDec(dr2("isr").ToString()) * 100
                                Exit For
                            End If
                        Next
                    End If
                    cnn.Close()
                End If
            End With

            sinfo2 = ""
            dt2 = New DataTable
            odata2 = New ToolKitSQL.myssql
            Dim ivaretporc As String = "0"
            With odata2
                If .dbOpen(cnn, sTarget, sinfo2) Then
                    If .getDt(cnn, dt2, "select ret_iva_perc from detalle_factura where factura = " & varnomid, sinfo2) Then
                        For Each dr2 In dt2.Rows
                            If dr2("ret_iva_perc").ToString > 0 Then
                                ivaretporc = CDec(dr2("ret_iva_perc").ToString()) * 100
                                Exit For
                            End If
                        Next
                    End If
                    cnn.Close()
                End If
            End With

            If banderaieps <> 0 Then
                cnn = New MySqlClient.MySqlConnection
                sinfo2 = ""
                dt2 = New DataTable
                odata2 = New ToolKitSQL.myssql
                With odata2
                    If .dbOpen(cnn, sTarget, sinfo2) Then
                        If .getDt(cnn, dt2, "select distinct ieps_porcentaje from detalle_factura where factura = " & varnomid, sinfo2) Then
                            Dim i As Integer = 0
                            For Each dr2 In dt2.Rows
                                cuantosieps(i) = dr2(0).ToString()
                                i = i + 1
                            Next
                        End If

                        For xd = 0 To 19
                            If cuantosieps(xd) <> "" Then
                                dt2 = New DataTable
                                If .getDt(cnn, dt2, "select ieps from detalle_factura where factura = " & varnomid & " and  ieps_porcentaje = '" & cuantosieps(xd) & "'", sinfo2) Then
                                End If

                                Select Case cuantosieps(xd)
                                    Case "0.030000"
                                        For Each dr2 In dt2.Rows
                                            ieps03 = ieps03 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.060000"
                                        For Each dr2 In dt2.Rows
                                            ieps06 = ieps06 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.070000"
                                        For Each dr2 In dt2.Rows
                                            ieps07 = ieps07 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.080000"
                                        For Each dr2 In dt2.Rows
                                            ieps08 = ieps08 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.090000"
                                        For Each dr2 In dt2.Rows
                                            ieps09 = ieps09 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.250000"
                                        For Each dr2 In dt2.Rows
                                            ieps25 = ieps25 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.265000"
                                        For Each dr2 In dt2.Rows
                                            ieps265 = ieps265 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.300000"
                                        For Each dr2 In dt2.Rows
                                            ieps3 = ieps3 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.304000"
                                        For Each dr2 In dt2.Rows
                                            ieps304 = ieps304 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.500000"
                                        For Each dr2 In dt2.Rows
                                            ieps5 = ieps5 + CDec(dr2(0).ToString())
                                        Next
                                    Case "0.530000"
                                        For Each dr2 In dt2.Rows
                                            ieps53 = ieps53 + CDec(dr2(0).ToString())
                                        Next
                                    Case "1.600000"
                                        For Each dr2 In dt2.Rows
                                            ieps160 = ieps160 + CDec(dr2(0).ToString())
                                        Next
                                End Select
                            End If
                        Next
                        cnn.Close()
                    End If
                End With
            End If

            Select Case varformapago
                Case "01"
                    varformapago = "01 Efectivo."
                Case "02"
                    varformapago = "02 Cheque nominativo."
                Case "03"
                    varformapago = "03 Transferencia electronica de fondos."
                Case "04"
                    varformapago = "04 Tarjetas de crédito."
                Case "05"
                    varformapago = "05 Monedero electrónico."
                Case "06"
                    varformapago = "06 Dinero electrónico"
                Case "08"
                    varformapago = "08 Vales de despensa"
                Case "12"
                    varformapago = "12 Dación en pago"
                Case "13"
                    varformapago = "13 Pago por subrogación"
                Case "14"
                    varformapago = "14 Pago por consignación"
                Case "15"
                    varformapago = "15 Condonación"
                Case "17"
                    varformapago = "17 Compensación"
                Case "23"
                    varformapago = "23 Novación"
                Case "24"
                    varformapago = "24 Confusión"
                Case "25"
                    varformapago = "25 Remisión de deuda"
                Case "26"
                    varformapago = "26 Prescripción o caducidad"
                Case "27"
                    varformapago = "27 A satisfacción del acreedor"
                Case "28"
                    varformapago = "28 Tarjeta de Debito"
                Case "29"
                    varformapago = "29 Tarjeta de Servicio"
                Case "30"
                    varformapago = "30 Aplicación de anticipos"
                Case "99"
                    varformapago = "99 Por definir"
            End Select

            dt = New DataTable
            odata = New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "select * from UsoComproCFDISat where ClaveUsoCFDI = '" & varusocfdi & "'", sinfo) Then
                        varusocfdi = dr("ClaveUsoCFDI").ToString() & " " & dr("Descripcion").ToString()
                    End If
                    cnn.Close()
                End If
            End With

            If CStr(cboTipoRelacion.Text) <> "" And CDec(dgUUID.RowCount) > 0 Then
                Dim varSTR As String = ""
                For i = 0 To dgUUID.RowCount - 1
                    varSTR = varSTR & dgUUID.Rows(i).Cells(1).Value.ToString() & " , "
                Next
                vartiporelacion = cboTipoRelacion.Text & " UUID: " & Mid(varSTR, 1, CInt(Len(Trim(varSTR)) - 1))
            Else
                vartiporelacion = ""
            End If

            If IsNumeric(varfolio) = False Then
                MsgBox("Debe seleccionar un folio")
                Exit Sub
            End If


            Dim pdfDoc As New Document(PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
            Dim pdfWrite As PdfWriter

            pdfWrite = PdfWriter.GetInstance(pdfDoc, New FileStream(root_name_recibo, FileMode.CreateNew))

            Dim piepagina As New preubavb
            pdfWrite.PageEvent = piepagina

            Dim Font8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
            Dim FontB8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
            Dim FontB12 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD))
            Dim CVacio As PdfPCell = New PdfPCell(New Phrase(""))
            CVacio.Border = 0

            Dim pdfsucursal As Integer = 0
            dt = New DataTable
            odata = New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "Select NumPart from Formatos where Facturas = 'Actu_Code'", sinfo) Then
                        If CDec(dr(0).ToString) = 1 Then
                            pdfsucursal = 1
                        Else
                            pdfsucursal = 0
                        End If
                    End If
                    cnn.Close()
                End If
            End With

            pdfDoc.Open()

            If Trim(txt_serie.Text) <> "" Then
                varserie = Trim(txt_serie.Text)
            End If

            If pdfsucursal = 1 Then
                dt = New DataTable
                odata = New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, "Select * from DatosNegocio where Em_Expedir = 'EXPEDIR'", sinfo) Then
                            If Trim(dr("Em_calle").ToString()) <> "" Then
                                varcalleemiS = "Calle: " & Trim(dr("Em_calle").ToString())
                            End If
                            If Trim(dr("Em_NumExterior").ToString()) <> "" Then
                                varcalleemiS = varcalleemiS & " Num. Ext.: " & Trim(dr("Em_NumExterior").ToString())
                            End If
                            If Trim(dr("Em_NumInterior").ToString()) <> "" Then
                                varcalleemiS = varcalleemiS & " Num. Int.: " & Trim(dr("Em_NumInterior").ToString())
                            End If
                            If Trim(dr("Em_colonia").ToString()) <> "" Then
                                varcoloniaemiS = "Colonia: " & Trim(dr("Em_colonia").ToString())
                            End If
                            If Trim(dr("Em_Municipio").ToString()) <> "" Then
                                varaclmunemiS = "Alc./Mun.: " & Trim(dr("Em_Municipio").ToString())
                            End If
                            If Trim(dr("Em_CP").ToString()) <> "" Then
                                varaclmunemiS = varaclmunemiS & " C.P.: " & Trim(dr("Em_CP").ToString())
                            End If
                            If Trim(dr("Em_Estado").ToString()) <> "" Then
                                varentidadaemiS = "Entidad Federativa: " & Trim(dr("Em_Estado").ToString())
                            End If
                        End If
                        cnn.Close()
                    End If
                End With

                dt = New DataTable
                odata = New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, "Select * from DatosNegocio where Em_Expedir = 'FISCAL'", sinfo) Then
                            If Trim(dr("Em_calle").ToString()) <> "" Then
                                varcalleemi = "Calle: " & Trim(dr("Em_calle").ToString())
                            End If
                            If Trim(dr("Em_NumExterior").ToString()) <> "" Then
                                varcalleemi = varcalleemi & " Num. Ext.: " & Trim(dr("Em_NumExterior").ToString())
                            End If
                            If Trim(dr("Em_NumInterior").ToString()) <> "" Then
                                varcalleemi = varcalleemi & " Num. Int.: " & Trim(dr("Em_NumInterior").ToString())
                            End If
                            If Trim(dr("Em_colonia").ToString()) <> "" Then
                                varcoloniaemi = "Colonia: " & Trim(dr("Em_colonia").ToString())
                            End If
                            If Trim(dr("Em_Municipio").ToString()) <> "" Then
                                varaclmunemi = "Alc./Mun.: " & Trim(dr("Em_Municipio").ToString())
                            End If
                            If Trim(dr("Em_CP").ToString()) <> "" Then
                                varaclmunemi = varaclmunemi & " C.P.: " & Trim(dr("Em_CP").ToString())
                            End If
                            If Trim(dr("Em_Estado").ToString()) <> "" Then
                                varentidadaemi = "Entidad Federativa: " & Trim(dr("Em_Estado").ToString())
                            End If
                        Else
                            If .getDr(cnn, dr, "Select * from DatosNegocio where Em_Expedir = 'SUCURSAL'", sinfo) Then
                                If Trim(dr("Em_calle").ToString()) <> "" Then
                                    varcalleemi = "Calle: " & Trim(dr("Em_calle").ToString())
                                End If
                                If Trim(dr("Em_NumExterior").ToString()) <> "" Then
                                    varcalleemi = varcalleemi & " Num. Ext.: " & Trim(dr("Em_NumExterior").ToString())
                                End If
                                If Trim(dr("Em_NumInterior").ToString()) <> "" Then
                                    varcalleemi = varcalleemi & " Num. Int.: " & Trim(dr("Em_NumInterior").ToString())
                                End If
                                If Trim(dr("Em_colonia").ToString()) <> "" Then
                                    varcoloniaemi = "Colonia: " & Trim(dr("Em_colonia").ToString())
                                End If
                                If Trim(dr("Em_Municipio").ToString()) <> "" Then
                                    varaclmunemi = "Alc./Mun.: " & Trim(dr("Em_Municipio").ToString())
                                End If
                                If Trim(dr("Em_CP").ToString()) <> "" Then
                                    varaclmunemi = varaclmunemi & " C.P.: " & Trim(dr("Em_CP").ToString())
                                End If
                                If Trim(dr("Em_Estado").ToString()) <> "" Then
                                    varentidadaemi = "Entidad Federativa: " & Trim(dr("Em_Estado").ToString())
                                End If
                            End If
                        End If
                        cnn.Close()
                    End If
                End With

            Else
                If Trim(txtLEcalle.Text) <> "" Then
                    varcalleemi = "Calle: " & Trim(txtLEcalle.Text)
                End If
                If Trim(txtLEnumext.Text) <> "" Then
                    varcalleemi = varcalleemi & " Num. Ext.: " & Trim(txtLEnumext.Text)
                End If
                If Trim(txtLEnumint.Text) <> "" Then
                    varcalleemi = varcalleemi & " Num. Int.: " & Trim(txtLEnumint.Text)
                End If
                If Trim(txtLEcolonia.Text) <> "" Then
                    varcoloniaemi = "Colonia: " & Trim(txtLEcolonia.Text)
                End If
                If Trim(txtLEalcmun.Text) <> "" Then
                    varaclmunemi = "Alc./Mun.: " & Trim(txtLEalcmun.Text)
                End If
                If Trim(txtLEcodpos.Text) <> "" Then
                    varaclmunemi = varaclmunemi & " C.P.: " & Trim(txtLEcodpos.Text)
                End If
                If Trim(txtLEedo.Text) <> "" Then
                    varentidadaemi = "Entidad Federativa: " & Trim(txtLEedo.Text)
                End If
            End If

            If Trim(Text_calle.Text) <> "" Then
                varcallecli = "Calle: " & Trim(Text_calle.Text)
            End If
            If Trim(Text_Num_Ex.Text) <> "" Then
                varcallecli = varcallecli & " Num. Ext.: " & Trim(Text_Num_Ex.Text)
            End If
            If Trim(Txt_num_int.Text) <> "" Then
                varcallecli = varcallecli & " Num. Int.: " & Trim(Txt_num_int.Text)
            End If
            If Trim(Text_Colonia.Text) <> "" Then
                varcoloniacli = "Colonia: " & Trim(Text_Colonia.Text)
            End If
            If Trim(Text_Delegacion.Text) <> "" Then
                varaclmuncli = "Alc./Mun.: " & Trim(Text_Delegacion.Text)
            End If
            If Trim(Text_CP.Text) <> "" Then
                varaclmuncli = varaclmuncli & " C.P.: " & Trim(Text_CP.Text)
            End If
            If Trim(Text_Edo.Text) <> "" Then
                varentidadacli = "Entidad Federativa: " & Trim(Text_Edo.Text)
            End If

            Dim varYlinea As Integer = 810
            Dim Table1 As PdfPTable = New PdfPTable(5)
            Dim Col1 As PdfPCell
            Dim Col2 As PdfPCell
            Dim Col3 As PdfPCell
            Dim Col4 As PdfPCell
            Dim Col5 As PdfPCell
            Dim Col6 As PdfPCell
            Dim Col7 As PdfPCell
            Dim ILine As Integer
            Dim iFila As Integer
            Table1.WidthPercentage = 95

            Dim widths As Single() = New Single() {4.0F, 1.0F, 1.0F, 5.0F, 0.5F}
            If pdfsucursal = 1 Then
                widths = New Single() {6.0F, 1.0F, 6.0F, 5.0F, 0.5F}
            Else
                widths = New Single() {12.0F, 1.0F, 1.0F, 5.0F, 0.5F}
            End If

            Table1.SetWidths(widths)

#Region "Encabezado"

            Dim var666 As String = My.Application.Info.DirectoryPath & "\LogoFac.jpg"

            'PictureBox1.Image = Drawing.Image.FromFile(Convert.ToString(var666))

            Try
                Dim imagenURL As String = Convert.ToString(var666)
                Dim imagenBMP As iTextSharp.text.Image
                imagenBMP = iTextSharp.text.Image.GetInstance(imagenURL)
                imagenBMP.ScaleToFit(150.0F, 90.0F)
                imagenBMP.SpacingBefore = 20.0F
                imagenBMP.SpacingAfter = 10.0F
                imagenBMP.SetAbsolutePosition(410, 754)
                pdfDoc.Add(imagenBMP)
            Catch ex As Exception
            End Try

            Col1 = New PdfPCell(New Phrase(cbo_emisor.Text, FontB8))
            Col1.Border = 0
            Col1.Colspan = 4
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)

            If Len(cbo_emisor.Text) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(cbo_emisor.Text), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase(cbo_rfc_emisor.Text, FontB8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            If pdfsucursal = 1 Then
                Col3 = New PdfPCell(New Phrase("Sucursal", FontB8))
                Col3.Border = 0
                Table1.AddCell(Col3)
            Else
                Table1.AddCell(CVacio)
            End If
            Table1.AddCell(CVacio)
            Table1.AddCell(CVacio)

            If Len(cbo_rfc_emisor.Text) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(cbo_rfc_emisor.Text), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase(varcalleemi, Font8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            If pdfsucursal = 1 Then
                Col3 = New PdfPCell(New Phrase(varcalleemiS, Font8))
                Col3.Border = 0
                Table1.AddCell(Col3)
            Else
                Table1.AddCell(CVacio)
            End If
            Table1.AddCell(CVacio)
            Table1.AddCell(CVacio)

            If Len(varcalleemi) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(varcalleemi), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase(varcoloniaemi, Font8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            If pdfsucursal = 1 Then
                Col3 = New PdfPCell(New Phrase(varcoloniaemiS, Font8))
                Col3.Border = 0
                Table1.AddCell(Col3)
            Else
                Table1.AddCell(CVacio)
            End If
            Table1.AddCell(CVacio)
            Table1.AddCell(CVacio)

            If Len(varcoloniaemi) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(varcoloniaemi), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase(varaclmunemi, Font8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            If pdfsucursal = 1 Then
                Col3 = New PdfPCell(New Phrase(varaclmunemiS, Font8))
                Col3.Border = 0
                Table1.AddCell(Col3)
            Else
                Table1.AddCell(CVacio)
            End If
            Table1.AddCell(CVacio)
            Table1.AddCell(CVacio)

            If Len(varaclmunemi) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(varaclmunemi), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase(varentidadaemi, Font8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            If pdfsucursal = 1 Then
                Col3 = New PdfPCell(New Phrase(varentidadaemiS, Font8))
                Col3.Border = 0
                Table1.AddCell(Col3)
            Else
                Table1.AddCell(CVacio)
            End If
            Col4 = New PdfPCell(New Phrase(Cmb_TipoFact.Text, FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 2
            Table1.AddCell(Col4)
            '        Table1.AddCell(CVacio)

            If Len(varentidadaemi) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(varentidadaemi), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase("Lugar de Expedición: " & Trim(txtLEcodpos.Text), Font8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            Table1.AddCell(CVacio)
            Col4 = New PdfPCell(New Phrase("Serie y folio: " & varserie & " - " & varfolio, FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 2
            Table1.AddCell(Col4)
            'Table1.AddCell(CVacio)

            If Len("Lugar de Expedición: " & Trim(txtLEcodpos.Text)) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len("Lugar de Expedición: " & Trim(txtLEcodpos.Text)), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase("Régimen Fiscal Emisor: " & Trim(varregimenemi), Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table1.AddCell(Col1)
            Col4 = New PdfPCell(New Phrase("EXPORTACION: No aplica", FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 2
            Table1.AddCell(Col4)
            'Table1.AddCell(CVacio)

            If Len("Regimen Fiscal Emisor: " & Trim(varregimenemi)) > 71 Then
                varYlinea = varYlinea - 12 'damevalorlinea(Len("Regimen Fiscal Emisor: " & Trim(varregimenemi)))
            Else
                varYlinea = varYlinea - 12
            End If

            Col1 = New PdfPCell(New Phrase("Facturado A:", FontB8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            Table1.AddCell(CVacio)
            Col4 = New PdfPCell(New Phrase("Fecha de Emisión: " & varfechaemision, FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 3
            Table1.AddCell(Col4)
            'Table1.AddCell(CVacio)

            If Len("Fecha de Emisión: " & varfechaemision) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len("Fecha de Emisión: " & varfechaemision), 0)
            Else
                varYlinea = varYlinea - 12
            End If
            Col1 = New PdfPCell(New Phrase(Trim(Cmb_RazonS.Text), FontB8))

            'Col1 = New PdfPCell(New Phrase(Mid(Trim(Cmb_RazonS.Text), 0, Len(Trim(Cmb_RazonS.Text)) - 3)), FontB8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            'Table1.AddCell(CVacio)
            Col4 = New PdfPCell(New Phrase("Fecha de Certificación: " & varfechacertifi, FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 4
            Table1.AddCell(Col4)
            'Table1.AddCell(CVacio)

            If Trim(Cmb_RazonS.Text).ToLower = Trim(Cmb_RazonS.Text) Then
                If Len(Trim(Cmb_RazonS.Text)) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len(Trim(Cmb_RazonS.Text)), 0)
                Else
                    varYlinea = varYlinea - 12
                End If
            Else
                If Len(Trim(Cmb_RazonS.Text)) > 67 Then
                    varYlinea = varYlinea - damevalorlinea(Len(Trim(Cmb_RazonS.Text)), 1)
                Else
                    varYlinea = varYlinea - 12
                End If
            End If

            Col1 = New PdfPCell(New Phrase(Trim(Cmb_RFC.Text), FontB8))
            Col1.Border = 0
            Table1.AddCell(Col1)
            'Table1.AddCell(CVacio)
            Col4 = New PdfPCell(New Phrase("No. Serie Certif. Sat: " & varcertifsat, FontB8))
            Col4.Border = 0
            Col4.HorizontalAlignment = 2
            Col4.Colspan = 4
            Table1.AddCell(Col4)
            'Table1.AddCell(CVacio)

            If Len(Cmb_RFC.Text) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len(Cmb_RFC.Text), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            'hay que ver si existe el nombre comercial 
            If Trim(varnombrecomercial_cliente) <> "" Then

                If Trim(varnombrecomercial_cliente) <> Trim(Cmb_RazonS.Text) Then
                    Col1 = New PdfPCell(New Phrase(Trim(varnombrecomercial_cliente), FontB8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    'Table1.AddCell(CVacio)
                    Col4 = New PdfPCell(New Phrase("No. Serie Certif. Emi.: " & varcertifemi, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varnombrecomercial_cliente) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varnombrecomercial_cliente), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varcallecli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("Tipo de Comprobante: " & vartipocomprobante, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varcallecli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varcallecli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varcoloniacli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("UUID: " & varuuid, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varcoloniacli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varcoloniacli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varaclmuncli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("RFC Prov. Certif.: LSO1306189R5", FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varaclmuncli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varaclmuncli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varentidadacli), Font8))
                    Col1.Border = 0
                    Col1.Colspan = 5
                    Table1.AddCell(Col1)
                    'Table1.AddCell(CVacio)

                    varYlinea = varYlinea - 12

                Else

                    Col1 = New PdfPCell(New Phrase(Trim(varcallecli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("No. Serie Certif. Emi.: " & varcertifemi, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)

                    If Len(varcallecli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varcallecli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varcoloniacli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("Tipo de Comprobante: " & vartipocomprobante, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varcoloniacli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varcoloniacli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varaclmuncli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("UUID: " & varuuid, FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varaclmuncli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varaclmuncli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If

                    Col1 = New PdfPCell(New Phrase(Trim(varentidadacli), Font8))
                    Col1.Border = 0
                    Table1.AddCell(Col1)
                    Col4 = New PdfPCell(New Phrase("RFC Prov. Certif.: LSO1306189R5", FontB8))
                    Col4.Border = 0
                    Col4.HorizontalAlignment = 2
                    Col4.Colspan = 4
                    Table1.AddCell(Col4)
                    'Table1.AddCell(CVacio)

                    If Len(varentidadacli) > 71 Then
                        varYlinea = varYlinea - damevalorlinea(Len(varentidadacli), 0)
                    Else
                        varYlinea = varYlinea - 12
                    End If
                End If

            Else

                Col1 = New PdfPCell(New Phrase(Trim(varcallecli), Font8))
                Col1.Border = 0
                Table1.AddCell(Col1)
                'Table1.AddCell(CVacio)
                Col4 = New PdfPCell(New Phrase("No. Serie Certif. Emi.: " & varcertifemi, FontB8))
                Col4.Border = 0
                Col4.HorizontalAlignment = 2
                Col4.Colspan = 4
                Table1.AddCell(Col4)
                'Table1.AddCell(CVacio)

                If Len(varcallecli) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len(varcallecli), 0)
                Else
                    varYlinea = varYlinea - 12
                End If

                Col1 = New PdfPCell(New Phrase(Trim(varcoloniacli), Font8))
                Col1.Border = 0
                Table1.AddCell(Col1)
                Col4 = New PdfPCell(New Phrase("Tipo de Comprobante: " & vartipocomprobante, FontB8))
                Col4.Border = 0
                Col4.HorizontalAlignment = 2
                Col4.Colspan = 4
                Table1.AddCell(Col4)
                'Table1.AddCell(CVacio)

                If Len(varcoloniacli) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len(varcoloniacli), 0)
                Else
                    varYlinea = varYlinea - 12
                End If

                Col1 = New PdfPCell(New Phrase(Trim(varaclmuncli), Font8))
                Col1.Border = 0
                Table1.AddCell(Col1)
                Col4 = New PdfPCell(New Phrase("UUID: " & varuuid, FontB8))
                Col4.Border = 0
                Col4.HorizontalAlignment = 2
                Col4.Colspan = 4
                Table1.AddCell(Col4)
                'Table1.AddCell(CVacio)

                If Len(varaclmuncli) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len(varaclmuncli), 0)
                Else
                    varYlinea = varYlinea - 12
                End If

                Col1 = New PdfPCell(New Phrase(Trim(varentidadacli), Font8))
                Col1.Border = 0
                Table1.AddCell(Col1)
                Col4 = New PdfPCell(New Phrase("RFC Prov. Certif.: LSO1306189R5", FontB8))
                Col4.Border = 0
                Col4.HorizontalAlignment = 2
                Col4.Colspan = 4
                Table1.AddCell(Col4)
                'Table1.AddCell(CVacio)

                If Len(varentidadacli) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len(varentidadacli), 0)
                Else
                    varYlinea = varYlinea - 12
                End If

            End If

            Col1 = New PdfPCell(New Phrase("Régimen Fiscal Cliente: " & Trim(varregimencli), Font8))
            Col1.Border = 0
            Col1.Colspan = 5
            Table1.AddCell(Col1)
            'Table1.AddCell(CVacio)

            varYlinea = varYlinea - 12

            Col1 = New PdfPCell(New Phrase("Uso de CFDI: " & Trim(varusocfdi), Font8))
            Col1.Border = 0
            Col1.Colspan = 5
            Table1.AddCell(Col1)
            'Table1.AddCell(CVacio)

            If Len("Uso de CFDI: " & Trim(varusocfdi)) > 71 Then
                varYlinea = varYlinea - damevalorlinea(Len("Uso de CFDI: " & Trim(varusocfdi)), 0)
            Else
                varYlinea = varYlinea - 12
            End If

            If vartiporelacion <> "" Then
                Col1 = New PdfPCell(New Phrase("Tipo Relación: " & Trim(vartiporelacion), Font8))
                Col1.Border = 0
                Col1.Colspan = 5
                Table1.AddCell(Col1)
                'Table1.AddCell(CVacio)

                If Len("Tipo Relacion: " & Trim(varusocfdi)) > 71 Then
                    varYlinea = varYlinea - damevalorlinea(Len("Tipo Relacion: " & Trim(vartiporelacion)), 0)
                Else
                    varYlinea = varYlinea - 12
                End If
            End If

            Dim cnn_new As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo_new As String = ""
            Dim dt_new As New DataTable
            Dim dr_new As DataRow
            Dim odata_new As New ToolKitSQL.myssql
            Dim folioticketfact As Integer = 0
            Dim cadenanotasdeventa As String = ""

            With odata_new
                If .dbOpen(cnn_new, sTarget, sinfo_new) Then
                    If .getDr(cnn_new, dr_new, "select NumPart from Formatos where Facturas = 'Aute_Server_SMTP'", sinfo_new) Then
                        If IsNumeric(dr_new(0).ToString) Then
                            folioticketfact = dr_new(0).ToString()
                        End If
                    End If
                    If .getDt(cnn_new, dt_new, "select Folio from Ventas where Facturado = '" & Cmb_Nfactura.Text & "'", sinfo) Then
                        For Each dr_new In dt_new.Rows
                            cadenanotasdeventa = cadenanotasdeventa & dr_new(0).ToString() & ","
                        Next
                        cadenanotasdeventa = cadenanotasdeventa.TrimEnd(",")
                    End If
                    cnn_new.Close()
                End If
            End With

            If folioticketfact > 0 Then
                Col1 = New PdfPCell(New Phrase("Nota de Venta: " & Trim(cadenanotasdeventa), Font8))
                Col1.Border = 0
                Col1.Colspan = 5
                Table1.AddCell(Col1)
                varYlinea = varYlinea - 12
            End If

            pdfDoc.Add(Table1)
#End Region

#Region "Tabla 3 - Cabecera"

            Dim Table3 As PdfPTable = New PdfPTable(9)
            Dim widths3 As Single() = New Single() {2.0F, 3.0F, 2.0F, 3.0F, 8.0F, 3.0F, 3.0F, 3.0F, 1.0F}
            Table3.WidthPercentage = 95
            Table3.SetWidths(widths3)
            Table3.DefaultCell.BorderWidth = 2

            Col1 = New PdfPCell(New Phrase("PART.", FontB8))
            Col1.BorderWidthLeft = 0
            Col1.BorderWidthRight = 0
            Col1.BorderWidth = 1
            Table3.AddCell(Col1)
            Col2 = New PdfPCell(New Phrase("CLAVE SAT", FontB8))
            Col2.BorderWidthLeft = 0
            Col2.BorderWidthRight = 0
            Col2.BorderWidth = 1
            Table3.AddCell(Col2)
            Col3 = New PdfPCell(New Phrase("CANT.", FontB8))
            Col3.BorderWidthLeft = 0
            Col3.BorderWidthRight = 0
            Col3.BorderWidth = 1
            Table3.AddCell(Col3)
            Col4 = New PdfPCell(New Phrase("U. VENTA", FontB8))
            Col4.BorderWidthLeft = 0
            Col4.BorderWidthRight = 0
            Col4.BorderWidth = 1
            Table3.AddCell(Col4)
            Col5 = New PdfPCell(New Phrase("CONCEPTO", FontB8))
            Col5.BorderWidthLeft = 0
            Col5.BorderWidthRight = 0
            Col5.BorderWidth = 1
            Table3.AddCell(Col5)
            Col6 = New PdfPCell(New Phrase("P.UNITARIO", FontB8))
            Col6.BorderWidthLeft = 0
            Col6.BorderWidthRight = 0
            Col6.BorderWidth = 1
            Col6.HorizontalAlignment = 2
            Table3.AddCell(Col6)
            Col7 = New PdfPCell(New Phrase("IMPORTE", FontB8))
            Col7.BorderWidthLeft = 0
            Col7.BorderWidthRight = 0
            Col7.BorderWidth = 1
            Col7.HorizontalAlignment = 2
            Table3.AddCell(Col7)
            Col7 = New PdfPCell(New Phrase("DESC.", FontB8))
            Col7.BorderWidthLeft = 0
            Col7.BorderWidthRight = 0
            Col7.BorderWidth = 1
            Col7.HorizontalAlignment = 2
            Table3.AddCell(Col7)
            Col7 = New PdfPCell(New Phrase("", FontB8))
            Col7.BorderWidthLeft = 0
            Col7.BorderWidthRight = 0
            Col7.BorderWidth = 1
            Table3.AddCell(Col7)

            pdfDoc.Add(Table3)

#End Region

            varYlinea = varYlinea - 12

#Region "Tabla 4 - Detalle"

            dt = New DataTable
            odata = New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from detalle_factura where factura = " & varnomid, sinfo) Then
                        Dim i As Integer = 0
                        For Each dr In dt.Rows

                            Dim Table4 As PdfPTable = New PdfPTable(9)
                            Dim widths4 As Single() = New Single() {2.0F, 3.0F, 2.0F, 3.0F, 8.0F, 3.0F, 3.0F, 3.0F, 1.0F}
                            Table4.WidthPercentage = 95
                            Table4.SetWidths(widths4)

                            i += 1
                            Col1 = New PdfPCell(New Phrase(i, Font8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(dr("clvsat").ToString, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Col3 = New PdfPCell(New Phrase(dr("cantidad").ToString, Font8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(dr("unidad").ToString, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)
                            Col5 = New PdfPCell(New Phrase(dr("descripcion").ToString, Font8))
                            Col5.Border = 0
                            Table4.AddCell(Col5)
                            Col6 = New PdfPCell(New Phrase(dr("preciou").ToString, Font8))
                            Col6.Border = 0
                            Col6.HorizontalAlignment = 2
                            Table4.AddCell(Col6)
                            Col7 = New PdfPCell(New Phrase(CDec(dr("cantidad").ToString) * CDec(dr("preciou").ToString), Font8))
                            Col7.Border = 0
                            Col7.HorizontalAlignment = 2
                            Table4.AddCell(Col7)
                            Col7 = New PdfPCell(New Phrase(dr("descuento").ToString, Font8))
                            Col7.Border = 0
                            Col7.HorizontalAlignment = 2
                            Table4.AddCell(Col7)
                            Table4.AddCell(CVacio)

                            TextBox2.Text = ""
                            TextBox2.Text = dr("descripcion_larga").ToString

                            Dim counter As Integer
                            Dim tempArray() As String
                            tempArray = TextBox2.Lines

                            If Trim(TextBox2.Text) <> "" Then
                                'For counter = 0 To tempArray.GetUpperBound(0)
                                '    'System.Diagnostics.Debug.WriteLine(tempArray(counter))
                                '    'MsgBox(tempArray(counter))
                                '    Table4.AddCell(CVacio)
                                '    Table4.AddCell(CVacio)
                                '    Table4.AddCell(CVacio)
                                '    Table4.AddCell(CVacio)
                                '    Col5 = New PdfPCell(New Phrase(tempArray(counter), Font8))
                                '    Col5.Border = 0
                                '    Col5.Colspan = 2
                                '    Table4.AddCell(Col5)
                                '    Table4.AddCell(CVacio)
                                '    Table4.AddCell(CVacio)
                                '    Table4.AddCell(CVacio)
                                'Next
                            Else
                                Table4.AddCell(CVacio)
                                Table4.AddCell(CVacio)
                                Table4.AddCell(CVacio)
                                Table4.AddCell(CVacio)
                                Col5 = New PdfPCell(New Phrase(dr("descripcion_larga").ToString, Font8))
                                Col5.Border = 0
                                Col5.Colspan = 2
                                Table4.AddCell(Col5)
                                Table4.AddCell(CVacio)
                                Table4.AddCell(CVacio)
                                Table4.AddCell(CVacio)
                            End If


                            Dim fechacad As String = ""
                            Dim lotecad As String = ""

                            If dr("FechaCad").ToString <> "" Then
                                fechacad = "Fecha de Cad.:" & dr("FechaCad").ToString
                            End If

                            If dr("LoteCad").ToString <> "" Then
                                lotecad = "Lote: " & dr("LoteCad").ToString
                            End If

                            If fechacad <> "" And lotecad <> "" Then
                                Col1 = New PdfPCell(New Phrase(fechacad & " " & lotecad, Font8))
                                Col1.Border = 0
                                Col1.Colspan = 8
                                Table4.AddCell(Col1)
                                Table4.AddCell(CVacio)
                            End If

                            pdfDoc.Add(Table4)

                            Dim Table41 As PdfPTable = New PdfPTable(12)
                            Dim widths41 As Single() = New Single() {1.0F, 3.0F, 3.0F, 3.1F, 3.0F, 1.0F, 3.0F, 3.0F, 3.0F, 3.0F, 1.0F, 5.0F}
                            Table41.WidthPercentage = 95
                            Table41.SetWidths(widths41)

                            Table41.AddCell(CVacio)
                            Col1 = New PdfPCell(New Phrase("Traslados", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)
                            Table41.AddCell(CVacio)
                            Table41.AddCell(CVacio)
                            Table41.AddCell(CVacio)

                            Table41.AddCell(CVacio)

                            If dr("ret_iva").ToString <> 0 Then
                                Col1 = New PdfPCell(New Phrase("Retenciones", FontB8))
                                Col1.Border = 0
                                Col1.Colspan = 2
                                Table41.AddCell(Col1)
                                Table41.AddCell(CVacio)
                                Table41.AddCell(CVacio)
                            Else
                                If dr("isr").ToString <> 0 Then
                                    Col1 = New PdfPCell(New Phrase("Retenciones", FontB8))
                                    Col1.Border = 0
                                    Col1.Colspan = 2
                                    Table41.AddCell(Col1)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                Else
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                End If
                            End If

                            Table41.AddCell(CVacio)

                            Col1 = New PdfPCell(New Phrase("Objeto Impuesto", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            Table41.AddCell(CVacio)
                            Col1 = New PdfPCell(New Phrase("Impuesto", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)
                            Col1 = New PdfPCell(New Phrase("TipoFactor", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)
                            Col1 = New PdfPCell(New Phrase("TasaOCuota", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)
                            Col1 = New PdfPCell(New Phrase("Importe", FontB8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            Table41.AddCell(CVacio)

                            If dr("ret_iva").ToString <> 0 Then
                                Col1 = New PdfPCell(New Phrase("Impuesto", FontB8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase("TipoFactor", FontB8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase("TasaOCuota", FontB8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase("Importe", FontB8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                            Else
                                If dr("isr").ToString <> 0 Then
                                    Col1 = New PdfPCell(New Phrase("Impuesto", FontB8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("TipoFactor", FontB8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("TasaOCuota", FontB8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Importe", FontB8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                Else
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                End If
                            End If

                            Table41.AddCell(CVacio)

                            If dr("porceniva").ToString > 0 Then
                                Col1 = New PdfPCell(New Phrase("Si objeto de Impuesto", Font8))
                            Else
                                If dr("ieps").ToString > 0 Then
                                    Col1 = New PdfPCell(New Phrase("Si objeto de Impuesto", Font8))
                                Else
                                    If dr("isr").ToString > 0 Then
                                        Col1 = New PdfPCell(New Phrase("Si objeto de Impuesto", Font8))
                                    Else
                                        Col1 = New PdfPCell(New Phrase("Si objeto de Impuesto", Font8))
                                    End If
                                End If
                            End If

                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            Table41.AddCell(CVacio)
                            Col1 = New PdfPCell(New Phrase("002 IVA", Font8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)
                            Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            If dr("porceniva").ToString = 16 Then
                                Col1 = New PdfPCell(New Phrase("0.160000", Font8))
                            Else
                                Col1 = New PdfPCell(New Phrase("0.000000", Font8))
                            End If
                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            Dim vartotal1 As Decimal = 0
                            Dim varresultado1 As Decimal = 0
                            Dim varope1 As Decimal = 0
                            varope1 = dr("totaliva").ToString - dr("totalsiva").ToString
                            vartotal1 = dr("porceniva").ToString / 100
                            varresultado1 = (CDec(dr("totalsiva").ToString) + CDec(dr("ieps").ToString)) * vartotal1
                            Select Case dr("porceniva").ToString
                                Case 16
                                    Col1 = New PdfPCell(New Phrase(IIf(Cmb_RFC.Text = "XAXX010101000", FormatNumber(varope1, 4), FormatNumber(varresultado1, 4)), Font8))
                                Case 0
                                    Col1 = New PdfPCell(New Phrase("0.00", Font8))
                                Case Else
                                    Col1 = New PdfPCell(New Phrase(FormatNumber(varresultado1, 6), Font8))
                            End Select
                            Col1.Border = 0
                            Table41.AddCell(Col1)

                            Table41.AddCell(CVacio)

                            If dr("ret_iva").ToString <> 0 Then
                                Col1 = New PdfPCell(New Phrase("002 IVA", Font8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase(dr("ret_iva_perc").ToString, Font8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                                Col1 = New PdfPCell(New Phrase(dr("ret_iva").ToString, Font8))
                                Col1.Border = 0
                                Table41.AddCell(Col1)
                            Else
                                If dr("isr").ToString <> 0 Then
                                    Col1 = New PdfPCell(New Phrase("001 ISR", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase((CDec(dr("isr").ToString) * 100) & "0000", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(CDec(dr("totalsiva").ToString) * CDec(dr("isr").ToString), Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                Else
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                End If
                            End If

                            Table41.AddCell(CVacio)
                            Table41.AddCell(CVacio)

                            If dr("ret_iva").ToString <> 0 And dr("isr").ToString <> 0 Then

                                If dr("ieps").ToString <> 0 Then
                                    Table41.AddCell(CVacio)
                                    Col1 = New PdfPCell(New Phrase("003 IEPS", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(dr("ieps_porcentaje").ToString, Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(dr("ieps").ToString, Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Table41.AddCell(CVacio)

                                    Col1 = New PdfPCell(New Phrase("001 ISR", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase((CDec(dr("isr").ToString) * 100) & "0000", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(CDec(dr("totalsiva").ToString) * CDec(dr("isr").ToString), Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                Else

                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)

                                    Col1 = New PdfPCell(New Phrase("001 ISR", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase((CDec(dr("isr").ToString) * 100) & "0000", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(CDec(dr("totalsiva").ToString) * CDec(dr("isr").ToString), Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)

                                End If

                            Else
                                If dr("ieps").ToString <> 0 Then
                                    Table41.AddCell(CVacio)
                                    Col1 = New PdfPCell(New Phrase("003 IEPS", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase("Tasa", Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(dr("ieps_porcentaje").ToString, Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Col1 = New PdfPCell(New Phrase(dr("ieps").ToString, Font8))
                                    Col1.Border = 0
                                    Table41.AddCell(Col1)
                                    Table41.AddCell(CVacio)

                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                    Table41.AddCell(CVacio)
                                End If
                            End If

                            pdfDoc.Add(Table41)

                        Next
                    End If
                    cnn.Close()
                End If
            End With

#End Region

            'varYlinea = 331 '307 '295
            'PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)
            For iFila = 1 To 32
                pdfDoc.Add(New Paragraph(" "))
                ILine = pdfWrite.GetVerticalPosition(True)
                If ILine < 331 Then
                    Exit For
                End If
            Next

#Region "Tabla 5 - Final"

            Dim Table5 As PdfPTable = New PdfPTable(3)
            Dim widths5 As Single() = New Single() {4.0F, 9.0F, 4.0F}
            Dim Table61 As PdfPTable = New PdfPTable(1)
            Dim Table62 As PdfPTable = New PdfPTable(1)
            Dim widths61 As Single() = New Single() {9.0F}
            Dim widths62 As Single() = New Single() {4.0F}

            Table5.WidthPercentage = 95
            Table5.SetWidths(widths5)

            Table61.SetWidths(widths61)
            Table62.SetWidths(widths62)

            Table5.DefaultCell.BorderWidth = 1

            'Table5.DefaultCell.Border = 0

            'Table5.TotalWidth = pdfDoc.PageSize.Width - 40

            Col1 = New PdfPCell(New Phrase("METODO DE PAGO: " & varmetodopago, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
            Col3 = New PdfPCell(New Phrase("SUMA: $" & Text_SubTotal.Text, Font8))
            Col3.Border = 0
            Col3.HorizontalAlignment = 2
            Table62.AddCell(Col3)

            Col1 = New PdfPCell(New Phrase("Condiciones de Pago: " & varcondiciones, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
            Col3 = New PdfPCell(New Phrase("DESCUENTO: $" & Text_Descuento.Text, Font8))
            Col3.Border = 0
            Col3.HorizontalAlignment = 2
            Table62.AddCell(Col3)

            Col1 = New PdfPCell(New Phrase("Numero de Cuenta: " & varnumerocta, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
            Col3 = New PdfPCell(New Phrase("SUBTOTAL: $" & TextBox1.Text, Font8))
            Col3.Border = 0
            Col3.HorizontalAlignment = 2
            Table62.AddCell(Col3)

            Col1 = New PdfPCell(New Phrase("Forma de pago: " & varformapago, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
            Col3 = New PdfPCell(New Phrase("IVA 16%: $" & FormatNumber(Text_IVA.Text, 2), Font8))
            Col3.Border = 0
            Col3.HorizontalAlignment = 2
            Table62.AddCell(Col3)

            If CDec(Text_IVARET.Text) > 0 And CDec(txt_impuestos.Text) > 0 And CDec(txtISR.Text) > 0 Then
                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("IVA ret. " & ivaretporc & "%: $" & FormatNumber(Text_IVARET.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("ISR ret. " & isrporc & "%: $" & FormatNumber(txtISR.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                If ieps160 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 160%: $" & FormatNumber(ieps160, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps53 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 53%: $" & FormatNumber(ieps53, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps5 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 50%: $" & FormatNumber(ieps5, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps304 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 30.4%: $" & FormatNumber(ieps304, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps3 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 30%: $" & FormatNumber(ieps3, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps265 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 26.5%: $" & FormatNumber(ieps265, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps25 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 25%: $" & FormatNumber(ieps25, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps09 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 9%: $" & FormatNumber(ieps09, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps08 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 8%: $" & FormatNumber(ieps08, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps07 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 7%: $" & FormatNumber(ieps07, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps06 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 6%: $" & FormatNumber(ieps06, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps03 > 0 Then
                    Table61.AddCell(CVacio)
                    Col3 = New PdfPCell(New Phrase("IEPS 5%: $" & FormatNumber(ieps03, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If

                Table61.AddCell(CVacio)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(Text_IVARET.Text) > 0 And CDec(txt_impuestos.Text) > 0 And CDec(txtISR.Text) = 0 Then

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("IVA ret. " & ivaretporc & "%: $" & FormatNumber(Text_IVARET.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Dim banderaentra As Integer = 0

                If ieps160 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 160%: $" & FormatNumber(ieps160, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps53 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 53%: $" & FormatNumber(ieps53, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps5 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 50%: $" & FormatNumber(ieps5, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps304 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30.4%: $" & FormatNumber(ieps304, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps3 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30%: $" & FormatNumber(ieps3, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps265 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 26.5%: $" & FormatNumber(ieps265, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps25 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 25%: $" & FormatNumber(ieps25, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps09 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 9%: $" & FormatNumber(ieps09, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps08 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 8%: $" & FormatNumber(ieps08, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps07 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 7%: $" & FormatNumber(ieps07, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps06 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 6%: $" & FormatNumber(ieps06, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps03 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 5%: $" & FormatNumber(ieps03, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If

                Table61.AddCell(CVacio)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(Text_IVARET.Text) > 0 And CDec(txtISR.Text) > 0 And CDec(txt_impuestos.Text) = 0 Then

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("IVA ret. " & ivaretporc & "%: $" & FormatNumber(Text_IVARET.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("ISR ret. " & isrporc & "%: $" & FormatNumber(txtISR.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Table61.AddCell(CVacio)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(txt_impuestos.Text) > 0 And CDec(txtISR.Text) > 0 And CDec(Text_IVARET.Text) = 0 Then

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("ISR ret. " & isrporc & "%: $" & FormatNumber(txtISR.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Dim banderaentra As Integer = 0

                If ieps160 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 160%: $" & FormatNumber(ieps160, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps53 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 53%: $" & FormatNumber(ieps53, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps5 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 50%: $" & FormatNumber(ieps5, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps304 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30.4%: $" & FormatNumber(ieps304, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps3 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30%: $" & FormatNumber(ieps3, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps265 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 26.5%: $" & FormatNumber(ieps265, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps25 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 25%: $" & FormatNumber(ieps25, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps09 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 9%: $" & FormatNumber(ieps09, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps08 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 8%: $" & FormatNumber(ieps08, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps07 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 7%: $" & FormatNumber(ieps07, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps06 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 6%: $" & FormatNumber(ieps06, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps03 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 5%: $" & FormatNumber(ieps03, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If

                Table61.AddCell(CVacio)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(Text_IVARET.Text) > 0 And CDec(txt_impuestos.Text) = 0 And CDec(txtISR.Text) = 0 Then

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("IVA ret. " & ivaretporc & "%: $" & FormatNumber(Text_IVARET.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(txt_impuestos.Text) > 0 And CDec(Text_IVARET.Text) = 0 And CDec(txtISR.Text) = 0 Then

                Dim banderaentra As Integer = 0

                If ieps160 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 160%: $" & FormatNumber(ieps160, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps53 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 53%: $" & FormatNumber(ieps53, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps5 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 50%: $" & FormatNumber(ieps5, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps304 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30.4%: $" & FormatNumber(ieps304, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps3 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 30%: $" & FormatNumber(ieps3, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps265 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 26.5%: $" & FormatNumber(ieps265, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps25 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 25%: $" & FormatNumber(ieps25, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps09 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 9%: $" & FormatNumber(ieps09, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps08 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 8%: $" & FormatNumber(ieps08, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps07 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 7%: $" & FormatNumber(ieps07, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps06 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 6%: $" & FormatNumber(ieps06, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If
                If ieps03 > 0 Then
                    If banderaentra = 0 Then
                        banderaentra = 1
                        Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    ElseIf banderaentra = 1 Then
                        banderaentra = 2
                        Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                        Col1.Border = 0
                        Table61.AddCell(Col1)
                    Else
                        Table61.AddCell(CVacio)
                    End If
                    Col3 = New PdfPCell(New Phrase("IEPS 5%: $" & FormatNumber(ieps03, 2), Font8))
                    Col3.Border = 0
                    Col3.HorizontalAlignment = 2
                    Table62.AddCell(Col3)
                End If

                If banderaentra = 1 Then
                    Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                    Col1.Border = 0
                    Table61.AddCell(Col1)
                Else
                    Table61.AddCell(CVacio)
                End If
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            ElseIf CDec(txtISR.Text) > 0 And CDec(Text_IVARET.Text) = 0 And CDec(txt_impuestos.Text) = 0 Then

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("ISR ret. " & isrporc & "%: $" & FormatNumber(txtISR.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

            Else

                Col1 = New PdfPCell(New Phrase("Cantidad con letra: ", FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Col3 = New PdfPCell(New Phrase("TOTAL: $" & FormatNumber(Text_TOTAL.Text, 2), Font8))
                Col3.Border = 0
                Col3.HorizontalAlignment = 2
                Table62.AddCell(Col3)

                Col1 = New PdfPCell(New Phrase(varnumletra, FontB8))
                Col1.Border = 0
                Table61.AddCell(Col1)
                Table62.AddCell(CVacio)

            End If

            Dim cadqr As String = ""

            If varrutabase <> "" Then
                cadqr = varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & var_folio & ".jpg"
            Else
                cadqr = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & var_folio & ".jpg"
            End If
            Dim qr2 As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & var_folio & ".jpg"

            Dim imagenURL2 As String = cadqr
            Dim imagenBMP2 As iTextSharp.text.Image

            Try
                imagenBMP2 = iTextSharp.text.Image.GetInstance(imagenURL2)
                imagenBMP2.ScaleToFit(100.0F, 100.0F)
                imagenBMP2.SpacingBefore = 20.0F
                imagenBMP2.SpacingAfter = 10.0F
                imagenBMP2.SetAbsolutePosition(25, 180)
            Catch ex As Exception
                imagenBMP2 = iTextSharp.text.Image.GetInstance(qr2)
                imagenBMP2.ScaleToFit(100.0F, 100.0F)
                imagenBMP2.SpacingBefore = 20.0F
                imagenBMP2.SpacingAfter = 10.0F
                imagenBMP2.SetAbsolutePosition(25, 180)
            End Try

            Table5.AddCell(imagenBMP2)
            Table5.AddCell(Table61)
            Table5.AddCell(Table62)
            Col1 = New PdfPCell(New Phrase("Leyenda: " & varleyenda, Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase("Sello Digital del CFDI:", Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase(varsellocfdi, Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase("Sello Digital del SAT:", Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase(varsellosat, Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase("Cadena Original del Comprobante de Certificación digital del SAT:", Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)
            Col1 = New PdfPCell(New Phrase(varcadenaoriginal, Font8))
            Col1.Border = 0
            Col1.Colspan = 3
            Table5.AddCell(Col1)

            pdfDoc.Add(Table5)

#End Region

            pdfDoc.Close()

            Try

                ProgressBar1.Value = 85
                lbl_proceso.Text = "Abriendo PDF ..."
                My.Application.DoEvents()

                If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Process.Start(root_name_recibo)
                End If

                If MsgBox("¿Desea enviar el Archivo Via E-Mail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Dim nombreCFD As String = "F" & txt_serie.Text & var_folio & ".xml"
                    Select Case Cmb_TipoFact.Text
                        Case "FACTURA"
                            nombreCFD = "F" & txt_serie.Text & var_folio & ".xml"
                        Case "PREFACTURA"
                            nombreCFD = "pf" & txt_serie.Text & var_folio & ".xml"
                        Case "RECIBO DE ARRENDAMIENTO"
                            nombreCFD = "A" & txt_serie.Text & var_folio & ".xml"
                        Case "RECIBO DE HONORARIOS"
                            nombreCFD = "H" & txt_serie.Text & var_folio & ".xml"
                        Case "NOTA DE CREDITO"
                            nombreCFD = "N" & txt_serie.Text & var_folio & ".xml"
                    End Select

                    Dim xmla As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD
                    ProgressBar1.Value = 90
                    lbl_proceso.Text = "Enviando E-Mail ..."
                    My.Application.DoEvents()
                    envio_mail.Show()
                    envio_mail.BringToFront()
                    envio_mail.archivoadj = root_name_recibo
                    If Cmb_TipoFact.Text <> "PREFACTURA" Then
                        envio_mail.archivoadj2 = xmla
                    End If
                    envio_mail.txtasunto.Text = Cmb_TipoFact.Text & " " & var_folio
                    envio_mail.txtpara.Text = Text_Email.Text
                End If
                llena_cbofolio()
                Cmb_Nfactura.SelectedIndex = Cmb_Nfactura.Items.Count - 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Function damevalorlinea(ByVal cantcaracteres As Long, ByVal vartipo As Integer) As Integer
        Dim ValorDecimal As Double = 0
        Dim ParteEntera As Long = 0
        Dim ParteDecimal As Double = 0
        If vartipo = 0 Then
            ValorDecimal = cantcaracteres / 90
        Else
            ValorDecimal = cantcaracteres / 67
        End If
        ParteEntera = Int(ValorDecimal)
        ParteDecimal = ValorDecimal - ParteEntera
        If ParteDecimal > 0 Then
            ParteEntera += 1
        End If
        ParteEntera = ParteEntera * 10
        Return ParteEntera
    End Function

    Public Sub PintarLinea(ByVal numGrosor As Double,
                          ByVal X1 As Integer, ByVal Y1 As Integer,
                          ByVal X2 As Integer, ByVal Y2 As Integer,
                          ByVal pdfWrite As PdfWriter)
        Dim linea As PdfContentByte
        linea = pdfWrite.DirectContent
        linea.SetLineWidth(numGrosor)
        linea.MoveTo(X1, Y1)
        linea.LineTo(X2, Y2)
        linea.Stroke()
        'pdfDoc.Add(Chunk.NEWLINE)
    End Sub

    Public Sub PintarCuadrado(ByVal numGrosor As Double,
                           ByVal X1 As Integer, ByVal Y1 As Integer,
                           ByVal X2 As Integer, ByVal Y2 As Integer,
                           ByVal pdfWrite As PdfWriter, ByVal pdfDoc As Document)

        Dim linea As PdfContentByte
        linea = pdfWrite.DirectContent
        linea.SetLineWidth(numGrosor)
        linea.MoveTo(X1, Y1)
        linea.LineTo(X2, Y1)
        linea.Stroke()
        linea.MoveTo(X2, Y1)
        linea.LineTo(X2, Y2)
        linea.Stroke()
        linea.MoveTo(X2, Y2)
        linea.LineTo(X1, Y2)
        linea.Stroke()
        linea.MoveTo(X1, Y2)
        linea.LineTo(X1, Y1)
        linea.Stroke()
        pdfDoc.Add(Chunk.NEWLINE)

    End Sub

    Private Sub Text_cantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_cantidad.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If Text_cantidad.Text = "" Or Text_cantidad.Text = "0" Then
                Text_cantidad.Text = "1"
            End If
            Text_Precio.Focus()
        End If
    End Sub

    Private Sub Text_cantidad_TextChanged(sender As Object, e As EventArgs) Handles Text_cantidad.TextChanged
        On Error GoTo malo
        Text_t.Text = CDbl(Text_cantidad.Text) * CDbl(Text_Precio.Text)
malo:
    End Sub

    Private Sub Text_Precio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Precio.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_piva.Focus()
        End If
    End Sub

    Private Sub Text_Precio_TextChanged(sender As Object, e As EventArgs) Handles Text_Precio.TextChanged
        On Error GoTo malo
        Text_t.Text = CDbl(Text_cantidad.Text) * CDbl(Text_Precio.Text)
malo:
    End Sub

    Private Sub Cmb_Nfactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_Nfactura.KeyPress
        On Error GoTo malo

        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            recupera_campos()
            My.Application.DoEvents()
            btnReenvio.Enabled = True

            If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo, "Delsscom Control Negocios Pro") = MsgBoxResult.Yes Then
                var_folio = Cmb_Nfactura.Text
                var_idfactura = Cmb_Nfactura.SelectedValue

                Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString

                Dim FileOpen As New ProcessStartInfo
                crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\")
                crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\")
                If varrutabase <> "" Then
                    crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\")
                    crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\")
                End If

                If varrutabase <> "" Then
                    Dim nombreCFD As String = ""
                    Select Case Cmb_TipoFact.Text
                        Case "FACTURA"
                            nombreCFD = "F" & txt_serie.Text & var_folio & ".xml"
                            If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD) = False Then
                                If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD) Then
                                    My.Computer.FileSystem.CopyFile("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD, "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                                End If
                            End If
                    End Select
                End If

                Dim root_name_recibo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"
                If varrutabase <> "" Then
                    root_name_recibo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"
                End If

                If File.Exists(root_name_recibo) Then
                    File.Delete(root_name_recibo)
                    consultaxml()
                    printRecibo()
                    Cmb_Nfactura.Text = var_folio
                    'FileOpen.UseShellExecute = True
                    'FileOpen.FileName = root_name_recibo
                    'Process.Start(FileOpen)
                Else
                    consultaxml()
                    printRecibo()
                End If

            End If
            'Dim ps As New PaperSize("Custom", 269, 4000)

            If MsgBox("¿Desea imprimir la factura en Ticket?", MsgBoxStyle.YesNo, "Delsscom Control Negocios Pro") = MsgBoxResult.Yes Then
                On Error GoTo ayudaXD
                Dim var666 As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\imagenes\" & Cmb_Nfactura.Text & ".jpg"
                PictureBox2.Image = System.Drawing.Image.FromFile(Convert.ToString(var666))
ayudaXD:
                Dim ps As New System.Drawing.Printing.PaperSize("Custom", 269, 8000)
                PrintDocument1.DefaultPageSettings.PaperSize = ps
                FolioTicket = Cmb_Nfactura.Text
                PrintDocument1.Print()
                envio_mail.BringToFront()
            End If

        End If
malo:
        'MsgBox(Err.Description)
    End Sub

    Private Sub recupera_campos()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from facturas where nom_id=" & Cmb_Nfactura.SelectedValue
        Dim dr As DataRow
        Dim dr5 As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then

                    Cmb_RazonS.Text = dame_RS_ClienteID(dr("nom_id_cliente").ToString)
                    Cmb_RFC.Text = dame_RFC_Cliente(Cmb_RazonS.Text)

                    If .getDt(cnn, dt, "select * from UUIDRelacion where IdFact = " & Cmb_Nfactura.Text & "", sinfo) Then
                        For Each dr5 In dt.Rows
                            dgUUID.Rows.Insert(0, cboFolio.Text, dr5("UUID").ToString)
                            cboTipoRelacion.Text = dr5("TipoRelacion").ToString
                        Next
                    Else
                        dgUUID.Rows.Clear()
                        cboTipoRelacion.SelectedIndex = -1
                    End If

                    var_cliente = dr("nom_id_cliente").ToString
                    muestra_datos_cliente()

                    llena_gridf(Cmb_Nfactura.SelectedValue)
                    Text_FormaPago.SelectedValue = dr("nom_tipo_pago").ToString
                    If Text_FormaPago.SelectedValue = "PPD" Then btnParcialidades.Enabled = True Else btnParcialidades.Enabled = False
                    cbometodo_pago.SelectedValue = dr("nom_metodo_pago").ToString
                    Select Case dr("nom_metodo_pago").ToString
                        Case "01"
                            cadena_pagos1 &= "01 Efectivo."
                        Case "02"
                            cadena_pagos1 &= "02 Cheque nominativo."
                        Case "03"
                            cadena_pagos1 &= "03 Transferencia electronica de fondos."
                        Case "04"
                            cadena_pagos1 &= "04 Tarjetas de crédito."
                        Case "05"
                            cadena_pagos1 &= "05 Monedero electrónico."
                        Case "06"
                            cadena_pagos1 &= "06 Dinero electrónico"
                        Case "08"
                            cadena_pagos1 &= "08 Vales de despensa"
                        Case "28"
                            cadena_pagos1 &= "28 Tarjeta de Debito"
                        Case "29"
                            cadena_pagos1 &= "29 Tarjeta de Servicio"
                        Case "99"
                            cadena_pagos1 &= "99 Otros"
                        Case Else
                    End Select

                    Text_nCuenta.Text = dr("nom_numcuenta").ToString
                    Text_MotivoDes.Text = dr("nom_mdescuento").ToString
                    txt_leyenda_add.Text = dr("nom_leyenda").ToString
                    Text_TOTAL.Text = dr("nom_total_pagado").ToString
                    Text_IVA.Text = dr("iva").ToString
                    Select Case dr("nom_status").ToString
                        Case "1"
                            lbl_estatus.Text = "Activa"
                        Case "3"
                            lbl_estatus.Text = "Error al timbrar"
                        Case "2"
                            lbl_estatus.Text = "Cancelada"
                    End Select

                    If dr("CartaPorte").ToString = 1 Then
                        CheckBox2.Checked = True
                        btnComplementoCP.Enabled = True
                        llena_cartaporte(dr("nom_id").ToString)
                    Else
                        CheckBox2.Checked = False
                        btnComplementoCP.Enabled = False
                    End If

                End If
                cnn.Close()
            Else
                'MsgBox(sinfo)
            End If
        End With

    End Sub

    Function dame_RS_ClienteID(ByVal varID As Integer) As String
        Dim cnn10 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RazonSocial from Clientes where Id = " & varID & ""
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn10, sTarget, sinfo) Then

                If .getDr(cnn10, dr, sSQL, sinfo) Then

                    cnn10.Close()
                    Return dr("RazonSocial").ToString
                Else
                    cnn10.Close()
                    Return ""
                End If
            End If
        End With
#Disable Warning BC42105 ' La función 'dame_RS_ClienteID' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dame_RS_ClienteID' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Public Sub llena_gridf(ByVal idf As Integer)
        txt_tasaiva.Text = "0"
        grid_prods.Rows.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from detalle_factura where factura=" & idf & " order by orden"
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    var1 = 0
                    For Each dr In dt.Rows
                        Dim descuento_uni As Decimal = CDec(dr("descuento").ToString) / CDec(dr("cantidad").ToString)
                        Dim unidadcivad As Decimal = FormatNumber(obtienepiva(CDec(dr("preciou").ToString), CDec(dr("porceniva").ToString)), 4)
                        Dim var_totalcivad As Decimal = unidadcivad * CDec(dr("cantidad").ToString)
                        Dim precio_uni As Decimal = FormatNumber(CDec(dr("preciou").ToString) + descuento_uni, 6)
                        Dim totalsiva As Decimal = CDec(precio_uni) * CDec(dr("cantidad").ToString)

                        'grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, CDec(dr("preciou").ToString) + CDec(dr("descuento").ToString), CDec(dr("descuento").ToString) + CDec(dr("totalsiva").ToString), unidadcivad, var_totalcivad, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, dr("isr").ToString)

                        grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, FormatNumber(precio_uni, 6), FormatNumber(totalsiva, 6), unidadcivad, FormatNumber(var_totalcivad, 4), dr("porceniva").ToString, FormatNumber(dr("descuento").ToString, 6), dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString, dr("orden").ToString, dr("clvsat").ToString, dr("isr").ToString, "", "", "", "", "")

                        If dr("porceniva").ToString > CDec(txt_tasaiva.Text) Then

                            txt_tasaiva.Text = dr("porceniva").ToString
                        End If
                        var1 = var1 + 1
                        My.Application.DoEvents()
                    Next
                Else
                    ''MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
        calcula()
    End Sub

    Public Sub llena_cartaporte(ByVal idf As Integer)

        dgProductos.Rows.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from CartaPorteI where FolioCarta=" & idf
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        If dr("Inter").ToString = "No" Then
                            chkInter.Checked = False
                            GroupBox13.Visible = False
                            GroupBox19.Visible = False
                        Else
                            chkInter.Checked = True
                            GroupBox13.Visible = True
                            GroupBox19.Visible = True
                        End If

                        txtAseguradora.Text = dr("Aseguradora").ToString
                        txtNumPoliza.Text = dr("NumPoliza").ToString
                        txtModeloAño.Text = dr("ModeloA").ToString
                        txtNumPermisoSCT.Text = dr("NumPermisoSCT").ToString
                        txtPlaca.Text = dr("Placa").ToString
                        cboConfigV.Text = regresarValor("Descripcion", "Clave", "PorteConfigAutotrans", dr("Config").ToString)
                        cboPermisoSCT.Text = regresarValor("Descripcion", "Clave", "PorteTipoPermiso", dr("PermisoSCT").ToString)
                        dgProductos.Rows.Clear()

                        cboOrigRemitente.Text = dr("OrigNombre").ToString
                        txtOrigRFC.Text = dr("OrigRFC").ToString
                        dtpOrigFecha.Text = Mid(dr("OrigFechaHora").ToString, 1, 10)
                        dtpOrigHora.Text = Mid(dr("OrigFechaHora").ToString, 12, 8)
                        txtOrigCP.Text = dr("OrigCP").ToString
                        txtOrigCalle.Text = dr("OrigCalle").ToString
                        txtOrigNumExt.Text = dr("OrigNumExt").ToString
                        txtOrigNumInt.Text = dr("OrigNumInt").ToString
                        cboOrigColonia.Text = dr("OrigColoniaT").ToString
                        cboOrigEdo.Text = dr("OrigEdoT").ToString
                        cboOrigMun.Text = dr("OrigMunT").ToString

                        cboDesDestinatario.Text = dr("DesNombre").ToString
                        txtDesRFC.Text = dr("DesRFC").ToString
                        dtpDesFecha.Text = Mid(dr("DesFechaHora").ToString, 1, 10)
                        dtpDesHora.Text = Mid(dr("DesFechaHora").ToString, 12, 8)
                        txtDestinoCP.Text = dr("DesCP").ToString
                        cboDestinoPais.Text = regresarValor("Nombre", "ClavePais", "PortePais", dr("DesPais").ToString)
                        txtDestinoCalle.Text = dr("DesCalle").ToString
                        txtDestinoNumE.Text = dr("DesNumExt").ToString
                        txtDestinoNumI.Text = dr("DesNumInt").ToString
                        cboDestinoColonia.Text = dr("DesColT").ToString
                        cboDestinoEdo.Text = dr("DesEdoT").ToString
                        cboDestinoMun.Text = dr("DesMunT").ToString
                        txtDestinioDist.Text = dr("TotalDistancia").ToString
                        txtDestinoLoc.Text = dr("DesLocalidad").ToString

                        cboTipoFigura.Text = dr("FiguraTrasporte").ToString
                        cboOpeNombre.Text = dr("OpeNombre").ToString
                        txtOpeRFC.Text = dr("OpeRFC").ToString
                        txtOpeLicencia.Text = dr("OpeLic").ToString

                        txtTotalPeso.Text = dr("TotalPesoM").ToString

                        Dim dt2 As New DataTable
                        Dim dr2 As DataRow
                        If .getDt(cnn, dt2, "select * from CartaPorteDetI where IdCarta = " & dr("Id").ToString & " order by Id", sinfo) Then
                            For Each dr2 In dt2.Rows
                                dgProductos.Rows.Add(dr2("Descripcion").ToString, dr2("UniMedSAT").ToString, dr2("ProdServSAT").ToString, dr2("Cantidad").ToString, dr2("ValorM").ToString, dr2("PesoKg").ToString, dr2("NumPed").ToString, dr2("UUIDComE").ToString, dr2("FracArancelaria").ToString)
                            Next
                        End If
                    Next
                Else
                    ''MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
        calcula()
    End Sub

    Private Function regresarValor(ByVal varCampo As String, ByVal varCampo2 As String, ByVal vartabla As String, ByVal varclave As String) As String
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select " & varCampo & " from " & vartabla & " where " & varCampo2 & " = '" & varclave & "'", sinfo1) Then
                    For Each dr1 In dt1.Rows
                        cnn1.Close()
                        Return dr1(0).ToString
                    Next
                Else
                    cnn1.Close()
                    Return ""
                End If
                cnn1.Close()
            End If
        End With
        Return ""
    End Function

    Private Function consultaxml()

        Dim nombreCFD As String = "F" & txt_serie.Text & var_folio & ".xml"
        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
        End Select

        Dim newcarpeta As String = Replace(razon_social, Chr(34), "").ToString
        Dim root_name_recibo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD '"C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & var_folio & "_F" & var_folio & ".pdf"
        If varrutabase <> "" Then
            root_name_recibo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD
        End If

        If File.Exists(root_name_recibo) Then
            'existencia de la factura
            Dim varexiste As Integer = 0
            'variables para la conexion
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sSQL As String = ""
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            Dim dr As DataRow
#Disable Warning BC42024 ' Variable local sin usar: 'dt'.
            Dim dt As DataTable
#Enable Warning BC42024 ' Variable local sin usar: 'dt'.

            'variables datos emisor
            Dim varEmiRazonSocial As String = ""
            Dim varEmiId As String = ""
            Dim varEmiRFC As String = ""
            Dim varEmiRegFiscal As String = ""
            Dim varEmiActEmpresa As String = ""
            Dim varEmiCalle As String = ""
            Dim varEmiColonia As String = ""
            Dim varEmiDelMun As String = ""
            Dim varEmiCP As String = ""
            Dim varExpedido As String = ""
            Dim varEmiEdo As String = ""
            Dim varEmiNumExt As String = ""
            Dim varEmiNumInt As String = ""
            'variables datos clientes
            Dim varClienteId As String = ""
            Dim varClienteRazonSocial As String = ""
            Dim varClienteRFC As String = ""
            Dim varClienteRegfis As String = ""
            Dim varClienteCalle As String = ""
            Dim varClienteColonia As String = ""
            Dim varClienteDelMun As String = ""
            Dim varClienteNumExt As String = ""
            Dim varClienteEdo As String = ""
            'variables datos factura
            Dim varNumFolioFact As String = ""
            Dim varNumFolioFactId As String = ""
            Dim varFechaFact As String = ""
            Dim varMetPagoFact As String = ""
            Dim varTipoPagoFact As String = ""
            Dim varUUIDFact As String = ""
            Dim varFechaFolSATFact As String = ""
            Dim varSelloEmiFact As String = ""
            Dim varSelloSATFact As String = ""
            Dim varTotalFact As String = "0"
            Dim varCSDSatFact As String = ""
            Dim varCSDEmpFact As String = ""
            Dim varEstatusFact As String = "1"
            Dim varDescuentoFact As String = "0"
            Dim varIVAFact As String = "0"
            Dim varSubTotalFact As String = "0"
            Dim varIVARetFact As String = "0"
            Dim varIEPSFact As String = "0"
            Dim varUsoCFDI As String = ""
            Dim varFormaPagoFact As String = ""
            Dim varVersion As String = ""
            Dim varRFCProvFact As String = ""
            'variables datos
            Dim varCantConceptos As Integer = 0
            'Buscamos el xml que se descargo
            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector.Name = "cfdi:Comprobante" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Folio"
                                            sSQL = "select nom_folio,nom_id from Facturas where nom_folio = " & Lector.Value & ""
                                            If oData.dbOpen(cnn, sTarget, sinfo) Then
                                                If oData.getDr(cnn, dr, sSQL, sinfo) Then
                                                    'si existe la factura
                                                    varexiste = 1
                                                End If
                                            End If
                                            cnn.Close()
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                        If Lector.Name = "cfdi:Comprobante" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Total"
                                            varTotalFact = Lector.Value
                                        Case "SubTotal"
                                            varSubTotalFact = Lector.Value
                                        Case "MetodoPago"
                                            varMetPagoFact = Lector.Value
                                        Case "FormaPago"
                                            varFormaPagoFact = Lector.Value
                                        Case "Folio"
                                            varNumFolioFact = Lector.Value
                                        Case "Fecha"
                                            varFechaFact = Lector.Value
                                        Case "Descuento"
                                            varDescuentoFact = Lector.Value
                                        Case "NoCertificado"
                                            varCSDEmpFact = Lector.Value
                                    End Select
                                End While
                            End If
                        End If

                        If Lector.Name = "cfdi:Emisor" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Rfc"
                                            varEmiRFC = Lector.Value
                                        Case "RegimenFiscal"
                                            varEmiRegFiscal = Lector.Value
                                        Case "Nombre"
                                            varEmiRazonSocial = Lector.Value
                                    End Select
                                End While
                            End If
                        End If

                        If Lector.Name = "cfdi:Receptor" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Rfc"
                                            varClienteRFC = Lector.Value
                                        Case "UsoCFDI"
                                            varUsoCFDI = Lector.Value
                                        Case "Nombre"
                                            varClienteRazonSocial = Lector.Value
                                        Case "RegimenFiscalReceptor"
                                            varClienteRegfis = Lector.Value
                                    End Select
                                End While
                            End If
                        End If

                        If Lector.Name = "tfd:TimbreFiscalDigital" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "UUID"
                                            varUUIDFact = Lector.Value
                                        Case "FechaTimbrado"
                                            varFechaFolSATFact = Lector.Value
                                        Case "SelloCFD"
                                            varSelloEmiFact = Lector.Value
                                        Case "SelloSAT"
                                            varSelloSATFact = Lector.Value
                                        Case "Version"
                                            varVersion = Lector.Value
                                        Case "NoCertificadoSAT"
                                            varCSDSatFact = Lector.Value
                                        Case "RfcProvCertif"
                                            varRFCProvFact = Lector.Value
                                    End Select
                                End While
                            End If
                        End If

                        Dim esuniva As Integer = 0
                        Dim tasacuota As String = ""
                        Dim ivatemporal As String = ""
                        Dim newbase As String = "0"

                        If Lector.Name = "cfdi:Traslado" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Impuesto"
                                            If CStr(Lector.Value) = "002" Then
                                                esuniva = 1
                                            End If
                                        Case "Importe"
                                            ivatemporal = Lector.Value
                                        Case "TasaOCuota"
                                            tasacuota = Lector.Value
                                        Case "Base"
                                            newbase = Lector.Value
                                    End Select
                                End While
                            End If
                        End If

                        If esuniva = 1 And tasacuota = "0.160000" And newbase > 0 Then
                            varIVAFact = ivatemporal
                        End If

                End Select
            Loop

            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "select * from Clientes where RazonSocial ='" & varClienteRazonSocial & "' and RFC = '" & varClienteRFC & "'", sinfo) Then
                        varClienteId = dr("Id").ToString
                        varClienteCalle = dr("Calle").ToString
                        varClienteColonia = dr("Colonia").ToString
                        varClienteDelMun = dr("Delegacion").ToString
                        varClienteNumExt = dr("NExterior").ToString
                        varClienteEdo = dr("Entidad").ToString
                    End If
                    cnn.Close()
                End If
            End With

            varEmiRazonSocial = "INDISTRIA ILUMINADORA DE ALMACENES"
            varEmiRFC = "IIA040805DZ4"

            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "select * from DatosNegocio where Em_RazonSocial ='" & varEmiRazonSocial & "' and Em_rfc = '" & varEmiRFC & "'", sinfo) Then
                        varEmiId = dr("Emisor_id").ToString
                        varEmiActEmpresa = dr("Em_Actividad").ToString
                        varEmiCalle = dr("Em_calle").ToString
                        varEmiColonia = dr("Em_colonia").ToString
                        varEmiDelMun = dr("Em_Municipio").ToString
                        varEmiCP = dr("Em_CP").ToString
                        varExpedido = dr("Em_Pais").ToString
                        varEmiEdo = dr("Em_Estado").ToString
                        varEmiNumExt = dr("Em_NumExterior").ToString
                        varEmiNumInt = dr("Em_NumInterior").ToString
                    End If
                    cnn.Close()
                End If
            End With


            Dim varCadenaOriginal As String = "||" & varVersion & "|" & varUUIDFact & "|" & varFechaFolSATFact & "|" & varRFCProvFact & "|" & varSelloEmiFact & "|" & varSelloEmiFact & "|" & varCSDSatFact & "||"

            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If varexiste = 0 Then

                        sSQL = "insert into Facturas(nom_id_cliente,nom_razon_social,nom_rfc_empresa,nom_reg_fiscal," &
                        "nom_actividad_empresa,nom_calle_empresa,nom_colonia_empresa,nom_del_mun_empresa,nom_cp_empresa," &
                        "nom_expedido,estado_empresa,nom_nombre_cliente,nom_calle_cliente,nom_colonia_cliente,nom_del_mun_cliente," &
                        "nom_rfc_cliente,nom_folio,nom_fecha_factura,nom_metodo_pago,nom_tipo_pago,nom_folio_sat_uuid," &
                        "nom_fecha_folio_sat,nom_sello_emisor,nom_sello_sat,nom_cadena_original,nom_total_pagado,nom_no_csd_emp,nom_no_csd_sat," &
                        "estatus_fac,id_evento,n_ext_cliente,edo_cli,descripcion,descuento,iva,preciopaq,id_emisor,nom_mdescuento,fecha,UsoCFDI,nom_numcuenta,
                        nom_leyenda,nom_isr,nom_cpago,nom_status,CartaPorte,regfis_cliente,nom_numext_empresa,nom_numint_empresa,nom_ivaret) " &
                        "values(" & varClienteId & ",'" & varEmiRazonSocial & "','" & varEmiRFC & "','" & varEmiRegFiscal & "'," &
                        "'" & varEmiActEmpresa & "','" & varEmiCalle & "','" & varEmiColonia & "','" & varEmiDelMun & "','" & varEmiCP & "'," &
                        "'" & varExpedido & "','" & varEmiEdo & "','" & varClienteRazonSocial & "','" & varClienteCalle & "','" & varClienteColonia & "','" & varClienteDelMun & "'," &
                        "'" & varClienteRFC & "'," & varNumFolioFact & ",'" & varFechaFact & "','" & varFormaPagoFact & "','" & varMetPagoFact & "','" & varUUIDFact & "', " &
                        "'" & varFechaFolSATFact & "','" & varSelloEmiFact & "','" & varSelloSATFact & "','" & varCadenaOriginal & "','" & varTotalFact & "','" & varCSDEmpFact & "','" & varCSDSatFact & "'," &
                        "1," & varNumFolioFact & ",'" & varClienteNumExt & "','" & varClienteEdo & "'," & varNumFolioFact & "," & varDescuentoFact & "," & varIVAFact & "," & varSubTotalFact & "," & varEmiId &
                        ",'" & IIf(varDescuentoFact = "0", "0.00", varDescuentoFact) & "','" & Format(CDate(varFechaFact), "dd/MM/yyyy HH:mm:ss") & "','" & varUsoCFDI & "','','',0,'',1,0,'" & varClienteRegfis &
                        "','" & varEmiNumExt & "','" & varEmiNumInt & "',0)"

                        .runSp(cnn, sSQL, sinfo)

                        sSQL = "select Max(nom_id) as XD from Facturas"
                        If oData.getDr(cnn, dr, sSQL, sinfo) Then
                            varNumFolioFactId = dr("XD").ToString
                        End If
                    Else
                        sSQL = "select nom_id from Facturas where nom_folio = " & varNumFolioFact & ""
                        If oData.getDr(cnn, dr, sSQL, sinfo) Then
                            varNumFolioFactId = dr("nom_id").ToString
                        End If
                    End If
                    cnn.Close()
                End If
            End With

            Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector.Name = "cfdi:Concepto" Then
                            If Lector.HasAttributes Then
                                varCantConceptos += 1
                            End If
                        End If
                End Select
            Loop

            Dim varDesc(varCantConceptos) As String
            Dim varCodigoP(varCantConceptos) As String
            Dim varValUni(varCantConceptos) As String
            Dim varIdent(varCantConceptos) As String
            Dim varImporte(varCantConceptos) As String
            Dim varDescripcion(varCantConceptos) As String
            Dim varClaveUnidad(varCantConceptos) As String
            Dim varClaveProd(varCantConceptos) As String
            Dim varCant(varCantConceptos) As String
            Dim varIvaProd(varCantConceptos) As String
            Dim varIvaProdBase(varCantConceptos) As String
            Dim varIvaProdTC(varCantConceptos) As String
            Dim varIIEPSProd(varCantConceptos) As String
            Dim varIIEPSProdBase(varCantConceptos) As String
            Dim varIIEPSProdTC(varCantConceptos) As String

            Dim entraaconceptos As Integer = 0
            varCantConceptos = 0
            Dim pruebasumamsg As Double = 0

            Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                        If Lector.Name = "cfdi:Concepto" Then
                            If Lector.HasAttributes Then
                                If entraaconceptos >= 1 Then
                                    entraaconceptos = 0
                                    varCantConceptos += 1
                                End If

                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Descuento"
                                            varDesc(varCantConceptos) = Lector.Value
                                        Case "ValorUnitario"
                                            varValUni(varCantConceptos) = Lector.Value
                                        Case "NoIdentificacion"
                                            varIdent(varCantConceptos) = Lector.Value
                                        Case "Importe"
                                            varImporte(varCantConceptos) = Lector.Value
                                        Case "ClaveUnidad"
                                            varClaveUnidad(varCantConceptos) = Lector.Value
                                        Case "ClaveProdServ"
                                            varClaveProd(varCantConceptos) = Lector.Value
                                        Case "Cantidad"
                                            varCant(varCantConceptos) = Lector.Value
                                        Case "Descripcion"
                                            varDescripcion(varCantConceptos) = Lector.Value
                                            varCodigoP(varCantConceptos) = busca_codigo(CStr(Lector.Value))
                                    End Select
                                End While

                                If IsNothing(varDesc(varCantConceptos)) Then varDesc(varCantConceptos) = "0"
                                If IsNothing(varValUni(varCantConceptos)) Then varValUni(varCantConceptos) = "0"
                                If IsNothing(varIdent(varCantConceptos)) Then varIdent(varCantConceptos) = ""
                                If IsNothing(varImporte(varCantConceptos)) Then varImporte(varCantConceptos) = "0"
                                If IsNothing(varClaveUnidad(varCantConceptos)) Then varClaveUnidad(varCantConceptos) = ""
                                If IsNothing(varClaveProd(varCantConceptos)) Then varClaveProd(varCantConceptos) = ""
                                If IsNothing(varCant(varCantConceptos)) Then varCant(varCantConceptos) = "0"

                                entraaconceptos = 1
                            End If
                        End If

                        If Lector.Name = "cfdi:Traslado" Then
                            If Lector.HasAttributes And entraaconceptos < 3 Then
                                Dim newtasacuota As String = ""
                                Dim newimporte As String = ""
                                Dim newbase As String = ""
                                Dim newimpuesto As String = ""

                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Importe"
                                            newimporte = Lector.Value
                                        Case "Base"
                                            newbase = Lector.Value
                                        Case "TasaOCuota"
                                            newtasacuota = Lector.Value
                                        Case "Impuesto"
                                            newimpuesto = Lector.Value
                                    End Select
                                End While

                                If newimpuesto = "002" Then
                                    If newtasacuota = "0.160000" Then
                                        varIvaProd(varCantConceptos) = newimporte
                                        varIvaProdBase(varCantConceptos) = newbase
                                        varIvaProdTC(varCantConceptos) = CDec(newtasacuota) * 100
                                    Else
                                        varIvaProd(varCantConceptos) = 0
                                        varIvaProdBase(varCantConceptos) = newbase
                                        varIvaProdTC(varCantConceptos) = CDec(newtasacuota) * 100
                                    End If
                                ElseIf newimpuesto = "003" Then
                                    varIIEPSProd(varCantConceptos) = newimporte
                                    varIIEPSProdBase(varCantConceptos) = newbase
                                    varIIEPSProdTC(varCantConceptos) = newtasacuota
                                End If

                                If IsNothing(varIvaProd(varCantConceptos)) Then varIvaProd(varCantConceptos) = "0"
                                If IsNothing(varIvaProdBase(varCantConceptos)) Then varIvaProdBase(varCantConceptos) = "0"
                                If IsNothing(varIvaProdTC(varCantConceptos)) Then varIvaProdTC(varCantConceptos) = "0"
                                If IsNothing(varIIEPSProd(varCantConceptos)) Then varIIEPSProd(varCantConceptos) = "0"
                                If IsNothing(varIIEPSProdBase(varCantConceptos)) Then varIIEPSProdBase(varCantConceptos) = "0"
                                If IsNothing(varIIEPSProdTC(varCantConceptos)) Then varIIEPSProdTC(varCantConceptos) = "0.00"

                                entraaconceptos += 1
                            End If
                        End If
                End Select
            Loop

            Dim varhaydetalle As Integer = 0
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, "select Count(id_prod) as XD from detalle_factura where factura = " & varNumFolioFactId & "", sinfo) Then
                        If CInt(dr("XD").ToString) > 0 Then
                            varhaydetalle = CInt(dr("XD").ToString)
                        End If
                    End If
                    cnn.Close()
                End If
            End With

            Dim varCantConceptos2 As Integer = 0

            Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If
            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector.Name = "cfdi:Traslado" Then
                            If Lector.HasAttributes Then ' And entraaconceptos < 3
                                varCantConceptos2 += 1
                            End If
                        End If
                End Select
            Loop


            Dim varIIEPSProd2(varCantConceptos2) As String
            Dim varIIEPSProdBase2(varCantConceptos2) As String
            Dim varIIEPSProdTC2(varCantConceptos2) As String

            varCantConceptos2 = 0

            Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            If varrutabase <> "" Then
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
            End If
            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                        'If Lector.Name = "cfdi:Concepto" Then
                        '    If Lector.HasAttributes Then

                        '        varCantConceptos += 1

                        '    End If
                        'End If

                        If Lector.Name = "cfdi:Traslado" Then
                            If Lector.HasAttributes Then ' And entraaconceptos < 3
                                varCantConceptos2 += 1
                                Dim newtasacuota As String = ""
                                Dim newimporte As String = ""
                                Dim newbase As String = ""
                                Dim newimpuesto As String = ""

                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "Importe"
                                            newimporte = Lector.Value
                                        Case "Base"
                                            newbase = Lector.Value
                                        Case "TasaOCuota"
                                            newtasacuota = Lector.Value
                                        Case "Impuesto"
                                            newimpuesto = Lector.Value
                                    End Select
                                End While

                                If newimpuesto = "003" Then
                                    varIIEPSProd2(varCantConceptos2) = newimporte
                                    varIIEPSProdBase2(varCantConceptos2) = newbase
                                    varIIEPSProdTC2(varCantConceptos2) = newtasacuota
                                End If

                                If IsNothing(varIIEPSProd2(varCantConceptos2)) Then varIIEPSProd2(varCantConceptos2) = "0"
                                If IsNothing(varIIEPSProdBase2(varCantConceptos2)) Then varIIEPSProdBase2(varCantConceptos2) = "0"
                                If IsNothing(varIIEPSProdTC2(varCantConceptos2)) Then varIIEPSProdTC2(varCantConceptos2) = "0.00"
                            End If
                        End If
                End Select
            Loop

            If varhaydetalle = 0 Then
                Dim newtotalieps As Double = 0
                Dim newtotalivaret As Double = 0

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Dim banderaieps As Integer = 0

                Dim ieps160 As Decimal = 0
                Dim ieps53 As Decimal = 0
                Dim ieps5 As Decimal = 0
                Dim ieps304 As Decimal = 0
                Dim ieps3 As Decimal = 0
                Dim ieps265 As Decimal = 0
                Dim ieps25 As Decimal = 0
                Dim ieps09 As Decimal = 0
                Dim ieps08 As Decimal = 0
                Dim ieps07 As Decimal = 0
                Dim ieps06 As Decimal = 0
                Dim ieps03 As Decimal = 0

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                sinfo = ""
                With oData
                    For i = 0 To varCantConceptos
                        If .dbOpen(cnn, sTarget, sinfo) Then
                            sSQL = "insert into detalle_factura(id_prod,descripcion,unidad,cantidad," &
                                   "preciou,totaliva,porceniva,descuento,ret_iva," &
                                   "ieps,cliente,factura,totalsiva,orden,clvsat," &
                                   "isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc,FechaCad,LoteCad,ValorM,PesoKg,NumPed,UUIDComE,FracArancelaria) " &
                                   "values('" & varCodigoP(i) & "','" & varDescripcion(i) & "','" & varClaveUnidad(i) & "'," & varCant(i) & "," &
                                   "" & varValUni(i) & "," & CDec(varImporte(i)) + CDec(varIvaProd(i)) + CDec(varIIEPSProd(i)) & "," & varIvaProdTC(i) & "," & varDesc(i) & ",0," &
                                   "" & varIIEPSProd(i) & "," & varClienteId & "," & varNumFolioFactId & "," & varImporte(i) & "," & i + 1 & ",'" & varClaveProd(i) & "'," &
                                   "0,'" & varIIEPSProdTC(i) & "','" & IIf(CDec(varIIEPSProd(i)) > 0, "Tasa", "") & "','0','" & dameIP2() & "','','','','','','','')"
                            .runSp(cnn, sSQL, sinfo)
                            cnn.Close()

                            If IsNumeric(varIIEPSProd(i)) Then
                                If varIIEPSProd(i) > 0 Then
                                    newtotalieps = newtotalieps + CDec(varIIEPSProd(i))
                                End If
                            End If
                        End If
                    Next

                    'If .dbOpen(cnn, sTarget, sinfo) Then
                    '    sSQL = "update Facturas set nom_mdescuento = '" & FormatNumber(newtotalieps, 2) & "' where nom_id = " & varNumFolioFactId & "" 'nom_isr ,
                    '    .runSp(cnn, sSQL, sinfo)
                    '    cnn.Close()
                    'End If

                End With

                Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                Dim sinfo2 As String = ""
                Dim dt2 As New DataTable
#Disable Warning BC42024 ' Variable local sin usar: 'dr2'.
                Dim dr2 As DataRow
#Enable Warning BC42024 ' Variable local sin usar: 'dr2'.
                Dim odata2 As New ToolKitSQL.myssql

                If newtotalieps > 0 Then
                    sinfo2 = ""
                    dt2 = New DataTable
                    odata2 = New ToolKitSQL.myssql
                    With odata2
                        If .dbOpen(cnn2, sTarget, sinfo2) Then
                            For i = 0 To varCantConceptos2
                                Select Case varIIEPSProdTC2(i)
                                    Case "0.030000"
                                        ieps03 = CDec(varIIEPSProd2(i)) 'ieps03 + CDec(varIIEPSProd2(i))
                                    Case "0.060000"
                                        ieps06 = CDec(varIIEPSProd2(i)) 'ieps06 + CDec(varIIEPSProd2(i))
                                    Case "0.070000"
                                        ieps07 = CDec(varIIEPSProd2(i)) 'ieps07 + CDec(varIIEPSProd2(i))
                                    Case "0.080000"
                                        ieps08 = CDec(varIIEPSProd2(i)) 'ieps08 + CDec(varIIEPSProd2(i))
                                    Case "0.090000"
                                        ieps09 = CDec(varIIEPSProd2(i)) 'ieps09 + CDec(varIIEPSProd2(i))
                                    Case "0.250000"
                                        ieps25 = CDec(varIIEPSProd2(i)) 'ieps25 + CDec(varIIEPSProd2(i))
                                    Case "0.265000"
                                        ieps265 = CDec(varIIEPSProd2(i)) 'ieps265 + CDec(varIIEPSProd2(i))
                                    Case "0.300000"
                                        ieps3 = CDec(varIIEPSProd2(i)) 'ieps3 + CDec(varIIEPSProd2(i))
                                    Case "0.304000"
                                        ieps304 = CDec(varIIEPSProd2(i)) 'ieps304 + CDec(varIIEPSProd2(i))
                                    Case "0.500000"
                                        ieps5 = CDec(varIIEPSProd2(i)) 'ieps5 + CDec(varIIEPSProd2(i))
                                    Case "0.530000"
                                        ieps53 = CDec(varIIEPSProd2(i)) 'ieps53 + CDec(varIIEPSProd2(i))
                                    Case "1.600000"
                                        ieps160 = CDec(varIIEPSProd2(i)) 'ieps160 + CDec(varIIEPSProd2(i))
                                End Select
                            Next

                            newtotalieps = 0

                            If ieps160 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                   "values(" & ieps160 & "," & varNumFolioFactId & ",'1.600000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps160
                            End If
                            If ieps53 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps53 & "," & varNumFolioFactId & ",'0.530000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps53
                            End If
                            If ieps5 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps5 & "," & varNumFolioFactId & ",'0.500000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps5
                            End If
                            If ieps304 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps304 & "," & varNumFolioFactId & ",'0.304000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps304
                            End If
                            If ieps3 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps3 & "," & varNumFolioFactId & ",'0.300000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps3
                            End If
                            If ieps265 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps265 & "," & varNumFolioFactId & ",'0.265000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps265
                            End If
                            If ieps25 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps25 & "," & varNumFolioFactId & ",'0.250000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps25
                            End If
                            If ieps09 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps09 & "," & varNumFolioFactId & ",'0.090000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps09
                            End If
                            If ieps08 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps08 & "," & varNumFolioFactId & ",'0.080000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps08
                            End If
                            If ieps07 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps07 & "," & varNumFolioFactId & ",'0.070000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps07
                            End If
                            If ieps06 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps06 & "," & varNumFolioFactId & ",'0.060000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps06
                            End If
                            If ieps03 > 0 Then
                                sSQL = "insert into detalle_factura_aux(ieps,factura,ieps_porcentaje,ieps_TasaoCuota) " &
                                  "values(" & ieps03 & "," & varNumFolioFactId & ",'0.030000','Tasa')"
                                .runSp(cnn2, sSQL, sinfo)
                                newtotalieps += ieps03
                            End If
                            cnn2.Close()

                            If .dbOpen(cnn, sTarget, sinfo) Then
                                sSQL = "update Facturas set nom_mdescuento = '" & FormatNumber(newtotalieps, 2) & "' where nom_id = " & varNumFolioFactId & "" 'nom_isr ,
                                .runSp(cnn, sSQL, sinfo)
                                cnn.Close()
                            End If
                        End If
                    End With
                End If
            End If
        End If
#Disable Warning BC42105 ' La función 'consultaxml' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'consultaxml' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Function busca_codigo(ByVal vardesc As String) As String
        Dim sSQL As String = "Select Codigo from Productos where Nombre='" & vardesc & "'"
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                cnn.Close()
                Return dr(0).ToString
            End If
            cnn.Close()
            Return ""
        End If
#Disable Warning BC42105 ' La función 'busca_codigo' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'busca_codigo' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub Btt_Nuevo_Click(sender As Object, e As EventArgs) Handles Btt_Nuevo.Click
        limpia_campos()

        txtUUID.Text = ""
        cboTipoRelacion.SelectedIndex = -1

        cboFolio.SelectedValue = -1
        dgUUID.Rows.Clear()

        Text_Descuento.Text = ""
        txtNotaVenta.Text = ""
        Cmb_RazonS.Text = ""
        Cmb_RFC.Text = ""
        Cmb_TipoFact.Text = "FACTURA"
        lbl_estatus.Text = "Estatus"
        'Cmb_RazonS.SelectedValue = -1
        'Cmb_RFC.SelectedValue = -1
        limpia_empresa()
        limpia_prod()
        busca_Foliofact()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                .runSp(cnn, "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'", sinfo)
                cnn.Close()
            End If
        End With

        GroupBox7.Visible = False
        btnGlobal.Enabled = False
        dtpDesde.Value = Today
        dtpHasta.Value = Today
        lbl_estatus.Text = "Estatus"

        Dim ssql10 As String = ""
        ssql10 = "Delete from Facturas where nom_folio_sat_uuid is null"
        Dim cnn10 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo10 As String = ""
        Dim odata10 As New ToolKitSQL.myssql
        If odata10.dbOpen(cnn10, sTarget, sinfo10) Then
            If odata10.runSp(cnn10, ssql10, sinfo10) Then
            Else
                'MsgBox(sinfo)
            End If
            cnn10.Close()
        Else
            'MsgBox(sinfo)
        End If

        ssql10 = "Delete from Facturas where nom_folio_sat_uuid = ''"
        sinfo10 = ""
        If odata10.dbOpen(cnn10, sTarget, sinfo10) Then
            If odata10.runSp(cnn10, ssql10, sinfo10) Then
            Else
                'MsgBox(sinfo)
            End If
            cnn10.Close()
        Else
            'MsgBox(sinfo)
        End If

        llenaFolioUUID()

        PictureBox2.Image = Nothing
        btnParcialidades.Enabled = False

        cbometodo_pago.SelectedValue = "01"

        cadena_pagos1 = ""

        Text_Descuento.Text = "0"
        TextBox1.Text = "0.00"

        chkInter.Checked = False
        GroupBox13.Visible = False
        GroupBox19.Visible = False

        txtAseguradora.Text = ""
        txtNumPoliza.Text = ""
        txtModeloAño.Text = ""
        txtNumPermisoSCT.Text = ""
        txtPlaca.Text = ""
        cboConfigV.Text = ""
        cboPermisoSCT.Text = ""

        cboOrigRemitente.Text = ""
        txtOrigRFC.Text = ""
        dtpOrigFecha.Text = Date.Now
        dtpOrigHora.Text = "00:00:00"
        txtOrigCP.Text = ""
        txtOrigCalle.Text = ""
        txtOrigNumExt.Text = ""
        txtOrigNumInt.Text = ""
        cboOrigColonia.Text = ""
        cboOrigEdo.Text = ""
        cboOrigMun.Text = ""

        cboDesDestinatario.Text = ""
        txtDesRFC.Text = ""
        dtpDesFecha.Text = Date.Now
        dtpDesHora.Text = "00:00:00"
        txtDestinoCP.Text = ""
        cboDestinoPais.Text = ""
        txtDestinoCalle.Text = ""
        txtDestinoNumE.Text = ""
        txtDestinoNumI.Text = ""
        cboDestinoColonia.Text = ""
        cboDestinoEdo.Text = ""
        cboDestinoMun.Text = ""
        txtDestinioDist.Text = ""
        txtDestinoLoc.Text = ""

        cboTipoFigura.Text = ""
        cboOpeNombre.Text = ""
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""


        cboDescripcion.Text = ""
        txtValorMerc.Text = ""
        txtPesoKG.Text = ""
        txtTotalPeso.Text = ""
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
        txtNumPed1.Text = ""
        txtNumPed2.Text = ""
        txtNumPed3.Text = ""
        txtNumPed4.Text = ""

        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = ""

        txtPartidaNew.Text = ""

        dgProductos.Rows.Clear()

        CheckBox2.Checked = False
        btnComplementoCP.Enabled = False
        GroupBox9.Visible = False

        cbo_regimen.SelectedValue = 0
        cbo_regimen.Text = ""

        cboPeriodicidad.Text = ""
        cboPeriodicidad.SelectedIndex = -1
        cboMeses.Text = ""
        cboMeses.SelectedIndex = -1
        txtAno.Text = Format(Today, "yyyy")

        chkMatPeg.Checked = False
        cboMatPeligroso.Text = ""
        cboEmbalaje.Text = ""

        txtAseguradoraMatPel.Text = ""
        txtNumPolizaMatPel.Text = ""

        chkAumentarISR.Checked = False
        txtISR.Text = ""

        limpia_lugarexp()

        gbLE.Visible = False
    End Sub


    Private Sub Btt_Cancelar_Click(sender As Object, e As EventArgs) Handles Btt_Cancelar.Click
        GroupBox20.Visible = True
        cboTipoCancelacion.Focus()
        'busca_d()
        'cancela(uidcancel, refccancel, Cmb_Nfactura.Text)
    End Sub

    Private Sub busca_d()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from Facturas where nom_id=" & Cmb_Nfactura.SelectedValue
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    uidcancel = dr("nom_folio_sat_uuid").ToString
                    refccancel = dr("nom_rfc_empresa").ToString
                Else
                    ''MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub actualiza_cliente()
        Dim client As Integer = 0
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            client = dame_IdClienteRS(Cmb_RazonS.Text)
        End If
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from datos_clientes where cli_rfc='" & Cmb_RFC.Text & "' "
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    If dr("cli_id").ToString > 0 Then
                        Dim ssql2 As String = "Update datos_clientes set cli_razon_social='" & Cmb_RazonS.Text & "',cli_calle='" & Text_calle.Text &
                                           "', cli_num_ext='" & Text_Num_Ex.Text & "', cli_num_int='" & Txt_num_int.Text & "', cli_cp='" & Text_CP.Text &
                                           "', cli_colonia='" & Text_Colonia.Text & "', cli_delegacion='" & Text_Delegacion.Text & "', cli_estado='" & Text_Edo.Text &
                                           "', cli_pais='" & Text_Pais.Text & "', cli_contacto_mail='" & Text_Email.Text & "', cli_nombre_comercial='" & txt_nombrec.Text & "' where cli_id=" & dr("cli_id").ToString
                        oData.runSp(cnn, ssql2, sinfo)
                    Else
                        Dim ssql2 As String = "insert into datos_clientes (cli_razon_social,cli_calle,cli_num_ext,cli_num_int,cli_num_int,cli_cp,cli_colonia,cli_delegacion,cli_estado,cli_pais,cli_contacto_mail)values('" &
                                             Cmb_RazonS.Text & "','" & Text_calle.Text & "', '" & Text_Num_Ex.Text & "', '" & Txt_num_int.Text & "', '" & Text_CP.Text &
                                          "', '" & Text_Colonia.Text & "', '" & Text_Delegacion.Text & "', '" & Text_Edo.Text &
                                          "', '" & Text_Pais.Text & "', '" & Text_Email.Text & "')"
                        oData.runSp(cnn, ssql2, sinfo)
                    End If
                Else
                    Dim ssql2 As String = "insert into datos_clientes (cli_razon_social,cli_nombre_comercial,cli_calle,cli_num_ext,cli_num_int,cli_cp,cli_colonia,cli_delegacion,cli_estado,cli_pais,cli_contacto_mail,cli_rfc)values('" &
                                             Cmb_RazonS.Text & "','" & txt_nombrec.Text & "','" & Text_calle.Text & "', '" & Text_Num_Ex.Text & "', '" & Txt_num_int.Text & "', '" & Text_CP.Text &
                                          "', '" & Text_Colonia.Text & "', '" & Text_Delegacion.Text & "', '" & Text_Edo.Text &
                                          "', '" & Text_Pais.Text & "', '" & Text_Email.Text & "','" & Cmb_RFC.Text & "')"
                    oData.runSp(cnn, ssql2, sinfo)
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub busca_cliente()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from datos_clientes where cli_rfc='" & Cmb_RFC.Text & "' "
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    var_cliente = dr("cli_id").ToString
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub actualiza_detalle_temp()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "update detalle_Factura set cliente=" & var_cliente & " where cliente=0"
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .runSp(cnn, sSQL, sinfo) Then
                Else
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub Cmb_RFC_DropDown(sender As Object, e As EventArgs) Handles Cmb_RFC.DropDown
        Cmb_RFC.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RFC from Clientes where RazonSocial <> '' and RFC <> '' order by RazonSocial"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        Cmb_RFC.Items.Add(dr("RFC").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub Cmb_RFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_RFC.KeyPress
        If e.KeyChar = ChrW(13) Then
            If Cmb_RFC.Text <> "" Then
                If dame_IdClienteRFC(Cmb_RFC.Text) = 0 Then MsgBox("El RFC del Cliente no existe hay que registrarlo en el catálogo de clientes") : Exit Sub
                abrir()
                Dim comando1 As MySqlClient.MySqlCommand
                comando1 = conexion.CreateCommand
                comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
                comando1.ExecuteNonQuery()
                conexion.Close()

                Cmb_RazonS.Text = dame_RS_Cliente(Cmb_RFC.Text)
                var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                muestra_datos_cliente()

                limpia_prod()

                If Cmb_RFC.Text = "XAXX010101000" Then
                    btnGlobal.Enabled = True
                Else
                    btnGlobal.Enabled = False
                End If
            End If
            Text_calle.Focus()
        End If
    End Sub

    Function dame_RS_Cliente(ByVal varRFC As String) As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RazonSocial from Clientes where RFC = '" & varRFC & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    cnn.Close()
                    Return dr("RazonSocial").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
            End If
        End With
#Disable Warning BC42105 ' La función 'dame_RS_Cliente' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dame_RS_Cliente' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Function dame_IdClienteRFC(ByVal varRFC As String) As Integer
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select Id from Clientes where RFC = '" & varRFC & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    cnn.Close()
                    Return CInt(dr("Id").ToString)
                Else
                    cnn.Close()
                    Return 0
                End If
            End If
        End With
#Disable Warning BC42353 ' La función 'dame_IdClienteRFC' no devuelve un valor en todas las rutas de acceso de código. ¿Falta alguna instrucción 'Return'?
    End Function
#Enable Warning BC42353 ' La función 'dame_IdClienteRFC' no devuelve un valor en todas las rutas de acceso de código. ¿Falta alguna instrucción 'Return'?

    Private Sub Cmb_RFC_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_RFC.SelectedValueChanged
        On Error GoTo malo

        abrir()
        Dim comando1 As MySqlClient.MySqlCommand
        comando1 = conexion.CreateCommand
        comando1.CommandText = "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'"
        comando1.ExecuteNonQuery()
        conexion.Close()

        Cmb_RazonS.Text = dame_RS_Cliente(Cmb_RFC.Text)
        var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
        muestra_datos_cliente()
        limpia_prod()
        If Cmb_RFC.Text = "XAXX010101000" Then
            btnGlobal.Enabled = True
        Else
            btnGlobal.Enabled = False
        End If
malo:
    End Sub

    Private Sub Cmb_RazonS_TextChanged(sender As Object, e As EventArgs) Handles Cmb_RazonS.TextChanged
        If Cmb_RazonS.Text = "" Then
            limpia_empresa()
            Cmb_RFC.Text = ""
        End If
    End Sub

    Private Sub Cmb_RFC_TextChanged(sender As Object, e As EventArgs) Handles Cmb_RFC.TextChanged
        If Cmb_RFC.Text = "" Then
            limpia_empresa()
            Cmb_RazonS.Text = ""
        End If
    End Sub

    Private Sub cbometodo_pago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbometodo_pago.KeyPress
        'Dim exist As Boolean = False
        'If cbometodo_pago.Text <> "" Then
        If Asc(e.KeyChar) = Keys.Enter Then
            'If grid_metodos.Rows.Count > 0 Then grid_metodos.Rows.Clear() : grid_metodos.Rows.Insert(grid_metodos.Rows.Count, cbometodo_pago.SelectedValue, cbometodo_pago.Text) : Exit Sub
            'For i = 0 To grid_metodos.Rows.Count - 1
            '    If grid_metodos.Rows(i).Cells(0).Value.ToString = cbometodo_pago.SelectedValue Then
            '        exist = True
            '    End If
            'Next

            'If exist = False Then
            '    grid_metodos.Rows.Insert(grid_metodos.Rows.Count, cbometodo_pago.SelectedValue, cbometodo_pago.Text)
            'End If
            Btt_Generar.Focus()
        End If
        'End If
    End Sub

    Private Sub duplica_detalle()
        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
            var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
        Else
            var_cliente = 0
        End If

        'If Cmb_RazonS.SelectedValue > 0 Then
        '    var_cliente = Cmb_RazonS.SelectedValue
        'Else
        '    var_cliente = 0
        'End If

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim ssqlx As String = "Delete from detalle_factura where factura=0 and ip_loc = '" & numero_MAC & "'"
        Dim sSQL As String = "Select * from detalle_factura where factura=" & Cmb_Nfactura.SelectedValue & " order by orden"
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        Dim contador As Integer = 1
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .runSp(cnn, ssqlx, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If dr("orden").ToString > 0 Then
                                contador = dr("orden").ToString
                            End If

                            Dim unidadcivad As Double = obtienepiva(CDbl(dr("preciou").ToString), CDbl(dr("porceniva").ToString))
                            Dim var_totalcivad As Double = unidadcivad * CDbl(dr("cantidad").ToString)

                            '  grid_prods.Rows.Insert(var1, dr("id_prod").ToString, dr("descripcion").ToString, dr("unidad").ToString, dr("cantidad").ToString, dr("preciou").ToString, dr("totalsiva").ToString, unidadcivad, var_totalcivad, dr("porceniva").ToString, dr("descuento").ToString, dr("ret_iva").ToString, dr("ieps").ToString, dr("descripcion_larga").ToString)

                            Dim ssql3 As String = "INSERT INTO detalle_factura (id_prod, descripcion,descripcion_larga, Unidad, cantidad, preciou, totaliva , porceniva" &
              " , descuento, ret_iva, ieps,  cliente, factura, totalsiva " &
              ", orden,clvsat) values('" & dr("id_prod").ToString & "', '" & dr("descripcion").ToString & "','" & dr("descripcion_larga").ToString & "','" & dr("unidad").ToString & "'," & dr("cantidad").ToString & "," & Replace(dr("preciou").ToString, ",", "") &
              " , " & Replace(var_totalcivad, ",", "") & "," & dr("porceniva").ToString & ", " & Replace(dr("descuento").ToString, ",", "") & " ," & dr("ret_iva").ToString &
              "," & dr("ieps").ToString & ", " & var_cliente & ", 0, " & Replace(dr("totalsiva").ToString, ",", "") & "," & contador & ",'" & dr("clvsat").ToString & "')"
                            oData.runSp(cnn, ssql3, sinfo)
                        Next
                        ' MsgBox("Copia Lista Seleccione el tipo de Archivo ")
                    Else
                        ''MsgBox(sinfo)
                    End If
                End If
                cnn.Close()
            Else
                '  'MsgBox(sinfo)
            End If
        End With
    End Sub

    Private Sub cbo_emisor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_emisor.SelectedIndexChanged
        serie()
        bfoliofac()
        Cmb_Nfactura.Text = var_folio
    End Sub

    Private Sub txt_prodsat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_prodsat.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            If valida_producto() Then
                buscappp()
                agrega_prod()
                'llena_cbo_descripcionticket()
                limpia_prod()
            End If
            Text_FormaPago.Focus()
        End If
    End Sub

    Private Sub txtNotaVenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNotaVenta.KeyPress
        If e.KeyChar = ChrW(13) Then
            If txtNotaVenta.Text = "" Then Exit Sub

            Dim Banderaglobal As Integer = 0
            Dim rdPrueba As MySqlClient.MySqlDataReader
            Dim comandPrueba As MySqlClient.MySqlCommand
            Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn1, sTarget, sinfo) Then
                    If .getDr(cnn1, dr, "Select NumPart from Formatos where Facturas = 'SHIBBOLETH'", sinfo) Then
                        If CDec(dr(0).ToString) = 1 Then
                            Banderaglobal = 1
                        End If
                    End If
                    cnn1.Close()
                End If
            End With

            If Cmb_RFC.Text = "XAXX010101000" Then
                If Banderaglobal = 1 Then
                    GoTo puerta_FacturaG
                End If

                sumatoriaIEPS = 0

                cnn1 = New MySqlClient.MySqlConnection
                sinfo = ""
                odata = New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn1, sTarget, sinfo) Then
                        .runSp(cnn1, "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'", sinfo)
                        cnn1.Close()
                    End If
                End With

                Text_SubTotal.Text = ""
                var1 = 0
                txt_partida.Text = "1"
                Text_Descuento.Text = "0"
                txt_impuestos.Text = "0"
                Text_IVARET.Text = "0"
                Text_IVA.Text = "0"
                conexion.Close()
                Dim vartot As Double = 0
                For i = 0 To grid_prods.Rows.Count
                    grid_prods.Rows().Clear()
                Next

                Dim str As String = ""
                Dim str1(15000) As String
                For xd = 0 To 500
                    For xd1 = 0 To 500
                        ArreIeps(xd, xd1) = ""
                    Next
                Next

                For xd = 0 To 500
                    For xd1 = 0 To 500
                        ArreIepsBase(xd, xd1) = ""
                    Next
                Next

                Dim contarray As Integer = 0
                For x = 1 To txtNotaVenta.TextLength
                    str = Mid$(txtNotaVenta.Text, x, 1)
                    If str = "," Then
                        contarray = contarray + 1
                    Else
                        str1(contarray) = str1(contarray) & str
                    End If
                Next

                Dim maxcontador As Integer = 0
                Dim contadorIeps As Integer = 0
                Dim contadorMatriz As Integer = 0
                Dim banderacontador As Integer = 0
                Dim banderaArrays As Integer = 0
                strconjunto = ""

                For x1 = 0 To contarray

                    cnn1 = New MySqlClient.MySqlConnection
                    sinfo = ""
                    dt = New DataTable
                    odata = New ToolKitSQL.myssql
                    With odata
                        If .dbOpen(cnn1, sTarget, sinfo) Then
                            If .getDr(cnn1, dr, "Select Facturado from Ventas where Folio = " & str1(x1) & "", sinfo) Then
                                If CStr(dr(0).ToString) <> "0" Then
                                    MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                    cnn1.Close()
                                    GoTo puerta2
                                End If
                            End If
                            cnn1.Close()
                        End If
                    End With

                    Dim montoIeps As Decimal = 0
                    Dim porcentaIeps As Decimal = 0
                    Dim TotalIeps As Decimal = 0
                    Dim strCompara As String = ""
                    If banderacontador = 1 Then contadorMatriz += 1 : banderacontador = 0

                    cnn1 = New MySqlClient.MySqlConnection
                    sinfo = ""
                    dt = New DataTable
                    odata = New ToolKitSQL.myssql
                    With odata
                        If .dbOpen(cnn1, sTarget, sinfo) Then
                            If .getDt(cnn1, dt, "Select * from Ventas where Folio = " & str1(x1) & " and Totales > 0 and Status <> 'CANCELADA'", sinfo) Then
                                For Each dr In dt.Rows
                                    sumaprodConIva = 0
                                    sumaprodSinIva = 0
                                    montoIeps = 0
                                    TotalIeps = 0
                                    contadorIeps = 0

                                    Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                                    sinfo = ""
                                    Dim dt2 As New DataTable
                                    Dim dr2 As DataRow
                                    With odata
                                        If .dbOpen(cnn2, sTarget, sinfo) Then
                                            If .getDt(cnn2, dt2, "Select * from VentasDetalle where Folio = " & str1(x1) & " order by TasaIeps", sinfo) Then
                                                For Each dr2 In dt2.Rows
                                                    If dr2("TasaIeps").ToString <> 0 Then If strCompara <> CStr(dr2("TasaIeps").ToString & ",") Then strCompara &= dr2("TasaIeps").ToString & ","
                                                    If FormatNumber(CDec(dr2("Total").ToString), 6) <> FormatNumber(CDec(dr2("TotalSinIVA").ToString), 6) Then
                                                        If dr2("TasaIeps").ToString <> 0 Then montoIeps += FormatNumber(CDec(CDec(CDec(dr2("Total").ToString) / 1.16) / CDec(1 + CDec(dr2("TasaIeps").ToString))) * dr2("TasaIeps").ToString, 6) : porcentaIeps = FormatNumber(CDec(dr2("TasaIeps").ToString), 6)
                                                        If dr2("TasaIeps").ToString <> 0 Then TotalIeps += FormatNumber(CDec(CDec(dr2("Total").ToString) / 1.16) / CDec(1 + CDec(dr2("TasaIeps").ToString)), 6)
                                                        If dr2("TasaIeps").ToString <> 0 Then ArreIeps(contadorMatriz, contadorIeps) = CDec(dr2("TasaIeps").ToString) : ArreIepsBase(contadorMatriz, contadorIeps) = FormatNumber(CDec(CDec(dr2("Total").ToString) / 1.16) / CDec(1 + CDec(dr2("TasaIeps").ToString)), 6) : contadorIeps += 1 : banderacontador = 1
                                                    Else
                                                        If dr2("TasaIeps").ToString <> 0 Then montoIeps += FormatNumber(CDec(CDec(dr2("Total").ToString) / CDec(1 + CDec(dr2("TasaIeps").ToString))) * dr2("TasaIeps").ToString, 6) : porcentaIeps = FormatNumber(CDec(dr2("TasaIeps").ToString), 6)
                                                        If dr2("TasaIeps").ToString <> 0 Then TotalIeps += FormatNumber(CDec(dr2("Total").ToString) / CDec(1 + CDec(dr2("TasaIeps").ToString)), 6)
                                                        If dr2("TasaIeps").ToString <> 0 Then ArreIeps(contadorMatriz, contadorIeps) = CDec(dr2("TasaIeps").ToString) : ArreIepsBase(contadorMatriz, contadorIeps) = FormatNumber(CDec(dr2("Total").ToString) / CDec(1 + CDec(dr2("TasaIeps").ToString)), 6) : contadorIeps += 1 : banderacontador = 1
                                                    End If
                                                    If maxcontador < contadorIeps Then maxcontador = contadorIeps
                                                    If FormatNumber(CDec(dr2("Total").ToString), 6) <> FormatNumber(CDec(dr2("TotalSinIVA").ToString), 6) Then
                                                        sumaprodConIva += FormatNumber(CDec(dr2("Total").ToString) / 1.16, 6)
                                                    Else
                                                        sumaprodSinIva += FormatNumber(dr2("Total").ToString, 6)
                                                    End If
                                                Next
                                                If banderacontador = 1 Then banderaArrays += 1
                                            Else
                                                If CDec(dr("IVA").ToString) = CDec(0) Then
                                                    sumaprodSinIva += FormatNumber(dr("Totales").ToString, 6)
                                                Else
                                                    sumaprodConIva += FormatNumber(CDec(dr("Totales").ToString) / 1.16, 6)
                                                End If
                                            End If
                                            cnn2.Close()
                                        End If
                                    End With

                                    If CInt(dr("Descuento").ToString) <> 0 Then
                                        If dr("Facturado").ToString <> "0" Then
                                            MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                            GoTo puerta2
                                        End If

                                        strconjunto = strCompara

                                        If strconjunto <> "" Then
                                            If Mid(strconjunto, Len(strconjunto), Len(strconjunto)) = "," Then strconjunto = CStr(Mid(strconjunto, 1, Len(strconjunto) - 1))
                                        End If

                                        If CDec(dr("IVA").ToString) = CDec(0) Then
                                            grid_prods.Rows.Insert(var1, "", "Venta", "ACT", "1", FormatNumber(CDec(FormatNumber(CDec(dr("Totales").ToString), 6)) + CDec(dr("Descuento").ToString) - CDec(montoIeps), 6), FormatNumber(CDec(FormatNumber(CDec(dr("Totales").ToString), 6)) + CDec(dr("Descuento").ToString) - CDec(montoIeps), 6), FormatNumber(CDec(dr("Totales").ToString), 6), FormatNumber(CDec(dr("Totales").ToString), 6), "0", FormatNumber(dr("Descuento").ToString, 2), "0", montoIeps, str1(x1), CStr(txt_partida.Text), "01010101", "0", porcentaIeps, IIf(montoIeps = "0", "", "Tasa"), "0", sumaprodConIva, TotalIeps, strconjunto)
                                        Else
                                            grid_prods.Rows.Insert(var1, "", "Venta", "ACT", "1", FormatNumber(CDec(FormatNumber((CDec(dr("Totales").ToString) - CDec(FormatNumber(sumaprodConIva * 0.16, 6))), 6)) + CDec(dr("Descuento").ToString), 6), FormatNumber(CDec(FormatNumber((CDec(dr("Totales").ToString) - CDec(FormatNumber(sumaprodConIva * 0.16, 6))), 6)) + CDec(dr("Descuento").ToString), 6), FormatNumber((FormatNumber(CDec(dr("Totales").ToString), 6)), 6), FormatNumber((FormatNumber(CDec(dr("Totales").ToString), 6)), 6), "16", FormatNumber(dr("Descuento").ToString, 2), "0", montoIeps, str1(x1), CStr(txt_partida.Text), "01010101", "0", porcentaIeps, IIf(montoIeps = "0", "", "Tasa"), "0", sumaprodConIva, TotalIeps, strconjunto)
                                        End If

                                        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
                                            var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                                        Else
                                            var_cliente = 0
                                        End If

                                        var1 = CDec(var1) + 1
                                        txt_partida.Text = CDec(txt_partida.Text) + 1

                                    Else

                                        If dr("Facturado").ToString <> "0" Then
                                            MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                            GoTo puerta2
                                        End If

                                        strconjunto = strCompara

                                        If strconjunto <> "" Then
                                            If Mid(strconjunto, Len(strconjunto), Len(strconjunto)) = "," Then strconjunto = CStr(Mid(strconjunto, 1, Len(strconjunto) - 1))
                                        End If

                                        If CDec(dr("IVA").ToString) = CDec(0) Then
                                            grid_prods.Rows.Insert(var1, "", "Venta", "ACT", "1", FormatNumber(CDec(dr("Subtotal").ToString) - montoIeps, 6), FormatNumber(CDec(dr("Subtotal").ToString) - montoIeps, 6), FormatNumber(FormatNumber(CDec(dr("Subtotal").ToString) - montoIeps, 6), 6), FormatNumber(FormatNumber(CDec(dr("Subtotal").ToString) - montoIeps, 6), 6), "0", FormatNumber(dr("Descuento").ToString, 2), "0", FormatNumber(montoIeps, 2), str1(x1), CStr(txt_partida.Text), "01010101", "0", porcentaIeps, IIf(montoIeps = "0", "", "Tasa"), "0", sumaprodConIva, TotalIeps, strconjunto)
                                        Else
                                            grid_prods.Rows.Insert(var1, "", "Venta", "ACT", "1", FormatNumber(CDec(dr("Totales").ToString) - CDec(FormatNumber(sumaprodConIva * 0.16, 6)), 6) - montoIeps, FormatNumber(CDec(dr("Totales").ToString) - CDec(FormatNumber(sumaprodConIva * 0.16, 6)), 6) - montoIeps, FormatNumber(dr("Totales").ToString, 6), FormatNumber(dr("Totales").ToString, 6), "16", FormatNumber(dr("Descuento").ToString, 2), "0", FormatNumber(montoIeps, 2), str1(x1), CStr(txt_partida.Text), "01010101", "0", porcentaIeps, IIf(montoIeps = "0", "", "Tasa"), "0", sumaprodConIva, TotalIeps, strconjunto)
                                        End If

                                        If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
                                            var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                                        Else
                                            var_cliente = 0
                                        End If

                                        var1 = CDec(var1) + 1
                                        txt_partida.Text = CDec(txt_partida.Text) + 1
                                    End If
                                Next
                            End If
                            cnn1.Close()
                        End If
                    End With
puerta2:
                Next

                My.Application.DoEvents()

                Dim vart As Double = 0
                Dim vart1 As Double = 0
                Dim sumaIeps As Double = 0
                Dim sumaIvaRet As Double = 0
                Dim sumaSubT As Decimal = 0
                Dim sumDesc As Decimal = 0
                For x = 0 To grid_prods.Rows.Count - 1
                    If Convert.ToDouble(grid_prods.Rows(x).Cells("Column4").Value) > 0 Then
                        sumaSubT += Convert.ToDouble(grid_prods.Rows(x).Cells("Total").Value) 'Total
                        vart1 = vart1 + FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("FactGlobal").Value), 6)
                    Else
                        sumaSubT += FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("Total").Value), 6) 'Total
                        vart1 = vart1 + 0
                    End If
                    sumDesc += CDec(Convert.ToDouble(grid_prods.Rows(x).Cells(9).Value))
                    If CDec(Convert.ToDouble(grid_prods.Rows(x).Cells("Column4").Value)) > 0 Then
                        vart = vart + Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value)
                    Else
                        vart = vart + Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value) + Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value)
                    End If
                    sumaIeps = FormatNumber(CDec(sumaIeps) + FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value), 6), 6)
                    sumaIvaRet += Convert.ToDouble(grid_prods.Rows(x).Cells("Column6").Value)
                Next
                vart1 = FormatNumber(vart1 * 0.16, 2)
                Text_SubTotal.Text = FormatNumber(sumaSubT, 2)
                Text_Descuento.Text = FormatNumber(sumDesc, 2)
                TextBox1.Text = FormatNumber(CDec(Text_SubTotal.Text) - CDec(Text_Descuento.Text), 2)
                Text_IVA.Text = FormatNumber(vart1, 2)
                Text_IVARET.Text = FormatNumber(sumaIvaRet, 2)
                txt_impuestos.Text = FormatNumber(sumaIeps, 2)
                txtISR.Text = FormatNumber(0, 2)
                Text_TOTAL.Text = FormatNumber(CDec(TextBox1.Text) + CDec(Text_IVA.Text) + CDec(txt_impuestos.Text) - CDec(Text_Descuento.Text) - CDec(Text_IVARET.Text), 2)

                Dim sumatoriavar265 As Decimal = 0
                Dim sumatoriavar30 As Decimal = 0
                Dim sumatoriavar53 As Decimal = 0
                Dim sumatoriavar50 As Decimal = 0
                Dim sumatoriavar160 As Decimal = 0
                Dim sumatoriavar304 As Decimal = 0
                Dim sumatoriavar25 As Decimal = 0
                Dim sumatoriavar9 As Decimal = 0
                Dim sumatoriavar8 As Decimal = 0
                Dim sumatoriavar7 As Decimal = 0
                Dim sumatoriavar6 As Decimal = 0
                Dim sumatoriavar3 As Decimal = 0

                If CDec(txt_impuestos.Text) > 0 Then
                    For xd = 0 To contadorMatriz
                        var265(xd) = 0
                        var3(xd) = 0
                        var53(xd) = 0
                        var5(xd) = 0
                        var1600(xd) = 0
                        var304(xd) = 0
                        var25(xd) = 0
                        var09(xd) = 0
                        var08(xd) = 0
                        var07(xd) = 0
                        var06(xd) = 0
                        var03(xd) = 0

                        For xd1 = 0 To maxcontador + 1
                            Select Case ArreIeps(xd, xd1)
                                Case "0.265000"
                                    var265(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.300000"
                                    var3(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.530000"
                                    var53(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.500000"
                                    var5(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "1.600000"
                                    var1600(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.304000"
                                    var304(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.250000"
                                    var25(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.090000"
                                    var09(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.080000"
                                    var08(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.070000"
                                    var07(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.060000"
                                    var06(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.030000"
                                    var03(xd) += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                            End Select
                        Next

                        sumatoriaIEPS += FormatNumber(var265(xd) * 0.265, 2)
                        sumatoriaIEPS += FormatNumber(var3(xd) * 0.3, 2)
                        sumatoriaIEPS += FormatNumber(var53(xd) * 0.53, 2)
                        sumatoriaIEPS += FormatNumber(var5(xd) * 0.5, 2)
                        sumatoriaIEPS += FormatNumber(var1600(xd) * 1.6, 2)
                        sumatoriaIEPS += FormatNumber(var304(xd) * 0.304, 2)
                        sumatoriaIEPS += FormatNumber(var25(xd) * 0.25, 2)
                        sumatoriaIEPS += FormatNumber(var09(xd) * 0.09, 2)
                        sumatoriaIEPS += FormatNumber(var08(xd) * 0.08, 2)
                        sumatoriaIEPS += FormatNumber(var07(xd) * 0.07, 2)
                        sumatoriaIEPS += FormatNumber(var06(xd) * 0.06, 2)
                        sumatoriaIEPS += FormatNumber(var03(xd) * 0.03, 2)
                    Next
                End If

                If sumatoriaIEPS > 0 Then
                    txt_impuestos.Text = FormatNumber(sumatoriaIEPS, 2)
                End If

                Text_TOTAL.Text = FormatNumber(CDec(Text_SubTotal.Text) + CDec(Text_IVA.Text) + CDec(txt_impuestos.Text) - CDec(Text_Descuento.Text) - CDec(Text_IVARET.Text), 2)

                If CDec(txt_impuestos.Text) > 0 Then
                    Bvar265 = 0
                    Bvar3 = 0
                    Bvar53 = 0
                    Bvar5 = 0
                    Bvar1600 = 0
                    Bvar304 = 0
                    Bvar25 = 0
                    Bvar09 = 0
                    Bvar08 = 0
                    Bvar07 = 0
                    Bvar06 = 0
                    Bvar03 = 0
                    For xd = 0 To contadorMatriz
                        For xd1 = 0 To maxcontador + 1
                            Select Case ArreIeps(xd, xd1)
                                Case "0.265000"
                                    Bvar265 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.300000"
                                    Bvar3 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.530000"
                                    Bvar53 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.500000"
                                    Bvar5 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "1.600000"
                                    Bvar1600 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.304000"
                                    Bvar304 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.250000"
                                    Bvar25 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.090000"
                                    Bvar09 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.080000"
                                    Bvar08 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.070000"
                                    Bvar07 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.060000"
                                    Bvar06 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                                Case "0.030000"
                                    Bvar03 += FormatNumber(CDec(ArreIepsBase(xd, xd1)), 6)
                            End Select
                        Next
                    Next

                End If

                Exit Sub
            End If

puerta_FacturaG:

            If txtNotaVenta.Text <> "" Then
                Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                sinfo = ""
                odata = New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        .runSp(cnn, "delete from detalle_factura where factura = 0 and ip_loc = '" & numero_MAC & "'", sinfo)
                        cnn.Close()
                    End If
                End With

                Text_SubTotal.Text = ""
                var1 = 0
                txt_partida.Text = "1"
                Text_Descuento.Text = "0"
                txt_impuestos.Text = "0"
                Text_IVARET.Text = "0"

                Dim vartot As Double = 0
                For i = 0 To grid_prods.Rows.Count
                    grid_prods.Rows().Clear()
                Next
                Dim str As String = ""
                Dim str1(10000) As String
                Dim contarray As Integer = 0
                For x = 1 To txtNotaVenta.TextLength
                    str = Mid$(txtNotaVenta.Text, x, 1)
                    If str = "," Then
                        contarray = contarray + 1
                    Else
                        str1(contarray) = str1(contarray) & str
                    End If
                Next
                For x1 = 0 To contarray
                    cnn1 = New MySqlClient.MySqlConnection
                    sinfo = ""
                    dt = New DataTable
                    With odata
                        If .dbOpen(cnn1, sTarget, sinfo) Then
                            If .getDt(cnn1, dt, "Select Facturado from Ventas where Folio = " & str1(x1) & "", sinfo) Then
                                For Each dr In dt.Rows
                                    If CStr(dr(0).ToString) <> "0" Then
                                        MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                        GoTo puerta
                                    End If
                                Next
                            End If
                            cnn1.Close()
                        End If
                    End With

                    sinfo = ""
                    dt = New DataTable
                    With odata
                        If .dbOpen(cnn1, sTarget, sinfo) Then
                            If .getDt(cnn1, dt, "Select Codigo,Nombre,Unidad,Cantidad,PrecioSinIVA,TotalSinIVA,Facturado,Descto,Total,TotalIEPS,Precio,CostVR from VentasDetalle where Folio = " & str1(x1) & " and Total <> '0'", sinfo) Then
                                For Each dr In dt.Rows
                                    If CDec(dr("Descto").ToString) <> CDec(0) Then
                                        If CDec(dr(6).ToString) <> CDec(0) Then
                                            MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                            GoTo puerta
                                        Else
                                            Dim varUniMed As String = ""
                                            Dim varClaveProd As String = ""
                                            Dim varDescLarg As String = ""
                                            Dim varIva As String = "0"
                                            Dim varDscto As String = "0"
                                            Dim varIvaReten As String = "0"
                                            Dim varIEPS As String = "0"

                                            Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                                            sinfo = ""
                                            Dim dt2 As New DataTable
                                            Dim dr2 As DataRow
                                            With odata
                                                If .dbOpen(cnn2, sTarget, sinfo) Then
                                                    If .getDt(cnn2, dt2, "Select * from Productos where Codigo = '" & dr(0).ToString & "'", sinfo) Then
                                                        For Each dr2 In dt2.Rows
                                                            varClaveProd = IIf(IsDBNull(dr2("ClaveSat").ToString), "", dr2("ClaveSat").ToString)
                                                            varUniMed = IIf(IsDBNull(dr2("UnidadSat").ToString), "", dr2("UnidadSat").ToString)
                                                            varDescLarg = IIf(dr(11).ToString = "0", "", dr(11).ToString)
                                                            varIva = IIf(IsDBNull(dr2("IVA").ToString), "0", dr2("IVA").ToString * 100)
                                                            varDscto = FormatNumber(IIf(IsDBNull(dr("Descto").ToString), "0", dr("Descto").ToString), 2)
                                                            If CStr(dr2("PercentIVAret").ToString) = "" Then
                                                                varIvaReten = 0
                                                            Else
                                                                varIvaReten = IIf(IsDBNull(dr2("PercentIVAret").ToString) Or CStr(dr2("PercentIVAret").ToString), "0", FormatNumber(dr2("PercentIVAret").ToString / 100, 6))
                                                            End If
                                                            If CStr(dr2("IIEPS").ToString) = "" Then
                                                                varIEPS = 0
                                                            Else
                                                                varIEPS = IIf(IsDBNull(dr2("IIEPS").ToString), "0", FormatNumber(dr2("IIEPS").ToString / 100, 6))
                                                                If varIEPS = "" Then varIEPS = 0
                                                            End If
                                                        Next
                                                    End If
                                                    cnn.Close()
                                                End If
                                            End With

                                            Dim varcuentas, varcuentas1 As Double
                                            Dim nuevo_descuento As Double = 0
                                            If varIva = "0" Then
                                                nuevo_descuento = varDscto
                                            Else
                                                nuevo_descuento = FormatNumber(varDscto * 1.16, 2)
                                            End If

                                            varcuentas = FormatNumber(CDbl(dr(10).ToString) - (FormatNumber(nuevo_descuento / CDbl(dr(3).ToString()), 2)), 6)
                                            'varcuentas = FormatNumber(CDbl(dr(10).ToString), 6)
                                            varcuentas1 = FormatNumber(FormatNumber(CDec(dr(7).ToString), 2) / CDec(dr(3).ToString), 6)

                                            Dim newIvaRet As Double = 0

                                            If varIvaReten > 0 Then
                                                newIvaRet = varIvaReten * CDec(FormatNumber(CDec(FormatNumber((CDec(dr(3).ToString) * CDec(FormatNumber((varcuentas) / 1.16, 6))), 6)), 6))
                                            End If

                                            If varIva = "0" Then
                                                If chkAumentarISR.Checked = True Then
                                                    Dim varopeisr As Double = 1.25 / 100
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(CDec(FormatNumber((varcuentas), 6)) + varcuentas1, 6), FormatNumber(CDec(FormatNumber((CDec(dr(3).ToString) * CDec(varcuentas)), 6)) + varDscto, 6), FormatNumber(varcuentas, 6), FormatNumber(CDec(dr(3).ToString) * CDec(varcuentas), 6), varIva, varDscto, "0", "0", varDescLarg, CStr(txt_partida.Text), varClaveProd, varopeisr, varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", "")
                                                Else
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(CDec(FormatNumber((varcuentas), 6)) + varcuentas1, 6), FormatNumber(CDec(FormatNumber((CDec(dr(3).ToString) * CDec(varcuentas)), 6)) + varDscto, 6), FormatNumber(varcuentas, 6), FormatNumber(CDec(dr(3).ToString) * CDec(varcuentas), 6), varIva, varDscto, "0", "0", varDescLarg, CStr(txt_partida.Text), varClaveProd, "0", varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", "")
                                                End If
                                                My.Application.DoEvents()
                                            Else
                                                If chkAumentarISR.Checked = True Then
                                                    Dim varopeisr As Double = 1.25 / 100
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(CDec(FormatNumber((varcuentas) / 1.16, 6)) + varcuentas1, 6), FormatNumber(CDec(FormatNumber((CDec(dr(3).ToString) * CDec(FormatNumber((varcuentas) / 1.16, 6))), 6)) + varDscto, 6), FormatNumber(varcuentas, 6), FormatNumber(CDec(dr(3).ToString) * CDec(varcuentas), 6), varIva, varDscto, FormatNumber(newIvaRet, 6), "0", varDescLarg, CStr(txt_partida.Text), varClaveProd, varopeisr, FormatNumber(varIEPS, 6), IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", "")
                                                Else
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(CDec(FormatNumber((varcuentas) / 1.16, 6)) + varcuentas1, 6), FormatNumber(CDec(FormatNumber((CDec(dr(3).ToString) * CDec(FormatNumber((varcuentas) / 1.16, 6))), 6)) + varDscto, 6), FormatNumber(varcuentas, 6), FormatNumber(CDec(dr(3).ToString) * CDec(varcuentas), 6), varIva, varDscto, FormatNumber(newIvaRet, 6), "0", varDescLarg, CStr(txt_partida.Text), varClaveProd, "0", FormatNumber(varIEPS, 6), IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", "")
                                                End If
                                                My.Application.DoEvents()
                                            End If

                                            If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
                                                var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                                            Else
                                                var_cliente = 0
                                            End If

                                            var1 = CDec(var1) + 1
                                            txt_partida.Text = CDec(txt_partida.Text) + 1
                                            Text_FormaPago.Focus()
                                        End If
                                    Else
                                        If dr(6).ToString <> "0" Then
                                            MsgBox("El folio " & str1(x1) & " ya fue facturado")
                                            GoTo puerta
                                        Else
                                            Dim varUniMed As String = ""
                                            Dim varClaveProd As String = ""
                                            Dim varDescLarg As String = ""
                                            Dim varIva As String = ""
                                            Dim varDscto As String = ""
                                            Dim varIvaReten As String = ""
                                            Dim varIEPS As String = ""
                                            Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                                            sinfo = ""
                                            Dim dt2 As New DataTable
                                            Dim dr2 As DataRow
                                            With odata
                                                If .dbOpen(cnn2, sTarget, sinfo) Then
                                                    If .getDt(cnn2, dt2, "Select * from Productos where Codigo = '" & dr(0).ToString & "'", sinfo) Then
                                                        For Each dr2 In dt2.Rows
                                                            varClaveProd = IIf(IsDBNull(dr2("ClaveSat").ToString), "", dr2("ClaveSat").ToString)
                                                            varUniMed = IIf(IsDBNull(dr2("UnidadSat").ToString), "", dr2("UnidadSat").ToString)
                                                            varDescLarg = IIf(dr(11).ToString = "0", "", dr(11).ToString)
                                                            varIva = IIf(IsDBNull(dr2("IVA").ToString), "0", dr2("IVA").ToString * 100)
                                                            varDscto = FormatNumber(IIf(IsDBNull(dr("Descto").ToString), "0", dr("Descto").ToString), 2)
                                                            If CStr(dr2("PercentIVAret").ToString) = "" Then
                                                                varIvaReten = 0
                                                            Else
                                                                varIvaReten = IIf(IsDBNull(dr2("PercentIVAret").ToString) Or CStr(dr2("PercentIVAret").ToString), "0", FormatNumber(dr2("PercentIVAret").ToString / 100, 6))
                                                            End If
                                                            If CStr(dr2("IIEPS").ToString) = "" Then
                                                                varIEPS = 0
                                                            Else
                                                                varIEPS = IIf(IsDBNull(dr2("IIEPS").ToString), "0", FormatNumber(dr2("IIEPS").ToString / 100, 6))
                                                                If varIEPS = "" Then varIEPS = 0
                                                            End If

                                                        Next
                                                    End If
                                                    cnn.Close()
                                                End If
                                            End With


                                            Dim opeieps As Decimal = 0
                                            Dim total As Double = 0
                                            Dim nuevoieps As Double = 0
                                            Dim basenuevoieps As Double = 0

                                            If varIva = "0" Then
                                                total = FormatNumber(CDec(dr(3).ToString) * CDec(dr("Precio").ToString), 2)
                                                opeieps = FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr("Precio").ToString / 1, 6)), 6)
                                                nuevoieps = FormatNumber(CDec(FormatNumber(opeieps / (CDec(1 + varIEPS)), 6)) * CDec(varIEPS), 6)
                                                basenuevoieps = FormatNumber(opeieps / (CDec(1 + varIEPS)), 6)
                                                total = FormatNumber(total - CDec(FormatNumber(CDec(opeieps) * 0, 6)) - nuevoieps, 6)

                                                If chkAumentarISR.Checked = True Then
                                                    Dim varopeisr As Double = 1.25 / 100
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(FormatNumber(total / dr(3).ToString, 6), 6), FormatNumber(total, 6), FormatNumber(dr("Precio").ToString, 6), FormatNumber(CDec(dr("Precio").ToString) * CDec(dr(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr(4).ToString, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 6), varDescLarg, CStr(txt_partida.Text), varClaveProd, varopeisr, varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", basenuevoieps)
                                                Else
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(FormatNumber(total / dr(3).ToString, 6), 6), FormatNumber(total, 6), FormatNumber(dr("Precio").ToString, 6), FormatNumber(CDec(dr("Precio").ToString) * CDec(dr(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr(4).ToString, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 6), varDescLarg, CStr(txt_partida.Text), varClaveProd, "0", varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", basenuevoieps)
                                                End If
                                            Else
                                                total = FormatNumber(CDec(dr(3).ToString) * CDec(dr("Precio").ToString), 2)
                                                opeieps = FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr("Precio").ToString / 1.16, 6)), 6)
                                                nuevoieps = FormatNumber(CDec(FormatNumber(opeieps / (CDec(1 + varIEPS)), 6)) * CDec(varIEPS), 6)
                                                basenuevoieps = FormatNumber(opeieps / (CDec(1 + varIEPS)), 6)
                                                total = FormatNumber(total - CDec(FormatNumber(CDec(opeieps) * 0.16, 6)) - nuevoieps, 6)

                                                'Dim totaliva As Double = FormatNumber(total - CDec(opeieps) - nuevoieps, 6)
                                                'total = FormatNumber(total - CDec(totaliva), 6)

                                                If chkAumentarISR.Checked = True Then
                                                    Dim varopeisr As Double = 1.25 / 100
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(total / dr(3).ToString, 6), FormatNumber(total, 6), FormatNumber(dr("Precio").ToString, 6), FormatNumber(CDec(dr("Precio").ToString) * CDec(dr(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr("Precio").ToString / 1.16, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 6), varDescLarg, CStr(txt_partida.Text), varClaveProd, varopeisr, varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", basenuevoieps)
                                                Else
                                                    grid_prods.Rows.Insert(var1, dr(0).ToString, dr(1).ToString, varUniMed, dr(3).ToString, FormatNumber(total / dr(3).ToString, 6), FormatNumber(total, 6), FormatNumber(dr("Precio").ToString, 6), FormatNumber(CDec(dr("Precio").ToString) * CDec(dr(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(dr(3).ToString) * CDec(FormatNumber(dr("Precio").ToString / 1.16, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 6), varDescLarg, CStr(txt_partida.Text), varClaveProd, "0", varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", basenuevoieps)
                                                End If

                                                'If chkAumentarISR.Checked = True Then
                                                '    Dim varopeisr As Double = 1.25 / 100
                                                '    grid_prods.Rows.Insert(var1, rd(0).ToString, rd(1).ToString, varUniMed, rd(3).ToString, FormatNumber(total / rd(3).ToString, 6), FormatNumber(total, 6), FormatNumber(rd("Precio").ToString, 6), FormatNumber(CDec(rd("Precio").ToString) * CDec(rd(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(rd(3).ToString) * CDec(FormatNumber(rd("Precio").ToString / 1.16, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 2), varDescLarg, CStr(txt_partida.Text), varClaveProd, varopeisr, varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", varFechaCad, varLoteCad)
                                                'Else
                                                '    grid_prods.Rows.Insert(var1, rd(0).ToString, rd(1).ToString, varUniMed, rd(3).ToString, FormatNumber(total / rd(3).ToString, 6), FormatNumber(total, 6), FormatNumber(rd("Precio").ToString, 6), FormatNumber(CDec(rd("Precio").ToString) * CDec(rd(3).ToString), 6), varIva, varDscto, FormatNumber(FormatNumber(CDec(rd(3).ToString) * CDec(FormatNumber(rd("Precio").ToString / 1.16, 6)), 6) * varIvaReten, 6), FormatNumber(nuevoieps, 2), varDescLarg, CStr(txt_partida.Text), varClaveProd, "0", varIEPS, IIf(varIEPS = "0", "", "Tasa"), varIvaReten, "", "", varFechaCad, varLoteCad)
                                                'End If

                                            End If

                                            If dame_IdClienteRS(Cmb_RazonS.Text) > 0 Then
                                                var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
                                            Else
                                                var_cliente = 0
                                            End If

                                            var1 = CDec(var1) + 1
                                            txt_partida.Text = CDec(txt_partida.Text) + 1
                                            Text_FormaPago.Focus()
                                        End If
                                    End If
                                Next
                            Else
                                MsgBox("El folio " & str1(x1) & " no existe")
                            End If
                            cnn1.Close()
                        End If
                    End With
puerta:
                Next

                'conexion.Close()
                Dim vart As Double = 0
                Dim vart1 As Double = 0
                Dim sumaIeps As Double = 0
                Dim sumaIvaRet As Double = 0
                Dim sumaSubT As Decimal = 0
                Dim sumDesc As Decimal = 0
                Dim varisr2 As Double = 0
                For x = 0 To grid_prods.Rows.Count - 1
                    If Convert.ToDouble(grid_prods.Rows(x).Cells("Column4").Value) > 0 Then
                        sumaSubT += Convert.ToDouble(grid_prods.Rows(x).Cells("Total").Value)
                        'sumaSubT += FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value) / 1.16, 6) - CDec(Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value)) 'Total
                        vart1 = vart1 + CDec(FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value) / 1.16, 6))
                        'vart1 = vart1 + FormatNumber(CDec(FormatNumber(Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value) / 1.16, 6)) - CDec(Convert.ToDouble(grid_prods.Rows(x).Cells(9).Value)), 6)

                    Else
                        sumaSubT += Convert.ToDouble(grid_prods.Rows(x).Cells("Total").Value) 'Total
                        vart1 = vart1 + 0
                    End If
                    sumDesc += CDec(Convert.ToDouble(grid_prods.Rows(x).Cells(9).Value))
                    If CDec(Convert.ToDouble(grid_prods.Rows(x).Cells("Column4").Value)) > 0 Then
                        vart = vart + Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value)
                    Else
                        vart = vart + Convert.ToDouble(grid_prods.Rows(x).Cells("Column2").Value) + Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value) 'vart = vart + Convert.ToDouble(grid_prods.Rows(x).Cells("Total").Value) + Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value)
                    End If
                    sumaIeps += Convert.ToDouble(grid_prods.Rows(x).Cells("Column7").Value)
                    sumaIvaRet += Convert.ToDouble(grid_prods.Rows(x).Cells("Column6").Value)

                    varisr2 = varisr2 + FormatNumber(CDec(CDec(grid_prods.Rows(x).Cells(5).Value.ToString) - CDec(grid_prods.Rows(x).Cells(9).Value.ToString)) * CDec(IIf(grid_prods.Rows(x).Cells(15).Value.ToString = "", "0", grid_prods.Rows(x).Cells(15).Value.ToString)), 6)
                Next
                Text_SubTotal.Text = FormatNumber(sumaSubT, 2)
                Text_Descuento.Text = FormatNumber(sumDesc, 2)
                vart1 = FormatNumber(vart1 * 0.16, 2)
                TextBox1.Text = FormatNumber(CDec(Text_SubTotal.Text) - CDec(Text_Descuento.Text), 2)
                Text_IVA.Text = FormatNumber(vart1, 2)
                Text_IVARET.Text = FormatNumber(sumaIvaRet, 2)
                txt_impuestos.Text = FormatNumber(sumaIeps, 2)
                txtISR.Text = FormatNumber(varisr2, 2)
                Text_TOTAL.Text = FormatNumber(CDec(Text_SubTotal.Text) + CDec(Text_IVA.Text) + CDec(txt_impuestos.Text) - CDec(Text_Descuento.Text) - CDec(Text_IVARET.Text) - CDec(txtISR.Text), 2)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        logdelsscom.Show()
    End Sub

    Private Sub btnGlobal_Click(sender As Object, e As EventArgs) Handles btnGlobal.Click
        GroupBox7.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Btt_Nuevo.PerformClick()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cboMeses.Text = "" Then MsgBox("Debe seleccionar el mes o los meses de la factura global") : Exit Sub
        If cboPeriodicidad.Text = "" Then MsgBox("Debe seleccionar el periodo para factura global") : Exit Sub
        If txtAno.Text = "" Then MsgBox("Debe escribir el año para factura global") : Exit Sub

        Dim VarsLeyenda As String = ""
        Dim Fol_ini As String = ""
        Dim FOL_Fin As String = ""
        Dim AuxFols() As String
        Dim Cad As String = ""
        txtNotaVenta.Text = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        'Dim sSQL As String = "Select * From Ventas Where Facturado = '0' and Status <> 'CANCELADA' and FVenta >=#" & Format(dtpDesde.Value, "dd/MM/yyyy") & "# and FVenta<=#" & Format(dtpHasta.Value, "dd/MM/yyyy") & "# Order by Folio ASC"
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        Dim contador As Integer = 1

        'Sí se seleccionó un usuario
        If cbouser.Text <> "" Then
            sSQL = "Select * from Ventas where FVenta Between '" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' And '" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Facturado = '0' and Status <> 'CANCELADA' and Totales > 0 and Usuario='" & cbouser.Text & "' Order by Folio ASC"
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                txtNotaVenta.Text = dr("Folio").ToString
                                FoliosFacGlobal = txtNotaVenta.Text
                            Else
                                txtNotaVenta.Text = txtNotaVenta.Text & "," & dr("Folio").ToString
                                FoliosFacGlobal = txtNotaVenta.Text
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With

            sSQL = "Select * From Ventas Where Facturado <> '0' and Status <> 'CANCELADA' and FVenta >='" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' and FVenta<='" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Totales > 0 and Usuario='" & cbouser.Text & "' Order by Folio ASC"
            sinfo = ""
            contador = 1
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                FolFacts = dr("Folio").ToString
                            Else
                                FolFacts = FolFacts & "," & dr("Folio").ToString
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With

            If txtNotaVenta.Text <> "" Then
                AuxFols = Split(txtNotaVenta.Text, ",")
                Fol_ini = AuxFols(0)
                FOL_Fin = AuxFols(UBound(AuxFols))
            End If

            If FolFacts <> "" Then
                VarsLeyenda = "Factura Global del Folio " & Fol_ini & " al " & FOL_Fin & " excepto los Folios ya facturados. Folio(s) Facturado(s): " & FolFacts
            Else
                VarsLeyenda = "Factura Global del Folio " & Fol_ini & " al " & FOL_Fin & ""
            End If

            'GrdCaptura.ToolTipText = VarsLeyenda

            sSQL = "Select * From Ventas Where Facturado <> '0' and Status <> 'CANCELADA' and FVenta >='" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' and FVenta<='" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Totales > 0 Order by Folio ASC"
            sinfo = ""
            contador = 1
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                FolFacts = dr("Folio").ToString
                            Else
                                FolFacts = FolFacts & "," & dr("Folio").ToString
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With
        Else
            sSQL = "Select * from Ventas where FVenta Between '" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' And '" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Facturado = '0' and Status <> 'CANCELADA' and Totales > 0 Order by Folio ASC"
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                txtNotaVenta.Text = dr("Folio").ToString
                                FoliosFacGlobal = txtNotaVenta.Text
                            Else
                                txtNotaVenta.Text = txtNotaVenta.Text & "," & dr("Folio").ToString
                                FoliosFacGlobal = txtNotaVenta.Text
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With

            sSQL = "Select * From Ventas Where Facturado <> '0' and Status <> 'CANCELADA' and FVenta >='" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' and FVenta<='" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Totales > 0 Order by Folio ASC"
            sinfo = ""
            contador = 1
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                FolFacts = dr("Folio").ToString
                            Else
                                FolFacts = FolFacts & "," & dr("Folio").ToString
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With

            If txtNotaVenta.Text <> "" Then
                AuxFols = Split(txtNotaVenta.Text, ",")
                Fol_ini = AuxFols(0)
                FOL_Fin = AuxFols(UBound(AuxFols))
            End If

            If FolFacts <> "" Then
                VarsLeyenda = "Factura Global del Folio " & Fol_ini & " al " & FOL_Fin & " excepto los Folios ya facturados. Folio(s) Facturado(s): " & FolFacts
            Else
                VarsLeyenda = "Factura Global del Folio " & Fol_ini & " al " & FOL_Fin & ""
            End If

            'GrdCaptura.ToolTipText = VarsLeyenda

            sSQL = "Select * From Ventas Where Facturado <> '0' and Status <> 'CANCELADA' and FVenta >='" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' and FVenta<='" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Totales > 0 Order by Folio ASC"
            sinfo = ""
            contador = 1
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If contador = 1 Then
                                contador = contador + 1
                                FolFacts = dr("Folio").ToString
                            Else
                                FolFacts = FolFacts & "," & dr("Folio").ToString
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                Else
                End If
            End With
        End If

        '"Select Sum(TotalSinIVA)as TSinIVA,Sum(Total-TotalSinIVA)as IVA,Sum(Total)as PTotal From Ventas V INNER JOIN VentasDetalle VD ON V.Folio=VD.Folio Where VD.Facturado='0' and V.Status<>'CANCELADA' and  V.FVenta >=#" & Format(mvDesde.value, "yyyy/mm/dd") & "# and V.FVenta<=#" & Format(mvHasta.value, "yyyy/mm/dd") & "#"
        'qr2 = db.CreateQueryDef("", SQL1)
        'rs2 = qr2.OpenRecordset()
        'If Not rs2.EOF Then
        '    txtSubtotal2.Text = Format(NulZe(rs2!TSinIVA), "###,##0.00")
        '    txtIVA.Text = Format(NulZe(rs2!IVA), "###,##0.00")
        '    txtTotal.Text = Format(NulZe(rs2!PTotal), "###,##0.00")
        'End If

        GroupBox7.Visible = False
    End Sub

    Private Sub btnReenvio_Click(sender As Object, e As EventArgs) Handles btnReenvio.Click
        Dim nombreCFD As String = "F" & txt_serie.Text & var_folio & ".xml"
        Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString
        Dim root_name_recibo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & Cmb_Nfactura.Text & "_F" & Cmb_Nfactura.Text & ".pdf"
        'If varrutabase <> "" Then
        ' root_name_recibo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & Cmb_TipoFact.Text & "\" & Cmb_TipoFact.Text & "_E" & Cmb_Nfactura.Text & "_F" & Cmb_Nfactura.Text & ".pdf"
        'End If

        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
        End Select

        Dim xmla As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD
        ' If varrutabase <> "" Then
        'xmla = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & Cmb_TipoFact.Text & "\" &'nombreCFD
        'End If
        ProgressBar1.Value = 90
        lbl_proceso.Text = "Enviando E-Mail ..."
        My.Application.DoEvents()
        envio_mail.Show()
        envio_mail.BringToFront()
        envio_mail.archivoadj = root_name_recibo

        If Cmb_TipoFact.Text <> "PREFACTURA" Then
            envio_mail.archivoadj2 = xmla
        End If

        envio_mail.txtasunto.Text = Cmb_TipoFact.Text & " " & Cmb_Nfactura.Text
        envio_mail.txtpara.Text = Text_Email.Text
    End Sub

    Private Sub Text_FormaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_FormaPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_CondiPago.Focus()
        End If
    End Sub

    Private Sub Text_MotivoDes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_MotivoDes.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_CondiPago.Focus()
        End If
    End Sub

    Private Sub Text_CondiPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_CondiPago.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_nCuenta.Focus()
        End If
    End Sub

    Private Sub Text_nCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_nCuenta.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            cbo_usocfdi.Focus()
        End If
    End Sub

    Private Sub cbo_usocfdi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_usocfdi.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            cbometodo_pago.Focus()
        End If
    End Sub

    Private Sub txt_leyenda_add_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_leyenda_add.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            cbometodo_pago.Focus()
        End If
    End Sub

    Private Sub txt_unidadventaNew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_unidadventaNew.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_cantidad.Focus()
        End If
    End Sub

    Private Sub txt_piva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_piva.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_descuento.Focus()
        End If
    End Sub

    Private Sub txt_descuento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_descuento.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_ivaret.Focus()
        End If
    End Sub

    Private Sub txt_ivaret_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ivaret.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            cboIeps.Focus()
        End If
    End Sub

    Private Sub txt_ieps_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_ieps.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_prodsat.Focus()
        End If
    End Sub

    Private Sub btnActProd_Click(sender As Object, e As EventArgs) Handles btnActProd.Click
        frmCambiaCodigo.Show()
    End Sub

    Private Sub btnActUni_Click(sender As Object, e As EventArgs) Handles btnActUni.Click
        frmCambiaUnidad.Show()
    End Sub

    Private Sub Text_calle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_calle.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Num_Ex.Focus()
        End If
    End Sub

    Private Sub Text_Num_Ex_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Num_Ex.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Txt_num_int.Focus()
        End If
    End Sub

    Private Sub Txt_num_int_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_num_int.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_CP.Focus()
        End If
    End Sub

    Private Sub Text_CP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_CP.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Colonia.Focus()
        End If
    End Sub

    Private Sub Text_Colonia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Colonia.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Delegacion.Focus()
        End If
    End Sub

    Private Sub Text_Delegacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Delegacion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Edo.Focus()
        End If
    End Sub

    Private Sub Text_Edo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Edo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Pais.Focus()
        End If
    End Sub

    Private Sub Text_Pais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Pais.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_Email.Focus()
        End If
    End Sub

    Private Sub Text_Email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Text_Email.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If Asc(e.KeyChar) = Keys.Enter Then
            txtNotaVenta.Focus()
        End If
    End Sub

    Private Sub btnTimbres_Click(sender As Object, e As EventArgs) Handles btnTimbres.Click
        If cbo_rfc_emisor.Text <> "" Then
            bandera_timbres = 1
            checat(cbo_rfc_emisor.Text)
            bandera_timbres = 0
        End If
    End Sub

    Private Sub cboIeps_DropDown(sender As Object, e As EventArgs) Handles cboIeps.DropDown
        If chkTasa.Checked = True Then
            cboIeps.Items.Clear()
            cboIeps.Text = ""
            cboIeps.Items.Add("3.0")
            cboIeps.Items.Add("6.0")
            cboIeps.Items.Add("7.0")
            cboIeps.Items.Add("8.0")
            cboIeps.Items.Add("9.0")
            cboIeps.Items.Add("25.0")
            cboIeps.Items.Add("26.5")
            cboIeps.Items.Add("30.0")
            cboIeps.Items.Add("30.4")
            cboIeps.Items.Add("50.0")
            cboIeps.Items.Add("53.0")
            cboIeps.Items.Add("160.0")
        ElseIf chkCuota.Checked = True Then
            cboIeps.Items.Clear()
            cboIeps.Text = ""
            cboIeps.Items.Add("43.77")
        Else
            cboIeps.Items.Clear()
            cboIeps.Text = ""
        End If
    End Sub

    Private Sub chkTasa_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles chkTasa.ContextMenuStripChanged
        If chkCuota.Checked = True Then
            chkTasa.Checked = True
            chkCuota.Checked = False
        End If
    End Sub

    Private Sub chkCuota_Click(sender As Object, e As EventArgs) Handles chkCuota.Click
        If chkTasa.Checked = True Then
            chkCuota.Checked = True
            chkTasa.Checked = False
        End If
    End Sub

    Private Sub txt_nombrec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_nombrec.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Text_calle.Focus()
        End If
    End Sub

    Private Sub cboIeps_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboIeps.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If cboIeps.Text = "" Then cboIeps.Text = "0"
            txtIsrDet.Focus()
        End If
    End Sub

    Private Sub txt_partida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_partida.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            txt_prodsat.Focus()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        consultaxml()

        Dim nombreCFD As String = "F" & txt_serie.Text & var_folio & ".xml"
        Select Case Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & txt_serie.Text & Cmb_Nfactura.Text & ".xml"
        End Select

        'existencia de la factura
        Dim varexiste As Integer = 0
        'variables para la conexion
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        Dim dr As DataRow
#Disable Warning BC42024 ' Variable local sin usar: 'dt'.
        Dim dt As DataTable
#Enable Warning BC42024 ' Variable local sin usar: 'dt'.
        'variables datos emisor
        Dim varEmiRazonSocial As String = ""
        Dim varEmiId As String = ""
        Dim varEmiRFC As String = ""
        Dim varEmiRegFiscal As String = ""
        Dim varEmiActEmpresa As String = ""
        Dim varEmiCalle As String = ""
        Dim varEmiColonia As String = ""
        Dim varEmiDelMun As String = ""
        Dim varEmiCP As String = ""
        Dim varExpedido As String = ""
        Dim varEmiEdo As String = ""
        Dim varEmiNumExt As String = ""
        Dim varEmiNumInt As String = ""
        'variables datos clientes
        Dim varClienteId As String = ""
        Dim varClienteRazonSocial As String = ""
        Dim varClienteRFC As String = ""
        Dim varClienteRegfis As String = ""
        Dim varClienteCalle As String = ""
        Dim varClienteColonia As String = ""
        Dim varClienteDelMun As String = ""
        Dim varClienteNumExt As String = ""
        Dim varClienteEdo As String = ""
        'variables datos factura
        Dim varNumFolioFact As String = ""
        Dim varNumFolioFactId As String = ""
        Dim varFechaFact As String = ""
        Dim varMetPagoFact As String = ""
        Dim varTipoPagoFact As String = ""
        Dim varUUIDFact As String = ""
        Dim varFechaFolSATFact As String = ""
        Dim varSelloEmiFact As String = ""
        Dim varSelloSATFact As String = ""
        Dim varTotalFact As String = "0"
        Dim varCSDSatFact As String = ""
        Dim varCSDEmpFact As String = ""
        Dim varEstatusFact As String = "1"
        Dim varDescuentoFact As String = "0"
        Dim varIVAFact As String = "0"
        Dim varSubTotalFact As String = "0"
        Dim varIVARetFact As String = "0"
        Dim varIEPSFact As String = "0"
        Dim varUsoCFDI As String = ""
        Dim varFormaPagoFact As String = ""
        Dim varVersion As String = ""
        Dim varRFCProvFact As String = ""
        'variables datos
        Dim varCantConceptos As Integer = 0
        'Buscamos el xml que se descargo
        Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        If varrutabase <> "" Then
            Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        End If

        Do While (Lector.Read())
            Select Case Lector.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If Lector.Name = "cfdi:Comprobante" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Folio"
                                        sSQL = "select nom_folio,nom_id from Facturas where nom_folio = " & Lector.Value & ""
                                        If oData.dbOpen(cnn, sTarget, sinfo) Then
                                            If oData.getDr(cnn, dr, sSQL, sinfo) Then
                                                'si existe la factura
                                                varexiste = 1
                                            End If
                                        End If
                                        cnn.Close()
                                End Select
                            End While
                        End If
                    End If
            End Select
        Loop

        Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        If varrutabase <> "" Then
            Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        End If

        Do While (Lector.Read())
            Select Case Lector.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If Lector.Name = "cfdi:Comprobante" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Total"
                                        varTotalFact = Lector.Value
                                    Case "SubTotal"
                                        varSubTotalFact = Lector.Value
                                    Case "MetodoPago"
                                        varMetPagoFact = Lector.Value
                                    Case "FormaPago"
                                        varFormaPagoFact = Lector.Value
                                    Case "Folio"
                                        varNumFolioFact = Lector.Value
                                    Case "Fecha"
                                        varFechaFact = Lector.Value
                                    Case "Descuento"
                                        varDescuentoFact = Lector.Value
                                    Case "NoCertificado"
                                        varCSDEmpFact = Lector.Value
                                End Select
                            End While
                        End If
                    End If

                    If Lector.Name = "cfdi:Emisor" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Rfc"
                                        varEmiRFC = Lector.Value
                                    Case "RegimenFiscal"
                                        varEmiRegFiscal = Lector.Value
                                    Case "Nombre"
                                        varEmiRazonSocial = Lector.Value
                                End Select
                            End While
                        End If
                    End If

                    If Lector.Name = "cfdi:Receptor" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Rfc"
                                        varClienteRFC = Lector.Value
                                    Case "UsoCFDI"
                                        varUsoCFDI = Lector.Value
                                    Case "Nombre"
                                        varClienteRazonSocial = Lector.Value
                                    Case "RegimenFiscalReceptor"
                                        varClienteRegfis = Lector.Value
                                End Select
                            End While
                        End If
                    End If

                    If Lector.Name = "tfd:TimbreFiscalDigital" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "UUID"
                                        varUUIDFact = Lector.Value
                                    Case "FechaTimbrado"
                                        varFechaFolSATFact = Lector.Value
                                    Case "SelloCFD"
                                        varSelloEmiFact = Lector.Value
                                    Case "SelloSAT"
                                        varSelloSATFact = Lector.Value
                                    Case "Version"
                                        varVersion = Lector.Value
                                    Case "NoCertificadoSAT"
                                        varCSDSatFact = Lector.Value
                                    Case "RfcProvCertif"
                                        varRFCProvFact = Lector.Value
                                End Select
                            End While
                        End If
                    End If

                    Dim esuniva As Integer = 0
                    Dim tasacuota As String = ""
                    Dim ivatemporal As String = ""
                    Dim newbase As String = ""

                    If Lector.Name = "cfdi:Traslado" Then
                        If Lector.HasAttributes Then
                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Impuesto"
                                        If CStr(Lector.Value) = "002" Then
                                            esuniva = 1
                                        End If
                                    Case "Importe"
                                        ivatemporal = Lector.Value
                                    Case "TasaOCuota"
                                        tasacuota = Lector.Value
                                    Case "Base"
                                        newbase = Lector.Value
                                End Select
                            End While
                        End If
                    End If

                    If esuniva = 1 And tasacuota = "0.160000" And newbase = "" Then
                        varIVAFact = ivatemporal
                    End If

            End Select
        Loop

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from Clientes where RazonSocial ='" & varClienteRazonSocial & "' and RFC = '" & varClienteRFC & "'", sinfo) Then
                    varClienteId = dr("Id").ToString
                    varClienteCalle = dr("Calle").ToString
                    varClienteColonia = dr("Colonia").ToString
                    varClienteDelMun = dr("Delegacion").ToString
                    varClienteNumExt = dr("CNumberExt").ToString
                    varClienteEdo = dr("Entidad").ToString
                End If
                cnn.Close()
            End If
        End With

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from DatosNegocio where Em_RazonSocial ='" & varEmiRazonSocial & "' and Em_rfc = '" & varEmiRFC & "'", sinfo) Then
                    varEmiId = dr("Emisor_id").ToString
                    varEmiActEmpresa = dr("Em_Actividad").ToString
                    varEmiCalle = dr("Em_calle").ToString
                    varEmiColonia = dr("Em_colonia").ToString
                    varEmiDelMun = dr("Em_Municipio").ToString
                    varEmiCP = dr("Em_CP").ToString
                    varExpedido = dr("Em_Pais").ToString
                    varEmiEdo = dr("Em_Estado").ToString
                    varEmiNumExt = dr("Em_NumExterior").ToString
                    varEmiNumInt = dr("Em_NumInterior").ToString
                End If
                cnn.Close()
            End If
        End With

        Dim varCadenaOriginal As String = "||" & varVersion & "|" & varUUIDFact & "|" & varFechaFolSATFact & "|" & varRFCProvFact & "|" & varSelloEmiFact & "|" & varSelloEmiFact & "|" & varCSDSatFact & "||"

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If varexiste = 0 Then
                    sSQL = "insert into Facturas(nom_id_cliente,nom_razon_social,nom_rfc_empresa,nom_reg_fiscal," &
                    "nom_actividad_empresa,nom_calle_empresa,nom_colonia_empresa,nom_del_mun_empresa,nom_cp_empresa," &
                    "nom_expedido,estado_empresa,nom_nombre_cliente,nom_calle_cliente,nom_colonia_cliente,nom_del_mun_cliente," &
                    "nom_rfc_cliente,nom_folio,nom_fecha_factura,nom_metodo_pago,nom_tipo_pago,nom_folio_sat_uuid," &
                    "nom_fecha_folio_sat,nom_sello_emisor,nom_sello_sat,nom_cadena_original,nom_total_pagado,nom_no_csd_emp,nom_no_csd_sat," &
                    "estatus_fac,id_evento,n_ext_cliente,edo_cli,descripcion,descuento,iva,preciopaq,id_emisor,nom_mdescuento,fecha,UsoCFDI,nom_numcuenta,
                    nom_leyenda,nom_isr,nom_cpago,nom_status,CartaPorte,regfis_cliente,nom_numext_empresa,nom_numint_empresa,nom_ivaret,nom_mdescuento) " &
                    "values(" & varClienteId & ",'" & varEmiRazonSocial & "','" & varEmiRFC & "','" & varEmiRegFiscal & "'," &
                    "'" & varEmiActEmpresa & "','" & varEmiCalle & "','" & varEmiColonia & "','" & varEmiDelMun & "','" & varEmiCP & "'," &
                    "'" & varExpedido & "','" & varEmiEdo & "','" & varClienteRazonSocial & "','" & varClienteCalle & "','" & varClienteColonia & "','" & varClienteDelMun & "'," &
                    "'" & varClienteRFC & "'," & varNumFolioFact & ",'" & varFechaFact & "','" & varFormaPagoFact & "','" & varMetPagoFact & "','" & varUUIDFact & "', " &
                    "'" & varFechaFolSATFact & "','" & varSelloEmiFact & "','" & varSelloSATFact & "','" & varCadenaOriginal & "','" & varTotalFact & "','" & varCSDEmpFact & "','" & varCSDSatFact & "'," &
                    "1," & varNumFolioFact & ",'" & varClienteNumExt & "','" & varClienteEdo & "'," & varNumFolioFact & "," & varDescuentoFact & "," & varIVAFact & "," & varSubTotalFact & "," & varEmiId &
                    ",'" & IIf(varDescuentoFact = "0", "0.00", varDescuentoFact) & "','" & Format(CDate(varFechaFact), "dd/MM/yyyy HH:mm:ss") & "','" & varUsoCFDI & "','','',0,'',1,0,'" & varClienteRegfis &
                    "','" & varEmiNumExt & "','" & varEmiNumInt & "',0,'0.00')"
                    .runSp(cnn, sSQL, sinfo)
                    sSQL = "select Max(nom_id) as XD from Facturas"
                    If oData.getDr(cnn, dr, sSQL, sinfo) Then
                        varNumFolioFactId = dr("XD").ToString
                    End If
                Else
                    sSQL = "select nom_id from Facturas where nom_folio = " & varNumFolioFact & ""
                    If oData.getDr(cnn, dr, sSQL, sinfo) Then
                        varNumFolioFactId = dr("nom_id").ToString
                    End If
                End If
                cnn.Close()
            End If
        End With

        Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)

        If varrutabase <> "" Then
            Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        End If

        Do While (Lector.Read())
            Select Case Lector.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If Lector.Name = "cfdi:Concepto" Then
                        If Lector.HasAttributes Then
                            varCantConceptos += 1
                        End If
                    End If
            End Select
        Loop

        Dim varDesc(varCantConceptos) As String
        Dim varCodigoP(varCantConceptos) As String
        Dim varValUni(varCantConceptos) As String
        Dim varIdent(varCantConceptos) As String
        Dim varImporte(varCantConceptos) As String
        Dim varDescripcion(varCantConceptos) As String
        Dim varClaveUnidad(varCantConceptos) As String
        Dim varClaveProd(varCantConceptos) As String
        Dim varCant(varCantConceptos) As String
        Dim varIvaProd(varCantConceptos) As String
        Dim varIvaProdBase(varCantConceptos) As String
        Dim varIvaProdTC(varCantConceptos) As String
        Dim varIIEPSProd(varCantConceptos) As String
        Dim varIIEPSProdBase(varCantConceptos) As String
        Dim varIIEPSProdTC(varCantConceptos) As String

        Dim entraaconceptos As Integer = 0

        varCantConceptos = 0

        Lector = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        If varrutabase <> "" Then
            Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & Cmb_TipoFact.Text & "\" & nombreCFD)
        End If

        Do While (Lector.Read())
            Select Case Lector.NodeType
                Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                    If Lector.Name = "cfdi:Concepto" Then
                        If Lector.HasAttributes Then
                            If entraaconceptos >= 1 Then
                                entraaconceptos = 0
                                varCantConceptos += 1
                            End If

                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Descuento"
                                        varDesc(varCantConceptos) = Lector.Value
                                    Case "ValorUnitario"
                                        varValUni(varCantConceptos) = Lector.Value
                                    Case "NoIdentificacion"
                                        varIdent(varCantConceptos) = Lector.Value
                                    Case "Importe"
                                        varImporte(varCantConceptos) = Lector.Value
                                    Case "ClaveUnidad"
                                        varClaveUnidad(varCantConceptos) = Lector.Value
                                    Case "ClaveProdServ"
                                        varClaveProd(varCantConceptos) = Lector.Value
                                    Case "Cantidad"
                                        varCant(varCantConceptos) = Lector.Value
                                    Case "Descripcion"
                                        varDescripcion(varCantConceptos) = Lector.Value
                                        varCodigoP(varCantConceptos) = busca_codigo(CStr(Lector.Value))
                                End Select
                            End While

                            If IsNothing(varDesc(varCantConceptos)) Then varDesc(varCantConceptos) = "0"
                            If IsNothing(varValUni(varCantConceptos)) Then varValUni(varCantConceptos) = "0"
                            If IsNothing(varIdent(varCantConceptos)) Then varIdent(varCantConceptos) = ""
                            If IsNothing(varImporte(varCantConceptos)) Then varImporte(varCantConceptos) = "0"
                            If IsNothing(varClaveUnidad(varCantConceptos)) Then varClaveUnidad(varCantConceptos) = ""
                            If IsNothing(varClaveProd(varCantConceptos)) Then varClaveProd(varCantConceptos) = ""
                            If IsNothing(varCant(varCantConceptos)) Then varCant(varCantConceptos) = "0"

                            entraaconceptos = 1
                        End If
                    End If

                    If Lector.Name = "cfdi:Traslado" Then
                        If Lector.HasAttributes And entraaconceptos < 3 Then
                            Dim newtasacuota As String = ""
                            Dim newimporte As String = ""
                            Dim newbase As String = ""
                            Dim newimpuesto As String = ""

                            While Lector.MoveToNextAttribute()
                                'Mostrar valor y nombre del atributo
                                Select Case Lector.Name
                                    Case "Importe"
                                        newimporte = Lector.Value
                                    Case "Base"
                                        newbase = Lector.Value
                                    Case "TasaOCuota"
                                        newtasacuota = Lector.Value
                                    Case "Impuesto"
                                        newimpuesto = Lector.Value
                                End Select
                            End While

                            If newimpuesto = "002" Then
                                If newtasacuota = "0.160000" Then
                                    varIvaProd(varCantConceptos) = newimporte
                                    varIvaProdBase(varCantConceptos) = newbase
                                    varIvaProdTC(varCantConceptos) = CDec(newtasacuota) * 100
                                Else
                                    varIvaProd(varCantConceptos) = 0
                                    varIvaProdBase(varCantConceptos) = newbase
                                    varIvaProdTC(varCantConceptos) = CDec(newtasacuota) * 100
                                End If
                            ElseIf newimpuesto = "003" Then
                                varIIEPSProd(varCantConceptos) = newimporte
                                varIIEPSProdBase(varCantConceptos) = newbase
                                varIIEPSProdTC(varCantConceptos) = newtasacuota
                            End If

                            If IsNothing(varIvaProd(varCantConceptos)) Then varIvaProd(varCantConceptos) = "0"
                            If IsNothing(varIvaProdBase(varCantConceptos)) Then varIvaProdBase(varCantConceptos) = "0"
                            If IsNothing(varIvaProdTC(varCantConceptos)) Then varIvaProdTC(varCantConceptos) = "0"
                            If IsNothing(varIIEPSProd(varCantConceptos)) Then varIIEPSProd(varCantConceptos) = "0"
                            If IsNothing(varIIEPSProdBase(varCantConceptos)) Then varIIEPSProdBase(varCantConceptos) = "0"
                            If IsNothing(varIIEPSProdTC(varCantConceptos)) Then varIIEPSProdTC(varCantConceptos) = "0.00"

                            entraaconceptos += 1
                        End If
                    End If
            End Select
        Loop

        Dim varhaydetalle As Integer = 0

        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select Count(id_prod) as XD from detalle_factura where factura = " & varNumFolioFactId & "", sinfo) Then
                    If CInt(dr("XD").ToString) > 0 Then
                        varhaydetalle = CInt(dr("XD").ToString)
                    End If
                End If
                cnn.Close()
            End If
        End With

        If varhaydetalle = 0 Then
            sinfo = ""
            With oData
                For i = 0 To varCantConceptos
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        sSQL = "insert into detalle_factura(id_prod,descripcion,unidad,cantidad," &
                           "preciou,totaliva,porceniva,descuento,ret_iva," &
                           "ieps,cliente,factura,totalsiva,orden,clvsat," &
                           "isr,ieps_porcentaje,ieps_TasaoCuota,ret_iva_perc,ip_loc) " &
                           "values('" & varCodigoP(i) & "','" & varDescripcion(i) & "','" & varClaveUnidad(i) & "'," & varCant(i) & "," &
                           "" & varValUni(i) & "," & CDec(varImporte(i)) + CDec(varIvaProd(i)) + CDec(varIIEPSProd(i)) & "," & varIvaProdTC(i) & "," & varDesc(i) & ",0," &
                           "" & varIIEPSProd(i) & "," & varClienteId & "," & varNumFolioFactId & "," & varImporte(i) & "," & i + 1 & ",'" & varClaveProd(i) & "'," &
                           "0,'" & varIIEPSProdTC(i) & "','" & IIf(CDec(varIIEPSProd(i)) > 0, "Tasa", "") & "','0','" & dameIP2() & "')"
                        .runSp(cnn, sSQL, sinfo)
                        cnn.Close()
                    End If
                Next
            End With

        End If
    End Sub

    Private Sub btnParcialidades_Click(sender As Object, e As EventArgs) Handles btnParcialidades.Click
        folFactParc = Cmb_Nfactura.Text
        folFactParcID = Cmb_Nfactura.SelectedValue
        RazonID = cbo_emisor.SelectedValue
        EmiIdDatos = cbo_emisor.SelectedValue
        CliIdDatos = dame_IdClienteRFC(Cmb_RFC.Text)
        email = Text_Email.Text
        SeriePar = txt_serie.Text
        Me.Enabled = False
        frmParcialidades.Show()
    End Sub

    Private Sub ChkCargarClaves_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCargarClaves.CheckedChanged
        If ChkCargarClaves.Checked = True Then
            llena_cbo_descripcionticket()
            limpia_prod()
            My.Application.DoEvents()
            txt_unidadventaNew.Text = ""
            txt_prodsat.Text = ""

            MsgBox("Catálogos del SAT cargados")
            ChkCargarClaves.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cboFolio.SelectedValue = -1
        txtUUID.Text = ""
        GbUUID.Visible = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmMultiParcialidades.Show()
        frmMultiParcialidades.BringToFront()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtUUID.Text = "" Then Exit Sub
        dgUUID.Rows.Insert(0, cboFolio.Text, txtUUID.Text)
        cboFolio.SelectedValue = -1
        txtUUID.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        cboFolio.SelectedValue = -1
        txtUUID.Text = ""
        dgUUID.Rows.Clear()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GbUUID.Visible = False
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        On Error GoTo malo
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from facturas where nom_id=" & cboFolio.SelectedValue
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    txtUUID.Text = dr("nom_folio_sat_uuid").ToString
                End If
                cnn.Close()
            Else
            End If
        End With
malo:
    End Sub

    Private Sub txtIsrDet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIsrDet.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If txtIsrDet.Text = "" Then txtIsrDet.Text = "0"
            txt_partida.Focus()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmCartaPorte.Show()
        frmCartaPorte.BringToFront()
    End Sub

    Private Sub btnComplementoCP_Click(sender As Object, e As EventArgs) Handles btnComplementoCP.Click
        If grid_prods.RowCount > 0 Then
            If grid_prods.RowCount = 1 Then
                GroupBox9.Visible = True
                TabControl1.SelectedTab = TabPage1
                txtPlaca.Focus.Equals(True)
            Else
                MsgBox("Solo puede registrar un producto para hacer la referencia del FLETE")
            End If
            'Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            'Dim sSQL As String = ""
            'sSQL = "Select * from facturas where nom_folio=" & Cmb_Nfactura.Text
            'Dim dr As DataRow
            'Dim sinfo As String = ""
            'Dim oData As New ToolKitSQL.myssql
            'With oData
            '    If .dbOpen(cnn, sTarget, sinfo) Then
            '        If .getDr(cnn, dr, sSQL, sinfo) Then
            '        Else
            '            If grid_prods.RowCount > dgProductos.RowCount Then
            '                dgProductos.Rows.Clear()
            '                For i = 0 To grid_prods.RowCount - 1
            '                    dgProductos.Rows.Add(grid_prods.Rows(i).Cells(1).Value.ToString, grid_prods.Rows(i).Cells(2).Value.ToString, grid_prods.Rows(i).Cells(14).Value.ToString, grid_prods.Rows(i).Cells(3).Value.ToString, 0, 0, "", "", "", grid_prods.Rows(i).Cells(13).Value.ToString)
            '                Next
            '            End If
            '        End If
            '        cnn.Close()
            '    End If
            'End With

        Else
            MsgBox("Debe registrar los producto antes de abrir este apartado")
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            btnComplementoCP.Enabled = True
        Else
            btnComplementoCP.Enabled = False
            GroupBox7.Visible = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If cboDescripcion.Text = "" Then
            MsgBox("Selecciona un Producto para continuar!!!", vbInformation + vbOKOnly)
            cboDescripcion.Focus()
            Exit Sub
        ElseIf cboUniMedSAT.Text = "" Then
            MsgBox("Selecciona la unidad de medida para continuar!!!", vbInformation + vbOKOnly)
            cboDescripcion.Focus()
            Exit Sub
        ElseIf txtPesoKG.Text = 0 Then
            MsgBox("El peso la mercancia en KG debe ser mayor a 0!!!", vbInformation + vbOKOnly)
            txtPesoKG.Focus()
            Exit Sub
        ElseIf cboUniMedSAT.Text = "" Then
            MsgBox("Seleccione la unidad de medida del producto seleccionado")
            cboUniMedSAT.Focus()
            Exit Sub
        ElseIf cboProdServSAT.Text = "" Then
            MsgBox("Seleccione la clave del producto o servicio seleccionado")
            cboProdServSAT.Focus()
            Exit Sub
        Else

            Dim matpeg As String = ""
            Dim matpegdesc As String = ""
            Dim matembalaje As String = ""

            If chkMatPeg.Checked = False Then
                matpeg = "No"
                matpegdesc = ""
                matembalaje = ""
            Else
                matpeg = "Sí"
                If cboMatPeligroso.Text = "" Then MsgBox("Seleccione la clave del material peligroso seleccionado") : cboMatPeligroso.Focus() : Exit Sub
                matpegdesc = dameMaterialPeligroso(cboMatPeligroso.Text)
                matembalaje = dameEmbalaje(cboEmbalaje.Text)
            End If

            dgProductos.Rows.Add(cboDescripcion.Text, dameUnidadMedSATM(cboUniMedSAT.Text), dameClaveSATM(Trim(cboProdServSAT.Text)), txtCantidad.Text, txtValorMerc.Text, txtPesoKG.Text, "", Trim(txtUUIDComE.Text), Trim(txtFraccAran.Text), matpeg, matpegdesc, cboEmbalaje.Text, matembalaje, cboMatPeligroso.Text)

            'dgProductos.Rows.Add(cboDescripcion.Text, dameUnidadMedSATM(cboUniMedSAT.Text), dameClaveSATM(Trim(cboProdServSAT.Text)), txtCantidad.Text, txtValorMerc.Text, txtPesoKG.Text, "", Trim(txtUUIDComE.Text), Trim(txtFraccAran.Text))

            calculatotalpeso()

            cboDescripcion.Text = ""
            txtValorMerc.Text = ""
            txtPesoKG.Text = ""
            txtUUIDComE.Text = ""
            txtFraccAran.Text = ""
            cboUniMedSAT.Text = ""
            cboProdServSAT.Text = ""
            txtCantidad.Text = ""
            txtPartidaNew.Text = ""
            chkMatPeg.Checked = False
            cboMatPeligroso.Text = ""
            cboEmbalaje.Text = ""
        End If
    End Sub

    Private Sub btnAceptarCP_Click(sender As Object, e As EventArgs) Handles btnAceptarCP.Click
        GroupBox9.Visible = False
    End Sub

    Private Sub btnLimpiarCP_Click(sender As Object, e As EventArgs) Handles btnLimpiarCP.Click
        chkInter.Checked = False
        GroupBox13.Visible = False
        GroupBox19.Visible = False

        txtAseguradora.Text = ""
        txtNumPoliza.Text = ""
        txtModeloAño.Text = ""
        txtNumPermisoSCT.Text = ""
        txtPlaca.Text = ""
        cboConfigV.Text = ""
        cboPermisoSCT.Text = ""

        cboOrigRemitente.Text = ""
        txtOrigRFC.Text = ""
        dtpOrigFecha.Text = Date.Now
        dtpOrigHora.Text = "00:00:00"
        txtOrigCP.Text = ""
        txtOrigCalle.Text = ""
        txtOrigNumExt.Text = ""
        txtOrigNumInt.Text = ""
        cboOrigColonia.Text = ""
        cboOrigEdo.Text = ""
        cboOrigMun.Text = ""

        cboDesDestinatario.Text = ""
        txtDesRFC.Text = ""
        dtpDesFecha.Text = Date.Now
        dtpDesHora.Text = "00:00:00"
        txtDestinoCP.Text = ""
        cboDestinoPais.Text = ""
        txtDestinoCalle.Text = ""
        txtDestinoNumE.Text = ""
        txtDestinoNumI.Text = ""
        cboDestinoColonia.Text = ""
        cboDestinoEdo.Text = ""
        cboDestinoMun.Text = ""
        txtDestinioDist.Text = ""
        txtDestinoLoc.Text = ""

        cboTipoFigura.Text = ""
        cboOpeNombre.Text = ""
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""

        cboDescripcion.Text = ""
        txtValorMerc.Text = ""
        txtPesoKG.Text = ""
        txtTotalPeso.Text = ""
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
        txtNumPed1.Text = ""
        txtNumPed2.Text = ""
        txtNumPed3.Text = ""
        txtNumPed4.Text = ""

        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = ""

        txtPartidaNew.Text = ""

        dgProductos.Rows.Clear()

        DataGridView1.Rows.Clear()
        txtPlacaTipoRemolque.Text = ""
        cboTipoRemolque.Text = ""

        chkMatPeg.Checked = False
        cboMatPeligroso.Text = ""
        cboEmbalaje.Text = ""

        txtAseguradoraMatPel.Text = ""
        txtNumPolizaMatPel.Text = ""

        'For i = 0 To grid_prods.RowCount - 1
        '    dgProductos.Rows.Add(grid_prods.Rows(i).Cells(1).Value.ToString, grid_prods.Rows(i).Cells(2).Value.ToString, grid_prods.Rows(i).Cells(14).Value.ToString, grid_prods.Rows(i).Cells(3).Value.ToString, 0, 0, "", "", "", grid_prods.Rows(i).Cells(13).Value.ToString)
        'Next
    End Sub

    Private Sub dgProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgProductos.RowsRemoved
        calculatotalpeso()
    End Sub

    Sub calculatotalpeso()
        txtTotalPeso.Text = "0"

        For i = 0 To dgProductos.RowCount - 1
            txtTotalPeso.Text = CDec(txtTotalPeso.Text) + CDec(dgProductos.Rows(i).Cells(3).Value.ToString)
        Next
    End Sub

    Private Sub cboOrigEdo_DropDown(sender As Object, e As EventArgs) Handles cboOrigEdo.DropDown
        cboOrigEdo.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Nombre from PorteEstados where Pais = 'MEX'", sinfo) Then
                    For Each dr In dt.Rows
                        cboOrigEdo.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboOrigColonia_DropDown(sender As Object, e As EventArgs) Handles cboOrigColonia.DropDown
        cboOrigColonia.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                If txtOrigCP.Text <> "" Then
                    str = "select Nombre from PorteColonia where CP = '" & txtOrigCP.Text & "' order by Nombre"
                    If .getDt(cnn, dt, str, sinfo) Then
                        For Each dr In dt.Rows
                            cboOrigColonia.Items.Add(dr("Nombre").ToString)
                        Next
                    End If
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboOrigMun_DropDown(sender As Object, e As EventArgs) Handles cboOrigMun.DropDown
        cboOrigMun.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = "select Descripcion from PorteMunicipios order by Descripcion"
                If cboOrigEdo.Text <> "" Then
                    str = "select Descripcion from PorteMunicipios where ClaveEdo = '" & dameclaveEdo() & "' order by Descripcion"
                End If
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboOrigMun.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboDestinoPais_DropDown(sender As Object, e As EventArgs) Handles cboDestinoPais.DropDown
        cboDestinoPais.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Nombre from PortePais order by Nombre"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboDestinoPais.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboDestinoColonia_DropDown(sender As Object, e As EventArgs) Handles cboDestinoColonia.DropDown
        cboDestinoColonia.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                If txtDestinoCP.Text <> "" Then
                    str = "select Nombre from PorteColonia where CP = '" & txtDestinoCP.Text & "' order by Nombre"
                    If .getDt(cnn, dt, str, sinfo) Then
                        For Each dr In dt.Rows
                            cboDestinoColonia.Items.Add(dr("Nombre").ToString)
                        Next
                    End If
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboDestinoEdo_DropDown(sender As Object, e As EventArgs) Handles cboDestinoEdo.DropDown
        cboDestinoEdo.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = "select Nombre from PorteEstados where Pais = 'MEX'"
                If Trim(cboDestinoPais.Text) <> "" Then
                    str = "select Nombre from PorteEstados where Pais = '" & dameclavePais() & "'"
                Else
                    str = "select Nombre from PorteEstados where Pais = 'MEX1'"
                End If
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboDestinoEdo.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Function dameclavePais() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClavePais from PortePais where Nombre = '" & Trim(cboDestinoPais.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClavePais").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Sub cboDestinoMun_DropDown(sender As Object, e As EventArgs) Handles cboDestinoMun.DropDown
        cboDestinoMun.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = "select Descripcion from PorteMunicipios order by Descripcion"
                If cboDestinoEdo.Text <> "" Then
                    str = "select Descripcion from PorteMunicipios where ClaveEdo = '" & dameclaveEdoD() & "' order by Descripcion"
                End If
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboDestinoMun.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Function dameclaveEdoD() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveEdo from PorteEstados where Nombre = '" & Trim(cboDestinoEdo.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClaveEdo").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Function dameclaveColoniaD() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveColonia from PorteColonia where Nombre = '" & Trim(cboDestinoColonia.Text) & "' and CP = '" & txtDestinoCP.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClaveColonia").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Function dameclaveMunD() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveMun from PorteMunicipios where Descripcion = '" & Trim(cboDestinoMun.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClaveMun").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Sub cboPermisoSCT_DropDown(sender As Object, e As EventArgs) Handles cboPermisoSCT.DropDown
        cboPermisoSCT.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Descripcion from PorteTipoPermiso order by Descripcion"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboPermisoSCT.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Function dameclavePermisoSCT() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Clave from PorteTipoPermiso where Descripcion = '" & Trim(cboPermisoSCT.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("Clave").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Sub cboConfigV_DropDown(sender As Object, e As EventArgs) Handles cboConfigV.DropDown
        cboConfigV.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Descripcion from PorteConfigAutotrans order by Descripcion"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboConfigV.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Function dameclaveConfigV() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Clave from PorteConfigAutotrans where Descripcion = '" & Trim(cboConfigV.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("Clave").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Sub cboOrigRemitente_DropDown(sender As Object, e As EventArgs) Handles cboOrigRemitente.DropDown
        cboOrigRemitente.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Remitente from PorteOrigen order by Remitente"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboOrigRemitente.Items.Add(dr("Remitente").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboDesDestinatario_DropDown(sender As Object, e As EventArgs) Handles cboDesDestinatario.DropDown
        cboDesDestinatario.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Destinatario from PorteDestino order by Destinatario"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboDesDestinatario.Items.Add(dr("Destinatario").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboOpeNombre_DropDown(sender As Object, e As EventArgs) Handles cboOpeNombre.DropDown
        cboOpeNombre.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Nombre from PorteOperador order by Nombre"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboOpeNombre.Items.Add(dr("Nombre").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboOrigRemitente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboOrigRemitente.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from PorteOrigen where Remitente = '" & Trim(cboOrigRemitente.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            txtOrigRFC.Text = dr("RFC").ToString
                            txtOrigCP.Text = dr("CP").ToString
                            txtOrigCalle.Text = dr("Calle").ToString
                            txtOrigNumExt.Text = dr("NumExt").ToString
                            txtOrigNumInt.Text = dr("NumInt").ToString
                            cboOrigColonia.Text = dr("Colonia").ToString
                            cboOrigEdo.Text = dr("Edo").ToString
                            cboOrigMun.Text = dr("Mun").ToString
                        Next
                    Else
                        txtOrigRFC.Text = ""
                        txtOrigCP.Text = ""
                        txtOrigCalle.Text = ""
                        txtOrigNumExt.Text = ""
                        txtOrigNumInt.Text = ""
                        cboOrigColonia.Text = ""
                        cboOrigEdo.Text = ""
                        cboOrigMun.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboOrigRemitente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboOrigRemitente.SelectedValueChanged
        On Error GoTo puertita
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from PorteOrigen where Remitente = '" & Trim(cboOrigRemitente.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        txtOrigRFC.Text = dr("RFC").ToString
                        txtOrigCP.Text = dr("CP").ToString
                        txtOrigCalle.Text = dr("Calle").ToString
                        txtOrigNumExt.Text = dr("NumExt").ToString
                        txtOrigNumInt.Text = dr("NumInt").ToString
                        cboOrigColonia.Text = dr("Colonia").ToString
                        cboOrigEdo.Text = dr("Edo").ToString
                        cboOrigMun.Text = dr("Mun").ToString
                    Next
                Else
                    txtOrigRFC.Text = ""
                    txtOrigCP.Text = ""
                    txtOrigCalle.Text = ""
                    txtOrigNumExt.Text = ""
                    txtOrigNumInt.Text = ""
                    cboOrigColonia.Text = ""
                    cboOrigEdo.Text = ""
                    cboOrigMun.Text = ""
                End If
                cnn.Close()
            End If
        End With
        Exit Sub

puertita:
        txtOrigRFC.Text = ""
        txtOrigCP.Text = ""
        txtOrigCalle.Text = ""
        txtOrigNumExt.Text = ""
        txtOrigNumInt.Text = ""
        cboOrigColonia.Text = ""
        cboOrigEdo.Text = ""
        cboOrigMun.Text = ""
    End Sub

    Private Sub cboDesDestinatario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDesDestinatario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from PorteDestino where Destinatario = '" & Trim(cboDesDestinatario.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            txtDesRFC.Text = dr("RFC").ToString
                            txtDestinoCP.Text = dr("CP").ToString
                            txtDestinoCalle.Text = dr("Calle").ToString
                            txtDestinoNumE.Text = dr("NumE").ToString
                            txtDestinoNumI.Text = dr("NumI").ToString
                            cboDestinoColonia.Text = dr("Colonia").ToString
                            cboDestinoEdo.Text = dr("Edo").ToString
                            cboDestinoMun.Text = dr("Mun").ToString
                            txtDestinioDist.Text = "0"
                            txtDestinoLoc.Text = dr("Loc").ToString
                            cboDestinoPais.Text = dr("Pais").ToString
                        Next
                    Else
                        txtDesRFC.Text = ""
                        txtDestinoCP.Text = ""
                        txtDestinoCalle.Text = ""
                        txtDestinoNumE.Text = ""
                        txtDestinoNumI.Text = ""
                        cboDestinoColonia.Text = ""
                        cboDestinoEdo.Text = ""
                        cboDestinoMun.Text = ""
                        txtDestinioDist.Text = "0"
                        txtDestinoLoc.Text = ""
                        cboDestinoPais.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboDesDestinatario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDesDestinatario.SelectedValueChanged
        On Error GoTo puertita
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from PorteDestino where Destinatario = '" & Trim(cboDesDestinatario.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        txtDesRFC.Text = dr("RFC").ToString
                        txtDestinoCP.Text = dr("CP").ToString
                        txtDestinoCalle.Text = dr("Calle").ToString
                        txtDestinoNumE.Text = dr("NumE").ToString
                        txtDestinoNumI.Text = dr("NumI").ToString
                        cboDestinoColonia.Text = dr("Colonia").ToString
                        cboDestinoEdo.Text = dr("Edo").ToString
                        cboDestinoMun.Text = dr("Mun").ToString
                        txtDestinioDist.Text = "0"
                        txtDestinoLoc.Text = dr("Loc").ToString
                        cboDestinoPais.Text = dr("Pais").ToString
                    Next
                Else
                    txtDesRFC.Text = ""
                    txtDestinoCP.Text = ""
                    txtDestinoCalle.Text = ""
                    txtDestinoNumE.Text = ""
                    txtDestinoNumI.Text = ""
                    cboDestinoColonia.Text = ""
                    cboDestinoEdo.Text = ""
                    cboDestinoMun.Text = ""
                    txtDestinioDist.Text = "0"
                    txtDestinoLoc.Text = ""
                    cboDestinoPais.Text = ""
                End If
                cnn.Close()
            End If
        End With
        Exit Sub

puertita:

        txtDesRFC.Text = ""
        txtDestinoCP.Text = ""
        txtDestinoCalle.Text = ""
        txtDestinoNumE.Text = ""
        txtDestinoNumI.Text = ""
        cboDestinoColonia.Text = ""
        cboDestinoEdo.Text = ""
        cboDestinoMun.Text = ""
        txtDestinioDist.Text = "0"
        txtDestinoLoc.Text = ""
        cboDestinoPais.Text = ""
    End Sub

    Private Sub cboOpeNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboOpeNombre.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If cboTipoFigura.Text = "Operador" Then
                        If .getDt(cnn, dt, "select * from PorteOperador where Nombre = '" & Trim(cboOpeNombre.Text) & "' ", sinfo) Then
                            For Each dr In dt.Rows
                                txtOpeRFC.Text = dr("RFC").ToString
                                txtOpeLicencia.Text = dr("Licencia").ToString
                            Next
                        Else
                            txtOpeRFC.Text = ""
                            txtOpeLicencia.Text = ""
                        End If
                    Else
                        If .getDt(cnn, dt, "select * from PortePropietario where Nombre = '" & Trim(cboOpeNombre.Text) & "' ", sinfo) Then
                            For Each dr In dt.Rows
                                txtOpeRFC.Text = dr("RFC").ToString
                                txtOpeLicencia.Text = dr("Licencia").ToString
                            Next
                        Else
                            txtOpeRFC.Text = ""
                            txtOpeLicencia.Text = ""
                        End If
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboOpeNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboOpeNombre.SelectedValueChanged
        On Error GoTo puertita
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If cboTipoFigura.Text = "Operador" Then
                    If .getDt(cnn, dt, "select * from PorteOperador where Nombre = '" & Trim(cboOpeNombre.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            txtOpeRFC.Text = dr("RFC").ToString
                            txtOpeLicencia.Text = dr("Licencia").ToString
                        Next
                    Else
                        txtOpeRFC.Text = ""
                        txtOpeLicencia.Text = ""
                    End If
                Else
                    If .getDt(cnn, dt, "select * from PortePropietario where Nombre = '" & Trim(cboOpeNombre.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            txtOpeRFC.Text = dr("RFC").ToString
                            txtOpeLicencia.Text = dr("Licencia").ToString
                        Next
                    Else
                        txtOpeRFC.Text = ""
                        txtOpeLicencia.Text = ""
                    End If
                End If
                cnn.Close()
            End If
        End With
        Exit Sub
puertita:
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""
    End Sub

    Private Function dameclaveEdo() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveEdo from PorteEstados where Nombre = '" & Trim(cboOrigEdo.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClaveEdo").ToString
                    Next
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
            End If
        End With
        Return ""
    End Function

    Private Sub txtPlaca_DropDown(sender As Object, e As EventArgs) Handles txtPlaca.DropDown
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select distinct Placas from Transporte order by Placas"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        txtPlaca.Items.Clear()
        Try
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            txtPlaca.Items.Add(dr(0).ToString)
                        Next
                    End If
                    cnn.Close()
                Else
                    MsgBox(sinfo)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn.Close()
        End Try
    End Sub

    Function dameClaveSATM(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveProdSat FROM PorteProductoSat where Descripcion = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("ClaveProdSat").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameClaveSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameClaveSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Function dameUnidadMedSATM(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveUnidad FROM PorteUnidadMedEmb where Nombre = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("ClaveUnidad").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameUnidadMedSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameUnidadMedSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    Function dameDesUnidadMedSATM(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Nombre FROM PorteUnidadMedEmb where ClaveUnidad = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("Nombre").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameDesUnidadMedSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameDesUnidadMedSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    Function dameDesClaveSATM(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Descripcion FROM PorteProductoSat where ClaveProdSat = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("Descripcion").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameDesClaveSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameDesClaveSATM' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub txtPlaca_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtPlaca.SelectedValueChanged
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from Transporte where Placas='" & txtPlaca.Text & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        Try
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            txtModeloAño.Text = dr("Modelo").ToString()
                            txtAseguradora.Text = dr("Seguro").ToString()
                            txtNumPoliza.Text = dr("NumPoliza").ToString()
                        Next
                    End If
                    cnn.Close()
                Else
                    MsgBox(sinfo)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn.Close()
        End Try
    End Sub

    Private Sub chkInter_CheckedChanged(sender As Object, e As EventArgs) Handles chkInter.CheckedChanged
        If chkInter.Checked = True Then
            GroupBox13.Visible = True
            GroupBox19.Visible = True
        Else
            GroupBox13.Visible = False
            GroupBox19.Visible = False
        End If
    End Sub

    Private Sub cboDescripcion_DropDown(sender As Object, e As EventArgs) Handles cboDescripcion.DropDown
        cboDescripcion.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select distinct Descripcion from PorteMercancia order by Descripcion"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboDescripcion.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboDescripcion.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from PorteMercancia where Descripcion = '" & Trim(cboDescripcion.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            cboUniMedSAT.Text = dameDesUnidadMedSATM(dr("UniMedSAT").ToString)
                            cboProdServSAT.Text = dameDesClaveSATM(dr("ProdServSAT").ToString)
                            txtCantidad.Text = "1"
                            txtValorMerc.Text = "0"
                            txtPesoKG.Text = "0"
                            txtUUIDComE.Text = ""
                            txtFraccAran.Text = ""
                        Next
                    Else
                        cboUniMedSAT.Text = ""
                        cboProdServSAT.Text = ""
                        txtCantidad.Text = "1"
                        txtValorMerc.Text = "0"
                        txtPesoKG.Text = "0"
                        txtUUIDComE.Text = ""
                        txtFraccAran.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboDescripcion_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedValueChanged
        On Error GoTo puertita
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from PorteMercancia where Descripcion = '" & Trim(cboDescripcion.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        cboUniMedSAT.Text = dameDesUnidadMedSATM(dr("UniMedSAT").ToString)
                        cboProdServSAT.Text = dameDesClaveSATM(dr("ProdServSAT").ToString)
                        txtCantidad.Text = "1"
                        txtValorMerc.Text = "0"
                        txtPesoKG.Text = "0"
                        txtUUIDComE.Text = ""
                        txtFraccAran.Text = ""

                    Next
                Else
                    cboUniMedSAT.Text = ""
                    cboProdServSAT.Text = ""
                    txtCantidad.Text = "1"
                    txtValorMerc.Text = "0"
                    txtPesoKG.Text = "0"
                    txtUUIDComE.Text = ""
                    txtFraccAran.Text = ""

                End If
                cnn.Close()
            End If
        End With
        Exit Sub
puertita:
        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = "1"
        txtValorMerc.Text = "0"
        txtPesoKG.Text = "0"
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
    End Sub

    Private Sub cboTipoFigura_DropDown(sender As Object, e As EventArgs) Handles cboTipoFigura.DropDown
        cboTipoFigura.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Descripcion from PorteFigura", sinfo) Then
                    For Each dr In dt.Rows
                        cboTipoFigura.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If txtPlacaTipoRemolque.Text = "" Then
            MsgBox("Datos obligatorios requeridos !!!", vbInformation + vbOKOnly)
            txtPlacaTipoRemolque.Focus()
            Exit Sub
        ElseIf cboTipoRemolque.Text = "" Then
            MsgBox("Datos obligatorios requeridos !!!", vbInformation + vbOKOnly)
            cboTipoRemolque.Focus()
            Exit Sub
        Else
            DataGridView1.Rows.Add(txtPlacaTipoRemolque.Text, cboTipoRemolque.Text, dameTipoRemolque(cboTipoRemolque.Text))
            txtPlacaTipoRemolque.Text = ""
            cboTipoRemolque.Text = ""
            btnAceptarCP.Focus()
        End If
    End Sub

    Function dameTipoRemolque(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveTipoRemolque FROM PorteTipoRemolque where Remolque = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("ClaveTipoRemolque").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameTipoRemolque' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameTipoRemolque' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub cboTipoRemolque_DropDown(sender As Object, e As EventArgs) Handles cboTipoRemolque.DropDown
        cboTipoRemolque.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Remolque from PorteTipoRemolque order by Remolque"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboTipoRemolque.Items.Add(dr("Remolque").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboMeses_DropDown(sender As Object, e As EventArgs) Handles cboMeses.DropDown
        cboMeses.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Descripcion from MesesSat order by Descripcion"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboMeses.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboPeriodicidad_DropDown(sender As Object, e As EventArgs) Handles cboPeriodicidad.DropDown
        cboPeriodicidad.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = ""
                str = "select Descripcion from PeriodicidadSat order by Descripcion"
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboPeriodicidad.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        busca_d()
        Dim str As String = ""
        Select Case Trim(cboTipoCancelacion.Text)
            Case "Comprobantes emitidos con errores con relación"
                str = "01"
                If Trim(txtUUIDCanelacion.Text) = "" Then
                    MsgBox("Debe escribir un uuid para relacionarlo con la cancelación")
                    txtUUIDCanelacion.Focus()
                    Exit Sub
                End If
            Case "Comprobantes emitidos con errores sin relación"
                str = "02"
            Case "No se llevó a cabo la operación"
                str = "03"
            Case "Operación nominativa relacionada en una factura global"
                str = "04"
            Case ""
                MsgBox("Debe seleccionar un tipo de cancelación")
                cboTipoCancelacion.Focus()
                Exit Sub
        End Select
        cancela(uidcancel, refccancel, Cmb_Nfactura.Text, str, txtUUIDCanelacion.Text)
        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
    End Sub

    Function dameMaterialPeligroso(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveMatPel FROM PorteMatPeligrosos where Descripcion = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.

                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("ClaveMatPel").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameMaterialPeligroso' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameMaterialPeligroso' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Function dameEmbalaje(ByVal varDesc As String) As String
        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveDesignacion FROM PorteTipoEmbalaje where Descripcion = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTarget, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If odata.getDr(cnn, dr, sSQL, sInfo) Then
                    cnn.Close()
                    Return dr("ClaveDesignacion").ToString
                Else
                    cnn.Close()
                    Return ""
                End If
                cnn.Close()
                Return ""
            End If
        End With
#Disable Warning BC42105 ' La función 'dameEmbalaje' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'dameEmbalaje' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.

    Private Sub btnDatosEmi_Click(sender As Object, e As EventArgs) Handles btnDatosEmi.Click
        If gbLE.Visible = True Then
            gbLE.Visible = False
        Else
            gbLE.Visible = True
        End If
    End Sub

    Private Sub cboLEdomi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboLEdomi.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Trim(cboLEdomi.Text) <> "" Then
                If IsNumeric(Trim(cboLEdomi.Text)) Then
                    Dim sinfo As String = ""
                    Dim sSQL As String = "Select * from DatosNegocio where Emisor_id=" & Trim(cboLEdomi.Text)
                    Dim dr As DataRow
                    Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                    Dim odata As New ToolKitSQL.myssql
                    If odata.dbOpen(cnn, sTarget, sinfo) Then
                        If odata.getDr(cnn, dr, sSQL, sinfo) Then
                            txtLEcalle.Text = dr("Em_calle").ToString
                            txtLEnumext.Text = dr("Em_NumExterior").ToString
                            txtLEnumint.Text = dr("Em_NumInterior").ToString
                            txtLEcodpos.Text = dr("Em_CP").ToString
                            txtLEcolonia.Text = dr("Em_colonia").ToString
                            txtLEalcmun.Text = dr("Em_Municipio").ToString
                            txtLEedo.Text = dr("Em_Estado").ToString
                        Else
                            MsgBox("Debe seleccionar un número de domicilio del combo")
                            cboLEdomi.Text = ""
                            txtLEcalle.Text = ""
                            txtLEnumext.Text = ""
                            txtLEnumint.Text = ""
                            txtLEcodpos.Text = ""
                            txtLEcolonia.Text = ""
                            txtLEalcmun.Text = ""
                            txtLEedo.Text = ""
                        End If
                        cnn.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cboLEdomi_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboLEdomi.SelectedValueChanged
        On Error GoTo puertita
        Dim sinfo As String = ""
        Dim sSQL As String = "Select * from DatosNegocio where Emisor_id=" & Trim(cboLEdomi.Text)
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                txtLEcalle.Text = dr("Em_calle").ToString
                txtLEnumext.Text = dr("Em_NumExterior").ToString
                txtLEnumint.Text = dr("Em_NumInterior").ToString
                txtLEcodpos.Text = dr("Em_CP").ToString
                txtLEcolonia.Text = dr("Em_colonia").ToString
                txtLEalcmun.Text = dr("Em_Municipio").ToString
                txtLEedo.Text = dr("Em_Estado").ToString
            End If
            cnn.Close()
        End If
puertita:
        cnn.Close()
    End Sub

    Private Sub btnGuardarCliente_Click(sender As Object, e As EventArgs) Handles btnGuardarCliente.Click
        Dim existe As Integer = 0
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select Id from Clientes where RFC = '" & Trim(Cmb_RFC.Text) & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    existe = CInt(dr("Id").ToString)
                Else
                    existe = 0
                End If
                cnn.Close()
            End If
        End With

        If existe <> 0 Then
            If Trim(Cmb_RazonS.Text) = "" Then MsgBox("Debe escribir la razón social") : Cmb_RazonS.Focus() : Exit Sub
            If Trim(Text_CP.Text) = "" Then MsgBox("Debe escribir un codigo postal") : Text_CP.Focus() : Exit Sub
            If Trim(cbo_regimen.Text) = "" Then MsgBox("Debe seleccionar un regimen fiscal") : cbo_regimen.Focus() : Exit Sub

            If MsgBox("El cliente ya existe, ¿Desea actualizar los datos?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cnn = New MySqlClient.MySqlConnection
                sSQL = ""
                sinfo = ""
                oData = New ToolKitSQL.myssql
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        Dim ssql2 As String = "Update Clientes set Nombre = '" & Trim(txt_nombrec.Text) & "',  RazonSocial='" & Trim(Cmb_RazonS.Text) & "', Calle='" & Trim(Text_calle.Text) &
                                                   "', CNumberExt='" & Trim(Text_Num_Ex.Text) & "', CNumberInt='" & Trim(Txt_num_int.Text) & "', CP='" & Trim(Text_CP.Text) &
                                                   "', Colonia='" & Trim(Text_Colonia.Text) & "', Delegacion='" & Trim(Text_Delegacion.Text) & "', Entidad='" & Trim(Text_Edo.Text) &
                                                   "', CPais='" & Text_Pais.Text & "', Email='" & Trim(Text_Email.Text) & "', Regfis = '" & cbo_regimen.SelectedValue & "' where Id=" & existe
                        oData.runSp(cnn, ssql2, sinfo)
                        cnn.Close()
                    End If
                End With
            End If
        Else
            If Trim(Cmb_RazonS.Text) = "" Then MsgBox("Debe escribir la razón social") : Cmb_RazonS.Focus() : Exit Sub
            If Trim(Cmb_RFC.Text) = "" Then MsgBox("Debe escribir el RFC") : Cmb_RFC.Focus() : Exit Sub
            If Trim(Text_CP.Text) = "" Then MsgBox("Debe escribir un codigo postal") : Text_CP.Focus() : Exit Sub
            If Trim(cbo_regimen.Text) = "" Then MsgBox("Debe seleccionar un regimen fiscal") : cbo_regimen.Focus() : Exit Sub

            If MsgBox("¿Desea guardar al Cliente?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                cnn = New MySqlClient.MySqlConnection
                sinfo = ""
                oData = New ToolKitSQL.myssql
                With oData
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDr(cnn, dr, "Select max(Id) as maxi from Clientes", sinfo) Then
                            existe = CInt(dr("maxi").ToString) + 1
                        Else
                            existe = 1
                        End If
                        Dim ssql2 As String = "insert into Clientes (Id, Nombre, RazonSocial, Tipo, RFC, Calle, Colonia, Delegacion, Entidad, CP, Correo, Credito, DiasCred, NExterior, NInterior, Pais, Regfis)values(" & existe & ", '" & Trim(txt_nombrec.Text) & "','" &
                                                     Trim(Cmb_RazonS.Text) & "','Lista','" & Trim(Cmb_RFC.Text) & "','" & Trim(Text_calle.Text) & "','" & Trim(Text_Colonia.Text) & "','" & Trim(Text_Delegacion.Text) & "','" & Trim(Text_Edo.Text) & "','" & Trim(Text_CP.Text) & "','" & Trim(Text_Email.Text) &
                                                     "','0.00','0','" & Trim(Text_Num_Ex.Text) & "','" & Trim(Txt_num_int.Text) & "','" & Trim(Text_Pais.Text) & "', '" & cbo_regimen.SelectedValue & "')"
                        oData.runSp(cnn, ssql2, sinfo)
                        cnn.Close()
                    End If
                End With
            End If
        End If

        var_cliente = dame_IdClienteRS(Cmb_RazonS.Text)
        muestra_datos_cliente()

        If Cmb_RFC.Text = "XAXX010101000" Then
            btnGlobal.Enabled = True
        Else
            btnGlobal.Enabled = False
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If cboMeses.Text = "" Then MsgBox("Debe seleccionar el mes o los meses de la factura global") : Exit Sub
        If cboPeriodicidad.Text = "" Then MsgBox("Debe seleccionar el periodo para factura global") : Exit Sub
        If txtAno.Text = "" Then MsgBox("Debe escribir el año para factura global") : Exit Sub

        GroupBox7.Visible = False
    End Sub

    Private Sub cbouser_DropDown(sender As Object, e As EventArgs) Handles cbouser.DropDown
        cbouser.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select distinct Usuario from Ventas where FVenta Between '" & Format(dtpDesde.Value, "yyyy-MM-dd") & "' And '" & Format(dtpHasta.Value, "yyyy-MM-dd") & "' and Facturado = '0' order by Usuario"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        cbouser.Items.Add(dr(0).ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cbouser_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbouser.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sSql As String = "select * from Usuarios where Alias='" & cbouser.Text & "'"
            Dim dr As DataRow
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql

            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, sSql, sinfo) Then
                        Button3.Focus().Equals(True)
                    Else
                        MsgBox("El usuario no existe o su Alias fue modificado." & vbNewLine & "Revisa la información.")
                        Exit Sub
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        On Error GoTo puertitaXD

        Dim var_nom As String = ""

        Dim EmiTicketCalle As String = ""
        Dim EmiTicketNumExt As String = ""
        Dim EmiTicketNumInt As String = ""
        Dim EmiTicketCol As String = ""
        Dim EmiTicketDel As String = ""
        Dim EmiTicketCP As String = ""
        Dim EmiTicketEdo As String = ""
        Dim EmiTicketPais As String = ""
        Dim EmiTicketRegFis As String = ""
        Dim EmiTicketRegFis1 As String = ""

        Dim FactFechaEmision As String = ""
        Dim FactFechaCertif As String = ""
        Dim FactCertSAT As String = ""
        Dim FactCertEmisor As String = ""
        Dim FactUUID As String = ""
        Dim FactCFDI As String = ""
        Dim FactCFDI1 As String = ""
        Dim FactTipoPago As String = ""
        Dim FactFormaPago As String = ""
        Dim FactSelloDigital As String = ""
        Dim FactSelloSat As String = ""
        Dim FactCadenaOrig As String = ""

        Dim CliTicketRegFis As String = ""

        Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from DatosNegocio where Em_RazonSocial = '" & cbo_emisor.Text & "' and Em_rfc='" & cbo_rfc_emisor.Text & "'"
        Dim dr As DataRow
        Dim dt As DataTable
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim odata1 As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                EmiTicketCalle = dr("Em_calle").ToString()
                EmiTicketNumExt = dr("Em_NumExterior").ToString()
                EmiTicketNumInt = dr("Em_NumInterior").ToString()
                EmiTicketCol = dr("Em_colonia").ToString()
                EmiTicketDel = dr("Em_Municipio").ToString()
                EmiTicketCP = dr("Em_CP").ToString()
                EmiTicketEdo = dr("Em_Estado").ToString()
                EmiTicketPais = dr("Em_Pais").ToString()
                EmiTicketRegFis = dr("Em_RFiscal").ToString()
                If odata1.dbOpen(cnn1, sTarget, sinfo) Then
                    odata1.getDt(cnn1, dt, "select * from RegimenFiscalSat where ClaveRegFis = '" & EmiTicketRegFis & "'", sinfo)
                    For Each dr In dt.Rows
                        EmiTicketRegFis1 = dr("Descripcion").ToString()
                    Next
                    cnn1.Close()
                End If
                cnn.Close()
            Else
                cnn.Close()
            End If
            cnn.Close()
        End If

        sSQL = "Select * from Facturas where nom_folio = " & Cmb_Nfactura.Text & ""
        sinfo = ""
        Dim dr1 As DataRow
        Dim dt1 As DataTable
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                var_idfactura = dr("nom_id").ToString()
                FactFechaEmision = dr("nom_fecha_factura").ToString()
                FactFechaCertif = dr("nom_fecha_folio_sat").ToString()
                FactCertSAT = dr("nom_no_csd_sat").ToString()
                FactCertEmisor = dr("nom_no_csd_emp").ToString()
                FactUUID = dr("nom_folio_sat_uuid").ToString()
                FactCFDI = dr("UsoCFDI").ToString()
                If odata1.dbOpen(cnn1, sTarget, sinfo) Then
                    odata1.getDt(cnn1, dt1, "select * from UsoComproCFDISat where ClaveUsoCFDI = '" & FactCFDI & "'", sinfo)
                    For Each dr1 In dt1.Rows
                        FactCFDI1 = dr1("Descripcion").ToString()
                    Next
                    cnn1.Close()
                End If
                FactTipoPago = dr("nom_tipo_pago").ToString()
                FactFormaPago = dr("nom_metodo_pago").ToString()
                FactSelloDigital = dr("nom_sello_emisor").ToString()
                FactSelloSat = dr("nom_sello_sat").ToString()
                FactCadenaOrig = dr("nom_cadena_original").ToString()
                cnn.Close()
            Else
                cnn.Close()
            End If
            cnn.Close()
        End If

        sinfo = ""
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDr(cnn, dr, "Select ClaveRegFis from RegimenFiscalSat where Descripcion = '" & cbo_regimen.Text & "'", sinfo) Then
                CliTicketRegFis = dr("ClaveRegFis").ToString()
            End If
            cnn.Close()
        End If

        Dim XD As Double = 0
        Dim nuevaIMG As Drawing.Image = PictureBox1.Image
        ' La fuente a usar
        Dim prFont As New Drawing.Font("Arial", 10, FontStyle.Bold)

        e.Graphics.DrawImage(nuevaIMG, 52, 1, 140, 95)
        XD = 110

puertitaXD:

        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)

        e.Graphics.DrawString(Cmb_TipoFact.Text, prFont, Brushes.Black, 1, XD)
        XD += 28

        If txt_serie.Text <> "" Then
            e.Graphics.DrawString("Serie: " & txt_serie.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        e.Graphics.DrawString("Folio: " & Cmb_Nfactura.Text, prFont, Brushes.Black, 1, XD)
        XD += 28

        'datos emisor
        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("Emisor:", prFont, Brushes.Black, 1, XD)
        XD += 28

        prFont = New Drawing.Font("Arial", 9, FontStyle.Bold)
        'razon social
        e.Graphics.DrawString(cbo_emisor.Text, prFont, Brushes.Black, 1, XD)
        XD += 18

        'rfc
        e.Graphics.DrawString(cbo_rfc_emisor.Text, prFont, Brushes.Black, 1, XD)
        XD += 18

        prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
        'calle
        If EmiTicketCalle <> "" Then
            e.Graphics.DrawString("Calle: " & EmiTicketCalle, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'numero ext y numero interior
        If EmiTicketNumExt <> "" Then
            If EmiTicketNumInt <> "" Then
                e.Graphics.DrawString("Núm. Ext.: " & EmiTicketNumExt & " Int.: " & EmiTicketNumInt, prFont, Brushes.Black, 1, XD)
                XD += 18
            Else
                e.Graphics.DrawString("Núm. Ext.: " & EmiTicketNumExt, prFont, Brushes.Black, 1, XD)
                XD += 18
            End If
        End If

        'colonia
        If EmiTicketCol <> "" Then
            e.Graphics.DrawString("Colonia: " & EmiTicketCol, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'delegacion
        If EmiTicketDel <> "" Then
            e.Graphics.DrawString("Alcaldía o Municipio: " & EmiTicketDel, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'codigo postal
        If EmiTicketCP <> "" Then
            e.Graphics.DrawString("Código Postal: " & EmiTicketCP, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'entidad feder
        If EmiTicketEdo <> "" Then
            e.Graphics.DrawString("Estado: " & EmiTicketEdo, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'pais
        If EmiTicketPais <> "" Then
            e.Graphics.DrawString("País: " & EmiTicketPais, prFont, Brushes.Black, 1, XD)
            XD += 18
        Else
            e.Graphics.DrawString("País: México", prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'regimen fiscal
        var_nom = ""
        e.Graphics.DrawString(Mid("Régimen Fiscal Emisor: " & EmiTicketRegFis & " " & EmiTicketRegFis1, 1, 46), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid("Régimen Fiscal Emisor: " & EmiTicketRegFis & " " & EmiTicketRegFis1, 47, 46)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid("Régimen Fiscal Emisor: " & EmiTicketRegFis & " " & EmiTicketRegFis1, 47, 46), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid("Régimen Fiscal Emisor: " & EmiTicketRegFis & " " & EmiTicketRegFis1, 93, 46)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid("Régimen Fiscal Emisor: " & EmiTicketRegFis & " " & EmiTicketRegFis1, 93, 46), prFont, Brushes.Black, 1, XD)
                XD += 18
            End If
        End If

        XD += 10

        'datos cliente
        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("Cliente:", prFont, Brushes.Black, 1, XD)
        XD += 28

        prFont = New Drawing.Font("Arial", 9, FontStyle.Bold)
        'razon social
        e.Graphics.DrawString(Cmb_RazonS.Text, prFont, Brushes.Black, 1, XD)
        XD += 18

        'rfc
        e.Graphics.DrawString(Cmb_RFC.Text, prFont, Brushes.Black, 1, XD)
        XD += 18

        prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
        'calle
        If Text_calle.Text <> "" Then
            e.Graphics.DrawString("Calle: " & Text_calle.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'numero ext y numero interior
        If Text_Num_Ex.Text <> "" Then
            If Txt_num_int.Text <> "" Then
                e.Graphics.DrawString("Núm. Ext.: " & Text_Num_Ex.Text & " Int.: " & Txt_num_int.Text, prFont, Brushes.Black, 1, XD)
                XD += 18
            Else
                e.Graphics.DrawString("Núm. Ext.: " & Text_Num_Ex.Text, prFont, Brushes.Black, 1, XD)
                XD += 18
            End If
        End If

        'colonia
        If Text_Colonia.Text <> "" Then
            e.Graphics.DrawString("Colonia: " & Text_Colonia.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'delegacion
        If Text_Delegacion.Text <> "" Then
            e.Graphics.DrawString("Alcaldía o Municipio: " & Text_Delegacion.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'codigo postal
        If Text_CP.Text <> "" Then
            e.Graphics.DrawString("Código Postal: " & Text_CP.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'entidad feder
        If Text_Edo.Text <> "" Then
            e.Graphics.DrawString("Estado: " & Text_Edo.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'pais
        If Text_Pais.Text <> "" Then
            e.Graphics.DrawString("País: " & Text_Pais.Text, prFont, Brushes.Black, 1, XD)
            XD += 18
        Else
            e.Graphics.DrawString("País: México", prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'regimen fiscal cliente
        var_nom = ""
        e.Graphics.DrawString(Mid("Régimen Fiscal Cliente: " & CliTicketRegFis & " " & cbo_regimen.Text, 1, 46), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid("Régimen Fiscal Cliente: " & CliTicketRegFis & " " & cbo_regimen.Text, 47, 46)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid("Régimen Fiscal Cliente: " & CliTicketRegFis & " " & cbo_regimen.Text, 47, 46), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid("Régimen Fiscal Cliente: " & CliTicketRegFis & " " & cbo_regimen.Text, 93, 46)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid("Régimen Fiscal Cliente: " & CliTicketRegFis & " " & cbo_regimen.Text, 93, 46), prFont, Brushes.Black, 1, XD)
                XD += 18
            End If
        End If

        XD += 10

        prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
        'fecha emision
        e.Graphics.DrawString("Fecha de Emisión: " & FactFechaEmision, prFont, Brushes.Black, 1, XD)
        XD += 18

        'fecha certificacion
        e.Graphics.DrawString("Fecha de Certificación: " & FactFechaCertif, prFont, Brushes.Black, 1, XD)
        XD += 18

        'fecha certificado sat
        e.Graphics.DrawString("Certificado SAT: " & FactCertSAT, prFont, Brushes.Black, 1, XD)
        XD += 18

        'fecha certificado emisor
        e.Graphics.DrawString("Certificado Emisor: " & FactCertEmisor, prFont, Brushes.Black, 1, XD)
        XD += 18

        'Tipo Comprobante
        If Cmb_Nfactura.Text = "NOTA DE CREDITO" Then
            e.Graphics.DrawString("Tipo de Comprobante: E Egreso", prFont, Brushes.Black, 1, XD)
            XD += 18
        Else
            e.Graphics.DrawString("Tipo de Comprobante: I Ingreso", prFont, Brushes.Black, 1, XD)
            XD += 18
        End If

        'uuid
        e.Graphics.DrawString("UUID: " & FactUUID, prFont, Brushes.Black, 1, XD)
        XD += 18

        'rfc prov cert
        e.Graphics.DrawString("RFC Prov. Cert.: LSO1306189R5", prFont, Brushes.Black, 1, XD)
        XD += 18

        'uso cfdi
        var_nom = ""
        e.Graphics.DrawString(Mid("Uso CFDI: " & FactCFDI & " " & FactCFDI1, 1, 46), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid("Uso CFDI: " & FactCFDI & " " & FactCFDI1, 47, 46)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid("Uso CFDI: " & FactCFDI & " " & FactCFDI1, 47, 92), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid("Uso CFDI: " & FactCFDI & " " & FactCFDI1, 93, 46)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid("Uso CFDI: " & FactCFDI & " " & FactCFDI1, 93, 46), prFont, Brushes.Black, 1, XD)
                XD += 18
            Else
                'XD += 10
            End If
        Else
            'XD += 10
        End If

        Dim banderaieps As Integer = 0

        Dim ieps160 As Decimal = 0
        Dim ieps53 As Decimal = 0
        Dim ieps5 As Decimal = 0
        Dim ieps304 As Decimal = 0
        Dim ieps3 As Decimal = 0
        Dim ieps265 As Decimal = 0
        Dim ieps25 As Decimal = 0
        Dim ieps09 As Decimal = 0
        Dim ieps08 As Decimal = 0
        Dim ieps07 As Decimal = 0
        Dim ieps06 As Decimal = 0
        Dim ieps03 As Decimal = 0

        Dim cuantosieps(20) As String
        For XD1 = 0 To 19
            cuantosieps(XD1) = ""
        Next

        cnn = New MySqlClient.MySqlConnection
        Dim sinfo2 As String = ""
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim odata2 As New ToolKitSQL.myssql
        With odata2
            If .dbOpen(cnn, sTarget, sinfo2) Then
                If .getDr(cnn, dr2, "select nom_mdescuento from Facturas where nom_id = " & var_idfactura, sinfo2) Then
                    If CDec(dr2(0).ToString()) > 0 Then
                        banderaieps = 1
                    Else
                        banderaieps = 0
                    End If
                Else
                    banderaieps = 0
                End If
                cnn.Close()
            End If
        End With

        cnn = New MySqlClient.MySqlConnection
        sinfo2 = ""
        dt2 = New DataTable
        odata2 = New ToolKitSQL.myssql
        Dim isrporc As Decimal = "0"
        With odata2
            If .dbOpen(cnn, sTarget, sinfo2) Then
                If .getDt(cnn, dt2, "select isr from detalle_factura where factura = " & var_idfactura, sinfo2) Then
                    For Each dr2 In dt2.Rows
                        If dr2("isr").ToString() > 0 Then
                            isrporc = FormatNumber(CDec(dr2("isr").ToString()) * 100, 2)
                            Exit For
                        End If
                    Next
                End If
                cnn.Close()
            End If
        End With

        cnn = New MySqlClient.MySqlConnection
        sinfo2 = ""
        dt2 = New DataTable
        odata2 = New ToolKitSQL.myssql
        Dim ivaretporc As Decimal = "0"
        With odata2
            If .dbOpen(cnn, sTarget, sinfo2) Then
                If .getDt(cnn, dt2, "select ret_iva_perc from detalle_factura where factura = " & var_idfactura, sinfo2) Then
                    For Each dr2 In dt2.Rows
                        If dr2("ret_iva_perc").ToString() > 0 Then
                            ivaretporc = FormatNumber(CDec(dr2("ret_iva_perc").ToString()) * 100, 4)
                            Exit For
                        End If
                    Next
                End If
                cnn.Close()
            End If
        End With

        If banderaieps <> 0 Then

            cnn = New MySqlClient.MySqlConnection
            sinfo2 = ""
            dt2 = New DataTable
            odata2 = New ToolKitSQL.myssql
            With odata2
                If .dbOpen(cnn, sTarget, sinfo2) Then
                    If .getDt(cnn, dt2, "select distinct ieps_porcentaje from detalle_factura where factura = " & var_idfactura, sinfo2) Then
                        Dim i As Integer = 0
                        For Each dr2 In dt2.Rows
                            cuantosieps(i) = dr2(0).ToString
                            i = i + 1
                        Next
                    End If

                    For XD1 = 0 To 19
                        If cuantosieps(XD1) <> "" Then
                            dt2 = New DataTable
                            If .getDt(cnn, dt2, "select ieps from detalle_factura where factura = " & var_idfactura & " and  ieps_porcentaje = '" & cuantosieps(XD1) & "'", sinfo2) Then
                            End If

                            Select Case cuantosieps(XD1)
                                Case "0.030000"
                                    For Each dr2 In dt2.Rows
                                        ieps03 = ieps03 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.060000"
                                    For Each dr2 In dt2.Rows
                                        ieps06 = ieps06 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.070000"
                                    For Each dr2 In dt2.Rows
                                        ieps07 = ieps07 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.080000"
                                    For Each dr2 In dt2.Rows
                                        ieps08 = ieps08 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.090000"
                                    For Each dr2 In dt2.Rows
                                        ieps09 = ieps09 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.250000"
                                    For Each dr2 In dt2.Rows
                                        ieps25 = ieps25 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.265000"
                                    For Each dr2 In dt2.Rows
                                        ieps265 = ieps265 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.300000"
                                    For Each dr2 In dt2.Rows
                                        ieps3 = ieps3 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.304000"
                                    For Each dr2 In dt2.Rows
                                        ieps304 = ieps304 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.500000"
                                    For Each dr2 In dt2.Rows
                                        ieps5 = ieps5 + CDec(dr2(0).ToString)
                                    Next
                                Case "0.530000"
                                    For Each dr2 In dt2.Rows
                                        ieps53 = ieps53 + CDec(dr2(0).ToString)
                                    Next
                                Case "1.600000"
                                    For Each dr2 In dt2.Rows
                                        ieps160 = ieps160 + CDec(dr2(0).ToString)
                                    Next
                            End Select
                        End If
                    Next
                    cnn.Close()
                End If
            End With
        End If

        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
        XD += 18
        prFont = New Drawing.Font("Arial", 11, FontStyle.Regular)
        e.Graphics.DrawString("ClaveProd/Serv   UnidadMedida", prFont, Brushes.Black, 1, XD)
        XD += 18
        e.Graphics.DrawString("Concepto", prFont, Brushes.Black, 1, XD)
        XD += 18
        e.Graphics.DrawString("Cantidad   PrecioUnitario    Importe", prFont, Brushes.Black, 1, XD)
        XD += 3
        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
        XD += 28

        If CDec(Text_Descuento.Text) > 0 Then
            prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
            Dim vardescuento As Double = 0
            For i = 0 To grid_prods.RowCount - 1
                vardescuento = 0
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(14).Value & "                 " & grid_prods.Rows(i).Cells(2).Value, prFont, Brushes.Black, 25, XD)
                XD += 18
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(1).Value, prFont, Brushes.Black, 1, XD)
                XD += 18
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(3).Value & "         $" & CDec(grid_prods.Rows(i).Cells(4).Value) + CDec(vardescuento) & "          $" & CDec(grid_prods.Rows(i).Cells(5).Value), prFont, Brushes.Black, 25, XD)
                XD += 18
                e.Graphics.DrawString("SI objeto de Impuesto", prFont, Brushes.Black, 25, XD)
                XD += 18
            Next

            prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
            e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
            XD += 28

            Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}

            e.Graphics.DrawString("Suma: $" & Text_SubTotal.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 18

            e.Graphics.DrawString("Descuento: $" & Text_Descuento.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 18

            e.Graphics.DrawString("SubTotal: $" & CDec(Text_SubTotal.Text) - CDec(Text_Descuento.Text), prFont, Brushes.Black, 250, XD, sf)
            XD += 18

            e.Graphics.DrawString("Iva 16%: $" & Text_IVA.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 18
            If CDec(Text_IVARET.Text) > 0 Then
                e.Graphics.DrawString("Iva Ret. " & ivaretporc & "%: $" & Text_IVARET.Text, prFont, Brushes.Black, 250, XD, sf)
                XD += 18
            End If
            If CDec(txt_impuestos.Text) > 0 Then
                If ieps03 > 0 Then e.Graphics.DrawString("Ieps 3%: $" & FormatNumber(ieps03, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps06 > 0 Then e.Graphics.DrawString("Ieps 6%: $" & FormatNumber(ieps06, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps07 > 0 Then e.Graphics.DrawString("Ieps 7%: $" & FormatNumber(ieps07, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps08 > 0 Then e.Graphics.DrawString("Ieps 8%: $" & FormatNumber(ieps08, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps09 > 0 Then e.Graphics.DrawString("Ieps 9%: $" & FormatNumber(ieps09, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps25 > 0 Then e.Graphics.DrawString("Ieps 25%: $" & FormatNumber(ieps25, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps265 > 0 Then e.Graphics.DrawString("Ieps 26.5%: $" & FormatNumber(ieps265, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps3 > 0 Then e.Graphics.DrawString("Ieps 30%: $" & FormatNumber(ieps3, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps304 > 0 Then e.Graphics.DrawString("Ieps 30.4%: $" & FormatNumber(ieps304, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps5 > 0 Then e.Graphics.DrawString("Ieps 50%: $" & FormatNumber(ieps5, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps53 > 0 Then e.Graphics.DrawString("Ieps 53%: $" & FormatNumber(ieps53, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps160 > 0 Then e.Graphics.DrawString("Ieps 160%: $" & FormatNumber(ieps160, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
            End If

            If CDec(txtISR.Text) > 0 Then
                e.Graphics.DrawString("Isr Ret. " & isrporc & "%: $" & txtISR.Text, prFont, Brushes.Black, 250, XD, sf)
                XD += 18
            End If

            e.Graphics.DrawString("Total: $" & Text_TOTAL.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 28
        Else

            prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
            For i = 0 To grid_prods.RowCount - 1
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(14).Value & "                 " & grid_prods.Rows(i).Cells(2).Value, prFont, Brushes.Black, 25, XD)
                XD += 18
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(1).Value, prFont, Brushes.Black, 1, XD)
                XD += 18
                e.Graphics.DrawString(grid_prods.Rows(i).Cells(3).Value & "         $" & grid_prods.Rows(i).Cells(4).Value & "          $" & grid_prods.Rows(i).Cells(5).Value, prFont, Brushes.Black, 25, XD)
                XD += 18
                e.Graphics.DrawString("SI objeto de Impuesto", prFont, Brushes.Black, 25, XD)
                XD += 18
            Next

            prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
            e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
            XD += 28

            Dim sf As New StringFormat With {.Alignment = StringAlignment.Far}

            e.Graphics.DrawString("SubTotal: $" & Text_SubTotal.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 18
            e.Graphics.DrawString("Iva 16%: $" & Text_IVA.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 18
            If CDec(Text_IVARET.Text) > 0 Then
                e.Graphics.DrawString("Iva Ret. " & ivaretporc & "%: $" & Text_IVARET.Text, prFont, Brushes.Black, 250, XD, sf)
                XD += 18
            End If
            If CDec(txt_impuestos.Text) > 0 Then
                If ieps03 > 0 Then e.Graphics.DrawString("Ieps 3%: $" & FormatNumber(ieps03, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps06 > 0 Then e.Graphics.DrawString("Ieps 6%: $" & FormatNumber(ieps06, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps07 > 0 Then e.Graphics.DrawString("Ieps 7%: $" & FormatNumber(ieps07, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps08 > 0 Then e.Graphics.DrawString("Ieps 8%: $" & FormatNumber(ieps08, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps09 > 0 Then e.Graphics.DrawString("Ieps 9%: $" & FormatNumber(ieps09, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps25 > 0 Then e.Graphics.DrawString("Ieps 25%: $" & FormatNumber(ieps25, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps265 > 0 Then e.Graphics.DrawString("Ieps 26.5%: $" & FormatNumber(ieps265, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps3 > 0 Then e.Graphics.DrawString("Ieps 30%: $" & FormatNumber(ieps3, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps304 > 0 Then e.Graphics.DrawString("Ieps 30.4%: $" & FormatNumber(ieps304, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps5 > 0 Then e.Graphics.DrawString("Ieps 50%: $" & FormatNumber(ieps5, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps53 > 0 Then e.Graphics.DrawString("Ieps 53%: $" & FormatNumber(ieps53, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
                If ieps160 > 0 Then e.Graphics.DrawString("Ieps 160%: $" & FormatNumber(ieps160, 2), prFont, Brushes.Black, 250, XD, sf) : XD += 18
            End If
            If CDec(txtISR.Text) > 0 Then
                e.Graphics.DrawString("Isr Ret. " & isrporc & "%: $" & txtISR.Text, prFont, Brushes.Black, 250, XD, sf)
                XD += 18
            End If
            e.Graphics.DrawString("Total: $" & Text_TOTAL.Text, prFont, Brushes.Black, 250, XD, sf)
            XD += 28
        End If

        Dim cantidadLetra As String = convLetras(CDbl(Text_TOTAL.Text))
        var_nom = ""
        prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
        e.Graphics.DrawString(Mid(cantidadLetra, 1, 32), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid(cantidadLetra, 33, 32)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid(cantidadLetra, 33, 32), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid(cantidadLetra, 65, 32)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid(cantidadLetra, 93, 32), prFont, Brushes.Black, 1, XD)
                XD += 18
            End If
        End If

        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
        XD += 28

        'metodo de pago
        prFont = New Drawing.Font("Arial", 9, FontStyle.Regular)
        If FactTipoPago = "PUE" Then
            e.Graphics.DrawString("Mét. Pago: PUE Pago en una sola exhibición", prFont, Brushes.Black, 1, XD)
        Else
            e.Graphics.DrawString("Mét. Pago: PPD Pago en parcialidades o diferido", prFont, Brushes.Black, 1, XD)
        End If
        XD += 18

        'forma de pago
        Select Case FactFormaPago
            Case "01"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Efectivo", prFont, Brushes.Black, 1, XD)
            Case "02"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Cheque nominativo", prFont, Brushes.Black, 1, XD)
            Case "03"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Transferencia electrónica de fondos", prFont, Brushes.Black, 1, XD)
            Case "04"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Tarjeta de crédito", prFont, Brushes.Black, 1, XD)
            Case "05"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Monedero electrónico", prFont, Brushes.Black, 1, XD)
            Case "06"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Dinero electrónico", prFont, Brushes.Black, 1, XD)
            Case "08"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Vales de despensa", prFont, Brushes.Black, 1, XD)
            Case "12"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Dación en pago", prFont, Brushes.Black, 1, XD)
            Case "13"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Pago por subrogación", prFont, Brushes.Black, 1, XD)
            Case "14"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Pago por consignación", prFont, Brushes.Black, 1, XD)
            Case "15"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Condonación", prFont, Brushes.Black, 1, XD)
            Case "17"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Compensación", prFont, Brushes.Black, 1, XD)
            Case "23"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Novación", prFont, Brushes.Black, 1, XD)
            Case "24"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Confusión", prFont, Brushes.Black, 1, XD)
            Case "25"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Remisión de deuda", prFont, Brushes.Black, 1, XD)
            Case "26"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Prescripción o caducidad", prFont, Brushes.Black, 1, XD)
            Case "27"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " A satisfacción del acreedor", prFont, Brushes.Black, 1, XD)
            Case "28"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Tarjeta de débito", prFont, Brushes.Black, 1, XD)
            Case "29"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Tarjeta de servicios", prFont, Brushes.Black, 1, XD)
            Case "30"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Aplicación de anticipos", prFont, Brushes.Black, 1, XD)
            Case "99"
                e.Graphics.DrawString("Forma de Pago: " & FactFormaPago & " Por definir", prFont, Brushes.Black, 1, XD)
        End Select
        XD += 28

        'leyenda adicional
        If txt_leyenda_add.Text <> "" Then
            var_nom = ""
            e.Graphics.DrawString("Leyenda Adicional: ", prFont, Brushes.Black, 1, XD)
            XD += 18
            e.Graphics.DrawString(Mid(txt_leyenda_add.Text, 1, 35), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid(txt_leyenda_add.Text, 36, 35)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid(txt_leyenda_add.Text, 36, 35), prFont, Brushes.Black, 1, XD)
                XD += 18
                var_nom = Mid(txt_leyenda_add.Text, 71, 35)
                If var_nom <> "" Then
                    e.Graphics.DrawString(Mid(txt_leyenda_add.Text, 71, 35), prFont, Brushes.Black, 1, XD)
                    XD += 18
                    var_nom = Mid(txt_leyenda_add.Text, 106, 35)
                    If var_nom <> "" Then
                        e.Graphics.DrawString(Mid(txt_leyenda_add.Text, 106, 35), prFont, Brushes.Black, 1, XD)
                        XD += 18
                        var_nom = Mid(txt_leyenda_add.Text, 141, 35)
                        If var_nom <> "" Then
                            e.Graphics.DrawString(Mid(txt_leyenda_add.Text, 141, 35), prFont, Brushes.Black, 1, XD)
                            XD += 18
                        End If
                    End If
                End If
            End If
            XD += 28
        End If

        'sello digital
        prFont = New Drawing.Font("Arial", 8, FontStyle.Regular)
        var_nom = ""
        e.Graphics.DrawString("Sello Digital: ", prFont, Brushes.Black, 1, XD)
        XD += 18
        e.Graphics.DrawString(Mid(FactSelloDigital, 1, 40), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid(FactSelloDigital, 41, 40)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid(FactSelloDigital, 41, 40), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid(FactSelloDigital, 81, 40)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid(FactSelloDigital, 81, 40), prFont, Brushes.Black, 1, XD)
                XD += 18
                var_nom = Mid(FactSelloDigital, 121, 40)
                If var_nom <> "" Then
                    e.Graphics.DrawString(Mid(FactSelloDigital, 121, 40), prFont, Brushes.Black, 1, XD)
                    XD += 18
                    var_nom = Mid(FactSelloDigital, 161, 40)
                    If var_nom <> "" Then
                        e.Graphics.DrawString(Mid(FactSelloDigital, 161, 40), prFont, Brushes.Black, 1, XD)
                        XD += 18
                        var_nom = Mid(FactSelloDigital, 201, 40)
                        If var_nom <> "" Then
                            e.Graphics.DrawString(Mid(FactSelloDigital, 201, 40), prFont, Brushes.Black, 1, XD)
                            XD += 18
                            var_nom = Mid(FactSelloDigital, 241, 40)
                            If var_nom <> "" Then
                                e.Graphics.DrawString(Mid(FactSelloDigital, 241, 40), prFont, Brushes.Black, 1, XD)
                                XD += 18
                                var_nom = Mid(FactSelloDigital, 281, 40)
                                If var_nom <> "" Then
                                    e.Graphics.DrawString(Mid(FactSelloDigital, 281, 40), prFont, Brushes.Black, 1, XD)
                                    XD += 18
                                    var_nom = Mid(FactSelloDigital, 321, 40)
                                    If var_nom <> "" Then
                                        e.Graphics.DrawString(Mid(FactSelloDigital, 321, 40), prFont, Brushes.Black, 1, XD)
                                        XD += 18
                                        var_nom = Mid(FactSelloDigital, 361, 40)
                                        If var_nom <> "" Then
                                            e.Graphics.DrawString(Mid(FactSelloDigital, 361, 40), prFont, Brushes.Black, 1, XD)
                                            XD += 18
                                            var_nom = Mid(FactSelloDigital, 401, 40)
                                            If var_nom <> "" Then
                                                e.Graphics.DrawString(Mid(FactSelloDigital, 401, 40), prFont, Brushes.Black, 1, XD)
                                                XD += 18
                                                var_nom = Mid(FactSelloDigital, 441, 40)
                                                If var_nom <> "" Then
                                                    e.Graphics.DrawString(Mid(FactSelloDigital, 441, 40), prFont, Brushes.Black, 1, XD)
                                                    XD += 18
                                                    var_nom = Mid(FactSelloDigital, 481, 40)
                                                    If var_nom <> "" Then
                                                        e.Graphics.DrawString(Mid(FactSelloDigital, 481, 40), prFont, Brushes.Black, 1, XD)
                                                        XD += 18
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        XD += 10

        'sello sat
        var_nom = ""
        e.Graphics.DrawString("Sello SAT: ", prFont, Brushes.Black, 1, XD)
        XD += 18
        e.Graphics.DrawString(Mid(FactSelloSat, 1, 40), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid(FactSelloSat, 41, 40)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid(FactSelloSat, 41, 40), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid(FactSelloSat, 81, 40)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid(FactSelloSat, 81, 40), prFont, Brushes.Black, 1, XD)
                XD += 18
                var_nom = Mid(FactSelloSat, 121, 40)
                If var_nom <> "" Then
                    e.Graphics.DrawString(Mid(FactSelloSat, 121, 40), prFont, Brushes.Black, 1, XD)
                    XD += 18
                    var_nom = Mid(FactSelloSat, 161, 40)
                    If var_nom <> "" Then
                        e.Graphics.DrawString(Mid(FactSelloSat, 161, 40), prFont, Brushes.Black, 1, XD)
                        XD += 18
                        var_nom = Mid(FactSelloSat, 201, 40)
                        If var_nom <> "" Then
                            e.Graphics.DrawString(Mid(FactSelloSat, 201, 40), prFont, Brushes.Black, 1, XD)
                            XD += 18
                            var_nom = Mid(FactSelloSat, 241, 40)
                            If var_nom <> "" Then
                                e.Graphics.DrawString(Mid(FactSelloSat, 241, 40), prFont, Brushes.Black, 1, XD)
                                XD += 18
                                var_nom = Mid(FactSelloSat, 281, 40)
                                If var_nom <> "" Then
                                    e.Graphics.DrawString(Mid(FactSelloSat, 281, 40), prFont, Brushes.Black, 1, XD)
                                    XD += 18
                                    var_nom = Mid(FactSelloSat, 321, 40)
                                    If var_nom <> "" Then
                                        e.Graphics.DrawString(Mid(FactSelloSat, 321, 40), prFont, Brushes.Black, 1, XD)
                                        XD += 18
                                        var_nom = Mid(FactSelloSat, 361, 40)
                                        If var_nom <> "" Then
                                            e.Graphics.DrawString(Mid(FactSelloSat, 361, 40), prFont, Brushes.Black, 1, XD)
                                            XD += 18
                                            var_nom = Mid(FactSelloSat, 401, 40)
                                            If var_nom <> "" Then
                                                e.Graphics.DrawString(Mid(FactSelloSat, 401, 40), prFont, Brushes.Black, 1, XD)
                                                XD += 18
                                                var_nom = Mid(FactSelloSat, 441, 40)
                                                If var_nom <> "" Then
                                                    e.Graphics.DrawString(Mid(FactSelloSat, 441, 40), prFont, Brushes.Black, 1, XD)
                                                    XD += 18
                                                    var_nom = Mid(FactSelloSat, 481, 40)
                                                    If var_nom <> "" Then
                                                        e.Graphics.DrawString(Mid(FactSelloSat, 481, 40), prFont, Brushes.Black, 1, XD)
                                                        XD += 18
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        XD += 10

        'cadena original
        var_nom = ""
        e.Graphics.DrawString("Cadena Original: ", prFont, Brushes.Black, 1, XD)
        XD += 18
        e.Graphics.DrawString(Mid(FactCadenaOrig, 1, 40), prFont, Brushes.Black, 1, XD)
        XD += 18
        var_nom = Mid(FactCadenaOrig, 41, 40)
        If var_nom <> "" Then
            e.Graphics.DrawString(Mid(FactCadenaOrig, 41, 40), prFont, Brushes.Black, 1, XD)
            XD += 18
            var_nom = Mid(FactCadenaOrig, 81, 40)
            If var_nom <> "" Then
                e.Graphics.DrawString(Mid(FactCadenaOrig, 81, 40), prFont, Brushes.Black, 1, XD)
                XD += 18
                var_nom = Mid(FactCadenaOrig, 121, 40)
                If var_nom <> "" Then
                    e.Graphics.DrawString(Mid(FactCadenaOrig, 121, 40), prFont, Brushes.Black, 1, XD)
                    XD += 18
                    var_nom = Mid(FactCadenaOrig, 161, 40)
                    If var_nom <> "" Then
                        e.Graphics.DrawString(Mid(FactCadenaOrig, 161, 40), prFont, Brushes.Black, 1, XD)
                        XD += 18
                        var_nom = Mid(FactCadenaOrig, 201, 40)
                        If var_nom <> "" Then
                            e.Graphics.DrawString(Mid(FactCadenaOrig, 201, 40), prFont, Brushes.Black, 1, XD)
                            XD += 18
                            var_nom = Mid(FactCadenaOrig, 241, 40)
                            If var_nom <> "" Then
                                e.Graphics.DrawString(Mid(FactCadenaOrig, 241, 40), prFont, Brushes.Black, 1, XD)
                                XD += 18
                                var_nom = Mid(FactCadenaOrig, 281, 40)
                                If var_nom <> "" Then
                                    e.Graphics.DrawString(Mid(FactCadenaOrig, 281, 40), prFont, Brushes.Black, 1, XD)
                                    XD += 18
                                    var_nom = Mid(FactCadenaOrig, 321, 40)
                                    If var_nom <> "" Then
                                        e.Graphics.DrawString(Mid(FactCadenaOrig, 321, 40), prFont, Brushes.Black, 1, XD)
                                        XD += 18
                                        var_nom = Mid(FactCadenaOrig, 361, 40)
                                        If var_nom <> "" Then
                                            e.Graphics.DrawString(Mid(FactCadenaOrig, 361, 40), prFont, Brushes.Black, 1, XD)
                                            XD += 18
                                            var_nom = Mid(FactCadenaOrig, 401, 40)
                                            If var_nom <> "" Then
                                                e.Graphics.DrawString(Mid(FactCadenaOrig, 401, 40), prFont, Brushes.Black, 1, XD)
                                                XD += 18
                                                var_nom = Mid(FactCadenaOrig, 441, 40)
                                                If var_nom <> "" Then
                                                    e.Graphics.DrawString(Mid(FactCadenaOrig, 441, 40), prFont, Brushes.Black, 1, XD)
                                                    XD += 18
                                                    var_nom = Mid(FactCadenaOrig, 481, 40)
                                                    If var_nom <> "" Then
                                                        e.Graphics.DrawString(Mid(FactCadenaOrig, 481, 40), prFont, Brushes.Black, 1, XD)
                                                        XD += 18
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        XD += 10

        nuevaIMG = PictureBox2.Image

        If IsNothing(nuevaIMG) = False Then
            e.Graphics.DrawImage(nuevaIMG, 52, CInt(XD), 140, 120)
            XD += 135
        End If


        prFont = New Drawing.Font("Arial", 11, FontStyle.Bold)
        e.Graphics.DrawString("________________________________", prFont, Brushes.Black, 1, XD)
        XD += 28

        'indicamos que hemos llegado al final de la pagina
        e.HasMorePages = False
    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub cboLEdomi_DropDown(sender As Object, e As EventArgs) Handles cboLEdomi.DropDown

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Me.Close()
    End Sub
End Class