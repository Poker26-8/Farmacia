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
Imports System.Data.SqlClient
Imports MySql.Data



Module Facturacion

    Public Const CK_KEY = "RSAT34MB34N_7F1CD986683M"
    Public xmldoc As New Xml.XmlDocument
    Public glob_certificado_empresa As String
    Public glob_numero_decertificado_empresa As String
    Public glob_pass_key As String
    Public glob_sello_cfdi As String

    Public ConCertificado As String
    Private m_xmlDOM As New XmlDocument
    Private c As Integer

    Dim nombree As String = ""
    Dim cuentamail As String = ""
    Dim passmail As String = ""
    Dim servidor As String = ""
    Dim puerto As String = ""
    Dim seguridad As Boolean = False
    Public clave_productod As String = ""
    Public Function FormatearSerieCert(ByVal Serie As String) As String
        Dim Resultado As String = ""
        Dim I As Integer

        For I = 2 To Len(Serie) Step 2
            Resultado = Resultado & Mid(Serie, I, 1)
        Next

        FormatearSerieCert = Resultado
    End Function

    Private Function maxidfactu() As Integer
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(nom_id) as maxi from Facturas", sinfo1) Then
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

    Private Function maxidcarta() As Integer
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(Id) as maxi from CartaPorteI", sinfo1) Then
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

    Public Sub cancelapar(ByVal uuid_noms As String, ByVal rfc_noms As String, ByVal foliof As String, ByVal FolioUnido As String, ByVal EmiRazonSocial As String, ByVal varidpar As String, ByVal varTipoCancelacion As String, ByVal varuuidcancel As String)

        Dim newcarpeta As String = Replace(EmiRazonSocial, Chr(34), "").ToString

        Dim x As Boolean = False
        If rfc_noms = "AAA010101AAA" Or rfc_noms = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If
        'En este ejemplo se muestra como cancelar un comprobante xml, previamente timbrado
        'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
        'Fasle = Ambiente de pruebas
        'True = Ambiente de producción
        Dim conector As New Profact.TimbraCFDI40.Conector(x)
        'Establecemos las credenciales para el permiso de conexión
        'Ambiente de pruebas = mvpNUXmQfK8=
        'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
        If rfc_noms = "AAA010101AAA" Or rfc_noms = "IIA040805DZ4" Then
            conector.EstableceCredenciales("mvpNUXmQfK8=")
        Else
            conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
        End If
        'Rfc Emisor
        Dim rfcEmisor As String = rfc_noms.Trim
        'Folio Fiscal - UUID
        Dim folioFiscal As String = uuid_noms.Trim

        Dim motivoCancelacion As String = varTipoCancelacion.Trim
        'Folio Fiscal - UUID a sustituir
        Dim uuidSustitucion = varuuidcancel.Trim
        If (motivoCancelacion = "01") Then
            'Si el valor de Motivo es 01, el UUID para sustituir es requerido
            If (uuidSustitucion = "") Then
                MessageBox.Show("Cuando el Motivo de cancelación es 01, se debe registrar el folio fiscal a sustituir")
            End If
        End If

        'Obtenemos el xml por medio del conector y guardamos resultado'
        Dim resultadoCancelacion As Profact.TimbraCFDI.ResultadoCancelacionAck
        resultadoCancelacion = conector.CancelaCFDIAck40(rfcEmisor, folioFiscal, motivoCancelacion, uuidSustitucion)

        'Verificamos el resultado
        If (resultadoCancelacion.Exitoso) Then
            'El comprobante fue cancelado exitosamente
            MessageBox.Show("Cancelación exitosa " + resultadoCancelacion.Descripcion)
            Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
            resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)
            'Verificamos el resultado
            If (resultadoConsulta.Exitoso) Then
                Dim destino As String = ""
                'El comprobante fue consultado exitosamente
                Dim tipo As String = ""
                Dim tipo2 As String = ""
                'Guardamos xml cfdi
                Dim rutaftp2 As String = ""
                Dim ruta_acuse As String = ""
                Dim nombre_acuse As String = "Acuse_" & FolioUnido & ".xml"
                ruta_acuse = "C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\PARCIALIDADES\Acuses\"

                If varrutabase <> "" Then
                    ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\PARCIALIDADES\Acuses\"
                End If

                crea_ruta(ruta_acuse)
                If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                    MsgBox("El xml fue guardado correctamente")
                    cancela_parcialidad(varidpar)
                Else
                    MsgBox("Ocurrió un error al guardar el comprobante")
                End If
            Else
                'No se pudo consultar, mostramos respuesta
                MsgBox(resultadoConsulta.Descripcion)
            End If
        Else
            'No se pudo cancelar, mostramos respuesta
            If resultadoCancelacion.Descripcion = "UUID Previamente cancelado." Then
                cancela_parcialidad(varidpar)
                Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
                resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)
                'Verificamos el resultado
                If (resultadoConsulta.Exitoso) Then
                    Dim destino As String = ""
                    'El comprobante fue consultado exitosamente
                    Dim tipo As String = ""
                    Dim tipo2 As String = ""
                    'Guardamos xml cfdi
                    Dim rutaftp2 As String = ""
                    Dim ruta_acuse As String = ""
                    Dim nombre_acuse As String = "Acuse_" & FolioUnido & ".xml"
                    ruta_acuse = "C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\PARCIALIDADES\Acuses\"
                    If varrutabase <> "" Then
                        ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\PARCIALIDADES\Acuses\"
                    End If
                    crea_ruta(ruta_acuse)
                    If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                        MsgBox("El xml fue guardado correctamente")
                        cancela_parcialidad(varidpar)
                        Try
                            Dim root_name_recibo As String = ruta_acuse & nombre_acuse
#Disable Warning BC42024 ' Variable local sin usar: 'sinfo'.
                            Dim sinfo As String
#Enable Warning BC42024 ' Variable local sin usar: 'sinfo'.
                        Catch ex As Exception
                        End Try
                    Else
                        ' MessageBox.Show("Ocurrió un error al guardar el comprobante")
                        MsgBox("Ocurrió un error al guardar el comprobante")
                    End If
                    MsgBox("Consulta exitosa")
                Else
                    'No se pudo consultar, mostramos respuesta
                    MsgBox("Cancelacion sin acuse intentelo mas tarde")
                End If
            End If
            MessageBox.Show(resultadoCancelacion.Descripcion)
        End If

    End Sub

    Private Sub cancela_parcialidad(ByVal varidpar As String)

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        'MsgBox(frmParcialidades.cboFolioPar.Text)
        Dim sSQL As String = "update Parcialidades set Estatus_par = 2 where Id=" & varidpar & "" ' & frmParcialidades.cboFolioPar.SelectedValue
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            If odata.runSp(cnn, sSQL, sinfo) Then
                'frm_facturacion.lbl_estatus.Text = "Cancelada"
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub


    Public Function GeneraXMLParcialidades(ByRef FolioFact As String, ByRef FolioPar As String, ByRef EmiNombre As String, ByRef EmiRFC As String, ByRef CodigoPostal As String, ByRef serie As String, ByRef EmiRegFis As String,
                                           ByRef CliRFC As String, ByRef CliNombre As String, ByRef NumOpe As String, ByRef MontoPar As String, ByRef FormaPagoPar As String, ByRef dgv As DataGridView, ByRef IDParci As String,
                                           ByVal FechPag As String, ByVal NumCta As String, ByVal NumCtaCliente As String, ByVal CtaRFCEmi As String, ByVal CtaRFCCli As String, ByVal Banco As String)

        Dim nombreCFD As String = ""
        Dim tretencionesp As Double = 0

        Dim newrazonsocial As String = EmiNombre 'Replace(razon_social, Chr(34), "&quot").ToString
        Dim newcarpeta As String = Replace(EmiNombre, Chr(34), "").ToString

        nombreCFD = "PP" & FolioPar & "-" & FolioFact & ".xml"

        crea_dir("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\")

        Dim miXml As XmlTextWriter
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\")
            miXml = New XmlTextWriter("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)

        Else
            crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\")
            miXml = New XmlTextWriter("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        End If
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechaFormateada2 As String
        Dim fechacreacion As DateTime = Now

        fechaFormateada = DateAndTime.Now.ToString("s")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-ddTHH:mm:ss")
        fechaFormateada2 = FechPag 'frmParcialidades.dtpFechaPago.Value.ToString("yyyy-MM-ddTHH:mm:ss")

        With miXml
            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE
            .WriteStartElement("cfdi:Comprobante")
            'aqui empece
            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/4")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            .WriteStartAttribute("xsi:schemaLocation")
            .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:pago20")
            .WriteValue("http://www.sat.gob.mx/Pagos20")
            .WriteEndAttribute()

            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(CodigoPostal)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            .WriteValue("P")
            .WriteEndAttribute()

            .WriteStartAttribute("Exportacion")
            .WriteValue("01")
            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("XXX")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue("" & fechaFormateada1 & "")
            .WriteEndAttribute()

            .WriteStartAttribute("Folio")
            .WriteValue("PP" & FolioPar)
            .WriteEndAttribute()

            .WriteStartAttribute("Version")
            .WriteValue("4.0")
            .WriteEndAttribute()

            .WriteStartAttribute("Serie")
            .WriteValue(serie)
            .WriteEndAttribute()

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")
            .WriteAttributeString("Rfc", EmiRFC)
            .WriteAttributeString("Nombre", EmiNombre)
            .WriteAttributeString("RegimenFiscal", EmiRegFis)
            .WriteEndElement() 'Emisor


            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Rfc", CliRFC)
            .WriteAttributeString("Nombre", CliNombre)
            .WriteAttributeString("UsoCFDI", "CP01")
            .WriteAttributeString("DomicilioFiscalReceptor", frmParcialidades.txtCPCLiente.Text)
            .WriteAttributeString("RegimenFiscalReceptor", frmParcialidades.txtCliRegFis.Text)
            .WriteEndElement() 'receptor

            '=========================== COMIENZA CONCEPTO

            .WriteStartElement("cfdi:Conceptos")

            .WriteStartElement("cfdi:Concepto")
            .WriteAttributeString("Cantidad", "1")
            .WriteAttributeString("Descripcion", "Pago")
            .WriteAttributeString("ValorUnitario", "0")
            .WriteAttributeString("Importe", "0")
            .WriteAttributeString("ClaveUnidad", "ACT")
            .WriteAttributeString("ClaveProdServ", "84111506")
            .WriteAttributeString("ObjetoImp", "01")
            .WriteEndElement() ' fin concepto

            .WriteEndElement() ' fin concepto

            '=========================== COMIENZA complemento

            .WriteStartElement("cfdi:Complemento")

            '=========================== COMIENZA pagos

            Dim opeiva As Double = 0
            Dim opeivaret As Double = 0
            Dim opeisr As Double = 0
            Dim opeieps As Double = 0
            Dim opeiva0 As Double = 0

            Dim opeivabase As Double = 0
            Dim opeivaretbase As Double = 0
            Dim opeisrbase As Double = 0
            Dim opeiepsbase As Double = 0
            Dim opeiva0base As Double = 0

            For i = 0 To frmParcialidades.GridParcialidades.RowCount - 2

                opeiva = opeiva + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)
                opeivaret = opeivaret + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString)
                opeieps = opeieps + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString)
                opeisr = opeisr + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString)
                opeiva0 = opeiva0 + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString)

                opeivabase = opeivabase + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(41).Value.ToString)
                opeivaretbase = opeivaretbase + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(43).Value.ToString)
                opeisrbase = opeisrbase + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(42).Value.ToString)
                opeiepsbase = opeiepsbase + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString)
                opeiva0base = opeiva0base + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(44).Value.ToString)

            Next

            opeiepsbase = opeiepsbase - opeieps
            opeiva0base = opeiva0base - opeiva0

            .WriteStartElement("pago20:Pagos")
            .WriteAttributeString("Version", "2.0")
            .WriteAttributeString("xmlns:pago20", "http://www.sat.gob.mx/Pagos20")

            .WriteStartElement("pago20:Totales")
            .WriteAttributeString("MontoTotalPagos", Replace(FormatNumber(frmParcialidades.txtTotalPagos.Text, 2), ",", "")) '.WriteAttributeString("MontoTotalPagos", "100.00")

            If CDec(frmParcialidades.txtTotalIVA.Text) > 0 Then
                .WriteAttributeString("TotalTrasladosBaseIVA16", Replace(FormatNumber(opeivabase + opeieps, 2), ",", "")) '.WriteAttributeString("TotalTrasladosBaseIVA16", "86.21")
                .WriteAttributeString("TotalTrasladosImpuestoIVA16", Replace(opeiva, ",", "")) '.WriteAttributeString("TotalTrasladosImpuestoIVA16", "13.79")
            End If

            If CDec(frmParcialidades.txtTotalIVA0.Text) > 0 Then
                .WriteAttributeString("TotalTrasladosBaseIVA0", Replace(opeiva0, ",", "")) '.WriteAttributeString("TotalTrasladosBaseIVA16", "86.21")
                .WriteAttributeString("TotalTrasladosImpuestoIVA0", Replace("0", ",", "")) '.WriteAttributeString("TotalTrasladosImpuestoIVA16", "13.79")
            End If

            If CDec(frmParcialidades.txtTotalIEPS.Text) > 0 Then
                .WriteAttributeString("TotalRetencionesIEPS", Replace(opeieps, ",", ""))
            End If

            If CDec(frmParcialidades.txtTotalIVAret.Text) > 0 Then
                .WriteAttributeString("TotalRetencionesIVA", Replace(opeivaret, ",", ""))
            End If

            If CDec(frmParcialidades.txtTotalISR.Text) > 0 Then
                .WriteAttributeString("TotalRetencionesISR", Replace(opeisr, ",", ""))
            End If

            .WriteEndElement()


            .WriteStartElement("pago20:Pago")

            If NumCtaCliente <> "" Then
                .WriteAttributeString("CtaBeneficiario", NumCtaCliente)
            End If

            If CtaRFCCli <> "" Then
                .WriteAttributeString("RfcEmisorCtaBen", CtaRFCCli)
            End If

            If NumCta <> "" Then
                .WriteAttributeString("CtaOrdenante", NumCta)
            End If

            If Banco <> "" Then
                '.WriteAttributeString("NomBancoOrdExt", Banco)
            End If

            If CtaRFCEmi <> "" Then
                .WriteAttributeString("RfcEmisorCtaOrd", CtaRFCEmi)
            End If

            If NumOpe <> "" Then
                .WriteAttributeString("NumOperacion", NumOpe)
            End If

            .WriteAttributeString("Monto", Replace(FormatNumber(MontoPar, 2), ",", ""))
            .WriteAttributeString("MonedaP", "MXN")
            .WriteAttributeString("FormaDePagoP", FormaPagoPar)
            .WriteAttributeString("FechaPago", fechaFormateada2)
            .WriteAttributeString("TipoCambioP", "1")



            For i = 0 To frmParcialidades.GridParcialidades.RowCount - 2
                .WriteStartElement("pago20:DoctoRelacionado")
                .WriteAttributeString("Folio", FolioFact)
                .WriteAttributeString("ImpSaldoInsoluto", Replace(FormatNumber(dgv.Rows(i).Cells(3).Value.ToString, 2), ",", ""))
                .WriteAttributeString("ImpPagado", Replace(FormatNumber(dgv.Rows(i).Cells(2).Value.ToString, 2), ",", ""))
                .WriteAttributeString("ImpSaldoAnt", Replace(FormatNumber(dgv.Rows(i).Cells(1).Value.ToString, 2), ",", ""))
                .WriteAttributeString("NumParcialidad", dgv.Rows(i).Cells(4).Value.ToString)
                '.WriteAttributeString("MetodoDePagoDR", "PPD")
                .WriteAttributeString("MonedaDR", "MXN")
                If SeriePar <> "" Then
                    .WriteAttributeString("Serie", SeriePar)
                End If
                .WriteAttributeString("IdDocumento", dgv.Rows(i).Cells(8).Value.ToString)
                .WriteAttributeString("EquivalenciaDR", "1")
                .WriteAttributeString("ObjetoImpDR", "02")

                If frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                    .WriteStartElement("pago20:ImpuestosDR")

                    If frmParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Then

                        .WriteStartElement("pago20:RetencionesDR")

                        If frmParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Then
                            'iva retenido
                            .WriteStartElement("pago20:RetencionDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(43).Value.ToString)
                            'newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) - CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(frmParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString, ",", ""))
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", frmParcialidades.GridParcialidades.Rows(i).Cells(15).Value.ToString)
                            '.WriteAttributeString("TasaOCuotaDR", "0.040000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin retencion dr

                        End If

                        If frmParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Then
                            'isr
                            .WriteStartElement("pago20:RetencionDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(42).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(frmParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString, ",", ""))
                            .WriteAttributeString("ImpuestoDR", "001")
                            .WriteAttributeString("TasaOCuotaDR", frmParcialidades.GridParcialidades.Rows(i).Cells(14).Value.ToString)
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin retencion dr

                        End If

                        If frmParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Then
                            'ieps

                            Dim str As String = ""
                            Dim str1(15) As String
                            Dim contarray As Integer = 0
                            For x = 1 To Len(frmParcialidades.GridParcialidades.Rows(i).Cells(16).Value.ToString)
                                str = Mid$(frmParcialidades.GridParcialidades.Rows(i).Cells(16).Value.ToString, x, 1)
                                If str = "," Then
                                    contarray = contarray + 1
                                Else
                                    str1(contarray) = str1(contarray) & str
                                End If
                            Next

                            Dim totalbaseieps As Double = 0
                            totalbaseieps = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(29).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(30).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(31).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(32).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(33).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(34).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(35).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(37).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(38).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(39).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(40).Value.ToString)

                            For x1 = 0 To contarray

                                .WriteStartElement("pago20:RetencionDR")

                                Dim newbase As Double = 0

                                Select Case Trim(str1(x1))
                                    Case "0.030000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(40).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.03
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.060000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(39).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.06
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.070000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(38).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.07
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.080000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(37).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.08
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.090000"
                                        'newbase = FormatNumber(CDec(100 * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString)) / totalbaseieps, 2)
                                        'newbase = FormatNumber(CDec(newbase * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString)) / 100, 2)
                                        'newbase = newbase / 1.09
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.09
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.250000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(35).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.25
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.265000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(34).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.265
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.300000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(33).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.3
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.304000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(32).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.304
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.500000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(31).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.5
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.530000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(30).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.53
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "1.600000"
                                        newbase = FormatNumber(CDec(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(29).Value.ToString)) / CDec(frmParcialidades.txtTotalFact.Text), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 2.6
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                End Select

                                .WriteAttributeString("ImpuestoDR", "003")
                                .WriteAttributeString("TasaOCuotaDR", Trim(str1(x1)))
                                .WriteAttributeString("TipoFactorDR", "Tasa")

                                .WriteEndElement() ' fin retencion dr

                            Next

                        End If

                        .WriteEndElement() ' fin retenciones dr

                    End If

                    If frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Or frmParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                        .WriteStartElement("pago20:TrasladosDR")

                        If frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Then

                            .WriteStartElement("pago20:TrasladoDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(41).Value.ToString) + CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString)
                            'newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) - CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(FormatNumber(CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString), 2), ",", ""))
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", "0.160000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin traslado dr

                        End If

                        If frmParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                            .WriteStartElement("pago20:TrasladoDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", "0.00")
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", "0.000000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin traslado dr

                        End If

                        .WriteEndElement() ' fin traslados dr

                    End If

                    .WriteEndElement() ' fin impuestos dr

                End If

                .WriteEndElement() ' fin documento relacionado

            Next

            .WriteStartElement("pago20:ImpuestosP")

            If opeivaret > 0 Or opeisr > 0 Or opeieps > 0 Then

                .WriteStartElement("pago20:RetencionesP")

                If opeivaret > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeivaret, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "002")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If

                If opeisr > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeisr, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "001")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If

                If opeieps > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeieps, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "003")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If


                .WriteEndElement() ' fin Retenciones dr

            End If

            If opeiva > 0 Then
                .WriteStartElement("pago20:TrasladosP")

                .WriteStartElement("pago20:TrasladoP")

                .WriteAttributeString("BaseP", Replace(opeivabase + opeieps, ",", ""))
                .WriteAttributeString("ImporteP", Replace(FormatNumber(opeiva, 2), ",", ""))
                .WriteAttributeString("ImpuestoP", "002")
                .WriteAttributeString("TasaOCuotaP", "0.160000")
                .WriteAttributeString("TipoFactorP", "Tasa")

                .WriteEndElement() ' fin traslado dr

                If opeiva0 > 0 Then
                    .WriteStartElement("pago20:TrasladoP")

                    .WriteAttributeString("BaseP", Replace(opeiva0, ",", ""))
                    .WriteAttributeString("ImporteP", "0.00")
                    .WriteAttributeString("ImpuestoP", "002")
                    .WriteAttributeString("TasaOCuotaP", "0.000000")
                    .WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin traslado dr
                End If

                .WriteEndElement() ' fin traslados dr

            End If

            If opeiva0 > 0 And opeiva <= 0 Then
                .WriteStartElement("pago20:TrasladosP")

                .WriteStartElement("pago20:TrasladoP")

                .WriteAttributeString("BaseP", Replace(opeiva0, ",", ""))
                .WriteAttributeString("ImporteP", "0.00")
                .WriteAttributeString("ImpuestoP", "002")
                .WriteAttributeString("TasaOCuotaP", "0.000000")
                .WriteAttributeString("TipoFactorP", "Tasa")

                .WriteEndElement() ' fin traslado dr

                .WriteEndElement() ' fin traslados dr

            End If

            .WriteEndElement() ' fin impuestos dr

            .WriteEndElement() ' fin pago

            .WriteEndElement() ' fin pagos

            .WriteEndElement() ' fin complemento

            .WriteEndElement() ' fin comprobante

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML

        If varrutabase <> "" Then
            xmldoc.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Load("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\" & nombreCFD)
        End If

        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml
        If varrutabase <> "" Then
            xmldoc.Save("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Save("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\Temporales\" & nombreCFD)
        End If
        '================================= termina xml base3

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""

        Dim varSello As String = ""
        Dim varNoCert As String = ""
        Dim varCertificado As String = ""
        Dim varUuid As String = ""
        Dim varSelloSat As String = ""
        Dim varSelloCFD As String = ""
        Dim varNoCertSat As String = ""
        Dim varFechatim As String = ""

        frmParcialidades.ProgressBar1.Value = 60
        frmParcialidades.lbl_proceso.Text = "Creando XML Timbrado ..."
        My.Application.DoEvents()

        If timbre_Par(FolioFact, serie, "PP" & FolioPar, folio_sat_uuid, fecha_folio_sat, newcarpeta, EmiRFC, cadena_orig, no_csd_emp, certificado_sat) Then

            Dim Lector As System.Xml.XmlTextReader

            If varrutabase = "" Then
                crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\")

                Lector = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)
            Else
                crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\")
                crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\")

                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector.Name = "tfd:TimbreFiscalDigital" Then
                            If Lector.HasAttributes Then
                                While Lector.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector.Name
                                        Case "UUID"
                                            varUuid = Lector.Value
                                        Case "SelloCFD"
                                            varSelloCFD = Lector.Value
                                        Case "NoCertificadoSAT"
                                            varNoCertSat = Lector.Value
                                        Case "SelloSAT"
                                            varSelloSat = Lector.Value
                                        Case "FechaTimbrado"
                                            varFechatim = Lector.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            Dim Lector1 As System.Xml.XmlTextReader = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)

            If varrutabase <> "" Then
                Lector1 = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)
            End If

            Do While (Lector1.Read())
                Select Case Lector1.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector1.Name = "cfdi:Comprobante" Then
                            If Lector1.HasAttributes Then
                                While Lector1.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector1.Name
                                        Case "Sello"
                                            varSello = Lector1.Value
                                        Case "NoCertificado"
                                            varNoCert = Lector1.Value
                                        Case "Certificado"
                                            varCertificado = Lector1.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop


            '   cadena_orig = CadenaOrg(folio_sat_uuid, fecha_folio_sat, sello_emisor, certificado_sat)
            frmParcialidades.ProgressBar1.Value = 70
            frmParcialidades.lbl_proceso.Text = "Guardando Datos Factura ..."
            My.Application.DoEvents()
            'actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, ESTATUS_FACTURA, id_evento)
            actualizaParcialidad(varUuid, varSello, varNoCert, varCertificado, varSelloCFD, varNoCertSat, varSelloSat, varFechatim, IDParci, cadena_orig)

            frmParcialidades.ProgressBar1.Value = 75

            frmParcialidades.lbl_proceso.Text = "Generando Qr ..."
            My.Application.DoEvents()
            'ima_qr(frmParcialidades.txtEmiRfc.Text, frmParcialidades.txtCliRfc.Text, frmParcialidades.txtMontoPar.Text, folio_sat_uuid, id_evento, frmParcialidades.txtEmiNombre.Text)

            ima_qrpar(EmiRFC, CliRFC, MontoPar, folio_sat_uuid, FolioPar & "-" & FolioFact, newcarpeta)
            Return True

        Else
            'actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, ESTATUS_FACTURA_ERROR, id_evento)
            'actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, ESTATUS_FACTURA_ERROR, FolioPar & "-" & FolioFact)
            Return False
        End If

    End Function

    Public Sub ima_qrpar(ByVal rfc_empresa As String, ByVal rfc_receptor As String, ByVal totalc As String, ByVal foliofis As String, ByVal id_evento As String, ByVal razon_social As String)
        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\imagenes\")

        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\imagenes\")
        End If

        Dim qre As New QrCodeImgControl
        qre.Size = New System.Drawing.Size(200, 200)
        qre.Text = "?re=" & rfc_empresa & "&rr=" & rfc_receptor & "&tt=" & totalc & "&id=" & foliofis
        Dim ima As Image = DirectCast(qre.Image.Clone, Image)

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg")
        End If

        ima.Save("C:\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg")

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg")
            End If
            ima.Save("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\imagenes\PP" & id_evento & ".jpg")
        End If

    End Sub
    Public Function timbre_Par(ByVal folioFact As String, ByVal serie As String, ByVal folio As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal razon_social As String, ByVal frcemisor As String, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String)

        Dim x As Boolean = False
        If frcemisor = "AAA010101AAA" Or frcemisor = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If

        Dim conector As New Profact.TimbraCFDI40.Conector(x)
#Disable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim idError As Integer
#Enable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim NError As String
#Disable Warning BC42024 ' Variable local sin usar: 'uuid'.
        Dim uuid As String
#Enable Warning BC42024 ' Variable local sin usar: 'uuid'.
#Disable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.
        Dim xmlTimbrado As String
