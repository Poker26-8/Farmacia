
Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports Servisim.WS.Conector
Imports Servisim.WS.Conector.Impl
Imports Profact.TimbraCFDI33
Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.Globalization
Imports Core.Common
Imports DGMCTimbre.ECodexSrvSeg
Imports MySql.Data
Module Rutinas

    Public glob_percepcion As String
    Public glob_percepcion_importe As String
    Public glob_deduccion As String
    Public glob_deduccion_importe As String
    Public glob_certificado_empresa As String
    Public glob_numero_decertificado_empresa As String
    Public glob_sello_cfdi As String
    Public var_logo As String = ""
    Public nomina_id1 As String = ""
    Public maiemp As String = ""
    'Public cadena_pagos1 As String = ""

    Public sTargetd2 As String = "server=174.136.30.136;uid=delsscom_Delsscom22;password=AlbertoJipl2211;database=delsscom_Control_Timbres;persist security info=false;connect timeout=300"


    Public serie_gen As String = ""
    Public vistarec As Boolean = False

    Dim nombree As String = ""
    Dim cuentamail As String = ""
    Dim passmail As String = ""
    Dim servidor As String = ""
    Dim puerto As String = ""
    Dim correo2 As String = ""
    Dim seguridad As Boolean = False

    Dim selloCFDI2 As String = ""
    Dim selloSAT2 As String = ""
    Dim varNomIdNom As String = ""

    Public serie_nomina As String = "B"

    Public cuenta_ As Integer = 0


    Public Sub GeneraXML_nomina(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                                ByVal deducciones As String, ByVal total As String, ByVal metodo_pago As String,
                                ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                                ByVal calle_empresa As String, ByVal num_empresa As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                                ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                                ByVal rfc_empreado As String, ByVal nombre_empleado As String, ByVal numero_domicilio_empleado As String,
                                ByVal curp_empleado As String, ByVal regimen_empleado As String, ByVal nss_empleado As String, ByVal fecha_pago As String,
                                ByVal fecha_inicio As String, ByVal fecha_fin As String, ByVal dias_pagados As String, ByVal departamento As String,
                                ByVal clabe As String, ByVal banco As String, ByVal fecha_inicio_laboral As String, ByVal antiguedad As String, ByVal puesto_empleado As String,
                                ByVal tipo_contrato As String, ByVal tipo_jornada As String, ByVal periodo_pago As String, ByVal salario_base As String,
                                ByVal riesgo_puesto As String, ByVal calle_empleado As String, ByVal colonia_empleado As String, ByVal municipio_empleado As String,
                                ByVal cp_empleado As String, ByVal numero_empleado As String, ByVal regimen_empresa As String, ByVal registro_patronal As String,
                                ByVal grabado_percepcion As String, ByVal exento_percepcion As String, ByVal num_nomina As String, ByVal ruta_certificado As String,
                                ByVal ruta_key As String, ByVal pass_key As String, ByVal detalle_nomina As String, ByVal reg_fiscal As String, ByVal tipo_pago_e As String,
                                ByVal id_empresa As Integer, ByVal totalotrospag As String, ByVal tipo_nomina As String)
        'ByVal no_certificado As String, ByVal sello As String, _

        Dim nombreCFD As String = "E" & id_empresa & "_T" & numero_empleado & "_N" & serie & folio & ".xml"

        Dim miXml As XmlTextWriter = New XmlTextWriter(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD, System.Text.Encoding.UTF8)
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechacreacion As DateTime = Now

        fechaFormateada = DateAndTime.Now.ToString("s")
        '        fechaFormateada = fechacreacion.ToString("yyyy-MM-ddThh:mm:ss")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-dd")

        With miXml

            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE

            .WriteStartElement("cfdi:Comprobante")

            'aqui empece
            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(cp_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("MetodoPago")
            .WriteValue("PUE")
            '.WriteValue(metodo_pago)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            .WriteValue("N")
            '.WriteValue("egreso")
            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("" & Format(CDec(total), "####0.00"))
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("MXN")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue(Format(CDec(subtotal), "####0.00"))
            .WriteEndAttribute()


            .WriteStartAttribute("FormaPago")
            .WriteValue("99")
            '.WriteValue("PAGO EN UNA SOLA EXHIBICION")
            .WriteEndAttribute()

            .WriteStartAttribute("TipoCambio")
            .WriteValue("1")
            .WriteEndAttribute()

            If deducciones > 0 Then
                .WriteStartAttribute("Descuento")
                .WriteValue(Format(CDec(deducciones), "####0.00"))
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("xmlns:nomina12")
            .WriteValue("http://www.sat.gob.mx/nomina12")
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue(fechaFormateada)
            .WriteEndAttribute()

            If folio <> "" Then
                .WriteStartAttribute("Folio")
                .WriteValue(folio)
                .WriteEndAttribute()
            End If


            If serie <> "" Then
                .WriteStartAttribute("Serie")
                .WriteValue(serie)
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("Version")
            .WriteValue("3.3")
            .WriteEndAttribute()

            .WriteStartAttribute("xsi:schemaLocation")
            .WriteValue("http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/3")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            Dim odata As New ToolKitSQL.myssql
            '//////
            Dim dr2x As DataRow
            Dim sinfo2 As String = ""
            Dim ssql2 As String = "SELECT Emp_curp FROM datosnegocio WHERE Em_rfc='" & rfc_empresa & "'"
            Dim curpempresa As String = ""
            Dim cnn2 As MySqlClient.MySqlConnection
            If odata.dbOpen(cnn2, sTargetlocal, sinfo2) Then

                If odata.getDr(cnn2, dr2x, ssql2, sinfo2) Then

                    curpempresa = dr2x("CURP").ToString

                Else

                    ' MsgBox(sinfo)

                End If

                cnn2.Close()
            End If

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")

            .WriteStartAttribute("Nombre")
            .WriteValue(razon_social)
            .WriteEndAttribute()

            .WriteStartAttribute("Rfc")
            .WriteValue(rfc_empresa)
            .WriteEndAttribute()
            If Len(rfc_empresa) = 13 Then
                '   .WriteAttributeString("curp", curpempresa) '*

            End If
            '.WriteStartElement("cfdi:RegimenFiscal") ' regimen fiscal inicia
            .WriteAttributeString("RegimenFiscal", reg_fiscal) ' Clave regimen

            '.WriteEndElement() 'Regimen
            .WriteEndElement() 'Emisor


            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Nombre", nombre_empleado)
            .WriteAttributeString("Rfc", rfc_empreado)
            .WriteAttributeString("UsoCFDI", "P01")
            ' .WriteAttributeString("curp", curp_empleado) '*
            .WriteEndElement() 'receptor
            '=========================== COMIENZA CONCEPTO

            .WriteStartElement("cfdi:Conceptos")
            .WriteStartElement("cfdi:Concepto")

            .WriteAttributeString("ClaveProdServ", "84111505")
            .WriteAttributeString("Importe", Format(CDec(subtotal), "####0.00"))
            .WriteAttributeString("ValorUnitario", Format(CDec(subtotal), "####0.00"))
            .WriteAttributeString("Descripcion", "Pago de nómina")
            .WriteAttributeString("ClaveUnidad", "ACT")
            .WriteAttributeString("Cantidad", "1")
            If deducciones > 0 Then
                .WriteAttributeString("Descuento", Format(CDec(deducciones), "####0.00"))
            End If

            .WriteEndElement()
            .WriteEndElement()


            '=============fin conceptos

            '===================================== INICIA IMPUESTOS

            If nss_empleado = "" Then
                nss_empleado = "S/N"
            End If

            '======================================== INICIA NOMINA
            .WriteStartElement("cfdi:Complemento")

            .WriteStartElement("nomina12:Nomina") 'Nomina 100
            If totalotrospag > 0 Then
                .WriteAttributeString("TotalOtrosPagos", totalotrospag) '*
            Else
                If frmNomina_Empleado.grid_otrosp.RowCount > 0 Then
                    .WriteAttributeString("TotalOtrosPagos", totalotrospag) '*
                End If
            End If


            If deducciones > 0 Then
                .WriteAttributeString("TotalDeducciones", deducciones) '*
            End If


            Dim totalpa As String = ""

            totalpa = CDec(exento_percepcion) + CDec(grabado_percepcion)

            .WriteAttributeString("TotalPercepciones", Replace(totalpa, ",", "")) '*
            .WriteAttributeString("NumDiasPagados", dias_pagados) '*
            .WriteAttributeString("FechaInicialPago", fecha_inicio) '*
            .WriteAttributeString("FechaFinalPago", fecha_fin) '*
            .WriteAttributeString("FechaPago", fecha_pago) '*
            .WriteAttributeString("TipoNomina", tipo_nomina) '*

            .WriteAttributeString("Version", "1.2") '*


            '=================== Emisor nomina12  
            .WriteStartElement("nomina12:Emisor")
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("RegistroPatronal", registro_patronal) '*
            End If
            If Len(rfc_empresa) = 13 Then
                .WriteAttributeString("Curp", curpempresa) '*
            End If
            .WriteEndElement()
            'fin emi
            '==============Receptor nom12

            .WriteStartElement("nomina12:Receptor")

            '.WriteAttributeString("RfcPatronOrigen", rfc_empresa) '*
            '.WriteAttributeString("RegistroPatronal", registro_patronal) '*
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("NumSeguridadSocial", nss_empleado) '0
            End If
            .WriteAttributeString("SalarioDiarioIntegrado", Format(CDec(salario_base), "####0.00")) '0
            .WriteAttributeString("RiesgoPuesto", riesgo_puesto) '0
            .WriteAttributeString("ClaveEntFed", estado) '*
            If clabe <> "" Then
                '.WriteAttributeString("CuentaBancaria", clabe) '0//puedequitarse
                .WriteAttributeString("Banco", banco) '0
            End If
            .WriteAttributeString("PeriodicidadPago", frmNomina_Empleado.cbo_periodicidad.SelectedValue) '*periodo_pago
            '.WriteAttributeString("Departamento", departamento) '0<//puedequitarse
            .WriteAttributeString("NumEmpleado", numero_empleado) '*
            .WriteAttributeString("TipoRegimen", regimen_empleado) '*
            '.WriteAttributeString("TipoJornada", tipo_jornada) '0//puedequitarse
            .WriteAttributeString("TipoContrato", tipo_contrato) '0
            .WriteAttributeString("Puesto", puesto_empleado) '0

            antiguedad = "P" & frmNomina_Empleado.txt_antiguedad.Text & "W"
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("Antigüedad", antiguedad) '0

            End If
            .WriteAttributeString("FechaInicioRelLaboral", fecha_inicio_laboral) '0
            .WriteAttributeString("Curp", curp_empleado) '*
            '.WriteAttributeString("SalarioBaseCotApor", "435.50") '*
            .WriteEndElement()




            '.WriteAttributeString("RiesgoPuesto", riesgo_puesto) '0
            '            .WriteAttributeString("SalarioDiarioIntegrado", "90.00") '0
            'percepcion nodo


            '===========================PERCEPCIONES


            .WriteStartElement("nomina12:Percepciones") 'Percepciones 
            .WriteAttributeString("TotalSueldos", Format((CDec(grabado_percepcion) + CDec(exento_percepcion)), "####0.00")) '*
            .WriteAttributeString("TotalGravado", Format(CDec(frmNomina_Empleado.txt_percepciones_gravado.Text), "####0.00")) '*
            .WriteAttributeString("TotalExento", Format(CDec(frmNomina_Empleado.txt_percepciones_exento.Text), "####0.00")) '*

            cuenta_ = 0

            Dim sinfo As String = ""

            Dim sSQL As String = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " ORDER BY id_detalle Desc"
            Dim dt As New DataTable
            Dim dr As DataRow

            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

                If odata.getDt(cnn, dt, sSQL, sinfo) Then

                    For Each dr In dt.Rows

                        If dr("id_percepcion").ToString <> "" Then
                            .WriteStartElement("nomina12:Percepcion")

                            .WriteAttributeString("ImporteExento", Format(CDec(dr("exento").ToString), "####0.00"))
                            .WriteAttributeString("ImporteGravado", Format(CDec(dr("gravado").ToString), "####0.00"))
                            .WriteAttributeString("Concepto", Replace(Replace(RemoveDiacritics(dr("concepto").ToString), "(", ""), ")", ""))
                            .WriteAttributeString("Clave", dr("id_percepcion").ToString)
                            .WriteAttributeString("TipoPercepcion", dr("id_percepcion").ToString)
                            .WriteEndElement()

                        End If
                        If dr("id_deduccion").ToString <> "" Then
                            cuenta_ = cuenta_ + 1
                        End If

                    Next
                    '  
                Else

                    ' MsgBox(sinfo)

                End If

                cnn.Close()
            End If


            .WriteEndElement()

            Dim bandera_incapacidad As Integer = 0

            '=========================== DEDUCCIONES
            If cuenta_ > 0 Then
                .WriteStartElement("nomina12:Deducciones")
                Dim tisr As String = "0"
                sinfo = ""
                sSQL = "Select * from detalle_nomina where id_empleado=" & numero_empleado & " and id_nomina=" & detalle_nomina & " order by id_detalle Desc"
                Dim dtx As New DataTable
                Dim drx As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dtx, sSQL, sinfo) Then
                        For Each drx In dtx.Rows
                            If drx("id_deduccion").ToString <> "" Then
                                If drx("id_deduccion").ToString = "002" Then
                                    tisr = tisr + CDec(drx("importe").ToString)
                                End If
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If

                Dim otrasdedu As Double = 0
                otrasdedu = deducciones - tisr

                If tisr > 0 Then
                    .WriteAttributeString("TotalImpuestosRetenidos", Replace(tisr, ",", "")) '*
                End If

                .WriteAttributeString("TotalOtrasDeducciones", Replace(otrasdedu, ",", "")) '*

                sinfo = ""

                sSQL = "Select * from detalle_nomina where id_empleado=" & numero_empleado & " and id_nomina=" & detalle_nomina & " order by id_detalle Desc"
                Dim dt2 As New DataTable
                Dim dr2 As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If dr("id_deduccion").ToString <> "" Then
                                .WriteStartElement("nomina12:Deduccion")
                                .WriteAttributeString("TipoDeduccion", dr("id_deduccion").ToString)
                                .WriteAttributeString("Clave", dr("id_deduccion").ToString)
                                If dr("id_deduccion").ToString = "006" Then
                                    bandera_incapacidad = 1
                                End If
                                .WriteAttributeString("Concepto", RemoveDiacritics(dr("concepto").ToString))
                                .WriteAttributeString("Importe", Format(CDec(dr("importe").ToString), "####0.00"))
                                .WriteEndElement()
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If
                .WriteEndElement()
            Else

            End If

            '=======================otros
            sinfo = ""

            sSQL = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " AND id_otropago<>'' ORDER BY id_detalle Desc"
            Dim dt3 As New DataTable
            Dim dr3 As DataRow
            Dim concepto_otrop As String = ""
            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

                If odata.getDt(cnn, dt3, sSQL, sinfo) Then

                    If dt3.Rows.Count > 0 Then

                        .WriteStartElement("nomina12:OtrosPagos")
                        '*
                        For Each dr3 In dt3.Rows

                            If dr3("id_otropago").ToString <> "" Then
                                concepto_otrop = ""

                                Select Case dr3("id_otropago").ToString
                                    Case "001"
                                        concepto_otrop = "Reintegro de ISR pagado en exceso"
                                    Case "002"
                                        concepto_otrop = "Subsidio para el empleo"
                                    Case "003"
                                        concepto_otrop = "Viáticos"
                                    Case "004"
                                        concepto_otrop = "Aplicación de saldo a favor por compensación anual"
                                    Case "999"
                                        concepto_otrop = "Pagos distintos a los listados"
                                End Select

                                .WriteStartElement("nomina12:OtroPago")

                                .WriteAttributeString("TipoOtroPago", dr3("id_otropago").ToString)
                                .WriteAttributeString("Clave", dr3("id_otropago").ToString)
                                .WriteAttributeString("Concepto", RemoveDiacritics(concepto_otrop))
                                .WriteAttributeString("Importe", Format(CDec(dr3("importe").ToString), "####0.00"))
                                If dr3("id_otropago").ToString = "002" Then

                                    .WriteStartElement("nomina12:SubsidioAlEmpleo")
                                    .WriteAttributeString("SubsidioCausado", dr3("Importe").ToString)
                                    .WriteEndElement()
                                End If

                                .WriteEndElement()

                            End If
                        Next
                        .WriteEndElement()
                    End If
                Else

                    ' MsgBox(sinfo)

                End If

                cnn.Close()
            End If

            If bandera_incapacidad = 1 Then
                sSQL = "Select * from detalle_nomina where id_empleado=" & numero_empleado & " and id_nomina=" & detalle_nomina & " order by id_detalle Desc"
                Dim dt2 As New DataTable
                Dim dr2 As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If dr("id_deduccion").ToString <> "" Then
                                If dr("id_deduccion").ToString = "006" Then
                                    .WriteStartElement("nomina12:Incapacidades")
                                    .WriteStartElement("nomina12:Incapacidad")
                                    .WriteAttributeString("DiasIncapacidad", frmNomina_Empleado.txtDiasInc.Text)
                                    '.WriteAttributeString("Clave", dr("id_deduccion").ToString)
                                    .WriteAttributeString("TipoIncapacidad", frmNomina_Empleado.cboTipoInca.SelectedValue)
                                    .WriteAttributeString("ImporteMonetario", Format(CDec(dr("importe").ToString), "####0.00"))
                                    .WriteEndElement()
                                    .WriteEndElement()
                                End If
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If
            End If

            .WriteEndElement() 'fin complemento de la nomina
            .WriteEndElement()
            .WriteEndElement()

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML
        ConCertificado = "concertificado"


        xmldoc.Load(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD)
        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml
        '   SellarCFD(Elemento, ruta_certificado, ruta_key, pass_key, no_csd_emp)
        xmldoc.Save(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD)

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""
        Dim rutaxmltimbre As String = ""
        frmNomina_Empleado.lbl_evento.Text = "Generando Timbre ..."
        frmNomina_Empleado.ProgressBar1.Value = 40
        My.Application.DoEvents()
        If timbre_f(serie, folio, folio_sat_uuid, fecha_folio_sat, nombre_empleado, id_empresa, numero_empleado, cadena_orig, sello_emisor, certificado_sat, rutaxmltimbre) Then

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath() & "\xml\XML_E" & id_empresa & "_T" & numero_empleado & "_N" & serie & folio & ".xml")

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                        If Lector.Name = "tfd:TimbreFiscalDigital" Then
                            If Lector.HasAttributes Then

                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "selloSAT"
                                            sello_sat = Lector.Value
                                        Case "noCertificadoSAT"
                                            certificado_sat = Lector.Value
                                        Case "selloCFD"
                                            sello_emisor = Lector.Value
                                        Case "FechaTimbrado"
                                            fecha_folio_sat = Lector.Value
                                    End Select

                                End While

                            End If
                        End If

                End Select
            Loop

            ' cadena_orig = CadenaOrg(folio_sat_uuid, fecha_folio_sat, sello_emisor, certificado_sat)
            frmNomina_Empleado.lbl_evento.Text = "Guardando Datos ..."
            frmNomina_Empleado.ProgressBar1.Value = 50
            My.Application.DoEvents()

            If Guarda_nomina(folio, serie, subtotal, deducciones, total, metodo_pago, pais, estado, rfc_empresa, razon_social, calle_empresa, num_empresa,
                            colonia_empresa, municipio_empresa, estado_empresa, pais_empresa, cp_empresa, actividad_empresa, rfc_empreado, nombre_empleado,
                            numero_domicilio_empleado, curp_empleado, regimen_empleado, nss_empleado, fecha_pago, fecha_inicio, fecha_fin, dias_pagados,
                            departamento, clabe, banco, fecha_inicio_laboral, antiguedad, puesto_empleado, tipo_contrato, tipo_jornada, periodo_pago,
                            salario_base, riesgo_puesto, calle_empleado, colonia_empleado, municipio_empleado, cp_empleado, numero_empleado,
                             regimen_empresa, registro_patronal, grabado_percepcion, exento_percepcion, num_nomina, reg_fiscal, tipo_pago_e, folio_sat_uuid,
                             fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, totalotrospag, tipo_nomina, fechaFormateada) Then

                ActualizaNomina()
                guarda_detalle(numero_empleado, detalle_nomina, folio)
                actualiza_fecha_timbre(numero_empleado)

                frmerrores_timbre.Show()
                frmerrores_timbre.lista_e.Text = "Nomina Guardada Correctamente." & nombre_empleado & "  " & folio

                Dim maxreg As String = ""
                frmNomina_Empleado.lbl_evento.Text = "Generando Documentos ..."
                frmNomina_Empleado.ProgressBar1.Value = 70
                My.Application.DoEvents()

                Thread.Sleep(2000)
                buscalogo(maxreg)
                Dim folio_nom = folio
                Dim rfc_nom As String = rfc_empresa
                Dim id_emp_nom As String = numero_empleado

                nomina_id1 = maxreg


                frmPrintRecibo.folio_nomina = folio_nom
                frmPrintRecibo.empleado_id = id_emp_nom

                frmPrintRecibo.param_cant_letra = convLetras(total)
                frmPrintRecibo.logo_empresa = var_logo
                Dim xsa As String = Application.StartupPath & "\recibos\RECIBO_E" & frmNomina_Empleado.cboEmpresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf"

                frmPrintRecibo.ViewRecibo(Application.StartupPath & "\recibos\RECIBO_E" & frmNomina_Empleado.cboEmpresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf")

                frmNomina_Empleado.lbl_evento.Text = "Generando Documentos ..."
                frmNomina_Empleado.ProgressBar1.Value = 70
                My.Application.DoEvents()

                If maiemp <> "" Then
                    frmNomina_Empleado.lbl_evento.Text = "Enviando Documentos ..."
                    frmNomina_Empleado.ProgressBar1.Value = 90
                    My.Application.DoEvents()
                    envio(maiemp, "Recibo de Nomina", "ESTE MENSAJE FUE ENVIADO AUTOMATICAMENTE NO CONTESTE ESTE MENSAJE", xsa, rutaxmltimbre)

                End If

                frmNomina_Empleado.cboTipoInca.SelectedValue = -1
                frmNomina_Empleado.txtDiasInc.Text = ""

            End If


        End If
        frmNomina_Empleado.lbl_evento.Text = "Recibo Finalizado ..."
        frmNomina_Empleado.ProgressBar1.Value = 100
        My.Application.DoEvents()
        Thread.Sleep(1000)
        ' frmNomina_empleados.lbl_evento.Text = ""
        '  frmNomina_empleados.ProgressBar1.Visible = False
    End Sub

    Public Sub GeneraXML_nomina4(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                                ByVal deducciones As String, ByVal total As String, ByVal metodo_pago As String,
                                ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                                ByVal calle_empresa As String, ByVal num_empresa As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                                ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                                ByVal rfc_empreado As String, ByVal nombre_empleado As String, ByVal numero_domicilio_empleado As String,
                                ByVal curp_empleado As String, ByVal regimen_empleado As String, ByVal nss_empleado As String, ByVal fecha_pago As String,
                                ByVal fecha_inicio As String, ByVal fecha_fin As String, ByVal dias_pagados As String, ByVal departamento As String,
                                ByVal clabe As String, ByVal banco As String, ByVal fecha_inicio_laboral As String, ByVal antiguedad As String, ByVal puesto_empleado As String,
                                ByVal tipo_contrato As String, ByVal tipo_jornada As String, ByVal periodo_pago As String, ByVal salario_base As String,
                                ByVal riesgo_puesto As String, ByVal calle_empleado As String, ByVal colonia_empleado As String, ByVal municipio_empleado As String,
                                ByVal cp_empleado As String, ByVal numero_empleado As String, ByVal regimen_empresa As String, ByVal registro_patronal As String,
                                ByVal grabado_percepcion As String, ByVal exento_percepcion As String, ByVal num_nomina As String, ByVal ruta_certificado As String,
                                ByVal ruta_key As String, ByVal pass_key As String, ByVal detalle_nomina As String, ByVal reg_fiscal As String, ByVal tipo_pago_e As String,
                                ByVal id_empresa As Integer, ByVal totalotrospag As String, ByVal tipo_nomina As String)
        'ByVal no_certificado As String, ByVal sello As String, _

        Dim nombreCFD As String = "E" & id_empresa & "_T" & numero_empleado & "_N" & serie & folio & ".xml"

        Dim miXml As XmlTextWriter = New XmlTextWriter(My.Application.Info.DirectoryPath & "\XML\" & nombreCFD, System.Text.Encoding.UTF8)
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechacreacion As DateTime = Now

        fechaFormateada = DateAndTime.Now.ToString("s")
        '        fechaFormateada = fechacreacion.ToString("yyyy-MM-ddThh:mm:ss")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-dd")

        With miXml

            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE

            .WriteStartElement("cfdi:Comprobante")

            'aqui empece
            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(cp_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("MetodoPago")
            .WriteValue("PUE")
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            .WriteValue("N")
            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("" & Format(CDec(total), "####0.00"))
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("MXN")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue(Format(CDec(subtotal), "####0.00"))
            .WriteEndAttribute()

            .WriteStartAttribute("Exportacion")
            .WriteValue("01")
            .WriteEndAttribute()


            '.WriteStartAttribute("FormaPago")
            '.WriteValue("99")
            '.WriteEndAttribute()

            '.WriteStartAttribute("TipoCambio")
            '.WriteValue("1")
            '.WriteEndAttribute()

            If deducciones > 0 Then
                .WriteStartAttribute("Descuento")
                .WriteValue(Format(CDec(deducciones), "####0.00"))
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("xmlns:nomina12")
            .WriteValue("http://www.sat.gob.mx/nomina12")
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue(fechaFormateada)
            .WriteEndAttribute()

            If folio <> "" Then
                .WriteStartAttribute("Folio")
                .WriteValue(folio)
                .WriteEndAttribute()
            End If


            If serie <> "" Then
                .WriteStartAttribute("Serie")
                .WriteValue(serie)
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("Version")
            .WriteValue("4.0")
            .WriteEndAttribute()

            .WriteStartAttribute("xsi:schemaLocation")
            .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/4")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            Dim odata As New ToolKitSQL.myssql
            '//////
            Dim dr2x As DataRow
            Dim sinfo2 As String = ""
            Dim ssql2 As String = "SELECT Emp_curp FROM datosnegocio WHERE Em_rfc='" & rfc_empresa & "'"
            Dim curpempresa As String = ""
            Dim cnn2 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            If odata.dbOpen(cnn2, sTargetlocal, sinfo2) Then

                If odata.getDr(cnn2, dr2x, ssql2, sinfo2) Then

                    curpempresa = dr2x("Emp_curp").ToString

                Else

                    ' MsgBox(sinfo)

                End If

                cnn2.Close()
            End If

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")

            .WriteStartAttribute("Nombre")
            .WriteValue(razon_social)
            .WriteEndAttribute()

            .WriteStartAttribute("Rfc")
            .WriteValue(rfc_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("RegimenFiscal")
            .WriteValue(reg_fiscal)
            .WriteEndAttribute()

            '.WriteAttributeString("RegimenFiscal", reg_fiscal) ' Clave regimen

            .WriteEndElement() 'Emisor


            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Nombre", nombre_empleado)
            .WriteAttributeString("Rfc", rfc_empreado)
            .WriteAttributeString("UsoCFDI", "CN01")

            .WriteAttributeString("DomicilioFiscalReceptor", cp_empleado)
            .WriteAttributeString("RegimenFiscalReceptor", "605")


            .WriteEndElement() 'receptor
            '=========================== COMIENZA CONCEPTO

            .WriteStartElement("cfdi:Conceptos")
            .WriteStartElement("cfdi:Concepto")

            .WriteAttributeString("ClaveProdServ", "84111505")
            .WriteAttributeString("Importe", Format(CDec(subtotal), "####0.00"))
            .WriteAttributeString("ValorUnitario", Format(CDec(subtotal), "####0.00"))
            .WriteAttributeString("Descripcion", "Pago de nómina")
            .WriteAttributeString("ClaveUnidad", "ACT")
            .WriteAttributeString("Cantidad", "1")
            .WriteAttributeString("ObjetoImp", "01")
            If deducciones > 0 Then
                .WriteAttributeString("Descuento", Format(CDec(deducciones), "####0.00"))
            End If

            .WriteEndElement()
            .WriteEndElement()


            '=============fin conceptos

            '===================================== INICIA IMPUESTOS

            If nss_empleado = "" Then
                nss_empleado = "S/N"
            End If

            '======================================== INICIA NOMINA
            .WriteStartElement("cfdi:Complemento")

            .WriteStartElement("nomina12:Nomina") 'Nomina 100
            If totalotrospag > 0 Then
                .WriteAttributeString("TotalOtrosPagos", totalotrospag) '*
            Else
                If frmNomina_Empleado.grid_otrosp.RowCount > 0 Then
                    .WriteAttributeString("TotalOtrosPagos", totalotrospag) '*
                End If
            End If


            If deducciones > 0 Then
                .WriteAttributeString("TotalDeducciones", deducciones) '*
            End If


            Dim totalpa As String = ""

            totalpa = CDec(exento_percepcion) + CDec(grabado_percepcion)

            .WriteAttributeString("TotalPercepciones", Replace(totalpa, ",", "")) '*
            .WriteAttributeString("NumDiasPagados", dias_pagados) '*
            .WriteAttributeString("FechaInicialPago", fecha_inicio) '*
            .WriteAttributeString("FechaFinalPago", fecha_fin) '*
            .WriteAttributeString("FechaPago", fecha_pago) '*
            .WriteAttributeString("TipoNomina", tipo_nomina) '*

            .WriteAttributeString("Version", "1.2") '*


            '=================== Emisor nomina12  
            .WriteStartElement("nomina12:Emisor")
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("RegistroPatronal", registro_patronal) '*
            End If
            If Len(rfc_empresa) = 13 Then
                .WriteAttributeString("Curp", curpempresa) '*
            End If
            .WriteEndElement()
            'fin emi
            '==============Receptor nom12

            .WriteStartElement("nomina12:Receptor")

            '.WriteAttributeString("RfcPatronOrigen", rfc_empresa) '*
            '.WriteAttributeString("RegistroPatronal", registro_patronal) '*
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("NumSeguridadSocial", nss_empleado) '0
            End If
            .WriteAttributeString("SalarioDiarioIntegrado", Format(CDec(salario_base), "####0.00")) '0
            .WriteAttributeString("RiesgoPuesto", riesgo_puesto) '0
            .WriteAttributeString("ClaveEntFed", estado) '*
            If clabe <> "" Then
                '.WriteAttributeString("CuentaBancaria", clabe) '0//puedequitarse
                .WriteAttributeString("Banco", banco) '0
            End If
            .WriteAttributeString("PeriodicidadPago", frmNomina_Empleado.cbo_periodicidad.SelectedValue) '*periodo_pago
            '.WriteAttributeString("Departamento", departamento) '0<//puedequitarse
            .WriteAttributeString("NumEmpleado", numero_empleado) '*
            .WriteAttributeString("TipoRegimen", regimen_empleado) '*
            '.WriteAttributeString("TipoJornada", tipo_jornada) '0//puedequitarse
            .WriteAttributeString("TipoContrato", tipo_contrato) '0
            .WriteAttributeString("Puesto", puesto_empleado) '0

            antiguedad = "P" & frmNomina_Empleado.txt_antiguedad.Text & "W"
            If nss_empleado <> "S/N" Then
                .WriteAttributeString("Antigüedad", antiguedad) '0

            End If
            .WriteAttributeString("FechaInicioRelLaboral", fecha_inicio_laboral) '0
            .WriteAttributeString("Curp", curp_empleado) '*
            '.WriteAttributeString("SalarioBaseCotApor", "435.50") '*
            .WriteEndElement()




            '.WriteAttributeString("RiesgoPuesto", riesgo_puesto) '0
            '            .WriteAttributeString("SalarioDiarioIntegrado", "90.00") '0
            'percepcion nodo


            '===========================PERCEPCIONES


            .WriteStartElement("nomina12:Percepciones") 'Percepciones 
            .WriteAttributeString("TotalSueldos", Format((CDec(grabado_percepcion) + CDec(exento_percepcion)), "####0.00")) '*
            .WriteAttributeString("TotalGravado", Format(CDec(frmNomina_Empleado.txt_percepciones_gravado.Text), "####0.00")) '*
            .WriteAttributeString("TotalExento", Format(CDec(frmNomina_Empleado.txt_percepciones_exento.Text), "####0.00")) '*

            cuenta_ = 0

            Dim sinfo As String = ""

            Dim sSQL As String = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " ORDER BY id_detalle Desc"
            Dim dt As New DataTable
            Dim dr As DataRow

            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

                If odata.getDt(cnn, dt, sSQL, sinfo) Then

                    For Each dr In dt.Rows

                        If dr("id_percepcion").ToString <> "" Then
                            .WriteStartElement("nomina12:Percepcion")

                            .WriteAttributeString("ImporteExento", Format(CDec(dr("exento").ToString), "####0.00"))
                            .WriteAttributeString("ImporteGravado", Format(CDec(dr("gravado").ToString), "####0.00"))
                            .WriteAttributeString("Concepto", Replace(Replace(RemoveDiacritics(dr("concepto").ToString), "(", ""), ")", ""))
                            .WriteAttributeString("Clave", dr("id_percepcion").ToString)
                            .WriteAttributeString("TipoPercepcion", dr("id_percepcion").ToString)
                            .WriteEndElement()

                        End If
                        If dr("id_deduccion").ToString <> "" Then
                            cuenta_ = cuenta_ + 1
                        End If

                    Next
                    '  
                Else

                    ' MsgBox(sinfo)

                End If

                cnn.Close()
            End If


            .WriteEndElement()

            Dim bandera_incapacidad As Integer = 0

            '=========================== DEDUCCIONES
            If cuenta_ > 0 Then
                .WriteStartElement("nomina12:Deducciones")
                Dim tisr As String = "0"
                sinfo = ""
                sSQL = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " ORDER BY id_detalle Desc"
                Dim dtx As New DataTable
                Dim drx As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dtx, sSQL, sinfo) Then
                        For Each drx In dtx.Rows
                            If drx("id_deduccion").ToString <> "" Then
                                If drx("id_deduccion").ToString = "002" Then
                                    tisr = tisr + CDec(drx("importe").ToString)
                                End If
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If

                Dim otrasdedu As Double = 0
                otrasdedu = deducciones - tisr

                If tisr > 0 Then
                    .WriteAttributeString("TotalImpuestosRetenidos", Replace(tisr, ",", "")) '*
                End If

                .WriteAttributeString("TotalOtrasDeducciones", Replace(otrasdedu, ",", "")) '*

                sinfo = ""

                sSQL = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " ORDER BY id_detalle Desc"
                Dim dt2 As New DataTable
                Dim dr2 As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If dr("id_deduccion").ToString <> "" Then
                                .WriteStartElement("nomina12:Deduccion")
                                .WriteAttributeString("TipoDeduccion", dr("id_deduccion").ToString)
                                .WriteAttributeString("Clave", dr("id_deduccion").ToString)
                                If dr("id_deduccion").ToString = "006" Then
                                    bandera_incapacidad = 1
                                End If
                                .WriteAttributeString("Concepto", RemoveDiacritics(dr("concepto").ToString))
                                .WriteAttributeString("Importe", Format(CDec(dr("importe").ToString), "####0.00"))
                                .WriteEndElement()
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If
                .WriteEndElement()
            Else

            End If

            '=======================otros
            sinfo = ""

            sSQL = "Select * from detalle_nomina where id_empleado=" & numero_empleado & " and id_nomina=" & detalle_nomina & " and id_otropago<>'' order by id_detalle Desc"
            Dim dt3 As New DataTable
            Dim dr3 As DataRow
            Dim concepto_otrop As String = ""
            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

                If odata.getDt(cnn, dt3, sSQL, sinfo) Then

                    If dt3.Rows.Count > 0 Then

                        .WriteStartElement("nomina12:OtrosPagos")
                        '*
                        For Each dr3 In dt3.Rows

                            If dr3("id_otropago").ToString <> "" Then
                                concepto_otrop = ""

                                Select Case dr3("id_otropago").ToString
                                    Case "001"
                                        concepto_otrop = "Reintegro de ISR pagado en exceso"
                                    Case "002"
                                        concepto_otrop = "Subsidio para el empleo"
                                    Case "003"
                                        concepto_otrop = "Viáticos"
                                    Case "004"
                                        concepto_otrop = "Aplicación de saldo a favor por compensación anual"
                                    Case "999"
                                        concepto_otrop = "Pagos distintos a los listados"
                                End Select

                                .WriteStartElement("nomina12:OtroPago")

                                .WriteAttributeString("TipoOtroPago", dr3("id_otropago").ToString)
                                .WriteAttributeString("Clave", dr3("id_otropago").ToString)
                                .WriteAttributeString("Concepto", RemoveDiacritics(concepto_otrop))
                                .WriteAttributeString("Importe", Format(CDec(dr3("importe").ToString), "####0.00"))
                                If dr3("id_otropago").ToString = "002" Then

                                    .WriteStartElement("nomina12:SubsidioAlEmpleo")
                                    .WriteAttributeString("SubsidioCausado", dr3("Importe").ToString)
                                    .WriteEndElement()
                                End If

                                .WriteEndElement()

                            End If
                        Next
                        .WriteEndElement()
                    End If
                Else

                    ' MsgBox(sinfo)

                End If

                cnn.Close()
            End If

            If bandera_incapacidad = 1 Then
                sSQL = "SELECT * FROM detalle_nomina WHERE id_empleado=" & numero_empleado & " AND id_nomina=" & detalle_nomina & " ORDER BY id_detalle Desc"
                Dim dt2 As New DataTable
                Dim dr2 As DataRow
                If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                    If odata.getDt(cnn, dt, sSQL, sinfo) Then
                        For Each dr In dt.Rows
                            If dr("id_deduccion").ToString <> "" Then
                                If dr("id_deduccion").ToString = "006" Then
                                    .WriteStartElement("nomina12:Incapacidades")
                                    .WriteStartElement("nomina12:Incapacidad")
                                    .WriteAttributeString("DiasIncapacidad", frmNomina_Empleado.txtDiasInc.Text)
                                    '.WriteAttributeString("Clave", dr("id_deduccion").ToString)
                                    .WriteAttributeString("TipoIncapacidad", frmNomina_Empleado.cboTipoInca.SelectedValue)
                                    .WriteAttributeString("ImporteMonetario", Format(CDec(dr("importe").ToString), "####0.00"))
                                    .WriteEndElement()
                                    .WriteEndElement()
                                End If
                            End If
                        Next
                    Else
                    End If
                    cnn.Close()
                End If
            End If

            .WriteEndElement() 'fin complemento de la nomina
            .WriteEndElement()
            .WriteEndElement()

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML
        ConCertificado = "concertificado"


        xmldoc.Load(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD)
        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml
        '   SellarCFD(Elemento, ruta_certificado, ruta_key, pass_key, no_csd_emp)
        xmldoc.Save(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD)

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""
        Dim rutaxmltimbre As String = ""
        Dim version As String = ""
        Dim rfcprovcertif As String = ""
        frmNomina_Empleado.lbl_evento.Text = "Generando Timbre ..."
        frmNomina_Empleado.ProgressBar1.Value = 40
        My.Application.DoEvents()

        If timbre_f(serie, folio, folio_sat_uuid, fecha_folio_sat, nombre_empleado, id_empresa, numero_empleado, cadena_orig, sello_emisor, certificado_sat, rutaxmltimbre) Then

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath() & "\xml\XML_E" & id_empresa & "_T" & numero_empleado & "_N" & serie & folio & ".xml")

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.

                        If Lector.Name = "cfdi:Comprobante" Then
                            If Lector.HasAttributes Then

                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "NoCertificado"
                                            no_csd_emp = Lector.Value
                                    End Select

                                End While

                            End If
                        End If

                        If Lector.Name = "tfd:TimbreFiscalDigital" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "SelloSAT"
                                            sello_sat = Lector.Value
                                        Case "NoCertificadoSAT"
                                            certificado_sat = Lector.Value
                                        Case "SelloCFD"
                                            sello_emisor = Lector.Value
                                        Case "FechaTimbrado"
                                            fecha_folio_sat = Lector.Value
                                        Case "UUID"
                                            folio_sat_uuid = Lector.Value
                                        Case "Version"
                                            version = Lector.Value
                                        Case "RfcProvCertif"
                                            rfcprovcertif = Lector.Value
                                    End Select

                                End While
                            End If
                        End If

                End Select
            Loop

            ' cadena_orig = CadenaOrg(folio_sat_uuid, fecha_folio_sat, sello_emisor, certificado_sat)
            frmNomina_Empleado.lbl_evento.Text = "Guardando Datos ..."
            frmNomina_Empleado.ProgressBar1.Value = 50
            My.Application.DoEvents()

            If Guarda_nomina(folio, serie, subtotal, deducciones, total, metodo_pago, pais, estado, rfc_empresa, razon_social, calle_empresa, num_empresa,
                            colonia_empresa, municipio_empresa, estado_empresa, pais_empresa, cp_empresa, actividad_empresa, rfc_empreado, nombre_empleado,
                            numero_domicilio_empleado, curp_empleado, regimen_empleado, nss_empleado, fecha_pago, fecha_inicio, fecha_fin, dias_pagados,
                            departamento, clabe, banco, fecha_inicio_laboral, antiguedad, puesto_empleado, tipo_contrato, tipo_jornada, periodo_pago,
                            salario_base, riesgo_puesto, calle_empleado, colonia_empleado, municipio_empleado, cp_empleado, numero_empleado,
                             regimen_empresa, registro_patronal, grabado_percepcion, exento_percepcion, num_nomina, reg_fiscal, tipo_pago_e, folio_sat_uuid,
                             fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, totalotrospag, tipo_nomina, fechaFormateada) Then

                'ActualizaNomina()
                guarda_detalle(numero_empleado, detalle_nomina, folio)
                actualiza_fecha_timbre(numero_empleado)

                frmerrores_timbre.Show()
                frmerrores_timbre.lista_e.Text = "Nomina Guardada Correctamente." & nombre_empleado & "  " & folio

                Dim maxreg As String = ""
                frmNomina_Empleado.lbl_evento.Text = "Generando Documentos ..."
                frmNomina_Empleado.ProgressBar1.Value = 70
                My.Application.DoEvents()

                Thread.Sleep(2000)
                buscalogo(maxreg)
                Dim folio_nom = folio
                Dim rfc_nom As String = rfc_empresa
                Dim id_emp_nom As String = numero_empleado

                nomina_id1 = maxreg


                frmPrintRecibo.folio_nomina = folio_nom
                frmPrintRecibo.empleado_id = id_emp_nom

                frmPrintRecibo.param_cant_letra = convLetras(total)
                frmPrintRecibo.logo_empresa = var_logo
                Dim xsa As String = Application.StartupPath & "\recibos\RECIBO_E" & frmNomina_Empleado.cboEmpresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf"

                frmPrintRecibo.ViewRecibo(Application.StartupPath & "\recibos\RECIBO_E" & frmNomina_Empleado.cboEmpresa.SelectedValue & "_T" & id_emp_nom & "_N" & folio_nom & ".pdf")

                frmNomina_Empleado.lbl_evento.Text = "Generando Documentos ..."
                frmNomina_Empleado.ProgressBar1.Value = 70
                My.Application.DoEvents()

                If maiemp <> "" Then
                    frmNomina_Empleado.lbl_evento.Text = "Enviando Documentos ..."
                    frmNomina_Empleado.ProgressBar1.Value = 90
                    My.Application.DoEvents()
                    envio(maiemp, "Recibo de Nomina", "ESTE MENSAJE FUE ENVIADO AUTOMATICAMENTE NO CONTESTE ESTE MENSAJE", xsa, rutaxmltimbre)

                End If

                frmNomina_Empleado.cboTipoInca.SelectedValue = -1
                frmNomina_Empleado.txtDiasInc.Text = ""

            End If


        End If
        frmNomina_Empleado.lbl_evento.Text = "Recibo Finalizado ..."
        frmNomina_Empleado.ProgressBar1.Value = 100
        My.Application.DoEvents()
        Thread.Sleep(1000)
        ' frmNomina_empleados.lbl_evento.Text = ""
        '  frmNomina_empleados.ProgressBar1.Visible = False
    End Sub


    Public Function timbre_f(ByVal serie As String, ByVal folio As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal nombre_emp_e As String, ByVal id_empresa As Integer, ByVal id_empleado As Integer, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String, ByRef xmltimbrado As String)
        Dim x As Boolean = False
        If frmNomina_Empleado.txtRFCEmisor.Text = "AAA010101AAA" Or frmNomina_Empleado.txtRFCEmisor.Text = "EKU9003173C9" Then
            x = False
        Else
            x = True

        End If

        'Dim conector As New Conector(x)
        Dim conector As New Profact.TimbraCFDI40.Conector(x)

        Dim idError As Integer
        Dim NError As String
        Dim uuid As String
        'Dim FechaTimbre As DateTime
        ' Dim xmlTimbrado As String


        Dim id As String
        Dim documentoXml As XmlDocument
        'Dim conector As IConectorServisim
        'conector = New ConectorServisimImpl()

        Dim nombreCFD As String = "E" & id_empresa & "_T" & id_empleado & "_N" & serie & folio & ".xml"

        documentoXml = New XmlDocument

        id = serie & folio



        documentoXml.Load(My.Application.Info.DirectoryPath() & "\xml\" & nombreCFD)

        Try

            'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
            If frmNomina_Empleado.txtRFCEmisor.Text = "AAA010101AAA" Or frmNomina_Empleado.txtRFCEmisor.Text = "EKU9003173C9" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = My.Application.Info.DirectoryPath() & "\XML\" & nombreCFD

            'Timbramos el CFDI por medio del conector y guardamos resultado'
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            '    MsgBox("No he timbrado")
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)
            '   MsgBox("Consume Servicio")
            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then
                '    MsgBox("resultado Correcto")
                'El comprobante fue timbrado exitosamente

                'Guardamos xml cfdi

                'Los siguientes datos deberán ir en la respresentación impresa ó PDF

                '1.- Código bidimensional
                'If (resultadoTimbre.GuardaCodigoBidimensional("C:\", "codigo")) Then
                '    MessageBox.Show("El código bidimensional fue guardado correctamente")
                'Else
                '    MessageBox.Show("Ocurrió un error al guardar el código bidimensional")
                'End If

                '2.- Folio fiscal*
                Dim foliFiscal As String = "" 'resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor*
                Dim noCertificado As String = "" 'resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT*
                Dim noCertificadoSat As String = "" 'resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación*
                Dim fechaCert As String = "" 'resultadoTimbre.FechaCertificacion

                '6.- Sello del cfdi
                Dim selloCFDI As String = "" 'resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = "" 'resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación*
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                '   MessageBox.Show("Timbrado Exitoso")

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                selloCFDI2 = selloCFDI
                selloSAT2 = selloSAT
                actualiza_timbres(frmNomina_Empleado.txtRFCEmisor.Text)

                Dim xmltimbradocompleto As New Xml.XmlDocument
                '   MsgBox("antes de leer timbrado")
                xmltimbradocompleto.LoadXml(resultadoTimbre.Xml)
                '   MsgBox("obtiene timbrado correcto")
                crea_dir(My.Application.Info.DirectoryPath() & "\xmlTimbrado")
                '  Dim x4 As String = My.Application.Info.DirectoryPath() & "\xml\XML_E" & id_empresa & "_T" & id_empleado & "_N" & serie & folio & ".xml"
                xmltimbradocompleto.Save(My.Application.Info.DirectoryPath() & "\xmlTimbrado\XML_E" & id_empresa & "_T" & id_empleado & "_N" & serie & folio & ".xml")
                xmltimbrado = My.Application.Info.DirectoryPath() & "\xmlTimbrado\XML_E" & id_empresa & "_T" & id_empleado & "_N" & serie & folio & ".xml"

                xmltimbradocompleto.Save(My.Application.Info.DirectoryPath() & "\xml\XML_E" & id_empresa & "_T" & id_empleado & "_N" & serie & folio & ".xml")

            Else

                '    MsgBox("resultado mal al consumir")
                'No se pudo timbrar, mostramos respuesta
                ' MessageBox.Show(resultadoTimbre.Descripcion)
                MsgBox("Error: " & resultadoTimbre.DescripcionInterna)
                MsgBox("Error: " & resultadoTimbre.Descripcion)
                '  frmNomina_empleados.lbl_evento.Text = ""
                '  frmNomina_empleados.ProgressBar1.Visible = False
                '  envio(frm_facturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & resultadoTimbre.Descripcion, "", "")
                ' bitacora(frm_facturacion.cbo_rfc_emisor.Text, "Error: " & NError & "- " & ex.Message)
                '       Form1.ListBox1.Text &= vbCrLf & "Error: " & resultadoTimbre.Descripcion

                Return False

            End If

        Catch ex As Exception
            'rs = cn.Execute("delete from recibos_nomina_detalle_paso ")
            ' frmNomina_empleados.lbl_evento.Text = ""
            ' frmNomina_empleados.ProgressBar1.Visible = False

            frmerrores_timbre.Show()
            frmerrores_timbre.lista_e.Text = frmerrores_timbre.lista_e.Text & vbCr & NError & vbCr & nombre_emp_e

            MsgBox(ex.Message)
            'MsgBox(NError)
            Return False
        End Try
        Return True
    End Function

    Private Sub guarda_detalle(ByVal id_emp_e As Integer, ByVal id_detalle_e As Integer, ByVal id_nomina As String)

        Dim ssql2 As String = ""
        Dim dt As New DataTable
        Dim dr As DataRow
        Dim odata As New ToolKitSQL.myssql
        Dim sinfo As String = ""
        Dim sSQL As String = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        If id_detalle_e = 0 Then
            sSQL = "UPDATE detalle_nomina SET id_nomina=" & id_nomina & " WHERE id_empleado=" & id_emp_e & " and id_nomina=0"

            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
                odata.runSp(cnn, sSQL, sinfo)

                cnn.Close()
            End If
        Else

            sSQL = "SELECT * FROM detalle_nomina  WHERE id_empleado=" & id_emp_e & " AND id_nomina=" & id_detalle_e

            If odata.dbOpen(cnn, sTarget, sinfo) Then

                If odata.getDt(cnn, dt, sSQL, sinfo) Then

                    For Each dr In dt.Rows

                        ssql2 = "insert into detalle_nomina (id_empleado,id_percepcion,id_deduccion,importe,id_nomina,gravado,exento,fecha,concepto,id_otropago)values(" & id_emp_e &
                             ", '" & dr("id_percepcion").ToString & "', '" & dr("id_deduccion").ToString & "', " & dr("importe").ToString &
                             ", " & id_nomina & ", '" & dr("gravado").ToString & "', '" & dr("exento").ToString &
                             "', '" & Format(Date.Now, "dd/MM/yyyy HH:mm") & "','" & dr("concepto").ToString & "','" & dr("id_otropago").ToString & "')"
                        odata.runSp(cnn, ssql2, sinfo)
                    Next

                End If
                cnn.Close()
            End If

        End If

    End Sub

    Private Function Guarda_nomina(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                                ByVal deducciones As String, ByVal total As String, ByVal metodo_pago As String,
                                ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                                ByVal calle_empresa As String, ByVal num_empresa As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                                ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                                ByVal rfc_empreado As String, ByVal nombre_empleado As String, ByVal numero_domicilio_empleado As String,
                                ByVal curp_empleado As String, ByVal regimen_empleado As String, ByVal nss_empleado As String, ByVal fecha_pago As String,
                                ByVal fecha_inicio As String, ByVal fecha_fin As String, ByVal dias_pagados As String, ByVal departamento As String,
                                ByVal clabe As String, ByVal banco As String, ByVal fecha_inicio_laboral As String, ByVal antiguedad As String, ByVal puesto_empleado As String,
                                ByVal tipo_contrato As String, ByVal tipo_jornada As String, ByVal periodo_pago As String, ByVal salario_base As String,
                                ByVal riesgo_puesto As String, ByVal calle_empleado As String, ByVal colonia_empleado As String, ByVal municipio_empleado As String,
                                ByVal cp_empleado As String, ByVal numero_empleado As String, ByVal regimen_empresa As String, ByVal registro_patronal As String,
                                ByVal grabado_percepcion As String, ByVal exento_percepcion As String, ByVal num_nomina As String, ByVal reg_fiscal As String, ByVal tipo_pago_e As String,
                                ByVal folio_sat_uuid As String, ByVal fecha_folio_sat As String, ByVal sello_emisor As String, ByVal sello_sat As String, ByVal cadena_orig As String,
                                ByVal csd_no_emp As String, ByVal csd_no_sat As String, ByVal total_otrospag As String, ByVal tipo_nomina As String, ByVal fechaemision As String)


        Dim sinfo As String = ""
        Dim sSQL As String = ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim tipoinca As String = IIf(frmNomina_Empleado.cboTipoInca.SelectedValue = -1, "", frmNomina_Empleado.cboTipoInca.SelectedValue)
        If CStr(tipoinca) = "" Then
            tipoinca = ""
        End If
        Try

            sSQL = "Insert into Nominas(nom_id_empleado,nom_razon_social,nom_rfc_empresa,nom_reg_fiscal,nom_actividad_empresa,nom_calle_empresa," &
            "nom_colonia_empresa,nom_del_mun_empresa,nom_cp_empresa,nom_expedido,nom_nombre_empleado,nom_calle_empleado,nom_colonia_empleado," &
            "nom_del_mun_empleado,nom_tipo_contrato,nom_jornada,nom_rfc_empleado,nom_curp,nom_nss,nom_fecha_ing,nom_antiguedad,nom_salario," &
            "nom_folio,nom_fecha_nomina,nom_periodo_del,nom_periodo_al,nom_dias_pagados,nom_metodo_pago,nom_tipo_pago,nom_num_empleado," &
            "nom_departamento,nom_puesto,nom_folio_sat_uuid,nom_fecha_folio_sat,nom_sello_emisor,nom_sello_sat,nom_cadena_original,nom_percepcion_gravado," &
            "nom_percepcion_exento,nom_deduccion,nom_total_pagado,nom_no_csd_emp,nom_no_csd_sat, nom_otrospag,nom_tipo_nomina, nom_Fecha_Emision)Values(" &
             numero_empleado & ", '" & razon_social & "', '" & rfc_empresa & "','" & reg_fiscal & "','" & actividad_empresa & "','" & calle_empresa &
             "','" & colonia_empresa & "','" & municipio_empresa & "','" & cp_empresa & "','" & pais_empresa & ", " & estado_empresa & "','" & nombre_empleado &
             "','" & calle_empleado & "','" & colonia_empleado & "','" & municipio_empleado & "','" & tipo_contrato & "','" & tipo_jornada &
             "','" & rfc_empreado & "','" & curp_empleado & "','" & nss_empleado & "','" & fecha_inicio_laboral & "','" & antiguedad &
             "','" & salario_base & "'," & folio & ",'" & fecha_pago & "','" & fecha_inicio & "','" & fecha_fin & "','" & dias_pagados & "','" & metodo_pago &
             "','" & tipo_pago_e & "','" & numero_empleado & "','" & departamento & "','" & puesto_empleado & "','" & folio_sat_uuid & "'," &
             "'" & fecha_folio_sat & "','" & sello_emisor & "','" & sello_sat & "','" & cadena_orig & "','" & grabado_percepcion & "','" & exento_percepcion &
             "','" & deducciones & "','" & total & "','" & csd_no_emp & "','" & csd_no_sat & "','" & total_otrospag & "','" & tipo_nomina & "','" & fechaemision & "')"

            varNomIdNom = folio_sat_uuid
            Dim odata As New ToolKitSQL.myssql
            If odata.dbOpen(cnn, sTargetlocal, sinfo) Then


                If odata.runSp(cnn, sSQL, sinfo) Then
                    cnn.Close()
                    Return True
                Else

                    MsgBox(sinfo)
                    Return False
                End If
            Else

                MsgBox(sinfo)

                Return False
                cnn.Close()
            End If

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

    End Function

    Public Function CadenaOrg(ByVal uuid As String, ByVal fechaTimbrado As String, ByVal selloEmisor As String, ByVal certificadoSat As String, Optional ByVal version As String = "1.0") As String
        Dim cadena_original As String

        cadena_original = "||" & version & "|" & uuid & "|" & fechaTimbrado & "|" & selloEmisor & "|" & certificadoSat & "||"

        Return cadena_original
    End Function

    Private Sub actualiza_fecha_timbre(ByVal numero_empleado As Integer)
        Dim odata As New ToolKitSQL.myssql
        Dim sinfo As String = ""
        Dim sSQL As String = "Update Datos_Empleado set emp_ultimo_timbre='" & Format(Date.Now, "dd-MM-yyyy HH:mm") & "' where emp_id=" & numero_empleado
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then

            odata.runSp(cnn, sSQL, sinfo)
            cnn.Close()
        End If
    End Sub


    Private Sub recupera_campos()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT * FROM datosnegocio WHERE Emisor_id=" & frmNomina_Empleado.cboEmpresa.SelectedValue
        Dim sinfo As String = ""
        Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData

            If oData.dbOpen(cnn, sTargetlocal, sinfo) Then

                If oData.getDr(cnn, dr, sSQL, sinfo) Then

                    cuentamail = dr("emi_mail").ToString
                    passmail = dr("emi_psw").ToString
                    servidor = dr("servidor").ToString
                    puerto = dr("puerto").ToString
                    seguridad = dr("seguridad")
                    nombree = dr("emi_nombre_negocio").ToString
                    correo2 = dr("correo2").ToString
                Else
                    MsgBox("Error en la configuracion de Correo")
                    ' Form1.ListBox1.Items.Add("Error en la configuracion de Correo")
                    'MsgBox("Error en la configuracion de correo")
                End If

                cnn.Close()
            Else
                MsgBox(sinfo)

                '   MsgBox(sinfo)
            End If

        End With

    End Sub

    Public Function Comprobar_Campo1() As Boolean


        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select correo2 from Datos_Negocio where emi_id=1"
        Dim sinfo As String = ""
        Dim dr As DataRow
        '   Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData
            If oData.dbOpen(cnn, sTargetlocal, sinfo) Then
                If oData.getDr(cnn, dr, sSQL, sinfo) Then
                Else
                    insertarcampos()
                End If
                cnn.Close()
            Else
                MsgBox(sinfo)
                '   MsgBox(sinfo)
            End If
        End With

    End Function

    Public Function insertarcampos() As Boolean

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim sSQL As String = "ALTER TABLE DatosNegocio ADD COLUMN folio_actual INT "
        Dim sSQL2 As String = "ALTER TABLE DatosNegocio ADD COLUMN servidor TEXT "
        Dim sSQL3 As String = "ALTER TABLE DatosNegocio ADD COLUMN puerto TEXT "
        Dim sSQL4 As String = "ALTER TABLE DatosNegocio ADD COLUMN seguridad BIT "
        Dim sSQL5 As String = "ALTER TABLE DatosNegocio ADD COLUMN correo2 TEXT "
        '  Dim sSQL6 As String = "ALTER TABLE Datos_Negocio ADD COLUMN folio_actual INT "

        Dim sinfo As String = ""

        Dim dr As DataRow

        '   Dim dr As DataRow
        Dim oData As New ToolKitSQL.myssql
        With oData

            If oData.dbOpen(cnn, sTargetlocal, sinfo) Then

                oData.runSp(cnn, sSQL, sinfo)
                oData.runSp(cnn, sSQL2, sinfo)
                oData.runSp(cnn, sSQL3, sinfo)
                oData.runSp(cnn, sSQL4, sinfo)
                oData.runSp(cnn, sSQL5, sinfo)

                cnn.Close()
            Else
                MsgBox(sinfo)

                '   MsgBox(sinfo)
            End If

        End With


    End Function

    Private Sub buscalogo(ByRef maximoreg As String)
        Dim odata As New ToolKitSQL.myssql
        Dim sinfo As String = ""
        Dim sSQL As String = "Select * from datosnegocio where Emisor_id=" & frmNomina_Empleado.cboEmpresa.SelectedValue
        Dim dr As DataRow
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        If odata.dbOpen(cnn, sTargetlocal, sinfo) Then
            If odata.getDr(cnn, dr, sSQL, sinfo) Then

                var_logo = dr("emi_logo").ToString

            End If

            sSQL = "Select max(nom_id) as maximo from nomina"
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
                maximoreg = dr("maximo").ToString

            End If

            cnn.Close()
        End If

    End Sub

    Public Sub cancela_profact(ByVal rfc_noms As String, ByVal uuid_noms As String, ByVal foliof As String)
        foliof = frm_consulta_nomina.grid_nominas.CurrentRow.Cells(1).Value.ToString
        '  datosftp()
        Dim destino As String = ""
        'El comprobante fue consultado exitosamente
        Dim tipo As String = ""
        Dim tipo2 As String = ""
        'Guardamos xml cfdi
        Dim rutaftp2 As String = ""
        Dim ruta_acuse As String = Application.StartupPath & "\Cancelados"
        crea_dir(Application.StartupPath & "\Cancelados")
        Dim nombre_acuse As String = "Acuse_" & foliof & ".xml"
        Dim x As Boolean = False
        'uuid_noms = "5129BA23-E598-4F77-AA6C-164E0989FDC9"
        If rfc_noms = "AAA010101AAA" Or rfc_noms = "EKU9003173C9" Then
            x = False
        Else
            x = True
        End If
        'En este ejemplo se muestra como cancelar un comprobante xml, previamente timbrado

        'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
        'Fasle = Ambiente de pruebas
        'True = Ambiente de producción
        Dim conector As New Conector(x)

        'Establecemos las credenciales para el permiso de conexión
        'Ambiente de pruebas = mvpNUXmQfK8=
        'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

        If rfc_noms = "AAA010101AAA" Or rfc_noms = "EKU9003173C9" Then
            conector.EstableceCredenciales("mvpNUXmQfK8=")
        Else
            conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")

        End If

        ' conector.EstableceCredenciales("mvpNUXmQfK8=")

        'Rfc Emisor
        Dim rfcEmisor As String = rfc_noms.Trim

        'Folio Fiscal - UUID
        Dim folioFiscal As String = uuid_noms.Trim

        'Obtenemos el xml por medio del conector y guardamos resultado'
        Dim resultadoCancelacion As Profact.TimbraCFDI.ResultadoCancelacion

        resultadoCancelacion = conector.CancelaCFDI(rfcEmisor, folioFiscal)
        'Verificamos el resultado
        If (resultadoCancelacion.Exitoso) Then

            'El comprobante fue cancelado exitosamente
            MessageBox.Show("Cancelación exitosa " + resultadoCancelacion.Descripcion)
            actualiza_timbres(rfc_noms)

            Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta

            resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)

            'Verificamos el resultado
            If (resultadoConsulta.Exitoso) Then

                crea_dir(ruta_acuse)
                If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then

                    '  MessageBox.Show("El xml fue guardado correctamente")

                    MsgBox("El xml fue guardado correctamente")
                    'cancela_facturad(foliof)


                End If


            Else

                'No se pudo consultar, mostramos respuesta
                MsgBox(resultadoConsulta.Descripcion)

            End If


        Else
            'No se pudo cancelar, mostramos respuesta

            If resultadoCancelacion.Descripcion = "UUID Previamente cancelado" Then


                Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta

                resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)

                'Verificamos el resultado
                If (resultadoConsulta.Exitoso) Then
                    '  datosftp()


                    crea_dir(ruta_acuse)
                    If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then

                        '  MessageBox.Show("El xml fue guardado correctamente")

                        MsgBox("El xml fue guardado correctamente")
                        'cancela_facturad(foliof)





                    Else

                        ' MessageBox.Show("Ocurrió un error al guardar el comprobante")
                        MsgBox("Ocurrió un error al guardar el comprobante")



                    End If



                Else

                    'No se pudo consultar, mostramos respuesta
                    MsgBox(resultadoConsulta.Descripcion)

                End If

            End If

            '  MessageBox.Show(resultadoCancelacion.Descripcion)


        End If


    End Sub

    Public Function Calcular_antiguadad(ByVal FechaInicio As Date, ByVal FechaActual As Date, ByRef Anios As Integer, ByRef Meses As Integer, ByRef Dias As Integer) As String

        Dim diaActual As Integer = DatePart("d", FechaActual)
        Dim mesActual As Integer = DatePart("m", FechaActual)
        Dim anioActual As Integer = DatePart("yyyy", FechaActual)
        '**************************************'
        Dim diaInicio As Integer = DatePart("d", FechaInicio)
        Dim mesInicio As Integer = DatePart("m", FechaInicio)
        Dim anioInicio As Integer = DatePart("yyyy", FechaInicio)

        Dim B As Integer = 0
        Dim Mes As Integer = mesInicio - 1

        ' si el mes es febrero
        If (Mes = 2) Then   ' *
            If ((anioActual / 4 = 0 And anioActual / 100.0! = 0) Or anioActual / 400 = 0) Then
                B = 29
            Else
                B = 28
            End If
        ElseIf (Mes <= 7) Then  '*
            If (Mes = 0) Then
                B = 31
            ElseIf (Mes / 2 = 0) Then
                B = 30
            Else
                B = 31
            End If

        ElseIf (Mes > 7) Then
            If (Mes / 2 = 0) Then
                B = 31
            Else
                B = 30
            End If
        End If

        If ((anioInicio > anioActual) Or (anioInicio = anioActual And mesInicio > mesActual) Or (anioInicio = anioActual And mesInicio = mesActual And diaInicio > diaActual)) Then
            MsgBox("La fecha de inicio ha de ser anterior a la fecha Actual")
        Else
            If (mesInicio <= mesActual) Then
                Anios = anioActual - anioInicio
                If (diaInicio <= diaActual) Then
                    Meses = mesActual - mesInicio
                    Dias = diaActual - diaInicio
                Else
                    If (mesActual = mesInicio) Then
                        Anios = Anios - 1
                    End If
                    Meses = (mesActual - mesInicio - 1 + 12) / 12
                    Dias = B - (diaInicio - diaActual)
                End If
            Else
                Anios = anioActual - anioInicio - 1

                If (diaInicio > diaActual) Then
                    Meses = mesActual - mesInicio - 1 + 12
                    Dias = B - (diaInicio - diaActual)
                Else
                    Meses = mesActual - mesInicio + 12
                    Dias = diaActual - diaInicio
                End If
            End If

        End If '*

        ' Calcular = Anios & "/" & Meses & "/" & Dias

    End Function

    Public Function RemoveDiacritics(stIn As String) As String

        Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()

        For ich As Integer = 0 To stFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
            If uc <> UnicodeCategory.NonSpacingMark Then
                sb.Append(stFormD(ich))
            End If
        Next

        Return (sb.ToString().Normalize(NormalizationForm.FormC))

    End Function

    Private Sub ActualizaNomina()

        'Dim sTarget As String = cnStr
        'Dim cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        'Dim sSQL As String = "update Nominas set nom_sello_emisor = '" & selloCFDI2 & "', nom_sello_sat ='" & selloSAT2 & "' where nom_folio_sat_uuid='" & varNomIdNom & "'"
        'Dim ds As New DataSet
        'Dim sinfo As String = ""
        'Dim odata As New ToolKitSQL.oledbdata
        'If odata.dbOpen(cnn, sTarget, sinfo) = True Then
        ' If odata.runSp(cnn, sSQL, sinfo) Then
        'End If
        'cnn.Close()
        'Else
        ' MsgBox(sinfo)
        ' End If

    End Sub








End Module
