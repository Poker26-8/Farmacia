Option Explicit On
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports Chilkat.Cert
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports Gma.QrCodeNet.Encoding.Windows.Forms
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Profact.TimbraCFDI33
Imports System.Threading
Imports System.Net.Mail
Imports System.Data.OleDb
Imports CrystalDecisions.Shared

Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing
Imports System.Drawing.Printing
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports MySql.Data
Public Class frmMultiParcialidades

    Public TotalFact As Integer = 0

    Dim nombree As String = ""
    Dim cuentamail As String = ""
    Dim passmail As String = ""
    Dim servidor As String = ""
    Dim puerto As String = ""
    Dim seguridad As Boolean = False
    Public clave_productod As String = ""
    Dim banderabusqueda As Integer = 0
    Dim variableParci As Integer = 0
    Dim var1 As Integer = 0

    Dim porcentajeisr As String = ""
    Dim porcentajeivaret As String = ""

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

    Dim Baseieps160 As Decimal = 0
    Dim Baseieps53 As Decimal = 0
    Dim Baseieps5 As Decimal = 0
    Dim Baseieps304 As Decimal = 0
    Dim Baseieps3 As Decimal = 0
    Dim Baseieps265 As Decimal = 0
    Dim Baseieps25 As Decimal = 0
    Dim Baseieps09 As Decimal = 0
    Dim Baseieps08 As Decimal = 0
    Dim Baseieps07 As Decimal = 0
    Dim Baseieps06 As Decimal = 0
    Dim Baseieps03 As Decimal = 0

    Private Sub frmMultiParcialidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNuevo.PerformClick()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        btn_reenvio.Visible = False

        Dim cnn As MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDt(cnn, dt, "select * from ParcialidadesMulti where UUID is null or UUID = ''", sinfo) Then
                For Each dr In dt.Rows
                    odata.runSp(cnn, "Delete from ParcialidadesDetalleMulti where IdParcialidades = " & dr("Id").ToString & "", sinfo)
                Next
                cnn.Close()
            End If
        End If

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from ParcialidadesMulti where UUID is null", sinfo)
            cnn.Close()
        End If
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from ParcialidadesMulti where UUID = ''", sinfo)
            cnn.Close()
        End If

        ''''''''''''''''''''''''''''''''
        txtNumCta.Text = ""
        txtNumCtaCliente.Text = ""
        txtCtaRFCEmi.Text = ""
        txtCtaRFCCli.Text = ""
        txtCtaBanco.Text = ""
        txtCtaBancoEmi.Text = ""
        ''''''''''''''''''''''''''''''''

        txtSerie.Text = ""
        txtCP.Text = ""
        txtNumOpe.Text = ""
        cboMoneda.Text = "MXN"
        llena_combo_metodos()
        dtpHoraPago.Value = DateTime.Now
        dtpFechaPago.Value = Date.Now

        txtMontoPar.Text = "0"
        llena_emisores()
        lblRegFis.Text = ""
        llena_cbocliente()
        recuperaRegimenF()

        txtUUID.Text = ""
        txtFolioParci.Text = "1"
        txtMonto.Text = "0"
        llena_cboFolioPar()
        GridParcialidades.Rows.Clear()
        txtTotalISR.Text = "0"
        txtTotalIVA.Text = "0"
        txtTotalIVA0.Text = "0"
        txtTotalIEPS.Text = "0"
        txtTotalIVAret.Text = "0"

        llena_cbofolio()

        getFolio()
        RichtxtComentario.Text = ""
        var1 = 0

        txtEmiRegFis.Text = ""
        TextBox1.Text = ""
        txtCliRegFis.Text = ""
        txtCPCLiente.Text = ""

        ieps160 = 0
        ieps53 = 0
        ieps5 = 0
        ieps304 = 0
        ieps3 = 0
        ieps265 = 0
        ieps25 = 0
        ieps09 = 0
        ieps08 = 0
        ieps07 = 0
        ieps06 = 0
        ieps03 = 0

        Baseieps160 = 0
        Baseieps53 = 0
        Baseieps5 = 0
        Baseieps304 = 0
        Baseieps3 = 0
        Baseieps265 = 0
        Baseieps25 = 0
        Baseieps09 = 0
        Baseieps08 = 0
        Baseieps07 = 0
        Baseieps06 = 0
        Baseieps03 = 0

        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False

        cnn = New MySqlClient.MySqlConnection
        sinfo = ""
        dt = New DataTable
        odata = New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from DatosNegocio where Em_RazonSocial = '" & cbo_emisor.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        lblRegFis.Text = dr("Em_RFiscal").ToString
                        txtEmiRegFis.Text = dr("Em_RFiscal").ToString
                        TextBox1.Text = dr("Em_CP").ToString
                    Next
                End If
                cnn.Close()
            End If
        End With

        cnn = New MySqlClient.MySqlConnection
        sinfo = ""
        dt = New DataTable
        odata = New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from Clientes where RazonSocial = '" & Cmb_RazonS.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        txtCliRegFis.Text = dr("Regfis").ToString
                        txtCPCLiente.Text = dr("CP").ToString
                    Next
                End If
                cnn.Close()
            End If
        End With

        TotalFact = 0

    End Sub

    Private Sub llena_cboFolioPar()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from ParcialidadesMulti where EmiIdDatos = " & cbo_emisor.SelectedValue & " order by FolioPar"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With cboFolioPar
                    Try
                        If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                            .DataSource = ds.Tables("edos")
                            .ValueMember = "Id"
                            .DisplayMember = "FolioPar"
                        Else
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End With
                cnn.Close()
            Else
            End If
        End With
        cboFolioPar.Text = ""

    End Sub

    Private Sub llena_combo_metodos()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from FormaPagoSat"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            With cboFormaPago
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

    Private Sub llena_emisores()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * From DatosNegocio"
        Dim ds As New DataSet
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            With cbo_emisor
                If odata.getDs(cnn, ds, sSQL, "Empresa", sinfo) = True Then
                    .DataSource = ds.Tables("Empresa")
                    .ValueMember = "Emisor_id"
                    .DisplayMember = "Em_RazonSocial"
                    cbo_rfc_emisor.DataSource = ds.Tables("Empresa")
                    cbo_rfc_emisor.ValueMember = "Emisor_id"
                    cbo_rfc_emisor.DisplayMember = "Em_rfc"
                End If
            End With
            cnn.Close()
        End If

        If cbo_emisor.Items.Count > 0 Then
            cbo_emisor.SelectedIndex = 0
            cbo_rfc_emisor.SelectedIndex = 0
            vempresa = 1
        End If

    End Sub

    Private Sub llena_cbocliente()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from Clientes where RazonSocial <> '' and RFC <> '' order by RazonSocial"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                With Cmb_RazonS
                    If oData.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                        .DataSource = ds.Tables("edos")
                        .ValueMember = "Id"
                        .DisplayMember = "RazonSocial"
                        Cmb_RFC.DataSource = ds.Tables("edos")
                        Cmb_RFC.ValueMember = "Id"
                        Cmb_RFC.DisplayMember = "RFC"
                    End If
                End With
                Cmb_RazonS.SelectedIndex = -1
                Cmb_RFC.SelectedIndex = -1
                cnn.Close()
            End If
        End With

    End Sub

    Private Sub recuperaRegimenF()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * From DatosNegocio"
        'Dim sSQL As String = "Select * From DatosNegocio where Em_rfc = '" & cbo_rfc_emisor.Text & "'"
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            If odata.getDt(cnn, dt, sSQL, sinfo) = True Then
                For Each dr In dt.Rows
                    If dr("Em_rfc").ToString <> "" Then
                        lblRegFis.Text = dr("Em_RFiscal").ToString
                        Exit For
                    End If
                Next
            End If
            cnn.Close()
        End If

    End Sub

    Private Sub llena_cbofolio()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from Facturas where estatus_fac=" & ESTATUS_FACTURA & " and id_emisor = " & cbo_emisor.SelectedValue & " order by nom_folio"
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
                        End If
                    Catch ex As Exception
                        'MsgBox(ex.ToString)
                    End Try
                End With
                cnn.Close()
            End If
        End With
        cboFolio.Text = ""

    End Sub

    Private Sub getFolio()
        Dim sSQL As String = "Select max(FolioPar) as XD from ParcialidadesMulti where EmiIdDatos = " & cbo_emisor.SelectedValue & ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    If dr("XD").ToString = "" Then
                        cboFolioPar.Text = 1
                    Else
                        cboFolioPar.Text = CDec(dr("XD").ToString) + 1
                    End If
                Else
                    cboFolioPar.Text = 1
                End If
                cnn.Close()
            Else
            End If
        End With
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click

        Dim nueva_fecha As String = ""
        nueva_fecha = CStr(Format(dtpFechaPago.Value, "yyyy-MM-dd")) & "T" & CStr(Format(dtpHoraPago.Value, "HH:mm:ss"))

        Dim sinfo As String = ""
        Dim sSQL As String = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        sSQL = "Select Id from ParcialidadesMulti where FolioPar = " & cboFolioPar.Text & " and EmiIdDatos = " & cbo_emisor.SelectedValue & ""
        Dim dr10 As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr10, sSQL, sinfo) Then
                    If dr10("Id").ToString <> "" Then
                        MsgBox("Este folio de parcialidad ya fue timbrado")
                        btnNuevo.PerformClick()
                        cnn.Close()
                        Exit Sub
                    End If
                End If
                cnn.Close()
            End If
        End With

        Dim FolioUnido As String = ""
        ProgressBar1.Maximum = 100
        ProgressBar1.Minimum = 0
        lbl_proceso.Visible = True
        ProgressBar1.Visible = True
        ProgressBar1.Value = 1
        lbl_proceso.Text = "Procesando ..."
        My.Application.DoEvents()

        If GridParcialidades.RowCount > 1 Then

            ProgressBar1.Value = 5
            lbl_proceso.Text = "Validando Timbres..."
            My.Application.DoEvents()

            If checat(cbo_rfc_emisor.Text) Then

                ProgressBar1.Value = 10
                lbl_proceso.Text = "Validando Información..."

                If valida_datos() = True Then
                    ProgressBar1.Value = 25
                    lbl_proceso.Text = "Almacenando Datos ..."
                    My.Application.DoEvents()

                    FolioUnido = "P" & cboFolioPar.Text
                    Dim maxnumpar As Integer = 0
                    Dim ultimid As Integer = 0

                    Dim baseivatotal As Double = 0
                    Dim baseiva0total As Double = 0
                    Dim baseivarettotal As Double = 0

                    For i = 0 To GridParcialidades.RowCount - 2
                        baseivatotal = baseivatotal + CDec(GridParcialidades.Rows(i).Cells(41).Value.ToString)
                        baseiva0total = baseiva0total + CDec(GridParcialidades.Rows(i).Cells(13).Value.ToString)
                        baseivarettotal = baseivarettotal + CDec(GridParcialidades.Rows(i).Cells(43).Value.ToString)
                    Next

                    sSQL = "Insert into ParcialidadesMulti(FolioPar,IdFact,FolioFact,LugarExp,TipoComprobante,Total," &
                    "Moneda,SubTotal,Fecha,Serie,EmiRFC,EmiRazon,EmiRegimen,CliRFC,CliRazon,CliUsoCFDI,Importe,ValorUnitario," &
                    "Descripcion,ClaveUnidad,NumOperacion,Monto,MonedaP,FormaPago,FechaPago,UUID,Sello,NoCert,Certificado,SelloCFD,NoCertSat,SelloSat," &
                    "CadenaOriginal,FechaTimbrado,RfcProvCertf, EmiIdDatos, CliIdDatos, FolioUnido, Estatus_par,NumCta,Comentario,NumCtaCliente,CtaRFCEmi, " &
                    "CtaRFCCli,Banco,BancoEmi,CPCli, CliRegimen, BaseIVA16, BaseIVA0, BaseIVARet)Values(" & cboFolioPar.Text & ", 0, 0,'" & txtCP.Text & "','P','0'," &
                     "'XXX','0','" & Format(Now, "yyyy-MM-ddThh:mm:ss") & "','" & txtSerie.Text & "', '" & cbo_rfc_emisor.Text & "','" & cbo_emisor.Text & "','" & lblRegFis.Text & "','" & Cmb_RFC.Text & "','" & Cmb_RazonS.Text & "','CP01','0','0'" &
                     ",'Pago','ACT','" & txtNumOpe.Text & "','" & Replace(txtMontoPar.Text, ",", "") & "','MXN','" & cboFormaPago.SelectedValue & "','" & nueva_fecha & "','','','','','','','','','','LSO1306189R5'," & cbo_emisor.SelectedValue & ", " &
                     Cmb_RazonS.SelectedValue & ",'" & FolioUnido & "','1','" & txtNumCta.Text & "','" & RichtxtComentario.Text & "','" & txtNumCtaCliente.Text & "','" & txtCtaRFCEmi.Text & "','" & txtCtaRFCCli.Text & "','" & txtCtaBanco.Text & "','" &
                     txtCtaBancoEmi.Text & "','" & txtCPCLiente.Text & "','" & txtCliRegFis.Text & "','" & baseivatotal & "','" & baseiva0total & "','" & baseivarettotal & "')"
                    If odata.dbOpen(cnn, sTarget, sinfo) Then
                        If odata.runSp(cnn, sSQL, sinfo) Then
                            cnn.Close()
                        Else
                            MsgBox(sinfo)
                            cnn.Close()
                        End If
                    Else
                        MsgBox(sinfo)
                        cnn.Close()
                    End If

                    ProgressBar1.Value = 40
                    lbl_proceso.Text = "Guardando Datos Temporales ..."
                    My.Application.DoEvents()

                    sSQL = "Select max(FolioPar) as XD from ParcialidadesMulti where EmiIdDatos = " & cbo_emisor.SelectedValue & ""
                    Dim dr As DataRow
                    With odata
                        If .dbOpen(cnn, sTarget, sinfo) Then
                            If .getDr(cnn, dr, sSQL, sinfo) Then
                                If dr("XD").ToString = "" Then
                                    maxnumpar = 1
                                Else
                                    maxnumpar = CDec(dr("XD").ToString)
                                End If
                            End If
                            cnn.Close()
                        Else
                        End If
                    End With

                    sSQL = "Select max(Id) as XD from ParcialidadesMulti where EmiIdDatos = " & cbo_emisor.SelectedValue & ""
                    Dim dr1 As DataRow
                    With odata
                        If .dbOpen(cnn, sTarget, sinfo) Then
                            If .getDr(cnn, dr1, sSQL, sinfo) Then
                                If dr1("XD").ToString = "" Then
                                    ultimid = 1
                                Else
                                    ultimid = CDec(dr1("XD").ToString)
                                End If
                            End If
                            cnn.Close()
                        Else
                        End If
                    End With

                    For i = 0 To GridParcialidades.RowCount - 2

                        sSQL = "Insert into ParcialidadesDetalleMulti(IdParcialidades,Folio,Serie,ImpSaldoIns,ImpPagado,ImpSaldoAnt," &
                        "NumParcialidades,MetodoPago,Moneda,UUID, OpeIva, OpeIvaRet, OpeIsr, OpeIeps, OpeIva0, IsrPorc, IvaRetPorc," &
                        "IepsPorc, ieps160, ieps53, ieps5, ieps304, ieps3, ieps265, ieps25, ieps09, ieps08, ieps07, ieps06, ieps03," &
                        "Baseieps160, Baseieps53, Baseieps5, Baseieps304, Baseieps3, Baseieps265, Baseieps25, Baseieps09, Baseieps08," &
                        "Baseieps07, Baseieps06, Baseieps03, BaseIVA16, BaseISR, BaseIVARet, BaseIVA0)Values(" &
                         ultimid & ", '" & GridParcialidades.Rows(i).Cells(0).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(7).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(3).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(2).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(1).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(4).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(5).Value.ToString & "','MXN','" & GridParcialidades.Rows(i).Cells(8).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(9).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(10).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(12).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(11).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(13).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(14).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(15).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(16).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(17).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(18).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(19).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(20).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(21).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(22).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(23).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(24).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(25).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(26).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(27).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(28).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(29).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(30).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(31).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(32).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(33).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(34).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(35).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(36).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(37).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(38).Value.ToString & "'," &
                         "'" & GridParcialidades.Rows(i).Cells(39).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(40).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(41).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(42).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(43).Value.ToString & "','" & GridParcialidades.Rows(i).Cells(44).Value.ToString & "')"
                        If odata.dbOpen(cnn, sTarget, sinfo) Then
                            If odata.runSp(cnn, sSQL, sinfo) Then
                                cnn.Close()
                            Else
                                MsgBox(sinfo)
                                cnn.Close()
                            End If
                        Else
                            MsgBox(sinfo)
                            cnn.Close()
                        End If

                    Next

                    ProgressBar1.Value = 50
                    lbl_proceso.Text = "Generando XML ..."
                    If GeneraXMLParcialidades1("", cboFolioPar.Text, cbo_emisor.Text, cbo_rfc_emisor.Text, txtCP.Text, txtSerie.Text, lblRegFis.Text, Cmb_RFC.Text, Cmb_RazonS.Text, txtNumOpe.Text, txtMontoPar.Text, cboFormaPago.SelectedValue, GridParcialidades, ultimid, nueva_fecha, txtNumCta.Text, txtNumCtaCliente.Text, txtCtaRFCEmi.Text, txtCtaRFCCli.Text, txtCtaBanco.Text) Then
                        MsgBox("TIMBRADO CORRECTAMENTE ")
                        ProgressBar1.Value = 80
                        lbl_proceso.Text = "Actualizando Base ..."
                        My.Application.DoEvents()
                        printReciboPar(FolioUnido, ultimid, email)
                    End If

                End If

            End If

            btnNuevo.PerformClick()
            lbl_proceso.Visible = False
            ProgressBar1.Visible = False
        Else
            lbl_proceso.Visible = False
            ProgressBar1.Visible = False
            MsgBox("Debe registrar un monto antes de Generar la Parcialidad")
        End If

    End Sub

    Private Sub cboFolioPar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFolioPar.KeyPress
        On Error GoTo malo
        If Asc(e.KeyChar) = Keys.Enter Then
            recupera_campos()
            If banderabusqueda = 1 Then banderabusqueda = 0 : Exit Sub
            btn_reenvio.Visible = True
            Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString
            If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim FolioUnido As String = "P" & cboFolioPar.Text
                Dim FileOpen As New ProcessStartInfo
                crea_dir("C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\PARCIALIDADES\")
                Dim root_name_recibo As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\PARCIALIDADES\" & FolioUnido & ".pdf"
                If File.Exists(root_name_recibo) Then
                    FileOpen.UseShellExecute = True
                    FileOpen.FileName = root_name_recibo
                    Process.Start(FileOpen)
                Else
                    printReciboPar(FolioUnido, cboFolioPar.SelectedValue, email)
                End If
            End If
        End If
        If cboFolioPar.Text <> "" And cboFolioPar.SelectedValue > 0 Then
        Else
            btn_reenvio.Visible = False
        End If
malo:
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtCP.Focus()
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtNumOpe.Focus()
        End If
    End Sub

    Private Sub txtNumOpe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumOpe.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboMoneda.Focus()
        End If
    End Sub

    Private Sub cboMoneda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboMoneda.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboFormaPago.Focus()
        End If
    End Sub

    Private Sub cboFormaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFormaPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpFechaPago.Focus()
        End If
    End Sub

    Private Sub dtpFechaPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpHoraPago.Focus()
        End If
    End Sub

    Private Sub dtpHoraPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpHoraPago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbo_emisor.Focus()
        End If
    End Sub

    Private Sub cbo_emisor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_emisor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbo_emisor.Text <> "" Then
                Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                Dim sinfo As String = ""
                Dim dt As New DataTable
                Dim dr As DataRow
                Dim odata As New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDt(cnn, dt, "select * from DatosNegocio where Em_RazonSocial = '" & cbo_emisor.Text & "'", sinfo) Then
                            For Each dr In dt.Rows
                                cbo_rfc_emisor.Text = dr("Em_rfc").ToString
                                lblRegFis.Text = dr("Em_RFiscal").ToString
                                txtEmiRegFis.Text = dr("Em_RFiscal").ToString
                                TextBox1.Text = dr("Em_CP").ToString
                            Next
                        End If
                        cnn.Close()
                    End If
                End With
            End If
            llena_cboFolioPar()
            llena_cbofolio()
            getFolio()
            cbo_rfc_emisor.Focus()
        End If
    End Sub

    Private Sub cbo_rfc_emisor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_rfc_emisor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cbo_rfc_emisor.Text <> "" Then
                Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                Dim sinfo As String = ""
                Dim dt As New DataTable
                Dim dr As DataRow
                Dim odata As New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDt(cnn, dt, "select * from DatosNegocio where Em_rfc = '" & cbo_rfc_emisor.Text & "'", sinfo) Then
                            For Each dr In dt.Rows
                                cbo_emisor.Text = dr("Em_RazonSocial").ToString
                                lblRegFis.Text = dr("Em_RFiscal").ToString
                                txtEmiRegFis.Text = dr("Em_RFiscal").ToString
                                TextBox1.Text = dr("Em_CP").ToString
                            Next
                        End If
                        cnn.Close()
                    End If
                End With
            End If
            llena_cboFolioPar()
            llena_cbofolio()
            getFolio()
            Cmb_RazonS.Focus()
        End If
    End Sub

    Private Sub Cmb_RazonS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_RazonS.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from Clientes where RazonSocial = '" & Cmb_RazonS.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            Cmb_RFC.Text = dr("RFC").ToString
                            txtCliRegFis.Text = dr("Regfis").ToString
                            txtCPCLiente.Text = dr("CP").ToString
                        Next
                    End If
                    cnn.Close()
                End If
            End With
            Cmb_RFC.Focus()
        End If
    End Sub

    Private Sub Cmb_RFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_RFC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from Clientes where RFC = '" & Cmb_RFC.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            Cmb_RazonS.Text = dr("RazonSocial").ToString
                            txtCliRegFis.Text = dr("Regfis").ToString
                            txtCPCLiente.Text = dr("CP").ToString
                        Next
                    End If
                    cnn.Close()
                End If
            End With
            cboFolio.Focus()
        End If
    End Sub

    Private Sub cboFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If cboFolio.Text <> "" Then
                Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                Dim sinfo As String = ""
                Dim dt As New DataTable
                Dim dr As DataRow
                Dim odata As New ToolKitSQL.myssql
                With odata
                    If .dbOpen(cnn, sTarget, sinfo) Then
                        If .getDt(cnn, dt, "select * from Facturas where nom_folio = " & cboFolio.Text & "", sinfo) Then
                            For Each dr In dt.Rows
                                txtUUID.Text = dr("nom_folio_sat_uuid").ToString
                                txtFolioParci.Text = "1"
                                txtMonto.Text = "0"

                                TotalFact = dr("nom_total_pagado").ToString

                                txtTotalIVA0.Text = 0

                                Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                                Dim sinfo1 As String = ""
                                Dim dt1 As New DataTable
                                Dim dr1 As DataRow
                                Dim odata1 As New ToolKitSQL.myssql
                                If odata1.dbOpen(cnn1, sTarget, sinfo1) Then
                                    If odata1.getDt(cnn1, dt1, "select * from detalle_factura where factura = " & dr("nom_id").ToString & "", sinfo1) Then
                                        For Each dr1 In dt1.Rows

                                            If CDec(dr1("isr").ToString) > 0 Then
                                                If porcentajeisr = "" Then
                                                    porcentajeisr = FormatNumber(CDec(dr1("isr").ToString), 6).ToString
                                                End If
                                            End If

                                            If CDec(dr1("ret_iva_perc").ToString) > 0 Then
                                                If porcentajeivaret = "" Then
                                                    porcentajeivaret = dr1("ret_iva_perc").ToString
                                                End If
                                            End If

                                            If CDec(dr1("porceniva").ToString) > 0 Then
                                            Else
                                                If CDec(dr1("ieps").ToString) > 0 Then
                                                Else
                                                    If CDec(dr1("isr").ToString) > 0 Then
                                                    Else
                                                        txtTotalIVA0.Text = CDec(txtTotalIVA0.Text) + CDec(dr1("totalsiva").ToString)
                                                    End If
                                                End If
                                            End If
                                        Next

                                    End If
                                    cnn1.Close()
                                End If

                                If porcentajeisr = "" Then
                                    porcentajeisr = "0"
                                End If

                                If porcentajeivaret = "" Then
                                    porcentajeivaret = "0"
                                End If

                                txtTotalIVA0.Text = FormatNumber(txtTotalIVA0.Text, 2)
                                txtTotalIVA.Text = FormatNumber(dr("iva").ToString, 2)
                                txtTotalIVAret.Text = FormatNumber(dr("nom_ivaret").ToString, 2)
                                txtTotalIEPS.Text = FormatNumber(dr("nom_mdescuento").ToString, 2)
                                txtTotalISR.Text = FormatNumber(dr("nom_isr").ToString, 2)



                            Next
                        End If
                        cnn.Close()
                    End If
                End With
                txtFolioParci.Focus()
            Else
                RichtxtComentario.Focus()
            End If
        End If
    End Sub

    Private Sub txtUUID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUUID.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtFolioParci.Focus()
        End If
    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress

        If AscW(e.KeyChar) = Keys.Enter Then
            If txtMonto.Text = "0" Then
                cboFolio.Focus()
            Else
                If IsNumeric(txtMonto.Text) And CDec(txtMonto.Text) > 0 Then

                    Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
                    Dim sinfo As String = ""
                    Dim dt As New DataTable
                    Dim dr As DataRow
                    Dim odata As New ToolKitSQL.myssql
                    Dim saldoAnt As Decimal = 0
                    Dim TotalFact As Decimal = 0
                    Dim folFactParcID As Integer = 0

                    With odata
                        If .dbOpen(cnn, sTarget, sinfo) Then
                            If .getDt(cnn, dt, "select * from Facturas where nom_folio_sat_uuid = '" & txtUUID.Text & "'", sinfo) Then
                                For Each dr In dt.Rows
                                    saldoAnt = CDec(dr("nom_total_pagado").ToString)
                                    TotalFact = CDec(dr("nom_total_pagado").ToString)
                                    folFactParcID = dr("nom_id").ToString
                                Next
                            End If
                            cnn.Close()
                        End If
                    End With

                    If CDec(txtMonto.Text) > CDec(saldoAnt) Then
                        MsgBox("El monto no puede ser mayor al restante de las parcialidades")
                        txtMonto.Focus()
                        Exit Sub
                    Else

                        cnn = New MySqlClient.MySqlConnection
                        sinfo = ""
                        dt = New DataTable
                        If odata.dbOpen(cnn, sTarget, sinfo) Then
                            If odata.getDt(cnn, dt, "select * from detalle_factura where factura = " & folFactParcID & "", sinfo) Then
                                For Each dr In dt.Rows

                                    If CDec(dr("isr").ToString) > 0 Then
                                        porcentajeisr = FormatNumber(CDec(dr("isr").ToString), 6).ToString
                                    End If

                                    If CDec(dr("ret_iva_perc").ToString) > 0 Then
                                        porcentajeivaret = dr("ret_iva_perc").ToString
                                    End If

                                    'If CDec(dr("porceniva").ToString) > 0 Then
                                    'Else
                                    '    If CDec(dr("ieps").ToString) > 0 Then
                                    '    Else
                                    '        If CDec(dr("isr").ToString) > 0 Then
                                    '        Else
                                    '            txtTotalIVA0.Text = CDec(txtTotalIVA0.Text) + CDec(dr("totalsiva").ToString)
                                    '        End If
                                    '    End If
                                    'End If
                                Next
                                cnn.Close()
                            End If
                        End If

                        If porcentajeisr = "" Then
                            porcentajeisr = "0"
                        End If

                        If porcentajeivaret = "" Then
                            porcentajeivaret = "0"
                        End If




                        txtMontoPar.Text = FormatNumber(CDec(txtMontoPar.Text) + CDec(txtMonto.Text), 2)

                        Dim opebasereal As Double = 0
                        opebasereal = 0 'FormatNumber(CDec(CDec(txtMonto.Text) * CDec(frm_facturacion.TextBox1.Text)) / CDec(txtTotalFact.Text), 2)

                        Dim opebaseivareal As Double = 0
                        Dim opebaseiva0real As Double = 0
                        Dim opebaseivaretreal As Double = 0
                        Dim opebaseiepsreal As Double = 0
                        Dim opebaseiisrreal As Double = 0

                        Dim opeiva As Double = 0
                        Dim opeivaret As Double = 0
                        Dim opeisr As Double = 0
                        Dim opeieps As Double = 0
                        Dim opeiva0 As Double = 0

                        Dim baseiva As Double = 0
                        Dim baseisr As Double = 0
                        Dim baseivaret As Double = 0
                        Dim baseiva0 As Double = 0

                        cnn = New MySqlClient.MySqlConnection
                        Dim sinfo2 As String = ""
                        Dim dt2 As New DataTable
                        Dim dr2 As DataRow
                        Dim odata2 As New ToolKitSQL.myssql
                        With odata2
                            If .dbOpen(cnn, sTarget, sinfo2) Then
                                If .getDt(cnn, dt2, "select * from detalle_factura where factura = " & folFactParcID, sinfo2) Then
                                    For Each dr2 In dt2.Rows
                                        If dr2("porceniva").ToString > 0 Then
                                            opebaseivareal = opebaseivareal + dr2("totalsiva").ToString
                                        ElseIf dr2("porceniva").ToString = 0 And dr2("ieps_porcentaje").ToString = 0 Then
                                            opebaseiva0real = opebaseiva0real + dr2("totalsiva").ToString
                                        End If
                                        If dr2("isr").ToString > 0 Then
                                            opebaseiisrreal = opebaseiisrreal + dr2("totalsiva").ToString
                                        End If
                                        If dr2("ret_iva_perc").ToString > 0 Then
                                            opebaseivaretreal = opebaseivaretreal + dr2("totalsiva").ToString
                                        End If
                                    Next
                                End If
                                cnn.Close()
                            End If
                        End With

                        opeiva = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVA.Text)) / CDec(CDec(TotalFact)), 2)
                        opeiva0 = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVA0.Text)) / CDec(CDec(TotalFact)), 2)
                        opeivaret = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVAret.Text)) / CDec(CDec(TotalFact)), 2)
                        opeisr = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalISR.Text)) / CDec(CDec(TotalFact)), 2)
                        opeieps = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIEPS.Text)) / CDec(CDec(TotalFact)), 2)

                        'opeiva = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVA.Text)) / CDec(CDec(TotalFact) + CDec(txtTotalIVAret.Text) + CDec(txtTotalISR.Text)), 2)
                        'opeiva0 = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVA0.Text)) / CDec(CDec(TotalFact) + CDec(txtTotalIVAret.Text) + CDec(txtTotalISR.Text)), 2)
                        'opeivaret = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIVAret.Text)) / CDec(CDec(TotalFact) + CDec(txtTotalIVAret.Text) + CDec(txtTotalISR.Text)), 2)
                        'opeisr = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalISR.Text)) / CDec(CDec(TotalFact) + CDec(txtTotalIVAret.Text) + CDec(txtTotalISR.Text) - CDec(txtTotalIVA.Text)), 2)
                        'opeieps = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(txtTotalIEPS.Text)) / CDec(CDec(TotalFact) + CDec(txtTotalIVAret.Text) + CDec(txtTotalISR.Text)), 2)

                        If opeiva > 0 Then
                            opebasereal = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(opebaseivareal)) / CDec(TotalFact), 2)
                            baseiva = opebasereal 'CDec(txtMonto.Text) - opeiva + CDec(txtTotalISR.Text)
                        End If

                        If opeisr > 0 Then
                            opebasereal = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(opebaseiisrreal)) / CDec(TotalFact), 2)
                            baseisr = opebasereal
                        End If

                        If opeivaret > 0 Then
                            opebasereal = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(opebaseivaretreal)) / CDec(TotalFact), 2)
                            baseivaret = opebasereal
                        End If

                        If opeiva0 > 0 Then
                            opebasereal = FormatNumber(CDec(CDec(txtMonto.Text) * CDec(opebaseiva0real)) / CDec(TotalFact), 2)
                            baseiva0 = opebasereal
                        End If

                        Dim banderaieps As Integer = 0

                        Dim cuantosieps(12) As String
                        For xd = 0 To 11
                            cuantosieps(xd) = ""
                        Next

                        Dim strieps As String = ""

                        ieps160 = 0
                        ieps53 = 0
                        ieps5 = 0
                        ieps304 = 0
                        ieps3 = 0
                        ieps265 = 0
                        ieps25 = 0
                        ieps09 = 0
                        ieps08 = 0
                        ieps07 = 0
                        ieps06 = 0
                        ieps03 = 0

                        Baseieps160 = 0
                        Baseieps53 = 0
                        Baseieps5 = 0
                        Baseieps304 = 0
                        Baseieps3 = 0
                        Baseieps265 = 0
                        Baseieps25 = 0
                        Baseieps09 = 0
                        Baseieps08 = 0
                        Baseieps07 = 0
                        Baseieps06 = 0
                        Baseieps03 = 0

                        If opeieps > 0 Then

                            cnn = New MySqlClient.MySqlConnection
                            sinfo2 = ""
                            dt2 = New DataTable
                            odata2 = New ToolKitSQL.myssql
                            With odata2
                                If .dbOpen(cnn, sTarget, sinfo2) Then
                                    If .getDr(cnn, dr2, "select nom_mdescuento from Facturas where nom_id = " & folFactParcID, sinfo2) Then
                                        If CDec(dr2(0).ToString) > 0 Then
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

                            If banderaieps <> 0 Then

                                cnn = New MySqlClient.MySqlConnection
                                sinfo2 = ""
                                dt2 = New DataTable
                                odata2 = New ToolKitSQL.myssql
                                With odata2
                                    If .dbOpen(cnn, sTarget, sinfo2) Then
                                        If .getDt(cnn, dt2, "select distinct ieps_porcentaje from detalle_factura where factura = " & folFactParcID, sinfo2) Then
                                            Dim i As Integer = 0
                                            For Each dr2 In dt2.Rows
                                                If dr2(0).ToString <> 0 Then
                                                    cuantosieps(i) = dr2(0).ToString
                                                    strieps = strieps & dr2(0).ToString & ","
                                                    i = i + 1
                                                End If
                                            Next
                                        End If

                                        strieps = Mid(strieps, 1, Len(strieps) - 1)

                                        For xd = 0 To 11
                                            If cuantosieps(xd) <> "" Then

                                                dt2 = New DataTable
                                                If .getDt(cnn, dt2, "select ieps,totalsiva from detalle_factura where factura = " & folFactParcID & " and  ieps_porcentaje = '" & cuantosieps(xd) & "'", sinfo2) Then
                                                End If

                                                Select Case cuantosieps(xd)
                                                    Case "0.030000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps03 = ieps03 + CDec(dr2(0).ToString)
                                                            Baseieps03 = Baseieps03 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.060000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps06 = ieps06 + CDec(dr2(0).ToString)
                                                            Baseieps06 = Baseieps06 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.070000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps07 = ieps07 + CDec(dr2(0).ToString)
                                                            Baseieps07 = Baseieps07 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.080000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps08 = ieps08 + CDec(dr2(0).ToString)
                                                            Baseieps08 = Baseieps08 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.090000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps09 = ieps09 + CDec(dr2(0).ToString)
                                                            Baseieps09 = Baseieps09 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.250000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps25 = ieps25 + CDec(dr2(0).ToString)
                                                            Baseieps25 = Baseieps25 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.265000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps265 = ieps265 + CDec(dr2(0).ToString)
                                                            Baseieps265 = Baseieps265 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.300000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps3 = ieps3 + CDec(dr2(0).ToString)
                                                            Baseieps3 = Baseieps3 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.304000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps304 = ieps304 + CDec(dr2(0).ToString)
                                                            Baseieps304 = Baseieps304 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.500000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps5 = ieps5 + CDec(dr2(0).ToString)
                                                            Baseieps5 = Baseieps5 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "0.530000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps53 = ieps53 + CDec(dr2(0).ToString)
                                                            Baseieps53 = Baseieps53 + CDec(dr2(1).ToString)
                                                        Next
                                                    Case "1.600000"
                                                        For Each dr2 In dt2.Rows
                                                            ieps160 = ieps160 + CDec(dr2(0).ToString)
                                                            Baseieps160 = Baseieps160 + CDec(dr2(1).ToString)
                                                        Next
                                                End Select

                                            End If
                                        Next

                                        cnn.Close()
                                    End If
                                End With

                            End If

                        End If


                        GridParcialidades.Rows.Insert(var1, cboFolio.Text, FormatNumber(saldoAnt, 2), FormatNumber(txtMonto.Text, 2), FormatNumber(CDec(saldoAnt) - CDec(txtMonto.Text), 2), txtFolioParci.Text, "PPD", "MXN", txtSerie.Text, txtUUID.Text, opeiva, opeivaret, opeieps, opeisr, opeiva0, porcentajeisr, porcentajeivaret, strieps, ieps160, ieps53, ieps5, ieps304, ieps3, ieps265, ieps25, ieps09, ieps08, ieps07, ieps06, ieps03, Baseieps160, Baseieps53, Baseieps5, Baseieps304, Baseieps3, Baseieps265, Baseieps25, Baseieps09, Baseieps08, Baseieps07, Baseieps06, Baseieps03, baseiva, baseisr, baseivaret, baseiva0)

                        var1 += 1
                        cboFolio.Text = ""
                        txtUUID.Text = ""
                        txtFolioParci.Text = ""
                        txtMonto.Text = "0"
                        txtTotalISR.Text = "0"
                        txtTotalIVA.Text = "0"
                        txtTotalIVA0.Text = "0"
                        txtTotalIEPS.Text = "0"
                        txtTotalIVAret.Text = "0"

                        cboFolio.Focus()

                    End If

                End If
            End If

        End If

    End Sub

    Private Sub recupera_campos()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = ""
        sSQL = "Select * from ParcialidadesMulti where FolioPar=" & cboFolioPar.Text & " and EmiIdDatos = " & cbo_emisor.SelectedValue & ""
        GridParcialidades.Rows.Clear()
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    txtNumCtaCliente.Text = dr("NumCta").ToString
                    txtSerie.Text = dr("Serie").ToString
                    cadena_pagos1 = ""
                    txtNumOpe.Text = dr("NumOperacion").ToString
                    ''''''''''''''''''''''''''''''''
                    txtNumCta.Text = dr("NumCta").ToString
                    txtNumCtaCliente.Text = dr("NumCtaCliente").ToString
                    txtCtaRFCEmi.Text = dr("CtaRFCEmi").ToString
                    txtCtaRFCCli.Text = dr("CtaRFCCli").ToString
                    txtCtaBanco.Text = dr("Banco").ToString
                    ''''''''''''''''''''''''''''''''
                    RichtxtComentario.Text = dr("Comentario").ToString
                    txtMontoPar.Text = dr("Monto").ToString
                    dtpFechaPago.Value = dr("FechaPago").ToString
                    dtpHoraPago.Value = dr("FechaPago").ToString 'FormatDateTime(dtpFechaPago.Text, DateFormat.ShortTime)
                    cboMoneda.Text = dr("MonedaP").ToString
                    cboFormaPago.SelectedValue = dr("FormaPago").ToString
                    txtCP.Text = dr("LugarExp").ToString
                    variableParci = dr("Id").ToString

                    Cmb_RazonS.Text = dr("CliRazon").ToString
                    Cmb_RFC.Text = dr("CliRFC").ToString

                Else
                    MsgBox("El folio de parcialidad no existe")
                    banderabusqueda = 1
                    GoTo door
                End If

                var1 = 0
                Dim dt2 As New DataTable
                Dim dr2 As DataRow
                If .getDt(cnn, dt2, "select * from ParcialidadesDetalleMulti where IdParcialidades = " & variableParci & "", sinfo) Then
                    For Each dr2 In dt2.Rows
                        GridParcialidades.Rows.Insert(var1, dr2("Folio").ToString, dr2("ImpSaldoAnt").ToString, dr2("ImpPagado").ToString, dr2("ImpSaldoIns").ToString, dr2("NumParcialidades").ToString, dr2("MetodoPago").ToString, dr2("Moneda").ToString, dr2("Serie").ToString, dr2("UUID").ToString, dr2("OpeIva").ToString, dr2("OpeIvaRet").ToString, dr2("OpeIeps").ToString, dr2("OpeIsr").ToString, dr2("OpeIva0").ToString, dr2("IsrPorc").ToString, dr2("IvaRetPorc").ToString, dr2("IepsPorc").ToString, dr2("ieps160").ToString, dr2("ieps53").ToString, dr2("ieps5").ToString, dr2("ieps304").ToString, dr2("ieps3").ToString, dr2("ieps265").ToString, dr2("ieps25").ToString, dr2("ieps09").ToString, dr2("ieps08").ToString, dr2("ieps07").ToString, dr2("ieps06").ToString, dr2("ieps03").ToString, dr2("Baseieps160").ToString, dr2("Baseieps53").ToString, dr2("Baseieps5").ToString, dr2("Baseieps304").ToString, dr2("Baseieps3").ToString, dr2("Baseieps265").ToString, dr2("Baseieps25").ToString, dr2("Baseieps09").ToString, dr2("Baseieps08").ToString, dr2("Baseieps07").ToString, dr2("Baseieps06").ToString, dr2("Baseieps03").ToString, dr2("BaseIVA16").ToString, dr2("BaseISR").ToString, dr2("BaseIVARet").ToString, dr2("BaseIVA0").ToString)
                        var1 += 1
                    Next
                End If

                cnn.Close()

            End If

        End With
