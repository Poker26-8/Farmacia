Imports System.IO
Imports Profact.TimbraCFDI40

Imports MySql.Data.MySqlClient
'Imports Profact.TimbraCFDI.wsReference.TimbradoSoapClient
'Imports Profact.TimbraCFDI.wsReference33.TimbradoSoapClient



Public Class frmConfigs
    Dim focotamaeti As Integer = 0
    Private Sub frmConfigs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SFormatos("IMG_PDF", "")

        Try
            cnn1.Close()
            cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from loginrecargas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                txtnumero.Text = rd1("numero").ToString
                txtusuario.Text = rd1("usuario").ToString
                txtcontra.Text = rd1("password").ToString
                lblid.Text = rd1("id").ToString
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

        Try
            Dim tipo_logo As String = ""
            Dim tipo_impresora As String = ""
            Dim nLogo As String = ""
            Dim nlogoeti As String = ""
            Dim medeti As String = "2
"
            If PrimeraConfig = "" Then
                tabFormatos.Focus().Equals(True)
                tabFormatos.Select()
            End If

            cnn4.Close() : cnn4.Open()

            'Costeo (una única vez)
            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select NumPart from Formatos where Facturas='Costeo'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = 1 Then
                        boxCosteo.Enabled = False
                        If rd4(0).ToString() = "PEPS" Then
                            optPEPS.Checked = True
                        Else
                            optPromedio.Checked = True
                        End If
                    End If
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand()
            cmd4.CommandText =
                 "select NumPart from Formatos where Facturas='CodAutoma'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = 1 Then
                        chkCodAuto.Checked = True
                        chkCodAuto.Enabled = False
                    Else
                        chkCodAuto.Checked = False
                        chkCodAuto.Enabled = True
                    End If
                End If
            End If
            rd4.Close()

            Dim linkau As String = ""
            Dim auto As Integer = 0

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='AutoFac'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    auto = rd4(0).ToString

                    If auto = 1 Then
                        chkautofacturas.Checked = True
                    Else
                        chkautofacturas.Checked = False
                    End If
                End If
            End If
            rd4.Close()

            If (chkautofacturas.Checked) Then
                pauto.Visible = True
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='LinkAuto'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        txtlink.Text = rd4(0).ToString
                    End If
                End If
                rd4.Close()

            End If

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select NumPart from Formatos where Facturas='Series'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = 1 Then
                        chkSeries.Checked = True
                        chkSeries.Enabled = False
                    Else
                        chkSeries.Checked = False
                        chkSeries.Enabled = True
                    End If
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select NumPart from Formatos where Facturas='Partes'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = 1 Then
                        chkPartes.Checked = True
                        chkPartes.Enabled = False
                    Else
                        chkPartes.Checked = False
                        chkPartes.Enabled = True
                    End If
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='MinimoA'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        chkMinAlmacen.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        chkMinAlmacen.Checked = False
                    End If
                End If
            Else
                chkMinAlmacen.Checked = False
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='Desc_Ventas'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        chkDesc_Ventas.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        chkDesc_Ventas.Checked = False
                    End If
                End If
            Else
                chkDesc_Ventas.Checked = False
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='Acumula'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        chkAcumula.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        chkAcumula.Checked = False
                    End If
                End If
            Else
                chkAcumula.Checked = False
            End If
            rd4.Close()


            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='Franquicia'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        chkFranquicia.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        chkFranquicia.Checked = False
                    Else
                        chkFranquicia.Checked = False
                    End If
                End If
            Else
                chkFranquicia.Checked = False
            End If
            rd4.Close()


            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "SELECT NoPrintCom FROM ticket"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        cbOrdenEntrega.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        cbOrdenEntrega.Checked = False
                    Else
                        cbOrdenEntrega.Checked = False
                    End If
                End If
            Else
                cbOrdenEntrega.Checked = False
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='Desglosa'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString() = "1" Then
                        chkDesglosa.Checked = True
                    ElseIf rd4(0).ToString() = "0" Then
                        chkDesglosa.Checked = False
                    End If
                End If
            Else
                chkDesglosa.Checked = False
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='LogoG'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    nLogo = rd4(0).ToString
                End If
            Else
                nLogo = ""
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='ImpreT'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    cboImpTickets.Text = rd4(0).ToString
                    If cboImpTickets.Text <> "" Then
                        boxTickets.Enabled = True
                    Else
                        boxTickets.Enabled = False
                    End If
                End If
            Else
                cboImpTickets.Text = ""
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='TipoLogo'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    tipo_logo = rd4(0).ToString
                    If tipo_logo = "SIN" Then
                        optnada.Checked = True
                    ElseIf tipo_logo = "RECT" Then
                        optrecta.Checked = True
                    ElseIf tipo_logo = "CUAD" Then
                        optcuadra.Checked = True
                    Else
                        optnada.Checked = True
                    End If

                    If tipo_logo <> "SIN" Then
                        If File.Exists(My.Application.Info.DirectoryPath & "\" & nLogo) Then
                            picLogo.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nLogo)
                        End If
                    End If
                End If
            End If
            rd4.Close()

            Dim logofractura As String = ""

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT emi_logo FROM DatosNegocio"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    logofractura = rd4(0).ToString
                End If
            End If
            rd4.Close()

            If logofractura <> "" Then
                picLogoFact.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\" & logofractura)
            End If

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='LogoE'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    nlogoeti = rd4(0).ToString

                    If File.Exists(My.Application.Info.DirectoryPath & "\" & nlogoeti) Then
                        picEtiq.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & nlogoeti)
                    End If

                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Medida_Eti'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    medeti = rd4(0).ToString

                    If medeti = "6.5x2.7" Then
                        optEM_65x27.Checked = True
                    ElseIf medeti = "2x4" Then
                        optEM_2x4.Checked = True
                    ElseIf medeti = "5x2.5" Then
                        optEM_5x25.Checked = True
                    ElseIf medeti = "5x3" Then
                        optEM5X3.Checked = True
                    Else
                        optEM_65x27.Checked = False
                        optEM_2x4.Checked = False
                        optEM_5x25.Checked = False

                    End If


                End If
            End If
            rd4.Close()

            Dim tamlogo As String = ""


            cmd4 = cnn4.CreateCommand
            cmd4.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='OriLogoE'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    tamlogo = rd4(0).ToString

                    If tamlogo = "S/ETI" Then
                        optE_Sin.Checked = True
                    ElseIf tamlogo = "ARRIBA" Then
                        optE_Arriba.Checked = True
                    ElseIf tamlogo = "IZQUIERDA" Then
                        optE_Izquierda.Checked = True
                    ElseIf tamlogo = "DERECHA" Then
                        optE_Derecha.Checked = True
                    End If

                End If
                End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    tipo_impresora = rd4(0).ToString()
                    If tipo_impresora = "80" Then
                        opt80.Checked = True
                    Else
                        opt58.Checked = True
                    End If
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select * from Ticket"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    optPregunta.Checked = rd4("NoPrint").ToString()
                    txtCopias.Text = rd4("Copias").ToString()
                    txtrazon.Text = rd4("Cab0").ToString()
                    txtrfc.Text = rd4("Cab1").ToString()
                    txtcalle.Text = rd4("Cab2").ToString()
                    txtcolonia.Text = rd4("Cab3").ToString()
                    txtdeleg.Text = rd4("Cab4").ToString()
                    txttel.Text = rd4("Cab5").ToString()
                    txtcorreo.Text = rd4("Cab6").ToString()
                    txtPdomicilio.Text = rd4("Pie1").ToString()
                    txtPcotiza.Text = rd4("Pie2").ToString()
                    'txtPagare.Text = rd4("Pagare").ToString()
                    'txtC1.Text = rd4("C1").ToString()
                    'txtC2.Text = rd4("C2").ToString()
                    'txtC3.Text = rd4("C3").ToString()
                    'txtC4.Text = rd4("C4").ToString()
                    'txtC5.Text = rd4("C5").ToString()
                    'txtC6.Text = rd4("C6").ToString()
                    'txtC7.Text = rd4("C7").ToString()
                    'txtC8.Text = rd4("C8").ToString()
                    'txtC9.Text = rd4("C9").ToString()
                    'txtC10.Text = rd4("C10").ToString()
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select NotasCred from Formatos where Facturas='TipoPrecio'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    If rd4(0).ToString = "NORMAL" Then
                        optPrecioFijo.Checked = True
                    End If
                    If rd4(0).ToString = "DIANOCHE" Then
                        optDiaNoche.Checked = True
                    End If
                End If
            End If                  '
            rd4.Close() : cnn4.Close()

            'Ticket
            'Esto va a ser por máquina/IP
            Dim equipo As String = ObtenerNombreEquipo()

            Try
                cnn5.Close() : cnn5.Open()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select Formato from RutasImpresion where Equipo='" & equipo & "' and Tipo='Venta'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cboventas.Text = rd5(0).ToString()
                    End If
                End If
                rd5.Close()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select Formato from RutasImpresion where Equipo='" & equipo & "' and Tipo='Cotiza'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cbocotiza.Text = rd5(0).ToString()
                    End If
                End If
                rd5.Close()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select Formato from RutasImpresion where Equipo='" & equipo & "' and Tipo='Compras'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cbocompras.Text = rd5(0).ToString()
                    End If
                End If
                rd5.Close()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & equipo & "' and Tipo='TICKET'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cboImpTickets.Text = rd5(0).ToString()
                    End If
                End If
                rd5.Close()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & equipo & "' and Tipo='CARTA'"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cboImpCarta.Text = rd5(0).ToString()
                    End If
                End If
                rd5.Close()
                cnn5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn5.Close()
            End Try

            'Moneda
            txtmoneda.Text = DatosRecarga("Moneda")
            txtsimbolo.Text = DatosRecarga("Simbolo")
            txtabrevia.Text = DatosRecarga("Abreviatura")
            txtmax_descu.Text = DatosRecarga("Mdescuento")

            'Correo
            cboproveedor.Text = DatosRecarga("PROVE_Ser")
            txtsmtp.Text = DatosRecarga("Server_SMTP")
            txtpuerto.Text = DatosRecarga("Pto_Mail")
            txtcorreo_ef.Text = DatosRecarga("Mail_Emi")
            txtcontra_correo.Text = DatosRecarga("Shibboleth_ML")
            txtcontra_correo2.Text = txtcontra_correo.Text
            chkssl.Checked = IIf(DatosRecarga("SSL") = "", False, DatosRecarga("SSL"))
            chksmtp.Checked = IIf(DatosRecarga("Aute_Server_SMTP") = "", False, DatosRecarga("Aute_Server_SMTP"))
            chkenvioauto.Checked = IIf(DatosRecarga("ENV_DOC") = "", False, DatosRecarga("ENV_DOC"))

            'CFDI
            txtSerie_Fac.Text = DatosRecarga("SERIE_FACT_EL")
            txtSerie_Not.Text = DatosRecarga("SERIE_NC_EL")
            txtFolioI_Fact.Text = DatosRecarga("FOLIOfacINI")
            txtFolioF_Fact.Text = DatosRecarga("FOLIOfacFIN")
            txtFolioI_Not.Text = DatosRecarga("FolioNtaCredIni")
            txtContra1.Text = DatosRecarga("SHIBBOLETH")
            txtContra2.Text = DatosRecarga("SHIBBOLETH")
            txtcertificado.Text = My.Application.Info.DirectoryPath & "\BinData\" & DatosRecarga("FILE_CERT")
            txtllave.Text = My.Application.Info.DirectoryPath & "\BinData\" & DatosRecarga("FILE_KEY")


            'cnn4.Close() : cnn4.Open()
            'cmd4 = cnn4.CreateCommand
            'cmd4.CommandText = "SELECT * FROM DatosNegocio"
            'rd4 = cmd4.ExecuteReader
            'If rd4.Read Then
            '    If rd4.HasRows Then
            '        txtdescripcion.Text = rd4("Em_Actividad").ToString
            '        cborazon_social.Text = rd4("Em_RazonSocial").ToString
            '        txtRFC_fact.Text = rd4("Em_rfc").ToString
            '        txtcalle_fact.Text = rd4("Em_calle").ToString
            '        txtn_exterior.Text = rd4("Em_NumExterior").ToString
            '        txtn_interior.Text = rd4("Em_NumInterior").ToString
            '        txtcolonia_fact.Text = rd4("Em_colonia").ToString
            '        txtcp_fact.Text = rd4("Em_CP").ToString
            '        txtdelegacion_fact.Text = rd4("Em_Municipio").ToString
            '        txtentidad_fact.Text = rd4("Em_Estado").ToString
            '        cbopais_fact.Text = rd4("Em_Pais").ToString
            '        txtcorreo_fact.Text = rd4("Em_mail").ToString
            '        txttelefono_fact.Text = rd4("Em_Tel").ToString
            '        cboregfis.Text = rd4("Em_RFiscal").ToString
            '        txtnombre_comercial.Text = rd4("Em_NombreNegocio").ToString

            '    End If
            'End If
            'rd4.Close()
            'cnn4.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub
    Private Sub Insert_Configs()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sSql) Then
                If .runSp(a_cnn, "update Ticket set Cab0='" & txtrazon.Text & "', Cab1='" & txtrfc.Text & "', Cab2='" & txtcalle.Text & "', Cab3='" & txtcolonia.Text & "', Cab4='" & txtdeleg.Text & "', Cab5='" & txttel.Text & "', Cab6='" & txtcorreo.Text & "'", sSql) Then
                    sSql = ""
                End If
                a_cnn.Close()
            End If
            If sSql <> "" Then
                MsgBox("Ocurrió un error." & vbNewLine & sSql, vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            End If
        End With
    End Sub

    Private Sub btnGuardaFormatos_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardaFormatos.Click
        If MsgBox("¿Deseas guardar estos datos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Ticket set Cab0='" & txtrazon.Text & "', Cab1='" & txtrfc.Text & "', Cab2='" & txtcalle.Text & "', Cab3='" & txtcolonia.Text & "', Cab4='" & txtdeleg.Text & "', Cab5='" & txttel.Text & "', Cab6='" & txtcorreo.Text & "', Pie1='" & txtPdomicilio.Text & "', Pie2='" & txtPcotiza.Text & "', Copias=" & IIf(txtCopias.Text = "", 0, txtCopias.Text)
                cmd1.ExecuteNonQuery()

                Insert_Configs()

                'Formato de ventas
                If cboventas.Text <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Venta'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            'Existe y actualiza
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update RutasImpresion set Formato='" & cboventas.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Venta'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        End If
                    Else
                        'No existe e inserta
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into RutasImpresion(Equipo,Tipo,Formato,Impresora) values('" & ObtenerNombreEquipo() & "','Venta','" & cboventas.Text & "','')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                End If

                'Forrmato de compras
                If cbocompras.Text <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Compras'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            'Existe y actualiza
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update RutasImpresion set Formato='" & cbocompras.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Compras'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        End If
                    Else
                        'No existe e inserta
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into RutasImpresion(Equipo,Tipo,Formato,Impresora) values('" & ObtenerNombreEquipo() & "','Compras','" & cbocompras.Text & "','')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                End If

                'Formato de cotizaciones y pedidos
                If cbocotiza.Text <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Cotiza'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            'Existe y actualiza
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "update RutasImpresion set Formato='" & cbocotiza.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Cotiza'"
                            cmd2.ExecuteNonQuery()
                            cnn2.Close()
                        End If
                    Else
                        'No existe e inserta
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "insert into RutasImpresion(Equipo,Tipo,Formato,Impresora) values('" & ObtenerNombreEquipo() & "','Cotiza','" & cbocotiza.Text & "','')"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                    rd1.Close()
                End If

                cnn1.Close()
                MsgBox("Datos actualizados.", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub optPregunta_Click(sender As Object, e As System.EventArgs) Handles optPregunta.Click
        Dim valor As Integer = 0
        If (optPregunta.Checked) Then
            valor = 1
        Else
            valor = 0
        End If
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "update Ticket set NoPrint=" & valor
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtrazon_Click(sender As Object, e As System.EventArgs) Handles txtrazon.Click
        txtrazon.SelectionStart = 0
        txtrazon.SelectionLength = Len(txtrazon.Text)
    End Sub

    Private Sub txtrazon_GotFocus(sender As Object, e As System.EventArgs) Handles txtrazon.GotFocus
        txtrazon.SelectionStart = 0
        txtrazon.SelectionLength = Len(txtrazon.Text)
    End Sub

    Private Sub txtrazon_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrazon.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtrfc.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtrfc_Click(sender As Object, e As System.EventArgs) Handles txtrfc.Click
        txtrfc.SelectionStart = 0
        txtrfc.SelectionLength = Len(txtrfc.Text)
    End Sub

    Private Sub txtrfc_GotFocus(sender As Object, e As System.EventArgs) Handles txtrfc.GotFocus
        txtrfc.SelectionStart = 0
        txtrfc.SelectionLength = Len(txtrfc.Text)
    End Sub

    Private Sub txtrfc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtrfc.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcalle.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcalle_Click(sender As Object, e As System.EventArgs) Handles txtcalle.Click
        txtcalle.SelectionStart = 0
        txtcalle.SelectionLength = Len(txtcalle.Text)
    End Sub

    Private Sub txtcalle_GotFocus(sender As Object, e As System.EventArgs) Handles txtcalle.GotFocus
        txtcalle.SelectionStart = 0
        txtcalle.SelectionLength = Len(txtcalle.Text)
    End Sub

    Private Sub txtcalle_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcalle.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolonia.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcolonia_Click(sender As Object, e As System.EventArgs) Handles txtcolonia.Click
        txtcolonia.SelectionStart = 0
        txtcolonia.SelectionLength = Len(txtcolonia.Text)
    End Sub

    Private Sub txtcolonia_GotFocus(sender As Object, e As System.EventArgs) Handles txtcolonia.GotFocus
        txtcolonia.SelectionStart = 0
        txtcolonia.SelectionLength = Len(txtcolonia.Text)
    End Sub

    Private Sub txtcolonia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcolonia.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdeleg.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdeleg_Click(sender As Object, e As System.EventArgs) Handles txtdeleg.Click
        txtdeleg.SelectionStart = 0
        txtdeleg.SelectionLength = Len(txtdeleg.Text)
    End Sub

    Private Sub txtdeleg_GotFocus(sender As Object, e As System.EventArgs) Handles txtdeleg.GotFocus
        txtdeleg.SelectionStart = 0
        txtdeleg.SelectionLength = Len(txtdeleg.Text)
    End Sub

    Private Sub txtdeleg_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdeleg.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txttel.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttel_Click(sender As Object, e As System.EventArgs) Handles txttel.Click
        txttel.SelectionStart = 0
        txttel.SelectionLength = Len(txttel.Text)
    End Sub

    Private Sub txttel_GotFocus(sender As Object, e As System.EventArgs) Handles txttel.GotFocus
        txttel.SelectionStart = 0
        txttel.SelectionLength = Len(txttel.Text)
    End Sub

    Private Sub txttel_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttel.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcorreo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcorreo_Click(sender As Object, e As System.EventArgs) Handles txtcorreo.Click
        txtcorreo.SelectionStart = 0
        txtcorreo.SelectionLength = Len(txtcorreo.Text)
    End Sub

    Private Sub txtcorreo_GotFocus(sender As Object, e As System.EventArgs) Handles txtcorreo.GotFocus
        txtcorreo.SelectionStart = 0
        txtcorreo.SelectionLength = Len(txtcorreo.Text)
    End Sub

    Private Sub txtcorreo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorreo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPdomicilio.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtPdomicilio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPdomicilio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtPcotiza.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtPcotiza_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPcotiza.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardaFormatos.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtCopias_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopias.KeyPress
        If Not IsNumeric(txtCopias.Text) Then txtCopias.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardaFormatos.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboventas_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboventas.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbocompras.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbocompras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocompras.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbocotiza.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbocotiza_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbocotiza.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuardaFormatos.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboImpTickets_DropDown(sender As System.Object, e As System.EventArgs) Handles cboImpTickets.DropDown
        cboImpTickets.Items.Clear()
        For Each printer As String In Drawing.Printing.PrinterSettings.InstalledPrinters
            cboImpTickets.Items.Add(printer)
        Next
    End Sub

    Private Sub cboImpCarta_DropDown(sender As System.Object, e As System.EventArgs) Handles cboImpCarta.DropDown
        cboImpCarta.Items.Clear()
        For Each printer As String In Drawing.Printing.PrinterSettings.InstalledPrinters
            cboImpCarta.Items.Add(printer)
        Next
    End Sub

    Private Sub cboImpTickets_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboImpTickets.SelectedValueChanged
        If cboImpTickets.Text <> "" Then
            boxTickets.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        With ofdLogo
            .Filter = "Archivo de imagen (*.jpg)|*.jpg"
            .Title = "Selecciona tu logotipo"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picLogo.Image = Image.FromFile(.FileName)
                Dim texto As String = .FileName
                Dim x As Integer = InStrRev(texto, "\", -1)
                TextBox1.Text = Mid(.FileName, x + 1, 200)
                If MsgBox("¿Deseas guardar esta imagen como logotipo para tus notas?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Try
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Formatos set NotasCred='LogoN.jpg' where Facturas='LogoG'"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()

                        If Not picLogo.Image Is Nothing Then
                            picLogo.Image.Save(My.Application.Info.DirectoryPath & "\LogoN.jpg", Imaging.ImageFormat.Jpeg)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                Else
                    picLogo.Image = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub optcuadra_Click(sender As Object, e As System.EventArgs) Handles optcuadra.Click
        If (optcuadra.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='CUAD' where Facturas='TipoLogo'"
                cmd1.ExecuteNonQuery() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub optrecta_Click(sender As Object, e As System.EventArgs) Handles optrecta.Click
        If (optrecta.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='RECT' where Facturas='TipoLogo'"
                cmd1.ExecuteNonQuery() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub optnada_Click(sender As Object, e As System.EventArgs) Handles optnada.Click
        If (optnada.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='SIN' where Facturas='TipoLogo'"
                cmd1.ExecuteNonQuery() : cnn1.Close()
                picLogo.Image = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub opt80_Click(sender As Object, e As System.EventArgs) Handles opt80.Click
        If (opt80.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='80' where Facturas='TamImpre'"
                cmd1.ExecuteNonQuery() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub opt58_Click(sender As Object, e As System.EventArgs) Handles opt58.Click
        If (opt58.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='58' where Facturas='TamImpre'"
                cmd1.ExecuteNonQuery() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            cnn1.Close() : cnn1.Open()

            If cboImpTickets.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update RutasImpresion set Impresora='" & cboImpTickets.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='TICKET'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into RutasImpresion(Equipo, Tipo, Formato, Impresora) values('" & ObtenerNombreEquipo() & "','TICKET','','" & cboImpTickets.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
            End If

            If cboImpCarta.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update RutasImpresion set Impresora='" & cboImpCarta.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into RutasImpresion(Equipo, Tipo, Formato, Impresora) values('" & ObtenerNombreEquipo() & "','CARTA','','" & cboImpCarta.Text & "')"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close()
            End If

            cnn1.Close()
            MsgBox("Configuración actualizada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboMoneda_DropDown(sender As System.Object, e As System.EventArgs) Handles cboMoneda.DropDown
        cboMoneda.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select nombre_moneda from tb_moneda"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboMoneda.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboMoneda_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboMoneda.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtValor.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboMoneda_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboMoneda.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from tb_moneda where nombre_moneda='" & cboMoneda.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboMoneda.Tag = rd1("id").ToString
                    txtValor.Text = FormatNumber(rd1("tipo_cambio").ToString, 2)
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtValor_Click(sender As Object, e As System.EventArgs) Handles txtValor.Click
        txtValor.SelectionStart = 0
        txtValor.SelectionLength = Len(txtValor.Text)
    End Sub

    Private Sub txtValor_GotFocus(sender As Object, e As System.EventArgs) Handles txtValor.GotFocus
        txtValor.SelectionStart = 0
        txtValor.SelectionLength = Len(txtValor.Text)
    End Sub

    Private Sub txtValor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValor.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button6.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtValor_LostFocus(sender As Object, e As System.EventArgs) Handles txtValor.LostFocus
        txtValor.Text = FormatNumber(txtValor.Text, 2)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        cboMoneda.Tag = ""
        cboMoneda.Text = ""
        txtValor.Text = "0.00"
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        If cboMoneda.Tag = "" Then MsgBox("Para poder eliminar una moneda, necesitas seleccionarla.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select id_tbMoneda from Productos where id_tbMoneda=" & cboMoneda.Tag
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    MsgBox("No se puede eliminar la moneda porque está en uso.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close()
                    cnn1.Close()
                    Exit Sub
                End If
            End If
            rd1.Close()

            If cboMoneda.Tag = "1" Then
                cboMoneda.Tag = ""
                cboMoneda.Text = ""
                txtValor.Text = "0.00"
                cnn1.Close()
                Exit Sub
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete * from tb_moneda where id=" & cboMoneda.Tag
            If cmd1.ExecuteNonQuery Then
                cboMoneda.Tag = ""
                cboMoneda.Text = ""
                txtValor.Text = "0.00"
            End If

            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        SFormatos("Moneda", txtmoneda.Text)
        MsgBox("Moneda registrada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        SFormatos("Simbolo", txtsimbolo.Text)
        MsgBox("Símbolo de modena registrado correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        SFormatos("Abreviatura", txtabrevia.Text)
        MsgBox("Abreviatura de moneda registrada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
    End Sub

    Private Sub optPrecioFijo_Click(sender As System.Object, e As System.EventArgs) Handles optPrecioFijo.Click
        If (optPrecioFijo.Checked) Then
            boxInicio.Enabled = False
            boxTermino.Enabled = False
        End If
    End Sub

    Private Sub optDiaNoche_Click(sender As Object, e As System.EventArgs) Handles optDiaNoche.Click
        If (optDiaNoche.Checked) Then
            boxInicio.Enabled = True
            boxTermino.Enabled = True
        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        If MsgBox("¿Deseas actualizar la configuración de cambio de precios?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Dim tipo As String = IIf(optDiaNoche.Checked = True, "DIANOCHE", "NORMAL")

            Try
                SFormatos("TipoPrecio", tipo)

                If tipo = "DIANOCHE" Then
                    SFormatos("HoraInicia", Format(dtpInicio.Value, "HH:mm"))
                    SFormatos("HoraTermina", Format(dtpTermino.Value, "HH:mm"))
                Else
                    cnn1.Close()
                    cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "delete from Formatos where Facturas='HoraInicia'"
                    cmd1.ExecuteNonQuery()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "delete from Formatos where Facturas='HoraTermina'"
                    cmd1.ExecuteNonQuery()

                    cnn1.Close()
                End If
                MsgBox("Configuración de precios actualizada.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub dtpInicio_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpInicio.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            dtpTermino.Focus().Equals(True)
        End If
    End Sub

    Private Sub dtpTermino_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpTermino.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button15.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If cboMoneda.Text = "" Then MsgBox("Selecciona o escribe el tipo de moneda para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboMoneda.Focus().Equals(True) : Exit Sub
        If MsgBox("¿Deseas guardar la configuración de moneda?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "select * from tb_moneda where nombre_moneda='" & cboMoneda.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        'Update
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                             "update tb_moneda set nombre_moneda='" & cboMoneda.Text & "', tipo_cambio=" & txtValor.Text & " where Id=" & rd1(0).ToString()
                        cmd2.ExecuteNonQuery()
                        cnn2.Close()
                    End If
                Else
                    'Insert
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                         "insert into tb_moneda(nombre_moneda,tipo_cambio) values('" & cboMoneda.Text & "'," & txtValor.Text & ")"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
                rd1.Close() : cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtmax_descu_Click(sender As System.Object, e As System.EventArgs) Handles txtmax_descu.Click
        txtmax_descu.SelectionStart = 0
        txtmax_descu.SelectionLength = Len(txtmax_descu.Text)
    End Sub

    Private Sub txtmax_descu_GotFocus(sender As Object, e As System.EventArgs) Handles txtmax_descu.GotFocus
        txtmax_descu.SelectionStart = 0
        txtmax_descu.SelectionLength = Len(txtmax_descu.Text)
    End Sub

    Private Sub txtmax_descu_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmax_descu.KeyPress
        If Not IsNumeric(txtmax_descu.Text) Then txtmax_descu.Text = ""
        If AscW(e.KeyChar) = Keys.Enter Then
            If CDbl(txtmax_descu.Text) >= 100 Then
                MsgBox("El descuento permitido no puede ser igual o mayor al 100%", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                txtmax_descu.Focus().Equals(True) : Exit Sub
            End If
            btnguarda_descuento.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnguarda_descuento_Click(sender As System.Object, e As System.EventArgs) Handles btnguarda_descuento.Click
        If MsgBox("¿Deseas actualizar el máximo de descuento permitido en las venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='" & txtmax_descu.Text & "' where Facturas='Mdescuento'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Máximo descuento actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboproveedor_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboproveedor.SelectedValueChanged
        If cboproveedor.Text = "Hotmail/Live" Then
            txtsmtp.Text = "smtp.live.com"
            txtpuerto.Text = "587"
            txtcorreo_ef.Text = ""
            chkssl.Checked = True
            chkenvioauto.Checked = False
            chksmtp.Checked = True
            txtcorreo_ef.Focus().Equals(True)
        End If
        If cboproveedor.Text = "Gmail" Then
            txtsmtp.Text = "smtp.gmail.com"
            txtpuerto.Text = "587"
            txtcorreo_ef.Text = ""
            chkssl.Checked = True
            chkenvioauto.Checked = False
            chksmtp.Checked = True
            txtcorreo_ef.Focus().Equals(True)
        End If
        If cboproveedor.Text = "Otro" Then
            txtsmtp.Text = ""
            txtpuerto.Text = "587"
            txtcorreo_ef.Text = ""
            chkssl.Checked = False
            chkenvioauto.Checked = False
            chksmtp.Checked = False
            txtcorreo_ef.Focus().Equals(True)
        End If
        If cboproveedor.Text = "Yahoo" Then
            txtsmtp.Text = "smtp.mail.yahoo.com"
            txtpuerto.Text = "465"
            txtcorreo_ef.Text = ""
            chkssl.Checked = True
            chkenvioauto.Checked = False
            chksmtp.Checked = True
            txtcorreo_ef.Focus().Equals(True)
        End If
    End Sub

    Private Sub chkMinAlmacen_Click(sender As System.Object, e As System.EventArgs) Handles chkMinAlmacen.Click
        SFormatos("MinimoA", "")
        If (chkMinAlmacen.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='1' where Facturas='MinimoA'"
                cmd1.ExecuteNonQuery()

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='0' where Facturas='MinimoA'"
                cmd1.ExecuteNonQuery()

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub chkCodAuto_Click(sender As System.Object, e As System.EventArgs) Handles chkCodAuto.Click
        SFormatos("CodAutoma", "")
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        crea_ruta(My.Application.Info.DirectoryPath & "\BinData\")
        Dim ruta_local As String = My.Application.Info.DirectoryPath & "\BinData\"

        ofdLogo.FileName = ""
        Try
            ofdLogo.Filter = "Archivos CER|*.cer"

            If ofdLogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtcertificado.Text = ruta_local & Path.GetFileName(ofdLogo.FileName)

                FileIO.FileSystem.CopyFile(ofdLogo.FileName, ruta_local & Path.GetFileName(ofdLogo.FileName), True)

                SFormatos("FILE_CERT", ofdLogo.SafeFileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Me.Close()
        End Try
    End Sub

    Private Sub btnGuarda_Cer_Click(sender As System.Object, e As System.EventArgs) Handles btnGuarda_Cer.Click
        If txtContra1.Text = "" Then
            MsgBox("Ingresa la contraseña del certificado de sello digital.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtContra1.Focus().Equals(True)
            Exit Sub
        End If

        If txtContra2.Text = "" Then
            MsgBox("Confirma la contraseña del certificado de sello digital.", vbInformation + vbOKOnly, "Delsscom Control Negocio Pro")
            txtContra2.Focus().Equals(True)
            Exit Sub
        End If

        If txtContra1.Text <> txtContra2.Text Then
            MsgBox("Las contraseñas no coinciden.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            txtContra2.Focus().Equals(True)
            Exit Sub
        End If

        If txtFolioI_Fact.Text = "" Then txtFolioI_Fact.Text = "1"

        If MsgBox("¿Es correcta la información que estás a punto de guardar?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then Exit Sub

        Try
            SFormatos("SHIBBOLETH", txtContra1.Text)
            SFormatos("SERIE_FACT_EL", txtSerie_Fac.Text)
            SFormatos("SERIE_NC_EL", txtSerie_Not.Text)
            SFormatos("FOLIOfacINI", txtFolioI_Fact.Text)
            SFormatos("FOLIOfacFIN", txtFolioF_Fact.Text)
            SFormatos("FolioNtaCredIni", txtFolioI_Not.Text)

            MsgBox("Información registrada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        If txtcertificado.Text = "" Then MsgBox("Selecciona tu certificado para seleccionar el archivo .key", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        crea_ruta(My.Application.Info.DirectoryPath & "\BinData\")
        Dim ruta_local As String = My.Application.Info.DirectoryPath & "\BinData\"

        txtllave.Text = ""
        Try
            ofdLogo.Filter = "Archivos KEY|*.key"

            If ofdLogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtllave.Text = ruta_local & Path.GetFileName(ofdLogo.FileName)

                FileIO.FileSystem.CopyFile(ofdLogo.FileName, ruta_local & Path.GetFileName(ofdLogo.FileName), True)

                SFormatos("FILE_KEY", ofdLogo.SafeFileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Me.Close()
        End Try
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        picLogoFact.Image = Nothing
        Try
            ofdLogo.Filter = "Archivos de Imagen(*.PNG)|*.png|Imagen(*.BMP)|*.bmp|Imagen (*.JPG)|*.jpg|Imagen(*.JPEG)|*jpeg"

            If ofdLogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                picLogoFact.Image = Image.FromFile(ofdLogo.FileName)
                Dim texto As String = ofdLogo.FileName
                Dim x As Integer = InStrRev(texto, "\", -1)
                txtLogotipo.Text = Mid(ofdLogo.FileName, x + 1, 200)

                txtLogotipo.Text = ofdLogo.FileName
                txtnombrelogotipo.Text = ofdLogo.SafeFileName

                If MsgBox("¿Deseas guardar esta imagen como logotipo para las facturas?", vbInformation + vbOKCancel) = vbOK Then
                    Try
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText = "select * from DatosNegocio where EM_Expedir='FISCAL'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then

                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "update DatosNegocio set emi_logo='LogoFac.jpg'"
                                cmd1.ExecuteNonQuery()
                                cnn1.Close()

                                If Not picLogoFact.Image Is Nothing Then
                                    picLogoFact.Image.Save(My.Application.Info.DirectoryPath & "\LogoFac.jpg", Imaging.ImageFormat.Jpeg)
                                End If

                            Else
                                'cnn1.Close() : cnn1.Open()
                                'cmd1 = cnn1.CreateCommand
                                'cmd1.CommandText = "insert Formatos(Facturas,NotasCred,NumPart) values('LogoT',0,0)"
                                'cmd1.ExecuteNonQuery()
                                'cnn1.Close()
                            End If
                        End If
                        rd2.Close()
                        cnn2.Close()
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                End If
            Else
                picLogoFact.Image = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Me.Close()
        End Try
    End Sub

    Private Sub chkAcumula_Click(sender As System.Object, e As System.EventArgs) Handles chkAcumula.Click
        SFormatos("Acumula", "")
        If (chkAcumula.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='1' where Facturas='Acumula'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='0' where Facturas='Acumula'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub chkautofacturas_Click(sender As System.Object, e As System.EventArgs) Handles chkautofacturas.Click
        SFormatos("AutoFac", "")
        If (chkautofacturas.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='1' where Facturas='AutoFac'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Formatos set NotasCred='0' where Facturas='AutoFac'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
            pauto.Visible = True
        End If
    End Sub

    Private Sub chkSeries_Click(sender As System.Object, e As System.EventArgs) Handles chkSeries.Click
        SFormatos("Series", "")
    End Sub

    Private Sub chkDesglosa_Click(sender As System.Object, e As System.EventArgs) Handles chkDesglosa.Click
        SFormatos("Desglosa", "")
        If (chkDesglosa.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='1' where Facturas='Desglosa'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='0' where Facturas='Desglosa'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcorreo_ef_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorreo_ef.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontra_correo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontra_correo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontra_correo.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcontra_correo2.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcontra_correo2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcontra_correo2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button12.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnCosteo_Click(sender As System.Object, e As System.EventArgs) Handles btnCosteo.Click
        If optPEPS.Checked = False And optPromedio.Checked = False Then MsgBox("Selecciona alguno de los dos métodos para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
        If MsgBox("Es importante considerar que el método seleccionado (" & IIf(optPEPS.Checked = True, "PEPS", IIf(optPromedio.Checked = True, "Promedio", "")) & ") no podrá cambiarse posteriormente." & vbNewLine & "¿Deseas guardar ésta información?" & vbNewLine & "*El sistema se cerrará al guardar los datos*", MsgBoxStyle.Question + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='" & IIf(optPEPS.Checked = True, "PEPS", IIf(optPromedio.Checked = True, "Promedio", "")) & "', NumPart=1 where Facturas='Costeo'"
                If cmd1.ExecuteNonQuery Then
                    cnn1.Close()
                    MsgBox("Método de costeo asignado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If MsgBox("Es importante considerar que estas modificaciones son únicas, por lo que sólo podrán ser modificadas una sola vez." & vbNewLine & "¿Deseas continuar con la actualización?", vbQuestion + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn2.Close() : cnn2.Open()

                If (chkCodAuto.Checked) Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                         "update Formatos set NotasCred='1', NumPart=1 WHERE Facturas='CodAutoma'"
                    cmd2.ExecuteNonQuery()
                End If

                If (chkSeries.Checked) Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                         "update Formatos set NotasCred='1', NumPart=1 where Facturas='Series'"
                    cmd2.ExecuteNonQuery()
                End If

                If (chkPartes.Checked) Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                         "update Formatos set NotasCred='1', NumPart=1 where Facturas='Partes'"
                    cmd2.ExecuteNonQuery()
                End If

                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
        End If
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        If cboproveedor.Text = "" Then MsgBox("Selecciona el proveedor del servicio para continuar.", vbInformation + vbOK, "Delsscom Control Negocios Pro") : cboproveedor.Focus().Equals(True) : Exit Sub
        If txtcorreo_ef.Text = "" Then MsgBox("Escribe tu correo para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcorreo_ef.Focus().Equals(True) : Exit Sub
        If txtcontra_correo.Text = "" Or txtcontra_correo2.Text = "" Then MsgBox("Escribe la contraseña del correo para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontra_correo.Focus().Equals(True) : Exit Sub
        If InStr(1, txtcorreo_ef.Text, "@") = 0 Then
            MsgBox("El correo electrónico es inválido.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
            txtcorreo_ef.SelectionStart = 0
            txtcorreo_ef.SelectionLength = Len(txtcorreo_ef.Text)
            Exit Sub
        End If
        If MsgBox("¿Deseas guardar esta información?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Call SFormatos("PROVE_Ser", cboproveedor.Text)
            Call SFormatos("Server_SMTP", txtsmtp.Text)
            Call SFormatos("Pto_Mail", txtpuerto.Text)
            Call SFormatos("Mail_Emi", txtcorreo_ef.Text)
            Call SFormatos("Shibboleth_ML", txtcontra_correo.Text)
            Call SFormatos("Aute_Server_SMTP", chksmtp.CheckState)
            Call SFormatos("SSL", chkssl.CheckState)
            Call SFormatos("ENV_DOC", chkenvioauto.CheckState)

            MsgBox("Datos guardados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
        End If
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        If MsgBox("¿Deseas eliminar tu configuración de envío de correos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='PROVE_Ser'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='Server_SMTP'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='Pto_Mail'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='Mail_Emi'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='Shibboleth_ML'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='Aute_Server_SMTP'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='SSL'"
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from Formatos where Facturas='ENV_DOC'"
                cmd1.ExecuteNonQuery()

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cborazon_social_DropDown(sender As System.Object, e As System.EventArgs) Handles cborazon_social.DropDown
        cborazon_social.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from DatosNegocio where Em_RazonSocial<>'' and (Em_Expedir='FISCAL' or Em_Expedir='SUCURSAL')"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cborazon_social.Items.Add(rd1("Em_RazonSocial").ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cborazon_social_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cborazon_social.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select * from DatosNegocio where Em_RazonSocial='" & cborazon_social.Text & "' and (Em_Expedir='FISCAL' or Em_Expedir='SUCURSAL')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cborazon_social.Tag = rd1("Emisor_id").ToString()
                    txtRFC_fact.Text = rd1("Em_rfc").ToString()
                    txtcalle_fact.Text = rd1("Em_calle").ToString()
                    txtcolonia_fact.Text = rd1("Em_colonia").ToString()
                    txtn_exterior.Text = rd1("Em_NumExterior").ToString()
                    txtn_interior.Text = rd1("Em_NumInterior").ToString()
                    txtcp_fact.Text = rd1("Em_CP").ToString()
                    txtdelegacion_fact.Text = rd1("Em_Municipio").ToString()
                    txtentidad_fact.Text = rd1("Em_Estado").ToString()
                    cbopais_fact.Text = rd1("Em_Pais").ToString()
                    txtcorreo_fact.Text = rd1("Em_Mail").ToString()
                    txttelefono_fact.Text = rd1("Em_Tel").ToString()
                    txtnombre_comercial.Text = rd1("Em_NombreNegocio").ToString()
                    txtdescripcion.Text = rd1("Em_Actividad").ToString()
                    If rd1("Em_Expedir").ToString() = "SUCURSAL" Then
                        chksucursal.Checked = True
                    Else
                        chksucursal.Checked = False
                    End If
                    cboregfis.Text = Dame_Regimen(rd1("Em_RFiscal").ToString())
                End If
            End If
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub btnLimpia_fact_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpia_fact.Click
        txtdescripcion.Text = ""
        cborazon_social.Items.Clear()
        cborazon_social.Text = ""
        txtRFC_fact.Text = ""
        txtcalle_fact.Text = ""
        txtn_exterior.Text = ""
        txtn_interior.Text = ""
        txtcolonia_fact.Text = ""
        txtcp_fact.Text = ""
        txtdelegacion_fact.Text = ""
        txtentidad_fact.Text = ""
        cbopais_fact.Items.Clear()
        cbopais_fact.Text = ""
        txtcorreo_ef.Text = ""
        txttelefono_fact.Text = ""
        cboregfis.Items.Clear()
        cboregfis.Text = ""
        txtnombre_comercial.Text = ""
        chksucursal.Checked = False
        cborazon_social.Focus().Equals(True)
    End Sub

    Private Sub btnGuarda_fact_Click(sender As System.Object, e As System.EventArgs) Handles btnGuarda_fact.Click
        Try
            Dim tipo_reg As String = ""
            If cborazon_social.Text = "" Then MsgBox("Escribe la razón social para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cborazon_social.Focus().Equals(True) : Exit Sub
            If txtcalle_fact.Text = "" Then MsgBox("Escribe la calle del domicilio fiscal para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcalle_fact.Focus().Equals(True) : Exit Sub
            If txtRFC_fact.Text = "" Then MsgBox("Escribe el RFC de la razón social para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtRFC_fact.Focus().Equals(True) : Exit Sub
            If txtcolonia_fact.Text = "" Then MsgBox("Escribe la colonia del domicilio fiscal para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcolonia_fact.Focus().Equals(True) : Exit Sub
            If txtdelegacion_fact.Text = "" Then MsgBox("Escribe la delegación/el municipio del domicilio fiscal para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtdelegacion_fact.Focus().Equals(True) : Exit Sub
            If txtentidad_fact.Text = "" Then MsgBox("Escribe la entiedad del domicilio fiscal para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtentidad_fact.Focus().Equals(True) : Exit Sub
            If cbopais_fact.Text = "" Then MsgBox("Selecciona el pais del domicilio fiscal para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbopais_fact.Focus().Equals(True)
            If cboregfis.Text = "" Then MsgBox("Selecciona el régimen fiscal del emisor para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboregfis.Focus().Equals(True) : Exit Sub
            If chksucursal.Checked = True Then
                tipo_reg = "SUCURSAL"
            Else
                tipo_reg = "FISCAL"
            End If

            If MsgBox("¿Deseas actualizar esta información para facturación?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()
                If cborazon_social.Tag = "" Then
                    'Inserta uno nuevo
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "insert into DatosNegocio(Em_RazonSocial,Em_NombreNegocio,Em_rfc,Em_mail,Em_usuario,Em_calle,Em_NumExterior,Em_NumInterior,Em_colonia,Em_Municipio,Em_Estado,Em_Pais,Em_CP,Em_Tipo,Em_Posicion,Em_Tel,Em_Expedir,Em_RFiscal,Em_Actividad,emi_logo) values('" & cborazon_social.Text & "','" & txtnombre_comercial.Text & "','" & txtRFC_fact.Text & "','" & txtcolonia_fact.Text & "','','" & txtcalle_fact.Text & "','" & txtn_exterior.Text & "','" & txtn_interior.Text & "','" & txtcolonia_fact.Text & "','" & txtdelegacion_fact.Text & "','" & txtentidad_fact.Text & "','" & cbopais_fact.Text & "','" & txtcp_fact.Text & "','',0,'" & txttelefono_fact.Text & "','" & tipo_reg & "','" & Dame_ClaveReg(cboregfis.Text) & "','" & txtdescripcion.Text & "','')"
                    cmd1.ExecuteNonQuery()

                    SFormatos("RFC_Emisor", txtRFC_fact.Text)
                Else
                    'Actualiza el existente
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "update DatosNegocio set Em_RazonSocial='" & cborazon_social.Text & "', Em_NombreNegocio='" & txtnombre_comercial.Text & "', Em_rfc='" & txtRFC_fact.Text & "', Em_mail='" & txtcorreo_fact.Text & "', Em_calle='" & txtcalle_fact.Text & "', Em_NumExterior='" & txtn_exterior.Text & "', Em_NumInterior='" & txtn_interior.Text & "', Em_colonia='" & txtcolonia_fact.Text & "', Em_Municipio='" & txtdelegacion_fact.Text & "', Em_Estado='" & txtentidad_fact.Text & "', Em_Pais='" & cbopais_fact.Text & "', Em_CP='" & txtcp_fact.Text & "', Em_Tel='" & txttelefono_fact.Text & "', Em_Expedir='" & tipo_reg & "', Em_RFiscal='" & Dame_ClaveReg(cboregfis.Text) & "', Em_Actividad='" & txtdescripcion.Text & "' where Emisor_id=" & cborazon_social.Tag
                    cmd1.ExecuteNonQuery()

                    SFormatos("RFC_Emisor", txtRFC_fact.Text)
                End If
                MsgBox("Datos de emisor actualizados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cborazon_social_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cborazon_social.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtRFC_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtRFC_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtRFC_fact.GotFocus
        txtRFC_fact.SelectionStart = 0
        txtRFC_fact.SelectionLength = Len(txtRFC_fact.Text)
    End Sub

    Private Sub txtRFC_fact_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRFC_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Len(txtRFC_fact.Text) > 13 Then MsgBox("RFC inválido, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            If txtRFC_fact.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                         "select * from DatosNegocio where Em_rfc='" & txtRFC_fact.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            cborazon_social.Tag = rd1("Emisor_id").ToString()
                            cborazon_social.Text = rd1("Em_RazonSocial").ToString()
                            txtcalle_fact.Text = rd1("Em_calle").ToString()
                            txtcolonia_fact.Text = rd1("Em_colonia").ToString()
                            txtn_exterior.Text = rd1("Em_NumExterior").ToString()
                            txtn_interior.Text = rd1("Em_NumInterior").ToString()
                            txtcp_fact.Text = rd1("Em_CP").ToString()
                            txtdelegacion_fact.Text = rd1("Em_Municipio").ToString()
                            txtentidad_fact.Text = rd1("Em_Estado").ToString()
                            cbopais_fact.Text = rd1("Em_Pais").ToString()
                            txtcorreo_fact.Text = rd1("Em_Mail").ToString()
                            txttelefono_fact.Text = rd1("Em_Tel").ToString()
                            txtnombre_comercial.Text = rd1("Em_NombreNegocio").ToString()
                            txtdescripcion.Text = rd1("Em_Actividad").ToString()
                            If rd1("Em_Expedir").ToString() = "SUCURSAL" Then
                                chksucursal.Checked = True
                            Else
                                chksucursal.Checked = False
                            End If
                            cboregfis.Text = Dame_Regimen(rd1("Em_RFiscal").ToString())
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try
            End If
            txtcalle_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtRFC_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtRFC_fact.Click
        txtRFC_fact.SelectionStart = 0
        txtRFC_fact.SelectionLength = Len(txtRFC_fact.Text)
    End Sub

    Private Sub txtcalle_fact_Click(sender As Object, e As System.EventArgs) Handles txtcalle_fact.Click
        txtcalle_fact.SelectionStart = 0
        txtcalle_fact.SelectionLength = Len(txtcalle_fact.Text)
    End Sub

    Private Sub txtcalle_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtcalle_fact.GotFocus
        txtcalle_fact.SelectionStart = 0
        txtcalle_fact.SelectionLength = Len(txtcalle_fact.Text)
    End Sub

    Private Sub txtcalle_fact_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcalle_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtn_exterior.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtn_exterior_Click(sender As System.Object, e As System.EventArgs) Handles txtn_exterior.Click
        txtn_exterior.SelectionStart = 0
        txtn_exterior.SelectionLength = Len(txtn_exterior.Text)
    End Sub

    Private Sub txtn_exterior_GotFocus(sender As Object, e As System.EventArgs) Handles txtn_exterior.GotFocus
        txtn_exterior.SelectionStart = 0
        txtn_exterior.SelectionLength = Len(txtn_exterior.Text)
    End Sub

    Private Sub txtn_exterior_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtn_exterior.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtn_interior.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtn_interior_Click(sender As System.Object, e As System.EventArgs) Handles txtn_interior.Click
        txtn_interior.SelectionStart = 0
        txtn_interior.SelectionLength = Len(txtn_interior.Text)
    End Sub

    Private Sub txtn_interior_GotFocus(sender As Object, e As System.EventArgs) Handles txtn_interior.GotFocus
        txtn_interior.SelectionStart = 0
        txtn_interior.SelectionLength = Len(txtn_interior.Text)
    End Sub

    Private Sub txtn_interior_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtn_interior.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcolonia_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcolonia_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtcolonia_fact.Click
        txtcolonia_fact.SelectionStart = 0
        txtcolonia_fact.SelectionLength = Len(txtcolonia_fact.Text)
    End Sub

    Private Sub txtcolonia_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtcolonia_fact.GotFocus
        txtcolonia_fact.SelectionStart = 0
        txtcolonia_fact.SelectionLength = Len(txtcolonia_fact.Text)
    End Sub

    Private Sub txtcolonia_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcolonia_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcp_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcp_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtcp_fact.Click
        txtcp_fact.SelectionStart = 0
        txtcp_fact.SelectionLength = Len(txtcp_fact.Text)
    End Sub

    Private Sub txtcp_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtcp_fact.GotFocus
        txtcp_fact.SelectionStart = 0
        txtcp_fact.SelectionLength = Len(txtcp_fact.Text)
    End Sub

    Private Sub txtcp_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcp_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If Len(txtcp_fact.Text) > 6 Then MsgBox("Código postal incorrecto, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txtdelegacion_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdelegacion_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtdelegacion_fact.Click
        txtdelegacion_fact.SelectionStart = 0
        txtdelegacion_fact.SelectionLength = Len(txtdelegacion_fact.Text)
    End Sub

    Private Sub txtdelegacion_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtdelegacion_fact.GotFocus
        txtdelegacion_fact.SelectionStart = 0
        txtdelegacion_fact.SelectionLength = Len(txtdelegacion_fact.Text)
    End Sub

    Private Sub txtdelegacion_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtdelegacion_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtentidad_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtentidad_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtentidad_fact.Click
        txtentidad_fact.SelectionStart = 0
        txtentidad_fact.SelectionLength = Len(txtentidad_fact.Text)
    End Sub

    Private Sub txtentidad_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtentidad_fact.GotFocus
        txtentidad_fact.SelectionStart = 0
        txtentidad_fact.SelectionLength = Len(txtentidad_fact.Text)
    End Sub

    Private Sub txtentidad_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtentidad_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbopais_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbopais_fact_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbopais_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcorreo_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcorreo_fact_Click(sender As System.Object, e As System.EventArgs) Handles txtcorreo_fact.Click
        txtcorreo_fact.SelectionStart = 0
        txtcorreo_fact.SelectionLength = Len(txtcorreo_fact.Text)
    End Sub

    Private Sub txtcorreo_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txtcorreo_fact.GotFocus
        txtcorreo_fact.SelectionStart = 0
        txtcorreo_fact.SelectionLength = Len(txtcorreo_fact.Text)
    End Sub

    Private Sub txtcorreo_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtcorreo_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            If InStr(1, txtcorreo_ef.Text, "@") = 0 Then MsgBox("Correo inválido, revisa la información.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Exit Sub
            txttelefono_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttelefono_fact_Click(sender As System.Object, e As System.EventArgs) Handles txttelefono_fact.Click
        txttelefono_fact.SelectionStart = 0
        txttelefono_fact.SelectionLength = Len(txttelefono_fact.Text)
    End Sub

    Private Sub txttelefono_fact_GotFocus(sender As Object, e As System.EventArgs) Handles txttelefono_fact.GotFocus
        txttelefono_fact.SelectionStart = 0
        txttelefono_fact.SelectionLength = Len(txttelefono_fact.Text)
    End Sub

    Private Sub txttelefono_fact_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txttelefono_fact.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboregfis.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboregfis_DropDown(sender As System.Object, e As System.EventArgs) Handles cboregfis.DropDown
        cboregfis.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Descripcion from RegimenFiscalSat order by ClaveRegFis"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboregfis.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboregfis_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboregfis.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnombre_comercial.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnombre_comercial_Click(sender As System.Object, e As System.EventArgs) Handles txtnombre_comercial.Click
        txtnombre_comercial.SelectionStart = 0
        txtnombre_comercial.SelectionLength = Len(txtnombre_comercial.Text)
    End Sub

    Private Sub txtnombre_comercial_GotFocus(sender As Object, e As System.EventArgs) Handles txtnombre_comercial.GotFocus
        txtnombre_comercial.SelectionStart = 0
        txtnombre_comercial.SelectionLength = Len(txtnombre_comercial.Text)
    End Sub

    Private Sub txtnombre_comercial_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtnombre_comercial.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            btnGuarda_fact.Focus().Equals(True)
        End If
    End Sub

    Private Sub btnElimina_fact_Click(sender As System.Object, e As System.EventArgs) Handles btnElimina_fact.Click
        If cborazon_social.Tag = "" Then cborazon_social.Focus().Equals(True) : Exit Sub
        If MsgBox("¿Deseas eliminar los datos del emisor?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "delete from DatosNegocio where Emisor_id=" & cborazon_social.Tag
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Datos de emisor eliminados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnLimpia_fact.PerformClick()
                End If

                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim contraseña As String = ""
        If txtcertificado.Text = "" Then MsgBox("Es necesario capturar el certificado antes de continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Button16.Focus().Equals(True) : Exit Sub
        If txtllave.Text = "" Then MsgBox("Es necesario capturar la llave de seguridad del certificado para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Button17.Focus().Equals(True) : Exit Sub
        contraseña = DatosRecarga("SHIBBOLETH")
        If contraseña = "" Then MsgBox("No has registrado la contraseña de tus certificados.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtContra1.Focus().Equals(True) : Exit Sub
        Dim RFC As String = DatosRecarga("RFC_Emisor")

        If MsgBox("Estás apunto de registrar tus certificados en el panel de timbrado." & vbNewLine & "¿Deseas continuar?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

            Dim x1 As Boolean = False
            If RFC = "AAA010101AAA" Or RFC = "IIA040805DZ4" Then
                x1 = False
            Else
                x1 = True
            End If

            Dim conector As New Profact.TimbraCFDI33.Conector(x1)

            If RFC = "AAA010101AAA" Or RFC = "IIA040805DZ4" Then
                conector.EstableceCredenciales("mvpNUXmQfK8=")
            Else
                conector.EstableceCredenciales("8zHEReNypKE/VqHQIeqBeA==")
            End If

            Dim rutaCer As String = txtcertificado.Text
            Dim rutaKey As String = txtllave.Text

            Dim ResultadoRegistro As Profact.TimbraCFDI.ResultadoRegistro
            ResultadoRegistro = conector.RegistraEmisor(RFC, rutaCer, rutaKey, contraseña)

            If (ResultadoRegistro.Exitoso) Then
                MsgBox("Certificados actualizados/registrados correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            Else
                MessageBox.Show(ResultadoRegistro.Descripcion)
            End If
        End If
    End Sub

    Private Sub chkPartes_Click(sender As Object, e As EventArgs) Handles chkPartes.Click
        SFormatos("Partes", "")
    End Sub

    Private Sub chkwhats_CheckedChanged(sender As Object, e As EventArgs) Handles chkwhats.CheckedChanged
        SFormatos("Whatsapp", "")
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If txtwhats.Text = "" Or Len(txtwhats.Text) < 10 Then MsgBox("Ingresa el número de teléfono de 10 dígitos (sin lada)", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtwhats.Focus().Equals(True) : Exit Sub
        If (chkwhats.Checked) Then
            If MsgBox("Al activar esta opción se mostrará un código QR en el pie de los tickets mediante el cuál tus clientes podrán escribirte por Whatsapp." & vbNewLine & "¿Deseas continuar?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then

                SFormatos("Whatsapp", "")

                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "update Formatos set NotasCred='" & txtwhats.Text & "', NumPart=1 where Facturas='Whatsapp'"
                    If cmd1.ExecuteNonQuery Then
                        MsgBox("Configuración actualizada", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    End If

                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                    cnn1.Close()
                End Try

            End If
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        boxpagare.Visible = True
        txtPagare.Focus().Equals(True)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        Try
            If MsgBox("¿Deseas actualizar el texto de 'pagaré' para tus notas?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Ticket set Pagare='" & txtPagare.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Texto de pagaré actualizado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    boxpagare.Visible = False
                End If
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        boxclausulas.Visible = True
        txtC1.Focus().Equals(True)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        Try
            If MsgBox("¿Deseas actualizar las clausulas para tus notas?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "update Ticket set C1='" & txtC1.Text & "', C2='" & txtC2.Text & "', C3='" & txtC3.Text & "', C4='" & txtC4.Text & "', C5='" & txtC5.Text & "', C6='" & txtC6.Text & "', C7='" & txtC7.Text & "', C8='" & txtC8.Text & "', C9='" & txtC9.Text & "', C10='" & txtC10.Text & "'"
                If cmd1.ExecuteNonQuery Then
                    MsgBox("Clausulas actualizadas.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    boxclausulas.Visible = False
                End If
                cnn1.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtC1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC1.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC2.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC2.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC3.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC3.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC4.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC4.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC5.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC5.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC6.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC6.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC7.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC7.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC8.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC8.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC9.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC9.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            txtC10.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtC10_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtC10.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button23.Focus().Equals(True)
        End If
    End Sub

    Private Sub chkDesc_Ventas_Click(sender As Object, e As EventArgs) Handles chkDesc_Ventas.Click
        SFormatos("Desc_Ventas", "")
        If (chkDesc_Ventas.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='1' where Facturas='Desc_Ventas'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='0' where Facturas='Desc_Ventas'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboGPrint_DropDown(sender As Object, e As EventArgs) Handles cboGPrint.DropDown
        cboGPrint.Items.Clear()

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct GPrint from Productos where GPrint<>'' order by GPrint"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboGPrint.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboGPrint_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboGPrint.KeyPress

        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cboImpre_Comanda.Focus().Equals(True)
        End If

    End Sub

    Private Sub cboGPrint_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboGPrint.SelectedValueChanged

        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & cboGPrint.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboImpre_Comanda.Text = rd1("Impresora").ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
        cboImpre_Comanda.Focus().Equals(True)

    End Sub

    Private Sub cboImpre_Comanda_DropDown(sender As Object, e As EventArgs) Handles cboImpre_Comanda.DropDown
        cboImpre_Comanda.Items.Clear()
        For Each printer As String In Drawing.Printing.PrinterSettings.InstalledPrinters
            cboImpre_Comanda.Items.Add(printer)
        Next
    End Sub

    Private Sub cboImpre_Comanda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboImpre_Comanda.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button24.Focus().Equals(True)
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click

        If cboGPrint.Text = "" Then MsgBox("Selecciona un grupo de impresión.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboGPrint.Focus().Equals(True) : Exit Sub
        If cboImpre_Comanda.Text = "" Then MsgBox("Selecciona la impresora del grupo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboImpre_Comanda.Focus().Equals(True) : Exit Sub

        If MsgBox("¿Deseas actualizar la ruta de impresión?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & cboGPrint.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        cnn2.Close() : cnn2.Open()
                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "update RutasImpresion set Impresora='" & cboImpre_Comanda.Text & "' where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & cboGPrint.Text & "'"
                        If cmd2.ExecuteNonQuery Then
                            MsgBox("Ruta de impresión actualizada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            cboGPrint.Text = ""
                            cboImpre_Comanda.Text = ""
                            cboImpre_Comanda.Focus().Equals(True)
                        End If
                        cnn2.Close()
                    End If
                Else
                    cnn2.Close() : cnn2.Open()

                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText =
                        "insert into RutasImpresion(Equipo,Tipo,Formato,Impresora) values('" & ObtenerNombreEquipo() & "','" & cboGPrint.Text & "','','" & cboImpre_Comanda.Text & "')"
                    If cmd2.ExecuteNonQuery Then
                        MsgBox("Ruta de impresión registrada correctamente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        cboGPrint.Text = ""
                        cboImpre_Comanda.Text = ""
                        cboImpre_Comanda.Focus().Equals(True)
                    End If
                    cnn2.Close()
                    cnn2.Close()
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub chkFranquicia_Click(sender As Object, e As EventArgs) Handles chkFranquicia.Click
        If (chkFranquicia.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='1' where Facturas='Franquicia'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='0' where Facturas='Franquicia'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtnumero_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnMigrar_Click(sender As Object, e As EventArgs) Handles btnMigrar.Click
        If txtBase.Text = "" Then MsgBox("Necesitas seleccionar una ruta de acceso para la base a migrar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtBase.Focus().Equals(True) : Exit Sub


    End Sub

    Private Sub Button25_Click_1(sender As Object, e As EventArgs) Handles Button25.Click
        If txtnumero.Text.Length <> 10 Then MsgBox("El número de télefono debe de ser de 10 digitos", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtnumero.Focus.Equals(True) : Exit Sub
        If txtusuario.Text = "" Then MsgBox("El usuario no puede ir vacio", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtusuario.Focus.Equals(True) : Exit Sub
        If txtcontra.Text = "" Then MsgBox("La contraseña no puede ir vacia", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontra.Focus.Equals(True) : Exit Sub

        If lblid.Text <> "" Then
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Update loginrecargas set numero='" & txtnumero.Text & "', usuario='" & txtusuario.Text & "', password='" & txtcontra.Text & "' where id=" & lblid.Text & ""
                If cmd1.ExecuteNonQuery Then
                    varnumero = txtnumero.Text
                    varusuario = txtusuario.Text
                    varcontra = txtcontra.Text
                    MsgBox("Datos actualizados correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                Else
                    MsgBox("Error al actualizar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close()
                cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "Insert into loginrecargas(numero,usuario,password) values('" & txtnumero.Text & "','" & txtusuario.Text & "','" & txtcontra.Text & "')"
                If cmd1.ExecuteNonQuery Then
                    varnumero = txtnumero.Text
                    varusuario = txtusuario.Text
                    varcontra = txtcontra.Text
                    cnn1.Close()

                    cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText = "Select * from Productos where Codigo='RECAR'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.Read Then
                        rd1.Close()
                        cnn1.Close()
                    Else
                        rd1.Close()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText = "Insert into Productos(Codigo,Nombre,ProvPri,ProvEme,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Min,Max) values('RECARG','RECARGA TELEFONICA','DELSSCOM','DELSSCOM','SERV','SERV','SERV',1,1,'RECARGAS','RECARGAS',1,1)"
                        If cmd1.ExecuteNonQuery Then
                            rd1.Close()
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText = "Insert into Productos(Codigo,Nombre,ProvPri,ProvEme,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Min,Max) values('PAGOSE','PAGO DE SERVICIOS','DELSSCOM','DELSSCOM','SERV','SERV','SERV',1,1,'PAGOS','PAGOS',1,1)"
                            If cmd1.ExecuteNonQuery Then
                                rd1.Close()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText = "Insert into Productos(Codigo,Nombre,ProvPri,ProvEme,UCompra,UVenta,UMinima,MCD,Multiplo,Departamento,Grupo,Min,Max) values('COMISI','COMISION PAGO DE SERVICIOS','DELSSCOM','DELSSCOM','SERV','SERV','SERV',1,1,'COMISION','COMISION',1,1)"
                                cmd1.ExecuteNonQuery()
                                rd1.Close()
                                MsgBox("Datos registrados correctamente", vbInformation + vbOKOnly, "Delsscom COntrol Negocios Pro")
                            End If
                        Else
                            MsgBox("Error al registrar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                            cnn1.Close()
                            Exit Sub
                        End If
                    End If
                    cnn1.Close()
                    Exit Sub
                Else
                    MsgBox("Error al registrar los datos de la cuenta", vbCritical + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub lblid_Click(sender As Object, e As EventArgs) Handles lblid.Click

    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs) Handles Label76.Click

    End Sub

    Private Sub txtnumero_TextChanged(sender As Object, e As EventArgs) Handles txtnumero.TextChanged

    End Sub

    Private Sub txtusuario_TextChanged(sender As Object, e As EventArgs) Handles txtusuario.TextChanged

    End Sub

    Private Sub txtcontra_TextChanged(sender As Object, e As EventArgs) Handles txtcontra.TextChanged

    End Sub

    Private Sub Label75_Click(sender As Object, e As EventArgs) Handles Label75.Click

    End Sub

    Private Sub Label77_Click(sender As Object, e As EventArgs) Handles Label77.Click

    End Sub

    Private Sub Label78_Click(sender As Object, e As EventArgs) Handles Label78.Click

    End Sub

    Private Sub txtnumero_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtnumero.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not e.KeyChar = Convert.ToChar(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnImgEtiq_Click(sender As Object, e As EventArgs) Handles btnImgEtiq.Click
        With ofdLogo
            .Filter = "Archivo de imagen (*.jpg)|*.jpg"
            .Title = "Selecciona tu logotipo"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picEtiq.Image = Image.FromFile(.FileName)
                Dim texto As String = .FileName
                Dim x As Integer = InStrRev(texto, "\", -1)
                TextBox2.Text = Mid(.FileName, x + 1, 200)
                If MsgBox("¿Deseas guardar esta imagen como logotipo para tus etiquetas?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Try
                        cnn1.Close() : cnn1.Open()
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "update Formatos set NotasCred='LogoEti.jpg' where Facturas='LogoE'"
                        cmd1.ExecuteNonQuery()
                        cnn1.Close()

                        If Not picEtiq.Image Is Nothing Then
                            picEtiq.Image.Save(My.Application.Info.DirectoryPath & "\LogoEti.jpg", Imaging.ImageFormat.Jpeg)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                        cnn1.Close()
                    End Try
                Else
                    picEtiq.Image = Nothing
                End If
            End If
        End With
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Dim medida As String = ""

            If (optEM_2x4.Checked) Then
                medida = "2x4"
            End If

            If (optEM_5x25.Checked) Then
                medida = "5x2.5"
            End If

            If (optEM_65x27.Checked) Then
                medida = "6.5x2.7"
            End If

            If (optEM5X3.Checked) Then
                medida = "5x3"
            End If



            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='Medida_Eti'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then

                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE formatos SET NotasCred='" & medida & "' WHERE Facturas='Medida_Eti'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()

                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('Medida_Eti','" & medida & "',0)"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()


            Dim orientacion As String = ""

            If (optE_Sin.Checked) Then
                orientacion = "S/ETI"
            End If

            If (optE_Arriba.Checked) Then
                orientacion = "ARRIBA"
            End If

            If (optE_Izquierda.Checked) Then
                orientacion = "IZQUIERDA"
            End If

            If (optE_Derecha.Checked) Then
                orientacion = "DERECHA"
            End If

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='OriLogoE'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE formatos SET NotasCred='" & orientacion & "' WHERE Facturas='OriLogoE'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('OriLogoE','" & orientacion & "',0)"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()
            MsgBox("Configuración de etiquetas agregada correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optEM_65x27_Click(sender As Object, e As EventArgs) Handles optEM_65x27.Click

        Try
            optEM_5x25.Checked = False
            optEM_2x4.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

    End Sub

    Private Sub optEM_5x25_Click(sender As Object, e As EventArgs) Handles optEM_5x25.Click
        Try
            optEM_65x27.Checked = False
            optEM_2x4.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub optEM_2x4_Click(sender As Object, e As EventArgs) Handles optEM_2x4.Click
        Try
            optEM_65x27.Checked = False
            optEM_5x25.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()

        End Try
    End Sub

    Private Sub optE_Sin_Click(sender As Object, e As EventArgs) Handles optE_Sin.Click
        optE_Arriba.Checked = False
        optE_Izquierda.Checked = False
        optE_Derecha.Checked = False

    End Sub

    Private Sub optE_Arriba_Click(sender As Object, e As EventArgs) Handles optE_Arriba.Click
        optE_Sin.Checked = False
        optE_Izquierda.Checked = False
        optE_Derecha.Checked = False
    End Sub

    Private Sub optE_Izquierda_Click(sender As Object, e As EventArgs) Handles optE_Izquierda.Click
        optE_Sin.Checked = False
        optE_Arriba.Checked = False
        optE_Derecha.Checked = False
    End Sub

    Private Sub optE_Derecha_Click(sender As Object, e As EventArgs) Handles optE_Derecha.Click
        optE_Sin.Checked = False
        optE_Arriba.Checked = False
        optE_Izquierda.Checked = False
    End Sub

    Private Sub optEM5X3_Click(sender As Object, e As EventArgs) Handles optEM5X3.Click
        If (optEM5X3.Checked) Then
            optEM_2x4.Checked = False
            optEM_65x27.Checked = False
            optEM_5x25.Checked = False
        End If
    End Sub


    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT NotasCred FROM formatos WHERE Facturas='LinkAuto'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cnn2.Close() : cnn2.Open()
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "UPDATE formatos SET NotasCred='" & txtlink.Text & "' WHERE Facturas='LinkAuto'"
                    cmd2.ExecuteNonQuery()
                    cnn2.Close()
                End If
            Else
                cnn2.Close() : cnn2.Open()
                cmd2 = cnn2.CreateCommand
                cmd2.CommandText = "INSERT INTO formatos(Facturas,NotasCred,NumPart) VALUES('LinkAuto','" & txtlink.Text & "','0')"
                cmd2.ExecuteNonQuery()
                cnn2.Close()
            End If
            rd1.Close()
            cnn1.Close()

        Catch ex As Exception

        End Try
    End Sub



    Private Sub cbOrdenEntrega_Click(sender As Object, e As EventArgs) Handles cbOrdenEntrega.Click
        Dim valor As Integer = 0
        If (cbOrdenEntrega.Checked) Then
            valor = 1
        Else
            valor = 0
        End If
        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "UPDATE ticket SET NoPrintCom=" & valor
            cmd1.ExecuteNonQuery()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub chkImg_PDF_Click(sender As Object, e As EventArgs) Handles chkImg_PDF.Click
        If (chkImg_PDF.Checked) Then
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='1' where Facturas='IMG_PDF'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                     "update Formatos set NotasCred='1' where Facturas='IMG_PDF'"
                cmd1.ExecuteNonQuery()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        End If
    End Sub
End Class