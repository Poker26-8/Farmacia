
Imports Core.Common
Imports MySql.Data
Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmNomina_Empleado
    Private Sub frmNomina_Empleado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        llena_combo_otros()
        llena_combo_persepciones()
        llena_combo_deducciones()
        llena_combo_empresa()
        llena_combo_origenrec()
        llena_combo_tiponom()
        llena_combo_peridicidad()
        llena_combo_tipoInca()
    End Sub



    Private Sub llena_combo_otros()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "SELECT clave,descripcion FROM otrospagos ORDER BY descripcion"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With concepto_otros
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "clave"
                    .DisplayMember = "descripcion"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub llena_combo_persepciones()


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "Select atpc_id,atpc_descripcion from tipo_percepcion_contable order by atpc_descripcion"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With concepto_precepcion
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "atpc_id"
                    .DisplayMember = "atpc_descripcion"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
    End Sub

    Private Sub llena_combo_deducciones()


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "Select atdc_id,atdc_descripcion from tipo_deduccion_contable  order by atdc_descripcion" '
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With consepto_deduccion
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "atdc_id"
                    .DisplayMember = "atdc_descripcion"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
    End Sub

    Private Sub llena_combo_empresa()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Emisor_id,Em_RazonSocial FROM datosnegocio ORDER BY Em_RazonSocial"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cboEmpresa
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "Emisor_id"
                    .DisplayMember = "Em_RazonSocial"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

        If cboEmpresa.Items.Count < 1 Then

            MsgBox("Debe AGREGAR almenos una Empresa")
            Me.GroupBox1.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.GroupBox3.Enabled = False
            Me.GroupBox4.Enabled = False

        Else
            cboEmpresa.SelectedIndex = 0


        End If

    End Sub

    Private Sub llena_combo_origenrec()


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "SELECT clave,descripcion FROM origenrecurso"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            With cbo_origenrec

                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "clave"
                    .DisplayMember = "descripcion"
                    .SelectedIndex = -1
                Else

                    MsgBox(sinfo)

                End If

            End With

            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
    End Sub

    Private Sub llena_combo_tiponom()


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "SELECT clave,descripcion FROM tiponomina"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            With cbo_tiponomina

                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "clave"
                    .DisplayMember = "descripcion"
                    .SelectedIndex = 1
                Else

                    MsgBox(sinfo)

                End If

            End With

            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
    End Sub

    Private Sub llena_combo_peridicidad()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select pp_id,pp_nombre from Periodicidad_pago order by pp_id"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cbo_periodicidad
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "pp_id"
                    .DisplayMember = "pp_nombre"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub llena_combo_tipoInca()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT TipoIncapacidad,Descripcion FROM tipoincapacidadSat ORDER BY Id"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cboTipoInca
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "TipoIncapacidad"
                    .DisplayMember = "Descripcion"

                Else
                    MsgBox(sinfo)
                End If
            End With
            cboTipoInca.SelectedValue = -1
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub llena_combo_periodo()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT pp_id,pp_nombre FROM periodicidad_pago ORDER BY pp_id"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cboPeriodo
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "pp_id"
                    .DisplayMember = "pp_nombre"
                Else
                    MsgBox(sinfo)

                End If

            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub cboEmpresa_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedValueChanged

        On Error GoTo marca
        If cboEmpresa.Text <> "" Then

            If cboEmpresa.SelectedValue > 0 Then
                grid_empleados.Rows.Clear()
                grid_deducciones.Rows.Clear()
                grid_percepciones.Rows.Clear()
                txt_deducciones.Text = "0"

                llena_informacion_empresa()
                llena_grid_empleado()
                busca_folio()
            End If
        End If

        If sello = "1212333" Then