#Enable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.

        Dim razon_ruta As String = ""
        Dim id As String
        Dim documentoXml As XmlDocument
        Dim nombreCFD As String = ""

        nombreCFD = folio & "-" & folioFact & ".xml"
        razon_ruta = Replace(razon_social, Chr(34), "").ToString()



        documentoXml = New XmlDocument

        id = folio & "-" & folioFact
        'id = serie & folio

        If varrutabase <> "" Then
            'XML Timbrado
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\")
            crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\")
            'XML Temporal
            documentoXml.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\Temporales\" & nombreCFD)

        Else
            'XML Timbrado
            crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\")
            'XML Temporal
            documentoXml.Load("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\Temporales\" & nombreCFD)
        End If

        Try
            'Este ejemplo está dirigido a aquellos integradores que ya generan el xml (CFDI) y solo desean timbrarlo

            'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
            'Fasle = Ambiente de pruebas
            'True = Ambiente de producción

            'Establecemos las credenciales para el permiso de conexión
            'Ambiente de pruebas = mvpNUXmQfK8=
            'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo

            If frcemisor = "AAA010101AAA" Or frcemisor = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = "C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\Temporales\" & nombreCFD

            If varrutabase <> "" Then
                'En los usuarios siempre agarra este
                rutaArchivo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\Temporales\" & nombreCFD
            End If

            'Timbramos el CFDI por medio del conector y guardamos resultado
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)

            crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\cd\PARCIALIDADES\")

            If varrutabase <> "" Then
                crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\cd\PARCIALIDADES\")
            End If

            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then
                'El comprobante fue timbrado exitosamente

                'Guardamos xml cfdi en equipo local
                If resultadoTimbre.GuardaXml("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\", nombreCFD) Then
                Else
                    'MessageBox.Show("Ocurrió un error al guardar el comprobante" & vbNewLine & "Equipo local")
                End If

                'Guardamos xml cfdi en equipo servidor
                If varrutabase <> "" Then
                    If (resultadoTimbre.GuardaXml("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\", nombreCFD)) Then
                    Else
                        ' MessageBox.Show("Ocurrió un error al guardar el comprobante" & vbNewLine & "Equipo Servidor")
                    End If
                End If

                'Generación de código QR local
                If (resultadoTimbre.GuardaCodigoBidimensional("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\cd\PARCIALIDADES\", folio & "-" & folioFact)) Then
                Else
                    'MessageBox.Show("Ocurrió un error al guardar el código QR" & vbNewLine & "Equipo local")
                End If

                'Generación de código QR servidor
                If varrutabase <> "" Then
                    If (resultadoTimbre.GuardaCodigoBidimensional("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\cd\PARCIALIDADES\", folio & "-" & folioFact)) Then
                    Else
                        MessageBox.Show("Ocurrió un error al guardar el código QR" & vbNewLine & "Equipo servidor")
                    End If
                End If

                If Not File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\" & nombreCFD) Then
                    If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\" & nombreCFD) Then
                        File.Copy("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\" & nombreCFD, "C:\ControlNegociosPro\ARCHIVOSDL1\" & razon_ruta & "\XML\PARCIALIDADES\" & nombreCFD)
                    End If
                End If

                '2.- Folio fiscal
                Dim foliFiscal As String = resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor
                Dim noCertificado As String = resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT
                Dim noCertificadoSat As String = resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación
                Dim fechaCert As String = resultadoTimbre.FechaCertificacion


                '6.- Sello del cfdi
                Dim selloCFDI As String = resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                '   MessageBox.Show("Timbrado Exitoso")

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                actualiza_timbres(frcemisor)
            Else
                'No se pudo timbrar, mostramos respuesta
                MessageBox.Show(resultadoTimbre.Descripcion)
                MessageBox.Show(resultadoTimbre.Detalle)
                Return False
            End If

        Catch ex As Exception
#Disable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            MsgBox("Error: " & NError & "- " & ex.Message)
#Enable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & NError & "- " & ex.Message, "", "")
            Return False
        End Try
        Return True

    End Function

    Private Sub actualizaParcialidad(ByVal uuid As String, ByVal sello As String, ByVal NoCert As String, ByVal certif As String, ByVal SelloCFD As String, ByVal NoCertSat As String,
                                ByVal selloSat As String, ByRef FechaTimbrado As String, ByRef IdPar As String, ByRef cadena As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "update Parcialidades set Certificado ='" & certif & "', UUID='" & uuid & "', Sello='" & sello & "',NoCert='" & NoCert & "',SelloCFD='" &
                                SelloCFD & "',NoCertSat='" & NoCertSat & "',SelloSat='" & selloSat & "',FechaTimbrado='" & FechaTimbrado & "', CadenaOriginal = '" & cadena & "' where Id =" & IdPar & ""
        'Dim sSQL As String = "update Parcialidades set Certificado ='" & certif & "', UUID='" & uuid & "', Sello='" & sello & "',NoCert='" & NoCert & "',SelloCFD='" & _
        '                        SelloCFD & "',NoCertSat='" & NoCertSat & "',SelloSat='" & selloSat & "',FechaTimbrado='" & FechaTimbrado & "', CadenaOriginal = '" & cadena & "' where Id=" & IdPar & ""
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then
            Else
            End If
            cnn.Close()
        End If

    End Sub

    Public Function envio(ByVal paraf As String, ByVal asuntof As String, ByVal mensajef As String, ByVal archivof As String, ByVal archivof2 As String)
        If archivof <> "" Then
            recupera_campos()

            Dim mail As New MailMessage
            Dim oAttch As Net.Mail.AttachmentBase = New Net.Mail.Attachment(archivof)
            Dim oAttch2 As Net.Mail.AttachmentBase
            If frmfacturacion.Cmb_TipoFact.Text <> "PREFACTURA" Then
                oAttch2 = New Net.Mail.Attachment(archivof2)
            End If
            Try
                mail.From = New MailAddress(cuentamail, nombree)
                mail.To.Add(paraf)
                mail.Subject = (asuntof)
                mail.Body = (mensajef)
                mail.Attachments.Add(oAttch)
                If frmfacturacion.Cmb_TipoFact.Text <> "PREFACTURA" Then
#Disable Warning BC42104 ' La variable 'oAttch2' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    mail.Attachments.Add(oAttch2)
#Enable Warning BC42104 ' La variable 'oAttch2' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                End If
                Dim servidorx As New SmtpClient(servidor)
                servidorx.Port = puerto
                servidorx.EnableSsl = seguridad
                servidorx.Credentials = New System.Net.NetworkCredential(cuentamail, passmail)
                servidorx.Send(mail)

                MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                Return False
            End Try
        End If
#Disable Warning BC42105 ' La función 'envio' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function
#Enable Warning BC42105 ' La función 'envio' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.


    Public Function envioPDF(ByVal paraf As String, ByVal asuntof As String, ByVal mensajef As String, ByVal archivof As String)
        If archivof <> "" Then
            recupera_campos()

            Dim mail As New MailMessage
            Dim oAttch As Net.Mail.AttachmentBase = New Net.Mail.Attachment(archivof)
            Dim oAttch2 As Net.Mail.AttachmentBase
            'If frmfacturacion.Cmb_TipoFact.Text <> "COTIZACION" Then
            '    oAttch2 = New Net.Mail.Attachment(archivof2)
            'End If
            Try
                mail.From = New MailAddress(cuentamail, nombree)
                mail.To.Add(paraf)
                mail.Subject = (asuntof)
                mail.Body = (mensajef)
                mail.Attachments.Add(oAttch)
                If frmfacturacion.Cmb_TipoFact.Text <> "COTIZACION" Then

                End If
                Dim servidorx As New SmtpClient(servidor)
                servidorx.Port = puerto
                servidorx.EnableSsl = seguridad
                servidorx.Credentials = New System.Net.NetworkCredential(cuentamail, passmail)
                servidorx.Send(mail)

                MessageBox.Show("Mensaje enviado correctamene", "Exito!", MessageBoxButtons.OK)
                Return True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
                Return False
            End Try
        End If
#Disable Warning BC42105 ' La función 'envio' no devuelve un valor en todas las rutas de acceso de código. Puede producirse una excepción de referencia NULL en tiempo de ejecución cuando se use el resultado.
    End Function

    Private Sub recupera_campos()
        conexionlocal()
        'cnn1.Close() : cnn1.Open()
        'cmd1 = cnn1.CreateCommand
        'cmd1.CommandText = ""
        'rd1 = cmd1.ExecuteReader
        'If rd1.HasRows Then
        '    If rd1.Read Then

        '    End If
        'End If
        'rd1.Close()
        'cnn1.Close()

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "SELECT * FROM Formatos"
        Dim sinfo As String = ""
        Dim dr As DataRow
        Dim dt As New DataTable
        Dim oData As New ToolKitSQL.myssql
        With oData
            If .dbOpen(cnn, sTargetlocal, sinfo) Then
                If .getDt(cnn, dt, sSQL, sinfo) Then
                    For Each dr In dt.Rows
                        Select Case dr("Facturas").ToString
                            Case "Mail_Emi"
                                cuentamail = dr("NotasCred").ToString
                            Case "Shibboleth_ML"
                                passmail = dr("NotasCred").ToString
                            Case "Server_SMTP"
                                servidor = dr("NotasCred").ToString
                            Case "Pto_Mail"
                                puerto = dr("NotasCred").ToString
                            Case "SSL"
                                seguridad = dr("NotasCred").ToString
                        End Select
                    Next
                    seguridad = True
                    nombree = varnomemail
                Else
                    MsgBox("Error en la configuracion de correo")
                End If
                cnn.Close()
            Else
                MsgBox(sinfo)
            End If
        End With
    End Sub

    Public Sub cancela(ByVal uuid_noms As String, ByVal rfc_noms As String, ByVal foliof As String, ByVal varTipoCancelacion As String, ByVal varuuidcancel As String)


        Dim newcarpeta As String = Replace(frmfacturacion.cbo_emisor.Text, Chr(34), "").ToString
        Dim x As Boolean = False
        If rfc_noms = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If
        Dim conector As New Profact.TimbraCFDI40.Conector(x)
        If rfc_noms = "IIA040805DZ4" Then
            conector.EstableceCredenciales("mvpNUXmQfK8=")
        Else
            conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
        End If
        'Rfc Emisor
        Dim rfcEmisor As String = rfc_noms.Trim

        'Folio Fiscal - UUID
        Dim folioFiscal As String = uuid_noms.Trim

        'Motivo
        Dim motivoCancelacion As String = varTipoCancelacion.Trim

        'Folio Fiscal - UUID a sustituir
        Dim uuidSustitucion = varuuidcancel.Trim

        If (motivoCancelacion = "01") Then
            'Si el valor de Motivo es 01, el UUID para sustituir es requerido
            If (uuidSustitucion = "") Then
                MessageBox.Show("Cuando el Motivo de cancelación es 01, se debe registrar el folio fiscal a sustituir")
            End If
        End If

        Dim resultadoCancelacion As Profact.TimbraCFDI.ResultadoCancelacionAck

        resultadoCancelacion = conector.CancelaCFDIAck40(rfcEmisor, folioFiscal, motivoCancelacion, uuidSustitucion)

        If (resultadoCancelacion.Exitoso) Then
            'El comprobante fue cancelado exitosamente
            MessageBox.Show("Cancelación exitosa " + resultadoCancelacion.Descripcion)

            Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
            resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)

            'Verificamos el resultado
            If (resultadoConsulta.Exitoso) Then
                Dim destino As String = ""
                'El comprobante fue consultado exitosamente
                Dim tipo As String = ""
                Dim tipo2 As String = ""
                'Guardamos xml cfdi
                Dim rutaftp2 As String = ""
                Dim ruta_acuse As String = ""
                Dim nombre_acuse As String = "Acuse_" & foliof & ".xml"
                Select Case frmfacturacion.Cmb_TipoFact.Text
                    Case "FACTURA"
                        If varrutabase <> "" Then
                            ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                        Else
                            ruta_acuse = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                        End If
                    Case "NOTA DE CREDITO"
                        If varrutabase <> "" Then
                            ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                        Else
                            ruta_acuse = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                        End If
                End Select
                crea_ruta(ruta_acuse)
                If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                    MsgBox("El xml fue guardado correctamente")
                    cancela_factura()
                Else
                    MsgBox("Ocurrió un error al guardar el comprobante")
                End If
            Else
                'No se pudo consultar, mostramos respuesta
                MsgBox(resultadoConsulta.Descripcion)
            End If
        Else
            'No se pudo cancelar, mostramos respuesta
            If resultadoCancelacion.Descripcion = "UUID Previamente cancelado." Then
                cancela_factura()
                Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
                resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)
                'Verificamos el resultado
                If (resultadoConsulta.Exitoso) Then
                    Dim destino As String = ""
                    'El comprobante fue consultado exitosamente
                    Dim tipo As String = ""
                    Dim tipo2 As String = ""
                    'Guardamos xml cfdi
                    Dim rutaftp2 As String = ""
                    Dim ruta_acuse As String = ""
                    Dim nombre_acuse As String = "Acuse_" & foliof & ".xml"
                    Select Case frmfacturacion.Cmb_TipoFact.Text
                        Case "FACTURA"
                            If varrutabase <> "" Then
                                ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                            Else
                                ruta_acuse = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                            End If
                        Case "NOTA DE CREDITO"
                            If varrutabase <> "" Then
                                ruta_acuse = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                            Else
                                ruta_acuse = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\" & frmfacturacion.Cmb_TipoFact.Text & "\Acuses\"
                            End If
                    End Select
                    crea_ruta(ruta_acuse)
                    If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                        MsgBox("El xml fue guardado correctamente")
                        cancela_factura()
                    Else
                        MsgBox("Ocurrió un error al guardar el comprobante")
                    End If
                    MsgBox("Consulta exitosa")
                Else
                    'No se pudo consultar, mostramos respuesta
                    MsgBox("Cancelacion sin acuse intentelo mas tarde")
                End If
            Else
                MessageBox.Show(resultadoCancelacion.Descripcion)
            End If
        End If
    End Sub

    Private Sub cancela_factura()
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "update Facturas set nom_status=2 where nom_id=" & frmfacturacion.Cmb_Nfactura.SelectedValue
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            If odata.runSp(cnn, sSQL, sinfo) Then
                frmfacturacion.lbl_estatus.Text = "Cancelada"
            End If
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If


        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL1 As String = "update Ventas set Facturado=0 where Facturado=" & frmfacturacion.Cmb_Nfactura.Text
        Dim ds1 As New DataSet
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        If odata1.dbOpen(cnn1, sTarget, sinfo1) = True Then
            If odata1.runSp(cnn1, sSQL1, sinfo1) Then
                frmfacturacion.lbl_estatus.Text = "Cancelada"
            End If
            cnn1.Close()
        Else
            MsgBox(sinfo1)
        End If



    End Sub

    Public Function Guarda_prefac(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                              ByVal total As String, ByVal metodo_pago As String, ByVal tipo_pago_e As String,
                              ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                              ByVal calle_empresa As String, ByVal num_empresa As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                              ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                              ByVal rfc_cliente As String, ByVal nombre_cliente As String, ByVal numero_domicilio_cliente As String,
                              ByVal calle_cliente As String, ByVal colonia_cliente As String, ByVal municipio_cliente As String,
                              ByVal cp_cliente As String, ByVal numero_cliente As String, ByVal regimen_empresa As String,
                              ByVal num_factura As String, ByVal reg_fiscal As String,
                              ByVal folio_sat_uuid As String, ByVal fecha_folio_sat As String, ByVal sello_emisor As String, ByVal sello_sat As String,
                              ByVal cadena_orig As String, ByVal csd_no_emp As String, ByVal csd_no_sat As String, ByVal nextcli As String,
                              ByVal id_evento As Integer, ByVal edocli As String, ByVal descripcion As String, ByVal descuento As String, ByVal iva As String,
                              ByVal preciopaq As String, ByVal numint_empresa As String)

        Dim estatuss1 As Integer = 3
        Select Case frmfacturacion.Cmb_TipoFact.Text
            Case "FACTURA"
                estatuss1 = ESTATUS_FACTURA
            Case "PREFACTURA"
                estatuss1 = ESTATUS_PREFACTURA
            Case "RECIBO DE ARRENDAMIENTO"
                estatuss1 = ESTATUS_ARRENDAMIENTO
            Case "RECIBO DE HONORARIOS"
                estatuss1 = ESTATUS_HONORARIOS
            Case "NOTA DE CREDITO"
                estatuss1 = ESTATUS_NOTASCREDITO
        End Select

        Dim sinfo As String = ""
        Dim sSQL As String = ""

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        sSQL = "Insert into Facturas(nom_id_cliente,nom_razon_social,nom_rfc_empresa,nom_reg_fiscal,nom_actividad_empresa,nom_calle_empresa," &
        "nom_colonia_empresa,nom_del_mun_empresa,nom_cp_empresa,nom_expedido,estado_empresa,nom_nombre_cliente,nom_calle_cliente,nom_colonia_cliente," &
        "nom_del_mun_cliente,nom_rfc_cliente,nom_folio,nom_metodo_pago,nom_tipo_pago," &
        "nom_folio_sat_uuid,nom_fecha_folio_sat,nom_sello_emisor,nom_sello_sat,nom_cadena_original," &
        "nom_total_pagado,nom_no_csd_emp,nom_no_csd_sat,estatus_fac,n_ext_cliente,id_evento,edo_cli,descripcion,descuento,iva,preciopaq,nom_fecha_factura, id_emisor,UsoCFDI,nom_cpago,nom_isr,nom_numext_empresa,nom_numint_empresa,nom_comercial_cli,nom_status)Values(" &
         numero_cliente & ", '" & Trim(Replace(razon_social, "'", "''")) & "', '" & rfc_empresa & "','" & reg_fiscal & "','" & actividad_empresa & "','" & calle_empresa &
         "','" & colonia_empresa & "','" & municipio_empresa & "','" & cp_empresa & "','" & pais_empresa & "', '" & estado_empresa & "','" & Trim(Replace(nombre_cliente, "'", "''")) &
         "','" & calle_cliente & "','" & colonia_cliente & "','" & municipio_cliente &
         "','" & rfc_cliente & "'," & folio & ",'" & metodo_pago &
         "','" & tipo_pago_e & "','" & folio_sat_uuid & "'," &
         "'" & fecha_folio_sat & "','" & sello_emisor & "','" & sello_sat & "','" & cadena_orig &
         "','" & Replace(total, ",", "") & "','" & csd_no_emp & "','" & csd_no_sat & "'," & ESTATUS_PREFACTURA & ",'" & nextcli & "'," &
         id_evento & ",'" & edocli & "','" & descripcion & "'," & Replace(descuento, ",", "") & "," & Replace(iva, ",", "") & "," & Replace(frmfacturacion.Text_SubTotal.Text, ",", "") & ",'" & Format(Now, "yyyy-MM-ddTHH:mm:ss") & "'," & frmfacturacion.cbo_emisor.SelectedValue & ",'" & frmfacturacion.cbo_usocfdi.SelectedValue & "', '" & frmfacturacion.Text_CondiPago.Text & "','" & frmfacturacion.txtISR.Text &
         "','" & num_empresa & "','" & numint_empresa & "','" & Trim(Replace(frmfacturacion.txt_nombrec.Text, "'", "''")) & "','1')"

        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then
                cnn.Close()
                Return True
            Else
                MsgBox(sinfo)
                cnn.Close()
                Return False
            End If
        Else
            MsgBox(sinfo)
            cnn.Close()
            Return False
        End If
    End Function

    Private Function dameclaveColonia() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveColonia from PorteColonia where Nombre = '" & Trim(frmfacturacion.cboOrigColonia.Text) & "' and CP = '" & frmfacturacion.txtOrigCP.Text & "'", sinfo) Then
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

    Private Function dameclaveMun() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveMun from PorteMunicipios where Descripcion = '" & Trim(frmfacturacion.cboOrigMun.Text) & "'", sinfo) Then
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

    Private Function dameclaveEdo() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveEdo from PorteEstados where Nombre = '" & Trim(frmfacturacion.cboOrigEdo.Text) & "'", sinfo) Then
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

    Private Function dameclavePais() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClavePais from PortePais where Nombre = '" & Trim(frmfacturacion.cboDestinoPais.Text) & "'", sinfo) Then
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

    Private Function dameclaveEdoD() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveEdo from PorteEstados where Nombre = '" & Trim(frmfacturacion.cboDestinoEdo.Text) & "'", sinfo) Then
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
                If .getDt(cnn, dt, "select ClaveColonia from PorteColonia where Nombre = '" & Trim(frmfacturacion.cboDestinoColonia.Text) & "' and CP = '" & frmfacturacion.txtDestinoCP.Text & "'", sinfo) Then
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
                If .getDt(cnn, dt, "select ClaveMun from PorteMunicipios where Descripcion = '" & Trim(frmfacturacion.cboDestinoMun.Text) & "'", sinfo) Then
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

    Private Function dameclavePermisoSCT() As String

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Clave from PorteTipoPermiso where Descripcion = '" & Trim(frmfacturacion.cboPermisoSCT.Text) & "'", sinfo) Then
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

    Private Function dameclavemes(ByVal varperiodo As String) As String
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(Clave) as maxi from MesesSat where Descripcion = '" & Trim(varperiodo) & "'", sinfo1) Then
                    For Each dr1 In dt1.Rows
                        cnn1.Close()
                        Return dr1("maxi").ToString
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

    Private Function dameclaveperiodo(ByVal varperiodo As String) As String
        Dim cnn1 As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo1 As String = ""
        Dim odata1 As New ToolKitSQL.myssql
        Dim dt1 As New DataTable
        Dim dr1 As DataRow
        With odata1
            If .dbOpen(cnn1, sTarget, sinfo1) Then
                If .getDt(cnn1, dt1, "select Max(Clave) as maxi from PeriodicidadSat where Descripcion = '" & Trim(varperiodo) & "'", sinfo1) Then
                    For Each dr1 In dt1.Rows
                        cnn1.Close()
                        Return dr1("maxi").ToString
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

    Public Sub busca_unidad(ByRef unidadsat As String, ByVal unidadclv As String)
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sSQL As String = "Select NomUnidad from  UnidadMedSat  where ClaveUnidad='" & unidadclv & "'"
        ' Dim sSQL As String = "Select UnidadSat from  Productos  where Codigo='" & unidadclv & "'"
        Dim dr As DataRow
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
#Disable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.getDr(cnn, dr, sSQL, sinfo) Then
#Enable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                unidadsat = dr("NomUnidad").ToString
            End If
            cnn.Close()
        Else
            MsgBox(sinfo)
        End If
    End Sub
    Private Function dameclaveConfigV() As String
        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select Clave from PorteConfigAutotrans where Descripcion = '" & Trim(frmfacturacion.cboConfigV.Text) & "'", sinfo) Then
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

    Public Function Guarda_fac(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                             ByVal total As String, ByVal metodo_pago As String, ByVal tipo_pago_e As String,
                             ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                             ByVal calle_empresa As String, ByVal num_empresa As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                             ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                             ByVal rfc_cliente As String, ByVal nombre_cliente As String, ByVal numero_domicilio_cliente As String,
                             ByVal calle_cliente As String, ByVal colonia_cliente As String, ByVal municipio_cliente As String,
                             ByVal cp_cliente As String, ByVal numero_cliente As String, ByVal regimen_empresa As String,
                             ByVal num_factura As String, ByVal reg_fiscal As String,
                             ByVal folio_sat_uuid As String, ByVal fecha_folio_sat As String, ByVal sello_emisor As String, ByVal sello_sat As String,
                             ByVal cadena_orig As String, ByVal csd_no_emp As String, ByVal csd_no_sat As String, ByVal nextcli As String,
                             ByVal id_evento As Integer, ByVal edocli As String, ByVal descripcion As String, ByVal descuento As String, ByVal iva As String,
                             ByVal preciopaq As String, ByVal cartap As Integer, ByVal numint_empresa As String)


        Dim sinfo As String = ""
        Dim sSQL As String = ""

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim numregfiscliente As String = ""

        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Or frmfacturacion.Cmb_RFC.Text = "XEXX010101000" Then
            numregfiscliente = "616"
        Else
            numregfiscliente = frmfacturacion.cbo_regimen.SelectedValue
        End If

        sSQL = "Insert into Facturas(nom_id_cliente,nom_razon_social,nom_rfc_empresa,nom_reg_fiscal,nom_actividad_empresa,nom_calle_empresa," &
        "nom_colonia_empresa,nom_del_mun_empresa,nom_cp_empresa,nom_expedido,estado_empresa,nom_nombre_cliente,nom_calle_cliente,nom_colonia_cliente," &
        "nom_del_mun_cliente,nom_rfc_cliente,nom_folio,nom_metodo_pago,nom_tipo_pago," &
        "nom_folio_sat_uuid,nom_fecha_folio_sat,nom_sello_emisor,nom_sello_sat,nom_cadena_original," &
        "nom_total_pagado,nom_no_csd_emp,nom_no_csd_sat,estatus_fac,n_ext_cliente,id_evento,edo_cli,descripcion,descuento,iva,preciopaq,nom_fecha_factura," &
        " id_emisor, nom_numcuenta, nom_mdescuento, nom_leyenda, nom_ivaret, UsoCFDI, nom_cpago,CartaPorte,regfis_cliente,nom_isr,nom_numext_empresa,nom_numint_empresa,nom_comercial_cli,nom_status,fecha)Values(" &
         numero_cliente & ", '" & Trim(Replace(razon_social, "'", "''")) & "', '" & rfc_empresa & "','" & reg_fiscal & "','" & actividad_empresa & "','" & calle_empresa &
         "','" & colonia_empresa & "','" & municipio_empresa & "','" & cp_empresa & "','" & pais_empresa & "', '" & estado_empresa & "','" & Trim(Replace(nombre_cliente, "'", "''")) &
         "','" & calle_cliente & "','" & colonia_cliente & "','" & municipio_cliente &
         "','" & rfc_cliente & "', " & folio & ",'" & metodo_pago &
         "','" & tipo_pago_e & "','" & folio_sat_uuid & "'," &
         "'" & fecha_folio_sat & "','" & sello_emisor & "','" & sello_sat & "','" & cadena_orig &
         "','" & Replace(total, ",", "") & "','" & csd_no_emp & "','" & csd_no_sat & "'," & IIf(frmfacturacion.Cmb_TipoFact.Text = "NOTA DE CREDITO", ESTATUS_NOTASCREDITO, ESTATUS_FACTURA) & ",'" & nextcli & "'," &
         id_evento & ",'" & edocli & "','" & descripcion & "'," & Replace(descuento, ",", "") & "," & Replace(iva, ",", "") & "," & Replace(frmfacturacion.Text_SubTotal.Text, ",", "") & ",'" & Format(Now, "yyyy-MM-ddTHH:mm:ss") & "', " & frmfacturacion.cbo_emisor.SelectedValue &
        ", '" & frmfacturacion.Text_nCuenta.Text & "', '" & Replace(frmfacturacion.txt_impuestos.Text, ",", "") & "', '" & frmfacturacion.txt_leyenda_add.Text & "', " & Replace(frmfacturacion.Text_IVARET.Text, ",", "") & ", '" & frmfacturacion.cbo_usocfdi.SelectedValue & "', '" & frmfacturacion.Text_CondiPago.Text & "'," & cartap & ",'" & numregfiscliente & "','" & frmfacturacion.txtISR.Text &
        "', '" & num_empresa & "','" & numint_empresa & "','" & Trim(Replace(frmfacturacion.txt_nombrec.Text, "'", "''")) & "','1','" & Format(Date.Now, "yyyy-MM-dd") & "')"

        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then

                odata.runSp(cnn, "update Clientes set Regfis = '" & numregfiscliente & "' where Id = " & numero_cliente & "", sinfo)
                If frmfacturacion.CheckBox2.Checked = True Then
                    Dim foliocarta As Integer = maxidfactu()
                    Dim varinter As String = "No"

                    If frmfacturacion.chkInter.Checked = False Then
                        varinter = "No"
                    Else
                        varinter = "Sí"
                    End If

                    Dim numpedimento As String = ""

                    If varinter = "Sí" Then
                        If frmfacturacion.txtNumPed1.Text <> "" And frmfacturacion.txtNumPed2.Text <> "" And frmfacturacion.txtNumPed3.Text <> "" And frmfacturacion.txtNumPed4.Text <> "" Then
                            numpedimento = frmfacturacion.txtNumPed1.Text & "  " & frmfacturacion.txtNumPed2.Text & "  " & frmfacturacion.txtNumPed3.Text & "  " & frmfacturacion.txtNumPed4.Text  '"21  47  3807  8003832"
                        End If
                    End If

                    Dim varOrigFechaHora As String = ""
                    varOrigFechaHora = Format(CDate(frmfacturacion.dtpOrigFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpOrigHora.Value), "HH:mm:ss")

                    Dim varDesFechaHora As String = ""
                    varDesFechaHora = Format(CDate(frmfacturacion.dtpDesFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpDesHora.Value), "HH:mm:ss")

                    Dim dt As New DataTable

                    For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                        If odata.getDt(cnn, dt, "select * from PorteMercancia where Descripcion = '" & Trim(frmfacturacion.dgProductos.Rows(i).Cells(0).Value.ToString) & "'", sinfo) Then
                            For Each dr In dt.Rows
                                odata.runSp(cnn, "update PorteMercancia set UniMedSAT = '" & frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString & "', ProdServSAT = '" & frmfacturacion.dgProductos.Rows(i).Cells(2).Value.ToString & "' where Id = " & dr("Id").ToString & "", sinfo)
                            Next
                        Else
                            odata.runSp(cnn, "insert into PorteMercancia(Descripcion,UniMedSAT,ProdServSAT) values('" & Trim(frmfacturacion.dgProductos.Rows(i).Cells(0).Value.ToString) & "','" & frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString & "','" & frmfacturacion.dgProductos.Rows(i).Cells(2).Value.ToString & "')", sinfo)
                        End If
                    Next

                    If odata.getDt(cnn, dt, "select * from PorteOrigen where Remitente = '" & frmfacturacion.cboOrigRemitente.Text & "' and RFC = '" & frmfacturacion.txtOrigRFC.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            odata.runSp(cnn, "update PorteOrigen set CP = '" & frmfacturacion.txtOrigCP.Text & "', Calle = '" & Trim(frmfacturacion.txtOrigCalle.Text) & "', NumExt = '" & Trim(frmfacturacion.txtOrigNumExt.Text) & "', NumInt = '" & Trim(frmfacturacion.txtOrigNumInt.Text) & "', Colonia = '" & Trim(frmfacturacion.cboOrigColonia.Text) & "', Edo = '" & Trim(frmfacturacion.cboOrigEdo.Text) & "', Mun = '" & Trim(frmfacturacion.cboOrigMun.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                        Next
                    Else
                        odata.runSp(cnn, "insert into PorteOrigen(Remitente,RFC,CP,Calle,NumExt,NumInt,Colonia,Edo,Mun) values('" & Trim(frmfacturacion.cboOrigRemitente.Text) & "', '" & Trim(frmfacturacion.txtOrigRFC.Text) & "','" & frmfacturacion.txtOrigCP.Text & "','" & Trim(frmfacturacion.txtOrigCalle.Text) & "','" & Trim(frmfacturacion.txtOrigNumExt.Text) & "','" & Trim(frmfacturacion.txtOrigNumInt.Text) & "','" & Trim(frmfacturacion.cboOrigColonia.Text) & "','" & Trim(frmfacturacion.cboOrigEdo.Text) & "','" & Trim(frmfacturacion.cboOrigMun.Text) & "') ", sinfo)
                    End If

                    If odata.getDt(cnn, dt, "select * from PorteDestino where Destinatario = '" & frmfacturacion.cboDesDestinatario.Text & "' and RFC = '" & frmfacturacion.txtDesRFC.Text & "'", sinfo) Then
                        For Each dr In dt.Rows
                            odata.runSp(cnn, "update PorteDestino set CP = '" & frmfacturacion.txtDestinoCP.Text & "', Calle = '" & Trim(frmfacturacion.txtDestinoCalle.Text) & "', NumE = '" & Trim(frmfacturacion.txtDestinoNumE.Text) & "', NumI = '" & Trim(frmfacturacion.txtDestinoNumI.Text) & "', Colonia = '" & Trim(frmfacturacion.cboDestinoColonia.Text) & "', Edo = '" & Trim(frmfacturacion.cboDestinoEdo.Text) & "', Mun = '" & Trim(frmfacturacion.cboDestinoMun.Text) & "', Pais = '" & Trim(frmfacturacion.cboDestinoPais.Text) & "', Loc = '" & Trim(frmfacturacion.txtDestinoLoc.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                        Next
                    Else
                        odata.runSp(cnn, "insert into PorteDestino(Destinatario,RFC,CP,Calle,NumE,NumI,Colonia,Edo,Mun,Pais,Loc) values('" & Trim(frmfacturacion.cboDesDestinatario.Text) & "', '" & Trim(frmfacturacion.txtDesRFC.Text) & "','" & frmfacturacion.txtDestinoCP.Text & "','" & Trim(frmfacturacion.txtDestinoCalle.Text) & "','" & Trim(frmfacturacion.txtDestinoNumE.Text) & "','" & Trim(frmfacturacion.txtDestinoNumI.Text) & "','" & Trim(frmfacturacion.cboDestinoColonia.Text) & "','" & Trim(frmfacturacion.cboDestinoEdo.Text) & "','" & Trim(frmfacturacion.cboDestinoMun.Text) & "','" & Trim(frmfacturacion.cboDestinoPais.Text) & "','" & Trim(frmfacturacion.txtDestinoLoc.Text) & "') ", sinfo)
                    End If

                    If frmfacturacion.cboTipoFigura.Text = "Operador" Then
                        If odata.getDt(cnn, dt, "select * from PorteOperador where Nombre = '" & frmfacturacion.cboOpeNombre.Text & "'", sinfo) Then
                            For Each dr In dt.Rows
                                odata.runSp(cnn, "update PorteOperador set  RFC = '" & Trim(frmfacturacion.txtOpeRFC.Text) & "', Licencia = '" & Trim(frmfacturacion.txtOpeLicencia.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                            Next
                        Else
                            odata.runSp(cnn, "insert into PorteOperador(Nombre,RFC,Licencia) values('" & Trim(frmfacturacion.cboOpeNombre.Text) & "', '" & Trim(frmfacturacion.txtOpeRFC.Text) & "','" & Trim(frmfacturacion.txtOpeLicencia.Text) & "') ", sinfo)
                        End If
                    Else
                        If odata.getDt(cnn, dt, "select * from PortePropietario where Nombre = '" & frmfacturacion.cboOpeNombre.Text & "'", sinfo) Then
                            For Each dr In dt.Rows
                                odata.runSp(cnn, "update PortePropietario set RFC = '" & Trim(frmfacturacion.txtOpeRFC.Text) & "', Licencia = '" & Trim(frmfacturacion.txtOpeLicencia.Text) & "' where Id = " & dr("Id").ToString & "", sinfo)
                            Next
                        Else
                            odata.runSp(cnn, "insert into PortePropietario(Nombre,RFC,Licencia) values('" & Trim(frmfacturacion.cboOpeNombre.Text) & "', '" & Trim(frmfacturacion.txtOpeRFC.Text) & "','" & Trim(frmfacturacion.txtOpeLicencia.Text) & "') ", sinfo)
                        End If
                    End If

                    If odata.runSp(cnn, "insert into CartaPorteI(FolioCarta, Inter, OrigNombre, OrigRFC, OrigFechaHora, OrigCP, OrigCalle, OrigNumExt, OrigNumInt, OrigColonia, OrigEdo," &
                                "OrigMun, TotalDistancia, DesNombre, DesRFC, DesFechaHora, DesCP, DesPais, DesCalle, DesNumExt, DesNumInt, DesCol, DesEdo, DesMun, PermisoSCT, NumPoliza, NumPermisoSCT,Aseguradora, Placa, " &
                                "Config, ModeloA, OpeRFC, OpeLic, OpeNombre, OpeNumExt, OpeNumInt, OpeMun, OpeEdo, OpeColonia, OpeCP, OpeCalle, TotalMercancias, OrigColoniaT, OrigEdoT, OrigMunT, DesColT, DesEdoT, DesMunT, OpeColoniaT, OpeEdoT, OpeMunT, TotalPesoM, DesLocalidad, " &
                                "TransDes, TransImporte, TransUniMedSat, TransClaveSat, NumPed, FiguraTrasporte, AseguradoraMedAmb, NumPolizaMedAmb) values(" & foliocarta &
                                ",'" & varinter & "', '" & frmfacturacion.cboOrigRemitente.Text & "', '" & frmfacturacion.txtOrigRFC.Text & "', '" & varOrigFechaHora & "', '" & frmfacturacion.txtOrigCP.Text &
                                "', '" & frmfacturacion.txtOrigCalle.Text & "', '" & frmfacturacion.txtOrigNumExt.Text & "', '" & frmfacturacion.txtOrigNumInt.Text & "', '" & dameclaveColonia() & "', '" & dameclaveEdo() & "'," &
                                "'" & dameclaveMun() & "', '" & frmfacturacion.txtDestinioDist.Text & "', '" & frmfacturacion.cboDesDestinatario.Text & "', '" & frmfacturacion.txtDesRFC.Text & "', '" & varDesFechaHora & "', '" & frmfacturacion.txtDestinoCP.Text & "', '" & dameclavePais() & "', '" & frmfacturacion.txtDestinoCalle.Text &
                                "', '" & frmfacturacion.txtDestinoNumE.Text & "', '" & frmfacturacion.txtDestinoNumI.Text & "', '" & dameclaveColoniaD() & "', '" & dameclaveEdoD() & "', '" & dameclaveMunD() & "', '" & dameclavePermisoSCT() & "', '" & frmfacturacion.txtNumPoliza.Text & "', '" & frmfacturacion.txtNumPermisoSCT.Text &
                                "', '" & frmfacturacion.txtAseguradora.Text & "', '" & frmfacturacion.txtPlaca.Text & "', '" & dameclaveConfigV() & "', '" & frmfacturacion.txtModeloAño.Text & "', '" & frmfacturacion.txtOpeRFC.Text & "', '" & frmfacturacion.txtOpeLicencia.Text & "', '" & frmfacturacion.cboOpeNombre.Text & "', '', ''" &
                                ", '', '', '', '', '', '" & frmfacturacion.dgProductos.RowCount & "', '" & frmfacturacion.cboOrigColonia.Text & "', '" & frmfacturacion.cboOrigEdo.Text & "', '" & frmfacturacion.cboOrigMun.Text & "', '" & frmfacturacion.cboDestinoColonia.Text & "', '" & frmfacturacion.cboDestinoEdo.Text & "', '" & frmfacturacion.cboDestinoMun.Text & "', '', '', '','" & frmfacturacion.txtTotalPeso.Text & "','" & frmfacturacion.txtDestinoLoc.Text &
                                "','', '', '', '','" & numpedimento & "','" & frmfacturacion.cboTipoFigura.Text & "','" & frmfacturacion.txtAseguradoraMatPel.Text & "','" & frmfacturacion.txtNumPolizaMatPel.Text & "')", sinfo) Then
                        Dim varfoliocarta As Integer = maxidcarta()

                        For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                            If odata.runSp(cnn, "insert into CartaPorteDetI(IdCarta, FolioCarta, Descripcion, UniMedSAT, ProdServSAT, Cantidad, ValorM, PesoKg, NumPed, UUIDComE, FracArancelaria, MatPel, ClaveMatPel, DescMatPel, Embalaje, ClaveEmbalaje) values(" & varfoliocarta & "," & foliocarta & ",'" & frmfacturacion.dgProductos.Rows(i).Cells(0).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(1).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(2).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(3).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(4).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(5).Value & "','','" & frmfacturacion.dgProductos.Rows(i).Cells(7).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(8).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(9).Value & "', '" & frmfacturacion.dgProductos.Rows(i).Cells(10).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(13).Value & "', '" & frmfacturacion.dgProductos.Rows(i).Cells(11).Value & "','" & frmfacturacion.dgProductos.Rows(i).Cells(12).Value & "')", sinfo) Then
                            End If
                        Next
                    End If
                End If
                cnn.Close()
                Return True
            Else
                MsgBox(sinfo)
                cnn.Close()
                Return False
            End If
        Else
            MsgBox(sinfo)
            cnn.Close()
            Return False
        End If
    End Function

    Public Function GeneraXML(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                              ByVal descuento_f As String, ByVal motivo_descuento As String, ByVal total As String, ByVal metodo_pago As String,
                              ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                              ByVal calle_empresa As String, ByVal num_empresa_ext As String, ByVal num_empresa_int As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                              ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                              ByVal rfc_receptor As String, ByVal nombre_receptor As String, ByVal numero_domicilio_receptor As String, ByVal numero_domicilio_receptor_int As String,
                              ByVal calle_receptor As String, ByVal colonia_receptor As String, ByVal municipio_receptor As String,
                              ByVal cp_receptor As String, ByVal numero_receptor_ext As String, ByVal regimen_empresa As String, ByVal registro_patronal As String,
                              ByVal id_facturaa As String, ByVal ruta_certificado As String, ByVal ruta_key As String, ByVal pass_key As String,
                              ByVal id_evento As String, ByVal descripcion_evento As String, ByVal precio_paqq As String, ByVal reg_fiscal As String, ByVal tipo_pago_e As String, ByVal id_empresa As Integer, ByVal cartap As Integer, ByVal varnumped As String)

        Dim nombreCFD As String = ""
        Dim tretencionesp As Double = 0

        Select Case frmfacturacion.Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & serie & folio & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & serie & folio & ".xml"
            Case "RECIBO DE ARRENDAMIENTO"
                nombreCFD = "A" & serie & folio & ".xml"
            Case "RECIBO DE HONORARIOS"
                nombreCFD = "H" & serie & folio & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & serie & folio & ".xml"
        End Select

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\")
        Dim miXml As XmlTextWriter = New XmlTextWriter(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\")
            miXml = New XmlTextWriter("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        End If
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechacreacion As DateTime = Now

        Dim nuevoIEPS265 As Double = 0
        Dim nuevoIEPS3 As Double = 0
        Dim nuevoIEPS53 As Double = 0
        Dim nuevoIEPS5 As Double = 0
        Dim nuevoIEPS1600 As Double = 0
        Dim nuevoIEPS304 As Double = 0
        Dim nuevoIEPS25 As Double = 0
        Dim nuevoIEPS09 As Double = 0
        Dim nuevoIEPS8 As Double = 0
        Dim nuevoIEPS07 As Double = 0
        Dim nuevoIEPS06 As Double = 0
        Dim nuevoIEPS03 As Double = 0
        Dim nuevoIEPS_SinIVA As Double = 0

        fechaFormateada = DateAndTime.Now.ToString("s")
        '        fechaFormateada = fechacreacion.ToString("yyyy-MM-ddThh:mm:ss")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-ddTHH:mm:ss")

        With miXml
            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE
            .WriteStartElement("cfdi:Comprobante")
            'aqui empece
            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/3")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            If frmfacturacion.CheckBox2.Checked = True Then
                .WriteStartAttribute("xsi:schemaLocation")
                .WriteValue("http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd http://www.sat.gob.mx/CartaPorte20 http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte20.xsd")
                .WriteEndAttribute()

                .WriteStartAttribute("xmlns:cartaporte20")
                .WriteValue("http://www.sat.gob.mx/CartaPorte20")
                .WriteEndAttribute()

            Else
                .WriteStartAttribute("xsi:schemaLocation")
                .WriteValue("http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd")
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(cp_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("MetodoPago")
            .WriteValue(frmfacturacion.Text_FormaPago.SelectedValue)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            If frmfacturacion.Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
                .WriteValue("E")
            Else
                .WriteValue("I")
            End If

            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("" & Replace(Format(CDec(total), "####0.00"), ",", ""))
            .WriteEndAttribute()

            .WriteStartAttribute("TipoCambio")
            .WriteValue("1")
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("MXN")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue(Replace(Format(CDec(subtotal), "####0.00"), ",", ""))
            .WriteEndAttribute()

            .WriteStartAttribute("FormaPago")
            .WriteValue(metodo_pago)
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue("" & fechaFormateada1 & "")
            .WriteEndAttribute()

            .WriteStartAttribute("Folio")
            .WriteValue(folio)
            .WriteEndAttribute()

            .WriteStartAttribute("Version")
            .WriteValue("3.3")
            .WriteEndAttribute()

            .WriteStartAttribute("Serie")
            .WriteValue(serie)
            .WriteEndAttribute()

            If descuento_f > 0 Then
                .WriteStartAttribute("Descuento")
                .WriteValue(Replace(Format(CDec(descuento_f), "####0.00"), ",", ""))
                .WriteEndAttribute()
            End If

            If frmfacturacion.cboTipoRelacion.Text = "" Then
            Else
                .WriteStartElement("cfdi:CfdiRelacionados")

                .WriteStartAttribute("TipoRelacion")
                .WriteValue(frmfacturacion.cboTipoRelacion.SelectedValue)
                .WriteEndAttribute()

                For i = 0 To frmfacturacion.dgUUID.RowCount - 1
                    .WriteStartElement("cfdi:CfdiRelacionado")
                    .WriteStartAttribute("UUID")
                    .WriteValue(frmfacturacion.dgUUID.Rows(i).Cells(1).Value.ToString)
                    .WriteEndAttribute()
                    .WriteEndElement() 'Termina Relacionado
                Next
                .WriteEndElement() 'Termina relacionado
            End If
            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")

            .WriteStartAttribute("Rfc")
            .WriteValue(rfc_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("Nombre")
            .WriteValue(razon_social)
            .WriteEndAttribute()

            .WriteStartAttribute("RegimenFiscal")
            .WriteValue(regimen_empresa)
            .WriteEndAttribute()

            .WriteEndElement() 'Emisor

            '========================================= COMIENZA RECEPTOR
            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Rfc", rfc_receptor)
            .WriteAttributeString("Nombre", nombre_receptor)

            Dim Banderaglobal As Integer = 0
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dr As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
#Disable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If .getDr(cnn, dr, "Select NumPart from Formatos where Facturas = 'SHIBBOLETH'", sinfo) Then
#Enable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        If CDec(dr(0).ToString) = 1 Then
                            Banderaglobal = 1
                        End If
                    End If
                    cnn.Close()
                End If
            End With

            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                If Banderaglobal = 1 Then
                    .WriteAttributeString("UsoCFDI", frmfacturacion.cbo_usocfdi.SelectedValue)
                Else
                    .WriteAttributeString("UsoCFDI", "P01")
                End If
            Else
                .WriteAttributeString("UsoCFDI", frmfacturacion.cbo_usocfdi.SelectedValue)
            End If

            .WriteEndElement() 'receptor

            '=========================== COMIENZA CONCEPTO
            Dim sumaimpuestosconcep As Double = 0
            Dim sumaImpFactGlobal As Double = 0

            .WriteStartElement("cfdi:Conceptos")

            Dim cadenaunidad As String = ""
            Dim bandera As Integer = 0
            Dim ieps_porcentaje As String = ""
            Dim ieps_val As Integer = 0
            Dim arreg(500) As String
            Dim arreg2(500) As String
            Dim tcuota As Double = 0
            Dim prubasuma As Decimal = 0
            Dim sumaiva As Decimal = 0
            Dim banderaiva As Integer = 0
            Dim banderaArrays As Integer = 0
            Dim banderaArrays2 As Integer = 0
            Dim banderacambio As Integer = 0

            For ii = 0 To frmfacturacion.grid_prods.RowCount - 1
                'MsgBox(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString), 6))
                prubasuma += FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString), 6)
            Next

            For ii = 0 To frmfacturacion.grid_prods.RowCount - 1
                If frmfacturacion.grid_prods.Rows(ii).Cells(8).Value.ToString > 0 Then
                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                            If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                                sumaiva += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(ii).Cells(9).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString)), 6)
                            Else
                                sumaiva += 0
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                                sumaiva += FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(19).Value.ToString), 6)
                            Else
                                sumaiva += 0 'FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(19).Value.ToString) * CDec(0.16), 6)
                            End If
                        End If
                    Else
                        If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                            sumaiva += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(ii).Cells(9).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString)), 6)
                        Else
                            sumaiva += 0
                        End If
                    End If
                End If
            Next

            sumaiva = FormatNumber(sumaiva * 0.16, 6)

            Dim actuieps As Double = 0
            If frmfacturacion.grid_prods.RowCount > 0 Then
                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                    actuieps = 0

                    cadenaunidad = ""
                    .WriteStartElement("cfdi:Concepto")
                    Dim varDescUnita As Double = 0
                    If descuento_f > 0 Then
                        .WriteAttributeString("Descuento", Replace(CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))
                    End If
                    .WriteAttributeString("Cantidad", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString, 6), ",", ""))
                    busca_unidad(cadenaunidad, frmfacturacion.grid_prods.Rows(i).Cells(2).Value.ToString)
                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                            .WriteAttributeString("Unidad", Mid(cadenaunidad, 1, 20))
                        Else
                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                .WriteAttributeString("NoIdentificacion", Mid(frmfacturacion.grid_prods.Rows(i).Cells(0).Value.ToString, 1, 20))
                            Else
                                .WriteAttributeString("NoIdentificacion", Mid(frmfacturacion.grid_prods.Rows(i).Cells(12).Value.ToString, 1, 20))
                            End If
                        End If
                    Else
                        .WriteAttributeString("Unidad", Mid(cadenaunidad, 1, 20))
                    End If
                    .WriteAttributeString("Descripcion", frmfacturacion.grid_prods.Rows(i).Cells(1).Value.ToString)
                    .WriteAttributeString("ValorUnitario", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) + CDec(varDescUnita), 6), ",", ""))

                    Dim banderarecorta As Integer = 0
                    Dim banderadecimales As Integer = 0
                    Dim strceros As String = "0."

                    If frmfacturacion.Text_SubTotal.Text = FormatNumber(prubasuma, 2) Then
                        For ii = 1 To Len(CStr(prubasuma))
                            If banderarecorta = 1 Then
                                banderadecimales += 1
                                strceros &= "0"
                            End If

                            If Mid(CStr(prubasuma), ii, 1) = "." Then banderarecorta = 1
                        Next
                        If banderadecimales > 2 Then
                            If frmfacturacion.Text_SubTotal.Text > FormatNumber(prubasuma, 2) Then
                                strceros = CStr(Left(strceros, banderadecimales + 1)) & "1"
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) + CDec(strceros), 6), ",", ""))
                            Else
                                If frmfacturacion.Text_SubTotal.Text = FormatNumber(prubasuma, 2) Then
                                    If frmfacturacion.grid_prods.RowCount = 1 Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 2), ",", ""))
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                                    End If
                                Else
                                    strceros = CStr(Left(strceros, banderadecimales + 1)) & "1"
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(strceros), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                                        End If
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(strceros), 6), ",", ""))
                                    End If
                                End If
                            End If
                        Else
                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                        End If
                    Else
                        If frmfacturacion.Text_SubTotal.Text > FormatNumber(prubasuma, 2) Then
                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 2), ",", ""))
                        Else
                            If FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6) > 0 And FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString, 6) = 0 Then
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                            Else
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                            End If
                        End If
                    End If

                    .WriteAttributeString("ClaveUnidad", Trim(frmfacturacion.grid_prods.Rows(i).Cells(2).Value.ToString))
                    .WriteAttributeString("ClaveProdServ", Trim(frmfacturacion.grid_prods.Rows(i).Cells(14).Value.ToString))

                    If frmfacturacion.CheckBox2.Checked = True Then
                        If frmfacturacion.chkInter.Checked = True Then
                            For ix = 0 To frmfacturacion.dgProductos.RowCount - 1
                                If Trim(varnumped) <> "" Then
                                    .WriteStartElement("cfdi:InformacionAduanera")
                                    .WriteAttributeString("NumeroPedimento", Trim(varnumped)) '.WriteAttributeString("NumeroPedimento", "21  47  3807  8003832")
                                    .WriteEndElement() 'info aduanera
                                End If
                            Next
                        End If
                    End If

                    '=========================== comiezan impuestos de los productos
                    Dim importeconceptoiva As Double = 0
                    Dim retenidop As Double = 0
                    Dim sumatoria As Decimal = 0
                    Dim sumatoria1 As Decimal = 0
                    Dim valorMaximo As Decimal = 0

                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                        tcuota = CDbl(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) / 100
                        If frmfacturacion.txt_impuestos.Text > 0 Then
                            'sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)), 6), ",", "")
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                If Banderaglobal = 1 Then
                                    If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                        sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                        sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    Else
                                        sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    End If
                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    Else
                                        If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString) > 0 Then
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    End If
                                End If
                            Else
                                If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                    sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                    sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                Else
                                    sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                End If
                            End If
                        Else
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                If Banderaglobal = 1 Then
                                    If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                        sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                        sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    Else
                                        sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    End If
                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString, 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString, 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    Else
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    End If
                                End If
                            Else
                                If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                    sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                    sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                Else
                                    sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                End If
                            End If
                        End If
                        sumatoria1 = sumatoria1 + sumatoria
                    Next

                    tcuota = CDbl(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) / 100
                    If frmfacturacion.txt_impuestos.Text > 0 Then
                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                            If Banderaglobal = 1 Then
                                If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                Else
                                    'MsgBox(Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                                End If
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", "")
                                        'importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", "")
                                    End If
                                Else
                                    If CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", "")
                                    End If
                                End If
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                            Else
                                'MsgBox(Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                            End If
                        End If
                        'importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                    Else
                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                            If Banderaglobal = 1 Then
                                If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                Else
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                                End If
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString, 6), ",", "")
                                    End If
                                Else
                                    If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", "")
                                    End If
                                End If
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                            Else
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                            End If
                        End If
                        valorMaximo = importeconceptoiva
                    End If

                    strceros = "0."

                    Dim cuantofalta As Decimal = 0
                    Dim cuantoSobra As Decimal = 0
                    Dim valorMinimo As Decimal = 0
                    'valorMinimo = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 6)
                    If CDec(FormatNumber(sumaiva, 2)) = CDec(frmfacturacion.Text_IVA.Text) Then
                        importeconceptoiva = FormatNumber(importeconceptoiva * tcuota, 6)
                    Else
                        If CDec(frmfacturacion.Text_IVA.Text) = FormatNumber(sumatoria1, 2) Then
                            If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                If banderaiva = 0 Then
                                    'banderaiva = 1
                                    'strceros &= "01"
                                    'importeconceptoiva = importeconceptoiva + CDec(strceros)
                                End If
                            Else
                                importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    strceros &= "01"
                                    importeconceptoiva = FormatNumber(importeconceptoiva - CDec(strceros), 2)
                                    valorMinimo = FormatNumber(CDec(FormatNumber(valorMaximo, 6)) * tcuota, 6) - importeconceptoiva
                                    If valorMinimo > 0.01 Then
                                        importeconceptoiva = FormatNumber(importeconceptoiva + CDec(strceros), 2)
                                    End If
                                Else
                                    banderaiva = 1
                                    strceros &= "01"
                                    importeconceptoiva = FormatNumber(importeconceptoiva - CDec(strceros), 2)
                                    valorMinimo = FormatNumber(CDec(FormatNumber(valorMaximo, 6)) * tcuota, 6) - importeconceptoiva
                                    If valorMinimo > 0.01 Then
                                        importeconceptoiva = FormatNumber(importeconceptoiva + CDec(strceros), 2)
                                    End If
                                End If
                            End If
                        Else
                            If CDec(frmfacturacion.Text_IVA.Text) > FormatNumber(sumaiva, 2) Then
                                'cuantofalta = CDec(frmfacturacion.Text_IVA.Text) - CDec(FormatNumber(sumaiva, 2))
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    'strceros &= "01"
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    importeconceptoiva = importeconceptoiva + CDec(cuantofalta)
                                Else
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 6)
                                End If
                            Else
                                cuantoSobra = CDec(FormatNumber(sumaiva, 2)) - CDec(frmfacturacion.Text_IVA.Text)
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    importeconceptoiva = importeconceptoiva - CDec(cuantoSobra)
                                Else
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                End If
                                'cuantoSobra = CDec(FormatNumber(sumaiva, 2)) - CDec(frmfacturacion.Text_IVA.Text)
                                'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                'If banderaiva = 0 Then
                                '    banderaiva = 1
                                '    importeconceptoiva = importeconceptoiva - CDec(cuantoSobra)
                                'End If
                            End If
                        End If

                        'If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                        '    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                        '    If banderaiva = 0 Then
                        '        'banderaiva = 1
                        '        'strceros &= "01"
                        '        'importeconceptoiva = importeconceptoiva + CDec(strceros)
                        '    End If
                        'Else
                        '    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                        '    If banderaiva = 0 Then
                        '        banderaiva = 1
                        '        strceros &= "01"
                        '        importeconceptoiva = importeconceptoiva - CDec(strceros)
                        '    End If
                        'End If
                    End If

                    sumaimpuestosconcep = sumaimpuestosconcep + importeconceptoiva

                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                        Else
                            sumaImpFactGlobal += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) * 0.16), 6)
                        End If
                    End If

                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                        'si tiene iva , iva retenido, ieps
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin Traslado iva

                        .WriteStartElement("cfdi:Traslado")

                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                            ieps_val = ieps_val + 1
                        End If

                        .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                        .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                        .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                        ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                        .WriteAttributeString("Impuesto", "003")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin Traslado ieps

                        .WriteEndElement() ' fin Traslados

                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten iva

                        retenidop = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(18).Value.ToString, 6) 'FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString) / frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString, 6)
                        tretencionesp = retenidop
                        .WriteAttributeString("Importe", Replace(FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(retenidop), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")

                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin reten iva

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString > 0 Then
                        'si tiene iva, iva retenido
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))

                        .WriteEndElement() ' fin Traslado

                        .WriteEndElement() ' fin Traslados

                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten iva

                        retenidop = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(18).Value.ToString, 6)
                        tretencionesp = retenidop

                        .WriteAttributeString("Importe", Replace(FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(retenidop), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))

                        .WriteEndElement() ' fin reten iva

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                        'si tiene iva, ieps

                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                            If Banderaglobal = 1 Then
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                If frmfacturacion.txt_impuestos.Text > 0 Then
                                    '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                    If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", ""))
                                    End If
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                End If
                                .WriteEndElement() ' fin Traslado
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If frmfacturacion.Text_IVA.Text = FormatNumber(sumaiva, 2) Or banderacambio = 1 Then
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6)), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    Else
                                        If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                            banderacambio = 1
                                            Dim cuenta As Decimal = 0
                                            cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01
                                            cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                            cuenta = cuenta
                                            If cuenta > 0 Then
                                                cuenta = cuenta
                                            Else
                                                cuenta = Math.Abs(cuenta)
                                            End If
                                            If cuenta > 0.009 Then
                                                banderacambio = 0
                                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01, ",", ""))
                                            End If
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        Else
                                            banderacambio = 1
                                            Dim cuenta As Decimal = 0
                                            cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01
                                            cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                            cuenta = cuenta
                                            If cuenta > 0 Then
                                                cuenta = cuenta
                                            Else
                                                cuenta = Math.Abs(cuenta)
                                            End If
                                            If cuenta > 0.009 Then
                                                banderacambio = 0
                                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01, ",", ""))
                                            End If
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If
                                    End If
                                Else
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    If frmfacturacion.txt_impuestos.Text > 0 Then
                                        '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                        If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", ""))
                                        End If

                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                End If
                            End If
                        Else
                            .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                            .WriteAttributeString("Impuesto", "002")
                            If frmfacturacion.txt_impuestos.Text > 0 Then
                                '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", ""))
                                End If
                            Else
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                            End If
                            .WriteEndElement() ' fin Traslado
                        End If

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                            If Banderaglobal = 1 Then
                                .WriteStartElement("cfdi:Traslado")
                                If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                    arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                    ieps_val = ieps_val + 1
                                End If
                                .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                                .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                .WriteAttributeString("Impuesto", "003")
                                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                    If Banderaglobal = 1 Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        If frmfacturacion.txtNotaVenta.Text = "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                        End If
                                    End If
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                End If
                                .WriteEndElement() ' fin Traslado
                                .WriteEndElement() ' fin Traslados
                                .WriteEndElement() ' fin impuestos
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    '"0.265"
                                    If var265(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS265 = CDec(nuevoIEPS265) + CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                        actuieps += CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.265000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var265(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.30"
                                    If var3(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS3 = CDec(nuevoIEPS3) + CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                        actuieps += CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.300000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var3(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.53"
                                    If var53(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS53 = CDec(nuevoIEPS53) + CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                        actuieps += CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.530000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var53(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado

                                    End If

                                    '"0.50"
                                    If var5(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS5 = CDec(nuevoIEPS5) + CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                        actuieps += CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.500000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var5(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"1.60"
                                    If var1600(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS1600 = CDec(nuevoIEPS1600) + CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                        actuieps += CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "1.600000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var1600(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.304"
                                    If var304(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS304 = CDec(nuevoIEPS304) + CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                        actuieps += CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.304000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var304(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.25"
                                    If var25(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS25 = CDec(nuevoIEPS25) + CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                        actuieps += CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.250000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var25(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.09"
                                    If var09(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS09 = CDec(nuevoIEPS09) + CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                        actuieps += CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.090000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var09(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.08"
                                    If var08(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If

                                        nuevoIEPS8 = CDec(nuevoIEPS8) + CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                        actuieps += CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.080000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var08(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.07"
                                    If var07(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS07 = CDec(nuevoIEPS07) + CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                        actuieps += CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.070000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var07(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.06"
                                    If var06(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If

                                        'nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2) + 0.01))
                                        nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                        actuieps += CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                        '.WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2)) + 0.01, ",", ""))
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2)), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.060000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var06(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.03"
                                    If var03(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS03 = CDec(nuevoIEPS03) + CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                        actuieps += CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.030000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var03(banderaArrays)), 6), ",", ""))
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    banderaArrays += 1
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos

                                Else
                                    .WriteStartElement("cfdi:Traslado")
                                    If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                        arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                        ieps_val = ieps_val + 1
                                    End If
                                    .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                    .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                    ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    .WriteAttributeString("Impuesto", "003")
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                            End If
                                        End If
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos
                                End If

                                frmfacturacion.grid_prods.Rows(i).Cells(11).Value = actuieps
                            End If
                        Else
                            .WriteStartElement("cfdi:Traslado")
                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                ieps_val = ieps_val + 1
                            End If

                            nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2))

                            .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                            .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                            .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                            ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                            .WriteAttributeString("Impuesto", "003")
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                If Banderaglobal = 1 Then
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                Else
                                    If frmfacturacion.txtNotaVenta.Text = "" Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                    End If
                                End If
                            Else
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                            End If
                            .WriteEndElement() ' fin Traslado
                            .WriteEndElement() ' fin Traslados
                            .WriteEndElement() ' fin impuestos
                        End If
                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 Then
                        'si tiene iva
                        .WriteStartElement("cfdi:Impuestos")
                        .WriteStartElement("cfdi:Traslados")
                        .WriteStartElement("cfdi:Traslado")

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                            If Banderaglobal = 1 Then
                                If frmfacturacion.txtNotaVenta.Text = "" Then
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                Else
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                End If
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString = frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.00", 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString), 6), ",", ""))
                                    Else
                                        If frmfacturacion.Text_IVA.Text = FormatNumber(sumaiva, 2) Or banderacambio = 1 Then
                                            .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6)), ",", ""))
                                        Else
                                            If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                                banderacambio = 1
                                                Dim cuenta As Decimal = 0
                                                cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) ' + 0.01
                                                cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                                cuenta = cuenta
                                                If cuenta > 0 Then
                                                    cuenta = cuenta
                                                Else
                                                    cuenta = Math.Abs(cuenta)
                                                End If
                                                If cuenta > 0.009 Then
                                                    banderacambio = 0
                                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                                Else
                                                    If cuenta > 0.003 Then
                                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01, ",", ""))
                                                    Else
                                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)), ",", ""))
                                                    End If
                                                End If
                                            Else
                                                banderacambio = 1
                                                Dim cuenta As Decimal = 0
                                                cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01
                                                cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                                cuenta = cuenta
                                                If cuenta > 0 Then
                                                    cuenta = cuenta
                                                Else
                                                    cuenta = Math.Abs(cuenta)
                                                End If
                                                If cuenta > 0.009 Then
                                                    banderacambio = 0
                                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                                Else
                                                    .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01, ",", ""))
                                                End If
                                            End If
                                        End If
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                    End If
                                Else
                                    If frmfacturacion.txtNotaVenta.Text = "" Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    End If
                                End If
                            End If
                        Else
                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                            Else
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                            End If
                        End If

                        .WriteEndElement() ' fin Traslado
                        .WriteEndElement() ' fin Traslados
                        .WriteEndElement() ' fin impuestos
                    Else
                        'si no tiene iva
                        If frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                            'si tiene ieps
                            .WriteStartElement("cfdi:Impuestos")
                            .WriteStartElement("cfdi:Traslados")
                            .WriteStartElement("cfdi:Traslado")

                            .WriteAttributeString("Importe", "0.00")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                            .WriteEndElement() ' fin Traslado

                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                If Banderaglobal = 1 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                        arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                        ieps_val = ieps_val + 1
                                    End If

                                    nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2))

                                    .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2)), ",", ""))
                                    .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                    .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                    ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    .WriteAttributeString("Impuesto", "003")
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                            End If
                                        End If
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos
                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        '"0.265"
                                        If var265(banderaArrays) > 0 Then
                                            nuevoIEPS265 = CDec(nuevoIEPS265) + CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                            actuieps += CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.265000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var265(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.30"
                                        If var3(banderaArrays) > 0 Then
                                            nuevoIEPS3 = CDec(nuevoIEPS3) + CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                            actuieps += CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.300000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var3(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.53"
                                        If var53(banderaArrays) > 0 Then
                                            nuevoIEPS53 = CDec(nuevoIEPS53) + CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                            actuieps += CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.530000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var53(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.50"
                                        If var5(banderaArrays) > 0 Then
                                            nuevoIEPS5 = CDec(nuevoIEPS5) + CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                            actuieps += CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.500000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var5(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"1.60"
                                        If var1600(banderaArrays) > 0 Then
                                            nuevoIEPS1600 = CDec(nuevoIEPS1600) + CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                            actuieps += CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "1.600000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var1600(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.304"
                                        If var304(banderaArrays) > 0 Then
                                            nuevoIEPS304 = CDec(nuevoIEPS304) + CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                            actuieps += CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.304000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var304(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.25"
                                        If var25(banderaArrays) > 0 Then
                                            nuevoIEPS25 = CDec(nuevoIEPS25) + CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                            actuieps += CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.250000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var25(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.09"
                                        If var09(banderaArrays) > 0 Then
                                            nuevoIEPS09 = CDec(nuevoIEPS09) + CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                            actuieps += CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.090000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var09(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.08"
                                        If var08(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS8 = CDec(nuevoIEPS8) + CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                            actuieps += CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.080000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var08(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.07"
                                        If var07(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS07 = CDec(nuevoIEPS07) + CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                            actuieps += CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.070000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var07(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.06"
                                        If var06(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                            actuieps += CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.060000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var06(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.03"
                                        If var03(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS03 = CDec(nuevoIEPS03) + CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                            actuieps += CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.030000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var03(banderaArrays)), 6), ",", ""))
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        banderaArrays += 1
                                        .WriteEndElement() ' fin Traslados
                                        .WriteEndElement() ' fin impuestos

                                        frmfacturacion.grid_prods.Rows(i).Cells(11).Value = actuieps
                                    Else
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        'MsgBox(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString)
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2)), ",", ""))
                                        .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                        .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                        ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        .WriteAttributeString("Impuesto", "003")
                                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                            If Banderaglobal = 1 Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                                            Else
                                                If frmfacturacion.txtNotaVenta.Text = "" Then
                                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                                Else
                                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                                End If
                                            End If
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        End If
                                        .WriteEndElement() ' fin Traslado
                                        .WriteEndElement() ' fin Traslados
                                        .WriteEndElement() ' fin impuestos
                                    End If
                                End If
                            Else
                                .WriteStartElement("cfdi:Traslado")
                                If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                    arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                    ieps_val = ieps_val + 1
                                End If

                                nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2))

                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2)), ",", ""))
                                .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                .WriteAttributeString("Impuesto", "003")
                                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                    If Banderaglobal = 1 Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        If frmfacturacion.txtNotaVenta.Text = "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                        End If
                                    End If
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                End If
                                .WriteEndElement() ' fin Traslado
                                .WriteEndElement() ' fin Traslados
                                .WriteEndElement() ' fin impuestos.
                            End If
                        Else
                            'si no tiene nada (IVA = 0)
                            .WriteStartElement("cfdi:Impuestos")
                            .WriteStartElement("cfdi:Traslados")
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Importe", "0.00")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                            .WriteEndElement() ' fin Traslado
                            .WriteEndElement() ' fin Traslados
                            .WriteEndElement() ' fin impuestos
                        End If
                    End If

                    '=========================== terminan impuestos de los productos
                    .WriteEndElement() ' fin concepto
                Next
            End If

            .WriteEndElement()

            actuieps = nuevoIEPS265 + nuevoIEPS3 + nuevoIEPS53 + nuevoIEPS5 + nuevoIEPS1600 + nuevoIEPS304 + nuevoIEPS25 + nuevoIEPS09 + nuevoIEPS8 + nuevoIEPS07 + nuevoIEPS06 + nuevoIEPS03 + nuevoIEPS_SinIVA

            '===================================== INICIA IMPUESTOS

            If frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.Text_IVARET.Text > 0 And frmfacturacion.txt_impuestos.Text > 0 Then
                'si tiene iva , iva retenido, ieps
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.Text_IVARET.Text, ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2) + CDec(frmfacturacion.txt_impuestos.Text), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVARET.Text), 2), ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteEndElement()
                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Importe", "0.00")
                            .WriteEndElement()
                            Exit For
                        End If
                    Next
                End If

                Dim varsum As Double = 0
                Dim varieps As String = ""

                For i = 0 To ieps_val - 1
                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString = arreg(i) Then
                            varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                            ieps_porcentaje = varieps
                        End If
                    Next

                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "003")
                    .WriteAttributeString("TipoFactor", arreg2(i))
                    .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                    .WriteAttributeString("Importe", Replace(varsum, ",", ""))
                    .WriteEndElement()

                    varsum = 0
                    varieps = ""
                Next

                .WriteEndElement()
            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.Text_IVARET.Text > 0 Then
                'si tiene iva, iva retenido
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.Text_IVARET.Text, ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVARET.Text), 2), ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Importe", "0.00")
                            .WriteEndElement()
                            Exit For
                        End If
                    Next
                End If

                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.txt_impuestos.Text > 0 Then
                'si tiene iva, ieps
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVA.Text) + CDec(actuieps), 2), ",", ""))
                '.WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVA.Text) + CDec(frmfacturacion.txt_impuestos.Text), 2), ",", ""))
                .WriteStartElement("cfdi:Traslados")

                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteEndElement()

                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                    If Banderaglobal = 1 Then
                        If frmfacturacion.grid_prods.RowCount > 1 Then
                            For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                If CDec(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) = 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.000000")
                                    .WriteAttributeString("Importe", "0.00")
                                    .WriteEndElement()
                                    Exit For
                                End If
                            Next
                        End If

                        Dim varsum As Double = 0
                        Dim varieps As String = ""
                        For i = 0 To ieps_val - 1
                            For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                    varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                    ieps_porcentaje = varieps
                                End If
                            Next
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Impuesto", "003")
                            .WriteAttributeString("TipoFactor", arreg2(i))
                            .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                            .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                            .WriteEndElement()
                            varsum = 0
                            varieps = ""
                        Next
                    Else

                        If frmfacturacion.txtNotaVenta.Text <> "" Then
                            Dim varsum10 As Double = 0
                            Dim varieps10 As String = ""
                            Dim varieps210 As String = ""
                            Dim varieps310 As String = ""
                            Dim varieps410 As String = ""
                            Dim varieps5r10 As String = ""
                            'If ieps_val > 1 Then

                            '"0.265"
                            If nuevoIEPS265 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.265000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS265, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.30"
                            If nuevoIEPS3 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.300000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS3, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.53"
                            If nuevoIEPS53 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.530000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS53, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.50"
                            If nuevoIEPS5 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.500000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS5, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"1.60"
                            If nuevoIEPS1600 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "1.600000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS1600, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.304"
                            If nuevoIEPS304 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.304000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS304, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.25"
                            If nuevoIEPS25 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.250000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS25, 2), ",", ""))
                                .WriteEndElement()

                            End If

                            '"0.09"
                            If nuevoIEPS09 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.090000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS09, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.08"
                            If nuevoIEPS8 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.080000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS8, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.07"
                            If nuevoIEPS07 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.070000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS07, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.06"
                            If nuevoIEPS06 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.060000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS06, 2), ",", ""))
                                '.WriteAttributeString("Importe", Replace(FormatNumber(3.94, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.03"
                            If nuevoIEPS03 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.030000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS03, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            'Else

                            '                            For i = 0 To ieps_val - 1
                            '                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                            '                                    If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                            '                                        varsum10 = varsum10 + CDec(FormatNumber(var265(i) * arreg(i), 6))
                            '                                        varsum10 = varsum10 + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                            '                                        ieps_porcentaje = varieps10
                            '                                    End If
                            '                                Next
                            '                                If varieps210 = arreg(i) Then
                            '                                    varsum10 = 0
                            '                                    varieps10 = ""
                            '                                    GoTo puertaXD10
                            '                                    'Exit For
                            '                                End If
                            '                                If varieps310 = arreg(i) Then
                            '                                    varsum10 = 0
                            '                                    varieps10 = ""
                            '                                    GoTo puertaXD10
                            '                                    'Exit For
                            '                                End If
                            '                                .WriteStartElement("cfdi:Traslado")
                            '                                .WriteAttributeString("Impuesto", "003")
                            '                                .WriteAttributeString("TipoFactor", arreg2(i))
                            '                                If varieps210 = "" Then
                            '                                    varieps210 = arreg(i)
                            '                                End If
                            '                                If varieps310 = "" And varieps210 <> "" And varieps210 <> arreg(i) Then
                            '                                    varieps310 = arreg(i)
                            '                                End If
                            '                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                            '                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum10, 2), ",", ""))
                            '                                .WriteEndElement()
                            '                                varsum10 = 0
                            '                                varieps10 = ""
                            'puertaXD10:
                            '                            Next

                            'End If

                            If frmfacturacion.grid_prods.RowCount > 1 Then
                                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                                        .WriteStartElement("cfdi:Traslado")
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.000000")
                                        .WriteAttributeString("Importe", "0.00")
                                        .WriteEndElement()
                                        Exit For
                                    End If
                                Next
                            End If
                        Else
                            If frmfacturacion.grid_prods.RowCount > 1 Then
                                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                                        .WriteStartElement("cfdi:Traslado")
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.000000")
                                        .WriteAttributeString("Importe", "0.00")
                                        .WriteEndElement()
                                        Exit For
                                    End If
                                Next
                            End If

                            Dim varsum As Double = 0
                            Dim varieps As String = ""
                            For i = 0 To ieps_val - 1
                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString = CDec(arreg(i)) Then
                                        varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                        ieps_porcentaje = varieps
                                    End If
                                Next
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", arreg2(i))
                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                .WriteEndElement()
                                varsum = 0
                                varieps = ""
                            Next
                        End If
                    End If
                Else
                    If frmfacturacion.grid_prods.RowCount > 1 Then
                        For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                            If CDec(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) = 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteEndElement()
                                Exit For
                            End If
                        Next
                    End If

                    Dim varsum As Double = 0
                    Dim varieps As String = ""
                    For i = 0 To ieps_val - 1
                        For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                            If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                ieps_porcentaje = varieps
                            End If
                        Next
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Impuesto", "003")
                        .WriteAttributeString("TipoFactor", arreg2(i))
                        .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                        .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                        .WriteEndElement()
                        varsum = 0
                        varieps = ""
                    Next
                End If
                .WriteEndElement()
            ElseIf frmfacturacion.Text_IVA.Text > 0 Then
                'si tiene iva
                .WriteStartElement("cfdi:Impuestos")
                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                    If Banderaglobal = 1 Then
                        .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                        .WriteStartElement("cfdi:Traslados")
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                    Else
                        .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaImpFactGlobal), 2), ",", ""))
                        .WriteStartElement("cfdi:Traslados")
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaImpFactGlobal), 2), ",", ""))
                    End If
                Else
                    .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                    .WriteStartElement("cfdi:Traslados")
                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "002")
                    .WriteAttributeString("TipoFactor", "Tasa")
                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                    .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                End If

                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Importe", "0.00")
                            .WriteEndElement()
                            Exit For
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString = frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteEndElement()
                                Exit For
                            End If
                        End If
                    Next
                End If

                .WriteEndElement()
            Else
                'si no tiene iva
                If frmfacturacion.txt_impuestos.Text > 0 Then
                    'si tiene ieps
                    .WriteStartElement("cfdi:Impuestos")
                    '.WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDec(frmfacturacion.txt_impuestos.Text), 2), ",", ""))
                    .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDec(actuieps), 2), ",", ""))
                    .WriteStartElement("cfdi:Traslados")

                    Dim varsum As Double = 0
                    Dim varieps As String = ""
                    Dim varieps2 As String = ""
                    Dim varieps3 As String = ""
                    Dim varieps4 As String = ""
                    Dim varieps5r As String = ""

                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "002")
                    .WriteAttributeString("TipoFactor", "Tasa")
                    .WriteAttributeString("TasaOCuota", "0.000000")
                    .WriteAttributeString("Importe", "0.00")
                    .WriteEndElement()

                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                            For i = 0 To ieps_val - 1
                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    'MsgBox(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString)
                                    If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                        varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                        ieps_porcentaje = varieps
                                    End If
                                Next
                                If varieps2 = arreg(i) Then
                                    varsum = 0
                                    varieps = ""
                                    GoTo puertaXD4
                                    'Exit For
                                End If
                                If varieps3 = arreg(i) Then
                                    varsum = 0
                                    varieps = ""
                                    GoTo puertaXD4
                                    'Exit For
                                End If
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", arreg2(i))
                                If varieps2 = "" Then
                                    varieps2 = arreg(i)
                                End If
                                If varieps3 = "" And varieps2 <> "" And varieps2 <> arreg(i) Then
                                    varieps3 = arreg(i)
                                End If
                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                .WriteEndElement()
                                varsum = 0
                                varieps = ""
