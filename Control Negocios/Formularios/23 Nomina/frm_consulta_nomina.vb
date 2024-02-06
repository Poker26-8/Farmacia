
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports Servisim.WS.Conector
Imports Servisim.WS.Conector.Impl
Imports System.Text
Imports ToolKitSQL
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Data.OleDb

Public Class frm_consulta_nomina

    Dim var_logo As String = ""
    Dim rfc_emisor As String = ""
    Private Sub frm_consulta_nomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error GoTo malo

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

        'dt_al.MaxDate = Date.Now
        'dt_del.MaxDate = Date.Now
        llena_combo_empresa()
        llena_combo_empleado()
        llena_grid()
        cbo_empleado.Text = ""
        cbo_empleado.Enabled = False
        dt_al.Enabled = False
        dt_del.Enabled = False
        If cbo_empresa.Items.Count < 1 Then
            MsgBox("Debe AGREGAR almenos una Empresa")
            Me.Close()

        End If
malo:
        If rfc_emisor <> "" Then
            checat(rfc_emisor)
            lbl_consumidos.Text = timbres_timbrados
            lbl_contratados.Text = timbres_totales
            lbl_restantes.Text = timbres_totales - timbres_timbrados
        Else
            lbl_consumidos.Text = "0"
            lbl_contratados.Text = "0"
            lbl_restantes.Text = "0"
        End If

    End Sub

    Private Sub llena_combo_empresa()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT * FROM datosnegocio ORDER BY Em_RazonSocial"
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cbo_empresa
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

        If cbo_empresa.Items.Count < 1 Then
        Else
            cbo_empresa.SelectedIndex = 0
            llena_combo_empleado()
        End If
    End Sub

    Private Sub llena_combo_empleado()

        Dim sSQL As String = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        If cbo_empresa.SelectedValue > 0 Then
            sSQL = "SELECT * FROM usuarios WHERE Status = 1 and Emp_empresa = " & cbo_empresa.SelectedValue & " order by Nombre"
        End If
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            With cbo_empleado
                If odata.getDs(cnn, ds, sSQL, "edos", sinfo) Then
                    .DataSource = ds.Tables("edos")
                    .ValueMember = "IdEmpleado"
                    .DisplayMember = "Nombre"
                Else
                    MsgBox(sinfo)
                End If
            End With
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
        If cbo_empleado.Items.Count > 0 Then
            cbo_empleado.SelectedIndex = 0
        Else
            MsgBox("No Existen Empleados Asignados a Esta Empresa")
        End If
    End Sub

    Private Function crea_sql() As String
        Dim ssql As String = "select * from nomina n where nom_razon_social='" & cbo_empresa.Text & "' "
        If chk_empleados.Checked = False Then
            ssql = ssql & " and nom_nombre_empleado='" & cbo_empleado.Text & "' "
        End If
        If chk_fechas.Checked = False Then
            If dt_del.Value.ToString = dt_al.Value.ToString Then
                ssql = ssql & " and nom_fecha_nomina = '" & Format(CDate(dt_del.Value.ToString), "yyyy-MM-dd") & "'"
            Else
                ssql = ssql & " and nom_fecha_nomina >= '" & Format(CDate(dt_del.Value.ToString), "yyyy-MM-dd") & "' And nom_fecha_nomina <= '" & Format(CDate(dt_al.Value.ToString), "yyyy-MM-dd") & "'"   'nom_fecha_nomina >='" & Format(dt_del.Value, "yyyy-MM-dd") & "' and nom_expedido <= '" & Format(dt_al.Value, "yyyy-MM-dd") & "'"
            End If
            'ssql = ssql & " and   nom_fecha_nomina Between Format(#" & dt_del.Value & "#,'yyyy-MM-dd') And Format(#" & dt_al.Value & "#,'yyyy-MM-dd')"   'nom_fecha_nomina >='" & Format(dt_del.Value, "yyyy-MM-dd") & "' and nom_expedido <= '" & Format(dt_al.Value, "yyyy-MM-dd") & "'"
        End If
        ssql = ssql & " Order by Id"
        Return ssql
    End Function

    Private Sub llena_grid()

        t_gravado.Text = "0.0"
        t_exento.Text = "0.0"
        t_percepcion.Text = "0.0"
        t_deducciones.Text = "0.0"
        tpagado.Text = "0.0"
        t_opagos.Text = "0.0"

        grid_nominas.Rows.Clear()
        grid_percepciones.Rows.Clear()
        grid_deducciones.Rows.Clear()
        grid_otrospagos.Rows.Clear()
        Dim fecha1 As Date = dt_del.Value
        Dim fecha2 As Date = dt_al.Value
        Dim sSQL As String = crea_sql()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim percepciones As String = ""
        Dim Estatus As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata.getDt(cnn, dt, sSQL, sinfo) Then
                For Each dr In dt.Rows
                    percepciones = ""
                    Estatus = "Timbrado"
                    If dr("nom_status").ToString = 0 Then
                        Estatus = "Timbrado"
                    Else
                        Estatus = "Cancelado"
                    End If
                    percepciones = Val(dr("nom_percepcion_exento").ToString) + Val(dr("nom_percepcion_gravado").ToString)
                    ''t_percepcion.Text = CDbl(t_percepcion.Text) + CDbl(percepciones)
                    't_deducciones.Text = CDbl(t_deducciones.Text) + CDbl(dr("nom_deduccion").ToString)

                    If chk_fechas.Checked = False Then
                        If chk_empleados.Checked = False Then
                            If dr("nom_nombre_empleado").ToString = cbo_empleado.Text Then
                                grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)
                            End If
                        Else
                            grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)
                        End If

                        'If CDate(dr("nom_fecha_nomina").ToString) >= fecha1 And CDate(dr("nom_fecha_nomina").ToString) <= fecha2 Then

                        '    If chk_empleados.Checked = False Then

                        '        If dr("nom_nombre_empleado").ToString = cbo_empleado.Text Then
                        '            grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)


                        '        End If
                        '    Else
                        '        grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)

                        '    End If

                        'End If

                    Else
                        If chk_empleados.Checked = False Then
                            If dr("nom_nombre_empleado").ToString = cbo_empleado.Text Then
                                grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)
                            End If
                        Else
                            grid_nominas.Rows.Insert(0, dr("nom_id").ToString, dr("nom_folio").ToString, dr("nom_nombre_empleado").ToString, dr("nom_total_pagado").ToString, percepciones, dr("nom_deduccion").ToString, dr("nom_fecha_nomina").ToString, Estatus, dr("nom_folio_sat_uuid").ToString, dr("nom_rfc_empresa").ToString, dr("nom_id_empleado").ToString, dr("nom_fecha_folio_sat").ToString, dr("nom_metodo_pago").ToString)
                        End If
                    End If
                    busca_detalle(dr("nom_id").ToString)
                    '   If dr("nom_rfc_empresa").ToString <> "AAA010101AAA" Then
                    rfc_emisor = dr("nom_rfc_empresa").ToString
                    '   End If
                Next
            End If
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
        tpagado.Text = CDbl(t_percepcion.Text) - CDbl(t_deducciones.Text) + CDbl(t_opagos.Text)
    End Sub

    Private Sub cancela()
        If grid_nominas.Rows.Count > 0 Then
            Try
                Dim uuid_nom As String = grid_nominas.CurrentRow.Cells(8).Value.ToString
                Dim rfc_nom As String = grid_nominas.CurrentRow.Cells(9).Value.ToString
                '  3. Cancelación de CFDi previamente timbrado.

                Dim conector As IConectorServisim = New ConectorServisimImpl()
                '//1. Establecer EndPoint de Servisim (Sin ?wsdl al final)
                'conector.establecerEndPoint("http://201.150.97.20:8080/ServisimTest/TimbradoCFDi")
                'conector.establecerSoapAction("http://controller.timbrado.ws.servisim.com/", "cancelarCFDi")
                'conector.establecerAcceso("1", "atenea1307")


                conector.establecerEndPoint("http://200.53.180.7/ServisimService/TimbradoCFDi")
                conector.establecerSoapAction("http://controller.timbrado.ws.servisim.com/", "cancelarCFDi")
                conector.establecerAcceso("173", "v4Lr0MD3ls591")


                '//2. Crear petición
                conector.crearPeticion()
                '//3. Asignar en petición
                '//3.1 Identificador del Emisor (RFC DE EMISOR)
                conector.asignarEnPeticion("Id", rfc_nom)
                '//3.2 Identificador del CFDi (UUID)
                conector.asignarEnPeticion("Xml", uuid_nom)
                '//4. consumir servicio
                conector.consumirServicio()
                '//5. Obtener datos de la respuesta
                Dim idError As Integer = conector.obtenerDeRespuesta("IdError")
                Dim error1 As String = conector.obtenerDeRespuesta("Error")
                Dim uuid As String = conector.obtenerDeRespuesta("UUID")
                Dim fechaTimbre As String = conector.obtenerDeRespuesta("FechaTimbre")
                Dim xmlTimbrado As String = conector.obtenerDeRespuesta("Xml")
                archivo_cancelado(xmlTimbrado)
                cancela_nomina()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            MsgBox("No Hay Nomina Seleccionada", MsgBoxStyle.Information, "Delsscom")
        End If
    End Sub

    Private Sub buscalogo()

        Dim sinfo As String = ""
        Dim sSQL As String = "SELECT * FROM datosnegocio WHERE Emisor_id=" & cbo_empresa.SelectedValue
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                var_logo = dr("emi_logo").ToString

            End If
            cnn.Close()
        End If

    End Sub

    Private Sub cancela_nomina()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "UPDATE nomina SET nom_status=1 WHERE nom_id=" & grid_nominas.CurrentRow.Cells(0).Value.ToString
        Dim ds As New DataSet
        Dim sinfo As String = ""

        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) = True Then

            If odata.runSp(cnn, sSQL, sinfo) Then

                llena_grid()
            End If

            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub archivo_cancelado(ByVal variable As String)
        On Error GoTo malo
        Dim path As String = "C:\ControlNegociosPro\recibos\CANCELADO_E" & cbo_empresa.SelectedValue & "_T" & grid_nominas.CurrentRow.Cells(0).Value.ToString & "_N" & grid_nominas.CurrentRow.Cells(1).Value.ToString & ".XML"

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(variable)
        fs.Write(info, 0, info.Length)
        fs.Close()