marca:
        End If

    End Sub

    Private Sub llena_informacion_empresa()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT Em_rfc,Em_RFiscal FROM datosnegocio WHERE Emisor_id=" & cboEmpresa.SelectedValue
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                txtRFCEmisor.Text = dr("Em_rfc").ToString
                txtRegFiscal.Text = dr("Em_RFiscal").ToString

            End If


            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub llena_grid_empleado()

        Dim sSQL As String = ""

        Dim fecha As Date = Nothing

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        'Emp_numerico1=Emp_empresa
        sSQL = "SELECT Ingreso,IdEmpleado,Nombre,Curp,NSS,Area,Puesto,Rfc,Sueldoxdia,Emp_ultimo_timbre FROM usuarios WHERE Status = 1 AND Emp_empresa = " & cboEmpresa.SelectedValue & " ORDER BY Nombre"
        Dim cadena_dep As String = ""
        Dim cadena_pue As String = ""
        Dim dt As New DataTable
        Dim sinfo As String = ""
        Dim dr As DataRow
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDt(cnn, dt, sSQL, sinfo) Then
                If dt.Rows.Count > 0 Then


                    For Each dr In dt.Rows
                        fecha = dr("Ingreso").ToString
                        '  busca_depto(CInt(dr("emp_area").ToString), cadena_dep)
                        ' busca_puesto(CInt(dr("emp_puesto").ToString), cadena_pue)

                        grid_empleados.Rows.Insert(0, dr("IdEmpleado").ToString, dr("Nombre").ToString, dr("Curp").ToString, dr("NSS").ToString, dr("IdEmpleado").ToString, dr("Area").ToString, dr("Puesto").ToString, dr("Rfc").ToString, dr("Sueldoxdia").ToString, dr("Emp_ultimo_timbre").ToString, "1", Format(fecha, "yyyy-MM-dd")) 'emp_importe_nomina

                    Next
                End If
            Else
                ' MsgBox(sinfo)

            End If

        Else
            MsgBox(sinfo)
        End If

        cnn.Close()

    End Sub

    Private Sub busca_folio(Optional ByRef cadena As String = "")

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT MAX(nom_folio) AS Ma FROM nomina WHERE nom_razon_social='" & cboEmpresa.Text & "'"
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                txtultimo_folio.Text = dr("Ma").ToString
                    cadena = dr("Ma").ToString


                    Else
                    sSQL = "SELECT emi_folio_inicial FROM datosnegocio where Emisor_id=" & cboEmpresa.SelectedValue
                If odata.getDr(cnn, dr, sSQL, sinfo) Then
                    txtultimo_folio.Text = dr("emi_folio_inicial").ToString
                    cadena = dr("emi_folio_inicial").ToString
                End If

            End If

            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub DTDel_ValueChanged(sender As Object, e As EventArgs) Handles DTDel.ValueChanged
        txtdiaspagados.Text = CInt((DTAl.Value - DTDel.Value).TotalDays) + 1
        calcula_anti()
    End Sub

    Private Sub DTAl_ValueChanged(sender As Object, e As EventArgs) Handles DTAl.ValueChanged
        txtdiaspagados.Text = CInt((DTAl.Value - DTDel.Value).TotalDays) + 1
        calcula_anti()
    End Sub

    Private Sub calcula_anti()
        Dim fecha_ing As Date
        Dim fecha_pago As Date

        fecha_pago = DTAl.Value
        fecha_ing = CDate(grid_empleados.CurrentRow.Cells(11).Value.ToString)
        txt_antiguedad.Text = (CInt((((CDate(fecha_pago) - CDate(fecha_ing)).TotalDays) - 1) / 7))

        If IsNumeric(txt_antiguedad.Text) And txt_antiguedad.Text > 100 Then
            txt_antiguedad.Text = CInt(txt_antiguedad.Text) - 1
        End If

    End Sub

    Private Sub grid_percepciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grid_percepciones.CellEndEdit

        SendKeys.Send("{TAB}")

        inicia_calculo_percepciones()
        grid_percepciones.CurrentRow.Cells(3).Value = Val(grid_percepciones.CurrentRow.Cells(1).Value.ToString) + Val(grid_percepciones.CurrentRow.Cells(2).Value.ToString)

    End Sub

    Private Sub inicia_calculo_percepciones()

        On Error GoTo marca
        Dim contador = 0
        txt_percepciones.Text = "0"
        txt_percepciones_gravado.Text = "0"
        txt_percepciones_exento.Text = "0"
        For i = 0 To grid_percepciones.Rows.Count - 1

            If grid_percepciones.Rows(contador).Cells(1).Value.ToString = "" Then
                grid_percepciones.Rows(contador).Cells(1).Value = "0"
            End If

            If grid_percepciones.Rows(contador).Cells(2).Value.ToString = "" Then
                grid_percepciones.Rows(contador).Cells(2).Value = "0"
            End If

            If grid_percepciones.Rows(contador).Cells(3).Value.ToString = "" Then
                grid_percepciones.Rows(contador).Cells(3).Value = "0"
            End If
            suma_percepciones_gravado(grid_percepciones.Rows(contador).Cells(1).Value.ToString)
            suma_percepciones_exento(grid_percepciones.Rows(contador).Cells(2).Value.ToString)
            'suma_percepciones(grid_percepciones.Rows(contador).Cells(3).Value.ToString)
            contador = contador + 1
        Next