door:
    End Sub

    Private Sub RichtxtComentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RichtxtComentario.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGenerar.Focus()
        End If
    End Sub

    Private Sub txtFolioParci_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioParci.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtMonto.Focus()
        End If
    End Sub

    Private Function valida_datos()

        If txtSerie.Text = "" Then
            MsgBox("Escriba un numero de serie")
            txtSerie.Focus()
            Return False
        End If

        If cboFolioPar.Text = "" Then
            Dim sSQL As String = "Select max(FolioPar) as XD from ParcialidadesMulti where EmiIdDatos = " & cbo_emisor.SelectedValue & ""
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim dr As DataRow
            Dim sinfo As String = ""
            Dim oData As New ToolKitSQL.myssql
            With oData
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDr(cnn, dr, sSQL, sinfo) Then
                        If dr("XD").ToString = "" Then
                            cboFolioPar.Text = 1
                        Else
                            cboFolioPar.Text = CDec(dr("XD").ToString) + 1
                        End If
                    Else
                        cboFolioPar.Text = 1
                    End If
                    cnn.Close()
                Else
                End If
            End With
            cboFolioPar.Focus()
            Return False
        End If

        If txtCP.Text = "" Then
            MsgBox("El código postal no puede estar vacio")
            txtMontoPar.Focus()
            Return False
        End If

        If checat(cbo_rfc_emisor.Text) Then
        Else
            Return False
        End If

        Return True

    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        GroupBox20.Visible = True
        cboTipoCancelacion.Focus()
    End Sub

    Private Sub busca_d()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from ParcialidadesMulti where Id=" & cboFolioPar.SelectedValue
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    uidcancel = dr("UUID").ToString
                    refccancel = dr("EmiRFC").ToString
                End If
                cnn.Close()
            End If
        End With

    End Sub

    Public Sub printReciboPar(ByVal FolioUnido As String, ByVal maxnumpar As String, ByVal email As String)

        Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString

        crea_dir("C:\DelsscomFarmacias.\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\PARCIALIDADES\")
        Dim root_name_recibo As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\PARCIALIDADES\" & FolioUnido & ".pdf"

        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Dim varcalleemi As String = ""
        Dim varcoloniaemi As String = ""
        Dim varaclmunemi As String = ""
        Dim varentidadaemi As String = ""
        Dim varregimenemi As String = ""
        Dim varcallecli As String = ""
        Dim varcoloniacli As String = ""
        Dim varaclmuncli As String = ""
        Dim varentidadacli As String = ""
        Dim varregimencli As String = ""
        Dim varserie As String = ""
        Dim varfolio As String = ""
        Dim varfoliounido As String = ""
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
        Dim varnumletra As String = "" 'convLetras(CDbl(Text_TOTAL.Text))
        Dim varleyenda As String = ""
        Dim varsellocfdi As String = ""
        Dim varsellosat As String = ""
        Dim varcadenaoriginal As String = ""
        Dim varmonto As String = ""
        Dim varfechapago As String = ""
        Dim varnumoperacion As String = ""
        Dim varmonedap As String = ""

        Dim varBaseIVA16 As String = ""
        Dim varBaseIVA0 As String = ""

        Dim varNumCta As String = ""
        Dim varNumCtaCliente As String = ""
        Dim varCtaRFCCli As String = ""
        Dim varCtaRFCEmi As String = ""
        Dim varBanco As String = ""
        Dim varBancoEmi As String = ""

        Dim banderaieps As Integer = 0

        Dim ieps160 As Decimal = 0 : Dim ieps53 As Decimal = 0 : Dim ieps5 As Decimal = 0
        Dim ieps304 As Decimal = 0 : Dim ieps3 As Decimal = 0 : Dim ieps265 As Decimal = 0
        Dim ieps25 As Decimal = 0 : Dim ieps09 As Decimal = 0 : Dim ieps08 As Decimal = 0
        Dim ieps07 As Decimal = 0 : Dim ieps06 As Decimal = 0 : Dim ieps03 As Decimal = 0

        Dim cuantosieps(20) As String
        For xd = 0 To 19
            cuantosieps(xd) = ""
        Next

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RFS.ClaveRegFis, RFS.Descripcion from DatosNegocio DN, RegimenFiscalSat RFS where RFS.ClaveRegFis = DN.Em_RFiscal and DN.Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    varregimenemi = dr("ClaveRegFis").ToString & " " & dr("Descripcion").ToString
                Else
                    varregimenemi = ""
                End If
                cnn.Close()
            End If
        End With

        Dim sSQL1 As String = ""
        sSQL1 = "Select * from ParcialidadesMulti where FolioPar=" & cboFolioPar.Text & ""
        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL1, sinfo) Then
                    varnomid = dr("Id").ToString
                    varfolio = dr("FolioPar").ToString
                    varfoliounido = dr("FolioUnido").ToString
                    varfechaemision = dr("Fecha").ToString
                    varfechacertifi = dr("FechaTimbrado").ToString
                    varcertifsat = dr("NoCertSat").ToString
                    varcertifemi = dr("NoCert").ToString
                    varuuid = dr("UUID").ToString
                    varusocfdi = dr("CliUsoCFDI").ToString
                    varmetodopago = "PPD Pago en parcialidades o diferido"
                    varformapago = dr("FormaPago").ToString
                    varleyenda = dr("Comentario").ToString
                    varsellosat = dr("SelloSat").ToString
                    varsellocfdi = dr("SelloCFD").ToString
                    varcadenaoriginal = dr("CadenaOriginal").ToString
                    varmonto = dr("Monto").ToString
                    varfechapago = dr("FechaPago").ToString
                    varnumoperacion = dr("NumOperacion").ToString
                    varmonedap = dr("MonedaP").ToString

                    varNumCta = dr("NumCta").ToString
                    varNumCtaCliente = dr("NumCtaCliente").ToString
                    varCtaRFCCli = dr("CtaRFCCli").ToString
                    varCtaRFCEmi = dr("CtaRFCEmi").ToString
                    varBanco = dr("Banco").ToString
                    varBancoEmi = dr("BancoEmi").ToString

                    varBaseIVA16 = dr("BaseIVA16").ToString
                    varBaseIVA0 = dr("BaseIVA0").ToString

                End If
                cnn.Close()
            End If
        End With

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from DatosNegocio where Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "'", sinfo) Then
                    If Trim(dr("Em_calle").ToString) <> "" Then
                        varcalleemi = "Calle: " & Trim(dr("Em_calle").ToString)
                    End If
                    If Trim(dr("Em_NumExterior").ToString) <> "" Then
                        varcalleemi = varcalleemi & " Num. Ext.: " & Trim(dr("Em_NumExterior").ToString)
                    End If
                    If Trim(dr("Em_NumInterior").ToString) <> "" Then
                        varcalleemi = varcalleemi & " Num. Int.: " & Trim(dr("Em_NumInterior").ToString)
                    End If
                    If Trim(dr("Em_colonia").ToString) <> "" Then
                        varcoloniaemi = "Colonia: " & Trim(dr("Em_colonia").ToString)
                    End If
                    If Trim(dr("Em_Municipio").ToString) <> "" Then
                        varaclmunemi = "Alc./Mun.: " & Trim(dr("Em_Municipio").ToString)
                    End If
                    If Trim(dr("Em_Estado").ToString) <> "" Then
                        varentidadaemi = "Entidad Federativa: " & Trim(dr("Em_Estado").ToString)
                    End If
                End If
                cnn.Close()
            End If
        End With

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from Clientes where RazonSocial = '" & Trim(Cmb_RazonS.Text) & "'", sinfo) Then
                    If Trim(dr("Calle").ToString) <> "" Then
                        varcallecli = "Calle: " & Trim(dr("Calle").ToString)
                    End If
                    If Trim(dr("NExterior").ToString) <> "" Then
                        varcallecli = varcallecli & " Num. Ext.: " & Trim(dr("NExterior").ToString)
                    End If
                    If Trim(dr("NInterior").ToString) <> "" Then
                        varcallecli = varcallecli & " Num. Int.: " & Trim(dr("NInterior").ToString)
                    End If
                    If Trim(dr("Colonia").ToString) <> "" Then
                        varcoloniacli = "Colonia: " & Trim(dr("Colonia").ToString)
                    End If
                    If Trim(dr("Delegacion").ToString) <> "" Then
                        varaclmuncli = "Alc./Mun.: " & Trim(dr("Delegacion").ToString)
                    End If
                    If Trim(dr("CP").ToString) <> "" Then
                        varaclmuncli = varaclmuncli & " C.P.: " & Trim(dr("CP").ToString)
                    End If
                    If Trim(dr("Entidad").ToString) <> "" Then
                        varentidadacli = "Entidad Federativa: " & Trim(dr("Entidad").ToString)
                    End If
                    If Trim(txtCliRegFis.Text) <> "" Then
                        varregimencli = txtCliRegFis.Text
                        Dim dr222 As DataRow
                        .getDr(cnn, dr222, "Select RFS.ClaveRegFis, RFS.Descripcion from RegimenFiscalSat RFS where RFS.ClaveRegFis = '" & Trim(txtCliRegFis.Text) & "'", sinfo)
                        varregimencli = varregimencli & " " & dr222(1).ToString
                    End If

                End If
                cnn.Close()
            End If
        End With

        Dim sinfo2 As String = ""
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim odata2 As New ToolKitSQL.oledbdata
        Dim isrporc As String = "0"
        Dim ivaretporc As String = "0"

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
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from UsoComproCFDISat where ClaveUsoCFDI = '" & varusocfdi & "'", sinfo) Then
                    varusocfdi = dr("ClaveUsoCFDI").ToString & " " & dr("Descripcion").ToString
                End If
                cnn.Close()
            End If
        End With

        If IsNumeric(varfolio) = False Then
            MsgBox("Debe seleccionar un folio")
            Exit Sub
        End If

        Dim pdfDoc As New Document(PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
        Dim pdfWrite As PdfWriter

        pdfWrite = PdfWriter.GetInstance(pdfDoc, New FileStream(root_name_recibo, FileMode.CreateNew))

        Dim Font8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        Dim FontB8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
        Dim FontB12 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD))
        Dim CVacio As PdfPCell = New PdfPCell(New Phrase(""))
        CVacio.Border = 0

        pdfDoc.Open()

        If Trim(txtSerie.Text) <> "" Then
            varserie = Trim(txtSerie.Text)
        End If

        If Trim(txtCP.Text) <> "" Then
            varaclmunemi = varaclmunemi & " C.P.: " & Trim(txtCP.Text)
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

        Dim widths As Single() = New Single() {12.0F, 1.0F, 1.0F, 5.0F, 0.5F}

        Table1.SetWidths(widths)