puertaXD4:
                            Next
                        Else
                            If frmfacturacion.txtNotaVenta.Text <> "" Then
                                '"0.265"
                                If nuevoIEPS265 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.265000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS265), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.30"
                                If nuevoIEPS3 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.300000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS3), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.53"
                                If nuevoIEPS53 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.530000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS53), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.50"
                                If nuevoIEPS5 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.500000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS5), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"1.60"
                                If nuevoIEPS1600 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "1.600000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS1600), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.304"
                                If nuevoIEPS304 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.304000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS304), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.25"
                                If nuevoIEPS25 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.250000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS25), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.09"
                                If nuevoIEPS09 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.090000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS09), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.08"
                                If nuevoIEPS8 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.080000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS8, 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.07"
                                If nuevoIEPS07 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.070000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS07), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.06"
                                If nuevoIEPS06 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.060000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS06), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.03"
                                If nuevoIEPS03 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.030000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS03), 2), ",", ""))
                                    .WriteEndElement()
                                End If
                            Else

                                For i = 0 To ieps_val - 1
                                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                        If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                            varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                            ieps_porcentaje = varieps
                                        End If
                                    Next
                                    If varieps2 = arreg(i) Then
                                        varsum = 0
                                        varieps = ""
                                        GoTo puertaXD
                                        'Exit For
                                    End If
                                    If varieps3 = arreg(i) Then
                                        varsum = 0
                                        varieps = ""
                                        GoTo puertaXD
                                        'Exit For
                                    End If
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", arreg2(i))
                                    If varieps2 = "" Then
                                        varieps2 = arreg(i)
                                    End If
                                    If varieps3 = "" And varieps2 <> "" And varieps2 <> arreg(i) Then
                                        varieps3 = arreg(i)
                                    End If
                                    .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                    .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                    .WriteEndElement()
                                    varsum = 0
                                    varieps = ""
puertaXD:
                                Next
                            End If
                        End If
                    Else
                        For i = 0 To ieps_val - 1
                            For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                'MsgBox(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString)
                                If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                    varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                    ieps_porcentaje = varieps
                                End If
                            Next
                            If varieps2 = arreg(i) Then
                                varsum = 0
                                varieps = ""
                                GoTo puertaXD1
                                'Exit For
                            End If
                            If varieps3 = arreg(i) Then
                                varsum = 0
                                varieps = ""
                                GoTo puertaXD1
                                'Exit For
                            End If
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Impuesto", "003")
                            .WriteAttributeString("TipoFactor", arreg2(i))
                            If varieps2 = "" Then
                                varieps2 = arreg(i)
                            End If
                            If varieps3 = "" And varieps2 <> "" And varieps2 <> arreg(i) Then
                                varieps3 = arreg(i)
                            End If
                            .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                            .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                            .WriteEndElement()
                            varsum = 0
                            varieps = ""