marca:

    End Sub

    Private Sub suma_percepciones_gravado(ByVal dato As String)
        If dato = "" Then dato = "0"
        If grid_percepciones.Rows.Count > 0 Then
            txt_percepciones_gravado.Text = Val(dato) + Val(txt_percepciones_gravado.Text)

        End If
    End Sub

    Private Sub suma_percepciones_exento(ByVal dato As String)

        If grid_percepciones.Rows.Count > 0 Then
            txt_percepciones_exento.Text = Val(dato) + Val(txt_percepciones_exento.Text)

        End If
    End Sub

    Private Sub grid_deducciones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grid_deducciones.CellEndEdit
        On Error GoTo marca

        Dim contador = 0

        txt_deducciones.Text = "0"

        For i = 0 To grid_deducciones.Rows.Count - 1

            If grid_deducciones.Rows(i).Cells(1).Value.ToString = "" Then
                grid_deducciones.Rows(i).Cells(1).Value = "0"
            End If
            suma_deducciones(grid_deducciones.Rows(i).Cells(1).Value.ToString)

        Next

        SendKeys.Send("{TAB}")

marca:
    End Sub

    Private Sub suma_deducciones(ByVal dato As String)

        If grid_deducciones.Rows.Count > 0 Then
            txt_deducciones.Text = Val(dato) + Val(txt_deducciones.Text)
        End If

    End Sub

    Private Sub resultado_recibo()
        txttotalpagar.Text = Val(txt_percepciones.Text) - Val(txt_deducciones.Text)
    End Sub

    Private Sub txt_percepciones_TextChanged(sender As Object, e As EventArgs) Handles txt_percepciones.TextChanged
        If txt_deducciones.Text <> "" And txt_percepciones.Text <> "" Then
            resultado_recibo()
        End If
    End Sub

    Private Sub txt_deducciones_TextChanged(sender As Object, e As EventArgs) Handles txt_deducciones.TextChanged
        If txt_deducciones.Text <> "" And txt_percepciones.Text <> "" Then
            resultado_recibo()
        End If
    End Sub

    Private Sub btn_guarda_nomina_Click(sender As Object, e As EventArgs) Handles btn_guarda_nomina.Click
        If Val(txttotalpagar.Text) > "0" Then
            txttotalpagar.Focus()
            elimina_nomina_nueva()
            llena_percepciones()
            llena_deducciones()
            llena_otropago()
            MsgBox("Nomina del Empleado Guardada Correctamente.", vbInformation)

            btnTimbrar.Focus()


        Else
            MsgBox("Error en las Percepciones o Deducciones la nomina no pude ser menor o igual a '0'")

        End If
    End Sub

    Private Sub elimina_nomina_nueva()

        Dim sinfo As String = ""
        Dim variable_empleado As Integer = grid_empleados.CurrentRow.Cells(0).Value.ToString
        Dim sSQL As String = "DELETE FROM detalle_nomina WHERE id_empleado=" & variable_empleado & " and id_nomina=0 "
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.runSp(cnn, sSQL, sinfo) Then
            Else
                ' MsgBox(sinfo)
            End If

            cnn.Close()
        End If

    End Sub

    Private Sub llena_percepciones()

        grid_percepciones.EndEdit()

        Dim cad_concepto As String = ""

        For i = 0 To grid_percepciones.Rows.Count - 1
            cad_concepto = ""
            busca_concepto_percepcion(grid_percepciones.Rows(i).Cells(0).Value.ToString, cad_concepto)
            Try
                guarda_detalle_nomina(grid_empleados.CurrentRow.Cells(0).Value.ToString, "0", grid_percepciones.Rows(i).Cells(3).Value.ToString, grid_percepciones.Rows(i).Cells(1).Value.ToString, grid_percepciones.Rows(i).Cells(2).Value.ToString, cad_concepto, grid_percepciones.Rows(i).Cells(0).Value.ToString, "")

            Catch ex As Exception

            End Try

        Next

    End Sub

    Private Sub busca_concepto_percepcion(ByVal dato As String, ByRef cadena As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "Select atpc_descripcion from Tipo_Percepcion_contable where atpc_id='" & dato & "'"
        Dim dr As DataRow

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                cadena = dr("atpc_descripcion").ToString

            Else
                ' MsgBox(sinfo)
            End If
            cnn.Close()
        End If

    End Sub
    Private Sub guarda_detalle_nomina(ByVal empleado As Integer, ByVal nomina As String, ByVal importe As String, ByVal gravado As String, ByVal exento As String,
                                      ByVal concepto As String, Optional ByVal percepcion As String = "", Optional ByVal deduccion As String = "", Optional ByVal otrop As String = "")
        Dim sinfo As String = ""
        Dim variable_empleado As Integer = grid_empleados.CurrentRow.Cells(0).Value.ToString
        Dim sSQL As String = "insert into detalle_nomina (id_empleado,id_percepcion,id_deduccion,importe,id_nomina,gravado,exento,fecha,concepto,id_otropago)values(" & empleado &
                             ", '" & percepcion & "', '" & deduccion & "', " & importe & ", " & nomina & ", '" & gravado & "', '" & exento & "', '" & Format(Date.Now, "yyyy/MM/dd HH:mm") & "','" & concepto & "','" & otrop & "')"


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then

            Else
                MsgBox(sinfo)
            End If

            cnn.Close()
        End If


    End Sub
    Private Sub llena_deducciones()

        grid_deducciones.EndEdit()
        Dim datas As String = ""
        Dim cad_concepto As String = ""
        For i = 0 To grid_deducciones.Rows.Count - 1
            cad_concepto = ""
            datas = grid_deducciones.Rows(i).Cells(0).Value.ToString
            busca_concepto_deduccion(datas, cad_concepto)

            If grid_deducciones.Rows(i).Cells(0).Value <> Nothing And grid_deducciones.Rows(i).Cells(1).Value <> Nothing Then
                guarda_detalle_nomina(grid_empleados.CurrentRow.Cells(0).Value.ToString, "0", grid_deducciones.Rows(i).Cells(1).Value.ToString, grid_deducciones.Rows(i).Cells(1).Value.ToString, "", cad_concepto, "", grid_deducciones.Rows(i).Cells(0).Value.ToString)
            End If

        Next

    End Sub

    Private Sub busca_concepto_deduccion(ByVal dato As String, ByRef cadena As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT atdc_descripcion FROM tipo_deduccion_contable WHERE atdc_id='" & dato & "'"
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                cadena = dr("atdc_descripcion").ToString

            Else

                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub llena_otropago()

        grid_otrosp.EndEdit()
        Dim datas As String = ""
        Dim cad_concepto As String = ""
        For i = 0 To grid_otrosp.Rows.Count - 1
            cad_concepto = ""
            datas = grid_otrosp.Rows(i).Cells(0).Value.ToString
            busca_concepto_otrospags(datas, cad_concepto)

            If grid_otrosp.Rows(i).Cells(0).Value > 0 And IsNumeric(grid_otrosp.Rows(i).Cells(1).Value) Then
                guarda_detalle_nomina(grid_empleados.CurrentRow.Cells(0).Value.ToString, "0", grid_otrosp.Rows(i).Cells(1).Value.ToString, "", "", cad_concepto, "", "", grid_otrosp.Rows(i).Cells(0).Value.ToString)
            End If

        Next

    End Sub

    Private Sub busca_concepto_otrospags(ByVal dato As String, ByRef cadena As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT descripcion FROM otrospagos WHERE clave='" & dato & "'"
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                cadena = dr("descripcion").ToString

            Else

                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub datos_empresa_nomina(ByRef rfc_e As String, ByRef calle_e As String, ByRef no_exterior_e As String, ByRef colonia_e As String, ByRef municipio_e As String,
                                     ByRef estado_e As String, ByRef cp_e As String, ByRef regimen_e As String, ByRef registro_patronal_e As String,
                                     ByRef ruta_certificado_e As String, ByRef ruta_key_e As String, ByRef pass_key_e As String, ByRef regimen_fiscal_e As String)


        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT Em_rfcm,Em_calle,Em_NumExterior,Em_colonia,Em_Municipio,Em_Estado,Em_CP,Em_RFiscal,Em_registro_patronal,emi_cer,emi_key,emi_psw,emi_pfx,Em_RFiscal,Em_serieN, FROM datosnegocio WHERE Emisor_id=" & cboEmpresa.SelectedValue
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                rfc_e = dr("Em_rfc").ToString
                calle_e = dr("Em_calle").ToString
                no_exterior_e = dr("Em_NumExterior").ToString
                colonia_e = dr("Em_colonia").ToString
                municipio_e = dr("Em_Municipio").ToString
                estado_e = dr("Em_Estado").ToString
                cp_e = dr("Em_CP").ToString
                regimen_e = dr("Em_RFiscal").ToString
                registro_patronal_e = dr("Em_registro_patronal").ToString
                ruta_certificado_e = dr("emi_cer").ToString
                ruta_key_e = dr("emi_key").ToString
                glob_pass_key = dr("emi_psw").ToString
                pass_key_e = dr("emi_pfx").ToString
                regimen_fiscal_e = dr("Em_RFiscal").ToString
                If dr("Em_serieN").ToString = "" Then
                    serie_nomina = dr("Em_serieN").ToString
                End If


            Else

                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub datos_empleado_nomina(ByVal id_emp_e As Integer, ByRef rfc_e As String, ByRef nombre_e As String, ByRef calle_e As String, ByRef no_exterior_e As String, ByRef colonia_e As String, ByRef municipio_e As String,
                                     ByRef estado_e As String, ByRef cp_e As String, ByRef regimen_e As String, ByRef curp_e As String, ByRef nns_e As String,
                                     ByRef departamento_e As String, ByRef clabe_e As String, ByRef banco_e As String, ByRef inicio_lab_e As Date, ByRef antiguedad_e As String,
                                     ByRef tipo_contrato_e As String, ByRef tipo_jornada_e As String, ByRef periodicidad_pago_e As String, ByRef salario_diario_e As String,
                                     ByRef riesgo_e As String, ByRef puesto_e As String, ByRef tipo_pago_e As String)


        maiemp = ""
        Dim sinfo As String = ""
        Dim sSQL As String = "Select Nombre,Rfc,Calle,NumExt,Colonia,Delegacion,Entidad,Cp,Emp_Regimen,Curp,NSS,Area,ClaveP,Banco,Ingreso,Emp_Contrato,Emp_Jornada,Emp_Periodo,Sueldoxdia,Emp_Riesgo,Puesto,FormaPago,Correo from usuarios where idEmpleado=" & id_emp_e
        Dim dr As DataRow

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                nombre_e = dr("Nombre").ToString
                rfc_e = dr("Rfc").ToString
                calle_e = dr("Calle").ToString
                no_exterior_e = dr("NumExt").ToString
                colonia_e = dr("Colonia").ToString
                municipio_e = dr("Delegacion").ToString
                estado_e = dr("Entidad").ToString
                cp_e = dr("Cp").ToString
                regimen_e = dr("Emp_Regimen").ToString
                curp_e = dr("Curp").ToString
                nns_e = dr("NSS").ToString
                departamento_e = dr("Area").ToString
                clabe_e = dr("ClaveP").ToString
                banco_e = dr("Banco").ToString
                inicio_lab_e = dr("Ingreso").ToString
                '   MsgBox(CDate(dtfecha_pago.Value) - CDate(dr("emp_fecha_ingreso").ToString))
                antiguedad_e = CInt((((CDate(dtfecha_pago.Value) - CDate(dr("Ingreso").ToString)).TotalDays) - 1) / 7)
                tipo_contrato_e = dr("Emp_Contrato").ToString
                tipo_jornada_e = dr("Emp_Jornada").ToString
                periodicidad_pago_e = dr("Emp_Periodo").ToString
                salario_diario_e = dr("Sueldoxdia").ToString
                riesgo_e = dr("Emp_Riesgo").ToString
                puesto_e = dr("Puesto").ToString
                tipo_pago_e = dr("FormaPago").ToString
                maiemp = dr("Correo").ToString


            Else

                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click
        ProgressBar1.Visible = True
        lbl_evento.Visible = True
        lbl_evento.Text = "Validando ..."
        ProgressBar1.Value = 10
        My.Application.DoEvents()
        If valida() Then
            vistarec = True
            lbl_evento.Text = "Guardando datos Temporales"
            ProgressBar1.Value = 20
            My.Application.DoEvents()
            timbrar_nomina(grid_empleados.CurrentRow.Cells(0).Value.ToString)
            cboEmpresa.DataSource = Nothing
            llena_combo_empresa()
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub timbrar_nomina(ByVal empleado_timbrado As Integer)


        Dim folio_ac As String = ""

        Dim metodo_p_ac As String = "NA"
        cadena_pagos1 = "NA"

        Dim estado_ac As String = ""
        Dim rfc_ac As String = ""
        Dim calle_ac As String = ""
        Dim nexterior_ac As String = ""
        Dim colonia_ac As String = ""
        Dim municipio_ac As String = ""
        Dim cp_ac As String = ""
        Dim regimen_ac As String = ""
        Dim registro_patronal_ac As String = ""
        Dim ruta_certificado_ac As String = ""
        Dim ruta_key_ac As String = ""
        Dim pass_key_ac As String = ""
        Dim reg_fiscal_ac As String = ""

        datos_empresa_nomina(rfc_ac, calle_ac, nexterior_ac, colonia_ac, municipio_ac, estado_ac, cp_ac, regimen_ac, registro_patronal_ac, ruta_certificado_ac, ruta_key_ac, pass_key_ac, reg_fiscal_ac)

        busca_folio(folio_ac)
        folio_ac = Val(folio_ac) + 1

        Dim curp_ace As String = ""
        Dim nss_ace As String = ""
        Dim nombre_ace As String = ""
        Dim estado_ace As String = ""
        Dim rfc_ace As String = ""
        Dim calle_ace As String = ""
        Dim nexterior_ace As String = ""
        Dim colonia_ace As String = ""
        Dim municipio_ace As String = ""
        Dim cp_ace As String = ""
        Dim regimen_ace As String = ""
        Dim id_ace As String = empleado_timbrado
        Dim departamento_ace As String = ""
        Dim puesto_ace As String = ""
        Dim clabe_ace As String = ""
        Dim banco_ace As String = ""
        Dim inicio_lab_ace As Date
        Dim antiguedad_ace As String = ""
        Dim tipo_contrato_ace As String = ""
        Dim tipo_jornada_ace As String = ""
        Dim periodicidad_pago_ace As String = ""
        Dim salario_diario_ace As String = ""
        Dim riesgo_puesto_ace As String = ""
        Dim detalle_ace As String = "0"
        Dim tipo_pago_ace As String = ""
        Dim cuenta_ace As String = ""

        lbl_evento.Text = "Obtiene Datos ..."
        ProgressBar1.Value = 20
        My.Application.DoEvents()

        datos_empleado_nomina(id_ace, rfc_ace, nombre_ace, calle_ace, nexterior_ace, colonia_ace, municipio_ace, estado_ace, cp_ace, regimen_ace, curp_ace, nss_ace,
                              departamento_ace, clabe_ace, banco_ace, inicio_lab_ace, antiguedad_ace, tipo_contrato_ace, tipo_jornada_ace, periodicidad_pago_ace, salario_diario_ace,
                              riesgo_puesto_ace, puesto_ace, tipo_pago_ace)

        Dim var_t_gravado_percepcio As Double = 0
        Dim var_t_exento_percepcio As Double = 0
        Dim var_t_gravado_deduccion As Double = 0
        Dim var_t_percepcio As Double = 0
        Dim var_total_t As Double = 0
        Dim var_total_otros As Double = 0

        id_detalle_nom_a(id_ace, detalle_ace)
        calcula_totales_n(id_ace, detalle_ace, var_t_gravado_percepcio, var_t_exento_percepcio, var_t_gravado_deduccion, var_t_percepcio, var_total_t, var_total_otros)

        lbl_evento.Text = "Generando Archivo Base ..."
        ProgressBar1.Value = 30
        My.Application.DoEvents()

        GeneraXML_nomina4(folio_ac, serie_nomina, var_t_percepcio + var_total_otros, var_t_gravado_deduccion, var_total_t, metodo_p_ac, "Mexico", estado_ac, rfc_ac, cboEmpresa.Text, calle_ac, nexterior_ac, colonia_ac,
         municipio_ac, estado_ac, "Mexico", cp_ac, regimen_ac, rfc_ace, nombre_ace, nexterior_ace, curp_ace, regimen_ace, nss_ace, Format(dtfecha_pago.Value, "yyyy-MM-dd"),
         Format(DTDel.Value, "yyyy-MM-dd"), Format(DTAl.Value, "yyyy-MM-dd"), txtdiaspagados.Text, departamento_ace, clabe_ace, banco_ace, Format(inicio_lab_ace, "yyyy-MM-dd"),
        CInt(antiguedad_ace), puesto_ace, tipo_contrato_ace, tipo_jornada_ace, periodicidad_pago_ace, salario_diario_ace, riesgo_puesto_ace, calle_ace, colonia_ace, municipio_ace,
         cp_ace, id_ace, regimen_ac, registro_patronal_ac, var_t_exento_percepcio, var_t_gravado_percepcio, folio_ac, ruta_certificado_ac, ruta_key_ac, pass_key_ac,
         detalle_ace, regimen_ac, tipo_pago_ace, cboEmpresa.SelectedValue, var_total_otros, cbo_tiponomina.SelectedValue)



    End Sub

    Private Function valida()

        If grid_empleados.Rows.Count = 0 Then
            MsgBox("No Existe Empleado Para Timbrar")
            Return False
        End If

        If Not checatnom(txtRFCEmisor.Text) Then
            Return False
        End If

        Return True
    End Function

    Private Sub id_detalle_nom_a(ByVal id_emp_e As Integer, ByRef id_detalle_nom As Integer)

        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT id_empleado FROM detalle_nomina WHERE id_empleado=" & id_emp_e & " and id_nomina=0"
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                id_detalle_nom = 0

            Else

                sSQL = "SELECT Max(id_nomina) as Ma FROM detalle_nomina WHERE id_empleado=" & id_emp_e


                If odata.getDr(cnn, dr, sSQL, sinfo) Then
                    If dr("Ma").ToString <> "" Then
                        id_detalle_nom = dr("Ma").ToString
                    Else
                        id_detalle_nom = 0
                    End If

                Else
                    id_detalle_nom = 0
                End If

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub calcula_totales_n(ByVal idac_empleadoo As Integer, ByVal id_det As Integer, ByRef var_t_gravado_percepcio As Double, ByRef var_t_exento_percepcio As Double, ByRef var_t_gravado_deduccion As Double, ByRef var_t_percepcio As Double, ByRef var_total_t As Double, ByRef var_t_otros As Double)


        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT id_percepcion,importe,gravado,exento,id_deduccion,id_otropago FROM detalle_nomina WHERE id_empleado=" & idac_empleadoo & " AND id_nomina=" & id_det
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDt(cnn, dt, sSQL, sinfo) Then

                For Each dr In dt.Rows

                    If dr("id_percepcion").ToString <> "" Then

                        var_t_percepcio = var_t_percepcio + Val(dr("importe").ToString)

                        If dr("gravado").ToString <> "0" Then

                            var_t_gravado_percepcio = var_t_gravado_percepcio + dr("gravado").ToString

                        End If

                        If dr("exento").ToString <> "0" Then

                            var_t_exento_percepcio = var_t_exento_percepcio + dr("exento").ToString

                        End If

                    End If

                    If dr("id_deduccion").ToString <> "" Then

                        var_t_gravado_deduccion = var_t_gravado_deduccion + Val(dr("importe").ToString)

                    End If

                    If dr("id_otropago").ToString <> "" Then

                        var_t_otros = var_t_otros + Val(dr("importe").ToString)

                    End If

                Next

                var_total_t = var_t_percepcio - var_t_gravado_deduccion + var_t_otros

            End If

            cnn.Close()
        End If

    End Sub

    Private Sub btnTimbrarMasivo_Click(sender As Object, e As EventArgs) Handles btnTimbrarMasivo.Click

        Exit Sub

        If checat(txtRFCEmisor.Text) Then


            If valida() Then
                vistarec = False
                For i = 0 To grid_empleados.Rows.Count - 1

                    timbrar_nomina(grid_empleados.Rows(i).Cells(0).Value.ToString)
                Next
                cboEmpresa.DataSource = Nothing
                llena_combo_empresa()
            End If
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim d As Integer = grid_deducciones.Rows.Count
        grid_deducciones.Rows.Insert(d, "", "0", "0", "0")
    End Sub

    Private Sub grid_deducciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_deducciones.CellContentClick

    End Sub

    Private Sub grid_empleados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_empleados.CellContentClick

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuNomina.Show()
    End Sub

    Private Sub txt_percepciones_gravado_TextChanged(sender As Object, e As EventArgs) Handles txt_percepciones_gravado.TextChanged
        txt_percepciones.Text = ConvertCero(txt_percepciones_gravado.Text) + ConvertCero(txt_percepciones_exento.Text) + ConvertCero(txt_otros_pagos.Text)
    End Sub

    Private Sub txt_percepciones_exento_TextChanged(sender As Object, e As EventArgs) Handles txt_percepciones_exento.TextChanged
        txt_percepciones.Text = ConvertCero(txt_percepciones_gravado.Text) + ConvertCero(txt_percepciones_exento.Text) + ConvertCero(txt_otros_pagos.Text)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim d As Integer = grid_otrosp.Rows.Count
        grid_otrosp.Rows.Insert(d, "", "0", "0", "0")
    End Sub

    Private Sub grid_otrosp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_otrosp.CellContentClick

    End Sub

    Private Sub grid_otrosp_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grid_otrosp.CellEndEdit
        SendKeys.Send("{TAB}")


        inicia_calculo_otrosp()
    End Sub

    Private Sub inicia_calculo_otrosp()

        On Error GoTo marca
        Dim contador = 0
        txt_otros_pagos.Text = "0"

        For i = 0 To grid_otrosp.Rows.Count - 1

            If grid_otrosp.Rows(i).Cells(1).Value.ToString = "" Then
                grid_otrosp.Rows(i).Cells(1).Value = "0"
            End If
            txt_otros_pagos.Text = CDbl(txt_otros_pagos.Text) + CDbl(grid_otrosp.Rows(i).Cells(1).Value)

        Next

marca:

    End Sub

    Private Sub txt_otros_pagos_TextChanged(sender As Object, e As EventArgs) Handles txt_otros_pagos.TextChanged
        txt_percepciones.Text = ConvertCero(txt_percepciones_gravado.Text) + ConvertCero(txt_percepciones_exento.Text) + ConvertCero(txt_otros_pagos.Text)
    End Sub

    Private Sub txt_retenidos_TextChanged(sender As Object, e As EventArgs) Handles txt_retenidos.TextChanged

    End Sub

    Private Sub txttotalpagar_TextChanged(sender As Object, e As EventArgs) Handles txttotalpagar.TextChanged
        Dim contador As Integer = 0
        Dim tisr As String = "0"

        For Each DataGridViewRow In grid_deducciones.Rows

            If grid_deducciones.Rows(contador).Cells(0).Value.ToString = "002" And grid_deducciones.Rows(contador).Cells(1).Value.ToString <> "" Then

                tisr = tisr + CDec(grid_deducciones.Rows(contador).Cells(1).Value.ToString)

            End If

            contador = contador + 1

        Next

        txt_retenidos.Text = tisr
    End Sub

    Private Sub dtfecha_pago_ValueChanged(sender As Object, e As EventArgs) Handles dtfecha_pago.ValueChanged
        calcula_anti()
    End Sub

    Private Sub btnagrega_percepcion_Click(sender As Object, e As EventArgs) Handles btnagrega_percepcion.Click
        Dim d As Integer = grid_percepciones.Rows.Count
        grid_percepciones.Rows.Insert(d, "", "0", "0", "0")
    End Sub

    Private Sub grid_percepciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid_percepciones.CellContentClick

    End Sub

    Private Sub grid_percepciones_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles grid_percepciones.RowsRemoved
        inicia_calculo_percepciones()
    End Sub

    Private Sub grid_empleados_SelectionChanged(sender As Object, e As EventArgs) Handles grid_empleados.SelectionChanged
        grid_deducciones.Rows.Clear()
        grid_percepciones.Rows.Clear()
        grid_otrosp.Rows.Clear()
        txt_otros_pagos.Text = "0"
        txt_deducciones.Text = 0
        txt_percepciones.Text = 0
        txt_percepciones_gravado.Text = 0
        txt_percepciones_exento.Text = 0

        busca_nomina_nueva()
        suma_valores()
        inicia_calculo_percepciones()
        inicia_calculo_otrosp()
        calcula_anti()
    End Sub

    Private Sub suma_valores()

        grid_deducciones.EndEdit()
        grid_percepciones.EndEdit()

        For i = 0 To grid_deducciones.Rows.Count - 1
            txt_deducciones.Text = Val(txt_deducciones.Text) + Val(grid_deducciones.Rows(i).Cells(1).Value.ToString)

        Next

        For i = 0 To grid_percepciones.Rows.Count - 1
            txt_percepciones.Text = Val(txt_percepciones.Text) + Val(grid_percepciones.Rows(i).Cells(3).Value.ToString)
            txt_percepciones_exento.Text = Val(txt_percepciones_exento.Text) + Val(grid_percepciones.Rows(i).Cells(2).Value.ToString)
            txt_percepciones_gravado.Text = Val(txt_percepciones_gravado.Text) + Val(grid_percepciones.Rows(i).Cells(1).Value.ToString)

        Next

    End Sub

    Private Sub agrega_otropago(ByVal dato1 As String, ByVal dato2 As String)

        grid_otrosp.Rows.Insert(0, dato1, dato2)

    End Sub

    Private Sub agrega_deduccion(ByVal dato1 As String, ByVal dato2 As String)

        grid_deducciones.Rows.Insert(0, dato1, dato2)

    End Sub

    Private Sub agrega_percepcion(ByVal iden As String, ByVal gravado As String, ByVal exento As String, ByVal importe As String)
        Select Case iden
            Case "016"
            Case "017"
            Case "018"
            Case Else
                grid_percepciones.Rows.Insert(0, iden, gravado, exento, importe)

        End Select

    End Sub

    Private Sub busca_nomina_nueva()

        Dim sinfo As String = ""
        'MsgBox(grid_empleados.CurrentRow.Cells("Column1").Value.ToString)
        Dim variable_empleado As Integer = grid_empleados.CurrentRow.Cells(0).Value.ToString  'grid_empleados.CurrentRow.Cells(0).Value.ToString
        Dim nomi_S As String = "0"
        id_detalle_nom_a(variable_empleado, nomi_S)
        Dim sSQL As String = "Select id_percepcion,gravado,exento,importe,id_deduccion,id_otropago from detalle_nomina where id_empleado=" & variable_empleado & " and id_nomina=" & nomi_S & " order by id_detalle Desc"
        Dim dt As New DataTable
        Dim dr As DataRow

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            If odata.getDt(cnn, dt, sSQL, sinfo) Then

                For Each dr In dt.Rows
                    If dr("id_percepcion").ToString <> "" Then

                        agrega_percepcion(dr("id_percepcion").ToString, dr("gravado").ToString, dr("exento").ToString, dr("importe").ToString)
                    Else

                    End If


                    If dr("id_deduccion").ToString <> "" Then

                        agrega_deduccion(dr("id_deduccion").ToString, dr("importe").ToString)
                    End If

                    If dr("id_otropago").ToString <> "" Then

                        agrega_otropago(dr("id_otropago").ToString, dr("importe").ToString)
                    End If

                Next

            Else
                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If
    End Sub

End Class