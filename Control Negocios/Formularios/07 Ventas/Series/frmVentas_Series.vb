Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

Public Class frmVentas_Series

    Public IMPRE As String = ""

    'Variables del formulario

    Dim EditaPrecio As Boolean = False
    Dim DondeVoy As String = ""
    Dim Promo As Boolean = False
    Dim modo_caja As String = ""
    Dim MyIdCliente As Integer = 0
    Dim T_Precio As String = ""
    Dim H_Inicia As String = ""
    Dim H_Final As String = ""
    Dim Anti As String = ""
    Dim ItWasDropDown As Boolean = False
    Dim MyNota As String = ""
    Dim renglon As Integer = 0
    Dim cbonombretag As String = ""
    Dim MYFOLIO As Integer = 0
    Dim TipoDevolucion As Integer = 0
    Dim SalenDevos As Double = 0

    Dim Entrega As Boolean = False

    Dim printLine As Integer = 0
    Dim Contador As Integer = 0
    Dim PosicionSinEncabezado As Integer = 0
    Dim pagina As Integer = 0

    Dim Busqueda As Boolean = False
    Dim Serchi As Boolean = False

    Dim termina As Boolean = False
    Dim pie_nota As Boolean = False

    Private config As datosSincronizador
    Private configF As datosAutoFac
    Private filenum As Integer
    Private recordLen As String
    Private currentRecord As Long
    Private lastRecord As Long
    Public franquicia As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Folio()
        Timer1.Start()
    End Sub