puertaXD1:
                        Next
                    End If
                    .WriteEndElement()
                Else
                    'sin iva
                    .WriteStartElement("cfdi:Impuestos")
                    .WriteAttributeString("TotalImpuestosTrasladados", "0.00")

                    .WriteStartElement("cfdi:Traslados")
                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "002")
                    .WriteAttributeString("TipoFactor", "Tasa")
                    .WriteAttributeString("TasaOCuota", "0.000000")
                    .WriteAttributeString("Importe", "0.00")

                    .WriteEndElement()
                    .WriteEndElement()
                End If
            End If

            .WriteEndElement()
            'inicia carta porte
            If frmfacturacion.CheckBox2.Checked = True Then
                '=========================== COMIENZA complemento
                .WriteStartElement("cfdi:Complemento")
                '=========================== COMIENZA carta

                .WriteStartElement("cartaporte20:CartaPorte")
                .WriteAttributeString("Version", "2.0")

                If frmfacturacion.chkInter.Checked = True Then
                    .WriteAttributeString("ViaEntradaSalida", "01")
                    'en este campo si en Trasporte internacional es Si se debe poner los campos EntradaSalidaMerc y ViaEntradaSalida
                    'en este campo si en Trasporte internacional es No los campos EntradaSalidaMerc y ViaEntradaSalida no deben de estar
                    'agregar una validacion aqui
                    .WriteAttributeString("TranspInternac", "Sí") '.WriteAttributeString("TranspInternac", "Sí")
                    'agregar una validacion aqui
                    .WriteAttributeString("EntradaSalidaMerc", "Salida")
                    'total de distancia tiene que ser igual a la suma del campo DistanciaRecorrida de las ubicaciones que se registren en kilometros
                    'Si existe la sección AutotransporteFederal o TransporteFerroviario de
                    'la sección Mercancias, este campo debe contener un valor; en caso de
                    'que no exista alguna de las secciones antes mencionadas, este campo
                    'no debe existir.
                    .WriteAttributeString("TotalDistRec", frmfacturacion.txtDestinioDist.Text)

                    If dameclavePais() <> "" Then
                        .WriteAttributeString("PaisOrigenDestino", dameclavePais)
                    End If
                Else
                    .WriteAttributeString("TranspInternac", "No")
                    .WriteAttributeString("TotalDistRec", frmfacturacion.txtDestinioDist.Text)
                End If

                '.WriteStartAttribute("xmlns:cartaporte")
                '.WriteValue("http://www.sat.gob.mx/CartaPorte")
                '.WriteEndAttribute()

                '=========================== COMIENZA ubicaciones
                'esta parte hay que hacerla con un ciclo porque se pueden poner varias

                .WriteStartElement("cartaporte20:Ubicaciones")

                .WriteStartElement("cartaporte20:Ubicacion")
                '.WriteAttributeString("DistanciaRecorrida", "1")
                '.WriteAttributeString("TipoEstacion", "01")

                .WriteAttributeString("TipoUbicacion", "Origen")

                If Trim(frmfacturacion.cboOrigRemitente.Text) <> "" Then
                    .WriteAttributeString("NombreRemitenteDestinatario", Trim(frmfacturacion.cboOrigRemitente.Text))
                End If
                .WriteAttributeString("RFCRemitenteDestinatario", Trim(Trim(frmfacturacion.txtOrigRFC.Text)))

                Dim varOrigFechaHora As String = ""
                varOrigFechaHora = Format(CDate(frmfacturacion.dtpOrigFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpOrigHora.Value), "HH:mm:ss")

                .WriteAttributeString("FechaHoraSalidaLlegada", varOrigFechaHora)

                'If dgdist.RowCount > 1 Then
                '    .WriteAttributeString("IDOrigen", Trim(varIdOrigen))
                'End If

                .WriteStartElement("cartaporte20:Domicilio")
                If Trim(frmfacturacion.txtOrigNumExt.Text) <> "" Then
                    .WriteAttributeString("NumeroExterior", Trim(frmfacturacion.txtOrigNumExt.Text))
                End If
                If Trim(frmfacturacion.txtOrigNumInt.Text) <> "" Then
                    .WriteAttributeString("NumeroInterior", Trim(frmfacturacion.txtOrigNumInt.Text))
                End If
                If Trim(frmfacturacion.cboOrigMun.Text) <> "" Then
                    .WriteAttributeString("Municipio", Trim(dameclaveMun))
                End If
                'If Trim(varOrigLoc) <> "" Then
                '    .WriteAttributeString("Localidad", Trim(varOrigLoc))
                'End If
                If Trim(frmfacturacion.cboOrigColonia.Text) <> "" Then
                    .WriteAttributeString("Colonia", Trim(dameclaveColonia))
                End If
                .WriteAttributeString("Pais", "MEX")
                .WriteAttributeString("Estado", Trim(dameclaveEdo))
                .WriteAttributeString("CodigoPostal", Trim(frmfacturacion.txtOrigCP.Text))
                .WriteAttributeString("Calle", Trim(frmfacturacion.txtOrigCalle.Text))
                .WriteEndElement() ' fin domicilio

                .WriteEndElement() ' fin UBICACION 1

                .WriteStartElement("cartaporte20:Ubicacion")
                .WriteAttributeString("DistanciaRecorrida", frmfacturacion.txtDestinioDist.Text)
                'Si el campo TranspInternac contiene el valor “No” y si existe la sección
                'TransporteFerroviario, TransporteMaritimo o TransporteAereo de la
                'sección Mercancias, este campo se debe registrar y debe contener una
                'clave del catálogo del complemento Carta Porte c_TipoEstacion,
                'publicado en el portan del SAT

                'En otro caso, si el campo TranspInternac contiene el valor “Sí” este
                'campo no debe registrarse siempre que el Origen o Destino de los
                'bienes o mercancías sea fuera de territorio nacional, por lo que el
                'campo Pais de la sección Ubicacion debe contener una clave distinta
                'de “MEX”, en caso contrario se debe registrar una clave del catálogo del
                'complemento Carta Porte c_TipoEstacion, publicado en el portal del
                'SAT.

                'If frmfacturacion.chkInter.Checked = False Then
                '    .WriteAttributeString("TipoEstacion", "01")
                'End If

                .WriteAttributeString("TipoUbicacion", "Destino")

                If Trim(frmfacturacion.cboDesDestinatario.Text) <> "" Then
                    .WriteAttributeString("NombreRemitenteDestinatario", Trim(frmfacturacion.cboDesDestinatario.Text))
                End If

                .WriteAttributeString("RFCRemitenteDestinatario", Trim(frmfacturacion.txtDesRFC.Text))
                Dim varDesFechaHora As String = ""
                varDesFechaHora = Format(CDate(frmfacturacion.dtpDesFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpDesHora.Value), "HH:mm:ss")
                .WriteAttributeString("FechaHoraSalidaLlegada", varDesFechaHora)

                'If dgdist.RowCount > 1 Then
                '    .WriteAttributeString("IDDestino", dgdist.Rows(i).Cells(1).Value.ToString)
                'End If

                .WriteStartElement("cartaporte20:Domicilio")
                If Trim(frmfacturacion.txtDestinoNumE.Text) <> "" Then
                    .WriteAttributeString("NumeroExterior", Trim(frmfacturacion.txtDestinoNumE.Text))
                End If
                If Trim(frmfacturacion.txtDestinoNumI.Text) <> "" Then
                    .WriteAttributeString("NumeroInterior", Trim(frmfacturacion.txtDestinoNumI.Text))
                End If
                If Trim(frmfacturacion.cboDestinoMun.Text) <> "" Then
                    .WriteAttributeString("Municipio", Trim(dameclaveMunD))
                End If
                If Trim(frmfacturacion.cboDestinoColonia.Text) <> "" Then
                    .WriteAttributeString("Colonia", Trim(dameclaveColoniaD))
                End If
                If frmfacturacion.chkInter.Checked = True Then
                    .WriteAttributeString("Localidad", Trim(frmfacturacion.txtDestinoLoc.Text))
                End If
                .WriteAttributeString("Pais", dameclavePais)
                .WriteAttributeString("Estado", dameclaveEdoD)
                .WriteAttributeString("CodigoPostal", frmfacturacion.txtDestinoCP.Text)
                .WriteAttributeString("Calle", frmfacturacion.txtDestinoCalle.Text)
                '.WriteAttributeString("Referencia", "casa blanca")

                .WriteEndElement() ' fin domicilio
                .WriteEndElement() ' fin UBICACION 2
                .WriteEndElement() ' fin UBICACIONES

                '=========================== COMIENZA Mercancias
                .WriteStartElement("cartaporte20:Mercancias")
                Dim pesobruto As Double = 0
                For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                    pesobruto = pesobruto + CDec(frmfacturacion.dgProductos.Rows(i).Cells(5).Value.ToString)
                Next

                Dim unidadpeso As String = ""
                For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                    unidadpeso = frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString
                    Exit For
                Next

                .WriteAttributeString("PesoBrutoTotal", pesobruto)
                .WriteAttributeString("UnidadPeso", unidadpeso)
                .WriteAttributeString("NumTotalMercancias", frmfacturacion.dgProductos.RowCount)

                For i = 0 To frmfacturacion.dgProductos.RowCount - 1

                    .WriteStartElement("cartaporte20:Mercancia")
                    .WriteAttributeString("ValorMercancia", frmfacturacion.dgProductos.Rows(i).Cells(4).Value.ToString)

                    If frmfacturacion.chkInter.Checked = True Then
                        .WriteAttributeString("UUIDComercioExt", frmfacturacion.dgProductos.Rows(i).Cells(7).Value.ToString) '.WriteAttributeString("UUIDComercioExt", "182fe8c7-bf27-43e6-b21b-b1a59eaa8399")
                        .WriteAttributeString("FraccionArancelaria", frmfacturacion.dgProductos.Rows(i).Cells(8).Value.ToString) '.WriteAttributeString("FraccionArancelaria", "3923100301")
                    End If

                    .WriteAttributeString("PesoEnKg", frmfacturacion.dgProductos.Rows(i).Cells(5).Value.ToString)
                    .WriteAttributeString("Moneda", "MXN")
                    .WriteAttributeString("Descripcion", frmfacturacion.dgProductos.Rows(i).Cells(0).Value.ToString)
                    .WriteAttributeString("ClaveUnidad", frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString)
                    .WriteAttributeString("Cantidad", frmfacturacion.dgProductos.Rows(i).Cells(3).Value.ToString)
                    .WriteAttributeString("BienesTransp", frmfacturacion.dgProductos.Rows(i).Cells(2).Value.ToString)

                    'If dgdist.RowCount > 1 Then
                    '    For i = 0 To dgdist.RowCount - 1
                    '        .WriteStartElement("cartaporte20:CantidadTransporta")
                    '        .WriteAttributeString("Cantidad", dgdist.Rows(i).Cells(2).Value.ToString)
                    '        .WriteAttributeString("IDOrigen", varIdOrigen)
                    '        .WriteAttributeString("IDDestino", dgdist.Rows(i).Cells(1).Value.ToString)
                    '        .WriteEndElement() ' fin CantidadTransporta
                    '    Next
                    'End If
                    .WriteEndElement() ' fin Mercancia
                Next

                .WriteStartElement("cartaporte20:Autotransporte")
                .WriteAttributeString("PermSCT", dameclavePermisoSCT)
                .WriteAttributeString("NumPermisoSCT", frmfacturacion.txtNumPermisoSCT.Text)

                .WriteStartElement("cartaporte20:IdentificacionVehicular")
                .WriteAttributeString("PlacaVM", frmfacturacion.txtPlaca.Text)
                .WriteAttributeString("ConfigVehicular", dameclaveConfigV)
                .WriteAttributeString("AnioModeloVM", frmfacturacion.txtModeloAño.Text)
                .WriteEndElement() ' fin identificacion vehicular

                .WriteStartElement("cartaporte20:Seguros")
                .WriteAttributeString("AseguraRespCivil", frmfacturacion.txtAseguradora.Text)
                .WriteAttributeString("PolizaRespCivil", frmfacturacion.txtNumPoliza.Text)
                .WriteEndElement() ' fin identificacion vehicular

                If frmfacturacion.DataGridView1.RowCount > 0 Then
                    .WriteStartElement("cartaporte20:Remolques")
                    For i = 0 To frmfacturacion.DataGridView1.RowCount - 1
                        .WriteStartElement("cartaporte20:Remolque")
                        .WriteAttributeString("SubTipoRem", frmfacturacion.DataGridView1.Rows(i).Cells(2).Value.ToString)
                        .WriteAttributeString("Placa", frmfacturacion.DataGridView1.Rows(i).Cells(0).Value.ToString)
                        .WriteEndElement() ' fin identificacion Remolque
                    Next
                    .WriteEndElement() ' fin identificacion Remolques
                End If

                .WriteEndElement() ' fin autotransport
                .WriteEndElement() ' fin Mercancias

                '=========================== COMIENZA Figura Transporte
                .WriteStartElement("cartaporte20:FiguraTransporte")
                '.WriteAttributeString("CveTransporte", "01")

                .WriteStartElement("cartaporte20:TiposFigura")
                '.WriteAttributeString("TipoFigura", "01")
                If frmfacturacion.cboTipoFigura.Text = "Operador" Then
                    .WriteAttributeString("TipoFigura", "01")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Propietario" Then
                    .WriteAttributeString("TipoFigura", "02")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Arrendador" Then
                    .WriteAttributeString("TipoFigura", "03")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Notificado" Then
                    .WriteAttributeString("TipoFigura", "04")
                End If

                '.WriteAttributeString("ResidenciaFiscalOperador", "MEX")
                If Trim(frmfacturacion.txtOpeRFC.Text) <> "" Then
                    .WriteAttributeString("RFCFigura", frmfacturacion.txtOpeRFC.Text)
                End If
                If Trim(frmfacturacion.txtOpeLicencia.Text) <> "" Then
                    .WriteAttributeString("NumLicencia", frmfacturacion.txtOpeLicencia.Text)
                End If

                If Trim(frmfacturacion.cboOpeNombre.Text) <> "" Then
                    .WriteAttributeString("NombreFigura", frmfacturacion.cboOpeNombre.Text)
                End If

                '.WriteAttributeString("NombreOperador", varOpeNom)

                .WriteEndElement() ' fin Tipos Figura
                .WriteEndElement() ' fin Figura Transporte
                .WriteEndElement() ' fin CARTA PORTE
                .WriteEndElement() ' fin complemento
            End If

            'termina carta porte
            .WriteEndElement()

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML
        If varrutabase <> "" Then
            xmldoc.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Load(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        End If
        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml

        If varrutabase <> "" Then
            xmldoc.Save("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Save(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        End If

        '================================= termina xml base3

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""
        frmfacturacion.ProgressBar1.Value = 60
        frmfacturacion.lbl_proceso.Text = "Creando XML Timbrado ..."
        My.Application.DoEvents()
        If timbre_f(serie, folio, folio_sat_uuid, fecha_folio_sat, razon_social, rfc_empresa, cadena_orig, no_csd_emp, certificado_sat) Then
            'If timbre_f(serie, folio, folio_sat_uuid, fecha_folio_sat, razon_social, rfc_empresa, cadena_orig, certificado_sat, certificado_sat) Then

            crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\" & nombreCFD)

            If varrutabase <> "" Then
                crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

            Do While (Lector.Read())
                Select Case Lector.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
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
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            '   cadena_orig = CadenaOrg(folio_sat_uuid, fecha_folio_sat, sello_emisor, certificado_sat)
            frmfacturacion.ProgressBar1.Value = 70
            frmfacturacion.lbl_proceso.Text = "Guardando Datos Factura ..."
            My.Application.DoEvents()
            actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, IIf(frmfacturacion.Cmb_TipoFact.Text = "NOTA DE CREDITO", ESTATUS_NOTASCREDITO, ESTATUS_FACTURA), id_evento)

            frmfacturacion.ProgressBar1.Value = 75
            'Actualiza_ventasf(folio)

            frmfacturacion.lbl_proceso.Text = "Generando Qr ..."
            My.Application.DoEvents()
            ima_qr(rfc_empresa, rfc_receptor, total, folio_sat_uuid, id_evento, razon_social, Right(sello_emisor, 8))
            Return True
        Else
            actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, ESTATUS_FACTURA_ERROR, id_evento)
            Return False
        End If
    End Function

    Public Function GeneraXML4(ByVal folio As String, ByVal serie As String, ByVal subtotal As String,
                              ByVal descuento_f As String, ByVal motivo_descuento As String, ByVal total As String, ByVal metodo_pago As String,
                              ByVal pais As String, ByVal estado As String, ByVal rfc_empresa As String, ByVal razon_social As String,
                              ByVal calle_empresa As String, ByVal num_empresa_ext As String, ByVal num_empresa_int As String, ByVal colonia_empresa As String, ByVal municipio_empresa As String,
                              ByVal estado_empresa As String, ByVal pais_empresa As String, ByVal cp_empresa As String, ByVal actividad_empresa As String,
                              ByVal rfc_receptor As String, ByVal nombre_receptor As String, ByVal numero_domicilio_receptor As String, ByVal numero_domicilio_receptor_int As String,
                              ByVal calle_receptor As String, ByVal colonia_receptor As String, ByVal municipio_receptor As String,
                              ByVal cp_receptor As String, ByVal numero_receptor_ext As String, ByVal regimen_empresa As String, ByVal registro_patronal As String,
                              ByVal id_facturaa As String, ByVal ruta_certificado As String, ByVal ruta_key As String, ByVal pass_key As String,
                              ByVal id_evento As String, ByVal descripcion_evento As String, ByVal precio_paqq As String, ByVal reg_fiscal As String, ByVal tipo_pago_e As String, ByVal id_empresa As Integer, ByVal cartap As Integer, ByVal varnumped As String)

        Dim nombreCFD As String = ""
        Dim tretencionesp As Double = 0

        Dim newrazonsocial As String = razon_social 'Replace(razon_social, Chr(34), "&quot").ToString
        Dim newcarpeta As String = Replace(razon_social, Chr(34), "").ToString

        Select Case frmfacturacion.Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & serie & folio & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & serie & folio & ".xml"
            Case "RECIBO DE ARRENDAMIENTO"
                nombreCFD = "A" & serie & folio & ".xml"
            Case "RECIBO DE HONORARIOS"
                nombreCFD = "H" & serie & folio & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & serie & folio & ".xml"
        End Select

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\")

        Dim miXml As XmlTextWriter = New XmlTextWriter(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\")
            miXml = New XmlTextWriter("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        End If

        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechacreacion As DateTime = Now

        Dim nuevoIEPS265 As Double = 0
        Dim nuevoIEPS3 As Double = 0
        Dim nuevoIEPS53 As Double = 0
        Dim nuevoIEPS5 As Double = 0
        Dim nuevoIEPS1600 As Double = 0
        Dim nuevoIEPS304 As Double = 0
        Dim nuevoIEPS25 As Double = 0
        Dim nuevoIEPS09 As Double = 0
        Dim nuevoIEPS8 As Double = 0
        Dim nuevoIEPS07 As Double = 0
        Dim nuevoIEPS06 As Double = 0
        Dim nuevoIEPS03 As Double = 0
        Dim nuevoIEPS_SinIVA As Double = 0
        Dim nuevoIEPS_ConIVA As Double = 0

        Dim basenuevoIEPS265 As Double = 0
        Dim basenuevoIEPS3 As Double = 0
        Dim basenuevoIEPS53 As Double = 0
        Dim basenuevoIEPS5 As Double = 0
        Dim basenuevoIEPS1600 As Double = 0
        Dim basenuevoIEPS304 As Double = 0
        Dim basenuevoIEPS25 As Double = 0
        Dim basenuevoIEPS09 As Double = 0
        Dim basenuevoIEPS8 As Double = 0
        Dim basenuevoIEPS07 As Double = 0
        Dim basenuevoIEPS06 As Double = 0
        Dim basenuevoIEPS03 As Double = 0
        Dim basenuevoIEPS_SinIVA As Double = 0

        fechaFormateada = DateAndTime.Now.ToString("s")
        '        fechaFormateada = fechacreacion.ToString("yyyy-MM-ddThh:mm:ss")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-ddTHH:mm:ss")

        With miXml
            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE
            .WriteStartElement("cfdi:Comprobante")
            'aqui empece
            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/4")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            If frmfacturacion.CheckBox2.Checked = True Then
                .WriteStartAttribute("xsi:schemaLocation")
                .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/CartaPorte20 http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte20.xsd")
                .WriteEndAttribute()

                .WriteStartAttribute("xmlns:cartaporte20")
                .WriteValue("http://www.sat.gob.mx/CartaPorte20")
                .WriteEndAttribute()

            Else
                .WriteStartAttribute("xsi:schemaLocation")
                .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd")
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(cp_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("MetodoPago")
            .WriteValue(frmfacturacion.Text_FormaPago.SelectedValue)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            If frmfacturacion.Cmb_TipoFact.Text = "NOTA DE CREDITO" Then
                .WriteValue("E")
            Else
                .WriteValue("I")
            End If

            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("" & Replace(Format(CDec(total), "####0.00"), ",", ""))
            .WriteEndAttribute()

            .WriteStartAttribute("TipoCambio")
            .WriteValue("1")
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("MXN")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue(Replace(Format(CDec(subtotal), "####0.00"), ",", ""))
            .WriteEndAttribute()

            .WriteStartAttribute("FormaPago")
            .WriteValue(metodo_pago)
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue("" & fechaFormateada1 & "")
            .WriteEndAttribute()

            .WriteStartAttribute("Folio")
            .WriteValue(folio)
            .WriteEndAttribute()

            .WriteStartAttribute("Version")
            .WriteValue("4.0")
            .WriteEndAttribute()

            .WriteStartAttribute("Serie")
            .WriteValue(serie)
            .WriteEndAttribute()

            If descuento_f > 0 Then
                .WriteStartAttribute("Descuento")
                .WriteValue(Replace(Format(CDec(descuento_f), "####0.00"), ",", ""))
                .WriteEndAttribute()
            End If

            .WriteStartAttribute("Exportacion")
            .WriteValue("01")
            .WriteEndAttribute()

            If frmfacturacion.Cmb_RFC.Text <> "XAXX010101000" And frmfacturacion.Cmb_RFC.Text <> "XEXX010101000" Then

                If Trim(frmfacturacion.Text_CondiPago.Text) <> "" Then
                    .WriteStartAttribute("CondicionesDePago")
                    .WriteValue(Trim(frmfacturacion.Text_CondiPago.Text))
                    .WriteEndAttribute()
                End If

            End If

            '.WriteStartAttribute("NoCertificado")
            'If frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
            '    .WriteValue("30001000000400002447")
            'Else
            '    .WriteValue("30001000000400002447")
            'End If
            '.WriteEndAttribute()

            '.WriteStartAttribute("Certificado")
            'If frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
            '    .WriteValue("MIIF7zCCA9egAwIBAgIUMzAwMDEwMDAwMDA0MDAwMDI0NDcwDQYJKoZIhvcNAQELBQAwggErMQ8wDQYDVQQDDAZBQyBVQVQxLjAsBgNVBAoMJVNFUlZJQ0lPIERFIEFETUlOSVNUUkFDSU9OIFRSSUJVVEFSSUExGjAYBgNVBAsMEVNBVC1JRVMgQXV0aG9yaXR5MSgwJgYJKoZIhvcNAQkBFhlvc2Nhci5tYXJ0aW5lekBzYXQuZ29iLm14MR0wGwYDVQQJDBQzcmEgY2VycmFkYSBkZSBjYWRpejEOMAwGA1UEEQwFMDYzNzAxCzAJBgNVBAYTAk1YMRkwFwYDVQQIDBBDSVVEQUQgREUgTUVYSUNPMREwDwYDVQQHDAhDT1lPQUNBTjERMA8GA1UELRMIMi41LjQuNDUxJTAjBgkqhkiG9w0BCQITFnJlc3BvbnNhYmxlOiBBQ0RNQS1TQVQwHhcNMTkwNjE3MjA1MDU1WhcNMjMwNjE3MjA1MDU1WjCCARUxNDAyBgNVBAMTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxNDAyBgNVBCkTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxNDAyBgNVBAoTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxJTAjBgNVBC0THElJQTA0MDgwNURaNCAvIEtBSE82NDExMDFCMzkxHjAcBgNVBAUTFSAvIEtBSE82NDExMDFITlRMS1MwNjEqMCgGA1UECxMhSUxVTklNQURPUkEgREUgQUxNQUNFTkVTIFNBIERFIENWMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhphiyS0yXFkRjef5ph34OekrmQ6v9HN8Je53Hb1ntTjiSfyYehbPjUbXGImvO9acFaDOYG07bkbSfFqVre6q5C6CzXI85R3SU8mh1Yt/vhECCuJyayBYs+RRghhSS01DfOcsgIurvS9I8focsSCkWjkw4SmIbVReGRTYzvsjmCrzLJFOAebr3arExvSXQ45EqL2kgdDhUS4duofNMCJy6SJyA6l+s5FdImRbxrRzZXsXd483ckiMPqNlJ+j4JGVCGPZYPcEMQzq2I+x5XNdWNO+jLgLCeMmFmuszDSxu2LUXRntKJYtWUnGDjLc+KImIhyTUoMSFTPrjCAVYT5o21QIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEArxekuVwawqjYDuaYfO/Tmre985sgjIoRaEhfHIUCU2Zo2jy7TXO3yTo3b4urW0s11SQfBgpwT5xu5gzsOr3scSNiVyuc1O3zLB05JbmEeBtwNPtIz7VyKVInTfn2MEGlS/olS1E8Q6NoyoE3yFcX2AZYRwOWnwpRXtJNyggCa+9y62IRGULfCqwnKt/YKCHioObbDtCFzPjik4E0jXB7GMl9WQFcTtpU1fM17zLGjQJh3cWqNyH/41UZjRFRBvBQOsyfl46doMOPZF1kOH16D/oTH4N9SaPNWL28XpeZhNOMy5TwM6jRyOWfXlhgFqoud1LYgh9RuoHaLg4pgZWs2DdqIGRPjKb/gNTDjkO+dMHltw4GBsEvR9bFQ/DkLk5+4lb0v9uBQ0vox83N7ovr5W6d/IvT5zW4fTxvykv7taYct43soCzUcX9+WKHChi8uIluEXn5uY5qI94FvD2myam9aUSQdZX9LrdWAE1tEoV17rFc1neN0vEqlVmax04wIcRh4Sfc1ZvbU/dMJfLC0EYVF0XgImg9wWg/8kohyCbSQx7TOO90UW86QYmCxE5EmmfpRD3xqY9Wk+pOHHJEWSJ17jvz2u/Kqv3UkZUSR0Q47cQGUR+NRURVjzS3S41iAZuAZJwh8gtrGvyE0fVyf7Rbd4txXqYVVGWBLPl1ai2M=")
            'Else
            '    .WriteValue("MIIF7zCCA9egAwIBAgIUMzAwMDEwMDAwMDA0MDAwMDI0NDcwDQYJKoZIhvcNAQELBQAwggErMQ8wDQYDVQQDDAZBQyBVQVQxLjAsBgNVBAoMJVNFUlZJQ0lPIERFIEFETUlOSVNUUkFDSU9OIFRSSUJVVEFSSUExGjAYBgNVBAsMEVNBVC1JRVMgQXV0aG9yaXR5MSgwJgYJKoZIhvcNAQkBFhlvc2Nhci5tYXJ0aW5lekBzYXQuZ29iLm14MR0wGwYDVQQJDBQzcmEgY2VycmFkYSBkZSBjYWRpejEOMAwGA1UEEQwFMDYzNzAxCzAJBgNVBAYTAk1YMRkwFwYDVQQIDBBDSVVEQUQgREUgTUVYSUNPMREwDwYDVQQHDAhDT1lPQUNBTjERMA8GA1UELRMIMi41LjQuNDUxJTAjBgkqhkiG9w0BCQITFnJlc3BvbnNhYmxlOiBBQ0RNQS1TQVQwHhcNMTkwNjE3MjA1MDU1WhcNMjMwNjE3MjA1MDU1WjCCARUxNDAyBgNVBAMTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxNDAyBgNVBCkTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxNDAyBgNVBAoTK0lORElTVFJJQSBJTFVNSU5BRE9SQSBERSBBTE1BQ0VORVMgU0EgREUgQ1YxJTAjBgNVBC0THElJQTA0MDgwNURaNCAvIEtBSE82NDExMDFCMzkxHjAcBgNVBAUTFSAvIEtBSE82NDExMDFITlRMS1MwNjEqMCgGA1UECxMhSUxVTklNQURPUkEgREUgQUxNQUNFTkVTIFNBIERFIENWMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhphiyS0yXFkRjef5ph34OekrmQ6v9HN8Je53Hb1ntTjiSfyYehbPjUbXGImvO9acFaDOYG07bkbSfFqVre6q5C6CzXI85R3SU8mh1Yt/vhECCuJyayBYs+RRghhSS01DfOcsgIurvS9I8focsSCkWjkw4SmIbVReGRTYzvsjmCrzLJFOAebr3arExvSXQ45EqL2kgdDhUS4duofNMCJy6SJyA6l+s5FdImRbxrRzZXsXd483ckiMPqNlJ+j4JGVCGPZYPcEMQzq2I+x5XNdWNO+jLgLCeMmFmuszDSxu2LUXRntKJYtWUnGDjLc+KImIhyTUoMSFTPrjCAVYT5o21QIDAQABox0wGzAMBgNVHRMBAf8EAjAAMAsGA1UdDwQEAwIGwDANBgkqhkiG9w0BAQsFAAOCAgEArxekuVwawqjYDuaYfO/Tmre985sgjIoRaEhfHIUCU2Zo2jy7TXO3yTo3b4urW0s11SQfBgpwT5xu5gzsOr3scSNiVyuc1O3zLB05JbmEeBtwNPtIz7VyKVInTfn2MEGlS/olS1E8Q6NoyoE3yFcX2AZYRwOWnwpRXtJNyggCa+9y62IRGULfCqwnKt/YKCHioObbDtCFzPjik4E0jXB7GMl9WQFcTtpU1fM17zLGjQJh3cWqNyH/41UZjRFRBvBQOsyfl46doMOPZF1kOH16D/oTH4N9SaPNWL28XpeZhNOMy5TwM6jRyOWfXlhgFqoud1LYgh9RuoHaLg4pgZWs2DdqIGRPjKb/gNTDjkO+dMHltw4GBsEvR9bFQ/DkLk5+4lb0v9uBQ0vox83N7ovr5W6d/IvT5zW4fTxvykv7taYct43soCzUcX9+WKHChi8uIluEXn5uY5qI94FvD2myam9aUSQdZX9LrdWAE1tEoV17rFc1neN0vEqlVmax04wIcRh4Sfc1ZvbU/dMJfLC0EYVF0XgImg9wWg/8kohyCbSQx7TOO90UW86QYmCxE5EmmfpRD3xqY9Wk+pOHHJEWSJ17jvz2u/Kqv3UkZUSR0Q47cQGUR+NRURVjzS3S41iAZuAZJwh8gtrGvyE0fVyf7Rbd4txXqYVVGWBLPl1ai2M=")
            'End If
            '.WriteEndAttribute()

            '===========================COMIENZA Global

            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                .WriteStartElement("cfdi:InformacionGlobal")

                .WriteStartAttribute("Periodicidad")
                .WriteValue(dameclaveperiodo(frmfacturacion.cboPeriodicidad.Text))
                .WriteEndAttribute()

                .WriteStartAttribute("Meses")
                .WriteValue(dameclavemes(frmfacturacion.cboMeses.Text))
                .WriteEndAttribute()

                .WriteStartAttribute("Año")
                .WriteValue(frmfacturacion.txtAno.Text)
                .WriteEndAttribute()

                .WriteEndElement() 'Global

            End If

            '===========================COMIENZA Global


            If frmfacturacion.cboTipoRelacion.Text = "" Then
            Else
                .WriteStartElement("cfdi:CfdiRelacionados")

                .WriteStartAttribute("TipoRelacion")
                .WriteValue(frmfacturacion.cboTipoRelacion.SelectedValue)
                .WriteEndAttribute()

                For i = 0 To frmfacturacion.dgUUID.RowCount - 1
                    .WriteStartElement("cfdi:CfdiRelacionado")
                    .WriteStartAttribute("UUID")
                    .WriteValue(frmfacturacion.dgUUID.Rows(i).Cells(1).Value.ToString)
                    .WriteEndAttribute()
                    .WriteEndElement() 'Termina Relacionado
                Next
                .WriteEndElement() 'Termina relacionado

            End If

            'If frmfacturacion.cboTipoRelacion.Text = "" Then
            'Else
            '    .WriteStartElement("cfdi:CfdiRelacionados")

            '    .WriteStartAttribute("TipoRelacion")
            '    .WriteValue(frmfacturacion.cboTipoRelacion.SelectedValue)
            '    .WriteEndAttribute()

            '    .WriteStartElement("cfdi:CfdiRelacionado")

            '    .WriteStartAttribute("UUID")
            '    .WriteValue(frmfacturacion.txtUUID.Text)
            '    .WriteEndAttribute()

            '    .WriteEndElement() 'Termina Relacionado
            '    .WriteEndElement() 'Termina relacionado
            'End If

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")

            .WriteStartAttribute("Rfc")
            .WriteValue(rfc_empresa)
            .WriteEndAttribute()

            .WriteStartAttribute("Nombre")
            .WriteValue(newrazonsocial)
            .WriteEndAttribute()

            .WriteStartAttribute("RegimenFiscal")
            .WriteValue(regimen_empresa)
            .WriteEndAttribute()

            .WriteEndElement() 'Emisor

            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Rfc", rfc_receptor)
            .WriteAttributeString("Nombre", nombre_receptor)

            Dim Banderaglobal As Integer = 0
            Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
            Dim sinfo As String = ""
            Dim dr As DataRow
            Dim odata As New ToolKitSQL.myssql
            With odata
                If .dbOpen(cnn, sTarget, sinfo) Then
#Disable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    If .getDr(cnn, dr, "Select NumPart from Formatos where Facturas = 'SHIBBOLETH'", sinfo) Then
#Enable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                        If CDec(dr(0).ToString) = 1 Then
                            Banderaglobal = 1
                        End If
                    End If
                    cnn.Close()
                End If
            End With

            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Or frmfacturacion.Cmb_RFC.Text = "XEXX010101000" Then
                .WriteAttributeString("UsoCFDI", "S01")
                .WriteAttributeString("DomicilioFiscalReceptor", cp_empresa)
                .WriteAttributeString("RegimenFiscalReceptor", "616")
            Else
                .WriteAttributeString("UsoCFDI", frmfacturacion.cbo_usocfdi.SelectedValue)
                .WriteAttributeString("DomicilioFiscalReceptor", frmfacturacion.Text_CP.Text)
                .WriteAttributeString("RegimenFiscalReceptor", frmfacturacion.cbo_regimen.SelectedValue)
            End If

            .WriteEndElement() 'receptor

            '=========================== COMIENZA CONCEPTO

            Dim sumaimpuestosconcep As Double = 0
            Dim sumaImpFactGlobal As Double = 0

            Dim valorbaseivatotal As Double = 0
            Dim valorbaseivacero As Double = 0

            .WriteStartElement("cfdi:Conceptos")

            Dim cadenaunidad As String = ""
            Dim bandera As Integer = 0
            Dim ieps_porcentaje As String = ""
            Dim ieps_val As Integer = 0
            Dim arreg(500) As String
            Dim arreg2(500) As String
            Dim tcuota As Double = 0
            Dim prubasuma As Decimal = 0
            Dim sumaiva As Decimal = 0
            Dim banderaiva As Integer = 0
            Dim banderaArrays As Integer = 0
            Dim banderaArrays2 As Integer = 0
            Dim banderacambio As Integer = 0

            For ii = 0 To frmfacturacion.grid_prods.RowCount - 1
                'MsgBox(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString), 6))
                prubasuma += FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString), 6)
            Next

            For ii = 0 To frmfacturacion.grid_prods.RowCount - 1
                If frmfacturacion.grid_prods.Rows(ii).Cells(8).Value.ToString > 0 Then
                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                        If Banderaglobal = 1 Then
                            If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                                sumaiva += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(ii).Cells(9).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString)), 6)
                            Else
                                sumaiva += 0
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                                sumaiva += FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(19).Value.ToString), 6)
                            Else
                                sumaiva += 0 'FormatNumber(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(19).Value.ToString) * CDec(0.16), 6)
                            End If
                        End If

                    Else
                        If frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString > 0 Then
                            sumaiva += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(ii).Cells(9).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(ii).Cells(11).Value.ToString)), 6)
                        Else
                            sumaiva += 0
                        End If
                    End If
                End If
            Next

            sumaiva = FormatNumber(sumaiva * 0.16, 6)

            Dim actuieps As Double = 0

            If frmfacturacion.grid_prods.RowCount > 0 Then
                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                    actuieps = 0

                    cadenaunidad = ""
                    .WriteStartElement("cfdi:Concepto")
                    Dim varDescUnita As Double = 0
                    If descuento_f > 0 Then
                        .WriteAttributeString("Descuento", Replace(CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))
                    End If
                    .WriteAttributeString("Cantidad", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString, 6), ",", ""))
                    busca_unidad(cadenaunidad, frmfacturacion.grid_prods.Rows(i).Cells(2).Value.ToString)
                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                            ' .WriteAttributeString("Unidad", Mid(cadenaunidad, 1, 20))
                        Else
                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                .WriteAttributeString("NoIdentificacion", Mid(frmfacturacion.grid_prods.Rows(i).Cells(0).Value.ToString, 1, 20))
                            Else
                                .WriteAttributeString("NoIdentificacion", Mid(frmfacturacion.grid_prods.Rows(i).Cells(12).Value.ToString, 1, 20))
                            End If
                        End If
                    Else
                        '.WriteAttributeString("Unidad", Mid(cadenaunidad, 1, 20))
                    End If
                    .WriteAttributeString("Descripcion", frmfacturacion.grid_prods.Rows(i).Cells(1).Value.ToString)
                    .WriteAttributeString("ValorUnitario", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) + CDec(varDescUnita), 6), ",", ""))

                    'MsgBox(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) + CDec(varDescUnita), 6))

                    Dim banderarecorta As Integer = 0
                    Dim banderadecimales As Integer = 0
                    Dim strceros As String = "0."

                    If frmfacturacion.Text_SubTotal.Text = FormatNumber(prubasuma, 2) Then
                        For ii = 1 To Len(CStr(prubasuma))
                            If banderarecorta = 1 Then
                                banderadecimales += 1
                                strceros &= "0"
                            End If

                            If Mid(CStr(prubasuma), ii, 1) = "." Then banderarecorta = 1
                            'prubasuma += FormatNumber(frmfacturacion.grid_prods.Rows(ii).Cells(5).Value.ToString, 6)
                        Next
                        If banderadecimales > 2 Then
                            If frmfacturacion.Text_SubTotal.Text > FormatNumber(prubasuma, 2) Then
                                strceros = CStr(Left(strceros, banderadecimales + 1)) & "1"
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) + CDec(strceros), 6), ",", ""))
                            Else
                                If frmfacturacion.Text_SubTotal.Text = FormatNumber(prubasuma, 2) Then
                                    If frmfacturacion.grid_prods.RowCount = 1 Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 2), ",", ""))
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                                    End If
                                    'If frmfacturacion.grid_prods.RowCount = 1 Then
                                    '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 2), ",", ""))
                                    'Else
                                    '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    'End If
                                Else
                                    strceros = CStr(Left(strceros, banderadecimales + 1)) & "1"
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(strceros), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                                        End If
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(strceros), 6), ",", ""))
                                    End If
                                    'If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                    '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    'Else
                                    '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) - CDec(strceros), 6), ",", ""))
                                    'End If
                                End If

                            End If
                        Else
                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                            '.WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                        End If
                    Else
                        If frmfacturacion.Text_SubTotal.Text > FormatNumber(prubasuma, 2) Then
                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 2), ",", ""))
                            '.WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 2), ",", ""))
                        Else
                            If FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6) > 0 And FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString, 6) = 0 Then
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                            Else
                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString), 6), ",", ""))
                            End If
                            'If FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6) > 0 And FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString, 6) = 0 Then
                            '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                            'Else
                            '    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                            'End If
                        End If
                    End If

                    .WriteAttributeString("ClaveUnidad", Trim(frmfacturacion.grid_prods.Rows(i).Cells(2).Value.ToString))
                    .WriteAttributeString("ClaveProdServ", Trim(frmfacturacion.grid_prods.Rows(i).Cells(14).Value.ToString))

                    'If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 Or frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Or frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString > 0 Then
                    .WriteAttributeString("ObjetoImp", "02")
                    'Else
                    '    .WriteAttributeString("ObjetoImp", "01")
                    'End If

                    If frmfacturacion.CheckBox2.Checked = True Then
                        If frmfacturacion.chkInter.Checked = True Then
                            For ix = 0 To frmfacturacion.dgProductos.RowCount - 1
                                If Trim(varnumped) <> "" Then
                                    .WriteStartElement("cfdi:InformacionAduanera")
                                    .WriteAttributeString("NumeroPedimento", Trim(varnumped)) '.WriteAttributeString("NumeroPedimento", "21  47  3807  8003832")
                                    .WriteEndElement() 'info aduanera
                                End If
                            Next
                        End If
                    End If

                    '=========================== comiezan impuestos de los productos

                    Dim importeconceptoiva As Double = 0
                    Dim retenidop As Double = 0
                    Dim sumatoria As Decimal = 0
                    Dim sumatoria1 As Decimal = 0
                    Dim valorMaximo As Decimal = 0

                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                        tcuota = CDbl(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) / 100
                        If frmfacturacion.txt_impuestos.Text > 0 Then
                            'sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)), 6), ",", "")
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                If Banderaglobal = 1 Then
                                    If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                        sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                        sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    Else
                                        sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    End If
                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    Else
                                        If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString) > 0 Then
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    End If
                                End If
                            Else
                                If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                    sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                    sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                Else
                                    sumatoria = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString), 6), ",", "")
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                End If
                            End If
                        Else
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                If Banderaglobal = 1 Then
                                    If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                        sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                        sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    Else
                                        sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                        sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                    End If

                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString, 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(19).Value.ToString, 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If
                                    Else
                                        If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                            sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        Else
                                            sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                            sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                        End If

                                    End If
                                End If
                            Else
                                If frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString > 0 Then
                                    sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                    sumatoria = sumatoria - CDec(frmfacturacion.grid_prods.Rows(iii).Cells(9).Value.ToString)
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                Else
                                    sumatoria = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6), ",", "")
                                    sumatoria = FormatNumber(CDec(FormatNumber(sumatoria, 6)) * tcuota, 2)
                                End If

                            End If
                        End If
                        sumatoria1 = sumatoria1 + sumatoria
                    Next

                    tcuota = CDbl(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) / 100
                    If frmfacturacion.txt_impuestos.Text > 0 Then
                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                            If Banderaglobal = 1 Then

                                If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                Else
                                    'MsgBox(Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                                End If
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", "")
                                        'importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", "")
                                    End If
                                Else
                                    If CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString) > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", "")
                                    End If
                                End If
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                            Else
                                'MsgBox(Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                            End If
                        End If
                        'importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                    Else
                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                            If Banderaglobal = 1 Then
                                If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                Else
                                    importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                                End If
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString, 6), ",", "")
                                    End If
                                Else
                                    If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                        importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                                    Else
                                        importeconceptoiva = Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", "")
                                    End If

                                End If
                            End If
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString > 0 Then
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", "")
                            Else
                                importeconceptoiva = Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDbl(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", "")
                            End If
                        End If
                        valorMaximo = importeconceptoiva
                    End If

                    strceros = "0."

                    Dim cuantofalta As Decimal = 0
                    Dim cuantoSobra As Decimal = 0
                    Dim valorMinimo As Decimal = 0

                    'valorMinimo = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 6)

                    If CDec(FormatNumber(sumaiva, 2)) = CDec(frmfacturacion.Text_IVA.Text) Then
                        importeconceptoiva = FormatNumber(importeconceptoiva * tcuota, 6)
                    Else
                        If CDec(frmfacturacion.Text_IVA.Text) = FormatNumber(sumatoria1, 2) Then
                            If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                If banderaiva = 0 Then
                                    'banderaiva = 1
                                    'strceros &= "01"
                                    'importeconceptoiva = importeconceptoiva + CDec(strceros)
                                End If
                            Else
                                importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    strceros &= "01"
                                    importeconceptoiva = FormatNumber(importeconceptoiva - CDec(strceros), 2)
                                    valorMinimo = FormatNumber(CDec(FormatNumber(valorMaximo, 6)) * tcuota, 6) - importeconceptoiva
                                    If valorMinimo > 0.01 Then
                                        importeconceptoiva = FormatNumber(importeconceptoiva + CDec(strceros), 2)
                                    End If
                                Else
                                    banderaiva = 1
                                    strceros &= "01"
                                    importeconceptoiva = FormatNumber(importeconceptoiva - CDec(strceros), 2)
                                    valorMinimo = FormatNumber(CDec(FormatNumber(valorMaximo, 6)) * tcuota, 6) - importeconceptoiva
                                    If valorMinimo > 0.01 Then
                                        importeconceptoiva = FormatNumber(importeconceptoiva + CDec(strceros), 2)
                                    End If
                                End If

                            End If
                        Else
                            If CDec(frmfacturacion.Text_IVA.Text) > FormatNumber(sumaiva, 2) Then
                                'cuantofalta = CDec(frmfacturacion.Text_IVA.Text) - CDec(FormatNumber(sumaiva, 2))
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    'strceros &= "01"
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    importeconceptoiva = importeconceptoiva + CDec(cuantofalta)
                                Else
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 6)
                                End If
                            Else
                                cuantoSobra = CDec(FormatNumber(sumaiva, 2)) - CDec(frmfacturacion.Text_IVA.Text)
                                If banderaiva = 0 Then
                                    banderaiva = 1
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                    importeconceptoiva = importeconceptoiva - CDec(cuantoSobra)
                                Else
                                    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 6)) * tcuota, 2)
                                End If
                                'cuantoSobra = CDec(FormatNumber(sumaiva, 2)) - CDec(frmfacturacion.Text_IVA.Text)
                                'importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                                'If banderaiva = 0 Then
                                '    banderaiva = 1
                                '    importeconceptoiva = importeconceptoiva - CDec(cuantoSobra)
                                'End If
                            End If
                        End If

                        'If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                        '    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                        '    If banderaiva = 0 Then
                        '        'banderaiva = 1
                        '        'strceros &= "01"
                        '        'importeconceptoiva = importeconceptoiva + CDec(strceros)
                        '    End If
                        'Else
                        '    importeconceptoiva = FormatNumber(CDec(FormatNumber(importeconceptoiva, 2)) * tcuota, 2)
                        '    If banderaiva = 0 Then
                        '        banderaiva = 1
                        '        strceros &= "01"
                        '        importeconceptoiva = importeconceptoiva - CDec(strceros)
                        '    End If
                        'End If
                    End If

                    sumaimpuestosconcep = sumaimpuestosconcep + importeconceptoiva

                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                        If Banderaglobal = 1 Then
                        Else
                            sumaImpFactGlobal += FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString) * 0.16), 6)
                        End If
                    End If

                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                        'si tiene iva , iva retenido, ieps
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)

                        .WriteEndElement() ' fin Traslado iva

                        .WriteStartElement("cfdi:Traslado")

                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                            ieps_val = ieps_val + 1
                        End If

                        .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                        .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                        .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                        ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                        .WriteAttributeString("Impuesto", "003")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin Traslado ieps

                        .WriteEndElement() ' fin Traslados


                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten iva

                        retenidop = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(18).Value.ToString, 6) 'FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString) / frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString, 6)
                        tretencionesp = retenidop
                        .WriteAttributeString("Importe", Replace(FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(retenidop), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin reten iva

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString > 0 Then
                        'si tiene iva, iva retenido, isr
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)

                        .WriteEndElement() ' fin Traslado

                        .WriteEndElement() ' fin Traslados

                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten iva

                        retenidop = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(18).Value.ToString, 6)
                        tretencionesp = retenidop
                        .WriteAttributeString("Importe", Replace(FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(retenidop), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin reten iva

                        .WriteStartElement("cfdi:Retencion") 'inicia reten isr

                        retenidop = FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString) / frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString, 6)
                        tretencionesp = retenidop
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) * frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString, 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString, 6), ",", ""))
                        .WriteAttributeString("Impuesto", "001")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin reten isr

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString > 0 Then
                        'si tiene iva, iva retenido
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))

                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)

                        .WriteEndElement() ' fin Traslado

                        .WriteEndElement() ' fin Traslados

                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten iva

                        retenidop = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(18).Value.ToString, 6)
                        tretencionesp = retenidop

                        .WriteAttributeString("Importe", Replace(FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(retenidop), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), ",", ""))

                        .WriteEndElement() ' fin reten iva

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                        'si tiene iva, ieps
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                            If Banderaglobal = 1 Then
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                If frmfacturacion.txt_impuestos.Text > 0 Then
                                    '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                    If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6)
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6)
                                    End If
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)
                                End If
                                .WriteEndElement() ' fin Traslado
                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    If frmfacturacion.Text_IVA.Text = FormatNumber(sumaiva, 2) Or banderacambio = 1 Then
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6)), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6)
                                        .WriteEndElement() ' fin Traslado
                                    Else
                                        If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                            banderacambio = 1
                                            Dim cuenta As Decimal = 0
                                            cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01
                                            cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                            cuenta = cuenta
                                            If cuenta > 0 Then
                                                cuenta = cuenta
                                            Else
                                                cuenta = Math.Abs(cuenta)
                                            End If
                                            If cuenta > 0.009 Then
                                                banderacambio = 0
                                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01, ",", ""))
                                            End If
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                            valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6)
                                            .WriteEndElement() ' fin Traslado
                                        Else
                                            banderacambio = 1
                                            Dim cuenta As Decimal = 0
                                            cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01
                                            cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                            cuenta = cuenta
                                            If cuenta > 0 Then
                                                cuenta = cuenta
                                            Else
                                                cuenta = Math.Abs(cuenta)
                                            End If
                                            If cuenta > 0.009 Then
                                                banderacambio = 0
                                                .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01, ",", ""))
                                            End If
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                            valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If
                                    End If
                                Else
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    If frmfacturacion.txt_impuestos.Text > 0 Then
                                        '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                        If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                            valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6)
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6), ",", ""))
                                            valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)), 6)
                                        End If
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                End If
                            End If

                        Else
                            .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                            .WriteAttributeString("Impuesto", "002")
                            If frmfacturacion.txt_impuestos.Text > 0 Then
                                '.WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))
                                If CStr(frmfacturacion.txtNotaVenta.Text) <> "" Then
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                    valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6)
                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6), ",", ""))
                                    valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) + CDec(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString), 6)
                                End If
                            Else
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)
                            End If
                            .WriteEndElement() ' fin Traslado
                        End If

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                            If Banderaglobal = 1 Then

                                .WriteStartElement("cfdi:Traslado")
                                If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                    arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                    ieps_val = ieps_val + 1
                                End If

                                Select Case frmfacturacion.grid_prods.Rows(i).Cells("Ieps_Porcentaje").Value
                                    Case "0.265000"
                                        nuevoIEPS265 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.300000"
                                        nuevoIEPS3 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.530000"
                                        nuevoIEPS53 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.500000"
                                        nuevoIEPS5 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "1.600000"
                                        nuevoIEPS1600 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.304000"
                                        nuevoIEPS304 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.250000"
                                        nuevoIEPS25 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.090000"
                                        nuevoIEPS09 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.080000"
                                        nuevoIEPS8 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.070000"
                                        nuevoIEPS07 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.060000"
                                        nuevoIEPS06 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    Case "0.030000"
                                        nuevoIEPS03 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                End Select

                                'nuevoIEPS_ConIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6))

                                .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                                .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                .WriteAttributeString("Impuesto", "003")
                                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                    If Banderaglobal = 1 Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        If frmfacturacion.txtNotaVenta.Text = "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                        End If
                                    End If

                                Else
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                End If
                                .WriteEndElement() ' fin Traslado
                                .WriteEndElement() ' fin Traslados
                                .WriteEndElement() ' fin impuestos

                            Else
                                If frmfacturacion.txtNotaVenta.Text <> "" Then
                                    '"0.265"
                                    If var265(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS265 = CDec(nuevoIEPS265) + CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                        actuieps += CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.265000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var265(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS265 += FormatNumber(CDec(var265(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.30"
                                    If var3(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS3 = CDec(nuevoIEPS3) + CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                        actuieps += CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.300000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var3(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS3 += FormatNumber(CDec(var3(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.53"
                                    If var53(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS53 = CDec(nuevoIEPS53) + CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                        actuieps += CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.530000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var53(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS53 += FormatNumber(CDec(var53(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado

                                    End If

                                    '"0.50"
                                    If var5(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS5 = CDec(nuevoIEPS5) + CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                        actuieps += CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.500000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var5(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS53 += FormatNumber(CDec(var53(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"1.60"
                                    If var1600(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS1600 = CDec(nuevoIEPS1600) + CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                        actuieps += CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "1.600000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var1600(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS1600 += FormatNumber(CDec(var1600(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.304"
                                    If var304(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS304 = CDec(nuevoIEPS304) + CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                        actuieps += CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.304000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var304(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS304 += FormatNumber(CDec(var304(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.25"
                                    If var25(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS25 = CDec(nuevoIEPS25) + CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                        actuieps += CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.250000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var25(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS25 += FormatNumber(CDec(var25(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.09"
                                    If var09(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS09 = CDec(nuevoIEPS09) + CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                        actuieps += CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.090000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var09(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS09 += FormatNumber(CDec(var09(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.08"
                                    If var08(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If

                                        nuevoIEPS8 = CDec(nuevoIEPS8) + CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                        actuieps += CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.080000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var08(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS8 += FormatNumber(CDec(var08(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.07"
                                    If var07(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS07 = CDec(nuevoIEPS07) + CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                        actuieps += CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.070000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var07(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS07 += FormatNumber(CDec(var07(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.06"
                                    If var06(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If

                                        'nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2) + 0.01))
                                        nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                        actuieps += CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                        '.WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2)) + 0.01, ",", ""))
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2)), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.060000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var06(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS06 += FormatNumber(CDec(var06(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    '"0.03"
                                    If var03(banderaArrays) > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        nuevoIEPS03 = CDec(nuevoIEPS03) + CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                        actuieps += CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.030000")
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(var03(banderaArrays)), 6), ",", ""))
                                        basenuevoIEPS03 += FormatNumber(CDec(var03(banderaArrays)), 6)
                                        .WriteEndElement() ' fin Traslado
                                    End If

                                    banderaArrays += 1
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos

                                Else
                                    .WriteStartElement("cfdi:Traslado")
                                    If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                        arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                        ieps_val = ieps_val + 1
                                    End If
                                    .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                    .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                    ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    .WriteAttributeString("Impuesto", "003")
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                            End If
                                        End If

                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos
                                End If

                                frmfacturacion.grid_prods.Rows(i).Cells(11).Value = actuieps

                            End If

                        Else
                            .WriteStartElement("cfdi:Traslado")
                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                ieps_val = ieps_val + 1
                            End If

                            nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6))

                            .WriteAttributeString("Importe", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6), ",", ""))
                            .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                            .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                            ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                            .WriteAttributeString("Impuesto", "003")
                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                If Banderaglobal = 1 Then
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                Else
                                    If frmfacturacion.txtNotaVenta.Text = "" Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                    End If
                                End If

                            Else

                                '.WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(21).Value.ToString, 6), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                            End If
                            .WriteEndElement() ' fin Traslado
                            .WriteEndElement() ' fin Traslados
                            .WriteEndElement() ' fin impuestos
                        End If

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 And frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString > 0 Then
                        'si tiene iva, isr
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) * CDec(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))

                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) * CDec(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)

                        .WriteEndElement() ' fin Traslado

                        .WriteEndElement() ' fin Traslados

                        .WriteStartElement("cfdi:Retenciones")

                        .WriteStartElement("cfdi:Retencion") 'inicia reten isr

                        retenidop = FormatNumber((frmfacturacion.grid_prods.Rows(i).Cells(10).Value.ToString) / CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString)), 6)
                        tretencionesp = retenidop

                        Dim baseparaisr As Double = FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) * CDec(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(baseparaisr) * CDec(frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString), 6), ",", ""))
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString, 6), ",", ""))
                        .WriteAttributeString("Impuesto", "001")
                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(baseparaisr) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                        '.WriteAttributeString("Base", Replace(FormatNumber(CDec(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString) * CDec(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))

                        .WriteEndElement() ' fin reten isr

                        .WriteEndElement() ' fin reten

                        .WriteEndElement() ' fin impuestos

                    ElseIf frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString > 0 Then
                        'si tiene iva
                        .WriteStartElement("cfdi:Impuestos")

                        .WriteStartElement("cfdi:Traslados")

                        .WriteStartElement("cfdi:Traslado")

                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                            If Banderaglobal = 1 Then

                                If frmfacturacion.txtNotaVenta.Text = "" Then
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                                Else
                                    .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                    valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                                End If

                            Else

                                If frmfacturacion.txtNotaVenta.Text <> "" Then

                                    If frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString = frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.00", 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString), 6)
                                    Else
                                        If frmfacturacion.Text_IVA.Text = FormatNumber(sumaiva, 2) Or banderacambio = 1 Then
                                            .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6)), ",", ""))
                                        Else
                                            If frmfacturacion.Text_IVA.Text > FormatNumber(sumaiva, 2) Then
                                                banderacambio = 1
                                                Dim cuenta As Decimal = 0
                                                cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) ' + 0.01
                                                cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                                cuenta = cuenta
                                                If cuenta > 0 Then
                                                    cuenta = cuenta
                                                Else
                                                    cuenta = Math.Abs(cuenta)
                                                End If
                                                If cuenta > 0.009 Then
                                                    banderacambio = 0
                                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                                Else
                                                    If cuenta > 0.003 Then
                                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) + 0.01, ",", ""))
                                                    Else
                                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)), ",", ""))
                                                    End If
                                                End If
                                            Else
                                                banderacambio = 1
                                                Dim cuenta As Decimal = 0
                                                cuenta = CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01
                                                cuenta = cuenta - CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6))
                                                cuenta = cuenta
                                                If cuenta > 0 Then
                                                    cuenta = cuenta
                                                Else
                                                    cuenta = Math.Abs(cuenta)
                                                End If
                                                If cuenta > 0.009 Then
                                                    banderacambio = 0
                                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 6), ",", ""))
                                                Else
                                                    .WriteAttributeString("Importe", Replace(CDec(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString * 0.16), 2)) - 0.01, ",", ""))
                                                End If

                                            End If
                                        End If
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6), ",", ""))

                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(19).Value.ToString), 6)

                                    End If
                                Else
                                    If frmfacturacion.txtNotaVenta.Text = "" Then
                                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                                    Else
                                        .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                        valorbaseivatotal = valorbaseivatotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                                    End If
                                End If

                            End If

                        Else
                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                            Else
                                .WriteAttributeString("Importe", Replace(FormatNumber((importeconceptoiva), 6), ",", ""))
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", Replace(FormatNumber(CDbl(tcuota), 6), ",", ""))
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                                valorbaseivatotal = valorbaseivatotal + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDbl(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                            End If
                        End If

                        .WriteEndElement() ' fin Traslado

                        .WriteEndElement() ' fin Traslados

                        .WriteEndElement() ' fin impuestos

                    Else
                        'si no tiene iva

                        If frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString > 0 Then
                            'si tiene ieps
                            .WriteStartElement("cfdi:Impuestos")

                            .WriteStartElement("cfdi:Traslados")

                            '.WriteStartElement("cfdi:Traslado")
                            '.WriteAttributeString("Importe", "0.00")
                            '.WriteAttributeString("TipoFactor", "Tasa")
                            '.WriteAttributeString("TasaOCuota", "0.000000")
                            '.WriteAttributeString("Impuesto", "002")
                            '.WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                            '.WriteEndElement() ' fin Traslado

                            If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                If Banderaglobal = 1 Then

                                    .WriteStartElement("cfdi:Traslado")
                                    If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                        arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                        ieps_val = ieps_val + 1
                                    End If

                                    Select Case frmfacturacion.grid_prods.Rows(i).Cells("Ieps_Porcentaje").Value
                                        Case "0.265000"
                                            nuevoIEPS265 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.300000"
                                            nuevoIEPS3 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.530000"
                                            nuevoIEPS53 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.500000"
                                            nuevoIEPS5 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "1.600000"
                                            nuevoIEPS1600 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.304000"
                                            nuevoIEPS304 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.250000"
                                            nuevoIEPS25 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.090000"
                                            nuevoIEPS09 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.080000"
                                            nuevoIEPS8 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.070000"
                                            nuevoIEPS07 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.060000"
                                            nuevoIEPS06 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                        Case "0.030000"
                                            nuevoIEPS03 += CDec(FormatNumber(Convert.ToDouble(frmfacturacion.grid_prods.Rows(i).Cells("Column7").Value), 6))
                                    End Select

                                    'nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2))

                                    .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2)), ",", ""))
                                    .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                    .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                    ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    .WriteAttributeString("Impuesto", "003")
                                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                        If Banderaglobal = 1 Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                                        Else
                                            If frmfacturacion.txtNotaVenta.Text = "" Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                            Else
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                            End If
                                        End If


                                    Else
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    End If
                                    .WriteEndElement() ' fin Traslado
                                    .WriteEndElement() ' fin Traslados
                                    .WriteEndElement() ' fin impuestos
                                Else
                                    If frmfacturacion.txtNotaVenta.Text <> "" Then
                                        '"0.265"
                                        If var265(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS265 = CDec(nuevoIEPS265) + CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                            actuieps += CDec(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var265(banderaArrays)) * 0.265, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.265000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var265(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS265 += FormatNumber(CDec(var265(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.30"
                                        If var3(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS3 = CDec(nuevoIEPS3) + CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                            actuieps += CDec(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var3(banderaArrays)) * 0.3, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.300000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var3(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS3 += FormatNumber(CDec(var3(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.53"
                                        If var53(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS53 = CDec(nuevoIEPS53) + CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                            actuieps += CDec(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var53(banderaArrays)) * 0.53, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.530000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var53(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS53 += FormatNumber(CDec(var53(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.50"
                                        If var5(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS5 = CDec(nuevoIEPS5) + CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                            actuieps += CDec(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var5(banderaArrays)) * 0.5, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.500000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var5(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS5 += FormatNumber(CDec(var5(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"1.60"
                                        If var1600(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS1600 = CDec(nuevoIEPS1600) + CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                            actuieps += CDec(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var1600(banderaArrays)) * 1.6, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "1.600000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var1600(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS1600 += FormatNumber(CDec(var1600(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.304"
                                        If var304(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS304 = CDec(nuevoIEPS304) + CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                            actuieps += CDec(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var304(banderaArrays)) * 0.304, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.304000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var304(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS304 += FormatNumber(CDec(var304(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.25"
                                        If var25(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS25 = CDec(nuevoIEPS25) + CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                            actuieps += CDec(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var25(banderaArrays)) * 0.25, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.250000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var25(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS25 += FormatNumber(CDec(var25(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.09"
                                        If var09(banderaArrays) > 0 Then
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS09 = CDec(nuevoIEPS09) + CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                            actuieps += CDec(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2))
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var09(banderaArrays)) * 0.09, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.090000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var09(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS09 += FormatNumber(CDec(var09(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.08"
                                        If var08(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS8 = CDec(nuevoIEPS8) + CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                            actuieps += CDec(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var08(banderaArrays)) * 0.08, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.080000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var08(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS8 += FormatNumber(CDec(var08(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.07"
                                        If var07(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS07 = CDec(nuevoIEPS07) + CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                            actuieps += CDec(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var07(banderaArrays)) * 0.07, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.070000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var07(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS07 += FormatNumber(CDec(var07(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.06"
                                        If var06(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS06 = CDec(nuevoIEPS06) + CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                            actuieps += CDec(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var06(banderaArrays)) * 0.06, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.060000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var06(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS06 += FormatNumber(CDec(var06(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        '"0.03"
                                        If var03(banderaArrays) > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                                arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                                arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                                ieps_val = ieps_val + 1
                                            End If
                                            nuevoIEPS03 = CDec(nuevoIEPS03) + CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                            actuieps += CDec(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2))
                                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(var03(banderaArrays)) * 0.03, 2), ",", ""))
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.030000")
                                            .WriteAttributeString("Impuesto", "003")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(var03(banderaArrays)), 6), ",", ""))
                                            basenuevoIEPS03 += FormatNumber(CDec(var03(banderaArrays)), 6)
                                            .WriteEndElement() ' fin Traslado
                                        End If

                                        banderaArrays += 1
                                        .WriteEndElement() ' fin Traslados
                                        .WriteEndElement() ' fin impuestos

                                        frmfacturacion.grid_prods.Rows(i).Cells(11).Value = actuieps

                                    Else

                                        .WriteStartElement("cfdi:Traslado")
                                        If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                            arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                            arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                            ieps_val = ieps_val + 1
                                        End If
                                        'MsgBox(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString)
                                        .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 2)), ",", ""))
                                        .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                        .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                        ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                        .WriteAttributeString("Impuesto", "003")
                                        If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                                            If Banderaglobal = 1 Then
                                                .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                                            Else
                                                If frmfacturacion.txtNotaVenta.Text = "" Then
                                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                                Else
                                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                                End If
                                            End If
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        End If
                                        .WriteEndElement() ' fin Traslado
                                        .WriteEndElement() ' fin Traslados
                                        .WriteEndElement() ' fin impuestos

                                    End If
                                End If
                            Else
                                .WriteStartElement("cfdi:Traslado")
                                If ieps_porcentaje <> FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6) Then
                                    arreg(ieps_val) = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                    arreg2(ieps_val) = frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString
                                    ieps_val = ieps_val + 1
                                End If

                                nuevoIEPS_SinIVA += CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6))

                                .WriteAttributeString("Importe", Replace(CDec(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(11).Value.ToString, 6)), ",", ""))
                                .WriteAttributeString("TipoFactor", frmfacturacion.grid_prods.Rows(i).Cells(17).Value.ToString)
                                .WriteAttributeString("TasaOCuota", FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6))
                                ieps_porcentaje = FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(16).Value.ToString), 6)
                                .WriteAttributeString("Impuesto", "003")
                                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then
                                    If Banderaglobal = 1 Then
                                        .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                    Else
                                        If frmfacturacion.txtNotaVenta.Text = "" Then
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))
                                        Else
                                            .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(20).Value.ToString, 6), ",", ""))
                                        End If
                                    End If
                                Else

                                    '.WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(21).Value.ToString, 6), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6), ",", ""))

                                End If
                                .WriteEndElement() ' fin Traslado
                                .WriteEndElement() ' fin Traslados
                                .WriteEndElement() ' fin impuestos

                            End If

                        ElseIf frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString > 0 Then

                            'si tiene isr
                            .WriteStartElement("cfdi:Impuestos")

                            .WriteStartElement("cfdi:Retenciones")

                            .WriteStartElement("cfdi:Retencion") 'inicia reten isr

                            Dim baseparaisr1 As Double = FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)
                            .WriteAttributeString("Importe", Replace(FormatNumber(CDec(baseparaisr1) * frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString, 6), ",", ""))
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", Replace(FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(15).Value.ToString, 6), ",", ""))
                            .WriteAttributeString("Impuesto", "001")
                            .WriteAttributeString("Base", Replace(baseparaisr1, ",", ""))

                            'valorbaseisrtotal = valorbaseisrtotal + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)

                            .WriteEndElement() ' fin reten isr

                            .WriteEndElement() ' fin reten

                            .WriteEndElement() ' fin impuestos

                        Else
                            'si no tiene nada (IVA = 0)

                            .WriteStartElement("cfdi:Impuestos")
                            .WriteStartElement("cfdi:Traslados")
                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Importe", "0.00")
                            .WriteAttributeString("TipoFactor", "Tasa")
                            .WriteAttributeString("TasaOCuota", "0.000000")
                            .WriteAttributeString("Impuesto", "002")
                            .WriteAttributeString("Base", Replace(FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6), ",", ""))
                            valorbaseivacero = valorbaseivacero + FormatNumber(CDec(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString)) - CDec(frmfacturacion.grid_prods.Rows(i).Cells(9).Value.ToString), 6)
                            .WriteEndElement() ' fin Traslado
                            .WriteEndElement() ' fin Traslados
                            .WriteEndElement() ' fin impuestos

                            'valorbaseivacero = valorbaseivacero + FormatNumber(frmfacturacion.grid_prods.Rows(i).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(i).Cells(3).Value.ToString), 6)

                        End If
                    End If

                    '=========================== terminan impuestos de los productos

                    .WriteEndElement() ' fin concepto

                Next

            End If

            .WriteEndElement()

            actuieps = CDec(FormatNumber(nuevoIEPS265, 2)) + CDec(FormatNumber(nuevoIEPS3, 2)) + CDec(FormatNumber(nuevoIEPS53, 2)) + CDec(FormatNumber(nuevoIEPS5, 2)) + CDec(FormatNumber(nuevoIEPS1600, 2)) + CDec(FormatNumber(nuevoIEPS304, 2)) + CDec(FormatNumber(nuevoIEPS25, 2)) + CDec(FormatNumber(nuevoIEPS09, 2)) + CDec(FormatNumber(nuevoIEPS8, 2)) + CDec(FormatNumber(nuevoIEPS07, 2)) + CDec(FormatNumber(nuevoIEPS06, 2)) + CDec(FormatNumber(nuevoIEPS03, 2)) + nuevoIEPS_SinIVA + nuevoIEPS_ConIVA


            'actuieps = nuevoIEPS265 + nuevoIEPS3 + nuevoIEPS53 + nuevoIEPS5 + nuevoIEPS1600 + nuevoIEPS304 + nuevoIEPS25 + nuevoIEPS09 + nuevoIEPS8 + nuevoIEPS07 + nuevoIEPS06 + nuevoIEPS03 + nuevoIEPS_SinIVA + nuevoIEPS_ConIVA

            '===================================== INICIA IMPUESTOS

            If frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.Text_IVARET.Text > 0 And frmfacturacion.txt_impuestos.Text > 0 Then
                'si tiene iva , iva retenido, ieps
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.Text_IVARET.Text, ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2) + CDec(frmfacturacion.txt_impuestos.Text), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVARET.Text), 2), ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))

                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            If valorbaseivacero > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                            End If
                            Exit For
                        End If
                    Next
                End If

                Dim varsum As Double = 0
                Dim varieps As String = ""
                Dim varsumbase As Double = 0
                Dim variepspasados(20) As String
                For iz = 0 To 19
                    variepspasados(iz) = ""
                Next


                For i = 0 To ieps_val - 1

                    Dim variepssi As Integer = 0

                    For iz = 0 To 19
                        If variepspasados(iz) = arreg(i) Then
                            variepssi = 1
                            Exit For
                        End If
                    Next

                    If variepssi = 0 Then
                        variepspasados(i) = arreg(i)
                    End If

                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                            varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                            ieps_porcentaje = varieps
                            varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                        End If
                    Next

                    If variepssi = 0 Then
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                        .WriteAttributeString("Impuesto", "003")
                        .WriteAttributeString("TipoFactor", arreg2(i))
                        .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                        .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                        .WriteEndElement()
                    End If

                    varsum = 0
                    varieps = ""
                    varsumbase = 0

                Next

                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.Text_IVARET.Text > 0 And frmfacturacion.txtISR.Text > 0 Then
                'si tiene iva, iva retenido, isr
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(FormatNumber(CDec(frmfacturacion.Text_IVARET.Text) + CDec(frmfacturacion.txtISR.Text), 2), ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVARET.Text), 2), ",", ""))

                .WriteEndElement()

                .WriteStartElement("cfdi:Retencion")
                .WriteAttributeString("Impuesto", "001")
                .WriteAttributeString("Importe", Replace(frmfacturacion.txtISR.Text, ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            If valorbaseivacero > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                            End If
                            Exit For
                        End If
                    Next
                End If

                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.Text_IVARET.Text > 0 Then
                'si tiene iva, iva retenido
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.Text_IVARET.Text, ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVARET.Text), 2), ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            If valorbaseivacero > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                            End If
                            Exit For
                        End If
                    Next
                End If

                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.txt_impuestos.Text > 0 Then
                'si tiene iva, ieps
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVA.Text) + CDec(actuieps), 2), ",", ""))
                '.WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(frmfacturacion.Text_IVA.Text) + CDec(frmfacturacion.txt_impuestos.Text), 2), ",", ""))
                .WriteStartElement("cfdi:Traslados")

                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteEndElement()

                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                    If Banderaglobal = 1 Then
                        If frmfacturacion.grid_prods.RowCount > 1 Then
                            For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                If CDec(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) = 0 Then
                                    If valorbaseivacero > 0 Then
                                        .WriteStartElement("cfdi:Traslado")
                                        .WriteAttributeString("Impuesto", "002")
                                        .WriteAttributeString("TipoFactor", "Tasa")
                                        .WriteAttributeString("TasaOCuota", "0.000000")
                                        .WriteAttributeString("Importe", "0.00")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                        .WriteEndElement()
                                    End If
                                    Exit For
                                End If
                            Next
                        End If

                        Dim varsum As Double = 0
                        Dim varieps As String = ""
                        Dim varsumbase As Double = 0
                        Dim variepspasados(20) As String
                        For iz = 0 To 19
                            variepspasados(iz) = ""
                        Next

                        For i = 0 To ieps_val - 1

                            Dim variepssi As Integer = 0

                            For iz = 0 To 19
                                If variepspasados(iz) = arreg(i) Then
                                    variepssi = 1
                                    Exit For
                                End If
                            Next

                            If variepssi = 0 Then
                                variepspasados(i) = arreg(i)
                            End If

                            For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                    varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                    ieps_porcentaje = varieps
                                    varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                                End If
                            Next

                            If variepssi = 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", arreg2(i))
                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            varsum = 0
                            varieps = ""
                            varsumbase = 0
                        Next
                    Else

                        If frmfacturacion.txtNotaVenta.Text <> "" Then

                            Dim varsum10 As Double = 0
                            Dim varieps10 As String = ""
                            Dim varieps210 As String = ""
                            Dim varieps310 As String = ""
                            Dim varieps410 As String = ""
                            Dim varieps5r10 As String = ""



                            'If ieps_val > 1 Then

                            '"0.265"
                            If nuevoIEPS265 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.265000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS265, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS265), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.30"
                            If nuevoIEPS3 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.300000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS3, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS3), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.53"
                            If nuevoIEPS53 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.530000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS53, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS53), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.50"
                            If nuevoIEPS5 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.500000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS5, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS5), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"1.60"
                            If nuevoIEPS1600 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "1.600000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS1600, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS1600), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.304"
                            If nuevoIEPS304 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.304000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS304, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS304), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.25"
                            If nuevoIEPS25 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.250000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS25, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS25), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.09"
                            If nuevoIEPS09 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.090000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS09, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS09), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.08"
                            If nuevoIEPS8 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.080000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS8, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS8), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.07"
                            If nuevoIEPS07 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.070000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS07, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS07), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.06"
                            If nuevoIEPS06 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.060000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS06, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS06), 2), ",", ""))
                                '.WriteAttributeString("Importe", Replace(FormatNumber(3.94, 2), ",", ""))
                                .WriteEndElement()
                            End If

                            '"0.03"
                            If nuevoIEPS03 > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.030000")
                                .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS03, 2), ",", ""))
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS03), 2), ",", ""))
                                .WriteEndElement()
                            End If

                            'Else

                            '                            For i = 0 To ieps_val - 1
                            '                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                            '                                    If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                            '                                        varsum10 = varsum10 + CDec(FormatNumber(var265(i) * arreg(i), 6))
                            '                                        varsum10 = varsum10 + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                            '                                        ieps_porcentaje = varieps10
                            '                                    End If
                            '                                Next
                            '                                If varieps210 = arreg(i) Then
                            '                                    varsum10 = 0
                            '                                    varieps10 = ""
                            '                                    GoTo puertaXD10
                            '                                    'Exit For
                            '                                End If
                            '                                If varieps310 = arreg(i) Then
                            '                                    varsum10 = 0
                            '                                    varieps10 = ""
                            '                                    GoTo puertaXD10
                            '                                    'Exit For
                            '                                End If
                            '                                .WriteStartElement("cfdi:Traslado")
                            '                                .WriteAttributeString("Impuesto", "003")
                            '                                .WriteAttributeString("TipoFactor", arreg2(i))
                            '                                If varieps210 = "" Then
                            '                                    varieps210 = arreg(i)
                            '                                End If
                            '                                If varieps310 = "" And varieps210 <> "" And varieps210 <> arreg(i) Then
                            '                                    varieps310 = arreg(i)
                            '                                End If
                            '                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                            '                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum10, 2), ",", ""))
                            '                                .WriteEndElement()
                            '                                varsum10 = 0
                            '                                varieps10 = ""
                            'puertaXD10:
                            '                            Next

                            'End If

                            If frmfacturacion.grid_prods.RowCount > 1 Then
                                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                                        If valorbaseivacero > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.000000")
                                            .WriteAttributeString("Importe", "0.00")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                            .WriteEndElement()
                                        End If
                                        Exit For
                                    End If
                                Next
                            End If

                        Else

                            If frmfacturacion.grid_prods.RowCount > 1 Then
                                For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                                        If valorbaseivacero > 0 Then
                                            .WriteStartElement("cfdi:Traslado")
                                            .WriteAttributeString("Impuesto", "002")
                                            .WriteAttributeString("TipoFactor", "Tasa")
                                            .WriteAttributeString("TasaOCuota", "0.000000")
                                            .WriteAttributeString("Importe", "0.00")
                                            .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                            .WriteEndElement()
                                        End If
                                        Exit For
                                    End If
                                Next
                            End If

                            Dim varsum As Double = 0
                            Dim varieps As String = ""
                            Dim varsumbase As Double = 0
                            Dim variepspasados(20) As String
                            For iz = 0 To 19
                                variepspasados(iz) = ""
                            Next
                            For i = 0 To ieps_val - 1

                                Dim variepssi As Integer = 0

                                For iz = 0 To 19
                                    If variepspasados(iz) = arreg(i) Then
                                        variepssi = 1
                                        Exit For
                                    End If
                                Next

                                If variepssi = 0 Then
                                    variepspasados(i) = arreg(i)
                                End If

                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                        varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                        ieps_porcentaje = varieps
                                        varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                                    End If
                                Next

                                If variepssi = 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", arreg2(i))
                                    .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                    .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                varsum = 0
                                varieps = ""
                                varsumbase = 0
                            Next
                        End If
                    End If

                Else
                    If frmfacturacion.grid_prods.RowCount > 1 Then
                        For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                            If CDec(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) = 0 Then
                                If valorbaseivacero > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.000000")
                                    .WriteAttributeString("Importe", "0.00")
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                    .WriteEndElement()
                                End If
                                Exit For
                            End If
                        Next
                    End If

                    Dim varsum As Double = 0
                    Dim varieps As String = ""
                    Dim varsumbase As Double = 0

                    Dim variepspasados(20) As String
                    For iz = 0 To 19
                        variepspasados(iz) = ""
                    Next

                    For i = 0 To ieps_val - 1

                        Dim variepssi As Integer = 0

                        For iz = 0 To 19
                            If variepspasados(iz) = arreg(i) Then
                                variepssi = 1
                                Exit For
                            End If
                        Next

                        If variepssi = 0 Then
                            variepspasados(i) = arreg(i)
                        End If

                        For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                            If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                ieps_porcentaje = varieps
                                varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                            End If
                        Next

                        If variepssi = 0 Then

                            .WriteStartElement("cfdi:Traslado")
                            .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                            .WriteAttributeString("Impuesto", "003")
                            .WriteAttributeString("TipoFactor", arreg2(i))
                            .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                            .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                            .WriteEndElement()

                        End If


                        varsum = 0
                        varieps = ""
                        varsumbase = 0
                    Next
                End If
                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 And frmfacturacion.txtISR.Text > 0 Then
                'si tiene iva, isr
                .WriteStartElement("cfdi:Impuestos")
                .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.txtISR.Text, ",", ""))
                .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))

                .WriteStartElement("cfdi:Retenciones")
                .WriteStartElement("cfdi:Retencion")

                .WriteAttributeString("Impuesto", "001")
                .WriteAttributeString("Importe", Replace(frmfacturacion.txtISR.Text, ",", ""))

                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("cfdi:Traslados")
                .WriteStartElement("cfdi:Traslado")
                .WriteAttributeString("Impuesto", "002")
                .WriteAttributeString("TipoFactor", "Tasa")
                .WriteAttributeString("TasaOCuota", "0.160000")
                .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then
                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If CDec(frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString) = 0 Then
                            If valorbaseivacero > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                            End If
                            Exit For
                        End If
                    Next
                End If

                .WriteEndElement()

            ElseIf frmfacturacion.Text_IVA.Text > 0 Then
                'si tiene iva
                .WriteStartElement("cfdi:Impuestos")
                If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                    If Banderaglobal = 1 Then
                        .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                        .WriteStartElement("cfdi:Traslados")
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                        .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))

                    Else
                        .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaImpFactGlobal), 2), ",", ""))
                        .WriteStartElement("cfdi:Traslados")
                        .WriteStartElement("cfdi:Traslado")
                        .WriteAttributeString("Impuesto", "002")
                        .WriteAttributeString("TipoFactor", "Tasa")
                        .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                        .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaImpFactGlobal), 2), ",", ""))
                        .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                    End If


                Else
                    .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                    .WriteStartElement("cfdi:Traslados")
                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "002")
                    .WriteAttributeString("TipoFactor", "Tasa")
                    .WriteAttributeString("TasaOCuota", Replace(FormatNumber("0.16", 6), ",", ""))
                    .WriteAttributeString("Importe", Replace(FormatNumber(CDbl(sumaimpuestosconcep), 2), ",", ""))
                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivatotal), 2), ",", ""))
                End If

                .WriteEndElement()

                If frmfacturacion.grid_prods.RowCount > 1 Then

                    For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                        If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                            If valorbaseivacero > 0 Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                            End If
                            Exit For
                        Else
                            If frmfacturacion.grid_prods.Rows(i).Cells(5).Value.ToString = frmfacturacion.grid_prods.Rows(i).Cells(7).Value.ToString Then
                                If valorbaseivacero > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "002")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.000000")
                                    .WriteAttributeString("Importe", "0.00")
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                    .WriteEndElement()
                                End If
                                Exit For
                            End If
                        End If
                    Next

                End If

                .WriteEndElement()

            Else
                'si no tiene iva
                If frmfacturacion.txt_impuestos.Text > 0 Then
                    'si tiene ieps
                    .WriteStartElement("cfdi:Impuestos")
                    '.WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDec(frmfacturacion.txt_impuestos.Text), 2), ",", ""))
                    .WriteAttributeString("TotalImpuestosTrasladados", Replace(FormatNumber(CDec(actuieps), 2), ",", ""))
                    .WriteStartElement("cfdi:Traslados")

                    Dim varsum As Double = 0
                    Dim varieps As String = ""
                    Dim varieps2 As String = ""
                    Dim varieps3 As String = ""
                    Dim varieps4 As String = ""
                    Dim varieps5r As String = ""

                    If frmfacturacion.grid_prods.RowCount > 1 Then
                        For i = 0 To frmfacturacion.grid_prods.RowCount - 1
                            If frmfacturacion.grid_prods.Rows(i).Cells(8).Value.ToString = "0" Then
                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Impuesto", "002")
                                .WriteAttributeString("TipoFactor", "Tasa")
                                .WriteAttributeString("TasaOCuota", "0.000000")
                                .WriteAttributeString("Importe", "0.00")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))
                                .WriteEndElement()
                                Exit For
                            End If
                        Next
                    End If

                    If frmfacturacion.Cmb_RFC.Text = "XAXX010101000" Then

                        If Banderaglobal = 1 Then

                            Dim varsumbase As Double = 0

                            Dim variepspasados(20) As String
                            For iz = 0 To 19
                                variepspasados(iz) = ""
                            Next

                            For i = 0 To ieps_val - 1

                                Dim variepssi As Integer = 0
                                For iz = 0 To 19
                                    If variepspasados(iz) = arreg(i) Then
                                        variepssi = 1
                                        Exit For
                                    End If
                                Next

                                If variepssi = 0 Then
                                    variepspasados(i) = arreg(i)
                                End If

                                For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                    If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                        varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                        ieps_porcentaje = varieps
                                        varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                                    End If
                                Next

                                If variepssi = 0 Then

                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", arreg2(i))
                                    .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                    .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                    .WriteEndElement()

                                    'If varieps2 = "" Then
                                    '    varieps2 = arreg(i)
                                    'End If
                                    'If varieps3 = "" And varieps2 <> "" And varieps2 <> arreg(i) Then
                                    '    varieps3 = arreg(i)
                                    'End If

                                End If

                                'If varieps2 = arreg(i) Then
                                '    varsum = 0
                                '    varieps = ""
                                '    varsumbase = 0
                                '    GoTo puertaXD4
                                '    'Exit For
                                'End If
                                'If varieps3 = arreg(i) Then
                                '    varsum = 0
                                '    varieps = ""
                                '    varsumbase = 0
                                '    GoTo puertaXD4
                                '    'Exit For
                                'End If

                                varsum = 0
                                varieps = ""
                                varsumbase = 0
