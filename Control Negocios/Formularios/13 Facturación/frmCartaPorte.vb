Imports CrystalDecisions.Shared
Imports System.IO
Imports MySql.Data
Public Class frmCartaPorte

    Dim varfoliocarta As Integer = 0
    Dim foliocarta As Integer = 0
    Private Sub frmCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llena_productos_SAT()
        llena_unidades_SAT()
        llena_Material_Peligroso()
        llena_Embalaje()
        llenarCboregimen()
        Btt_Nuevo.PerformClick()
    End Sub

    Private Sub llena_productos_SAT()
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

    Private Sub llena_unidades_SAT()
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

    Private Sub btnelimina_Click(sender As Object, e As EventArgs) Handles btnelimina.Click
        Me.Close()
    End Sub

    Private Sub cbo_emisor_DropDown(sender As Object, e As EventArgs) Handles cbo_emisor.DropDown
        cbo_emisor.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Em_RazonSocial from DatosNegocio", sinfo) Then
                    For Each dr In dt.Rows
                        cbo_emisor.Items.Add(dr("Em_RazonSocial").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cbo_rfc_emisor_DropDown(sender As Object, e As EventArgs) Handles cbo_rfc_emisor.DropDown

        cbo_rfc_emisor.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection=New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Em_rfc from DatosNegocio", sinfo) Then
                    For Each dr In dt.Rows
                        cbo_rfc_emisor.Items.Add(dr("Em_rfc").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With

    End Sub

    Private Sub Btt_Nuevo_Click(sender As Object, e As EventArgs) Handles Btt_Nuevo.Click

        lbl_proceso.Visible = False
        ProgressBar1.Visible = False

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDt(cnn, dt, "select * from CartaPorte where UUID is null or UUID = ''", sinfo) Then
                For Each dr In dt.Rows
                    odata.runSp(cnn, "Delete from CartaPorteDet where IdCarta = " & dr("Id").ToString & "", sinfo)
                Next
                cnn.Close()
            End If
        End If

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from CartaPorte where UUID is null", sinfo)
            cnn.Close()
        End If

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from CartaPorte where UUID = ''", sinfo)
            cnn.Close()
        End If

        cboFolio.Text = ""
        cbo_emisor.Text = ""
        cbo_rfc_emisor.Text = ""
        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""

        cbo_emisor.Text = ""
        cbo_rfc_emisor.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""
        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        chkInter.Checked = False
        GroupBox11.Visible = False

        txtAseguradora.Text = ""
        txtNumPoliza.Text = ""
        txtModeloAño.Text = ""
        txtNumPermisoSCT.Text = ""
        txtPlaca.Text = ""
        cboConfigV.Text = ""
        cboPermisoSCT.Text = ""
        dgProductos.Rows.Clear()
        cboFolio.Text = ""

        txtTransDesc.Text = ""
        txtTransImporte.Text = "0"
        cboTransClaveSat.Text = ""
        txtTransUniMed.Text = ""

        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow

        If odata1.dbOpen(cnn1, sTarget, sinfo1) Then
            If odata1.getDt(cnn1, dt1, "select * from PorteProducto", "") Then
                For Each dr1 In dt1.Rows
                    txtTransDesc.Text = dr1("Descripcion").ToString
                    txtTransImporte.Text = dr1("ValorUnitario").ToString
                    cboTransClaveSat.Text = dr1("NomClaveSat").ToString
                    txtTransUniMed.Text = dr1("UniMedSat").ToString
                Next
                cnn1.Close()
            End If
        End If

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
        cboOrigLoc.Text = ""

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
        cboDestinoLoc.Text = ""

        cboTipoFigura.Text = ""
        cboOpeNombre.Text = ""
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""

        cboDescripcion.Text = ""
        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = ""
        txtValorMerc.Text = ""
        txtPesoKG.Text = ""
        txtTotalPeso.Text = ""
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
        txtNumPed1.Text = ""
        txtNumPed2.Text = ""
        txtNumPed3.Text = ""
        txtNumPed4.Text = ""

        varfoliocarta = 0
        foliocarta = 0

        dgProductos.Rows.Clear()

        DataGridView1.Rows.Clear()
        txtPlacaTipoRemolque.Text = ""
        cboTipoRemolque.Text = ""

        chkMatPeg.Checked = False
        cboMatPeligroso.Text = ""
        cboEmbalaje.Text = ""

        txtAseguradoraMatPel.Text = ""
        txtNumPolizaMatPel.Text = ""

        txtCPCliente.Text = ""
        cbo_regimen.SelectedIndex = -1
        cbo_regimen.Text = ""

        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False

    End Sub

    Private Sub cboFolio_DropDown(sender As Object, e As EventArgs) Handles cboFolio.DropDown
        cboFolio.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select FolioCarta from CartaPorte order by FolioCarta", sinfo) Then
                    For Each dr In dt.Rows
                        cboFolio.Items.Add(dr("FolioCarta").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cbo_emisor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_emisor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select Em_rfc, Em_CP, Em_RFiscal from DatosNegocio where Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            cbo_rfc_emisor.Text = dr("Em_rfc").ToString
                            txtCP.Text = dr("Em_CP").ToString
                            txtRegFisEmi.Text = dr("Em_RFiscal").ToString
                        Next
                    Else
                        cbo_rfc_emisor.Text = ""
                        txtCP.Text = ""
                        txtRegFisEmi.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cbo_emisor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_emisor.SelectedValueChanged
        On Error GoTo puerta

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Em_rfc, Em_CP, Em_RFiscal from DatosNegocio where Em_RazonSocial = '" & Trim(cbo_emisor.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        cbo_rfc_emisor.Text = dr("Em_rfc").ToString
                        txtCP.Text = dr("Em_CP").ToString
                        txtRegFisEmi.Text = dr("Em_RFiscal").ToString
                    Next
                Else
                    cbo_rfc_emisor.Text = ""
                    txtCP.Text = ""
                    txtRegFisEmi.Text = ""
                End If
                cnn.Close()
            End If
        End With

        Exit Sub

puerta:

        cnn.Close()
        cbo_rfc_emisor.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""
    End Sub

    Private Sub cbo_rfc_emisor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbo_rfc_emisor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select Em_RazonSocial, Em_CP, Em_RFiscal from DatosNegocio where Em_rfc = '" & Trim(cbo_rfc_emisor.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            cbo_emisor.Text = dr("Em_RazonSocial").ToString
                            txtCP.Text = dr("Em_CP").ToString
                            txtRegFisEmi.Text = dr("Em_RFiscal").ToString
                        Next
                    Else
                        cbo_emisor.Text = ""
                        txtCP.Text = ""
                        txtRegFisEmi.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cbo_rfc_emisor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_rfc_emisor.SelectedValueChanged
        On Error GoTo puerta

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Em_RazonSocial, Em_CP, Em_RFiscal from DatosNegocio where Em_rfc = '" & Trim(cbo_rfc_emisor.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        cbo_emisor.Text = dr("Em_RazonSocial").ToString
                        txtCP.Text = dr("Em_CP").ToString
                        txtRegFisEmi.Text = dr("Em_RFiscal").ToString
                    Next
                Else
                    cbo_emisor.Text = ""
                    txtCP.Text = ""
                    txtRegFisEmi.Text = ""
                End If
                cnn.Close()
            End If
        End With

        Exit Sub

puerta:

        cnn.Close()
        cbo_emisor.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""
    End Sub

    Private Sub cboFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboFolio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then

            varfoliocarta = 0
            foliocarta = 0

            cboCliente.Text = ""
            cboClienteRFC.Text = ""
            txtCP.Text = ""
            txtRegFisEmi.Text = ""

            cbo_emisor.Text = ""
            cbo_rfc_emisor.Text = ""
            txtCP.Text = ""
            txtRegFisEmi.Text = ""
            cboCliente.Text = ""
            cboClienteRFC.Text = ""
            chkInter.Checked = False
            GroupBox11.Visible = False
            txtAseguradora.Text = ""
            txtNumPoliza.Text = ""
            txtModeloAño.Text = ""
            txtNumPermisoSCT.Text = ""
            txtPlaca.Text = ""
            cboConfigV.Text = ""
            cboPermisoSCT.Text = ""
            dgProductos.Rows.Clear()

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
            cboOrigLoc.Text = ""

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
            cboDestinoLoc.Text = ""

            cboTipoFigura.Text = ""
            cboOpeNombre.Text = ""
            txtOpeRFC.Text = ""
            txtOpeLicencia.Text = ""

            cboDescripcion.Text = ""
            cboUniMedSAT.Text = ""
            cboProdServSAT.Text = ""
            txtCantidad.Text = ""
            txtValorMerc.Text = ""
            txtPesoKG.Text = ""
            txtTotalPeso.Text = ""
            txtUUIDComE.Text = ""
            txtFraccAran.Text = ""
            txtNumPed1.Text = ""
            txtNumPed2.Text = ""
            txtNumPed3.Text = ""
            txtNumPed4.Text = ""

            txtTransDesc.Text = ""
            txtTransImporte.Text = ""
            txtTransUniMed.Text = ""
            cboTransClaveSat.Text = ""

            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select * from CartaPorte where FolioCarta = " & Trim(cboFolio.Text) & "", sinfo) Then
                        For Each dr In dt.Rows
                            cbo_emisor.Text = dr("EmiNombre").ToString
                            cbo_rfc_emisor.Text = dr("EmiRFC").ToString
                            varfoliocarta = dr("Id").ToString
                            foliocarta = cboFolio.Text

                            cboCliente.Text = dr("CliNombre").ToString
                            cboClienteRFC.Text = dr("CliRFC").ToString

                            Dim dt3 As New DataTable
                            Dim dr3 As DataRow
                            If .getDt(cnn, dt3, "select Regfis from Clientes where RFC = '" & dr("CliRFC").ToString & "'", sinfo) Then
                                For Each dr3 In dt3.Rows
                                    cbo_regimen.SelectedValue = dr3("Regfis").ToString
                                Next
                            End If

                            txtCP.Text = dr("EmiCP").ToString
                            txtRegFisEmi.Text = dr("EmiRegFis").ToString


                            If dr("Inter").ToString = "No" Then
                                chkInter.Checked = False
                                GroupBox11.Visible = False
                            Else
                                chkInter.Checked = True
                                GroupBox11.Visible = True
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
                            cboDestinoLoc.Text = dr("DesLocalidad").ToString

                            cboTipoFigura.Text = dr("FiguraTrasporte").ToString
                            cboOpeNombre.Text = dr("OpeNombre").ToString
                            txtOpeRFC.Text = dr("OpeRFC").ToString
                            txtOpeLicencia.Text = dr("OpeLic").ToString

                            txtTotalPeso.Text = dr("TotalPesoM").ToString

                            txtTransDesc.Text = dr("TransDes").ToString
                            txtTransImporte.Text = dr("TransImporte").ToString
                            txtTransUniMed.Text = dr("TransUniMedSat").ToString
                            cboTransClaveSat.Text = dameDesClaveSATM2(dr("TransClaveSat").ToString)

                            If dr("NumPed").ToString <> "" Then
                                txtNumPed1.Text = Mid(dr("NumPed").ToString, 1, 2)
                                txtNumPed2.Text = Mid(dr("NumPed").ToString, 5, 2)
                                txtNumPed3.Text = Mid(dr("NumPed").ToString, 7, 4)
                                txtNumPed4.Text = Mid(dr("NumPed").ToString, 11, 7)
                            Else
                                txtNumPed1.Text = ""
                                txtNumPed2.Text = ""
                                txtNumPed3.Text = ""
                                txtNumPed4.Text = ""
                            End If

                            Dim dt2 As New DataTable
                            Dim dr2 As DataRow
                            If .getDt(cnn, dt2, "select * from CartaPorteDet where IdCarta = " & dr("Id").ToString & " order by Id", sinfo) Then
                                For Each dr2 In dt2.Rows
                                    dgProductos.Rows.Add(dr2("Descripcion").ToString, dr2("UniMedSAT").ToString, dr2("ProdServSAT").ToString, dr2("Cantidad").ToString, dr2("ValorM").ToString, dr2("PesoKg").ToString, "", dr2("UUIDComE").ToString, dr2("FracArancelaria").ToString)
                                Next
                            End If
                        Next
                        If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            printRecibo()
                        End If
                    Else

                        varfoliocarta = 0
                        foliocarta = 0

                        cboCliente.Text = ""
                        cboClienteRFC.Text = ""
                        txtCP.Text = ""
                        txtRegFisEmi.Text = ""

                        cbo_emisor.Text = ""
                        cbo_rfc_emisor.Text = ""
                        txtCP.Text = ""
                        txtRegFisEmi.Text = ""
                        cboCliente.Text = ""
                        cboClienteRFC.Text = ""
                        chkInter.Checked = False
                        GroupBox11.Visible = False
                        txtAseguradora.Text = ""
                        txtNumPoliza.Text = ""
                        txtModeloAño.Text = ""
                        txtNumPermisoSCT.Text = ""
                        txtPlaca.Text = ""
                        cboConfigV.Text = ""
                        cboPermisoSCT.Text = ""
                        dgProductos.Rows.Clear()

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
                        cboDestinoLoc.Text = ""

                        cboTipoFigura.Text = ""
                        cboOpeNombre.Text = ""
                        txtOpeRFC.Text = ""
                        txtOpeLicencia.Text = ""

                        cboDescripcion.Text = ""
                        cboUniMedSAT.Text = ""
                        cboProdServSAT.Text = ""
                        txtCantidad.Text = ""
                        txtValorMerc.Text = ""
                        txtPesoKG.Text = ""
                        txtTotalPeso.Text = ""
                        txtUUIDComE.Text = ""
                        txtFraccAran.Text = ""
                        txtNumPed1.Text = ""
                        txtNumPed2.Text = ""
                        txtNumPed3.Text = ""
                        txtNumPed4.Text = ""

                        txtTransDesc.Text = ""
                        txtTransImporte.Text = ""
                        txtTransUniMed.Text = ""
                        cboTransClaveSat.Text = ""

                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboFolio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboFolio.SelectedValueChanged
        On Error GoTo puerta

        varfoliocarta = 0
        foliocarta = 0

        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""

        cbo_emisor.Text = ""
        cbo_rfc_emisor.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""
        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        chkInter.Checked = False
        GroupBox11.Visible = False
        txtAseguradora.Text = ""
        txtNumPoliza.Text = ""
        txtModeloAño.Text = ""
        txtNumPermisoSCT.Text = ""
        txtPlaca.Text = ""
        cboConfigV.Text = ""
        cboPermisoSCT.Text = ""
        dgProductos.Rows.Clear()

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
        cboOrigLoc.Text = ""

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
        cboDestinoLoc.Text = ""

        cboTipoFigura.Text = ""
        cboOpeNombre.Text = ""
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""

        cboDescripcion.Text = ""
        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = ""
        txtValorMerc.Text = ""
        txtPesoKG.Text = ""
        txtTotalPeso.Text = ""
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
        txtNumPed1.Text = ""
        txtNumPed2.Text = ""
        txtNumPed3.Text = ""
        txtNumPed4.Text = ""

        txtTransDesc.Text = ""
        txtTransImporte.Text = ""
        txtTransUniMed.Text = ""
        cboTransClaveSat.Text = ""

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select * from CartaPorte where FolioCarta = " & Trim(cboFolio.Text) & "", sinfo) Then
                    For Each dr In dt.Rows
                        cbo_emisor.Text = dr("EmiNombre").ToString
                        cbo_rfc_emisor.Text = dr("EmiRFC").ToString
                        varfoliocarta = dr("Id").ToString
                        foliocarta = cboFolio.Text

                        cboCliente.Text = dr("CliNombre").ToString
                        cboClienteRFC.Text = dr("CliRFC").ToString

                        Dim dt3 As New DataTable
                        Dim dr3 As DataRow
                        If .getDt(cnn, dt3, "select Regfis,CP from Clientes where RFC = '" & dr("CliRFC").ToString & "'", sinfo) Then
                            For Each dr3 In dt3.Rows
                                txtCPCliente.Text = dr3("CP").ToString
                                cbo_regimen.SelectedValue = dr3("Regfis").ToString
                            Next
                        End If

                        txtCP.Text = dr("EmiCP").ToString
                        txtRegFisEmi.Text = dr("EmiRegFis").ToString

                        If dr("Inter").ToString = "No" Then
                            chkInter.Checked = False
                            GroupBox11.Visible = False
                        Else
                            chkInter.Checked = True
                            GroupBox11.Visible = True
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
                        cboDestinoLoc.Text = dr("DesLocalidad").ToString

                        cboTipoFigura.Text = dr("FiguraTrasporte").ToString
                        cboOpeNombre.Text = dr("OpeNombre").ToString
                        txtOpeRFC.Text = dr("OpeRFC").ToString
                        txtOpeLicencia.Text = dr("OpeLic").ToString

                        txtTotalPeso.Text = dr("TotalPesoM").ToString

                        txtTransDesc.Text = dr("TransDes").ToString
                        txtTransImporte.Text = dr("TransImporte").ToString
                        txtTransUniMed.Text = dr("TransUniMedSat").ToString
                        cboTransClaveSat.Text = dameDesClaveSATM2(dr("TransClaveSat").ToString)

                        If dr("NumPed").ToString <> "" Then
                            txtNumPed1.Text = Mid(dr("NumPed").ToString, 1, 2)
                            txtNumPed2.Text = Mid(dr("NumPed").ToString, 5, 2)
                            txtNumPed3.Text = Mid(dr("NumPed").ToString, 7, 4)
                            txtNumPed4.Text = Mid(dr("NumPed").ToString, 11, 7)
                        Else
                            txtNumPed1.Text = ""
                            txtNumPed2.Text = ""
                            txtNumPed3.Text = ""
                            txtNumPed4.Text = ""
                        End If

                        Dim dt2 As New DataTable
                        Dim dr2 As DataRow
                        If .getDt(cnn, dt2, "select * from CartaPorteDet where IdCarta = " & dr("Id").ToString & " order by Id", sinfo) Then
                            For Each dr2 In dt2.Rows
                                dgProductos.Rows.Add(dr2("Descripcion").ToString, dr2("UniMedSAT").ToString, dr2("ProdServSAT").ToString, dr2("Cantidad").ToString, dr2("ValorM").ToString, dr2("PesoKg").ToString, "", dr2("UUIDComE").ToString, dr2("FracArancelaria").ToString)
                            Next
                        End If

                    Next

                    'If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    '    printRecibo()
                    'End If

                Else

                    varfoliocarta = 0
                    foliocarta = 0

                    cboCliente.Text = ""
                    cboClienteRFC.Text = ""
                    txtCP.Text = ""
                    txtRegFisEmi.Text = ""

                    cbo_emisor.Text = ""
                    cbo_rfc_emisor.Text = ""
                    txtCP.Text = ""
                    txtRegFisEmi.Text = ""
                    cboCliente.Text = ""
                    cboClienteRFC.Text = ""
                    chkInter.Checked = False
                    GroupBox11.Visible = False
                    txtAseguradora.Text = ""
                    txtNumPoliza.Text = ""
                    txtModeloAño.Text = ""
                    txtNumPermisoSCT.Text = ""
                    txtPlaca.Text = ""
                    cboConfigV.Text = ""
                    cboPermisoSCT.Text = ""
                    dgProductos.Rows.Clear()

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
                    cboDestinoLoc.Text = ""

                    cboTipoFigura.Text = ""
                    cboOpeNombre.Text = ""
                    txtOpeRFC.Text = ""
                    txtOpeLicencia.Text = ""

                    cboDescripcion.Text = ""
                    cboUniMedSAT.Text = ""
                    cboProdServSAT.Text = ""
                    txtCantidad.Text = ""
                    txtValorMerc.Text = ""
                    txtPesoKG.Text = ""
                    txtTotalPeso.Text = ""
                    txtUUIDComE.Text = ""
                    txtFraccAran.Text = ""
                    txtNumPed1.Text = ""
                    txtNumPed2.Text = ""
                    txtNumPed3.Text = ""
                    txtNumPed4.Text = ""

                    txtTransDesc.Text = ""
                    txtTransImporte.Text = ""
                    txtTransUniMed.Text = ""
                    cboTransClaveSat.Text = ""

                End If
                cnn.Close()
            End If
        End With

        Exit Sub
puerta:
        cnn.Close()
        varfoliocarta = 0
        foliocarta = 0

        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""

        cbo_emisor.Text = ""
        cbo_rfc_emisor.Text = ""
        txtCP.Text = ""
        txtRegFisEmi.Text = ""
        cboCliente.Text = ""
        cboClienteRFC.Text = ""
        chkInter.Checked = False
        GroupBox11.Visible = False
        txtAseguradora.Text = ""
        txtNumPoliza.Text = ""
        txtModeloAño.Text = ""
        txtNumPermisoSCT.Text = ""
        txtPlaca.Text = ""
        cboConfigV.Text = ""
        cboPermisoSCT.Text = ""
        dgProductos.Rows.Clear()

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
        cboOrigLoc.Text = ""

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
        cboDestinoLoc.Text = ""

        cboTipoFigura.Text = ""
        cboOpeNombre.Text = ""
        txtOpeRFC.Text = ""
        txtOpeLicencia.Text = ""

        cboDescripcion.Text = ""
        cboUniMedSAT.Text = ""
        cboProdServSAT.Text = ""
        txtCantidad.Text = ""
        txtValorMerc.Text = ""
        txtPesoKG.Text = ""
        txtTotalPeso.Text = ""
        txtUUIDComE.Text = ""
        txtFraccAran.Text = ""
        txtNumPed1.Text = ""
        txtNumPed2.Text = ""
        txtNumPed3.Text = ""
        txtNumPed4.Text = ""

        txtTransDesc.Text = ""
        txtTransImporte.Text = ""
        txtTransUniMed.Text = ""
        cboTransClaveSat.Text = ""

        cnn.Close()
    End Sub

    Private Sub Btt_Generar_Click(sender As Object, e As EventArgs) Handles Btt_Generar.Click

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.getDt(cnn, dt, "select * from CartaPorte where UUID is null or UUID = ''", sinfo) Then
                For Each dr In dt.Rows
                    odata.runSp(cnn, "Delete from CartaPorteDet where IdCarta = " & dr("Id").ToString & "", sinfo)
                Next
                cnn.Close()
            End If
        End If

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from CartaPorte where UUID is null", sinfo)
            cnn.Close()
        End If

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            odata.runSp(cnn, "Delete from CartaPorte where UUID = ''", sinfo)
            cnn.Close()
        End If

        If cbo_emisor.Text = "" Then MsgBox("Debe seleccionar un emisor") : cbo_emisor.Focus() : Exit Sub
        If cboCliente.Text = "" Then MsgBox("Debe seleccionar un cliente") : cboCliente.Focus() : Exit Sub
        If cbo_rfc_emisor.Text = "" Then MsgBox("Debe seleccionar el rfc del emisor") : cbo_rfc_emisor.Focus() : Exit Sub
        If cboClienteRFC.Text = "" Then MsgBox("Debe seleccionar el rfc del cliente") : cboClienteRFC.Focus() : Exit Sub

        If txtTransDesc.Text = "" Then MsgBox("Debe Escribir una descripcion para el Translado") : Exit Sub
        If txtTransImporte.Text = "" Or txtTransImporte.Text = "0" Then MsgBox("Debe Escribir un importe para el Translado") : Exit Sub
        If IsNumeric(txtTransImporte.Text) = False Then MsgBox("Debe Escribir un importe con un valor numérico para el Translado") : Exit Sub
        If cboTransClaveSat.Text = "" Then MsgBox("Debe Escribir una descripcion para el Translado") : Exit Sub
        If txtTransUniMed.Text = "" Then MsgBox("Debe Escribir una unidad de medida Translado") : Exit Sub

        If cboTipoFigura.Text = "" Then MsgBox("Debe seleccionar un tipo de figura") : Exit Sub

        Dim varinter As String = "No"

        If chkInter.Checked = False Then
            varinter = "No"
        Else
            varinter = "Sí"
        End If

        Dim numpedimento As String = ""

        If varinter = "Sí" Then
            If txtNumPed1.Text <> "" And txtNumPed2.Text <> "" And txtNumPed3.Text <> "" And txtNumPed4.Text <> "" Then
                numpedimento = txtNumPed1.Text & "  " & txtNumPed2.Text & "  " & txtNumPed3.Text & "  " & txtNumPed4.Text  '"21  47  3807  8003832"
            End If
        End If

        Dim varOrigFechaHora As String = ""
        varOrigFechaHora = Format(CDate(dtpOrigFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(dtpOrigHora.Value), "HH:mm:ss")

        Dim varDesFechaHora As String = ""
        varDesFechaHora = Format(CDate(dtpDesFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(dtpDesHora.Value), "HH:mm:ss")

        foliocarta = 0

        If cboFolio.Text <> "" Then
            If validaCarta() > 0 Then
                MsgBox("El folio ya existe")
                Exit Sub
            End If
        End If

        cnn = New MySqlClient.MySqlConnection
        sinfo = ""
        odata = New ToolKitSQL.myssql
        dt = New DataTable
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                For i = 0 To dgProductos.RowCount - 1
                    If .getDt(cnn, dt, "select * from PorteMercancia where Descripcion = '" & Trim(dgProductos.Rows(i).Cells(0).Value.ToString) & "'", sinfo) Then
                        For Each dr In dt.Rows
                            .runSp(cnn, "update PorteMercancia set UniMedSAT = '" & dgProductos.Rows(i).Cells(1).Value.ToString & "', ProdServSAT = '" & dgProductos.Rows(i).Cells(2).Value.ToString & "' where Id = " & dr("Id").ToString & "", sinfo)
                        Next
                    Else
                        .runSp(cnn, "insert into PorteMercancia(Descripcion,UniMedSAT,ProdServSAT) values('" & Trim(dgProductos.Rows(i).Cells(0).Value.ToString) & "','" & dgProductos.Rows(i).Cells(1).Value.ToString & "','" & dgProductos.Rows(i).Cells(2).Value.ToString & "')", sinfo)
                    End If
                Next

                If .getDt(cnn, dt, "select * from PorteProducto", sinfo) Then
                    For Each dr In dt.Rows
                        .runSp(cnn, "update PorteProducto set Descripcion = '" & Trim(txtTransDesc.Text) & "', ValorUnitario = '" & Trim(txtTransImporte.Text) & "', UniMedSat = '" & Trim(txtTransUniMed.Text) & "', ClaveSat = '" & Trim(dameClaveSAT(cboTransClaveSat.Text)) & "', NomClaveSat = '" & Trim(cboTransClaveSat.Text) & "'", sinfo)
                    Next
                Else
                    .runSp(cnn, "insert into PorteProducto(Descripcion,ValorUnitario,UniMedSat,ClaveSat,NomClaveSat) values('" & Trim(txtTransDesc.Text) & "', '" & Trim(txtTransImporte.Text) & "','" & Trim(txtTransUniMed.Text) & "','" & Trim(dameClaveSAT(cboTransClaveSat.Text)) & "','" & Trim(cboTransClaveSat.Text) & "') ", sinfo)
                End If

                If .getDt(cnn, dt, "select * from PorteOrigen where Remitente = '" & cboOrigRemitente.Text & "' and RFC = '" & txtOrigRFC.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        .runSp(cnn, "update PorteOrigen set CP = '" & txtOrigCP.Text & "', Calle = '" & Trim(txtOrigCalle.Text) & "', NumExt = '" & Trim(txtOrigNumExt.Text) & "', NumInt = '" & Trim(txtOrigNumInt.Text) & "', Colonia = '" & Trim(cboOrigColonia.Text) & "', Edo = '" & Trim(cboOrigEdo.Text) & "', Mun = '" & Trim(cboOrigMun.Text) & "', Loc = '" & Trim(cboOrigLoc.Text) & "'  where Id = " & dr("Id").ToString & "", sinfo)
                    Next
                Else
                    .runSp(cnn, "insert into PorteOrigen(Remitente,RFC,CP,Calle,NumExt,NumInt,Colonia,Edo,Mun,Loc) values('" & Trim(cboOrigRemitente.Text) & "', '" & Trim(txtOrigRFC.Text) & "','" & txtOrigCP.Text & "','" & Trim(txtOrigCalle.Text) & "','" & Trim(txtOrigNumExt.Text) & "','" & Trim(txtOrigNumInt.Text) & "','" & Trim(cboOrigColonia.Text) & "','" & Trim(cboOrigEdo.Text) & "','" & Trim(cboOrigMun.Text) & "','" & Trim(cboOrigLoc.Text) & "') ", sinfo)
                End If
                If .getDt(cnn, dt, "select * from PorteDestino where Destinatario = '" & cboDesDestinatario.Text & "' and RFC = '" & txtDesRFC.Text & "'", sinfo) Then
                    For Each dr In dt.Rows
                        .runSp(cnn, "update PorteDestino set CP = '" & txtDestinoCP.Text & "', Calle = '" & Trim(txtDestinoCalle.Text) & "', NumE = '" & Trim(txtDestinoNumE.Text) & "', NumI = '" & Trim(txtDestinoNumI.Text) & "', Colonia = '" & Trim(cboDestinoColonia.Text) & "', Edo = '" & Trim(cboDestinoEdo.Text) & "', Mun = '" & Trim(cboDestinoMun.Text) & "', Pais = '" & Trim(cboDestinoPais.Text) & "', Loc = '" & Trim(cboDestinoLoc.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                    Next
                Else
                    .runSp(cnn, "insert into PorteDestino(Destinatario,RFC,CP,Calle,NumE,NumI,Colonia,Edo,Mun,Pais,Loc) values('" & Trim(cboDesDestinatario.Text) & "', '" & Trim(txtDesRFC.Text) & "','" & txtDestinoCP.Text & "','" & Trim(txtDestinoCalle.Text) & "','" & Trim(txtDestinoNumE.Text) & "','" & Trim(txtDestinoNumI.Text) & "','" & Trim(cboDestinoColonia.Text) & "','" & Trim(cboDestinoEdo.Text) & "','" & Trim(cboDestinoMun.Text) & "','" & Trim(cboDestinoPais.Text) & "','" & Trim(cboDestinoLoc.Text) & "') ", sinfo)
                End If

                If cboTipoFigura.Text = "Operador" Then
                    If .getDt(cnn, dt, "select * from PorteOperador where Nombre = '" & cboOpeNombre.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            .runSp(cnn, "update PorteOperador set  RFC = '" & Trim(txtOpeRFC.Text) & "', Licencia = '" & Trim(txtOpeLicencia.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                        Next
                    Else
                        .runSp(cnn, "insert into PorteOperador(Nombre,RFC,Licencia) values('" & Trim(cboOpeNombre.Text) & "', '" & Trim(txtOpeRFC.Text) & "','" & Trim(txtOpeLicencia.Text) & "') ", sinfo)
                    End If
                Else
                    If .getDt(cnn, dt, "select * from PortePropietario where Nombre = '" & cboOpeNombre.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            .runSp(cnn, "update PortePropietario set RFC = '" & Trim(txtOpeRFC.Text) & "', Licencia = '" & Trim(txtOpeLicencia.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                        Next
                    Else
                        .runSp(cnn, "insert into PortePropietario(Nombre,RFC,Licencia) values('" & Trim(cboOpeNombre.Text) & "', '" & Trim(txtOpeRFC.Text) & "','" & Trim(txtOpeLicencia.Text) & "') ", sinfo)
                    End If
                End If

                foliocarta = maxidcartafolio() + 1
                If .runSp(cnn, "insert into CartaPorte(FolioCarta, EmiNombre, EmiRFC, EmiCP, EmiRegFis, CliRFC, CliNombre, Inter, OrigNombre, OrigRFC, OrigFechaHora, OrigCP, OrigCalle, OrigNumExt, OrigNumInt, OrigColonia, OrigEdo," &
                                "OrigMun, TotalDistancia, DesNombre, DesRFC, DesFechaHora, DesCP, DesPais, DesCalle, DesNumExt, DesNumInt, DesCol, DesEdo, DesMun, PermisoSCT, NumPoliza, NumPermisoSCT,Aseguradora, Placa, " &
                                "Config, ModeloA, OpeRFC, OpeLic, OpeNombre, OpeNumExt, OpeNumInt, OpeMun, OpeEdo, OpeColonia, OpeCP, OpeCalle, TotalMercancias, OrigColoniaT, OrigEdoT, OrigMunT, DesColT, DesEdoT, DesMunT, OpeColoniaT, OpeEdoT, OpeMunT, TotalPesoM, DesLocalidad, " &
                                " TransDes, TransImporte, TransUniMedSat, TransClaveSat, NumPed, FiguraTrasporte, AseguradoraMedAmb, NumPolizaMedAmb) values(" & foliocarta & ",'" & cbo_emisor.Text & "', '" & cbo_rfc_emisor.Text & "', '" & txtCP.Text &
                                "', '" & txtRegFisEmi.Text & "', '" & cboClienteRFC.Text & "', '" & cboCliente.Text & "', '" & varinter & "', '" & cboOrigRemitente.Text & "', '" & txtOrigRFC.Text & "', '" & varOrigFechaHora & "', '" & txtOrigCP.Text &
                                "', '" & txtOrigCalle.Text & "', '" & txtOrigNumExt.Text & "', '" & txtOrigNumInt.Text & "', '" & dameclaveColonia() & "', '" & dameclaveEdo() & "'," &
                                "'" & dameclaveMun() & "', '" & txtDestinioDist.Text & "', '" & cboDesDestinatario.Text & "', '" & txtDesRFC.Text & "', '" & varDesFechaHora & "', '" & txtDestinoCP.Text & "', '" & dameclavePais() & "', '" & txtDestinoCalle.Text &
                                "', '" & txtDestinoNumE.Text & "', '" & txtDestinoNumI.Text & "', '" & dameclaveColoniaD() & "', '" & dameclaveEdoD() & "', '" & dameclaveMunD() & "', '" & dameclavePermisoSCT() & "', '" & txtNumPoliza.Text & "', '" & txtNumPermisoSCT.Text &
                                "', '" & txtAseguradora.Text & "', '" & txtPlaca.Text & "', '" & dameclaveConfigV() & "', '" & txtModeloAño.Text & "', '" & txtOpeRFC.Text & "', '" & txtOpeLicencia.Text & "', '" & cboOpeNombre.Text & "', '', '' " &
                                ", '', '', '', '', '', '" & dgProductos.RowCount & "', '" & cboOrigColonia.Text & "', '" & cboOrigEdo.Text & "', '" & cboOrigMun.Text &
                                "', '" & cboDestinoColonia.Text & "', '" & cboDestinoEdo.Text & "', '" & cboDestinoMun.Text & "', '', '', '','" & txtTotalPeso.Text & "','" & cboDestinoLoc.Text &
                                "', '" & Trim(txtTransDesc.Text) & "', '" & Trim(txtTransImporte.Text) & "', '" & Trim(txtTransUniMed.Text) & "', '" & dameClaveSAT(Trim(cboTransClaveSat.Text)) & "','" & numpedimento & "','" & cboTipoFigura.Text & "','" & txtAseguradoraMatPel.Text & "','" & txtNumPolizaMatPel.Text & "')", sinfo) Then
                    varfoliocarta = maxidcarta()

                    For i = 0 To dgProductos.RowCount - 1

                        If .runSp(cnn, "insert into CartaPorteDet(IdCarta, FolioCarta, Descripcion, UniMedSAT, ProdServSAT, Cantidad, ValorM, PesoKg, NumPed, UUIDComE, FracArancelaria, MatPel, ClaveMatPel, DescMatPel, Embalaje, ClaveEmbalaje) values(" & varfoliocarta & "," & foliocarta & ",'" & dgProductos.Rows(i).Cells(0).Value & "','" & dgProductos.Rows(i).Cells(1).Value & "','" & dgProductos.Rows(i).Cells(2).Value & "','" & dgProductos.Rows(i).Cells(3).Value & "','" & dgProductos.Rows(i).Cells(4).Value & "','" & dgProductos.Rows(i).Cells(5).Value & "','" & dgProductos.Rows(i).Cells(6).Value & "','" & dgProductos.Rows(i).Cells(7).Value & "','" & dgProductos.Rows(i).Cells(8).Value & "','" & dgProductos.Rows(i).Cells(9).Value & "', '" & dgProductos.Rows(i).Cells(10).Value & "','" & dgProductos.Rows(i).Cells(13).Value & "', '" & dgProductos.Rows(i).Cells(11).Value & "','" & dgProductos.Rows(i).Cells(12).Value & "')", sinfo) Then

                        End If

                    Next


                End If
                cnn.Close()
            End If
        End With

        lbl_proceso.Visible = True
        ProgressBar1.Visible = True

        ProgressBar1.Value = 10
        lbl_proceso.Text = "Iniciando ..."
        My.Application.DoEvents()

        If GeneraXMLTrasporte(varfoliocarta, foliocarta, cbo_emisor.Text, cbo_rfc_emisor.Text, txtCP.Text, txtRegFisEmi.Text, cboClienteRFC.Text, cboCliente.Text, varinter, cboOrigRemitente.Text, txtOrigRFC.Text,
                        varOrigFechaHora, txtOrigCP.Text, txtOrigCalle.Text, txtOrigNumExt.Text, txtOrigNumInt.Text, dameclaveColonia(), dameclaveEdo(), dameclaveLoc(), dameclaveMun(), txtDestinioDist.Text,
                        cboDesDestinatario.Text, txtDesRFC.Text, varDesFechaHora, txtDestinoCP.Text, dameclavePais(), txtDestinoCalle.Text, txtDestinoNumE.Text, txtDestinoNumI.Text, dameclaveColoniaD(),
                        dameclaveEdoD(), dameclaveMunD(), dgProductos, dameclavePermisoSCT(), txtNumPoliza.Text, txtNumPermisoSCT.Text, txtAseguradora.Text, txtPlaca.Text, dameclaveConfigV(), txtModeloAño.Text,
                        txtOpeRFC.Text, txtOpeLicencia.Text, cboOpeNombre.Text, "", "", "", "", "", "", "", cboDestinoLoc.Text,
                        txtTransDesc.Text, txtTransImporte.Text, txtTransUniMed.Text, dameClaveSAT(Trim(cboTransClaveSat.Text)), numpedimento, cboTipoFigura.Text) Then

            ProgressBar1.Value = 95
            lbl_proceso.Text = "Generando PDF ..."
            My.Application.DoEvents()

            MsgBox("Carta generada correctamente")

            printRecibo()

            Btt_Nuevo.PerformClick()

        End If

        lbl_proceso.Visible = False
        ProgressBar1.Visible = False

    End Sub

    Private Function validaCarta() As Integer

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Id from CartaPorte where FolioCarta = " & Trim(cboFolio.Text) & "", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return CInt(dr("Id").ToString)
                    Next
                Else
                    cnn.Close()
                    Return 0
                End If
                cnn.Close()
            End If
        End With

        Return 0
    End Function

    Private Function maxidcarta() As Integer

        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(Id) as maxi from CartaPorte", sinfo1) Then
                    For Each dr1 In dt1.Rows
                        cnn1.Close()
                        Return CInt(dr1("maxi").ToString)
                    Next
                Else
                    cnn1.Close()
                    Return 0
                End If
                cnn1.Close()
            End If
        End With

        Return 0

    End Function

    Private Function maxidcartafolio() As Integer

        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(FolioCarta) as maxi from CartaPorte", sinfo1) Then
                    For Each dr1 In dt1.Rows
                        cnn1.Close()
                        Return CInt(IIf(IsNumeric(dr1("maxi").ToString), dr1("maxi").ToString, 0))
                    Next
                Else
                    cnn1.Close()
                    Return 0
                End If
                cnn1.Close()
            End If
        End With

        Return 0

    End Function

    Public Sub printRecibo()

        'Dim FileOpen As New ProcessStartInfo
        'crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\CARTAPORTE\")
        'Dim root_name_recibo As String = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\CARTAPORTE\C_" & foliocarta & ".pdf"
        'Dim FileNta As New CartaPorte

        'Try
        '    FileNta.SetDatabaseLogon("", "jipl22")
        '    FileNta.DataDefinition.FormulaFields("identificador").Text = "'" & varfoliocarta & "'"
        '    FileNta.DataDefinition.FormulaFields("FolioCarta").Text = "'Folio: " & foliocarta & "'"
        '    Dim cadqr As String = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & cbo_emisor.Text & "\cd\CARTAPORTE\CP" & foliocarta
        '    FileNta.DataDefinition.FormulaFields("qr").Text = "'" & cadqr & ".jpg'"
        '    Refresh()
        '    FileNta.Refresh()
        '    FileNta.Refresh()
        '    FileNta.Refresh()
        '    If File.Exists(root_name_recibo) Then
        '        File.Delete(root_name_recibo)
        '    End If
        '    Try
        '        Dim CrExportOptions As ExportOptions
        '        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        '        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
        '        CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
        '        CrExportOptions = FileNta.ExportOptions
        '        With CrExportOptions
        '            .ExportDestinationType = ExportDestinationType.DiskFile
        '            .ExportFormatType = ExportFormatType.PortableDocFormat
        '            .DestinationOptions = CrDiskFileDestinationOptions
        '            .FormatOptions = CrFormatTypeOptions
        '        End With

        '        FileNta.Export()
        '        FileOpen.UseShellExecute = True
        '        FileOpen.FileName = root_name_recibo
        '        My.Application.DoEvents()
        '        If MsgBox("¿Desea Abrir el Archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '            Process.Start(FileOpen)
        '        End If

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'FileNta.Close()

    End Sub

    Private Sub cboCliente_DropDown(sender As Object, e As EventArgs) Handles cboCliente.DropDown
        cboCliente.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select RazonSocial from Clientes order by RazonSocial", sinfo) Then
                    For Each dr In dt.Rows
                        cboCliente.Items.Add(dr("RazonSocial").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With

    End Sub

    Private Sub cboClienteRFC_DropDown(sender As Object, e As EventArgs) Handles cboClienteRFC.DropDown
        cboClienteRFC.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select RFC from Clientes", sinfo) Then
                    For Each dr In dt.Rows
                        cboClienteRFC.Items.Add(dr("RFC").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
    End Sub

    Private Sub cboCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboCliente.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select RFC,CP,Regfis from Clientes where RazonSocial = '" & Trim(cboCliente.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            cboClienteRFC.Text = dr("RFC").ToString
                            cbo_regimen.SelectedValue = dr("Regfis").ToString
                            txtCPCliente.Text = dr("CP").ToString
                        Next
                    Else
                        cboClienteRFC.Text = ""
                        cbo_regimen.Text = ""
                        cbo_regimen.SelectedIndex = -1
                        txtCPCliente.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedValueChanged

        On Error GoTo puerta
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select RFC,Regfis,CP from Clientes where RazonSocial = '" & Trim(cboCliente.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        cboClienteRFC.Text = dr("RFC").ToString
                        cbo_regimen.SelectedValue = dr("Regfis").ToString
                        txtCPCliente.Text = dr("CP").ToString
                    Next
                Else
                    cboClienteRFC.Text = ""
                    cbo_regimen.Text = ""
                    cbo_regimen.SelectedValue = -1
                    txtCPCliente.Text = ""
                End If
                cnn.Close()
            End If
        End With

        Exit Sub

puerta:

        cnn.Close()
        cboClienteRFC.Text = ""
    End Sub

    Private Sub cboClienteRFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboClienteRFC.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim odata As New ToolKitSQL.myssql
            Dim dt As New DataTable
            Dim dr As DataRow
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
                    If .getDt(cnn, dt, "select RazonSocial,Regfis,CP from Clientes where RFC = '" & Trim(cboClienteRFC.Text) & "' ", sinfo) Then
                        For Each dr In dt.Rows
                            cboCliente.Text = dr("RazonSocial").ToString
                            cbo_regimen.SelectedValue = dr("Regfis").ToString
                            txtCPCliente.Text = dr("CP").ToString
                        Next
                    Else
                        cboCliente.Text = ""
                        cbo_regimen.Text = ""
                        cbo_regimen.SelectedValue = -1
                        txtCPCliente.Text = ""
                    End If
                    cnn.Close()
                End If
            End With
        End If
    End Sub

    Private Sub cboClienteRFC_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboClienteRFC.SelectedValueChanged
        On Error GoTo puerta

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select RazonSocial,Regfis,CP from Clientes where RFC = '" & Trim(cboClienteRFC.Text) & "' ", sinfo) Then
                    For Each dr In dt.Rows
                        cboCliente.Text = dr("RazonSocial").ToString
                        cbo_regimen.SelectedValue = dr("Regfis").ToString
                        txtCPCliente.Text = dr("CP").ToString
                    Next
                Else
                    cboCliente.Text = ""
                    cbo_regimen.Text = ""
                    cbo_regimen.SelectedValue = -1
                    txtCPCliente.Text = ""
                End If
                cnn.Close()
            End If
        End With

        Exit Sub

puerta:

        cnn.Close()
        cboCliente.Text = ""
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

    Private Sub cboOrigLoc_DropDown(sender As Object, e As EventArgs) Handles cboOrigLoc.DropDown
        cboOrigLoc.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                Dim str As String = "select Distinct Descripcion from PorteLocalidad order by Descripcion"
                If cboOrigEdo.Text <> "" Then
                    str = "select Distinct Descripcion from PorteLocalidad where ClaveEdo = '" & dameclaveEdo() & "' order by Descripcion"
                End If
                If .getDt(cnn, dt, str, sinfo) Then
                    For Each dr In dt.Rows
                        cboOrigLoc.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With
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

    Private Function dameclaveColonia() As String

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveColonia from PorteColonia where Nombre = '" & Trim(cboOrigColonia.Text) & "' and CP = '" & txtOrigCP.Text & "'", sinfo) Then
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

    Private Function dameclaveLoc() As String

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveLocalidad from PorteLocalidad where Descripcion = '" & Trim(cboOrigLoc.Text) & "'", sinfo) Then
                    For Each dr In dt.Rows
                        cnn.Close()
                        Return dr("ClaveLocalidad").ToString
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

    Private Function dameclaveMun() As String

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveMun from PorteMunicipios where Descripcion = '" & Trim(cboOrigMun.Text) & "'", sinfo) Then
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If cboDescripcion.Text = "" Then
            MsgBox("Selecciona un Producto para continuar!!!", vbInformation + vbOKOnly)
            cboDescripcion.Focus()
            Exit Sub
        ElseIf cboUniMedSAT.Text = "" Then
            MsgBox("Selecciona la unidad de medida para continuar!!!", vbInformation + vbOKOnly)
            cboDescripcion.Focus()
            Exit Sub
            'ElseIf txtValorMerc.Text = 0 Then
            '    MsgBox("El valor de la mercancia debe ser mayor a 0!!!", vbInformation + vbOKOnly)
            '    txtValorMerc.Focus()
            '    Exit Sub
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
            chkMatPeg.Checked = False
            cboMatPeligroso.Text = ""
            cboEmbalaje.Text = ""

        End If

    End Sub

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

    Private Sub chkInter_CheckedChanged(sender As Object, e As EventArgs) Handles chkInter.CheckedChanged
        If chkInter.Checked = True Then
            GroupBox11.Visible = True
        Else
            GroupBox11.Visible = False
        End If
    End Sub

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
                            cboDestinoLoc.Text = dr("Loc").ToString
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
                        cboDestinoLoc.Text = ""
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
                        cboDestinoLoc.Text = dr("Loc").ToString
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
                    cboDestinoLoc.Text = ""
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
        cboDestinoLoc.Text = ""
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
            'Dim cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
            'Dim sinfo As String = ""
            'Dim odata As New ToolKitSQL.oledbdata
            'Dim dt As New DataTable
            'Dim dr As DataRow
            'With odata
            '    If .dbOpen(cnn, sTarget, sinfo) Then
            '        If .getDt(cnn, dt, "select * from Productos where Nombre = '" & cboDescripcion.Text & "' ", "dtuno", sinfo) Then
            '            For Each dr In dt.Rows
            '                cboUniMedSAT.Text = dameDesUnidadMedSATM(dr("UniMedSAT").ToString)
            '                cboProdServSAT.Text = dameDesClaveSATM(dr("ProdServSAT").ToString)
            '                txtCantidad.Text = "1"
            '                txtValorMerc.Text = "0"
            '                txtPesoKG.Text = "0"
            '                txtUUIDComE.Text = ""
            '                txtFraccAran.Text = ""
            '            Next
            '        Else
            '            cboUniMedSAT.Text = ""
            '            cboProdServSAT.Text = ""
            '            txtCantidad.Text = "1"
            '            txtValorMerc.Text = "0"
            '            txtPesoKG.Text = "0"
            '            txtUUIDComE.Text = ""
            '            txtFraccAran.Text = ""
            '        End If
            '        cnn.Close()
            '    End If
            'End With
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

    Private Sub dgProductos_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgProductos.RowsRemoved
        calculatotalpeso()
    End Sub

    Sub calculatotalpeso()

        txtTotalPeso.Text = "0"

        For i = 0 To dgProductos.RowCount - 1
            txtTotalPeso.Text = CDec(txtTotalPeso.Text) + CDec(dgProductos.Rows(i).Cells(3).Value.ToString)
        Next
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

    Function dameClaveSAT(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveProdSat FROM PorteProductoSat2 where Descripcion = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Function dameClaveSATM(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveProdSat FROM PorteProductoSat where Descripcion = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Function dameUnidadMedSATM(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveUnidad FROM PorteUnidadMedEmb where Nombre = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Function dameDesClaveSATM(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Descripcion FROM PorteProductoSat where ClaveProdSat = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Function dameDesClaveSATM2(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Descripcion FROM PorteProductoSat2 where ClaveProdSat = '" & varDesc & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Function dameDesUnidadMedSATM(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Nombre FROM PorteUnidadMedEmb where ClaveUnidad = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

    Private Sub cboTransClaveSat_DropDown(sender As Object, e As EventArgs) Handles cboTransClaveSat.DropDown

        cboTransClaveSat.Items.Clear()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Descripcion from PorteProductoSat2", sinfo) Then
                    For Each dr In dt.Rows
                        cboTransClaveSat.Items.Add(dr("Descripcion").ToString)
                    Next
                End If
                cnn.Close()
            End If
        End With

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

    Private Sub Btt_Cancelar_Click(sender As Object, e As EventArgs) Handles Btt_Cancelar.Click
        GroupBox20.Visible = True
        cboTipoCancelacion.Focus()
    End Sub

    Private Sub busca_d()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select * from CartaPorte where FolioCarta=" & cboFolio.Text
        Dim sinfo As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDr(cnn, dr, sSQL, sinfo) Then
                    uidcancel = dr("UUID").ToString
                    refccancel = dr("EmiRFC").ToString
                Else
                    'MsgBox(sinfo)
                End If
                cnn.Close()
            Else
                'MsgBox(sinfo)
            End If

        End With

    End Sub

    Function dameMaterialPeligroso(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveMatPel FROM PorteMatPeligrosos where Descripcion = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then
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

    End Function

    Function dameEmbalaje(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveDesignacion FROM PorteTipoEmbalaje where Descripcion = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then
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

    End Function

    Function dameTipoRemolque(ByVal varDesc As String) As String

        Dim sInfo As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT ClaveTipoRemolque FROM PorteTipoRemolque where Remolque = '" & Trim(varDesc) & "'"
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If odata.dbOpen(cnn, sTarget, sInfo) Then

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

    End Function

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

        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
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
        'cancelaporte(uidcancel, refccancel, cboFolio.Text, str, txtUUIDCanelacion.Text)

        cancelaporte(uidcancel, refccancel, cboFolio.Text, "CP" & cboFolio.Text, cbo_emisor.Text, str, txtUUIDCanelacion.Text)

        txtUUIDCanelacion.Text = ""
        cboTipoCancelacion.Text = ""
        cboTipoCancelacion.SelectedIndex = -1
        GroupBox20.Visible = False
    End Sub
End Class