malo:
    End Sub

    Private Function validafecha()

        Dim fecha1 As Date = CDate(grid_nominas.CurrentRow.Cells(11).Value.ToString)
        Dim fecha2 As Date = fecha1.AddDays(3)

        If Now < fecha2 Then

            MsgBox("Deben Pasar 72 horas para la cancelacion del Recibo")
            Return False
        End If
        Return True

    End Function

    Private Sub calcula_datos()


        If grid_nominas.RowCount > 0 Then

            For i As Integer = 0 To grid_nominas.RowCount - 1


            Next

        End If


    End Sub

    Private Sub busca_detalle(ByVal idnom1 As String)

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT * FROM  detalle_nomina  where id_nomina=" & idnom1
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim sinfo As String = ""

        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTargetlocal, sinfo) = True Then

            If odata.getDt(cnn, dt, sSQL, sinfo) Then

                For Each dr In dt.Rows

                    If dr("id_percepcion").ToString <> "" Then

                        t_gravado.Text = CDbl(t_gravado.Text) + CDbl(dr("gravado").ToString)
                        t_exento.Text = CDbl(t_exento.Text) + CDbl(dr("exento").ToString)
                        insertagrid_percepciones(dr("id_percepcion").ToString, dr("concepto").ToString, dr("gravado").ToString, dr("exento").ToString)
                    End If

                    If dr("id_otropago").ToString <> "" Then

                        t_opagos.Text = CDbl(t_opagos.Text) + CDbl(dr("importe").ToString)
                        insertagrid_otrosp(dr("id_otropago").ToString, dr("concepto").ToString, dr("importe").ToString)

                    End If

                    If dr("id_deduccion").ToString <> "" Then

                        t_deducciones.Text = CDbl(t_deducciones.Text) + CDbl(dr("importe").ToString)

                        insertagrid_deducciones(dr("id_deduccion").ToString, dr("concepto").ToString, dr("importe").ToString)

                    End If

                Next

                t_percepcion.Text = CDbl(t_gravado.Text) + CDbl(t_exento.Text)

            End If

            cnn.Close()
        Else
            MsgBox(sinfo)
        End If

    End Sub

    Private Sub insertagrid_percepciones(ByVal clvp As String, ByVal conceptop As String, ByVal tgravado As String, ByVal texento As String)

        Dim encontrado As Boolean = False

        If grid_percepciones.RowCount > 0 Then
            For i = 0 To grid_percepciones.RowCount - 1

                If grid_percepciones.Rows(i).Cells(0).Value.ToString = clvp Then

                    grid_percepciones.Rows(i).Cells(2).Value = CDbl(grid_percepciones.Rows(i).Cells(2).Value) + CDbl(texento)
                    grid_percepciones.Rows(i).Cells(3).Value = CDbl(grid_percepciones.Rows(i).Cells(3).Value) + CDbl(tgravado)
                    grid_percepciones.Rows(i).Cells(4).Value = CDbl(grid_percepciones.Rows(i).Cells(2).Value) + CDbl(grid_percepciones.Rows(i).Cells(3).Value)
                    encontrado = True
                    Exit Sub
                End If

            Next

            If encontrado = False Then
                grid_percepciones.Rows.Insert(0, clvp, conceptop, texento, tgravado, (CDbl(tgravado) + CDbl(texento)))
            End If

        Else
            grid_percepciones.Rows.Insert(0, clvp, conceptop, texento, tgravado, (CDbl(tgravado) + CDbl(texento)))
        End If

    End Sub

    Private Sub insertagrid_deducciones(ByVal clvp As String, ByVal conceptop As String, ByVal timporte As String)

        Dim encontrado As Boolean = False

        If grid_deducciones.RowCount > 0 Then

            For i = 0 To grid_deducciones.RowCount - 1

                If grid_deducciones.Rows(i).Cells(0).Value.ToString = clvp Then

                    grid_deducciones.Rows(i).Cells(2).Value = CDbl(grid_deducciones.Rows(i).Cells(2).Value) + CDbl(timporte)

                    encontrado = True
                    Exit Sub
                End If

            Next

            If encontrado = False Then

                grid_deducciones.Rows.Insert(0, clvp, conceptop, timporte)

            End If

        Else
            grid_deducciones.Rows.Insert(0, clvp, conceptop, timporte)
        End If

    End Sub

    Private Sub insertagrid_otrosp(ByVal clvp As String, ByVal conceptop As String, ByVal timporte As String)

        Dim encontrado As Boolean = False

        If grid_otrospagos.RowCount > 0 Then

            For i = 0 To grid_otrospagos.RowCount - 1

                If grid_otrospagos.Rows(i).Cells(0).Value.ToString = clvp Then

                    grid_otrospagos.Rows(i).Cells(2).Value = CDbl(grid_otrospagos.Rows(i).Cells(2).Value) + CDbl(timporte)

                    encontrado = True
                    Exit Sub
                End If

            Next

            If encontrado = False Then

                grid_otrospagos.Rows.Insert(0, clvp, conceptop, timporte)

            End If

        Else
            grid_otrospagos.Rows.Insert(0, clvp, conceptop, timporte)
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmMenuNomina.Show()
    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        ' If validafecha() Then
        Dim uuid_nom As String = grid_nominas.CurrentRow.Cells(8).Value.ToString
        Dim rfc_nom As String = grid_nominas.CurrentRow.Cells(9).Value.ToString
        Dim foln As String = grid_nominas.CurrentRow.Cells(9).Value.ToString
        cancela_profact(rfc_nom, uuid_nom, foln)
        cancela_nomina()
        '   End If
    End Sub

    Private Sub btn_consulta_Click(sender As Object, e As EventArgs) Handles btn_consulta.Click
        vistarec = True
        cadena_pagos1 = "NA"
        Dim strMyString As String = grid_nominas.CurrentRow.Cells(12).Value.ToString
        If grid_nominas.Rows.Count > 0 Then

            buscalogo()
            Dim folio_nom = grid_nominas.CurrentRow.Cells(1).Value.ToString
            Dim rfc_nom As String = grid_nominas.CurrentRow.Cells(9).Value.ToString
            Dim id_emp_nom As String = grid_nominas.CurrentRow.Cells(10).Value.ToString


            If strMyString.Contains("01") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "01 Efectivo"
            End If

            If strMyString.Contains("02") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "02 Cheque Nominativo"
            End If

            If strMyString.Contains("03") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "03 Tarjeta electronica de fondos"
            End If

            If strMyString.Contains("04") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "04 Tarjeta de Credito"
            End If

            If strMyString.Contains("05") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "05 Monedero Electronico"
            End If

            If strMyString.Contains("06") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "06 Dinero Electronico"
            End If

            If strMyString.Contains("08") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "08 Vales de Despensa"
            End If

            If strMyString.Contains("28") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "28 Tarjeta de Debito"
            End If

            If strMyString.Contains("29") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "29 Tarjeta de Servicio"
            End If

            If strMyString.Contains("99") Then
                If cadena_pagos1 <> "" Then cadena_pagos1 &= ", "
                cadena_pagos1 &= "99 Otros"
            End If

            'cadena_pagos1 = grid_nominas.CurrentRow.Cells(12).Value.ToString
            nomina_id1 = grid_nominas.CurrentRow.Cells(0).Value.ToString
            frmPrintRecibo.folio_nomina = folio_nom
            frmPrintRecibo.empleado_id = id_emp_nom

            frmPrintRecibo.param_cant_letra = convLetras(grid_nominas.CurrentRow.Cells(3).Value.ToString)
            frmPrintRecibo.logo_empresa = var_logo
            crea_dir(Application.StartupPath & "\recibos")
            Dim xsa As String = Application.StartupPath & "\recibos\RECIBO_E" & cbo_empresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf"
            frmPrintRecibo.ViewRecibo(Application.StartupPath & "\recibos\RECIBO_E" & cbo_empresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf")
        Else
            MsgBox("No Hay Nomina Seleccionada", MsgBoxStyle.Information, "Delsscom")
        End If
    End Sub
End Class