puertaXD4:
                            Next

                        Else
                            If frmfacturacion.txtNotaVenta.Text <> "" Then
                                '"0.265"
                                If nuevoIEPS265 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.265000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS265), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS265), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.30"
                                If nuevoIEPS3 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.300000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS3), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS3), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.53"
                                If nuevoIEPS53 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.530000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS53), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS53), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.50"
                                If nuevoIEPS5 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.500000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS5), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS5), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"1.60"
                                If nuevoIEPS1600 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "1.600000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS1600), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS1600), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.304"
                                If nuevoIEPS304 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.304000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS304), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS304), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.25"
                                If nuevoIEPS25 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.250000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS25), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS25), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.09"
                                If nuevoIEPS09 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.090000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS09), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS09), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.08"
                                If nuevoIEPS8 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.080000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(nuevoIEPS8, 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS8), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.07"
                                If nuevoIEPS07 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.070000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS07), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS07), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.06"
                                If nuevoIEPS06 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.060000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS06), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS06), 2), ",", ""))
                                    .WriteEndElement()
                                End If

                                '"0.03"
                                If nuevoIEPS03 > 0 Then
                                    .WriteStartElement("cfdi:Traslado")
                                    .WriteAttributeString("Impuesto", "003")
                                    .WriteAttributeString("TipoFactor", "Tasa")
                                    .WriteAttributeString("TasaOCuota", "0.030000")
                                    .WriteAttributeString("Importe", Replace(FormatNumber(CDec(nuevoIEPS03), 2), ",", ""))
                                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(basenuevoIEPS03), 2), ",", ""))
                                    .WriteEndElement()
                                End If
                            Else

                                Dim varsumbase As Double = 0
                                Dim variepspasados(20) As String
                                For iz = 0 To 19
                                    variepspasados(iz) = ""
                                Next

                                For i = 0 To ieps_val - 1

                                    Dim variepssi As Integer = 0

                                    For iz = 0 To 19
                                        If variepspasados(iz) = arreg(i) Then
                                            variepssi = 1
                                            Exit For
                                        End If
                                    Next

                                    If variepssi = 0 Then
                                        variepspasados(i) = arreg(i)
                                    End If

                                    For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                        If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                            varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                            ieps_porcentaje = varieps
                                            varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                                        End If
                                    Next

                                    If variepssi = 0 Then

                                        .WriteStartElement("cfdi:Traslado")
                                        .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                                        .WriteAttributeString("Impuesto", "003")
                                        .WriteAttributeString("TipoFactor", arreg2(i))
                                        .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                        .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                        .WriteEndElement()

                                    End If

                                    varsum = 0
                                    varieps = ""
                                    varsumbase = 0