#Region "Funciones"
    Public Sub Folio()
        Try
            If cnn9.State = 1 Then cnn9.Close()
            cnn9.Open()

            cmd9 = cnn9.CreateCommand
            If Me.Text = "Ventas Series" Then
                cmd9.CommandText =
                    "select MAX(Folio) from Ventas"
            End If
            If Me.Text = "Cotización Series" Then
                cmd9.CommandText =
                    "select MAX(Folio) from CotPed"
            End If
            If Me.Text = "" Then Exit Sub
            rd9 = cmd9.ExecuteReader
            If rd9.HasRows Then
                If rd9.Read Then
                    lblfolio.Text = CDbl(IIf(rd9(0).ToString = "", "0", rd9(0).ToString)) + 1
                Else
                    lblfolio.Text = "1"
                End If
            Else
                lblfolio.Text = "1"
            End If
            rd9.Close() : cnn9.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn9.Close()
        End Try
    End Sub

    Public Sub CodBar()
        If cbocodigo.Text = "" And cbodesc.Text = "" Then Exit Sub
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            If cbocodigo.Text = "" Then
                cmd3.CommandText =
                    "select * from Productos where CodBarra='" & cbodesc.Text & "'"
            Else
                cmd3.CommandText =
                    "select * from Productos where CodBarra='" & cbocodigo.Text & "'"
            End If
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    cbocodigo.Text = rd3("Codigo").ToString
                    Anti = rd1("Grupo").ToString
                End If
            Else
                cnn4.Close() : cnn4.Open()
                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                    "select * from Productos where "
                If IsNumeric(cbodesc.Text) Then
                    cbodesc.Text = ""
                    rd3.Close() : cnn3.Close() : Exit Sub
                End If
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub

    Private Sub UpGrid()
        Dim TPapel As String = ""
        Dim Conteo As Double = 0
        Dim Alerta_Min As Boolean = False
        Dim Acumula As Boolean = False
        Dim minimo As Double = 0

        Try
            cnn3.Close() : cnn3.Open()

            'cmd3 = cnn3.CreateCommand
            'cmd3.CommandText =
            '    "select NotasCred from Formatos where Facturas='TPapelV'"
            'rd3 = cmd3.ExecuteReader
            'If rd3.HasRows Then
            '    If rd3.Read Then
            '        TPapel = rd3(0).ToString
            '    End If
            'End If
            'rd3.Close()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select NotasCred from Formatos where Facturas='MinimoA'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Alerta_Min = IIf(rd3(0).ToString() = "1", True, False)
                End If
            End If
            rd3.Close()

            cnn3.Close()

            If TPapel = "MEDIA CARTA" Then
                If grdcaptura.Rows.Count > 13 Then
                    MsgBox("Se establecen 13 partidas como máximo para el formato de impresión 'MEDIA CARTA'", vbInformation + vbOK, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If
            End If

            Dim Val_Punto As Integer = 0
            Dim Mid_precio As String = ""

            Dim codigo As String = cbocodigo.Text
            Dim nombre As String = cbodesc.Text
            Dim unidad As String = txtunidad.Text
            Dim cantid As Double = IIf(txtcantidad.Text = "", "0", txtcantidad.Text)
            Dim precio As Double = 0

            Val_Punto = InStr(1, txtprecio.Text, ".")
            If Val_Punto = 0 Then
                precio = FormatNumber(txtprecio.Text, 2)
            Else
                Mid_precio = Mid(txtprecio.Text, Val_Punto, 20)
                If Len(Mid_precio) = 2 Then
                    precio = FormatNumber(txtprecio.Text, 2)
                ElseIf Len(Mid_precio) > 2 Then
                    precio = FormatNumber(txtprecio.Text, 2)
                End If
            End If

            Dim total As Double = txttotal.Text

            Dim existencia As Double = 0
            If unidad <> "N/A" Then
                existencia = txtexistencia.Text
            Else
                existencia = 0
            End If
            Dim lote As String = cboSerie.Text
            Dim id_lote As Integer = IIf(cboSerie.Tag = 0, 0, cboSerie.Tag)
            Dim fcad As String = txtfechacad.Text
            Dim PU As Double = CDbl(txttotal.Text) / (1 + IvaDSC(cbocodigo.Text))

            Dim IvaIeps As Double = PU - (PU / (1 + ProdsIEPS(cbocodigo.Text)))
            Dim ieps As Double = ProdsIEPS(cbocodigo.Text)

            Dim desucentoiva As Double = 0
            Dim total1 As Double = 0
            Dim monedero As Double = 0
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IVA,Promo_Monedero,Min from Productos where Codigo='" & cbocodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    monedero = rd3(1).ToString()
                    minimo = rd3(2).ToString()
                    If CDbl(rd3(0).ToString) = 0.16 Then
                        desucentoiva = FormatNumber(CDbl(txttotal.Text) / 1.16, 2)
                        total1 = FormatNumber(CDbl(txttotal.Text) / 1.16, 2)
                    Else
                        desucentoiva = FormatNumber(txttotal.Text, 2)
                        total1 = 0
                    End If
                End If
            Else
                desucentoiva = FormatNumber(txttotal.Text, 2)
                total1 = 0
            End If
            rd3.Close()
            cnn3.Close()

            'Sólo agrega y ya
            grdcaptura.Rows.Add(codigo, nombre, unidad, cantid, FormatNumber(precio, 2), FormatNumber(total, 2), existencia, id_lote, lote, fcad, FormatNumber(IvaIeps, 2), FormatNumber(ieps, 2), desucentoiva, total1, monedero)

            If Alerta_Min = True Then
                If (existencia - cantid) <= minimo Then
                    MsgBox("Se ha alcanzo el mínimo en almacén para este producto.", vbCritical & vbOKOnly, "Delsscom Control Negocios Pro")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Sub
    Private Function ConsultaPrecio(ByVal codigo As String, ByVal cantidad As Double) As Double
        Dim precio_base As Double = 0

        Try
            cnn4.Close() : cnn4.Open()

            Dim temp As Double = 0
            Dim TiCambio As Double = 0
            Dim H_Actual As String = Format(Date.Now, "HH:mm")

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select tipo_cambio from tb_moneda,Productos where Codigo='" & codigo & "' and Productos.id_tbMoneda=tb_moneda.id"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    TiCambio = rd4(0).ToString
                    If TiCambio = 0 Then TiCambio = 1
                End If
            Else
                TiCambio = 1
            End If
            rd4.Close()

            If cbotipo.Visible = False Then

                Dim ATemp1, ATemp2, ATemp3, ATemp4 As Double

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                    "select * from Productos where Codigo='" & codigo & "'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                            precio_base = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString)) * TiCambio
                            precio_base = FormatNumber(precio_base, 2)
                        Else
                            precio_base = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString)) * TiCambio
                            precio_base = FormatNumber(txtprecio.Text, 2)

                            If Not IsDBNull(rd4("CantLst1").ToString) And Not IsDBNull(rd4("CantLst2").ToString) Then
                                If CDbl(cantidad) >= CDbl(rd4("CantLst1").ToString) And CDbl(cantidad) <= CDbl(rd4("CantLst2").ToString) Then
                                    precio_base = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString))
                                    precio_base = FormatNumber(precio_base, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantEsp1").ToString) And Not IsDBNull(rd4("CantEsp2").ToString) Then
                                ATemp1 = rd4("CantEsp1").ToString
                                If CDbl(cantidad) >= CDbl(rd4("CantEsp1").ToString) And CDbl(cantidad) <= CDbl(rd4("CantEsp2").ToString) Then
                                    precio_base = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString))
                                    precio_base = FormatNumber(precio_base, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMM1").ToString) And Not IsDBNull(rd4("CantMM2").ToString) Then
                                ATemp2 = rd4("CantMM1").ToString
                                If CDbl(cantidad) >= CDbl(rd4("CantMM1").ToString) And CDbl(cantidad) <= CDbl(rd4("CantMM2").ToString) Then
                                    precio_base = CDbl(IIf(rd4("PreMM").ToString = "", "0", rd4("PreMM").ToString))
                                    precio_base = FormatNumber(precio_base, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMay1").ToString) And Not IsDBNull(rd4("CantMay2").ToString) Then
                                ATemp3 = rd4("CantMay1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMay1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMay2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMay").ToString = "", "0", rd4("PreMay").ToString))
                                    txtprecio.Text = FormatNumber(precio_base, 2)
                                    txtprecio.Tag = FormatNumber(precio_base, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMin1").ToString) And Not IsDBNull(rd4("CantMin2").ToString) Then
                                ATemp4 = rd4("CantMin1").ToString
                                If CDbl(cantidad) >= CDbl(rd4("CantMin1").ToString) And CDbl(cantidad) <= CDbl(rd4("CantMin2").ToString) Then
                                    precio_base = CDbl(IIf(rd4("PreMin").ToString = "", "0", rd4("PreMin").ToString))
                                    precio_base = FormatNumber(precio_base, 2)
                                    temp = 1
                                End If
                            End If

                        End If

                        If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Then
                            If temp = 0 Then
                                cnn5.Close() : cnn5.Open()
                                cmd5 = cnn5.CreateCommand
                                cmd5.CommandText =
                                    "select * from Productos where Codigo='" & codigo & "'"
                                rd5 = cmd5.ExecuteReader
                                If rd5.HasRows Then
                                    If rd5.Read Then
                                        precio_base = CDbl(IIf(rd5("PrecioVentaIVA").ToString = "", "0", rd5("PrecioVentaIVA").ToString))
                                        precio_base = FormatNumber(precio_base, 2)
                                    End If
                                Else
                                    MsgBox("El producto no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                End If
                                rd5.Close()
                                cnn5.Close()
                                rd4.Close() : cnn4.Close()
                                Return precio_base
                                Exit Function
                            End If
                        End If
                    End If
                End If
                rd4.Close()
            End If
            cnn4.Close()

            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                precio_base = CalPreDevo(cbonota.Text, codigo)
                precio_base = FormatNumber(precio_base, 2)
            End If
            If precio_base = 0 Then precio_base = 0

            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try

        Return precio_base
    End Function
    Private Sub Actualiza()
        If txtSubTotal.Tag = 0 Then
            txtSubTotal.Text = txtSubTotal.Text
            txtSubTotal.Text = CDbl(IIf(txtSubTotal.Text = "", "0", txtSubTotal.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text))
            txtSubTotal.Text = FormatNumber(txtSubTotal.Text, 2)
        End If
        If txtSubTotal.Tag <> 0 Then
            txtSubTotal.Text = txtSubTotal.Text
        End If
    End Sub
    Private Function CalPreDevo(ByVal folio As Integer, ByVal cod As String) As Double
        Dim precio As Double = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Precio from VentasDetalle where Folio=" & folio & " and Codigo='" & cbocodigo.Text & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    precio = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                precio = 0
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try

        Return precio
    End Function
    Public Function IvaDSC(ByVal cod As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select IVA from Productos where Codigo='" & cod & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    IvaDSC = CDbl(IIf(rd3(0).ToString = "", "0", rd3(0).ToString))
                End If
            Else
                IvaDSC = 0
            End If
            rd3.Close()
            cnn3.Close()
            Return IvaDSC
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function
    Private Function ValCantDev(ByVal ka As Integer) As Boolean
        Try
            Dim getpaso As Boolean = False
            ValCantDev = False

            If cbonota.Text <> "" Then
                If cbocodigo.Text <> "" And ka = 13 Then
                    Call Cant(cbocodigo.Text, getpaso)
                    ValCantDev = getpaso
                End If
            Else
                ValCantDev = True
            End If

            Return ValCantDev
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Function
    Private Sub Cant(ByVal codigo As String, ByRef paso As Boolean)
        Dim canti As Double = 0
        If txtcantidad.Text = "" Then Exit Sub
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                "select Folio,Codigo,Cantidad from VentasDetalle where Folio=" & cbonota.Text & " and Codigo='" & codigo & "' order by Nombre"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    canti = rd5("Cantidad").ToString
                    If CDbl(txtcantidad.Text) > canti Then
                        MsgBox("No puedes devolver una cantidad mayor a la vendida.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtcantidad.SelectionStart = 0
                        txtcantidad.SelectionLength = Len(txtcantidad.Text)
                        rd5.Close() : cnn5.Close()
                        paso = False
                        Exit Sub
                    Else
                        paso = True
                        txtprecio.Focus().Equals(True)
                    End If
                End If
            End If
            rd5.Close()
            cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
    End Sub
    Private Function CantLte() As Double
        If cboSerie.Tag <> 0 Then
            Try
                cnn5.Close() : cnn5.Open()

                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                            "Select Cantidad From LoteCaducidad Where id=" & cboSerie.Tag
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        CantLte = rd5(0).ToString
                    End If
                End If
                rd5.Close() : cnn5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn5.Close()
            End Try
        End If
    End Function
    Private Function Cambio(ByVal Moneda As Double) As Double
        Cambio = 0
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select * from Productos where Codigo='" & Trim(cbocodigo.Text) & "'"
            rd3 = cmd3.ExecuteReader

            Select Case cbotipo.Text
                Case Is = "Lista"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PrecioVentaIVA").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PrecioVentaIVA").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()
                Case Is = "Minimo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMin").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMin").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()
                Case Is = "Mayoreo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMay").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMay").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()
                Case Is = "Medio Mayoreo"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreMM").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreMM").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()
                Case Is = "Especial"
                    If rd3.HasRows Then
                        If rd3.Read Then
                            If Moneda > 0 Then
                                Cambio = CDbl(rd3("PreEsp").ToString) * Moneda
                            Else
                                Cambio = CDbl(rd3("PreEsp").ToString)
                            End If
                        End If
                    End If
                    rd3.Close()
            End Select

            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return Cambio
    End Function
    Private Sub Fn()
        Try
            Dim Imprime As Boolean = False
            Dim TPrint As String = ""
            Dim Imprime_En As String = ""
            Dim Impresora As String = ""
            Dim Tamaño As String = ""
            Dim Pasa_Print As Boolean = False

            Dim pide As String = "", contra As String = txtcontraseña.Text, usu As String = lblusuario.Text

            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select NoPrint from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    Imprime = rd1(0).ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            If (Imprime) Then
                If MsgBox("¿Deseas imprimir nota de venta?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                    Pasa_Print = True
                Else
                    Pasa_Print = False
                End If
            Else
                Pasa_Print = True
            End If

            If (Pasa_Print) Then

                TPrint = cboimpresion.Text

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Tamaño = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If TPrint = "PDF - CARTA" Then

                    'Genera PDF y lo guarda en la ruta
                    Panel6.Visible = True
                    My.Application.DoEvents()
                    Insert_Venta()
                    PDF_Venta()
                    Panel6.Visible = False
                    My.Application.DoEvents()

                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Impresora = rd1(0).ToString
                        End If
                    Else
                        If TPrint = "MEDIA CARTA" Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                            "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    Impresora = rd2(0).ToString()
                                End If
                            Else
                                MsgBox("No tienes una impresora configurada para imprimir en formato " & TPrint & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                rd2.Close() : cnn2.Close()
                                rd1.Close() : cnn1.Close()

                                cnn1.Close() : cnn1.Open()
                                If txtcotped.Text <> "" Then
                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                    "delete from CotPed where Folio=" & txtcotped.Text
                                    cmd1.ExecuteNonQuery()

                                    cmd1 = cnn1.CreateCommand
                                    cmd1.CommandText =
                                    "delete from CotPedDet where Folio=" & txtcotped.Text
                                    cmd1.ExecuteNonQuery()
                                End If

                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "select NotasCred from Formatos where Facturas='PedirContra'"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        pide = rd1(0).ToString
                                    End If
                                End If
                                rd1.Close() : cnn1.Close()

                                btnnuevo.PerformClick()
                                If pide = "1" Then
                                    lblusuario.Text = usu
                                    txtcontraseña.Text = contra
                                End If
                                If modo_caja = "CAJA" Then
                                Else
                                    cboNombre.Text = "MOSTRADOR"
                                End If
                                cbodesc.Focus().Equals(True)
                                MYFOLIO = 0
                                Exit Sub
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                        cnn1.Close()
                    End If
                    rd1.Close() : cnn1.Close()
                End If

                If TPrint = "TICKET" Then
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Ventas() : Exit Sub
                    If Tamaño = "80" Then
                        pVenta80.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pVenta80.Print()
                    End If
                    If Tamaño = "58" Then
                        pVenta58.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pVenta58.Print()
                    End If
                Else
                    'If TPrint = "MEDIA CARTA" Then
                    '    pVentaMediaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                    '    pVentaMediaCarta.Print()
                    'End If                
                    If TPrint = "CARTA" Then
                        If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Ventas() : Exit Sub
                        pVentaCarta.DefaultPageSettings.PrinterSettings.PrinterName = Impresora
                        pVentaCarta.Print()
                    End If
                End If
            End If

            cnn1.Close() : cnn1.Open()
            If txtcotped.Text <> "" Then
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "delete from CotPed where Folio=" & txtcotped.Text
                cmd1.ExecuteNonQuery()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "delete from CotPedDet where Folio=" & txtcotped.Text
                cmd1.ExecuteNonQuery()
            End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='PedirContra'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    pide = rd1(0).ToString
                End If
            End If
            rd1.Close() : cnn1.Close()

            btnnuevo.PerformClick()
            If pide = "1" Then
                lblusuario.Text = usu
                txtcontraseña.Text = contra
            End If
            If modo_caja = "CAJA" Then
            Else
                cboNombre.Text = "MOSTRADOR"
            End If
            cbodesc.Focus().Equals(True)
            MYFOLIO = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub
    Private Sub ActualizaPEPS(ByVal folio As String, ByVal codigo As String, ByVal cantidad As Double)
        Dim cant_registros As Integer = 0
        Dim suma_registros As Double = 0
        Dim cuestan_registros As Double = 0

        Dim costo_registro As Double = 0

        Dim p_nombre As String = ""
        Dim p_unidad As String = ""

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select * from Productos where Codigo='" & codigo & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    p_nombre = rd4("Nombre").ToString()
                    p_unidad = rd4("UVenta").ToString()
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select count(Id) from Costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    cant_registros = rd4(0).ToString()
                End If
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                 "select SUM(Salida) as Salen, SUM(Costo) as Cuestan from Costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    suma_registros = rd4("Salen").ToString()
                    cuestan_registros = rd4("Cuestan").ToString()
                End If
            End If
            rd4.Close()

            If cant_registros = 1 Then
                'Aquí sólo se ocupó una entrada y se inserta con el mismo costo

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "select Costo from Costeo where Referencia='" & folio & "' and Codigo='" & codigo & "' and Concepto='VENTA'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        costo_registro = rd4("Costo").ToString()
                    End If
                End If
                rd4.Close()

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','DEVOLUCION','" & folio & "','" & codigo & "','" & p_nombre & "','" & p_unidad & "'," & cantidad & ",0," & cantidad & "," & costo_registro & ",0,0,'" & lblusuario.Text & "')"
                cmd4.ExecuteNonQuery()
            ElseIf cant_registros > 1 Then
                costo_registro = cuestan_registros / cant_registros

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                     "insert into Costeo(Fecha,Hora,Concepto,Referencia,Codigo,Descripcion,Unidad,Entrada,Salida,Saldo,Costo,Precio,Utilidad,Usuario) values('" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','DEVOLUCION','" & folio & "','" & codigo & "','" & p_nombre & "','" & p_unidad & "'," & cantidad & ",0," & cantidad & "," & costo_registro & ",0,0,'" & lblusuario.Text & "')"
                cmd4.ExecuteNonQuery()
            End If

            cnn4.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn4.Close()
        End Try
    End Sub
    Private Function TotCantBase(ByVal FOL As Integer, ByVal COD As String) As Double
        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Cantidad from VentasDetalle where Folio=" & FOL & " and Codigo='" & COD & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    TotCantBase = rd3(0).ToString
                End If
            Else
                TotCantBase = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function
    Private Function TCantProd(ByVal fol As Integer) As Double
        Dim resultado As Double = 0
        Try
            cnn3.Close() : cnn3.Open()
            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Codigo from VentasDetalle where Folio=" & fol
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                Do While rd3.Read
                    resultado = resultado + 1
                Loop
            Else
                resultado = 0
            End If
            rd3.Close()
            cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
        Return resultado
    End Function
    Private Function DESuni(ByVal FOL As Integer, ByVal COD As String) As Double
        Dim Cant As Double = 0
        Dim TotDesc As Double = 0

        Try
            cnn3.Close() : cnn3.Open()

            cmd3 = cnn3.CreateCommand
            cmd3.CommandText =
                "select Descto, Cantidad from VentasDetalle where Folio=" & FOL & " and Codigo='" & COD & "'"
            rd3 = cmd3.ExecuteReader
            If rd3.HasRows Then
                If rd3.Read Then
                    Cant = rd3("Cantidad").ToString
                    TotDesc = rd3("Descto").ToString
                    DESuni = TotDesc / Cant
                End If
            Else
                DESuni = 0
            End If
            rd3.Close() : cnn3.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn3.Close()
        End Try
    End Function
    Private Function Calcula_Descu(ByVal precio_base As Double, ByVal precio_minimo As Double) As Double
        Dim descuento As Double = 0

        Dim base As Double = precio_base
        Dim mini As Double = precio_minimo
        Dim descontado As Double = base - mini

        Dim ope1 As Double = descontado * 100
        descuento = FormatNumber(ope1 / base, 1)

        Return descuento
    End Function
    Private Function GetCantLote(ByVal cod As String, ByVal lote As String) As Double
        GetCantLote = 0
        If cod = "" Then GetCantLote = 0 : Exit Function
        Try
            cnn5.Close() : cnn5.Open()

            cmd5 = cnn5.CreateCommand
            cmd5.CommandText =
                      "select Cantidad from LoteCaducidad where Codigo='" & cod & "' and Lote='" & lote & "'"
            rd5 = cmd5.ExecuteReader
            If rd5.HasRows Then
                If rd5.Read Then
                    GetCantLote = rd5(0).ToString
                End If
            Else
                GetCantLote = 0
            End If
            rd5.Close() : cnn5.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn5.Close()
        End Try
        Return GetCantLote
    End Function
    Private Function ReviewLote() As Boolean
        ReviewLote = True
        If cboSerie.Text <> "" Then
            ReviewLote = False
            Try
                cnn5.Close() : cnn5.Open()
                cmd5 = cnn5.CreateCommand
                cmd5.CommandText =
                    "select * from LoteCaducidad where Codigo='" & cbocodigo.Text & "' and Lote='" & cboSerie.Text & "' and Cantidad>0"
                rd5 = cmd5.ExecuteReader
                If rd5.HasRows Then
                    If rd5.Read Then
                        cboSerie.Tag = rd5("Id").ToString
                        txtfechacad.Text = rd5("Caducidad").ToString
                        ReviewLote = True
                    End If
                Else
                    MsgBox("El lote no está registrado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cboSerie.Text = ""
                    cboSerie.Tag = 0
                    txtfechacad.Text = ""
                    ReviewLote = False
                End If
                rd5.Close()
                cnn5.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn5.Close()
            End Try
        End If
    End Function
#End Region

    Private Sub frmVentas_Series_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True

        Try

            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "Select * from loginrecargas"
            rd1 = cmd1.ExecuteReader
            If rd1.Read Then
                Button8.Visible = True
            Else
                Button8.Visible = False
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try

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

                Label1.Text = "AutoFact base: " & databaseF
                FileClose()
            Else
                ipserverF = ""
                databaseF = ""
                userbdF = ""
                passbdF = ""
            End If
        End If

        grdcaptura.Rows.Clear()
        grdcaptura.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
        grdcaptura.DefaultCellStyle.SelectionForeColor = Color.Blue

        Dim log As String = ""

        cnn1.Close() : cnn1.Open()
        cnn2.Close() : cnn2.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT NotasCred FROM Formatos WHERE Facturas='TomaContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                tomacontralog = rd1(0).ToString

                If tomacontralog = "1" Then
                    cmd2 = cnn2.CreateCommand
                    cmd2.CommandText = "SELECT Clave,Alias FROM Usuarios WHERE IdEmpleado=" & id_usu_log
                    rd2 = cmd2.ExecuteReader
                    If rd2.HasRows Then
                        If rd2.Read Then
                            txtcontraseña.Text = rd2(0).ToString
                            lblusuario.Text = rd2(1).ToString
                            txtcontraseña.PasswordChar = "*"
                            txtcontraseña.ForeColor = Color.Black
                        End If
                    End If
                    rd2.Close()
                End If
            End If
        End If
        rd1.Close()
        cnn1.Close()
        cnn2.Close()

        cnn4.Close() : cnn4.Open()
        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "select NotasCred from Formatos where Facturas='LogoG'"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                log = rd4(0).ToString
            End If
        End If
        rd4.Close()

        cmd4 = cnn4.CreateCommand
        cmd4.CommandText = "Select NotasCred from Formatos where Facturas='Franquicia'"
        rd4 = cmd4.ExecuteReader
        If rd4.HasRows Then
            If rd4.Read Then
                franquicia = rd4(0).ToString
            End If
        End If
        rd4.Close()
        cnn4.Close()

        If log <> "" Then
            If File.Exists(My.Application.Info.DirectoryPath & "\" & log) Then
                PictureBox2.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\" & log)
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox2.Dock = DockStyle.Fill
                Panel8.Controls.Add(PictureBox2)
            End If
        End If

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select NumPart from Formatos where Facturas='Entregas'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If rd1(0).ToString() = 1 Then
                        Button11.Visible = True
                    Else
                        Button11.Visible = False
                    End If
                End If
            Else
                Button11.Visible = False
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Formato from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='Venta'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    cboimpresion.Text = rd1(0).ToString()
                End If
            Else
                cboimpresion.Text = "TICKET"
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        DondeVoy = ""
        cbonombretag = ""
        renglon = 0
        modo_caja = ""
        Anti = ""
        EditaPrecio = False
        Promo = False
        lblfecha.Text = Date.Now
        dtpFecha_E.Value = Date.Now
        dtpFecha_P.Value = Date.Now
        txtfechacad.Text = ""
        MyIdCliente = 0
        TipoDevolucion = 0
        modo_caja = DatosRecarga("Modo")
        If modo_caja = "MOSTRADOR" Then
            txtefectivo.ReadOnly = True
            cboNombre.Text = "MOSTRADOR"
            cboNombre.Enabled = False
        Else
            txtefectivo.ReadOnly = False
        End If
        Entrega = False
        cbotipo.Text = "Lista"
        txtdia.Text = Weekday(Date.Now)
        Timer1.Start()
        cbodesc.Focus().Equals(True)
    End Sub

    Private Sub frmVentas_Series_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        cbodesc.Focus().Equals(True)
    End Sub

    Private Sub frmVentas_Series_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtdia.Text = Weekday(Date.Now)
    End Sub

    'Ventas
    Private Sub Insert_Venta()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sinfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim ACuenta As Double = 0
        Dim Resta As Double = 0
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sinfo) Then
                .runSp(a_cnn, "delete from VentasDetalle", sinfo)
                .runSp(a_cnn, "delete from Ventas", sinfo)
                sinfo = ""

                ACuenta = FormatNumber((CDbl(txtefectivo.Text) - CDbl(txtCambio.Text)) + CDbl(txtMontoP.Text), 2)
                Resta = FormatNumber(txtResta.Text, 2)

                If CDbl(txtResta.Text) = 0 Then
                    MyStatus = "PAGADO"
                Else
                    MyStatus = "RESTA"
                End If

                If cboNombre.Text <> "" Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            tel_cliente = rd3("Telefono").ToString()
                        End If
                    End If
                    rd3.Close() : cnn3.Close()
                End If

                'Inserta en la tabla de Ventas
                If .runSp(a_cnn, "insert into Ventas(Nombre,Direccion,Totales,Descuento,ACuenta,Resta,Usuario,FVenta,HVenta,Status,Comentario,FolMonedero,CodFactura,Entregas,Telefono) values('" & cboNombre.Text & "','" & txtdireccion.Text & "'," & CDbl(txtPagar.Text) & "," & CDbl(txtdescuento1.Text) & "," & ACuenta & "," & Resta & ",'" & lblusuario.Text & "',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#,#" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "#,'" & MyStatus & "','','',''," & IIf(Entrega = True, 1, 0) & ",'" & tel_cliente & "')", sinfo) Then
                    sinfo = ""
                Else
                    MsgBox(sinfo)
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from Ventas", sinfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                For pipo As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(pipo).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    Dim nombre As String = grdcaptura.Rows(pipo).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(pipo).Cells(3).Value.ToString()
                    Dim precio_original As Double = grdcaptura.Rows(pipo).Cells(4).Value.ToString()
                    Dim total_original As Double = precio_original * cantidad

                    If codigo <> "" Then
                        cod_temp = codigo
                        If .runSp(a_cnn, "insert into VentasDetalle(Folio,Codigo,Nombre,Cantidad,UVenta,Precio_Original,Total_Original,Dscto_Unitario,Dscto_Total,Precio_Descuento,Total_Descuento,Depto,Grupo,CostVR,FechaCad,LoteCad,NumParte) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "'," & precio_original & "," & total_original & ",0,0,0,0,'','','','','','')", sinfo) Then
                            sinfo = ""
                        Else
                            MsgBox(sinfo)
                        End If
                    End If
                    Continue For
doorcita:
                    If grdcaptura.Rows(pipo).Cells(1).Value.ToString() <> "" Then
                        'Es comentario
                        .runSp(a_cnn, "update VentasDetalle set CostVR='" & grdcaptura.Rows(pipo).Cells(1).Value.ToString() & "' where Codigo='" & cod_temp & "' and Folio=" & my_folio, sinfo)
                        sinfo = ""
                    End If
                Next
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub PDF_Venta()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo
        Dim FileNta As New Venta
        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\")
        root_name_recibo = "C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf"

        If File.Exists("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf") Then
            File.Delete("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = "C:\ControlNegociosPro\DL1.mdb"
            .DatabaseName = "C:\ControlNegociosPro\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Dim TotalIEPSPrint As Double = 0
        Dim SubtotalPrint As Double = 0
        Dim MySubtotal As Double = 0
        Dim TotalIVAPrint As Double = 0

        Dim SubTotal As Double = 0
        Dim IVA_Vent As Double = 0
        Dim Total_Ve As Double = 0

        Dim PieNota As String = ""
        Dim Pagare As String = ""

        Dim DesglosaIVA As String = DatosRecarga("Desglosa")

        Try
            txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
            If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"

            cnn1.Close() : cnn1.Open()
            For N As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) <> "" Then
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select IVA from Productos where Codigo='" & CStr(grdcaptura.Rows(N).Cells(0).Value.ToString) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(grdcaptura.Rows(N).Cells(13).Value.ToString) <> 0 Then
                                MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(N).Cells(13).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)))
                                TotalIVAPrint = TotalIVAPrint + (CDbl(grdcaptura.Rows(N).Cells(13).Value.ToString) - (CDbl(grdcaptura.Rows(N).Cells(12).Value.ToString) * (CDbl(txtdescuento1.Text) / 100)) * CDbl(rd1(0).ToString))
                            End If
                        End If
                    End If
                    rd1.Close()
                End If
            Next
            TotalIVAPrint = FormatNumber(TotalIVAPrint, 4)
            MySubtotal = FormatNumber(MySubtotal, 4)

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie1, Pagare from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    PieNota = rd1(0).ToString()
                    Pagare = rd1(1).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        IVA_Vent = FormatNumber(CDbl(txtPagar.Text) - CDbl(TotalIVAPrint), 2)
        SubTotal = FormatNumber(TotalIVAPrint, 2)
        Total_Ve = FormatNumber(CDbl(txtPagar.Text), 2)

        Dim TotTarjeta As Double = 0, TotTransfe As Double = 0, TotMonedero As Double = 0, TotOtros As Double = 0
        If grdpago.Rows.Count > 0 Then
            For R As Integer = 0 To grdpago.Rows.Count - 1
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "TARJETA" Then
                    TotTarjeta = TotTarjeta + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "TRANSFERENCIA" Then
                    TotTransfe = TotTransfe + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "MONEDERO" Then
                    TotMonedero = TotMonedero + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                End If
                If CStr(grdpago.Rows(R).Cells(0).Value.ToString) = "OTRO" Then
                    TotOtros = TotOtros + CDbl(grdpago.Rows(R).Cells(3).Value.ToString)
                End If
            Next
        End If

        'Los totales los va a mandar directos
        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & MYFOLIO & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txtPagar.Text) & "'"

        'Pagos
        If DesglosaIVA = "1" Then
            If SubTotal > 0 Then
                FileNta.DataDefinition.FormulaFields("subtotal").Text = "'" & FormatNumber(SubTotal, 2) & "'"       'Subtotal
            End If
            If IVA_Vent > 0 Then
                If IVA_Vent > 0 And IVA_Vent <> CDbl(txtPagar.Text) Then
                    FileNta.DataDefinition.FormulaFields("iva_vent").Text = "'" & FormatNumber(IVA_Vent, 2) & "'"   'IVA
                End If
            End If
        End If
        FileNta.DataDefinition.FormulaFields("total_vent").Text = "'" & FormatNumber(Total_Ve, 2) & "'"             'Total
        If CDbl(txtefectivo.Text) > 0 Then
            FileNta.DataDefinition.FormulaFields("efectivo_vent").Text = "'" & FormatNumber(txtefectivo.Text, 2) & "'"  'Efectivo
        End If
        If CDbl(txtCambio.Text) > 0 Then
            FileNta.DataDefinition.FormulaFields("cambio_vent").Text = "'" & FormatNumber(txtCambio.Text, 2) & "'"      'Cambio
        End If
        If TotTarjeta > 0 Then
            FileNta.DataDefinition.FormulaFields("tarjeta_vent").Text = "'" & FormatNumber(TotTarjeta, 2) & "'"         'Tarjeta
        End If
        If TotTransfe > 0 Then
            FileNta.DataDefinition.FormulaFields("transferencia_vent").Text = "'" & FormatNumber(TotTransfe, 2) & "'"   'Transferencia
        End If
        If TotMonedero > 0 Then
            FileNta.DataDefinition.FormulaFields("monedero_vent").Text = "'" & FormatNumber(TotMonedero, 2) & "'"       'Monedero
        End If
        If TotOtros > 0 Then
            FileNta.DataDefinition.FormulaFields("otros_vent").Text = "'" & FormatNumber(txtCambio.Text, 2) & "'"       'Otros
        End If
        If CDbl(txtResta.Text) > 0 Then
            FileNta.DataDefinition.FormulaFields("resta_vent").Text = "'" & FormatNumber(txtResta.Text, 2) & "'"        'Resta
        End If

        If Entrega = True Then
            FileNta.DataDefinition.FormulaFields("Fecha_Entrega").Text = "'" & FormatDateTime(dtpFecha_E.Value, DateFormat.ShortDate) & "'"
        End If
        If Pagare <> "" Then
            FileNta.DataDefinition.FormulaFields("Pagare").Text = "'" & Pagare & "'"
        End If

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then

            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf")
            End If

            System.IO.File.Copy("C:\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\VENTAS\Venta_" & MYFOLIO & ".pdf")
        End If
    End Sub

    Public Sub Termina_Error_Ventas()
        Dim pide As String = "", contra As String = txtcontraseña.Text, usu As String = lblusuario.Text

        cnn1.Close() : cnn1.Open()
        If txtcotped.Text <> "" Then
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from CotPed where Folio=" & txtcotped.Text
            cmd1.ExecuteNonQuery()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "delete from CotPedDet where Folio=" & txtcotped.Text
            cmd1.ExecuteNonQuery()
        End If

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
            "select NotasCred from Formatos where Facturas='PedirContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                pide = rd1(0).ToString
            End If
        End If
        rd1.Close() : cnn1.Close()

        btnnuevo.PerformClick()
        If pide = "1" Then
            lblusuario.Text = usu
            txtcontraseña.Text = contra
        End If
        If modo_caja = "CAJA" Then
        Else
            cboNombre.Text = "MOSTRADOR"
        End If
        cbodesc.Focus().Equals(True)
    End Sub

    Private Sub txtcontraseña_Click(sender As Object, e As EventArgs) Handles txtcontraseña.Click
        If txtcontraseña.Text = "CONTRASEÑA" Then
            txtcontraseña.Text = ""
            txtcontraseña.PasswordChar = "*"
            txtcontraseña.ForeColor = Color.Black
        Else
            txtcontraseña.SelectionStart = 0
            txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
        End If
    End Sub

    Private Sub txtcontraseña_GotFocus(sender As Object, e As EventArgs) Handles txtcontraseña.GotFocus
        If txtcontraseña.Text = "CONTRASEÑA" Then
            txtcontraseña.Text = ""
            txtcontraseña.PasswordChar = "*"
            txtcontraseña.ForeColor = Color.Black
        Else
            txtcontraseña.SelectionStart = 0
            txtcontraseña.SelectionLength = Len(txtcontraseña.Text)
        End If
    End Sub

    Private Sub txtcontraseña_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcontraseña.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString
                        btnventa.Focus().Equals(True)
                    End If
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            If DondeVoy = "Venta" Then
                btnventa.Focus().Equals(True)
            End If
            If DondeVoy = "Cotiza" Then
                Button3.Focus().Equals(True)
            End If
            If DondeVoy = "Devo" Then
                btndevo.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtcontraseña_LostFocus(sender As Object, e As EventArgs) Handles txtcontraseña.LostFocus
        If txtcontraseña.Text = "" Then
            txtcontraseña.Text = "CONTRASEÑA"
            txtcontraseña.PasswordChar = ""
            txtcontraseña.ForeColor = Color.Gray
        End If
    End Sub


    'Pantalla
    Private Sub cboNombre_DropDown(sender As Object, e As EventArgs) Handles cboNombre.DropDown
        cboNombre.Items.Clear()
        If franquicia = 0 Then
            If Busqueda = True Then
                Busqueda = False
            Else
                cboNombre.Items.Clear()
                Try
                    cnn1.Close() : cnn1.Open()
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                            "select Nombre from Clientes where Nombre<>''"
                    rd1 = cmd1.ExecuteReader
                    Do While rd1.Read
                        If rd1.HasRows Then cboNombre.Items.Add(rd1(0).ToString)
                    Loop
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
        Else
            Try
                Dim cnn As MySqlConnection = New MySqlConnection
                Dim sSQL As String = "Select Distinct nombre from sucursales order by Nombre"
                Dim dt1 As New DataTable
                Dim dr As DataRow
                Dim sinfo As String = ""
                Dim oData As New ToolKitSQL.myssql
                With oData
                    If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                        If .getDt(cnn, dt1, sSQL, "etres") Then
                            For Each dr In dt1.Rows
                                cboNombre.Items.Add(dr("nombre").ToString)
                            Next
                        End If
                        cnn.Close()
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cboNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboNombre.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            If franquicia = 0 Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If (rd1("Suspender").ToString) Then MsgBox("Venta suspendida a este cliente." & vbNewLine & "Consulta con el administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : rd1.Close() : cnn1.Close() : Exit Sub
                            cbotipo.Text = rd1("Tipo").ToString
                            MyIdCliente = rd1("Id").ToString
                            lblNumCliente.Text = MyIdCliente
                            txtcredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                            cbocomisionista.Text = rd1("Comisionista").ToString
                            If Trim(cbocomisionista.Text) <> "" Then
                                cbocomisionista.Enabled = True
                            Else
                                cbocomisionista.Enabled = False
                            End If

                            txtafavor.Text = FormatNumber(rd1("SaldoFavor").ToString(), 2)

                            Label1.Visible = True
                            cboDomi.Visible = True
                            Label20.Visible = True
                            txtcredito.Visible = True
                            Label19.Visible = True
                            cbotipo.Visible = True
                            Label17.Visible = True
                            txtafavor.Visible = True
                            Label18.Visible = True
                            txtadeuda.Visible = True
                        End If
                    Else
                        cbocodigo.Text = ""
                        cbodesc.Text = ""
                        txtunidad.Text = ""
                        txtcantidad.Text = ""
                        txtprecio.Text = "0.00"
                        txtprecio.Tag = 0
                        txttotal.Text = "0.00"
                        txtexistencia.Text = ""
                        cboSerie.Text = ""
                        cboSerie.Tag = 0
                        cboDomi.Text = ""
                        txtcredito.Text = "0.00"
                        txtafavor.Text = "0.00"
                        txtadeuda.Text = "0.00"
                        txtfechacad.Text = ""
                        Label1.Visible = False
                        cboDomi.Visible = False
                        Label20.Visible = False
                        txtcredito.Visible = False
                        Label19.Visible = False
                        cbotipo.Visible = False
                        Label17.Visible = False
                        txtafavor.Visible = False
                        Label18.Visible = False
                        txtadeuda.Visible = False

                        cbocomisionista.Enabled = False
                        cbocomisionista.Text = ""
                        lblNumCliente.Text = "MOSTRADOR"
                        cboNombre.SelectionStart = 0
                        cboNombre.SelectionLength = Len(cboNombre.Text)
                        MyIdCliente = 0
                        rd1.Close()
                        cnn1.Close()
                        txtdireccion.Focus().Equals(True)
                        Exit Sub
                    End If
                    rd1.Close()

                    Dim MySaldo As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where Cliente='" & cboNombre.Text & "')"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                            If MySaldo > 0 Then
                                txtadeuda.Text = Math.Abs(MySaldo)
                                txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
                            Else
                                txtadeuda.Text = "0.00"
                            End If
                        End If
                    Else
                        txtadeuda.Text = "0.00"
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                txtdireccion.Focus().Equals(True)
            Else
                Try
                    If cboNombre.Text = "" Then Exit Sub
                    cbonombretag = cboNombre.Text

                    Dim cnn As MySqlConnection = New MySqlConnection
                    Dim sinfo As String = ""
                    Dim oData As New ToolKitSQL.myssql
                    Dim oData1 As New ToolKitSQL.myssql
                    Dim dt As New DataTable
                    Dim dr As DataRow
                    Dim dt1 As New DataTable
                    Dim dr1 As DataRow
                    With oData
                        If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                            If .getDt(cnn, dt1, "Select id from sucursales where nombre='" & cboNombre.Text & "'", "dtUno") Then
                                For Each dr1 In dt1.Rows
                                    MyIdCliente = dr1("id").ToString
                                    lblNumCliente.Text = MyIdCliente
                                    Label1.Visible = True
                                    cboDomi.Visible = True
                                    Label20.Visible = True
                                    txtcredito.Visible = True
                                    Label19.Visible = True
                                    cbotipo.Visible = True
                                    Label17.Visible = True
                                    txtafavor.Visible = True
                                    Label18.Visible = True
                                    txtadeuda.Visible = True
                                    chkBuscaCliente.Checked = False
                                    txtNombreClave.Text = ""
                                Next
                            End If

                            If lblNumCliente.Text = "MOSTRADOR" Then MyIdCliente = 0 : Exit Sub
                            cbocodigo.Text = ""
                            cbodesc.Text = ""
                            txtunidad.Text = ""
                            txtcantidad.Text = ""
                            txtprecio.Text = "0.00"
                            txtprecio.Tag = 0
                            txttotal.Text = "0.00"
                            txtexistencia.Text = ""
                            cboSerie.Text = ""
                            cboSerie.Tag = 0
                            cboDomi.Text = ""
                            txtadeuda.Text = "0.00"
                            txtafavor.Text = "0.00"
                            txtfechacad.Text = ""

                            cnn.Close()
                            If cboNombre.Text = "" Then lblNumCliente.Text = "MOSTRADOR" : MyIdCliente = 0
                        End If
                    End With
                Catch ex As Exception
                    cnn1.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub cboNombre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboNombre.SelectedValueChanged
        Dim MySaldo As Double = 0
        If franquicia = 0 Then
            Try
                If cboNombre.Text = "" Then Exit Sub
                cbonombretag = cboNombre.Text

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        If (rd1("Suspender").ToString) Then MsgBox("Venta suspendida a este cliente." & vbNewLine & "Consulta con el administrador.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : rd1.Close() : cnn1.Close() : Exit Sub
                        cbotipo.Text = rd1("Tipo").ToString
                        MyIdCliente = rd1("Id").ToString
                        lblNumCliente.Text = MyIdCliente
                        txtcredito.Text = FormatNumber(rd1("Credito").ToString, 2)
                        cbocomisionista.Text = rd1("Comisionista").ToString
                        txttel.Text = rd1("Telefono").ToString
                        If Trim(cbocomisionista.Text) <> "" Then
                            cbocomisionista.Enabled = False
                        Else
                            cbocomisionista.Enabled = True
                        End If

                        txtafavor.Text = FormatNumber(rd1("SaldoFavor").ToString(), 2)

                        Label1.Visible = True
                        cboDomi.Visible = True
                        Label20.Visible = True
                        txtcredito.Visible = True
                        Label19.Visible = True
                        cbotipo.Visible = True
                        Label17.Visible = True
                        txtafavor.Visible = True
                        Label18.Visible = True
                        txtadeuda.Visible = True
                        chkBuscaCliente.Checked = False
                        txtNombreClave.Text = ""
                    End If
                End If
                rd1.Close()

                If lblNumCliente.Text = "MOSTRADOR" Then MyIdCliente = 0 : Exit Sub

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select Saldo from AbonoI where Id=(select max(Id) from AbonoI where Cliente='" & cboNombre.Text & "')"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MySaldo = CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString))
                        If MySaldo > 0 Then
                            txtadeuda.Text = Math.Abs(MySaldo)
                            txtadeuda.Text = FormatNumber(txtadeuda.Text, 2)
                        Else
                            txtadeuda.Text = "0.00"
                        End If
                    End If
                Else
                    cbocodigo.Text = ""
                    cbodesc.Text = ""
                    txtunidad.Text = ""
                    txtcantidad.Text = ""
                    txtprecio.Text = "0.00"
                    txtprecio.Tag = 0
                    txttotal.Text = "0.00"
                    txtexistencia.Text = ""
                    cboSerie.Text = ""
                    cboSerie.Tag = 0
                    cboDomi.Text = ""
                    txtadeuda.Text = "0.00"
                    txtafavor.Text = "0.00"
                    txtfechacad.Text = ""
                End If
                rd1.Close()
                cnn1.Close()
                If cboNombre.Text = "" Then lblNumCliente.Text = "MOSTRADOR" : MyIdCliente = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn1.Close()
            End Try
        Else
            Try
                If cboNombre.Text = "" Then Exit Sub
                cbonombretag = cboNombre.Text

                Dim cnn As MySqlConnection = New MySqlConnection
                Dim sinfo As String = ""
                Dim oData As New ToolKitSQL.myssql
                Dim oData1 As New ToolKitSQL.myssql
                Dim dt As New DataTable
                Dim dr As DataRow
                Dim dt1 As New DataTable
                Dim dr1 As DataRow
                With oData
                    If .dbOpen(cnn, sTargetdSincro, sinfo) Then
                        If .getDt(cnn, dt1, "Select id from sucursales where nombre='" & cboNombre.Text & "'", "dtUno") Then
                            For Each dr1 In dt1.Rows
                                MyIdCliente = dr1("id").ToString
                                lblNumCliente.Text = MyIdCliente
                                Label1.Visible = True
                                cboDomi.Visible = True
                                Label20.Visible = True
                                txtcredito.Visible = True
                                Label19.Visible = True
                                cbotipo.Visible = True
                                Label17.Visible = True
                                txtafavor.Visible = True
                                Label18.Visible = True
                                txtadeuda.Visible = True
                                chkBuscaCliente.Checked = False
                                txtNombreClave.Text = ""
                            Next
                        End If

                        If lblNumCliente.Text = "MOSTRADOR" Then MyIdCliente = 0 : Exit Sub
                        cbocodigo.Text = ""
                        cbodesc.Text = ""
                        txtunidad.Text = ""
                        txtcantidad.Text = ""
                        txtprecio.Text = "0.00"
                        txtprecio.Tag = 0
                        txttotal.Text = "0.00"
                        txtexistencia.Text = ""
                        cboSerie.Text = ""
                        cboSerie.Tag = 0
                        cboDomi.Text = ""
                        txtadeuda.Text = "0.00"
                        txtafavor.Text = "0.00"
                        txtfechacad.Text = ""

                        cnn.Close()
                        If cboNombre.Text = "" Then lblNumCliente.Text = "MOSTRADOR" : MyIdCliente = 0
                    End If
                End With
            Catch ex As Exception
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbotipo_DropDown(sender As Object, e As EventArgs) Handles cbotipo.DropDown
        cbotipo.Items.Clear()
        cbotipo.Items.Add("Lista")
        cbotipo.Items.Add("Mayoreo")
        cbotipo.Items.Add("Medio Mayoreo")
        cbotipo.Items.Add("Minimo")
        cbotipo.Items.Add("Especial")
    End Sub

    Private Sub cboDomi_DropDown(sender As Object, e As EventArgs) Handles cboDomi.DropDown
        cboDomi.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Contador from Entregas where IdCliente=(select Id from Clientes where Nombre='" & cboNombre.Text & "')"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then
                    cboDomi.Items.Add(rd1(0).ToString())
                End If
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub cboDomi_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDomi.SelectedValueChanged
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                 "select Domicilio from Entregas where Contador=" & cboDomi.Text & " and IdCliente=(select Id from Clientes where Nombre='" & cboNombre.Text & "')"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    txtdireccion.Text = rd1(0).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtdireccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdireccion.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txttel.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbocomisionista_DropDown(sender As Object, e As EventArgs) Handles cbocomisionista.DropDown
        cbocomisionista.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Alias from Usuarios where Comisionista=1"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocomisionista.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocomisionista_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocomisionista.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            btnventa.Focus().Equals(True)
        End If
    End Sub

    Private Sub picProd_DoubleClick(sender As Object, e As EventArgs) Handles picProd.DoubleClick
        If picProd.Width = 72 Then
            picProd.Left = 767
            picProd.Top = 93
            picProd.Width = 158
            picProd.Height = 158
        Else
            picProd.Left = 853
            picProd.Top = 96
            picProd.Width = 72
            picProd.Height = 72
        End If
    End Sub

    Private Sub cbonota_DropDown(sender As Object, e As EventArgs) Handles cbonota.DropDown
        cbonota.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Ventas where Status<>'CANCELADA' order by Folio"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbonota.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbonota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbonota.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbonota_LostFocus(sender As Object, e As EventArgs) Handles cbonota.LostFocus
        If cbonota.Text <> "" Then
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Ventas where Folio=" & cbonota.Text
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        MyIdCliente = rd1("IdCliente").ToString
                        lblNumCliente.Text = IIf(rd1("IdCliente").ToString = "0", "MOSTRADOR", rd1("IdCliente").ToString)
                        cboNombre.Text = rd1("Cliente").ToString
                        'txtDireccion.Text = rd1("Direccion").ToString
                        lblfolio.Text = cbonota.Text
                        cbodesc.Focus().Equals(True)
                    End If
                Else
                    MsgBox("No existe el folio ingresado.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    btnnuevo.PerformClick()
                    rd1.Close() : cnn1.Close()
                    btndevo.Focus().Equals(True)
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        Else
            btndevo.Text = "DEVOLUCIÓN"
            btnnuevo.PerformClick()
            Exit Sub
        End If
    End Sub

    Private Sub cbonota_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbonota.SelectedValueChanged
        cbodesc.Focus().Equals(True)
        Call cbonota_LostFocus(cbonota, New EventArgs())
    End Sub

    Private Sub txtMonedero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonedero.KeyPress
        Dim saldo As Double = 0
        If AscW(e.KeyChar) = Keys.Enter Then
            If txtMonedero.Text = "" Then Exit Sub
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Monedero where Barras='" & txtMonedero.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        saldo = rd1("Saldo").ToString
                        If saldo > 0 Then
                            lblmonedero.BackColor = Color.Lime
                            MsgBox("El cliente cuenta con un saldo de " & FormatNumber(saldo, 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        End If
                    End If
                Else
                    lblmonedero.BackColor = Color.White
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub cboimpresion_DropDown(sender As Object, e As EventArgs) Handles cboimpresion.DropDown
        cboimpresion.Items.Clear()
        cboimpresion.Items.Add("TICKET")
        'cboimpresion.Items.Add("CARTA")
        'cboimpresion.Items.Add("MEDIA CARTA")
        cboimpresion.Items.Add("PDF - CARTA")
    End Sub

    Private Sub chkBuscaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscaCliente.CheckedChanged
        If (chkBuscaCliente.Checked) Then
            txtNombreClave.Text = ""
            Busqueda = False
            Panel2.Visible = True
            txtNombreClave.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtNombreClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cboNombre.Items.Clear()

            Try
                cnn2.Close() : cnn2.Open()

                cmd2 = cnn2.CreateCommand
                cmd2.CommandText =
                    "select Nombre from Clientes where Nombre like '%" & txtNombreClave.Text & "%' order by Nombre"
                rd2 = cmd2.ExecuteReader
                Do While rd2.Read
                    If rd2.HasRows Then cboNombre.Items.Add(rd2(0).ToString())
                Loop
                rd2.Close()
                cnn2.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn2.Close()
            End Try
            Busqueda = True
            Panel2.Visible = False
            chkBuscaCliente.Checked = False
            cboNombre.Focus().Equals(True)
        End If
    End Sub

    'productos
    Private Sub cbodesc_DropDown(sender As Object, e As EventArgs) Handles cbodesc.DropDown

        If Serchi = True Then
            Serchi = False
        Else
            cbodesc.Items.Clear()
            Try
                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                If cbonota.Text = "" Then
                    cmd1.CommandText =
                        "select distinct Nombre from Productos where Grupo<>'INSUMO' and ProvRes<>1 order by Nombre"
                Else
                    cmd1.CommandText =
                        "select distinct Nombre from VentasDetalle where Folio=" & cbonota.Text & " order by Nombre"
                End If
                rd1 = cmd1.ExecuteReader
                Do While rd1.Read
                    If rd1.HasRows Then cbodesc.Items.Add(
                        rd1(0).ToString
                        )
                Loop
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If

    End Sub

    Private Sub cbodesc_GotFocus(sender As Object, e As EventArgs) Handles cbodesc.GotFocus
        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")
    End Sub

    Private Sub cbodesc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbodesc.SelectedValueChanged
        Dim tasm_impre As String = DatosRecarga("TPapelV")
        Dim MyCode As String = ""

        If tasm_impre = "MEDIA CARTA" And grdcaptura.Rows.Count > 12 Then MsgBox("Se establecen 13 partidas como máximo para el formato de impresión 'MEDIA CARTA'", vbInformation + vbOK, "Delsscom Control Negocios Pro") : cbodesc.Text = "" : Exit Sub

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select Codigo,Grupo from Productos where Nombre='" & cbodesc.Text & "'"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    MyCode = rd4(0).ToString
                    ' cbocodigo.Text = ""
                    cbocodigo.Text = MyCode
                End If
            Else
                MsgBox("Producto no registrado en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                rd4.Close()
                cnn4.Close()
                Exit Sub
            End If
            rd4.Close()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select Codigo from Productos where Left(Codigo, 6)='" & MyCode & "'"
            rd4 = cmd4.ExecuteReader
            Do While rd4.Read
                If rd4.HasRows Then cbocodigo.Items.Add(
                    rd4(0).ToString
                    )
            Loop
            rd4.Close()
            cnn4.Close()

            'txtunidad.Text = ""
            'txtprecio.Text = "0.00"
            'txtprecio.Tag = 0
            'txtexistencia.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
    End Sub

    Private Sub cbodesc_KeyDown(sender As Object, e As KeyEventArgs) Handles cbodesc.KeyDown
        Select Case e.KeyCode
            Case Is = Keys.F2
                If cbodesc.Text <> "" Then MsgBox("Primero baja el producto para asignar un comentario.", vbInformation + vbOKOnly, titulocentral) : cbodesc.Focus().Equals(True) : Exit Sub
                If grdcaptura.Rows.Count = 0 Then MsgBox("No cuentas con productos para asignar comentarios.", vbInformation + vbOKOnly, titulocentral) : Exit Sub
                If txtcoment.Visible = False Then
                    txtcoment.Visible = True
                    txtcoment.Focus().Equals(True)
                Else
                    txtcoment.Visible = False
                    cbodesc.Focus().Equals(True)
                End If
            Case Is = Keys.F3
                frmBuscaVentas.Vienna = "Ventas1"
                frmBuscaVentas.Show()
            Case Is = Keys.F5
                frmVentasKit.Vienna = "Ventas1"
                frmVentasKit.Show()
            Case Is = Keys.F7
                chkBuscaProd.Checked = True
        End Select
    End Sub

    Private Sub cbodesc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodesc.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim Multiplica As String = ""
        Dim VSE As Boolean = False
        Dim H_Actual As String = Format(Date.Now, "HH:mm")

        Dim Multiplo As Double = 0
        Dim Minimo As Double = 0
        Dim TiCambio As Double = 0
        Dim PreLst As Double = 0, PreEsp As Double = 0

        If AscW(e.KeyChar) = Keys.Enter And cbodesc.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            If Strings.Left(cbodesc.Text, 1) = "*" Then
                Multiplica = "*"
                cbodesc.Text = Mid(cbodesc.Text, 2, 99)
            End If

            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select VSE from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        VSE = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Productos where Nombre='" & cbodesc.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Promo = IIf(rd1("Status_Promocion").ToString = False, False, True)
                        Anti = rd1("Grupo").ToString
                        If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                            If MsgBox("Este en un " & Anti & " ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                cbocodigo.Text = ""
                                cbodesc.Text = ""
                                txtunidad.Text = ""
                                txtcantidad.Text = ""
                                txtprecio.Text = "0.00"
                                txtprecio.Tag = 0
                                txttotal.Text = "0.00"
                                txtexistencia.Text = ""
                                cboSerie.Text = ""
                                cboSerie.Tag = 0
                                txtfechacad.Text = ""
                                txtubicacion.Text = ""
                                cbodesc.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                        If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            cbocodigo.Focus().Equals(True)
                            rd1.Close()
                            cnn1.Close()
                            Exit Sub
                        End If

                        cbocodigo.Text = rd1("Codigo").ToString()
                        cbodesc.Text = rd1("Nombre").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                        Multiplo = rd1("MCD").ToString()
                        Minimo = rd1("Min").ToString()
                        txtubicacion.Text = rd1("Ubicacion").ToString()

                        cnn2.Close() : cnn2.Open() : cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                txtexistencia.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) * Multiplo
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select FechaC from ComprasDet where Codigo='" & cbocodigo.Text & "' LIMIT 1"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                Label2.Text = "Descrpción " & FormatDateTime(rd2(0).ToString, DateFormat.ShortDate)
                            End If
                        Else
                            Label2.Text = "Descrpción"
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                TiCambio = rd2(0).ToString
                                If TiCambio = 0 Then TiCambio = 1
                            End If
                        Else
                            TiCambio = 1
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select PrecioVentaIVA, PreEsp from Productos where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                PreLst = rd2(0).ToString
                                PreEsp = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        If cbotipo.Visible = False Then
                            If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                                txtprecio.Text = FormatNumber(PreEsp * TiCambio, 2)
                                txtprecio.Tag = FormatNumber(PreEsp * TiCambio, 2)
                            Else
                                txtprecio.Text = FormatNumber(PreLst * TiCambio, 2)
                                txtprecio.Tag = FormatNumber(PreLst * TiCambio, 2)
                            End If
                            txtprecio.ReadOnly = False
                            If (Promo) Then
                                txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                txtprecio.ReadOnly = False
                            End If
                        Else
                            If (Promo) Then
                                txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                txtprecio.ReadOnly = False
                            Else
                                If cbonota.Text = "" Then
                                    txtprecio.Text = Cambio(TiCambio)
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.ReadOnly = False
                                Else
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                        "select Precio from VentasDetalle where Codigo='" & cbocodigo.Text & "' and Folio=" & cbonota.Text & ""
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        If rd2.Read Then
                                            txtprecio.Text = IIf(rd2(0).ToString = "", "0", rd2(0).ToString)
                                            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.ReadOnly = True
                                        End If
                                    Else
                                        txtprecio.Text = Cambio(TiCambio)
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.ReadOnly = False
                                    End If
                                    rd2.Close()
                                End If
                            End If
                        End If
                        cnn2.Close()

                        cbocodigo.Focus().Equals(True)
                        rd1.Close()
                        cnn1.Close()
                        Exit Sub
                    End If
                End If
                rd1.Close()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                        "select * from Productos where CodBarra='" & cbodesc.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        Promo = IIf(rd1("Status_Promocion").ToString = False, False, True)
                        Anti = rd1("Grupo").ToString
                        If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                            If MsgBox("Este en un " & Anti & " ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
                                cbocodigo.Text = ""
                                cbodesc.Text = ""
                                txtunidad.Text = ""
                                txtcantidad.Text = ""
                                txtprecio.Text = "0.00"
                                txtprecio.Tag = 0
                                txttotal.Text = "0.00"
                                txtexistencia.Text = ""
                                cboSerie.Text = ""
                                cboSerie.Tag = 0
                                txtfechacad.Text = ""
                                txtubicacion.Text = ""
                                cbodesc.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                        If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                            cbocodigo.Text = rd1("Codigo").ToString
                            cbocodigo.Focus().Equals(True)
                            rd1.Close()
                            cnn1.Close()
                            Exit Sub
                        End If

                        cbocodigo.Text = rd1("Codigo").ToString()
                        cbodesc.Text = rd1("Nombre").ToString()
                        txtunidad.Text = rd1("UVenta").ToString()
                        Multiplo = rd1("MCD").ToString()
                        Minimo = rd1("Min").ToString()
                        txtubicacion.Text = rd1("Ubicacion").ToString()

                        cnn2.Close() : cnn2.Open() : cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                txtexistencia.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) * Multiplo
                            End If
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                TiCambio = rd2(0).ToString
                                If TiCambio = 0 Then TiCambio = 1
                            End If
                        Else
                            TiCambio = 1
                        End If
                        rd2.Close()

                        cmd2 = cnn2.CreateCommand
                        cmd2.CommandText =
                            "select PrecioVentaIVA, PreEsp from Productos where Codigo='" & cbocodigo.Text & "'"
                        rd2 = cmd2.ExecuteReader
                        If rd2.HasRows Then
                            If rd2.Read Then
                                PreLst = rd2(0).ToString
                                PreEsp = rd2(1).ToString
                            End If
                        End If
                        rd2.Close()

                        If cbotipo.Visible = False Then
                            If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                                txtprecio.Text = FormatNumber(PreEsp * TiCambio, 2)
                                txtprecio.Tag = FormatNumber(PreEsp * TiCambio, 2)
                            Else
                                txtprecio.Text = FormatNumber(PreLst * TiCambio, 2)
                                txtprecio.Tag = FormatNumber(PreLst * TiCambio, 2)
                            End If
                            If (Promo) Then
                                txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                            End If
                            txtprecio.ReadOnly = False
                        Else
                            If (Promo) Then
                                txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                txtprecio.ReadOnly = False
                            Else
                                If cbonota.Text = "" Then
                                    txtprecio.Text = Cambio(TiCambio)
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.ReadOnly = False
                                Else
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                        "select Precio from VentasDetalle where Codigo='" & cbocodigo.Text & "' and Folio=" & cbonota.Text & ""
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        If rd2.Read Then
                                            txtprecio.Text = rd2(0).ToString
                                            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.ReadOnly = True
                                        End If
                                    Else
                                        txtprecio.Text = Cambio(TiCambio)
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.ReadOnly = False
                                    End If
                                    rd2.Close()
                                End If
                            End If
                        End If
                        cnn2.Close()

                        If Multiplica = "" Then
                            txtcantidad.Text = "1"
                            If CDbl(txtexistencia.Text) - CDbl(txtcantidad.Text) < 0 Then
                                If VSE = False Then
                                    If Me.Text = "Ventas (1)" Then
                                        MsgBox("No se puede vender sin existencias.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                        rd1.Close() : cnn1.Close()
                                        cbocodigo.Text = ""
                                        cbodesc.Text = ""
                                        txtunidad.Text = ""
                                        txtcantidad.Text = ""
                                        txtprecio.Text = "0.00"
                                        txtprecio.Tag = 0
                                        txttotal.Text = "0.00"
                                        txtexistencia.Text = ""
                                        cboSerie.Text = ""
                                        cboSerie.Tag = 0
                                        txtfechacad.Text = ""
                                        txtubicacion.Text = ""
                                        txtprecio.ReadOnly = False
                                        cbodesc.Focus().Equals(True)
                                        Exit Sub
                                    End If
                                End If
                            End If
                            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                            txttotal.Text = FormatNumber(txttotal.Text, 2)
                            Call UpGrid()
                            My.Application.DoEvents()

                            Dim VarSumXD As Double = 0
                            For w = 0 To grdcaptura.Rows.Count - 1
                                If grdcaptura.Rows(w).Cells(6).Value.ToString = "" Then
                                Else
                                    VarSumXD = VarSumXD + CDbl(grdcaptura.Rows(w).Cells(5).Value.ToString)
                                End If
                                txtSubTotal.Text = FormatNumber(VarSumXD, 2)
                            Next

                            If CDbl(txtdescuento1.Text) > 0 Then
                                txtSubTotal.Tag = 1
                            End If
                            txtcoment.Text = ""
                            cbocodigo.Text = ""
                            cbocodigo.Items.Clear()
                            cbodesc.Text = ""
                            cbodesc.Items.Clear()
                            txtunidad.Text = ""
                            txtcantidad.Text = "1"
                            txtprecio.Text = "0.00"
                            txtprecio.Tag = 0
                            txttotal.Text = "0.00"
                            txtexistencia.Text = ""
                            txtfechacad.Text = ""
                            cboSerie.Text = ""
                            cboSerie.Tag = 0
                            txtubicacion.Text = ""
                            cnn1.Close()

                            If CDbl(txtdescuento1.Text) <= 0 Then
                                txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
                            End If

                            Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

                            cbodesc.Focus().Equals(True)
                            txtprecio.ReadOnly = False
                        Else
                            txtcantidad.Focus().Equals(True)
                        End If
                        rd1.Close() : cnn1.Close()
                        Exit Sub
                    End If
                Else
                    MsgBox("Producto no encontrado en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    rd1.Close() : cnn1.Close()
                    Exit Sub
                End If
                rd1.Close()
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub cbocodigo_Click(sender As Object, e As EventArgs) Handles cbocodigo.Click
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)
    End Sub

    Private Sub cbocodigo_TextChanged(sender As Object, e As EventArgs) Handles cbocodigo.TextChanged
        Dim nombre As String = cbocodigo.Text
        If System.IO.File.Exists(ruta_servidor & "\ProductosImg\" & nombre & ".jpg") Then
            picProd.Image = System.Drawing.Image.FromFile(ruta_servidor & "\ProductosImg\" & nombre & ".jpg")
        End If
    End Sub

    Private Sub cbocodigo_DropDown(sender As Object, e As EventArgs) Handles cbocodigo.DropDown
        cbocodigo.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct Codigo from Productos order by Codigo"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbocodigo.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbocodigo_GotFocus(sender As Object, e As EventArgs) Handles cbocodigo.GotFocus
        cbocodigo.SelectionStart = 0
        cbocodigo.SelectionLength = Len(cbocodigo.Text)

        T_Precio = DatosRecarga("TipoPrecio")
        H_Inicia = DatosRecarga("HoraInicia")
        H_Final = DatosRecarga("HoraTermina")

    End Sub

    Private Sub cbocodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbocodigo.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter And (cbocodigo.Text <> "" Or cbodesc.Text <> "") Then
            Dim MCD As Double = 0
            Dim Multiplo As Double = 0
            Dim Minimo As Double = 0
            Dim TiCambio As Double = 0
            Dim PreLst As Double = 0, PreEsp As Double = 0
            Dim H_Actual As String = Format(Date.Now, "HH:mm")

            If cbocodigo.Text <> "" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Promo = IIf(rd1("Status_Promocion").ToString = True, True, False)
                            Anti = rd1("Grupo").ToString
                            If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                                cbodesc.Text = rd1("Nombre").ToString
                                txtprecio.Text = rd1("PrecioVentaIVA").ToString
                                txtprecio.Tag = rd1("PrecioVentaIVA").ToString
                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)

                                txtunidad.Text = rd1("UVenta").ToString

                                txtcantidad.Focus().Equals(True)
                                rd1.Close()
                                cnn1.Close()
                                Exit Sub
                            End If

                            If File.Exists(My.Application.Info.DirectoryPath & "\ProductosImg\" & cbocodigo.Text & ".jpg") Then
                                picProd.Image = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\ProductosImg\" & cbocodigo.Text & ".jpg")
                            End If

                            txtunidad.Text = rd1("UVenta").ToString()
                            cbocodigo.Text = rd1("Codigo").ToString()
                            cbodesc.Text = rd1("Nombre").ToString()
                            MCD = rd1("MCD").ToString()
                            Multiplo = rd1("Multiplo").ToString()
                            Minimo = rd1("Min").ToString()
                            txtubicacion.Text = rd1("Ubicacion").ToString()

                            cnn2.Close() : cnn2.Open()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                            "select Existencia from Productos where Codigo='" & Strings.Left(cbocodigo.Text, 6) & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    txtexistencia.Text = CDbl(IIf(rd2(0).ToString = "", "0", rd2(0).ToString)) * MCD
                                End If
                            End If
                            rd2.Close()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select FechaC from ComprasDet where Codigo='" & cbocodigo.Text & "' LIMIT 1"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    Label2.Text = "Descripción " & FormatDateTime(rd2(0).ToString, DateFormat.ShortDate)
                                End If
                            Else
                                Label2.Text = "Descripción"
                            End If
                            rd2.Close()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    TiCambio = rd2(0).ToString
                                    If TiCambio = 0 Then TiCambio = 1
                                End If
                            Else
                                TiCambio = 1
                            End If
                            rd2.Close()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select PrecioVentaIVA, PreEsp from Productos where Codigo='" & cbocodigo.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    PreLst = rd2(0).ToString
                                    PreEsp = rd2(1).ToString
                                End If
                            End If
                            rd2.Close()

                            If cbotipo.Visible = False Then
                                If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                                    txtprecio.Text = FormatNumber(PreEsp * TiCambio, 2)
                                    txtprecio.Tag = FormatNumber(PreEsp * TiCambio, 2)
                                Else
                                    txtprecio.Text = FormatNumber(PreLst * TiCambio, 2)
                                    txtprecio.Tag = FormatNumber(PreLst * TiCambio, 2)
                                End If
                                If (Promo) Then
                                    txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                End If
                                txtprecio.ReadOnly = False
                            Else
                                If (Promo) Then
                                    txtprecio.Text = Promos(cbocodigo.Text, txtprecio.Text)
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.ReadOnly = False
                                Else
                                    If cbonota.Text = "" Then
                                        txtprecio.Text = Cambio(TiCambio)
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.ReadOnly = False
                                    Else
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                            "select Precio from VentasDetalle where Codigo='" & cbocodigo.Text & "' and Folio=" & cbonota.Text & ""
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            If rd2.Read Then
                                                txtprecio.Text = rd2(0).ToString
                                                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                                txtprecio.ReadOnly = True
                                            End If
                                        Else
                                            txtprecio.Text = Cambio(TiCambio)
                                            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                            txtprecio.ReadOnly = False
                                        End If
                                        rd2.Close()
                                    End If
                                End If
                            End If
                            cnn2.Close()
                        End If
                    Else
                        MsgBox("El código no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        rd1.Close()
                        cnn1.Close()
                        cbocodigo.Focus().Equals(True)
                        Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtcantidad.Focus().Equals(True)
        End If
        If AscW(e.KeyChar) = Keys.Enter And (cbocodigo.Text = "" And cbodesc.Text = "") Then
            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                btndevo.Focus().Equals(True)
            Else
                Dim descu As Double = 0
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select NotasCred from Formatos where Facturas='MDescuento'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            descu = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
                If descu > 0 Then
                    txtdescuento1.ReadOnly = False
                Else
                    txtdescuento1.ReadOnly = True
                End If
            End If
            If Me.Text = "Ventas (1)" Then
                txtefectivo.Focus().Equals(True)
            End If
            If Me.Text = "Cotización (1)" Then
                Button3.Focus().Equals(True)
            End If
        End If
        If AscW(e.KeyChar) = Keys.Enter And btndevo.Text = "GUARDAR DEVOLUCIÓN" And cbocodigo.Text = "" Then btndevo.Focus().Equals(True)
    End Sub

    Private Sub txtcantidad_Click(sender As Object, e As EventArgs) Handles txtcantidad.Click
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_GotFocus(sender As Object, e As EventArgs) Handles txtcantidad.GotFocus
        txtcantidad.SelectionStart = 0
        txtcantidad.SelectionLength = Len(txtcantidad.Text)
    End Sub

    Private Sub txtcantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcantidad.KeyPress
        If Not IsNumeric(txtcantidad.Text) Then txtcantidad.Text = ""
        If txtcantidad.Text = "" Then Exit Sub
        If AscW(e.KeyChar) = Keys.Enter And cbodesc.Text = "" Then cbodesc.Focus().Equals(True)
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim Edita As Boolean = False
            Try
                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select * from Permisos where IdEmpleado=" & id_usu_log
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Edita = rd1("Vent_EPrec").ToString
                    End If
                End If
                rd1.Close()

                If Edita = False Then
                    If cbocodigo.Text = "" Then cbodesc.Focus().Equals(True) : Exit Sub
                    If ValCantDev(13) = False Then
                        Exit Sub
                    End If

                    If CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) = 0 Or txtcantidad.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub
                    If CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) = 0 Or txtprecio.Text = "" Then cbocodigo.Focus().Equals(True) : Exit Sub

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select PreMin from Productos where Codigo='" & cbocodigo.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If CDbl(txtprecio.Text) < CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) Then
                                MsgBox("El precio de venta mínimo para el producto es de " & FormatNumber(CDbl(rd1(0).ToString), 2) & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtprecio.SelectionStart = 0 : txtprecio.SelectionLength = Len(txtprecio.Text) : Exit Sub
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                    rd1.Close()

                    txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
                    txttotal.Text = FormatNumber(txttotal.Text, 2)
                    txtprecio.Focus().Equals(True)
                Else
                    If ValCantDev(13) = False Then
                        cnn1.Close()
                        Exit Sub
                    End If
                    txtprecio.Focus().Equals(True)
                End If
                cnn1.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                cnn1.Close()
            End Try
        End If
    End Sub

    Private Sub txtcantidad_TextChanged(sender As Object, e As EventArgs) Handles txtcantidad.TextChanged
        Dim temp As Double = 0
        Dim TiCambio As Double = 0
        Dim H_Actual As String = Format(Date.Now, "HH:mm")
        If txtcantidad.Text = "" Or txtcantidad.Text = "." Then Exit Sub

        Try
            cnn4.Close() : cnn4.Open()

            cmd4 = cnn4.CreateCommand
            cmd4.CommandText =
                "select tipo_cambio from tb_moneda,Productos where Codigo='" & cbocodigo.Text & "' and Productos.id_tbMoneda=tb_moneda.id"
            rd4 = cmd4.ExecuteReader
            If rd4.HasRows Then
                If rd4.Read Then
                    TiCambio = rd4(0).ToString
                    If TiCambio = 0 Then TiCambio = 1
                End If
            Else
                TiCambio = 1
            End If
            rd4.Close()

            If cbotipo.Visible = False Then
                If Promo = True Then
                    txttotal.Text = CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) * CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text))
                    txttotal.Text = FormatNumber(txttotal.Text, 2)
                    rd4.Close() : cnn4.Close()
                    Exit Sub
                End If

                Dim ATemp1, ATemp2, ATemp3, ATemp4 As Double

                cmd4 = cnn4.CreateCommand
                cmd4.CommandText =
                    "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                rd4 = cmd4.ExecuteReader
                If rd4.HasRows Then
                    If rd4.Read Then
                        If T_Precio = "DIA_NOCHE" And (H_Actual > H_Inicia Or H_Actual < H_Final) Then
                            txtprecio.Text = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString)) * TiCambio
                            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                            txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                        Else
                            txtprecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString)) * TiCambio
                            txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                            txtprecio.Tag = FormatNumber(txtprecio.Text, 2)

                            If Not IsDBNull(rd4("CantLst1").ToString) And Not IsDBNull(rd4("CantLst2").ToString) Then
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantLst1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantLst2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PrecioVentaIVA").ToString = "", "0", rd4("PrecioVentaIVA").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantEsp1").ToString) And Not IsDBNull(rd4("CantEsp2").ToString) Then
                                ATemp1 = rd4("CantEsp1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantEsp1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantEsp2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreEsp").ToString = "", "0", rd4("PreEsp").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMM1").ToString) And Not IsDBNull(rd4("CantMM2").ToString) Then
                                ATemp2 = rd4("CantMM1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMM1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMM2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMM").ToString = "", "0", rd4("PreMM").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMay1").ToString) And Not IsDBNull(rd4("CantMay2").ToString) Then
                                ATemp3 = rd4("CantMay1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMay1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMay2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMay").ToString = "", "0", rd4("PreMay").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    temp = 1
                                End If
                            End If

                            If Not IsDBNull(rd4("CantMin1").ToString) And Not IsDBNull(rd4("CantMin2").ToString) Then
                                ATemp4 = rd4("CantMin1").ToString
                                If CDbl(txtcantidad.Text) >= CDbl(rd4("CantMin1").ToString) And CDbl(txtcantidad.Text) <= CDbl(rd4("CantMin2").ToString) Then
                                    txtprecio.Text = CDbl(IIf(rd4("PreMin").ToString = "", "0", rd4("PreMin").ToString))
                                    txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                    txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    temp = 1
                                End If
                            End If

                        End If

                        If ATemp1 <> 0 Or ATemp2 <> 0 Or ATemp3 <> 0 Or ATemp4 <> 0 Then
                            If temp = 0 Then
                                cnn5.Close() : cnn5.Open()
                                cmd5 = cnn5.CreateCommand
                                cmd5.CommandText =
                                    "select * from Productos where Codigo='" & cbocodigo.Text & "'"
                                rd5 = cmd5.ExecuteReader
                                If rd5.HasRows Then
                                    If rd5.Read Then
                                        txtprecio.Text = CDbl(IIf(rd5("PrecioVentaIVA").ToString = "", "0", rd5("PrecioVentaIVA").ToString))
                                        txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                                        txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                                    End If
                                Else
                                    MsgBox("El producto no se encuentra en la base de datos.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                End If
                                rd5.Close()
                                cnn5.Close()
                                rd4.Close() : cnn4.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                rd4.Close()
            End If
            cnn4.Close()

            If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
                txtprecio.Text = CalPreDevo(cbonota.Text, cbocodigo.Text)
                txtprecio.Text = FormatNumber(txtprecio.Text, 2)
                txtprecio.Tag = FormatNumber(txtprecio.Text, 2)
                txtprecio.ReadOnly = True
            Else
                txtprecio.ReadOnly = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn4.Close()
        End Try
        If txtprecio.Text = "" Then txtprecio.Text = "0.00"
    End Sub

    Private Sub txtprecio_Click(sender As Object, e As EventArgs) Handles txtprecio.Click
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_GotFocus(sender As Object, e As EventArgs) Handles txtprecio.GotFocus
        txtprecio.SelectionStart = 0
        txtprecio.SelectionLength = Len(txtprecio.Text)
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        Dim chec As Boolean = False
        Dim editap As Boolean = False
        If Not IsNumeric(txtprecio.Text) Then txtprecio.Text = ""
        If cbocodigo.Text = "" Then MsgBox("Necesitas seleccionar un producto.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbodesc.Focus().Equals(True) : Exit Sub
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Vent_EPrec from Permisos where IdEmpleado=" & id_usu_log
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    editap = rd1(0).ToString
                End If
            End If
            rd1.Close()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select * from Productos where Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1(0).ToString) = "SERVICIOS" Then
                        If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                        If AscW(e.KeyChar) = Keys.Enter Then
                            cnn2.Close() : cnn2.Open()
                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select *  from series where Codigo='" & cbocodigo.Text & "'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                cboSerie.Focus().Equals(True)
                            Else
                                rd1.Close() : cnn1.Close()
                                rd2.Close() : cnn2.Close()
                                cboSerie_KeyPress(cboSerie, New KeyPressEventArgs(ChrW(Keys.Enter)))
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                    Else
                        If chec = True Then
                            Dim existencia As Double = rd1("Existencia").ToString
                            Dim TExiste As Double = existencia - CDbl(txtcantidad.Text)

                            If TExiste < 0 And btndevo.Text = "DEVOLUCIÓN" Then
                                If Me.Text = "Ventas Series" Then
                                    MsgBox("No puedes vender sin existencia.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                    txtcantidad.Focus().Equals(True)
                                    rd1.Close() : cnn1.Close()
                                    Exit Sub
                                Else
                                    If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                    If AscW(e.KeyChar) = Keys.Enter Then
                                        cnn2.Close() : cnn2.Open()
                                        cmd2 = cnn2.CreateCommand
                                        cmd2.CommandText =
                                "select *  from series where Codigo='" & cbocodigo.Text & "'"
                                        rd2 = cmd2.ExecuteReader
                                        If rd2.HasRows Then
                                            cboSerie.Focus().Equals(True)
                                        Else
                                            rd1.Close() : cnn1.Close()
                                            rd2.Close() : cnn2.Close()
                                            cboSerie_KeyPress(cboSerie, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                        End If
                                        rd2.Close() : cnn2.Close()
                                    End If
                                End If
                            Else
                                If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                                If AscW(e.KeyChar) = Keys.Enter Then
                                    cnn2.Close() : cnn2.Open()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText =
                                "select *  from series where Codigo='" & cbocodigo.Text & "'"
                                    rd2 = cmd2.ExecuteReader
                                    If rd2.HasRows Then
                                        cboSerie.Focus().Equals(True)
                                    Else
                                        rd1.Close() : cnn1.Close()
                                        rd2.Close() : cnn2.Close()
                                        cboSerie_KeyPress(cboSerie, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                    End If
                                    rd2.Close() : cnn2.Close()
                                End If
                            End If
                        Else
                            If editap = False And AscW(e.KeyChar) <> 13 Then e.KeyChar = Nothing
                            If AscW(e.KeyChar) = Keys.Enter Then
                                cnn2.Close() : cnn2.Open()
                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText =
                                "select *  from series where Codigo='" & cbocodigo.Text & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.HasRows Then
                                    cboSerie.Focus().Equals(True)
                                Else
                                    rd1.Close() : cnn1.Close()
                                    rd2.Close() : cnn2.Close()
                                    cboSerie_KeyPress(cboSerie, New KeyPressEventArgs(ChrW(Keys.Enter)))
                                End If
                                rd2.Close() : cnn2.Close()
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()
            cnn1.Close()

            If txtprecio.Text = "" Then
                txtprecio.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub txtprecio_TextChanged(sender As Object, e As EventArgs) Handles txtprecio.TextChanged
        txttotal.Text = CDbl(IIf(txtcantidad.Text = "" Or txtcantidad.Text = ".", "0", txtcantidad.Text)) * CDbl(IIf(txtprecio.Text = "" Or txtprecio.Text = ".", "0", txtprecio.Text))
        txttotal.Text = FormatNumber(txttotal.Text, 2)
    End Sub

    Private Sub cboSerie_DropDown(sender As Object, e As EventArgs) Handles cboSerie.DropDown
        cboSerie.Items.Clear()
        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        If btndevo.Text = "GUARDAR DEVOLUCIÓN" Then
            cmd1.CommandText =
                "SELECT * FROM series WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboSerie.Items.Add(
                    rd1("serie").ToString
                    )
            Loop
            rd1.Close()
        Else
            If cbocodigo.Text = "" Then Exit Sub
            cmd1.CommandText =
                "select distinct(Serie) as Lt from series WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cboSerie.Items.Add(
                    rd1("Lt").ToString
                    )
            Loop
            rd1.Close()
        End If
        cnn1.Close()
    End Sub

    Private Sub cboSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboSerie.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        Dim chec As Boolean = False
        Dim renta As Boolean = False

        If cboSerie.Text = "" Then
            If cboSerie.Items.Count > 0 Then
                MsgBox("Necesitas seleccionar una serie de producto.", vbInformation + vbOKOnly, titulocentral)
                Exit Sub
            End If
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select VSE from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    chec = rd1(0).ToString()
                End If
            End If
            rd1.Close()

            Dim cant_lotes As Double = 0

            'If cboSerie.Text <> "" Then
            '    cmd1 = cnn1.CreateCommand
            '    cmd1.CommandText =
            '        "select Cantidad from LoteCaducidad where Lote='" & cboSerie.Text & "' and Codigo='" & cbocodigo.Text & "'"
            '    rd1 = cmd1.ExecuteReader
            '    If rd1.HasRows Then
            '        If rd1.Read Then
            '            cant_lotes = rd1(0).ToString()
            '        End If
            '    End If
            '    rd1.Close()

            '    cant_lotes = cant_lotes - CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text))

            '    For i = 0 To grdcaptura.Rows.Count - 1
            '        If grdcaptura.Rows(i).Cells(8).Value.ToString = cboSerie.Text Then
            '            cant_lotes = cant_lotes - CDec(grdcaptura.Rows(i).Cells(8).Value.ToString)
            '        End If
            '    Next

            '    If cant_lotes < 0 Then
            '        MsgBox("No cuentas con unidades suficiente del lote para venderlo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
            '        cboSerie.Text = ""
            '        cbodesc.Focus().Equals(True)
            '        cnn1.Close()
            '        Exit Sub
            '    End If
            'End If

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT * FROM Productos WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If CStr(rd1("Departamento").ToString()) = "SERVICIOS" Then
                    ElseIf CStr(rd1("Grupo").ToString()) = "RENTAS" Then
                        renta = True
                    Else
                        If chec = True Then
                            If btndevo.Text <> "GUARDAR DEVOLUCIÓN" Then
                                Dim Existe As Double = rd1("Existencia").ToString()
                                Dim TExiste As Double = Existe - CDbl(txtcantidad.Text)
                                If Me.Text = "Ventas(1)" Then
                                    If Text < 0 Then
                                        MsgBox("No está permitido vender sin existencias.", vbInformation + vbOKOnly, titulocentral)
                                        txtcantidad.Focus().Equals(True)
                                        rd1.Close() : cnn1.Close()
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            If ReviewLote() = False Then Exit Sub

            If cboSerie.Tag = 0 Then
                cboSerie.Text = ""
                cboSerie.Tag = 0
                txtfechacad.Text = ""
            Else
                Dim CantLote As Double = CantLte()
                If CDbl(txtcantidad.Text) > CantLote Then
                    MsgBox("No cuentas con suficientes unidades para cubrir a cantidad ingresada.", vbInformation + vbOKOnly, titulocentral)
                    txtcantidad.Focus().Equals(True)
                    cnn1.Close()
                    Exit Sub
                End If
            End If

            If ValCantDev(13) = False Then
                cnn1.Close()
                Exit Sub
            End If

            If Anti = "ANTIBIOTICO" Or Anti = "CONTROLADO" Then
                If MsgBox("Este producto es un " & Anti & ", ¿deseas continuar con el proceso?", vbInformation + vbOKCancel, titulocentral) = vbCancel Then
                    cbocodigo.Text = ""
                    cbodesc.Text = ""
                    txtunidad.Text = ""
                    txtcantidad.Text = ""
                    txtprecio.Text = "0.00"
                    txttotal.Text = "0.00"
                    txtexistencia.Text = ""
                    cboSerie.Text = ""
                    txtfechacad.Text = ""
                    cbodesc.Focus().Equals(True)
                    cnn1.Close()
                    Exit Sub
                End If
            End If

            Dim dia As Integer = 0
            Dim decu As String = ""
            Dim pre_ini As Double = txtprecio.Text, pre_fini As Double = 0

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT Dia,Descu FROM Productos WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    dia = rd1(0).ToString
                    decu = rd1(1).ToString
                End If
            End If
            rd1.Close()

            If dia = 0 Then
            Else
                If dia = CInt(txtdia.Text) Then
                    Dim descu As Double = CDbl(decu) / 100
                    Dim p1 As Double = CDbl(pre_ini) * descu
                    pre_fini = pre_ini - p1

                    txtprecio.Text = FormatNumber(pre_fini, 2)
                End If
            End If

            If cbocodigo.Text = "" Then cbodesc.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtcantidad.Text = "", "0", txtcantidad.Text)) = 0 Or txtcantidad.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub
            If CDbl(IIf(txtprecio.Text = "", "0", txtprecio.Text)) = 0 Or txtprecio.Text = "" Then cbocodigo.Focus().Equals(True) : cnn1.Close() : Exit Sub

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText = "SELECT PreMin FROM Productos WHERE Codigo='" & cbocodigo.Text & "'"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    If Promo = False Then
                        If CDbl(txtprecio.Text) < CDbl(IIf(rd1(0).ToString = "", "0", rd1(0).ToString)) Then
                            If btndevo.Text <> "GUARDAR DEVOLUCIÓN" Then
                                MsgBox("El precio de venta mínimo establecido es de " & FormatNumber(rd1(0).ToString, 2) & ".", vbInformation + vbOKOnly, titulocentral)
                                txtprecio.Focus().Equals(True)
                                rd1.Close() : cnn1.Close()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            rd1.Close()

            txtefectivo.Text = "0.00"
            txtCambio.Text = "0.00"
            txttotal.Text = CDbl(txtcantidad.Text) * CDbl(txtprecio.Text)
            txttotal.Text = FormatNumber(txttotal.Text, 2)
            Call UpGrid()

            'If Anti = "CONTROLADO" Or Anti = "ANTIBIOTICO" Then
            '    grdantis.Rows.Add(cbocodigo.Text, cbodesc.Text, txtunidad.Text, txtcantidad.Text, FormatNumber(txtprecio.Text, 2), FormatNumber(txttotal.Text, 2), FormatNumber(txtexistencia.Text, 2))
            'End If

            Dim VarSumXD As Double = 0
            Dim total_prods As Double = 0
            For w = 0 To grdcaptura.Rows.Count - 1
                If grdcaptura.Rows(w).Cells(5).Value.ToString = "" Then
                Else
                    VarSumXD = VarSumXD + (CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString) * CDbl(grdcaptura.Rows(w).Cells(4).Value.ToString))
                    total_prods = total_prods + CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString)
                End If
                txtSubTotal.Text = FormatNumber(VarSumXD, 2)
            Next

            txtcant_productos.Text = total_prods

            If CDbl(txtdescuento1.Text) > 0 Then
                txtSubTotal.Tag = 1
            End If
            txtcoment.Text = ""
            cbocodigo.Text = ""
            cbocodigo.Items.Clear()
            cbodesc.Text = ""
            cbodesc.Items.Clear()
            txtunidad.Text = ""
            txtcantidad.Text = ""
            txtprecio.Text = "0.00"
            txttotal.Text = "0.00"
            txtexistencia.Text = ""
            txtfechacad.Text = ""
            cboSerie.Text = ""
            picProd.Image = Nothing
            cboSerie.Items.Clear()
            cnn1.Close()

            If CDbl(txtdescuento1.Text) <= 0 Then
                txtPagar.Text = CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text)
                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
            End If

            Call txtdescuento1_TextChanged(txtdescuento1, New EventArgs())

            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub txttotal_Click(sender As Object, e As EventArgs) Handles txttotal.Click
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub

    Private Sub txttotal_GotFocus(sender As Object, e As EventArgs) Handles txttotal.GotFocus
        txttotal.SelectionStart = 0
        txttotal.SelectionLength = Len(txttotal.Text)
    End Sub

    Private Sub txttotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttotal.KeyPress
        Dim edita_pr As Boolean = False

        cnn1.Close() : cnn1.Open()

        cmd1 = cnn1.CreateCommand
        cmd1.CommandText = "SELECT EditaPrecios FROM Permisos WHERE IdEmpleado=" & id_usu_log
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                edita_pr = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()
        If edita_pr = False And AscW(e.KeyChar) = 13 Then e.KeyChar = ChrW(0)

        If AscW(e.KeyChar) = Keys.Enter Then
            If IsNumeric(txtprecio.Text) And IsNumeric(txttotal.Text) Then
                txtcantidad.Text = FormatNumber(CDbl(txttotal.Text) / CDbl(txtprecio.Text), 2)
            Else
                txttotal.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub txttotal_TextChanged(sender As Object, e As EventArgs) Handles txttotal.TextChanged
        Call Actualiza()
    End Sub

    Private Sub txtcoment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcoment.KeyPress
        If AscW(e.KeyChar) = 0 Then
            txtcoment.Text = ""
            txtcoment.Visible = False
            cbodesc.Focus().Equals(True)
            Exit Sub
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            txtcoment.Visible = False
            If renglon = 0 Then
                grdcaptura.Rows.Add("", txtcoment.Text, "", "", "", "", "", "", "", "", "", "", "", "")
            Else
                grdcaptura.Rows(renglon).Cells(1).Value = txtcoment.Text
            End If
            For t As Integer = 0 To grdcaptura.Rows.Count - 1
                If CStr(grdcaptura.Rows(t).Cells(0).Value.ToString) = "" Then
                    grdcaptura.Rows(t).DefaultCellStyle.ForeColor = Color.DarkOrange
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionBackColor = Color.Pink
                    grdcaptura.Rows(t).DefaultCellStyle.SelectionForeColor = Color.Black
                End If
            Next
            txtcoment.Text = ""
            renglon = 0
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtcomentario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcomentario.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            boxcomentario.Visible = False
            btnventa.Focus().Equals(True)
        End If
    End Sub

    Private Sub grdcaptura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdcaptura.KeyDown
        If e.KeyCode = Keys.Delete Then

            Dim Tpagar As Single = 0, tmpIva As Single = 0, tmpDsct As Single = 0, tmpSub As Single = 0
            Dim index As Integer = grdcaptura.CurrentRow.Index
            Dim CODx As String = ""
            Dim CantDX As Double = 0
            Dim MyNota As String = ""

            cbodesc.Focus().Equals(True)
            If grdcaptura.Rows.Count > 0 Then
                If grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                    renglon = grdcaptura.CurrentRow.Index
                    txtcoment.Visible = True
                    txtcoment.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
                    txtcoment.Focus().Equals(True)
                    Exit Sub
                End If

                cbocodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
                cbodesc.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
                txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
                txtcantidad.Text = "" ' grdcaptura.Rows(index).Cells(3).Value.ToString
                txtprecio.Text = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString, 2)
                txtprecio.Tag = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString, 2)
                txttotal.Text = FormatNumber(grdcaptura.Rows(index).Cells(5).Value.ToString, 2)
                txtexistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString

                If grdcaptura.Rows.Count = 1 Then
                    CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                    CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString
                    grdcaptura.Rows.Clear()
                Else
                    CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                    CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString
                    If grdcaptura.Rows(index).Cells(1).Value.ToString <> "" And grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                        MyNota = grdcaptura.Rows(index).Cells(1).Value.ToString
                        If grdcaptura.Rows.Count = 1 Then
                            grdcaptura.Rows.Clear()
                        Else
                            grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                        End If
                    Else
                        grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                    End If
                End If

                Dim total_prods As Double = 0
                Dim SUBsinIVA As Double = 0
                Dim SinDesct As Double = 0

                If txtSubTotal.Text = "0.00" Or CDbl(txtSubTotal.Text) = 0 Then cbodesc.Focus().Equals(True)
                If CDbl(txtdescuento1.Text) > 0 Then
                    cnn1.Close() : cnn1.Open()
                    For N As Integer = 0 To grdcaptura.Rows.Count - 1
                        If grdcaptura.Rows(N).Cells(0).Value.ToString() <> "" Then
                            cmd1 = cnn1.CreateCommand
                            cmd1.CommandText =
                                "select IVA from Productos where Codigo='" & grdcaptura.Rows(N).Cells(0).Value.ToString() & "'"
                            rd1 = cmd1.ExecuteReader
                            If rd1.HasRows Then
                                If rd1.Read Then

                                    SUBsinIVA = SUBsinIVA + (CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString()) / (1 + CDbl(rd1(0).ToString)))
                                    SinDesct = SinDesct + CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString())

                                    tmpIva = 1 + CDbl(rd1(0).ToString)
                                    tmpDsct = (CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString) / (1 + CDbl(rd1(0).ToString))) * CDbl(txtdescuento1.Text) / 100
                                    Tpagar = Tpagar + ((CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString()) / (1 + CDbl(rd1(0).ToString)) - tmpDsct) * tmpIva)
                                    tmpSub = tmpSub + ((CDec(grdcaptura.Rows(N).Cells(5).Value.ToString) - (CDec(grdcaptura.Rows(N).Cells(5).Value.ToString()) * (CDbl(txtdescuento1.Text) / 100)))) / (1 + (CDbl(rd1(0).ToString)))
                                End If
                            End If
                            rd1.Close()
                        End If
                    Next
                    cnn1.Close()

                    txtdescuento2.Text = FormatNumber(SUBsinIVA * CDbl(txtdescuento1.Text), 2)
                    Dim VarSunXD As Double = 0
                    For w As Integer = 0 To grdcaptura.Rows.Count - 1
                        VarSunXD = VarSunXD + CDbl(grdcaptura.Rows(w).Cells(5).Value.ToString)
                        total_prods = total_prods + CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString())
                    Next
                    txtcant_productos.Text = total_prods
                    txtPagar.Text = FormatNumber(VarSunXD, 2)
                    txtSubTotal.Text = FormatNumber(Tpagar, 2)
                End If
                If CDbl(txtdescuento1.Text) <= 0 Then
                    txtPagar.Text = CDbl(txtPagar.Text) - CDbl(txttotal.Text)
                End If
                cbocodigo.Focus().Equals(True)
                txtPagar.Text = FormatNumber(txtPagar.Text, 2)
            End If
            If CDbl(txtdescuento1.Text) <= 0 Then
                txtSubTotal.Text = txtResta.Text
            End If
            txtSubTotal.Text = txtPagar.Text
            txtResta.Text = txtSubTotal.Text
            If CDbl(txtSubTotal.Text) = 0 Then
                txtdescuento1.Text = "0"
                txtefectivo.Text = "0.00"
                txtCambio.Text = "0.00"
            End If
            txtResta.Text = txtPagar.Text
            Call cbocodigo_KeyPress(cbocodigo, New KeyPressEventArgs(Chr(Keys.Enter)))

        End If
    End Sub

    Private Sub grdcaptura_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdcaptura.CellDoubleClick
        Dim Tpagar As Single = 0, tmpIva As Single = 0, tmpDsct As Single = 0, tmpSub As Single = 0
        Dim index As Integer = grdcaptura.CurrentRow.Index
        Dim CODx As String = ""
        Dim CantDX As Double = 0
        Dim MyNota As String = ""

        cbodesc.Focus().Equals(True)
        If grdcaptura.Rows.Count > 0 Then
            If grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                renglon = grdcaptura.CurrentRow.Index
                txtcoment.Visible = True
                txtcoment.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
                txtcoment.Focus().Equals(True)
                Exit Sub
            End If

            cbocodigo.Text = grdcaptura.Rows(index).Cells(0).Value.ToString
            cbodesc.Text = grdcaptura.Rows(index).Cells(1).Value.ToString
            txtunidad.Text = grdcaptura.Rows(index).Cells(2).Value.ToString
            txtcantidad.Text = "" ' grdcaptura.Rows(index).Cells(3).Value.ToString
            txtprecio.Text = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString, 2)
            txtprecio.Tag = FormatNumber(grdcaptura.Rows(index).Cells(4).Value.ToString, 2)
            txttotal.Text = FormatNumber(grdcaptura.Rows(index).Cells(5).Value.ToString, 2)
            txtexistencia.Text = grdcaptura.Rows(index).Cells(6).Value.ToString

            If grdcaptura.Rows.Count = 1 Then
                CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString
                grdcaptura.Rows.Clear()
            Else
                CODx = grdcaptura.Rows(index).Cells(0).Value.ToString
                CantDX = grdcaptura.Rows(index).Cells(3).Value.ToString
                If grdcaptura.Rows(index).Cells(1).Value.ToString <> "" And grdcaptura.Rows(index).Cells(0).Value.ToString = "" Then
                    MyNota = grdcaptura.Rows(index).Cells(1).Value.ToString
                    If grdcaptura.Rows.Count = 1 Then
                        grdcaptura.Rows.Clear()
                    Else
                        grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                    End If
                Else
                    grdcaptura.Rows.Remove(grdcaptura.Rows(index))
                End If
            End If

            Dim total_prods As Double = 0
            Dim SUBsinIVA As Double = 0
            Dim SinDesct As Double = 0

            If txtSubTotal.Text = "0.00" Or CDbl(txtSubTotal.Text) = 0 Then cbodesc.Focus().Equals(True)
            If CDbl(txtdescuento1.Text) > 0 Then
                cnn1.Close() : cnn1.Open()
                For N As Integer = 0 To grdcaptura.Rows.Count - 1
                    If grdcaptura.Rows(N).Cells(0).Value.ToString() <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                            "select IVA from Productos where Codigo='" & grdcaptura.Rows(N).Cells(0).Value.ToString() & "'"
                        rd1 = cmd1.ExecuteReader
                        If rd1.HasRows Then
                            If rd1.Read Then

                                SUBsinIVA = SUBsinIVA + (CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString()) / (1 + CDbl(rd1(0).ToString)))
                                SinDesct = SinDesct + CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString())

                                tmpIva = 1 + CDbl(rd1(0).ToString)
                                tmpDsct = (CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString) / (1 + CDbl(rd1(0).ToString))) * CDbl(txtdescuento1.Text) / 100
                                Tpagar = Tpagar + ((CDbl(grdcaptura.Rows(N).Cells(5).Value.ToString()) / (1 + CDbl(rd1(0).ToString)) - tmpDsct) * tmpIva)
                                tmpSub = tmpSub + ((CDec(grdcaptura.Rows(N).Cells(5).Value.ToString) - (CDec(grdcaptura.Rows(N).Cells(5).Value.ToString()) * (CDbl(txtdescuento1.Text) / 100)))) / (1 + (CDbl(rd1(0).ToString)))
                            End If
                        End If
                        rd1.Close()
                    End If
                Next
                cnn1.Close()

                txtdescuento2.Text = FormatNumber(SUBsinIVA * CDbl(txtdescuento1.Text), 2)
                Dim VarSunXD As Double = 0
                For w As Integer = 0 To grdcaptura.Rows.Count - 1
                    VarSunXD = VarSunXD + CDbl(grdcaptura.Rows(w).Cells(5).Value.ToString)
                    total_prods = total_prods + CDbl(grdcaptura.Rows(w).Cells(3).Value.ToString())
                Next
                txtcant_productos.Text = total_prods
                txtPagar.Text = FormatNumber(VarSunXD, 2)
                txtSubTotal.Text = FormatNumber(Tpagar, 2)
            End If
            If CDbl(txtdescuento1.Text) <= 0 Then
                txtPagar.Text = CDbl(txtPagar.Text) - CDbl(txttotal.Text)
            End If
            cbocodigo.Focus().Equals(True)
            txtPagar.Text = FormatNumber(txtPagar.Text, 2)
        End If
        If CDbl(txtdescuento1.Text) <= 0 Then
            txtSubTotal.Text = txtResta.Text
        End If
        txtSubTotal.Text = txtPagar.Text
        txtResta.Text = txtSubTotal.Text
        If CDbl(txtSubTotal.Text) = 0 Then
            txtdescuento1.Text = "0"
            txtefectivo.Text = "0.00"
            txtCambio.Text = "0.00"
        End If
        txtResta.Text = txtPagar.Text
        txtcant_productos.Text = txtcant_productos.Text - CantDX
        Call cbocodigo_KeyPress(cbocodigo, New KeyPressEventArgs(Chr(Keys.Enter)))
    End Sub

    Private Sub chkBuscaProd_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscaProd.CheckedChanged
        If (chkBuscaProd.Checked) Then
            txtProdClave.Text = ""
            Serchi = False
            Panel4.Visible = True
            txtProdClave.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtProdClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProdClave.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbodesc.Items.Clear()

            Try
                cnn3.Close() : cnn3.Open()

                cmd3 = cnn3.CreateCommand
                cmd3.CommandText =
                    "select distinct Nombre from Productos where Nombre like '%" & txtProdClave.Text & "%' order by Nombre"
                rd3 = cmd3.ExecuteReader
                Do While rd3.Read
                    If rd3.HasRows Then cbodesc.Items.Add(rd3(0).ToString())
                Loop
                rd3.Close() : cnn3.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                cnn3.Close()
            End Try
            Serchi = True
            Panel4.Visible = False
            chkBuscaProd.Checked = False
            cbodesc.Focus().Equals(True)
        End If
    End Sub

    'PAGOS
    Private Sub txtPagar_DoubleClick(sender As Object, e As EventArgs) Handles txtPagar.DoubleClick
        Dim TotalNV As Double = 0
        If MsgBox("¿Deseas agregar 16% de IVA a todos los productos?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then
            txtefectivo.Focus().Equals(True)
            Exit Sub
        Else
            Dim Ahorro As Double = 0
            TotalNV = txtSubTotal.Text
            Dim MyProcVent As Double = 16
            txtSubTotal.Text = 0.0#

            For Zi As Integer = 0 To grdcaptura.Rows.Count - 1
                grdcaptura.Rows(Zi).Cells(4).Value = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(4).Value.ToString) + (CDbl(grdcaptura.Rows(Zi).Cells(4).Value.ToString) * (MyProcVent / 100)), 2)
                grdcaptura.Rows(Zi).Cells(5).Value = FormatNumber(CDbl(grdcaptura.Rows(Zi).Cells(4).Value.ToString + CDbl(grdcaptura.Rows(Zi).Cells(3).Value.ToString)), 2)
                txtSubTotal.Text = CDbl(txtSubTotal.Text) + CDbl(grdcaptura.Rows(Zi).Cells(6).Value.ToString)
            Next

            Ahorro = TotalNV - CDbl(txtSubTotal.Text)
            If Ahorro < 0 Then Ahorro = 0

            txtPagar.Enabled = False
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdescuento1_Click(sender As Object, e As EventArgs) Handles txtdescuento1.Click
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub

    Private Sub txtdescuento1_GotFocus(sender As Object, e As EventArgs) Handles txtdescuento1.GotFocus
        txtdescuento1.SelectionStart = 0
        txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
    End Sub

    Private Sub txtdescuento1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento1.KeyPress
        If txtdescuento1.Text = "" And AscW(e.KeyChar) = 46 Then
            txtdescuento1.Text = "0.00"
            txtdescuento1.SelectionStart = 0
            txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
            txtdescuento1.Focus().Equals(True)
        End If
        If AscW(e.KeyChar) = Keys.Enter Then
            If modo_caja = "CAJA" Then
                txtefectivo.Focus().Equals(True)
            Else
                btnventa.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtdescuento1_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento1.TextChanged
        If txtdescuento1.Text = "" Then
            txtdescuento1.Text = "0"
            txtPagar.Text = txtSubTotal.Text
            Exit Sub
        End If

        If CDbl(txtdescuento1.Text) > 0 Then
            If grdpago.Rows.Count > 0 Then grdpago.Rows.Clear() : txtMontoP.Text = "0.00"
        End If

        Dim CampoDsct As Double = IIf(txtdescuento1.Text = "", "0", txtdescuento1.Text)
        Dim Desc As Double = 0

        txtdescuento2.Text = (CampoDsct / 100) * CDbl(txtSubTotal.Text)
        txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 2)
        txtPagar.Text = CDbl(txtSubTotal.Text) - ((CampoDsct / 100) * CDbl(txtSubTotal.Text))
        txtPagar.Text = FormatNumber(txtPagar.Text, 2)
        txtResta.Text = CDbl(txtSubTotal.Text) - ((CampoDsct / 100) * CDbl(txtSubTotal.Text))
        txtResta.Text = FormatNumber(txtResta.Text, 2)

        cnn5.Close() : cnn5.Open()

        cmd5 = cnn5.CreateCommand
        cmd5.CommandText =
            "select NotasCred from Formatos where Facturas='Mdescuento'"
        rd5 = cmd5.ExecuteReader
        If rd5.HasRows Then
            If rd5.Read Then
                Desc = rd5(0).ToString
                If CampoDsct = 0 Then
                    txtdescuento2.Text = "0.00"
                    txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtMontoP.Text) - (CDbl(txtefectivo.Text) - CDbl(txtCambio.Text)), 2)
                    CampoDsct = 0
                    txtPagar.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                    Exit Sub
                End If
                If CampoDsct > Desc Then
                    MsgBox("No puedes rebasar el descuento máximo.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    CampoDsct = 0
                    txtdescuento2.Text = "0.00"
                    txtResta.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtMontoP.Text), 2)
                    txtPagar.Text = FormatNumber(CDbl(txtSubTotal.Text) - CDbl(txtdescuento2.Text), 2)
                    txtdescuento1.SelectionStart = 0
                    txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
                    Exit Sub
                End If
            End If
        Else
            If CampoDsct <> 0 Then
                MsgBox("Establece un máximo de descuento por venta para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                CampoDsct = 0
                txtdescuento1.SelectionStart = 0
                txtdescuento1.SelectionLength = Len(txtdescuento1.Text)
                rd5.Close() : cnn5.Close()
                Exit Sub
            End If
        End If
        rd5.Close() : cnn5.Close()
    End Sub

    Private Sub txtProdClave_GotFocus(sender As Object, e As EventArgs) Handles txtProdClave.GotFocus
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub
    Private Sub txtdescuento2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescuento2.KeyPress
        If Not IsNumeric(txtdescuento2.Text) Then txtdescuento2.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then
            txtdescuento2.Text = FormatNumber(txtdescuento2.Text, 2)
            txtPagar.Text = FormatNumber(CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtResta.Text = FormatNumber(CDbl(IIf(txtResta.Text = "", "0", txtResta.Text)) - CDbl(IIf(txtdescuento2.Text = "", "0", txtdescuento2.Text)), 2)
            txtefectivo.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtdescuento2_TextChanged(sender As Object, e As EventArgs) Handles txtdescuento2.TextChanged
        txtdescuento2.SelectionStart = 0
        txtdescuento2.SelectionLength = Len(txtdescuento2.Text)
    End Sub

    Private Sub txtefectivo_Click(sender As Object, e As EventArgs) Handles txtefectivo.Click
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_GotFocus(sender As Object, e As EventArgs) Handles txtefectivo.GotFocus
        txtefectivo.SelectionStart = 0
        txtefectivo.SelectionLength = Len(txtefectivo.Text)
    End Sub

    Private Sub txtefectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtefectivo.KeyDown
        If txtSubTotal.Text <> "" Then
            If modo_caja = "CAJA" Then
                txtefectivo.ReadOnly = False
            End If
        Else
            txtefectivo.ReadOnly = True
        End If
    End Sub

    Private Sub txtefectivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtefectivo.KeyPress
        If Not IsNumeric(txtefectivo.Text) Then txtefectivo.Text = "" : Exit Sub
        If txtefectivo.Text = "" And AscW(e.KeyChar) = 46 Then
            txtefectivo.Text = "0.00"
            txtefectivo.SelectionStart = 0
            txtefectivo.SelectionLength = Len(txtefectivo.Text)
            txtefectivo.Focus().Equals(True)
        End If

        If AscW(e.KeyChar) = Keys.Enter Then
            txtefectivo.Text = FormatNumber(txtefectivo.Text, 2)
            Dim MyOpe As Double = CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtefectivo.Text = "", "0", txtefectivo.Text)))
            If MyOpe < 0 Then
                txtCambio.Text = FormatNumber(-MyOpe, 2)
                txtResta.Text = "0.00"
            Else
                txtResta.Text = FormatNumber(MyOpe, 2)
                txtCambio.Text = "0.00"
            End If
            txtCambio.Text = FormatNumber(txtCambio.Text, 2)
            txtResta.Text = FormatNumber(txtResta.Text, 2)
            btnventa.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtefectivo_TextChanged(sender As Object, e As EventArgs) Handles txtefectivo.TextChanged
        Dim MyOpe As Double = CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtefectivo.Text = "", "0", txtefectivo.Text)))
        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
    End Sub

    Private Sub cbobanco_DropDown(sender As Object, e As EventArgs) Handles cbobanco.DropDown
        cbobanco.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Banco from Bancos"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbobanco.Items.Add(
                    rd1(0).ToString
                    )
            Loop
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            cnn1.Close()
        End Try
    End Sub

    Private Sub cbobanco_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbobanco.KeyPress
        e.KeyChar = UCase(e.KeyChar)
        If AscW(e.KeyChar) = Keys.Enter Then
            txtnumref.Focus().Equals(True)
        End If
    End Sub

    Private Sub cbotpago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbotpago.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            cbobanco.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtnumref_Click(sender As Object, e As EventArgs) Handles txtnumref.Click
        txtnumref.SelectionStart = 0
        txtnumref.SelectionLength = Len(txtnumref.Text)
    End Sub

    Private Sub txtnumref_GotFocus(sender As Object, e As EventArgs) Handles txtnumref.GotFocus
        txtnumref.SelectionStart = 0
        txtnumref.SelectionLength = Len(txtnumref.Text)
    End Sub

    Private Sub txtnumref_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumref.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Dim saldo As Double = 0
            If cbotpago.Text = "MONEDERO" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Monedero where Barras='" & txtMonedero.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.HasRows Then
                            txtsaldo_monedero.Text = FormatNumber(IIf(rd1("Saldo").ToString() = "", 0, rd1("Saldo").ToString()), 2)
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            If cbotpago.Text = "TARJETA" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from MovCuenta where Tipo='TARJETA' and Referencia='" & txtnumref.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("Ya fue registrado este pago en una venta diferente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtnumref.Text = ""
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            If cbotpago.Text = "TRANSFERENCIA" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from MovCuenta where Tipo='TRANSFERENCIA' and Referencia='" & txtnumref.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("Ya fue registrado este pago en una venta diferente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtnumref.Text = ""
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            If cbotpago.Text = "OTRO" Then
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from MovCuenta where Tipo='OTRO' and Referencia='" & txtnumref.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MsgBox("Ya fue registrado este pago en una venta diferente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                            txtnumref.Text = ""
                            rd1.Close() : cnn1.Close()
                            Exit Sub
                        End If
                    End If
                    rd1.Close()
                    cnn1.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            End If
            txtmonto.Focus().Equals(True)
        End If
    End Sub

    Private Sub txtmonto_Click(sender As Object, e As EventArgs) Handles txtmonto.Click
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_GotFocus(sender As Object, e As EventArgs) Handles txtmonto.GotFocus
        txtmonto.SelectionStart = 0
        txtmonto.SelectionLength = Len(txtmonto.Text)
    End Sub

    Private Sub txtmonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtmonto.KeyPress
        If Not IsNumeric(txtmonto.Text) Then txtmonto.Text = "" : Exit Sub
        If AscW(e.KeyChar) = Keys.Enter Then

            If cbotpago.Text = "SALDO A FAVOR" Then
                If CDbl(txtafavor.Text) <= 0 Then
                    MsgBox("No es posible agregar el pago ya que el cliente no cuenta con un saldo a favor disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtmonto.Text = "0.00"
                    cbobanco.Text = ""
                    txtnumref.Text = ""
                    cbotpago.Text = ""
                    cbotpago.Focus().Equals(True)
                    Exit Sub
                End If

                If CDbl(txtmonto.Text) > CDbl(txtafavor.Text) Then
                    MsgBox("No es posible agregar el pago ya que el monto supera el saldo a favor disponible.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    txtmonto.Text = "0.00"
                    txtmonto.Focus().Equals(True)
                    Exit Sub
                End If
            End If

            If cbotpago.Text = "MONEDERO " Then
                Dim saldo As Double = 0
                Dim actul As Double = txtmonto.Text
                Try
                    cnn1.Close() : cnn1.Open()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select * from Monederos where Barras='" & txtnumref.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            saldo = rd1("Saldo").ToString
                        End If
                    Else
                        MsgBox("No existe el registro de este monedero.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtnumref.Focus().Equals(True)
                        rd1.Close() : cnn1.Close()
                        Exit Sub
                    End If
                    rd1.Close()
                    cnn1.Close()

                    If actul > saldo Then
                        MsgBox("Saldo insuficiente.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                        txtmonto.Text = "0.00"
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                    cnn1.Close()
                End Try
            Else
                txtComentarioPago.Focus().Equals(True)
            End If
        End If
    End Sub

    Private Sub txtMontoP_TextChanged(sender As Object, e As EventArgs) Handles txtMontoP.TextChanged
        If txtMontoP.Text = "" Then txtMontoP.Text = "0.00"
        If txtefectivo.Text = "" Then txtefectivo.Text = "0.00"
        If txtSubTotal.Text = "" Then txtSubTotal.Text = "0.00"

        Dim MyOpe As Double = CDbl(IIf(txtPagar.Text = "", "0", txtPagar.Text)) - (CDbl(IIf(txtMontoP.Text = "", "0", txtMontoP.Text)) + CDbl(IIf(txtefectivo.Text = "", "0", txtefectivo.Text)))

        If MyOpe < 0 Then
            txtCambio.Text = FormatNumber(-MyOpe, 2)
            txtResta.Text = "0.00"
        Else
            txtResta.Text = FormatNumber(MyOpe, 2)
            txtCambio.Text = "0.00"
        End If
        txtCambio.Text = FormatNumber(txtCambio.Text, 2)
        txtResta.Text = FormatNumber(txtResta.Text, 2)
    End Sub

    Private Sub cbotpago_DropDown(sender As Object, e As EventArgs) Handles cbotpago.DropDown
        cbotpago.Items.Clear()
        Try
            cnn1.Close() : cnn1.Open()

            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select distinct FormaPago from FormasPago where FormaPago<>''"
            rd1 = cmd1.ExecuteReader
            Do While rd1.Read
                If rd1.HasRows Then cbotpago.Items.Add(rd1(0).ToString())
            Loop
            rd1.Close() : cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try
    End Sub

    Private Sub dtpFecha_P_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFecha_P.KeyPress
        If AscW(e.KeyChar) = Keys.Enter Then
            Button9.Focus().Equals(True)
        End If
    End Sub

    Private Sub grdpago_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdpago.CellDoubleClick
        Dim indexito As Integer = grdpago.CurrentRow.Index

        cbotipo.Text = grdpago.Rows(indexito).Cells(0).Value.ToString()
        cbobanco.Text = grdpago.Rows(indexito).Cells(1).Value.ToString()
        txtnumref.Text = grdpago.Rows(indexito).Cells(2).Value.ToString()
        txtmonto.Text = grdpago.Rows(indexito).Cells(3).Value.ToString()
        dtpFecha_P.Value = grdpago.Rows(indexito).Cells(4).Value.ToString()

        grdpago.Rows.Remove(grdpago.Rows(indexito))

        Dim pagos As Double = 0
        For wy As Integer = 0 To grdpago.Rows.Count - 1
            pagos = pagos + CDbl(grdpago.Rows(wy).Cells(3).Value.ToString)
        Next

        txtMontoP.Text = FormatNumber(pagos, 2)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim tpago As String = cbotpago.Text
        Dim banco As String = cbobanco.Text
        Dim refe As String = txtnumref.Text
        Dim monto As Double = FormatNumber(txtmonto.Text, 2)
        Dim fecha As String = Format(dtpFecha_P.Value, "dd/MM/yyyy")
        Dim comentario As String = txtComentarioPago.Text
        Dim cuentar As String = cboCuentaRecepcion.Text
        Dim bancorep As String = cboBancoRecepcion.Text

        grdpago.Rows.Add(tpago, banco, refe, monto, fecha, comentario, cuentar, bancorep)
        grdpago.Refresh()

        Dim pagos As Double = 0
        For wy As Integer = 0 To grdpago.Rows.Count - 1
            pagos = pagos + CDbl(grdpago.Rows(wy).Cells(3).Value.ToString)
        Next

        txtMontoP.Text = FormatNumber(pagos, 2)
        cbotpago.Text = ""
        cbobanco.Text = ""
        txtnumref.Text = ""
        txtmonto.Text = "0.00"
        lblsaldo_monedero.Visible = False
        txtsaldo_monedero.Text = ""
        txtsaldo_monedero.Visible = False
        dtpFecha_P.Value = Date.Now
        cbotpago.Focus().Equals(True)

        txtComentarioPago.Text = ""
        cboCuentaRecepcion.Text = ""
        cboCuentaRecepcion.Text = ""
    End Sub

    'Botones
    Private Sub btncomentario_Click(sender As Object, e As EventArgs) Handles btncomentario.Click
        If grdcaptura.Rows.Count = 0 Then
            MsgBox("Agrega productos a la venta para asignar un comentario.", vbInformation + vbOK, "Delsscom Control Negocios Pro")
            Exit Sub
        End If

        boxcomentario.Visible = True
        txtcomentario.Focus().Equals(True)
    End Sub

    Private Sub btnnuevo_Click(sender As Object, e As EventArgs) Handles btnnuevo.Click
        Timer1.Stop()
        Me.Text = "Ventas (1)"
        txttel.Text = ""
        cboNombre.Text = ""
        cboNombre.Items.Clear()
        cbonombretag = ""
        txtdireccion.Text = ""
        txtcant_productos.Text = "0"

        txtMonedero.Text = ""
        lblmonedero.BackColor = Color.White
        cboDomi.Text = ""
        cboDomi.Visible = False
        Label1.Visible = False
        txtadeuda.Text = "0.00"
        txtadeuda.Visible = False
        Label18.Visible = False
        txtcredito.Text = "0.00"
        txtcredito.Visible = False
        Label20.Visible = False
        txtMonedero.ReadOnly = False
        txtafavor.Text = "0.00"
        txtafavor.Visible = False
        Label17.Visible = False
        cbotipo.Text = "Lista"
        cbotipo.Visible = False
        Label19.Visible = False
        btndevo.Text = "DEVOLUCIÓN"
        lblusuario.Text = ""
        cbocomisionista.Items.Clear()
        cbocomisionista.Text = ""
        dtpFecha_E.Value = Date.Now
        lbldevo.Visible = False
        cbonota.Text = ""
        cbonota.Visible = False
        picProd.Image = Nothing
        txtcontraseña.Text = ""
        lblfolio.Text = ""
        lblNumCliente.Text = "MOSTRADOR"

        cbocodigo.Items.Clear()
        cbocodigo.Text = ""
        cbodesc.Items.Clear()
        cbodesc.Text = ""
        txtunidad.Text = ""
        txtcantidad.Text = ""
        txtprecio.Text = "0.00"
        txtprecio.Tag = 0
        txttotal.Text = "0.00"
        txtexistencia.Text = ""
        cboSerie.Text = ""
        cboSerie.Tag = 0
        txtfechacad.Text = ""
        txtubicacion.Text = ""
        grdcaptura.Rows.Clear()
        grdcaptura.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
        grdcaptura.DefaultCellStyle.SelectionForeColor = Color.Blue
        txtcoment.Text = ""
        txtcoment.Visible = False

        txtsaldo_monedero.Text = "0.00"
        txtsaldo_monedero.Visible = False
        lblsaldo_monedero.Visible = False
        cbotpago.Enabled = True
        cbotpago.Items.Clear()
        cbotpago.Text = ""
        cbobanco.Enabled = True
        cbobanco.Items.Clear()
        cbobanco.Text = ""
        txtnumref.Enabled = True
        txtnumref.Text = ""
        txtmonto.Enabled = True
        txtmonto.Text = ""
        dtpFecha_P.Enabled = True
        Button9.Enabled = True
        grdpago.Enabled = True
        grdpago.Rows.Clear()

        txtdescuento1.Text = "0"
        txtdescuento1.ReadOnly = False
        txtefectivo.Text = "0.00"
        txtefectivo.ReadOnly = False
        txtResta.Text = "0.00"
        txtResta.ReadOnly = False
        txtCambio.Text = "0.00"
        txtCambio.ReadOnly = False

        txtMontoP.Text = "0.00"
        txtSubTotal.Text = "0.00"
        txtdescuento2.Text = "0.00"
        txtPagar.Text = "0.00"

        btnventa.Enabled = True
        Button3.Enabled = True

        lblentrega.Visible = False
        dtpFecha_E.Visible = False
        Entrega = False

        DondeVoy = ""
        renglon = 0
        modo_caja = ""
        Anti = ""
        Promo = False
        lblfecha.Text = Date.Now
        dtpFecha_E.Value = Date.Now
        dtpFecha_P.Value = Date.Now
        txtfechacad.Text = ""
        MyIdCliente = 0
        modo_caja = DatosRecarga("Modo")
        If modo_caja = "MOSTRADOR" Then
            txtefectivo.ReadOnly = True
            cboNombre.Text = "MOSTRADOR"
            cboNombre.Enabled = False
        Else
            txtefectivo.ReadOnly = False
        End If
        MYFOLIO = 0
        cbotipo.Text = "Lista"
        txtdia.Text = Weekday(Date.Now)
        txtResta.Text = "0.00"
        txtcotped.Text = ""
        Timer1.Start()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        VieneDe_Folios = "frmVentas_Series"
        frmConsultaNotas.Show()
        frmConsultaNotas.BringToFront()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        frmModEntregas.Show()
        frmModEntregas.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmMonederos.Show()
        frmMonederos.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmAbonoNotas.Show()
        frmAbonoNotas.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmPasa_Corte.Show()
    End Sub

    'Cotizaciones
    Public Sub Insert_Cotizacion()
        Dim oData As New ToolKitSQL.oledbdata
        Dim sSql As String = ""
        Dim a_cnn As OleDb.OleDbConnection = New OleDb.OleDbConnection
        Dim sInfo As String = ""
        Dim dr As DataRow = Nothing
        Dim dt As New DataTable

        Dim my_folio As Integer = 0
        Dim MyStatus As String = ""
        Dim tel_cliente As String = ""

        With oData
            If .dbOpen(a_cnn, Direcc_Access, sInfo) Then
                .runSp(a_cnn, "delete from CotPedDetalle", sInfo) : sInfo = ""
                .runSp(a_cnn, "delete from CotPed", sInfo) : sInfo = ""

                If cboNombre.Text <> "" Then
                    cnn3.Close() : cnn3.Open()
                    cmd3 = cnn3.CreateCommand
                    cmd3.CommandText =
                        "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                    rd3 = cmd3.ExecuteReader
                    If rd3.HasRows Then
                        If rd3.Read Then
                            tel_cliente = rd3("Telefono").ToString()
                        End If
                    End If
                    rd3.Close() : cnn3.Close()
                End If

                If .runSp(a_cnn, "insert into CotPed(idCliente,Nombre,Direccion,Totales,Descuento,ACuenta,Resta,Usuario,FVenta,HVenta,Status,MontoSnDesc,Comentario,Telefono) values(0,'" & cboNombre.Text & "','" & txtdireccion.Text & "',0,0,0,0,'" & lblusuario.Text & "',#" & FormatDateTime(Date.Now, DateFormat.ShortDate) & "#,#" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "#,'COTIZACION',0,'" & txtcomentario.Text & "','" & tel_cliente & "')", sInfo) Then
                    sInfo = ""
                Else
                    MsgBox(sInfo)
                End If

                If .getDr(a_cnn, dr, "select MAX(Folio) from CotPed", sInfo) Then
                    my_folio = dr(0).ToString()
                End If

                Dim cod_temp As String = ""

                Dim ruta_imagen As String = ""



                For pipo As Integer = 0 To grdcaptura.Rows.Count - 1
                    Dim codigo As String = grdcaptura.Rows(pipo).Cells(0).Value.ToString()
                    If codigo = "" Then GoTo doorcita

                    'Traa la imgen del producto para la cotización
                    If File.Exists("C:\ControlNegociosPro\ProductosImg\" & codigo & ".jpg") Then
                        ruta_imagen = "C:\ControlNegociosPro\ProductosImg\" & codigo & ".jpg"
                    Else
                        If varrutabase <> "" Then
                            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ProductosImg\" & codigo & ".jpg") Then
                                ruta_imagen = "\\" & varrutabase & "\ControlNegociosPro\ProductosImg\" & codigo & ".jpg"
                            Else
                                ruta_imagen = ""
                            End If
                        Else
                            ruta_imagen = ""
                        End If
                    End If

                    Dim nombre As String = grdcaptura.Rows(pipo).Cells(1).Value.ToString()
                    Dim unidad As String = grdcaptura.Rows(pipo).Cells(2).Value.ToString()
                    Dim cantidad As Double = grdcaptura.Rows(pipo).Cells(3).Value.ToString()
                    Dim precio_original As Double = grdcaptura.Rows(pipo).Cells(4).Value.ToString()
                    Dim total_original As Double = precio_original * cantidad

                    If codigo <> "" Then
                        cod_temp = codigo
                        If .runSp(a_cnn, "insert into CotPedDetalle(Folio,Codigo,Nombre,Cantidad,UVenta,Precio_Original,Total_Original,Descuento_Unitario,Descuento_Total,Precio_Descuento,Total_Descuento,Comisionista,Comentario,Ruta_Imagen) values(" & my_folio & ",'" & codigo & "','" & nombre & "'," & cantidad & ",'" & unidad & "'," & precio_original & "," & total_original & ",0,0,0,0,'','','" & ruta_imagen & "')", sInfo) Then
                            sInfo = ""
                        Else
                            MsgBox(sInfo)
                        End If
                    End If
                    Continue For
doorcita:
                    If grdcaptura.Rows(pipo).Cells(1).Value.ToString() <> "" Then
                        'Es comentario
                        .runSp(a_cnn, "update CotPedDetalle set Comentario='" & grdcaptura.Rows(pipo).Cells(1).Value.ToString() & "' where Codigo='" & cod_temp & "' and Folio=" & my_folio, sInfo)
                        sInfo = ""
                    End If
                Next
                a_cnn.Close()
            End If
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Text = "Cotización Series"
        If Me.Text = "Ventas Series" Then
            btnnuevo.PerformClick()


            btndevo.Enabled = False
            btnventa.Enabled = False
            Button3.Enabled = True

            txtefectivo.ReadOnly = True
            txtCambio.ReadOnly = True
            txtResta.ReadOnly = True
            cbotpago.Enabled = False
            cbobanco.Enabled = False
            txtnumref.Enabled = False
            txtmonto.Enabled = False
            dtpFecha_P.Enabled = False
            Button9.Enabled = False
            grdpago.Enabled = False
            cboNombre.Focus().Equals(True)
        ElseIf Me.Text = "Cotización (1)" Then
            If grdcaptura.Rows.Count = 0 Then MsgBox("Captura productos para guardar la cotización.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cbocodigo.Focus().Equals(True) : Exit Sub
            If lblusuario.Text = "" Then MsgBox("Escribe tu contraseña para continuar con la cotización.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : txtcontraseña.Focus().Equals(True) : DondeVoy = "Cotiza" : Exit Sub
            If cboNombre.Text = "" Then MsgBox("Escribe/Selecciona un cliente para realizar la cotización.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : cboNombre.Focus().Equals(True) : Exit Sub

            Dim VarUser As String = "", VarIdUsuario As Integer = 0
            Dim DsctoProd As Single = 0, PorcentDscto As Single = 0, DsctoProdTod As Single = 0
            Dim CveLte As Double = 0
            Dim IdCliente As Integer = 0
            Dim ConteoXD As Double = 0

            Dim MySubtotal As Double = 0

            If cboNombre.Text = "" Then
                cboNombre.Text = "PUBLICO EN GENERAL"
            End If

            'Guarda la cotización
            Try
                cnn1.Close() : cnn1.Open()

                For i As Integer = 0 To grdcaptura.Rows.Count - 1
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & grdcaptura.Rows(i).Cells(0).Value.ToString() & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MySubtotal = MySubtotal + (CDbl(grdcaptura.Rows(i).Cells(6).Value.ToString) / (1 + CDbl(rd1(0).ToString)))
                        End If
                    End If
                    rd1.Close()
                Next

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select * from Usuarios where Clave='" & txtcontraseña.Text & "'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        lblusuario.Text = rd1("Alias").ToString
                        VarUser = rd1("Alias").ToString
                        VarIdUsuario = rd1("IdEmpleado").ToString
                    End If
                Else
                    MsgBox("Escribe/Revisa tu contraseña para continuar.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    cnn1.Close()
                    DondeVoy = "Cotiza"
                    txtcontraseña.Focus().Equals(True) : Exit Sub
                End If
                rd1.Close()

                Dim Cliente As String = cboNombre.Text

                If cboNombre.Text = "" Then
                    IdCliente = 0
                    Cliente = ""
                Else
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from Clientes where Nombre='" & cboNombre.Text & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            IdCliente = rd1("Id").ToString
                        End If
                    Else
                        IdCliente = 0
                    End If
                    rd1.Close()
                End If

                'Permiso para realizar cotizaciones
                Dim per_venta As Boolean = False

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select * from Permisos where IdEmpleado= " & VarIdUsuario
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        per_venta = rd1("Vent_Coti").ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()

                If Not (per_venta) Then
                    MsgBox("No cuentas con permiso para realizar cotizaciones.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                    Exit Sub
                End If

                If MsgBox("¿Deseas guardar los datos de esta cotización?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbCancel Then cnn1.Close() : Exit Sub

                Dim SubTotal As Double = 0
                Dim IVA_Vent As Double = 0
                Dim Total_Ve As Double = 0

                IVA_Vent = CDbl(txtPagar.Text) - MySubtotal
                SubTotal = MySubtotal
                Total_Ve = txtPagar.Text
                MYFOLIO = 0

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "insert into CotPed(IdCliente,Cliente,Direccion,Subtotal,IVA,Totales,ACuenta,Resta,Usuario,Fecha,Hora,Status,Tipo,Comentario,IP) values(" & IdCliente & ",'" & cboNombre.Text & "',''," & SubTotal & "," & IVA_Vent & "," & Total_Ve & ",0,0,'" & lblusuario.Text & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & Format(Date.Now, "HH:mm:ss") & "','','COTIZACION','" & cboimpresion.Text & "','" & dameIP2() & "')"
                cmd1.ExecuteNonQuery()

                Do Until MYFOLIO <> 0
                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select MAX(Folio) from CotPed where Tipo='COTIZACION' and IP='" & dameIP2() & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MYFOLIO = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()
                Loop
                cnn1.Close()

                cnn1.Close() : cnn1.Open()
                For T As Integer = 0 To grdcaptura.Rows.Count - 1
                    If grdcaptura.Rows(T).Cells(0).Value.ToString = "" Then GoTo Door

                    Dim mycode As String = grdcaptura.Rows(T).Cells(0).Value.ToString
                    Dim mydesc As String = grdcaptura.Rows(T).Cells(1).Value.ToString
                    Dim myunid As String = grdcaptura.Rows(T).Cells(2).Value.ToString
                    Dim mycant As Double = grdcaptura.Rows(T).Cells(3).Value.ToString
                    Dim myprecio As Double = grdcaptura.Rows(T).Cells(4).Value.ToString
                    Dim caduca As String = grdcaptura.Rows(T).Cells(9).Value.ToString
                    Dim lote As String = grdcaptura.Rows(T).Cells(8).Value.ToString
                    Dim mytotal As Double = FormatNumber(mycant * myprecio, 2)

                    Dim ieps As Double = grdcaptura.Rows(T).Cells(10).Value.ToString
                    Dim tasaieps As Double = grdcaptura.Rows(T).Cells(11).Value.ToString

                    Dim MyMCD As Double = 0
                    Dim MyIVA As Double = 0
                    Dim MyDepto As String = ""
                    Dim MyGrupo As String = ""
                    Dim Pre_Comp As Double = 0

                    Dim MyCostVUE As Double = 0
                    Dim MyProm As Double = 0

                    Dim myprecioS As Double = 0
                    Dim mytotalS As Double = 0

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select IVA from Productos where Codigo='" & mycode & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyIVA = rd1(0).ToString
                        End If
                    End If
                    rd1.Close()

                    myprecioS = FormatNumber(myprecio / (1 + MyIVA), 6)
                    mytotalS = FormatNumber(mytotal / (1 + MyIVA), 6)

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from Productos where Codigo='" & mycode & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            MyCostVUE = 0
                            MyProm = 0
                            MyDepto = rd1("Departamento").ToString
                            MyGrupo = rd1("Grupo").ToString
                            MyMCD = rd1("MCD").ToString
                            If CStr(rd1("Departamento").ToString) = "SERVICIOS" Then
                                rd1.Close() : cnn1.Close()
                                GoTo Door
                            End If
                        End If
                    End If
                    rd1.Close()

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                    "select * from Productos where Codigo='" & Strings.Left(mycode, 6) & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            If rd1("Departamento").ToString <> "SERVICIOS" Then
                                Pre_Comp = rd1("PrecioCompra").ToString
                                MyCostVUE = Pre_Comp * (mycant / MyMCD)
                            End If
                        End If
                    End If
                    rd1.Close()

Door:
                    If grdcaptura.Rows(T).Cells(0).Value.ToString <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                       "insert into CotPedDet(Folio,Codigo,Nombre,Cantidad,Unidad,CostoV,Precio,Total,PrecioSIVA,TotalSIVA,Fecha,Usuario,Depto,Grupo,CostVR,Tipo) values(" & MYFOLIO & ",'" & mycode & "','" & mydesc & "'," & mycant & ",'" & myunid & "'," & MyCostVUE & "," & myprecio & "," & mytotal & "," & myprecioS & "," & mytotalS & ",'" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "','" & lblusuario.Text & "','" & MyDepto & "','" & MyGrupo & "','','COTIZACION')"
                        cmd1.ExecuteNonQuery()
                    End If

                    If grdcaptura.Rows(T).Cells(0).Value.ToString = "" And grdcaptura.Rows(T).Cells(1).Value.ToString <> "" Then
                        cmd1 = cnn1.CreateCommand
                        cmd1.CommandText =
                        "update CotPedDet set CostVR='" & grdcaptura.Rows(T).Cells(1).Value.ToString & "' where CostVR='' and Tipo='COTIZACION' and Codigo='" & mycode & "' and Folio=" & MYFOLIO
                        cmd1.ExecuteNonQuery()
                    End If
                Next
                cnn1.Close()

                '----------------------------------------------------------AGREGAR CLIENTES DESDE VENTAS---------------------------------------------------------------------

                Dim agregarcli As Integer = 0

                cnn1.Close() : cnn1.Open()
                cnn2.Close() : cnn2.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText = "SELECT Ad_Cli FROM Permisos WHERE IdEmpleado=" & VarIdUsuario
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then

                        agregarcli = rd1(0).ToString

                        If agregarcli = "1" Then

                            If cboNombre.Text <> "" Then

                                cmd2 = cnn2.CreateCommand
                                cmd2.CommandText = "Select * from Clientes where Nombre='" & cboNombre.Text & "'"
                                rd2 = cmd2.ExecuteReader
                                If rd2.Read Then
                                    rd2.Close()
                                Else
                                    rd2.Close()
                                    cmd2 = cnn2.CreateCommand
                                    cmd2.CommandText = "Insert into Clientes(Nombre,RazonSocial,Telefono,Tipo) values('" & cboNombre.Text & "','" & cboNombre.Text & "','" & txttel.Text & "','Lista')"
                                    If cmd2.ExecuteNonQuery() Then
                                        MsgBox("Cliente registrado correctamente", vbInformation + vbOKOnly, "Delsscom® Control Negocios Pro")
                                    End If
                                End If
                                rd2.Close()
                            End If

                        Else
                        End If

                    End If
                End If
                cnn2.Close()
                rd1.Close()
                cnn1.Close()

                Dim Imprime As Boolean = False
                Dim TPrint As String = ""
                Dim Imprime_En As String = ""
                Dim Impresora As String = ""
                Dim Tamaño As String = ""
                Dim Pasa_Print As Boolean = False

                Dim pide As String = "", contra As String = txtcontraseña.Text, usu As String = lblusuario.Text

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NoPrint from Ticket"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Imprime = rd1(0).ToString
                    End If
                End If
                rd1.Close() : cnn1.Close()

                Dim img_pdf As String = DatosRecarga("IMG_PDF")

                If (Imprime) Then
                    If MsgBox("¿Deseas imprimir esta cotización?", vbInformation + vbOKCancel, "Delsscom Control Negocios Pro") = vbOK Then
                        Pasa_Print = True
                    Else
                        Pasa_Print = False
                    End If
                Else
                    Pasa_Print = True
                End If

                If Pasa_Print = True Then

                End If
                TPrint = cboimpresion.Text

                cnn1.Close() : cnn1.Open()

                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                    "select NotasCred from Formatos where Facturas='TamImpre'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        Tamaño = rd1(0).ToString
                    End If
                End If
                rd1.Close()

                If TPrint = "PDF - CARTA" Then

                    Panel6.Visible = True
                    My.Application.DoEvents()
                    Insert_Cotizacion()
                    If img_pdf = "1" Then
                        PDF_Cotizacion_Img()
                    Else
                        PDF_Cotizacion()
                    End If
                    Panel6.Visible = False
                    My.Application.DoEvents()

                Else

                    cmd1 = cnn1.CreateCommand
                    cmd1.CommandText =
                        "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='" & TPrint & "'"
                    rd1 = cmd1.ExecuteReader
                    If rd1.HasRows Then
                        If rd1.Read Then
                            Impresora = rd1(0).ToString()
                        End If
                    Else
                        If TPrint = "MEDIA CARTA" Then
                            cnn2.Close() : cnn2.Open()

                            cmd2 = cnn2.CreateCommand
                            cmd2.CommandText =
                                "select Impresora from RutasImpresion where Equipo='" & ObtenerNombreEquipo() & "' and Tipo='CARTA'"
                            rd2 = cmd2.ExecuteReader
                            If rd2.HasRows Then
                                If rd2.Read Then
                                    Impresora = rd2(0).ToString()
                                End If
                            Else
                                MsgBox("No tienes una impresora configurada para imprimir en formato " & TPrint & ".", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro")
                                rd2.Close() : cnn2.Close()
                                rd1.Close() : cnn1.Close()

                                cnn1.Close() : cnn1.Open()
                                cmd1 = cnn1.CreateCommand
                                cmd1.CommandText =
                                "select NotasCred from Formatos where Facturas='PedirContra'"
                                rd1 = cmd1.ExecuteReader
                                If rd1.HasRows Then
                                    If rd1.Read Then
                                        pide = rd1(0).ToString
                                    End If
                                End If
                                rd1.Close()
                                cnn1.Close()

                                btnnuevo.PerformClick()
                                If pide = "1" Then
                                    lblusuario.Text = usu
                                    txtcontraseña.Text = contra
                                End If
                                MYFOLIO = 0
                                cbodesc.Focus().Equals(True)
                                Exit Sub
                            End If
                            rd2.Close() : cnn2.Close()
                        End If
                    End If
                    rd1.Close() : cnn1.Close()
                End If

                If TPrint = "TICKET" Then
                    If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Coti() : Exit Sub
                    If Tamaño = "80" Then
                        pCotiza80.PrinterSettings.PrinterName = Impresora
                        pCotiza80.Print()
                    End If
                    If Tamaño = "58" Then
                        pCotiza58.PrinterSettings.PrinterName = Impresora
                        pCotiza58.Print()
                    End If
                Else
                    If TPrint = "CARTA" Then
                        If Impresora = "" Then MsgBox("No se encontró una impresora.", vbInformation + vbOKOnly, "Delsscom Control Negocios Pro") : Termina_Error_Coti() : Exit Sub
                        pCotizaCarta.PrinterSettings.PrinterName = Impresora
                        pCotizaCarta.Print()
                    End If
                End If

                cnn1.Close() : cnn1.Open()
                cmd1 = cnn1.CreateCommand
                cmd1.CommandText =
                "select NotasCred from Formatos where Facturas='PedirContra'"
                rd1 = cmd1.ExecuteReader
                If rd1.HasRows Then
                    If rd1.Read Then
                        pide = rd1(0).ToString
                    End If
                End If
                rd1.Close()
                cnn1.Close()

                btnnuevo.PerformClick()
                If pide = "1" Then
                    lblusuario.Text = usu
                    txtcontraseña.Text = contra
                End If
                MYFOLIO = 0
                cbodesc.Focus().Equals(True)

            Catch ex As Exception
                MessageBox.Show(ex.ToString())
                Me.Text = "Ventas (1)"
                btnnuevo.PerformClick()
                cnn1.Close()
            End Try
        End If

    End Sub

    Public Sub PDF_Cotizacion()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo

        'Nombre del CrystalReport
        Dim FileNta As New Cotización

        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Dim PieNota As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie2 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    PieNota = rd1(0).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & MYFOLIO & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txtPagar.Text) & "'"

        If PieNota <> "" Then
            FileNta.DataDefinition.FormulaFields("pieNota").Text = "'" & PieNota & "'"          'Pie de nota
        End If

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
        End If
    End Sub

    Public Sub PDF_Cotizacion_Img()
        Dim root_name_recibo As String = ""
        Dim FileOpen As New ProcessStartInfo

        'Nombre del CrystalReport
        Dim FileNta As New Cotización_Img

        Dim strServerName As String = Application.StartupPath
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        crea_ruta(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\")
        root_name_recibo = My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf"

        If File.Exists(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
            File.Delete(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
        End If

        If varrutabase <> "" Then
            If File.Exists("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf") Then
                File.Delete("\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
            End If
        End If

        With crConnectionInfo
            .ServerName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .DatabaseName = My.Application.Info.DirectoryPath & "\DL1.mdb"
            .UserID = ""
            .Password = "jipl22"
        End With

        CrTables = FileNta.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        Dim PieNota As String = ""

        Try
            cnn1.Close() : cnn1.Open()
            cmd1 = cnn1.CreateCommand
            cmd1.CommandText =
                "select Pie2 from Ticket"
            rd1 = cmd1.ExecuteReader
            If rd1.HasRows Then
                If rd1.Read Then
                    PieNota = rd1(0).ToString()
                End If
            End If
            rd1.Close()
            cnn1.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            cnn1.Close()
        End Try

        FileNta.SetDatabaseLogon("", "jipl22")
        FileNta.DataDefinition.FormulaFields("Folio").Text = "'" & MYFOLIO & "'"
        FileNta.DataDefinition.FormulaFields("Usuario").Text = "'" & lblusuario.Text & "'"
        FileNta.DataDefinition.FormulaFields("conLetra").Text = "'" & convLetras(txtPagar.Text) & "'"

        If PieNota <> "" Then
            FileNta.DataDefinition.FormulaFields("pieNota").Text = "'" & PieNota & "'"          'Pie de nota
        End If

        FileNta.Refresh()
        FileNta.Refresh()
        FileNta.Refresh()
        If File.Exists(root_name_recibo) Then
            File.Delete(root_name_recibo)
        End If

        Try
            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

            CrDiskFileDestinationOptions.DiskFileName = root_name_recibo '"c:\crystalExport.pdf"
            CrExportOptions = FileNta.ExportOptions
            With CrExportOptions
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With

            FileNta.Export()
            FileOpen.UseShellExecute = True
            FileOpen.FileName = root_name_recibo

            My.Application.DoEvents()

            If MsgBox("¿Deseas abrir el archivo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Process.Start(FileOpen)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileNta.Close()

        If varrutabase <> "" Then
            System.IO.File.Copy(My.Application.Info.DirectoryPath & "\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf", "\\" & varrutabase & "\ControlNegociosPro\ARCHIVOSDL1\COTIZACIONES\" & MYFOLIO & ".pdf")
        End If
    End Sub

    Public Sub Termina_Error_Coti()
        Dim pide As String = "", contra As String = txtcontraseña.Text, usu As String = lblusuario.Text

        cnn1.Close() : cnn1.Open()
        cmd1 = cnn1.CreateCommand
        cmd1.CommandText =
        "select NotasCred from Formatos where Facturas='PedirContra'"
        rd1 = cmd1.ExecuteReader
        If rd1.HasRows Then
            If rd1.Read Then
                pide = rd1(0).ToString
            End If
        End If
        rd1.Close()
        cnn1.Close()

        btnnuevo.PerformClick()
        If pide = "1" Then
            lblusuario.Text = usu
            txtcontraseña.Text = contra
        End If
        MYFOLIO = 0
        cbodesc.Focus().Equals(True)
    End Sub
End Class