#Region "Tabla.Encabezado"

        Dim var666 As String = ""
        busca_logo(var666)

        Try
            Dim imagenURL As String = var666
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
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(cbo_emisor.Text) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(cbo_emisor.Text))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(cbo_rfc_emisor.Text, FontB8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(cbo_rfc_emisor.Text) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(cbo_rfc_emisor.Text))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varcalleemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varcalleemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcalleemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varcoloniaemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varcoloniaemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcoloniaemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varaclmunemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varaclmunemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varaclmunemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varentidadaemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Col4 = New PdfPCell(New Phrase("PARCIALIDAD", FontB8)) ' Col4 = New PdfPCell(New Phrase(Cmb_TipoFact.Text, FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 2
        Table1.AddCell(Col4)
        '        Table1.AddCell(CVacio)

        If Len(varentidadaemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varentidadaemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Lugar de Expedición: " & Trim(txtCP.Text), Font8))
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

        If Len("Lugar de Expedición: " & Trim(txtCP.Text)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len("Lugar de Expedición: " & Trim(txtCP.Text)))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Régimen Fiscal Emisor: " & Trim(varregimenemi), Font8))
        Col1.Border = 0
        Col1.Colspan = 3
        Table1.AddCell(Col1)
        Col4 = New PdfPCell(New Phrase("", FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 2
        Table1.AddCell(Col4)
        'Table1.AddCell(CVacio)

        If Len("Regimen Fiscal Emisor: " & Trim(varregimenemi)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len("Regimen Fiscal Emisor: " & Trim(varregimenemi)))
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
            varYlinea = varYlinea - damevalorlinea(Len("Fecha de Emisión: " & varfechaemision))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(Trim(Cmb_RazonS.Text), FontB8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)
        Col4 = New PdfPCell(New Phrase("Fecha de Certificación: " & varfechacertifi, FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 4
        Table1.AddCell(Col4)
        'Table1.AddCell(CVacio)

        If Len(Trim(Cmb_RazonS.Text)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(Trim(Cmb_RazonS.Text)))
        Else
            varYlinea = varYlinea - 12
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
            varYlinea = varYlinea - damevalorlinea(Len(Cmb_RFC.Text))
        Else
            varYlinea = varYlinea - 12
        End If

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
            varYlinea = varYlinea - damevalorlinea(Len(varcallecli))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(Trim(varcoloniacli), Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Col4 = New PdfPCell(New Phrase("Tipo de Comprobante: P PAGO", FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 4
        Table1.AddCell(Col4)
        'Table1.AddCell(CVacio)

        If Len(varcoloniacli) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcoloniacli))
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
            varYlinea = varYlinea - damevalorlinea(Len(varaclmuncli))
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
            varYlinea = varYlinea - damevalorlinea(Len(varentidadacli))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Régimen Fiscal Cliente: " & Trim(varregimencli), Font8))
        Col1.Border = 0
        Col1.Colspan = 5
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        If Len("Regimen Fiscal Cliente: " & Trim(varregimencli)) > 71 Then
            varYlinea = varYlinea - 12 'damevalorlinea(Len("Regimen Fiscal Cliente: " & Trim(varregimencli)))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Uso de CFDI: " & Trim(varusocfdi), Font8))
        Col1.Border = 0
        Col1.Colspan = 5
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        If Len("Uso de CFDI: " & Trim(varusocfdi)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len("Uso de CFDI: " & Trim(varusocfdi)))
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
                varYlinea = varYlinea - damevalorlinea(Len("Tipo Relacion: " & Trim(vartiporelacion)))
            Else
                varYlinea = varYlinea - 12
            End If
        End If

        pdfDoc.Add(Table1)

#End Region

        'PintarCuadrado(0.7, 410, 740, 530, 820, pdfWrite, pdfDoc)
        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)
        'pdfDoc.Add(New Paragraph("."))

#Region "Tabla3-Cabecera"

        Dim Table3 As PdfPTable = New PdfPTable(9)
        Dim widths3 As Single() = New Single() {1.0F, 3.0F, 3.0F, 2.0F, 8.0F, 3.0F, 3.0F, 3.0F, 1.0F}
        Table3.WidthPercentage = 95
        Table3.SetWidths(widths3)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("CLAVE SAT", FontB8))
        Col2.Border = 0
        Table3.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("U. VENTA", FontB8))
        Col3.Border = 0
        Table3.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("CANT.", FontB8))
        Col4.Border = 0
        Table3.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("DESCRIPCIÓN", FontB8))
        Col5.Border = 0
        Table3.AddCell(Col5)
        Col6 = New PdfPCell(New Phrase("P.UNITARIO", FontB8))
        Col6.Border = 0
        Col6.HorizontalAlignment = 1
        Table3.AddCell(Col6)
        Col7 = New PdfPCell(New Phrase("IMPORTE", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Col7 = New PdfPCell(New Phrase("OBJETO IMPUESTO", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 20

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("84111506", FontB8))
        Col2.Border = 0
        Table3.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("ACT", FontB8))
        Col3.Border = 0
        Table3.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("1", FontB8))
        Col4.Border = 0
        Table3.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("PAGO", FontB8))
        Col5.Border = 0
        Table3.AddCell(Col5)
        Col6 = New PdfPCell(New Phrase("0", FontB8))
        Col6.Border = 0
        Col6.HorizontalAlignment = 1
        Table3.AddCell(Col6)
        Col7 = New PdfPCell(New Phrase("0", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Col7 = New PdfPCell(New Phrase("02", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("MONEDA: XXX Los códigos asignados para las transacciones en que intervenga ninguna moneda", FontB8))
        Col2.Border = 0
        Col2.Colspan = 5
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("SUBTOTAL: $0.00", FontB8))
        Col7.Border = 0
        Col7.Colspan = 2
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("", FontB8))
        Col2.Border = 0
        Col2.Colspan = 5
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("TOTAL: $0.00", FontB8))
        Col7.Border = 0
        Col7.Colspan = 2
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("", FontB8))
        Col2.Border = 0
        Col2.Colspan = 4
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("MONTO TOTAL PAGADO: $" & varmonto, FontB8))
        Col7.Border = 0
        Col7.Colspan = 3
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        pdfDoc.Add(Table3)