puertaXD:
                                Next

                            End If

                        End If


                    Else

                        Dim varsumbase As Double = 0
                        Dim variepspasados(20) As String
                        For iz = 0 To 19
                            variepspasados(iz) = ""
                        Next

                        For i = 0 To ieps_val - 1
                            Dim variepssi As Integer = 0

                            For iz = 0 To 19
                                If variepspasados(iz) = arreg(i) Then
                                    variepssi = 1
                                    Exit For
                                End If
                            Next

                            If variepssi = 0 Then
                                variepspasados(i) = arreg(i)
                            End If

                            For iii = 0 To frmfacturacion.grid_prods.RowCount - 1
                                If CDec(frmfacturacion.grid_prods.Rows(iii).Cells(16).Value.ToString) = CDec(arreg(i)) Then
                                    varsum = varsum + CDec(frmfacturacion.grid_prods.Rows(iii).Cells(11).Value.ToString)
                                    ieps_porcentaje = varieps
                                    varsumbase = varsumbase + FormatNumber(frmfacturacion.grid_prods.Rows(iii).Cells(4).Value.ToString * CDbl(frmfacturacion.grid_prods.Rows(iii).Cells(3).Value.ToString), 6)
                                End If
                            Next

                            If variepssi = 0 Then

                                .WriteStartElement("cfdi:Traslado")
                                .WriteAttributeString("Base", Replace(FormatNumber(CDbl(varsumbase), 2), ",", ""))
                                .WriteAttributeString("Impuesto", "003")
                                .WriteAttributeString("TipoFactor", arreg2(i))
                                .WriteAttributeString("TasaOCuota", FormatNumber(arreg(i), 6))
                                .WriteAttributeString("Importe", Replace(FormatNumber(varsum, 2), ",", ""))
                                .WriteEndElement()

                            End If

                            varsum = 0
                            varieps = ""
                            varsumbase = 0
puertaXD1:
                        Next
                    End If
                    .WriteEndElement()

                ElseIf frmfacturacion.txtISR.Text > 0 Then
                    'si tiene isr
                    .WriteStartElement("cfdi:Impuestos")
                    .WriteAttributeString("TotalImpuestosRetenidos", Replace(frmfacturacion.txtISR.Text, ",", ""))
                    '.WriteAttributeString("TotalImpuestosTrasladados", "0.00")

                    .WriteStartElement("cfdi:Retenciones")
                    .WriteStartElement("cfdi:Retencion")
                    .WriteAttributeString("Impuesto", "001")
                    .WriteAttributeString("Importe", Replace(frmfacturacion.txtISR.Text, ",", ""))

                    .WriteEndElement()
                    .WriteEndElement()

                Else
                    'sin iva
                    .WriteStartElement("cfdi:Impuestos")
                    .WriteAttributeString("TotalImpuestosTrasladados", "0.00")

                    .WriteStartElement("cfdi:Traslados")
                    .WriteStartElement("cfdi:Traslado")
                    .WriteAttributeString("Impuesto", "002")
                    .WriteAttributeString("TipoFactor", "Tasa")
                    .WriteAttributeString("TasaOCuota", "0.000000")
                    .WriteAttributeString("Importe", "0.00")
                    .WriteAttributeString("Base", Replace(FormatNumber(CDbl(valorbaseivacero), 2), ",", ""))

                    .WriteEndElement()
                    .WriteEndElement()
                End If

            End If

            .WriteEndElement()

            'inicia carta porte

            If frmfacturacion.CheckBox2.Checked = True Then

                '=========================== COMIENZA complemento

                .WriteStartElement("cfdi:Complemento")


                '=========================== COMIENZA carta

                .WriteStartElement("cartaporte20:CartaPorte")
                .WriteAttributeString("Version", "2.0")

                If frmfacturacion.chkInter.Checked = True Then
                    .WriteAttributeString("ViaEntradaSalida", "01")
                    'en este campo si en Trasporte internacional es Si se debe poner los campos EntradaSalidaMerc y ViaEntradaSalida
                    'en este campo si en Trasporte internacional es No los campos EntradaSalidaMerc y ViaEntradaSalida no deben de estar
                    'agregar una validacion aqui
                    .WriteAttributeString("TranspInternac", "Sí") '.WriteAttributeString("TranspInternac", "Sí")
                    'agregar una validacion aqui
                    .WriteAttributeString("EntradaSalidaMerc", "Salida")
                    'total de distancia tiene que ser igual a la suma del campo DistanciaRecorrida de las ubicaciones que se registren en kilometros
                    'Si existe la sección AutotransporteFederal o TransporteFerroviario de
                    'la sección Mercancias, este campo debe contener un valor; en caso de
                    'que no exista alguna de las secciones antes mencionadas, este campo
                    'no debe existir.
                    .WriteAttributeString("TotalDistRec", frmfacturacion.txtDestinioDist.Text)

                    If dameclavePais() <> "" Then
                        .WriteAttributeString("PaisOrigenDestino", dameclavePais)
                    End If

                Else
                    .WriteAttributeString("TranspInternac", "No")
                    .WriteAttributeString("TotalDistRec", frmfacturacion.txtDestinioDist.Text)
                End If

                '.WriteStartAttribute("xmlns:cartaporte")
                '.WriteValue("http://www.sat.gob.mx/CartaPorte")
                '.WriteEndAttribute()

                '=========================== COMIENZA ubicaciones
                'esta parte hay que hacerla con un ciclo porque se pueden poner varias

                .WriteStartElement("cartaporte20:Ubicaciones")

                .WriteStartElement("cartaporte20:Ubicacion")
                '.WriteAttributeString("DistanciaRecorrida", "1")
                '.WriteAttributeString("TipoEstacion", "01")

                .WriteAttributeString("TipoUbicacion", "Origen")

                If Trim(frmfacturacion.cboOrigRemitente.Text) <> "" Then
                    .WriteAttributeString("NombreRemitenteDestinatario", Trim(frmfacturacion.cboOrigRemitente.Text))
                End If
                .WriteAttributeString("RFCRemitenteDestinatario", Trim(Trim(frmfacturacion.txtOrigRFC.Text)))

                Dim varOrigFechaHora As String = ""
                varOrigFechaHora = Format(CDate(frmfacturacion.dtpOrigFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpOrigHora.Value), "HH:mm:ss")

                .WriteAttributeString("FechaHoraSalidaLlegada", varOrigFechaHora)

                'If dgdist.RowCount > 1 Then
                '    .WriteAttributeString("IDOrigen", Trim(varIdOrigen))
                'End If

                .WriteStartElement("cartaporte20:Domicilio")
                If Trim(frmfacturacion.txtOrigNumExt.Text) <> "" Then
                    .WriteAttributeString("NumeroExterior", Trim(frmfacturacion.txtOrigNumExt.Text))
                End If
                If Trim(frmfacturacion.txtOrigNumInt.Text) <> "" Then
                    .WriteAttributeString("NumeroInterior", Trim(frmfacturacion.txtOrigNumInt.Text))
                End If
                If Trim(frmfacturacion.cboOrigMun.Text) <> "" Then
                    .WriteAttributeString("Municipio", Trim(dameclaveMun))
                End If
                'If Trim(varOrigLoc) <> "" Then
                '    .WriteAttributeString("Localidad", Trim(varOrigLoc))
                'End If
                If Trim(frmfacturacion.cboOrigColonia.Text) <> "" Then
                    .WriteAttributeString("Colonia", Trim(dameclaveColonia))
                End If
                .WriteAttributeString("Pais", "MEX")
                .WriteAttributeString("Estado", Trim(dameclaveEdo))
                .WriteAttributeString("CodigoPostal", Trim(frmfacturacion.txtOrigCP.Text))
                .WriteAttributeString("Calle", Trim(frmfacturacion.txtOrigCalle.Text))
                .WriteEndElement() ' fin domicilio

                .WriteEndElement() ' fin UBICACION 1

                .WriteStartElement("cartaporte20:Ubicacion")
                .WriteAttributeString("DistanciaRecorrida", frmfacturacion.txtDestinioDist.Text)
                'Si el campo TranspInternac contiene el valor “No” y si existe la sección
                'TransporteFerroviario, TransporteMaritimo o TransporteAereo de la
                'sección Mercancias, este campo se debe registrar y debe contener una
                'clave del catálogo del complemento Carta Porte c_TipoEstacion,
                'publicado en el portan del SAT

                'En otro caso, si el campo TranspInternac contiene el valor “Sí” este
                'campo no debe registrarse siempre que el Origen o Destino de los
                'bienes o mercancías sea fuera de territorio nacional, por lo que el
                'campo Pais de la sección Ubicacion debe contener una clave distinta
                'de “MEX”, en caso contrario se debe registrar una clave del catálogo del
                'complemento Carta Porte c_TipoEstacion, publicado en el portal del
                'SAT.

                'If frmfacturacion.chkInter.Checked = False Then
                '    .WriteAttributeString("TipoEstacion", "01")
                'End If

                .WriteAttributeString("TipoUbicacion", "Destino")

                If Trim(frmfacturacion.cboDesDestinatario.Text) <> "" Then
                    .WriteAttributeString("NombreRemitenteDestinatario", Trim(frmfacturacion.cboDesDestinatario.Text))
                End If

                .WriteAttributeString("RFCRemitenteDestinatario", Trim(frmfacturacion.txtDesRFC.Text))
                Dim varDesFechaHora As String = ""
                varDesFechaHora = Format(CDate(frmfacturacion.dtpDesFecha.Value), "yyyy-MM-dd") & "T" & Format(CDate(frmfacturacion.dtpDesHora.Value), "HH:mm:ss")
                .WriteAttributeString("FechaHoraSalidaLlegada", varDesFechaHora)

                'If dgdist.RowCount > 1 Then
                '    .WriteAttributeString("IDDestino", dgdist.Rows(i).Cells(1).Value.ToString)
                'End If

                .WriteStartElement("cartaporte20:Domicilio")
                If Trim(frmfacturacion.txtDestinoNumE.Text) <> "" Then
                    .WriteAttributeString("NumeroExterior", Trim(frmfacturacion.txtDestinoNumE.Text))
                End If
                If Trim(frmfacturacion.txtDestinoNumI.Text) <> "" Then
                    .WriteAttributeString("NumeroInterior", Trim(frmfacturacion.txtDestinoNumI.Text))
                End If
                If Trim(frmfacturacion.cboDestinoMun.Text) <> "" Then
                    .WriteAttributeString("Municipio", Trim(dameclaveMunD))
                End If
                If Trim(frmfacturacion.cboDestinoColonia.Text) <> "" Then
                    .WriteAttributeString("Colonia", Trim(dameclaveColoniaD))
                End If
                If frmfacturacion.chkInter.Checked = True Then
                    .WriteAttributeString("Localidad", Trim(frmfacturacion.txtDestinoLoc.Text))
                End If
                .WriteAttributeString("Pais", dameclavePais)
                .WriteAttributeString("Estado", dameclaveEdoD)
                .WriteAttributeString("CodigoPostal", frmfacturacion.txtDestinoCP.Text)
                .WriteAttributeString("Calle", frmfacturacion.txtDestinoCalle.Text)
                '.WriteAttributeString("Referencia", "casa blanca")
                .WriteEndElement() ' fin domicilio

                .WriteEndElement() ' fin UBICACION 2

                .WriteEndElement() ' fin UBICACIONES

                '=========================== COMIENZA Mercancias
                .WriteStartElement("cartaporte20:Mercancias")
                Dim pesobruto As Double = 0
                For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                    pesobruto = pesobruto + CDec(frmfacturacion.dgProductos.Rows(i).Cells(5).Value.ToString)
                Next

                Dim unidadpeso As String = ""
                For i = 0 To frmfacturacion.dgProductos.RowCount - 1
                    unidadpeso = frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString
                    Exit For
                Next

                .WriteAttributeString("PesoBrutoTotal", pesobruto)
                .WriteAttributeString("UnidadPeso", unidadpeso)
                .WriteAttributeString("NumTotalMercancias", frmfacturacion.dgProductos.RowCount)

                Dim BanderaMetPel As String = ""

                For i = 0 To frmfacturacion.dgProductos.RowCount - 1

                    .WriteStartElement("cartaporte20:Mercancia")
                    .WriteAttributeString("ValorMercancia", frmfacturacion.dgProductos.Rows(i).Cells(4).Value.ToString)

                    If frmfacturacion.chkInter.Checked = True Then
                        .WriteAttributeString("UUIDComercioExt", frmfacturacion.dgProductos.Rows(i).Cells(7).Value.ToString) '.WriteAttributeString("UUIDComercioExt", "182fe8c7-bf27-43e6-b21b-b1a59eaa8399")
                        .WriteAttributeString("FraccionArancelaria", frmfacturacion.dgProductos.Rows(i).Cells(8).Value.ToString) '.WriteAttributeString("FraccionArancelaria", "3923100301")
                    End If

                    .WriteAttributeString("PesoEnKg", frmfacturacion.dgProductos.Rows(i).Cells(5).Value.ToString)
                    .WriteAttributeString("Moneda", "MXN")
                    .WriteAttributeString("Descripcion", frmfacturacion.dgProductos.Rows(i).Cells(0).Value.ToString)
                    .WriteAttributeString("ClaveUnidad", frmfacturacion.dgProductos.Rows(i).Cells(1).Value.ToString)
                    .WriteAttributeString("Cantidad", frmfacturacion.dgProductos.Rows(i).Cells(3).Value.ToString)
                    .WriteAttributeString("BienesTransp", frmfacturacion.dgProductos.Rows(i).Cells(2).Value.ToString)

                    If valida_MatPel(frmfacturacion.dgProductos.Rows(i).Cells(2).Value.ToString) Then
                        .WriteAttributeString("MaterialPeligroso", frmfacturacion.dgProductos.Rows(i).Cells(9).Value.ToString)
                        If frmfacturacion.dgProductos.Rows(i).Cells(9).Value.ToString = "Sí" Then
                            BanderaMetPel = "Sí"
                            .WriteAttributeString("CveMaterialPeligroso", frmfacturacion.dgProductos.Rows(i).Cells(10).Value.ToString)
                            .WriteAttributeString("Embalaje", frmfacturacion.dgProductos.Rows(i).Cells(12).Value.ToString)
                            .WriteAttributeString("DescripEmbalaje", frmfacturacion.dgProductos.Rows(i).Cells(11).Value.ToString)
                        End If
                    End If

                    'If dgdist.RowCount > 1 Then
                    '    For i = 0 To dgdist.RowCount - 1
                    '        .WriteStartElement("cartaporte20:CantidadTransporta")
                    '        .WriteAttributeString("Cantidad", dgdist.Rows(i).Cells(2).Value.ToString)
                    '        .WriteAttributeString("IDOrigen", varIdOrigen)
                    '        .WriteAttributeString("IDDestino", dgdist.Rows(i).Cells(1).Value.ToString)
                    '        .WriteEndElement() ' fin CantidadTransporta
                    '    Next
                    'End If

                    .WriteEndElement() ' fin Mercancia

                Next

                .WriteStartElement("cartaporte20:Autotransporte")
                .WriteAttributeString("PermSCT", dameclavePermisoSCT)
                .WriteAttributeString("NumPermisoSCT", frmfacturacion.txtNumPermisoSCT.Text)

                .WriteStartElement("cartaporte20:IdentificacionVehicular")
                .WriteAttributeString("PlacaVM", frmfacturacion.txtPlaca.Text)
                .WriteAttributeString("ConfigVehicular", dameclaveConfigV)
                .WriteAttributeString("AnioModeloVM", frmfacturacion.txtModeloAño.Text)
                .WriteEndElement() ' fin identificacion vehicular

                .WriteStartElement("cartaporte20:Seguros")
                .WriteAttributeString("AseguraRespCivil", frmfacturacion.txtAseguradora.Text)
                .WriteAttributeString("PolizaRespCivil", frmfacturacion.txtNumPoliza.Text)
                If BanderaMetPel = "Sí" Then
                    .WriteAttributeString("AseguraMedAmbiente", frmfacturacion.txtAseguradoraMatPel.Text)
                    .WriteAttributeString("PolizaMedAmbiente", frmfacturacion.txtNumPolizaMatPel.Text)
                End If
                .WriteEndElement() ' fin identificacion vehicular

                If frmfacturacion.DataGridView1.RowCount > 0 Then
                    .WriteStartElement("cartaporte20:Remolques")
                    For i = 0 To frmfacturacion.DataGridView1.RowCount - 1
                        .WriteStartElement("cartaporte20:Remolque")
                        .WriteAttributeString("SubTipoRem", frmfacturacion.DataGridView1.Rows(i).Cells(2).Value.ToString)
                        .WriteAttributeString("Placa", frmfacturacion.DataGridView1.Rows(i).Cells(0).Value.ToString)
                        .WriteEndElement() ' fin identificacion Remolque
                    Next
                    .WriteEndElement() ' fin identificacion Remolques
                End If

                .WriteEndElement() ' fin autotransport

                .WriteEndElement() ' fin Mercancias

                '=========================== COMIENZA Figura Transporte
                .WriteStartElement("cartaporte20:FiguraTransporte")
                '.WriteAttributeString("CveTransporte", "01")

                .WriteStartElement("cartaporte20:TiposFigura")
                '.WriteAttributeString("TipoFigura", "01")
                If frmfacturacion.cboTipoFigura.Text = "Operador" Then
                    .WriteAttributeString("TipoFigura", "01")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Propietario" Then
                    .WriteAttributeString("TipoFigura", "02")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Arrendador" Then
                    .WriteAttributeString("TipoFigura", "03")
                ElseIf frmfacturacion.cboTipoFigura.Text = "Notificado" Then
                    .WriteAttributeString("TipoFigura", "04")
                End If

                '.WriteAttributeString("ResidenciaFiscalOperador", "MEX")
                If Trim(frmfacturacion.txtOpeRFC.Text) <> "" Then
                    .WriteAttributeString("RFCFigura", frmfacturacion.txtOpeRFC.Text)
                End If
                If Trim(frmfacturacion.txtOpeLicencia.Text) <> "" Then
                    .WriteAttributeString("NumLicencia", frmfacturacion.txtOpeLicencia.Text)
                End If

                If Trim(frmfacturacion.cboOpeNombre.Text) <> "" Then
                    .WriteAttributeString("NombreFigura", frmfacturacion.cboOpeNombre.Text)
                End If

                '.WriteAttributeString("NombreOperador", varOpeNom)

                .WriteEndElement() ' fin Tipos Figura

                .WriteEndElement() ' fin Figura Transporte

                .WriteEndElement() ' fin CARTA PORTE

                .WriteEndElement() ' fin complemento

            End If

            'termina carta porte

            .WriteEndElement()

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML


        If varrutabase <> "" Then
            xmldoc.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Load(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)
        End If

        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml

        If varrutabase <> "" Then
            xmldoc.Save("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)
        Else
            xmldoc.Save(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)
        End If

        '================================= termina xml base3

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""
        Dim version As String = ""
        Dim rfcprovcertif As String = ""
        frmfacturacion.ProgressBar1.Value = 60
        frmfacturacion.lbl_proceso.Text = "Creando XML Timbrado ..."
        My.Application.DoEvents()

        If timbre_f4(serie, folio, folio_sat_uuid, fecha_folio_sat, newcarpeta, rfc_empresa, cadena_orig, no_csd_emp, certificado_sat) Then

            crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\" & nombreCFD)

            If varrutabase <> "" Then
                crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
                Lector = New System.Xml.XmlTextReader("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\" & nombreCFD)
            End If

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

            cadena_orig = CadenaOrg(version, folio_sat_uuid, fecha_folio_sat, rfcprovcertif, sello_emisor, certificado_sat)
            frmfacturacion.ProgressBar1.Value = 70
            frmfacturacion.lbl_proceso.Text = "Guardando Datos Factura ..."
            My.Application.DoEvents()
            actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, IIf(frmfacturacion.Cmb_TipoFact.Text = "NOTA DE CREDITO", ESTATUS_NOTASCREDITO, ESTATUS_FACTURA), id_evento)

            frmfacturacion.ProgressBar1.Value = 75
            'Actualiza_ventasf(folio)

            frmfacturacion.lbl_proceso.Text = "Generando Qr ..."
            My.Application.DoEvents()
            ima_qr(rfc_empresa, rfc_receptor, total, folio_sat_uuid, id_evento, newcarpeta, Right(sello_emisor, 8))
            Return True
        Else
            actualiza_valores_fac(folio_sat_uuid, fecha_folio_sat, sello_emisor, sello_sat, cadena_orig, no_csd_emp, certificado_sat, ESTATUS_FACTURA_ERROR, id_evento)
            Return False
        End If
    End Function


    Public Function timbre_f(ByVal serie As String, ByVal folio As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal razon_social As String, ByVal frcemisor As String, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String)
        Dim x As Boolean = False
        ' MsgBox(frmfacturacion.cbo_rfc_emisor.Text)
        If frmfacturacion.cbo_rfc_emisor.Text = "AAA010101AAA" Or frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If

        Dim conector As New Conector(x)
#Disable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim idError As Integer
#Enable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim NError As String
#Disable Warning BC42024 ' Variable local sin usar: 'uuid'.
        Dim uuid As String
#Enable Warning BC42024 ' Variable local sin usar: 'uuid'.
        'Dim FechaTimbre As DateTime
#Disable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.
        Dim xmlTimbrado As String
#Enable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.

        Dim id As String
        Dim documentoXml As XmlDocument
        ' Dim conector As IConectorServisim
        '  conector = New ConectorServisimImpl()

        Dim nombreCFD As String = ""

        Select Case frmfacturacion.Cmb_TipoFact.Text

            Case "FACTURA"
                nombreCFD = "F" & serie & folio & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & serie & folio & ".xml"
            Case "RECIBO DE ARRENDAMIENTO"
                nombreCFD = "A" & serie & folio & ".xml"
            Case "RECIBO DE HONORARIOS"
                nombreCFD = "H" & serie & folio & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & serie & folio & ".xml"
        End Select

        documentoXml = New XmlDocument

        id = serie & folio

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
        End If

        If varrutabase <> "" Then
            documentoXml.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\Temporales\" & nombreCFD)
        Else
            documentoXml.Load(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\Temporales\" & nombreCFD)
        End If

        Try

            'Este ejemplo está dirigido a aquellos integradores que ya generan el xml (CFDI) y solo desean timbrarlo

            'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
            'Fasle = Ambiente de pruebas
            'True = Ambiente de producción

            'Establecemos las credenciales para el permiso de conexión
            'Ambiente de pruebas = mvpNUXmQfK8=
            'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
            If frmfacturacion.cbo_rfc_emisor.Text = "AAA010101AAA" Or frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\Temporales\" & nombreCFD
            If varrutabase <> "" Then
                rutaArchivo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\Temporales\" & nombreCFD
            End If
            '"C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\comprobanteSinTimbrar2.xml" ' 
            'Timbramos el CFDI por medio del conector y guardamos resultado'
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)

            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then

                'El comprobante fue timbrado exitosamente
                'Guardamos xml cfdi

                If (resultadoTimbre.GuardaXml(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\", nombreCFD)) Then
                    '     MessageBox.Show("El xml fue guardado correctamente")
                Else
                    MessageBox.Show("Ocurrió un error al guardar el comprobante")
                End If

                If varrutabase <> "" Then
                    If (resultadoTimbre.GuardaXml("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\", nombreCFD)) Then
                    Else
                        MessageBox.Show("Ocurrió un error al guardar el comprobante")
                    End If
                End If

                'Los siguientes datos deberán ir en la respresentación impresa ó PDF

                '1.- Código bidimensional
                'If (resultadoTimbre.GuardaCodigoBidimensional("C:\", "codigo")) Then
                '    MessageBox.Show("El código bidimensional fue guardado correctamente")
                'Else
                '    MessageBox.Show("Ocurrió un error al guardar el código bidimensional")
                'End If

                '2.- Folio fiscal
                Dim foliFiscal As String = resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor
                Dim noCertificado As String = resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT
                Dim noCertificadoSat As String = resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación
                Dim fechaCert As String = resultadoTimbre.FechaCertificacion

                '6.- Sello del cfdi
                Dim selloCFDI As String = resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                '   MessageBox.Show("Timbrado Exitoso")

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                actualiza_timbres(frcemisor)
            Else

                'No se pudo timbrar, mostramos respuesta
                MessageBox.Show(resultadoTimbre.Descripcion)
                MessageBox.Show(resultadoTimbre.Detalle)
                MessageBox.Show(resultadoTimbre.DescripcionInterna)


                '  envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & resultadoTimbre.Descripcion, "", "")
                ' bitacora(frmfacturacion.cbo_rfc_emisor.Text, "Error: " & NError & "- " & ex.Message)
                'Form1.ListBox1.Text &= vbCrLf & "Error: " & resultadoTimbre.Descripcion
                frmfacturacion.Cmb_RazonS.SelectedValue = 0
                frmfacturacion.Cmb_RFC.SelectedValue = 0
                Return False

            End If

        Catch ex As Exception
            'rs = cn.Execute("delete from recibos_nomina_detalle_paso ")

            'frmerrores_timbre.Show()
            'frmerrores_timbre.lista_e.Text = frmerrores_timbre.lista_e.Text & vbCr & NError & vbCr & nombre_emp_e

#Disable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            MsgBox("Error: " & NError & "- " & ex.Message)
#Enable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.

            envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & NError & "- " & ex.Message, "", "")
            ' bitacora(frmfacturacion.cbo_rfc_emisor.Text, "Error: " & NError & "- " & ex.Message)
            '  Form1.ListBox1.Text &= vbCrLf & "Error: " & NError & "- " & ex.Message
            frmfacturacion.Cmb_RazonS.SelectedValue = 0
            frmfacturacion.Cmb_RFC.SelectedValue = 0

            '  MsgBox("Error: " & NError & "- " & ex.Message)

            Return False

        End Try

        Return True

    End Function

    Private Sub actualiza_valores_fac(ByVal folio_sat As String, ByVal fecha_folio_sat As String, ByVal sello_emisor As String,
                               ByVal sello_sat As String, ByVal cadena_original As String, ByVal no_serie_certificado As String,
                               ByVal no_serie_certificado_sat As String, ByVal estatus_fac As Integer, ByVal evento As Integer)

        Dim sinfo As String = ""
        Dim sSQL As String = "update facturas set nom_folio_sat_uuid='" & folio_sat & "', nom_fecha_folio_sat='" & fecha_folio_sat &
                                "',nom_sello_emisor='" & sello_emisor & "',nom_sello_sat='" & sello_sat & "',nom_cadena_original='" &
                                cadena_original & "',nom_no_csd_emp='" & no_serie_certificado & "',nom_no_csd_sat='" & no_serie_certificado_sat &
                                "',estatus_fac=" & estatus_fac & ", fecha='" & Format(Date.Now, "yyyy-MM-dd") & "' where id_evento=" & evento & " and estatus_fac=" & estatus_fac

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection

        Dim odata As New ToolKitSQL.myssql

        If odata.dbOpen(cnn, sTarget, sinfo) Then

            If odata.runSp(cnn, sSQL, sinfo) Then

            Else

                ' MsgBox(sinfo)

            End If

            cnn.Close()
        End If

    End Sub

    Public Function CadenaOrg(ByVal version As String, ByVal uuid As String, ByVal fechaTimbrado As String, ByVal rfcprovcertif As String, ByVal selloEmisor As String, ByVal certificadoSat As String) As String
        Dim cadena_original As String = ""

        cadena_original = "||" & version & "|" & uuid & "|" & fechaTimbrado & "|" & rfcprovcertif & "|" & selloEmisor & "|" & certificadoSat & "||"

        Return cadena_original

    End Function

    Public Sub ima_qr(ByVal rfc_empresa As String, ByVal rfc_receptor As String, ByVal totalc As String, ByVal foliofis As String, ByVal id_evento As Integer, ByVal razon_social As String, ByVal sello_emisor As String)

        Dim newcarpeta As String = Replace(frmfacturacion.cbo_emisor.Text, Chr(34), "").ToString

        '" & newcarpeta & "\"

        'crea_ruta("C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\imagenes\")
        'Dim qre As New QrCodeImgControl
        'qre.Size = New System.Drawing.Size(200, 200)
        'qre.Text = "?re=" & rfc_empresa & "&rr=" & rfc_receptor & "&tt=" & totalc & "&id=" & foliofis
        'Dim ima As Image = DirectCast(qre.Image.Clone, Image)

        'If File.Exists("C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\imagenes\" & id_evento & ".jpg") Then
        '    File.Delete("C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\imagenes\" & id_evento & ".jpg")
        'End If
        'ima.Save("C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\imagenes\" & id_evento & ".jpg")

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\")
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\")
        End If
        Dim qre As New QrCodeImgControl
        qre.Size = New System.Drawing.Size(200, 200)
        qre.Text = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=" & foliofis & "&re=" & rfc_empresa & "&rr=" & rfc_receptor & "&tt=" & totalc & "&fe=" & sello_emisor
        Dim ima As Image = DirectCast(qre.Image.Clone, Image)


        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg")
            End If
        End If

        ima.Save(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg")
        If varrutabase <> "" Then
            ima.Save("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\imagenes\" & id_evento & ".jpg")
        End If

    End Sub

    Public Function timbre_f4(ByVal serie As String, ByVal folio As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal razon_social As String, ByVal frcemisor As String, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String)

        Dim x As Boolean = False
        If frmfacturacion.cbo_rfc_emisor.Text = "AAA010101AAA" Or frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If

        Dim conector As New Profact.TimbraCFDI40.Conector(x)
#Disable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim idError As Integer
#Enable Warning BC42024 ' Variable local sin usar: 'idError'.
        Dim NError As String
#Disable Warning BC42024 ' Variable local sin usar: 'uuid'.
        Dim uuid As String
#Enable Warning BC42024 ' Variable local sin usar: 'uuid'.
#Disable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.
        Dim xmlTimbrado As String
#Enable Warning BC42024 ' Variable local sin usar: 'xmlTimbrado'.
        Dim id As String
        Dim documentoXml As XmlDocument
        Dim nombreCFD As String = ""

        Select Case frmfacturacion.Cmb_TipoFact.Text
            Case "FACTURA"
                nombreCFD = "F" & serie & folio & ".xml"
            Case "PREFACTURA"
                nombreCFD = "pf" & serie & folio & ".xml"
            Case "RECIBO DE ARRENDAMIENTO"
                nombreCFD = "A" & serie & folio & ".xml"
            Case "RECIBO DE HONORARIOS"
                nombreCFD = "H" & serie & folio & ".xml"
            Case "NOTA DE CREDITO"
                nombreCFD = "N" & serie & folio & ".xml"
        End Select

        documentoXml = New XmlDocument

        id = serie & folio

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
        If varrutabase <> "" Then
            crea_ruta("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
        End If

        If varrutabase <> "" Then
            documentoXml.Load("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        Else
            documentoXml.Load(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)
        End If

        Try

            'Este ejemplo está dirigido a aquellos integradores que ya generan el xml (CFDI) y solo desean timbrarlo
            If frmfacturacion.cbo_rfc_emisor.Text = "AAA010101AAA" Or frmfacturacion.cbo_rfc_emisor.Text = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD
            If varrutabase <> "" Then
                rutaArchivo = "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD
            End If
            'Timbramos el CFDI por medio del conector y guardamos resultado'
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)

            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then

                'El comprobante fue timbrado exitosamente
                'Guardamos xml cfdi

                If (resultadoTimbre.GuardaXml(My.Application.Info.DirectoryPath & "\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\", nombreCFD)) Then
                Else
                    MessageBox.Show("Ocurrió un error al guardar el comprobante")
                End If

                If varrutabase <> "" Then
                    If (resultadoTimbre.GuardaXml("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\", nombreCFD)) Then
                    End If
                End If

                'crea_ruta("\\" & varrutabase & "\ControlNegociosPRO\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\" & frmfacturacion.Cmb_TipoFact.Text & "\")
                'documentoXml.Load("\\" & varrutabase & "\ControlNegociosPRO\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)


                'Los siguientes datos deberán ir en la respresentación impresa ó PDF

                '2.- Folio fiscal
                Dim foliFiscal As String = "" 'resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor
                Dim noCertificado As String = "" 'resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT
                Dim noCertificadoSat As String = "" 'resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación
                Dim fechaCert As String = "" 'resultadoTimbre.FechaCertificacion

                '6.- Sello del cfdi
                Dim selloCFDI As String = "" 'resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = "" 'resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                actualiza_timbres(frcemisor)
            Else

                'No se pudo timbrar, mostramos respuesta
                MessageBox.Show(resultadoTimbre.Descripcion)
                MessageBox.Show(resultadoTimbre.Detalle)
                MessageBox.Show(resultadoTimbre.DescripcionInterna)

                frmfacturacion.Cmb_RazonS.SelectedValue = 0
                frmfacturacion.Cmb_RFC.SelectedValue = 0
                Return False

            End If

        Catch ex As Exception

#Disable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            MsgBox("Error: " & NError & "- " & ex.Message)
#Enable Warning BC42104 ' La variable 'NError' se usa antes de que se le haya asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & NError & "- " & ex.Message, "", "")
            frmfacturacion.Cmb_RazonS.SelectedValue = 0
            frmfacturacion.Cmb_RFC.SelectedValue = 0

            Return False

        End Try

        Return True

    End Function

    Public Sub actualiza_timbres(ByVal rfcem As String)

        Dim sInfo As String
        Dim cnn As MySqlConnection = New MySqlConnection
        timbres_timbrados = timbres_timbrados + 1

        Dim sSQL As String = "update  Panel_Principal set Timbres_Consumidos=" & timbres_timbrados & " where rfc='" & rfcem & "'"

        Dim odata As New ToolKitSQL.myssql


        With odata

#Disable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
            If odata.dbOpen(cnn, sTargetMYSQL, sInfo) Then
#Enable Warning BC42030 ' La variable 'sInfo' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.

                If odata.runSp(cnn, sSQL, sInfo) Then

                End If

                cnn.Close()
            Else
                ' MessageBox.Show("Hubo un error en la conexion verifique los datos o su conexion a Internet")

            End If

        End With


    End Sub

    Function valida_MatPel(ByVal varcodprod As String) As Boolean

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
#Disable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                If .getDr(cnn, dr, "select ClaveProdSat from PorteMatPeligrososV where ClaveProdSat = '" & Trim(varcodprod) & "'", sinfo) Then
#Enable Warning BC42030 ' La variable 'dr' se ha pasado como referencia antes de haberle asignado un valor. Podría darse una excepción de referencia NULL en tiempo de ejecución.
                    cnn.Close()
                    If dr("ClaveProdSat").ToString <> "" Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    cnn.Close()
                    Return False
                End If
                cnn.Close()
            End If
        End With

        Return False

    End Function

    Public Sub cancelaporte(ByVal uuid_noms As String, ByVal rfc_noms As String, ByVal foliof As String, ByVal FolioUnido As String, ByVal EmiRazonSocial As String, ByVal varTipoCancelacion As String, ByVal varuuidcancel As String)

        Dim x As Boolean = False
        If rfc_noms = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If
        Dim conector As New Profact.TimbraCFDI40.Conector(False)
        If rfc_noms = "IIA040805DZ4" Then
            conector.EstableceCredenciales("mvpNUXmQfK8=")
        Else
            conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
        End If

        'Rfc Emisor
        Dim rfcEmisor As String = rfc_noms.Trim
        'Folio Fiscal - UUID
        Dim folioFiscal As String = uuid_noms.Trim
        'Motivo
        Dim motivoCancelacion As String = varTipoCancelacion.Trim
        'Folio Fiscal - UUID a sustituir
        Dim uuidSustitucion = varuuidcancel.Trim
        If (motivoCancelacion = "01") Then
            'Si el valor de Motivo es 01, el UUID para sustituir es requerido
            If (uuidSustitucion = "") Then
                MessageBox.Show("Cuando el Motivo de cancelación es 01, se debe registrar el folio fiscal a sustituir")
            End If
        End If

        'Obtenemos el xml por medio del conector y guardamos resultado'
        Dim resultadoCancelacion As Profact.TimbraCFDI.ResultadoCancelacionAck
        resultadoCancelacion = conector.CancelaCFDIAck40(rfcEmisor, folioFiscal, motivoCancelacion, uuidSustitucion)
        'resultadoCancelacion = conector.CancelaCFDIAck(rfcEmisor, folioFiscal)
        'Verificamos el resultado
        If (resultadoCancelacion.Exitoso) Then
            'El comprobante fue cancelado exitosamente
            MessageBox.Show("Cancelación exitosa " + resultadoCancelacion.Descripcion)
            Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
            resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)
            'Verificamos el resultado
            If (resultadoConsulta.Exitoso) Then
                Dim destino As String = ""
                'El comprobante fue consultado exitosamente
                Dim tipo As String = ""
                Dim tipo2 As String = ""
                'Guardamos xml cfdi
                Dim rutaftp2 As String = ""
                Dim ruta_acuse As String = ""
                Dim nombre_acuse As String = "Acuse_" & FolioUnido & ".xml"
                ruta_acuse = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiRazonSocial & "\CARTAPORTE\Acuses\"
                crea_dir(ruta_acuse)
                If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                    MsgBox("El xml fue guardado correctamente")
                    cancela_porte(uuid_noms)
                Else
                    MsgBox("Ocurrió un error al guardar el comprobante")
                End If
            Else
                'No se pudo consultar, mostramos respuesta
                MsgBox(resultadoConsulta.Descripcion)
            End If
        Else
            'No se pudo cancelar, mostramos respuesta
            If resultadoCancelacion.Descripcion = "UUID Previamente cancelado." Then
                cancela_porte(uuid_noms)
                Dim resultadoConsulta As Profact.TimbraCFDI.ResultadoConsulta
                resultadoConsulta = conector.ObtieneCFDI(rfcEmisor, folioFiscal)
                'Verificamos el resultado
                If (resultadoConsulta.Exitoso) Then
                    Dim destino As String = ""
                    'El comprobante fue consultado exitosamente
                    Dim tipo As String = ""
                    Dim tipo2 As String = ""
                    'Guardamos xml cfdi
                    Dim rutaftp2 As String = ""
                    Dim ruta_acuse As String = ""
                    Dim nombre_acuse As String = "Acuse_" & FolioUnido & ".xml"
                    ruta_acuse = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiRazonSocial & "\CARTAPORTE\Acuses\"
                    crea_dir(ruta_acuse)
                    If (resultadoConsulta.GuardaXml(ruta_acuse, nombre_acuse)) Then
                        MsgBox("El xml fue guardado correctamente")
                        cancela_porte(uuid_noms)
                        Try
                            Dim root_name_recibo As String = ruta_acuse & nombre_acuse
                            Dim sinfo As String
                        Catch ex As Exception
                        End Try
                    Else
                        ' MessageBox.Show("Ocurrió un error al guardar el comprobante")
                        MsgBox("Ocurrió un error al guardar el comprobante")
                    End If
                    MsgBox("Consulta exitosa")
                Else
                    'No se pudo consultar, mostramos respuesta
                    MsgBox("Cancelacion sin acuse intentelo mas tarde")
                End If
            End If
            MessageBox.Show(resultadoCancelacion.Descripcion)
        End If

    End Sub
    Public Function GeneraXMLTrasporte(ByVal varIdCarta As String, ByRef FolioFact As String, ByRef EmiNombre As String, ByRef EmiRFC As String, ByRef CodigoPostal As String, ByRef EmiRegFis As String,
                                              ByRef CliRFC As String, ByRef CliNombre As String, ByVal valInter As String, ByVal varOrigRemitente As String,
                                              ByVal varOrigRFC As String, ByVal varOrigfechahora As String, ByVal varOrigCP As String, ByVal varOrigCalle As String,
                                              ByVal varOrigNumExt As String, ByVal varOrigNumInt As String, ByVal varOrigColonia As String, ByVal varOrigEdo As String,
                                              ByVal varOrigLoc As String, ByVal varOrigMun As String, ByVal vartotaldistancia As String, ByVal varDesNombre As String, ByVal varDesRFC As String,
                                              ByVal varDesfechahora As String, ByVal varDesCP As String, ByVal varDesPais As String, ByVal varDesCalle As String, ByVal varDesnume As String,
                                              ByVal varDesnumi As String, ByVal varDesCol As String, ByVal varDesedo As String, ByVal varDesmun As String, ByVal dgprod As DataGridView,
                                              ByVal varPermisoSCT As String, ByVal varNumPoliza As String, ByVal varNumPermisoSCT As String, ByVal varAseguradora As String,
                                              ByVal varPlaca As String, ByVal varConfig As String, ByVal varAño As String, ByVal varOpeRFC As String, ByVal varOpeLic As String,
                                              ByVal varOpeNom As String, ByVal varOpeNumE As String, ByVal varOpeNumI As String, ByVal varOpeMun As String, ByVal varOpeEdo As String, ByVal varOpeColonia As String,
                                              ByVal varOpeCP As String, ByVal varOpeCalle As String, ByVal varDesLoc As String, ByVal varTransDescripcion As String, ByVal varTransValorUnitario As String,
                                              ByVal varTransUniMedSat As String, ByVal varTransClaveSat As String, ByVal varTransNumPed As String, ByVal varTipofigura As String)

        frmCartaPorte.ProgressBar1.Value = 30
        frmCartaPorte.lbl_proceso.Text = "Creando XML Temporal ..."
        My.Application.DoEvents()

        Dim nombreCFD As String = ""
        Dim tretencionesp As Double = 0

        nombreCFD = "CP" & FolioFact & ".xml"

        crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\Temporales\")

        Dim miXml As XmlTextWriter = New XmlTextWriter("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechacreacion As DateTime = Now


        fechaFormateada = DateAndTime.Now.ToString("s")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-ddTHH:mm:ss")

        With miXml
            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE
            .WriteStartElement("cfdi:Comprobante")
            'aqui empece
            .WriteStartAttribute("xmlns:cartaporte20")
            .WriteValue("http://www.sat.gob.mx/CartaPorte20")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/4")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            .WriteStartAttribute("xsi:schemaLocation")
            .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/CartaPorte20 http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte20.xsd")
            .WriteEndAttribute()

            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(CodigoPostal)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            .WriteValue("T")
            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("XXX")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue("" & fechaFormateada1 & "")
            .WriteEndAttribute()

            .WriteStartAttribute("Folio")
            .WriteValue("CP" & FolioFact)
            .WriteEndAttribute()

            .WriteStartAttribute("Version")
            .WriteValue("4.0")
            .WriteEndAttribute()

            .WriteStartAttribute("Exportacion")
            .WriteValue("01")
            .WriteEndAttribute()

            '.WriteStartAttribute("Serie")
            '.WriteValue(serie)
            '.WriteEndAttribute()

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")
            .WriteAttributeString("Rfc", EmiRFC)
            .WriteAttributeString("Nombre", EmiNombre)
            .WriteAttributeString("RegimenFiscal", EmiRegFis)
            .WriteEndElement() 'Emisor


            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Rfc", CliRFC)
            .WriteAttributeString("Nombre", Trim(CliNombre))
            .WriteAttributeString("UsoCFDI", "S01")
            .WriteAttributeString("DomicilioFiscalReceptor", Trim(frmCartaPorte.txtCPCliente.Text))
            .WriteAttributeString("RegimenFiscalReceptor", frmCartaPorte.cbo_regimen.SelectedValue)
            .WriteEndElement() 'receptor

            '=========================== COMIENZA CONCEPTO

            .WriteStartElement("cfdi:Conceptos")

            'For i = 0 To dgprod.RowCount - 1
            .WriteStartElement("cfdi:Concepto")
            .WriteAttributeString("Cantidad", "1")
            .WriteAttributeString("Descripcion", Trim(varTransDescripcion))
            .WriteAttributeString("ValorUnitario", varTransValorUnitario)
            .WriteAttributeString("Importe", varTransValorUnitario)
            '.WriteAttributeString("NoIdentificacion", "01")
            '.WriteAttributeString("Unidad", "SERVICIO")
            .WriteAttributeString("ClaveUnidad", varTransUniMedSat)
            .WriteAttributeString("ClaveProdServ", varTransClaveSat)
            .WriteAttributeString("ObjetoImp", "01")

            If valInter = "Sí" Then
                .WriteStartElement("cfdi:InformacionAduanera")
                .WriteAttributeString("NumeroPedimento", Trim(varTransNumPed)) '.WriteAttributeString("NumeroPedimento", "21  47  3807  8003832")
                .WriteEndElement() 'info aduanera
            End If
            .WriteEndElement() ' fin concepto
            'Next

            .WriteEndElement() ' fin conceptoS

            '=========================== COMIENZA complemento

            .WriteStartElement("cfdi:Complemento")

            '=========================== COMIENZA carta

            .WriteStartElement("cartaporte20:CartaPorte")
            .WriteAttributeString("Version", "2.0")

            If valInter = "Sí" Then
                .WriteAttributeString("ViaEntradaSalida", "01")
                'en este campo si en Trasporte internacional es Si se debe poner los campos EntradaSalidaMerc y ViaEntradaSalida
                'en este campo si en Trasporte internacional es No los campos EntradaSalidaMerc y ViaEntradaSalida no deben de estar
                'agregar una validacion aqui
                .WriteAttributeString("TranspInternac", "Sí") '.WriteAttributeString("TranspInternac", "Sí")
                'agregar una validacion aqui
                .WriteAttributeString("EntradaSalidaMerc", "Salida")
                'total de distancia tiene que ser igual a la suma del campo DistanciaRecorrida de las ubicaciones que se registren en kilometros
                'Si existe la sección AutotransporteFederal o TransporteFerroviario de
                'la sección Mercancias, este campo debe contener un valor; en caso de
                'que no exista alguna de las secciones antes mencionadas, este campo
                'no debe existir.
                .WriteAttributeString("TotalDistRec", vartotaldistancia)
                If varDesPais <> "" Then
                    .WriteAttributeString("PaisOrigenDestino", varDesPais)
                End If
            Else
                .WriteAttributeString("TranspInternac", "No")
                .WriteAttributeString("TotalDistRec", vartotaldistancia)
            End If


            '=========================== COMIENZA ubicaciones
            'esta parte hay que hacerla con un ciclo porque se pueden poner varias

            .WriteStartElement("cartaporte20:Ubicaciones")

            .WriteStartElement("cartaporte20:Ubicacion")
            '.WriteAttributeString("DistanciaRecorrida", "1")
            '.WriteAttributeString("TipoEstacion", "01")

            .WriteAttributeString("TipoUbicacion", "Origen")

            If Trim(varOrigRemitente) <> "" Then
                .WriteAttributeString("NombreRemitenteDestinatario", Trim(varOrigRemitente))
            End If

            .WriteAttributeString("RFCRemitenteDestinatario", Trim(varOrigRFC))

            .WriteAttributeString("FechaHoraSalidaLlegada", varOrigfechahora)

            'If dgdist.RowCount > 1 Then
            '    .WriteAttributeString("IDOrigen", Trim(varIdOrigen))
            'End If

            .WriteStartElement("cartaporte20:Domicilio")
            If Trim(varOrigNumExt) <> "" Then
                .WriteAttributeString("NumeroExterior", Trim(varOrigNumExt))
            End If
            If Trim(varOrigNumInt) <> "" Then
                .WriteAttributeString("NumeroInterior", Trim(varOrigNumInt))
            End If
            If Trim(varOrigMun) <> "" Then
                .WriteAttributeString("Municipio", Trim(varOrigMun))
            End If
            If Trim(varOrigLoc) <> "" Then
                .WriteAttributeString("Localidad", Trim(varOrigLoc))
            End If
            If Trim(varOrigColonia) <> "" Then
                .WriteAttributeString("Colonia", Trim(varOrigColonia))
            End If
            .WriteAttributeString("Pais", "MEX")
            .WriteAttributeString("Estado", Trim(varOrigEdo))
            .WriteAttributeString("CodigoPostal", Trim(varOrigCP))
            If Trim(varOrigCalle) <> "" Then
                .WriteAttributeString("Calle", Trim(varOrigCalle))
            End If

            .WriteEndElement() ' fin domicilio

            .WriteEndElement() ' fin UBICACION 1

            .WriteStartElement("cartaporte20:Ubicacion")
            .WriteAttributeString("DistanciaRecorrida", vartotaldistancia)
            'Si el campo TranspInternac contiene el valor “No” y si existe la sección
            'TransporteFerroviario, TransporteMaritimo o TransporteAereo de la
            'sección Mercancias, este campo se debe registrar y debe contener una
            'clave del catálogo del complemento Carta Porte c_TipoEstacion,
            'publicado en el portan del SAT

            'En otro caso, si el campo TranspInternac contiene el valor “Sí” este
            'campo no debe registrarse siempre que el Origen o Destino de los
            'bienes o mercancías sea fuera de territorio nacional, por lo que el
            'campo Pais de la sección Ubicacion debe contener una clave distinta
            'de “MEX”, en caso contrario se debe registrar una clave del catálogo del
            'complemento Carta Porte c_TipoEstacion, publicado en el portal del
            'SAT.

            'If valInter = "No" Then
            '    .WriteAttributeString("TipoEstacion", "01")
            'End If

            .WriteAttributeString("TipoUbicacion", "Destino")

            If Trim(varDesNombre) <> "" Then
                .WriteAttributeString("NombreRemitenteDestinatario", Trim(varDesNombre))
            End If

            .WriteAttributeString("RFCRemitenteDestinatario", Trim(varDesRFC))

            .WriteAttributeString("FechaHoraSalidaLlegada", varDesfechahora)

            .WriteStartElement("cartaporte20:Domicilio")
            If Trim(varDesnume) <> "" Then
                .WriteAttributeString("NumeroExterior", Trim(varDesnume))
            End If
            If Trim(varDesnumi) <> "" Then
                .WriteAttributeString("NumeroInterior", Trim(varDesnumi))
            End If
            If Trim(varDesmun) <> "" Then
                .WriteAttributeString("Municipio", Trim(varDesmun))
            End If
            If Trim(varDesCol) <> "" Then
                .WriteAttributeString("Colonia", Trim(varDesCol))
            End If
            If valInter = "Sí" Then
                If Trim(varDesLoc) <> "" Then
                    .WriteAttributeString("Localidad", Trim(varDesLoc))
                End If
            Else
                If Trim(varDesLoc) <> "" Then
                    .WriteAttributeString("Localidad", Trim(dameLocalidadDtraslado))
                End If
            End If
            .WriteAttributeString("Pais", varDesPais)
            .WriteAttributeString("Estado", varDesedo)
            .WriteAttributeString("CodigoPostal", varDesCP)
            If Trim(varDesCalle) <> "" Then
                .WriteAttributeString("Calle", varDesCalle)
            End If
            '.WriteAttributeString("Referencia", "casa blanca")
            .WriteEndElement() ' fin domicilio

            .WriteEndElement() ' fin UBICACION 2

            .WriteEndElement() ' fin UBICACIONES

            '=========================== COMIENZA Mercancias
            .WriteStartElement("cartaporte20:Mercancias")

            Dim pesobruto As Double = 0
            For i = 0 To dgprod.RowCount - 1
                pesobruto = pesobruto + CDec(dgprod.Rows(i).Cells(5).Value.ToString)
            Next

            Dim unidadpeso As String = ""
            For i = 0 To dgprod.RowCount - 1
                unidadpeso = dgprod.Rows(i).Cells(1).Value.ToString
                Exit For
            Next

            .WriteAttributeString("PesoBrutoTotal", pesobruto)
            .WriteAttributeString("UnidadPeso", unidadpeso)
            .WriteAttributeString("NumTotalMercancias", dgprod.RowCount)

            Dim BanderaMetPel As String = ""

            For i = 0 To dgprod.RowCount - 1

                .WriteStartElement("cartaporte20:Mercancia")

                If IsNumeric(dgprod.Rows(i).Cells(4).Value.ToString) Then

                    .WriteAttributeString("ValorMercancia", dgprod.Rows(i).Cells(4).Value.ToString)

                End If

                If valInter = "Sí" Then
                    .WriteAttributeString("UUIDComercioExt", dgprod.Rows(i).Cells(7).Value.ToString) '.WriteAttributeString("UUIDComercioExt", "182fe8c7-bf27-43e6-b21b-b1a59eaa8399")
                    .WriteAttributeString("FraccionArancelaria", dgprod.Rows(i).Cells(8).Value.ToString) '.WriteAttributeString("FraccionArancelaria", "3923100301")
                End If

                .WriteAttributeString("PesoEnKg", dgprod.Rows(i).Cells(5).Value.ToString)
                .WriteAttributeString("Moneda", "MXN")
                .WriteAttributeString("Descripcion", dgprod.Rows(i).Cells(0).Value.ToString)
                .WriteAttributeString("ClaveUnidad", dgprod.Rows(i).Cells(1).Value.ToString)
                .WriteAttributeString("Cantidad", dgprod.Rows(i).Cells(3).Value.ToString)
                .WriteAttributeString("BienesTransp", dgprod.Rows(i).Cells(2).Value.ToString)

                If valida_MatPel(dgprod.Rows(i).Cells(2).Value.ToString) Then
                    .WriteAttributeString("MaterialPeligroso", dgprod.Rows(i).Cells(9).Value.ToString)
                    If dgprod.Rows(i).Cells(9).Value.ToString = "Sí" Then
                        BanderaMetPel = "Sí"
                        .WriteAttributeString("CveMaterialPeligroso", dgprod.Rows(i).Cells(10).Value.ToString)
                        .WriteAttributeString("Embalaje", dgprod.Rows(i).Cells(12).Value.ToString)
                        .WriteAttributeString("DescripEmbalaje", dgprod.Rows(i).Cells(11).Value.ToString)
                    End If
                End If

                'If dgdist.RowCount > 1 Then
                '    For i = 0 To dgdist.RowCount - 1
                '        .WriteStartElement("cartaporte20:CantidadTransporta")
                '        .WriteAttributeString("Cantidad", dgdist.Rows(i).Cells(2).Value.ToString)
                '        .WriteAttributeString("IDOrigen", varIdOrigen)
                '        .WriteAttributeString("IDDestino", dgdist.Rows(i).Cells(1).Value.ToString)
                '        .WriteEndElement() ' fin CantidadTransporta
                '    Next
                'End If

                .WriteEndElement() ' fin Mercancia

            Next

            .WriteStartElement("cartaporte20:Autotransporte")
            .WriteAttributeString("PermSCT", varPermisoSCT)
            .WriteAttributeString("NumPermisoSCT", varNumPermisoSCT)

            .WriteStartElement("cartaporte20:IdentificacionVehicular")
            .WriteAttributeString("PlacaVM", varPlaca)
            .WriteAttributeString("ConfigVehicular", varConfig)
            .WriteAttributeString("AnioModeloVM", varAño)
            .WriteEndElement() ' fin identificacion vehicular

            .WriteStartElement("cartaporte20:Seguros")
            .WriteAttributeString("AseguraRespCivil", varAseguradora)
            .WriteAttributeString("PolizaRespCivil", varNumPoliza)
            If BanderaMetPel = "Sí" Then
                .WriteAttributeString("AseguraMedAmbiente", frmCartaPorte.txtAseguradoraMatPel.Text)
                .WriteAttributeString("PolizaMedAmbiente", frmCartaPorte.txtNumPolizaMatPel.Text)
            End If
            .WriteEndElement() ' fin identificacion vehicular

            If frmCartaPorte.DataGridView1.RowCount > 0 Then
                .WriteStartElement("cartaporte20:Remolques")
                For i = 0 To frmCartaPorte.DataGridView1.RowCount - 1
                    .WriteStartElement("cartaporte20:Remolque")
                    .WriteAttributeString("SubTipoRem", frmCartaPorte.DataGridView1.Rows(i).Cells(2).Value.ToString)
                    .WriteAttributeString("Placa", frmCartaPorte.DataGridView1.Rows(i).Cells(0).Value.ToString)
                    .WriteEndElement() ' fin identificacion Remolque
                Next
                .WriteEndElement() ' fin identificacion Remolques
            End If

            .WriteEndElement() ' fin autotransporte

            .WriteEndElement() ' fin Mercancias

            '=========================== COMIENZA Figura Transporte
            .WriteStartElement("cartaporte20:FiguraTransporte")
            '.WriteAttributeString("CveTransporte", "01")

            .WriteStartElement("cartaporte20:TiposFigura")
            If varTipofigura = "Operador" Then
                .WriteAttributeString("TipoFigura", "01")
            ElseIf varTipofigura = "Propietario" Then
                .WriteAttributeString("TipoFigura", "02")
            ElseIf varTipofigura = "Arrendador" Then
                .WriteAttributeString("TipoFigura", "03")
            ElseIf varTipofigura = "Notificado" Then
                .WriteAttributeString("TipoFigura", "04")
            End If
            '.WriteAttributeString("ResidenciaFiscalOperador", "MEX")
            If Trim(varOpeRFC) <> "" Then
                .WriteAttributeString("RFCFigura", varOpeRFC)
            End If
            If Trim(varOpeLic) <> "" Then
                .WriteAttributeString("NumLicencia", varOpeLic)
            End If

            If Trim(varOpeNom) <> "" Then
                .WriteAttributeString("NombreFigura", varOpeNom)
            End If

            .WriteEndElement() ' fin Tipos Figura

            .WriteEndElement() ' fin Figura Transporte

            .WriteEndElement() ' fin CARTA PORTE

            .WriteEndElement() ' fin complemento

            .WriteEndElement() ' fin comprobante

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML

        xmldoc.Load("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\Temporales\" & nombreCFD)
        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml
        xmldoc.Save("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\Temporales\" & nombreCFD)

        '================================= termina xml base3

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""

        Dim varSello As String = ""
        Dim varNoCert As String = ""
        Dim varCertificado As String = ""
        Dim varUuid As String = ""
        Dim varSelloSat As String = ""
        Dim varSelloCFD As String = ""
        Dim varNoCertSat As String = ""
        Dim varFechatim As String = ""

        frmCartaPorte.ProgressBar1.Value = 60
        frmCartaPorte.lbl_proceso.Text = "Creando XML Timbrado ..."
        My.Application.DoEvents()
        If timbre_CartaPorte("CP" & FolioFact, folio_sat_uuid, fecha_folio_sat, EmiNombre, EmiRFC, cadena_orig, no_csd_emp, certificado_sat) Then

            crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\XML\CARTAPORTE\")

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\XML\CARTAPORTE\" & nombreCFD)

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
                                        Case "UUID"
                                            varUuid = Lector.Value
                                        Case "SelloCFD"
                                            varSelloCFD = Lector.Value
                                        Case "NoCertificadoSAT"
                                            varNoCertSat = Lector.Value
                                        Case "SelloSAT"
                                            varSelloSat = Lector.Value
                                        Case "FechaTimbrado"
                                            varFechatim = Lector.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            Dim Lector1 As System.Xml.XmlTextReader = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & EmiNombre & "\XML\CARTAPORTE\" & nombreCFD)

            Do While (Lector1.Read())
                Select Case Lector1.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector1.Name = "cfdi:Comprobante" Then
                            If Lector1.HasAttributes Then
                                While Lector1.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector1.Name
                                        Case "Sello"
                                            varSello = Lector1.Value
                                        Case "NoCertificado"
                                            varNoCert = Lector1.Value
                                        Case "Certificado"
                                            varCertificado = Lector1.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            frmCartaPorte.ProgressBar1.Value = 85
            frmCartaPorte.lbl_proceso.Text = "Guardando Datos Factura ..."
            My.Application.DoEvents()
            actualizaCartaPorte(fechaFormateada1, varUuid, varSello, varNoCert, varCertificado, varSelloCFD, varNoCertSat, varSelloSat, varFechatim, varIdCarta, cadena_orig)

            'ima_qrCARTA(EmiRFC, CliRFC, "0", folio_sat_uuid, FolioFact, EmiNombre)
            Return True

        Else
            Return False
        End If

    End Function

    Private Function dameLocalidadDtraslado() As String

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        Dim dt As New DataTable
        Dim dr As DataRow
        With odata
            If .dbOpen(cnn, sTarget, sinfo) Then
                If .getDt(cnn, dt, "select ClaveLocalidad from PorteLocalidad where Descripcion = '" & Trim(frmCartaPorte.cboDestinoLoc.Text) & "'", "dtuno") Then
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

    Private Sub actualizaCartaPorte(ByVal varFechaEmi As String, ByVal uuid As String, ByVal sello As String, ByVal NoCert As String, ByVal certif As String, ByVal SelloCFD As String, ByVal NoCertSat As String,
                                ByVal selloSat As String, ByRef FechaTimbrado As String, ByRef IdPar As String, ByRef cadena As String)

        frmCartaPorte.ProgressBar1.Value = 90
        frmCartaPorte.lbl_proceso.Text = "Actualizando Datos ..."
        My.Application.DoEvents()

        Dim sinfo As String = ""
        Dim sSQL As String = "update CartaPorte set FechaEmi = '" & varFechaEmi & "', Certificado ='" & certif & "', UUID='" & uuid & "', Sello='" & sello & "',NoCert='" & NoCert & "',SelloCFD='" &
                                SelloCFD & "',NoCertSat='" & NoCertSat & "',SelloSat='" & selloSat & "',FechaTimbrado='" & FechaTimbrado & "', CadenaOriginal = '" & cadena & "' where Id =" & IdPar & ""
        'Dim sSQL As String = "update Parcialidades set Certificado ='" & certif & "', UUID='" & uuid & "', Sello='" & sello & "',NoCert='" & NoCert & "',SelloCFD='" & _
        '                        SelloCFD & "',NoCertSat='" & NoCertSat & "',SelloSat='" & selloSat & "',FechaTimbrado='" & FechaTimbrado & "', CadenaOriginal = '" & cadena & "' where Id=" & IdPar & ""

        Dim cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim odata As New ToolKitSQL.oledbdata
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then
            Else
            End If
            cnn.Close()
        End If

    End Sub
    Public Function timbre_CartaPorte(ByVal folioFact As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal razon_social As String, ByVal frcemisor As String, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String)
        Dim x As Boolean = False
        If frcemisor = "IIA040805DZ4" Or frcemisor = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If

        Dim conector As New Conector(x)
        Dim idError As Integer
        Dim NError As String
        Dim uuid As String
        Dim xmlTimbrado As String

        Dim id As String
        Dim documentoXml As XmlDocument
        Dim nombreCFD As String = ""

        nombreCFD = folioFact & ".xml"

        documentoXml = New XmlDocument
        id = folioFact

        crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\XML\CARTAPORTE\")
        documentoXml.Load("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\Temporales\" & nombreCFD)

        frmCartaPorte.ProgressBar1.Value = 65
        frmCartaPorte.lbl_proceso.Text = "Timbrando ..."
        My.Application.DoEvents()

        Try
            'Este ejemplo está dirigido a aquellos integradores que ya generan el xml (CFDI) y solo desean timbrarlo

            'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
            'Fasle = Ambiente de pruebas
            'True = Ambiente de producción

            'Establecemos las credenciales para el permiso de conexión
            'Ambiente de pruebas = mvpNUXmQfK8=
            'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
            If frcemisor = "IIA040805DZ4" Or frcemisor = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Trim(Replace(razon_social, Chr(34), "").ToString) & "\Temporales\" & nombreCFD
            'Timbramos el CFDI por medio del conector y guardamos resultado'
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)
            crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Trim(Replace(razon_social, Chr(34), "").ToString) & "\cd\CARTAPORTE\")

            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then

                'El comprobante fue timbrado exitosamente
                frmCartaPorte.ProgressBar1.Value = 80
                frmCartaPorte.lbl_proceso.Text = "Timbrado exitoso ..."
                My.Application.DoEvents()

                'Guardamos xml cfdi
                If (resultadoTimbre.GuardaXml("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Trim(Replace(razon_social, Chr(34), "").ToString) & "\XML\CARTAPORTE\", nombreCFD)) Then
                    '     MessageBox.Show("El xml fue guardado correctamente")
                Else
                    MessageBox.Show("Ocurrió un error al guardar el comprobante")
                End If

                'Los siguientes datos deberán ir en la respresentación impresa ó PDF

                '  1.- Código bidimensional folio & "-" & folioFact

                If (resultadoTimbre.GuardaCodigoBidimensional("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & Trim(Replace(razon_social, Chr(34), "").ToString) & "\cd\CARTAPORTE\", folioFact)) Then
                    ' MessageBox.Show("El código bidimensional fue guardado correctamente")
                Else
                    '  MessageBox.Show("Ocurrió un error al guardar el código bidimensional")
                End If

                '2.- Folio fiscal
                Dim foliFiscal As String = "" 'resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor
                Dim noCertificado As String = "" 'resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT
                Dim noCertificadoSat As String = "" 'resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación
                Dim fechaCert As String = "" 'resultadoTimbre.FechaCertificacion

                '6.- Sello del cfdi
                Dim selloCFDI As String = "" 'resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = "" 'resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                '   MessageBox.Show("Timbrado Exitoso")

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                actualiza_timbres(frcemisor)

            Else

                frmCartaPorte.ProgressBar1.Value = 80
                frmCartaPorte.lbl_proceso.Text = "Error al Timbrar ..."
                My.Application.DoEvents()

                'No se pudo timbrar, mostramos respuesta
                MessageBox.Show(resultadoTimbre.Descripcion)
                MessageBox.Show(resultadoTimbre.DescripcionInterna)
                MessageBox.Show(resultadoTimbre.Detalle)
                Return False

            End If

        Catch ex As Exception
            MsgBox("Error: " & NError & "- " & ex.Message)
            envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & NError & "- " & ex.Message, "", "")
            Return False
        End Try
        Return True

    End Function
    Private Sub cancela_porte(ByVal varidpar As String)

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        'MsgBox(frmParcialidades.cboFolioPar.Text)
        Dim sSQL As String = "update CartaPorte set Estatus = 2 where UUID='" & varidpar & "'" ' & frmParcialidades.cboFolioPar.SelectedValue
        Dim ds As New DataSet
        Dim sinfo As String = ""
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) = True Then
            If odata.runSp(cnn, sSQL, sinfo) Then
                'frm_facturacion.lbl_estatus.Text = "Cancelada"
            End If
            cnn.Close()
        Else
            'MsgBox(sinfo)
        End If
    End Sub

    Public Function GeneraXMLParcialidades1(ByRef FolioFact As String, ByRef FolioPar As String, ByRef EmiNombre As String, ByRef EmiRFC As String, ByRef CodigoPostal As String, ByRef serie As String, ByRef EmiRegFis As String,
                                           ByRef CliRFC As String, ByRef CliNombre As String, ByRef NumOpe As String, ByRef MontoPar As String, ByRef FormaPagoPar As String, ByRef dgv As DataGridView, ByRef IDParci As String,
                                           ByVal FechPag As String, ByVal NumCta As String, ByVal NumCtaCliente As String, ByVal CtaRFCEmi As String, ByVal CtaRFCCli As String, ByVal Banco As String)

        Dim nombreCFD As String = ""
        Dim tretencionesp As Double = 0

        Dim newrazonsocial As String = EmiNombre 'Replace(razon_social, Chr(34), "&quot").ToString
        Dim newcarpeta As String = Replace(EmiNombre, Chr(34), "").ToString

        nombreCFD = "P" & FolioPar & ".xml"

        crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\")

        Dim miXml As XmlTextWriter = New XmlTextWriter("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD, System.Text.Encoding.UTF8)
        Dim fechaFormateada As String
        Dim fechaFormateada1 As String
        Dim fechaFormateada2 As String
        Dim fechacreacion As DateTime = Now

        fechaFormateada = DateAndTime.Now.ToString("s")
        fechaFormateada1 = fechacreacion.ToString("yyyy-MM-ddTHH:mm:ss")
        fechaFormateada2 = FechPag

        With miXml
            .Formatting = System.Xml.Formatting.Indented
            .WriteStartDocument()
            '======================================COMIENZA COMPROVANTE
            .WriteStartElement("cfdi:Comprobante")
            'aqui empece
            .WriteStartAttribute("xmlns:cfdi")
            .WriteValue("http://www.sat.gob.mx/cfd/4")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:xsi")
            .WriteValue("http://www.w3.org/2001/XMLSchema-instance")
            .WriteEndAttribute()

            .WriteStartAttribute("xsi:schemaLocation")
            .WriteValue("http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd")
            .WriteEndAttribute()

            .WriteStartAttribute("xmlns:pago20")
            .WriteValue("http://www.sat.gob.mx/Pagos20")
            .WriteEndAttribute()

            .WriteStartAttribute("LugarExpedicion")
            .WriteValue(CodigoPostal)
            .WriteEndAttribute()

            .WriteStartAttribute("TipoDeComprobante")
            .WriteValue("P")
            .WriteEndAttribute()

            .WriteStartAttribute("Exportacion")
            .WriteValue("01")
            .WriteEndAttribute()

            .WriteStartAttribute("Total")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Moneda")
            .WriteValue("XXX")
            .WriteEndAttribute()

            .WriteStartAttribute("SubTotal")
            .WriteValue("0")
            .WriteEndAttribute()

            .WriteStartAttribute("Fecha")
            .WriteValue("" & fechaFormateada1 & "")
            .WriteEndAttribute()

            .WriteStartAttribute("Folio")
            .WriteValue("P" & FolioPar)
            .WriteEndAttribute()

            .WriteStartAttribute("Version")
            .WriteValue("4.0")
            .WriteEndAttribute()

            .WriteStartAttribute("Serie")
            .WriteValue(serie)
            .WriteEndAttribute()

            '===========================COMIENZA EMISOR

            .WriteStartElement("cfdi:Emisor")
            .WriteAttributeString("Rfc", EmiRFC)
            .WriteAttributeString("Nombre", EmiNombre)
            .WriteAttributeString("RegimenFiscal", EmiRegFis)
            .WriteEndElement() 'Emisor


            '========================================= COMIENZA RECEPTOR

            .WriteStartElement("cfdi:Receptor")
            .WriteAttributeString("Rfc", CliRFC)
            .WriteAttributeString("Nombre", CliNombre)
            .WriteAttributeString("UsoCFDI", "CP01")
            .WriteAttributeString("DomicilioFiscalReceptor", frmMultiParcialidades.txtCPCLiente.Text)
            .WriteAttributeString("RegimenFiscalReceptor", frmMultiParcialidades.txtCliRegFis.Text)
            .WriteEndElement() 'receptor

            '=========================== COMIENZA CONCEPTO

            .WriteStartElement("cfdi:Conceptos")

            .WriteStartElement("cfdi:Concepto")
            .WriteAttributeString("Cantidad", "1")
            .WriteAttributeString("Descripcion", "Pago")
            .WriteAttributeString("ValorUnitario", "0")
            .WriteAttributeString("Importe", "0")
            .WriteAttributeString("ClaveUnidad", "ACT")
            .WriteAttributeString("ClaveProdServ", "84111506")
            .WriteAttributeString("ObjetoImp", "01")

            .WriteEndElement() ' fin concepto

            .WriteEndElement() ' fin concepto

            '=========================== COMIENZA complemento

            .WriteStartElement("cfdi:Complemento")

            '=========================== COMIENZA pagos

            Dim opeiva As Double = 0
            Dim opeivaret As Double = 0
            Dim opeisr As Double = 0
            Dim opeieps As Double = 0
            Dim opeiva0 As Double = 0

            Dim opeivabase As Double = 0
            Dim opeivaretbase As Double = 0
            Dim opeisrbase As Double = 0
            Dim opeiepsbase As Double = 0
            Dim opeiva0base As Double = 0

            For i = 0 To frmMultiParcialidades.GridParcialidades.RowCount - 2

                opeiva = opeiva + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)
                opeivaret = opeivaret + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString)
                opeieps = opeieps + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString)
                opeisr = opeisr + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString)
                opeiva0 = opeiva0 + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString)

                If CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(41).Value.ToString) > 0 Then
                    opeivabase = opeivabase + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(41).Value.ToString)
                    opeivaretbase = opeivaretbase + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(43).Value.ToString)
                End If

                If CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(42).Value.ToString) > 0 Then
                    opeisrbase = opeisrbase + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(42).Value.ToString)
                End If
                If opeieps > 0 Then
                    opeiepsbase = opeiepsbase + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString)
                End If
                If opeiva0 > 0 Then
                    opeiva0base = opeiva0base + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(44).Value.ToString)
                End If
            Next

            'opeivabase = opeivabase - opeiva
            'opeivaretbase = opeivaretbase - opeiva
            'opeisrbase = opeisrbase - opeisr
            'opeiepsbase = opeiepsbase - opeieps
            'opeiva0base = opeiva0base - opeiva0

            .WriteStartElement("pago20:Pagos")
            .WriteAttributeString("Version", "2.0")
            .WriteAttributeString("xmlns:pago20", "http://www.sat.gob.mx/Pagos20")

            .WriteStartElement("pago20:Totales")
            .WriteAttributeString("MontoTotalPagos", Replace(FormatNumber(frmMultiParcialidades.txtMontoPar.Text, 2), ",", "")) '.WriteAttributeString("MontoTotalPagos", "100.00")

            If CDec(opeiva) > 0 Then
                .WriteAttributeString("TotalTrasladosBaseIVA16", Replace(opeivabase + opeieps, ",", "")) '.WriteAttributeString("TotalTrasladosBaseIVA16", "86.21")
                .WriteAttributeString("TotalTrasladosImpuestoIVA16", Replace(opeiva, ",", "")) '.WriteAttributeString("TotalTrasladosImpuestoIVA16", "13.79")
            End If

            If CDec(opeiva0) > 0 Then
                .WriteAttributeString("TotalTrasladosBaseIVA0", Replace(opeiva0base, ",", "")) '.WriteAttributeString("TotalTrasladosBaseIVA16", "86.21")
                .WriteAttributeString("TotalTrasladosImpuestoIVA0", Replace("0", ",", "")) '.WriteAttributeString("TotalTrasladosImpuestoIVA16", "13.79")
            End If

            If CDec(opeieps) > 0 Then
                .WriteAttributeString("TotalRetencionesIEPS", Replace(opeieps, ",", ""))
            End If

            If CDec(opeivaret) > 0 Then
                .WriteAttributeString("TotalRetencionesIVA", Replace(opeivaret, ",", ""))
            End If

            If CDec(opeisr) > 0 Then
                .WriteAttributeString("TotalRetencionesISR", Replace(opeisr, ",", ""))
            End If

            .WriteEndElement() ' fin TOTALES

            .WriteStartElement("pago20:Pago")

            If NumCtaCliente <> "" Then
                .WriteAttributeString("CtaBeneficiario", NumCtaCliente)
            End If

            If CtaRFCCli <> "" Then
                .WriteAttributeString("RfcEmisorCtaBen", CtaRFCCli)
            End If

            If NumCta <> "" Then
                .WriteAttributeString("CtaOrdenante", NumCta)
            End If

            If Banco <> "" Then
                ' .WriteAttributeString("NomBancoOrdExt", Banco)
            End If

            If CtaRFCEmi <> "" Then
                .WriteAttributeString("RfcEmisorCtaOrd", CtaRFCEmi)
            End If

            If NumOpe <> "" Then
                .WriteAttributeString("NumOperacion", NumOpe)
            End If

            .WriteAttributeString("Monto", Replace(FormatNumber(MontoPar, 2), ",", ""))
            .WriteAttributeString("MonedaP", "MXN")
            .WriteAttributeString("FormaDePagoP", FormaPagoPar)
            .WriteAttributeString("FechaPago", fechaFormateada2)
            .WriteAttributeString("TipoCambioP", "1")


            For i = 0 To frmMultiParcialidades.GridParcialidades.RowCount - 2
                .WriteStartElement("pago20:DoctoRelacionado")
                .WriteAttributeString("Folio", dgv.Rows(i).Cells(0).Value.ToString)
                .WriteAttributeString("ImpSaldoInsoluto", Replace(FormatNumber(dgv.Rows(i).Cells(3).Value.ToString, 2), ",", ""))
                .WriteAttributeString("ImpPagado", Replace(FormatNumber(dgv.Rows(i).Cells(2).Value.ToString, 2), ",", ""))
                .WriteAttributeString("ImpSaldoAnt", Replace(FormatNumber(dgv.Rows(i).Cells(1).Value.ToString, 2), ",", ""))
                .WriteAttributeString("NumParcialidad", dgv.Rows(i).Cells(4).Value.ToString)
                '.WriteAttributeString("MetodoDePagoDR", dgv.Rows(i).Cells(5).Value.ToString)
                .WriteAttributeString("MonedaDR", "MXN")
                If dgv.Rows(i).Cells(7).Value.ToString <> "" Then
                    .WriteAttributeString("Serie", dgv.Rows(i).Cells(7).Value.ToString)
                End If
                '.WriteAttributeString("Serie", SeriePar)
                .WriteAttributeString("IdDocumento", dgv.Rows(i).Cells(8).Value.ToString)
                .WriteAttributeString("EquivalenciaDR", "1")
                .WriteAttributeString("ObjetoImpDR", "02")

                If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                    .WriteStartElement("pago20:ImpuestosDR")

                    If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Then

                        .WriteStartElement("pago20:RetencionesDR")

                        If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString > 0 Then
                            'iva retenido
                            .WriteStartElement("pago20:RetencionDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(43).Value.ToString) '- CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)
                            'newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) - CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(10).Value.ToString, ",", ""))
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", frmMultiParcialidades.GridParcialidades.Rows(i).Cells(15).Value.ToString)
                            '.WriteAttributeString("TasaOCuotaDR", "0.040000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin retencion dr

                        End If

                        If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString > 0 Then
                            'isr
                            .WriteStartElement("pago20:RetencionDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(42).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(12).Value.ToString, ",", ""))
                            .WriteAttributeString("ImpuestoDR", "001")
                            .WriteAttributeString("TasaOCuotaDR", frmMultiParcialidades.GridParcialidades.Rows(i).Cells(14).Value.ToString)
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin retencion dr

                        End If

                        If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(11).Value.ToString > 0 Then
                            'ieps

                            Dim str As String = ""
                            Dim str1(15) As String
                            Dim contarray As Integer = 0
                            For x = 1 To Len(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(16).Value.ToString)
                                str = Mid$(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(16).Value.ToString, x, 1)
                                If str = "," Then
                                    contarray = contarray + 1
                                Else
                                    str1(contarray) = str1(contarray) & str
                                End If
                            Next

                            Dim totalbaseieps As Double = 0
                            totalbaseieps = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(29).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(30).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(31).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(32).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(33).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(34).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(35).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(37).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(38).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(39).Value.ToString) + CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(40).Value.ToString)

                            For x1 = 0 To contarray

                                .WriteStartElement("pago20:RetencionDR")

                                Dim newbase As Double = 0

                                Select Case Trim(str1(x1))
                                    Case "0.030000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(40).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.03
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.060000"
                                        'newbase = FormatNumber(CDec(100 * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(39).Value.ToString)) / totalbaseieps, 2)
                                        'newbase = FormatNumber(CDec(newbase * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString)) / 100, 2)
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(39).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.06
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.070000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(38).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.07
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.080000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(37).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.08
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.090000"
                                        'newbase = FormatNumber(CDec(100 * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString)) / totalbaseieps, 2)
                                        'newbase = FormatNumber(CDec(newbase * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString)) / 100, 2)
                                        'newbase = newbase / 1.09
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(36).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.09
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.250000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(35).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.25
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.265000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(34).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.265
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.300000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(33).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.3
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.304000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(32).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.304
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.500000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(31).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.5
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "0.530000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(30).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 0.53
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                    Case "1.600000"
                                        newbase = FormatNumber(CDec(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) * CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(29).Value.ToString)) / CDec(frmMultiParcialidades.TotalFact), 6)
                                        .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                                        Dim newimporte As Double = 0
                                        newimporte = FormatNumber(newbase, 6) * 2.6
                                        .WriteAttributeString("ImporteDR", Replace(FormatNumber(newimporte, 6), ",", ""))
                                End Select

                                .WriteAttributeString("ImpuestoDR", "003")
                                .WriteAttributeString("TasaOCuotaDR", Trim(str1(x1)))
                                .WriteAttributeString("TipoFactorDR", "Tasa")

                                .WriteEndElement() ' fin retencion dr

                            Next

                        End If

                        .WriteEndElement() ' fin retenciones dr

                    End If

                    If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Or frmMultiParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                        .WriteStartElement("pago20:TrasladosDR")

                        If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString > 0 Then

                            .WriteStartElement("pago20:TrasladoDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(41).Value.ToString) '- CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)
                            'newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(2).Value.ToString) - CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase + opeieps, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", Replace(FormatNumber(CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(9).Value.ToString), 2), ",", ""))
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", "0.160000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin traslado dr

                        End If

                        If frmMultiParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString > 0 Then

                            .WriteStartElement("pago20:TrasladoDR")

                            Dim newbase As Double = 0
                            newbase = CDec(frmMultiParcialidades.GridParcialidades.Rows(i).Cells(13).Value.ToString)

                            .WriteAttributeString("BaseDR", Replace(FormatNumber(newbase, 6), ",", ""))
                            .WriteAttributeString("ImporteDR", "0.00")
                            .WriteAttributeString("ImpuestoDR", "002")
                            .WriteAttributeString("TasaOCuotaDR", "0.000000")
                            .WriteAttributeString("TipoFactorDR", "Tasa")

                            .WriteEndElement() ' fin traslado dr

                        End If

                        .WriteEndElement() ' fin traslados dr

                    End If

                    .WriteEndElement() ' fin impuestos dr

                End If

                .WriteEndElement() ' fin documento relacionado
            Next

            .WriteStartElement("pago20:ImpuestosP")

            If opeivaret > 0 Or opeisr > 0 Or opeieps > 0 Then

                .WriteStartElement("pago20:RetencionesP")

                If opeivaret > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeivaret, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "002")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If

                If opeisr > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeisr, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "001")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If

                If opeieps > 0 Then
                    .WriteStartElement("pago20:RetencionP")

                    '.WriteAttributeString("BaseP", opeivaretbase)
                    .WriteAttributeString("ImporteP", Replace(FormatNumber(opeieps, 2), ",", ""))
                    .WriteAttributeString("ImpuestoP", "003")
                    '.WriteAttributeString("TasaOCuotaP", "0.040000")
                    '.WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin Retencion dr
                End If

                .WriteEndElement() ' fin Retenciones dr

            End If

            If opeiva > 0 Then
                .WriteStartElement("pago20:TrasladosP")

                .WriteStartElement("pago20:TrasladoP")

                .WriteAttributeString("BaseP", Replace(opeivabase + opeieps, ",", ""))
                .WriteAttributeString("ImporteP", Replace(FormatNumber(opeiva, 2), ",", ""))
                .WriteAttributeString("ImpuestoP", "002")
                .WriteAttributeString("TasaOCuotaP", "0.160000")
                .WriteAttributeString("TipoFactorP", "Tasa")

                .WriteEndElement() ' fin traslado dr

                If opeiva0 > 0 Then
                    .WriteStartElement("pago20:TrasladoP")

                    .WriteAttributeString("BaseP", Replace(opeiva0, ",", ""))
                    .WriteAttributeString("ImporteP", "0.00")
                    .WriteAttributeString("ImpuestoP", "002")
                    .WriteAttributeString("TasaOCuotaP", "0.000000")
                    .WriteAttributeString("TipoFactorP", "Tasa")

                    .WriteEndElement() ' fin traslado dr

                End If

                .WriteEndElement() ' fin traslados dr

            End If

            If opeiva0 > 0 And opeiva <= 0 Then
                .WriteStartElement("pago20:TrasladosP")

                .WriteStartElement("pago20:TrasladoP")

                .WriteAttributeString("BaseP", Replace(opeiva0, ",", ""))
                .WriteAttributeString("ImporteP", "0.00")
                .WriteAttributeString("ImpuestoP", "002")
                .WriteAttributeString("TasaOCuotaP", "0.000000")
                .WriteAttributeString("TipoFactorP", "Tasa")

                .WriteEndElement() ' fin traslado dr

                .WriteEndElement() ' fin traslados dr

            End If


            .WriteEndElement() ' fin impuestos P

            .WriteEndElement() ' fin pagos

            .WriteEndElement() ' fin complemento

            .WriteEndElement() ' fin comprobante

            .Flush()
            .Close()
            Console.ReadLine()
        End With

        '============================= TERMINA EL XML

        xmldoc.Load("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)
        Dim Elemento As Xml.XmlElement = xmldoc.DocumentElement
        Dim Oxml As String
        Oxml = xmldoc.DocumentElement.InnerXml

        Dim no_csd_emp As String = ""

        Dim R
        R = Elemento.InnerXml

        xmldoc.Save("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\Temporales\" & nombreCFD)

        '================================= termina xml base3

        Dim folio_sat_uuid As String = ""
        Dim fecha_folio_sat As String = ""
        Dim cadena_orig As String = ""

        Dim sello_emisor As String = ""
        Dim sello_sat As String = ""
        Dim certificado_sat As String = ""

        Dim varSello As String = ""
        Dim varNoCert As String = ""
        Dim varCertificado As String = ""
        Dim varUuid As String = ""
        Dim varSelloSat As String = ""
        Dim varSelloCFD As String = ""
        Dim varNoCertSat As String = ""
        Dim varFechatim As String = ""

        frmMultiParcialidades.ProgressBar1.Value = 60
        frmMultiParcialidades.lbl_proceso.Text = "Creando XML Timbrado ..."
        My.Application.DoEvents()
        If timbre_Par1(FolioFact, serie, "P" & FolioPar, folio_sat_uuid, fecha_folio_sat, newcarpeta, EmiRFC, cadena_orig, no_csd_emp, certificado_sat) Then

            crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\PARCIALIDADES\")

            Dim Lector As System.Xml.XmlTextReader = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)

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
                                        Case "UUID"
                                            varUuid = Lector.Value
                                        Case "SelloCFD"
                                            varSelloCFD = Lector.Value
                                        Case "NoCertificadoSAT"
                                            varNoCertSat = Lector.Value
                                        Case "SelloSAT"
                                            varSelloSat = Lector.Value
                                        Case "FechaTimbrado"
                                            varFechatim = Lector.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop


            Dim Lector1 As System.Xml.XmlTextReader = New System.Xml.XmlTextReader("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & newcarpeta & "\XML\PARCIALIDADES\" & nombreCFD)

            Do While (Lector1.Read())
                Select Case Lector1.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.
                        If Lector1.Name = "cfdi:Comprobante" Then
                            If Lector1.HasAttributes Then
                                While Lector1.MoveToNextAttribute()
                                    'Mostrar valor y nombre del atributo
                                    Select Case Lector1.Name
                                        Case "Sello"
                                            varSello = Lector1.Value
                                        Case "NoCertificado"
                                            varNoCert = Lector1.Value
                                        Case "Certificado"
                                            varCertificado = Lector1.Value
                                    End Select
                                End While
                            End If
                        End If
                End Select
            Loop

            frmMultiParcialidades.ProgressBar1.Value = 70
            frmMultiParcialidades.lbl_proceso.Text = "Guardando Datos Factura ..."
            My.Application.DoEvents()
            actualizaParcialidad1(varUuid, varSello, varNoCert, varCertificado, varSelloCFD, varNoCertSat, varSelloSat, varFechatim, IDParci, cadena_orig)

            frmMultiParcialidades.ProgressBar1.Value = 75

            frmMultiParcialidades.lbl_proceso.Text = "Generando Qr ..."
            My.Application.DoEvents()

            ima_qrpar(EmiRFC, CliRFC, MontoPar, folio_sat_uuid, FolioPar, newcarpeta)
            Return True

        Else
            Return False
        End If

    End Function

    Public Function timbre_Par1(ByVal folioFact As String, ByVal serie As String, ByVal folio As String, ByRef folio_uudi As String, ByRef fecha_sat As String, ByVal razon_social As String, ByVal frcemisor As String, ByRef cadenao As String, ByRef certificado As String, ByRef certificaco_sat As String)
        Dim x As Boolean = False
        If frcemisor = "AAA010101AAA" Or frcemisor = "IIA040805DZ4" Then
            x = False
        Else
            x = True
        End If

        Dim conector As New Profact.TimbraCFDI40.Conector(x)
        Dim idError As Integer
        Dim NError As String
        Dim uuid As String
        Dim xmlTimbrado As String

        Dim id As String
        Dim documentoXml As XmlDocument
        Dim nombreCFD As String = ""

        nombreCFD = folio & ".xml"

        documentoXml = New XmlDocument
        id = folio
        'id = serie & folio

        crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\PARCIALIDADES\")
        documentoXml.Load("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD)

        Try
            'Este ejemplo está dirigido a aquellos integradores que ya generan el xml (CFDI) y solo desean timbrarlo

            'Inicializamos el conector' el parámetro indica el ambiente en el que se utilizará 
            'Fasle = Ambiente de pruebas
            'True = Ambiente de producción

            'Establecemos las credenciales para el permiso de conexión
            'Ambiente de pruebas = mvpNUXmQfK8=
            'Ambiente de producción = Esta será asignado por el proveedor al salir a productivo
            If frcemisor = "AAA010101AAA" Or frcemisor = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")

            End If

            'Ruta del archivo a timbrar
            Dim rutaArchivo As String = "C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\Temporales\" & nombreCFD
            'Timbramos el CFDI por medio del conector y guardamos resultado'
            Dim resultadoTimbre As Profact.TimbraCFDI.ResultadoTimbre
            resultadoTimbre = conector.TimbraCFDI(rutaArchivo)
            crea_dir("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\cd\PARCIALIDADES\")
            'Verificamos el resultado
            If (resultadoTimbre.Exitoso) Then

                'El comprobante fue timbrado exitosamente

                'Guardamos xml cfdi
                If (resultadoTimbre.GuardaXml("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\XML\PARCIALIDADES\", nombreCFD)) Then
                    '     MessageBox.Show("El xml fue guardado correctamente")
                Else
                    MessageBox.Show("Ocurrió un error al guardar el comprobante")
                End If

                'Los siguientes datos deberán ir en la respresentación impresa ó PDF

                '  1.- Código bidimensional folio & "-" & folioFact
                'If (resultadoTimbre.GuardaCodigoBidimensional("C:\ControlNegociosV2022\ARCHIVOSDL" & varnumbase & "\" & Replace(razon_social, Chr(34), "").ToString & "\cd\PARCIALIDADES\", folio)) Then

                If (resultadoTimbre.GuardaCodigoBidimensional("C:\ControlNegociosPro\ARCHIVOSDL" & varnumbase & "\" & razon_social & "\cd\PARCIALIDADES\", folio)) Then
                    ' MessageBox.Show("El código bidimensional fue guardado correctamente")
                Else
                    '  MessageBox.Show("Ocurrió un error al guardar el código bidimensional")
                End If

                '2.- Folio fiscal
                Dim foliFiscal As String = "" ' resultadoTimbre.FolioUUID

                '3.- No. Certificado del Emisor
                Dim noCertificado As String = "" ' resultadoTimbre.No_Certificado

                '4.- No. Certificado del SAT
                Dim noCertificadoSat As String = "" ' resultadoTimbre.No_Certificado_SAT

                '5.- Fecha y Hora de certificación
                Dim fechaCert As String = "" ' resultadoTimbre.FechaCertificacion


                '6.- Sello del cfdi
                Dim selloCFDI As String = "" ' resultadoTimbre.SelloCFDI

                '7.- Sello del SAT
                Dim selloSAT As String = "" 'resultadoTimbre.SelloSAT

                '8.- Cadena original de complemento de certificación
                Dim cadena As String = resultadoTimbre.CadenaTimbre

                '   MessageBox.Show("Timbrado Exitoso")

                folio_uudi = foliFiscal
                fecha_sat = fechaCert
                cadenao = cadena
                certificado = noCertificado
                certificaco_sat = noCertificadoSat
                actualiza_timbres(frcemisor)
            Else
                'No se pudo timbrar, mostramos respuesta
                MessageBox.Show(resultadoTimbre.Descripcion)
                MessageBox.Show(resultadoTimbre.Detalle)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error: " & NError & "- " & ex.Message)
            envio(frmfacturacion.Text_Email.Text, "ERROR EN FACTURA", "SU PETICION NO PUDO SER GENERADA, EXISTE UN ERROR EN LOS DATOS. " & "Error: " & NError & "- " & ex.Message, "", "")
            Return False
        End Try
        Return True

    End Function
    Private Sub actualizaParcialidad1(ByVal uuid As String, ByVal sello As String, ByVal NoCert As String, ByVal certif As String, ByVal SelloCFD As String, ByVal NoCertSat As String,
                                ByVal selloSat As String, ByRef FechaTimbrado As String, ByRef IdPar As String, ByRef cadena As String)

        Dim sinfo As String = ""
        Dim sSQL As String = "update ParcialidadesMulti set Certificado ='" & certif & "', UUID='" & uuid & "', Sello='" & sello & "',NoCert='" & NoCert & "',SelloCFD='" &
                                SelloCFD & "',NoCertSat='" & NoCertSat & "',SelloSat='" & selloSat & "',FechaTimbrado='" & FechaTimbrado & "', CadenaOriginal = '" & cadena & "' where Id =" & IdPar & ""

        Dim cnn As MySqlClient.MySqlConnection = New MySqlClient.MySqlConnection
        Dim odata As New ToolKitSQL.myssql
        If odata.dbOpen(cnn, sTarget, sinfo) Then
            If odata.runSp(cnn, sSQL, sinfo) Then
            Else
            End If
            cnn.Close()
        End If

    End Sub

End Module