#End Region

        varYlinea = varYlinea - 12

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Dim varOpeIva As Double = 0
        Dim varOpeIva0 As Double = 0
        Dim varOpeIvaRet As Double = 0
        Dim varOpeIsr As Double = 0
        Dim varOpeIeps As Double = 0

#Region "Tabla4-detalle"

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from ParcialidadesDetalleMulti where IdParcialidades = " & varnomid, sinfo) Then

                    For Each dr In dt.Rows

                        varOpeIva += dr("OpeIva").ToString
                        varOpeIva0 += dr("OpeIva0").ToString
                        varOpeIvaRet += dr("OpeIvaRet").ToString
                        varOpeIsr += dr("OpeIsr").ToString
                        varOpeIeps += dr("OpeIeps").ToString

                        Dim Table4 As PdfPTable = New PdfPTable(5)
                        Dim widths4 As Single() = New Single() {4.0F, 5.0F, 0.5F, 4.0F, 5.0F}
                        Table4.WidthPercentage = 95
                        Table4.SetWidths(widths4)

                        Col1 = New PdfPCell(New Phrase("INFORMACIÓN DEL PAGO", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 5
                        Table4.AddCell(Col1)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("FORMA DE PAGO: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase(varformapago, Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("FECHA DE PAGO", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varfechapago, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("NÚMERO DE OPERACIÓN: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase(varnumoperacion, Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONEDA DE PAGO:", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varmonedap, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("MÉTODO DE PAGO: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase("PUE EN UNA SOLA EXHIBICIÓN", Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONTO:", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varmonto, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        If varNumCta <> "" Or varNumCtaCliente <> "" Or varCtaRFCCli <> "" Or varCtaRFCEmi <> "" Or varBanco <> "" Or varBancoEmi <> "" Then

                            Col1 = New PdfPCell(New Phrase("DOCUMENTO RELACIONADO", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table4.AddCell(Col1)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("NÚMERO CTA CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varNumCtaCliente, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("NÚMERO CTA EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varNumCta, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("RFC BANCO CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varCtaRFCCli, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("RFC BANCO EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varCtaRFCEmi, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("BANCO CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varBanco, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("BANCO EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varBancoEmi, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                        End If

                        pdfDoc.Add(Table4)

                        Dim Table41 As PdfPTable = New PdfPTable(5)
                        Dim widths41 As Single() = New Single() {4.0F, 5.0F, 0.5F, 4.0F, 5.0F}
                        Table41.WidthPercentage = 95
                        Table41.SetWidths(widths41)

                        Col1 = New PdfPCell(New Phrase("DOCUMENTO RELACIONADO", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 5
                        Table41.AddCell(Col1)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("ID DOCUMENTO: " & dr("UUID").ToString, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONEDA DEL DOC. RELACIONADO: MXN PESO MEXICANO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("FOLIO: " & cboFolioPar.Text, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MÉTODO DE PAGO DEL DOCUMENTO RELACIONADO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("SERIE: " & dr("Serie").ToString, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("PPD PAGO EN PARCIALIDADES O DIFERIDO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("NÚMERO PARCIALIDAD: " & varfolio, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE DE SALDO ANTERIOR: " & dr("ImpSaldoAnt").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("OBJETO IMPUESTO: 02", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE PAGADO: " & dr("ImpPagado").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE DE SALDO INSOLUTO: " & dr("ImpSaldoIns").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        If dr("OpeIva").ToString <> 0 Or dr("OpeIva0").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("Impuestos TrasladosDR", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIva").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & (CDec(dr("BaseIVA16").ToString) + varOpeIeps) & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.16, ImporteDR: " & dr("OpeIva").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIva0").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("OpeIva0").ToString & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.00, ImporteDR 0.00 ", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If

                        If dr("OpeIvaRet").ToString <> 0 Or dr("OpeIsr").ToString <> 0 Or dr("OpeIeps").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("Impuestos RetencionesDR", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIvaRet").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("BaseIVA16").ToString & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: " & dr("IvaRetPorc").ToString & ", ImporteDR: " & dr("OpeIvaRet").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIsr").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("BaseISR").ToString & ", ImpuestoDR: ISR, TipoFactorDR: Tasa, Tasa o CuotaDR: " & dr("IsrPorc").ToString & ", ImporteDR: " & dr("OpeIsr").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps160").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps160").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 1.60, ImporteDR: " & CDbl(dr("Baseieps160").ToString) * 1.6, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps53").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps53").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.53, ImporteDR: " & CDbl(dr("Baseieps53").ToString) * 0.53, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps5").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps5").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.5, ImporteDR: " & CDbl(dr("Baseieps5").ToString) * 0.5, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps3").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps3").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.3, ImporteDR: " & CDbl(dr("Baseieps3").ToString) * 0.3, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps265").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps265").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.265, ImporteDR: " & CDbl(dr("Baseieps265").ToString) * 0.265, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps25").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps25").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.25, ImporteDR: " & CDbl(dr("Baseieps25").ToString) * 0.25, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps09").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps09").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.09, ImporteDR: " & CDbl(dr("Baseieps09").ToString) * 0.09, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps08").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps08").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.08, ImporteDR: " & CDbl(dr("Baseieps08").ToString) * 0.08, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps07").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps07").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.07, ImporteDR: " & CDbl(dr("Baseieps07").ToString) * 0.07, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps06").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps06").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.06, ImporteDR: " & CDbl(dr("Baseieps06").ToString) * 0.06, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps03").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps03").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.03, ImporteDR: " & CDbl(dr("Baseieps03").ToString) * 0.03, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If

                        If Trim(varleyenda) <> "" Then
                            Col1 = New PdfPCell(New Phrase("COMENTARIO: ", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase(varleyenda, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)

                            varYlinea = varYlinea - 12

                        End If

                        pdfDoc.Add(Table41)

                        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

                    Next

                End If
                cnn.Close()
            End If
        End With


#End Region

        varYlinea = 295

        'PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        For iFila = 1 To 40
            pdfDoc.Add(New Paragraph(" "))
            ILine = pdfWrite.GetVerticalPosition(True)
            If ILine < 242 Then ' If ILine <296 Then
                Exit For
            End If
        Next

#Region "tabla5-Final"

        Dim Table5 As PdfPTable = New PdfPTable(2)
        Dim widths5 As Single() = New Single() {3.0F, 14.0F}
        Dim Table61 As PdfPTable = New PdfPTable(1)
        Dim widths61 As Single() = New Single() {14.0F}

        Table5.WidthPercentage = 95
        Table5.SetWidths(widths5)

        Table61.SetWidths(widths61)

        Table5.DefaultCell.BorderWidth = 1

        'Table5.DefaultCell.Border = 0

        'Table5.TotalWidth = pdfDoc.PageSize.Width - 40

        Dim y As String = ""

        If varOpeIva <> 0 Then
            y = "Impuestos TrasladosP BaseP: " & varBaseIVA16 + varOpeIeps & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.16, ImporteP: " & varOpeIva
        End If
        If varOpeIva0 <> 0 Then
            If y <> "" Then
                y &= " Impuestos TrasladosP BaseP: " & varBaseIVA0 & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.00, ImporteP: " & varOpeIva0
            Else
                y = "Impuestos TrasladosP BaseP: " & varBaseIVA0 & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.00, ImporteP: " & varOpeIva0
            End If
        End If

        If y <> "" Then
            Col1 = New PdfPCell(New Phrase(y, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
        End If

        y = ""

        If varOpeIvaRet <> 0 Then
            y = "Impuestos RetencionesP ImpuestoP: IVA, ImporteP: " & varOpeIvaRet
        End If
        If varOpeIsr <> 0 Then
            If y <> "" Then
                y &= " Impuestos RetencionesP ImpuestoP: ISR, ImporteP: " & varOpeIsr
            Else
                y = "Impuestos RetencionesP ImpuestoP: ISR, ImporteP: " & varOpeIsr
            End If
        End If
        If varOpeIeps <> 0 Then
            If y <> "" Then
                y &= " Impuestos RetencionesP ImpuestoP: IEPS, ImporteP: " & varOpeIeps
            Else
                y = "Impuestos RetencionesP ImpuestoP: IEPS, ImporteP: " & varOpeIeps
            End If
        End If

        If y <> "" Then
            Col1 = New PdfPCell(New Phrase(y, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
        End If

        Col1 = New PdfPCell(New Phrase(" ", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Sello Digital del CFDI:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varsellocfdi, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Sello Digital del SAT:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varsellosat, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Cadena Original del Comprobante de Certificación digital del SAT:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varcadenaoriginal, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)


        Dim cadqr As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\cd\PARCIALIDADES\" & FolioUnido & ".jpg"

        Dim imagenURL2 As String = cadqr
        Dim imagenBMP2 As iTextSharp.text.Image

        Try
            imagenBMP2 = iTextSharp.text.Image.GetInstance(imagenURL2)
            imagenBMP2.ScaleToFit(100.0F, 100.0F)
            imagenBMP2.SpacingBefore = 20.0F
            imagenBMP2.SpacingAfter = 10.0F
            imagenBMP2.SetAbsolutePosition(25, 180)
        Catch ex As Exception

        End Try

        Table5.AddCell(imagenBMP2)
        Table5.AddCell(Table61)

        'Table5.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 13, pdfDoc.PageSize.Height - 560, pdfWrite.DirectContent)

        pdfDoc.Add(Table5)

#End Region

        varYlinea = 32

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Dim Table7 As PdfPTable = New PdfPTable(3)
        Table7.WidthPercentage = 95
        Dim widths7 As Single() = New Single() {4.5F, 1.0F, 8.0F}
        Table7.SetWidths(widths7)
        Table7.TotalWidth = pdfDoc.PageSize.Width - 55

        Font8.SetColor(192, 192, 192)

        Col1 = New PdfPCell(New Phrase("FACTURADO CON UN SISTEMA DELSSCOM", Font8))
        Col1.Border = 0
        Table7.AddCell(Col1)
        Table7.AddCell(CVacio)
        Col1 = New PdfPCell(New Phrase("ESTE DOCUMENTO ES UNA REPRESENTACION IMPRESA DE UN CFDI", Font8))
        Col1.Border = 0
        Col1.HorizontalAlignment = 2
        Table7.AddCell(Col1)

        Table7.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 13, 32, pdfWrite.DirectContent)

        pdfDoc.Close()

        ProgressBar1.Value = 85
        lbl_proceso.Text = "Abriendo PDF ..."
        My.Application.DoEvents()
        If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Process.Start(root_name_recibo)
        End If

        Try
            If MsgBox("¿Desea enviar el Archivo Via E-Mail?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim nombreCFD As String = FolioUnido & ".xml"
                Dim xmla As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD
                ProgressBar1.Value = 90
                lbl_proceso.Text = "Enviando E-Mail ..."
                My.Application.DoEvents()
                envio_mail.Show()
                envio_mail.archivoadj = root_name_recibo
                envio_mail.archivoadj2 = xmla
                envio_mail.txtasunto.Text = FolioUnido
                envio_mail.txtpara.Text = email
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btn_reenvio_Click(sender As Object, e As EventArgs) Handles btn_reenvio.Click
        Dim newcarpeta As String = Replace(cbo_emisor.Text, Chr(34), "").ToString
        Dim FolioUnido As String = "P" & cboFolioPar.Text
        Dim root_name_recibo As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\PARCIALIDADES\" & FolioUnido & ".pdf"
        Dim nombreCFD As String = FolioUnido & ".xml"
        Dim xmla As String = "C:\DelsscomFarmacias\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD
        ProgressBar1.Value = 90
        lbl_proceso.Text = "Enviando E-Mail ..."
        My.Application.DoEvents()
        envio_mail.Show()
        envio_mail.archivoadj = root_name_recibo
        envio_mail.archivoadj2 = xmla
        envio_mail.txtasunto.Text = FolioUnido
        envio_mail.txtpara.Text = email
    End Sub

    Private Sub Cmb_RazonS_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_RazonS.SelectedValueChanged
        On Error GoTo puerta
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from Clientes where RazonSocial = '" & Cmb_RazonS.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        txtCliRegFis.Text = dr("Regfis").ToString
                        txtCPCLiente.Text = dr("CP").ToString
                    Next
                End If
                cnn.Close()
            End If
        End With
puerta:
    End Sub

    Private Sub Cmb_RFC_SelectedValueChanged(sender As Object, e As EventArgs) Handles Cmb_RFC.SelectedValueChanged
        On Error GoTo puerta
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim odata As New ToolKitSQL.myssql
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from Clientes where RFC = '" & Cmb_RFC.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        txtCliRegFis.Text = dr("Regfis").ToString
                        txtCPCLiente.Text = dr("CP").ToString
                    Next
                End If
                cnn.Close()
            End If
        End With
puerta:
    End Sub

    Private Sub GridParcialidades_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles GridParcialidades.RowsRemoved
        var1 -= 1
        If GridParcialidades.Rows.Count > 0 Then
            txtMontoPar.Text = 0
            For i = 0 To GridParcialidades.RowCount - 2
                txtMontoPar.Text = CDec(txtMontoPar.Text) + CDec(GridParcialidades.Rows(i).Cells(2).Value)
            Next
        Else
            txtMontoPar.Text = 0
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim FolioUnido As String = ""
        FolioUnido = "P" & cboFolioPar.Text

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

        'cancelaporte(uidcancel, refccancel, cboFolio.Text, "CP" & cboFolio.Text, cbo_emisor.Text, str, txtUUIDCanelacion.Text)
        cancelapar(uidcancel, refccancel, cboFolioPar.Text, FolioUnido, cbo_emisor.Text, cboFolioPar.SelectedValue, str, txtUUIDCanelacion.Text)

        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click

        If File.Exists("C:\2022\demo3.pdf") Then
            File.Delete("C:\2022\demo3.pdf")
        End If

        Dim varcalleemi As String = ""
        Dim varcoloniaemi As String = ""
        Dim varaclmunemi As String = ""
        Dim varentidadaemi As String = ""
        Dim varregimenemi As String = ""
        Dim varcallecli As String = ""
        Dim varcoloniacli As String = ""
        Dim varaclmuncli As String = ""
        Dim varentidadacli As String = ""
        Dim varregimencli As String = ""
        Dim varserie As String = ""
        Dim varfolio As String = ""
        Dim varfoliounido As String = ""
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
        Dim varnumletra As String = "" 'convLetras(CDbl(Text_TOTAL.Text))
        Dim varleyenda As String = ""
        Dim varsellocfdi As String = ""
        Dim varsellosat As String = ""
        Dim varcadenaoriginal As String = ""
        Dim varmonto As String = ""
        Dim varfechapago As String = ""
        Dim varnumoperacion As String = ""
        Dim varmonedap As String = ""

        Dim varBaseIVA16 As String = ""
        Dim varBaseIVA0 As String = ""

        Dim varNumCta As String = ""
        Dim varNumCtaCliente As String = ""
        Dim varCtaRFCCli As String = ""
        Dim varCtaRFCEmi As String = ""
        Dim varBanco As String = ""
        Dim varBancoEmi As String = ""

        Dim banderaieps As Integer = 0

        Dim ieps160 As Decimal = 0 : Dim ieps53 As Decimal = 0 : Dim ieps5 As Decimal = 0
        Dim ieps304 As Decimal = 0 : Dim ieps3 As Decimal = 0 : Dim ieps265 As Decimal = 0
        Dim ieps25 As Decimal = 0 : Dim ieps09 As Decimal = 0 : Dim ieps08 As Decimal = 0
        Dim ieps07 As Decimal = 0 : Dim ieps06 As Decimal = 0 : Dim ieps03 As Decimal = 0

        Dim cuantosieps(20) As String
        For xd = 0 To 19
            cuantosieps(xd) = ""
        Next

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select RFS.ClaveRegFis, RFS.Descripcion from DatosNegocio DN, RegimenFiscalSat RFS where RFS.ClaveRegFis = DN.Em_RFiscal and DN.Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "'"
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    varregimenemi = dr("ClaveRegFis").ToString & " " & dr("Descripcion").ToString
                Else
                    varregimenemi = ""
                End If
                cnn.Close()
            End If
        End With

        Dim sSQL1 As String = ""
        sSQL1 = "Select * from ParcialidadesMulti where FolioPar=" & cboFolioPar.Text & ""
        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL1, sinfo) Then
                    varnomid = dr("Id").ToString
                    varfolio = dr("FolioPar").ToString
                    varfoliounido = dr("FolioUnido").ToString
                    varfechaemision = dr("Fecha").ToString
                    varfechacertifi = dr("FechaTimbrado").ToString
                    varcertifsat = dr("NoCertSat").ToString
                    varcertifemi = dr("NoCert").ToString
                    varuuid = dr("UUID").ToString
                    varusocfdi = dr("CliUsoCFDI").ToString
                    varmetodopago = "PPD Pago en parcialidades o diferido"
                    varformapago = dr("FormaPago").ToString
                    varleyenda = dr("Comentario").ToString
                    varsellosat = dr("SelloSat").ToString
                    varsellocfdi = dr("SelloCFD").ToString
                    varcadenaoriginal = dr("CadenaOriginal").ToString
                    varmonto = dr("Monto").ToString
                    varfechapago = dr("FechaPago").ToString
                    varnumoperacion = dr("NumOperacion").ToString
                    varmonedap = dr("MonedaP").ToString

                    varNumCta = dr("NumCta").ToString
                    varNumCtaCliente = dr("NumCtaCliente").ToString
                    varCtaRFCCli = dr("CtaRFCCli").ToString
                    varCtaRFCEmi = dr("CtaRFCEmi").ToString
                    varBanco = dr("Banco").ToString
                    varBancoEmi = dr("BancoEmi").ToString

                    varBaseIVA16 = dr("BaseIVA16").ToString
                    varBaseIVA0 = dr("BaseIVA0").ToString

                End If
                cnn.Close()
            End If
        End With

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from DatosNegocio where Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "'", sinfo) Then
                    If Trim(dr("Em_calle").ToString) <> "" Then
                        varcalleemi = "Calle: " & Trim(dr("Em_calle").ToString)
                    End If
                    If Trim(dr("Em_NumExterior").ToString) <> "" Then
                        varcalleemi = varcalleemi & " Num. Ext.: " & Trim(dr("Em_NumExterior").ToString)
                    End If
                    If Trim(dr("Em_NumInterior").ToString) <> "" Then
                        varcalleemi = varcalleemi & " Num. Int.: " & Trim(dr("Em_NumInterior").ToString)
                    End If
                    If Trim(dr("Em_colonia").ToString) <> "" Then
                        varcoloniaemi = "Colonia: " & Trim(dr("Em_colonia").ToString)
                    End If
                    If Trim(dr("Em_Municipio").ToString) <> "" Then
                        varaclmunemi = "Alc./Mun.: " & Trim(dr("Em_Municipio").ToString)
                    End If
                    If Trim(dr("Em_Estado").ToString) <> "" Then
                        varentidadaemi = "Entidad Federativa: " & Trim(dr("Em_Estado").ToString)
                    End If
                End If
                cnn.Close()
            End If
        End With

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from Clientes where RazonSocial = '" & Trim(Cmb_RazonS.Text) & "'", sinfo) Then
                    If Trim(dr("Calle").ToString) <> "" Then
                        varcallecli = "Calle: " & Trim(dr("Calle").ToString)
                    End If
                    If Trim(dr("CNumberExt").ToString) <> "" Then
                        varcallecli = varcallecli & " Num. Ext.: " & Trim(dr("CNumberExt").ToString)
                    End If
                    If Trim(dr("CNumberInt").ToString) <> "" Then
                        varcallecli = varcallecli & " Num. Int.: " & Trim(dr("CNumberInt").ToString)
                    End If
                    If Trim(dr("Colonia").ToString) <> "" Then
                        varcoloniacli = "Colonia: " & Trim(dr("Colonia").ToString)
                    End If
                    If Trim(dr("Delegacion").ToString) <> "" Then
                        varaclmuncli = "Alc./Mun.: " & Trim(dr("Delegacion").ToString)
                    End If
                    If Trim(dr("CP").ToString) <> "" Then
                        varaclmuncli = varaclmuncli & " C.P.: " & Trim(dr("CP").ToString)
                    End If
                    If Trim(dr("Entidad").ToString) <> "" Then
                        varentidadacli = "Entidad Federativa: " & Trim(dr("Entidad").ToString)
                    End If
                End If
                cnn.Close()
            End If
        End With

        Dim sinfo2 As String = ""
        Dim dt2 As New DataTable
        Dim dr2 As DataRow
        Dim odata2 As New ToolKitSQL.myssql
        Dim isrporc As String = "0"
        Dim ivaretporc As String = "0"

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
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, "select * from UsoComproCFDISat where ClaveUsoCFDI = '" & varusocfdi & "'", sinfo) Then
                    varusocfdi = dr("ClaveUsoCFDI").ToString & " " & dr("Descripcion").ToString
                End If
                cnn.Close()
            End If
        End With

        If IsNumeric(varfolio) = False Then
            MsgBox("Debe seleccionar un folio")
            Exit Sub
        End If

        Dim pdfDoc As New Document(PageSize.A4, 15.0F, 15.0F, 30.0F, 30.0F)
        Dim pdfWrite As PdfWriter

        pdfWrite = PdfWriter.GetInstance(pdfDoc, New FileStream("C:\2022\demo3.pdf", FileMode.CreateNew))

        Dim Font8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL))
        Dim FontB8 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD))
        Dim FontB12 As New iTextSharp.text.Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD))
        Dim CVacio As PdfPCell = New PdfPCell(New Phrase(""))
        CVacio.Border = 0

        pdfDoc.Open()

        If Trim(txtSerie.Text) <> "" Then
            varserie = Trim(txtSerie.Text)
        End If

        If Trim(txtCP.Text) <> "" Then
            varaclmunemi = varaclmunemi & " C.P.: " & Trim(txtCP.Text)
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

        Dim widths As Single() = New Single() {12.0F, 1.0F, 1.0F, 5.0F, 0.5F}

        Table1.SetWidths(widths)

#Region "Tabla.Encabezado"
        Dim imagenURL As String = "C:\DelsscomFarmacias\Dls.jpg"
        Dim imagenBMP As iTextSharp.text.Image
        imagenBMP = iTextSharp.text.Image.GetInstance(imagenURL)
        imagenBMP.ScaleToFit(150.0F, 90.0F)
        imagenBMP.SpacingBefore = 20.0F
        imagenBMP.SpacingAfter = 10.0F
        imagenBMP.SetAbsolutePosition(410, 754)
        pdfDoc.Add(imagenBMP)

        Col1 = New PdfPCell(New Phrase(cbo_emisor.Text, FontB8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(cbo_emisor.Text) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(cbo_emisor.Text))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(Cmb_RFC.Text, FontB8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(Cmb_RFC.Text) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(Cmb_RFC.Text))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varcalleemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varcalleemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcalleemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varcoloniaemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varcoloniaemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcoloniaemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varaclmunemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)

        If Len(varaclmunemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varaclmunemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(varentidadaemi, Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Table1.AddCell(CVacio)
        Table1.AddCell(CVacio)
        Col4 = New PdfPCell(New Phrase("PARCIALIDAD", FontB8)) ' Col4 = New PdfPCell(New Phrase(Cmb_TipoFact.Text, FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 2
        Table1.AddCell(Col4)
        '        Table1.AddCell(CVacio)

        If Len(varentidadaemi) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varentidadaemi))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Lugar de Expedición: " & Trim(txtCP.Text), Font8))
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

        If Len("Lugar de Expedición: " & Trim(txtCP.Text)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len("Lugar de Expedición: " & Trim(txtCP.Text)))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Régimen Fiscal Emisor: " & Trim(varregimenemi), Font8))
        Col1.Border = 0
        Col1.Colspan = 3
        Table1.AddCell(Col1)
        Col4 = New PdfPCell(New Phrase("", FontB8))
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
            varYlinea = varYlinea - damevalorlinea(Len("Fecha de Emisión: " & varfechaemision))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(Trim(Cmb_RazonS.Text), FontB8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)
        Col4 = New PdfPCell(New Phrase("Fecha de Certificación: " & varfechacertifi, FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 4
        Table1.AddCell(Col4)
        'Table1.AddCell(CVacio)

        If Len(Trim(Cmb_RazonS.Text)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(Trim(Cmb_RazonS.Text)))
        Else
            varYlinea = varYlinea - 12
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
            varYlinea = varYlinea - damevalorlinea(Len(Cmb_RFC.Text))
        Else
            varYlinea = varYlinea - 12
        End If

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
            varYlinea = varYlinea - damevalorlinea(Len(varcallecli))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase(Trim(varcoloniacli), Font8))
        Col1.Border = 0
        Table1.AddCell(Col1)
        Col4 = New PdfPCell(New Phrase("Tipo de Comprobante: P PAGO", FontB8))
        Col4.Border = 0
        Col4.HorizontalAlignment = 2
        Col4.Colspan = 4
        Table1.AddCell(Col4)
        'Table1.AddCell(CVacio)

        If Len(varcoloniacli) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len(varcoloniacli))
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
            varYlinea = varYlinea - damevalorlinea(Len(varaclmuncli))
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
            varYlinea = varYlinea - damevalorlinea(Len(varentidadacli))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Régimen Fiscal Cliente: " & Trim(varregimenemi), Font8))
        Col1.Border = 0
        Col1.Colspan = 5
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        If Len("Regimen Fiscal Cliente: " & Trim(varregimenemi)) > 71 Then
            varYlinea = varYlinea - 12 'damevalorlinea(Len("Regimen Fiscal Cliente: " & Trim(varregimenemi)))
        Else
            varYlinea = varYlinea - 12
        End If

        Col1 = New PdfPCell(New Phrase("Uso de CFDI: " & Trim(varusocfdi), Font8))
        Col1.Border = 0
        Col1.Colspan = 5
        Table1.AddCell(Col1)
        'Table1.AddCell(CVacio)

        If Len("Uso de CFDI: " & Trim(varusocfdi)) > 71 Then
            varYlinea = varYlinea - damevalorlinea(Len("Uso de CFDI: " & Trim(varusocfdi)))
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
                varYlinea = varYlinea - damevalorlinea(Len("Tipo Relacion: " & Trim(vartiporelacion)))
            Else
                varYlinea = varYlinea - 12
            End If
        End If

        pdfDoc.Add(Table1)

#End Region

        'PintarCuadrado(0.7, 410, 740, 530, 820, pdfWrite, pdfDoc)
        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)
        'pdfDoc.Add(New Paragraph("."))

#Region "Tabla3-Cabecera"

        Dim Table3 As PdfPTable = New PdfPTable(9)
        Dim widths3 As Single() = New Single() {1.0F, 3.0F, 3.0F, 2.0F, 8.0F, 3.0F, 3.0F, 3.0F, 1.0F}
        Table3.WidthPercentage = 95
        Table3.SetWidths(widths3)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("CLAVE SAT", FontB8))
        Col2.Border = 0
        Table3.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("U. VENTA", FontB8))
        Col3.Border = 0
        Table3.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("CANT.", FontB8))
        Col4.Border = 0
        Table3.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("DESCRIPCIÓN", FontB8))
        Col5.Border = 0
        Table3.AddCell(Col5)
        Col6 = New PdfPCell(New Phrase("P.UNITARIO", FontB8))
        Col6.Border = 0
        Col6.HorizontalAlignment = 1
        Table3.AddCell(Col6)
        Col7 = New PdfPCell(New Phrase("IMPORTE", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Col7 = New PdfPCell(New Phrase("OBJETO IMPUESTO", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 20

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("84111506", FontB8))
        Col2.Border = 0
        Table3.AddCell(Col2)
        Col3 = New PdfPCell(New Phrase("ACT", FontB8))
        Col3.Border = 0
        Table3.AddCell(Col3)
        Col4 = New PdfPCell(New Phrase("1", FontB8))
        Col4.Border = 0
        Table3.AddCell(Col4)
        Col5 = New PdfPCell(New Phrase("PAGO", FontB8))
        Col5.Border = 0
        Table3.AddCell(Col5)
        Col6 = New PdfPCell(New Phrase("0", FontB8))
        Col6.Border = 0
        Col6.HorizontalAlignment = 1
        Table3.AddCell(Col6)
        Col7 = New PdfPCell(New Phrase("0", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Col7 = New PdfPCell(New Phrase("02", FontB8))
        Col7.Border = 0
        Col7.HorizontalAlignment = 1
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("MONEDA: XXX Los códigos asignados para las transacciones en que intervenga ninguna moneda", FontB8))
        Col2.Border = 0
        Col2.Colspan = 5
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("SUBTOTAL: $0.00", FontB8))
        Col7.Border = 0
        Col7.Colspan = 2
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("", FontB8))
        Col2.Border = 0
        Col2.Colspan = 5
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("TOTAL: $0.00", FontB8))
        Col7.Border = 0
        Col7.Colspan = 2
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        varYlinea = varYlinea - 12

        Col1 = New PdfPCell(New Phrase("", FontB8))
        Col1.Border = 0
        Table3.AddCell(Col1)
        Col2 = New PdfPCell(New Phrase("", FontB8))
        Col2.Border = 0
        Col2.Colspan = 4
        Table3.AddCell(Col2)
        Col7 = New PdfPCell(New Phrase("MONTO TOTAL PAGADO: $" & varmonto, FontB8))
        Col7.Border = 0
        Col7.Colspan = 3
        Col7.HorizontalAlignment = 2
        Table3.AddCell(Col7)
        Table3.AddCell(CVacio)

        pdfDoc.Add(Table3)

#End Region

        varYlinea = varYlinea - 12

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Dim varOpeIva As Double = 0
        Dim varOpeIva0 As Double = 0
        Dim varOpeIvaRet As Double = 0
        Dim varOpeIsr As Double = 0
        Dim varOpeIeps As Double = 0

#Region "Tabla4-detalle"

        dt = New DataTable
        oData = New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from ParcialidadesDetalleMulti where IdParcialidades = " & varnomid, sinfo) Then

                    For Each dr In dt.Rows

                        varOpeIva += dr("OpeIva").ToString
                        varOpeIva0 += dr("OpeIva0").ToString
                        varOpeIvaRet += dr("OpeIvaRet").ToString
                        varOpeIsr += dr("OpeIsr").ToString
                        varOpeIeps += dr("OpeIeps").ToString

                        Dim Table4 As PdfPTable = New PdfPTable(5)
                        Dim widths4 As Single() = New Single() {4.0F, 5.0F, 0.5F, 4.0F, 5.0F}
                        Table4.WidthPercentage = 95
                        Table4.SetWidths(widths4)

                        Col1 = New PdfPCell(New Phrase("INFORMACIÓN DEL PAGO", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 5
                        Table4.AddCell(Col1)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("FORMA DE PAGO: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase(varformapago, Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("FECHA DE PAGO", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varfechapago, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("NÚMERO DE OPERACIÓN: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase(varnumoperacion, Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONEDA DE PAGO:", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varmonedap, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("MÉTODO DE PAGO: ", FontB8))
                        Col1.Border = 0
                        Table4.AddCell(Col1)
                        Col2 = New PdfPCell(New Phrase("PUE EN UNA SOLA EXHIBICIÓN", Font8))
                        Col2.Border = 0
                        Table4.AddCell(Col2)
                        Table4.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONTO:", FontB8))
                        Col3.Border = 0
                        Table4.AddCell(Col3)
                        Col4 = New PdfPCell(New Phrase(varmonto, Font8))
                        Col4.Border = 0
                        Table4.AddCell(Col4)

                        varYlinea = varYlinea - 12

                        If varNumCta <> "" Or varNumCtaCliente <> "" Or varCtaRFCCli <> "" Or varCtaRFCEmi <> "" Or varBanco <> "" Or varBancoEmi <> "" Then

                            Col1 = New PdfPCell(New Phrase("DOCUMENTO RELACIONADO", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table4.AddCell(Col1)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("NÚMERO CTA CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varNumCtaCliente, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("NÚMERO CTA EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varNumCta, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("RFC BANCO CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varCtaRFCCli, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("RFC BANCO EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varCtaRFCEmi, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase("BANCO CLIENTE: ", FontB8))
                            Col1.Border = 0
                            Table4.AddCell(Col1)
                            Col2 = New PdfPCell(New Phrase(varBanco, Font8))
                            Col2.Border = 0
                            Table4.AddCell(Col2)
                            Table4.AddCell(CVacio)
                            Col3 = New PdfPCell(New Phrase("BANCO EMISOR:", FontB8))
                            Col3.Border = 0
                            Table4.AddCell(Col3)
                            Col4 = New PdfPCell(New Phrase(varBancoEmi, Font8))
                            Col4.Border = 0
                            Table4.AddCell(Col4)

                            varYlinea = varYlinea - 12

                        End If

                        pdfDoc.Add(Table4)

                        Dim Table41 As PdfPTable = New PdfPTable(5)
                        Dim widths41 As Single() = New Single() {4.0F, 5.0F, 0.5F, 4.0F, 5.0F}
                        Table41.WidthPercentage = 95
                        Table41.SetWidths(widths41)

                        Col1 = New PdfPCell(New Phrase("DOCUMENTO RELACIONADO", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 5
                        Table41.AddCell(Col1)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("ID DOCUMENTO: " & dr("UUID").ToString, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MONEDA DEL DOC. RELACIONADO: MXN PESO MEXICANO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("FOLIO: " & cboFolioPar.Text, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("MÉTODO DE PAGO DEL DOCUMENTO RELACIONADO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("SERIE: " & dr("Serie").ToString, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("PPD PAGO EN PARCIALIDADES O DIFERIDO", FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("NÚMERO PARCIALIDAD: " & varfolio, FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE DE SALDO ANTERIOR: " & dr("ImpSaldoAnt").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("OBJETO IMPUESTO: 02", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE PAGADO: " & dr("ImpPagado").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        Col1 = New PdfPCell(New Phrase("", FontB8))
                        Col1.Border = 0
                        Col1.Colspan = 2
                        Table41.AddCell(Col1)
                        Table41.AddCell(CVacio)
                        Col3 = New PdfPCell(New Phrase("IMPORTE DE SALDO INSOLUTO: " & dr("ImpSaldoIns").ToString, FontB8))
                        Col3.Border = 0
                        Col3.Colspan = 2
                        Table41.AddCell(Col3)

                        varYlinea = varYlinea - 12

                        If dr("OpeIva").ToString <> 0 Or dr("OpeIva0").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("Impuestos TrasladosDR", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIva").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("BaseIVA16").ToString & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.16, ImporteDR: " & dr("OpeIva").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIva0").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("OpeIva0").ToString & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.00, ImporteDR 0.00 ", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If

                        If dr("OpeIvaRet").ToString <> 0 Or dr("OpeIsr").ToString <> 0 Or dr("OpeIeps").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("Impuestos RetencionesDR", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIvaRet").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("BaseIVARet").ToString & ", ImpuestoDR: IVA, TipoFactorDR: Tasa, Tasa o CuotaDR: " & dr("IvaRetPorc").ToString & ", ImporteDR: " & dr("OpeIvaRet").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("OpeIsr").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("BaseISR").ToString & ", ImpuestoDR: ISR, TipoFactorDR: Tasa, Tasa o CuotaDR: " & dr("IsrPorc").ToString & ", ImporteDR: " & dr("OpeIsr").ToString, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps160").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps160").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 1.60, ImporteDR: " & CDbl(dr("Baseieps160").ToString) * 1.6, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps53").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps53").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.53, ImporteDR: " & CDbl(dr("Baseieps53").ToString) * 0.53, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps5").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps5").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.5, ImporteDR: " & CDbl(dr("Baseieps5").ToString) * 0.5, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps3").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps3").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.3, ImporteDR: " & CDbl(dr("Baseieps3").ToString) * 0.3, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps265").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps265").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.265, ImporteDR: " & CDbl(dr("Baseieps265").ToString) * 0.265, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps25").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps25").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.25, ImporteDR: " & CDbl(dr("Baseieps25").ToString) * 0.25, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps09").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps09").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.09, ImporteDR: " & CDbl(dr("Baseieps09").ToString) * 0.09, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps08").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps08").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.08, ImporteDR: " & CDbl(dr("Baseieps08").ToString) * 0.08, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps07").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps07").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.07, ImporteDR: " & CDbl(dr("Baseieps07").ToString) * 0.07, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps06").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps06").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.06, ImporteDR: " & CDbl(dr("Baseieps06").ToString) * 0.06, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If
                        If dr("Baseieps03").ToString <> 0 Then
                            Col1 = New PdfPCell(New Phrase("BaseDR: " & dr("Baseieps03").ToString & ", ImpuestoDR: IEPS, TipoFactorDR: Tasa, Tasa o CuotaDR: 0.03, ImporteDR: " & CDbl(dr("Baseieps03").ToString) * 0.03, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)
                            varYlinea = varYlinea - 12
                        End If

                        If Trim(varleyenda) <> "" Then
                            Col1 = New PdfPCell(New Phrase("COMENTARIO: ", FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)

                            varYlinea = varYlinea - 12

                            Col1 = New PdfPCell(New Phrase(varleyenda, FontB8))
                            Col1.Border = 0
                            Col1.Colspan = 5
                            Table41.AddCell(Col1)

                            varYlinea = varYlinea - 12

                        End If

                        pdfDoc.Add(Table41)

                        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

                    Next

                End If
                cnn.Close()
            End If
        End With


#End Region

        varYlinea = 295

        'PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        For iFila = 1 To 40
            pdfDoc.Add(New Paragraph(" "))
            ILine = pdfWrite.GetVerticalPosition(True)
            If ILine < 242 Then ' If ILine <296 Then
                Exit For
            End If
        Next

#Region "tabla5-Final"

        Dim Table5 As PdfPTable = New PdfPTable(2)
        Dim widths5 As Single() = New Single() {3.0F, 14.0F}
        Dim Table61 As PdfPTable = New PdfPTable(1)
        Dim widths61 As Single() = New Single() {14.0F}

        Table5.WidthPercentage = 95
        Table5.SetWidths(widths5)

        Table61.SetWidths(widths61)

        Table5.DefaultCell.BorderWidth = 1

        'Table5.DefaultCell.Border = 0

        'Table5.TotalWidth = pdfDoc.PageSize.Width - 40

        Dim y As String = ""

        If varOpeIva <> 0 Then
            y = "Impuestos TrasladosP BaseP: " & varBaseIVA16 & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.16, ImporteP: " & varOpeIva
        End If
        If varOpeIva0 <> 0 Then
            If y <> "" Then
                y &= " Impuestos TrasladosP BaseP: " & varBaseIVA0 & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.00, ImporteP: " & varOpeIva0
            Else
                y = "Impuestos TrasladosP BaseP: " & varBaseIVA0 & ", ImpuestoP: IVA, TipoFactorP: Tasa, Tasa o CuotaP: 0.00, ImporteP: " & varOpeIva0
            End If
        End If

        If y <> "" Then
            Col1 = New PdfPCell(New Phrase(y, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
        End If

        y = ""

        If varOpeIvaRet <> 0 Then
            y = "Impuestos RetencionesP ImpuestoP: IVA, ImporteP: " & varOpeIvaRet
        End If
        If varOpeIsr <> 0 Then
            If y <> "" Then
                y &= " Impuestos RetencionesP ImpuestoP: ISR, ImporteP: " & varOpeIsr
            Else
                y = "Impuestos RetencionesP ImpuestoP: ISR, ImporteP: " & varOpeIsr
            End If
        End If
        If varOpeIeps <> 0 Then
            If y <> "" Then
                y &= " Impuestos RetencionesP ImpuestoP: IEPS, ImporteP: " & varOpeIeps
            Else
                y = "Impuestos RetencionesP ImpuestoP: IEPS, ImporteP: " & varOpeIeps
            End If
        End If

        If y <> "" Then
            Col1 = New PdfPCell(New Phrase(y, FontB8))
            Col1.Border = 0
            Table61.AddCell(Col1)
        End If

        Col1 = New PdfPCell(New Phrase(" ", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Sello Digital del CFDI:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varsellocfdi, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Sello Digital del SAT:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varsellosat, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase("Cadena Original del Comprobante de Certificación digital del SAT:", FontB8))
        Col1.Border = 0
        Table61.AddCell(Col1)

        Col1 = New PdfPCell(New Phrase(varcadenaoriginal, Font8))
        Col1.Border = 0
        Table61.AddCell(Col1)


        Dim imagenURL2 As String = "C:\DelsscomFarmacias\ARCHIVOSDL1\imagenes\PP12-1549.jpg"
        Dim imagenBMP2 As iTextSharp.text.Image
        imagenBMP2 = iTextSharp.text.Image.GetInstance(imagenURL2)
        imagenBMP2.ScaleToFit(100.0F, 100.0F)
        imagenBMP2.SpacingBefore = 20.0F
        imagenBMP2.SpacingAfter = 10.0F
        imagenBMP2.SetAbsolutePosition(25, 180)

        Table5.AddCell(imagenBMP2)
        Table5.AddCell(Table61)

        'Table5.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 13, pdfDoc.PageSize.Height - 560, pdfWrite.DirectContent)

        pdfDoc.Add(Table5)

#End Region

        varYlinea = 32

        PintarLinea(1, 30, varYlinea, 565, varYlinea, pdfWrite)

        Dim Table7 As PdfPTable = New PdfPTable(3)
        Table7.WidthPercentage = 95
        Dim widths7 As Single() = New Single() {4.5F, 1.0F, 8.0F}
        Table7.SetWidths(widths7)
        Table7.TotalWidth = pdfDoc.PageSize.Width - 55

        Font8.SetColor(192, 192, 192)

        Col1 = New PdfPCell(New Phrase("FACTURADO CON UN SISTEMA DELSSCOM", Font8))
        Col1.Border = 0
        Table7.AddCell(Col1)
        Table7.AddCell(CVacio)
        Col1 = New PdfPCell(New Phrase("ESTE DOCUMENTO ES UNA REPRESENTACION IMPRESA DE UN CFDI", Font8))
        Col1.Border = 0
        Col1.HorizontalAlignment = 2
        Table7.AddCell(Col1)

        Table7.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 13, 32, pdfWrite.DirectContent)

        pdfDoc.Close()

        Process.Start("C:\2022\demo3.pdf")

    End Sub

    Function damevalorlinea(ByVal cantcaracteres As Long) As Integer
        Dim ValorDecimal As Double = 0
        Dim ParteEntera As Long = 0
        Dim ParteDecimal As Double = 0
        ValorDecimal = cantcaracteres / 71
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
                          ByVal pdfWrite As iTextSharp.text.pdf.PdfWriter)
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
                'logr = Mid(dr("emi_logo").ToString, 1, Len(dr("emi_logo").ToString) - 4) & "1" & Mid(dr("emi_logo").ToString, Len(dr("emi_logo").ToString) - 3, 4)
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
End Class